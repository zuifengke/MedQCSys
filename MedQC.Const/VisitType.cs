using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 就诊类型常量
        /// </summary>
        public struct VisitType
        {
            /// <summary>
            /// 住院
            /// </summary>
            public const string IP = "IP";
            /// <summary>
            /// 门诊
            /// </summary>
            public const string OP = "OP";
        }
    }
}
