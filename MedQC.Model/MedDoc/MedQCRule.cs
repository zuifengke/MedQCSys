using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{


    /// <summary>
    /// 文档质控规则对象定义
    /// </summary>
    [System.Serializable]
    public class MedQCRule : DbTypeBase, ICloneable
    {
        private string m_szRuleID = string.Empty;       //规则ID
        private string m_szRuleID1 = string.Empty;      //条件规则1
        private string m_szOperator = string.Empty;     //条件规则运算符
        private string m_szRuleID2 = string.Empty;      //条件规则2
        private string m_szEntryID = string.Empty;      //原子规则ID
        private string m_szRefRuleID = string.Empty;    //结果规则ID
        private int m_nBugLevel = 0;                    //缺陷等级
        private string m_szBugDesc = string.Empty;      //缺陷描述
        private string m_szResponse = string.Empty;     //缺陷在客户端界面的响应方式
        private string m_szRuleID1Desc = string.Empty;  //条件1描述
        private string m_szRuleID2Desc = string.Empty;  //条件2描述
        private string m_szRefRuleDesc = string.Empty;  //结果条件描述

        /// <summary>
        /// 获取或设置规则ID
        /// </summary>
        public string RuleID
        {
            get { return this.m_szRuleID; }
            set { this.m_szRuleID = value; }
        }
        /// <summary>
        /// 获取或设置条件规则1
        /// </summary>
        public string RuleID1
        {
            get { return this.m_szRuleID1; }
            set { this.m_szRuleID1 = value; }
        }
        /// <summary>
        /// 获取或设置条件规则1描述.
        /// 注意：该属性客户端临时使用,不持久化
        /// </summary>
        public string RuleID1Desc
        {
            get { return this.m_szRuleID1Desc; }
            set { this.m_szRuleID1Desc = value; }
        }
        /// <summary>
        /// 获取或设置条件规则运算符
        /// </summary>
        public string Operator
        {
            get { return this.m_szOperator; }
            set { this.m_szOperator = value; }
        }
        /// <summary>
        /// 获取或设置条件规则2
        /// </summary>
        public string RuleID2
        {
            get { return this.m_szRuleID2; }
            set { this.m_szRuleID2 = value; }
        }
        /// <summary>
        /// 获取或设置条件规则1描述.
        /// 注意：该属性客户端临时使用,不持久化
        /// </summary>
        public string RuleID2Desc
        {
            get { return this.m_szRuleID2Desc; }
            set { this.m_szRuleID2Desc = value; }
        }
        /// <summary>
        /// 获取或设置原子规则ID
        /// </summary>
        public string EntryID
        {
            get { return this.m_szEntryID; }
            set { this.m_szEntryID = value; }
        }
        /// <summary>
        /// 获取或设置结果规则ID
        /// </summary>
        public string RefRuleID
        {
            get { return this.m_szRefRuleID; }
            set { this.m_szRefRuleID = value; }
        }
        /// <summary>
        /// 获取或设置结果规则描述.
        /// 注意：该属性客户端临时使用,不持久化
        /// </summary>
        public string RefRuleDesc
        {
            get { return this.m_szRefRuleDesc; }
            set { this.m_szRefRuleDesc = value; }
        }
        /// <summary>
        /// 获取或设置缺陷等级
        /// </summary>
        public int BugLevel
        {
            get { return this.m_nBugLevel; }
            set { this.m_nBugLevel = value; }
        }
        /// <summary>
        /// 获取或设置缺陷描述
        /// </summary>
        public string BugDesc
        {
            get { return this.m_szBugDesc; }
            set { this.m_szBugDesc = value; }
        }
        /// <summary>
        /// 获取或设置缺陷在客户端界面的响应方式
        /// </summary>
        public string Response
        {
            get { return this.m_szResponse; }
            set { this.m_szResponse = value; }
        }

        public override string ToString()
        {
            return this.m_szBugDesc;
        }

        public object Clone()
        {
            MedQCRule qcRule = new MedQCRule();
            qcRule.RuleID = this.m_szRuleID;
            qcRule.RuleID1 = this.m_szRuleID1;
            qcRule.Operator = this.m_szOperator;
            qcRule.RuleID2 = this.m_szRuleID2;
            qcRule.EntryID = this.m_szEntryID;
            qcRule.RefRuleID = this.m_szRefRuleID;
            qcRule.BugLevel = this.m_nBugLevel;
            qcRule.BugDesc = this.m_szBugDesc;
            qcRule.Response = this.m_szResponse;
            qcRule.RuleID1Desc = this.m_szRuleID1Desc;
            qcRule.RuleID2Desc = this.m_szRuleID2Desc;
            qcRule.RefRuleDesc = this.m_szRefRuleDesc;
            return qcRule;
        }

        public string MakeRuleID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("R{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
