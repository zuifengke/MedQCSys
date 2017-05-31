using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    public enum SortMode
    {
        /// <summary>
        /// 不排序
        /// </summary>
        None = 0,

        /// <summary>
        /// 升序排列
        /// </summary>
        Ascending = 1,

        /// <summary>
        /// 降序排列
        /// </summary>
        Descending = 2
    }
    /// <summary>
    /// 获取或设置表单打印模式
    /// </summary>
    public enum FormPrintMode
    {
        /// <summary>
        /// 都不打印
        /// </summary>
        None = 0,

        /// <summary>
        /// 仅打印表单
        /// </summary>
        Form = 1,

        /// <summary>
        /// 仅打印已写列表
        /// </summary>
        List = 2,

        /// <summary>
        /// 表单和列表都打印
        /// </summary>
        FormAndList = 3
    }
    /// <summary>
    /// 文档类型信息类
    /// </summary>
    public class DocTypeInfo : DbTypeBase, ICloneable
    {
        private string m_szDocTypeID = string.Empty;

        /// <summary>
        /// 获取或设置文档类型的ID，采用和CDA兼容的LONIC文档编码作为文档的ID
        /// </summary>
        public string DocTypeID
        {
            get { return this.m_szDocTypeID; }
            set { this.m_szDocTypeID = value; }
        }

        private int m_nDocTypeNo = 0;

        /// <summary>
        /// 获取或设置该文档类型在列表中的排序
        /// </summary>
        public int DocTypeNo
        {
            get { return this.m_nDocTypeNo; }
            set { this.m_nDocTypeNo = value; }
        }

        private string m_szDocTypeName = string.Empty;

        /// <summary>
        /// 获取或设置文件类型的显示中文名
        /// </summary>
        public string DocTypeName
        {
            get { return this.m_szDocTypeName; }
            set { this.m_szDocTypeName = value; }
        }

        private string m_szApplyEnv = string.Empty;

        /// <summary>
        /// 获取或设置应用环境
        /// </summary>
        public string ApplyEnv
        {
            get { return this.m_szApplyEnv; }
            set { this.m_szApplyEnv = value; }
        }

        private string m_szParentID = string.Empty;

        /// <summary>
        /// 获取或设置该文档类型对应的目录ID
        /// </summary>
        public string ParentID
        {
            get { return this.m_szParentID; }
            set { this.m_szParentID = value; }
        }

        private bool m_bIsRepeated = true;

        /// <summary>
        /// 获取或设置该类型的文档是否可重复
        /// </summary>
        public bool IsRepeated
        {
            get { return this.m_bIsRepeated; }
            set { this.m_bIsRepeated = value; }
        }

        private bool m_bIsValid = true;

        /// <summary>
        /// 获取或设置标识当前文档类型是否有效
        /// </summary>
        public bool IsValid
        {
            get { return this.m_bIsValid; }
            set { this.m_bIsValid = value; }
        }

        private bool m_bIsVisible = true;

        /// <summary>
        /// 获取或设置标识当前文档类型是否界面可见
        /// </summary>
        public bool IsVisible
        {
            get { return this.m_bIsVisible; }
            set { this.m_bIsVisible = value; }
        }

        private FormPrintMode m_nPrintMode = FormPrintMode.None;

        /// <summary>
        /// 获取或设置标识当前文档模板打印模式
        /// </summary>
        public FormPrintMode PrintMode
        {
            get { return this.m_nPrintMode; }
            set { this.m_nPrintMode = value; }
        }

        private bool m_bIsFolder = false;

        /// <summary>
        /// 获取或设置标识当前文档类型是否是目录
        /// </summary>
        public bool IsFolder
        {
            get { return this.m_bIsFolder; }
            set { this.m_bIsFolder = value; }
        }

        private DateTime m_dtModifyTime;

        /// <summary>
        /// 获取或设置文档类型信息的修改时间
        /// </summary>
        public DateTime ModifyTime
        {
            get { return this.m_dtModifyTime; }
            set { this.m_dtModifyTime = value; }
        }

        private string m_szSortColumn = string.Empty;

        /// <summary>
        /// 获取或设置文档列表默认排序列
        /// </summary>
        public string SortColumn
        {
            get { return this.m_szSortColumn; }
            set { this.m_szSortColumn = value; }
        }

        private SortMode m_iSortMode = SortMode.None;

        /// <summary>
        /// 获取或设置文档列表默认排序方式
        /// </summary>
        public SortMode SortMode
        {
            get { return this.m_iSortMode; }
            set { this.m_iSortMode = value; }
        }

        private string m_szSchemaID = null;

        /// <summary>
        /// 获取或设置文档所属表格列配置方案ID
        /// </summary>
        public string SchemaID
        {
            get { return this.m_szSchemaID; }
            set { this.m_szSchemaID = value; }
        }

        /// <summary>
        /// 获取或设置该文档类型对应的主文档类型ID
        /// </summary>
        public string HostTypeID { get; set; }

        /// <summary>
        /// 获取或设置文档应用的环境，比如门诊 OP、病区 IP
        /// </summary>
        public string ApplyEvn { get; set; }

        /// <summary>
        /// 获取或设置哪些文档是哪些用户有权限创建的， ALL 表示所有
        /// DOC 表示医生 NUR 表示护士 CIS表示其它应用系统 ADM 管理人员等
        /// </summary>
        public string DocRight { get; set; }
        public string SignFlag { get; set; }
        public bool CanCreate { get; set; }
        /// <summary>
        /// 获取或设置文档页首是否独立纸张打印
        /// </summary>
        public bool IsTotalPage { get; set; }
        /// <summary>
        /// 获取或设置该文档类型是否是结构化的
        /// </summary>
        public bool IsStruct { get; set; }

        /// <summary>
        /// 获取或设置文档页尾是否独立纸张打印
        /// </summary>
        public bool IsEndEmpty { get; set; }
        /// <summary>
        /// 获取或设置文档是否自动合并显示
        /// </summary>
        public bool NeedCombin { get; set; }

        /// <summary>
        /// 获取或设置病历是否自动生成标题
        /// </summary>
        public bool AutoMakeTitle { get; set; }
        /// <summary>
        /// 获取或设置标识当前文档类型是否有效
        /// </summary>
        public bool IsHostType
        {
            get { return GlobalMethods.Misc.IsEmptyString(this.HostTypeID); }
        }
        /// <summary>
        /// 获取或设置该文档类型在列表中的排序
        /// </summary>
        public int OrderValue { get; set; }
        public DocTypeInfo()
        {
            this.m_dtModifyTime = base.DefaultTime;
            this.SignFlag = string.Empty;
            this.DocRight = string.Empty;
        }
        public override string ToString()
        {
            return this.m_szDocTypeName;
        }

        public string MakeDocTypeID()
        {
            return GlobalMethods.Misc.Random(100000, 999999).ToString();
        }
    }

}
