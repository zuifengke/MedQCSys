using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 科室病案统计比较
    /// </summary>
    public class DeptDocScoreInfo : DbTypeBase
    {
        private string m_szDeptCode = string.Empty;
        /// <summary>
        /// 获取或设置科室代码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        private string m_szDeptName = string.Empty;
        /// <summary>
        /// 获取或设置科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        private float m_fScoreANum = 0f;
        /// <summary>
        /// 获取或设置甲级病案数
        /// </summary>
        public float ScoreANum
        {
            get { return this.m_fScoreANum; }
            set { this.m_fScoreANum = value; }
        }
        private float m_fScoreBNum = 0f;
        /// <summary>
        /// 获取或设置乙级病案数
        /// </summary>
        public float ScoreBNum
        {
            get { return this.m_fScoreBNum; }
            set { this.m_fScoreBNum = value; }
        }
        private float m_fScoreCNum = 0f;
        /// <summary>
        /// 获取或设置丙级病案数
        /// </summary>
        public float ScoreCNum
        {
            get { return this.m_fScoreCNum; }
            set { this.m_fScoreCNum = value; }
        }
    }

}
