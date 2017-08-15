// ***********************************************************
// 病历质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{

    public class ScriptDataAccess : DBAccessBase
    {
        private static ScriptDataAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static ScriptDataAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ScriptDataAccess();
                return ScriptDataAccess.m_Instance;
            }
        }

        /// <summary>
        /// 根据脚本ID号和病历类型ID号，获取脚本可执行文件数据
        /// </summary>
        /// <param name="szScriptID">脚本ID号</param>
        /// <param name="byteScriptData">脚本数据信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetScriptData(string szScriptID, ref byte[] byteScriptData)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = SystemData.ScriptDataTable.SCRIPT_DATA;
            string szCondition = string.Format("{0}='{1}'", SystemData.ScriptDataTable.SCRIPT_ID, szScriptID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                , szField, SystemData.DataTable.SCRIPT_DATA, szCondition, SystemData.ScriptDataTable.SCRIPT_ID);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (!dataReader.IsDBNull(0)) byteScriptData = (byte[])dataReader.GetValue(0);
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("AutoCalc.GetScriptData", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 保存一条脚本可执行文件数据
        /// </summary>
        /// <param name="szScriptID">脚本ID号</param>
        /// <param name="byteScriptData">脚本可执行文件数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveScriptData(string szScriptID, byte[] byteScriptData)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1}", SystemData.ScriptDataTable.SCRIPT_ID, SystemData.ScriptDataTable.SCRIPT_DATA);
            string szValue = string.Format("'{0}',{1}", szScriptID, base.MedQCAccess.GetSqlParamName("SCRIPT_DATA"));
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.SCRIPT_DATA, szField, szValue);

            DbParameter[] pmi = new DbParameter[1];
            pmi[0] = new DbParameter("SCRIPT_DATA", byteScriptData == null ? new byte[0] : byteScriptData);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("AutoCalc.SaveScriptData", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("AutoCalc.SaveScriptData", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新一条脚本可执行文件数据
        /// </summary>
        /// <param name="szScriptID">脚本ID号</param>
        /// <param name="byteScriptData">脚本可执行文件数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateScriptData(string szScriptID, byte[] byteScriptData)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}={1}"
                , SystemData.ScriptDataTable.SCRIPT_DATA, base.MedQCAccess.GetSqlParamName("SCRIPT_DATA"));
            string szCondition = string.Format("{0}='{1}'", SystemData.ScriptDataTable.SCRIPT_ID, szScriptID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.SCRIPT_DATA, szField, szCondition);

            DbParameter[] pmi = new DbParameter[1];
            pmi[0] = new DbParameter("SCRIPT_DATA", byteScriptData == null ? new byte[0] : byteScriptData);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("AutoCalc.UpdateScriptData", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("AutoCalc.UpdateScriptData", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除指定的脚本配置ID和病历文档类型ID的脚本配置信息
        /// </summary>
        /// <param name="szScriptID">脚本配置ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteScriptData(string szScriptID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.ScriptConfigTable.SCRIPT_ID, szScriptID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.SCRIPT_DATA, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("AutoCalc.DeleteScriptData", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("AutoCalc.DeleteScriptData", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
    }
}