using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 文档元素缺陷信息
    /// </summary>
    public class ElementBugInfo
    {
        private string m_szElementID = string.Empty;
        /// <summary>
        /// 获取或设置元素ID
        /// </summary>
        public string ElementID
        {
            get { return this.m_szElementID; }
            set { this.m_szElementID = value; }
        }

        private string m_szElementName = string.Empty;
        /// <summary>
        /// 获取或设置元素名称
        /// </summary>
        public string ElementName
        {
            get { return this.m_szElementName; }
            set { this.m_szElementName = value; }
        }

        private  ElementType m_szElementType =  ElementType.None;
        /// <summary>
        /// 获取或设置元素类型
        /// </summary>
        public ElementType ElementType
        {
            get { return this.m_szElementType; }
            set { this.m_szElementType = value; }
        }

        private string m_szBugDesc = string.Empty;
        /// <summary>
        /// 获取或设置缺陷信息
        /// </summary>
        public string BugDesc
        {
            get { return this.m_szBugDesc; }
            set { this.m_szBugDesc = value; }
        }

        private bool m_bIsFatalBug = false;
        /// <summary>
        /// 获取或设置当前缺陷是否是致命的缺陷
        /// </summary>
        public bool IsFatalBug
        {
            get { return this.m_bIsFatalBug; }
            set { this.m_bIsFatalBug = value; }
        }

        private object m_Tag = false;
        /// <summary>
        /// 获取或设置tag属性
        /// </summary>
        public object Tag
        {
            get { return this.m_Tag; }
            set { this.m_Tag = value; }
        }
    }
}
