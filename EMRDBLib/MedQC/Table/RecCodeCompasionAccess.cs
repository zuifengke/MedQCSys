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
using System.Reflection;
using System.Text;

namespace EMRDBLib.DbAccess
{

    public class RecCodeCompasionAccess : DBAccessBase
    {
        private string TableName = SystemData.DataTable.REC_CODE_COMPASION;
        private static RecCodeCompasionAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RecCodeCompasionAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RecCodeCompasionAccess();
                return RecCodeCompasionAccess.m_Instance;
            }
        }

        public short GetRecCodeCompasion(string id, ref RecCodeCompasion recCodeCompasion)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODETYPE_NAME);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODE_ID);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODE_NAME);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.DM);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.DMLB);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.ID);
            sbField.AppendFormat("{0}", SystemData.RecCodeCompasionTable.MC);
            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1} = '{2}'"
                , szCondition
                , SystemData.RecCodeCompasionTable.ID
                , id);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_CODE_COMPASION, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (recCodeCompasion == null)
                    recCodeCompasion = new RecCodeCompasion();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.RecCodeCompasionTable.CODETYPE_NAME:
                            recCodeCompasion.CODETYPE_NAME = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.RecCodeCompasionTable.CODE_ID:
                            recCodeCompasion.CODE_ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.RecCodeCompasionTable.CODE_NAME:
                            recCodeCompasion.DM = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.RecCodeCompasionTable.DMLB:
                            recCodeCompasion.ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.RecCodeCompasionTable.MC:
                            recCodeCompasion.MC = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.RecCodeCompasionTable.DM:
                            recCodeCompasion.DM = dataReader.GetValue(i).ToString();
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
            finally { base.QCAccess.CloseConnnection(false); }
        }

        public short GetRecCodeCompasions(string codeTypeName, ref List<RecCodeCompasion> lstRecCodeCompasions)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODETYPE_NAME);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODE_ID);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODE_NAME);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.DM);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.DMLB);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.ID);
            sbField.AppendFormat("{0}", SystemData.RecCodeCompasionTable.MC);

            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1} = '{2}' and {3} = 0 "
                , szCondition
                , SystemData.RecCodeCompasionTable.CODETYPE_NAME
                , codeTypeName
                , SystemData.RecCodeCompasionTable.IS_CONFIG);
            string szOrderBy = string.Format("{0}", SystemData.RecCodeCompasionTable.DM);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable.REC_CODE_COMPASION, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecCodeCompasions == null)
                    lstRecCodeCompasions = new List<RecCodeCompasion>();
                lstRecCodeCompasions.Clear();
                do
                {
                    RecCodeCompasion recCodeCompasion = new RecCodeCompasion();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecCodeCompasionTable.CODETYPE_NAME:
                                recCodeCompasion.CODETYPE_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecCodeCompasionTable.CODE_ID:
                                recCodeCompasion.CODE_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecCodeCompasionTable.CODE_NAME:
                                recCodeCompasion.CODE_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecCodeCompasionTable.DMLB:
                                recCodeCompasion.DMLB = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecCodeCompasionTable.ID:
                                recCodeCompasion.ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecCodeCompasionTable.MC:
                                recCodeCompasion.MC = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecCodeCompasionTable.DM:
                                recCodeCompasion.DM = dataReader.GetValue(i).ToString();
                                break;
                            default: break;
                        }
                    }
                    lstRecCodeCompasions.Add(recCodeCompasion);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }


        public short GetLists(bool bIsConfig, ref List<RecCodeCompasion> lstRecCodeCompasions)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = {2}"
                , szCondition
                , SystemData.RecCodeCompasionTable.IS_CONFIG
                , bIsConfig ? 1 : 0);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), TableName, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecCodeCompasions == null)
                    lstRecCodeCompasions = new List<RecCodeCompasion>();
                lstRecCodeCompasions.Clear();
                do
                {
                    RecCodeCompasion item = new RecCodeCompasion();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        PropertyInfo property = Reflect.GetPropertyInfo(typeof(RecCodeCompasion), dataReader.GetName(i));
                        bool result = Reflect.SetPropertyValue(item, property, dataReader.GetValue(i));
                    }
                    lstRecCodeCompasions.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 新增一条人工核查结果信息
        /// </summary>
        /// <param name="recCodeCompasion">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(RecCodeCompasion recCodeCompasion)
        {
            if (recCodeCompasion == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recCodeCompasion }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (recCodeCompasion.ID == string.Empty)
            {
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODETYPE_NAME);
            sbValue.AppendFormat("'{0}',", recCodeCompasion.CODETYPE_NAME);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODE_ID);
            sbValue.AppendFormat("'{0}',", recCodeCompasion.CODE_ID);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CODE_NAME);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlParamName("CODE_NAME") );
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.DM);
            sbValue.AppendFormat("'{0}',", recCodeCompasion.DM);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.DMLB);
            sbValue.AppendFormat("'{0}',", recCodeCompasion.DMLB);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.ID);
            sbValue.AppendFormat("'{0}',", recCodeCompasion.ID);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.FORM_SQL);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlParamName("FORM_SQL"));
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.IS_CONFIG);
            sbValue.AppendFormat("{0},", recCodeCompasion.IS_CONFIG);
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.TO_SQL);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlParamName("TO_SQL"));
            sbField.AppendFormat("{0},", SystemData.RecCodeCompasionTable.CONFIG_NAME);
            sbValue.AppendFormat("'{0}',", recCodeCompasion.CONFIG_NAME);
            sbField.AppendFormat("{0}", SystemData.RecCodeCompasionTable.MC);
            sbValue.AppendFormat("{0}", base.QCAccess.GetSqlParamName("MC"));


            if (recCodeCompasion.FORM_SQL == null)
                recCodeCompasion.FORM_SQL = string.Empty;
            if (recCodeCompasion.TO_SQL == null)
                recCodeCompasion.TO_SQL = string.Empty;
            if (recCodeCompasion.CODE_NAME == null)
                recCodeCompasion.CODE_NAME = string.Empty;
            if (recCodeCompasion.DM == null)
                recCodeCompasion.DM = string.Empty;
            if (recCodeCompasion.MC == null)
                recCodeCompasion.MC = string.Empty;
            DbParameter[] pmi = new DbParameter[4];
            pmi[0] = new DbParameter("CODE_NAME", recCodeCompasion.CODE_NAME);
            pmi[1] = new DbParameter("FORM_SQL", recCodeCompasion.FORM_SQL);
            pmi[2] = new DbParameter("TO_SQL", recCodeCompasion.TO_SQL);
            pmi[3] = new DbParameter("MC", recCodeCompasion.MC);

            string szSQL = string.Format(SystemData.SQL.INSERT, TableName, sbField.ToString(), sbValue.ToString());
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text,ref pmi);
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
        /// 更新一条整改通知单
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(RecCodeCompasion recCodeCompasion)
        {
            if (recCodeCompasion == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recCodeCompasion }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if(recCodeCompasion.IS_CONFIG==0)
            {
                if (string.IsNullOrEmpty(recCodeCompasion.MC) ||
                    string.IsNullOrEmpty(recCodeCompasion.DM))
                {
                    return this.Delete(recCodeCompasion.ID);
                }
            }
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecCodeCompasionTable.CODETYPE_NAME, recCodeCompasion.CODETYPE_NAME);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecCodeCompasionTable.CODE_ID, recCodeCompasion.CODE_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecCodeCompasionTable.CODE_NAME, recCodeCompasion.CODE_NAME);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecCodeCompasionTable.DM, recCodeCompasion.DM);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecCodeCompasionTable.DMLB, recCodeCompasion.DMLB);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecCodeCompasionTable.FORM_SQL, base.QCAccess.GetSqlParamName("FORM_SQL"));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecCodeCompasionTable.CONFIG_NAME, recCodeCompasion.CONFIG_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecCodeCompasionTable.IS_CONFIG, recCodeCompasion.IS_CONFIG);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecCodeCompasionTable.TO_SQL, base.QCAccess.GetSqlParamName("TO_SQL"));
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.RecCodeCompasionTable.MC, recCodeCompasion.MC);
            string szCondition = string.Format("{0}='{1}'", SystemData.RecCodeCompasionTable.ID, recCodeCompasion.ID);

            DbParameter[] pmi = new DbParameter[2];
            pmi[0] = new DbParameter("FORM_SQL", recCodeCompasion.FORM_SQL == null ? string.Empty : recCodeCompasion.FORM_SQL);
            pmi[1] = new DbParameter("TO_SQL", recCodeCompasion.TO_SQL==null?string.Empty:recCodeCompasion.TO_SQL);

            string szSQL = string.Format(SystemData.SQL.UPDATE, TableName, sbField.ToString(), szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text,ref pmi);
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

        public short Delete(string szID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.RecCodeCompasionTable.ID, szID);
            string szSQL = string.Format(SystemData.SQL.DELETE, TableName, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
    }
}