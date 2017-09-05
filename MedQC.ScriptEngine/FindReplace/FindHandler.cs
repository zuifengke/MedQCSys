// ***********************************************************
// 护理病历配置管理系统,脚本编辑器脚本文本查找处理器
// Author : YangMingkun, Date : 2013-5-4
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using Heren.Common.TextEditor;
using Heren.Common.TextEditor.Document;

namespace Heren.MedQC.ScriptEngine.FindReplace
{
    internal class FindHandler
    {
        private static FindHandler m_instance = null;

        /// <summary>
        /// 获取当前查找处理器实例
        /// </summary>
        public static FindHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new FindHandler();
                return m_instance;
            }
        }

        private FindHandler()
        {
        }

        /// <summary>
        /// 在指定的TextEditor编辑器内查找指定的文本,并返回索引和长度
        /// </summary>
        /// <param name="editor">TextEditor编辑器</param>
        /// <param name="szFindText">指定的文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <returns>FindResult对象</returns>
        /// <remarks>本函数不会移动光标,也不会自动选中找到的文本</remarks>
        private FindResult FindNextPrivate(TextEditorControl editor, string szFindText, bool bMatchCase)
        {
            if (editor == null || editor.IsDisposed || string.IsNullOrEmpty(szFindText))
                return null;

            if (!bMatchCase)
                szFindText = szFindText.ToLower();
            int nFindLength = szFindText.Length;

            IDocument document = editor.ActiveTextAreaControl.Document;
            int nDocumentLength = document.TextLength;
            int offset = editor.ActiveTextAreaControl.Caret.Offset;
            while (offset < nDocumentLength)
            {
                bool match = true;
                int index = 0;
                for (; index < nFindLength; index++)
                {
                    if (offset + index >= nDocumentLength)
                        return null;
                    char ch = document.GetCharAt(offset + index);
                    if (szFindText[index] != (bMatchCase ? ch : Char.ToLower(ch)))
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    int line = editor.Document.GetLineNumberForOffset(offset);
                    LineSegment segment = editor.Document.GetLineSegment(line);
                    string text = editor.Document.GetText(segment);
                    return new FindResult(offset, nFindLength, line, text);
                }
                offset += index + 1;
            }
            return null;
        }

        /// <summary>
        /// 在指定的TextEditor编辑器内查找指定的文本,并返回索引和长度
        /// </summary>
        /// <param name="editor">TextEditor编辑器</param>
        /// <param name="szFindText">指定的文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <returns>FindResult对象</returns>
        /// <remarks>本函数会移动光标,也会自动选中找到的文本</remarks>
        public FindResult FindNext(TextEditorControl editor, string szFindText, bool bMatchCase)
        {
            if (editor == null || editor.IsDisposed || string.IsNullOrEmpty(szFindText))
                return null;
            editor.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
            FindResult result = this.FindNextPrivate(editor, szFindText, bMatchCase);
            if (result == null)
                return result;
            Point startPos = editor.Document.OffsetToPosition(result.Offset);
            Point endPos = editor.Document.OffsetToPosition(result.Offset + result.Length);
            editor.ActiveTextAreaControl.SelectionManager.SetSelection(startPos, endPos);
            editor.ActiveTextAreaControl.TextArea.Caret.Position = editor.Document.OffsetToPosition(result.Offset);
            return result;
        }

        /// <summary>
        /// 在指定的TextEditor编辑器内查找与指定的文本匹配的所有文本
        /// </summary>
        /// <param name="editor">TextEditor编辑器</param>
        /// <param name="szFindText">文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <returns>FindResult对象列表</returns>
        public List<FindResult> FindAll(TextEditorControl editor, string szFindText, bool bMatchCase)
        {
            List<FindResult> results = new List<FindResult>();
            if (editor == null || editor.IsDisposed || string.IsNullOrEmpty(szFindText))
                return results;

            int nVScrollBarValue = editor.ActiveTextAreaControl.VScrollBar.Value;
            int nHScrollBarValue = editor.ActiveTextAreaControl.HScrollBar.Value;

            IDocument document = editor.ActiveTextAreaControl.Document;
            editor.ActiveTextAreaControl.TextArea.Caret.Position = document.OffsetToPosition(0);

            FindResult result = this.FindNextPrivate(editor, szFindText, bMatchCase);
            while (result != null)
            {
                results.Add(result);
                editor.ActiveTextAreaControl.TextArea.Caret.Position = document.OffsetToPosition(result.Offset + result.Length);
                result = this.FindNextPrivate(editor, szFindText, bMatchCase);
            }

            editor.ActiveTextAreaControl.VScrollBar.Value = nVScrollBarValue;
            editor.ActiveTextAreaControl.HScrollBar.Value = nHScrollBarValue;
            return results;
        }

        /// <summary>
        /// 在指定的TextEditor编辑器内查找并替换下一处找到的文本
        /// </summary>
        /// <param name="editor">TextEditor编辑器</param>
        /// <param name="szFindText">查找文本</param>
        /// <param name="szReplaceText">替换文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        public void ReplaceNext(TextEditorControl editor, string szFindText, string szReplaceText, bool bMatchCase)
        {
            if (editor == null || editor.IsDisposed || string.IsNullOrEmpty(szFindText))
                return;
            string szSelectedText = editor.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;
            if (szSelectedText != string.Empty
                && ((bMatchCase && szSelectedText == szFindText)
                || (!bMatchCase && szSelectedText.ToLower() == szFindText.ToLower())))
            {
                int start = editor.ActiveTextAreaControl.TextArea.SelectionManager.SelectionCollection[0].Offset;
                int end = editor.ActiveTextAreaControl.TextArea.SelectionManager.SelectionCollection[0].EndOffset;
                editor.Document.Replace(Math.Min(start, end), szSelectedText.Length, szReplaceText);
            }

            editor.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();

            FindResult result = this.FindNextPrivate(editor, szFindText, bMatchCase);
            if (result != null)
            {
                Point startPos = editor.Document.OffsetToPosition(result.Offset);
                Point endPos = editor.Document.OffsetToPosition(result.Offset + result.Length);
                editor.ActiveTextAreaControl.SelectionManager.SetSelection(startPos, endPos);
                editor.ActiveTextAreaControl.TextArea.Caret.Position = editor.Document.OffsetToPosition(result.Offset);
            }
        }

        /// <summary>
        /// 在指定的TextEditor编辑器内查找并替换指定的所有文本
        /// </summary>
        /// <param name="editor">TextEditor编辑器</param>
        /// <param name="szFindText">查找文本</param>
        /// <param name="szReplaceText">替换文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        public void ReplaceAll(TextEditorControl editor, string szFindText, string szReplaceText, bool bMatchCase)
        {
            if (editor == null || editor.IsDisposed || string.IsNullOrEmpty(szFindText))
                return;
            if (szReplaceText == null)
                szReplaceText = string.Empty;

            int nVScrollBarValue = editor.ActiveTextAreaControl.VScrollBar.Value;
            int nHScrollBarValue = editor.ActiveTextAreaControl.HScrollBar.Value;

            IDocument document = editor.ActiveTextAreaControl.Document;
            editor.ActiveTextAreaControl.TextArea.Caret.Position = document.OffsetToPosition(0);

            FindResult result = this.FindNextPrivate(editor, szFindText, bMatchCase);
            while (result != null)
            {
                document.Replace(result.Offset, result.Length, szReplaceText);
                editor.ActiveTextAreaControl.TextArea.Caret.Position = document.OffsetToPosition(result.Offset + szReplaceText.Length);
                result = this.FindNextPrivate(editor, szFindText, bMatchCase);
            }

            if (nVScrollBarValue <= editor.ActiveTextAreaControl.VScrollBar.Maximum && nVScrollBarValue >= editor.ActiveTextAreaControl.VScrollBar.Minimum)
            {
                editor.ActiveTextAreaControl.VScrollBar.Value = nVScrollBarValue;
            }
            if (nHScrollBarValue <= editor.ActiveTextAreaControl.HScrollBar.Maximum && nHScrollBarValue >= editor.ActiveTextAreaControl.HScrollBar.Minimum)
            {
                editor.ActiveTextAreaControl.HScrollBar.Value = nHScrollBarValue;
            }
        }
    }
}
