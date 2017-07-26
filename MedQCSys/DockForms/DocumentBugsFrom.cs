// ***********************************************************
// 文档缺陷自动检查结果显示窗口.
// Creator:YangMingkun  Date:2009-11-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using MedDocSys.QCEngine.BugCheck;

using MedQCSys.Document;
using Heren.Common.RichEditor;
using EMRDBLib;

namespace MedQCSys.DockForms
{
    internal partial class DocumentBugsForm : DockContentBase
    {
        private const string BUG_RESPONSE_LOCATE = "LOCATE";
        private BugCheckEngine m_bugCheckEngine = null;

        private IDocumentForm m_documentForm = null;
        /// <summary>
        /// 获取或设置当前缺陷窗口关联的文档窗口
        /// </summary>
        [Browsable(false)]
        public IDocumentForm DocumentForm
        {
            get { return this.m_documentForm; }
            set
            {
                this.listView1.Items.Clear();
                this.listView1.Update();
                this.m_documentForm = value;
            }
        }

        public DocumentBugsForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();

            this.ShowInTaskbar = false;
            this.ShowHint = DockState.DockBottom;
            this.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Float;
        }

        public override void OnRefreshView()
        {
            this.CheckDocumentBugs(this.m_documentForm);
        }

        protected override void OnPatientInfoChanged()
        {
            this.DocumentForm = null;
        }

        private UserInfo GetUserInfo()
        {
            UserInfo userInfo = SystemParam.Instance.UserInfo;
            UserInfo clientUserInfo = new UserInfo();
            clientUserInfo.USER_ID = userInfo.USER_ID;
            clientUserInfo.USER_NAME = userInfo.USER_NAME;
            clientUserInfo.DEPT_CODE = userInfo.DEPT_CODE;
            clientUserInfo.DEPT_NAME = userInfo.DEPT_NAME;
            return clientUserInfo;
        }

        private PatientInfo GetPatientInfo()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return new PatientInfo();

            PatientInfo clientPatientInfo = new PatientInfo();
            clientPatientInfo.ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            clientPatientInfo.Name = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            clientPatientInfo.Gender = SystemParam.Instance.PatVisitInfo.PATIENT_SEX;

            clientPatientInfo.BirthTime = SystemParam.Instance.PatVisitInfo.BIRTH_TIME;

            return clientPatientInfo;
        }

        private VisitInfo GetVisitInfo()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return new VisitInfo();

            VisitInfo clientVisitInfo = new VisitInfo();
            clientVisitInfo.ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            clientVisitInfo.InpID = SystemParam.Instance.PatVisitInfo.INP_NO;
            clientVisitInfo.Time = SystemParam.Instance.PatVisitInfo.VISIT_TIME;
            clientVisitInfo.WardCode = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            clientVisitInfo.WardName = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            //clientVisitInfo.CareCode = visitInfo.CareCode;
            //clientVisitInfo.CareName = visitInfo.CareName;
            clientVisitInfo.BedCode = SystemParam.Instance.PatVisitInfo.BED_CODE;
            clientVisitInfo.Type = VisitType.IP;
            return clientVisitInfo;
        }

        /// <summary>
        /// 检查文档缺陷,并返回检查结果
        /// </summary>
        /// <param name="documentForm">被检查缺陷的文档窗口</param>
        /// <returns>Common.SystemData.ReturnValue</returns>
        public short CheckDocumentBugs(IDocumentForm documentForm)
        {
            if (this.DocumentForm != documentForm)
                this.DocumentForm = documentForm;
            this.listView1.Items.Clear();
            this.Update();

            if (documentForm == null || documentForm.IsDisposed)
                return SystemData.ReturnValue.FAILED;
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return SystemData.ReturnValue.FAILED;

            //获取病历文本数据
            string szTextData = string.Empty;
            short shRet = SystemData.ReturnValue.OK;
            if (documentForm is HerenDocForm)
                szTextData = (documentForm as HerenDocForm).TextEditor.Text;
            else
                documentForm.MedEditor.GetPureTextData(ref szTextData);
            if (shRet != SystemData.ReturnValue.OK || GlobalMethods.Misc.IsEmptyString(szTextData))
                return SystemData.ReturnValue.OK;

            //初始化质控引擎
            if (this.m_bugCheckEngine == null)
                this.m_bugCheckEngine = new BugCheckEngine();
            this.m_bugCheckEngine.UserInfo = this.GetUserInfo();
            this.m_bugCheckEngine.PatientInfo = this.GetPatientInfo();
            this.m_bugCheckEngine.VisitInfo = this.GetVisitInfo();
            this.m_bugCheckEngine.DocType = this.Text;
            this.m_bugCheckEngine.DocText = szTextData;
            //m_bugCheckEngine.SectionInfos = new List<DocumentSectionInfo>();
            shRet = this.m_bugCheckEngine.InitializeEngine();
            if (shRet != SystemData.ReturnValue.CANCEL && shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("病历质控引擎初始化失败,无法对病历进行自动质控！");
                return SystemData.ReturnValue.OK;
            }

            //检查文档内容缺陷
            List<DocuemntBugInfo> lstDocuemntBugList = null;
            if (shRet == SystemData.ReturnValue.OK)
            {
                lstDocuemntBugList = this.m_bugCheckEngine.PerformBugCheck();
                this.m_bugCheckEngine.DocText = null;
            }

            //检查文档元素缺陷
            List<ElementBugInfo> lstElementBugList = null;
            List<MedDocSys.PadWrapper.ElementBugInfo> bugs = new List<MedDocSys.PadWrapper.ElementBugInfo>();
            if (documentForm is HerenDocForm)
                (documentForm as HerenDocForm).CheckElementBugs(ref lstElementBugList);
            else
            {
                documentForm.MedEditor.CheckElementBugs(ref bugs);
                foreach (var item in bugs)
                {
                    ElementBugInfo bug = new ElementBugInfo();
                    bug.BugDesc = item.BugDesc;
                    bug.ElementID = item.ElementID;
                    bug.ElementName = item.ElementName;
                    if (item.ElementType == MDSDBLib.ElementType.CheckBox)
                        bug.ElementType = ElementType.CheckBox;
                    else if (item.ElementType == MDSDBLib.ElementType.ComplexOption)
                        bug.ElementType = ElementType.ComplexOption;
                    else if (item.ElementType == MDSDBLib.ElementType.InputBox)
                        bug.ElementType = ElementType.InputBox;
                    else if (item.ElementType == MDSDBLib.ElementType.Outline)
                        bug.ElementType = ElementType.Outline;
                    else if (item.ElementType == MDSDBLib.ElementType.SimpleOption)
                        bug.ElementType = ElementType.SimpleOption;
                    bug.IsFatalBug = item.IsFatalBug;
                }
            }

            if ((lstDocuemntBugList == null || lstDocuemntBugList.Count <= 0)
                && (lstElementBugList == null || lstElementBugList.Count <= 0))
            {
                MessageBoxEx.Show("系统已完成文档缺陷检查,没有检查到缺陷！", MessageBoxIcon.Information);
                //未检测到缺陷,则将窗口置后并最小化
                if (this.DockPanel == null)
                {
                    this.Owner = null;
                    this.SendToBack();
                    this.WindowState = FormWindowState.Minimized;
                }
                return SystemData.ReturnValue.OK;
            }
            this.RefreshBugsList(lstElementBugList, lstDocuemntBugList);
            return SystemData.ReturnValue.OK;
        }

        private void RefreshBugsList(List<ElementBugInfo> lstElementBugList, List<DocuemntBugInfo> lstDocuemntBugList)
        {
            string szDocTitle = string.Empty;
            if (this.m_documentForm != null && !this.m_documentForm.IsDisposed)
                szDocTitle = this.m_documentForm.DockHandler.TabText;

            for (int index = 0; lstDocuemntBugList != null && index < lstDocuemntBugList.Count; index++)
            {
                DocuemntBugInfo docuemntBugInfo = lstDocuemntBugList[index];
                ListViewItem item = new ListViewItem();
                item.Tag = docuemntBugInfo;
                item.SubItems.Add((this.listView1.Items.Count + 1).ToString());
                if (docuemntBugInfo.BugLevel == BugLevel.Warn)
                {
                    item.SubItems.Add("警告");
                    item.ImageIndex = 0;
                }
                else
                {
                    item.SubItems.Add("错误");
                    item.ImageIndex = 1;
                }

                item.SubItems.Add(szDocTitle);
                item.SubItems.Add(docuemntBugInfo.BugDesc);
                this.listView1.Items.Add(item);
            }

            for (int index = 0; lstElementBugList != null && index < lstElementBugList.Count; index++)
            {
                ElementBugInfo elementBugInfo = lstElementBugList[index];
                ListViewItem item = new ListViewItem();
                item.Tag = elementBugInfo;
                item.SubItems.Add((this.listView1.Items.Count + 1).ToString());
                item.SubItems.Add("错误");
                item.ImageIndex = 1;
                item.SubItems.Add(szDocTitle);
                item.SubItems.Add(elementBugInfo.BugDesc);
                this.listView1.Items.Add(item);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count <= 0)
                return;

            if (this.m_documentForm == null || this.m_documentForm.IsDisposed)
                return;

            this.m_documentForm.DockHandler.Activate();
            if (this.m_documentForm.MedEditor != null && !this.m_documentForm.MedEditor.Focused)
                this.m_documentForm.MedEditor.Focus();

            ListViewItem selectedItem = this.listView1.GetItemAt(e.X, e.Y);
            if (selectedItem == null)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            ElementBugInfo elementBugInfo = selectedItem.Tag as ElementBugInfo;
            if (elementBugInfo != null)
            {
                if (this.m_documentForm is HerenDocForm)
                {
                    TextField textField = elementBugInfo.Tag as TextField;
                    if (textField != null)
                    {
                        (this.m_documentForm as HerenDocForm).TextEditor.GotoField(textField);
                        (this.m_documentForm as HerenDocForm).TextEditor.SelectCurrentField();
                    }
                    else
                        (this.m_documentForm as HerenDocForm).GotoElement(elementBugInfo.ElementID, elementBugInfo.ElementName);
                }
                else
                {
                    MDSDBLib.ElementType type = MDSDBLib.ElementType.SimpleOption;
                    if (elementBugInfo.ElementType == ElementType.CheckBox)
                        type = MDSDBLib.ElementType.CheckBox;
                    else if (elementBugInfo.ElementType == ElementType.ComplexOption)
                        type = MDSDBLib.ElementType.ComplexOption;
                    else if (elementBugInfo.ElementType == ElementType.InputBox)
                        type = MDSDBLib.ElementType.InputBox;
                    else if (elementBugInfo.ElementType == ElementType.Outline)
                        type = MDSDBLib.ElementType.Outline;
                    else if (elementBugInfo.ElementType == ElementType.SimpleOption)
                        type = MDSDBLib.ElementType.SimpleOption;
                    this.m_documentForm.MedEditor.LocateToElement(type, elementBugInfo.ElementID
                       , elementBugInfo.ElementName);
                }
                   
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }

            DocuemntBugInfo docuemntBugInfo = selectedItem.Tag as DocuemntBugInfo;
            if (docuemntBugInfo != null && !GlobalMethods.Misc.IsEmptyString(docuemntBugInfo.BugKey)
                && docuemntBugInfo.Response == BUG_RESPONSE_LOCATE)
            {
                if (this.m_documentForm is HerenDocForm)
                {
                    (this.m_documentForm as HerenDocForm).GotoText(docuemntBugInfo.BugKey, docuemntBugInfo.BugIndex);
                }
                else
                {
                    this.m_documentForm.MedEditor.SetCursorPos(false);
                    this.m_documentForm.MedEditor.LocateToText(docuemntBugInfo.BugKey, docuemntBugInfo.BugIndex);
                }
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            ListViewItem item = this.listView1.GetItemAt(e.X, e.Y);
            if (item == null)
                return;
            Point ptMousePos = this.listView1.PointToClient(Control.MousePosition);
            this.cmenuDocBugs.Show(this.listView1, ptMousePos);
        }

        private void mnuCopyBugDesc_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count <= 0)
                return;
            if (this.listView1.SelectedItems[0].SubItems[this.colBugDesc.Index] == null)
                return;
            string szBugDesc = this.listView1.SelectedItems[0].SubItems[this.colBugDesc.Index].Text;
            try
            {
                if (GlobalMethods.Misc.IsEmptyString(szBugDesc))
                    Clipboard.Clear();
                else
                    Clipboard.SetDataObject(szBugDesc);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DocumentBugsForm.mnuCopyBugDesc_Click", ex);
            }
        }



    }
}