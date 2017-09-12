using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 时效性质控记录表
    /// </summary>
    public class QcTimeRecord : DbTypeBase
    {
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
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        private string m_szEventID = string.Empty;
        /// <summary>
        /// 关联事件ID号
        /// </summary>
        public string EventID
        {
            get { return this.m_szEventID; }
            set { this.m_szEventID = value; }
        }
        private string m_szEventName = string.Empty;
        /// <summary>
        /// 关联事件名称
        /// </summary>
        public string EventName
        {
            get { return this.m_szEventName; }
            set { this.m_szEventName = value; }
        }

        private DateTime m_dtEventTime;
        /// <summary>
        /// 关联事件时间
        /// </summary>
        public DateTime EventTime
        {
            get { return this.m_dtEventTime; }
            set { this.m_dtEventTime = value; }
        }
        private string m_szDocTypeID = string.Empty;
        /// <summary>
        /// 文书类型ID号
        /// </summary>
        public string DocTypeID
        {
            get { return this.m_szDocTypeID; }
            set { this.m_szDocTypeID = value; }
        }

        private string m_szDocTypeName = string.Empty;
        /// <summary>
        /// 文书类型名
        /// </summary>
        public string DocTypeName
        {
            get { return this.m_szDocTypeName; }
            set { this.m_szDocTypeName = value; }
        }

        private DateTime m_dtBeginDate;
        /// <summary>
        /// 正常书写开始时间
        /// </summary>
        public DateTime BeginDate
        {
            get { return this.m_dtBeginDate; }
            set { this.m_dtBeginDate = value; }
        }
        private DateTime m_dtEndDate;
        /// <summary>
        /// 正常书写截止时间
        /// </summary>
        public DateTime EndDate
        {
            get { return this.m_dtEndDate; }
            set { this.m_dtEndDate = value; }
        }
        private float m_fPoint = 0;
        /// <summary>
        /// 扣分
        /// </summary>
        public float Point
        {
            get { return this.m_fPoint; }
            set { this.m_fPoint = value; }
        }
        private string m_szCheckName = string.Empty;
        /// <summary>
        /// 检查者姓名
        /// </summary>
        public string CheckName
        {
            get { return this.m_szCheckName; }
            set { this.m_szCheckName = value; }
        }
        private DateTime m_dtCheckDate;
        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime CheckDate
        {
            get { return this.m_dtCheckDate; }
            set { this.m_dtCheckDate = value; }
        }
        private string m_szDocID = string.Empty;

        /// <summary>
        /// 文档ID号
        /// </summary>
        public string DocID
        {
            get { return this.m_szDocID; }
            set { this.m_szDocID = value; }
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
        private string m_szRecNo = string.Empty;
        /// <summary>
        /// 份数
        /// </summary>
        public string RecNo
        {
            get { return this.m_szRecNo; }
            set { this.m_szRecNo = value; }
        }

        private DateTime m_dtRecordTime;
        /// <summary>
        /// 病历记录时间
        /// </summary>
        public DateTime RecordTime
        {
            get { return this.m_dtRecordTime; }
            set { this.m_dtRecordTime = value; }
        }
        private DateTime m_dtDocTime;
        /// <summary>
        /// 病历创建时间
        /// </summary>
        public DateTime DocTime
        {
            get { return this.m_dtDocTime; }
            set { this.m_dtDocTime = value; }
        }
        private string m_szQcResult;
        /// <summary>
        /// 0:正常;1:提前;2:超期;3:未写;4:警告;9:其它
        /// </summary>
        public string QcResult
        {
            get { return this.m_szQcResult; }
            set { this.m_szQcResult = value; }
        }

        private string m_szCreateID = string.Empty;
        /// <summary>
        /// 病历书写者ID
        /// </summary>
        public string CreateID
        {
            get { return this.m_szCreateID; }
            set { this.m_szCreateID = value; }
        }
        private string m_szCreateName = string.Empty;
        /// <summary>
        /// 病历书写者姓名
        /// </summary>
        public string CreateName
        {
            get { return this.m_szCreateName; }
            set { this.m_szCreateName = value; }
        }
        private string m_szQcExplain = string.Empty;
        /// <summary>
        /// 质控依据说明
        /// </summary>
        public string QcExplain
        {
            get { return this.m_szQcExplain; }
            set { this.m_szQcExplain = value; }
        }

        private string m_szDoctorInCharge = string.Empty;
        /// <summary>
        /// 书写此病历的责任医生(经治)_统计
        /// </summary>
        public string DoctorInCharge
        {
            get { return this.m_szDoctorInCharge; }
            set { this.m_szDoctorInCharge = value; }
        }

        private string m_szDeptInCharge = string.Empty;
        /// <summary>
        /// 书写此病历的责任科室_统计
        /// </summary>
        public string DeptInCharge
        {
            get { return this.m_szDeptInCharge; }
            set { this.m_szDeptInCharge = value; }
        }

        private string m_szDeptStayed = string.Empty;
        /// <summary>
        /// 当前病人所在科室_综合查询
        /// </summary>
        public string DeptStayed
        {
            get { return this.m_szDeptStayed; }
            set { this.m_szDeptStayed = value; }
        }

        private string m_szPatientName = string.Empty;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get { return this.m_szPatientName; }
            set { this.m_szPatientName = value; }
        }
        private DateTime m_dtDischargeTime;
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DischargeTime
        {
            get { return this.m_dtDischargeTime; }
            set { this.m_dtDischargeTime = value; }
        }
        private bool m_bIsVeto = false;
        /// <summary>
        /// 是否是单项否决  1 是 0 否
        /// </summary>
        public bool IsVeto
        {
            get { return m_bIsVeto; }
            set { m_bIsVeto = value; }
        }
        private bool m_bMessageNotify;
        /// <summary>
        /// 是否短信已通知 0：未通知 1：已通知 默认为未通知
        /// </summary>
        public bool MessageNotify
        {
            get { return this.m_bMessageNotify; }
            set { this.m_bMessageNotify = value; }
        }
        public QcTimeRecord()
        {
            this.m_dtBeginDate = this.DefaultTime;
            this.m_dtCheckDate = this.DefaultTime;
            this.m_dtEndDate = this.DefaultTime;
            this.m_dtRecordTime = this.DefaultTime;
            this.m_dtEventTime = this.DefaultTime;
            this.m_dtDocTime = this.DefaultTime;
            this.m_dtDischargeTime = this.DefaultTime;
            this.m_bMessageNotify = false;
        }
    }
}
