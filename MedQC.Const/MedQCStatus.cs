using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病质控审查状态常量
        /// </summary>
        public struct MedQCStatus
        {
            /// <summary>
            /// 未审查
            /// </summary>
            public const string NO_CHECK = "-1";
            /// <summary>
            /// 已审查
            /// </summary>
            public const string CHECKED = "0";
            /// <summary>
            /// 审查通过
            /// </summary>
            public const string PASS = "1";
            /// <summary>
            /// 审查后存在问题
            /// </summary>
            public const string EXIST_BUG = "2";
            /// <summary>
            /// 审查后存在严重问题
            /// </summary>
            public const string SERIOUS_BUG = "3";
        }
    }
}
