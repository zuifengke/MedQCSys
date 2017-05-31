// ***********************************************************
// 病案质控系统主业务处理层.
// Creator:YangMingkun  Date:2009-11-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using MedQCSys.Dialogs;
using MedQCSys.Document;
using MedQCSys.DockForms;
using Heren.Common.RichEditor;
using System.IO;
using EMRDBLib.DbAccess;
using EMRDBLib;
using MedQCSys.PatPage;
using Heren.MedQC.Core;

namespace MedQCSys
{
    public partial class MainForm : HerenForm
    {
        private PatientListForm m_PatientListForm = null;
        private DocumentListForm m_DocumentListForm = null;
        private PatsDocmentListForm m_PatDocListForm = null;
        private DocumentBugsForm m_DocumentBugsForm = null;
        private QuestionListForm m_QuestionListForm = null;
        private DocumentTimeForm m_DocumentTimeForm = null;
        private ExamResultListForm m_ExamResultForm = null;
        private DiagnosisListForm m_DiagnosisListForm = null;
        private TestResultListForm m_TestResultForm = null;
        private VitalSignsGraphForm m_VitalSignsGraphForm = null;
        private OrdersListForm m_OrdersListForm = null;
        private PatientInfoForm m_PatientInfoForm = null;
        private DocScoreForm m_DocScoreForm = null;
        private PatientIndexForm m_PatientIndexForm = null;
        public DocScoreNewForm DocScoreNewForm = null;
        /// <summary>
        /// 获取当前停靠控件
        /// </summary>
        [Browsable(false)]
        public DockPanel DockPanel
        {
            get { return this.dockPanel1; }
        }

        #region"属性定义"
        /// <summary>
        /// 获取当前处于活动状态的停靠窗口
        /// </summary>
        [Browsable(false)]
        [Description("获取当前处于活动状态的停靠窗口")]
        public IDockContent ActiveContent
        {
            get { return this.dockPanel1.ActiveContent; }
        }

        /// <summary>
        /// 获取当前处于活动状态的显示窗口
        /// </summary>
        [Browsable(false)]
        [Description("获取当前处于活动状态的显示窗口")]
        public IDockContent ActiveDocument
        {
            get { return this.dockPanel1.ActiveDocument; }
        }

        /// <summary>
        /// 获取或设置病程记录窗口
        /// </summary>
        public DocumentListForm DocumentListForm
        {
            get { return this.m_DocumentListForm; }
            set { this.m_DocumentListForm = value; }
        }

        /// <summary>
        /// 获取或设置病历评分窗口
        /// </summary>
        public DocScoreForm DocScoreForm
        {
            get { return this.m_DocScoreForm; }
            set { this.m_DocScoreForm = value; }
        }

        #endregion

        #region"事件定义"
        /// <summary>
        /// 当患者的ID,就诊ID等信息改变前触发
        /// </summary>
        [Description("当患者的ID,就诊ID等信息改变前触发")]
        public event CancelEventHandler PatientInfoChanging = null;
        internal virtual void OnPatientInfoChanging(CancelEventArgs e)
        {
            if (this.PatientInfoChanging == null)
                return;
            try
            {
                this.PatientInfoChanging(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.OnPatientInfoChanging", ex);
            }
        }

        /// <summary>
        /// 当患者的ID,就诊ID等信息改变时触发
        /// </summary>
        [Description("当患者的ID,就诊ID等信息改变时触发")]
        public event EventHandler PatientInfoChanged = null;
        public virtual void OnPatientInfoChanged(System.EventArgs e)
        {
            if (this.PatientInfoChanged == null)
                return;
            this.RefreshWindowTitle();
            try
            {
                this.PatientInfoChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.OnPatientInfoChanged", ex);
            }
        }

        /// <summary>
        /// 当患者质检问题发生改变时触发
        /// </summary>
        [Description("当患者质检问题发生改变时触发")]
        public event EventHandler PatientScoreChanged = null;
        internal virtual void OnPatientScoreChanged(System.EventArgs e)
        {
            if (this.PatientScoreChanged == null)
                return;
            this.RefreshWindowTitle();
            try
            {
                this.PatientScoreChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.OnPatientScoreChanged", ex);
            }
        }

        /// <summary>
        /// 当患者列表的信息改变时触发
        /// </summary>
        [Description(" 当患者列表的信息改变时触发")]
        public event EventHandler PatientListInfoChanged = null;
        internal virtual void OnPatientListInfoChanged(System.EventArgs e)
        {
            if (this.PatientListInfoChanged == null)
                return;
            this.RefreshWindowTitle();
            try
            {
                this.PatientListInfoChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.OnPatientListInfoChanged", ex);
            }
        }

        /// <summary>
        /// 当停靠窗口活动状态改变时触发
        /// </summary>
        [Description("当停靠窗口活动状态改变时触发")]
        public event EventHandler ActiveContentChanged = null;
        protected virtual void OnActiveContentChanged(System.EventArgs e)
        {
            if (this.ActiveContentChanged == null)
                return;
            try
            {
                this.ActiveContentChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.OnActiveContentChanged", ex);
            }
        }
        private void dockPanel1_ActiveContentChanged(object sender, System.EventArgs e)
        {
            this.OnActiveContentChanged(e);
        }
        private void dockPanel1_ActiveDocumentChanged(object sender, System.EventArgs e)
        {
            if (this.dockPanel1.ActiveDocument is ChenPadDocForm)
            {
                //显示当前活动文档的问题清单
                ChenPadDocForm form = this.dockPanel1.ActiveDocument as ChenPadDocForm;
                MedDocInfo docInfo = form.Document;
                if (docInfo != null)
                    this.ShowQuestionListByDocInfo(docInfo);
                return;
            }
            else if (this.dockPanel1.ActiveDocument is BaodianDocForm)
            {
                BaodianDocForm form = this.dockPanel1.ActiveDocument as BaodianDocForm;
                MedDocInfo docInfo = form.Document;
                if (docInfo != null)
                    this.ShowQuestionListByDocInfo(docInfo);
                return;
            }
            else
            {
                //显示全部问题清单
                this.ShowQuestionListByDocInfo(null);
                return;
            }
        }
        public void ShowQuestionListByDocInfo(MedDocInfo docInfo)
        {
            if (this.m_QuestionListForm == null || this.m_QuestionListForm.IsDisposed)
                return;
            this.m_QuestionListForm.ShowQuestionListByDocInfo(docInfo);
        }

        public delegate void AllDockWindowHiddenHandler(bool bIsHidden);
        /// <summary>
        /// 当同时隐藏或显示所有停靠窗口时触发
        /// </summary>
        [Description("当同时隐藏或显示所有停靠窗口时触发")]
        public event AllDockWindowHiddenHandler AllDockWindowHidden = null;
        protected virtual void OnAllDockWindowHidden(bool bIsHidden)
        {
            if (this.AllDockWindowHidden == null)
                return;
            try
            {
                this.AllDockWindowHidden(bIsHidden);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.OnAllDockWindowHidden", ex);
            }
        }

        public void SwitchPatient(PatVisitInfo patVisit)
        {
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(patVisit.PATIENT_ID, patVisit.VISIT_ID, ref patVisit);
            this.ReSetPatListForm(patVisit);
            this.ShowPatientPageForm(patVisit);
        }
        public void SwitchPatient(string szPatientID, string szVisitID)
        {
            PatVisitInfo patVisit = null;
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(szPatientID, szVisitID, ref patVisit);
            this.ReSetPatListForm(patVisit);
            this.ShowPatientPageForm(patVisit);
        }
        #endregion

        #region"系统初始化"
        public MainForm()
        {
            //设置配置文件
            MessageBoxEx.Caption = Application.ProductName;
            this.InitializeComponent();
            this.menuStrip1.MainForm = this;
            this.toolStrip1.MainForm = this;
            this.statusStrip1.MainForm = this;
            this.Load += new EventHandler(this.MainForm_Load);
            this.Shown += new EventHandler(this.MainForm_Shown);
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            if (SystemParam.Instance.LocalConfigOption.IsNewTheme)
            {
                this.dockPanel1.ShowDocumentSubhead = false;

            }
        }

        public MainForm(string szParam)
        {
            SystemConfig.Instance.ConfigFile = string.Format("{0}\\MedQCSys.xml", Application.StartupPath);
            MessageBoxEx.Caption = Application.ProductName;
            LogManager.Instance.TextLogOnly = true;

            this.InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            bool r= CommandHandler.Instance.SendCommand("切换账号", this, null);
            if (!r)
            {
                this.Close();
            }
            //InitMainForm();
            //this.toolStrip1.Visible = false;
        }

        public void InitMainForm()
        {
            if (SystemParam.Instance.LocalConfigOption.HdpUse)
                this.menuStrip1.RefreshUIConfig();
            this.RefreshWindowTitle();
            this.RestoreWindowState();
            this.Icon = MedQCSys.Properties.Resources.medical;
            this.toolStrip1.Visible = SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_TOOL_STRIP, false);
            this.statusStrip1.Visible = SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_STATUS_STRIP, true);

            //启动消息窗口
            if (SystemParam.Instance.LocalConfigOption.IsShowChat)
                this.StartQChat();
        }

        private void StartQChat()
        {
            ThreadStart func = new ThreadStart(StartMedTask);
            Thread thread = new Thread(func);
            thread.Start();
        }

        public void StartMedTask()
        {
            StringBuilder sbArgs = new StringBuilder();
            //参数：当前用户ID;对方ID；1/0 (1登陆后关闭，0,停留在当前消息窗口)
            sbArgs.AppendFormat("{0};{1};{2};", SystemParam.Instance.UserInfo.ID, "", "1");
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo();
            proc.StartInfo.Arguments = sbArgs.ToString();
            proc.StartInfo.FileName = string.Format(@"{0}\ChatClient.exe", Application.StartupPath);

            try
            {
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("无法启动病历消息提醒程序!");
                LogManager.Instance.WriteLog("CommandHandler.StartMedTask", null, null, "病历消息提醒系统启动失败!", ex);
            }
        }
        public bool ExitMedTask()
        {
            IntPtr hMainFormHandle = GlobalMethods.Win32.GetSystemHandle("ChatClient");
            if (!NativeMethods.User32.IsWindow(hMainFormHandle))
                return true;
            NativeMethods.User32.SetForegroundWindow(hMainFormHandle);
            NativeMethods.User32.SetActiveWindow(hMainFormHandle);
            IntPtr iParam = GlobalMethods.Win32.StringToPtr("QUIT");
            NativeMethods.User32.SendMessage(hMainFormHandle, NativeConstants.WM_COPYDATA, IntPtr.Zero, iParam);
            return !NativeMethods.User32.IsWindow(hMainFormHandle);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Update();
            ////读取界面布局配置
            string szFileName = string.Format("{0}\\MedQC.Dock.config", Application.StartupPath);
            //
            DeserializeDockContent deserializeDockContent =
                new DeserializeDockContent(this.GetContentFromPersistString);
            try
            {
                if (System.IO.File.Exists(szFileName))
                    this.dockPanel1.LoadFromXml(szFileName, deserializeDockContent);

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.MainForm_Shown", ex);
            }

            if (!SystemParam.Instance.QCUserRight.BrowseQCStatistics.Value)
                this.menuStrip1.StatisticMenu.Visible = false;
            this.Update();
            this.SaveWindowState = true;
            if (this.m_PatientListForm != null) this.m_PatientListForm.OnRefreshView();
            if (SystemParam.Instance.LocalConfigOption.IsOpenHomePage)
            {
                CommandHandler.Instance.SendCommand("起始页", this, null);
            }
            else
            {
                if (SystemParam.Instance.LocalConfigOption.IsNewTheme)
                    this.ShowPatientPageForm(null);
            }
            this.Update();
            this.ShowSystemAboutForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //未登录时关闭主窗口,则不予提示
            if (SystemParam.Instance.UserInfo == null) return;

            if (MessageBoxEx.Show("确认关闭病案质控系统吗？"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }
            this.Update();
            this.ExitMedTask();
            this.RestoreAllDockWindow();
            try
            {
                this.dockPanel1.SaveAsXml(string.Format("{0}\\MedQC.Dock.config", Application.StartupPath));
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.MainForm_FormClosing", ex);
            }
        }

        /// <summary>
        /// 显示系统版本更新信息
        /// </summary>
        private void ShowSystemAboutForm()
        {
            string szVersionsFile = string.Format("{0}\\Versions.dat"
                , GlobalMethods.Misc.GetWorkingPath());
            DateTime dtLastWriteTime = DateTime.Now;
            GlobalMethods.IO.GetFileLastModifyTime(szVersionsFile, ref dtLastWriteTime);
            string szLastModifyTime = dtLastWriteTime.ToString("yyyyMMddHHmmss");

            if (SystemParam.Instance.UserInfo == null)
                return;
            string szConfigKey = "Readme." + SystemParam.Instance.UserInfo.ID;
            string szCurrModifyTime = SystemConfig.Instance.Get(szConfigKey, string.Empty);
            if (szCurrModifyTime != szLastModifyTime)
            {
                (new SystemAboutForm()).ShowDialog();
                SystemConfig.Instance.Write(szConfigKey, szLastModifyTime);
            }
        }

        /// <summary>
        /// 刷新主程序窗口显示标题
        /// </summary>
        internal void RefreshWindowTitle()
        {
            string szUserName = string.Empty;
            if (SystemParam.Instance.UserInfo == null)
                szUserName = "未登录";
            else
                szUserName = SystemParam.Instance.UserInfo.Name + (SystemParam.Instance.QCUserRight.IsSpecialDoc.Value ? "(专家)" : "(普通)");
            string szPatientName = string.Empty;
            if (SystemParam.Instance.PatVisitInfo == null)
                szPatientName = "未选择";
            else
                szPatientName = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            if (SystemParam.Instance.LocalConfigOption.HdpUse
                && DataCache.Instance.HdpProduct!=null)
                this.Text = string.Format("{0} - 当前用户：{1}，当前患者：{2}", DataCache.Instance.HdpProduct.CN_NAME, szUserName, szPatientName);
            else
                this.Text = string.Format("{0} - 当前用户：{1}，当前患者：{2}", Application.ProductName, szUserName, szPatientName);
        }

        /// <summary>
        /// DockPanel组件初始化各停靠窗口时,回调函数实现
        /// </summary>
        /// <param name="szPersistString">停靠窗口类型全名字符串</param>
        /// <returns>IDockContent</returns>
        private IDockContent GetContentFromPersistString(string szPersistString)
        {
            if (szPersistString == typeof(PatientListForm).ToString())
            {
                if (this.m_PatientListForm == null || this.m_PatientListForm.IsDisposed)
                    this.m_PatientListForm = new PatientListForm(this);
                return this.m_PatientListForm;
            }
            else if (szPersistString == typeof(DocumentListForm).ToString() || szPersistString == typeof(PatsDocmentListForm).ToString())
            {
                //判断是否显示病程记录窗口
                if (!SystemParam.Instance.QCUserRight.BrowseDocumentList.Value)
                    return null;

                if (SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_MANY_PATIENT_DOCLIST, false))
                {
                    if (this.m_PatDocListForm == null || this.m_PatDocListForm.IsDisposed)
                        this.m_PatDocListForm = new PatsDocmentListForm(this);
                    return this.m_PatDocListForm;
                }
                else
                {

                    if (this.m_DocumentListForm == null || this.m_DocumentListForm.IsDisposed)
                        this.m_DocumentListForm = new DocumentListForm(this);
                    return this.m_DocumentListForm;
                }
            }
            else if (szPersistString == typeof(QuestionListForm).ToString())
            {
                //判断是否显示质检问题窗口
                if (!SystemParam.Instance.QCUserRight.BrowseQCQuestion.Value)
                    return null;

                if (this.m_QuestionListForm == null || this.m_QuestionListForm.IsDisposed)
                    this.m_QuestionListForm = new QuestionListForm(this);
                return this.m_QuestionListForm;
            }
            else if (szPersistString == typeof(DocumentTimeForm).ToString())
            {
                //判断是否显示病历时效窗口
                if (!SystemParam.Instance.QCUserRight.BrowseDocumentTime.Value)
                    return null;

                if (this.m_DocumentTimeForm == null || this.m_DocumentTimeForm.IsDisposed)
                    this.m_DocumentTimeForm = new DocumentTimeForm(this);
                return this.m_DocumentTimeForm;
            }
            else if (szPersistString == typeof(ExamResultListForm).ToString())
            {
                //判断是否显示检查记录窗口
                if (!SystemParam.Instance.QCUserRight.BrowseExamList.Value)
                    return null;

                if (this.m_ExamResultForm == null || this.m_ExamResultForm.IsDisposed)
                    this.m_ExamResultForm = new ExamResultListForm(this);
                return this.m_ExamResultForm;
            }
            else if (szPersistString == typeof(TestResultListForm).ToString())
            {
                //判断是否显示检验记录窗口
                if (!SystemParam.Instance.QCUserRight.BrowseLabTestList.Value)
                    return null;

                if (this.m_TestResultForm == null || this.m_TestResultForm.IsDisposed)
                    this.m_TestResultForm = new TestResultListForm(this);
                return this.m_TestResultForm;
            }
            else if (szPersistString == typeof(OrdersListForm).ToString())
            {
                //判断是否显示医嘱列表窗口
                if (!SystemParam.Instance.QCUserRight.BrowseOrdersList.Value)
                    return null;

                if (this.m_OrdersListForm == null || this.m_OrdersListForm.IsDisposed)
                    this.m_OrdersListForm = new OrdersListForm(this);
                return this.m_OrdersListForm;
            }
            else if (szPersistString == typeof(DiagnosisListForm).ToString())
            {
                //判断是否显示患者诊断信息窗口
                if (!SystemParam.Instance.QCUserRight.BrowseDiagnosisList.Value)
                    return null;

                if (this.m_DiagnosisListForm == null || this.m_DiagnosisListForm.IsDisposed)
                    this.m_DiagnosisListForm = new DiagnosisListForm(this);
                return this.m_DiagnosisListForm;
            }
            else if (szPersistString == typeof(PatientInfoForm).ToString())
            {
                //判断是否显示患者信息窗口
                if (!SystemParam.Instance.QCUserRight.BrowsePatientInfo.Value)
                    return null;

                if (this.m_PatientInfoForm == null || this.m_PatientInfoForm.IsDisposed)
                    this.m_PatientInfoForm = new PatientInfoForm(this);
                return this.m_PatientInfoForm;
            }
            else if (szPersistString == typeof(DocScoreForm).ToString())
            {
                //判断是否显示病案评分
                if (!SystemParam.Instance.QCUserRight.BrowseMRScore.Value)
                    return null;

                if (this.m_DocScoreForm == null || this.m_DocScoreForm.IsDisposed)
                    this.m_DocScoreForm = new DocScoreForm(this);
                return this.m_DocScoreForm;
            }
            else if (szPersistString == typeof(VitalSignsGraphForm).ToString())
            {
                //判断是否显示病案评分
                string szTempletPath = string.Format(@"{0}\Templet\\{1}\\{2}"
               , GlobalMethods.Misc.GetWorkingPath()
               , MedDocSys.DataLayer.SystemParam.Instance.SystemOption.HospitalName
               , "体温单.hrdt"
               );
                if (!File.Exists(szTempletPath))
                    return null;

                if (this.m_VitalSignsGraphForm == null || this.m_VitalSignsGraphForm.IsDisposed)
                    this.m_VitalSignsGraphForm = new VitalSignsGraphForm(this);
                return this.m_VitalSignsGraphForm;
            }
            return null;
        }

        #endregion

        #region"显示各子窗口"
        internal void ShowPatientListForm()
        {
            try
            {
                if (this.m_PatientListForm == null || this.m_PatientListForm.IsDisposed)
                {
                    this.m_PatientListForm = new PatientListForm(this);
                    this.m_PatientListForm.Show(this.dockPanel1);
                }
                else
                {
                    this.m_PatientListForm.Activate();
                }
                this.m_PatientListForm.OnRefreshView();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        internal void ShowDocumentListForm()
        {
            //判断是否显示病程记录窗口
            if (!SystemParam.Instance.QCUserRight.BrowseDocumentList.Value)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            if (this.m_DocumentListForm == null || this.m_DocumentListForm.IsDisposed)
            {
                this.m_DocumentListForm = new DocumentListForm(this);
                //始终把病程记录Tab显示在第一位
                IDockContent activeDocument = this.dockPanel1.ActiveDocument;
                if (activeDocument == null)
                {
                    this.m_DocumentListForm.Show(this.dockPanel1);
                }
                else
                {
                    DockPane pane = activeDocument.DockHandler.PanelPane;
                    this.m_DocumentListForm.Show(pane, activeDocument);
                }
            }
            else
            {
                this.m_DocumentListForm.Activate();
            }
            this.m_DocumentListForm.OnRefreshView();

            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowPatsDocumentListForm()
        {
            //判断是否显示病程记录窗口
            if (!SystemParam.Instance.QCUserRight.BrowseDocumentList.Value)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_PatDocListForm == null || this.m_PatDocListForm.IsDisposed)
            {
                this.m_PatDocListForm = new PatsDocmentListForm(this);
                //始终把病程记录Tab显示在第一位
                IDockContent activeDocument = this.dockPanel1.ActiveDocument;
                if (activeDocument == null)
                {
                    this.m_PatDocListForm.Show(this.dockPanel1);
                }
                else
                {
                    DockPane pane = activeDocument.DockHandler.PanelPane;
                    this.m_PatDocListForm.Show(pane, activeDocument);
                }
            }
            else
            {
                this.m_PatDocListForm.Activate();
            }
            this.m_PatDocListForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowDocumentBugsForm(IDocumentForm documentForm)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_DocumentBugsForm == null || this.m_DocumentBugsForm.IsDisposed)
            {
                this.m_DocumentBugsForm = new DocumentBugsForm(this);
            }
            else
            {
                this.m_DocumentBugsForm.Activate();
            }
            this.m_DocumentBugsForm.DocumentForm = documentForm;
            if (SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_FORM_EMBED, true))
            {
                this.m_DocumentBugsForm.SaveWindowBoundsEnabled = false;
                this.m_DocumentBugsForm.Owner = null;
                this.m_DocumentBugsForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_DocumentBugsForm.Owner = (documentForm as Form);
                this.m_DocumentBugsForm.Show();
                this.m_DocumentBugsForm.SaveWindowBoundsEnabled = true;
                GlobalMethods.UI.ActivateWindow(this.m_DocumentBugsForm.Handle);
            }
            this.m_DocumentBugsForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowQuestionListForm()
        {
            //判断是否显示质检问题窗口
            if (!SystemParam.Instance.QCUserRight.BrowseQCQuestion.Value)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_QuestionListForm == null || this.m_QuestionListForm.IsDisposed)
            {
                this.m_QuestionListForm = new QuestionListForm(this);
                this.m_QuestionListForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_QuestionListForm.Activate();
            }
            this.m_QuestionListForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowPatientIndexForm()
        {

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_PatientIndexForm == null || this.m_PatientIndexForm.IsDisposed)
            {
                this.m_PatientIndexForm = new PatientIndexForm(this);
                this.m_PatientIndexForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_PatientIndexForm.Activate();
            }
            this.m_PatientIndexForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 显示质检问题窗口,并弹出病案质控系统问题分类对话框
        /// </summary>
        /// <param name="szDocTitle">病历标题</param>
        /// <param name="szDocSetID">病历文档集ID</param>
        /// <<param name="szCreator">病历的创建者</param>
        /// <<param name="szDeptCode">病历的创建者所在科室</param>
        internal void AddFeedBackInfo(string szDocTitle, string szDocSetID, string szCreatorName, string szDeptCode, byte[] byteDocData)
        {
            this.ShowQuestionListForm();
            this.m_QuestionListForm.AddNewItem(szDocTitle, szDocSetID, szCreatorName, szDeptCode, byteDocData);
        }

        internal void ShowDocumentTimeForm()
        {
            //判断是否显示病历时效窗口
            if (!SystemParam.Instance.QCUserRight.BrowseDocumentTime.Value)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_DocumentTimeForm == null || this.m_DocumentTimeForm.IsDisposed)
            {
                this.m_DocumentTimeForm = new DocumentTimeForm(this);
                this.m_DocumentTimeForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_DocumentTimeForm.Activate();
            }
            this.m_DocumentTimeForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowExamResultListForm()
        {
            //判断是否显示检查记录窗口
            if (!SystemParam.Instance.QCUserRight.BrowseExamList.Value)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_ExamResultForm == null || this.m_ExamResultForm.IsDisposed)
            {
                this.m_ExamResultForm = new ExamResultListForm(this);
                this.m_ExamResultForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_ExamResultForm.Activate();
            }
            this.m_ExamResultForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowDiagnosisResultForm()
        {
            //判断是否显示诊断信息窗口
            if (!SystemParam.Instance.QCUserRight.BrowseDiagnosisList.Value)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_DiagnosisListForm == null || this.m_DiagnosisListForm.IsDisposed)
            {
                this.m_DiagnosisListForm = new DiagnosisListForm(this);
                this.m_DiagnosisListForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_DiagnosisListForm.Activate();
            }
            this.m_DiagnosisListForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 获取指定病人信息对应的病人选项卡窗口
        /// </summary>
        /// <param name="patVisit">病人信息</param>
        /// <returns>病人选项卡窗口</returns>
        public PatientPageForm GetPatientPageForm(PatVisitInfo patVisit)
        {
            if (patVisit == null)
                return null;
            return this.GetPatientPageForm(patVisit.PATIENT_ID, patVisit.VISIT_ID);
        }
        /// <summary>
        /// 获取已打开的病人窗口中第一个病人选项卡窗口
        /// </summary>
        /// <returns>病人选项卡窗口</returns>
        internal PatientPageForm GetPatientPageForm()
        {
            foreach (IDockContent content in this.dockPanel1.Documents)
            {
                PatientPageForm patientPageForm = content as PatientPageForm;
                if (patientPageForm != null && !patientPageForm.IsDisposed)
                    return patientPageForm;
            }
            return null;
        }
        /// <summary>
        /// 获取指定病人信息对应的病人选项卡窗口
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <returns>病人选项卡窗口</returns>
        internal PatientPageForm GetPatientPageForm(string szPatientID, string szVisitID)
        {
            foreach (IDockContent content in this.dockPanel1.Documents)
            {
                PatientPageForm patientPageForm = content as PatientPageForm;
                if (patientPageForm == null || patientPageForm.IsDisposed)
                    continue;
                if (patientPageForm.PatVisitInfo == null)
                    return patientPageForm;
                if (patientPageForm.PatVisitInfo.PATIENT_ID == szPatientID
                    && patientPageForm.PatVisitInfo.VISIT_ID == szVisitID)
                    return patientPageForm;
            }
            return null;
        }

        /// <summary>
        /// 打开指定病人就诊信息的病人选项卡窗口
        /// </summary>
        /// <param name="patVisit">病人就诊信息</param>
        public void ShowPatientPageForm(PatVisitInfo patVisit)
        {
            if (!string.IsNullOrEmpty(DataCache.Instance.QcAdminDepts) && DataCache.Instance.QcAdminDepts.IndexOf(patVisit.DEPT_NAME) < 0)
            {
                MessageBoxEx.ShowMessage(string.Format("您的管辖科室为{0},患者不在范围内，无法打开患者病案", DataCache.Instance.QcAdminDepts));
                return;
            }
            this.ShowPatientPageForm(patVisit, null, null);
        }

        /// <summary>
        /// 打开指定病人就诊信息的病人的指定文档类型和指定文档记录的文档编辑窗口
        /// </summary>
        /// <param name="patVisit">病人就诊信息</param>
        /// <param name="szDocTypeID">文档类型ID</param>
        /// <param name="szDocID">文档记录ID</param>
        public void ShowPatientPageForm(PatVisitInfo patVisit, string szDocTypeID, string szDocID)
        {

            PatPage.PatientPageForm patientPageForm = this.GetPatientPageForm(patVisit);
            if (patientPageForm == null || patientPageForm.IsDisposed)
            {
                if (SystemParam.Instance.LocalConfigOption.SinglePatientMode)
                    patientPageForm = this.GetPatientPageForm();
            }
            if (patientPageForm == null || patientPageForm.IsDisposed)
            {
                patientPageForm = new PatientPageForm(this);
                patientPageForm.Show(this.dockPanel1);
            }

            patientPageForm.DockHandler.Activate();
            if (!patientPageForm.SwitchPatient(patVisit))
                return;

            //打开并定位到指定的已保存的表单或新建表单
            //if (!GlobalMethods.Misc.IsEmptyString(szDocTypeID))
            //{
            //    Application.DoEvents();
            //    patientPageForm.LocateToModule(szDocTypeID, szDocID);
            //}
        }

        internal void ShowTestResultListForm()
        {
            //判断是否显示检验记录窗口
            if (!SystemParam.Instance.QCUserRight.BrowseLabTestList.Value)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_TestResultForm == null || this.m_TestResultForm.IsDisposed)
            {
                this.m_TestResultForm = new TestResultListForm(this);
                this.m_TestResultForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_TestResultForm.Activate();
            }
            this.m_TestResultForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowVitalSignsGraphForm()
        {

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_VitalSignsGraphForm == null || this.m_VitalSignsGraphForm.IsDisposed)
            {
                this.m_VitalSignsGraphForm = new VitalSignsGraphForm(this);
                this.m_VitalSignsGraphForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_VitalSignsGraphForm.Activate();
            }
            this.m_VitalSignsGraphForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowOrdersListForm()
        {
            //判断是否显示医嘱列表窗口
            if (!SystemParam.Instance.QCUserRight.BrowseOrdersList.Value)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_OrdersListForm == null || this.m_OrdersListForm.IsDisposed)
            {
                this.m_OrdersListForm = new OrdersListForm(this);
                this.m_OrdersListForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_OrdersListForm.Activate();
            }
            this.m_OrdersListForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }


        internal void ShowStandardTermForm(string szSearchText)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            CommandHandler.Instance.SendCommand("ICD10标准诊断库", this, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowPatientInfoForm()
        {
            //判断是否显示患者信息窗口
            if (!SystemParam.Instance.QCUserRight.BrowsePatientInfo.Value)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Update();
            if (this.m_PatientInfoForm == null || this.m_PatientInfoForm.IsDisposed)
            {
                this.m_PatientInfoForm = new PatientInfoForm(this);
                this.m_PatientInfoForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_PatientInfoForm.Activate();
                this.m_PatientInfoForm.OnRefreshView();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }


        internal void ShowModifyPwdForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void ShowSysHelpForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            //打开用户手册(Word文档)
            string szHelpFile = string.Format("{0}\\mrqc.doc", Application.StartupPath);
            try
            {
                if (System.IO.File.Exists(szHelpFile))
                    System.Diagnostics.Process.Start(szHelpFile);
                else
                    MessageBoxEx.Show("未找到用户手册文件!");
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.ShowSysHelpForm", ex);
                MessageBoxEx.Show("无法打开用户手册文件!", ex.Message);
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        public void ShowDocScoreForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Update();
            if (this.m_DocScoreForm == null || this.m_DocScoreForm.IsDisposed)
            {
                this.m_DocScoreForm = new DocScoreForm(this);
                this.m_DocScoreForm.Show(this.dockPanel1);
            }
            else
            {
                this.m_DocScoreForm.Activate();
            }
            this.m_DocScoreForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        internal void RefreshDocScoreView()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Update();
            if (this.m_DocScoreForm == null || this.m_DocScoreForm.IsDisposed)
                return;
            if (!this.m_DocScoreForm.IsActivated)
                return;
            this.m_DocScoreForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        #endregion

        #region"病历文档操作"
        /// <summary>
        /// 切换文档窗口的显示模式(嵌入/弹出)
        /// </summary>
        internal void SwitchDocumentFormMode(bool bIsEmbed)
        {
            FormCollection lstOpenForms = Application.OpenForms;
            for (int index = 0; index < lstOpenForms.Count; index++)
            {
                DockContentBase content = lstOpenForms[index] as DockContentBase;
                if (content == null || content.IsDisposed)
                    continue;
                if (!(content is IDocumentForm)
                    && !(content is DocumentBugsForm))
                {
                    continue;
                }

                if (bIsEmbed)
                {
                    GlobalMethods.UI.ActivateWindow(content.Handle);
                    content.Visible = false;
                    content.SaveWindowBoundsEnabled = false;
                    content.Owner = null;
                    content.DockPanel = this.dockPanel1;
                    content.Show();
                    continue;
                }

                content.DockPanel = null;
                content.TopLevel = true;
                content.FormBorderStyle = FormBorderStyle.Sizable;
                content.RestoreWindowLocationAndSize();
                content.Show();
                content.BringToFront();
                content.SaveWindowBoundsEnabled = true;

                DocumentBugsForm frmDocumentBugs = content as DocumentBugsForm;
                if (frmDocumentBugs != null && !frmDocumentBugs.IsDisposed)
                {
                    if (frmDocumentBugs.DocumentForm == null || frmDocumentBugs.DocumentForm.IsDisposed)
                        frmDocumentBugs.DocumentForm = null;
                    frmDocumentBugs.Owner = this;
                }
            }
        }

        /// <summary>
        /// 切换显示病程记录窗口显示的样式
        /// </summary>
        /// <param name="bShowPatDocList">是否在同一个窗口中同时显示多个患者的病程记录</param>
        internal void SwitchDocumentListFormMode(bool bShowPatsDocList)
        {
            if (bShowPatsDocList)
            {
                if (this.m_DocumentListForm != null)
                {
                    this.m_DocumentListForm.Close();
                    this.m_DocumentListForm.Dispose();
                    this.ShowPatsDocumentListForm();
                }
            }
            else
            {
                if (this.m_PatDocListForm != null)
                {
                    this.m_PatDocListForm.Close();
                    this.m_PatDocListForm.Dispose();
                    this.ShowDocumentListForm();
                }
            }
        }

        /// <summary>
        /// 激活指定的病历文档窗口
        /// </summary>
        /// <param name="docInfo">病历信息</param>
        internal bool ActivateDocument(MedDocInfo docInfo)
        {
            if (docInfo == null)
                return false;
            FormCollection lstOpenForms = Application.OpenForms;
            for (int index = 0; index < lstOpenForms.Count; index++)
            {
                IDocumentForm documentForm = lstOpenForms[index] as IDocumentForm;
                if (documentForm == null || documentForm.IsDisposed)
                    continue;
                if (documentForm.Documents == null)
                    continue;
                MedDocInfo document = documentForm.Documents[0];
                if (document.PATIENT_ID != docInfo.PATIENT_ID)
                    continue;
                if (document.VISIT_ID != docInfo.VISIT_ID)
                    continue;
                if (document.FileName != docInfo.FileName)
                    continue;
                if (SystemParam.Instance.LocalConfigOption.DefaultEditor != "2")
                {
                    if (document.DOC_ID != docInfo.DOC_ID)
                        continue;
                    if (document.DOC_TIME != docInfo.DOC_TIME)
                        continue;
                }
                else
                {
                    //和仁编辑器控件通过docsetid来打开
                    if (document.DOC_SETID != docInfo.DOC_SETID)
                    {
                        continue;
                    }
                    HerenDocForm herenDocForm = documentForm as HerenDocForm;
                    herenDocForm.ClickDocument = docInfo;
                    if (herenDocForm == null)
                        continue;
                    SectionInfo section = herenDocForm.TextEditor.GetSection(docInfo.DOC_ID, MatchMode.ID);
                    if (herenDocForm.TextEditor.GotoSection(section))
                    {
                        herenDocForm.TextEditor.ScrollToView();
                        herenDocForm.TextEditor.SelectCurrentLine();
                    }

                }

                Form form = documentForm as Form;
                if (form.Parent != null) form.BringToFront();
                documentForm.DockHandler.Activate();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 激活指定的病历文档窗口
        /// </summary>
        /// <param name="docInfo">病历信息</param>
        internal bool ActivateDocument(MedDocList lstDocInfos)
        {
            return (lstDocInfos == null || lstDocInfos.Count <= 0) ?
                false : this.ActivateDocument(lstDocInfos[0]);
        }

        /// <summary>
        /// 质控人员打开历史病历
        /// </summary>
        internal void OpenHistoryDocument(EMRDBLib.MedicalQcMsg questionInfo)
        {

            if (string.IsNullOrEmpty(questionInfo.TOPIC_ID))
            {
                MessageBoxEx.Show("没有找到需要打开的病历!", MessageBoxIcon.Warning);
                return;
            }
            List<MedDocInfo> lstDocInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfoBySetID(questionInfo.TOPIC_ID, ref lstDocInfo);
            if (shRet != SystemData.ReturnValue.OK || lstDocInfo == null)
            {
                MessageBoxEx.Show("没有找到需要打开的病历！", MessageBoxIcon.Warning);
                return;
            }
            MedDocInfo docInfo = new MedDocInfo();
            docInfo.PATIENT_ID = questionInfo.PATIENT_ID;
            docInfo.VISIT_ID = questionInfo.VISIT_ID;
            docInfo.EMR_TYPE = lstDocInfo[0].EMR_TYPE;
            if (lstDocInfo[0].EMR_TYPE != "CHENPAD"
                && lstDocInfo[0].EMR_TYPE != "HEREN")
                docInfo.EMR_TYPE = "BAODIAN";
            docInfo.DOC_TIME = questionInfo.ISSUED_DATE_TIME;
            docInfo.CREATOR_NAME = questionInfo.ISSUED_BY;
            docInfo.DOC_ID = questionInfo.TOPIC_ID;
            if (this.ActivateDocument(docInfo))
                return;
            if (SystemParam.Instance.LocalConfigOption.DefaultEditor == "2")
            {
                this.OpenHerenDocument(docInfo);
                return;
            }
            IDocumentForm documentForm = DocFormFactory.Instance.CreateDocForm(this, docInfo);
            if (documentForm == null || documentForm.IsDisposed)
                return;

            DockContentBase content = documentForm as DockContentBase;
            if (content == null || content.IsDisposed)
                return;

            if (!SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_FORM_EMBED, true))
            {
                content.Show();
                content.SaveWindowBoundsEnabled = true;
                content.BringToFront();
            }
            else
            {
                content.SaveWindowBoundsEnabled = false;
                content.Show(this.dockPanel1);
                documentForm.DockHandler.Activate();
            }
            documentForm.OpenHistoryDocument(questionInfo);
            //if (!SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_READONLY, false))
            //    documentForm.MedEditor.Readonly = false;
        }

        /// <summary>
        /// 打开指定病历信息的病历文档
        /// </summary>
        /// <param name="docInfo">病历信息</param>
        public void OpenDocument(MedDocInfo docInfo)
        {
            try
            {
                //打开和仁编辑器文书
                if (SystemParam.Instance.LocalConfigOption.DefaultEditor == "2")
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                    if (this.ActivateDocument(docInfo))
                    {
                        GlobalMethods.UI.SetCursor(this, Cursors.Default);
                        return;
                    }
                    this.OpenHerenDocument(docInfo);
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }

                MedDocList lstDocInfos = new MedDocList();
                lstDocInfos.Add(docInfo);
                this.OpenDocument(lstDocInfos);
                ShowQuestionListByDocInfo(lstDocInfos[0]);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("OpenDocument", ex);
            }
        }

        internal void OpenHerenDocument(MedDocInfo docInfo)
        {
            MedDocInfo hostDocInfo = null;
            if (!string.IsNullOrEmpty(docInfo.DOC_SETID)
                && docInfo.DOC_SETID != docInfo.DOC_ID)
            {
                EmrDocAccess.Instance.GetDocInfo(docInfo.DOC_SETID, ref hostDocInfo);
            }
            if (hostDocInfo == null)
                hostDocInfo = docInfo;
            IDocumentForm documentForm = DocFormFactory.Instance.CreateDocForm(this, hostDocInfo);
            if (documentForm == null || documentForm.IsDisposed)
                return;

            DockContentBase content = documentForm as DockContentBase;
            if (content == null || content.IsDisposed)
                return;
            if (!SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_FORM_EMBED, true))
            {
                content.Show();
                content.SaveWindowBoundsEnabled = true;
                content.BringToFront();
            }
            else
            {
                content.SaveWindowBoundsEnabled = false;
                content.Show(this.dockPanel1);
                documentForm.DockHandler.Activate();
            }

            HerenDocForm form = documentForm as HerenDocForm;
            form.ClickDocument = docInfo;
            documentForm.OpenDocument(hostDocInfo);
            if (form == null || form.IsDisposed)
                return;
            //打开文档后是否显示为只读状态
            if (!SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_READONLY, false))
            {
                form.TextEditor.ReadOnly = false;
            }
        }
        /// <summary>
        /// 打开指定的一系列的病历文档
        /// </summary>
        /// <param name="lstDocInfos">病历信息列表</param>
        public void OpenDocument(MedDocList lstDocInfos)
        {

            if (lstDocInfos == null || lstDocInfos.Count <= 0)
                return;
            if (this.ActivateDocument(lstDocInfos))
                return;
            IDocumentForm documentForm = DocFormFactory.Instance.CreateDocForm(this, lstDocInfos);
            if (documentForm == null || documentForm.IsDisposed)
                return;

            DockContentBase content = documentForm as DockContentBase;
            if (content == null || content.IsDisposed)
                return;

            if (!SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_FORM_EMBED, true))
            {
                content.Show();
                content.SaveWindowBoundsEnabled = true;
                content.BringToFront();
            }
            else
            {
                content.SaveWindowBoundsEnabled = false;
                content.Show(this.dockPanel1);
                documentForm.DockHandler.Activate();
            }
            if (lstDocInfos.Count > 1)
                documentForm.OpenDocument(lstDocInfos);
            else
            {
                documentForm.OpenDocument(lstDocInfos[0]);
                //打开文档后是否显示为只读状态
                if (!SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_READONLY, false))
                {
                    if (lstDocInfos[0].EMR_TYPE != "HEREN")
                        documentForm.MedEditor.Readonly = false;
                }
            }
            //modified by yap on 2014-07-10 
            //考虑到无编辑病历权限的质控人员给病历插入批注问题，将病历置为可编辑状态
            //但是在单击工具条上保存按钮时必须判断其是否具有保存病历权限，如没有不允许保存。
            if (lstDocInfos[0].EMR_TYPE != "HEREN")
            {
                if (lstDocInfos.Count > 1)
                {
                    MessageBoxEx.ShowMessage("合并打开的文档不允许编辑");
                    documentForm.MedEditor.Readonly = true;
                    return;
                }
                documentForm.MedEditor.Readonly = false;
            }
        }

        /// <summary>
        /// 统计报表双击打开病历
        /// DocSetID不为空时打开此病历
        /// 为空打开患者所有病历
        /// </summary>
        /// <param name="szDocSetID">病历的SetID</param>
        /// <param name="szPatientID"></param>
        /// <param name="szVisitID"></param>
        public void OpenDocument(string szDocSetID, string szPatientID, string szVisitID)
        {
            PatVisitInfo patVisitInfo = null;
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(szPatientID, szVisitID, ref patVisitInfo);
            //打开病历时有可能会增加质检问题，此时应将患者列表清空并只留当前选中患者
            ReSetPatListForm(patVisitInfo);

            //如果病历DocSetID不为空则打开此病历
            //为空则打开此患者所有病历
            MedDocInfo docInfo = null;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (!string.IsNullOrEmpty(szDocSetID))
            {
                shRet = EmrDocAccess.Instance.GetLatestDocID(szDocSetID, ref docInfo);
                if (shRet != SystemData.ReturnValue.OK || docInfo == null)
                {
                    MessageBoxEx.Show("查找病历信息失败！");
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                OpenDocument(docInfo);
            }
            else
            {
                MedDocList lstDocInfos = null;
                shRet = EmrDocAccess.Instance.GetDocInfos(szPatientID, szVisitID,
                   SystemData.VisitType.IP, DateTime.Now, string.Empty, ref lstDocInfos);
                if (shRet != SystemData.ReturnValue.OK || lstDocInfos == null || lstDocInfos.Count == 0)
                {
                    //MessageBoxEx.Show("查找患者所有病历！");
                    this.ShowDocumentListForm();
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                if (SystemParam.Instance.LocalConfigOption.DefaultEditor == "2")
                {
                    this.ShowDocumentListForm();
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                OpenDocument(lstDocInfos);
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ReSetPatListForm(PatVisitInfo patVistLog)
        {
            if (this.m_PatientListForm == null || this.m_PatientListForm.IsDisposed)
                this.m_PatientListForm = new PatientListForm(this);

            this.m_PatientListForm.LoadPatientVisitList(new List<EMRDBLib.PatVisitInfo> { patVistLog }, true);
        }

        #endregion

        /// <summary>
        /// 隐藏除文档窗口外的所有停靠的窗口和浮动的窗口
        /// </summary>
        internal void HideAllDockWindow()
        {
            if (this.dockPanel1 == null || this.dockPanel1.IsDisposed)
                return;
            this.Update();
            for (int index = 0; index < this.dockPanel1.Contents.Count; index++)
            {
                DockContentBase dockContent = this.dockPanel1.Contents[index] as DockContentBase;
                if (dockContent == null || dockContent.IsDisposed)
                    continue;
                if (dockContent.DockState == DockState.Hidden)
                    continue;
                if (dockContent.DockState == DockState.Document)
                    continue;
                if (dockContent.DockState == DockState.DockTopAutoHide)
                    continue;
                if (dockContent.DockState == DockState.DockBottomAutoHide)
                    continue;
                if (dockContent.DockState == DockState.DockLeftAutoHide)
                    continue;
                if (dockContent.DockState == DockState.DockRightAutoHide)
                    continue;
                dockContent.Hide();
                dockContent.IsUserHidden = true;
            }
            //触发所有停靠窗口同时被隐藏或显示的事件
            this.OnAllDockWindowHidden(true);
        }

        /// <summary>
        /// 恢复被隐藏的所有停靠的窗口和浮动的窗口
        /// </summary>
        internal void RestoreAllDockWindow()
        {
            if (this.dockPanel1 == null || this.dockPanel1.IsDisposed)
                return;
            this.Update();
            IDockContent activeContent = this.dockPanel1.ActiveContent;
            for (int index = 0; index < this.dockPanel1.Contents.Count; index++)
            {
                DockContentBase dockContent = this.dockPanel1.Contents[index] as DockContentBase;
                if (dockContent == null || dockContent.IsDisposed)
                    continue;
                if (!dockContent.IsUserHidden)
                    continue;
                dockContent.IsUserHidden = false;
                if (dockContent.DockState == DockState.Document)
                    continue;
                if (dockContent.DockState != DockState.Hidden)
                    continue;
                dockContent.DockHandler.Show(this.dockPanel1);
            }
            if (activeContent != null)
                activeContent.DockHandler.Activate();

            //触发所有停靠窗口同时被隐藏或显示的事件
            this.OnAllDockWindowHidden(false);
        }

        /// <summary>
        /// 在主程序任务栏上显示一条消息
        /// </summary>
        /// <param name="szMessage">消息串</param>
        public void ShowStatusMessage(string szMessage)
        {
            if (this.statusStrip1 != null && !this.statusStrip1.IsDisposed)
                this.statusStrip1.ShowStatusMessage(szMessage);
        }

        /// <summary>
        /// 显示或隐藏工具栏
        /// </summary>
        /// <param name="bVisible">显示或隐藏</param>
        internal void ShowToolStrip(bool bVisible)
        {
            if (this.toolStrip1 != null && !this.toolStrip1.IsDisposed)
                this.toolStrip1.Visible = bVisible;
            SystemConfig.Instance.Write(SystemData.ConfigKey.SHOW_TOOL_STRIP, bVisible.ToString());
        }

        /// <summary>
        /// 显示或隐藏状态栏
        /// </summary>
        /// <param name="bVisible">显示或隐藏</param>
        internal void ShowStatusStrip(bool bVisible)
        {
            if (this.statusStrip1 != null && !this.statusStrip1.IsDisposed)
                this.statusStrip1.Visible = bVisible;
            SystemConfig.Instance.Write(SystemData.ConfigKey.SHOW_STATUS_STRIP, bVisible.ToString());
        }

        /// <summary>
        /// 刷新患者列表中的病案审核状态
        /// </summary>
        internal void RefreshQCResultStatus(float fScore)
        {
            if (this.m_PatientListForm != null && !this.m_PatientListForm.IsDisposed)
                this.m_PatientListForm.RefreshPatStatus(fScore);
        }
        public void DocScoreNewForm_HummanScoreSaved(object sender, EventArgs e)
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            if (this.m_PatientListForm != null && !this.m_PatientListForm.IsDisposed)
                this.m_PatientListForm.RefreshDocScore();
        }

    }
}