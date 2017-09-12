using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    
    /// <summary>
    /// 报表类型信息类
    /// </summary>
    public class TempletType : DbTypeBase, ICloneable
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
        public object Clone()
        {
            TempletType docTypeInfo = new TempletType();
            GlobalMethods.Reflect.CopyProperties(this, docTypeInfo);
            return docTypeInfo;
        }

        public override string ToString()
        {
            return this.m_szDocTypeName;
        }

        public string MakeDocTypeID()
        {
            return GlobalMethods.Misc.Random(100000, 999999).ToString();
        }

        private byte[] m_byteTempletData = null;

        /// <summary>
        /// 获取或设置模板二进制数据
        /// </summary>
        public byte[] ByteTempletData
        {
            get { return this.m_byteTempletData; }
            set { this.m_byteTempletData = value; }
        }
    }

}
