using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    
    /// <summary>
    /// 报表类型信息类
    /// </summary>
    public class ReportType : DbTypeBase, ICloneable
    {
        private string m_szReportTypeID = string.Empty;

        /// <summary>
        /// 获取或设置报表类型的ID
        /// </summary>
        public string ReportTypeID
        {
            get { return this.m_szReportTypeID; }
            set { this.m_szReportTypeID = value; }
        }

        private int m_nReportTypeNo = 0;

        /// <summary>
        /// 获取或设置该报表类型在列表中的排序
        /// </summary>
        public int ReportTypeNo
        {
            get { return this.m_nReportTypeNo; }
            set { this.m_nReportTypeNo = value; }
        }

        private string m_szReportTypeName = string.Empty;

        /// <summary>
        /// 获取或设置文件类型的显示中文名
        /// </summary>
        public string ReportTypeName
        {
            get { return this.m_szReportTypeName; }
            set { this.m_szReportTypeName = value; }
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

        private bool m_bIsValid = true;

        /// <summary>
        /// 获取或设置标识当前报表类型是否有效
        /// </summary>
        public bool IsValid
        {
            get { return this.m_bIsValid; }
            set { this.m_bIsValid = value; }
        }

        private bool m_bIsFolder = false;

        /// <summary>
        /// 获取或设置标识当前报表类型是否是目录
        /// </summary>
        public bool IsFolder
        {
            get { return this.m_bIsFolder; }
            set { this.m_bIsFolder = value; }
        }

        private string m_szParentID = string.Empty;

        /// <summary>
        /// 获取或设置该报表型对应的目录ID
        /// </summary>
        public string ParentID
        {
            get { return this.m_szParentID; }
            set { this.m_szParentID = value; }
        }

        private DateTime m_dtModifyTime;

        /// <summary>
        /// 获取或设置报表类型信息的修改时间
        /// </summary>
        public DateTime ModifyTime
        {
            get { return this.m_dtModifyTime; }
            set { this.m_dtModifyTime = value; }
        }

        public ReportType()
        {
            this.m_dtModifyTime = base.DefaultTime;
        }


        public override string ToString()
        {
            return this.m_szReportTypeName;
        }

        public string MakeReportypeID()
        {
            return GlobalMethods.Misc.Random(100000, 999999).ToString();
        }

        #region ICloneable 成员

        public object Clone()
        {
            ReportType reportTypeInfo = new ReportType();
            GlobalMethods.Reflect.CopyProperties(this, reportTypeInfo);
            return reportTypeInfo;
        }

        #endregion
    }

}
