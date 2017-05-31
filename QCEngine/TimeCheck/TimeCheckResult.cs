// ***********************************************************
// 病历时效质控引擎时效分析结果信息
// 主要在时效分析过程中,用来创建病历时间表以及返回时效检查结果
// Creator:YangMingkun  Date:2012-1-3
// Copyright:supconhealth
// ***********************************************************
using EMRDBLib;
using System;
using System.Collections.Generic;
namespace MedDocSys.QCEngine.TimeCheck
{
    /// <summary>
    /// 时效审核状态枚举
    /// </summary>
    public enum WrittenState
    {
        /// <summary>
        /// 未核实
        /// </summary>
        Uncheck = -1,
        /// <summary>
        /// 正常状态
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 未书写
        /// </summary>
        Unwrite = 1,
        /// <summary>
        /// 书写提前
        /// </summary>
        Early = 2,
        /// <summary>
        /// 书写超时
        /// </summary>
        Timeout = 3
    }

    /// <summary>
    /// 时效检查结果列表
    /// </summary>
    public class TimeCheckResultList : List<TimeCheckResult>
    { }

    /// <summary>
    /// 时效审核结果信息类
    /// </summary>
    public class TimeCheckResult
    {
        private string m_szPatientID = string.Empty;        //病人编号
        private string m_szPatientName = string.Empty;      //病人姓名
        private string m_szVisitID = string.Empty;          //病人当次住院标识
        private string m_szVisitNO = string.Empty;
        private string m_szEventID = string.Empty;          //事件CODE
        private string m_szEventName = string.Empty;        //事件名称
        private DateTime m_dtEventTime = DateTime.Now;      //事件发生时间        
        private string m_szDocID = string.Empty;            //文档编号
        private string m_szDocTitle = string.Empty;         //文档名称
        private string m_szDocTypeID = string.Empty;        //文档类型代码列表
        private string m_szDocTypeName = string.Empty;      //文档类型名称列表
        private string m_szCreatorID = string.Empty;        //创建者ID
        private string m_szCreatorName = string.Empty;      //创建者姓名
        private DateTime m_dtDocTime = DateTime.Now;        //病历实际书写时间
        private DateTime m_dtRecordTime = DateTime.Now;      //病历文档内部书写时间
        private DateTime m_dtStartTime = DateTime.Now;      //书写的起始时间
        private DateTime m_dtEndTime = DateTime.Now;        //最后期限时间
        private string m_szWrittenPeriod = string.Empty;    //期限时间描述
        private bool m_bIsRepeat = false;                   //是否是循环书写
        private string m_szResultDesc = string.Empty;       //检查结果描述
        private float m_fQCScore = 0f;                      //质控扣分
        private WrittenState m_writtenState = WrittenState.Normal;//状态描述
        private string m_szBedCode = string.Empty;          //床号
        private DateTime m_dtVisitTime = DateTime.Now;      //就诊时间
        private string m_szDoctorLevel = "1";               //监控医生等级 默认1，即经治医师
        private DateTime m_dtSignDate = DateTime.Now;       //文档的签名时间
        private bool m_bIsStopRight = false;                //是否要停止处方权
        private bool m_IsVeto = false;                      //是否单项否决
        /// <summary>
        /// 获取默认时间
        /// </summary>
        public DateTime DefaultTime
        {
            get { return DateTime.Parse("1900-1-1"); }
        }
        /// <summary>
        /// 获取或设置病人编号
        /// </summary>
        public string PatientID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }
        /// <summary>
        /// 获取或设置病人姓名
        /// </summary>
        public string PatientName
        {
            get { return this.m_szPatientName; }
            set { this.m_szPatientName = value; }
        }
        /// <summary>
        /// 获取或设置病人当次住院标识
        /// </summary>
        public string VisitID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }
        /// <summary>
        /// 获取或设置患者就诊流水号
        /// </summary>
        public string VisitNO
        {
            get { return this.m_szVisitNO; }
            set { this.m_szVisitNO = value; }
        }
        /// <summary>
        /// 获取或设置时效结果的事件ID
        /// </summary>
        public string EventID
        {
            get { return this.m_szEventID; }
            set { this.m_szEventID = value; }
        }
        /// <summary>
        /// 获取或设置时效结果的事件名称
        /// </summary>
        public string EventName
        {
            get { return this.m_szEventName; }
            set { this.m_szEventName = value; }
        }
        /// <summary>
        /// 获取或设置事件发生的时间
        /// </summary>
        public DateTime EventTime
        {
            get { return this.m_dtEventTime; }
            set { this.m_dtEventTime = value; }
        }
        /// <summary>
        /// 获取或设置书写的起始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return this.m_dtStartTime; }
            set { this.m_dtStartTime = value; }
        }
        /// <summary>
        /// 获取或设置文档期限时间
        /// </summary>
        public DateTime EndTime
        {
            get { return this.m_dtEndTime; }
            set { this.m_dtEndTime = value; }
        }
        /// <summary>
        /// 获取或设置书写期限描述
        /// </summary>
        public string WrittenPeriod
        {
            get { return this.m_szWrittenPeriod; }
            set { this.m_szWrittenPeriod = value; }
        }
        /// <summary>
        /// 获取或设置文档编号
        /// </summary>
        public string DocID
        {
            get { return this.m_szDocID; }
            set { this.m_szDocID = value; }
        }
        /// <summary>
        /// 获取或设置文档名称
        /// </summary>
        public string DocTitle
        {
            get { return this.m_szDocTitle; }
            set { this.m_szDocTitle = value; }
        }
        /// <summary>
        /// 获取或设置文档类型代码
        /// </summary>
        public string DocTypeID
        {
            get { return this.m_szDocTypeID; }
            set { this.m_szDocTypeID = value; }
        }
        /// <summary>
        /// 获取或设置病历文档类型名称
        /// </summary>
        public string DocTypeName
        {
            get { return this.m_szDocTypeName; }
            set { this.m_szDocTypeName = value; }
        }
        /// <summary>
        /// 获取或设置文档实际书写时间
        /// </summary>
        public DateTime DocTime
        {
            get { return this.m_dtDocTime; }
            set { this.m_dtDocTime = value; }
        }

        /// <summary>
        /// 获取或设置文档内部书写时间
        /// </summary>
        public DateTime RecordTime
        {
            get { return this.m_dtRecordTime; }
            set { this.m_dtRecordTime = value; }
        }

        /// <summary>
        /// 获取或设置创建者ID号
        /// </summary>
        public string CreatorID
        {
            get { return this.m_szCreatorID; }
            set { this.m_szCreatorID = value; }
        }
        /// <summary>
        /// 获取或设置创建者姓名
        /// </summary>
        public string CreatorName
        {
            get { return this.m_szCreatorName; }
            set { this.m_szCreatorName = value; }
        }
        /// <summary>
        /// 获取或设置病历书写状态描述
        /// </summary>
        public WrittenState WrittenState
        {
            get { return this.m_writtenState; }
            set { this.m_writtenState = value; }
        }
        /// <summary>
        /// 获取或设置质控扣分
        /// </summary>
        public float QCScore
        {
            get { return this.m_fQCScore; }
            set { this.m_fQCScore = value; }
        }
        /// <summary>
        /// 获取或设置是否循环检查时效
        /// </summary>
        public bool IsRepeat
        {
            get { return this.m_bIsRepeat; }
            set { this.m_bIsRepeat = value; }
        }
        /// <summary>
        /// 获取或设置检查结果描述
        /// </summary>
        public string ResultDesc
        {
            get { return this.m_szResultDesc; }
            set { this.m_szResultDesc = value; }
        }
        /// <summary>
        /// 获取或设置在院病人床号
        /// </summary>
        public string BedCode
        {
            get { return this.m_szBedCode; }
            set { this.m_szBedCode = value; }
        }
        /// <summary>
        /// 获取或设置病人就诊时间
        /// </summary>
        public DateTime VisitTime
        {
            get { return this.m_dtVisitTime; }
            set { this.m_dtVisitTime = value; }
        }

        /// <summary>
        /// 监控医生等级
        /// </summary>
        public string DoctorLevel
        {
            get { return this.m_szDoctorLevel; }
            set { this.m_szDoctorLevel = value; }
        }

        /// <summary>
        /// 签名时间
        /// </summary>
        public DateTime SignDate
        {
            get { return this.m_dtSignDate; }
            set { this.m_dtSignDate = value; }
        }

        /// <summary>
        /// 获取或设置是否停止处方权时效
        /// </summary>
        public bool IsStopRight
        {
            get { return this.m_bIsStopRight; }
            set { this.m_bIsStopRight = value; }
        }

        /// <summary>
        /// 获取或设置是否单项否决
        /// </summary>
        public bool IsVeto
        {
            get { return this.m_IsVeto; }
            set { this.m_IsVeto = value; }
        }

        public TimeCheckResult()
        {
            this.m_dtEventTime = this.DefaultTime;
            this.m_dtStartTime = this.DefaultTime;
            this.m_dtEndTime = this.DefaultTime;
            this.m_dtDocTime = this.DefaultTime;
            this.m_dtRecordTime = this.DefaultTime;
            this.m_dtSignDate = this.DefaultTime;
        }

        public string GetKeyWord()
        {
            string szEndTime = this.m_dtEndTime.ToString("yyyy-MM-dd HH:MM:ss");
            return this.m_szPatientID + "_" + this.m_szVisitID + "_" + this.m_szDocTypeID
                + "_" + szEndTime;
        }
        /// <summary>
        /// 检查指定的病历信息是否在当前检查结果起止时间内
        /// </summary>
        /// <param name="docInfo">病历信息</param>
        /// <returns>bool</returns>
        internal bool IsTimeBetween(MedDocInfo docInfo)
        {
            if (docInfo == null)
                return false;

            if (docInfo.RECORD_TIME == docInfo.DefaultTime)
            {
                return (docInfo.DOC_TIME >= this.m_dtStartTime
                    && docInfo.DOC_TIME <= this.m_dtEndTime);
            }
            else
            {
                return (docInfo.RECORD_TIME >= this.m_dtStartTime
                    && docInfo.RECORD_TIME <= this.m_dtEndTime);
            }
        }

        /// <summary>
        /// 获取指定病历的时间与当前检查结果的时间差
        /// </summary>
        /// <param name="docInfo">病历信息</param>
        /// <returns>long</returns>
        internal long TimeSpan(MedDocInfo docInfo)
        {
            if (docInfo == null)
                return -1;

            if (docInfo.DOC_TIME == docInfo.DefaultTime)
                return -1;
            return docInfo.DOC_TIME.Ticks - this.m_dtStartTime.Ticks;
        }

        public override string ToString()
        {
            return string.Format("WrittenState={0};StartTime={1};EndTime={2};DocTime={3};DocTitle={4};"
                , this.m_writtenState, this.m_dtStartTime, this.m_dtEndTime, this.m_dtDocTime, this.m_szDocTitle);
        }
    }
}
