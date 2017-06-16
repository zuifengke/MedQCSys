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
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.STATUS);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.VISIT_ID);
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
                        case SystemData.RecUploadTable.STATUS:
                            RecUpload.STATUS = int.Parse(dataReader.GetValue(i).ToString());
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
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.STATUS);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecUploadTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.RecUploadTable.PATIENT_ID, szPatientID
                , SystemData.RecUploadTable.VISIT_NO,szVisitNo);
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
                            case SystemData.RecUploadTable.STATUS:
                                RecUpload.STATUS = int.Parse(dataReader.GetValue(i).ToString());
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
        /// <param name="RecUpload">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(RecUpload RecUpload)
        {
            if (RecUpload == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { RecUpload }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (RecUpload.UPLOAD_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", RecUpload.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.PATIENT_NAME);
            sbValue.AppendFormat("'{0}',", RecUpload.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.STATUS);
            sbValue.AppendFormat("{0},", RecUpload.STATUS);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.UPLOAD_ID);
            sbValue.AppendFormat("'{0}',", RecUpload.UPLOAD_ID);
            sbField.AppendFormat("{0},", SystemData.RecUploadTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", RecUpload.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecUploadTable.VISIT_NO);
            sbValue.AppendFormat("'{0}'", RecUpload.VISIT_NO);
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
        public short Update(RecUpload RecUpload)
        {
            if (RecUpload == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { RecUpload }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.PATIENT_ID,RecUpload.PATIENT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.PATIENT_NAME, RecUpload.PATIENT_NAME);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecUploadTable.STATUS, RecUpload.STATUS);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecUploadTable.UPLOAD_ID, RecUpload.UPLOAD_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecUploadTable.VISIT_ID, RecUpload.VISIT_ID);
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.RecUploadTable.VISIT_NO, RecUpload.VISIT_NO);
            string szCondition = string.Format("{0}='{1}'", SystemData.RecUploadTable.UPLOAD_ID, RecUpload.UPLOAD_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REC_PAPER, sbField.ToString(), szCondition);
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