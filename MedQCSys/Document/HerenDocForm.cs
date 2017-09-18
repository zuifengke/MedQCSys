// ***********************************************************
// 病案质控系统文档容器窗口,多文档对应多个文档窗口
// Creator:LiChunYing  Date:2011-6-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using MedQCSys.DockForms;

using MedQCSys.Dialogs;
using Heren.Common.RichEditor;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace MedQCSys.Document
{
    public partial class HerenDocForm : DockContentBase, IDocumentForm
    {
        private TextEditor textEditorPrint = null;
        /// <summary>
        /// 缺陷检查按钮
        /// </summary>
        private FlatButton m_CheckDocBugButton = null;

        public HerenDocForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.textEditorPrint = new TextEditor();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.Icon = MedQCSys.Properties.Resources.MedDocIcon;

            //读配置文件判断是否需要添加【新增质检问题】按钮,如果为true则显示全部右键菜单。

            this.InsertMenuItem("新增质检问题", new EventHandler(mnuAddFeedInfo_Click));
            this.InsertMenuItem("保存", new EventHandler(textEditor1_SaveButtonClick));
            this.InsertMenuItem("自动检查缺陷", new EventHandler(this.CheckDocBugButton_Click));
            this.InsertMenuItem("插入批注", new EventHandler(mnuInsertCommentForm_Click));
            this.InsertMenuItem("删除批注", new EventHandler(mnuDeleteCommentForm_Click));
            this.InsertMenuItem("检索标准诊断", new EventHandler(mnuShowStandardTermForm_Click));
            this.InsertMenuItem("退回病历", new EventHandler(mnuRollbackDocument_Click));


            this.textEditor1.BeforeCopy += new CancelEventHandler(this.textEditor1_BeforeCopy);
            this.textEditor1.CommentEditMode = true;
            this.textEditor1.ReviseEnabled = false;
            this.textEditor1.RevisionVisible = false;
            this.textEditor1.FieldFlagColor = Color.Transparent;
        }
        private void InsertMenuItem(string szText, EventHandler handler)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = null;
            menuItem.Text = szText;
            if (handler != null)
                menuItem.Click += handler;
            this.PopupMenu.Items.Add(menuItem);
        }
        #region"IDocumentForm"
        /// <summary>
        /// 获取或设置当前文档信息
        /// </summary>
        public MedDocInfo Document
        {
            get
            {
                if (this.m_documents == null || this.m_documents.Count <= 0)
                    return null;
                return this.m_documents[0];
            }
        }
        private MedDocInfo m_ClickDocument;
        /// <summary>
        /// 选中的文档节点
        /// </summary>
        public MedDocInfo ClickDocument
        {
            get
            {
                if (this.m_ClickDocument == null)
                    this.m_ClickDocument = new MedDocInfo();
                return this.m_ClickDocument;
            }
            set
            {
                this.m_ClickDocument = value;
            }
        }
        private MedDocList m_documents = null;
        /// <summary>
        /// 获取或设置文档信息列表
        /// </summary>
        public MedDocList Documents
        {
            get { return this.m_documents; }
        }

        /// <summary>
        /// 获取本窗口中编辑器控件,新控件名为TextEditor
        /// </summary>
        public TextEditor TextEditor
        {
            get
            {
                if (this.textEditor1 == null || this.textEditor1.IsDisposed)
                    return null;
                return this.textEditor1;
            }
        }

        MedDocList IDocumentForm.Documents
        {
            get
            {
                return this.Documents;
            }
        }

        MedDocInfo IDocumentForm.Document
        {
            get
            {
                return this.Document;
            }
        }



        MedDocSys.PadWrapper.IMedEditor IDocumentForm.MedEditor
        {
            get { return null; }
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.InitCheckDocBugButton();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            this.CloseDocument();
            if (this.textEditor1 != null && !this.textEditor1.IsDisposed)
                this.textEditor1.Dispose();
            if (this.m_CheckDocBugButton != null && !this.m_CheckDocBugButton.IsDisposed)
                this.m_CheckDocBugButton.Dispose();
        }

        protected override void OnPatientInfoChanged()
        {
            base.OnPatientInfoChanged();
            this.Close();
        }

        /// <summary>
        /// 刷新文档窗口显示标题
        /// </summary>
        /// <param name="szDocTitle">文档显示标题</param>
        public void RefreshFormTitle(string szDocTitle)
        {
            string szTabText = szDocTitle;
            if (this.Documents == null || this.Documents.Count <= 0)
                szTabText = "病历文档窗口";

            if (this.Document != null)
                szTabText = this.Document.DOC_TITLE;
            if (this.Documents.Count > 1)
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    szTabText = "病历文档窗口";
                else
                    szTabText = string.Concat(SystemParam.Instance.PatVisitInfo.PATIENT_NAME, "的病历");
            }
            if (GlobalMethods.Misc.IsEmptyString(szTabText))
                szTabText = "病历文档窗口";
            this.Text = szTabText;
            if (this.Document != null)
            {
                this.TabSubhead = string.Format("{0} {1}", this.Document.CREATOR_NAME
                    , this.Document.DOC_TIME.ToString("yyyy-M-d HH:mm"));
            }
        }

        /// <summary>
        /// 质控人员打开历史病历
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenHistoryDocument(EMRDBLib.MedicalQcMsg questionInfo)
        {
            MedDocInfo docInfo = new MedDocInfo();
            docInfo.PATIENT_ID = questionInfo.PATIENT_ID;
            docInfo.VISIT_ID = questionInfo.VISIT_ID;
            docInfo.DOC_SETID = questionInfo.TOPIC_ID;
            docInfo.DOC_TITLE = questionInfo.TOPIC;
            docInfo.CREATOR_NAME = questionInfo.ISSUED_BY;
            docInfo.DOC_TIME = questionInfo.ISSUED_DATE_TIME;
            docInfo.DOC_ID = questionInfo.TOPIC_ID;
            this.m_documents = new MedDocList();
            this.m_documents.Add(docInfo);
            this.RefreshFormTitle(null);
            byte[] byteSmdfData = null;
            string szRemoteFile = SystemParam.Instance.GetQCFtpDocPath(questionInfo, "smdf");
            short shRet = EmrDocAccess.Instance.GetFtpHistoryDocByID(docInfo.DOC_SETID, questionInfo.ISSUED_DATE_TIME, szRemoteFile, ref byteSmdfData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("无法打开文档！文档数据下载失败！");
                return shRet;
            }
            //编辑器控件加载文档
            bool result = textEditor1.LoadDocument2(byteSmdfData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("无法打开文档！文档数据加载失败！");
                return shRet;
            }
            this.textEditor1.ReviseEnabled = true;
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 打开指定的文档
        /// </summary>
        /// <param name="document">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument(MedDocInfo document)
        {

            this.m_documents = new MedDocList();
            this.m_documents.Add(document);
            this.RefreshFormTitle(null);
            if (document == null || GlobalMethods.Misc.IsEmptyString(document.DOC_ID))
            {
                MessageBoxEx.Show("无法打开文档！文档信息非法！");
                return SystemData.ReturnValue.FAILED;
            }

            byte[] byteSmdfData = null;
            short shRet = SystemData.ReturnValue.OK;
            shRet = EmrDocAccess.Instance.GetDocByID(document.DOC_ID, ref byteSmdfData);

            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("无法打开文档！文档数据下载失败！");
                return shRet;
            }

            //编辑器控件加载文档
            this.textEditor1.LoadDocument2(byteSmdfData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("无法打开文档！文档数据加载失败！");
                return shRet;
            }
            this.AppendHistory(SystemParam.Instance.UserInfo);
            this.GoSection(document);
            
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 合并打开指定的一系列文档
        /// </summary>
        /// <param name="documents">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument(MedDocList documents)
        {
            this.m_documents = documents;
            if (documents == null || documents.Count <= 0)
                return SystemData.ReturnValue.CANCEL;

            MedDocInfo firstDocInfo = documents[0];
            this.RefreshFormTitle(null);

            WorkProcess.Instance.Initialize(this, documents.Count
                , string.Format("正在下载“{0}”，请稍候...", firstDocInfo.DOC_TITLE));

            //下载第一份文档
            byte[] byteDocData = null;
            short shRet = EmrDocAccess.Instance.GetDocByID(firstDocInfo.DOC_ID, ref byteDocData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                WorkProcess.Instance.Close();
                MessageBoxEx.Show(this, string.Format("文档“{0}”下载失败！", firstDocInfo.DOC_TITLE));
                return SystemData.ReturnValue.FAILED;
            }

            if (WorkProcess.Instance.Canceled)
            {
                WorkProcess.Instance.Close();
                return SystemData.ReturnValue.CANCEL;
            }

            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 关闭当前文档
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short CloseDocument()
        {
            //清空病历内容以及病历信息数据
            this.textEditor1.CloseDocument();
            this.m_documents = null;
            return SystemData.ReturnValue.OK;
        }

        public short GotoText(string text, int index)
        {
            bool result = true;
            this.textEditor1.GotoDocumentHead(true);
            while (index >= 0 && result)
            {
                result = this.textEditor1.FindNext(text, false, false);
                index--;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 初始化工具栏上的文档缺陷检查按钮
        /// </summary>
        private void InitCheckDocBugButton()
        {
            if (this.m_CheckDocBugButton != null && !this.m_CheckDocBugButton.IsDisposed)
            {
                this.m_CheckDocBugButton.Visible = true;
                this.m_CheckDocBugButton.BringToFront();
                return;
            }
            this.m_CheckDocBugButton = new FlatButton();
            this.m_CheckDocBugButton.Text = "检查文档缺陷";
            this.m_CheckDocBugButton.Image = global::MedQCSys.Properties.Resources.CheckDocBugs;
            this.m_CheckDocBugButton.Size = new Size(100, 22);
            this.m_CheckDocBugButton.Location = new Point(this.textEditor1.Width - this.m_CheckDocBugButton.Width - 16, 24);
            this.m_CheckDocBugButton.Parent = this.textEditor1;
            this.m_CheckDocBugButton.BackColor = Color.FromArgb(244, 243, 232);
            this.m_CheckDocBugButton.ForeColor = Color.Blue;
            this.m_CheckDocBugButton.Visible = true;
            this.m_CheckDocBugButton.BringToFront();
            this.m_CheckDocBugButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.m_CheckDocBugButton.Click += new EventHandler(this.CheckDocBugButton_Click);
        }

        private void AddFeedInfo()
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;

            if (this.m_documents == null)
                return;

            if (this.m_documents.Count <= 0)
                return;

            SectionInfo sectionInfo = this.textEditor1.GetCurrentSection();

            if (sectionInfo != null)
            {
                this.m_documents[0].DOC_TITLE = sectionInfo.Name;
            }
            this.MainForm.AddMedicalQcMsg(this.m_documents[0]);
        }

        private void CheckDocBugButton_Click(object sender, EventArgs e)
        {
            this.MainForm.ShowDocumentBugsForm(this);
        }

        private void mnuShowStandardTermForm_Click(object sender, EventArgs e)
        {
            this.MainForm.ShowStandardTermForm(this.textEditor1.SelectedText);
        }

        private void mnuInsertCommentForm_Click(object sender, EventArgs e)
        {
            this.textEditor1.InsertComment();
        }
        private void mnuDeleteCommentForm_Click(object sender, EventArgs e)
        {
            this.textEditor1.DeleteComment();
        }
        /// <summary>
        /// 追加修订历史信息
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        public bool AppendHistory(UserInfo userInfo)
        {
            if (userInfo == null)
                return false;
            DocumentHistory history = new DocumentHistory();
            history.Author.Code = userInfo.USER_ID;
            history.Author.Name = userInfo.USER_NAME;
            history.Author.Organization = userInfo.DEPT_NAME;
            history.Timestamp = DateTime.Now;
            if (this.textEditor1.DocumentInfo.Histories.Count <= 0)
                history.Description = "创建";
            else
                history.Description = "修订";
            this.textEditor1.DocumentInfo.Histories.Add(history);
            return true;
        }
        private void mnuRollbackDocument_Click(object sender, EventArgs e)
        {
            //判断是否是已归档患者的病历,C 表示已归档
            if (SystemParam.Instance.PatVisitInfo.MR_STATUS.ToUpper() == "C")
            {
                MessageBoxEx.Show(this, "该患者病案已归档，不能再退回，请医生到医生站回退病历", MessageBoxIcon.Warning);
                return;
            }
            else if (this.m_ClickDocument.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.QC_ROLLBACK)
            {
                MessageBoxEx.Show(this, "该病历处于质控人员退回状态，不用重新退回！", MessageBoxIcon.Warning);
                return;
            }

            RollbackDocument rbForm = new RollbackDocument();

            if (rbForm.ShowDialog() == DialogResult.OK)
            {
                //获取文档信息
                MedDocInfo docInfo = this.m_ClickDocument;
                this.m_ClickDocument.SIGN_CODE = MedDocSys.DataLayer.SystemData.SignState.QC_ROLLBACK;
                byte[] temp = null;
                if (this.Document.DOC_ID == this.m_ClickDocument.DOC_ID)
                {
                    this.textEditor1.SaveDocument2(out temp);
                }
                short shRet = EmrDocAccess.Instance.UpdateDoc(this.m_ClickDocument.DOC_ID, this.m_ClickDocument, rbForm.Reason, temp);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    //向医生站发送消息
                    //1.向Medical_QC_LOG表插入反馈信息记录
                    EMRDBLib.MedicalQcLog qcActionLog = new EMRDBLib.MedicalQcLog();
                    if (!QuestionListForm.MakeQCActionLog(ref qcActionLog))
                    {
                        GlobalMethods.UI.SetCursor(this, Cursors.Default);
                        return;
                    }
                    qcActionLog.LOG_DESC = "质控人员退回病历";
                    qcActionLog.CHECK_TYPE = 6;
                    qcActionLog.AddQCQuestion = false;
                    qcActionLog.DOC_SETID = this.Document.DOC_SETID;
                    shRet = MedicalQcLogAccess.Instance.Insert(qcActionLog);

                    //2.向Medical_QC_MSG表插入质控人员质检记录

                    EMRDBLib.MedicalQcMsg qcQuestionInfo = new EMRDBLib.MedicalQcMsg();
                    qcQuestionInfo.QC_MODULE = "DOCTOR_MR";
                    qcQuestionInfo.TOPIC_ID = this.Document.DOC_SETID;
                    qcQuestionInfo.TOPIC = this.Document.DOC_TITLE;
                    qcQuestionInfo.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                    qcQuestionInfo.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                    if (!GlobalMethods.Misc.IsEmptyString(SystemParam.Instance.PatVisitInfo.DEPT_CODE))
                        qcQuestionInfo.DEPT_STAYED = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
                    else
                        qcQuestionInfo.DEPT_STAYED = SystemParam.Instance.PatVisitInfo.DischargeDeptCode;
                    string inChargeDoctor = string.Empty;
                    //DataAccess.GetPatChargeDoctorID(SystemParam.Instance.PatVisitLog.PatientID, SystemParam.Instance.PatVisitLog.VisitID, ref inChargeDoctor);
                    qcQuestionInfo.DOCTOR_IN_CHARGE = this.Document.CREATOR_NAME;
                    qcQuestionInfo.PARENT_DOCTOR = SystemParam.Instance.PatVisitInfo.AttendingDoctor;
                    qcQuestionInfo.SUPER_DOCTOR = SystemParam.Instance.PatVisitInfo.SUPER_DOCTOR;
                    qcQuestionInfo.QC_MSG_CODE = "Q1";
                    //将退回原因作为质检问题描述
                    if (string.IsNullOrEmpty(rbForm.Reason))
                        qcQuestionInfo.MESSAGE = "存在其他对病历质量造成严重影响的问题";
                    else
                        qcQuestionInfo.MESSAGE = rbForm.Reason;
                    qcQuestionInfo.MSG_STATUS = 0;
                    qcQuestionInfo.QA_EVENT_TYPE = "质控退回原因";
                    qcQuestionInfo.POINT_TYPE = 1;
                    qcQuestionInfo.ISSUED_BY = SystemParam.Instance.UserInfo.USER_NAME;
                    qcQuestionInfo.ISSUED_DATE_TIME = SysTimeHelper.Instance.Now;
                    qcQuestionInfo.ISSUED_ID = SystemParam.Instance.UserInfo.USER_ID;
                    qcQuestionInfo.POINT_TYPE = 0;
                    qcQuestionInfo.POINT = 0;

                    shRet = MedicalQcMsgAccess.Instance.Insert(qcQuestionInfo);
                    if (shRet == SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show(this, "已成功退回病历", MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void mnuAddFeedInfo_Click(object sender, EventArgs e)
        {

            this.AddFeedInfo();
        }

        private void textEditor1_BeforeCopy(object sender, CancelEventArgs e)
        {
            if (!SystemParam.Instance.UserRight.CopyFormDocument.Value)
                e.Cancel = true;
        }

        private void textEditor1_SaveButtonClick(object sender, EventArgs e)
        {
            //和仁编辑器有痕迹保留功能，对质控科放开保存病历权限
            byte[] temp = new byte[] { };
            this.textEditor1.SaveDocument2(out temp);
            if (this.Document != null)
            {
                if (EmrDocAccess.Instance.UpdateDoc(this.Document.DOC_ID, this.Document, "质控科发现问题直接修改", temp) != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.Show("病历保存失败");
                }
                else
                {
                    MessageBoxEx.Show("保存成功", MessageBoxIcon.Information);
                    this.textEditor1.ReadOnly = true;
                }
            }
        }

        private void textEditor1_PrintButtonClick(object sender, EventArgs e)
        {
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
        public short GotoElement(string id, string name)
        {
            this.textEditor1.GotoField2(id, MatchMode.ID);
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 获取文档中所有与元素有关的缺陷信息
        /// </summary>
        /// <param name="lstElementBugInfos">元素缺陷信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short CheckElementBugs(ref List<ElementBugInfo> elementBugInfos)
        {
            if (this.textEditor1 == null || this.textEditor1.IsDisposed)
                return EMRDBLib.SystemData.ReturnValue.PARAM_ERROR;

            //检查内容为空的元素,这里会有个问题：
            //同一个元素文档里有多个时,用户双击错误列表就定位不准确

            if (elementBugInfos == null)
                elementBugInfos = new List<ElementBugInfo>();
            elementBugInfos.Clear();

            TextField[] textFileds = this.textEditor1.GetFields(null, MatchMode.Type);
            if (textFileds == null || textFileds.Length <= 0)
                return EMRDBLib.SystemData.ReturnValue.OK;
            foreach (TextField field in textFileds)
            {
                string fieldText = string.Empty;
                this.textEditor1.GetFieldText(field, out fieldText);

                ElementBugInfo bugInfo = new ElementBugInfo();
                bugInfo.Tag = field;
                bugInfo.ElementID = field.ID;
                bugInfo.ElementName = field.Name;
                if (field.FieldType == FieldType.TextOption)
                    bugInfo.ElementType = ElementType.SimpleOption;
                else if (field.FieldType == FieldType.RichOption)
                    bugInfo.ElementType = ElementType.ComplexOption;
                else
                    bugInfo.ElementType = ElementType.InputBox;

                if (!field.AllowEmpty && string.IsNullOrEmpty(fieldText))
                {
                    bugInfo.IsFatalBug = true;
                    bugInfo.BugDesc = string.Format("“{0}”内容为空!", bugInfo.ElementName);
                    elementBugInfos.Add(bugInfo);
                    continue;
                }

                if (field.HitForced && !field.AlreadyHitted)
                {
                    //用户必须点击，但是没有点击
                    bugInfo.BugDesc = string.Format("“{0}”是重点关注项，务必用鼠标点击一次!", field.Name);
                    elementBugInfos.Add(bugInfo);
                    continue;
                }

                //检查超出范围情况，MaxValue未null或者-1时，不用检查
                if (field.ValueType == FieldValueType.Numeric)
                {
                    decimal currValue = 0;
                    if (!decimal.TryParse(fieldText, out currValue))
                    {
                        bugInfo.IsFatalBug = true;
                        bugInfo.BugDesc = string.Format("请在“{0}”内正确输入数值!", field.Name);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }

                    decimal minValue = 0;
                    decimal maxValue = 0;
                    bool result1 = decimal.TryParse(field.MinValue, out minValue);
                    bool result2 = decimal.TryParse(field.MaxValue, out maxValue);

                    //数值不在范围内
                    if (result1 && minValue > 0 && currValue < minValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”不能小于{1}!", field.Name, field.MinValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                    if (result2 && maxValue > 0 && currValue > maxValue && maxValue >= 0)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”不能大于{1}!", field.Name, field.MaxValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                }
                else if (field.ValueType == FieldValueType.DateTime)
                {
                    DateTime currValue = new DateTime();
                    if (!GlobalMethods.Convert.StringToDate(fieldText, ref currValue))
                    {
                        bugInfo.IsFatalBug = true;
                        bugInfo.BugDesc = string.Format("请在“{0}”内正确输入日期!", field.Name);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }

                    //填入的内容确定为日期，再检查范围
                    DateTime minValue;
                    DateTime maxValue;
                    bool result1 = DateTime.TryParse(field.MinValue, out minValue);
                    bool result2 = DateTime.TryParse(field.MaxValue, out maxValue);

                    //时间不在范围内
                    if (result1 && currValue < minValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”时间不能小于{1}!", field.Name, field.MinValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                    if (result2 && currValue > maxValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”时间不能大于{1}!", field.Name, field.MaxValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                }
                else
                {
                    int minValue = 0;
                    int maxValue = 0;
                    bool result1 = int.TryParse(field.MinValue, out minValue);
                    bool result2 = int.TryParse(field.MaxValue, out maxValue);

                    //文本长度不在范围内
                    if (result1 && minValue > 0 && fieldText.Length < minValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”文本长度不能小于{1}!", field.Name, field.MinValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                    if (result2 && maxValue > 0 && fieldText.Length > maxValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”文本长度不能大于{1}!", field.Name, field.MaxValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                }
            }
            return SystemData.ReturnValue.OK;
        }
        public bool IsNum(string szFieldText)
        {
            if (string.IsNullOrEmpty(szFieldText))
                return false;
            bool result = Regex.IsMatch(szFieldText, @"^-?\d+\.?\d*$");
            return result;
        }
        public bool IsTime(string szFieldText)
        {
            if (string.IsNullOrEmpty(szFieldText))
                return false;
            DateTime dtFieldTime = new DateTime();
            string szTime = szFieldText.Replace("年", "-").Replace("月", "-").Replace("日", "").Replace("时", ":").Replace("分", "").Replace("，", " ");
            bool result = DateTime.TryParse(szTime, out dtFieldTime);
            return result;
        }
        #region IDocumentForm 成员

        internal void GoSection(MedDocInfo docInfo)
        {
            this.Text = docInfo.DOC_TITLE;
            this.m_documents[0] = docInfo;
            this.m_ClickDocument = docInfo;
            SectionInfo section = this.TextEditor.GetSection(docInfo.DOC_ID, MatchMode.ID);
            if (this.TextEditor.GotoSection(section))
            {
                this.TextEditor.ScrollToView();
                this.TextEditor.SelectCurrentLine();
            }
        }

        public short OpenDocument(MDSDBLib.MedDocInfo document)
        {
            throw new NotImplementedException();
        }

        public short OpenDocument(MDSDBLib.MedDocList documents)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void toolbtnPrintPreview_Click(object sender, EventArgs e)
        {
            
            SectionInfo curSection= this.textEditor1.GetCurrentSection();
            byte[] byteDocument = null;
            this.textEditor1.SaveSection(curSection, out byteDocument);
            if (byteDocument == null)
            {
                this.textEditor1.SaveDocument2(out byteDocument);
            }
            this.textEditorPrint.ReviseEnabled = false;
            this.textEditorPrint.CommentEditMode = false;
            this.textEditorPrint.CommentVisible = false;
            this.textEditorPrint.RevisionVisible = false;
            this.textEditorPrint.LoadDocument2(byteDocument);
            this.textEditorPrint.Design = true;
            this.textEditorPrint.ShowPreviewDialog();
            this.textEditorPrint.Design = false;
        }

        private void toolbtnPrintAllPreview_Click(object sender, EventArgs e)
        {
            byte[] fileData = null;
            bool result= this.textEditor1.SaveDocument2(out fileData);
            if (fileData == null)
            {
                MessageBoxEx.ShowMessage("获取打印文档数据失败，无法预览");
                return;
            }
            this.textEditorPrint.ReviseEnabled = false;
            this.textEditorPrint.CommentEditMode = false;
            this.textEditorPrint.CommentVisible = false;
            this.textEditorPrint.RevisionVisible = false;
            this.textEditorPrint.LoadDocument2(fileData);
            this.textEditorPrint.ShowPreviewDialog();
        }
    }
}