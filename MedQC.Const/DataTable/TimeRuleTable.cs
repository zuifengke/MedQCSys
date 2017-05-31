using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病历时效规则配置信息表
        /// </summary>
        public struct TimeRuleTable
        {
            /// <summary>
            /// 配置ID字段
            /// </summary>
            public const string RULE_ID = "RULE_ID";
            /// <summary>
            /// 关联事件ID字段
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 应完成文档类型ID号列表字段
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 应完成文档类型名称列表字段
            /// </summary>
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";
            /// <summary>
            /// 应完成文档类型名称别名字段
            /// </summary>
            public const string DOCTYPE_ALIAS = "DOCTYPE_ALIAS";
            /// <summary>
            /// 最晚完成期限字段
            /// </summary>
            public const string WRITTEN_PERIOD = "WRITTEN_PERIOD";
            /// <summary>
            /// 是否循环检查时效字段
            /// </summary>
            public const string IS_REPEAT = "IS_REPEAT";
            /// <summary>
            /// 是否启用此时效名称
            /// </summary>
            public const string IS_VALID = "IS_VALID";
            /// <summary>
            /// 时效规则对应的质控扣分
            /// </summary>
            public const string QC_SCORE = "QC_SCORE";
            /// <summary>
            /// 时效定义名称描述字符串字段
            /// </summary>
            public const string RULE_DESC = "RULE_DESC";
            /// <summary>
            /// 时效规则在规则列表中的排序
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 单项否决
            /// </summary>
            public const string Is_VETO = "ISVETO";
        }
    }
}
