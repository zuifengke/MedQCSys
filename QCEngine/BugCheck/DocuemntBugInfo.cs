// ***********************************************************
// 病历文档系统文档质控引擎,文档缺陷信息类
// Creator:YangMingkun  Date:2009-8-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;

namespace MedDocSys.QCEngine.BugCheck
{
    /// <summary>
    /// 文档缺陷等级枚举
    /// </summary>
    public enum BugLevel
    {
        /// <summary>
        /// 警告0
        /// </summary>
        Warn = 0,
        /// <summary>
        /// 错误1
        /// </summary>
        Error = 1
    }

    /// <summary>
    /// 文档缺陷信息类
    /// </summary>
    public class DocuemntBugInfo
    {
        private BugLevel m_bugLevel = BugLevel.Error;
        /// <summary>
        /// 获取或设置显示的BUG等级
        /// </summary>
        public BugLevel BugLevel
        {
            get { return this.m_bugLevel; }
            set { this.m_bugLevel = value; }
        }

        private string m_szBugKey = null;
        /// <summary>
        /// 获取或设置显示的BUG关键字
        /// </summary>
        public string BugKey
        {
            get { return this.m_szBugKey; }
            set { this.m_szBugKey = value; }
        }

        private string m_szBugDesc = null;
        /// <summary>
        /// 获取或设置显示的BUG描述
        /// </summary>
        public string BugDesc
        {
            get { return this.m_szBugDesc; }
            set { this.m_szBugDesc = value; }
        }

        private int m_nBugIndex = 0;
        /// <summary>
        /// 获取或设置BUG缺陷对应的字符在文档中的索引
        /// </summary>
        public int BugIndex
        {
            get { return this.m_nBugIndex; }
            set { this.m_nBugIndex = value; }
        }

        private string m_szResponse = string.Empty;
        /// <summary>
        /// 获取或设置缺陷的响应方式
        /// </summary>
        public string Response
        {
            get { return this.m_szResponse; }
            set { this.m_szResponse = value; }
        }
    }
}
