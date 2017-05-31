using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 添加质检问题的医生类型
        /// </summary>
        public struct IssuedType
        {
            /// <summary>
            /// 普通医生
            /// </summary>
            public const int NORMAL = 0;
            /// <summary>
            /// 专家医生
            /// </summary>
            public const int SPECIAL = 1;
        }
    }
}
