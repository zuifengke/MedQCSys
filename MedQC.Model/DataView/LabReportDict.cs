using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 检验报告字典
    /// </summary>
    public class LabReportDict : DbTypeBase
    {
        private string m_szItemCode = string.Empty;
        /// <summary>
        /// 项目代码
        /// </summary>
        public string ItemCode
        {
            get { return this.m_szItemCode; }
            set { this.m_szItemCode = value; }
        }

        private string m_szItemName = string.Empty;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            get { return this.m_szItemName; }
            set { this.m_szItemName = value; }
        }


        public override string ToString()
        {
            return this.m_szItemName;
        }
    }
}
