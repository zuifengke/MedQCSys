// ***********************************************************
// 护理病历配置管理系统,脚本编辑器脚本文本查找结果信息对象
// Author : YangMingkun, Date : 2013-5-4
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Text;
using System.Drawing;
using Heren.Common.TextEditor.Document;

namespace Designers.FindReplace
{
    internal class FindResult
    {
        private int m_offset = 0;

        /// <summary>
        /// 获取当前查找的字符索引
        /// </summary>
        public int Offset
        {
            get { return this.m_offset; }
        }

        private int m_length = 0;

        /// <summary>
        /// 获取当前查找到的字符长度
        /// </summary>
        public int Length
        {
            get { return this.m_length; }
        }

        private int m_line = 0;

        /// <summary>
        /// 获取当前查找到的字符所在行
        /// </summary>
        public int Line
        {
            get { return this.m_line; }
        }

        private string m_text = string.Empty;

        /// <summary>
        /// 获取当前查找到的文本行
        /// </summary>
        public string Text
        {
            get { return this.m_text; }
        }

        private string m_templetID = string.Empty;

        /// <summary>
        /// 获取查询结果文档ID号
        /// </summary>
        public string TempletID
        {
            get { return this.m_templetID; }
        }

        private string m_templetName = string.Empty;

        /// <summary>
        /// 获取查询结果文档名
        /// </summary>
        public string TempletName
        {
            get { return this.m_templetName; }
        }

        private string m_fileType = string.Empty;

        /// <summary>
        /// 查询结果类型
        /// </summary>
        public string FileType
        {
            get { return this.m_fileType; }
        }

        public FindResult(int offset, int length, int line, string text)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException("length");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            this.m_offset = offset;
            this.m_length = length;
            this.m_line = line;
            this.m_text = text;
        }

        public FindResult(int offset, int length, int line, string text, string templetID, string templetName
            , string Filetype)
            : this(offset, length, line, text)
        {
            this.m_templetID = templetID;
            this.m_templetName = templetName;
            this.m_fileType = Filetype;
        }

        public virtual Point GetStartPosition(IDocument document)
        {
            return document.OffsetToPosition(this.Offset);
        }

        public virtual Point GetEndPosition(IDocument document)
        {
            return document.OffsetToPosition(this.Offset + this.Length);
        }

        public override string ToString()
        {
            return string.Format("[FindResult: Offset={0}, Length={1}, Line={2}, Text={3}]", this.Offset, this.Length, this.Line, this.Text);
        }
    }
}
