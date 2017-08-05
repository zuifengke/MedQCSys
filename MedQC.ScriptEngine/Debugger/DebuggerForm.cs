// ***********************************************************
// 电子病历系统脚本配置工具主程序窗口.
// Creator: YangMingkun  Date:2011-11-15
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.ScriptEngine.Script;
using EMRDBLib;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    public partial class DebuggerForm : HerenForm
    {
        private TempletListForm m_TempletListForm = null;
        private ErrorsListForm m_ErrorsListForm = null;
        public QcCheckPoint QcCheckPoint { get; set; }
        public PatVisitInfo PatVisitInfo { get; set; }
        public QcCheckResult QcCheckResult { get; set; }

        private string m_workingPath = null;
        /// <summary>
        /// 获取或设置调试器工作路径
        /// </summary>
        [Browsable(false)]
        public string WorkingPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_workingPath))
                    return GlobalMethods.Misc.GetWorkingPath();
                return this.m_workingPath;
            }
            set { this.m_workingPath = value; }
        }

        private ScriptProperty m_scriptProperty = null;
        /// <summary>
        /// 获取或设置当前打开的脚本
        /// </summary>
        [Browsable(false)]
        public ScriptProperty ScriptProperty
        {
            get { return this.m_scriptProperty; }
            set
            {
                this.m_scriptProperty = null;
                if (value == null)
                    return;
                this.m_scriptProperty = value.Clone() as ScriptProperty;
            }
        }

        /// <summary>
        /// 获取当前活动的脚本编辑窗口
        /// </summary>
        [Browsable(false)]
        internal ScriptEditForm ActiveScriptForm
        {
            get
            {
                IDockContent content = this.dockPanel1.ActiveDocument;
                ScriptEditForm scriptEditForm = content as ScriptEditForm;
                if (scriptEditForm == null || scriptEditForm.IsDisposed)
                    return null;
                return scriptEditForm;
            }
        }

        #region"系统初始化"
        public DebuggerForm()
        {
            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.RestoreWindowState();
            this.Icon = Heren.MedQC.ScriptEngine.Properties.Resources.SysIcon;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.ShowScriptSamplesForm();

            //设置为自动保存窗口状态
            this.SaveWindowState = true;

            //为空，则表示启动本程序EXE
            if (this.m_scriptProperty == null)
            {
                this.toolbtnNew.Visible = true;
                this.toolbtnOK.Visible = false;
            }
            //否则，表示改程序被别的程序调用，直接打开参数中的代码
            else
            {
                this.toolbtnNew.Visible = false;
                this.OpenScript(this.m_scriptProperty);
                if (this.ActiveScriptForm != null)
                    this.ActiveScriptForm.CloseButtonVisible = false;
            }
            this.ShowStatusMessage("就绪!");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //如果SaveWindowState值为false,说明未登录
            if (!this.SaveWindowState)
                return;

            //检查并提示是否需要保存
            int index = 0;
            DockContentBase content = null;
            while (index < this.dockPanel1.Contents.Count)
            {
                content = this.dockPanel1.Contents[index] as DockContentBase;
                index++;
                if (content == null || content.IsDisposed)
                    continue;
                e.Cancel = !content.CheckModifiedData();
                if (e.Cancel) return;
            }
        }
        #endregion

        #region "工具条事件"
        private void toolbtnNew_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.CreateNewScript();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "请选择脚本文件";
            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append("脚本文件(*.vbs)|*.vbs|");
            sbFilter.Append("文本文件(*.txt)|*.txt|");
            sbFilter.Append("所有文件(*.*)|*.*");
            openDialog.Filter = sbFilter.ToString();
            openDialog.Multiselect = false;
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.OpenScript(openDialog.FileName);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnSaveAs_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.SaveScript();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnComment_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ScriptEditForm scriptEditForm = this.ActiveScriptForm;
            if (scriptEditForm != null)
                scriptEditForm.Comment();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnUncomment_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ScriptEditForm scriptEditForm = this.ActiveScriptForm;
            if (scriptEditForm != null)
                scriptEditForm.Comment();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnTest_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            //this.ShowScriptTestForm();
            this.TestScript();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        private void TestScript()
        {
            if (this.PatVisitInfo == null)
            {
                MessageBoxEx.ShowMessage("请先选择患者");
                return;
            }
            if (this.QcCheckPoint == null)
            {
                MessageBoxEx.ShowMessage("缺陷规则未初始化");
                return;
            }

        }
        private void toolbtnOK_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (!this.CompileWithOK())
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            this.DialogResult = DialogResult.OK;
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnExamples_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowScriptSamplesForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnHelp_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            //打开用户手册(Word文档)
            string helpFile = string.Format("{0}\\Script\\元素互动计算VB脚本开发手册.doc", this.WorkingPath);
            try
            {
                if (System.IO.File.Exists(helpFile))
                    System.Diagnostics.Process.Start(helpFile);
                else
                    MessageBoxEx.Show("未找到帮助文档文件!");
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("无法打开帮助文档文件!", ex.Message);
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "显示子窗口"
        /// <summary>
        /// 显示脚本样例窗口
        /// </summary>
        private void ShowScriptSamplesForm()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_TempletListForm != null && !this.m_TempletListForm.IsDisposed)
            {
                this.m_TempletListForm.Activate();
            }
            else
            {
                this.m_TempletListForm = new TempletListForm(this);
                this.m_TempletListForm.Show(this.dockPanel1);
            }
            this.m_TempletListForm.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 显示编译错误列表
        /// </summary>
        internal void ShowCompileErrorForm(CompileErrorCollection errors)
        {
            if (errors == null || errors.Count <= 0)
                return;
            ScriptEditForm activeScriptForm = this.ActiveScriptForm;
            if (activeScriptForm == null || activeScriptForm.IsDisposed)
                return;
            if (this.m_ErrorsListForm == null || this.m_ErrorsListForm.IsDisposed)
            {
                this.m_ErrorsListForm = new ErrorsListForm(this);
                this.m_ErrorsListForm.Show(this.dockPanel1, DockState.DockBottom);
            }
            this.m_ErrorsListForm.Activate();
            this.m_ErrorsListForm.CompileErrors = errors;
            this.m_ErrorsListForm.ScriptEditForm = activeScriptForm;
            this.m_ErrorsListForm.OnRefreshView();
        }

        /// <summary>
        /// 显示脚本测试窗口
        /// </summary>
        internal void ShowScriptTestForm()
        {
            if (this.m_ErrorsListForm != null && !this.m_ErrorsListForm.IsDisposed)
                this.m_ErrorsListForm.Close();
            ScriptEditForm activeScriptForm = this.ActiveScriptForm;
            if (activeScriptForm == null || activeScriptForm.IsDisposed)
                return;
            ScriptProperty scriptProperty = activeScriptForm.ScriptProperty;
            if (scriptProperty == null)
                scriptProperty = new ScriptProperty();

            ScriptCompiler.Instance.WorkingPath = this.WorkingPath;
            CompileResults results = ScriptCompiler.Instance.CompileScript(scriptProperty);
            if (results.HasErrors)
            {
                this.ShowCompileErrorForm(results.Errors);
                MessageBoxEx.Show("编译失败，无法启动测试程序！");
                return;
            }
            ScriptTestForm scriptTestForm = new ScriptTestForm();
            scriptTestForm.ShowDialog(scriptProperty.ScriptName, scriptProperty.ScriptText);
        }
        #endregion

        public void ShowStatusMessage(string szMessage)
        {
            this.tsslblSystemStatus.Text = szMessage;
        }

        /// <summary>
        /// 获取指定路径的脚本编辑窗口对象
        /// </summary>
        /// <param name="szFileName">指定路径</param>
        /// <returns>ScriptEditForm</returns>
        private ScriptEditForm GetScriptEditForm(string szFileName)
        {
            IDockContent[] documents = this.dockPanel1.DocumentsToArray();
            for (int index = 0; index < documents.Length; index++)
            {
                ScriptEditForm scriptForm = documents[index] as ScriptEditForm;
                if (scriptForm == null || scriptForm.IsDisposed)
                    continue;
                if (scriptForm.ScriptProperty == null)
                    continue;
                string szFilePath = scriptForm.ScriptProperty.FilePath;
                if (string.Compare(szFilePath, szFileName, true) == 0)
                    return scriptForm;
            }
            return null;
        }

        /// <summary>
        /// 创建一个新的脚本编辑窗口
        /// </summary>
        internal void CreateNewScript()
        {
            ScriptNewForm frmNewScript = new ScriptNewForm();
            if (frmNewScript.ShowDialog() != DialogResult.OK)
                return;
            ScriptEditForm scriptEditForm = new ScriptEditForm(this);
            scriptEditForm.Show(this.dockPanel1, DockState.Document);
            this.dockPanel1.Update();

            string szScriptFile = frmNewScript.FileName;
            string szScriptText = null;
            if (!GlobalMethods.IO.GetFileText(szScriptFile, ref szScriptText))
                return;

            ScriptProperty scriptProperty = new ScriptProperty();
            scriptProperty.ScriptName = frmNewScript.ScriptTitle;
            scriptEditForm.ScriptProperty = scriptProperty;
            if (!scriptEditForm.OpenScriptText(szScriptText))
                MessageBoxEx.ShowError("脚本创建失败!");
        }

        /// <summary>
        /// 打开本地文件
        /// </summary>
        /// <param name="szFullName">文件路径</param>
        internal void OpenScript(string szFullName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szFullName))
                return;
            ScriptProperty scriptProperty = new ScriptProperty();
            string szScriptText = null;
            GlobalMethods.IO.GetFileText(szFullName, ref szScriptText);
            scriptProperty.ScriptText = szScriptText;
            scriptProperty.FilePath = szFullName;
            scriptProperty.ScriptName = GlobalMethods.IO.GetFileName(szFullName, true);
            this.OpenScript(scriptProperty);
        }

        /// <summary>
        /// 打开指定脚本配置信息的脚本
        /// </summary>
        /// <param name="scriptProperty">脚本配置信息</param>
        internal void OpenScript(ScriptProperty scriptProperty)
        {
            if (scriptProperty == null)
                return;
            string szScriptFile = scriptProperty.FilePath;
            ScriptEditForm scriptEditForm = this.GetScriptEditForm(szScriptFile);
            if (scriptEditForm != null)
            {
                scriptEditForm.Activate();
                scriptEditForm.OnRefreshView();
                return;
            }
            if (scriptEditForm == null || scriptEditForm.IsDisposed)
            {
                scriptEditForm = new ScriptEditForm(this);
                scriptEditForm.Show(this.dockPanel1, DockState.Document);
            }
            scriptEditForm.ScriptProperty = scriptProperty;
            this.dockPanel1.Update();
            if (!scriptEditForm.OpenScriptText(scriptProperty.ScriptText))
                MessageBoxEx.Show("文件打开失败！", MessageBoxIcon.Error);
        }

        /// <summary>
        /// 另存脚本到本地
        /// </summary>
        private void SaveScript()
        {
            ScriptEditForm activeScriptForm = this.ActiveScriptForm;
            if (activeScriptForm != null && !activeScriptForm.IsDisposed)
                activeScriptForm.SaveScript();
        }

        /// <summary>
        /// 单击确定按钮，生成二进制DLL
        /// </summary>
        /// <returns>是否编译成功</returns>
        private bool CompileWithOK()
        {
            if (this.m_scriptProperty == null)
                this.m_scriptProperty = new ScriptProperty();
            ScriptEditForm activeScriptForm = this.GetScriptEditForm(this.m_scriptProperty.FilePath);
            if (activeScriptForm == null)
                return false;
            activeScriptForm.Activate();
            if (!activeScriptForm.Compile())
            {
                MessageBoxEx.Show("编译失败，请查看错误列表！");
                return false;
            }
            activeScriptForm.IsModified = false;
            this.m_scriptProperty = activeScriptForm.ScriptProperty;
            return true;
        }
    }
}