using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 手术操作字典视图
        /// </summary>
        public struct OperationDictView
        {
            /// <summary>
            /// 手术编码
            /// </summary>
            public const string OPERATION_CODE = "OPERATION_CODE";
            /// <summary>
            /// 手术名称
            /// </summary>
            public const string OPERATION_NAME = "OPERATION_NAME";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
        }
    }
}
