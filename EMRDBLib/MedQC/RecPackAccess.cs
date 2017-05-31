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

    public class RecPackAccess : DBAccessBase
    {
        private static RecPackAccess m_Instance = null;

        public static RecPackAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RecPackAccess();
                return RecPackAccess.m_Instance;
            }
        }

        public short GetRecPacks(string szPackerID, ref List<RecPack> lstRecPacks)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.ACCESS_ERROR;
            if (string.IsNullOrEmpty(szPackerID))
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPackTable.CASE_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_NO);
            sbField.AppendFormat("{0}", SystemData.RecPackTable.PAPER_NUMBER);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPackerID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecPackTable.PACKER_ID
                    , szPackerID);
            }

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PACK, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPacks == null)
                    lstRecPacks = new List<RecPack>();
                do
                {
                    RecPack RecPack = new RecPack();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPackTable.CASE_NO:
                                RecPack.CASE_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.DISCHARGE_TIME:
                                RecPack.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.HOSPITAL_DISTRICT:
                                RecPack.HOSPITAL_DISTRICT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER:
                                RecPack.PACKER = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_ID:
                                RecPack.PACK_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_NO:
                                RecPack.PACK_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PATIENT_ID:
                                RecPack.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_ID:
                                RecPack.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_NO:
                                RecPack.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER_ID:
                                RecPack.PACKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_TIME:
                                RecPack.PACK_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.PAPER_NUMBER:
                                RecPack.PAPER_NUMBER = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPackTable.PATIENT_NAME:
                                RecPack.PATIENT_NAME = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPacks.Add(RecPack);
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

        public short GetRecPacks(string szCaseNo,string szPackNo,string szPatientID, ref List<RecPack> lstRecPacks)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.ACCESS_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPackTable.CASE_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_NO);
            sbField.AppendFormat("{0}", SystemData.RecPackTable.PAPER_NUMBER);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szCaseNo))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecPackTable.CASE_NO
                    , szCaseNo);
            }
            if (!string.IsNullOrEmpty(szPackNo))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecPackTable.PACK_NO
                    , szPackNo);
            }
            if (!string.IsNullOrEmpty(szPatientID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecPackTable.PATIENT_ID
                    , szPatientID);
            }

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PACK, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPacks == null)
                    lstRecPacks = new List<RecPack>();
                do
                {
                    RecPack RecPack = new RecPack();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPackTable.CASE_NO:
                                RecPack.CASE_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.DISCHARGE_TIME:
                                RecPack.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.HOSPITAL_DISTRICT:
                                RecPack.HOSPITAL_DISTRICT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER:
                                RecPack.PACKER = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_ID:
                                RecPack.PACK_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_NO:
                                RecPack.PACK_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PATIENT_ID:
                                RecPack.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_ID:
                                RecPack.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_NO:
                                RecPack.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER_ID:
                                RecPack.PACKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_TIME:
                                RecPack.PACK_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.PAPER_NUMBER:
                                RecPack.PAPER_NUMBER = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPackTable.PATIENT_NAME:
                                RecPack.PATIENT_NAME = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPacks.Add(RecPack);
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

        public short GetRecPacksByPackNo(string szPackNo, ref List<RecPack> lstRecPacks)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPackTable.CASE_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_NO);
            sbField.AppendFormat("{0}", SystemData.RecPackTable.PAPER_NUMBER);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPackNo))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecPackTable.PACK_NO
                    , szPackNo);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PACK, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPacks == null)
                    lstRecPacks = new List<RecPack>();
                do
                {
                    RecPack RecPack = new RecPack();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPackTable.CASE_NO:
                                RecPack.CASE_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.DISCHARGE_TIME:
                                RecPack.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.HOSPITAL_DISTRICT:
                                RecPack.HOSPITAL_DISTRICT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER:
                                RecPack.PACKER = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_ID:
                                RecPack.PACK_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_NO:
                                RecPack.PACK_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PATIENT_ID:
                                RecPack.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_ID:
                                RecPack.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_NO:
                                RecPack.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER_ID:
                                RecPack.PACKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_TIME:
                                RecPack.PACK_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.PAPER_NUMBER:
                                RecPack.PAPER_NUMBER = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPackTable.PATIENT_NAME:
                                RecPack.PATIENT_NAME = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPacks.Add(RecPack);
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

        public int GetNextCaseNo()
        {
            int caseNo = 1;
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szSql = "select max(case_no) as case_no from rec_pack t";
            try
            {
                DataSet ds = base.QCAccess.ExecuteDataSet(szSql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][SystemData.RecPackTable.CASE_NO] == null
                        || ds.Tables[0].Rows[0][SystemData.RecPackTable.CASE_NO].ToString() == string.Empty)
                        caseNo = 1;
                    else
                        caseNo = int.Parse(ds.Tables[0].Rows[0][SystemData.RecPackTable.CASE_NO].ToString())+1;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(szSql, ex);
                return caseNo;
            }
            finally
            {
                base.QCAccess.CloseConnnection(false);
            }
            return caseNo;
        }

        public short GetRecPacksByCaseNo(string szCaseNo, ref List<RecPack> lstRecPacks)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPackTable.CASE_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_NO);
            sbField.AppendFormat("{0}", SystemData.RecPackTable.PAPER_NUMBER);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}'"
                , szCondition
                , SystemData.RecPackTable.CASE_NO
                , szCaseNo);
            string szOrderBy = string.Format("{0}", SystemData.RecPackTable.PACK_NO);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable.REC_PACK, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPacks == null)
                    lstRecPacks = new List<RecPack>();
                do
                {
                    RecPack RecPack = new RecPack();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPackTable.CASE_NO:
                                RecPack.CASE_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.DISCHARGE_TIME:
                                RecPack.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.HOSPITAL_DISTRICT:
                                RecPack.HOSPITAL_DISTRICT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER:
                                RecPack.PACKER = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_ID:
                                RecPack.PACK_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_NO:
                                RecPack.PACK_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PATIENT_ID:
                                RecPack.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_ID:
                                RecPack.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_NO:
                                RecPack.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER_ID:
                                RecPack.PACKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_TIME:
                                RecPack.PACK_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.PAPER_NUMBER:
                                RecPack.PAPER_NUMBER = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPackTable.PATIENT_NAME:
                                RecPack.PATIENT_NAME = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPacks.Add(RecPack);
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

        public short GetRecPack(string szPatientID, string szVisitNo, ref RecPack RecPack)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szPatientID) || string.IsNullOrEmpty(szVisitNo))
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPackTable.CASE_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_NO);
            sbField.AppendFormat("{0}", SystemData.RecPackTable.PAPER_NUMBER);
            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.RecPackTable.PATIENT_ID, szPatientID
                , SystemData.RecPackTable.VISIT_NO, szVisitNo);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PACK, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (RecPack == null)
                    RecPack = new RecPack();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.RecPackTable.CASE_NO:
                            RecPack.CASE_NO = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.DISCHARGE_TIME:
                            RecPack.DISCHARGE_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.RecPackTable.HOSPITAL_DISTRICT:
                            RecPack.HOSPITAL_DISTRICT = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.PACKER:
                            RecPack.PACKER = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.PACK_ID:
                            RecPack.PACK_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.PATIENT_ID:
                            RecPack.PATIENT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.VISIT_ID:
                            RecPack.VISIT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.VISIT_NO:
                            RecPack.VISIT_NO = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.PACK_NO:
                            RecPack.PACK_NO = dataReader.GetString(i);
                            break;
                        case SystemData.RecPackTable.PACK_TIME:
                            RecPack.PACK_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.RecPackTable.PAPER_NUMBER:
                            RecPack.PAPER_NUMBER = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.RecPackTable.PATIENT_NAME:
                            RecPack.PATIENT_NAME = dataReader.GetString(i);
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
        public short GetRecPacks(string szPatientID, string szVisitNo, ref List<RecPack> lstRecPacks)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPackTable.CASE_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_TIME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_NO);
            sbField.AppendFormat("{0}", SystemData.RecPackTable.PAPER_NUMBER);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.RecPackTable.PATIENT_ID, szPatientID
                , SystemData.RecPackTable.VISIT_NO, szVisitNo);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PAPER, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPacks == null)
                    lstRecPacks = new List<RecPack>();
                do
                {
                    RecPack RecPack = new RecPack();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPackTable.CASE_NO:
                                RecPack.CASE_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.DISCHARGE_TIME:
                                RecPack.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.HOSPITAL_DISTRICT:
                                RecPack.HOSPITAL_DISTRICT = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER:
                                RecPack.PACKER = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACKER_ID:
                                RecPack.PACKER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_ID:
                                RecPack.PACK_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PATIENT_ID:
                                RecPack.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_ID:
                                RecPack.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.VISIT_NO:
                                RecPack.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_NO:
                                RecPack.PACK_NO = dataReader.GetString(i);
                                break;
                            case SystemData.RecPackTable.PACK_TIME:
                                RecPack.PACK_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.RecPackTable.PAPER_NUMBER:
                                RecPack.PAPER_NUMBER = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPackTable.PATIENT_NAME:
                                RecPack.PATIENT_NAME = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPacks.Add(RecPack);
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

        public short Insert(RecPack RecPack)
        {
            if (RecPack == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { RecPack }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (RecPack.PACK_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPackTable.CASE_NO);
            sbValue.AppendFormat("'{0}',", RecPack.CASE_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.DISCHARGE_TIME);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlTimeFormat(RecPack.DISCHARGE_TIME));
            sbField.AppendFormat("{0},", SystemData.RecPackTable.HOSPITAL_DISTRICT);
            sbValue.AppendFormat("'{0}',", RecPack.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER);
            sbValue.AppendFormat("'{0}',", RecPack.PACKER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACKER_ID);
            sbValue.AppendFormat("'{0}',", RecPack.PACKER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_ID);
            sbValue.AppendFormat("{0},", RecPack.PACK_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_NO);
            sbValue.AppendFormat("'{0}',", RecPack.PACK_NO);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PACK_TIME);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlTimeFormat(RecPack.PACK_TIME));
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PAPER_NUMBER);
            sbValue.AppendFormat("{0},", RecPack.PAPER_NUMBER);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", RecPack.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.PATIENT_NAME);
            sbValue.AppendFormat("'{0}',", RecPack.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.RecPackTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", RecPack.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPackTable.VISIT_NO);
            sbValue.AppendFormat("'{0}'", RecPack.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.REC_PACK, sbField.ToString(), sbValue.ToString());
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

        public short Update(RecPack recPack)
        {
            if (recPack == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recPack }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPackTable.CASE_NO, recPack.CASE_NO);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPackTable.DISCHARGE_TIME, base.QCAccess.GetSqlTimeFormat(recPack.DISCHARGE_TIME));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPackTable.HOSPITAL_DISTRICT, recPack.HOSPITAL_DISTRICT);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPackTable.PACKER, recPack.PACKER);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPackTable.PACKER_ID, recPack.PACKER_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPackTable.PACK_NO, recPack.PACK_NO);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPackTable.PACK_TIME, base.QCAccess.GetSqlTimeFormat(recPack.PACK_TIME));
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPackTable.PAPER_NUMBER, recPack.PAPER_NUMBER);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPackTable.PATIENT_ID, recPack.PATIENT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPackTable.VISIT_ID, recPack.VISIT_ID);
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.RecPackTable.VISIT_NO, recPack.VISIT_NO);
            string szCondition = string.Format("{0}='{1}'", SystemData.RecPackTable.PACK_ID, recPack.PACK_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REC_PACK, sbField.ToString(), szCondition);
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

        public short UpdateCaseNo(string szPackNo, string szCaseNo)
        {
            if (szPackNo == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szPackNo }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.RecPackTable.CASE_NO, szCaseNo);
            string szCondition = string.Format("{0}='{1}'", SystemData.RecPackTable.PACK_NO, szPackNo);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REC_PACK, sbField.ToString(), szCondition);
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

        public short Delete(string szPackID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szPackID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szPackID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.RecPackTable.PACK_ID, szPackID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.REC_PACK, szCondition);
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