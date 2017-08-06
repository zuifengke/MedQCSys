// ***********************************************************
// 电子病历系统关联元素自动计算脚本编辑窗口.
// Creator: YangMingkun  Date:2011-11-10
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.TextEditor;
using Heren.Common.TextEditor.Actions;
using Heren.Common.TextEditor.Document;
using Heren.Common.Libraries;
using Heren.MedQC.ScriptEngine.Script;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class ScriptEditForm : DockContentBase
    {
        private ScriptProperty m_scriptProperty = null;
        /// <summary>
        /// 获取或设置当前打开的脚本源码
        /// </summary>
        public ScriptProperty ScriptProperty
        {
            get
            {
                this.RefreshScriptProperty();
                return this.m_scriptProperty;
            }
            set { this.m_scriptProperty = value; }
        }

        private bool m_bIsModified = false;
        /// <summary>
        /// 获取或设置文档是否已经发生变化
        /// </summary>
        public bool IsModified
        {
            get { return this.m_bIsModified; }
            set { this.m_bIsModified = value; }
        }

        public ScriptEditForm(DebuggerForm mainForm)
            : base(mainForm)
        {
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.m_scriptProperty = new ScriptProperty();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            this.textEditorControl1.ShowEOLMarkers = false;
            this.textEditorControl1.ShowTabs = false;
            this.textEditorControl1.ShowSpaces = false;
            this.textEditorControl1.ShowMatchingBracket = true;
            this.textEditorControl1.EnableFolding = true;
            this.textEditorControl1.ShowInvalidLines = false;
            this.textEditorControl1.SetHighlighting("VBNET");
            this.textEditorControl1.IndentStyle = IndentStyle.Auto;
            this.textEditorControl1.Font = new Font("宋体", 9f, FontStyle.Regular);
            this.textEditorControl1.Document.DocumentChanged +=
                new DocumentEventHandler(this.TextEditor_DocumentChanged);
        }

        /// <summary>
        /// 刷新窗口标题
        /// </summary>
        private void RefreshWindowTitle()
        {
            if (this.m_scriptProperty == null)
                return;
            this.Text = this.m_scriptProperty.ScriptName;
            if (this.m_bIsModified)
                this.Text += " *";
            this.TabSubhead = "编号："
                + GlobalMethods.IO.GetFileName(this.m_scriptProperty.FilePath, false);
        }

        private void TextEditor_DocumentChanged(object sender, DocumentEventArgs e)
        {
            this.m_bIsModified = true;
            this.RefreshWindowTitle();
        }

        /// <summary>
        /// 刷新脚本属性信息对象
        /// </summary>
        private void RefreshScriptProperty()
        {
            if (this.m_scriptProperty == null)
                this.m_scriptProperty = new ScriptProperty();
            this.m_scriptProperty.ScriptText = this.textEditorControl1.Text;
        }

        /// <summary>
        /// 检查当前窗口的数据是否有修改
        /// </summary>
        /// <returns>bool</returns>
        public override bool HasUncommit()
        {
            if (this.textEditorControl1 == null || this.textEditorControl1.IsDisposed)
                return false;
            return this.m_bIsModified;
        }

        /// <summary>
        /// 提交当前已被修改的脚本
        /// </summary>
        /// <returns>bool</returns>
        public override bool CommitModify()
        {
            return this.SaveScript();
        }

        /// <summary>
        /// 清空脚本代码文本
        /// </summary>
        public void Clear()
        {
            TextArea textArea = null;
            try
            {
                textArea = this.textEditorControl1.ActiveTextAreaControl.TextArea;
                textArea.Document.TextContent = string.Empty;
                textArea.Invalidate();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptEditForm.Clear", ex);
            }
        }

        /// <summary>
        /// 打开指定脚本内容
        /// </summary>
        /// <param name="source">脚本内容</param>
        /// <returns>bool</returns>
        public bool OpenScriptText(string source)
        {
            this.Clear();
            if (this.m_scriptProperty == null)
                this.m_scriptProperty = new ScriptProperty();
            this.m_scriptProperty.ScriptText = source;

            try
            {
                TextArea textArea =
                    this.textEditorControl1.ActiveTextAreaControl.TextArea;
                textArea.Document.TextContent = source;
                textArea.Invalidate();
                this.m_bIsModified = false;
                this.RefreshWindowTitle();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptEditForm.OpenDoument", ex);
                return false;
            }
        }

        /// <summary>
        /// 打开指定路径的文件
        /// </summary>
        /// <param name="szFullName">文件路径</param>
        /// <returns>bool</returns>
        public bool OpenScriptFile(string szFullName)
        {
            this.Clear();
            if (this.m_scriptProperty == null)
                this.m_scriptProperty = new ScriptProperty();
            this.m_scriptProperty.FilePath = szFullName;

            if (GlobalMethods.Misc.IsEmptyString(szFullName))
                return true;
            string szSource = null;
            if (!GlobalMethods.IO.GetFileText(szFullName, ref szSource))
                return false;
            return this.OpenScriptText(szSource);
        }

        /// <summary>
        /// 保存当前脚本
        /// </summary>
        /// <returns>bool</returns>
        public bool SaveScript()
        {
            if (this.m_scriptProperty == null)
                return false;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "请选择保存路径";
            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append("脚本文件(*.vbs)|*.vbs|");
            sbFilter.Append("文本文件(*.txt)|*.txt|");
            sbFilter.Append("所有文件(*.*)|*.*");
            saveDialog.Filter = sbFilter.ToString();
            saveDialog.FileName = this.m_scriptProperty.ScriptName;
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return false;
            return this.SaveScript(saveDialog.FileName);
        }

        /// <summary>
        /// 保存当前脚本
        /// </summary>
        /// <returns>bool</returns>
        public bool SaveScript(string szFileName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szFileName))
                return false;
            try
            {
                this.textEditorControl1.SaveFile(szFileName);
                this.m_bIsModified = false;
                this.RefreshWindowTitle();
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("脚本另存失败！\r\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 编译当前脚本
        /// </summary>
        /// <returns>bool</returns>
        public bool Compile()
        {
            if (this.DebuggerForm == null || this.DebuggerForm.IsDisposed)
                return false;

            if (this.m_scriptProperty == null)
                this.m_scriptProperty = new ScriptProperty();
            ScriptProperty scriptProperty =
                this.m_scriptProperty.Clone() as ScriptProperty;
            scriptProperty.ScriptText = this.textEditorControl1.Text;

            ScriptCompiler.Instance.WorkingPath = this.DebuggerForm.WorkingPath;
            CompileResults results = ScriptCompiler.Instance.CompileScript(scriptProperty);
            if (results.HasErrors)
            {
                this.DebuggerForm.ShowCompileErrorForm(results.Errors);
                return false;
            }
            this.m_scriptProperty = scriptProperty;
            return !results.HasErrors;
        }

        public void SetAsReadonly()
        {
            try
            {
                this.textEditorControl1.ActiveTextAreaControl.Document.ReadOnly = true;
            }
            catch { }
        }

        public bool Comment()
        {
            TextArea textArea = null;
            ToggleComment toggle = null;
            try
            {
                textArea = this.textEditorControl1.ActiveTextAreaControl.TextArea;
                toggle = new ToggleComment();
                toggle.Execute(textArea);
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptEditForm.Comment", ex);
                return false;
            }
        }

        public bool Uncomment()
        {
            return this.Comment();
        }

        public bool FormatScript()
        {
            TextArea textArea = null;
            FormatBuffer formatBuffer = null;
            try
            {
                textArea = this.textEditorControl1.ActiveTextAreaControl.TextArea;
                formatBuffer = new FormatBuffer();
                formatBuffer.Execute(textArea);
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptEditForm.FormatScript", ex);
                return false;
            }
        }

        public void LocateTo(int nLine, int nColumn)
        {
            try
            {
                this.Activate();
                this.textEditorControl1.ActiveTextAreaControl.JumpTo(nLine - 1, nColumn);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptEditForm.LocateTo", ex);
            }
        }
    }
}