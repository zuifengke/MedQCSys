// ***********************************************************
// 护理病历配置管理系统,报表模板脚本编辑窗口.
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.TextEditor;
using Heren.Common.TextEditor.Actions;
using Heren.Common.TextEditor.Document;
using Heren.Common.Report.Loader;
using Designers.FindReplace;
using EMRDBLib;
using Designers;

namespace Designers.Report
{
    internal partial class ScriptEditForm : DockContentBase, IScriptEditForm
    {
        private ReportType m_reportTemplet = null;

        /// <summary>
        /// 获取当打开的是服务器文件时,
        /// 设计器窗口当前关联的服务器文件信息
        /// </summary>
        public ReportType ReportTemplet
        {
            get { return this.m_reportTemplet; }
        }

        private string m_hndfFile = null;

        /// <summary>
        /// 获取当打开的是本地文件时,
        /// 设计器窗口当前关联的本地文件路径
        /// </summary>
        public string HndfFile
        {
            get { return this.m_hndfFile; }
        }

        private string m_flagCode = null;

        /// <summary>
        /// 获取或设置当前窗口的唯一标识,
        /// 仅用于查找到对应的脚本编辑窗口
        /// </summary>
        public string FlagCode
        {
            get { return this.m_flagCode; }
            set { this.m_flagCode = value; }
        }

        private bool m_bIsModified = false;

        /// <summary>
        /// 标识当前脚本是否已经被修改过
        /// </summary>
        public bool IsModified
        {
            get
            {
                return this.m_bIsModified;
            }

            set
            {
                this.m_bIsModified = value;
                this.RefreshFormText();
            }
        }

        public ScriptEditForm(DesignForm mainForm)
            : base(mainForm)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.textEditor1.ShowEOLMarkers = false;
            this.textEditor1.ShowTabs = false;
            this.textEditor1.ShowSpaces = false;
            this.textEditor1.ShowMatchingBracket = true;
            this.textEditor1.EnableFolding = true;
            this.textEditor1.ShowInvalidLines = false;
            this.textEditor1.SetHighlighting("VBNET");
            this.textEditor1.IndentStyle = IndentStyle.Auto;
            this.textEditor1.Font = new Font("宋体", 9f, FontStyle.Regular);
            this.textEditor1.ContextMenuStrip = this.cmenuScript;
            this.textEditor1.Document.DocumentChanged +=
                new DocumentEventHandler(this.TextEditor_DocumentChanged);
        }

        /// <summary>
        /// 检查是否有未保存的数据
        /// </summary>
        /// <returns>bool</returns>
        public override bool HasUncommit()
        {
            return this.IsModified;
        }

        /// <summary>
        /// 保存当前窗口的数据修改
        /// </summary>
        /// <returns>bool</returns>
        public override bool CommitModify()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            bool success = ReportHandler.Instance.SaveReport();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            return success;
        }

        private void TextEditor_DocumentChanged(object sender, DocumentEventArgs e)
        {
            this.IsModified = true;
        }

        #region"工具栏"
        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ReportHandler.Instance.SaveReport();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnUndo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.Undo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnRedo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.Redo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnCut_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnCopy_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnPaste_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnFindReplace_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowFindReplaceForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnComment_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Comment();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnDebug_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ReportHandler.Instance.ShowScriptTestForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        #endregion

        #region"右键菜单"
        private void mnuUIDesign_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ReportHandler.Instance.OpenDesignEditForm(this);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
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
            this.textEditor1.Undo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.Redo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.textEditor1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(null, null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        #endregion

        /// <summary>
        /// 刷新表单标题
        /// </summary>
        private void RefreshFormText()
        {
            string title = string.Empty;
            string subhead = string.Empty;
            if (this.m_reportTemplet == null)
            {
                title = "新模板";
            }
            if (this.m_hndfFile != null)
            {
                title = GlobalMethods.IO.GetFileName(this.m_hndfFile, true);
            }
            if (this.m_reportTemplet != null)
            {
                title = this.m_reportTemplet.ReportTypeName;
                subhead = "更新时间:"
                    + this.m_reportTemplet.ModifyTime.ToString("yyyy年M月d日 HH:mm");
            }
            if (!this.IsModified)
                this.Text = title + "(脚本)";
            else
                this.Text = title + "(脚本) *";
            this.TabSubhead = subhead;
        }

        /// <summary>
        /// 打开指定的报表模板对应的脚本
        /// </summary>
        /// <param name="reportTemplet">报表模板信息</param>
        /// <returns>是否成功</returns>
        public bool Open(ReportType reportTemplet)
        {
            return this.Open(reportTemplet, null);
        }

        /// <summary>
        /// 打开指定的报表模板文件对应的脚本
        /// </summary>
        /// <param name="szHndfFile">报表模板文件</param>
        /// <returns>是否成功</returns>
        public bool Open(string szHndfFile)
        {
            return this.Open(null, szHndfFile);
        }

        /// <summary>
        /// 打开指定的报表模板或者报表模板文件对应的脚本
        /// </summary>
        /// <param name="reportTemplet">报表模板信息</param>
        /// <param name="szHndfFile">报表模板文件</param>
        /// <returns>是否成功</returns>
        public bool Open(ReportType reportTemplet, string szHndfFile)
        {
            this.IsModified = false;
            this.m_hndfFile = szHndfFile;
            this.m_reportTemplet = reportTemplet;
            this.RefreshFormText();

            ReportFileParser parser = new ReportFileParser();
            this.textEditor1.Text = parser.GetScriptData(szHndfFile);

            if (GlobalMethods.Misc.IsEmptyString(this.textEditor1.Text))
            {
                string szDefaultHndfFile = string.Format("{0}\\Templet\\Default.hrdt"
                    , GlobalMethods.Misc.GetWorkingPath());
                this.textEditor1.Text = parser.GetScriptData(szDefaultHndfFile);
            }
            this.IsModified = false;
            return true;
        }

        /// <summary>
        /// 将当前脚本保存为文本并返回
        /// </summary>
        /// <returns>脚本文本</returns>
        public string Save()
        {
            try
            {
                return this.textEditor1.Text;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptEditForm.Save", ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// 将当前脚本文本保存到指定的文本文件中
        /// </summary>
        /// <param name="fileName">文本文件</param>
        /// <returns>是否成功</returns>
        public bool Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;
            try
            {
                this.textEditor1.SaveFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptEditForm.Save"
                    , new string[] { "fileName" }, new object[] { fileName }, ex);
                return false;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                //GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

                //string szReportTypeID = m_reportTemplet.ReportTypeID;
                //if (string.IsNullOrEmpty(szReportTypeID))
                //    return true;
                ////重新查询获取文档类型信息
                //ReportTypeInfo reportTypeInfo = null;
                //short shRet = TempletService.Instance.GetReportTypeInfo(szReportTypeID, ref reportTypeInfo);
                //// 如果本地与服务器的版本相同,则无需重新加载
                //DateTime dtModifyTime = ReportCache.Instance.GetReportModifyTime(szReportTypeID);
                //if (dtModifyTime.CompareTo(reportTypeInfo.ModifyTime) == 0)
                //{
                //    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                //    return true;
                //}
                //byte[] byteTempletData = null;
                //bool result = ReportCache.Instance.GetReportTemplet(reportTypeInfo, ref byteTempletData);
                //if (!result)
                //{
                //    MessageBoxEx.Show("刷新失败");
                //    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                //    return true;
                //}
                //GlobalMethods.UI.SetCursor(this, Cursors.Default);
                //return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 将当前选中的脚本注释掉
        /// </summary>
        public void Comment()
        {
            ToggleComment toggle = new ToggleComment();
            toggle.Execute(this.textEditor1.ActiveTextAreaControl.TextArea);
        }

        /// <summary>
        /// 获取当前选中的文本
        /// </summary>
        /// <returns>选中的文本</returns>
        public string GetSelectedText()
        {
            return this.textEditor1.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;
        }

        /// <summary>
        /// 查找与指定的文本匹配的所有文本
        /// </summary>
        /// <param name="szFindText">文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public void FindText(string szFindText, bool bMatchCase)
        {
            List<FindResult> results = FindHandler.Instance.FindAll(this.textEditor1, szFindText, bMatchCase);
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
            //if (!bMatchCase)
            //    szFindText = szFindText.ToLower();
            //List<ReportTypeData> lstReportTypeData = new List<ReportTypeData>();
            //TempletService.Instance.GetReportTemplet(ref lstReportTypeData);
            //if (lstReportTypeData.Count <= 0)
            //    return;

            //List<FindResult> Result = new List<FindResult>();
            //int indextext = 0;//索引号
            //int indexLine = 0;//行号
            //int i = 0;//正在比对的字符序号
            //int indexCol = 0;
            //char chFindText = new char();
            //string sztextFormat = string.Empty;
            //char[] arrFindText = szFindText.Trim().ToCharArray();
            //ReportFileParser parser = new ReportFileParser();
            //for (int index = 0; index < lstReportTypeData.Count; index++)
            //{
            //    if (lstReportTypeData[index].IsFolder)
            //        continue;
            //    if (lstReportTypeData[index].ByteTempletData == null)
            //        continue;

            //    parser = new ReportFileParser();
            //    string szScripData = parser.GetScriptData(lstReportTypeData[index].ByteTempletData);
            //    string[] arrScripText = szScripData.Split(new Char[] { '\n' }, StringSplitOptions.None);

            //    indexLine = 0; //行号清零
            //    indextext = 0; //索引号清零
            //    foreach (string sztext in arrScripText)
            //    {
            //        if (string.IsNullOrEmpty(sztext))
            //            continue;
            //        if (!bMatchCase)
            //            sztextFormat = sztext.ToLower();
            //        else
            //            sztextFormat = sztext;
            //        char[] arrCtext = sztextFormat.ToCharArray();
            //        i = 0;//正在比对的字符序号
            //        for (indexCol = 0; indexCol < arrCtext.Length; indexCol++)
            //        {
            //            chFindText = arrCtext[indexCol];
            //            indextext++;
            //            if (i != 0 && chFindText != arrFindText[i])
            //            { indexCol -= i - 1; indextext -= i - 1; i = 0; continue; }
            //            if (chFindText != arrFindText[i])
            //            { i = 0; continue; }
            //            if (i == arrFindText.Length - 1)
            //            {
            //                Result.Add(new FindResult(indextext - szFindText.Trim().Length
            //                    , szFindText.Trim().Length
            //                    , indexLine
            //                    , sztext
            //                    , lstReportTypeData[index].ReportTypeID
            //                    , lstReportTypeData[index].ReportTypeName
            //                    , ServerData.FileType.REPORT));
            //                i = 0;
            //                continue;
            //            }
            //            i++;
            //        }
            //        indextext++;//修正分行去掉'\n'产生的偏移量
            //        indexLine++;
            //    }
            //}

            //if (this.MainForm != null && !this.MainForm.IsDisposed)
            //    this.MainForm.ShowFindResultForm(this, szFindText, Result, true);
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
                FindHandler.Instance.ReplaceAll(this.textEditor1, szFindText, szReplaceText, bMatchCase);
            else
                FindHandler.Instance.ReplaceNext(this.textEditor1, szFindText, szReplaceText, bMatchCase);
        }

        /// <summary>
        /// 将当前脚本编辑器窗口光标定位到指定行列
        /// </summary>
        /// <param name="nLine">行号</param>
        /// <param name="nColumn">列号</param>
        public void LocateTo(int nLine, int nColumn)
        {
            this.Activate();
            this.textEditor1.ActiveTextAreaControl.JumpTo(nLine - 1, nColumn);
        }

        /// <summary>
        /// 将当前脚本编辑器窗口光标定位到指定的文本
        /// </summary>
        /// <param name="offset">索引位置</param>
        /// <param name="length">长度</param>
        public void LocateToText(int offset, int length)
        {
            this.Activate();
            this.textEditor1.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
            if (offset < 0 || length < 0
                || offset >= this.textEditor1.Document.TextLength
                || offset + length >= this.textEditor1.Document.TextLength)
                return;
            Point startPos = this.textEditor1.Document.OffsetToPosition(offset);
            Point endPos = this.textEditor1.Document.OffsetToPosition(offset + length);
            this.textEditor1.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(startPos, endPos);
            this.textEditor1.ActiveTextAreaControl.TextArea.Caret.Position = this.textEditor1.Document.OffsetToPosition(offset);
        }
    }
}
