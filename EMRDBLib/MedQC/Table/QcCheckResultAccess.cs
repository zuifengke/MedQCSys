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

    public class QcCheckResultAccess : DBAccessBase
    {
        private static QcCheckResultAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static QcCheckResultAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcCheckResultAccess();
                return QcCheckResultAccess.m_Instance;
            }
        }


        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcCheckResults(string szPatientID, string szVisitID, int nStatType, ref List<QcCheckResult> lstQcCheckResults)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("*");
            string szCondition = string.Format("1=1 ");
            if (!string.IsNullOrEmpty(szPatientID) && !string.IsNullOrEmpty(szVisitID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}' AND {3}='{4}'"
                    , szCondition
                    , SystemData.QcCheckResultTable.PATIENT_ID
                    , szPatientID
                    , SystemData.QcCheckResultTable.VISIT_ID
                    , szVisitID);
            }
            szCondition = string.Format("{0} AND {1}={2}"
                , szCondition
                , SystemData.QcCheckResultTable.STAT_TYPE
                , nStatType);

            string szOrderBy = string.Format("{0}"
            , SystemData.QcCheckResultTable.ORDER_VALUE);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , szField, SystemData.DataTable.QC_CHECK_RESULT, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcCheckResults == null)
                    lstQcCheckResults = new List<QcCheckResult>();
                do
                {
                    QcCheckResult qcCheckResult = new QcCheckResult();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.QcCheckResultTable.BUG_CLASS:
                                qcCheckResult.BUG_CLASS = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.CHECKER_NAME:
                                qcCheckResult.CHECKER_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECKER_ID:
                                qcCheckResult.CHECKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECK_DATE:
                                qcCheckResult.CHECK_DATE = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECK_POINT_ID:
                                qcCheckResult.CHECK_POINT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECK_RESULT_ID:
                                qcCheckResult.CHECK_RESULT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcCheckResultTable.CHECK_TYPE:
                                qcCheckResult.CHECK_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CREATE_ID:
                                qcCheckResult.CREATE_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CREATE_NAME:
                                qcCheckResult.CREATE_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DEPT_CODE:
                                qcCheckResult.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DEPT_IN_CHARGE:
                                qcCheckResult.DEPT_IN_CHARGE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.INCHARGE_DOCTOR:
                                qcCheckResult.INCHARGE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DOCTYPE_ID:
                                qcCheckResult.DOCTYPE_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DOC_SETID:
                                qcCheckResult.DOC_SETID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DOC_TIME:
                                qcCheckResult.DOC_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcCheckResultTable.DOC_TITLE:
                                qcCheckResult.DOC_TITLE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.ERROR_COUNT:
                                qcCheckResult.ERROR_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.ISVETO:
                                qcCheckResult.ISVETO = int.Parse(dataReader.GetValue(i).ToString()) == 1;
                                break;
                            case SystemData.QcCheckResultTable.MODIFY_TIME:
                                qcCheckResult.MODIFY_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcCheckResultTable.MR_STATUS:
                                qcCheckResult.MR_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MSG_DICT_CODE:
                                qcCheckResult.MSG_DICT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MSG_DICT_MESSAGE:
                                qcCheckResult.MSG_DICT_MESSAGE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.ORDER_VALUE:
                                qcCheckResult.ORDER_VALUE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.PATIENT_ID:
                                qcCheckResult.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.PATIENT_NAME:
                                qcCheckResult.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.QA_EVENT_TYPE:
                                qcCheckResult.QA_EVENT_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.QC_EXPLAIN:
                                qcCheckResult.QC_EXPLAIN = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.QC_RESULT:
                                qcCheckResult.QC_RESULT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.REMARKS:
                                qcCheckResult.REMARKS = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.SOCRE:
                                qcCheckResult.SCORE = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.STAT_TYPE:
                                qcCheckResult.STAT_TYPE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.VISIT_ID:
                                qcCheckResult.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.VISIT_NO:
                                qcCheckResult.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MSG_ID:
                                qcCheckResult.MSG_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MODIFY_NOTICE_ID:
                                qcCheckResult.MODIFY_NOTICE_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.INCHARGE_DOCTOR_ID:
                                qcCheckResult.INCHARGE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstQcCheckResults.Add(qcCheckResult);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckResult.GetQcCheckResults", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcCheckResults(DateTime dtBeginTime, DateTime dtEndTime, string szPatientID, string szVisitID, string szDeptCode, string szOrderBy, string szMrStatus, int nStatType, ref List<QcCheckResult> lstQcCheckResults)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("*");
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
            if (dtBeginTime != DateTime.Parse("1900-1-1") && dtEndTime != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND {1}>{2} AND {1}<{3}"
                    , szCondition
                    , SystemData.QcCheckResultTable.CHECK_DATE
                    , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime)
                    , base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            }
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.QcCheckResultTable.DEPT_CODE
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szMrStatus))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.QcCheckResultTable.MR_STATUS
                    , szMrStatus);
            }
            szCondition = string.Format("{0} AND {1}={2}"
                , szCondition
                , SystemData.QcCheckResultTable.STAT_TYPE
                , nStatType);
            if (string.IsNullOrEmpty(szOrderBy))
            {
                szOrderBy = string.Format("{0},{1},{2},{3},{4}"
               , SystemData.QcCheckResultTable.ORDER_VALUE
               , SystemData.QcCheckResultTable.DEPT_CODE
               , SystemData.QcCheckResultTable.INCHARGE_DOCTOR
               , SystemData.QcCheckResultTable.PATIENT_ID
               , SystemData.QcCheckResultTable.VISIT_ID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , szField, SystemData.DataTable.QC_CHECK_RESULT, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcCheckResults == null)
                    lstQcCheckResults = new List<QcCheckResult>();
                lstQcCheckResults.Clear();
                do
                {
                    QcCheckResult qcCheckResult = new QcCheckResult();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.QcCheckResultTable.BUG_CLASS:
                                qcCheckResult.BUG_CLASS = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.CHECKER_NAME:
                                qcCheckResult.CHECKER_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECKER_ID:
                                qcCheckResult.CHECKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECK_DATE:
                                qcCheckResult.CHECK_DATE = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECK_POINT_ID:
                                qcCheckResult.CHECK_POINT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CHECK_RESULT_ID:
                                qcCheckResult.CHECK_RESULT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcCheckResultTable.CHECK_TYPE:
                                qcCheckResult.CHECK_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CREATE_ID:
                                qcCheckResult.CREATE_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.CREATE_NAME:
                                qcCheckResult.CREATE_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DEPT_CODE:
                                qcCheckResult.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DEPT_IN_CHARGE:
                                qcCheckResult.DEPT_IN_CHARGE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.INCHARGE_DOCTOR:
                                qcCheckResult.INCHARGE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DOCTYPE_ID:
                                qcCheckResult.DOCTYPE_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DOC_SETID:
                                qcCheckResult.DOC_SETID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.DOC_TIME:
                                qcCheckResult.DOC_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcCheckResultTable.DOC_TITLE:
                                qcCheckResult.DOC_TITLE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.ERROR_COUNT:
                                qcCheckResult.ERROR_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.ISVETO:
                                qcCheckResult.ISVETO = int.Parse(dataReader.GetValue(i).ToString()) == 1;
                                break;
                            case SystemData.QcCheckResultTable.MODIFY_TIME:
                                qcCheckResult.MODIFY_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcCheckResultTable.MR_STATUS:
                                qcCheckResult.MR_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MSG_DICT_CODE:
                                qcCheckResult.MSG_DICT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MSG_DICT_MESSAGE:
                                qcCheckResult.MSG_DICT_MESSAGE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.ORDER_VALUE:
                                qcCheckResult.ORDER_VALUE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.PATIENT_ID:
                                qcCheckResult.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.PATIENT_NAME:
                                qcCheckResult.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.QA_EVENT_TYPE:
                                qcCheckResult.QA_EVENT_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.QC_EXPLAIN:
                                qcCheckResult.QC_EXPLAIN = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.QC_RESULT:
                                qcCheckResult.QC_RESULT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.REMARKS:
                                qcCheckResult.REMARKS = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.SOCRE:
                                qcCheckResult.SCORE = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.STAT_TYPE:
                                qcCheckResult.STAT_TYPE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcCheckResultTable.VISIT_ID:
                                qcCheckResult.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.VISIT_NO:
                                qcCheckResult.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MSG_ID:
                                qcCheckResult.MSG_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.MODIFY_NOTICE_ID:
                                qcCheckResult.MODIFY_NOTICE_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcCheckResultTable.INCHARGE_DOCTOR_ID:
                                qcCheckResult.INCHARGE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstQcCheckResults.Add(qcCheckResult);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckResult.GetQcCheckResults", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcCheckResult(string szPatientID, string szVisitID, string szCheckPointID, ref QcCheckResult qcCheckResult)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("*");
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
            if (!string.IsNullOrEmpty(szCheckPointID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.QcCheckResultTable.CHECK_POINT_ID
                    , szCheckPointID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , szField, SystemData.DataTable.QC_CHECK_RESULT, szCondition, SystemData.TimeRuleTable.ORDER_VALUE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                qcCheckResult = new QcCheckResult();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.QcCheckResultTable.BUG_CLASS:
                            qcCheckResult.BUG_CLASS = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcCheckResultTable.CHECKER_NAME:
                            qcCheckResult.CHECKER_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.CHECKER_ID:
                            qcCheckResult.CHECKER_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.CHECK_DATE:
                            qcCheckResult.CHECK_DATE = dataReader.GetDateTime(i);
                            break;
                        case SystemData.QcCheckResultTable.CHECK_POINT_ID:
                            qcCheckResult.CHECK_POINT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.CHECK_RESULT_ID:
                            qcCheckResult.CHECK_RESULT_ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.QcCheckResultTable.CHECK_TYPE:
                            qcCheckResult.CHECK_TYPE = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.CREATE_ID:
                            qcCheckResult.CREATE_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.CREATE_NAME:
                            qcCheckResult.CREATE_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.DEPT_CODE:
                            qcCheckResult.DEPT_CODE = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.DEPT_IN_CHARGE:
                            qcCheckResult.DEPT_IN_CHARGE = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.INCHARGE_DOCTOR:
                            qcCheckResult.INCHARGE_DOCTOR = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.DOCTYPE_ID:
                            qcCheckResult.DOCTYPE_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.DOC_SETID:
                            qcCheckResult.DOC_SETID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.DOC_TIME:
                            qcCheckResult.DOC_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.QcCheckResultTable.DOC_TITLE:
                            qcCheckResult.DOC_TITLE = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.ERROR_COUNT:
                            qcCheckResult.ERROR_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcCheckResultTable.ISVETO:
                            qcCheckResult.ISVETO = int.Parse(dataReader.GetValue(i).ToString()) == 1;
                            break;
                        case SystemData.QcCheckResultTable.MODIFY_TIME:
                            qcCheckResult.MODIFY_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.QcCheckResultTable.MR_STATUS:
                            qcCheckResult.MR_STATUS = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.MSG_DICT_CODE:
                            qcCheckResult.MSG_DICT_CODE = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.MSG_DICT_MESSAGE:
                            qcCheckResult.MSG_DICT_MESSAGE = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.ORDER_VALUE:
                            qcCheckResult.ORDER_VALUE = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcCheckResultTable.PATIENT_ID:
                            qcCheckResult.PATIENT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.PATIENT_NAME:
                            qcCheckResult.PATIENT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.QA_EVENT_TYPE:
                            qcCheckResult.QA_EVENT_TYPE = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.QC_EXPLAIN:
                            qcCheckResult.QC_EXPLAIN = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.QC_RESULT:
                            qcCheckResult.QC_RESULT = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcCheckResultTable.REMARKS:
                            qcCheckResult.REMARKS = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.SOCRE:
                            qcCheckResult.SCORE = float.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcCheckResultTable.STAT_TYPE:
                            qcCheckResult.STAT_TYPE = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcCheckResultTable.VISIT_ID:
                            qcCheckResult.VISIT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.VISIT_NO:
                            qcCheckResult.VISIT_NO = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.MSG_ID:
                            qcCheckResult.MSG_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.MODIFY_NOTICE_ID:
                            qcCheckResult.MODIFY_NOTICE_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcCheckResultTable.INCHARGE_DOCTOR_ID:
                            qcCheckResult.INCHARGE_DOCTOR_ID = dataReader.GetString(i);
                            break;
                        default: break;
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckResult.GetQcCheckResults", new string[] { "szSQL" }, new object[] { szSQL
    }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 新增一条自动核查结果信息
        /// </summary>
        /// <param name="qcCheckResult">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveQcCheckResult(QcCheckResult qcCheckResult)
        {
            if (qcCheckResult == null)
            {
                LogManager.Instance.WriteLog("QcCheckResultAccess.SaveQcCheckResult", new string[] { "timeQCRule" }
                    , new object[] { qcCheckResult }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            //保存前确认是否已经存在
            QcCheckResult exist = null;
            short shRet = this.GetQcCheckResult(qcCheckResult.PATIENT_ID, qcCheckResult.VISIT_ID, qcCheckResult.CHECK_POINT_ID, ref exist);
            if (shRet == SystemData.ReturnValue.OK)
            {
                qcCheckResult.CHECK_RESULT_ID = exist.CHECK_RESULT_ID;
                return this.Update(qcCheckResult);

            }
            else
            {
                //生成自增主键
                qcCheckResult.CHECK_RESULT_ID = qcCheckResult.MakeID();
            }
            if (qcCheckResult.CHECK_RESULT_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            
            return this.Insert(qcCheckResult);
        }
        /// <summary>
        /// 新增一条人工核查结果信息
        /// </summary>
        /// <param name="qcCheckResult">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(QcCheckResult qcCheckResult)
        {
            if (qcCheckResult == null)
            {
                LogManager.Instance.WriteLog("QcCheckResultAccess.Insert", new string[] { "timeQCRule" }
                    , new object[] { qcCheckResult }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (qcCheckResult.CHECK_RESULT_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34}"
                , SystemData.QcCheckResultTable.BUG_CLASS, SystemData.QcCheckResultTable.CHECKER_NAME
                , SystemData.QcCheckResultTable.CHECK_DATE, SystemData.QcCheckResultTable.CHECK_POINT_ID
                , SystemData.QcCheckResultTable.CHECK_RESULT_ID, SystemData.QcCheckResultTable.CHECK_TYPE
                , SystemData.QcCheckResultTable.CREATE_ID, SystemData.QcCheckResultTable.CREATE_NAME
                , SystemData.QcCheckResultTable.DEPT_IN_CHARGE, SystemData.QcCheckResultTable.INCHARGE_DOCTOR
                , SystemData.QcCheckResultTable.DOCTYPE_ID, SystemData.QcCheckResultTable.DOC_SETID
                , SystemData.QcCheckResultTable.DOC_TIME, SystemData.QcCheckResultTable.DOC_TITLE
                , SystemData.QcCheckResultTable.MODIFY_TIME, SystemData.QcCheckResultTable.ORDER_VALUE
                , SystemData.QcCheckResultTable.PATIENT_ID, SystemData.QcCheckResultTable.PATIENT_NAME
                , SystemData.QcCheckResultTable.SOCRE, SystemData.QcCheckResultTable.QC_EXPLAIN
                , SystemData.QcCheckResultTable.QC_RESULT, SystemData.QcCheckResultTable.VISIT_ID
                , SystemData.QcCheckResultTable.MSG_DICT_MESSAGE, SystemData.QcCheckResultTable.DEPT_CODE
                , SystemData.QcCheckResultTable.ERROR_COUNT, SystemData.QcCheckResultTable.QA_EVENT_TYPE
                , SystemData.QcCheckResultTable.MSG_DICT_CODE
                , SystemData.QcCheckResultTable.STAT_TYPE
                , SystemData.QcCheckResultTable.MR_STATUS
                , SystemData.QcCheckResultTable.VISIT_NO
                , SystemData.QcCheckResultTable.REMARKS
                , SystemData.QcCheckResultTable.CHECKER_ID
                , SystemData.QcCheckResultTable.MSG_ID
                , SystemData.QcCheckResultTable.MODIFY_NOTICE_ID
                , SystemData.QcCheckResultTable.INCHARGE_DOCTOR_ID);
            string szValue = string.Format("{0},'{1}',{2},'{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}',{14},{15},'{16}','{17}',{18},'{19}',{20},'{21}','{22}','{23}',{24},'{25}','{26}',{27},'{28}','{29}','{30}','{31}','{32}','{33}','{34}'"
                , qcCheckResult.BUG_CLASS.ToString()
                , qcCheckResult.CHECKER_NAME
                , base.MedQCAccess.GetSqlTimeFormat(qcCheckResult.CHECK_DATE)
                , qcCheckResult.CHECK_POINT_ID
                , qcCheckResult.CHECK_RESULT_ID.ToString()
                , qcCheckResult.CHECK_TYPE
                , qcCheckResult.CREATE_ID
                , qcCheckResult.CREATE_NAME
                , qcCheckResult.DEPT_IN_CHARGE
                , qcCheckResult.INCHARGE_DOCTOR
                , qcCheckResult.DOCTYPE_ID
                , qcCheckResult.DOC_SETID
                , base.MedQCAccess.GetSqlTimeFormat(qcCheckResult.DOC_TIME)
                , qcCheckResult.DOC_TITLE
                , base.MedQCAccess.GetSqlTimeFormat(qcCheckResult.MODIFY_TIME)
                , qcCheckResult.ORDER_VALUE
                , qcCheckResult.PATIENT_ID
                , qcCheckResult.PATIENT_NAME
                , qcCheckResult.SCORE
                , qcCheckResult.QC_EXPLAIN
                , qcCheckResult.QC_RESULT
                , qcCheckResult.VISIT_ID
                , qcCheckResult.MSG_DICT_MESSAGE
                , qcCheckResult.DEPT_CODE
                , qcCheckResult.ERROR_COUNT
                , qcCheckResult.QA_EVENT_TYPE
                , qcCheckResult.MSG_DICT_CODE
                , qcCheckResult.STAT_TYPE
                , qcCheckResult.MR_STATUS
                , qcCheckResult.VISIT_NO
                , qcCheckResult.REMARKS
                , qcCheckResult.CHECKER_ID
                , qcCheckResult.MSG_ID
                , qcCheckResult.MODIFY_NOTICE_ID
                , qcCheckResult.INCHARGE_DOCTOR_ID);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_CHECK_RESULT, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckResultAccess.SaveQcCheckResult", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcCheckResultAccess.SaveQcCheckResult", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 更新一条自动核查规则配置信息
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(QcCheckResult qcCheckResult)
        {
            if (qcCheckResult == null)
            {
                LogManager.Instance.WriteLog("QcCheckResultAccess.UpdateQcCheckResult", new string[] { "qcCheckResult" }
                    , new object[] { qcCheckResult }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}={1},{2}='{3}',{4}={5},{6}='{7}',{8}='{9}',{10}='{11}',{12}='{13}',{14}='{15}',{16}='{17}',{18}='{19}',{20}='{21}',{22}={23},{24}='{25}',{26}={27},{28}={29},{30}='{31}',{32}='{33}',{34}={35},{36}='{37}',{38}={39},{40}='{41}',{42}='{43}',{44}='{45}',{46}={47},{48}='{49}',{50}='{51}',{52}='{53}',{54}='{55}',{56}='{57}',{58}='{59}',{60}='{61}',{62}='{63}',{64}='{65}'"
                , SystemData.QcCheckResultTable.BUG_CLASS, qcCheckResult.BUG_CLASS
                , SystemData.QcCheckResultTable.CHECKER_NAME, qcCheckResult.CHECKER_NAME
                , SystemData.QcCheckResultTable.CHECK_DATE, base.MedQCAccess.GetSqlTimeFormat(qcCheckResult.CHECK_DATE)
                , SystemData.QcCheckResultTable.CHECK_POINT_ID, qcCheckResult.CHECK_POINT_ID
                , SystemData.QcCheckResultTable.CHECK_TYPE, qcCheckResult.CHECK_TYPE
                , SystemData.QcCheckResultTable.CREATE_ID, qcCheckResult.CREATE_ID
                , SystemData.QcCheckResultTable.CREATE_NAME, qcCheckResult.CREATE_NAME
                , SystemData.QcCheckResultTable.DEPT_IN_CHARGE, qcCheckResult.DEPT_IN_CHARGE
                , SystemData.QcCheckResultTable.INCHARGE_DOCTOR, qcCheckResult.INCHARGE_DOCTOR
                , SystemData.QcCheckResultTable.DOCTYPE_ID, qcCheckResult.DOCTYPE_ID
                , SystemData.QcCheckResultTable.DOC_SETID, qcCheckResult.DOC_SETID
                , SystemData.QcCheckResultTable.DOC_TIME, base.MedQCAccess.GetSqlTimeFormat(qcCheckResult.DOC_TIME)
                , SystemData.QcCheckResultTable.DOC_TITLE, qcCheckResult.DOC_TITLE
                , SystemData.QcCheckResultTable.MODIFY_TIME, base.MedQCAccess.GetSqlTimeFormat(qcCheckResult.MODIFY_TIME)
                , SystemData.QcCheckResultTable.ORDER_VALUE, qcCheckResult.ORDER_VALUE
                , SystemData.QcCheckResultTable.PATIENT_ID, qcCheckResult.PATIENT_ID
                , SystemData.QcCheckResultTable.PATIENT_NAME, qcCheckResult.PATIENT_NAME
                , SystemData.QcCheckResultTable.SOCRE, qcCheckResult.SCORE
                , SystemData.QcCheckResultTable.QC_EXPLAIN, qcCheckResult.QC_EXPLAIN
                , SystemData.QcCheckResultTable.QC_RESULT, qcCheckResult.QC_RESULT
                , SystemData.QcCheckResultTable.VISIT_ID, qcCheckResult.VISIT_ID
                , SystemData.QcCheckResultTable.MSG_DICT_MESSAGE, qcCheckResult.MSG_DICT_MESSAGE
                , SystemData.QcCheckResultTable.DEPT_CODE, qcCheckResult.DEPT_CODE
                , SystemData.QcCheckResultTable.ERROR_COUNT, qcCheckResult.ERROR_COUNT
                , SystemData.QcCheckResultTable.QA_EVENT_TYPE, qcCheckResult.QA_EVENT_TYPE
                , SystemData.QcCheckResultTable.MSG_DICT_CODE, qcCheckResult.MSG_DICT_CODE
                , SystemData.QcCheckResultTable.MR_STATUS, qcCheckResult.MR_STATUS
                , SystemData.QcCheckResultTable.VISIT_NO, qcCheckResult.VISIT_NO
                , SystemData.QcCheckResultTable.REMARKS, qcCheckResult.REMARKS
                , SystemData.QcCheckResultTable.CHECKER_ID, qcCheckResult.CHECKER_ID
                , SystemData.QcCheckResultTable.MSG_ID, qcCheckResult.MSG_ID
                , SystemData.QcCheckResultTable.MODIFY_NOTICE_ID, qcCheckResult.MODIFY_NOTICE_ID
                , SystemData.QcCheckResultTable.INCHARGE_DOCTOR_ID, qcCheckResult.INCHARGE_DOCTOR_ID);

            string szCondition = string.Format("{0}='{1}'", SystemData.QcCheckResultTable.CHECK_RESULT_ID, qcCheckResult.CHECK_RESULT_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_CHECK_RESULT, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckResultAccess.UpdateQcCheckResult", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcCheckResultAccess.UpdateQcCheckResult", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条自动核查结果信息
        /// </summary>
        /// <param name="szRuleID">自动核查结果ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string nCheckResultID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(nCheckResultID))
            {
                LogManager.Instance.WriteLog("", new string[] { "szCheckResultID" }
                    , new object[] { nCheckResultID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcCheckResultTable.CHECK_RESULT_ID, nCheckResultID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_CHECK_RESULT, szCondition);

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