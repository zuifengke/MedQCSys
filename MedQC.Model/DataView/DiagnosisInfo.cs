using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 患者诊断信息类
    /// </summary>
    [System.Serializable]
    public class DiagnosisInfo : DbTypeBase
    {
        private string m_szPatientID = string.Empty;
        /// <summary>
        /// 获取或设置病人ID
        /// </summary>
        public string PatientID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }

        private string m_szVisitID = string.Empty;
        /// <summary>
        /// 获取或设置就诊ID
        /// </summary>
        public string VisitID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }

        private string m_szDiagnosisType = string.Empty;
        /// <summary>
        /// 获取或设置诊断类型
        /// </summary>
        public string DiagnosisType
        {
            get { return this.m_szDiagnosisType; }
            set { this.m_szDiagnosisType = value; }
        }

        private string m_szDiagnosisTypeName = string.Empty;
        /// <summary>
        /// 获取或设置就诊类型名称
        /// </summary>
        public string DiagnosisTypeName
        {
            get { return this.m_szDiagnosisTypeName; }
            set { this.m_szDiagnosisTypeName = value; }
        }

        private int m_nDiagnosisNO;
        /// <summary>
        /// 获取或设置诊断编号
        /// </summary>
        public int DiagnosisNO
        {
            get { return this.m_nDiagnosisNO; }
            set { this.m_nDiagnosisNO = value; }
        }

        private string m_szDiagnosisDesc = string.Empty;
        /// <summary>
        /// 获取或设置就诊描述
        /// </summary>
        public string DiagnosisDesc
        {
            get { return this.m_szDiagnosisDesc; }
            set { this.m_szDiagnosisDesc = value; }
        }

        private DateTime m_dtDiagnosisDate = DateTime.MinValue;
        /// <summary>
        /// 获取或设置就诊日期
        /// </summary>
        public DateTime DiagnosisDate
        {
            get { return this.m_dtDiagnosisDate; }
            set { this.m_dtDiagnosisDate = value; }
        }

        private string m_szTreatResult;
        /// <summary>
        /// 获取或设置治疗结果
        /// </summary>
        public string TreatResult
        {
            get { return this.m_szTreatResult; }
            set { this.m_szTreatResult = value; }
        }
    }
}
