// ***********************************************************
// 数据库访问基础方法类之数据库类型枚举
// Creator:YangMingkun  Date:2009-6-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// SQLSERVER数据库
        /// </summary>
        SQLSERVER = 0,
        /// <summary>
        /// ORACLE数据库
        /// </summary>
        ORACLE = 1,
        /// <summary>
        /// 微软ACCESS
        /// </summary>
        ACCESS = 2
    }
}
