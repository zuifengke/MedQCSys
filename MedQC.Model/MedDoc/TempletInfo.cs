using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 文档模板信息类
    /// </summary>
    [System.Serializable]
    public class TempletInfo : DbTypeBase
    {
        private string m_szTempletID;       //模扳编号
        private string m_szDocTypeID;       //文档类型代码
        private string m_szTempletName;     //模板的描述名用户自定义录入内容
        private string m_szShareLevel;      //共享的水平，P-为个人，D-为科室，H-为公用等
        private string m_szCreatorID;       //创建者的编号
        private string m_szCreatorName;     //创建者的名称
        private DateTime m_dtCreateTime;    //创建时间
        private DateTime m_dtModifyTime;    //模扳最近一次修改时间
        private string m_szDeptCode;        //所属科室代码
        private string m_szDeptName;        //所属科室名称
        private bool m_bIsValid;            //模板是否可用
        private string m_szParentID;        //标识当前模板或者文件夹的父节点ID
        private bool m_bIsFolder;           //标识当前记录是否为文件夹,1文件夹
        private TempletCheckStatus m_eCheckStatus;     //标识当前模板审核状态
        private string m_szCheckerID;       //模板审核人ID
        private string m_szCheckerName;     //模板审核人姓名
        private DateTime m_dtCheckTime;     //模板审核时间
        private string m_szCheckMessage;    //模板审核结果信息
        private string m_szSuperCheckerID;  //上级审核人ID
        private string m_szSuperCheckerName;//上级审核人姓名
        private DateTime m_dtSuperCheckTime;  //上级审核时间

        /// <summary>
        /// 默认无参构造函数
        /// </summary>
        /// <remarks></remarks>
        public TempletInfo()
        {
            this.Initialize();
        }

        /// <summary>
        /// 过程：初始化各属性值(设置其默认值)
        /// </summary>
        /// <remarks></remarks>
        public void Initialize()
        {
            this.m_szTempletID = string.Empty;
            this.m_szDocTypeID = string.Empty;
            this.m_szTempletName = string.Empty;
            this.m_szShareLevel = SystemData.ShareLevel.DEPART;
            this.m_szCreatorID = string.Empty;
            this.m_szCreatorName = string.Empty;
            this.m_dtCreateTime = this.DefaultTime;
            this.m_dtModifyTime = this.DefaultTime;
            this.m_szDeptCode = string.Empty;
            this.m_szDeptName = string.Empty;
            this.m_bIsValid = true;
            this.m_szParentID = string.Empty;
            this.m_bIsFolder = false;
            this.m_eCheckStatus = TempletCheckStatus.None;
            this.m_szCheckerID = string.Empty;
            this.m_szCheckerName = string.Empty;
            this.m_dtCheckTime = this.DefaultTime;
            this.m_szCheckMessage = string.Empty;
            this.m_szSuperCheckerID = string.Empty;
            this.m_szSuperCheckerName = string.Empty;
            this.m_dtSuperCheckTime = this.DefaultTime;
        }
        /// <summary>
        /// 获取或设置模板编号
        /// </summary>
        public string TempletID
        {
            get { return this.m_szTempletID; }
            set { this.m_szTempletID = value; }
        }
        /// <summary>
        /// 获取或设置模板所适用的文档类型编号
        /// </summary>
        public string DocTypeID
        {
            get { return this.m_szDocTypeID; }
            set { this.m_szDocTypeID = value; }
        }
        /// <summary>
        /// 获取或设置模板类型描述，用户自定义输入内容
        /// </summary>
        public string TempletName
        {
            get { return this.m_szTempletName; }
            set { this.m_szTempletName = value; }
        }
        /// <summary>
        /// 获取或设置模板的共享水平，P-个人，D-科室，H-公用等
        /// </summary>
        public string ShareLevel
        {
            get { return this.m_szShareLevel; }
            set { this.m_szShareLevel = value; }
        }
        /// <summary>
        /// 获取或设置模板的创建者编号
        /// </summary>
        public string CreatorID
        {
            get { return this.m_szCreatorID; }
            set { this.m_szCreatorID = value; }
        }
        /// <summary>
        /// 获取或设置模板的创建者名称
        /// </summary>
        public string CreatorName
        {
            get { return this.m_szCreatorName; }
            set { this.m_szCreatorName = value; }
        }
        /// <summary>
        /// 获取或设置模板文件的创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return this.m_dtCreateTime; }
            set { this.m_dtCreateTime = value; }
        }
        /// <summary>
        /// 获取或设置模板的最后更新时间
        /// </summary>
        public DateTime ModifyTime
        {
            get { return this.m_dtModifyTime; }
            set { this.m_dtModifyTime = value; }
        }
        /// <summary>
        /// 获取或设置所属科室代码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        /// <summary>
        /// 获取或设置所属科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        /// <summary>
        /// 获取或设置模板是否可用
        /// </summary>
        public bool IsValid
        {
            get { return this.m_bIsValid; }
            set { this.m_bIsValid = value; }
        }
        /// <summary>
        /// 获取或设置当前模板或者文件夹的父节点ID
        /// </summary>
        public string ParentID
        {
            get { return this.m_szParentID; }
            set { this.m_szParentID = value; }
        }
        /// <summary>
        /// 获取或设置当前记录是否为文件夹
        /// </summary>
        public bool IsFolder
        {
            get { return this.m_bIsFolder; }
            set { this.m_bIsFolder = value; }
        }
        /// <summary>
        /// 获取或设置模板审核状态
        /// </summary>
        public TempletCheckStatus CheckStatus
        {
            get { return this.m_eCheckStatus; }
            set { this.m_eCheckStatus = value; }
        }
        /// <summary>
        /// 获取或设置模板审核人ID
        /// </summary>
        public string CheckerID
        {
            get { return this.m_szCheckerID; }
            set { this.m_szCheckerID = value; }
        }
        /// <summary>
        /// 获取或设置模板审核人姓名
        /// </summary>
        public string CheckerName
        {
            get { return this.m_szCheckerName; }
            set { this.m_szCheckerName = value; }
        }
        /// <summary>
        /// 获取或设置模板审核时间
        /// </summary>
        public DateTime CheckTime
        {
            get { return this.m_dtCheckTime; }
            set { this.m_dtCheckTime = value; }
        }
        /// <summary>
        /// 获取或设置模板审核结果信息
        /// </summary>
        public string CheckMessage
        {
            get { return this.m_szCheckMessage; }
            set { this.m_szCheckMessage = value; }
        }
        /// <summary>
        /// 获取或设置上级审核者ID
        /// </summary>
        public string SuperCheckerID
        {
            get { return this.m_szSuperCheckerID; }
            set { this.m_szSuperCheckerID = value; }
        }
        /// <summary>
        /// 获取或设置上级审核者姓名
        /// </summary>
        public string SuperCheckerName
        {
            get { return this.m_szSuperCheckerName; }
            set { this.m_szSuperCheckerName = value; }
        }
        /// <summary>
        /// 获取或设置上级审核时间
        /// </summary>
        public DateTime SuperCheckTime
        {
            get { return this.m_dtSuperCheckTime; }
            set { this.m_dtSuperCheckTime = value; }
        }

        public override string ToString()
        {
            return this.m_szTempletName;
        }

        public static TempletCheckStatus GetCheckStatus(string status)
        {
            switch (status)
            {
                case "1": return TempletCheckStatus.HasBug;
                case "2": return TempletCheckStatus.Affirm;
                case "3": return TempletCheckStatus.Passed;
                case "4": return TempletCheckStatus.Saved;
                case "5": return TempletCheckStatus.DeptPassed;
                default: return TempletCheckStatus.None;
            }
        }
        public static string GetCheckStatus(TempletCheckStatus status)
        {
            switch (status)
            {
                case TempletCheckStatus.HasBug: return "1";
                case TempletCheckStatus.Affirm: return "2";
                case TempletCheckStatus.Passed: return "3";
                case TempletCheckStatus.Saved: return "4";
                case TempletCheckStatus.DeptPassed: return "5";
                default: return "0";
            }
        }
        public TempletInfo Clone()
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bf.Serialize(ms, this);
            ms.Position = 0;
            return bf.Deserialize(ms) as TempletInfo;
        }
    }

}
