using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 病历时效检查扣分信息
    /// </summary>
    public class QCTimeCheck : DbTypeBase
    {
        private string m_szPatientID = string.Empty;
        /// <summary>
        /// 获取或设置患者的ID
        /// </summary>
        public string PatientID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }

        private string m_szVisitID = string.Empty;
        /// <summary>
        /// 获取或设置患者的本次就诊ID
        /// </summary>
        public string VisitID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }
        private string m_szEventID = string.Empty;
        /// <summary>
        /// 获取或设置事件ID
        /// </summary>
        public string EventID
        {
            get { return this.m_szEventID; }
            set { this.m_szEventID = value; }
        }

        private string m_szDocTypeID = string.Empty;
        /// <summary>
        /// 获取或设置病历文档类型
        /// </summary>
        public string DocTypeID
        {
            get { return this.m_szDocTypeID; }
            set { this.m_szDocTypeID = value; }
        }

        private DateTime m_dtBeginTime = DateTime.Now;
        /// <summary>
        /// 获取或设置病历书写的的截止时间
        /// </summary>
        public DateTime BeginTime
        {
            get { return this.m_dtBeginTime; }
            set { this.m_dtBeginTime = value; }
        }

        private DateTime m_dtEndTime = DateTime.Now;
        /// <summary>
        /// 获取或设置病历书写的起始时间
        /// </summary>
        public DateTime EndTime
        {
            get { return this.m_dtEndTime; }
            set { this.m_dtEndTime = value; }
        }

        private string m_szPoint = string.Empty;
        /// <summary>
        /// 获取或设置扣分值
        /// </summary>
        public string Point
        {
            get { return this.m_szPoint; }
            set { this.m_szPoint = value; }
        }

        private string m_szCheckerName = string.Empty;
        /// <summary>
        /// 获取或设置检查人姓名
        /// </summary>
        public string CheckerName
        {
            get { return this.m_szCheckerName; }
            set { this.m_szCheckerName = value; }
        }

        private DateTime m_dtCheckTime = DateTime.Now;
        /// <summary>
        ///获取或设置检查日期
        /// </summary>
        public DateTime CheckTime
        {
            get { return this.m_dtCheckTime; }
            set { this.m_dtCheckTime = value; }
        }
    }
}
