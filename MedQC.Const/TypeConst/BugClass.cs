using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    { /// <summary>
      /// 文档状态数据
      /// </summary>
        public struct BugClass
        {
            /// <summary>
            /// 警告
            /// </summary>
            public const int WARNING = 0;
            /// <summary>
            /// 错误
            /// </summary>
            public const int ERROR = 1;

        }
    }
}
