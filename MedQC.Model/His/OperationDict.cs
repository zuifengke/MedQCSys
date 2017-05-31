using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 手术操作字典
    /// </summary>
    public class OperationDict : DbTypeBase
    {
        private string m_szOperationCode = string.Empty;
        /// <summary>
        /// 获取或设置手术编码
        /// </summary>
        public string OperationCode
        {
            get { return this.m_szOperationCode; }
            set { this.m_szOperationCode = value; }
        }

        private string m_szOperationName = string.Empty;
        /// <summary>
        /// 获取或设置手术名称
        /// </summary>
        public string OperationName
        {
            get { return this.m_szOperationName; }
            set { this.m_szOperationName = value; }
        }

        private string m_szInputCode = string.Empty;
        /// <summary>
        /// 获取或设置输入码
        /// </summary>
        public string InputCode
        {
            get { return this.m_szInputCode; }
            set { this.m_szInputCode = value; }
        }

        public override string ToString()
        {
            return this.m_szOperationName;
        }
    }
}
