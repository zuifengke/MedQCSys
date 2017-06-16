// ***********************************************************
// 病案归档数据相关的访问类.
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

    public class MrArchiveAccess : DBAccessBase
    {
        private static MrArchiveAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static MrArchiveAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new MrArchiveAccess();
                return MrArchiveAccess.m_Instance;
            }
        }

        public short GetMrArchives(DateTime dtVisitTimeBegin, DateTime dtVisitTimeEnd, DateTime dtDischargeTimeBegin, DateTime dtDischargeTimeEnd, string szMrStatus, string szDeptCode, ref List<MrArchive> lstMrArchives)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ARCHIVE_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ARCHIVE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ARCHIVE_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_DISCHARGE_FROM);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_DISCHARGE_NAME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_ADMISSION_NAME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DISCHARGE_DATE_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ADMISSION_DATE_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_ADMISSION_TO);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.MR_CLASS);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.HOS_QCMAN);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.MR_STATUS);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PATIENT_SEX);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PAPER_RECEIVE);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.RETURN_COUNT);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.SUBMIT_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.SUBMIT_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.MrArchiveView.VISIT_NO);
            string szCondition = string.Format("1=1");

            if (dtVisitTimeBegin != SystemParam.Instance.DefaultTime
              && dtVisitTimeEnd != SystemParam.Instance.DefaultTime)
            {
                szCondition = string.Format("{0} AND {1} > {2} AND {1} < {3}"
                    , szCondition
                    , SystemData.MrArchiveView.ADMISSION_DATE_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            if (dtDischargeTimeBegin != SystemParam.Instance.DefaultTime
                && dtDischargeTimeEnd != SystemParam.Instance.DefaultTime)
            {
                szCondition = string.Format("{0} AND {1} > {2} AND {1} < {3}"
                      , szCondition
                      , SystemData.MrArchiveView.DISCHARGE_DATE_TIME
                      , base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeBegin)
                      , base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeEnd));
            }
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.MrArchiveView.DEPT_ADMISSION_TO
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szMrStatus))
            {
                szCondition = string.Format("{0} AND {1} ='{2}'"
                    , szCondition
                    , SystemData.MrArchiveView.MR_STATUS
                    , szMrStatus);
            }
            string szOrderBy = string.Format("{0},{1}"
                , SystemData.MrArchiveView.DEPT_ADMISSION_NAME
                , SystemData.MrArchiveView.PATIENT_NAME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataView.MR_ARCHIVE_V, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstMrArchives == null)
                    lstMrArchives = new List<MrArchive>();
                do
                {
                    MrArchive mrArchive = new MrArchive();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.MrArchiveView.ARCHIVE_DOCTOR:
                                mrArchive.ARCHIVE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.ARCHIVE_TIME:
                                mrArchive.ARCHIVE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.ARCHIVE_DOCTOR_ID:
                                mrArchive.ARCHIVE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.ADMISSION_DATE_TIME:
                                mrArchive.ADMISSION_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.DISCHARGE_DATE_TIME:
                                mrArchive.DISCHARGE_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_DISCHARGE_FROM:
                                mrArchive.DEPT_DISCHARGE_FROM = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_DISCHARGE_NAME:
                                mrArchive.DEPT_DISCHARGE_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_ADMISSION_NAME:
                                mrArchive.DEPT_ADMISSION_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_ADMISSION_TO:
                                mrArchive.DEPT_ADMISSION_TO = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.MR_CLASS:
                                mrArchive.MR_CLASS = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.MR_STATUS:
                                mrArchive.MR_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.HOS_QCMAN:
                                mrArchive.HOS_QCMAN = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.RETURN_COUNT:
                                mrArchive.RETURN_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MrArchiveView.SUBMIT_DOCTOR:
                                mrArchive.SUBMIT_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.SUBMIT_DOCTOR_ID:
                                mrArchive.SUBMIT_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.SUBMIT_TIME:
                                mrArchive.SUBMIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.VISIT_ID:
                                mrArchive.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.PATIENT_ID:
                                mrArchive.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.PATIENT_NAME:
                                mrArchive.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.PATIENT_SEX:
                                mrArchive.PATIENT_SEX = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.VISIT_NO:
                                mrArchive.VISIT_NO = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstMrArchives.Add(mrArchive);
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
        public short GetMrArchives(DateTime dtVisitTimeBegin,DateTime dtVisitTimeEnd, DateTime dtDischargeTimeBegin,DateTime dtDischargeTimeEnd,string szMrStatus,string szDeptCode,string szPatientID,string szPatientName, ref List<MrArchive> lstMrArchives)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ARCHIVE_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ARCHIVE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ARCHIVE_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_DISCHARGE_FROM);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_DISCHARGE_NAME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_ADMISSION_NAME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DISCHARGE_DATE_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.ADMISSION_DATE_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.DEPT_ADMISSION_TO);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.MR_CLASS);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.HOS_QCMAN);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.MR_STATUS);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PATIENT_SEX);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PAPER_RECEIVE);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.RETURN_COUNT);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.SUBMIT_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.SUBMIT_TIME);
            sbField.AppendFormat("{0},", SystemData.MrArchiveView.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.MrArchiveView.VISIT_NO);
            string szCondition = string.Format("1=1");

            if (dtVisitTimeBegin != SystemParam.Instance.DefaultTime
              && dtVisitTimeEnd != SystemParam.Instance.DefaultTime)
            {
                szCondition = string.Format("{0} AND {1} > {2} AND {1} < {3}"
                    , szCondition
                    , SystemData.MrArchiveView.ADMISSION_DATE_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            if (dtDischargeTimeBegin != SystemParam.Instance.DefaultTime
                && dtDischargeTimeEnd != SystemParam.Instance.DefaultTime)
            {
                szCondition = string.Format("{0} AND {1} > {2} AND {1} < {3}"
                      , szCondition
                      , SystemData.MrArchiveView.DISCHARGE_DATE_TIME
                      , base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeBegin)
                      , base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeEnd));
            }
            if(!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.MrArchiveView.DEPT_ADMISSION_TO
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szPatientID))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                  , szCondition
                  , SystemData.MrArchiveView.PATIENT_ID
                  , szPatientID);
            }
            if (!string.IsNullOrEmpty(szPatientName))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                  , szCondition
                  , SystemData.MrArchiveView.PATIENT_NAME
                  , szPatientName);
            }
            if (!string.IsNullOrEmpty(szMrStatus))
            {
                szCondition = string.Format("{0} AND {1} ='{2}'"
                    , szCondition
                    , SystemData.MrArchiveView.MR_STATUS
                    , szMrStatus);
            }
            string szOrderBy = string.Format("{0},{1}"
                , SystemData.MrArchiveView.DEPT_ADMISSION_NAME
                , SystemData.MrArchiveView.PATIENT_NAME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataView.MR_ARCHIVE_V, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstMrArchives == null)
                    lstMrArchives = new List<MrArchive>();
                do
                {
                    MrArchive mrArchive = new MrArchive();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.MrArchiveView.ARCHIVE_DOCTOR:
                                mrArchive.ARCHIVE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.ARCHIVE_TIME:
                                mrArchive.ARCHIVE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.ARCHIVE_DOCTOR_ID:
                                mrArchive.ARCHIVE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.ADMISSION_DATE_TIME:
                                mrArchive.ADMISSION_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.DISCHARGE_DATE_TIME:
                                mrArchive.DISCHARGE_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_DISCHARGE_FROM:
                                mrArchive.DEPT_DISCHARGE_FROM = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_DISCHARGE_NAME:
                                mrArchive.DEPT_DISCHARGE_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_ADMISSION_NAME:
                                mrArchive.DEPT_ADMISSION_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.DEPT_ADMISSION_TO:
                                mrArchive.DEPT_ADMISSION_TO = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.MR_CLASS:
                                mrArchive.MR_CLASS = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.MR_STATUS:
                                mrArchive.MR_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.HOS_QCMAN:
                                mrArchive.HOS_QCMAN = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.RETURN_COUNT:
                                mrArchive.RETURN_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MrArchiveView.SUBMIT_DOCTOR:
                                mrArchive.SUBMIT_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.SUBMIT_DOCTOR_ID:
                                mrArchive.SUBMIT_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.SUBMIT_TIME:
                                mrArchive.SUBMIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MrArchiveView.VISIT_ID:
                                mrArchive.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.PATIENT_ID:
                                mrArchive.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.PATIENT_NAME:
                                mrArchive.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.PATIENT_SEX:
                                mrArchive.PATIENT_SEX = dataReader.GetString(i);
                                break;
                            case SystemData.MrArchiveView.VISIT_NO:
                                mrArchive.VISIT_NO = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstMrArchives.Add(mrArchive);
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
    }
}