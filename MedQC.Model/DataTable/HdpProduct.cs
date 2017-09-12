using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;

namespace EMRDBLib
{
    /// <summary>
    /// 产品管理表
    /// </summary>
    public class HdpProduct : DbTypeBase
    {
        private string m_szSerialNo = string.Empty;
        private string m_szNameShort = string.Empty;
        private string m_szCnName = string.Empty;
        private string m_szEnName = string.Empty;
        private string m_szProductBak = string.Empty;

        /// <summary>
        /// 获取或设置序号
        /// </summary>
        public string SERIAL_NO
        {
            get { return this.m_szSerialNo; }
            set { this.m_szSerialNo = value; }
        }
        /// <summary>
        /// 产品缩写
        /// </summary>
        public string NAME_SHORT
        {
            get { return this.m_szNameShort; }
            set { this.m_szNameShort = value; }
        }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string CN_NAME
        {
            get { return this.m_szCnName; }
            set { this.m_szCnName = value; }
        }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string EN_NAME
        {
            get { return this.m_szEnName; }
            set { this.m_szEnName = value; }
        }
        /// <summary>
        /// 产品备注
        /// </summary> 
        public string PRODUCT_BAK
        {
            get { return this.m_szProductBak; }
            set { this.m_szProductBak = value; }
        }

        public override string ToString()
        {
            return this.m_szCnName;
        }
    }
}
