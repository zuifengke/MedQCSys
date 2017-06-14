using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 程序启动参数有关常量
        /// </summary>
        public struct StartupArgs
        {
            /// <summary>
            /// 启动参数中的组间分隔符
            /// </summary>
            public const string GROUP_SPLIT = "|";
            /// <summary>
            /// 启动参数中的组内字段分隔符
            /// </summary>
            public const string FIELD_SPLIT = ";";
            /// <summary>
            /// 启动参数字符串内的被转义字符
            /// </summary>
            public const string ESCAPED_CHAR = " ";
            /// <summary>
            /// 启动参数字符串内的转义符
            /// </summary>
            public const string ESCAPE_CHAR = "$";
        }
    }
}
