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
using EMRDBLib.DbAccess;

namespace EMRDBLib
{
    public class NurDocCommonAccess : DBAccessBase
    {
        private static NurDocCommonAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static NurDocCommonAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new NurDocCommonAccess();
                return m_Instance;
            }
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
            if (base.NurDocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            try
            {
                result = base.NurDocAccess.ExecuteDataSet(sql, CommandType.Text);
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
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.HerenHisAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            if (sqlarray == null)
                sqlarray = new string[0];
            foreach (string sql in sqlarray)
            {
                try
                {
                    if (!isProc)
                        base.HerenHisAccess.ExecuteNonQuery(sql, CommandType.Text);
                    else
                        base.HerenHisAccess.ExecuteNonQuery(sql, CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    base.HerenHisAccess.AbortTransaction();
                    LogManager.Instance.WriteLog("CommonAccess.ExecuteUpdate", new string[] { "sql" }, new object[] { sql }, ex);
                    return SystemData.ReturnValue.EXCEPTION;
                }
            }
            base.HerenHisAccess.CommitTransaction(true);
            return SystemData.ReturnValue.OK;
        }
    }
}
