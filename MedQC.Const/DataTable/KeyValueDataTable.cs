using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 键值对表
        /// </summary>
        public struct KeyValueDataTable
        {
            /// <summary>
            /// 键名
            /// </summary>
            public const string DATA_KEY = "DATA_KEY";
            /// <summary>
            /// 键值
            /// </summary>
            public const string DATA_VALUE = "DATA_VALUE";
            /// <summary>
            /// 键值对分组
            /// </summary>
            public const string DATA_GROUP = "DATA_GROUP";
            /// <summary>
            /// 扩展字段1
            /// </summary>
            public const string VALUE1 ="VALUE1";
            /// <summary>
            /// 主键
            /// </summary>
            public const string ID = "ID";
        }
    }
}
