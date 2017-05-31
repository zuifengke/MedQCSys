// ***********************************************************
// 病历时效质控引擎时效分析结果信息
// 主要在时效分析过程中,用来创建病历时间表以及返回时效检查结果
// Creator:YangMingkun  Date:2012-1-3
// Copyright:supconhealth
// ***********************************************************
using EMRDBLib;
using System;
using System.Collections.Generic;

namespace MedDocSys.QCEngine.AuditCheck
{
    /// <summary>
    /// 审签检查结果列表
    /// </summary>
    public class AuditCheckResultList : List<AuditCheckResult>
    { }

    /// <summary>
    /// 三级审签审核结果信息类
    /// </summary>
    public class AuditCheckResult
    {
        private string m_szPatientID = string.Empty;        //病人编号
        private string m_szPatientName = string.Empty;      //病人姓名
        private string m_szVisitID = string.Empty;          //病人当次住院标识
        private string m_szDocID = string.Empty;            //文档编号
        private string m_szDocTitle = string.Empty;         //文档名称
        private string m_szDocTypeID = string.Empty;        //文档类型代码列表
        private string m_szDocTypeName = string.Empty;      //文档类型名称列表
        private string m_szCreatorID = string.Empty;        //创建者ID
        private string m_szCreatorName = string.Empty;      //创建者姓名
        private string m_szModifierID = string.Empty;       //修改者ID
        private string m_szModifierName = string.Empty;     //修改者姓名
        private DateTime m_dtModifyTime = DateTime.Now;     //修改时间
        private DateTime m_dtDocTime = DateTime.Now;        //病历书写时间
        private string m_szResultDesc = string.Empty;       //检查结果描述
        private string m_szAuditStatus = string.Empty;      //病历审签状态
        private DateTime m_dtVisitTime = DateTime.Now;      //就诊时间

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
        /// 获取或设置文档实际时间
        /// </summary>
        public DateTime DocTime
        {
            get { return this.m_dtDocTime; }
            set { this.m_dtDocTime = value; }
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
        /// 获取或设置病历最后修改人ID
        /// </summary>
        public string ModifierID
        {
            get { return this.m_szModifierID; }
            set { this.m_szModifierID = value; }
        }
        /// <summary>
        /// 获取或设置病历最后修改人姓名
        /// </summary>
        public string ModifierName
        {
            get { return this.m_szModifierName; }
            set { this.m_szModifierName = value; }
        }
        /// <summary>
        /// 获取或设置病历最后修改时间
        /// </summary>
        public DateTime ModifyTime
        {
            get { return this.m_dtModifyTime; }
            set { this.m_dtModifyTime = value; }
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
        /// 获取或设置审签状态描述
        /// </summary>
        public string AuditStatus
        {
            get { return this.m_szAuditStatus; }
            set { this.m_szAuditStatus = value; }
        }
        /// <summary>
        /// 获取或设置检查结果描述
        /// </summary>
        public DateTime VisitTime
        {
            get { return this.m_dtVisitTime; }
            set { this.m_dtVisitTime = value; }
        }

        public AuditCheckResult()
        {
            this.m_dtDocTime = this.DefaultTime;
            this.m_dtModifyTime = this.DefaultTime;
        }

        /// <summary>
        /// 更新三级审签审核结果对应的病历信息
        /// </summary>
        /// <param name="docInfo">病历信息</param>
        internal void UpdateDocInfo(MedDocInfo docInfo)
        {
            if (docInfo == null)
            {
                this.m_szDocID = string.Empty;
                this.m_szCreatorID = string.Empty;
                this.m_szCreatorName = string.Empty;
                this.m_dtDocTime = this.DefaultTime;
                this.m_szDocTitle = string.Empty;
                this.m_szDocTypeID = string.Empty;
                this.m_szDocTypeName = string.Empty;
                this.m_szModifierID = string.Empty;
                this.m_szModifierName = string.Empty;
                this.m_dtModifyTime = this.DefaultTime;
                this.m_szPatientID = string.Empty;
                this.m_szPatientName = string.Empty;
                this.m_szVisitID = string.Empty;
                this.m_dtVisitTime = this.DefaultTime;
                this.m_szResultDesc = string.Empty;
                this.m_szAuditStatus = string.Empty;
            }
            else
            {
                this.m_szDocID = docInfo.DOC_ID;
                this.m_szCreatorID = docInfo.CREATOR_ID;
                this.m_szCreatorName = docInfo.CREATOR_NAME;
                this.m_dtDocTime = docInfo.DOC_TIME;
                this.m_szDocTitle = docInfo.DOC_TITLE;
                this.m_szDocTypeID = docInfo.DOC_TITLE;
                this.m_szDocTypeName = docInfo.DOC_TITLE;
                this.m_szModifierID = docInfo.MODIFIER_ID;
                this.m_szModifierName = docInfo.MODIFIER_NAME;
                this.m_dtModifyTime = docInfo.MODIFY_TIME;
                this.m_szPatientID = docInfo.PATIENT_ID;
                this.m_szPatientName = docInfo.PATIENT_NAME;
                this.m_szVisitID = docInfo.VISIT_ID;
                this.m_dtVisitTime = docInfo.VISIT_TIME;
                this.m_szResultDesc = docInfo.StatusDesc;
                if (docInfo.SIGN_CODE == SystemData.SignState.CREATOR_SAVE || docInfo.SIGN_CODE == ""//新增SignCode为空字符串的条件
                    || (docInfo.SIGN_CODE == SystemData.SignState.CREATOR_COMMIT)) 
                    this.m_szAuditStatus = SystemData.SignState.CREATOR_SAVE_CH;
                else if (docInfo.SIGN_CODE == SystemData.SignState.CREATOR_COMMIT)
                    this.m_szAuditStatus = SystemData.SignState.CREATOR_COMMIT_CH;
                else if (docInfo.SIGN_CODE == SystemData.SignState.PARENT_COMMIT)
                    this.m_szAuditStatus = SystemData.SignState.PARENT_COMMIT_CH;
                else if (docInfo.SIGN_CODE == SystemData.SignState.SUPER_COMMIT)
                    this.m_szAuditStatus = SystemData.SignState.SUPER_COMMIT_CH;
                else if (docInfo.SIGN_CODE == SystemData.SignState.PARENT_ROLLBACK)
                    this.m_szAuditStatus = SystemData.SignState.PARENT_ROLLBACK_CH;
                else if (docInfo.SIGN_CODE == SystemData.SignState.SUPER_ROLLBACK)
                    this.m_szAuditStatus = SystemData.SignState.SUPER_ROLLBACK_CH;
                else if (docInfo.SIGN_CODE == SystemData.SignState.QC_ROLLBACK)
                    this.m_szAuditStatus = SystemData.SignState.QC_ROLLBACK_CH;
            }
        }

        public override string ToString()
        {
            return string.Format("DocID={0};DocTitle={1};DocTime={2};AuditState={3};ResultDesc={4};"
                , this.m_szDocID, this.m_szDocTitle, this.m_dtDocTime, this.m_szAuditStatus, this.m_szResultDesc);
        }
    }
}
