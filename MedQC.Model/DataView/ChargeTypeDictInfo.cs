using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 费别字典信息
    /// </summary>
    [System.Serializable]
    public class ChargeTypeDictInfo
    {
        private int m_nSerialNo = 0;
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNo
        {
            get { return this.m_nSerialNo; }
            set { this.m_nSerialNo = value; }
        }

        private string m_szChargeTypeCode = string.Empty;
        /// <summary>
        /// 费别代码
        /// </summary>
        public string ChargeTypeCode
        {
            get { return this.m_szChargeTypeCode; }
            set { this.m_szChargeTypeCode = value; }
        }

        private string m_szChargeTypeName = string.Empty;
        /// <summary>
        /// 获取或设置费别名称
        /// </summary>
        public string ChargeTypeName
        {
            get { return this.m_szChargeTypeName; }
            set { this.m_szChargeTypeName = value; }

        }

        public override string ToString()
        {
            return this.m_szChargeTypeName;
        }
    }

}
