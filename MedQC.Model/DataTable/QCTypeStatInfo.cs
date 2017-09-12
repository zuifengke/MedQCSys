using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 质控问题按问题类型统计信息
    /// </summary>
    public class QCTypeStatInfo : DbTypeBase
    {
        private string m_szQuestionType = string.Empty;
        /// <summary>
        /// 获取或设置问题类型
        /// </summary>
        public string QuestionType
        {
            get { return m_szQuestionType; }
            set { m_szQuestionType = value; }
        }
        private string m_szQuestionMsg = string.Empty;
        /// <summary>
        /// 获取或设置问题内容
        /// </summary>
        public string QuestionMsg
        {
            get { return m_szQuestionMsg; }
            set { m_szQuestionMsg = value; }
        }
        private string m_szCount = string.Empty;
        /// <summary>
        /// 获取或设置问题统计个数
        /// </summary>
        public string Count
        {
            get { return m_szCount; }
            set { m_szCount = value; }
        }

        private string m_szDeptName = string.Empty;
        /// <summary>
        /// 获取或设置病人所在科室名称
        /// </summary>
        public string DeptName
        {
            get { return m_szDeptName; }
            set { m_szDeptName = value; }
        }
    }
}
