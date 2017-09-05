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
using EMRDBLib;
using Heren.MedQC.ScriptEngine.FindReplace;
using EMRDBLib.DbAccess;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class ScriptEditForm : DockContentBase
    {
        public string FlagCode { get; set; }
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
        /// <summary>
        /// 脚本配置
        /// </summary>
        public ScriptConfig ScriptConfig { get; set; }
        private bool m_bIsModified = false;
        /// <summary>
        /// 获取或设置文档是否已经发生变化
        /// </summary>
        public bool IsModified
        {
            get { return this.m_bIsModified; }
            set { this.m_bIsModified = value;
                this.RefreshFormText();
            }
        }

        private string m_vbsFile = null;

        /// <summary>
        /// 获取当打开的是本地文件时,
        /// 设计器窗口当前关联的本地文件路径
        /// </summary>
        public string VbsFile
        {
            get { return this.m_vbsFile; }
        }
        public DebuggerForm MainForm { get; set; }
        public ScriptEditForm(DebuggerForm mainForm)
            : base(mainForm)
        {
            this.MainForm = mainForm;
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
        /// 保存当前窗口的数据修改
        /// </summary>
        /// <returns>bool</returns>
        public override bool CommitModify()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (!this.DebuggerForm.CompileWithOK())
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return false;
            }
            bool success = ScriptHandler.Instance.SaveTemplet();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            return success;
        }
        /// <summary>
        /// 刷新表单标题
        /// </summary>
        private void RefreshFormText()
        {
            string title = string.Empty;
            string subhead = string.Empty;
            if (this.ScriptConfig == null)
            {
                title = "新模板";
            }
            if (this.m_vbsFile != null)
            {
                title = GlobalMethods.IO.GetFileName(this.m_vbsFile, true);
            }
            if (this.ScriptConfig != null)
            {
                title = this.ScriptConfig.SCRIPT_NAME;
                subhead = "更新时间:"
                    + this.ScriptConfig.MODIFY_TIME.ToString("yyyy年M月d日 HH:mm");
            }
            if (!this.IsModified)
                this.Text = title + "(脚本)";
            else
                this.Text = title + "(脚本) *";
            this.TabSubhead = subhead;
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
            this.IsModified = true;
            //this.RefreshWindowTitle();
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

        ///// <summary>
        ///// 提交当前已被修改的脚本
        ///// </summary>
        ///// <returns>bool</returns>
        //public override bool CommitModify()
        //{
        //    return this.SaveScript();
        //}

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
                this.IsModified = false;
                //this.RefreshWindowTitle();
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
            this.m_vbsFile = szFullName;
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
                this.IsModified = false;
                //this.RefreshWindowTitle();
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

        /// <summary>
        /// 获取当前选中的文本
        /// </summary>
        /// <returns>选中的文本</returns>
        public string GetSelectedText()
        {
            return this.textEditorControl1.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;
        }

        /// <summary>
        /// 查找与指定的文本匹配的所有文本
        /// </summary>
        /// <param name="szFindText">文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public void FindText(string szFindText, bool bMatchCase)
        {
            List<FindResult> results = FindHandler.Instance.FindAll(this.textEditorControl1, szFindText, bMatchCase);
            if (this.MainForm != null && !this.MainForm.IsDisposed)
                this.MainForm.ShowFindResultForm(this, szFindText, results, false);
        }

        /// <summary>
        /// 在所有报表中查找指定的文本
        /// </summary>
        /// <param name="szFindText">文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        public void FindTextInAllTemplet(string szFindText, bool bMatchCase)
        {
            if (!bMatchCase)
                szFindText = szFindText.ToLower();
            List<ScriptConfig> lstScriptConfig = new List<ScriptConfig>();
            ScriptConfigAccess.Instance.GetScriptConfigs(ref lstScriptConfig);
            if (lstScriptConfig.Count <= 0)
                return;

            List<FindResult> Result = new List<FindResult>();
            int indextext = 0;//索引号
            int indexLine = 0;//行号
            int i = 0;//正在比对的字符序号
            int indexCol = 0;
            char chFindText = new char();
            string sztextFormat = string.Empty;
            char[] arrFindText = szFindText.Trim().ToCharArray();
            for (int index = 0; index < lstScriptConfig.Count; index++)
            {
                if (lstScriptConfig[index].IS_FOLDER==1)
                    continue;
                string szSource = string.Empty;
                ScriptConfigAccess.Instance.GetScriptSource(lstScriptConfig[index].SCRIPT_ID, ref szSource);
                if (string.IsNullOrEmpty(szSource))
                    continue;
                //string szScripData = parser.GetScriptData(lstScriptConfig[index].REPORT_DATA);
                string[] arrScripText = szSource.Split(new Char[] { '\n' }, StringSplitOptions.None);

                indexLine = 0; //行号清零
                indextext = 0; //索引号清零
                foreach (string sztext in arrScripText)
                {
                    if (string.IsNullOrEmpty(sztext))
                        continue;
                    if (!bMatchCase)
                        sztextFormat = sztext.ToLower();
                    else
                        sztextFormat = sztext;
                    char[] arrCtext = sztextFormat.ToCharArray();
                    i = 0;//正在比对的字符序号
                    for (indexCol = 0; indexCol < arrCtext.Length; indexCol++)
                    {
                        chFindText = arrCtext[indexCol];
                        indextext++;
                        if (i != 0 && chFindText != arrFindText[i])
                        { indexCol -= i - 1; indextext -= i - 1; i = 0; continue; }
                        if (chFindText != arrFindText[i])
                        { i = 0; continue; }
                        if (i == arrFindText.Length - 1)
                        {
                            Result.Add(new FindResult(indextext - szFindText.Trim().Length
                                , szFindText.Trim().Length
                                , indexLine
                                , sztext
                                , lstScriptConfig[index].SCRIPT_ID
                                , lstScriptConfig[index].SCRIPT_NAME
                                , SystemData.FileType.SCRIPT));
                            i = 0;
                            continue;
                        }
                        i++;
                    }
                    indextext++;//修正分行去掉'\n'产生的偏移量
                    indexLine++;
                }
            }

            if (this.MainForm != null && !this.MainForm.IsDisposed)
                this.MainForm.ShowFindResultForm(this, szFindText, Result, true);
        }

        /// <summary>
        /// 查找并替换指定的文本
        /// </summary>
        /// <param name="szFindText">查找文本</param>
        /// <param name="szReplaceText">替换文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <param name="bReplaceAll">是否替换所有</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public void ReplaceText(string szFindText, string szReplaceText, bool bMatchCase, bool bReplaceAll)
        {
            if (bReplaceAll)
                FindHandler.Instance.ReplaceAll(this.textEditorControl1, szFindText, szReplaceText, bMatchCase);
            else
                FindHandler.Instance.ReplaceNext(this.textEditorControl1, szFindText, szReplaceText, bMatchCase);
        }
        
        /// <summary>
        /// 将当前脚本编辑器窗口光标定位到指定的文本
        /// </summary>
        /// <param name="offset">索引位置</param>
        /// <param name="length">长度</param>
        public void LocateToText(int offset, int length)
        {
            this.Activate();
            this.textEditorControl1.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
            if (offset < 0 || length < 0
                || offset >= this.textEditorControl1.Document.TextLength
                || offset + length >= this.textEditorControl1.Document.TextLength)
                return;
            Point startPos = this.textEditorControl1.Document.OffsetToPosition(offset);
            Point endPos = this.textEditorControl1.Document.OffsetToPosition(offset + length);
            this.textEditorControl1.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(startPos, endPos);
            this.textEditorControl1.ActiveTextAreaControl.TextArea.Caret.Position = this.textEditorControl1.Document.OffsetToPosition(offset);
        }
        
        private void toolmnuFind_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowFindReplaceForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolmnuFindSelected_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindText(this.GetSelectedText(), false);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditorControl1.Undo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditorControl1.Redo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}