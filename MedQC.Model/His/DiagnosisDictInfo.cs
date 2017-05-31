using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 诊断字典信息
    /// </summary>
    [System.Serializable]
    public class DiagnosisDictInfo
    {
        private string m_szDiagnosisCode = string.Empty;
        /// <summary>
        /// 获取或设置诊断编码
        /// </summary>
        public string DiagnosisCode
        {
            get { return this.m_szDiagnosisCode; }
            set { this.m_szDiagnosisCode = value; }
        }

        private string m_szDiagnosisName = string.Empty;
        /// <summary>
        /// 获取或设置诊断名称
        /// </summary>
        public string DiagnosisName
        {
            get { return this.m_szDiagnosisName; }
            set { this.m_szDiagnosisName = value; }
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
    }
}
