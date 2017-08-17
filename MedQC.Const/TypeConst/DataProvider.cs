using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 数据库驱动类型常量
        /// </summary>
        public struct DataProvider
        {
            /// <summary>
            /// .NET提供的SqlClient驱动类型
            /// </summary>
            public const string SQLCLIENT = "System.Data.SqlClient";
            /// <summary>
            /// .NET提供的Oracle驱动类型
            /// </summary>
            public const string ORACLE = "System.Data.OracleClient";
            /// <summary>
            /// .NET提供的OleDb驱动类型
            /// </summary>
            public const string OLEDB = "System.Data.OleDb";
            /// <summary>
            /// .NET提供的ODBC驱动类型
            /// </summary>
            public const string ODBC = "System.Data.Odbc";
            /// <summary>
            /// Oracle提供的ODPNET驱动类型
            /// </summary>
            public const string ODPNET = "Oracle.DataAccess.Client";
            /// <summary>
            /// Oracle提供的ODPNET驱动类型
            /// </summary>
            public const string ODPNET_Managed = "Oracle.ManagedDataAccess.Client";
        }
    }
}
