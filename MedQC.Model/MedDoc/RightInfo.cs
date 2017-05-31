using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EMRDBLib
{



    /// <summary>
    /// 权限点信息
    /// </summary>
    [System.Serializable]
    public class RightInfo : DbTypeBase
    {
        private string m_szName = string.Empty;
        /// <summary>
        /// 获取权限点名字
        /// </summary>
        public string Name
        {
            set { }
            get { return this.m_szName; }
        }

        private int m_nIndex = -1;
        /// <summary>
        /// 获取权限点在权限控制表中的索引
        /// </summary>
        public int Index
        {
            set { }
            get { return this.m_nIndex; }
        }

        private bool m_bValue = false;
        /// <summary>
        /// 获取或设置权限值
        /// </summary>
        public bool Value
        {
            get { return this.m_bValue; }
            set { this.m_bValue = value; }
        }

        private string m_szDescription = string.Empty;
        /// <summary>
        /// 获取或设置权限描述
        /// </summary>
        public string Description
        {
            set { }
            get { return this.m_szDescription; }
        }

        public override string ToString()
        {
            return this.m_szName;
        }

        public RightInfo(string name, int index, bool value, string description)
        {
            this.m_szName = name;
            this.m_nIndex = index;
            this.m_bValue = value;
            this.m_szDescription = description;
        }
    }

}
