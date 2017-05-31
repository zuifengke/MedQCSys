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

    public class RecMrBatchAccess : DBAccessBase
    {
        private static RecMrBatchAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RecMrBatchAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RecMrBatchAccess();
                return RecMrBatchAccess.m_Instance;
            }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetRecMrBatch(string szBatchNo, ref RecMrBatch RecMrBatch)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.BATCH_NO);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.INP_NOS);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.MR_COUNT);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.PAPER_COUNT);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DOCTOR_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.REMARK);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DOCTOR_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_TIME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.VISIT_NOS);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.WORKER_ID);
            sbField.AppendFormat("{0}", SystemData.RecMrBatchTable.WORKER_NAME);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szBatchNo))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecMrBatchTable.BATCH_NO
                    , szBatchNo);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_MR_BATCH, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (RecMrBatch == null)
                    RecMrBatch = new RecMrBatch();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.RecMrBatchTable.BATCH_NO:
                            RecMrBatch.BATCH_NO = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.INP_NOS:
                            RecMrBatch.INP_NOS = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.MR_COUNT:
                            RecMrBatch.MR_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.RecMrBatchTable.PAPER_COUNT:
                            RecMrBatch.PAPER_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.RecMrBatchTable.RECEIVE_DEPT_CODE:
                            RecMrBatch.RECEIVE_DEPT_CODE = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.RecMrBatchTable.RECEIVE_DEPT_NAME:
                            RecMrBatch.RECEIVE_DEPT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.RECEIVE_DOCTOR_ID:
                            RecMrBatch.RECEIVE_DOCTOR_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.RECEIVE_DOCTOR_NAME:
                            RecMrBatch.RECEIVE_DOCTOR_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.RECEIVE_TIME:
                            RecMrBatch.RECEIVE_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.RecMrBatchTable.REMARK:
                            RecMrBatch.REMARK = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.SEND_DEPT_CODE:
                            RecMrBatch.SEND_DEPT_CODE = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.SEND_DEPT_NAME:
                            RecMrBatch.SEND_DEPT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.SEND_DOCTOR_ID:
                            RecMrBatch.SEND_DOCTOR_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.SEND_DOCTOR_NAME:
                            RecMrBatch.SEND_DOCTOR_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.SEND_TIME:
                            RecMrBatch.SEND_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.RecMrBatchTable.VISIT_NOS:
                            RecMrBatch.VISIT_NOS = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.WORKER_ID:
                            RecMrBatch.WORKER_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecMrBatchTable.WORKER_NAME:
                            RecMrBatch.WORKER_NAME = dataReader.GetString(i);
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

        public short GetRecMrBatchs(DateTime dtSendTimeBegin, DateTime dtSendTimeEnd, string szDeptCode,string szBatchNo, ref List<RecMrBatch> lstRecMrBatchs)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.BATCH_NO);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.INP_NOS);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.MR_COUNT);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.PAPER_COUNT);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DOCTOR_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.REMARK);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DOCTOR_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_TIME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.VISIT_NOS);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.WORKER_ID);
            sbField.AppendFormat("{0}", SystemData.RecMrBatchTable.WORKER_NAME);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} >= {2} AND {1} <= {3}"
                , szCondition
                , SystemData.RecMrBatchTable.SEND_TIME
                , base.QCAccess.GetSqlTimeFormat(dtSendTimeBegin)
                , base.QCAccess.GetSqlTimeFormat(dtSendTimeEnd));
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.RecMrBatchTable.SEND_DEPT_CODE
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szBatchNo))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.RecMrBatchTable.BATCH_NO
                    , szBatchNo);
            }
            string szOrderBy = string.Format("{0}", SystemData.RecMrBatchTable.SEND_TIME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable.REC_MR_BATCH, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecMrBatchs == null)
                    lstRecMrBatchs = new List<RecMrBatch>();
                do
                {
                    RecMrBatch RecMrBatch = new RecMrBatch();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecMrBatchTable.BATCH_NO:
                                RecMrBatch.BATCH_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.INP_NOS:
                                RecMrBatch.INP_NOS = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.MR_COUNT:
                                RecMrBatch.MR_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecMrBatchTable.PAPER_COUNT:
                                RecMrBatch.PAPER_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecMrBatchTable.RECEIVE_DEPT_CODE:
                                RecMrBatch.RECEIVE_DEPT_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecMrBatchTable.RECEIVE_DEPT_NAME:
                                RecMrBatch.RECEIVE_DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.RECEIVE_DOCTOR_ID:
                                RecMrBatch.RECEIVE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.RECEIVE_DOCTOR_NAME:
                                RecMrBatch.RECEIVE_DOCTOR_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.RECEIVE_TIME:
                                RecMrBatch.RECEIVE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecMrBatchTable.REMARK:
                                RecMrBatch.REMARK = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.SEND_DEPT_CODE:
                                RecMrBatch.SEND_DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.SEND_DEPT_NAME:
                                RecMrBatch.SEND_DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.SEND_DOCTOR_ID:
                                RecMrBatch.SEND_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.SEND_DOCTOR_NAME:
                                RecMrBatch.SEND_DOCTOR_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.SEND_TIME:
                                RecMrBatch.SEND_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecMrBatchTable.VISIT_NOS:
                                RecMrBatch.VISIT_NOS = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.WORKER_ID:
                                RecMrBatch.WORKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecMrBatchTable.WORKER_NAME:
                                RecMrBatch.WORKER_NAME = dataReader.GetString(i);
                                break;
                            default:
                                break;
                        }
                    }
                    lstRecMrBatchs.Add(RecMrBatch);
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
        /// <param name="RecMrBatch">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(RecMrBatch RecMrBatch)
        {
            if (RecMrBatch == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { RecMrBatch }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (RecMrBatch.BATCH_NO == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.BATCH_NO);
            sbValue.AppendFormat("'{0}',", RecMrBatch.BATCH_NO);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.INP_NOS);
            sbValue.AppendFormat("'{0}',", RecMrBatch.INP_NOS);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.MR_COUNT);
            sbValue.AppendFormat("{0},", RecMrBatch.MR_COUNT);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.PAPER_COUNT);
            sbValue.AppendFormat("{0},", RecMrBatch.PAPER_COUNT);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DEPT_CODE);
            sbValue.AppendFormat("'{0}',", RecMrBatch.RECEIVE_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DEPT_NAME);
            sbValue.AppendFormat("'{0}',", RecMrBatch.RECEIVE_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DOCTOR_ID);
            sbValue.AppendFormat("'{0}',", RecMrBatch.RECEIVE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_DOCTOR_NAME);
            sbValue.AppendFormat("'{0}',", RecMrBatch.RECEIVE_DOCTOR_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.RECEIVE_TIME);
            sbValue.AppendFormat("{0},",base.QCAccess.GetSqlTimeFormat(RecMrBatch.RECEIVE_TIME));
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.REMARK);
            sbValue.AppendFormat("'{0}',", RecMrBatch.REMARK);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DEPT_CODE);
            sbValue.AppendFormat("'{0}',", RecMrBatch.SEND_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DEPT_NAME);
            sbValue.AppendFormat("'{0}',", RecMrBatch.SEND_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DOCTOR_ID);
            sbValue.AppendFormat("'{0}',", RecMrBatch.SEND_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_DOCTOR_NAME);
            sbValue.AppendFormat("'{0}',", RecMrBatch.SEND_DOCTOR_NAME);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.SEND_TIME);
            sbValue.AppendFormat("{0},",base.QCAccess.GetSqlTimeFormat(RecMrBatch.SEND_TIME));
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.VISIT_NOS);
            sbValue.AppendFormat("'{0}',", RecMrBatch.VISIT_NOS);
            sbField.AppendFormat("{0},", SystemData.RecMrBatchTable.WORKER_ID);
            sbValue.AppendFormat("'{0}',", RecMrBatch.WORKER_ID);
            sbField.AppendFormat("{0}", SystemData.RecMrBatchTable.WORKER_NAME);
            sbValue.AppendFormat("'{0}'", RecMrBatch.WORKER_NAME);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.REC_MR_BATCH, sbField.ToString(), sbValue.ToString());
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
        public short Update(RecMrBatch recMrBatch)
        {
            if (recMrBatch == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recMrBatch }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.INP_NOS, recMrBatch.INP_NOS);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecMrBatchTable.MR_COUNT, recMrBatch.MR_COUNT);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecMrBatchTable.PAPER_COUNT, recMrBatch.PAPER_COUNT);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.RECEIVE_DEPT_CODE, recMrBatch.RECEIVE_DEPT_CODE);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.RECEIVE_DEPT_NAME, recMrBatch.RECEIVE_DEPT_NAME);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.RECEIVE_DOCTOR_ID, recMrBatch.RECEIVE_DOCTOR_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.RECEIVE_DOCTOR_NAME, recMrBatch.RECEIVE_DOCTOR_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecMrBatchTable.RECEIVE_TIME,base.QCAccess.GetSqlTimeFormat(recMrBatch.RECEIVE_TIME));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.REMARK, recMrBatch.REMARK);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecMrBatchTable.SEND_DEPT_CODE, recMrBatch.SEND_DEPT_CODE);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.SEND_DEPT_NAME, recMrBatch.SEND_DEPT_NAME);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.SEND_DOCTOR_ID, recMrBatch.SEND_DOCTOR_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.SEND_DOCTOR_NAME, recMrBatch.SEND_DOCTOR_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecMrBatchTable.SEND_TIME,base.QCAccess.GetSqlTimeFormat(recMrBatch.SEND_TIME) );
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.VISIT_NOS, recMrBatch.VISIT_NOS);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecMrBatchTable.WORKER_ID, recMrBatch.WORKER_ID);
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.RecMrBatchTable.WORKER_NAME, recMrBatch.WORKER_NAME);
            string szCondition = string.Format("{0}='{1}'", SystemData.RecMrBatchTable.BATCH_NO, recMrBatch.BATCH_NO);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REC_MR_BATCH, sbField.ToString(), szCondition);
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
        /// 删除一条整改通知单
        /// </summary>
        /// <param name="szRuleID">自动核查结果ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szBatchNO)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szBatchNO))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szBatchNO }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.RecMrBatchTable.BATCH_NO, szBatchNO);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.REC_MR_BATCH, szCondition);
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