using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 手术操作字典
    /// </summary>
    public class QcTimeRecordStatByDept
    {
        private DateTime m_szCheckDate;
        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime CheckDate
        {
            get { return this.m_szCheckDate; }
            set { this.m_szCheckDate = value; }
        }

        private string m_szDeptCode = string.Empty;
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }

        private string m_szDeptName = string.Empty;
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        private string m_szDocTitle = string.Empty;
        /// <summary>
        /// 文档标题
        /// </summary>
        public string DocTitle
        {
            get { return this.m_szDocTitle; }
            set { this.m_szDocTitle = value; }
        }

        private int m_nNormal;
        /// <summary>
        /// 正常书写数量
        /// </summary>
        public int Normal
        {
            get { return this.m_nNormal; }
            set { this.m_nNormal = value; }
        }
        private int m_nUnWrite;
        /// <summary>
        /// 未书写数量
        /// </summary>
        public int UnWrite
        {
            get { return this.m_nUnWrite; }
            set { this.m_nUnWrite = value; }
        }
        private int m_nEarly;
        /// <summary>
        /// 书写提前
        /// </summary>
        public int Early
        {
            get { return this.m_nEarly; }
            set { this.m_nEarly = value; }
        }
        private int m_nTimeOut;
        /// <summary>
        /// 书写超时
        /// </summary>
        public int TimeOut
        {
            get { return this.m_nTimeOut; }
            set { this.m_nTimeOut = value; }
        }
        private int m_nUnWriteNormal;
        /// <summary>
        /// 未书写超时
        /// </summary>
        public int UnWriteNormal
        {
            get { return this.m_nUnWriteNormal; }
            set { this.m_nUnWriteNormal = value; }
        }
        private int m_nNeedCount;
        /// <summary>
        /// 全科应写该病历总数
        /// </summary>
        public int NeedCount
        {
            get { return this.m_nNeedCount; }
            set { this.m_nNeedCount = value; }
        }

        private int m_nUnDoPatientCount;
        /// <summary>
        /// 未完成病历涉及的患者数,按海总需求改为正常未书写的人
        /// </summary>
        public int UnDoPatientCount
        {
            get { return this.m_nUnDoPatientCount; }
            set { this.m_nUnDoPatientCount = value; }
        }
        private int m_nDeptPatientCount;
        /// <summary>
        /// 科室当前在院人数
        /// </summary>
        public int DeptPatientCount
        {
            get { return this.m_nDeptPatientCount; }
            set { this.m_nDeptPatientCount = value; }
        }
    }
}
