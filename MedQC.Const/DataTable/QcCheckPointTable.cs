using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 自动核查缺陷点配置表
        /// </summary>
        public struct QcCheckPointTable
        {
            public const string CHECK_POINT_ID = "CHECK_POINT_ID";
            public const string CHECK_POINT_CONTENT = "CHECK_POINT_CONTENT";
            public const string HANDLER_COMMAND = "HANDLER_COMMAND";
            public const string MSG_DICT_CODE = "MSG_DICT_CODE";
            public const string MSG_DICT_MESSAGE = "MSG_DICT_MESSAGE";
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";
            public const string IS_VALID = "IS_VALID";
            public const string SCORE = "SCORE";
            public const string ORDER_VALUE = "ORDER_VALUE";
            public const string WRITTEN_PERIOD = "WRITTEN_PERIOD";
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            public const string EXPRESSION = "EXPRESSION";
            public const string EVENT_ID = "EVENT_ID";
            public const string IS_REPEAT = "IS_REPEAT";
            public const string ELEMENT_NAME = "ELEMENT_NAME";
            /// <summary>
            /// 检查类型：时效性 完整性 一致性 合理性
            /// </summary>
            public const string CHECK_TYPE = "CHECK_TYPE";
        }
    }
}
