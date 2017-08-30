// ***********************************************************
// 病历编辑器配置管理系统主程序窗口.
// Creator:YangMingkun  Date:2010-11-29
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Designers;
using Designers.Report;
using Designers.Templet;
using System.ComponentModel;
using Designers.FindReplace;
using EMRDBLib;
using System.Diagnostics;
using MedQCSys;

namespace Designers
{
    public partial class DesignForm : MedQCSys.DockForms.DockContentBase
    {
        private ToolboxListForm m_ToolboxListForm = null;
        private PropertyEditForm m_PropertyEditForm = null;
        private ErrorsListForm m_ErrorsListForm = null;
        private FindReplaceForm m_FindReplaceForm = null;
        private FindResultForm m_FindResultForm = null;


        #region"系统初始化"
        public DesignForm()
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;

        }
        public DesignForm(MainForm form) : base(form)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.RestoreWindowState();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //设置为自动保存窗口状态
            //this.SaveWindowState = true;

            //读取界面布局配置
            this.LoadLayoutConfig();
            this.ShowStatusMessage("已就绪!");

            ReportHandler.Instance.InitReportHandler(this);
            Templet.TempletHandler.Instance.InitTempletHandler(this);


            //双击模板打开
            if (!string.IsNullOrEmpty(FilePath))
            {
                OpenFile(FilePath);
            }
            //修改注册表默认打开
            RegisterFileType();
            this.ShowReportTreeForm();
            this.ShowTempletTreeForm();
        }

        private void RegisterFileType()
        {
            Register.FileTypeRegInfo fileRegInfo = new Register.FileTypeRegInfo();

            fileRegInfo.ExePath = Process.GetCurrentProcess().MainModule.FileName;
            fileRegInfo.ExtendName = ".hndt";
            fileRegInfo.IconPath = System.Windows.Forms.Application.StartupPath + @"\Resources\SysIcon.ico";
            Register.FileTypeRegister.RegisterFileType(fileRegInfo);
            fileRegInfo.ExtendName = ".hrdt";
            Register.FileTypeRegister.RegisterFileType(fileRegInfo);
        }

        private void OpenFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;
            if (filePath.ToUpper().EndsWith("HRDT"))
            {
                ReportHandler.Instance.OpenReport(filePath);
            }
            else if (filePath.ToUpper().EndsWith("HNDT"))
            {
                TempletHandler.Instance.OpenTemplet(filePath);
            }

        }

        /// <summary>
        /// 加载DockPanel界面布局配置文件
        /// </summary>
        private void LoadLayoutConfig()
        {

        }

        #endregion


        #region"属性"
        /// <summary>
        /// 获取当活动的可停靠窗口
        /// </summary>
        [Description("获取当活动的可停靠窗口")]
        internal IDockContent ActiveContent
        {
            get { return this.dockPanel1.ActiveContent; }
        }

        /// <summary>
        /// 获取当活动的文档窗口
        /// </summary>
        [Description("获取当活动的文档窗口")]
        internal IDockContent ActiveDocument
        {
            get { return this.dockPanel1.ActiveDocument; }
        }

        /// <summary>
        /// 获取所有可停靠窗口的列表
        /// </summary>
        [Description("获取所有可停靠窗口的列表")]
        internal DockContentCollection Contents
        {
            get { return this.dockPanel1.Contents; }
        }

        /// <summary>
        /// 获取所有文档窗口的列表
        /// </summary>
        [Description("获取所有文档窗口的列表")]
        internal IDockContent[] Documents
        {
            get { return this.dockPanel1.DocumentsToArray(); }
        }

        /// <summary>
        /// 获取当活动的设计器窗口
        /// </summary>
        [Description("获取当活动的设计器窗口")]
        internal IDesignEditForm ActiveDesign
        {
            get { return this.dockPanel1.ActiveDocument as IDesignEditForm; }
        }

        /// <summary>
        /// 获取当活动的脚本编辑窗口
        /// </summary>
        [Description("获取当活动的脚本编辑窗口")]
        internal IScriptEditForm ActiveScript
        {
            get { return this.dockPanel1.ActiveDocument as IScriptEditForm; }
        }
        #endregion

        #region"事件"
        /// <summary>
        /// 当活动的文档窗口改变活动状态时触发
        /// </summary>
        [Description("当活动的文档窗口改变活动状态时触发")]
        internal event EventHandler ActiveDocumentChanged;

        internal virtual void OnActiveDocumentChanged(EventArgs e)
        {
            if (this.ActiveDocumentChanged == null)
                return;
            try
            {
                this.ActiveDocumentChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.OnActiveDocumentChanged", ex);
            }
        }

        /// <summary>
        /// 当活动的停靠窗口改变活动状态时触发
        /// </summary>
        [Description("当活动的停靠窗口改变活动状态时触发")]
        internal event EventHandler ActiveContentChanged;

        internal virtual void OnActiveContentChanged(EventArgs e)
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

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {
            this.OnActiveDocumentChanged(e);
        }
        /// <summary>
        /// 打开表单或报表设计器窗口
        /// </summary>
        /// <param name="designEditForm">设计器窗口</param>
        internal void OpenDesignEditForm(IDesignEditForm designEditForm)
        {
            if (designEditForm == null || designEditForm.IsDisposed)
                return;
            this.dockPanel1.Update();
            IDockContent content = designEditForm as IDockContent;
            if (content != null)
                content.DockHandler.Show(this.dockPanel1);
        }
        /// <summary>
        /// 显示控件工具箱窗口
        /// </summary>
        internal void ShowToolboxListForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_ToolboxListForm == null || this.m_ToolboxListForm.IsDisposed)
                this.m_ToolboxListForm = new ToolboxListForm(this);
            this.m_ToolboxListForm.Show(this.dockPanel1);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        /// <summary>
        /// 显示对象属性编辑窗口
        /// </summary>
        internal void ShowPropertyEditForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_PropertyEditForm == null || this.m_PropertyEditForm.IsDisposed)
                this.m_PropertyEditForm = new PropertyEditForm(this);
            this.m_PropertyEditForm.Show(this.dockPanel1);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        public void ShowStatusMessage(string szMessage)
        {
            object result = null;

        }
        /// <summary>
        /// 显示脚本编译错误列表窗口
        /// </summary>
        internal void ShowCompileErrorForm(ErrorsListForm.CompileError[] errors)
        {
            if (this.m_ErrorsListForm != null && !this.m_ErrorsListForm.IsDisposed)
                this.m_ErrorsListForm.Close();
            if (errors == null || errors.Length <= 0)
                return;
            if (this.m_ErrorsListForm == null || this.m_ErrorsListForm.IsDisposed)
            {
                this.m_ErrorsListForm = new ErrorsListForm(this);
                this.m_ErrorsListForm.Show(this.dockPanel1, DockState.DockBottom);
            }
            this.m_ErrorsListForm.Activate();
            this.m_ErrorsListForm.CompileErrors = errors;
            this.m_ErrorsListForm.ScriptEditForm = this.ActiveScript;
            this.m_ErrorsListForm.OnRefreshView();
        }

        /// <summary>
        /// 打开表单或报表脚本编辑器窗口
        /// </summary>
        /// <param name="scriptEditForm">脚本编辑器窗口</param>
        internal void OpenScriptEditForm(IScriptEditForm scriptEditForm)
        {
            if (scriptEditForm == null || scriptEditForm.IsDisposed)
                return;
            this.dockPanel1.Update();
            IDockContent content = scriptEditForm as IDockContent;
            if (content != null)
                content.DockHandler.Show(this.dockPanel1);
        }
        /// <summary>
        /// 显示脚本文本查找替换窗口
        /// </summary>
        internal void ShowFindReplaceForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_FindReplaceForm == null || this.m_FindReplaceForm.IsDisposed)
                this.m_FindReplaceForm = new FindReplaceForm(this);
            this.m_FindReplaceForm.Show(this.dockPanel1);
            if (this.ActiveScript != null)
                this.m_FindReplaceForm.DefaultFindText = this.ActiveScript.GetSelectedText();
            this.m_FindReplaceForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        /// <summary>
        /// 显示脚本文本查找结果窗口
        /// </summary>
        /// <param name="scriptEditForm">脚本编辑器窗口</param>
        /// <param name="szFindText">查找文本</param>
        /// <param name="results">查找结果集</param>
        /// <param name="bshowFileName">设置是否显示文件名列</param>
        internal void ShowFindResultForm(IScriptEditForm scriptEditForm
            , string szFindText, List<FindResult> results, bool bshowFileName)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_FindResultForm == null || this.m_FindResultForm.IsDisposed)
                this.m_FindResultForm = new FindResultForm(this);
            this.m_FindResultForm.ScriptEditForm = scriptEditForm;
            this.m_FindResultForm.FindText = szFindText;
            this.m_FindResultForm.Results = results;

            this.m_FindResultForm.Show(this.dockPanel1);
            this.m_FindResultForm.ShowFileName = bshowFileName;
            this.m_FindResultForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        #endregion



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }



        private void 打开报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportHandler.Instance.OpenReport();
        }

        private void 新建报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportType reportTypeInfo = new ReportType();
            reportTypeInfo.ReportTypeName = "新建报表";
            ReportHandler.Instance.NewReport(reportTypeInfo);
        }

        private void 打开表单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Templet.TempletHandler.Instance.OpenTemplet();
        }

        private void 新建表单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempletType typeInfo = new TempletType();
            typeInfo.DocTypeName = "新建模板";
            TempletHandler.Instance.OpenTemplet(typeInfo);
        }

        /// <summary>
        /// 双击打开文档路径
        /// </summary>
        public string FilePath
        { get; set; }

        private void 报表列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReportTreeForm();
        }
        private ReportTreeForm m_ReportTreeForm;
        /// <summary>
        /// 显示报表模板管理窗口
        /// </summary>
        internal void ShowReportTreeForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_ReportTreeForm == null || this.m_ReportTreeForm.IsDisposed)
                this.m_ReportTreeForm = new ReportTreeForm(this);
            this.m_ReportTreeForm.Show(this.dockPanel1);
            this.m_ReportTreeForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        private TempletTreeForm m_TempletTreeForm;
        private void 表单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTempletTreeForm();
        }

        private void ShowTempletTreeForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_TempletTreeForm == null || this.m_TempletTreeForm.IsDisposed)
                this.m_TempletTreeForm = new TempletTreeForm(this);
            this.m_TempletTreeForm.Show(this.dockPanel1);
            this.m_TempletTreeForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}