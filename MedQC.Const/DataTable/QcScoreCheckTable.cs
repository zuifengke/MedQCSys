using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 质控自动扣分规则配置表结构
        /// </summary>
        public struct QcScoreCheckTable
        {
            /// <summary>
            /// 自动扣分规则ID号
            /// </summary>
            public const string CONFIG_ID = "CONFIG_ID";
            /// <summary>
            /// 病历类型ID号
            /// </summary>
            public const string DOC_TYPE_ID = "DOC_TYPE_ID";
            /// <summary>
            /// 病历类型名
            /// </summary>
            public const string DOC_TYPE_NAME = "DOC_TYPE_NAME";
            /// <summary>
            /// 病历内元素名
            /// </summary>
            public const string ELEMENT = "ELEMENT";
            /// <summary>
            /// 关联逻辑性规则
            /// </summary>
            public const string QC_RULE = "QC_RULE";
            /// <summary>
            /// 关联逻辑性规则ID号
            /// </summary>
            public const string QC_RULE_ID = "QC_RULE_ID";
            /// <summary>
            /// 扣分依据
            /// </summary>
            public const string CONFIG_DESC = "CONFIG_DESC";
            /// <summary>
            /// 扣分值
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 内容自动扣分类型 0 ：内容逻辑性错误 1：元素内容为空
            /// </summary>
            public const string CONFIG_TYPE = "CONFIG_TYPE";
            /// <summary>
            /// 排序值
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 是否有效
            /// </summary>
            public const string IS_VALID = "IS_VALID";
        }
    }
}
