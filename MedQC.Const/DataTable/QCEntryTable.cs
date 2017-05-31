using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 质控原子规则ENTRY表字段常量
        /// </summary>
        public struct QCEntryTable
        {
            /// <summary>
            /// 原子规则Entry的ID字段
            /// </summary>
            public const string ENTRY_ID = "ENTRY_ID";
            /// <summary>
            /// 原子规则Entry的名称字段
            /// </summary>
            public const string ENTRY_NAME = "ENTRY_NAME";
            /// <summary>
            /// 原子规则Entry的类型字段
            /// </summary>
            public const string ENTRY_TYPE = "ENTRY_TYPE";
            /// <summary>
            /// 原子规则Entry的描述字段
            /// </summary>
            public const string ENTRY_DESC = "ENTRY_DESC";
            /// <summary>
            /// 原子规则Entry的值和实际数据的运算符字段
            /// </summary>
            public const string OPERATOR = "OPERATOR";
            /// <summary>
            /// 原子规则Entry的值字段
            /// </summary>
            public const string ENTRY_VALUE = "ENTRY_VALUE";
            /// <summary>
            /// 原子规则Entry的值的数据类型字段
            /// </summary>
            public const string VALUE_TYPE = "VALUE_TYPE";
        }
    }
}
