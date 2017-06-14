using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 扣分类型
        /// </summary>
        public struct PointType
        {
            /// <summary>
            /// 自动
            /// </summary>
            public const int AutoMatic = 0;
            /// <summary>
            /// 人工
            /// </summary>
            public const int Artific = 1;
        }

    }
}
