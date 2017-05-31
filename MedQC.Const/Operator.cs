using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 系统涉及的运算符常量
        /// </summary>
        public struct Operator
        {
            /// <summary>
            /// 等于
            /// </summary>
            public const string EQUAL = "等于";
            /// <summary>
            /// 小于
            /// </summary>
            public const string LESS = "小于";
            /// <summary>
            /// 大于
            /// </summary>
            public const string MORE = "大于";
            /// <summary>
            /// 小于等于
            /// </summary>
            public const string NOMORE = "小于等于";
            /// <summary>
            /// 大于等于
            /// </summary>
            public const string NOLESS = "大于等于";
            /// <summary>
            /// 不等于
            /// </summary>
            public const string NOEQUAL = "不等于";
            /// <summary>
            /// 包含
            /// </summary>
            public const string CONTAINS = "包含";
            /// <summary>
            /// 不包含
            /// </summary>
            public const string NOCONTAINS = "不包含";
            /// <summary>
            /// 并且
            /// </summary>
            public const string AND = "并且";
            /// <summary>
            /// 或者
            /// </summary>
            public const string OR = "或者";
        }

    }
}
