// ***********************************************************
// 病历质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using Heren.Common.Libraries.Ftp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{

    public class RecUploadAccess : DBAccessBase
    {
        private static RecUploadAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RecUploadAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RecUploadAccess();
                return RecUploadAccess.m_Instance;
            }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetRecUpload(string szUploadID, ref RecUpload RecUpload)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_STATUS);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_LOG);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_TIME);
            sbField.AppendFormat("{0}", SystemData.RecUploadTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szUploadID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecUploadTable.UPLOAD_ID
                    , szUploadID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PAPER, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (RecUpload == null)
                    RecUpload = new RecUpload();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.RecUploadTable.PATIENT_ID:
                            RecUpload.PATIENT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecUploadTable.PATIENT_NAME:
                            RecUpload.PATIENT_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.RecUploadTable.UPLOAD_STATUS:
                            RecUpload.UPLOAD_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.RecUploadTable.UPLOAD_ID:
                            RecUpload.UPLOAD_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecUploadTable.VISIT_ID:
                            RecUpload.VISIT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecUploadTable.VISIT_NO:
                            RecUpload.VISIT_NO = dataReader.GetString(i);
                            break;
                        case SystemData.RecUploadTable.UPLOAD_LOG:
                            RecUpload.UPLOAD_LOG = dataReader.GetString(i);
                            break;
                        case SystemData.RecUploadTable.UPLOAD_TIME:
                            RecUpload.UPLOAD_TIME = dataReader.GetDateTime(i);
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
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        public short GetRecUploads(string szPatientID, string szVisitNo, ref List<RecUpload> lstRecUploads)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_STATUS);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_LOG);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_TIME);
            sbField.AppendFormat("{0}", SystemData.RecUploadTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.RecUploadTable.PATIENT_ID, szPatientID
                , SystemData.RecUploadTable.VISIT_NO, szVisitNo);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_UPLOAD, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecUploads == null)
                    lstRecUploads = new List<RecUpload>();
                do
                {
                    RecUpload RecUpload = new RecUpload();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecUploadTable.PATIENT_ID:
                                RecUpload.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.PATIENT_NAME:
                                RecUpload.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.UPLOAD_STATUS:
                                RecUpload.UPLOAD_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecUploadTable.UPLOAD_ID:
                                RecUpload.UPLOAD_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.VISIT_ID:
                                RecUpload.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.VISIT_NO:
                                RecUpload.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.UPLOAD_LOG:
                                RecUpload.UPLOAD_LOG = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.UPLOAD_TIME:
                                RecUpload.UPLOAD_TIME = dataReader.GetDateTime(i);
                                break;
                        }
                    }
                    lstRecUploads.Add(RecUpload);
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

        public short GetRecUploads(string szPatientID, string szUploadStatus, string szTimeType, DateTime dtStartTime, DateTime dtEndTime, string szDeptCodes, ref List<RecUpload> lstRecUploads)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.PATIENT_ID);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.PATIENT_NAME);
            sbField.AppendFormat("B.{0},", SystemData.RecUploadTable.UPLOAD_STATUS);
            sbField.AppendFormat("B.{0},", SystemData.RecUploadTable.UPLOAD_ID);
            sbField.AppendFormat("B.{0},", SystemData.RecUploadTable.UPLOAD_LOG);
            sbField.AppendFormat("B.{0},", SystemData.RecUploadTable.UPLOAD_TIME);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.PATIENT_ID);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.VISIT_ID);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.DIAGNOSIS);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.DISCHARGE_TIME);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.DEPT_NAME);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.VISIT_TIME);
            sbField.AppendFormat("A.{0},", SystemData.PatVisitView.INCHARGE_DOCTOR);
            sbField.AppendFormat("A.{0}", SystemData.RecUploadTable.VISIT_NO);
            string szCondition = string.Format("1=1 AND A.{0}=B.{0}(+) AND A.{1}=B.{1}(+)"
                , SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID);
            if (!string.IsNullOrEmpty(szPatientID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecUploadTable.PATIENT_ID, szPatientID);
            }
            if (!string.IsNullOrEmpty(szDeptCodes))
            {
                szCondition = string.Format("{0} AND {1} in({2})"
                    , szCondition
                    , SystemData.PatVisitView.DEPT_CODE, szDeptCodes);
            }
            szCondition = string.Format("{0} AND {1} >= {2} AND {1}<={3}"
                , szCondition
                , szTimeType
                , base.MedQCAccess.GetSqlTimeFormat(dtStartTime)
                , base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            if (!string.IsNullOrEmpty(szUploadStatus))
            {
                int nUploadStatus = SystemData.UploadStatus.GetMsgStateCode(szUploadStatus);
                if (szUploadStatus == SystemData.UploadStatus.CnNot)
                {
                    szCondition = string.Format("{0} AND ({1} is null or {1} = 0 )"
                        , szCondition
                        , SystemData.RecUploadTable.UPLOAD_STATUS);
                }
                else
                    szCondition = string.Format("{0} AND {1} = {2}"
                        , szCondition
                        , SystemData.RecUploadTable.UPLOAD_STATUS
                        , nUploadStatus);
            }
            string szTable = string.Format("{0} A,{1} B"
                , SystemData.DataView.PAT_VISIT_V
                , SystemData.DataTable.REC_UPLOAD);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), szTable, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecUploads == null)
                    lstRecUploads = new List<RecUpload>();
                do
                {
                    RecUpload RecUpload = new RecUpload();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecUploadTable.PATIENT_ID:
                                RecUpload.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.PATIENT_NAME:
                                RecUpload.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.RecUploadTable.UPLOAD_STATUS:
                                RecUpload.UPLOAD_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecUploadTable.UPLOAD_ID:
                                RecUpload.UPLOAD_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecUploadTable.VISIT_ID:
                                RecUpload.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecUploadTable.VISIT_NO:
                                RecUpload.VISIT_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecUploadTable.UPLOAD_LOG:
                                RecUpload.UPLOAD_LOG = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecUploadTable.UPLOAD_TIME:
                                RecUpload.UPLOAD_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.PatVisitView.DIAGNOSIS:
                                RecUpload.Diagnosis = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.PatVisitView.DEPT_NAME:
                                RecUpload.DeptName = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.PatVisitView.DISCHARGE_TIME:
                                RecUpload.DischargeTime = dataReader.GetDateTime(i);
                                break;
                            case SystemData.PatVisitView.VISIT_TIME:
                                RecUpload.VisitTime = dataReader.GetDateTime(i);
                                break;
                            case SystemData.PatVisitView.INCHARGE_DOCTOR:
                                RecUpload.InchargeDoctor = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.PatVisitView.PATIENT_SEX:
                                RecUpload.PatientSex = dataReader.GetValue(i).ToString();
                                break;
                        }
                    }
                    lstRecUploads.Add(RecUpload);
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
        /// <param name="recUpload">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(RecUpload recUpload)
        {
            if (recUpload == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recUpload }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (recUpload.UPLOAD_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", recUpload.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_NAME);
            sbValue.AppendFormat("'{0}',", recUpload.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_STATUS);
            sbValue.AppendFormat("{0},", recUpload.UPLOAD_STATUS);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(recUpload.UPLOAD_TIME));
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_ID);
            sbValue.AppendFormat("'{0}',", recUpload.UPLOAD_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_LOG);
            sbValue.AppendFormat("'{0}',", recUpload.UPLOAD_LOG);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", recUpload.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecUploadTable.VISIT_NO);
            sbValue.AppendFormat("'{0}'", recUpload.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.REC_UPLOAD, sbField.ToString(), sbValue.ToString());
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
        public short Update(RecUpload model)
        {
            if (model == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { model }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.PATIENT_ID, model.PATIENT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.PATIENT_NAME, model.PATIENT_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecUploadTable.UPLOAD_STATUS, model.UPLOAD_STATUS);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.VISIT_ID, model.VISIT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.VISIT_NO, model.VISIT_NO);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.UPLOAD_LOG, model.UPLOAD_LOG);
            sbField.AppendFormat("{0}={1}"
                , SystemData.RecUploadTable.UPLOAD_TIME,base.MedQCAccess.GetSqlTimeFormat(model.UPLOAD_TIME));
            string szCondition = string.Format("{0}='{1}'", SystemData.RecUploadTable.UPLOAD_ID, model.UPLOAD_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REC_UPLOAD, sbField.ToString(), szCondition);
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
        /// 
        /// </summary>
        /// <param name="szRuleID">自动核查结果ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.RecUploadTable.UPLOAD_ID, szID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.REC_UPLOAD, szCondition);
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