using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 身份字典信息
    /// </summary>
    [System.Serializable]
    public class IDentityDictInfo
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

        private string m_szIdentityCode = string.Empty;
        /// <summary>
        /// 身份代码
        /// </summary>
        public string IdentityCode
        {
            get { return this.m_szIdentityCode; }
            set { this.m_szIdentityCode = value; }
        }

        private string m_szIdentityName = string.Empty;
        /// <summary>
        /// 获取或设置身份名称
        /// </summary>
        public string IdentityName
        {
            get { return this.m_szIdentityName; }
            set { this.m_szIdentityName = value; }

        }

        public override string ToString()
        {
            return this.m_szIdentityName;
        }
    }


}
