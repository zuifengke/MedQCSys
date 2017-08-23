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

    public class ReportTypeAccess : DBAccessBase
    {
        private static ReportTypeAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static ReportTypeAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ReportTypeAccess();
                return ReportTypeAccess.m_Instance;
            }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetReportTypes(string szApplyEnv, ref List<ReportType> lstReportTypes)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.APPLY_ENV);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.IS_FOLDER);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.IS_VALID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.PARENT_ID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.REPORT_TYPE_ID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.REPORT_TYPE_NAME);
            sbField.AppendFormat("{0}", SystemData.ReportTypeTable.REPORT_TYPE_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szApplyEnv))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.ReportTypeTable.APPLY_ENV
                    , szApplyEnv);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REPORT_TYPE, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstReportTypes == null)
                    lstReportTypes = new List<ReportType>();
                do
                {
                    ReportType reportType = new ReportType();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.ReportTypeTable.APPLY_ENV:
                                reportType.ApplyEnv = dataReader.GetString(i).ToString();
                                break;
                            case SystemData.ReportTypeTable.IS_FOLDER:
                                reportType.IsFolder = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.ReportTypeTable.IS_VALID:
                                reportType.IsValid = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.ReportTypeTable.MODIFY_TIME:
                                reportType.ModifyTime = dataReader.GetDateTime(i);
                                break;
                            case SystemData.ReportTypeTable.PARENT_ID:
                                reportType.ParentID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.ReportTypeTable.REPORT_TYPE_ID:
                                reportType.ReportTypeID = dataReader.GetString(i);
                                break;
                            case SystemData.ReportTypeTable.REPORT_TYPE_NAME:
                                reportType.ReportTypeName = dataReader.GetString(i);
                                break;
                            case SystemData.ReportTypeTable.REPORT_TYPE_NO:
                                reportType.ReportTypeNo = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            default: break;
                        }
                    }
                    lstReportTypes.Add(reportType);
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
        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetReportType(string szReportTypeID, ref ReportType reportType)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szReportTypeID))
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.APPLY_ENV);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.IS_FOLDER);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.IS_VALID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.PARENT_ID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.REPORT_TYPE_ID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.REPORT_TYPE_NAME);
            sbField.AppendFormat("{0}", SystemData.ReportTypeTable.REPORT_TYPE_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szReportTypeID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.ReportTypeTable.REPORT_TYPE_ID
                    , szReportTypeID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REPORT_TYPE, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (reportType == null)
                    reportType = new ReportType();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.ReportTypeTable.APPLY_ENV:
                            reportType.ApplyEnv = dataReader.GetString(i).ToString();
                            break;
                        case SystemData.ReportTypeTable.IS_FOLDER:
                            reportType.IsFolder = dataReader.GetValue(i).ToString() == "1";
                            break;
                        case SystemData.ReportTypeTable.IS_VALID:
                            reportType.IsValid = dataReader.GetValue(i).ToString() == "1";
                            break;
                        case SystemData.ReportTypeTable.MODIFY_TIME:
                            reportType.ModifyTime = dataReader.GetDateTime(i);
                            break;
                        case SystemData.ReportTypeTable.PARENT_ID:
                            reportType.ParentID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.ReportTypeTable.REPORT_TYPE_ID:
                            reportType.ReportTypeID = dataReader.GetString(i);
                            break;
                        case SystemData.ReportTypeTable.REPORT_TYPE_NAME:
                            reportType.ReportTypeName = dataReader.GetString(i);
                            break;
                        case SystemData.ReportTypeTable.REPORT_TYPE_NO:
                            reportType.ReportTypeNo = int.Parse(dataReader.GetValue(i).ToString());
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
        /// <summary>
        /// 根据报表模板ID从DB中获取报表模板内容
        /// </summary>
        /// <param name="szTempletID">报表模板ID</param>
        /// <param name="byteReportData">报表模板二进制内容</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short GetReportData(string szTempletID, ref byte[] byteReportData)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.ReportTypeTable.REPORT_TYPE_ID, szTempletID);
            string szField = string.Format("{0},{1}"
                , SystemData.ReportTypeTable.REPORT_DATA
                , SystemData.ReportTypeTable.REPORT_TYPE_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataTable.REPORT_TYPE, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    LogManager.Instance.WriteLog("TempletAccess.GetReportTempletFromDB", new string[] { "szSQL" }, new object[] { szSQL }, "没有查询到记录!");
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                return GlobalMethods.IO.GetBytes(dataReader, 0, ref byteReportData)
                    ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }


        /// <summary>
        /// 保存系统缺省模板到数据库服务器
        /// </summary>
        /// <param name="szDocTypeID">报表类型ID</param>
        /// <param name="byteTempletData">系统缺省模板</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short SaveReportDataToDB(string szDocTypeID, byte[] byteTempletData)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}={1}", SystemData.ReportTypeTable.MODIFY_TIME, base.MedQCAccess.GetSystemTimeSql());

            DbParameter[] pmi = null;
            if (byteTempletData != null)
            {
                szField = string.Format("{0},{1}={2}", szField, SystemData.ReportTypeTable.REPORT_DATA, base.MedQCAccess.GetSqlParamName("REPORT_DATA"));

                pmi = new DbParameter[1];
                pmi[0] = new DbParameter("REPORT_DATA", byteTempletData);
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.ReportTypeTable.REPORT_TYPE_ID, szDocTypeID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REPORT_TYPE, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("TempletAccess.SaveSystemReportToDB", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        public short Insert(ReportType reportType)
        {
            if (reportType == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { reportType }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (reportType.ReportTypeID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.APPLY_ENV);
            sbValue.AppendFormat("'{0}',", reportType.ApplyEnv);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.IS_FOLDER);
            sbValue.AppendFormat("{0},", reportType.IsFolder ? 1 : 0);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.IS_VALID);
            sbValue.AppendFormat("{0},", reportType.IsValid ? 1 : 0);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.MODIFY_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(reportType.ModifyTime));
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.PARENT_ID);
            sbValue.AppendFormat("'{0}',", reportType.ParentID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.REPORT_TYPE_ID);
            sbValue.AppendFormat("'{0}',", reportType.ReportTypeID);
            sbField.AppendFormat("{0},", SystemData.ReportTypeTable.REPORT_TYPE_NAME);
            sbValue.AppendFormat("'{0}',", reportType.ReportTypeName);
            sbField.AppendFormat("{0}", SystemData.ReportTypeTable.REPORT_TYPE_NO);
            sbValue.AppendFormat("{0}", reportType.ReportTypeNo);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.REPORT_TYPE, sbField.ToString(), sbValue.ToString());
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
        /// 更新一条整改通知单
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(ReportType reportType)
        {
            if (reportType == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { reportType }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.ReportTypeTable.APPLY_ENV, reportType.ApplyEnv);
            sbField.AppendFormat("{0}={1},"
                , SystemData.ReportTypeTable.IS_FOLDER, reportType.IsFolder ? 1 : 0);
            sbField.AppendFormat("{0}={1},"
                , SystemData.ReportTypeTable.IS_VALID, reportType.IsValid ? 1 : 0);
            sbField.AppendFormat("{0}={1},"
                , SystemData.ReportTypeTable.MODIFY_TIME, base.MedQCAccess.GetSqlTimeFormat(reportType.ModifyTime));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.ReportTypeTable.PARENT_ID, reportType.ParentID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.ReportTypeTable.REPORT_TYPE_NAME, reportType.ReportTypeName);
            sbField.AppendFormat("{0}={1}"
                , SystemData.ReportTypeTable.REPORT_TYPE_NO, reportType.ReportTypeNo);
            string szCondition = string.Format("{0}='{1}'", SystemData.ReportTypeTable.REPORT_TYPE_ID, reportType.ReportTypeID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REPORT_TYPE, sbField.ToString(), szCondition);
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
        public short Delete(string szReportTypeID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szReportTypeID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szReportTypeID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.ReportTypeTable.REPORT_TYPE_ID, szReportTypeID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.REPORT_TYPE, szCondition);
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

        public short DeleteAll(List<string> lstReportTypeID)
        {
            try
            {
                if (base.MedQCAccess == null)
                    return SystemData.ReturnValue.PARAM_ERROR;

                //开始数据库事务
                if (!base.MedQCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                    return SystemData.ReturnValue.EXCEPTION;
                foreach (var item in lstReportTypeID)
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