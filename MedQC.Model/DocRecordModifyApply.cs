using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 病历审核申请
    /// </summary>
    public class DocRecordModifyApply : DbTypeBase
    {
        private string m_QC_ID = string.Empty;
        /// <summary>
        /// 质控科签字ID
        /// </summary>
        public string QCID
        {
            get { return m_QC_ID; }
            set { m_QC_ID = value; }
        }
        private DateTime m_QC_Time;
        /// <summary>
        /// 质控科签字时间
        /// </summary>
        public DateTime QCTime
        {
            get { return m_QC_Time; }
            set { m_QC_Time = value; }
        }
        private string m_QC_Remark = string.Empty;
        /// <summary>
        /// 质控科备注
        /// </summary>
        public string QCRemark
        {
            get { return m_QC_Remark; }
            set { m_QC_Remark = value; }
        }
        private string m_PatintID = string.Empty;
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatintID
        {
            get { return m_PatintID; }
            set { m_PatintID = value; }
        }
        private string m_VisitID = string.Empty;

        /// <summary>
        /// 就诊ID
        /// </summary>
        public string VisitID
        {
            get { return m_VisitID; }
            set { m_VisitID = value; }
        }
        private DateTime m_VisitTime;
        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime VisitTime
        {
            get { return m_VisitTime; }
            set { m_VisitTime = value; }
        }
        private string m_DocID = string.Empty;
        /// <summary>
        /// 病历ID
        /// </summary>
        public string DocID
        {
            get { return m_DocID; }
            set { m_DocID = value; }
        }
        private string m_DocTitle = string.Empty;
        /// <summary>
        /// 病历标题
        /// </summary>
        public string DocTitle
        {
            get { return m_DocTitle; }
            set { m_DocTitle = value; }
        }
        private string m_PatientName = string.Empty;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get { return m_PatientName; }
            set { m_PatientName = value; }
        }
        private string m_ModifyReason = string.Empty;
        /// <summary>
        /// 修改理由
        /// </summary>
        public string ModifyReason
        {
            get { return m_ModifyReason; }
            set { m_ModifyReason = value; }
        }
        private string m_BeforeContent = string.Empty;
        /// <summary>
        /// 修改/更换前内容
        /// </summary>
        public string BeforeContent
        {
            get { return m_BeforeContent; }
            set { m_BeforeContent = value; }
        }
        private string m_AfterContent = string.Empty;
        /// <summary>
        /// 修改/更换后内容
        /// </summary>
        public string AfterContent
        {
            get { return m_AfterContent; }
            set { m_AfterContent = value; }
        }
        private string m_ApplicantID = string.Empty;
        /// <summary>
        /// 申请者ID
        /// </summary>
        public string ApplicantID
        {
            get { return m_ApplicantID; }
            set { m_ApplicantID = value; }
        }
        private DateTime dt_ApplyDate;
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate
        {
            get { return dt_ApplyDate; }
            set { dt_ApplyDate = value; }
        }
        private string m_HeaderID = string.Empty;
        /// <summary>
        /// 科主任/护士长签字
        /// </summary>
        public string HeaderID
        {
            get { return m_HeaderID; }
            set { m_HeaderID = value; }
        }
        private DateTime dt_HeaderTime;
        /// <summary>
        /// 科主任/护士长签字时间
        /// </summary>
        public DateTime HeaderTime
        {
            get { return dt_HeaderTime; }
            set { dt_HeaderTime = value; }
        }
        private string m_HeaderRemark = string.Empty;
        /// <summary>
        /// 科主任备注
        /// </summary>
        public string HeaderRemark
        {
            get { return m_HeaderRemark; }
            set { m_HeaderRemark = value; }
        }

        private string m_AuditStatus = string.Empty;

        /// <summary>
        /// 审核状态【保存、已申请、撤销、退回、主任审核、质控科审核、完成】
        ///                                 --BC、YSQ、CX、TH、ZSH、QCSH、WC
        /// </summary>
        public string AuditStatus
        {
            get { return m_AuditStatus; }
            set { m_AuditStatus = value; }
        }
        private string m_ApplyDeptCode = string.Empty;
        /// <summary>
        /// 申请科室代码
        /// </summary>
        public string ApplyDeptCode
        {
            get { return m_ApplyDeptCode; }
            set { m_ApplyDeptCode = value; }
        }
        public DocRecordModifyApply()
        {
            dt_HeaderTime = base.DefaultTime;
            dt_ApplyDate = base.DefaultTime;
            m_VisitTime = base.DefaultTime;
            m_QC_Time = base.DefaultTime;
        }
    }

}
