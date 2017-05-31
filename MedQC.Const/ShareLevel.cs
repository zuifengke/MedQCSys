using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 共享水平常量
        /// </summary>
        public struct ShareLevel
        {
            /// <summary>
            /// 全院共享"H"
            /// </summary>
            public const string HOSPITAL = "H";
            /// <summary>
            /// 科室共享"D"
            /// </summary>
            public const string DEPART = "D";
            /// <summary>
            /// 个人私有"P"
            /// </summary>
            public const string PERSONAL = "P";
        }

    }
}
