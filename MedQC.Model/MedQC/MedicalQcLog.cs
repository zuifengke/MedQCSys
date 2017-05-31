using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 病案质量监控日志类
    /// </summary>
    public class MedicalQcLog : DbTypeBase
    {
        private string m_szPatientID = string.Empty;    //病人标识号
        private string m_szVisitID = string.Empty;      //病人本次住院标识
        private string m_szDeptStayed = string.Empty;     //病人所在科室
        private DateTime m_dtCheckTime = DateTime.Now;  //审查日期
        private string m_szCheckerName = string.Empty;  //审查者
        private string m_szDocSetID = string.Empty;     //文档集ID
        private string m_szDeptCode = string.Empty;    //检查者所在科室代码
        private string m_szDeptName = string.Empty;      //检查者所在科室名称
        private int m_nCheckType = 0;         //检查类型
        private int m_nLogType = 0;           //日志类型
        private string m_szLogDesc = string.Empty;     //日志描述
        private bool m_bAddQCQuestion = false;         //日否是添加反馈信息
        public string DocTitle { get; set; }
        public string PatientName { get; set; }
        /// <summary>
        /// 获取或设置病人ID
        /// </summary>
        public string PATIENT_ID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }
        /// <summary>
        /// 获取或设置就诊号
        /// </summary>
        public string VISIT_ID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }
        /// <summary>
        /// 获取或设置病人所在科室
        /// </summary>
        public string DEPT_STAYED
        {
            get { return this.m_szDeptStayed; }
            set { this.m_szDeptStayed = value; }
        }
        /// <summary>
        /// 获取或设置审查日期
        /// </summary>
        public DateTime CHECK_DATE
        {
            get { return this.m_dtCheckTime; }
            set { this.m_dtCheckTime = value; }
        }
        /// <summary>
        /// 获取或设置审查者姓名
        /// </summary>
        public string CHECKED_BY
        {
            get { return this.m_szCheckerName; }
            set { this.m_szCheckerName = value; }
        }
        /// <summary>
        /// 获取或设置病历文档ID
        /// </summary>
        public string DOC_SETID
        {
            get { return this.m_szDocSetID; }
            set { this.m_szDocSetID = value; }
        }
        /// <summary>
        /// 获取或设置科室代码
        /// </summary>
        public string DEPT_CODE
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }

        /// <summary>
        /// 获取或设置科室名称
        /// </summary>
        public string DEPT_NAME
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        /// <summary>
        /// 获取或设置病历操作类型(0-正在读；1-正在写；2-写完成；3-删除完成；4-归档完成;5-添加反馈信息成功;)
        /// </summary>
        public int CHECK_TYPE
        {
            get { return this.m_nCheckType; }
            set { this.m_nCheckType = value; }
        }
        /// <summary>
        /// 获取或设置日志类型(0-医生读写日志；1-质控读写日志；2-院级读写日志；)
        /// </summary>
        public int LOG_TYPE
        {
            get { return this.m_nLogType; }
            set { this.m_nLogType = value; }
        }
        /// <summary>
        /// 获取或设置日志描述信息
        /// </summary>
        public string LOG_DESC
        {
            get { return this.m_szLogDesc; }
            set { this.m_szLogDesc = value; }
        }

        public string m_CheckedID = string.Empty;

        /// <summary>
        /// 获取或设置是否是新增反馈信息所产生的日志
        /// </summary>
        public bool AddQCQuestion
        {
            get { return this.m_bAddQCQuestion; }
            set { this.m_bAddQCQuestion = value; }
        }

        /// <summary>
        /// 质检者ID
        /// </summary>
        public string CHECKED_ID
        {
            get { return m_CheckedID; }
            set { m_CheckedID = value; }
        }
        /// <summary>
        /// 质检问题代码
        /// </summary>
        public string QC_MSG_CODE { get; set; }
        public MedicalQcLog()
        {
            this.QC_MSG_CODE = string.Empty;
            this.m_dtCheckTime = this.DefaultTime;
        }
    }

}
