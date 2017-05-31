// ***********************************************************
// 病历时效质控引擎时效检查查询类
// 主要用于外部传入给引擎用来查询病人医疗数据
// Creator:YangMingkun  Date:2012-1-3
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace MedDocSys.QCEngine.TimeCheck
{
    public class TimeCheckQuery
    {
        private string m_szUserID = string.Empty;
        /// <summary>
        /// 获取或设置用户ID
        /// </summary>
        public string UserID
        {
            get { return this.m_szUserID; }
            set { this.m_szUserID = value; }
        }

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
        private string m_szVisitNo = string.Empty;
        /// <summary>
        /// 获取或设置就诊流水号
        /// </summary>
        public string VisitNO
        {
            get { return this.m_szVisitNo; }
            set { this.m_szVisitNo = value; }
        }

        private string m_szBedCode = string.Empty;
        /// <summary>
        /// 获取或设置就诊床号
        /// </summary>
        public string BedCode
        {
            get { return this.m_szBedCode; }
            set { this.m_szBedCode = value; }
        }

        private string m_szDiagnosis = string.Empty;
        /// <summary>
        /// 获取或设置入院诊断
        /// </summary>
        public string Diagnosis
        {
            get { return this.m_szDiagnosis; }
            set { this.m_szDiagnosis = value; }
        }

        private string m_szPatientName = string.Empty;
        /// <summary>
        /// 获取或设置病人姓名
        /// </summary>
        public string PatientName
        {
            get { return this.m_szPatientName; }
            set { this.m_szPatientName = value; }
        }

        private DateTime m_dtVisitTime = DateTime.Now;
        /// <summary>
        /// 获取或设置病人就诊时间
        /// </summary>
        public DateTime VisitTime
        {
            get { return this.m_dtVisitTime; }
            set { this.m_dtVisitTime = value; }
        }

        private string m_szDeptCode = string.Empty;
        /// <summary>
        /// 获取或设置科室编码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }

        private string m_szDoctorLevel = string.Empty;
        /// <summary>
        /// 医生等级
        /// <para>1.经治医生; 2.上级医生; 3. 主任医生</para>
        /// </summary>
        public string DoctorLevel
        {
            get { return this.m_szDoctorLevel; }
            set { this.m_szDoctorLevel = value; }
        }
        public TimeCheckQuery()
        {
            this.m_szDoctorLevel = "1";
        }
    }
}
