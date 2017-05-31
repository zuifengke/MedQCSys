using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 医疗文档信息类
    /// </summary>
    [System.Serializable]
    public class MedDocInfo : DbTypeBase
    {
        private string m_szDocID;           //文档编号
        private string m_szDocTypeID;       //文档类型代码
        private string m_szDocTitle;        //文档标题
        private DateTime m_dtDocTime;       //文档创建时间
        private string m_szDocSetID;        //文档集编号
        private int m_nDocVersion;          //文档版本号
        private string m_szCreatorID;       //文档创建人ID
        private string m_szCreatorName;     //文档创建人姓名
        private string m_szModifierID;      //文档修改人ID
        private string m_szModifierName;    //文档修改人姓名
        private DateTime m_dtModifyTime;    //文档修改时间
        private string m_szPatientID;       //病人编号
        private string m_szPatientName;     //病人姓名
        private string m_szVisitID;         //就诊号
        private DateTime m_dtVisitTime;     //就诊时间
        private string m_szVisitType;       //就诊类型
        private string m_szDeptCode;        //创建科室代码
        private string m_szDeptName;        //创建科室
        private string m_szSignCode;        //签名代码
        private string m_szConfidCode;      //机密等级
        private int m_nOrderValue;          //文档排序值
        private bool m_bNeedCombin;         //是否需合并        
        private string m_szFileName;        //文件名
        private string m_szFilePath;        //文件路径
        private string m_szFileType;        //文件类型
        private DateTime m_dtRecordTime;    //实际记录时间
        private string m_szStatusDesc;      //文档状态描述
        private DateTime m_dtRequestSignDate; //经治医生签名时间
        private DateTime m_dtParentSignDate;  //上级医生签名时间
        private DateTime m_dtSuperSignDate;   //主任医生签名时间
        private string[] m_szDocContent;    //文档内容
        private string m_szTemplet_ID;      //模板ID
        /// <summary>
        /// 文档信息类
        /// </summary>
        /// <remarks></remarks>
        public MedDocInfo()
        {
            this.Initialize();
        }

        /// <summary>
        /// 文档信息类成员初始化过程(设置其默认值)
        /// </summary>
        /// <remarks></remarks>
        public void Initialize()
        {
            this.m_szDocID = string.Empty;
            this.m_szDocTypeID = string.Empty;
            this.m_szDocTitle = string.Empty;
            this.m_dtDocTime = this.DefaultTime;
            this.m_szDocSetID = string.Empty;
            this.m_nDocVersion = 0;
            this.m_szCreatorID = string.Empty;
            this.m_szCreatorName = string.Empty;
            this.m_szModifierID = string.Empty;
            this.m_szModifierName = string.Empty;
            this.m_dtModifyTime = this.DefaultTime;
            this.m_szPatientID = string.Empty;
            this.m_szPatientName = string.Empty;
            this.m_szVisitID = string.Empty;
            this.m_dtVisitTime = this.DefaultTime;
            this.m_szVisitType = string.Empty;
            this.m_szDeptCode = string.Empty;
            this.m_szDeptName = string.Empty;
            this.m_szSignCode = string.Empty;
            this.m_szConfidCode = string.Empty;
            this.m_nOrderValue = -1;
            this.m_bNeedCombin = false;
            this.m_szFileType = string.Empty;
            this.m_szFileName = string.Empty;
            this.m_szFilePath = string.Empty;
            this.m_dtRecordTime = this.DefaultTime;
            this.m_szStatusDesc = string.Empty;
        }

        public override string ToString()
        {
            return this.m_szDocTitle;
        }

        /// <summary>
        /// 获取或设置文档编号
        /// </summary>
        public string DOC_ID
        {
            get { return this.m_szDocID; }
            set { this.m_szDocID = value; }
        }
        /// <summary>
        /// 获取或设置文档类型代码
        /// </summary>
        public string DOC_TYPE
        {
            get { return this.m_szDocTypeID; }
            set { this.m_szDocTypeID = value; }
        }
        /// <summary>
        /// 获取或设置文档的显示标题
        /// </summary>
        public string DOC_TITLE
        {
            get { return this.m_szDocTitle; }
            set { this.m_szDocTitle = value; }
        }
        /// <summary>
        /// 获取或设置文档的创建时间
        /// </summary>
        public DateTime DOC_TIME
        {
            get { return this.m_dtDocTime; }
            set { this.m_dtDocTime = value; }
        }
        /// <summary>
        /// 获取或设置文档所属文档集编号
        /// </summary>
        public string DOC_SETID
        {
            get { return this.m_szDocSetID; }
            set { this.m_szDocSetID = value; }
        }
        /// <summary>
        /// 获取或设置文档版本号
        /// </summary>
        public int DOC_VERSION
        {
            get { return this.m_nDocVersion; }
            set { this.m_nDocVersion = value; }
        }
        /// <summary>
        /// 获取或设置作者ID
        /// </summary>
        public string CREATOR_ID
        {
            get { return this.m_szCreatorID; }
            set { this.m_szCreatorID = value; }
        }
        /// <summary>
        /// 获取或设置作者姓名
        /// </summary>
        public string CREATOR_NAME
        {
            get { return this.m_szCreatorName; }
            set { this.m_szCreatorName = value; }
        }
        /// <summary>
        /// 获取或设置文档修改人编号
        /// </summary>
        public string MODIFIER_ID
        {
            get { return this.m_szModifierID; }
            set { this.m_szModifierID = value; }
        }
        /// <summary>
        /// 获取或设置文档修改人姓名
        /// </summary>
        public string MODIFIER_NAME
        {
            get { return this.m_szModifierName; }
            set { this.m_szModifierName = value; }
        }
        /// <summary>
        /// 获取或设置文档的修改时间
        /// </summary>
        public DateTime MODIFY_TIME
        {
            get { return this.m_dtModifyTime; }
            set { this.m_dtModifyTime = value; }
        }
        /// <summary>
        /// 获取或设置病人唯一编号
        /// </summary>
        public string PATIENT_ID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }
        /// <summary>
        /// 获取或设置病人姓名
        /// </summary>
        public string PATIENT_NAME
        {
            get { return this.m_szPatientName; }
            set { this.m_szPatientName = value; }
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
        /// 获取或设置就诊时间
        /// </summary>
        public DateTime VISIT_TIME
        {
            get { return this.m_dtVisitTime; }
            set { this.m_dtVisitTime = value; }
        }
        /// <summary>
        /// 获取或设置就诊类型(OP-门诊，IP-住院)
        /// </summary>
        public string VISIT_TYPE
        {
            get { return this.m_szVisitType; }
            set { this.m_szVisitType = value; }
        }
        /// <summary>
        /// 获取或设置文档创建科室代码
        /// </summary>
        public string DEPT_CODE
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        /// <summary>
        /// 获取或设置文档创建科室
        /// </summary>
        public string DEPT_NAME
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        /// <summary>
        /// 获取或设置签名代码
        /// </summary>
        public string SIGN_CODE
        {
            get { return this.m_szSignCode; }
            set { this.m_szSignCode = value; }
        }
        /// <summary>
        /// 获取或设置机密等级
        /// </summary>
        public string CONFID_CODE
        {
            get { return this.m_szConfidCode; }
            set { this.m_szConfidCode = value; }
        }
        /// <summary>
        /// 获取或设置文档排序值
        /// </summary>
        public int ORDER_VALUE
        {
            get { return this.m_nOrderValue; }
            set { this.m_nOrderValue = value; }
        }
        /// <summary>
        /// 获取或设置是否需要合并
        /// </summary>
        public bool NeedCombin
        {
            get { return this.m_bNeedCombin; }
            set { this.m_bNeedCombin = value; }
        }
        /// <summary>
        /// 获取或设置文档文件类型
        /// </summary>
        public string EMR_TYPE
        {
            get { return this.m_szFileType; }
            set { this.m_szFileType = value; }
        }
        /// <summary>
        /// 获取或设置文档文件名(对于新病历,为空)
        /// </summary>
        public string FileName
        {
            get { return this.m_szFileName; }
            set { this.m_szFileName = value; }
        }
        /// <summary>
        /// 获取或设置文档存放路径(对于新病历,为空)
        /// </summary>
        public string FilePath
        {
            get { return this.m_szFilePath; }
            set { this.m_szFilePath = value; }
        }
        /// <summary>
        /// 获取或设置实际记录时间
        /// </summary>
        public DateTime RECORD_TIME
        {
            get { return this.m_dtRecordTime; }
            set { this.m_dtRecordTime = value; }
        }
        /// <summary>
        /// 获取或设置文档状态描述
        /// </summary>
        public string StatusDesc
        {
            get { return this.m_szStatusDesc; }
            set { this.m_szStatusDesc = value; }
        }

        /// <summary>
        /// 经治医生签名时间
        /// </summary>
        public DateTime RequestSignDate
        {
            get { return this.m_dtRequestSignDate; }
            set { this.m_dtRequestSignDate = value; }
        }
        /// <summary>
        /// 上级医生签名时间
        /// </summary>
        public DateTime ParentSignDate
        {
            get { return this.m_dtParentSignDate; }
            set { this.m_dtParentSignDate = value; }
        }
        /// <summary>
        /// 主任医生签名时间
        /// </summary>
        public DateTime SuperSignDate
        {
            get { return this.m_dtSuperSignDate; }
            set { this.m_dtSuperSignDate = value; }
        }

        /// <summary>
        /// 模板ID
        /// </summary>
        public string TEMPLET_ID
        {
            get { return this.m_szTemplet_ID; }
            set { this.m_szTemplet_ID = value; }
        }

    }
}
