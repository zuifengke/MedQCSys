// ***********************************************************
// 病案质控系统文档容器窗口,多文档对应多个文档窗口
// Creator:YangMingkun  Date:2009-7-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using MedDocSys.PadWrapper;
using MedQCSys.DockForms;

using MedQCSys.Dialogs;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Core;

namespace MedQCSys.Document
{
    internal partial class BaodianDocForm : DockContentBase, IDocumentForm
    {

        public BaodianDocForm(MainForm mainForm)
            : base(mainForm)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.Icon = MedQCSys.Properties.Resources.MedDocIcon;

            //读配置文件判断是否需要添加【新增质检问题】按钮,如果为true则显示全部右键菜单。
 
                this.medEditor1.ShowInternalPopupMenu = true;
                this.medEditor1.ShowInternalMenuStrip = true;
                this.medEditor1.ShowInternalToolStrip = true;
                this.medEditor1.PopupMenu.InsertMenuItem("新增质检问题", new EventHandler(mnuAddFeedInfo_Click));
                this.medEditor1.PopupMenu.InsertMenuItem("自动检查缺陷", new EventHandler(this.CheckDocBugButton_Click));
                this.medEditor1.PopupMenu.InsertMenuItem("复制文档页眉", new EventHandler(mnuCopyDocumentHeader_Click));
                this.medEditor1.PopupMenu.InsertMenuItem("检索标准诊断", new EventHandler(mnuShowStandardTermForm_Click));
                this.medEditor1.PopupMenu.InsertMenuItem("退回病历...", new EventHandler(mnuRollbackDocument_Click));
                this.medEditor1.PopupMenu.InsertMenuItem("-");
          
            this.medEditor1.BeforeCopy += new CancelEventHandler(this.medEditor1_BeforeCopy);
            this.medEditor1.SaveButtonClick += new CancelEventHandler(medEditor1_SaveButtonClick);
            this.medEditor1.PrintButtonClick += new EventHandler(medEditor1_PrintButtonClick);
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

        private MedDocList m_documents = null;
        /// <summary>
        /// 获取或设置文档信息列表
        /// </summary>
        public MedDocList Documents
        {
            get { return this.m_documents; }
        }

        /// <summary>
        /// 获取本窗口中编辑器控件
        /// </summary>
        public IMedEditor MedEditor
        {
            get
            {
                if (this.medEditor1 == null || this.medEditor1.IsDisposed)
                    return null;
                return this.medEditor1;
            }
        }
        #endregion

        private MedDocSys.DataLayer.UserInfo GetUserInfo()
        {
            UserInfo userInfo = SystemParam.Instance.UserInfo;
            MedDocSys.DataLayer.UserInfo clientUserInfo = new MedDocSys.DataLayer.UserInfo();
            clientUserInfo.ID = userInfo.ID;
            clientUserInfo.Name = userInfo.Name;
            clientUserInfo.DeptCode = userInfo.DeptCode;
            clientUserInfo.DeptName = userInfo.DeptName;
            return clientUserInfo;
        }

        private MedDocSys.DataLayer.PatientInfo GetPatientInfo()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return new MedDocSys.DataLayer.PatientInfo();

            MedDocSys.DataLayer.PatientInfo clientPatientInfo = new MedDocSys.DataLayer.PatientInfo();
            clientPatientInfo.ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            clientPatientInfo.Name = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            clientPatientInfo.Gender = SystemParam.Instance.PatVisitInfo.PATIENT_SEX;
            clientPatientInfo.BirthTime = SystemParam.Instance.PatVisitInfo.BIRTH_TIME;
            return clientPatientInfo;
        }

        private MedDocSys.DataLayer.VisitInfo GetVisitInfo()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return new MedDocSys.DataLayer.VisitInfo();

            MedDocSys.DataLayer.VisitInfo clientVisitInfo = new MedDocSys.DataLayer.VisitInfo();
            clientVisitInfo.ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            clientVisitInfo.InpID = SystemParam.Instance.PatVisitInfo.INP_NO;
            clientVisitInfo.Time = SystemParam.Instance.PatVisitInfo.VISIT_TIME;
            clientVisitInfo.WardCode = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            clientVisitInfo.WardName = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            clientVisitInfo.BedCode = SystemParam.Instance.PatVisitInfo.BED_CODE;
            clientVisitInfo.Type = MedDocSys.DataLayer.VisitType.IP;
            return clientVisitInfo;
        }

        /// <summary>
        /// 缺陷检查按钮
        /// </summary>
        private FlatButton m_CheckDocBugButton = null;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
           
                this.InitCheckDocBugButton();
           
            this.medEditor1.ElementTagColor = MedDocSys.DataLayer.SystemParam.Instance.ElementTagColor;
            this.medEditor1.ManageDeptLib = SystemParam.Instance.UserRight.ManageDeptElement.Value
                && SystemParam.Instance.UserRight.ManageDeptPicture.Value;
            this.medEditor1.ManagePublicLib = SystemParam.Instance.UserRight.ManageAllElement.Value
                && SystemParam.Instance.UserRight.ManageAllPicture.Value;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            this.CloseDocument();
            if (this.medEditor1 != null && !this.medEditor1.IsDisposed)
                this.medEditor1.Dispose();
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
            shRet = this.medEditor1.OpenDocument(byteSmdfData, null, true);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("无法打开文档！文档数据加载失败！");
                return shRet;
            }
            //打开文档后是否显示为只读状态
            if (!SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_READONLY, false))
                this.MedEditor.Readonly = false;
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
            short shRet = EmrDocAccess.Instance.GetDocByID(document.DOC_ID, ref byteSmdfData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("无法打开文档！文档数据下载失败！");
                return shRet;
            }
            //编辑器控件加载文档
            shRet = this.medEditor1.OpenDocument(byteSmdfData, false, document.DOC_ID, document.DOC_TITLE);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("无法打开文档！文档数据加载失败！");
                return shRet;
            }
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
            this.medEditor1.UserInfo = this.GetUserInfo();
            this.medEditor1.PatientInfo = this.GetPatientInfo();
            this.medEditor1.VisitInfo = this.GetVisitInfo();
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
            WorkProcess.Instance.Show(string.Format("正在打开“{0}”，请稍候...", firstDocInfo.DOC_TITLE), 1);

            //打开第一份文档
            shRet = this.medEditor1.InitCombinDisplay(byteDocData, firstDocInfo.DOC_ID, firstDocInfo.DOC_TITLE, true);
            if (shRet != SystemData.ReturnValue.OK)
            {
                WorkProcess.Instance.Close();
                MessageBoxEx.Show(this, string.Format("文档“{0}”加载失败！", firstDocInfo.DOC_TITLE));
                return SystemData.ReturnValue.FAILED;
            }

            DocTypeInfo prevDocTypeInfo = null;
            DataCache.Instance.GetDocTypeInfo(firstDocInfo.DOC_TYPE, ref prevDocTypeInfo);

            //循环打开其余的文档
            for (int index = 1; index < documents.Count; index++)
            {
                MedDocInfo docInfo = documents[index];

                if (WorkProcess.Instance.Canceled)
                    break;
                WorkProcess.Instance.Show(string.Format("正在下载“{0}”，请稍候...", docInfo.DOC_TITLE), index + 1);

                //下载文档内容
                byteDocData = null;
                shRet = EmrDocAccess.Instance.GetDocByID(docInfo.DOC_ID, ref byteDocData);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    string szTipInfo = string.Format("“{0}”文档数据下载失败！是否继续？", docInfo.DOC_TITLE);
                    if (MessageBoxEx.Show(szTipInfo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        break;
                }

                if (WorkProcess.Instance.Canceled)
                    break;
                WorkProcess.Instance.Show(string.Format("正在打开“{0}”，请稍候...", docInfo.DOC_TITLE), index + 1);

                //当前文档或前一文档是需要独立打印的,那么插入一个或两个硬分页符
                DocTypeInfo docTypeInfo = null;
                DataCache.Instance.GetDocTypeInfo(docInfo.DOC_TYPE, ref docTypeInfo);
                if ((docTypeInfo != null && docTypeInfo.IsTotalPage)
                    || (prevDocTypeInfo != null && prevDocTypeInfo.IsEndEmpty))
                {
                    int nTotalPageCount = 0;

                    //获取总页数.注意:单面打印时只需要插入一个空白页
                    if (this.medEditor1.PageSettings.PageLayout != MedDocSys.DataLayer.PageLayout.Normal)
                    {
                        //格式化一次文档,才能正确获取总页数
                        this.medEditor1.RefreshCombinDisplay();
                        this.medEditor1.GetPageCount(ref nTotalPageCount);
                    }

                    int nBlankPageCount = (nTotalPageCount % 2 == 0) ? 1 : 2;
                    this.AppendBlankToCombin(nBlankPageCount, true);
                }
                prevDocTypeInfo = docTypeInfo;

                if (WorkProcess.Instance.Canceled)
                    break;

                //OCX编辑器装载文档
                shRet = this.medEditor1.AppendToCombinDisplay(byteDocData, docInfo.DOC_ID, docInfo.DOC_TITLE, true);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    string szTipInfo = string.Format("“{0}”文档数据加载失败！是否继续？", docInfo.DOC_TITLE);
                    if (MessageBoxEx.Show(szTipInfo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        break;
                }
            }
            this.medEditor1.RefreshCombinDisplay();
            WorkProcess.Instance.Close();
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 插入空白纸张到合并显示的文档
        /// </summary>
        /// <param name="nBlankCount">需要追加的空白页的数目</param>
        /// <param name="bNeedPrint">空白页是否需要打印</param>
        private void AppendBlankToCombin(int nBlankCount, bool bNeedPrint)
        {
            if (this.IsDisposed || nBlankCount <= 0)
                return;
            string szBlankFile = string.Format("{0}\\Baodian\\Blank.smdf", GlobalMethods.Misc.GetWorkingPath());
            byte[] byteBlankDocData = null;
            if (!GlobalMethods.IO.GetFileBytes(szBlankFile, ref byteBlankDocData))
                return;
            string szBlankDocID = MedDocSys.DataLayer.SystemData.MiscConstant.BLANK_DOCUMENT_ID;
            for (int index = 0; index < nBlankCount; index++)
            {
                this.medEditor1.AppendToCombinDisplay(byteBlankDocData, szBlankDocID, "空白病历", bNeedPrint);
            }
        }

        /// <summary>
        /// 打印当前文档
        /// </summary>
        /// <param name="bNeedPreview">是否需要先预览再打印</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short PrintDocument(bool bNeedPreview)
        {
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short CloseDocument()
        {
            //清空病历内容以及病历信息数据
            this.medEditor1.CloseDocument();
            this.m_documents = null;
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
            this.m_CheckDocBugButton.Location = new Point(this.medEditor1.Width - this.m_CheckDocBugButton.Width - 16, 24);
            this.m_CheckDocBugButton.Parent = this.medEditor1;
            this.m_CheckDocBugButton.BackColor = Color.FromArgb(244, 243, 232);
            this.m_CheckDocBugButton.ForeColor = Color.Blue;
            this.m_CheckDocBugButton.Visible = true;
            this.m_CheckDocBugButton.BringToFront();
            this.m_CheckDocBugButton.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            this.m_CheckDocBugButton.Click += new EventHandler(this.CheckDocBugButton_Click);
        }

        private void CheckDocBugButton_Click(object sender, EventArgs e)
        {
            this.MainForm.ShowDocumentBugsForm(this);
        }

        private void mnuCopyDocumentHeader_Click(object sender, EventArgs e)
        {
            this.medEditor1.CopyDocumentHeader(false);
        }

        private void mnuShowStandardTermForm_Click(object sender, EventArgs e)
        {
            this.MainForm.ShowStandardTermForm(this.medEditor1.GetSelectedText());
        }

        private void mnuRollbackDocument_Click(object sender, EventArgs e)
        {
            //判断是否是已归档患者的病历,C 表示已归档
            if (SystemParam.Instance.PatVisitInfo.MR_STATUS.ToUpper() == "C")
            {
                MessageBoxEx.Show(this, "该患者病案已归档，不能再退回，请医生到医生站回退病历", MessageBoxIcon.Warning);
                return;
            }
            else if (this.Document.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.QC_ROLLBACK)
            {
                MessageBoxEx.Show(this, "该病历处于质控人员退回状态，不用重新退回！", MessageBoxIcon.Warning);
                return;
            }

            RollbackDocument rbForm = new RollbackDocument();
            
            if (rbForm.ShowDialog() == DialogResult.OK)
            {
                //获取文档信息
                MedDocInfo docInfo = this.Document;
                string szOldDocID = this.Document.DOC_ID;
                this.Document.DOC_VERSION = this.Document.DOC_VERSION + 1;
                this.Document.DOC_ID = this.Document.DOC_SETID + "_" + this.Document.DOC_VERSION;

                byte[] byteSmdfData = null;
                this.medEditor1.SaveDocument(true, false, ref byteSmdfData);
                this.Document.SIGN_CODE = MedDocSys.DataLayer.SystemData.SignState.QC_ROLLBACK;
                short shRet = EmrDocAccess.Instance.UpdateDoc(szOldDocID, docInfo, "质控人员退回病历", byteSmdfData);
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
                    qcActionLog.DOC_SETID = this.Document.DOC_SETID;
                    shRet =MedicalQcLogAccess.Instance.Insert(qcActionLog);

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
                    string inChargeDoctor=string.Empty;
                    EmrDocAccess.Instance.GetPatChargeDoctorID(SystemParam.Instance.PatVisitInfo.PATIENT_ID, SystemParam.Instance.PatVisitInfo.VISIT_ID, ref inChargeDoctor);
                    qcQuestionInfo.DOCTOR_IN_CHARGE = inChargeDoctor;
                    qcQuestionInfo.PARENT_DOCTOR = SystemParam.Instance.PatVisitInfo.AttendingDoctor;
                    qcQuestionInfo.SUPER_DOCTOR = SystemParam.Instance.PatVisitInfo.SUPER_DOCTOR;
                    qcQuestionInfo.QC_MSG_CODE = "Q1";
                    qcQuestionInfo.MESSAGE = "存在其他对病历质量造成严重影响的问题";
                    qcQuestionInfo.MSG_STATUS = 0;
                    qcQuestionInfo.QA_EVENT_TYPE = "其他严重质量问题";
                    qcQuestionInfo.POINT_TYPE = 1;
                    qcQuestionInfo.ISSUED_BY = SystemParam.Instance.UserInfo.Name;
                    qcQuestionInfo.ISSUED_DATE_TIME = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                    qcQuestionInfo.ISSUED_ID = SystemParam.Instance.UserInfo.ID;
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
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;

            if (this.m_documents == null)
                return;

            if (this.m_documents.Count <= 0)
                return;

            this.MainForm.AddMedicalQcMsg(this.m_documents[0]);
        }

        private void medEditor1_BeforeCopy(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!SystemParam.Instance.UserRight.CopyFormDocument.Value)
                e.Cancel = true;
        }

        private void medEditor1_SaveButtonClick(object sender, CancelEventArgs e)
        {
            bool bQCSaveDocEnable = EmrDocAccess.Instance.CheckQCSaveDocEnable();
            bool bEditAbleDoc = true;
            if (bQCSaveDocEnable && bEditAbleDoc)
            {
                byte[] temp = new byte[] { };
                this.medEditor1.SaveDocument(false, false, ref temp);
                if (this.Document != null)
                {
                    if (EmrDocAccess.Instance.UpdateDoc(this.Document.DOC_ID, this.Document, "质控科发现问题直接修改", temp) != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show("病历保存失败");
                    }
                    else
                    {
                        MessageBoxEx.Show("保存成功", MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (!bQCSaveDocEnable)
                    MessageBoxEx.Show("质控科保存病历未开启!");
                else if (!bEditAbleDoc)
                    MessageBoxEx.Show("您没有权限保存病历！");
                e.Cancel = true;
            }
        }

        private void medEditor1_PrintButtonClick(object sender, EventArgs e)
        {
            bool bReadonly = this.medEditor1.Readonly;

            //底层编辑器生成文档内容
            byte[] byteSmdfData = null;
            short shRet = this.medEditor1.SaveDocument(false, false, ref byteSmdfData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("文档保存失败！");
                return;
            }
            this.medEditor1.IsModified = false;
            MedDocSys.DataLayer.PrintSettings printSettings = new MedDocSys.DataLayer.PrintSettings();
            this.medEditor1.PrintDocument(printSettings);
            if (!bReadonly)
                this.medEditor1.SetReadonlyState(false);
        }
    }
}