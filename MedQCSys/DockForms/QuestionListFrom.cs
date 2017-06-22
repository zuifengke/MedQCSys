// ***********************************************************
// 病案质控系统质控问题管理窗口,负责已有问题的显示\修改\删除
// 以及新问题的提出.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Controls;
using Heren.Common.Controls.TableView;
using Heren.Common.Controls.VirtualTreeView;

using MedQCSys.Dialogs;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.Common.VectorEditor.Print;
using System.Drawing.Printing;
using MedQCSys.Document;

namespace MedQCSys.DockForms
{
    public partial class QuestionListForm : DockContentBase
    {
        /// <summary>
        /// 已有病历列表中合并文档节点标识
        /// </summary>
        private const string COMBIN_NODE_TAG = "COMBIN_NODE";
        /// <summary>
        /// 医生写的病历
        /// </summary>
        private const string DOCTOR_NODE_TAG = "DOC_NODE";
        /// <summary>
        /// 护士写的病历
        /// </summary>
        private const string NURSE_NODE_TAG = "NUR_NODE";
        /// <summary>
        /// 未知类型的病历
        /// </summary>
        private const string UNKNOWN_NODE_TAG = "UNKNOWN_NODE";
        /// <summary>
        /// 行状态是新建
        /// </summary>
        private const string STATUS_NEW = "NEW";
        /// <summary>
        /// 行状态是修改
        /// </summary>
        private const string STATUS_MODIFY = "MODIFY";
        /// <summary>
        /// 行状态是删除
        /// </summary>
        private const string STATUS_DELETE = "DELETE";
        /// <summary>
        /// 行状态是正常
        /// </summary>
        private const string STATUS_NORMAL = "NORMAL";

        /// <summary>
        /// 保存质检问题模板的哈希表
        /// </summary>
        private Hashtable m_htMsgDict = null;

        private string m_szDocSetID;
        /// <summary>
        /// 获取或设置病历的文档集编号
        /// </summary>
        public string DocSetID
        {
            get { return this.m_szDocSetID; }
            set { this.m_szDocSetID = value; }
        }

        private string m_szDocTitle;
        /// <summary>
        /// 获取或设置病历的标题
        /// </summary>
        public string DocTitle
        {
            get { return this.m_szDocTitle; }
            set { this.m_szDocTitle = value; }
        }

        private Hashtable m_htMsgCodeTable = null;

        private string m_PrintName = string.Empty;
        private int m_iQTotalNum = 0;//问题总数
        private int m_iPrintedNum = 0;//已打印问题数
        private int m_iPrintingPageIndex = 0; //当前正打印第几页
        private int m_iTotalPageNum = 0; //需要打印的总页数
        private const int NUM_PER_PAGE = 22;//每页问题记录最大数
        List<UserInfo> m_lstUserInfo = null;
        public List<UserInfo> ListUserInfo
        {
            get
            {
                if (m_lstUserInfo == null)
                {
                    m_lstUserInfo = new List<UserInfo>();
                    UserAccess.Instance.GetAllUserInfos(ref m_lstUserInfo);
                }
                return m_lstUserInfo;
            }
        }

        public QuestionListForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.DockBottom;
            this.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
            this.HideOnClose = true;
            this.CloseButtonVisible = false;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
            this.dataGridView1.AutoReadonly = true;
            this.toolbthQChat.Visible = SystemParam.Instance.LocalConfigOption.IsShowChat;
            this.toolbtnLock.Visible = SystemParam.Instance.LocalConfigOption.IsShowDocLock;
            this.colLockStatus.Visible = SystemParam.Instance.LocalConfigOption.IsShowDocLock;
        }

        /// <summary>
        /// 刷新患者质控质检问题列表
        /// </summary>
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            if (!this.SaveUncommitedChange())
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在刷新质控质检问题，请稍候...");
            this.LoadQCMsgDict();
            this.LoadQCQuestionList();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        protected override void OnPatientInfoChanging(CancelEventArgs e)
        {
            //取消切换到新患者时的第二次调用
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            //保存未被保存的改变
            if (!this.SaveUncommitedChange())
                e.Cancel = true;
            else
                this.dataGridView1.Rows.Clear();
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
        /// 当切换活动文档时刷新数据
        /// </summary>
        protected override void OnActiveContentChanged()
        {
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this && this.NeedRefreshView && this.IsActivated)
                this.OnRefreshView();
        }

        /// <summary>
        /// 装载质控质检问题
        /// </summary>
        private void LoadQCQuestionList()
        {
            this.dataGridView1.Rows.Clear();
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            if (this.m_htMsgCodeTable == null)
                this.m_htMsgCodeTable = new Hashtable();
            else
                this.m_htMsgCodeTable.Clear();
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
            if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count <= 0)
                return;

            for (int index = 0; index < lstQCQuestionInfos.Count; index++)
            {
                EMRDBLib.MedicalQcMsg qcQuestionInfo = lstQCQuestionInfos[index];
                if (qcQuestionInfo == null)
                    continue;

                if (!this.m_htMsgCodeTable.ContainsKey(qcQuestionInfo.QC_MSG_CODE))
                    this.m_htMsgCodeTable.Add(qcQuestionInfo.QC_MSG_CODE, qcQuestionInfo);
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = qcQuestionInfo;
                this.SetRowData(row, qcQuestionInfo);
            }
            if (this.dataGridView1.Rows.Count > 0)
            {
                this.dataGridView1.ClearSelection();
            }
        }
        List<EMRDBLib.QcMsgDict> lstQCMessageTemplet = null;
        private void LoadQCMsgDict()
        {
            short shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(ref lstQCMessageTemplet);
            if (shRet != SystemData.ReturnValue.OK && lstQCMessageTemplet == null)
                return;
            if (this.m_htMsgDict == null)
                this.m_htMsgDict = new Hashtable();
            for (int index = 0; index < lstQCMessageTemplet.Count; index++)
            {
                EMRDBLib.QcMsgDict messageTemplet = lstQCMessageTemplet[index];
                if (!m_htMsgDict.ContainsKey(messageTemplet.QC_MSG_CODE))
                    this.m_htMsgDict.Add(messageTemplet.QC_MSG_CODE, messageTemplet);
            }
        }

        /// <summary>
        /// 检查是否有未提交的修改
        /// </summary>
        /// <returns>bool</returns>
        public override bool HasUncommit()
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return false;
            foreach (DataTableViewRow row in this.dataGridView1.Rows)
            {
                if (this.dataGridView1.IsDeletedRow(row))
                    return true;
                if (this.dataGridView1.IsNewRow(row))
                    return true;
                if (this.dataGridView1.IsModifiedRow(row))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 保存质控反馈问题类型列表的修改
        /// </summary>
        /// <returns>bool</returns>
        public bool CommitModify(string szDocTitle, string szDocSetID, string szCreatorName, byte[] byteDocData)
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return true;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            int count = 0;
            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index < this.dataGridView1.Rows.Count; index++)
            {
                DataTableViewRow row = this.dataGridView1.Rows[index];
                //取得问题大类列的Tag属性,判断当前行新建、修改还是删除状态。
                string szRowState = (string)row.Cells[this.colQCEventType.Index].Tag;
                if (szRowState == STATUS_NORMAL)
                    continue;

                shRet = this.SaveRowData(row, szRowState, szDocTitle, szDocSetID, szCreatorName, byteDocData);
                if (shRet == SystemData.ReturnValue.OK)
                    count++;
                else if (shRet == SystemData.ReturnValue.FAILED)
                    break;
            }
            if (count > 0)
            {
                //hhhh
                //增加质控人员病案检查记录
                EMRDBLib.MedicalQcLog actionLog = new EMRDBLib.MedicalQcLog();
                bool bOK = QuestionListForm.MakeQCActionLog(ref actionLog);

                //获取选中的病历的DocID记录到medical_qc_log表
                if (this.MainForm.ActiveDocument is IDocumentForm)
                {
                    IDocumentForm document = this.MainForm.ActiveDocument as IDocumentForm;
                    if (this.MainForm.ActiveDocument is HerenDocForm)
                    {
                        HerenDocForm herendocument = this.MainForm.ActiveDocument as HerenDocForm;
                        if (herendocument.TextEditor.GetCurrentSection() != null)
                        {
                            string szDocID = herendocument.TextEditor.GetCurrentSection().ID;
                            actionLog.DOC_SETID = szDocID;
                            LogManager.Instance.WriteLog(szDocID);
                        }
                    }
                    else
                        actionLog.DOC_SETID = document.Document.DOC_ID;
                }
                else
                    actionLog.DOC_SETID = szDocSetID;
                if (bOK)
                {
                    actionLog.LOG_DESC = "质控者添加质检问题";

                    this.SaveQCActionLog(actionLog);
                }
            }

            this.RefreshQCResultStatus();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            string szMessageText = null;
            if (shRet == SystemData.ReturnValue.FAILED)
            {
                szMessageText = string.Format("保存失败,已保存{0}条记录！", count);
                MessageBoxEx.Show(szMessageText, MessageBoxIcon.Information);
            }
            return shRet == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="medicalQcMsg">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataTableViewRow row, MedicalQcMsg medicalQcMsg)
        {
            if (row == null || row.Index < 0 || medicalQcMsg == null)
                return false;
            if (this.m_htMsgDict == null)
                return false;

            row.Tag = medicalQcMsg;
            if (medicalQcMsg.LOCK_STATUS)
                row.Cells[this.colLockStatus.Index].Value = Properties.Resources._lock;
            row.Cells[this.colQCEventType.Index].Value = medicalQcMsg.QA_EVENT_TYPE;
            row.Cells[this.colQCEventType.Index].Tag = STATUS_NORMAL;
            if (this.m_htMsgDict.Contains(medicalQcMsg.QC_MSG_CODE))
            {
                EMRDBLib.QcMsgDict qcMessage = this.m_htMsgDict[medicalQcMsg.QC_MSG_CODE] as EMRDBLib.QcMsgDict;
                if (qcMessage == null)
                    return false;

                row.Cells[this.colMessage.Index].Value = string.IsNullOrEmpty(qcMessage.MESSAGE_TITLE) ? qcMessage.QA_EVENT_TYPE : qcMessage.MESSAGE_TITLE;
                row.Cells[this.colScore.Index].Value =
                        medicalQcMsg.POINT;
                row.Cells[this.colScore.Index].Tag =
                medicalQcMsg.POINT;
            }
            row.Cells[this.colMessage.Index].Tag = medicalQcMsg.QC_MSG_CODE;
            if (medicalQcMsg.ISSUED_DATE_TIME != medicalQcMsg.DefaultTime)
                row.Cells[this.colCheckTime.Index].Value = medicalQcMsg.ISSUED_DATE_TIME.ToString("yyyy-M-d HH:mm");
            if (medicalQcMsg.ASK_DATE_TIME != medicalQcMsg.DefaultTime)
                row.Cells[this.colConfirmTime.Index].Value = medicalQcMsg.ASK_DATE_TIME.ToString("yyyy-M-d HH:mm");
            row.Cells[this.colDocTitle.Index].Value = medicalQcMsg.TOPIC;
            row.Cells[this.colDocTitle.Index].Tag = medicalQcMsg.TOPIC_ID;
            row.Cells[this.colFeedBackInfo.Index].Value = medicalQcMsg.DOCTOR_COMMENT;
            row.Cells[this.colDetailInfo.Index].Value = medicalQcMsg.MESSAGE;
            row.Cells[this.colCreator.Index].Value = medicalQcMsg.DOCTOR_IN_CHARGE;
            row.Cells[this.colDept_Code.Index].Value = medicalQcMsg.DEPT_STAYED;
            //质检者姓名显示权限，有权利或者是自己添加的
            //显示权限改到质控权限控制
            row.Cells[this.colIssusdBy.Index].Value = medicalQcMsg.ISSUED_BY;

            row.Cells[this.colMsgStatus.Index].Value = SystemData.MsgStatus.GetCnMsgState(medicalQcMsg.MSG_STATUS);
            if (medicalQcMsg.MSG_STATUS == SystemData.MsgStatus.UnCheck) //0为未接收、未确认状态
            {
                row.Cells[this.colMsgStatus.Index].Style.ForeColor = Color.Red;
            }
            else if (medicalQcMsg.MSG_STATUS ==
               SystemData.MsgStatus.Checked)//1为已接收、已确认状态
            {
                row.Cells[this.colMsgStatus.Index].Style.ForeColor = Color.Yellow;
            }
            else if (medicalQcMsg.MSG_STATUS == SystemData.MsgStatus.Modified)//2为已修改状态
            {
                row.Cells[this.colMsgStatus.Index].Style.ForeColor = Color.Blue;
            }
            else if (medicalQcMsg.MSG_STATUS == SystemData.MsgStatus.Pass)
            {
                row.Cells[this.colMsgStatus.Index].Style.ForeColor = Color.Green;
            }
            row.State = RowState.Normal;
            return true;
        }

        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="qcQuestionInfo">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref EMRDBLib.MedicalQcMsg qcQuestionInfo)
        {
            if (row == null || row.Index < 0)
            {
                MessageBoxEx.Show("质控质检问题数据行非法，不可用！");
                return false;
            }

            if (SystemParam.Instance.UserInfo == null)
            {
                MessageBoxEx.Show("您还没有登录系统！");
                return false;
            }

            if (SystemParam.Instance.PatVisitInfo == null)
            {
                MessageBoxEx.Show("您没有选择任何患者！");
                return false;
            }

            EMRDBLib.MedicalQcMsg oldQCQuestionInfo = row.Tag as EMRDBLib.MedicalQcMsg;
            if (oldQCQuestionInfo == null)
            {
                MessageBoxEx.Show("质控质检问题行数据信息为空！");
                return false;
            }
            string szQCEventType = (string)row.Cells[this.colQCEventType.Index].Value;
            if (GlobalMethods.Misc.IsEmptyString(szQCEventType))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colQCEventType.Index];
                MessageBoxEx.Show("您必须选择反馈问题类型！");
                return false;
            }

            string szMessageCode = (string)row.Cells[this.colMessage.Index].Tag;
            string szMessageContent = (string)row.Cells[this.colDetailInfo.Index].Value;
            if (GlobalMethods.Misc.IsEmptyString(szMessageCode)
                || GlobalMethods.Misc.IsEmptyString(szMessageContent))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colMessage.Index];
                MessageBoxEx.Show("您必须输入质检问题！");
                return false;
            }

            if (qcQuestionInfo == null)
                qcQuestionInfo = new EMRDBLib.MedicalQcMsg();
            qcQuestionInfo.MSG_ID = oldQCQuestionInfo.MSG_ID;
            qcQuestionInfo.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            qcQuestionInfo.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcQuestionInfo.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            //转科后BUG修改
            //科室取书写病历时所在的科室
            qcQuestionInfo.DEPT_STAYED = row.Cells[this.colDept_Code.Index].Value != null ? row.Cells[this.colDept_Code.Index].Value.ToString() : string.Empty;
            //DoctorInCharge取创建者
            qcQuestionInfo.DOCTOR_IN_CHARGE = row.Cells[this.colCreator.Index].Value != null ? row.Cells[this.colCreator.Index].Value.ToString() : string.Empty;
            qcQuestionInfo.PARENT_DOCTOR = SystemParam.Instance.PatVisitInfo.AttendingDoctor;
            qcQuestionInfo.SUPER_DOCTOR = SystemParam.Instance.PatVisitInfo.SUPER_DOCTOR;
            qcQuestionInfo.QA_EVENT_TYPE = szQCEventType;
            qcQuestionInfo.QC_MSG_CODE = szMessageCode;
            qcQuestionInfo.MESSAGE = szMessageContent;
            if (oldQCQuestionInfo.MSG_STATUS != 0)
                qcQuestionInfo.MSG_STATUS = oldQCQuestionInfo.MSG_STATUS;
            else
                qcQuestionInfo.MSG_STATUS = 0;
            qcQuestionInfo.ISSUED_BY = SystemParam.Instance.UserInfo.Name;
            qcQuestionInfo.ISSUED_DATE_TIME = oldQCQuestionInfo.ISSUED_DATE_TIME;
            qcQuestionInfo.ISSUED_ID = SystemParam.Instance.UserInfo.ID;
            qcQuestionInfo.POINT_TYPE = 0;
            qcQuestionInfo.QCDOC_TYPE = oldQCQuestionInfo.QCDOC_TYPE;
            qcQuestionInfo.ISSUED_TYPE = SystemData.IssuedType.NORMAL;
            if (row.Cells[this.colScore.Index].Tag != null)
                qcQuestionInfo.POINT = float.Parse(row.Cells[this.colScore.Index].Tag.ToString());
            return true;
        }

        /// <summary>
        /// 保存指定行的数据到远程数据表,需要注意的是：行的删除状态会与其他状态共存
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="szDocSetID">病历文档集ID</param>
        /// <param name="szDocTitle">病历文档标题</param>
        /// <param name="szRowState">行状态</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short SaveRowData(DataTableViewRow row, string szRowState, string szDocTitle, string szDocSetID
            , string szCreatorName, byte[] byteDocData)
        {
            DateTime dtBeginTime1 = DateTime.Now;
            if (row == null || row.Index < 0)
                return SystemData.ReturnValue.FAILED;

            EMRDBLib.MedicalQcMsg qcQuestionInfo = row.Tag as EMRDBLib.MedicalQcMsg;
            if (qcQuestionInfo == null)
                return SystemData.ReturnValue.FAILED;

            string szPatientID = qcQuestionInfo.PATIENT_ID;
            string szVisitID = qcQuestionInfo.VISIT_ID;
            string szQuestionCode = qcQuestionInfo.QC_MSG_CODE;
            DateTime dtCheckTime = qcQuestionInfo.ISSUED_DATE_TIME;
            qcQuestionInfo = null;
            if (!this.MakeRowData(row, ref qcQuestionInfo))
                return SystemData.ReturnValue.FAILED;

            //如果病历的创建者不为空，修改经治医生的姓名为创建者，这样在医生站创建者就能收到质控发来的质检问题。
            if (!string.IsNullOrEmpty(szCreatorName))
                qcQuestionInfo.DOCTOR_IN_CHARGE = szCreatorName;

            short shRet = SystemData.ReturnValue.OK;
            if (szRowState == STATUS_DELETE)
            {
                if (!this.dataGridView1.IsNewRow(row))
                    shRet = MedicalQcMsgAccess.Instance.Delete(qcQuestionInfo.MSG_ID);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法删除当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                this.dataGridView1.Rows.Remove(row);
                if (this.m_htMsgCodeTable.ContainsKey(qcQuestionInfo.QC_MSG_CODE))
                    this.m_htMsgCodeTable.Remove(qcQuestionInfo.QC_MSG_CODE);
            }
            else if (szRowState == STATUS_MODIFY)
            {
                DateTime dtNewCheckDate = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                shRet = MedicalQcMsgAccess.Instance.Update(qcQuestionInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                if (!string.IsNullOrEmpty(szDocSetID))
                {
                    qcQuestionInfo.TOPIC_ID = szDocSetID;
                    qcQuestionInfo.TOPIC = szDocTitle;
                    string szRemotePath = SystemParam.Instance.GetQCFtpDocPath(qcQuestionInfo, "smdf");
                    EmrDocAccess.Instance.UpdateQCDocToFtp(qcQuestionInfo, szRemotePath, dtNewCheckDate);
                }
                row.Cells[this.colQCEventType.Index].Tag = STATUS_NORMAL;
                row.Cells[this.colCheckTime.Index].Value = dtNewCheckDate.ToString("yyyy-M-d HH:mm");
                row.Cells[this.colScore.Index].Value = qcQuestionInfo.POINT;
                qcQuestionInfo.ISSUED_DATE_TIME = dtNewCheckDate;
                row.Tag = qcQuestionInfo;
                if (!this.m_htMsgCodeTable.ContainsKey(qcQuestionInfo.QC_MSG_CODE))
                    this.m_htMsgCodeTable.Add(qcQuestionInfo.QC_MSG_CODE, qcQuestionInfo);
            }
            else if (szRowState == STATUS_NEW)
            {
                qcQuestionInfo.QC_MODULE = "DOCTOR_MR";
                qcQuestionInfo.TOPIC_ID = szDocSetID;
                qcQuestionInfo.TOPIC = szDocTitle;
                qcQuestionInfo.MSG_STATUS = 0;
                shRet = MedicalQcMsgAccess.Instance.Insert(qcQuestionInfo);


                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Cells[this.colCheckTime.Index].Value = qcQuestionInfo.ISSUED_DATE_TIME.ToString("yyyy-M-d HH:mm");
                row.Cells[this.colDocTitle.Index].Value = szDocTitle;
                row.Cells[this.colDocTitle.Index].Tag = szDocSetID;
                row.Cells[this.colDetailInfo.Index].Value = qcQuestionInfo.MESSAGE;
                row.Cells[this.colScore.Index].Value = qcQuestionInfo.POINT;
                row.Cells[this.colQCEventType.Index].Tag = STATUS_NORMAL;
                row.Tag = qcQuestionInfo;
                if (!this.m_htMsgCodeTable.ContainsKey(qcQuestionInfo.QC_MSG_CODE))
                    this.m_htMsgCodeTable.Add(qcQuestionInfo.QC_MSG_CODE, qcQuestionInfo);
                //把病历保存到FTP上
                if (byteDocData != null)
                {
                    string szRemotePath = SystemParam.Instance.GetQCFtpDocPath(qcQuestionInfo, "smdf");
                    DateTime dtBeginTime = DateTime.Now;
                    shRet = EmrDocAccess.Instance.SaveQCDocToFTP(qcQuestionInfo.TOPIC_ID, qcQuestionInfo.ISSUED_DATE_TIME, szRemotePath, byteDocData);
                    DateTime dtEndTime = DateTime.Now;
                    LogManager.Instance.WriteLog(DateDiff("备份文档存到ftp", dtBeginTime, dtEndTime));
                }

            }
            DateTime dtEndTime1 = DateTime.Now;
            LogManager.Instance.WriteLog(DateDiff("保存质控信息", dtBeginTime1, dtEndTime1));
            row.State = RowState.Normal;
            return SystemData.ReturnValue.OK;
        }

        private string DateDiff(string szMessage, DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts = DateTime1.Subtract(DateTime2).Duration();
            dateDiff = szMessage + "用时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒" + ts.Milliseconds + "毫秒";
            return dateDiff;
        }
        /// <summary>
        /// 生成一条病案质量监控日志
        /// </summary>
        /// <param name="qcActionLog">生成的监控日志信息</param>
        /// <returns>bool</returns>
        public static bool MakeQCActionLog(ref EMRDBLib.MedicalQcLog qcActionLog)
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return false;
            if (qcActionLog == null)
                qcActionLog = new EMRDBLib.MedicalQcLog();
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
            qcActionLog.CHECK_TYPE = 5;
            qcActionLog.LOG_TYPE = 1;
            qcActionLog.LOG_DESC = "质控者添加质检问题";
            qcActionLog.AddQCQuestion = true;
            return true;
        }

        /// <summary>
        /// 保存一条病案质量监控日志
        /// </summary>
        /// <returns>bool</returns>
        private bool SaveQCActionLog(EMRDBLib.MedicalQcLog qcActionLog)
        {
            short shRet = MedicalQcLogAccess.Instance.Insert(qcActionLog);
            if (shRet != SystemData.ReturnValue.OK)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show(string.Format("病案质量监控日志保存失败！"));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 刷新病案质控结果状态
        /// </summary>
        private void RefreshQCResultStatus()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            string szQCResultStatus = string.Empty;
            float fScore = 0;
            short shRet = MedQCAccess.Instance.GetQCResultStatus(szPatientID, szVisitID, SystemParam.Instance.LocalConfigOption.GradingLow, ref fScore, ref szQCResultStatus);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("更新病案的质控结果状态失败！");
                return;
            }
            SystemParam.Instance.PatVisitInfo.QCResultStatus = szQCResultStatus;
            fScore = -1;
            //刷新病案状态标志
            if (this.MainForm != null && !this.MainForm.IsDisposed)
                this.MainForm.RefreshQCResultStatus(-1);
        }

        /// <summary>
        /// 检查是否允许将当前病案设置为审查通过
        /// </summary>
        /// <returns>bool</returns>
        private bool IsAllowSetAsPassed()
        {
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            string szQCResultStatus = SystemParam.Instance.PatVisitInfo.QCResultStatus;

            //如果有存在未确认的质检问题，则不允许标志为合格
            List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos = null;
            short shRet = SystemData.ReturnValue.OK;
            shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szPatientID, szVisitID, ref lstQCQuestionInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("查询质控质检问题列表时出错,无法标记为合格！");
                return false;
            }
            if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count <= 0)
                return true;
            for (int index = 0; index < lstQCQuestionInfos.Count; index++)
            {
                EMRDBLib.MedicalQcMsg qcQuestionInfo = lstQCQuestionInfos[index];
                if (qcQuestionInfo.MSG_STATUS.ToString() != MDSDBLib.SystemData.QCQuestionStatus.PASSCODE)//质检问题都被标记为合格
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    MessageBoxEx.Show("该病案存在未合格的质控质检问题,无法标记为合格！");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 将当前病案设置为审查通过
        /// </summary>
        private void SetMedRecordPassed()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            if (SystemParam.Instance.UserRight == null)
                return;


            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (!this.IsAllowSetAsPassed())
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }


            EMRDBLib.MedicalQcLog qcActionLog = new EMRDBLib.MedicalQcLog();
            if (!QuestionListForm.MakeQCActionLog(ref qcActionLog))
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            qcActionLog.LOG_DESC = "病案设置为合格";
            short shRet = MedicalQcLogAccess.Instance.Insert(qcActionLog);

            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("病案质量监控日志保存失败！");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            this.RefreshQCResultStatus();
            DialogResult reslut = DialogResult.OK;
            reslut = MessageBoxEx.Show("病案已成功标志为合格！现在是否对病历进行评分？", MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if (reslut != DialogResult.OK)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            this.MainForm.ShowDocScoreForm();

            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        /// <summary>
        /// 增加一行记录
        /// </summary>
        /// <param name="szDocTitle">病历标题</param>
        /// <param name="szDocSetID">病历文档集ID</param>
        /// <param name="szCreatorName">创建者姓名</param>
        /// <param name="szDeptCode">创建者所在科室</param>
        /// <param name="byteDocData">文档数据</param>
        internal void AddNewItem(string szDocTitle, string szDocSetID, string szCreatorName, string szDeptCode, byte[] byteDocData)
        {
            if (!HasRightAddItem())
                return;

            //创建数据
            EMRDBLib.MedicalQcMsg qcQuestionInfo = new EMRDBLib.MedicalQcMsg();
            qcQuestionInfo.ISSUED_DATE_TIME = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            if (szDocTitle == null && szDocSetID == null && szCreatorName == null && szDeptCode == null)
            {
                short shRet = this.GetSelectedNodeDocInfo(ref szDocTitle, ref szDocSetID, ref szCreatorName, ref szDeptCode, ref byteDocData);
                if (shRet != SystemData.ReturnValue.OK)
                    return;
            }
            //创建行
            int index = this.dataGridView1.Rows.Add();
            DataTableViewRow row = this.dataGridView1.Rows[index];
            row.Tag = qcQuestionInfo;
            SelectQuestionForm questionTypeForm = new SelectQuestionForm();
            questionTypeForm.QCMessageTemplet = null;
            questionTypeForm.DocTitle = szDocTitle;
            questionTypeForm.Text = "质检问题新增";
            questionTypeForm.QCCheckTime = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            if (questionTypeForm.ShowDialog() != DialogResult.OK)
            {
                this.dataGridView1.Rows.Remove(row);
                return;
            }
            this.SetSelectedRowValues(row, questionTypeForm.QCMessageTemplet);
            this.dataGridView1.CurrentCell = row.Cells[this.colConfirmTime.Index];
            row.Cells[this.colQCEventType.Index].Tag = STATUS_NEW;
            row.Cells[this.colMsgStatus.Index].Value = "未接收";
            row.Cells[this.colDept_Code.Index].Value = string.IsNullOrEmpty(szDeptCode) ? SystemParam.Instance.PatVisitInfo.DEPT_CODE : szDeptCode;
            row.Cells[this.colCreator.Index].Value = string.IsNullOrEmpty(szCreatorName) ? SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR : szCreatorName; ;
            this.CommitModify(szDocTitle, szDocSetID, szCreatorName, byteDocData);
            this.UpdatePatientScore();
        }

        /// <summary>
        ///修改选中行数据
        /// </summary>
        private void ModifySelectedItem()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;

            if (SystemParam.Instance.UserRight == null)
                return;

            DataTableViewRow row = this.dataGridView1.SelectedRows[0];
            if (row.Cells[this.colQCEventType.Index].Value == null)
                return;

            if (row.Cells[this.colConfirmTime.Index].Value != null)
            {
                MessageBoxEx.Show("该质检问题已经被确认，不允许您修改！", MessageBoxIcon.Warning);
                return;
            }
            EMRDBLib.MedicalQcMsg questionInfo = row.Tag as EMRDBLib.MedicalQcMsg;
            if (questionInfo == null)
                return;

            if (questionInfo.ISSUED_BY != SystemParam.Instance.UserInfo.Name
                && !SystemConfig.Instance.Get(SystemData.ConfigKey.MODIFY_OR_DELETE_QUESTION, false))
            {
                MessageBoxEx.Show("该质检问题不是您添加的，不允许您修改！", MessageBoxIcon.Warning);
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            row.Cells[this.colQCEventType.Index].Tag = STATUS_MODIFY;
            EMRDBLib.QcMsgDict messageTemplet = new EMRDBLib.QcMsgDict();
            messageTemplet.QA_EVENT_TYPE = row.Cells[this.colQCEventType.Index].Value.ToString();
            messageTemplet.MESSAGE = row.Cells[this.colDetailInfo.Index].Value.ToString();
            if (row.Cells[this.colMessage.Index].Value != null)
                messageTemplet.MESSAGE_TITLE = row.Cells[this.colMessage.Index].Value.ToString();
            messageTemplet.QC_MSG_CODE = row.Cells[this.colMessage.Index].Tag.ToString();
            if (row.Cells[this.colScore.Index].Value != null)
                messageTemplet.SCORE = float.Parse(row.Cells[this.colScore.Index].Value.ToString());
            messageTemplet.QCDocType = questionInfo.QCDOC_TYPE;
            SelectQuestionForm frmQuestion = new SelectQuestionForm();
            frmQuestion.QCMessageTemplet = messageTemplet;
            frmQuestion.QCAskDateTime = (string)row.Cells[this.colConfirmTime.Index].Value;
            frmQuestion.DoctorComment = (string)row.Cells[this.colFeedBackInfo.Index].Value;
            frmQuestion.Text = "质检问题查询修改";
            frmQuestion.DocTitle = (string)row.Cells[this.colDocTitle.Index].Value;
            if (row.Cells[this.colCheckTime.Index].Value != null)
                frmQuestion.QCCheckTime = DateTime.Parse(row.Cells[this.colCheckTime.Index].Value.ToString());
            if (frmQuestion.ShowDialog() != DialogResult.OK)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            this.SetSelectedRowValues(row, frmQuestion.QCMessageTemplet);
            string szDocTitle = (string)row.Cells[this.colDocTitle.Index].Value;
            string szDocSetID = (string)row.Cells[this.colDocTitle.Index].Tag;
            string szCreatorName = (string)row.Cells[this.colCheckTime.Index].Tag;
            this.CommitModify(szDocTitle, szDocSetID, szCreatorName, null);
            this.UpdatePatientScore();
            this.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 删除选中行数据
        /// </summary>
        private void DeleteSelectedItem()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;

            if (SystemParam.Instance.UserRight == null)
                return;

            DialogResult result = MessageBoxEx.Show("您真的要删除当前行吗?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;

            DataTableViewRow selectedRow = this.dataGridView1.SelectedRows[0];
            if (selectedRow == null)
                return;
            EMRDBLib.MedicalQcMsg questionInfo = selectedRow.Tag as EMRDBLib.MedicalQcMsg;
            if (questionInfo == null)
                return;
            
                if ( selectedRow.Cells[this.colConfirmTime.Index].Value != null)
                {
                    MessageBoxEx.Show("该质检问题已被确认，不能删除！", MessageBoxIcon.Warning);
                    return;
                }
                if (questionInfo.ISSUED_BY != SystemParam.Instance.UserInfo.Name
                    && !SystemConfig.Instance.Get(SystemData.ConfigKey.MODIFY_OR_DELETE_QUESTION, false))
                {
                    MessageBoxEx.Show("该质检问题不是您添加的，不允许您删除！", MessageBoxIcon.Warning);
                    return;
                }
           

            selectedRow.Cells[this.colQCEventType.Index].Tag = STATUS_DELETE;
            string szDocTitle = (string)selectedRow.Cells[this.colDocTitle.Index].Value;
            string szDocSetID = (string)selectedRow.Cells[this.colDocTitle.Index].Tag;
            string szCreatorName = (string)selectedRow.Cells[this.colCheckTime.Index].Tag;
            this.CommitModify(szDocTitle, szDocSetID, szCreatorName, null);
            this.UpdatePatientScore();
        }

        //查看历史病历
        private void OpenSelectedDocument()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            DataTableViewRow selectedRow = this.dataGridView1.SelectedRows[0];
            if (selectedRow == null)
                return;
            EMRDBLib.MedicalQcMsg questionInfo = selectedRow.Tag as EMRDBLib.MedicalQcMsg;
            if (questionInfo == null)
                return;
            this.MainForm.OpenHistoryDocument(questionInfo);

        }

        /// <summary>
        /// 给选中行的各个列赋值
        /// </summary>
        /// <param name="messageTemplet">质检问题模板对象</param>
        private void SetSelectedRowValues(DataTableViewRow selectedRow, EMRDBLib.QcMsgDict messageTemplet)
        {
            if (messageTemplet == null)
                return;
            if (m_htMsgDict == null)
                return;

            selectedRow.Cells[this.colQCEventType.Index].Value = messageTemplet.QA_EVENT_TYPE;
            if (this.m_htMsgDict.ContainsKey(messageTemplet.QC_MSG_CODE))
                selectedRow.Cells[this.colMessage.Index].Value = string.IsNullOrEmpty(messageTemplet.MESSAGE_TITLE) ?
                    this.m_htMsgDict[messageTemplet.QC_MSG_CODE] : messageTemplet.MESSAGE_TITLE;
            selectedRow.Cells[this.colMessage.Index].Tag = messageTemplet.QC_MSG_CODE;
            selectedRow.Cells[this.colDetailInfo.Index].Value = messageTemplet.MESSAGE;
            selectedRow.Cells[this.colScore.Index].Value = Math.Round(new decimal(GlobalMethods.Convert.StringToValue(messageTemplet.SCORE, 0f)), 1).ToString("F1");
            selectedRow.Cells[this.colScore.Index].Tag = Math.Round(new decimal(GlobalMethods.Convert.StringToValue(messageTemplet.SCORE, 0f)), 1).ToString("F1");
            EMRDBLib.MedicalQcMsg qcQuestionInfo = selectedRow.Tag as EMRDBLib.MedicalQcMsg;
            if (qcQuestionInfo != null)
            {
                qcQuestionInfo.QCDOC_TYPE = messageTemplet.QCDocType;
            }
        }

        /// <summary>
        /// 获取病程记录窗口选中节点的病历文档信息
        /// </summary>
        /// <param name="szDocTitle">病历文档标题</param>
        /// <param name="szDocSetID">病历文档ID</param>
        /// <param name="szCreatorName">病历创建者姓名</param>
        private short GetSelectedNodeDocInfo(ref string szDocTitle, ref string szDocSetID, ref string szCreatorName, ref string szDeptCode, ref byte[] byteDocData)
        {
            short shRet = SystemData.ReturnValue.OK;
            if (this.MainForm.DocumentListForm == null)
                return SystemData.ReturnValue.FAILED;
            if (this.MainForm.DocumentListForm.SelectedNode == null)
            {
                MessageBoxEx.Show("没有选中病历文书中任何一份病历，无法添加质检问题！", MessageBoxIcon.Warning);
                return SystemData.ReturnValue.FAILED;
            }
            VirtualNode selectedNode = this.MainForm.DocumentListForm.SelectedNode;
            MDSDBLib.MedDocInfo docInfo = selectedNode.Data as MDSDBLib.MedDocInfo;
            if (docInfo != null)
            {
                szDocTitle = docInfo.DocTitle;
                if (docInfo.FileType != "BAODIAN" && docInfo.FileType != "CHENPAD" && docInfo.FileType != "HEREN")
                    szDocSetID = string.Empty;
                else
                    szDocSetID = docInfo.DocSetID;
                szCreatorName = docInfo.CreatorName;
                szDeptCode = docInfo.DeptCode;
                EmrDocAccess.Instance.GetDocByID(docInfo.DocID, ref byteDocData);
            }
            else if (selectedNode.Data.Equals(COMBIN_NODE_TAG))
                szDocTitle = string.Concat(SystemParam.Instance.PatVisitInfo.PATIENT_NAME, "的病历");
            else if (selectedNode.Data.Equals(DOCTOR_NODE_TAG))
                szDocTitle = "医生写的病历";
            else if (selectedNode.Data.Equals(NURSE_NODE_TAG))
                szDocTitle = "护士写的病历";
            else if (selectedNode.Data.Equals(UNKNOWN_NODE_TAG))
                szDocTitle = "未被归类的病历";
            else
                szDocTitle = string.Concat(SystemParam.Instance.PatVisitInfo.PATIENT_NAME, "的以往旧病历");
            return shRet;
        }

        /// <summary>
        /// 判断当前登陆用户是否有权限添加质检问题
        /// </summary>
        /// <returns></returns>
        private bool HasRightAddItem()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return false;

            if (SystemParam.Instance.UserRight == null)
                return false;

           
            return true;
        }


        private void toolbtnNew_Click(object sender, EventArgs e)
        {
            this.AddNewQuestion();
        }

        private void AddNewQuestion()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
            {
                MessageBoxEx.Show("请选择一个患者！", MessageBoxIcon.Warning);
                return;
            }
            //先刷新下病历列表
            //if (this.MainForm.DocumentListForm.NeedRefreshView)
            //{
            //    this.MainForm.DocumentListForm.OnRefreshView();
            //}

            Document.IDocumentForm documentForm = this.MainForm.ActiveDocument as Document.IDocumentForm;
            DockForms.DockContentBase ActiveDocument = this.MainForm.ActiveDocument as DockForms.DockContentBase;

            //文档类型的质控
            if (documentForm != null)
            {
                if (documentForm.Documents.Count == 1) //单文档打开
                    this.AddNewItem(null, null, null, null, null);
                else if (documentForm.Documents.Count > 1) //合并打开
                    this.AddNewItem(ActiveDocument != null ? ActiveDocument.Text : "合并打开病历质控", null,
                        SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR, SystemParam.Instance.PatVisitInfo.DEPT_CODE, null);
            }
            else if (ActiveDocument != null)
            {
                if (ActiveDocument.Text == "病历文书")//病历列表增加质控
                    this.AddNewItem(null, null, null, null, null);
                else
                    this.AddNewItem(ActiveDocument.Text + "质控", null, SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR, SystemParam.Instance.PatVisitInfo.DEPT_CODE, null);
            }
        }

        /// <summary>
        /// 刷新此患者病案评分
        /// </summary>
        private void UpdatePatientScore()
        {
            this.MainForm.OnPatientScoreChanged(EventArgs.Empty);
        }

        private void toolbtnModify_Click(object sender, EventArgs e)
        {
            
            this.ModifySelectedItem();
        }

        private void toolbtnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedItem();
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            this.CommitModify();
        }

        private void toolbtnPass_Click(object sender, EventArgs e)
        {
            
            this.SetMedRecordPassed();
        }

        private void mnuAddItem_Click(object sender, EventArgs e)
        {
            this.AddNewQuestion();
        }

        private void mnuModifyItem_Click(object sender, EventArgs e)
        {
            this.ModifySelectedItem();
        }

        private void mnuDeleteItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedItem();
        }

        private void mnuOpenDoc_Click(object sender, EventArgs e)
        {
            this.OpenSelectedDocument();
        }

        private void mnuSaveItems_Click(object sender, EventArgs e)
        {
            this.CommitModify();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            this.ModifySelectedItem();
        }

        private void toolbtnRollback_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// 显示当前病历的质检问题，为空显示全部
        /// </summary>
        /// <param name="docInfo"></param>
        public void ShowQuestionListByDocInfo(MedDocInfo docInfo)
        {
            if (docInfo == null)
            {
                this.chbShowAll.Checked = true;
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row.Visible == false)
                        row.Visible = true;
                }
            }
            else
            {
                this.chbShowAll.Checked = false;
                szCurrentDocSetID = docInfo.DOC_SETID;
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    EMRDBLib.MedicalQcMsg qcQuestionInfo = row.Tag as EMRDBLib.MedicalQcMsg;
                    if (qcQuestionInfo == null)
                        continue;
                    if (qcQuestionInfo.TOPIC_ID == docInfo.DOC_SETID)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }

        }
        private string szCurrentDocSetID = string.Empty;
        private void chbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbShowAll.Checked == true)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row.Visible == false)
                        row.Visible = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    EMRDBLib.MedicalQcMsg qcQuestionInfo = row.Tag as EMRDBLib.MedicalQcMsg;
                    if (qcQuestionInfo == null)
                        continue;
                    if (qcQuestionInfo.TOPIC_ID == szCurrentDocSetID)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void toolbtnQCPass_Click(object sender, EventArgs e)
        {
            
            this.PassSelectedItem();
        }

        /// <summary>
        /// 将选中的问题设置成合格
        /// </summary>
        private void PassSelectedItem()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;

            if (SystemParam.Instance.UserRight == null)
                return;

            DataTableViewRow row = this.dataGridView1.SelectedRows[0];
            if (row.Cells[this.colQCEventType.Index].Value == null)
                return;

            EMRDBLib.MedicalQcMsg questionInfo = row.Tag as EMRDBLib.MedicalQcMsg;
            if (questionInfo == null)
                return;
            if (questionInfo.MSG_STATUS == 3)
            {
                MessageBoxEx.Show("当前质检问题已经是合格状态！", MessageBoxIcon.Warning);
                return;
            }
            else if (questionInfo.MSG_STATUS != 2)
            {
                MessageBoxEx.Show("当前质检问题医生未修改,不允许修改成合格状态！", MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBoxEx.Show("您真的要修改当前行质检问题为合格吗?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;
            questionInfo.MSG_STATUS = 3;
            short shRet = MedicalQcMsgAccess.Instance.Update(questionInfo);
            if (shRet == SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("质检问题已修改为合格！", MessageBoxIcon.Information);
                this.SetRowData(row, questionInfo);
                return;
            }
            else
            {
                MessageBoxEx.Show("质检问题修改失败！");
                return;
            }
        }

        private void toolbthQChat_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBoxEx.Show("请选择一条质检问题！");
                return;
            }
            DataTableViewRow row = this.dataGridView1.SelectedRows[0];
            if (row.Cells[this.colQCEventType.Index].Value == null)
                return;

            EMRDBLib.MedicalQcMsg questionInfo = row.Tag as EMRDBLib.MedicalQcMsg;
            if (questionInfo == null)
                return;

            StringBuilder sbArgs = new StringBuilder();
            string sbContent = GetMsgContent(questionInfo);
            UserInfo u = GetLinstenID(questionInfo);
            sbArgs.AppendFormat("{0};{1};{2}", SystemParam.Instance.UserInfo.ID, u == null ? "" : u.ID, sbContent);

            IntPtr fromHandle = GlobalMethods.Win32.GetSystemHandle(SystemData.MappingName.QUESTION_CHAT_CLIENT_SYS);
            IntPtr intParam = GlobalMethods.Win32.StringToPtr(sbArgs.ToString());
            NativeMethods.User32.ShowWindow(fromHandle, NativeConstants.SW_RESTORE);
            NativeMethods.User32.SetForegroundWindow(fromHandle);
            NativeMethods.User32.SendMessage(fromHandle, NativeConstants.WM_COPYDATA, IntPtr.Zero, intParam);
        }
        private UserInfo GetLinstenID(EMRDBLib.MedicalQcMsg questionInfo)
        {
            UserInfo u = null;
            if (questionInfo == null || string.IsNullOrEmpty(questionInfo.DOCTOR_IN_CHARGE))
            {
                u = ListUserInfo.Find(i => i.Name == SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR);
            }
            else
            {
                u = ListUserInfo.Find(i => i.Name == questionInfo.DOCTOR_IN_CHARGE);
            }
            return u;
        }

        /// <summary>
        /// 获取发送消息的内容
        /// </summary>
        /// <param name="questionInfo"></param>
        /// <returns></returns>
        private string GetMsgContent(EMRDBLib.MedicalQcMsg questionInfo)
        {
            if (questionInfo == null)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("病人:{0} 住院号:{1}{2}", SystemParam.Instance.PatVisitInfo.PATIENT_NAME,
                                                   SystemParam.Instance.PatVisitInfo.INP_NO, Environment.NewLine);
            sb.AppendFormat("病历主题:{0}{1}", questionInfo.TOPIC, Environment.NewLine);
            EMRDBLib.QcMsgDict qcMessageTemplet = lstQCMessageTemplet.Find(
              delegate (EMRDBLib.QcMsgDict q)
              {
                  return q.QC_MSG_CODE == questionInfo.QC_MSG_CODE;
              }
              );
            sb.AppendFormat("项目:{0}{1}", qcMessageTemplet != null ? qcMessageTemplet.MESSAGE : "", Environment.NewLine);
            sb.AppendFormat("内容:{0}{1}", questionInfo.MESSAGE, Environment.NewLine);
            sb.AppendFormat("扣分:{0}{1}", questionInfo.POINT, Environment.NewLine);

            return sb.ToString();
        }
        private void mnuPassItem_Click(object sender, EventArgs e)
        {
            
            this.PassSelectedItem();
        }

        private void toolbtnLock_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBoxEx.ShowMessage("请选择问题项，才能锁定");
                return;
            }
            EMRDBLib.MedicalQcMsg qcQuestionInfo = this.dataGridView1.SelectedRows[0].Tag as EMRDBLib.MedicalQcMsg;
            if (qcQuestionInfo == null)
            {
                return;
            }
            short shRet = SystemData.ReturnValue.OK;
            if (qcQuestionInfo.LOCK_STATUS)
            {
                shRet = MedicalQcMsgAccess.Instance.UpdateMesageLockStatus(false, qcQuestionInfo.MSG_ID);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowMessage("解除锁定成功");
                    qcQuestionInfo.LOCK_STATUS = false;
                    this.dataGridView1.SelectedRows[0].Cells[this.colLockStatus.Index].Value = Properties.Resources.empty;
                    this.toolbtnLock.Image = Properties.Resources._lock;
                    this.toolbtnLock.Text = "强制锁定";
                    return;
                }
                else
                {
                    MessageBoxEx.ShowError("解除锁定失败");
                }
            }

            if (MessageBoxEx.ShowConfirm("医生必须修改该问题才能继续书写病历，您确定强制锁定吗？") != DialogResult.OK)
                return;
            shRet = MedicalQcMsgAccess.Instance.UpdateMesageLockStatus(true, qcQuestionInfo.MSG_ID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("强制锁定失败");
            }
            MessageBoxEx.ShowMessage("锁定成功");
            qcQuestionInfo.LOCK_STATUS = true;
            this.dataGridView1.SelectedRows[0].Cells[this.colLockStatus.Index].Value = Properties.Resources._lock;
            this.toolbtnLock.Image = Properties.Resources.unlock;
            this.toolbtnLock.Text = "解除锁定";
            return;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EMRDBLib.MedicalQcMsg qcQuestionInfo = this.dataGridView1.Rows[e.RowIndex].Tag as EMRDBLib.MedicalQcMsg;
            if (qcQuestionInfo == null)
                return;
            if (qcQuestionInfo.LOCK_STATUS)
            {
                this.toolbtnLock.Image = Properties.Resources.unlock;
                this.toolbtnLock.Text = "解除锁定";
            }
            else
            {
                this.toolbtnLock.Image = Properties.Resources._lock;
                this.toolbtnLock.Text = "强制锁定";
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            EMRDBLib.MedicalQcMsg qcQuestionInfo = this.dataGridView1.Rows[e.RowIndex].Tag as EMRDBLib.MedicalQcMsg;
            if (qcQuestionInfo == null)
                return;
            if (qcQuestionInfo.LOCK_STATUS)
            {
                this.toolbtnLock.Image = Properties.Resources.unlock;
                this.toolbtnLock.Text = "解除锁定";
            }
            else
            {
                this.toolbtnLock.Image = Properties.Resources._lock;
                this.toolbtnLock.Text = "强制锁定";
            }
        }

        private void toolbtnPrint_Click(object sender, EventArgs e)
        {
            this.m_iQTotalNum = this.dataGridView1.Rows.Count;
            this.m_iPrintedNum = 0;
            this.m_iPrintingPageIndex = 1;
            this.m_iTotalPageNum = (this.m_iQTotalNum / NUM_PER_PAGE) + (this.m_iQTotalNum % NUM_PER_PAGE == 0 ? 0 : 1);
            this.printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("质控问题清单", new Font(new FontFamily("黑体"), 18, FontStyle.Bold), System.Drawing.Brushes.Black, 300, 35);
            int i = 0, width = 740, x = 50, y = 90, fontSize = 10;
            if (this.m_iPrintingPageIndex == 1)
            {
                e.Graphics.DrawString(string.Format("打印者：{0}    打印时间：{1}", SystemParam.Instance.UserInfo.Name, DateTime.Now.ToString()), new Font(new FontFamily("宋体"), 10, FontStyle.Regular), System.Drawing.Brushes.Black, 400, 70);
            }
            else
            {
                y -= 10;
            }
            e.Graphics.DrawLine(Pens.Black, x, y, width, y);
            y += 10;
            for (; m_iPrintedNum < this.dataGridView1.Rows.Count && m_iPrintedNum < this.m_iPrintingPageIndex * NUM_PER_PAGE; m_iPrintedNum++)
            {
                i++;
                DataGridViewRow dvr = this.dataGridView1.Rows[m_iPrintedNum];
                EMRDBLib.MedicalQcMsg que = dvr.Tag as EMRDBLib.MedicalQcMsg;
                if (que != null && !string.IsNullOrEmpty(que.PATIENT_ID))
                {
                    string szLineText = (this.m_iPrintedNum + 1).ToString() + ". ";
                    szLineText += string.Format("审核时间：{0}    审核人：{1}    问题状态：{2}", que.ISSUED_DATE_TIME.ToString(), dvr.Cells[this.colIssusdBy.Index].Value.ToString(), dvr.Cells[this.colMsgStatus.Index].Value.ToString());
                    e.Graphics.DrawString(szLineText, new Font(new FontFamily("宋体"), 8, FontStyle.Regular), System.Drawing.Brushes.Black, x, y);
                    y += 15;
                    e.Graphics.DrawString("问题：" + que.MESSAGE, new Font(new FontFamily("宋体"), fontSize, FontStyle.Bold), System.Drawing.Brushes.Black, x, y);
                    y += 20;
                    e.Graphics.DrawLine(Pens.Black, x, y, width, y);
                    y += 10;
                }
            }
            this.m_iPrintingPageIndex++;
            if (this.m_iPrintingPageIndex - 1 < this.m_iTotalPageNum)
            {
                e.HasMorePages = true;
                LogManager.Instance.WriteLog("多页打印执行过程(if)记录：" + e.HasMorePages.ToString());
            }
            else
            {
                e.HasMorePages = false;
                LogManager.Instance.WriteLog("多页打印执行过程(else)记录：" + e.HasMorePages.ToString());
            }
        }


        private string GetMsgStatusDesc(string statusCode)
        {
            switch (statusCode)
            {
                case "0":
                    return "未接收";
                case "1":
                    return "已接收";
                case "2":
                    return "已修改";
                case "3":
                    return "已合格";
                default:
                    return "未接收";
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            this.printDocument1.DocumentName = "质控问题";

            //根据纸张获取指定的打印机
            float fWidth = 210f;
            float fHeight = 297f;
            PaperInfo paperInfo = new PaperInfo(System.Drawing.Printing.PaperKind.A4, fWidth, fHeight);
            this.m_PrintName = GlobalMethods.Win32.GetSysDefaultPrinter();
            paperInfo.Printer = this.m_PrintName;

            SelectPrinterForm frmSelectPrinter = new SelectPrinterForm();
            frmSelectPrinter.SelectedPrinter = paperInfo.Printer;
            if (frmSelectPrinter.ShowDialog() != DialogResult.OK)
                return;

            if (!GlobalMethods.Misc.IsEmptyString(paperInfo.Printer) && paperInfo.Printer != this.m_PrintName)
                GlobalMethods.Win32.SetSysDefaultPrinter(paperInfo.Printer);
        }

        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            //恢复用户PC上的默认打印机,以不影响其他程序打印
            if (!GlobalMethods.Misc.IsEmptyString(this.m_PrintName))
                GlobalMethods.Win32.SetSysDefaultPrinter(this.m_PrintName);
        }

        private void mnuNotPassItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBoxEx.Show("请选择置为不合格的问题");
                return;
            }
            if (MessageBoxEx.ShowConfirm("您发现问题并未修改，确定将问题置为未修改并提醒医生重新修改吗？") != DialogResult.OK)
                return;
            DataTableViewRow row = this.dataGridView1.SelectedRows[0];
            MedicalQcMsg questionInfo = this.dataGridView1.SelectedRows[0].Tag as MedicalQcMsg;
            if (questionInfo == null)
            {
                MessageBoxEx.Show("质控信息不存在，无法将问题置为未修改");
                return;
            }
            questionInfo.MSG_STATUS = 0;
            short shRet = MedicalQcMsgAccess.Instance.Update(questionInfo);
            if (shRet == SystemData.ReturnValue.OK)
            {
                //将病历状态置为为质控退回

                shRet = EmrDocAccess.Instance.UpdateDocSignCode(questionInfo.TOPIC_ID, MedDocSys.DataLayer.SystemData.SignState.QC_ROLLBACK);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.Show("病历退回失败");
                    return;
                }
                MessageBoxEx.Show("质检问题置为不合格成功！", MessageBoxIcon.Information);
                this.SetRowData(row, questionInfo);
                return;
            }
            else
            {
                MessageBoxEx.Show("质检问题失败！");
                return;
            }
        }
    }
}