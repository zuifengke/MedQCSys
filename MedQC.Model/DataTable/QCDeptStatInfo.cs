using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 质控问题按科室统计信息
    /// </summary>
    public class QCDeptStatInfo : DbTypeBase
    {
        private string m_szPatientID = string.Empty;
        /// <summary>
        /// 获取或设置患者ID
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

        private string m_InpNO = string.Empty;
        /// <summary>
        /// 住院号
        /// </summary>
        public string InpNo
        {
            get { return m_InpNO; }
            set { m_InpNO = value; }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_CODE { get; set; }
        private string m_szPatientName = string.Empty;
        /// <summary>
        /// 获取或设置患者姓名
        /// </summary>
        public string PatientName
        {
            get { return this.m_szPatientName; }
            set { this.m_szPatientName = value; }
        }
        private string m_szMessage = string.Empty;
        /// <summary>
        /// 获取或设置反馈信息
        /// </summary>
        public string Message
        {
            get { return this.m_szMessage; }
            set { this.m_szMessage = value; }
        }
        private string m_szDoctorInCharge = string.Empty;
        /// <summary>
        /// 获取或设置经治医师
        /// </summary>
        public string DoctorInCharge
        {
            get { return this.m_szDoctorInCharge; }
            set { this.m_szDoctorInCharge = value; }
        }
        private string m_Parent_Doctor = string.Empty;
        /// <summary>
        /// 上级医生
        /// </summary>
        public string ParentDoctor
        {
            get { return m_Parent_Doctor; }
            set { m_Parent_Doctor = value; }
        }
        private string m_Super_Doctor = string.Empty;
        /// <summary>
        /// 主任医生
        /// </summary>
        public string SuperDoctor
        {
            get { return m_Super_Doctor; }
            set { m_Super_Doctor = value; }
        }
        private string m_szCheckerName = string.Empty;
        /// <summary>
        /// 获取或设置检查者姓名
        /// </summary>
        public string CheckerName
        {
            get { return this.m_szCheckerName; }
            set { this.m_szCheckerName = value; }
        }

        private DateTime m_dtCheckTime = DateTime.Now;
        /// <summary>
        /// 获取或设置检查日期
        /// </summary>
        public DateTime CheckTime
        {
            get { return this.m_dtCheckTime; }
            set { this.m_dtCheckTime = value; }
        }

        private DateTime m_dtConfirmTime = DateTime.Now;
        /// <summary>
        /// 获取或设置确认日期
        /// </summary>
        public DateTime ConfirmTime
        {
            get { return this.m_dtConfirmTime; }
            set { this.m_dtConfirmTime = value; }
        }

        private string szDept_Code = string.Empty;
        /// <summary>
        /// 获取或设置科室代码
        /// </summary>
        public string Dept_Code
        {
            get { return szDept_Code; }
            set { szDept_Code = value; }
        }

        private string szDept_Name = string.Empty;
        /// <summary>
        /// 获取或设置科室名称
        /// </summary>
        public string Dept_Name
        {
            get { return szDept_Name; }
            set { szDept_Name = value; }
        }


        /// <summary>
        /// 病历集ID
        /// </summary>
        public string DocSetID
        {
            get { return szDocSetID; }
            set { szDocSetID = value; }
        }

        /// <summary>
        /// 问题类型
        /// </summary>
        public string QaEventType
        {
            get { return szQaEventType; }
            set { szQaEventType = value; }
        }

        private string szDocSetID = string.Empty;

        private string szQaEventType = string.Empty;

        public QCDeptStatInfo()
        {
            this.m_dtCheckTime = this.DefaultTime;
            this.m_dtConfirmTime = this.DefaultTime;
        }
    }
}
