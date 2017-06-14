using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 质控状态
        /// </summary>
        public struct QcResult
        {
            /// <summary>
            /// 通过
            /// </summary>
            public const int Pass = 1;
            /// <summary>
            /// 未通过
            /// </summary>
            public const int UnPass = 0;

        }
    }
}
