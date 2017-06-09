// ***********************************************************
// 病案质控系统患者列表显示窗口.
// Creator:YangMingkun  Date:2009-11-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Controls;
using Heren.Common.Controls.VirtualTreeView;
using MedDocSys.QCEngine.TimeCheck;

using MedQCSys.Dialogs;
using MedQCSys.Utility;
using MedQCSys.Controls.PatInfoList;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Core;
using System.Linq;

namespace MedQCSys.DockForms
{
    public partial class PatientListForm : DockContentBase
    {
        //用于记录用户最近一次选择的患者就诊信息
        private EMRDBLib.PatVisitInfo m_lastSelectedPatVisitLog = null;

        //用于对患者列表排序的委托
        private Comparison<EMRDBLib.PatVisitInfo> m_comparison = null;

        /// <summary>
        /// 存放检索到的患者就诊信息
        /// </summary>
        private List<EMRDBLib.PatVisitInfo> m_lstPatVisitLog = null;
        /// <summary>
        /// 科室信息
        /// </summary>
        private Hashtable m_htDeptInfo = null;

        //线程状态变更事件定义
        public delegate void UpdateThreadState(string szThrdName, List<EMRDBLib.PatVisitInfo> lstPatVisitLog, EMRDBLib.SearchThreadState threadState);

        public PatientListForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.DockLeft;
            this.DockAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom;
            // Control.CheckForIllegalCrossThreadCalls = false;
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.patInfoList.SuspendLayout();注释此布局逻辑，否侧，patInfoList显示不正确
            this.patSearchPane1.ComboBoxSelectItemChanged += new EventHandler(PatSearchPane1_ComboBoxSelectItemChanged);
            this.patSearchPane1.PatListForm = this;
            //this.patInfoList.PerformLayout();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.patSearchPane1.SetHeight();
        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Invalidate(true);
            this.Update();
            this.patSearchPane1.InitPatSearchType();
        }
        public void ClearPatList()
        {
            if (this.patInfoList.SelectedCard != null)
                this.patInfoList.SelectedCard = null;
            this.patInfoList.ClearPatInfo();
        }

        /// <summary>
        /// 装载指定的患者就诊信息列表
        /// </summary>
        /// <param name="lstPatVisitLogs">患者就诊信息列表</param>
        /// <param name="bClearDate">是否清楚原有数据</param>
        public void LoadPatientVisitList(List<EMRDBLib.PatVisitInfo> lstPatVisitLogs, bool bClearDate)
        {
            if (bClearDate)
                ClearPatList();
            if (lstPatVisitLogs == null || lstPatVisitLogs.Count <= 0)
            {
                this.ShowStatusMessage("未找到相关患者列表");
                return;
            }
            //清空系统中各数据窗口中的数据

            if (this.patSearchPane1.SearchType != EMRDBLib.PatSearchType.Department)
            {
                if (this.m_comparison == null)
                    this.m_comparison = new Comparison<EMRDBLib.PatVisitInfo>(this.ComparePatVisitLog);
                lstPatVisitLogs.Sort(this.m_comparison);
            }

            this.ShowStatusMessage("正在加载患者列表，请稍候...");
            PatInfoCard lastSelectedPatInfoCard = null;
            this.patInfoList.SuspendLayout();
            //更新病情
            this.UpdatePatientsCondition(lstPatVisitLogs);
            //获取三级医生信息
            int currentIndex = 0;
            for (int index = lstPatVisitLogs.Count - 1; index >= 0; index--)
            {
                EMRDBLib.PatVisitInfo patVisitLog = lstPatVisitLogs[index];
                this.SetPatVisitLogDeptName(patVisitLog);
                this.ShowStatusMessage(string.Format("正在加载病人列表{0}/{1}，请稍候...", currentIndex++, lstPatVisitLogs.Count));
                //将患者添加到列表
                PatInfoCard patInfoCard = this.patInfoList.AddPatInfo(patVisitLog);
                //添加科室名称标记
                this.AddDeptNameTag(lstPatVisitLogs, index);

                //加入哈希表
                if (!SystemParam.Instance.PatVisitLogTable.ContainsKey(patVisitLog.PATIENT_ID))
                    SystemParam.Instance.PatVisitLogTable.Add(patVisitLog.PATIENT_ID, patInfoCard);

                //设置缺省选中的患者
                if (lastSelectedPatInfoCard != null)
                    continue;
                if (this.m_lastSelectedPatVisitLog == null)
                    continue;
                if (patVisitLog.PATIENT_ID == this.m_lastSelectedPatVisitLog.PATIENT_ID)
                    lastSelectedPatInfoCard = patInfoCard;
                //只有一人 则直接选中
                if (lstPatVisitLogs.Count == 1)
                    lastSelectedPatInfoCard = patInfoCard;

            }
            this.patInfoList.ResumeLayout(true);
            this.patInfoList.Update();
            this.ShowStatusMessage(null);

            if (lastSelectedPatInfoCard != null && !lastSelectedPatInfoCard.IsDisposed)
                this.patInfoList.SelectedCard = lastSelectedPatInfoCard;

            if (bClearDate)
                this.MainForm.ShowStatusMessage(string.Format("共检索到{0}条数据", lstPatVisitLogs.Count));
            else
                this.MainForm.ShowStatusMessage(null);
            BindDetialInfo(lstPatVisitLogs);
        }

        private void BindDetialInfo(List<PatVisitInfo> lstPatVisitLogs)
        {
            try
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                if (lstPatVisitLogs == null || lstPatVisitLogs.Count == 0)
                    return;
                if (backgroundWorker.IsBusy)
                    return;
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork += M_BackgroundWorker_DoWork;
                backgroundWorker.RunWorkerCompleted += M_BackgroundWorker_RunWorkerCompleted;
                backgroundWorker.RunWorkerAsync(lstPatVisitLogs);

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("后台刷新数据出错。。。", ex);
            }
        }

        private void M_BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<PatVisitInfo> lstPatVisitLogs = e.Result as List<PatVisitInfo>;
            if (lstPatVisitLogs == null)
            {
                this.ShowStatusMessage(null);
                return;
            }
            this.patInfoList.SuspendLayout();
            foreach (var item in this.patInfoList.Controls)
            {
                if (!(item is PatInfoCard))
                    continue;
                PatInfoCard card = (PatInfoCard)item;
                PatVisitInfo pat = lstPatVisitLogs.Find(
                           i => i.PATIENT_ID == card.PatVisitLog.PATIENT_ID && i.VISIT_ID == card.PatVisitLog.VISIT_ID);
                if (pat != null)
                    card.PatVisitLog = pat;
            }
            this.patInfoList.ResumeLayout(false);
            this.patInfoList.Update();

            this.ShowStatusMessage(string.Format("共检索到{0}条数据", lstPatVisitLogs.Count));
        }

        private void M_BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<PatVisitInfo> lstPatVisitLogs = e.Argument as List<PatVisitInfo>;
            if (lstPatVisitLogs == null)
                return;

            //病人病情
            this.UpdatePatientsCondition(lstPatVisitLogs);
            //分页方式分步查 患者400个sql拼接会报错,每次执行最多300个患者
            for (int i = 0; i < lstPatVisitLogs.Count() / 100 + 1; i++)
            {
                var result = lstPatVisitLogs.Skip(i * 100).Take(100).ToList();
                //查询质控结果状态
                MedQCAccess.Instance.GetQCResultStatus(ref result);
                //查询病历得分
                MedQCAccess.Instance.GetPatQCScore(ref result);
                //查询是否手术
                MedQCAccess.Instance.GetPatOperation(ref result);
                //查询患者是否输血
                MedQCAccess.Instance.GetPatBloodTransfusion(ref result);
            }
            e.Result = lstPatVisitLogs;
        }


        /// <summary>
        /// 获取患者三级医生信息
        /// </summary>
        /// <param name="lstPatVisitLogs"></param>
        private void GetPatDoctorInfos(ref List<EMRDBLib.PatVisitInfo> lstPatVisitLogs)
        {
            if (lstPatVisitLogs == null || lstPatVisitLogs.Count == 0)
                return;
            List<EMRDBLib.PatDoctorInfo> lstPatDoctorInfos = new List<EMRDBLib.PatDoctorInfo>();
            Hashtable hashtable = new Hashtable();
            //获取需要查询历史三级医生信息的患者
            for (int index = 0; index < lstPatVisitLogs.Count; index++)
            {
                EMRDBLib.PatVisitInfo item = lstPatVisitLogs[index];
                if (!hashtable.ContainsKey(item.PATIENT_ID + item.VISIT_ID))
                {
                    EMRDBLib.PatDoctorInfo patDoctorInfo = new EMRDBLib.PatDoctorInfo();
                    patDoctorInfo.PatientID = item.PATIENT_ID;
                    patDoctorInfo.VisitID = item.VISIT_ID;
                    hashtable.Add(patDoctorInfo.PatientID + patDoctorInfo.VisitID, patDoctorInfo);
                    lstPatDoctorInfos.Add(patDoctorInfo);
                }
            }
            //获取三级医生信息
            short shRet = PatVisitAccess.Instance.GetPatSanjiDoctors(ref lstPatDoctorInfos);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            if (lstPatVisitLogs == null)
                return;
            foreach (EMRDBLib.PatVisitInfo item in lstPatVisitLogs)
            {
                EMRDBLib.PatDoctorInfo patDoctorInfo = lstPatDoctorInfos.Find(delegate (EMRDBLib.PatDoctorInfo p)
                {
                    if (p.PatientID == item.PATIENT_ID && p.VisitID == item.VISIT_ID)
                        return true;
                    else
                        return false;
                });
                if (patDoctorInfo != null)
                {
                    //item.InchargeDoctor = patDoctorInfo.RequestDoctorName;//经治医生已经通过视图获取了，这里就不用再赋值了
                    item.AttendingDoctor = patDoctorInfo.ParentDoctorName;
                    item.SUPER_DOCTOR = patDoctorInfo.SuperDoctorName;
                }
            }
        }

        /// <summary>
        /// 添加科室名称标记到患者列表中
        /// </summary>
        /// <param name="szDeptName">科室名称</param>
        private void AddDeptNameTag(List<EMRDBLib.PatVisitInfo> lstPatVisitLogs, int index)
        {
            if (lstPatVisitLogs == null || lstPatVisitLogs.Count <= 0)
                return;
            if (index < 0 || index >= lstPatVisitLogs.Count)
                return;

            //注意：下面代码与加载患者列表时的循环顺序是有关系的

            EMRDBLib.PatVisitInfo prevPatVisitLog = null;
            if (index > 0)
                prevPatVisitLog = lstPatVisitLogs[index - 1];
            EMRDBLib.PatVisitInfo currPatVisitLog = lstPatVisitLogs[index];

            if (index == 0 || currPatVisitLog.DEPT_CODE != prevPatVisitLog.DEPT_CODE)
            {
                Label lblDeptName = new Label();
                lblDeptName.BackColor = Color.LightSteelBlue;
                lblDeptName.ForeColor = Color.Black;
                lblDeptName.Height = 24;
                lblDeptName.Width = this.patInfoList.Width;
                lblDeptName.Dock = DockStyle.Top;
                lblDeptName.Text = currPatVisitLog.DEPT_NAME;
                lblDeptName.TextAlign = ContentAlignment.MiddleLeft;
                lblDeptName.Parent = this.patInfoList;
                lblDeptName.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            }
        }


        /// <summary>
        /// 对查询出来的患者列表进行升序排序
        /// </summary>
        /// <param name="patVisitLog1">PatVisitLog对象1</param>
        /// <param name="patVisitLog2">PatVisitLog对象2</param>
        /// <returns>排序结果</returns>
        private int ComparePatVisitLog(EMRDBLib.PatVisitInfo patVisitLog1, EMRDBLib.PatVisitInfo patVisitLog2)
        {
            if (patVisitLog1 == null && patVisitLog2 != null)
                return 1;
            if (patVisitLog1 != null && patVisitLog2 == null)
                return -1;
            if (patVisitLog1 == null && patVisitLog2 == null)
                return 0;
            //对于入院患者列表或死亡患者列表,按科室升序排序
            if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Admission
                || this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Death
                || this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Discharge
                || this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.InHospitalDays
                || this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.OperationPatient
                || this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.SeriousAndCritical
                || this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.SpecialQC)
            {
                int nRet = string.Compare(patVisitLog1.DEPT_NAME, patVisitLog2.DEPT_NAME);
                if (nRet != 0)
                    return nRet;

                //科室相同时按床号排序
                int nBedCode1 = 0;
                int.TryParse(patVisitLog1.BED_CODE, out nBedCode1);
                int nBedCode2 = 0;
                int.TryParse(patVisitLog2.BED_CODE, out nBedCode2);
                return nBedCode1.CompareTo(nBedCode2);
            }

            //对于指定ID的患者列表,则只按住院标识号进行升序排序
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.PatientID
                || this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.InHospitalID)
            {
                int nVisitID1 = 0;
                int.TryParse(patVisitLog1.VISIT_ID, out nVisitID1);
                int nVisitID2 = 0;
                int.TryParse(patVisitLog2.VISIT_ID, out nVisitID2);
                return nVisitID1.CompareTo(nVisitID2);
            }
            return 0;
        }

        /// <summary>
        /// 检查指定的PatVisitLog对象,如果发现科室名称为空,那么更新科室名称
        /// </summary>
        /// <param name="patVisitLog">PatVisitLog</param>
        private void SetPatVisitLogDeptName(EMRDBLib.PatVisitInfo patVisitLog)
        {
            if (patVisitLog == null || !GlobalMethods.Misc.IsEmptyString(patVisitLog.DEPT_NAME))
                return;
            DeptInfo deptInfo = null;
            if (!GlobalMethods.Misc.IsEmptyString(patVisitLog.DEPT_CODE))
            {
                DataCache.Instance.GetDeptInfo(patVisitLog.DEPT_CODE, ref deptInfo);
            }
            else if (!GlobalMethods.Misc.IsEmptyString(patVisitLog.DischargeDeptCode))
            {
                DataCache.Instance.GetDeptInfo(patVisitLog.DischargeDeptCode, ref deptInfo);
            }
            if (deptInfo != null)
                patVisitLog.DEPT_NAME = deptInfo.DEPT_NAME;
        }

        /// <summary>
        /// 刷新选中患者的状态
        /// </summary>
        public void RefreshPatStatus(float fScore)
        {
            if (SystemParam.Instance.PatVisitLogTable == null)
                return;
            Hashtable htPatVisitLog = SystemParam.Instance.PatVisitLogTable;
            if (!htPatVisitLog.Contains(SystemParam.Instance.PatVisitInfo))
                return;
            if (this.patInfoList.SelectedCard == null)
                return;
            //查询质控结果状态
            string szQCResultStatus = GetQCResultStatus();
            SystemParam.Instance.PatVisitInfo.QCResultStatus = szQCResultStatus;
            //设置病案评分
            if (fScore > 0)
                SystemParam.Instance.PatVisitInfo.TotalScore = fScore.ToString();

            this.patInfoList.SelectedCard.PatVisitLog = SystemParam.Instance.PatVisitInfo;
            this.patInfoList.SelectedCard.Refresh();
        }
        public void RefreshDocScore()
        {
            QCScore qcScore = null;
            short shRet = QcScoreAccess.Instance.GetQCScore(SystemParam.Instance.PatVisitInfo.PATIENT_ID, SystemParam.Instance.PatVisitInfo.VISIT_ID, ref qcScore);
            SystemParam.Instance.PatVisitInfo.TotalScore = qcScore.HOS_ASSESS.ToString();
            this.patInfoList.SelectedCard.PatVisitLog = SystemParam.Instance.PatVisitInfo;
            this.patInfoList.SelectedCard.Refresh();
        }
        /// <summary>
        /// 获取患者质控结果
        /// 刷新患者评分时没有刷新质控结果
        /// RefreshPatStatus时实时获取下
        /// </summary>
        /// <returns></returns>
        private string GetQCResultStatus()
        {
            string szQCResultStatus = string.Empty;
            float Score = 0.0f;
            short shRet = MedQCAccess.Instance.GetQCResultStatus(SystemParam.Instance.PatVisitInfo.PATIENT_ID, SystemParam.Instance.PatVisitInfo.VISIT_ID, ref Score, ref szQCResultStatus);

            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("获取质控结果状态失败！");
                return string.Empty;
            }
            return szQCResultStatus;
        }
        /// <summary>
        /// 更新线程的状态
        /// </summary>
        /// <param name="szThrdName">线程名称</param>
        /// <param name="lstMedDocInfo">查询到的文档列表</param>
        /// <param name="st">线程状态</param>
        internal void OnUpdateThreadState(string szThrdName, List<EMRDBLib.PatVisitInfo> lstPatVisitLog, EMRDBLib.SearchThreadState threadState)
        {
            if (this.m_lstPatVisitLog == null)
                this.m_lstPatVisitLog = new List<EMRDBLib.PatVisitInfo>();

            SearchThread searchThread = QueryHelper.Instance.Item(szThrdName);
            searchThread.ThreadState = threadState;
            if (threadState != EMRDBLib.SearchThreadState.finished)
                return;
            if (lstPatVisitLog != null)
                this.m_lstPatVisitLog.AddRange(lstPatVisitLog);
            if (QueryHelper.Instance.IsFinishProgress())
            {
                this.LoadPatientVisitList(this.m_lstPatVisitLog, true);
            }
            if (lstPatVisitLog == null)
            {
                this.CheckThreadProcess();
                return;
            }
            this.CheckThreadProcess();
        }

        private void CheckThreadProcess()
        {
            if (!QueryHelper.Instance.IsFinishProgress())
            {
                if (QueryHelper.Instance.StartNextThread())
                    this.MainForm.ShowStatusMessage("正在读取患者列表，请稍候...");
                return;
            }
            if (this.m_lstPatVisitLog == null || this.m_lstPatVisitLog.Count <= 0)
            {
                this.patInfoList.ClearPatInfo();
                this.MainForm.ShowStatusMessage("没有检索到符合条件的数据");
            }
            else
            {
                this.MainForm.ShowStatusMessage(string.Format("共检索到{0}条数据", this.m_lstPatVisitLog.Count));
            }
            SystemParam.Instance.PatVisitLogList = this.m_lstPatVisitLog;
            this.MainForm.OnPatientListInfoChanged(EventArgs.Empty);
        }

        /// <summary>
        /// 回退已提交病历
        /// </summary>
        private void RollBackSubmitDoc()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            EMRDBLib.MrIndex mrIndex = null;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            short shRet = MrIndexAccess.Instance.GetMrIndex(szPatientID, szVisitID, ref mrIndex);
            if (shRet != SystemData.ReturnValue.OK || mrIndex == null)
                return;
            string status = mrIndex.MR_STATUS;//备份历史病案状态
            mrIndex.MR_STATUS = "O";
            shRet = MrIndexAccess.Instance.UpdateMrStatus(mrIndex);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("更新病案状态失败！", MessageBoxIcon.Warning);
                return;
            }
            //选择通知给哪个医生
            //string szVisitType = MedDocSys.DataLayer.SystemData.VisitType.OP;

            List<MedDocInfo> lstDocInfos = null;
            //shRet = DataAccess.GetPastDocList(szPatientID, szVisitID, ref lstDocInfos);
            shRet = EmrDocAccess.Instance.GetDocList(szPatientID, szVisitID, ref lstDocInfos);
            Dictionary<string, string> doctorDict = new Dictionary<string, string>();
            if (lstDocInfos != null)
            {
                foreach (MedDocInfo doc in lstDocInfos)
                {
                    if (!doctorDict.ContainsKey(doc.CREATOR_ID))
                    {
                        doctorDict.Add(doc.CREATOR_ID, doc.CREATOR_NAME);
                    }
                }
            }
            if (doctorDict.Count > 0)
            {
                //如果系列文档创建者只有一个，不用选择提醒医生
                if (doctorDict.Count == 1)
                {
                    mrIndex.SUBMIT_DOCTOR_ID = lstDocInfos[0].CREATOR_ID;
                }
                else
                {
                    SelectDoctorForm selForm = new SelectDoctorForm(doctorDict);
                    DialogResult result = selForm.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        mrIndex.SUBMIT_DOCTOR_ID = selForm.DoctorID;
                    }
                    else//取消选择提醒医生，那么QCScore复原
                    {
                        mrIndex.MR_STATUS = status;
                        MrIndexAccess.Instance.UpdateMrStatus(mrIndex);
                        return;
                    }
                }
            }

            shRet = PatVisitAccess.Instance.UpdateMrOnLineInfo(szPatientID, szVisitID, "0", mrIndex.SUBMIT_DOCTOR_ID
                , DateTime.Now, 1);
            //操作OperFlag为1时，插入记录，可能主键冲突导致失败，这种情况需要执行更新操作
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
            {
                shRet = PatVisitAccess.Instance.UpdateMrOnLineInfo(szPatientID, szVisitID, "0", mrIndex.SUBMIT_DOCTOR_ID
                               , DateTime.Now, 2);
            }
            if (shRet == SystemData.ReturnValue.OK)
            {
                //新军字一号测试后，不需要改已删除的文档状态
                //shRet = MedQCAccess.Instance.UpdateDocStatus(szPatientID, szVisitID, "0");
                if (shRet == SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.Show("回退已提交病历成功！", MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show("回退已提交病历失败！", MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBoxEx.Show("回退已提交病历失败！", MessageBoxIcon.Warning);
            }
        }

        private void patSearchPane1_StartSearch(object sender, EventArgs e)
        {
            //清空系统中各数据窗口中的数据
            if (this.patInfoList.SelectedCard != null)
                this.patInfoList.SelectedCard = null;

            //仍不等于null说明用户已经取消了患者切换
            if (this.patInfoList.SelectedCard != null)
                return;

            this.ShowStatusMessage("正在读取患者列表，请稍候...");
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.patInfoList.ClearPatInfo();
            if (this.m_lstPatVisitLog == null)
                this.m_lstPatVisitLog = new List<EMRDBLib.PatVisitInfo>();
            this.m_lstPatVisitLog.Clear();
            if (this.m_htDeptInfo == null)
                this.m_htDeptInfo = new Hashtable();
            this.m_htDeptInfo.Clear();
            if (SystemParam.Instance.PatVisitLogTable == null)
                SystemParam.Instance.PatVisitLogTable = new Hashtable();
            else
                SystemParam.Instance.PatVisitLogTable.Clear();

            short shRet = SystemData.ReturnValue.OK;
            List<EMRDBLib.PatVisitInfo> lstPatVisitLogs = null;
            string szDeptCode = null;
            if (!SystemParam.Instance.QCUserRight.ManageAllQC.Value)
                szDeptCode = SystemParam.Instance.UserInfo.DeptCode;

            //科室检索
            if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Department)
            {
                DeptInfo deptInfo = this.patSearchPane1.DeptInfo;

                string szSelectDeptCode = string.Empty;
                if (deptInfo != null)
                {
                    szSelectDeptCode = deptInfo.DEPT_CODE;
                }
                TimeSpan timeSpan = this.patSearchPane1.AdmissionTimeEnd - this.patSearchPane1.AdmissionTimeBegin;
                if (timeSpan.Days <= 30 || patSearchPane1.PatientType == EMRDBLib.PatientType.PatInHosptial)
                {
                    shRet = PatVisitAccess.Instance.GetPatVisitList(szSelectDeptCode, this.patSearchPane1.PatientType, this.patSearchPane1.AdmissionTimeBegin
                       , this.patSearchPane1.AdmissionTimeEnd, ref lstPatVisitLogs);
                }
                else
                {
                    QueryHelper.Instance.ExecuteSearch(szSelectDeptCode, this.patSearchPane1.PatientType, this.patSearchPane1.AdmissionTimeBegin
                        , this.patSearchPane1.AdmissionTimeEnd, this, this.patSearchPane1.SearchType, string.Empty, null);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
            }
            //入院时间检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Admission)
            {
                DateTime dtAdmissionTimeBegin = this.patSearchPane1.AdmissionTimeBegin;
                DateTime dtAdmissionTimeEnd = this.patSearchPane1.AdmissionTimeEnd;
                dtAdmissionTimeBegin = this.patSearchPane1.AdmissionTimeBegin;
                dtAdmissionTimeEnd = this.patSearchPane1.AdmissionTimeEnd;
                TimeSpan timeSpan = dtAdmissionTimeEnd - dtAdmissionTimeBegin;
                if (timeSpan.Days <= 30 || this.patSearchPane1.PatientType == EMRDBLib.PatientType.PatInHosptial)
                {
                    shRet = PatVisitAccess.Instance.GetPatsListByAdmTime(dtAdmissionTimeBegin, dtAdmissionTimeEnd, this.patSearchPane1.PatientType
                        , szDeptCode, ref lstPatVisitLogs);
                }
                else
                {
                    QueryHelper.Instance.ExecuteSearch(string.Empty, this.patSearchPane1.PatientType, dtAdmissionTimeBegin
                        , dtAdmissionTimeEnd, this, this.patSearchPane1.SearchType, string.Empty, null);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
            }
            //出院时间检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Discharge)
            {
                //上线时间长，出院人数较多，
                //因此切换到根据出院时间检索时，全部异步线程
                DateTime dtDischargeTimeBegin = this.patSearchPane1.DischargeTimeBegin;
                DateTime dtDischargeTimeEnd = this.patSearchPane1.DischargeTimeEnd;
                dtDischargeTimeBegin = this.patSearchPane1.DischargeTimeBegin;
                dtDischargeTimeEnd = this.patSearchPane1.DischargeTimeEnd;

                QueryHelper.Instance.ExecuteSearch(string.Empty, this.patSearchPane1.PatientType, dtDischargeTimeBegin
                    , dtDischargeTimeEnd, this, this.patSearchPane1.SearchType, string.Empty, null);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            //危重病历检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.SeriousAndCritical)
            {
                DateTime dtAdmissionTimeBegin = this.patSearchPane1.SerCriAdmissionTimeBegin;
                DateTime dtAdmissionTimeEnd = this.patSearchPane1.SerCriAdmissionTimeEnd;
                TimeSpan timeSpan = dtAdmissionTimeEnd - dtAdmissionTimeBegin;

                //dtAdmissionTimeBegin = DateTime.MinValue;
                //dtAdmissionTimeEnd = DateTime.MaxValue;
                shRet = InpVisitAccess.Instance.GetPatsListBySerious(dtAdmissionTimeBegin, dtAdmissionTimeEnd, szDeptCode, ref lstPatVisitLogs);
                if (lstPatVisitLogs == null || lstPatVisitLogs.Count <= 0)
                {
                    if (SystemConfig.Instance.Get(SystemData.ConfigKey.SERIOUSPATLIST_BY_ADTLOG, false))
                        shRet = InpVisitAccess.Instance.GetPatsListSeriousByAdtLog(dtAdmissionTimeBegin, dtAdmissionTimeEnd, szDeptCode, ref lstPatVisitLogs);
                }
            }
            //死亡病历检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Death)
            {
                DateTime dtDischargeTimeBegin = this.patSearchPane1.DischargeTimeBegin;
                DateTime dtDischargeTimeEnd = this.patSearchPane1.DischargeTimeEnd;
                TimeSpan timeSpan = dtDischargeTimeEnd - dtDischargeTimeBegin;
                if (timeSpan.Days <= 30)
                {
                    shRet = PatVisitAccess.Instance.GetPatsListByDeadTime(dtDischargeTimeBegin, dtDischargeTimeEnd, szDeptCode, ref lstPatVisitLogs);
                }
                else
                {
                    QueryHelper.Instance.ExecuteSearch(string.Empty, this.patSearchPane1.PatientType, dtDischargeTimeBegin
                        , dtDischargeTimeEnd, this, this.patSearchPane1.SearchType, string.Empty, null);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
            }
            //患者住院号检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.InHospitalID)
            {
                string szInpNo = this.patSearchPane1.InHospitalID;
                if (GlobalMethods.Misc.IsEmptyString(szInpNo))
                {
                    this.ShowStatusMessage(null);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                shRet = PatVisitAccess.Instance.GetPatsListByPatient(szInpNo, false, null, szDeptCode, ref lstPatVisitLogs);
            }
            //患者ID检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.PatientID)
            {
                string szPatientID = this.patSearchPane1.PatientID;
                if (GlobalMethods.Misc.IsEmptyString(szPatientID))
                {
                    this.ShowStatusMessage(null);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                shRet = PatVisitAccess.Instance.GetPatsListByPatient(szPatientID, true, null, szDeptCode, ref lstPatVisitLogs);
            }
            //患者姓名检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.PatientName)
            {
                string szPatientName = this.patSearchPane1.PatientName;
                if (GlobalMethods.Misc.IsEmptyString(szPatientName))
                {
                    this.ShowStatusMessage(null);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                shRet = PatVisitAccess.Instance.GetPatsListByPatient(null, false, szPatientName, szDeptCode, ref lstPatVisitLogs);
            }
            //手术患者检索
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.OperationPatient)
            {
                string szPatDeptCode = string.Empty;
                DeptInfo deptInfo = this.patSearchPane1.DeptInfo;
                if (deptInfo != null)
                    szPatDeptCode = deptInfo.DEPT_CODE;
                TimeSpan timeSpan = this.patSearchPane1.AdmissionTimeEnd - this.patSearchPane1.AdmissionTimeBegin;
                if (timeSpan.Days <= 30 || patSearchPane1.PatientType == EMRDBLib.PatientType.PatInHosptial)
                {
                    shRet = PatVisitAccess.Instance.GetPatListByOperation(szPatDeptCode, this.patSearchPane1.PatientType, this.patSearchPane1.AdmissionTimeBegin
                       , this.patSearchPane1.AdmissionTimeEnd, this.patSearchPane1.OperationCode, ref lstPatVisitLogs);
                }
                else
                {
                    QueryHelper.Instance.ExecuteSearch(deptInfo.DEPT_CODE, this.patSearchPane1.PatientType, this.patSearchPane1.AdmissionTimeBegin
                        , this.patSearchPane1.AdmissionTimeEnd, this, this.patSearchPane1.SearchType, this.patSearchPane1.OperationCode, null);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
            }
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.InHospitalDays)
            {
                string szPatDeptCode = string.Empty;
                DeptInfo deptInfo = this.patSearchPane1.DeptInfo;
                if (deptInfo != null)
                    szPatDeptCode = deptInfo.DEPT_CODE;
                if (this.patSearchPane1.InHosptialDays <= 0)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    this.ShowStatusMessage(null);
                    return;
                }
                shRet = PatVisitAccess.Instance.GetPatListByInHospDays(szPatDeptCode, this.patSearchPane1.InHosptialDays, this.patSearchPane1.operatorType
                    , this.patSearchPane1.PatientType, ref lstPatVisitLogs);
            }//已质检病历人员查询
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.CheckedDoc)
            {
                string szCheckerName = string.Empty;
                UserInfo userInfo = this.patSearchPane1.UserInfo;
                if (userInfo != null)
                    szCheckerName = userInfo.Name;

                shRet = PatVisitAccess.Instance.GetPatListByCheckedDoc(szCheckerName, this.patSearchPane1.IssusdTimeBegin, this.patSearchPane1.IssusdTimeEnd
                        , ref lstPatVisitLogs);
            }
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.SpecialQC)
            {
                if (this.patSearchPane1.QcSpecialCheck != null)
                {
                    string szConfigID = this.patSearchPane1.QcSpecialCheck.ConfigID;
                    string szUserID = this.patSearchPane1.IsSpecialAll ? "" : SystemParam.Instance.UserInfo.ID;//仅显示分配的病人再传用户ID
                    shRet = SpecialAccess.Instance.GetPatientList(szConfigID, szUserID, ref lstPatVisitLogs);
                    if (this.m_comparison == null)
                        this.m_comparison = new Comparison<EMRDBLib.PatVisitInfo>(this.ComparePatVisitLog);
                    if (lstPatVisitLogs != null)
                        lstPatVisitLogs.Sort(this.m_comparison);
                }
            }
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.DocType)
            {
                DocTypeInfo docTypeInfo = this.patSearchPane1.DocType;
                if (docTypeInfo == null)
                {
                    MessageBoxEx.Show("请选择文档类型", MessageBoxIcon.Warning);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    this.ShowStatusMessage(null);
                    return;
                }
                TimeSpan timeSpan = this.patSearchPane1.DocTimeEnd - this.patSearchPane1.DocTimeBegin;
                shRet = EmrDocAccess.Instance.GetPatListByDocTypeAndDocTime(docTypeInfo.DocTypeID, this.patSearchPane1.DocTimeBegin, this.patSearchPane1.DocTimeEnd, ref lstPatVisitLogs);

            }
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.MutiVisit)
            {
                TimeSpan timeSpan = this.patSearchPane1.VisitTimeEnd - this.patSearchPane1.VisitTimeBegin;
                if (timeSpan.Days < 0)
                    return;
                shRet = PatVisitAccess.Instance.GetPatListByMutiVisit(this.patSearchPane1.DocTimeBegin, this.patSearchPane1.DocTimeEnd, ref lstPatVisitLogs);
            }
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.TransferPatient)
            {
                TimeSpan timeSpan = this.patSearchPane1.VisitTimeEnd - this.patSearchPane1.VisitTimeBegin;
                if (timeSpan.Days < 0)
                    return;
                shRet = PatVisitAccess.Instance.GetPatListByTransferTime(this.patSearchPane1.DocTimeBegin, this.patSearchPane1.DocTimeEnd, ref lstPatVisitLogs);
            }
            //待复审
            else if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.Review)
            {
                //暂时先按转科查询
                TimeSpan timeSpan = this.patSearchPane1.VisitTimeEnd - this.patSearchPane1.VisitTimeBegin;
                if (timeSpan.Days < 0)
                    return;
                shRet = PatVisitAccess.Instance.GetPatListByDocReview(this.patSearchPane1.DocTimeBegin, this.patSearchPane1.DocTimeEnd, ref lstPatVisitLogs);
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            if (shRet == EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("没有获取到符合条件的患者列表!", MessageBoxIcon.Asterisk);
                return;
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("读取患者列表失败！");
                return;
            }
            this.LoadPatientVisitList(lstPatVisitLogs, true);
            SystemParam.Instance.PatVisitLogList = lstPatVisitLogs;
            this.MainForm.OnPatientListInfoChanged(EventArgs.Empty);
        }

        private void patSearchPane1_StatusMessageChanged(string szStatusMessage)
        {
            this.ShowStatusMessage(szStatusMessage);
        }

        private void PatSearchPane1_ComboBoxSelectItemChanged(object sender, EventArgs e)
        {
            this.patInfoList.ClearPatInfo();
            this.ShowStatusMessage("就绪");
        }

        private void mnuHistoryVisit_Click(object sender, EventArgs e)
        {

            if (this.patInfoList.SelectedCard == null)
                return;
            EMRDBLib.PatVisitInfo patVisitLog = this.patInfoList.SelectedCard.Tag as EMRDBLib.PatVisitInfo;
            if (patVisitLog == null)
                return;

            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            SystemConfig.Instance.Write(SystemData.ConfigKey.DEFAULT_PATIENT_ID, patVisitLog.PATIENT_ID);
            this.patSearchPane1.LastPatientID = patVisitLog.PATIENT_ID;
            this.patSearchPane1.SearchType = EMRDBLib.PatSearchType.PatientID;
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuPreviousView_Click(object sender, EventArgs e)
        {
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.patSearchPane1.LastSearchType != EMRDBLib.PatSearchType.Unknown)
                this.patSearchPane1.SearchType = this.patSearchPane1.LastSearchType;
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuDocumentList_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowDocumentListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuOrderList_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowOrdersListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuVitalSignsGraph_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowVitalSignsGraphForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        private void mnuExamList_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowExamResultListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuTestList_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowTestResultListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuPatientInfo_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowPatientInfoForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuDocumentTime_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowDocumentTimeForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuQuestionList_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowQuestionListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuDiagnosisList_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowDiagnosisResultForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuPatientIndex_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowPatientIndexForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }


        private void mnuDocScore_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowDocScoreForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuRollBackDoc_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            this.RollBackSubmitDoc();
        }

        private void cmenuPatientList_Opening(object sender, CancelEventArgs e)
        {
            this.mnuHistoryVisit.Enabled = false;
            this.mnuDocumentList.Enabled = false;
            this.mnuOrderList.Enabled = false;
            this.mnuExamList.Enabled = false;
            this.mnuTestList.Enabled = false;
            this.mnuDocumentTime.Enabled = false;
            this.mnuQuestionList.Enabled = false;
            this.mnuPreviousView.Enabled = false;
            this.mnuVitalSignsGraph.Visible = false;
            this.mnuIEDoc.Visible = false;
            if (this.patSearchPane1.LastSearchType != EMRDBLib.PatSearchType.Unknown)
                this.mnuPreviousView.Enabled = true;

            if (this.patInfoList.SelectedCard == null)
                return;

            EMRDBLib.PatVisitInfo patVisitLog = this.patInfoList.SelectedCard.PatVisitLog as EMRDBLib.PatVisitInfo;
            if (patVisitLog == null)
                return;

            if (SystemParam.Instance.PatVisitInfo != patVisitLog)
                this.MainForm.OnPatientInfoChanged(EventArgs.Empty);
            SystemParam.Instance.PatVisitInfo = patVisitLog;
            this.m_lastSelectedPatVisitLog = patVisitLog;

            if (SystemParam.Instance.QCUserRight.BrowseDocumentList.Value)
                this.mnuDocumentList.Enabled = true;
            else
                this.mnuDocumentList.Visible = false;

            if (SystemParam.Instance.QCUserRight.BrowseOrdersList.Value)
                this.mnuOrderList.Enabled = true;
            else
                this.mnuOrderList.Visible = false;

            if (SystemParam.Instance.QCUserRight.BrowseExamList.Value)
                this.mnuExamList.Enabled = true;
            else
                this.mnuExamList.Visible = false;

            if (SystemParam.Instance.QCUserRight.BrowseLabTestList.Value)
                this.mnuTestList.Enabled = true;
            else
                this.mnuTestList.Visible = false;

            if (SystemParam.Instance.QCUserRight.BrowseDocumentTime.Value)
                this.mnuDocumentTime.Enabled = true;
            else
                this.mnuDocumentTime.Visible = false;

            if (SystemParam.Instance.QCUserRight.BrowseQCQuestion.Value)
                this.mnuQuestionList.Enabled = true;
            else
                this.mnuQuestionList.Visible = false;
            if (SystemParam.Instance.QCUserRight.BrowsePatientInfo.Value)
                this.mnuPatientInfo.Enabled = true;
            else
            {
                this.mnuPatientInfo.Visible = false;
                this.toolStripSeparator2.Visible = false;
            }
            if (SystemParam.Instance.QCUserRight.BrowseDiagnosisList.Value)
                this.mnuDiagnosisList.Enabled = true;
            else
                this.mnuDiagnosisList.Visible = false;
            if (SystemParam.Instance.QCUserRight.BrowseMRScore.Value
                && SystemParam.Instance.QCUserRight.ManageAllQC.Value)
                this.mnuDocScore.Enabled = true;
            else
                this.mnuDocScore.Visible = false;
            if (SystemParam.Instance.QCUserRight.ManageRollbackSubmitDoc.Value
                && SystemParam.Instance.QCUserRight.ManageAllQC.Value)
            {
                this.mnuRollBackDoc.Enabled = true;
                if (EMRDBLib.SystemParam.Instance.LocalConfigOption.RightClickCallback)
                {
                    this.mnuRollBackDoc.Text = "病历召回";
                }
            }
            else
            {
                this.toolStripSeparator3.Visible = false;
                this.mnuRollBackDoc.Visible = false;
            }

            if (this.patSearchPane1.SearchType != EMRDBLib.PatSearchType.Unknown &&
                this.patSearchPane1.SearchType != EMRDBLib.PatSearchType.PatientID &&
                this.patSearchPane1.SearchType != EMRDBLib.PatSearchType.InHospitalID)
            {
                this.mnuHistoryVisit.Enabled = true;
            }
            //是否显示体温单
            if (SystemParam.Instance.LocalConfigOption.IsShowVitalSignsGraph && SystemParam.Instance.QCUserRight.BrowsTemperatureChart.Value)
                this.mnuVitalSignsGraph.Visible = true;
            //是否显示病案首页
            if (!SystemParam.Instance.LocalConfigOption.IsShowPatientIndex)
            {
                this.mnuPatientIndex.Visible = false;
            }
            //检索方式是专家质控且当前用户有专家质控权限才显示扫描病历
            if (this.patSearchPane1.SearchType == EMRDBLib.PatSearchType.SpecialQC && SystemParam.Instance.QCUserRight.IsSpecialDoc.Value)
            {
                this.mnuIEDoc.Visible = true;
            }
            //新版风格隐藏患者列表右键和病案资料相关的菜单
            if (SystemParam.Instance.LocalConfigOption.IsNewTheme)
            {
                mnuDiagnosisList.Visible = false;
                mnuDocScore.Visible = false;
                mnuDocumentList.Visible = false;
                mnuDocumentTime.Visible = false;
                mnuExamList.Visible = false;
                mnuOrderList.Visible = false;
                mnuPatientIndex.Visible = false;
                mnuPatientInfo.Visible = false;
                mnuTestList.Visible = false;
                mnuVitalSignsGraph.Visible = false;
            }
        }

        private void patInfoList_CardSelectedChanged(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;

            PatInfoCard selectedPatCard = this.patInfoList.SelectedCard;
            if (selectedPatCard == null || selectedPatCard.IsDisposed)
                return;
            this.UpdatePatientCondition(selectedPatCard.PatVisitLog);
            EMRDBLib.PatVisitInfo patVisitLog = selectedPatCard.PatVisitLog;
            if (patVisitLog == null)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.patInfoList.SelectedCard.Invalidate();
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, ref patVisitLog);
            SystemParam.Instance.PatVisitInfo = patVisitLog;
            this.MainForm.OnPatientInfoChanged(EventArgs.Empty);

            this.m_lastSelectedPatVisitLog = patVisitLog;

            if (SystemParam.Instance.LocalConfigOption.IsNewTheme)
            {
                this.MainForm.ShowPatientPageForm(patVisitLog);
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 更新出院患者病情
        /// </summary>
        /// <param name="patVisitLog"></param>
        private void UpdatePatientCondition(EMRDBLib.PatVisitInfo patVisitLog)
        {
            if (patVisitLog == null)
                return;
            if (patVisitLog.DISCHARGE_TIME == patVisitLog.DefaultTime)
                return;
            if (!string.IsNullOrEmpty(patVisitLog.PATIENT_CONDITION))
                return;
            List<EMRDBLib.PatVisitInfo> lstPatVisitLog = new List<EMRDBLib.PatVisitInfo>();
            lstPatVisitLog.Add(patVisitLog);
            PatVisitAccess.Instance.GetOutPatientCondition(lstPatVisitLog);
            if (lstPatVisitLog == null)
                return;
        }

        /// <summary>
        /// 更新患者列表中出院患者的病情
        /// </summary>
        /// <param name="lstPatVisitLog"></param>
        private void UpdatePatientsCondition(List<EMRDBLib.PatVisitInfo> lstPatVisitLog)
        {
            if (lstPatVisitLog == null || lstPatVisitLog.Count == 0)
                return;
            //获取出院患者
            List<EMRDBLib.PatVisitInfo> lstOutPatientVisitLog = new List<EMRDBLib.PatVisitInfo>();
            foreach (EMRDBLib.PatVisitInfo item in lstPatVisitLog)
            {
                if (item.DISCHARGE_TIME == item.DefaultTime)
                    continue;
                lstOutPatientVisitLog.Add(item);
            }
            if (lstOutPatientVisitLog == null || lstOutPatientVisitLog.Count == 0)
                return;
            //更新出院患者病情
            short shRet = PatVisitAccess.Instance.GetOutPatientCondition(lstOutPatientVisitLog);
            if (shRet != SystemData.ReturnValue.OK)
                return;

            foreach (EMRDBLib.PatVisitInfo item in lstOutPatientVisitLog)
            {
                EMRDBLib.PatVisitInfo patVisitLog = lstPatVisitLog.Find(delegate (EMRDBLib.PatVisitInfo p)
                {
                    if (p.VISIT_ID == item.VISIT_ID && p.PATIENT_ID == item.PATIENT_ID)
                        return true;
                    else
                        return false;
                });
                if (patVisitLog != null)
                    patVisitLog.PATIENT_CONDITION = item.PATIENT_CONDITION;
            }
        }

        private void patInfoList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            this.cmenuPatientList.Show(this.patInfoList, e.Location);
        }

        private void patInfoList_CardSelectedChanging(object sender, CancelEventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在准备切换患者信息，请稍候...");

            CancelEventArgs cancelArgs = new CancelEventArgs();
            this.MainForm.OnPatientInfoChanging(cancelArgs);
            if (cancelArgs.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                SystemParam.Instance.PatVisitInfo = null;
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        private void patInfoList_CardMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            PatInfoCard patInfoCard = sender as PatInfoCard;
            if (patInfoCard == null || patInfoCard.IsDisposed)
                return;
            this.cmenuPatientList.Show(patInfoCard, e.Location);
        }


    }
}