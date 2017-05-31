using EMRDBLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedDocSys.QCEngine.BugCheck
{


    /// <summary>
    /// 文档主条目信息
    /// </summary>
    public class OutlineInfo : ICloneable
    {
        private string m_szID = null;
        /// <summary>
        /// 获取或设置文档主条目ID
        /// </summary>
        public string ID
        {
            get { return this.m_szID; }
            set { this.m_szID = value; }
        }

        private string m_szName = null;
        /// <summary>
        /// 获取或设置文档主条目名称
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }

        private string m_szText = null;
        /// <summary>
        /// 获取或设置文档主条目下用户输入的文本
        /// </summary>
        public string Text
        {
            get { return this.m_szText; }
            set { this.m_szText = value; }
        }

        private ElementType m_ElementType = ElementType.None;
        /// <summary>
        /// 获取或设置文档主条目是否是复杂元素
        /// </summary>
        public ElementType ElementType
        {
            get { return this.m_ElementType; }
            set { this.m_ElementType = value; }
        }

        public OutlineInfo()
        {
        }

        public OutlineInfo(string szSectionID, string szSectionName, ElementType shElementType)
        {
            this.m_szID = szSectionID;
            this.m_szName = szSectionName;
            this.ElementType = shElementType;
        }

        public object Clone()
        {
            OutlineInfo outlineInfo = new OutlineInfo();
            outlineInfo.ID = this.m_szID;
            outlineInfo.Name = this.m_szName;
            outlineInfo.Text = this.m_szText;
            outlineInfo.ElementType = this.ElementType;
            return outlineInfo;
        }
    }
}
