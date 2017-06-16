// ***********************************************************
// 数据库访问层通用操作有关的数据访问接口.
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class CommonAccess : DBAccessBase
    {
        private static CommonAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static CommonAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new CommonAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <param name="dtSysDate">数据库服务器时间</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetServerTime(ref DateTime dtSysDate)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = null;
            if (base.MedQCAccess.DatabaseType == DatabaseType.SQLSERVER)
            {
                szSQL = string.Format(SystemData.SQL.SELECT, "CONVERT(VARCHAR(20), GETDATE(), 20)");
            }
            else if (base.MedQCAccess.DatabaseType == DatabaseType.ORACLE)
            {
                szSQL = string.Format(SystemData.SQL.SELECT_FROM, "SYSDATE", "DUAL");
            }
            else
            {
                dtSysDate = DateTime.Now;
                return SystemData.ReturnValue.OK;
            }
            object oRet = null;
            try
            {
                oRet = base.MedQCAccess.ExecuteScalar(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.GetServerTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            try
            {
                dtSysDate = DateTime.Parse(oRet.ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.GetServerTime", new string[] { "szSQL" }, new object[] { szSQL }
                    , string.Format("无法将“{0}”转换为DateTime!", oRet), ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 执行指定的SQL语句查询
        /// </summary>
        /// <param name="sql">查询的SQL语句</param>
        /// <param name="result">查询返回的结果集</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short ExecuteQuery(string sql, out DataSet result)
        {
            result = null;
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            try
            {
                result = base.MedQCAccess.ExecuteDataSet(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.ExecuteQuery", new string[] { "sql" }, new object[] { sql }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 执行指定的一系列的SQL语句更新
        /// </summary>
        /// <param name="isProc">传入的SQL是否是存储过程</param>
        /// <param name="sqlArray">查询的SQL语句集合</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short ExecuteUpdate(bool isProc, params string[] sqlarray)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.MedQCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            if (sqlarray == null)
                sqlarray = new string[0];
            foreach (string sql in sqlarray)
            {
                try
                {
                    if (!isProc)
                        base.MedQCAccess.ExecuteNonQuery(sql, CommandType.Text);
                    else
                        base.MedQCAccess.ExecuteNonQuery(sql, CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    base.MedQCAccess.AbortTransaction();
                    LogManager.Instance.WriteLog("CommonAccess.ExecuteUpdate", new string[] { "sql" }, new object[] { sql }, ex);
                    return SystemData.ReturnValue.EXCEPTION;
                }
            }
            base.MedQCAccess.CommitTransaction(true);
            return SystemData.ReturnValue.OK;
        }
    }
}
