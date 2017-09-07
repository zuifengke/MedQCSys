// ***********************************************************
// 病案质控系统质检问题对话框.
// Creator:LiChunYing  Date:2012-02-09
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using MedDocSys.QCEngine.TimeCheck;
using Heren.Common.Report;
using EMRDBLib;
using EMRDBLib.DbAccess;
using System.Linq;
using Heren.MedQC.CheckPoint;
using MedQCSys.Controls;
using Heren.MedQC.Core;

namespace MedQCSys.DockForms
{
    public partial class DocScoreNewForm : DockContentBase
    {
        private bool m_NeedSave = false;
        private List<QcCheckResult> m_lstQcCheckResult;
        /// <summary>
        /// 是否需要保存病案评分
        /// </summary>
        public bool NeedSave
        {
            get { return m_NeedSave; }
            set { m_NeedSave = value; }
        }
        public DocScoreNewForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent, patientPageControl)
        {
            this.InitializeComponent();
            //判断权限
            bool bRight = RightHandler.Instance.HasRight(RightResource.MedRecord_DocScore);
            if (SystemParam.Instance.LocalConfigOption.IsScoreRightShow
                && bRight)
                this.ShowHint = DockState.DockRight;
            else
            {
                this.colItem.Width = 350;
                this.ShowHint = DockState.Document;

            }
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
            this.dgvHummanScore.Font = new Font("宋体", 10.5f);
            this.dgvSystemScore.Font = new Font("宋体", 10.5f);
            foreach (DataGridViewColumn item in this.dgvHummanScore.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn item in this.dgvSystemScore.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvHummanScore.Columns[this.colItem.Index].DefaultCellStyle.WrapMode =
             DataGridViewTriState.True;
            this.dgvHummanScore.IsFreezeGroupHeader = true;
            this.dgvHummanScore.OnBindDataDetail += new Controls.CollapseDataGridView.BindDataDetailHandler(dgvHummanScore_OnBindDataDetail);
        }
        protected override void OnPatientScoreChanged()
        {
            base.OnPatientScoreChanged();
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.NeedRefreshView)
            {

                this.OnRefreshView();
                base.OnRefreshView();
            }
            this.NeedSave = true;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.LoadHummanQcMsgDict();
            this.LoadSystemQcMsgDict();
            this.OnRefreshView();
        }
        public override void OnRefreshView()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在分析人工检测扣分情况...");
            this.LoadHummanScoreInfos();
            this.ShowStatusMessage("正在分析系统检测扣分情况...");
            this.LoadSystemScoreInfos();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        /// <summary>
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            if (this.IsHidden)
                return;
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
            {
                this.OnRefreshView();
                base.OnRefreshView();
            }
        }
        /// <summary>
        /// 停靠窗体变换时重写
        /// </summary>
        protected override void OnActiveContentChanged()
        {
            base.OnActiveContentChanged();
            if (this.IsHidden)
                return;
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this && this.NeedRefreshView)
                this.OnRefreshView();
        }
        /// <summary>
        /// 当患者列表的信息改变时触发
        /// </summary>
        [Description(" 当病历评分保存成功后触发")]
        public event EventHandler HummanScoreSaved = null;
        internal virtual void OnHummanScoreSaved(System.EventArgs e)
        {
            if (this.HummanScoreSaved == null)
                return;
            try
            {
                this.HummanScoreSaved(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DocScoreNewForm.OnHummanScoreSaved", ex);
            }
        }
        /// <summary>
        /// 保存病历内容扣分
        /// </summary>
        private void SaveHummanScore()
        {
            if (this.dgvHummanScore.Rows.Count <= 0)
                return;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            short shRet = SystemData.ReturnValue.OK;
            if (this.m_lstQcCheckResult == null)
                this.m_lstQcCheckResult = new List<QcCheckResult>();
            this.m_lstQcCheckResult.Clear();
            shRet = QcCheckResultAccess.Instance.GetQcCheckResults(SystemParam.Instance.PatVisitInfo.PATIENT_ID, SystemParam.Instance.PatVisitInfo.VISIT_ID, SystemData.StatType.Artificial, ref this.m_lstQcCheckResult);
            for (int index = 0; index < this.dgvHummanScore.Rows.Count; index++)
            {
                DataGridViewRow row = this.dgvHummanScore.Rows[index];
                if (row is CollapseDataGridViewRow)
                {
                    foreach (var item in (row as CollapseDataGridViewRow).Rows)
                    {
                        if (!SaveQcCheckResult(item))
                            continue;
                    }
                }
            }

            //评分明细项保存完毕，保存评分结果到QC_SCORE表
            this.CalHummanScore();
            QCScore qcScore = this.tpHummanScore.Tag as QCScore;
            shRet = QcScoreAccess.Instance.Save(qcScore);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("评分结果保存失败");
                return;
            }

            this.OnHummanScoreSaved(System.EventArgs.Empty);
            if (qcScore.HOS_ASSESS == 100)
            {
                MessageBoxEx.ShowMessage("评分保存成功");
                return;
            }
            else if (MessageBoxEx.ShowConfirm("评分保存成功,是否通知相关医生整改") == DialogResult.OK)
            {
                try
                {
                    Dialogs.ModifyNoticeForm frm = new Dialogs.ModifyNoticeForm();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBoxEx.ShowMessage("操作失败，系统发生异常，请联系管理员", ex.ToString());
                }
            }
        }
        private bool SaveQcCheckResult(DataGridViewRow row)
        {
            short shRet = SystemData.ReturnValue.OK;
            QcMsgDict qcMsgDict = row.Tag as QcMsgDict;
            if (qcMsgDict == null
                || string.IsNullOrEmpty(qcMsgDict.MESSAGE))
                return false;
            if (this.m_lstQcCheckResult == null)
                this.m_lstQcCheckResult = new List<QcCheckResult>();
            QcCheckResult qcCheckResult = this.m_lstQcCheckResult.Where(m => m.MSG_DICT_CODE == qcMsgDict.QC_MSG_CODE).FirstOrDefault();
            if (row.Cells[this.colCheckBox.Index].Value == null)
                return false;
            bool isCheck = bool.Parse(row.Cells[this.colCheckBox.Index].Value.ToString());
            //如果扣分项未勾选并且系统已经有扣分记录，则删除
            if (!isCheck && qcCheckResult != null)
            {
                shRet = QcCheckResultAccess.Instance.Delete(qcCheckResult.CHECK_RESULT_ID);
                if (!string.IsNullOrEmpty(qcCheckResult.MSG_ID))
                    MedicalQcMsgAccess.Instance.Delete(qcCheckResult.MSG_ID);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    //MessageBoxEx.Show(string.Format("第{0}行取消病历扣分信息保存失败！", row.Index + 1), MessageBoxIcon.Error);
                    return false;
                }
            }
            if (!isCheck)
                return false;
            DateTime dtCheckTime = DateTime.Now;
            string szMessgCode = string.Empty;
            if (qcCheckResult == null)
            {
                qcCheckResult = new EMRDBLib.QcCheckResult();
                qcCheckResult.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                qcCheckResult.CHECKER_NAME = SystemParam.Instance.UserInfo.USER_NAME;
                qcCheckResult.CHECKER_ID = SystemParam.Instance.UserInfo.USER_ID;
                qcCheckResult.CHECK_DATE = SysTimeHelper.Instance.Now;
                qcCheckResult.BUG_CLASS = SystemData.BugClass.ERROR;
                qcCheckResult.CHECK_POINT_ID = string.Empty;
                qcCheckResult.CHECK_RESULT_ID = qcCheckResult.MakeID();
                qcCheckResult.CHECK_TYPE = string.Empty;
                qcCheckResult.CREATE_ID = string.Empty;
                qcCheckResult.CREATE_NAME = string.Empty;
                qcCheckResult.DEPT_CODE = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
                qcCheckResult.DEPT_IN_CHARGE = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                qcCheckResult.INCHARGE_DOCTOR = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
                qcCheckResult.INCHARGE_DOCTOR_ID = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR_ID;
                qcCheckResult.DOCTYPE_ID = string.Empty;
                qcCheckResult.DOC_SETID = string.Empty;
                qcCheckResult.DOC_TIME = SysTimeHelper.Instance.DefaultTime;
                qcCheckResult.DOC_TITLE = string.Empty;
                qcCheckResult.ERROR_COUNT = int.Parse(row.Cells[this.colErrorCount.Index].Value.ToString());
                qcCheckResult.ISVETO = false;
                qcCheckResult.MODIFY_TIME = SysTimeHelper.Instance.DefaultTime;
                qcCheckResult.MR_STATUS = SystemParam.Instance.PatVisitInfo.MR_STATUS;
                qcCheckResult.MSG_DICT_CODE = qcMsgDict.QC_MSG_CODE;
                qcCheckResult.MSG_DICT_MESSAGE = qcMsgDict.MESSAGE;
                qcCheckResult.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                qcCheckResult.PATIENT_NAME = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                qcCheckResult.QA_EVENT_TYPE = qcMsgDict.QA_EVENT_TYPE;
                qcCheckResult.QC_EXPLAIN = string.Empty;
                qcCheckResult.QC_RESULT = SystemData.QcResult.UnPass;
                qcCheckResult.SCORE = qcMsgDict.SCORE;
                qcCheckResult.ORDER_VALUE = qcMsgDict.SERIAL_NO;
                qcCheckResult.STAT_TYPE = SystemData.StatType.Artificial;
                qcCheckResult.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                qcCheckResult.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
                if (row.Cells[this.colRemark.Index].Value != null)
                    qcCheckResult.REMARKS = row.Cells[this.colRemark.Index].Value.ToString();
                shRet = QcCheckResultAccess.Instance.Insert(qcCheckResult);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    //MessageBoxEx.Show(string.Format("第{0}行病历扣分信息保存失败！", row.Index + 1), MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                qcCheckResult.CHECKER_ID = SystemParam.Instance.UserInfo.USER_ID;
                qcCheckResult.CHECKER_NAME = SystemParam.Instance.UserInfo.USER_NAME;
                qcCheckResult.ORDER_VALUE = qcMsgDict.SERIAL_NO;
                qcCheckResult.MR_STATUS = SystemParam.Instance.PatVisitInfo.MR_STATUS;
                qcCheckResult.CHECK_DATE = SysTimeHelper.Instance.Now;
                qcCheckResult.ERROR_COUNT = int.Parse(row.Cells[this.colErrorCount.Index].Value.ToString());
                if (row.Cells[this.colRemark.Index].Value != null)
                    qcCheckResult.REMARKS = row.Cells[this.colRemark.Index].Value.ToString();
                shRet = QcCheckResultAccess.Instance.Update(qcCheckResult);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    //MessageBoxEx.Show(string.Format("第{0}行病历扣分信息更新失败！", row.Index + 1), MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveHummanScore();
        }
        private void btnSystemCheck_Click(object sender, EventArgs e)
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            try
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                WorkProcess.Instance.Initialize(this, 2, "系统重检开始。。。");
                WorkProcess.Instance.Show(0);
                CheckPointHelper.Instance.CheckPatient(SystemParam.Instance.PatVisitInfo);
                WorkProcess.Instance.Show("正在加载结果。。。", 1);
                LoadSystemScoreInfos();
                WorkProcess.Instance.Show(3);
                this.tpSystemScore.Focus();
                WorkProcess.Instance.Close();
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("单患者运行所有规则出错", ex);
                MessageBoxEx.ShowErrorFormat("单患者运行所有规则出错", ex.ToString(), null);
            }
        }
        private void btnModifyNotice_Click(object sender, EventArgs e)
        {
            Dialogs.ModifyNoticeForm frm = new Dialogs.ModifyNoticeForm();
            frm.ShowDialog();
        }
        protected override void OnPatientInfoChanging(CancelEventArgs e)
        {
            base.OnPatientInfoChanging(e);
            if (!this.NeedSave)
                return;
            DialogResult diaResult = MessageBoxEx.ShowConfirm("当前病案评分没有保存，是否保存?");
            if (diaResult == DialogResult.OK)
            {
                this.SaveHummanScore();
            }
            this.NeedSave = false;
        }
        private void dgvHummanScore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;
                DataGridViewRow row = this.dgvHummanScore.Rows[e.RowIndex];

                bool flag = row.Cells[this.colCheckBox.Index].Value != null ? bool.Parse(row.Cells[this.colCheckBox.Index].Value.ToString()) : false;
                var qcMsgDict = row.Tag as QcMsgDict;
                if (qcMsgDict == null
                    || string.IsNullOrEmpty(qcMsgDict.MESSAGE))
                    return;
                if (e.ColumnIndex == this.colCheckBox.Index)
                {
                    row.Cells[this.colCheckBox.Index].ReadOnly = false;
                    row.Cells[this.colCheckBox.Index].Value = !flag;
                    flag = !flag;
                    if (flag)
                    {
                        row.Cells[this.colErrorCount.Index].ReadOnly = false;
                        row.Cells[this.colErrorCount.Index].Value = 1;
                    }
                    else
                    {
                        row.Cells[this.colErrorCount.Index].Value = string.Empty;
                    }
                }
                else
                {
                    row.Cells[this.colRemark.Index].ReadOnly = !flag;
                    row.Cells[this.colErrorCount.Index].ReadOnly = !flag;
                }
                this.CalHummanScore();
                this.NeedSave = true;
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowError("发生错误", ex.ToString());
            }
        }
        private void dgvHummanScore_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                DataGridViewRow row = this.dgvHummanScore.Rows[e.RowIndex];
                bool flag = row.Cells[this.colCheckBox.Index].Value != null ? bool.Parse(row.Cells[this.colCheckBox.Index].Value.ToString()) : false;
                var qcMsgDict = row.Tag as QcMsgDict;
                if (qcMsgDict == null
                    || string.IsNullOrEmpty(qcMsgDict.MESSAGE))
                {
                    this.PatientPageControl.LoadModule(qcMsgDict.QA_EVENT_TYPE);
                    return;
                }
                row.Cells[this.colCheckBox.Index].ReadOnly = false;
                row.Cells[this.colCheckBox.Index].Value = !flag;
                flag = !flag;
                if (flag)
                {
                    row.Cells[this.colErrorCount.Index].ReadOnly = false;
                    row.Cells[this.colErrorCount.Index].Value = 1;
                }
                else
                {
                    row.Cells[this.colErrorCount.Index].Value = string.Empty;
                }
                this.NeedSave = true;
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowError("打开关联病历出错", ex.ToString());
            }

        }
        private void dgvHummanScore_OnBindDataDetail(object item, int rowIndex, bool isMainItem)
        {
            DataGridViewRow row = this.dgvHummanScore.Rows[rowIndex];
            QcMsgDict singleModel = item as QcMsgDict;
            row.ReadOnly = true;
            //Country
            if (isMainItem)
            {
                row.Cells[this.colItem.Index].Value = singleModel.QA_EVENT_TYPE;
                row.DefaultCellStyle.BackColor = Color.FromArgb(185, 185, 185);

            }
            else
            {
                if (string.IsNullOrEmpty(singleModel.MESSAGE))
                {
                    //二级分类
                    row.Cells[this.colItem.Index].Value = "  " + singleModel.MESSAGE_TITLE;
                    row.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
                }
                else
                {
                    //评分项
                    row.Cells[this.colItem.Index].Value = "    " + singleModel.OrderNo.ToString() + "、" + singleModel.MESSAGE;
                    row.Cells[this.colPoint.Index].Value = singleModel.SCORE;
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);

                    //if (m_lstQcCheckResult != null)
                    //{
                    //    QcCheckResult qcCheckResult = m_lstQcCheckResult.Where(m => m.MSG_DICT_CODE == singleModel.QC_MSG_CODE).FirstOrDefault();
                    //    if (qcCheckResult != null)
                    //    {
                    //        row.Cells[this.colRemark.Index].Value = qcCheckResult.REMARKS;
                    //        row.Cells[this.colCheckBox.Index].Value = true;
                    //        row.Cells[this.colErrorCount.Index].Value = qcCheckResult.ERROR_COUNT;
                    //        row.Cells[this.colErrorCount.Index].ReadOnly = false;
                    //        row.Cells[this.colRemark.Index].ReadOnly = false;
                    //    }
                    //}
                }
            }
            //Name
            //Gender
        }
        /// <summary>
        /// 加载人工评分项目
        /// </summary>
        public void LoadHummanQcMsgDict()
        {
            this.dgvHummanScore.Rows.Clear();
            List<QaEventTypeDict> lstQaEventTypeDict = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQaEventTypeDict);
            List<QcMsgDict> lstQcMsgDict = null;
            shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(ref lstQcMsgDict);
            lstQcMsgDict = lstQcMsgDict.Where(m => m.IS_VALID == 1).ToList();

            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("质控质检问题下载失败！");
                return;
            }

            var firstQaEventTypeDict = lstQaEventTypeDict.Where(m => m.PARENT_CODE == string.Empty).ToList();
            GroupQcMsgDict groupQcMsgDict = new GroupQcMsgDict();
            foreach (var item in firstQaEventTypeDict)
            {
                //添加一级分类
                ListQcMsgDict listQcMsgDict = new ListQcMsgDict();
                QcMsgDict firstQaEventType = new QcMsgDict();
                firstQaEventType.QA_EVENT_TYPE = item.QA_EVENT_TYPE;
                listQcMsgDict.Add(firstQaEventType);

                var firstMsgDict = lstQcMsgDict.Where(m => m.MESSAGE_TITLE == string.Empty && m.QA_EVENT_TYPE == item.QA_EVENT_TYPE).ToList();
                if (firstMsgDict.Count > 0)
                {
                    foreach (var item3 in firstMsgDict)
                    {
                        item3.OrderNo = firstMsgDict.IndexOf(item3) + 1;
                        //添加一级分类下的质检问题项
                        listQcMsgDict.Add(item3);

                    }
                }

                var secondQaEventTypeDict = lstQaEventTypeDict.Where(m => m.PARENT_CODE == item.INPUT_CODE).ToList();
                if (secondQaEventTypeDict.Count > 0)
                {
                    foreach (var childItem in secondQaEventTypeDict)
                    {
                        //增加二级分类
                        QcMsgDict secondQaEventType = new QcMsgDict();
                        secondQaEventType.QA_EVENT_TYPE = item.QA_EVENT_TYPE;
                        secondQaEventType.MESSAGE_TITLE = childItem.QA_EVENT_TYPE;
                        listQcMsgDict.Add(secondQaEventType);
                        var secondMsgdict = lstQcMsgDict.Where(m => m.MESSAGE_TITLE == childItem.QA_EVENT_TYPE).ToList();
                        if (secondMsgdict.Count > 0)
                        {
                            foreach (var itemMsgDict in secondMsgdict)
                            {
                                itemMsgDict.OrderNo = secondMsgdict.IndexOf(itemMsgDict) + 1;
                                //添加二级分类下的质检问题项
                                listQcMsgDict.Add(itemMsgDict);
                            }
                        }
                    }
                }
                if (listQcMsgDict.Count > 0)
                    groupQcMsgDict.Add(listQcMsgDict);
            }
            this.dgvHummanScore.BindDataSource<GroupQcMsgDict, QcMsgDict>(groupQcMsgDict);
            //默认展开第一组
            this.dgvHummanScore.Expand(0);
        }
        /// <summary>
        /// 加载评分结果，切换患者刷新只需要更新评分结果
        /// </summary>
        public void LoadHummanScoreInfos()
        {
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            if (m_lstQcCheckResult == null)
                m_lstQcCheckResult = new List<QcCheckResult>();
            m_lstQcCheckResult.Clear();
            short shRet = QcCheckResultAccess.Instance.GetQcCheckResults(SystemParam.Instance.DefaultTime, SystemParam.Instance.DefaultTime, szPatientID, szVisitID, null, null, null, SystemData.StatType.Artificial, ref m_lstQcCheckResult);

            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("质控质检问题下载失败！");
                return;
            }
            foreach (DataGridViewRow row in this.dgvHummanScore.Rows)
            {
                if (row is CollapseDataGridViewRow)
                {
                    //第一级分类行
                    CollapseDataGridViewRow FirstRow = (row as CollapseDataGridViewRow);
                    foreach (var item in FirstRow.Rows)
                    {

                        var qcMsgDict = item.Tag as QcMsgDict;
                        if (qcMsgDict == null || string.IsNullOrEmpty(qcMsgDict.MESSAGE))
                            continue;
                        if (m_lstQcCheckResult != null)
                        {
                            QcCheckResult qcCheckResult = m_lstQcCheckResult.Where(m => m.MSG_DICT_CODE == qcMsgDict.QC_MSG_CODE).FirstOrDefault();
                            if (qcCheckResult != null)
                            {
                                item.Cells[this.colRemark.Index].Value = qcCheckResult.REMARKS;
                                item.Cells[this.colCheckBox.Index].Value = true;
                                item.Cells[this.colErrorCount.Index].Value = qcCheckResult.ERROR_COUNT;
                                item.Cells[this.colErrorCount.Index].ReadOnly = false;
                                item.Cells[this.colRemark.Index].ReadOnly = false;
                            }
                            else
                            {
                                item.Cells[this.colRemark.Index].Value = null;
                                item.Cells[this.colCheckBox.Index].Value = false;
                                item.Cells[this.colErrorCount.Index].Value = null;
                                item.Cells[this.colErrorCount.Index].ReadOnly = true;
                                item.Cells[this.colRemark.Index].ReadOnly = true;

                            }
                        }
                    }
                }
            }
            //默认展开第一组
            //this.dgvHummanScore.Expand(0);
            this.CalHummanScore();
        }
        /// <summary>
        /// 加载系统评分项目
        /// </summary>
        public void LoadSystemQcMsgDict()
        {
            this.dgvSystemScore.Rows.Clear();
            List<QaEventTypeDict> lstQaEventTypeDict = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQaEventTypeDict);
            List<QcMsgDict> lstQcMsgDict = null;
            shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(ref lstQcMsgDict);
            //if (SystemParam.Instance.PatVisitInfo == null)

            //string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            //string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("质控质检问题下载失败！");
                return;
            }
            var firstQaEventTypeDict = lstQaEventTypeDict.Where(m => m.PARENT_CODE == string.Empty).ToList();
            int nRowIndex = 0;
            foreach (var item in firstQaEventTypeDict)
            {
                //添加一级分类
                nRowIndex = this.dgvSystemScore.Rows.Add();
                DataGridViewRow row = this.dgvSystemScore.Rows[nRowIndex];
                row.Tag = item;
                row.Cells[this.col_2_Item.Index].Value = item.QA_EVENT_TYPE;
                row.ReadOnly = true;
                row.DefaultCellStyle.BackColor = Color.FromArgb(185, 185, 185);
                var secondQaEventTypeDict = lstQaEventTypeDict.Where(m => m.PARENT_CODE == item.INPUT_CODE).ToList();
                if (secondQaEventTypeDict.Count > 0)
                {
                    foreach (var childItem in secondQaEventTypeDict)
                    {
                        //增加二级分类
                        nRowIndex = this.dgvSystemScore.Rows.Add();
                        DataGridViewRow childrow = this.dgvSystemScore.Rows[nRowIndex];
                        childrow.Tag = childItem;
                        childrow.Cells[this.col_2_Item.Index].Value = "  " + childItem.QA_EVENT_TYPE;
                        childrow.ReadOnly = true;
                        childrow.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
                        var secondMsgdict = lstQcMsgDict.Where(m => m.MESSAGE_TITLE == childItem.QA_EVENT_TYPE).ToList();
                        if (secondMsgdict.Count > 0)
                        {
                            foreach (var itemMsgDict in secondMsgdict)
                            {
                                //添加二级分类下的质检问题项
                                nRowIndex = this.dgvSystemScore.Rows.Add();
                                DataGridViewRow row2 = this.dgvSystemScore.Rows[nRowIndex];
                                row2.Tag = itemMsgDict;
                                row2.ReadOnly = true;
                                row2.Cells[this.col_2_Item.Index].Value = string.Format("    {0}、{1}", secondMsgdict.IndexOf(itemMsgDict, 0) + 1, itemMsgDict.MESSAGE);
                                row2.Cells[this.col_2_Score.Index].Value = itemMsgDict.SCORE;

                            }
                        }
                    }
                }
                var firstMsgDict = lstQcMsgDict.Where(m => m.MESSAGE_TITLE == string.Empty && m.QA_EVENT_TYPE == item.QA_EVENT_TYPE).ToList();
                if (firstMsgDict.Count > 0)
                {
                    foreach (var item3 in firstMsgDict)
                    {
                        //添加一级分类下的质检问题项
                        nRowIndex = this.dgvSystemScore.Rows.Add();
                        DataGridViewRow row2 = this.dgvSystemScore.Rows[nRowIndex];
                        row2.Tag = item3;
                        row2.Cells[this.col_2_Item.Index].Value = string.Format("  {0}、{1}", firstMsgDict.IndexOf(item3, 0) + 1, item3.MESSAGE);
                        row2.Cells[this.col_2_Score.Index].Value = item3.SCORE;
                        row2.ReadOnly = true;
                    }
                }
            }
        }
        /// <summary>
        /// 加载系统检查扣分信息
        /// </summary>
        private void LoadSystemScoreInfos()
        {

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            List<QcCheckResult> lstQcCheckResult = null;
            short shRet = QcCheckResultAccess.Instance.GetQcCheckResults(SystemParam.Instance.DefaultTime, SystemParam.Instance.DefaultTime, szPatientID, szVisitID, null, null, null, SystemData.StatType.System, ref lstQcCheckResult);

            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("质控质检问题下载失败！");
                return;
            }
            foreach (DataGridViewRow item in this.dgvSystemScore.Rows)
            {
                QcMsgDict qcMsgDict = item.Tag as QcMsgDict;
                if (qcMsgDict == null)
                    continue;
                if (lstQcCheckResult == null)
                {
                    item.Cells[this.col_2_QC_EXPLAIN.Index].Tag = null;
                    item.Visible = false;
                    continue;
                }
                QcCheckResult qcCheckResult = lstQcCheckResult.Where(m => m.MSG_DICT_CODE == qcMsgDict.QC_MSG_CODE && m.QC_RESULT == SystemData.QcResult.UnPass).FirstOrDefault();
                if (qcCheckResult != null)
                {
                    item.Cells[this.col_2_ErrorCount.Index].Value = qcCheckResult.ERROR_COUNT;
                    item.Cells[this.col_2_QC_EXPLAIN.Index].Value = qcCheckResult.QC_EXPLAIN;
                    item.Cells[this.col_2_Score.Index].Value = qcCheckResult.SCORE;
                    item.Cells[this.col_2_QC_EXPLAIN.Index].Tag = qcCheckResult;
                    item.DefaultCellStyle.ForeColor = Color.Red;
                    item.Visible = true;
                }
                else
                {
                    item.Cells[this.col_2_QC_EXPLAIN.Index].Tag = null;
                    item.Visible = false;
                }
            }
            //加载评分结果
            this.CalSystemScore();
            QCScore qcScore = new QCScore();
            shRet = QcScoreAccess.Instance.GetQCScore(szPatientID, szVisitID, ref qcScore);
            this.tpHummanScore.Tag = qcScore;
        }
        private void CalHummanScore()
        {
            float totalScore = 100;
            foreach (DataGridViewRow row in this.dgvHummanScore.Rows)
            {
                if (row is CollapseDataGridViewRow)
                {
                    //第一级分类行
                    CollapseDataGridViewRow FirstRow = (row as CollapseDataGridViewRow);
                    foreach (var item in FirstRow.Rows)
                    {

                        var qcMsgDict = item.Tag as QcMsgDict;
                        if (qcMsgDict == null || string.IsNullOrEmpty(qcMsgDict.MESSAGE))
                            continue;
                        if (item.Cells[this.colCheckBox.Index].Value != null &&
                            item.Cells[this.colCheckBox.Index].Value.ToString() == "True")
                        {
                            float point = float.Parse(item.Cells[this.colPoint.Index].Value.ToString());
                            int errorCount = int.Parse(item.Cells[this.colErrorCount.Index].Value.ToString());
                            totalScore -= point * errorCount;
                        }
                    }
                }
            }
            this.tpHummanScore.Text = string.Format("人工检测（{0}）", totalScore);
            this.txtLevel.Text = DocLevel.GetDocLevel(totalScore);
            QCScore qcScore = this.tpHummanScore.Tag as QCScore;
            if (qcScore == null)
            {
                qcScore = new QCScore();
            }
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            qcScore.DeptCode = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            qcScore.DEPT_NAME = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            qcScore.PATIENT_NAME = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            qcScore.DOC_LEVEL = DocLevel.GetDocLevel(totalScore);
            qcScore.HOS_ASSESS = totalScore;
            qcScore.HOS_DATE = SysTimeHelper.Instance.Now;
            qcScore.HOS_QCMAN = SystemParam.Instance.UserInfo.USER_NAME;
            qcScore.HOS_QCMAN_ID = SystemParam.Instance.UserInfo.USER_ID;
            qcScore.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            qcScore.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcScore.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
        }
        private void CalSystemScore()
        {
            float totalScore = 100;
            foreach (DataGridViewRow item in this.dgvSystemScore.Rows)
            {
                var qcCheckResult = item.Cells[this.col_2_QC_EXPLAIN.Index].Tag as QcCheckResult;
                if (qcCheckResult == null)
                    continue;
                if (qcCheckResult.QC_RESULT == SystemData.QcResult.UnPass)
                {
                    float point = float.Parse(item.Cells[this.col_2_Score.Index].Value.ToString());
                    int errorCount = int.Parse(item.Cells[this.col_2_ErrorCount.Index].Value.ToString());
                    totalScore -= point * errorCount;
                }
            }
            this.tpSystemScore.Text = string.Format("系统检测（{0}）", totalScore);
        }
    }

    public class ListQcMsgDict : List<QcMsgDict>
    {
    }
    public class GroupQcMsgDict : List<List<QcMsgDict>>
    { }

}