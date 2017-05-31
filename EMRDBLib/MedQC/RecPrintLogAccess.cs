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

    public class RecPrintLogAccess : DBAccessBase
    {
        private static RecPrintLogAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RecPrintLogAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RecPrintLogAccess();
                return RecPrintLogAccess.m_Instance;
            }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetRecPrintLog(string szPrintID, ref RecPrintLog RecPrintLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.INVOICE);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.MONEY);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_CONTENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.REMARKS);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPrintLogTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPrintID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecPrintLogTable.PRINT_ID
                    , szPrintID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PRINT_LOG, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (RecPrintLog == null)
                    RecPrintLog = new RecPrintLog();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.RecPrintLogTable.DISCHARGE_TIME:
                            RecPrintLog.DISCHARGE_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.RecPrintLogTable.INVOICE:
                            RecPrintLog.INVOICE = dataReader.GetValue(i).ToString() == "1";
                            break;
                        case SystemData.RecPrintLogTable.MONEY:
                            RecPrintLog.MONEY = float.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.RecPrintLogTable.PATIENT_ID:
                            RecPrintLog.PATIENT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.PATIENT_ID_NO:
                            RecPrintLog.PATIENT_ID_NO = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.RecPrintLogTable.PATIENT_NAME:
                            RecPrintLog.PATIENT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.VISIT_ID:
                            RecPrintLog.VISIT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.VISIT_NO:
                            RecPrintLog.VISIT_NO = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.PRINT_CONTENT:
                            RecPrintLog.PRINT_CONTENT = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.PRINT_ID:
                            RecPrintLog.PRINT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.PRINT_ID_NO:
                            RecPrintLog.PRINT_ID_NO = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.PRINT_NAME:
                            RecPrintLog.PRINT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.PRINT_TIME:
                            RecPrintLog.PRINT_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT:
                            RecPrintLog.RELATIONSHIP_PATIENT = dataReader.GetString(i);
                            break;
                        case SystemData.RecPrintLogTable.REMARKS:
                            RecPrintLog.REMARKS = dataReader.GetString(i);
                            break;
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

        public short GetRecPrintLogs(string szPatientID, string szVisitNo, ref List<RecPrintLog> lstRecPrintLogs)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.INVOICE);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.MONEY);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_CONTENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.REMARKS);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPrintLogTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.RecPrintLogTable.PATIENT_ID, szPatientID
                , SystemData.RecPrintLogTable.VISIT_NO, szVisitNo);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PRINT_LOG, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPrintLogs == null)
                    lstRecPrintLogs = new List<RecPrintLog>();
                do
                {
                    RecPrintLog RecPrintLog = new RecPrintLog();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPrintLogTable.DISCHARGE_TIME:
                                RecPrintLog.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPrintLogTable.INVOICE:
                                RecPrintLog.INVOICE = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.RecPrintLogTable.MONEY:
                                RecPrintLog.MONEY = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPrintLogTable.PATIENT_ID:
                                RecPrintLog.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PATIENT_ID_NO:
                                RecPrintLog.PATIENT_ID_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecPrintLogTable.PATIENT_NAME:
                                RecPrintLog.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.VISIT_ID:
                                RecPrintLog.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.VISIT_NO:
                                RecPrintLog.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_CONTENT:
                                RecPrintLog.PRINT_CONTENT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_ID:
                                RecPrintLog.PRINT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_ID_NO:
                                RecPrintLog.PRINT_ID_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_NAME:
                                RecPrintLog.PRINT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_TIME:
                                RecPrintLog.PRINT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT:
                                RecPrintLog.RELATIONSHIP_PATIENT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.REMARKS:
                                RecPrintLog.REMARKS = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPrintLogs.Add(RecPrintLog);
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

        public short GetRecPrintLogs(DateTime dtPrintTimeBegin, DateTime dtPrintTimeEnd, string szPatientName, ref List<RecPrintLog> lstRecPrintLogs)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.INVOICE);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.MONEY);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_CONTENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.REMARKS);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPrintLogTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} >= {2} AND {1} <= {3}"
                , szCondition
                , SystemData.RecPrintLogTable.PRINT_TIME
                , base.QCAccess.GetSqlTimeFormat(dtPrintTimeBegin)
                , base.QCAccess.GetSqlTimeFormat(dtPrintTimeEnd)
                );
            if (!string.IsNullOrEmpty(szPatientName))
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                    , szCondition
                    , SystemData.RecPrintLogTable.PATIENT_NAME
                    , szPatientName);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PRINT_LOG, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPrintLogs == null)
                    lstRecPrintLogs = new List<RecPrintLog>();
                do
                {
                    RecPrintLog RecPrintLog = new RecPrintLog();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPrintLogTable.DISCHARGE_TIME:
                                RecPrintLog.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPrintLogTable.INVOICE:
                                RecPrintLog.INVOICE = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.RecPrintLogTable.MONEY:
                                RecPrintLog.MONEY = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPrintLogTable.PATIENT_ID:
                                RecPrintLog.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PATIENT_ID_NO:
                                RecPrintLog.PATIENT_ID_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecPrintLogTable.PATIENT_NAME:
                                RecPrintLog.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.VISIT_ID:
                                RecPrintLog.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.VISIT_NO:
                                RecPrintLog.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_CONTENT:
                                RecPrintLog.PRINT_CONTENT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_ID:
                                RecPrintLog.PRINT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_ID_NO:
                                RecPrintLog.PRINT_ID_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_NAME:
                                RecPrintLog.PRINT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.PRINT_TIME:
                                RecPrintLog.PRINT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT:
                                RecPrintLog.RELATIONSHIP_PATIENT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPrintLogTable.REMARKS:
                                RecPrintLog.REMARKS = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPrintLogs.Add(RecPrintLog);
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
        /// <summary>
        /// 新增一条人工核查结果信息
        /// </summary>
        /// <param name="recPrintLog">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(RecPrintLog recPrintLog)
        {
            if (recPrintLog == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recPrintLog }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (recPrintLog.PRINT_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.DISCHARGE_TIME);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlTimeFormat(recPrintLog.DISCHARGE_TIME));
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.INVOICE);
            sbValue.AppendFormat("{0},", recPrintLog.INVOICE ? 1 : 0);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.MONEY);
            sbValue.AppendFormat("{0},", recPrintLog.MONEY);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", recPrintLog.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_ID_NO);
            sbValue.AppendFormat("'{0}',", recPrintLog.PATIENT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PATIENT_NAME);
            sbValue.AppendFormat("'{0}',", recPrintLog.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_CONTENT);
            sbValue.AppendFormat("'{0}',", recPrintLog.PRINT_CONTENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID);
            sbValue.AppendFormat("'{0}',", recPrintLog.PRINT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_ID_NO);
            sbValue.AppendFormat("'{0}',", recPrintLog.PRINT_ID_NO);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_NAME);
            sbValue.AppendFormat("'{0}',", recPrintLog.PRINT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.PRINT_TIME);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlTimeFormat(recPrintLog.PRINT_TIME));
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.REMARKS);
            sbValue.AppendFormat("'{0}',", recPrintLog.REMARKS);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT);
            sbValue.AppendFormat("'{0}',", recPrintLog.RELATIONSHIP_PATIENT);
            sbField.AppendFormat("{0},", SystemData.RecPrintLogTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", recPrintLog.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPrintLogTable.VISIT_NO);
            sbValue.AppendFormat("'{0}'", recPrintLog.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.REC_PRINT_LOG, sbField.ToString(), sbValue.ToString());
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
        /// <summary>
        /// 更新一条整改通知单
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(RecPrintLog recPrintLog)
        {
            if (recPrintLog == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recPrintLog }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPrintLogTable.DISCHARGE_TIME, base.QCAccess.GetSqlTimeFormat(recPrintLog.DISCHARGE_TIME));
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPrintLogTable.INVOICE, recPrintLog.INVOICE ? 1 : 0);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPrintLogTable.MONEY, recPrintLog.MONEY);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.PATIENT_ID, recPrintLog.PATIENT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.PATIENT_ID_NO, recPrintLog.PATIENT_ID_NO);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.PATIENT_NAME, recPrintLog.PATIENT_NAME);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.PRINT_CONTENT, recPrintLog.PRINT_CONTENT);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.PRINT_ID, recPrintLog.PRINT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.PRINT_ID_NO, recPrintLog.PRINT_ID_NO);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.PRINT_NAME, recPrintLog.PRINT_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPrintLogTable.PRINT_TIME, base.QCAccess.GetSqlTimeFormat(recPrintLog.PRINT_TIME));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.RELATIONSHIP_PATIENT, recPrintLog.RELATIONSHIP_PATIENT);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.REMARKS, recPrintLog.REMARKS);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPrintLogTable.VISIT_ID, recPrintLog.VISIT_ID);
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.RecPrintLogTable.VISIT_NO, recPrintLog.VISIT_NO);
            string szCondition = string.Format("{0}='{1}'", SystemData.RecPrintLogTable.PRINT_ID, recPrintLog.PRINT_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REC_PRINT_LOG, sbField.ToString(), szCondition);
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

        public short Delete(string szPrintID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szPrintID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szPrintID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.RecPrintLogTable.PRINT_ID, szPrintID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.REC_PRINT_LOG, szCondition);
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