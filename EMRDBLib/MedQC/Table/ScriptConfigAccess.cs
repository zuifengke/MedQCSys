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

    public class ScriptConfigAccess : DBAccessBase
    {
        private static ScriptConfigAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static ScriptConfigAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ScriptConfigAccess();
                return ScriptConfigAccess.m_Instance;
            }
        }

        public short GetScriptConfigs(ref List<ScriptConfig> lstScriptConfigs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATE_TIME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATOR_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATOR_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.IS_FOLDER);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFIER_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFIER_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.PARENT_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_LANG);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_NO);
            sbField.AppendFormat("{0}", SystemData.ScriptConfigTable.SCRIPT_USING);

            string szCondition = string.Format("1=1");
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.SCRIPT_CONFIG, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstScriptConfigs == null)
                    lstScriptConfigs = new List<ScriptConfig>();
                do
                {
                    ScriptConfig ScriptConfig = new ScriptConfig();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.ScriptConfigTable.CREATE_TIME:
                                ScriptConfig.CREATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.ScriptConfigTable.CREATOR_ID:
                                ScriptConfig.CREATOR_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.ScriptConfigTable.CREATOR_NAME:
                                ScriptConfig.CREATOR_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.ScriptConfigTable.IS_FOLDER:
                                ScriptConfig.IS_FOLDER = decimal.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.ScriptConfigTable.PARENT_ID:
                                ScriptConfig.PARENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.ScriptConfigTable.MODIFIER_ID:
                                ScriptConfig.MODIFIER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.ScriptConfigTable.MODIFIER_NAME:
                                ScriptConfig.MODIFIER_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.ScriptConfigTable.MODIFY_TIME:
                                ScriptConfig.MODIFY_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.ScriptConfigTable.SCRIPT_ID:
                                ScriptConfig.SCRIPT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.ScriptConfigTable.SCRIPT_LANG:
                                ScriptConfig.SCRIPT_LANG = dataReader.GetString(i);
                                break;
                            case SystemData.ScriptConfigTable.SCRIPT_USING:
                                ScriptConfig.SCRIPT_USING = dataReader.GetString(i);
                                break;
                            case SystemData.ScriptConfigTable.SCRIPT_NO:
                                ScriptConfig.SCRIPT_NO = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.ScriptConfigTable.SCRIPT_NAME:
                                ScriptConfig.SCRIPT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            default: break;
                        }
                    }
                    lstScriptConfigs.Add(ScriptConfig);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
    }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        public short GetScriptConfig(string szScriptConfigID, ref ScriptConfig ScriptConfig)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szScriptConfigID))
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATE_TIME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATOR_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATOR_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.IS_FOLDER);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFIER_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFIER_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.PARENT_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_LANG);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_SOURCE);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_NO);
            sbField.AppendFormat("{0}", SystemData.ScriptConfigTable.SCRIPT_USING);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szScriptConfigID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.ScriptConfigTable.SCRIPT_ID
                    , szScriptConfigID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.SCRIPT_CONFIG, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (ScriptConfig == null)
                    ScriptConfig = new ScriptConfig();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.ScriptConfigTable.CREATE_TIME:
                            ScriptConfig.CREATE_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.ScriptConfigTable.CREATOR_ID:
                            ScriptConfig.CREATOR_ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.ScriptConfigTable.CREATOR_NAME:
                            ScriptConfig.CREATOR_NAME = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.ScriptConfigTable.IS_FOLDER:
                            ScriptConfig.IS_FOLDER = decimal.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.ScriptConfigTable.PARENT_ID:
                            ScriptConfig.PARENT_ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.ScriptConfigTable.MODIFIER_ID:
                            ScriptConfig.MODIFIER_ID = dataReader.GetString(i);
                            break;
                        case SystemData.ScriptConfigTable.MODIFIER_NAME:
                            ScriptConfig.MODIFIER_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.ScriptConfigTable.MODIFY_TIME:
                            ScriptConfig.MODIFY_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.ScriptConfigTable.SCRIPT_ID:
                            ScriptConfig.SCRIPT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.ScriptConfigTable.SCRIPT_LANG:
                            ScriptConfig.SCRIPT_LANG = dataReader.GetString(i);
                            break;
                        case SystemData.ScriptConfigTable.SCRIPT_USING:
                            ScriptConfig.SCRIPT_USING = dataReader.GetString(i);
                            break;
                        case SystemData.ScriptConfigTable.SCRIPT_NO:
                            ScriptConfig.SCRIPT_NO = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.ScriptConfigTable.SCRIPT_NAME:
                            ScriptConfig.SCRIPT_NAME = dataReader.GetValue(i).ToString();
                            break;
                        default: break;
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        public short GetScriptSource(string szScriptID, ref string szScriptSource)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.ScriptConfigTable.SCRIPT_ID, szScriptID);
            string szField = string.Format("{0},{1}"
                ,SystemData.ScriptConfigTable.SCRIPT_SOURCE
                ,SystemData.ScriptConfigTable.SCRIPT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataTable.SCRIPT_CONFIG, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    LogManager.Instance.WriteLog("ScriptAccess.GetScriptScriptFromDB", new string[] { "szSQL" }, new object[] { szSQL }, "没有查询到记录!");
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (!dataReader.IsDBNull(0))
                    szScriptSource = dataReader.GetValue(0).ToString();
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }


        /// <summary>
        /// 保存系统缺省模板到数据库服务器
        /// </summary>
        /// <param name="szScriptID">报表类型ID</param>
        /// <param name="byteScriptData">系统缺省模板</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short SaveScriptDataToDB(ScriptConfig scriptConfig, string szScriptSource,byte[]  byteScriptData)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}={1}", SystemData.ScriptConfigTable.MODIFY_TIME, base.MedQCAccess.GetSqlTimeFormat(scriptConfig.MODIFY_TIME));

            DbParameter[] pmi = null;
            if (szScriptSource != null)
            {
                szField = string.Format("{0},{1}={2}", szField, SystemData.ScriptConfigTable.SCRIPT_SOURCE, base.MedQCAccess.GetSqlParamName("SCRIPT_DATA"));

                pmi = new DbParameter[1];
                pmi[0] = new DbParameter("SCRIPT_DATA", szScriptSource);
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.ScriptConfigTable.SCRIPT_ID, scriptConfig.SCRIPT_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.SCRIPT_CONFIG, szField, szCondition);
            if (!base.MedQCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                base.MedQCAccess.AbortTransaction();
                LogManager.Instance.WriteLog("", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("ScriptAccess.SaveSystemScriptToDB", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            short result =ScriptDataAccess.Instance.UpdateScriptData(scriptConfig.SCRIPT_ID, byteScriptData);
            if (result != SystemData.ReturnValue.OK)
            {
                base.MedQCAccess.AbortTransaction();
                return result;
            }
            base.MedQCAccess.CommitTransaction(true);
            return SystemData.ReturnValue.OK;
        }
        public short Insert(ScriptConfig scriptConfig)
        {
            if (scriptConfig == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { scriptConfig }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (scriptConfig.SCRIPT_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATE_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(scriptConfig.CREATE_TIME));
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.IS_FOLDER);
            sbValue.AppendFormat("{0},", scriptConfig.IS_FOLDER.ToString());
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATOR_ID);
            sbValue.AppendFormat("'{0}',", scriptConfig.CREATOR_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.CREATOR_NAME);
            sbValue.AppendFormat("'{0}',", scriptConfig.CREATOR_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.PARENT_ID);
            sbValue.AppendFormat("'{0}',", scriptConfig.PARENT_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_ID);
            sbValue.AppendFormat("'{0}',", scriptConfig.SCRIPT_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFIER_ID);
            sbValue.AppendFormat("'{0}',", scriptConfig.MODIFIER_ID);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFIER_NAME);
            sbValue.AppendFormat("'{0}',", scriptConfig.MODIFIER_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.MODIFY_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(scriptConfig.MODIFY_TIME));
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_LANG);
            sbValue.AppendFormat("'{0}',", scriptConfig.SCRIPT_LANG);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_NAME);
            sbValue.AppendFormat("'{0}',", scriptConfig.SCRIPT_NAME);
            sbField.AppendFormat("{0},", SystemData.ScriptConfigTable.SCRIPT_USING);
            sbValue.AppendFormat("'{0}',", scriptConfig.SCRIPT_USING);
            sbField.AppendFormat("{0}", SystemData.ScriptConfigTable.SCRIPT_NO);
            sbValue.AppendFormat("{0}", scriptConfig.SCRIPT_NO);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.SCRIPT_CONFIG, sbField.ToString(), sbValue.ToString());
            if (!base.MedQCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                base.MedQCAccess.AbortTransaction();
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                base.MedQCAccess.AbortTransaction();
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            short result =ScriptDataAccess.Instance.SaveScriptData(scriptConfig.SCRIPT_ID, null);
            if (result != SystemData.ReturnValue.OK)
            {
                base.MedQCAccess.AbortTransaction();
                return result;
            }
            base.MedQCAccess.CommitTransaction(true);
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 更新一条整改通知单
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(ScriptConfig scriptConfig)
        {
            if (scriptConfig == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { scriptConfig }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}={1},"
                , SystemData.ScriptConfigTable.CREATE_TIME, base.MedQCAccess.GetSqlTimeFormat(scriptConfig.CREATE_TIME));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.ScriptConfigTable.CREATOR_ID, scriptConfig.CREATOR_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.ScriptConfigTable.CREATOR_NAME, scriptConfig.CREATOR_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.ScriptConfigTable.IS_FOLDER, scriptConfig.IS_FOLDER);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.ScriptConfigTable.MODIFIER_ID, scriptConfig.MODIFIER_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.ScriptConfigTable.MODIFIER_NAME, scriptConfig.MODIFIER_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.ScriptConfigTable.MODIFY_TIME, base.MedQCAccess.GetSqlTimeFormat(scriptConfig.MODIFY_TIME));
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.ScriptConfigTable.PARENT_ID, scriptConfig.PARENT_ID);
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.ScriptConfigTable.SCRIPT_LANG, scriptConfig.SCRIPT_LANG);
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.ScriptConfigTable.SCRIPT_NAME, scriptConfig.SCRIPT_NAME);
            sbField.AppendFormat("{0}={1},"
               , SystemData.ScriptConfigTable.SCRIPT_NO, scriptConfig.SCRIPT_NO);
            sbField.AppendFormat("{0}='{1}'"
               , SystemData.ScriptConfigTable.SCRIPT_USING, scriptConfig.SCRIPT_USING);
            string szCondition = string.Format("{0}='{1}'", SystemData.ScriptConfigTable.SCRIPT_ID, scriptConfig.SCRIPT_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.SCRIPT_CONFIG, sbField.ToString(), szCondition);
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条整改通知单
        /// </summary>
        /// <param name="szRuleID">自动核查结果ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szScriptConfigID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szScriptConfigID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szScriptConfigID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.ScriptConfigTable.SCRIPT_ID, szScriptConfigID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.SCRIPT_CONFIG, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        public short DeleteAll(List<string> lstScriptConfigID)
        {
            try
            {
                if (base.MedQCAccess == null)
                    return SystemData.ReturnValue.PARAM_ERROR;

                //开始数据库事务
                if (!base.MedQCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                    return SystemData.ReturnValue.EXCEPTION;
                foreach (var item in lstScriptConfigID)
                {
                    //删除原有关联信息
                    short shRet = this.Delete(item);
                    if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
                    {
                        base.MedQCAccess.AbortTransaction();
                        return shRet;
                    }
                }
                //提交数据库更新
                if (!base.MedQCAccess.CommitTransaction(true))
                    return SystemData.ReturnValue.EXCEPTION;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", ex);
            }
            finally
            {
                base.MedQCAccess.CloseConnnection(false);
            }
            return SystemData.ReturnValue.OK;
        }
    }
}