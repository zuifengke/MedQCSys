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

    public class QcModifyNoticeAccess : DBAccessBase
    {
        private static QcModifyNoticeAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static QcModifyNoticeAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcModifyNoticeAccess();
                return QcModifyNoticeAccess.m_Instance;
            }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcModifyNotice(string szPatientID, string szVisitID, ref QcModifyNotice qcModifyNotice)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_NOTICE_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_PERIOD);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_REMARK);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_SCORE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.NOTICE_STATUS);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.NOTICE_TIME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_LEVEL);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_MAN);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_MAN_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.QcModifyNoticeTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPatientID) && !string.IsNullOrEmpty(szVisitID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}' AND {3}='{4}'"
                    , szCondition
                    , SystemData.QcCheckResultTable.PATIENT_ID
                    , szPatientID
                    , SystemData.QcCheckResultTable.VISIT_ID
                    , szVisitID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.QC_MODIFY_NOTICE, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (qcModifyNotice == null)
                    qcModifyNotice = new QcModifyNotice();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.QcModifyNoticeTable.MODIFY_NOTICE_ID:
                            qcModifyNotice.MODIFY_NOTICE_ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.QcModifyNoticeTable.MODIFY_PERIOD:
                            qcModifyNotice.MODIFY_PERIOD = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.MODIFY_REMARK:
                            qcModifyNotice.MODIFY_REMARK = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.MODIFY_SCORE:
                            qcModifyNotice.MODIFY_SCORE = float.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcModifyNoticeTable.NOTICE_STATUS:
                            qcModifyNotice.NOTICE_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcModifyNoticeTable.NOTICE_TIME:
                            qcModifyNotice.NOTICE_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.QcModifyNoticeTable.PATIENT_ID:
                            qcModifyNotice.PATIENT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.QC_DEPT_CODE:
                            qcModifyNotice.QC_DEPT_CODE = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.QC_DEPT_NAME:
                            qcModifyNotice.QC_DEPT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.QC_LEVEL:
                            qcModifyNotice.QC_LEVEL = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcModifyNoticeTable.QC_MAN:
                            qcModifyNotice.QC_MAN = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.QC_MAN_ID:
                            qcModifyNotice.QC_MAN_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.RECEIVER:
                            qcModifyNotice.RECEIVER = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.RECEIVER_DEPT_CODE:
                            qcModifyNotice.RECEIVER_DEPT_CODE = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.RECEIVER_DEPT_NAME:
                            qcModifyNotice.RECEIVER_DEPT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.VISIT_ID:
                            qcModifyNotice.VISIT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.VISIT_NO:
                            qcModifyNotice.VISIT_NO = dataReader.GetString(i);
                            break;
                        case SystemData.QcModifyNoticeTable.RECEIVER_ID:
                            qcModifyNotice.RECEIVER_ID = dataReader.GetString(i);
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
        /// 获取整改通知书
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcModifyNotices(DateTime dtNoticeTimeBegin, DateTime dtNoticeTimeEnd, string szDeptCode, string szUserID, string szPatientID, string szPatientName, ref List<QcModifyNotice> lstQcModifyNotices)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_NOTICE_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_PERIOD);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_REMARK);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_SCORE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.NOTICE_STATUS);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.NOTICE_TIME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_LEVEL);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_MAN);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_MAN_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.QcModifyNoticeTable.VISIT_NO);

            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1} >= {2} AND {1} <= {3}"
                , szCondition
                , SystemData.QcModifyNoticeTable.NOTICE_TIME
                , base.MedQCAccess.GetSqlTimeFormat(dtNoticeTimeBegin)
                , base.MedQCAccess.GetSqlTimeFormat(dtNoticeTimeEnd));
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.QcModifyNoticeTable.RECEIVER_DEPT_CODE
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szUserID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.QcModifyNoticeTable.QC_MAN_ID
                    , szUserID);
            }
            if (!string.IsNullOrEmpty(szPatientID))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                    , szCondition
                    , SystemData.QcModifyNoticeTable.PATIENT_ID
                    , szPatientID);
            }
            if (!string.IsNullOrEmpty(szPatientName))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                    , szCondition
                    , SystemData.QcModifyNoticeTable.PATIENT_NAME
                    , szPatientName);
            }
            string szOrderBy = string.Format("{0}", SystemData.QcModifyNoticeTable.NOTICE_TIME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable.QC_MODIFY_NOTICE, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcModifyNotices == null)
                    lstQcModifyNotices = new List<QcModifyNotice>();
                do
                {
                    QcModifyNotice qcModifyNotice = new QcModifyNotice();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.QcModifyNoticeTable.MODIFY_NOTICE_ID:
                                qcModifyNotice.MODIFY_NOTICE_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcModifyNoticeTable.MODIFY_PERIOD:
                                qcModifyNotice.MODIFY_PERIOD = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.MODIFY_REMARK:
                                qcModifyNotice.MODIFY_REMARK = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.MODIFY_SCORE:
                                qcModifyNotice.MODIFY_SCORE = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcModifyNoticeTable.NOTICE_STATUS:
                                qcModifyNotice.NOTICE_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcModifyNoticeTable.NOTICE_TIME:
                                qcModifyNotice.NOTICE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcModifyNoticeTable.PATIENT_ID:
                                qcModifyNotice.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.PATIENT_NAME:
                                qcModifyNotice.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.QC_DEPT_CODE:
                                qcModifyNotice.QC_DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.QC_DEPT_NAME:
                                qcModifyNotice.QC_DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.QC_LEVEL:
                                qcModifyNotice.QC_LEVEL = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcModifyNoticeTable.QC_MAN:
                                qcModifyNotice.QC_MAN = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.QC_MAN_ID:
                                qcModifyNotice.QC_MAN_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.RECEIVER:
                                qcModifyNotice.RECEIVER = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.RECEIVER_DEPT_CODE:
                                qcModifyNotice.RECEIVER_DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.RECEIVER_DEPT_NAME:
                                qcModifyNotice.RECEIVER_DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.VISIT_ID:
                                qcModifyNotice.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcModifyNoticeTable.VISIT_NO:
                                qcModifyNotice.VISIT_NO = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstQcModifyNotices.Add(qcModifyNotice);
                } while (dataReader.Read());
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
        /// 新增一条人工核查结果信息
        /// </summary>
        /// <param name="qcModifyNotice">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(QcModifyNotice qcModifyNotice)
        {
            if (qcModifyNotice == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { qcModifyNotice }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (qcModifyNotice.MODIFY_NOTICE_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_NOTICE_ID);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.MODIFY_NOTICE_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_PERIOD);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.MODIFY_PERIOD);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_REMARK);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.MODIFY_REMARK);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_SCORE);
            sbValue.AppendFormat("{0},", qcModifyNotice.MODIFY_SCORE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.MODIFY_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(qcModifyNotice.MODIFY_TIME));
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.NOTICE_STATUS);
            sbValue.AppendFormat("{0},", qcModifyNotice.NOTICE_STATUS);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.NOTICE_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(qcModifyNotice.NOTICE_TIME));
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_DEPT_CODE);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.QC_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_DEPT_NAME);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.QC_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_LEVEL);
            sbValue.AppendFormat("{0},", qcModifyNotice.QC_LEVEL);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_MAN);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.QC_MAN);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.QC_MAN_ID);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.QC_MAN_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.RECEIVER);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_DEPT_CODE);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.RECEIVER_DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_DEPT_NAME);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.RECEIVER_DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.RECEIVER_ID);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.RECEIVER_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.QcModifyNoticeTable.VISIT_NO);
            sbValue.AppendFormat("'{0}',", qcModifyNotice.VISIT_NO);
            sbField.AppendFormat("{0}", SystemData.QcModifyNoticeTable.PATIENT_NAME);
            sbValue.AppendFormat("'{0}'", qcModifyNotice.PATIENT_NAME);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_MODIFY_NOTICE, sbField.ToString(), sbValue.ToString());
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
        public short Update(QcModifyNotice qcModifyNotice)
        {
            if (qcModifyNotice == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { qcModifyNotice }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.MODIFY_PERIOD, qcModifyNotice.MODIFY_PERIOD);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.MODIFY_REMARK, qcModifyNotice.MODIFY_REMARK);
            sbField.AppendFormat("{0}={1},"
                , SystemData.QcModifyNoticeTable.MODIFY_SCORE, qcModifyNotice.MODIFY_SCORE);
            sbField.AppendFormat("{0}={1},"
                , SystemData.QcModifyNoticeTable.NOTICE_STATUS, qcModifyNotice.NOTICE_STATUS);
            sbField.AppendFormat("{0}={1},"
                , SystemData.QcModifyNoticeTable.NOTICE_TIME, base.MedQCAccess.GetSqlTimeFormat(qcModifyNotice.NOTICE_TIME));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.PATIENT_ID, qcModifyNotice.PATIENT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.PATIENT_NAME, qcModifyNotice.PATIENT_NAME);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.QC_DEPT_CODE, qcModifyNotice.QC_DEPT_CODE);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.QC_DEPT_NAME, qcModifyNotice.QC_DEPT_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.QcModifyNoticeTable.QC_LEVEL, qcModifyNotice.QC_LEVEL);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.QC_MAN, qcModifyNotice.QC_MAN);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.QC_MAN_ID, qcModifyNotice.QC_MAN_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.RECEIVER, qcModifyNotice.RECEIVER);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.RECEIVER_DEPT_CODE, qcModifyNotice.RECEIVER_DEPT_CODE);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.RECEIVER_DEPT_NAME, qcModifyNotice.RECEIVER_DEPT_NAME);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcModifyNoticeTable.VISIT_ID, qcModifyNotice.VISIT_ID);
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.QcModifyNoticeTable.VISIT_NO, qcModifyNotice.VISIT_NO);
            string szCondition = string.Format("{0}='{1}'", SystemData.QcModifyNoticeTable.MODIFY_NOTICE_ID, qcModifyNotice.MODIFY_NOTICE_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_MODIFY_NOTICE, sbField.ToString(), szCondition);
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
        public short Delete(string szModifyNoticeID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szModifyNoticeID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szModifyNoticeID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcModifyNoticeTable.MODIFY_NOTICE_ID, szModifyNoticeID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_MODIFY_NOTICE, szCondition);
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
    }
}