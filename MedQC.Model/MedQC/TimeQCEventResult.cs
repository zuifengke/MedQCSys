using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.Entity
{
    /// <summary>
    /// 病历时效事件执行结果类
    /// </summary>
    [System.Serializable]
    public class TimeQCEventResult : DbTypeBase, ICloneable
    {
        private DateTime? m_dtEventTime = null;
        private DateTime? m_dtEndTime = null;
        private string m_szDoctorLevel = "1";
        /// <summary>
        /// 获取或设置事件发生的时间
        /// </summary>
        public DateTime? EventTime
        {
            get { return this.m_dtEventTime; }
            set { this.m_dtEventTime = value; }
        }

        /// <summary>
        /// 获取或设置事件发生后的截止时间
        /// </summary>
        public DateTime? EndTime
        {
            get { return this.m_dtEndTime; }
            set { this.m_dtEndTime = value; }
        }
        /// <summary>
        /// 获取或设置监控的医生级别
        /// </summary>
        public string DoctorLevel
        {
            get { return this.m_szDoctorLevel; }
            set { this.m_szDoctorLevel = value; }
        }
        public object Clone()
        {
            TimeQCEventResult timeQCEventResult = new TimeQCEventResult();
            timeQCEventResult.EventTime = this.m_dtEventTime;
            timeQCEventResult.EndTime = this.m_dtEndTime;
            timeQCEventResult.DoctorLevel = this.m_szDoctorLevel;
            return timeQCEventResult;
        }
    }

}
