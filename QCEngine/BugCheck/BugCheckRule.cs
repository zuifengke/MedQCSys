// ***********************************************************
// 病历文档系统文档质控引擎,质控规则信息类
// Creator:YangMingkun  Date:2009-8-18
// Copyright:supconhealth
// ***********************************************************
using System;
using EMRDBLib;
namespace MedDocSys.QCEngine.BugCheck
{
    internal class BugCheckRule
    {
        private string m_szRuleID = string.Empty;
        /// <summary>
        /// 获取或设置规则ID
        /// </summary>
        public string RuleID
        {
            get { return this.m_szRuleID; }
            set { this.m_szRuleID = value; }
        }

        private BugCheckRule m_subRule1 = null;
        /// <summary>
        /// 获取或设置条件规则1
        /// </summary>
        public BugCheckRule SubRule1
        {
            get { return this.m_subRule1; }
            set { this.m_subRule1 = value; }
        }

        private string m_szOperator = string.Empty;
        /// <summary>
        /// 获取或设置条件规则运算符
        /// </summary>
        public string Operator
        {
            get { return this.m_szOperator; }
            set { this.m_szOperator = value; }
        }

        private BugCheckRule m_subRule2 = null;
        /// <summary>
        /// 获取或设置条件规则2
        /// </summary>
        public BugCheckRule SubRule2
        {
            get { return this.m_subRule2; }
            set { this.m_subRule2 = value; }
        }

        private BugCheckEntry m_ruleEntry = null;
        /// <summary>
        /// 获取或设置原子规则ID
        /// </summary>
        public BugCheckEntry RuleEntry
        {
            get { return this.m_ruleEntry; }
            set { this.m_ruleEntry = value; }
        }

        private BugCheckRule m_refRule = null;
        /// <summary>
        /// 获取或设置结果规则ID
        /// </summary>
        public BugCheckRule RefRule
        {
            get { return this.m_refRule; }
            set { this.m_refRule = value; }
        }

        private string m_szBugKey = string.Empty;
        /// <summary>
        /// 获取或设置缺陷关键字
        /// </summary>
        public string BugKey
        {
            get { return this.m_szBugKey; }
            set { this.m_szBugKey = value; }
        }

        private BugLevel m_bugLevel = BugLevel.Error;
        /// <summary>
        /// 获取或设置缺陷等级
        /// </summary>
        public BugLevel BugLevel
        {
            get { return this.m_bugLevel; }
            set { this.m_bugLevel = value; }
        }

        private string m_szBugDesc = string.Empty;
        /// <summary>
        /// 获取或设置缺陷描述
        /// </summary>
        public string BugDesc
        {
            get { return this.m_szBugDesc; }
            set { this.m_szBugDesc = value; }
        }

        private int m_nOccurCount = 0;
        /// <summary>
        /// 获取或设置规则的出现次数,也即缺陷出现次数
        /// </summary>
        public int OccurCount
        {
            get { return this.m_nOccurCount; }
            set { this.m_nOccurCount = value; }
        }

        private string m_szResponse = string.Empty;
        /// <summary>
        /// 获取或设置缺陷在客户端界面的响应方式
        /// </summary>
        public string Response
        {
            get { return this.m_szResponse; }
            set { this.m_szResponse = value; }
        }

        /// <summary>
        /// 执行当前规则
        /// </summary>
        public void Execute()
        {
            //RuleEntry不等于null说明是原子规则
            if (this.RuleEntry != null)
            {
                this.BugKey = this.RuleEntry.EntryValue;
                this.OccurCount = this.RuleEntry.OccurCount;
                return;
            }

            bool bSubRule1Result = true;
            if (this.SubRule1 != null)
            {
                this.SubRule1.Execute();
                bSubRule1Result = !(this.SubRule1.OccurCount <= 0);
            }

            bool bSubRule2Result = true;
            if (this.SubRule2 != null)
            {
                this.SubRule2.Execute();
                bSubRule2Result = !(this.SubRule2.OccurCount <= 0);
            }

            bool bConditionResult = bSubRule1Result;
            if (this.Operator == SystemData.Operator.AND)
            {
                bConditionResult = (bSubRule1Result && bSubRule2Result);
            }
            else if (this.Operator == SystemData.Operator.OR)
            {
                bConditionResult = (bSubRule1Result || bSubRule2Result);
            }

            if (!bConditionResult)
            {
                this.OccurCount = 0;
                this.BugKey = string.Empty;
                return;
            }

            //RefRule等于null说明是中间规则,而不是最终规则
            if (this.RefRule == null)
            {
                this.BugKey = string.Empty;
                this.OccurCount++;
            }
            else
            {
                this.RefRule.Execute();
                this.BugKey = this.RefRule.BugKey;
                this.OccurCount = this.RefRule.OccurCount;
            }
        }
    }
}
