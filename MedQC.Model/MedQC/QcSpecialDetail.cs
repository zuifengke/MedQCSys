using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{



    public class QcSpecialDetail : DbTypeBase
    {
        private string m_szConfigID = string.Empty;
        /// <summary>
        /// 抽检批次号
        /// </summary>
        public string ConfigID
        {
            get { return this.m_szConfigID; }
            set { this.m_szConfigID = value; }
        }
        private string m_szSpecialID = string.Empty;
        /// <summary>
        /// 专家账号
        /// </summary>
        public string SpecialID
        {
            get { return this.m_szSpecialID; }
            set { this.m_szSpecialID = value; }
        }
        private string m_szSpecialName = string.Empty;
        /// <summary>
        /// 专家姓名
        /// </summary>
        public string SpecialName
        {
            get { return this.m_szSpecialName; }
            set { this.m_szSpecialName = value; }
        }
        private string m_szPatientID = string.Empty;
        /// <summary>
        /// 病人ID号
        /// </summary>
        public string PatientID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }
        private string m_szVisitID = string.Empty;
        /// <summary>
        /// 就诊号
        /// </summary>
        public string VisitID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }

        public QcSpecialDetail()
        {
        }
    }


}
