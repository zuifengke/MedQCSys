using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 质控规则表字段常量
        /// </summary>
        public struct QCRuleTable
        {
            /// <summary>
            /// 规则ID字段
            /// </summary>
            public const string RULE_ID = "RULE_ID";
            /// <summary>
            /// 条件规则1字段
            /// </summary>
            public const string RULE_ID1 = "RULE_ID1";
            /// <summary>
            /// 条件规则运算符字段
            /// </summary>
            public const string OPERATOR = "OPERATOR";
            /// <summary>
            /// 条件规则2字段
            /// </summary>
            public const string RULE_ID2 = "RULE_ID2";
            /// <summary>
            /// 原子规则ID字段
            /// </summary>
            public const string ENTRY_ID = "ENTRY_ID";
            /// <summary>
            /// 结果规则ID字段
            /// </summary>
            public const string REF_RULE = "REF_RULE";
            /// <summary>
            /// 缺陷等级字段
            /// </summary>
            public const string BUG_LEVEL = "BUG_LEVEL";
            /// <summary>
            /// 缺陷描述字段
            /// </summary>
            public const string BUG_DESC = "BUG_DESC";
            /// <summary>
            /// 缺陷在客户端界面的响应方式字段
            /// </summary>
            public const string RESPONSE = "RESPONSE";
        }
    }
}
