using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 存储过程操作标识
        /// </summary>
        public struct OperFlag
        {
            /// <summary>
            /// 新增
            /// </summary>
            public const string INSERT = "1";
            /// <summary>
            /// 更新
            /// </summary>
            public const string UPDATE = "2";
            /// <summary>
            /// 删除
            /// </summary>
            public const string DELETE = "3";
        }
    }
}
