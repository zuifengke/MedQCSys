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
using QaEventTypeDict = EMRDBLib.QaEventTypeDict;
using QcMsgDict = EMRDBLib.QcMsgDict;
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace MedQCSys.DockForms
{
    public partial class DocScoreForm : DockContentBase
    {

        private float m_fDocScore = 0;
        /// <summary>
        /// 获取病历得分
        /// </summary>
        public float DocScore
        {
            get { return this.m_fDocScore; }
        }

        private string m_szDocLevel = string.Empty;
        /// <summary>
        /// 获取病历评分等级
        /// </summary>
        public string DocLevel
        {
            get { return this.m_szDocLevel; }
        }

        private string m_szQcChecker = string.Empty;
        /// <summary>
        /// 获取评分检查人
        /// </summary>
        public string QcChecker
        {
            get { return this.m_szQcChecker; }
        }
        private bool m_NeedSave = false;
        /// <summary>
        /// 是否需要保存病案评分
        /// </summary>
        public bool NeedSave
        {
            get { return m_NeedSave; }
            set { m_NeedSave = value; }
        }

        public DocScoreForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
            this.dgvDocContent.Font = new Font("宋体", 10.5f);
            this.dgvDocTime.Font = new Font("宋体", 10.5f);
        }

        public DocScoreForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent, patientPageControl)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
            this.dgvDocContent.Font = new Font("宋体", 10.5f);
            this.dgvDocTime.Font = new Font("宋体", 10.5f);
        }

        protected override void OnPatientScoreChanged()
        {
            base.OnPatientScoreChanged();
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.NeedRefreshView)
                this.OnRefreshView();
            this.NeedSave = true;
        }

        public override void OnRefreshView()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Update();

            this.ShowStatusMessage("正在分析内容质控扣分情况...");
            float fContentScore = 0;
            this.LoadDocContentInfos(ref fContentScore);
            this.txtContentPoint.Text = fContentScore.ToString();

            this.ShowStatusMessage("正在分析时效质控扣分情况...");
            float fTimeSocre = 0;
            this.LoadDocTimeInfos(ref fTimeSocre);
            this.txtTimePoint.Text = fTimeSocre.ToString();


            this.CalcDocScore(100 - fContentScore - fTimeSocre);

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
                this.OnRefreshView();
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
        public event EventHandler DocScoreSaved = null;
        internal virtual void OnDocScoreSaved(System.EventArgs e)
        {
            if (this.DocScoreSaved == null)
                return;
            try
            {
                this.DocScoreSaved(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DocScoreForm.OnDocScoreSaved", ex);
            }
        }
        /// <summary>
        /// 当前患者质检问题缓存
        /// </summary>
        private List<EMRDBLib.MedicalQcMsg> m_lstQCQuestionInfos = null;
        /// <summary>
        /// 加载病历内容扣分信息
        /// </summary>
        private void LoadDocContentInfos(ref float fContentScore)
        {
            this.dgvDocContent.Rows.Clear();
            List<QCEventTypeTemplate> lstQCEventTypeTemplate = null;
            //初始化
            InitListQCEventTypeTemplate(ref lstQCEventTypeTemplate);

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szPatientID, szVisitID, ref lstQCQuestionInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("质控质检问题下载失败！");
                return;
            }
            m_lstQCQuestionInfos = lstQCQuestionInfos;
            Hashtable htQuestionInfo = null;
            if (lstQCQuestionInfos != null && lstQCQuestionInfos.Count > 0)
            {
                htQuestionInfo = new Hashtable();
                for (int index = 0; index < lstQCQuestionInfos.Count; index++)
                {
                    EMRDBLib.MedicalQcMsg questionInfo = lstQCQuestionInfos[index];
                    if (!htQuestionInfo.ContainsKey(questionInfo.QC_MSG_CODE))
                        htQuestionInfo.Add(questionInfo.QC_MSG_CODE, questionInfo);
                }
            }

            foreach (QCEventTypeTemplate item in lstQCEventTypeTemplate)
            {
                //一级目录
                QaEventTypeDict qcEventType = item.QcEventType;
                if (AddEventTypeRow(qcEventType, item)) continue;

                //二级目录
                foreach (QCEventTypeTemplate subItem in item.LstQCEventTypeTemplate)
                {
                    qcEventType = subItem.QcEventType;
                    if (AddEventTypeRow(qcEventType, subItem)) continue;

                    //加载二级类别的QCMessageTeplate
                    this.SetQcMessageTemplets(subItem.LstQcMessageTemplets, htQuestionInfo, lstQCQuestionInfos, ref fContentScore);
                }
                //一级目录的QCMessageTeplate
                this.SetQcMessageTemplets(item.LstQcMessageTemplets, htQuestionInfo, lstQCQuestionInfos, ref fContentScore);
            }


        }

        private bool AddEventTypeRow(QaEventTypeDict qcEventType, QCEventTypeTemplate item)
        {
            int nRowIndex = this.dgvDocContent.Rows.Add();
            DataGridViewRow row = this.dgvDocContent.Rows[nRowIndex];
            row.Tag = qcEventType; //将记录信息保存到该行
            row.Cells[this.colItem.Index].Value = item.IsParent ? qcEventType.QA_EVENT_TYPE : "  " + qcEventType.QA_EVENT_TYPE;
            row.ReadOnly = true;
            if (string.IsNullOrEmpty(qcEventType.PARENT_CODE))
                row.DefaultCellStyle.BackColor = Color.FromArgb(185, 185, 185);
            else
                row.DefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            return false;
        }

        private void SetQcMessageTemplets(List<QcMsgDict> lstQcMessageTemplets, Hashtable htQuestionInfo,
            List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos, ref float fContentScore)
        {
            int nMessageNum = 0;
            for (int index1 = 0; index1 < lstQcMessageTemplets.Count; index1++)
            {
                EMRDBLib.QcMsgDict qcMessageTemplet = lstQcMessageTemplets[index1];
                int rowIndex = this.dgvDocContent.Rows.Add();
                DataGridViewRow currRow = this.dgvDocContent.Rows[rowIndex];
                nMessageNum++;
                if (!string.IsNullOrEmpty(qcMessageTemplet.MESSAGE_TITLE))//二级目录下的问题模板加空格
                    currRow.Cells[this.colItem.Index].Value = string.Format("    {0}、{1}", nMessageNum, qcMessageTemplet.MESSAGE);
                else
                    currRow.Cells[this.colItem.Index].Value = string.Format("  {0}、{1}", nMessageNum, qcMessageTemplet.MESSAGE);
                currRow.Cells[this.colPoint.Index].Value =
                    GlobalMethods.Convert.StringToValue(qcMessageTemplet.SCORE, 0f).ToString();
                if (qcMessageTemplet.ISVETO)
                {
                    currRow.Cells[this.colContentIsVeto.Index].Value = "是";
                }
                if (htQuestionInfo == null)
                {
                    qcMessageTemplet.HosScore = "0";
                    currRow.Tag = qcMessageTemplet;
                    continue;
                }
                if (htQuestionInfo.Contains(qcMessageTemplet.QC_MSG_CODE))
                {
                    string szHosScore = this.GetHosScore(qcMessageTemplet.QC_MSG_CODE, lstQCQuestionInfos);
                    EMRDBLib.MedicalQcMsg qcQuestionInfo = htQuestionInfo[qcMessageTemplet.QC_MSG_CODE] as EMRDBLib.MedicalQcMsg;
                    if (qcQuestionInfo == null)
                        continue;

                    if (string.IsNullOrEmpty(szHosScore) || szHosScore.Equals("0.0"))
                    {
                        qcMessageTemplet.HosScore = "0";
                        currRow.Cells[this.colHosPoint.Index].Value = "";
                    }
                    else
                    {
                        qcMessageTemplet.HosScore = szHosScore;
                        currRow.Cells[this.colHosPoint.Index].Value = szHosScore;
                    }

                    fContentScore += GlobalMethods.Convert.StringToValue(currRow.Cells[this.colHosPoint.Index].Value.ToString(), 0f);
                    currRow.Cells[this.colItem.Index].Tag = qcQuestionInfo;
                    currRow.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    qcMessageTemplet.HosScore = "0";
                    currRow.Cells[this.colHosPoint.Index].Value = "";
                }
                currRow.Tag = qcMessageTemplet;
            }
        }
        /// <summary>
        /// 组合QCEventType和QCMessageTemlate
        /// </summary>
        /// <param name="lstQcEventTypeTemplate"></param>
        /// <returns></returns>
        private bool InitListQCEventTypeTemplate(ref List<QCEventTypeTemplate> lstQcEventTypeTemplate)
        {
            List<EMRDBLib.QaEventTypeDict> lstQCEventTypes = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQCEventTypes);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("获取病案质量问题分类字典失败！");
                return false;
            }
            if (lstQCEventTypes == null || lstQCEventTypes.Count <= 0)
                return false;
            SortQCEventType(ref lstQCEventTypes);


            List<EMRDBLib.QcMsgDict> lstQCMessageTemplets = null;
            shRet = QcMsgDictAccess.Instance.GetQcMsgDictList("", ref lstQCMessageTemplets);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("获取反馈质控信息字典失败！");
                return false;
            }
            if (lstQCMessageTemplets == null || lstQCMessageTemplets.Count <= 0)
                return false;
            lstQcEventTypeTemplate = new List<QCEventTypeTemplate>();
            //lstQCEventTypes已经按照一级二级组装排序
            //组装问题类型和反馈信息类型模板
            foreach (QaEventTypeDict eventType in lstQCEventTypes)
            {
                if (string.IsNullOrEmpty(eventType.PARENT_CODE)) //新增一级以及直属于一级的反馈信息类型
                {
                    QCEventTypeTemplate qcEventTypeTemplate = new QCEventTypeTemplate();
                    qcEventTypeTemplate.IsParent = true;
                    qcEventTypeTemplate.QcEventType = eventType;
                    //查找直属的QCMessageTempet
                    List<EMRDBLib.QcMsgDict> itemTemplet =
                        lstQCMessageTemplets.FindAll(
                            item => string.IsNullOrEmpty(item.MESSAGE_TITLE) && item.QA_EVENT_TYPE == eventType.QA_EVENT_TYPE);
                    qcEventTypeTemplate.LstQcMessageTemplets = itemTemplet;

                    lstQcEventTypeTemplate.Add(qcEventTypeTemplate);
                }
                else
                {
                    //找到QCEventTypeTemplate，添加二级QCEventTypeTemplate
                    QCEventTypeTemplate parentTypeTemplate =
                        lstQcEventTypeTemplate.Find(item => item.QcEventType.INPUT_CODE == eventType.PARENT_CODE);
                    if (parentTypeTemplate == null)
                        continue;
                    QCEventTypeTemplate subQCEventTypeTemplate = new QCEventTypeTemplate();
                    subQCEventTypeTemplate.QcEventType = eventType;
                    subQCEventTypeTemplate.IsParent = false;
                    //查找二级的QCMessageTempet
                    List<EMRDBLib.QcMsgDict> itemTemplet =
                        lstQCMessageTemplets.FindAll(
                            item => item.MESSAGE_TITLE == eventType.QA_EVENT_TYPE);
                    subQCEventTypeTemplate.LstQcMessageTemplets = itemTemplet;
                    parentTypeTemplate.LstQCEventTypeTemplate.Add(subQCEventTypeTemplate);
                }
            }
            return true;
        }

        /// <summary>
        /// 排序问题类型
        /// </summary>
        /// <param name="lstQcEventTypes"></param>
        private void SortQCEventType(ref List<QaEventTypeDict> lstQcEventTypes)
        {
            if (lstQcEventTypes == null)
                return;
            if (lstQcEventTypes.Count == 0)
                return;
            List<QaEventTypeDict> lstNew = new List<QaEventTypeDict>();
            //一级二级分组排序
            //筛选一级
            List<QaEventTypeDict> lsts = lstQcEventTypes.FindAll(item => string.IsNullOrEmpty(item.PARENT_CODE));
            lstNew.AddRange(lsts);
            for (int index = 0; index < lstNew.Count; index++)
            {
                List<QaEventTypeDict> items = lstQcEventTypes.FindAll(item => lstNew[index].INPUT_CODE == item.PARENT_CODE);
                if (items.Count > 0)
                {
                    int _index = 0;
                    _index = lstNew.IndexOf(lstNew[index]);
                    if (_index + 1 < lstNew.Count)
                        lstNew.InsertRange(_index + 1, items);
                    else
                        lstNew.AddRange(items);
                    //跳到下个一级节点索引
                    index += items.Count;
                }
            }
            lstQcEventTypes = lstNew;
        }

        /// <summary>
        /// 获取质检问题代码对应的扣分总数
        /// </summary>
        /// <param name="p"></param>
        /// <param name="lstQCQuestionInfos"></param>
        /// <returns></returns>
        private string GetHosScore(string szQCMsgCode, List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos)
        {
            if (string.IsNullOrEmpty(szQCMsgCode))
                return string.Empty;
            if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count == 0)
                return string.Empty;
            float fScore_0 = 0.0f;//自动扣分，对应病历
            float fScore_1 = 0.0f;//手动扣分，不对应病历
            foreach (EMRDBLib.MedicalQcMsg qcQuestionInfo in lstQCQuestionInfos)
            {
                if (qcQuestionInfo.QC_MSG_CODE != szQCMsgCode)
                    continue;
                if (qcQuestionInfo.POINT_TYPE == 0)
                {
                    fScore_0 += GlobalMethods.Convert.StringToValue(qcQuestionInfo.POINT, 0f);
                }
                else if (qcQuestionInfo.POINT_TYPE == 1)
                {
                    fScore_1 += GlobalMethods.Convert.StringToValue(qcQuestionInfo.POINT, 0f);
                }
            }
            //如果有自动扣分，返回自动扣分的总分
            //改成两者综合
            return (fScore_0 + fScore_1).ToString();
        }

        /// <summary>
        /// 加载病历时效信息
        /// </summary>
        private void LoadDocTimeInfos(ref float fTimeSocre)
        {
            this.dgvDocTime.Rows.Clear();
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            TimeCheckQuery timeCheckQuery = new TimeCheckQuery();
            timeCheckQuery.PatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            timeCheckQuery.PatientName = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            //timeCheckQuery.VisitID = SystemParam.Instance.PatVisitLog.VISIT_ID;
            //编辑器VISIT_NO=VISIT_ID
            timeCheckQuery.VisitID = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            timeCheckQuery.VisitNO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            try
            {
                TimeCheckEngine.Instance.PerformTimeCheck(timeCheckQuery);
            }
            catch (Exception ex)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                LogManager.Instance.WriteLog("DocScoreForm.LoadDocTimeInfos", ex);
                return;
            }

            List<TimeCheckResult> lstCheckResults = TimeCheckEngine.Instance.TimeCheckResults;
            if (lstCheckResults == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index < lstCheckResults.Count; index++)
            {
                TimeCheckResult resultInfo = lstCheckResults[index];
                resultInfo.VisitID =SystemParam.Instance.PatVisitInfo.VISIT_ID;
                if (resultInfo.WrittenState == WrittenState.Early)
                    continue;
                if (resultInfo.WrittenState == WrittenState.Normal)
                    continue;

                int nRowIndex = this.dgvDocTime.Rows.Add();
                DataGridViewRow row = this.dgvDocTime.Rows[nRowIndex];
                row.Tag = resultInfo;
                row.Cells[this.colDocName.Index].Value = resultInfo.DocTitle;

                if (resultInfo.WrittenState == WrittenState.Timeout)
                {
                    row.Cells[this.colStatus.Index].Value = "书写超时";
                }
                else if (resultInfo.WrittenState == WrittenState.Unwrite)
                {
                    row.Cells[this.colStatus.Index].Value = "未书写";
                    //正常未书写
                    if (DateTime.Compare(resultInfo.EndTime, DateTime.Now) > 0)
                    {
                        row.Cells[this.colStatus.Index].Value = "正常未书写";
                    }
                }
                if (resultInfo.WrittenState != WrittenState.Unwrite)
                {
                    row.Cells[this.colCreateTime.Index].Value = resultInfo.DocTime.ToString("yyyy-M-d HH:mm");
                    row.Cells[this.colCreator.Index].Value = resultInfo.CreatorName;
                }
                row.Cells[this.colEndTime.Index].Value = resultInfo.EndTime.ToString("yyyy-M-d HH:mm");

                float fPointValue = resultInfo.QCScore;
                //获取病历时效扣分信息
                EMRDBLib.QCTimeCheck timeCheckInfo = null;
                shRet = QcTimeCheckAccess.Instance.GetQcTimeCheckInfo(resultInfo.PatientID, resultInfo.VisitID, resultInfo.EventID, resultInfo.DocTypeID
                    , resultInfo.StartTime, resultInfo.EndTime, ref timeCheckInfo);
                if (shRet != SystemData.ReturnValue.OK || timeCheckInfo == null)
                {
                    //正常未书写不扣分
                    if (DateTime.Compare(resultInfo.EndTime, DateTime.Now) > 0)
                    {
                        row.Cells[this.colDocPoint.Index].Value = 0.0f;
                    }
                    else
                    {
                        row.Cells[this.colDocPoint.Index].Value = resultInfo.QCScore;
                        fTimeSocre += resultInfo.QCScore;
                    }
                }
                else
                {
                    row.Cells[this.colDocPoint.Index].Value = timeCheckInfo.Point;
                    row.Cells[this.colDocName.Index].Tag = timeCheckInfo;
                    resultInfo.QCScore = GlobalMethods.Convert.StringToValue(timeCheckInfo.Point, 0f);
                    fTimeSocre += GlobalMethods.Convert.StringToValue(timeCheckInfo.Point, 0f);
                }
                row.Cells[this.colDocPoint.Index].Tag = fPointValue;
                row.Cells[this.colQcTimeIsVeto.Index].Value = resultInfo.IsVeto ? "是" : "";
                if (!resultInfo.IsRepeat)
                {
                    row.Cells[this.colCheckBasic.Index].Value = string.Format("患者{0}{1},{2}内书写{3}"
                        , resultInfo.EventTime.ToString("yyyy-M-d HH:mm")
                        , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                }
                else
                {
                    row.Cells[this.colCheckBasic.Index].Value = string.Format("患者{0}{1},每{2}书写一次{3}"
                        , resultInfo.EventTime.ToString("yyyy-M-d HH:mm")
                        , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                }
                row.Tag = resultInfo;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 计算患者病历得分和等级
        /// </summary>
        /// <param name="fTotalScore">病历得分</param>
        private void CalcDocScore(float fTotalScore)
        {
            if (fTotalScore < 0)
                fTotalScore = 0;
            else if (fTotalScore > 100)
                fTotalScore = 100;
            this.txtScore.Text = Math.Round(new decimal(fTotalScore), 1).ToString();
            int szDocScoreLevel = (int)DocLevelEnum.D;
            if (fTotalScore >= SystemParam.Instance.LocalConfigOption.GradingHigh)
                szDocScoreLevel = (int)DocLevelEnum.A;
            else if (fTotalScore < SystemParam.Instance.LocalConfigOption.GradingHigh && fTotalScore > SystemParam.Instance.LocalConfigOption.GradingLow)
                szDocScoreLevel = (int)DocLevelEnum.B;
            else
                szDocScoreLevel = (int)DocLevelEnum.C;


            //兼容单项否决的甲乙丙评分
            if (SystemParam.Instance.LocalConfigOption.VetoHigh > 0 ||
                SystemParam.Instance.LocalConfigOption.VetoLow > 0)
            {
                int szDocVetoLevel = (int)DocLevelEnum.D;
                int iVetoCount = 0;//单项否决总个数
                //内容
                int iVetoContentCount = 0;//单项否决内容个数
                MedQCAccess.Instance.GetContentVetoCount(SystemParam.Instance.PatVisitInfo.PATIENT_ID,
                     SystemParam.Instance.PatVisitInfo.VISIT_ID, ref iVetoContentCount);
                iVetoCount += iVetoContentCount;
                //时效
                int iVetoQcTimeCount = 0;//单项否决时效个数，可从界面获取
                iVetoQcTimeCount = this.GetVetoTimeCount();
                iVetoCount += iVetoQcTimeCount;
                if (iVetoCount >= SystemParam.Instance.LocalConfigOption.VetoHigh)
                    szDocVetoLevel = (int)DocLevelEnum.B;
                if (iVetoCount >= SystemParam.Instance.LocalConfigOption.VetoLow)
                    szDocVetoLevel = (int)DocLevelEnum.C;

                //和评分病历等级比较，取最低值
                if (szDocScoreLevel < szDocVetoLevel)
                    szDocScoreLevel = szDocVetoLevel;
                if (!this.picVetoDesc.Visible)
                    this.picVetoDesc.Visible = true;
                this.toolTip1.SetToolTip(this.picVetoDesc, string.Format("等级说明：\n此病案包括{0}项内容单项否决\n{1}项时效单项否决", iVetoContentCount, iVetoQcTimeCount));

            }
            if (szDocScoreLevel == (int)DocLevelEnum.A)
                this.txtLevel.Text = "甲";
            else if (szDocScoreLevel == (int)DocLevelEnum.B)
                this.txtLevel.Text = "乙";
            else if (szDocScoreLevel == (int)DocLevelEnum.C)
                this.txtLevel.Text = "丙";
            else
                this.txtLevel.Text = "未知";
        }

        private int GetVetoTimeCount()
        {
            int iCount = 0;
            foreach (DataGridViewRow row in this.dgvDocTime.Rows)
            {
                if (row.Cells[this.colQcTimeIsVeto.Index].Value == null)
                    continue;
                if (row.Cells[this.colQcTimeIsVeto.Index].Value.ToString() != "是")
                    continue;
                string szDocStatus = row.Cells[this.colStatus.Index].Value.ToString();
                if (szDocStatus == "未书写" || szDocStatus == "书写超时")
                    iCount++;
            }
            return iCount;
        }

        /// <summary>
        /// 保存病历内容扣分
        /// </summary>
        private void SaveDocContentPoints()
        {
            if (this.dgvDocContent.Rows.Count <= 0)
                return;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index < this.dgvDocContent.Rows.Count; index++)
            {
                DataGridViewRow row = this.dgvDocContent.Rows[index];
                EMRDBLib.QcMsgDict qcMessageTemplet = row.Tag as EMRDBLib.QcMsgDict;
                if (qcMessageTemplet == null)
                    continue;

                if (row.Cells[this.colHosPoint.Index].Value == null)
                    continue;
                if (string.IsNullOrEmpty(row.Cells[this.colHosPoint.Index].Value.ToString()))
                    continue;

                EMRDBLib.MedicalQcMsg qcQuestionInfo = row.Cells[this.colItem.Index].Tag as EMRDBLib.MedicalQcMsg;
                DateTime dtCheckTime = DateTime.Now;
                string szMessgCode = string.Empty;
                if (qcQuestionInfo == null)
                {
                    qcQuestionInfo = new EMRDBLib.MedicalQcMsg();
                    qcQuestionInfo.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                    qcQuestionInfo.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                    qcQuestionInfo.ISSUED_BY = SystemParam.Instance.UserInfo.Name;
                    qcQuestionInfo.ISSUED_DATE_TIME = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                    qcQuestionInfo.DEPT_STAYED = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
                    qcQuestionInfo.DEPT_NAME = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                    qcQuestionInfo.DOCTOR_IN_CHARGE = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
                    qcQuestionInfo.PARENT_DOCTOR = SystemParam.Instance.PatVisitInfo.AttendingDoctor;
                    qcQuestionInfo.SUPER_DOCTOR = SystemParam.Instance.PatVisitInfo.SUPER_DOCTOR;
                    qcQuestionInfo.QC_MODULE = "DOCTOR_MR";
                    qcQuestionInfo.QC_MSG_CODE = qcMessageTemplet.QC_MSG_CODE;
                    qcQuestionInfo.MESSAGE = qcMessageTemplet.MESSAGE;
                    qcQuestionInfo.MSG_STATUS = 0;
                    qcQuestionInfo.QA_EVENT_TYPE = qcMessageTemplet.QA_EVENT_TYPE;
                    qcQuestionInfo.POINT_TYPE = 1;
                    qcQuestionInfo.ISSUED_ID = SystemParam.Instance.UserInfo.ID;
                    qcQuestionInfo.POINT = int.Parse(row.Cells[this.colHosPoint.Index].Value.ToString());
                    shRet = MedicalQcMsgAccess.Instance.Insert(qcQuestionInfo);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show(string.Format("第{0}行病历扣分信息保存失败！", index + 1), MessageBoxIcon.Error);
                        continue;
                    }
                    row.Cells[this.colItem.Index].Tag = qcQuestionInfo;

                }
                else
                {
                    float fPoint = 0f;
                    if (qcQuestionInfo.POINT_TYPE == 0)//自动扣分的在此不再重复扣分，只能在添加质检问题中针对一份病历修改分数
                        continue;
                    if (row.Cells[this.colHosPoint.Index].Value != null)
                        fPoint = float.Parse(row.Cells[this.colHosPoint.Index].Value.ToString());
                    if (GlobalMethods.Convert.StringToValue(qcQuestionInfo.POINT, 0f) == fPoint)
                        continue;
                    qcQuestionInfo.POINT = fPoint;
                    dtCheckTime = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                    szMessgCode = qcQuestionInfo.QC_MSG_CODE;
                    shRet = MedicalQcMsgAccess.Instance.Update(qcQuestionInfo);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show(string.Format("第{0}行病历扣分信息更新失败！", index + 1), MessageBoxIcon.Error);
                        continue;
                    }
                    qcQuestionInfo.ISSUED_DATE_TIME = dtCheckTime;
                }
            }
        }

        /// <summary>
        /// 保存病历时效扣分
        /// </summary>
        private void SaveDocTimePoints()
        {
            if (this.dgvDocContent.Rows.Count <= 0)
                return;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index < this.dgvDocTime.Rows.Count; index++)
            {
                DataGridViewRow row = this.dgvDocTime.Rows[index];
                TimeCheckResult resultInfo = this.dgvDocTime.Rows[index].Tag as TimeCheckResult;
                if (resultInfo == null)
                    continue;
                if (row.Cells[this.colDocPoint.Index].Value == null)
                    continue;
                float fPoint = GlobalMethods.Convert.StringToValue(row.Cells[this.colDocPoint.Index].Value.ToString(), 0f);
                if (fPoint < 0f)
                    continue;

                EMRDBLib.QCTimeCheck qcTimeCheckInfo = row.Cells[this.colDocName.Index].Tag as EMRDBLib.QCTimeCheck;
                if (qcTimeCheckInfo == null)
                {
                    if (fPoint == 0f)
                        continue;

                    qcTimeCheckInfo = new EMRDBLib.QCTimeCheck();
                    qcTimeCheckInfo.PatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                    qcTimeCheckInfo.VisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                    qcTimeCheckInfo.CheckerName = SystemParam.Instance.UserInfo.Name;
                    qcTimeCheckInfo.CheckTime = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                    qcTimeCheckInfo.EventID = resultInfo.EventID;
                    qcTimeCheckInfo.DocTypeID = resultInfo.DocTypeID;
                    if (row.Cells[this.colDocPoint.Index].Value != null)
                        qcTimeCheckInfo.Point = row.Cells[this.colDocPoint.Index].Value.ToString();
                    qcTimeCheckInfo.BeginTime = resultInfo.StartTime;
                    qcTimeCheckInfo.EndTime = resultInfo.EndTime;
                    shRet = QcTimeCheckAccess.Instance.SaveQCTimeCheck(qcTimeCheckInfo);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show(string.Format("第{0}行病历时效检查扣分信息保存失败！", index + 1), MessageBoxIcon.Error);
                        continue;
                    }
                }
                else
                {
                    if (GlobalMethods.Convert.StringToValue(qcTimeCheckInfo.Point, 0f) == fPoint)
                        continue;
                    qcTimeCheckInfo.Point = fPoint.ToString();
                    qcTimeCheckInfo.CheckerName = SystemParam.Instance.UserInfo.Name;
                    qcTimeCheckInfo.CheckTime = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                    shRet = QcTimeCheckAccess.Instance.UpdateQCTimeCheck(qcTimeCheckInfo);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show(string.Format("第{0}行病历时效检查扣分信息保存失败！", index + 1), MessageBoxIcon.Error);
                        continue;
                    }
                }
                row.Cells[this.colDocName.Index].Tag = qcTimeCheckInfo;
            }
        }

        private ReportExplorerForm GetReportExplorerForm()
        {
            ReportExplorerForm reportExplorerForm = new ReportExplorerForm();
            reportExplorerForm.WindowState = FormWindowState.Maximized;
            reportExplorerForm.QueryContext +=
                new QueryContextEventHandler(this.ReportExplorerForm_QueryContext);
            reportExplorerForm.NotifyNextReport +=
                new NotifyNextReportEventHandler(this.ReportExplorerForm_NotifyNextReport);
            return reportExplorerForm;
        }

        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "病历评分清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("病历评分清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("病历评分清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveDocScore();
        }

        private void SaveDocScore()
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (string.IsNullOrEmpty(this.txtScore.Text))
                return;
            this.dgvDocTime.EndEdit();
            this.dgvDocContent.EndEdit();
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            EMRDBLib.QCScore qcScore =null;
            short shRet = QcScoreAccess.Instance.GetQCScore(szPatientID, szVisitID, ref qcScore);
            if (qcScore == null)
            {
                qcScore = new QCScore();
                qcScore.PATIENT_ID = szPatientID;
                qcScore.VISIT_ID = szVisitID;
                qcScore.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
                qcScore.HOS_QCMAN = SystemParam.Instance.UserInfo.Name;
                qcScore.HOS_ASSESS = float.Parse(this.txtScore.Text);
                qcScore.HOS_DATE = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                qcScore.DOC_LEVEL = this.txtLevel.Text;
                shRet = QcScoreAccess.Instance.Insert(qcScore);
            }
            else
            {
                qcScore.PATIENT_ID = szPatientID;
                qcScore.VISIT_ID = szVisitID;
                qcScore.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
                qcScore.HOS_QCMAN = SystemParam.Instance.UserInfo.Name;
                qcScore.HOS_ASSESS = float.Parse(this.txtScore.Text);
                qcScore.HOS_DATE = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                qcScore.DOC_LEVEL = this.txtLevel.Text;
                shRet = QcScoreAccess.Instance.Update(qcScore);
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("病历评分保存失败！");
                return;
            }
            this.m_fDocScore = qcScore.HOS_ASSESS;
            this.m_szDocLevel = this.txtLevel.Text;
            this.m_szQcChecker = SystemParam.Instance.UserInfo.Name;
            this.SaveDocContentPoints();
            this.SaveDocTimePoints();
            MessageBoxEx.ShowMessage("病历评分保存成功！");
            if (!this.AddQCActionLog())
            {
                MessageBoxEx.Show("病历评分保存失败！");
                return;
            }
            this.OnRefreshView();
            this.OnDocScoreSaved(System.EventArgs.Empty);
            this.NeedSave = false;
            this.MainForm.RefreshQCResultStatus(qcScore.HOS_ASSESS);
        }

        /// <summary>
        /// 保存一条质检LOG信息
        /// </summary>
        private bool AddQCActionLog()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return false;
            EMRDBLib.MedicalQcLog qcActionLog = new EMRDBLib.MedicalQcLog();
            qcActionLog.CHECK_DATE = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            if (!GlobalMethods.Misc.IsEmptyString(SystemParam.Instance.PatVisitInfo.DEPT_CODE))
                qcActionLog.DEPT_STAYED = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            else
                qcActionLog.DEPT_STAYED = SystemParam.Instance.PatVisitInfo.DischargeDeptCode;
            qcActionLog.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            qcActionLog.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcActionLog.CHECKED_BY = SystemParam.Instance.UserInfo.Name;
            qcActionLog.CHECKED_ID = SystemParam.Instance.UserInfo.ID;
            qcActionLog.DEPT_CODE = SystemParam.Instance.UserInfo.DeptCode;
            qcActionLog.DEPT_NAME = SystemParam.Instance.UserInfo.DeptName;
            qcActionLog.DOC_SETID = string.Empty;
            qcActionLog.CHECK_TYPE = 2;
            qcActionLog.LOG_TYPE = 1;
            qcActionLog.LOG_DESC = "质控者保存病案评分";
            qcActionLog.AddQCQuestion = false;
            return MedicalQcLogAccess.Instance.Insert(qcActionLog) == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <returns>System.Data.DataTable</returns>
        private DataTable GetPrintData()
        {
            System.Data.DataTable table = GlobalMethods.Table.GetDataTable(this.dgvDocContent, false, 0);
            DataRow row = null;
            for (int index = 0; index < this.dgvDocTime.Rows.Count; index++)
            {
                DataGridViewRow currRow = this.dgvDocTime.Rows[index];
                row = table.NewRow();
                row[0] = currRow.Cells[this.colCheckBasic.Index].Value;
                if (currRow.Cells[this.colDocPoint.Index].Tag != null)
                    row[1] = currRow.Cells[this.colDocPoint.Index].Tag.ToString();
                else
                    row[1] = string.Empty;
                row[2] = currRow.Cells[this.colDocPoint.Index].Value;
                table.Rows.Add(row);
            }
            row = table.NewRow();
            row[0] = string.Format("总得分：{0} 等级：{1} 内容扣分：{2} 时效扣分：{3}", this.txtScore.Text
              , this.txtLevel.Text, this.txtContentPoint.Text, this.txtTimePoint.Text);
            row[1] = string.Empty;
            row[2] = string.Empty;
            table.Rows.Add(row);
            return table;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "所在科室")
            {
                value = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                return true;
            }
            if (name == "患者姓名")
            {

                value = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                return true;
            }
            if (name == "患者ID")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            return false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dgvDocContent.Rows.Count <= 0 && this.dgvDocTime.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可打印内容！");
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            byte[] byteReportData = this.GetReportFileData(null);
            if (byteReportData != null)
            {
                System.Data.DataTable table = this.GetPrintData();
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.ReportFileData = byteReportData;
                explorerForm.ReportParamData.Add("是否续打", false);
                explorerForm.ReportParamData.Add("打印数据", table);
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dgvDocContent_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell currCell = this.dgvDocContent.CurrentCell;
            if (currCell == null)
                return;

            if (currCell.ColumnIndex != this.colHosPoint.Index)
                return;

            TextBox textBoxExitingControl = e.Control as TextBox;
            if (textBoxExitingControl == null || textBoxExitingControl.IsDisposed)
                return;
            textBoxExitingControl.ImeMode = ImeMode.Alpha;
            textBoxExitingControl.KeyPress -= new KeyPressEventHandler(this.TextBoxExitingControl_KeyPress);
            textBoxExitingControl.KeyPress += new KeyPressEventHandler(this.TextBoxExitingControl_KeyPress);
        }

        private void dgvDocTime_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell currCell = this.dgvDocTime.CurrentCell;
            if (currCell == null)
                return;

            if (currCell.ColumnIndex != this.colDocPoint.Index)
                return;

            TextBox textBoxExitingControl = e.Control as TextBox;
            if (textBoxExitingControl == null || textBoxExitingControl.IsDisposed)
                return;
            textBoxExitingControl.ImeMode = ImeMode.Alpha;
            textBoxExitingControl.KeyPress -= new KeyPressEventHandler(this.TimesTextBoxExitingControl_KeyPress);
            textBoxExitingControl.KeyPress += new KeyPressEventHandler(this.TimesTextBoxExitingControl_KeyPress);
        }

        private void TextBoxExitingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewCell currCell = this.dgvDocContent.CurrentCell;
            if (currCell == null)
                return;

            if (currCell.ColumnIndex == this.colHosPoint.Index)
            {
                if (e.KeyChar == (char)((int)Keys.Back))
                    return;
                if (e.KeyChar.CompareTo('0') >= 0 && e.KeyChar.CompareTo('9') <= 0)
                    return;
                if (e.KeyChar.CompareTo('.') == 0)
                    return;
                e.Handled = true;
            }
        }

        private void TimesTextBoxExitingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewCell currCell = this.dgvDocTime.CurrentCell;
            if (currCell == null)
                return;

            if (currCell.ColumnIndex == this.colDocPoint.Index)
            {
                if (e.KeyChar == (char)((int)Keys.Back))
                    return;
                if (e.KeyChar.CompareTo('0') >= 0 && e.KeyChar.CompareTo('9') <= 0)
                    return;
                if (e.KeyChar.CompareTo('.') == 0)
                    return;
                e.Handled = true;
            }
        }

        private void dgvDocContent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currCell = this.dgvDocContent.CurrentCell;
            if (currCell == null)
                return;
            if (currCell.ColumnIndex != this.colHosPoint.Index)
                return;
            if (currCell.Value == null)
                return;

            object oPoint = this.dgvDocContent.Rows[currCell.RowIndex].Cells[this.colPoint.Index].Value;
            if (oPoint == null || string.IsNullOrEmpty(oPoint.ToString()))
                return;

            float fPointValue = GlobalMethods.Convert.StringToValue(oPoint.ToString(), 0f);
            float fCellValue = GlobalMethods.Convert.StringToValue(currCell.Value.ToString(), 0f);

            if (fPointValue < fCellValue)
            {
                currCell.Value = oPoint.ToString();
                return;
            }

            EMRDBLib.QcMsgDict qcTemplet = this.dgvDocContent.Rows[currCell.RowIndex].Tag as EMRDBLib.QcMsgDict;
            if (qcTemplet == null)
                return;

            //病历得分=病历原始得分-（单元格原始值-修改后单元格的值）
            float fHosScore = GlobalMethods.Convert.StringToValue(qcTemplet.HosScore, 0f);
            float fTxtScore = GlobalMethods.Convert.StringToValue(this.txtScore.Text, 0f);
            float fTotalScore = fTxtScore + (fHosScore - fCellValue);
            float fContentPoint = GlobalMethods.Convert.StringToValue(this.txtContentPoint.Text, 0f) - (fHosScore - fCellValue);
            this.CalcDocScore(fTotalScore);
            this.txtContentPoint.Text = fContentPoint.ToString();
            qcTemplet.HosScore = currCell.Value.ToString();
            this.dgvDocContent.Rows[currCell.RowIndex].Tag = qcTemplet;
            this.NeedSave = true;
        }

        private void dgvDocTime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currCell = this.dgvDocTime.CurrentCell;
            if (currCell == null)
                return;
            if (currCell.ColumnIndex != this.colDocPoint.Index)
                return;
            if (currCell.Value == null)
                return;

            TimeCheckResult resultInfo = this.dgvDocTime.Rows[currCell.RowIndex].Tag as TimeCheckResult;
            if (resultInfo == null)
                return;

            //病历得分=病历原始得分-（单元格原始值-修改后单元格的值）
            float fTotalScore = float.Parse(this.txtScore.Text) + (resultInfo.QCScore - float.Parse(currCell.Value.ToString()));
            float fTimePoint = float.Parse(this.txtTimePoint.Text) - (resultInfo.QCScore - float.Parse(currCell.Value.ToString()));
            this.CalcDocScore(fTotalScore);
            this.txtTimePoint.Text = fTimePoint.ToString();
            resultInfo.QCScore = float.Parse(currCell.Value.ToString());
            this.dgvDocTime.Rows[currCell.RowIndex].Tag = resultInfo;
            this.NeedSave = true;
        }

        private void dgvDocContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (this.dgvDocContent.CurrentCell == null)
                return;
            EMRDBLib.MedicalQcMsg qcQuestionInfo = this.dgvDocContent.CurrentRow.Cells[this.colItem.Index].Tag as EMRDBLib.MedicalQcMsg;
            if (qcQuestionInfo != null && m_lstQCQuestionInfos != null)
            {
                foreach (EMRDBLib.MedicalQcMsg item in m_lstQCQuestionInfos)
                {
                    if (item.QC_MSG_CODE == qcQuestionInfo.QC_MSG_CODE && item.POINT_TYPE == 0)
                    {
                        MessageBox.Show("您已经添加过该类型的质检问题，请在质检问题中修改分数！");
                        this.dgvDocContent.CurrentCell.ReadOnly = true;
                        return;
                    }
                }
            }
            if (this.dgvDocContent.CurrentCell == this.dgvDocContent.Rows[e.RowIndex].Cells[this.colHosPoint.Index])
            {
                this.dgvDocContent.CurrentCell.ReadOnly = false;
                this.dgvDocContent.BeginEdit(true);
            }
        }

        private void dgvDocTime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (this.dgvDocTime.CurrentCell == null)
                return;

            if (this.dgvDocContent.CurrentCell == this.dgvDocTime.Rows[e.RowIndex].Cells[this.colDocPoint.Index])
                this.dgvDocTime.BeginEdit(true);
        }

        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void ReportExplorerForm_NotifyNextReport(object sender, Heren.Common.Report.NotifyNextReportEventArgs e)
        {
            e.ReportData = this.GetReportFileData(e.ReportName);
        }

        protected override void OnPatientInfoChanging(CancelEventArgs e)
        {
            base.OnPatientInfoChanging(e);
            if (!this.NeedSave)
                return;
            DialogResult diaResult = MessageBoxEx.ShowConfirm("当前病案评分没有保存，是否保存?");
            if (diaResult == DialogResult.OK)
            {
                this.SaveDocScore();
            }
            this.NeedSave = false;
        }
    }


    
}