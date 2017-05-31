using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病历时效事件源配置信息表
        /// </summary>
        public struct TimeEventTable
        {
            /// <summary>
            /// 事件编号字段
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 事件名称字段
            /// </summary>
            public const string EVENT_NAME = "EVENT_NAME";
            /// <summary>
            /// 配置的事件源SQL语句名称
            /// </summary>
            public const string SQL_TEXT = "SQL_TEXT";
            /// <summary>
            /// SQL字符串中的条件字段
            /// </summary>
            public const string SQL_CONDITON = "SQL_CONDITON";
            /// <summary>
            /// 依赖事件编号字段
            /// </summary>
            public const string DEPEND_EVENT = "DEPEND_EVENT";
        }
    }
}
