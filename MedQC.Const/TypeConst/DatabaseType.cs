using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>s
        /// 数据库类型常量
        /// </summary>
        public struct DatabaseType
        {
            /// <summary>
            /// ORACLE数据库类型
            /// </summary>
            public const string ORACLE = "ORACLE";
            /// <summary>
            /// SQLSERVER数据库类型
            /// </summary>
            public const string SQLSERVER = "SQLSERVER";
        }
    }
}
