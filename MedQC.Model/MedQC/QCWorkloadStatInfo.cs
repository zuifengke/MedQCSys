using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 质控问题按工作量统计信息
    /// </summary>
    public class QCWorkloadStatInfo : DbTypeBase
    {
        private string m_szCheckerID = string.Empty;
        /// <summary>
        /// 获取或设置检查者姓名
        /// </summary>
        public string CheckerID
        {
            get { return this.m_szCheckerID; }
            set { this.m_szCheckerID = value; }
        }
        private string m_szCheckerName = string.Empty;
        /// <summary>
        /// 获取或设置检查者姓名
        /// </summary>
        public string CheckerName
        {
            get { return this.m_szCheckerName; }
            set { this.m_szCheckerName = value; }
        }
        private string m_szNumOfDoc = string.Empty;
        /// <summary>
        /// 获取或设置病案数
        /// </summary>
        public string NumOfDoc
        {
            get { return this.m_szNumOfDoc; }
            set { this.m_szNumOfDoc = value; }
        }
        private string m_szNumOfCheck = string.Empty;
        /// <summary>
        /// 获取或设置检查例次
        /// </summary>
        public string NumOfCheck
        {
            get { return this.m_szNumOfCheck; }
            set { this.m_szNumOfCheck = value; }
        }
        private string m_szNumOfQuestion = string.Empty;
        /// <summary>
        /// 获取或设置问题条目数
        /// </summary>
        public string NumOfQuestion
        {
            get { return this.m_szNumOfQuestion; }
            set { this.m_szNumOfQuestion = value; }
        }
        private string m_szDeptCode = string.Empty;
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        private string m_szDeptName = string.Empty;
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
    }
}
