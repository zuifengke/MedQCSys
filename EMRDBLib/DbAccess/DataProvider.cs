// ***********************************************************
// 数据库访问基础方法类之数据提供者类型枚举
// Creator:YangMingkun  Date:2009-6-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 数据提供者类型枚举
    /// </summary>
    public enum DataProvider
    {
        /// <summary>
        /// ODBC(0)
        /// </summary>
        Odbc = 0,
        /// <summary>
        /// SQLClient(1)
        /// </summary>
        SqlClient = 1,
        /// <summary>
        /// OLEDB(2)
        /// </summary>
        OleDb = 2,
        /// <summary>
        /// .NET自带的ORACLE驱动(3)
        /// </summary>
        OracleClient = 3,
        /// <summary>
        /// ORACLE提供的ODPNET(4)
        /// </summary>
        ODPNET = 4,
        /// <summary>
        /// ORACLE提供的ODPNET Managed(5)
        /// </summary>
        ODPNET_Managed = 5
    }
}
