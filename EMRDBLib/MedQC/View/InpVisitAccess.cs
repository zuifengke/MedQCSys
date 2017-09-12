using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class InpVisitAccess : DBAccessBase
    {

        private static InpVisitAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static InpVisitAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new InpVisitAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取在院患者列表
        /// </summary>
        /// <param name="lstPatVisitInfo"></param>
        /// <returns></returns>
        public short GetInpVisitInfos(ref List<PatVisitInfo> lstPatVisitInfo)
        {
            if (lstPatVisitInfo == null)
                lstPatVisitInfo = new List<PatVisitInfo>();
            if (base.MedQCAccess == null)
            {
                LogManager.Instance.WriteLog("质控数据库连接打开失败");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}"
                , SystemData.InpVisitView.VISIT_TIME
                , SystemData.InpVisitView.ADM_WARD_TIME
                , SystemData.InpVisitView.BED_CODE
                , SystemData.InpVisitView.DEPT_CODE
                , SystemData.InpVisitView.DIAGNOSIS
                , SystemData.InpVisitView.INCHARGE_DOCTOR
                , SystemData.InpVisitView.NURSING_CLASS
                , SystemData.InpVisitView.PATIENT_CONDITION
                , SystemData.InpVisitView.PATIENT_ID
                , SystemData.InpVisitView.VISIT_ID
                , SystemData.InpVisitView.VISIT_TIME
                , SystemData.InpVisitView.WARD_CODE
                , SystemData.InpVisitView.MR_STATUS
                , SystemData.InpVisitView.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM, szField, SystemData.DataView.INP_VISIT_V);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitInfo == null)
                    lstPatVisitInfo = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitInfo.VISIT_TIME = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) patVisitInfo.ADM_WARD_TIME = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) patVisitInfo.BED_CODE = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) patVisitInfo.DEPT_CODE = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitInfo.DIAGNOSIS = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) patVisitInfo.NURSING_CLASS = dataReader.GetString(6).ToString();
                    if (!dataReader.IsDBNull(7)) patVisitInfo.PATIENT_CONDITION = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitInfo.PATIENT_ID = dataReader.GetString(8).ToString();
                    if (!dataReader.IsDBNull(9)) patVisitInfo.VISIT_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) patVisitInfo.VISIT_TIME = dataReader.GetDateTime(10);
                    if (!dataReader.IsDBNull(11)) patVisitInfo.WARD_CODE = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) patVisitInfo.MR_STATUS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitInfo.VISIT_NO = dataReader.GetString(13);
                    lstPatVisitInfo.Add(patVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("InpVisitAccess.GetInpVisitList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 病历质控系统,获取在院病人
        /// </summary>
        /// <param name="dtBeginTime">起始时间</param>
        /// <param name="dtEndTime">截止时间</param>
        /// <param name="szDeptCode">当前用户所在科室编码</param>
        /// <param name="lstPatVisitLogs">该入院时间段内的危重患者列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetInpVisitInfos(string szDeptCode, DateTime dtBeginTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.ALLERGY_DRUGS, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.InpVisitView.VISIT_NO
                );

            string szCondition = string.Format("{0}>={1} AND {0}<={2}", SystemData.PatVisitView.VISIT_TIME
                , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A", SystemData.DataView.INP_VISIT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLogs == null)
                    lstPatVisitLogs = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) patVisitLog.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.INP_NO = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) patVisitLog.ALLERGY_DRUGS = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(16);
                    if (!dataReader.IsDBNull(17)) patVisitLog.VISIT_NO = dataReader.GetString(17);
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByInHosptial", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        public short GetInpVisitInfos(string szDeptCode,string szUserID,string szPatientID,string szPatientName,DateTime dtVisitTimeBegin,DateTime dtVisitTimeEnd, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.InpVisitView.ADM_WARD_TIME);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.ALLERGY_DRUGS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.BED_CODE);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.DIAGNOSIS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.INCHARGE_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.INCHARGE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.MR_STATUS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.NURSING_CLASS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PATIENT_CONDITION);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PREPAYMENTS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.TOTAL_CHARGES);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.TOTAL_COSTS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.VISIT_NO);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.VISIT_TIME);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.WARD_CODE);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PATIENT_SEX);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.BIRTH_TIME);
            sbField.AppendFormat("{0}", SystemData.InpVisitView.PATIENT_NAME);

            string szCondition = string.Format("1=1");
            
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.InpVisitView.DEPT_CODE
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szUserID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.InpVisitView.INCHARGE_DOCTOR_ID
                    , szUserID);
            }
            if (!string.IsNullOrEmpty(szPatientID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.InpVisitView.PATIENT_ID
                    , szPatientID);
            }
            if (!string.IsNullOrEmpty(szPatientName))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                    , szCondition
                    , SystemData.InpVisitView.PATIENT_NAME
                    , szPatientName);
            }
            if (dtVisitTimeBegin != SystemParam.Instance.DefaultTime
                && dtVisitTimeEnd != SystemParam.Instance.DefaultTime)
            {
                szCondition = string.Format("{0} AND {1} > {2} AND {1} < {3}"
                    , szCondition
                    , SystemData.InpVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            string szOrderBy = string.Format("{0},{1}",SystemData.InpVisitView.DEPT_NAME, SystemData.InpVisitView.BED_CODE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataView.INP_VISIT_V, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitInfo = new PatVisitInfo();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.InpVisitView.ADM_WARD_TIME:
                                patVisitInfo.ADM_WARD_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.InpVisitView.ALLERGY_DRUGS:
                                patVisitInfo.ALLERGY_DRUGS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.BED_CODE:
                                patVisitInfo.BED_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.BED_LABEL:
                                patVisitInfo.BED_LABEL = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.BIRTH_TIME:
                                patVisitInfo.BIRTH_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.InpVisitView.CHARGE_TYPE:
                                patVisitInfo.CHARGE_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.DEPT_CODE:
                                patVisitInfo.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.DEPT_NAME:
                                patVisitInfo.DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.DIAGNOSIS:
                                patVisitInfo.DIAGNOSIS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.IDENTITY:
                                patVisitInfo.IDENTITY = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.INCHARGE_DOCTOR:
                                patVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.INCHARGE_DOCTOR_ID:
                                patVisitInfo.INCHARGE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.INP_NO:
                                patVisitInfo.INP_NO = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.MR_STATUS:
                                patVisitInfo.MR_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.NURSING_CLASS:
                                patVisitInfo.NURSING_CLASS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_CONDITION:
                                patVisitInfo.PATIENT_CONDITION = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_ID:
                                patVisitInfo.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_NAME:
                                patVisitInfo.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_SEX:
                                patVisitInfo.PATIENT_SEX = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PREPAYMENTS:
                                patVisitInfo.PREPAYMENTS =double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.InpVisitView.TOTAL_CHARGES:
                                patVisitInfo.TOTAL_CHARGES = double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.InpVisitView.TOTAL_COSTS:
                                patVisitInfo.TOTAL_COSTS = double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.InpVisitView.VISIT_ID:
                                patVisitInfo.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.VISIT_NO:
                                patVisitInfo.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.VISIT_TIME:
                                patVisitInfo.VISIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.InpVisitView.VISIT_TYPE:
                                patVisitInfo.VISIT_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.WARD_CODE:
                                patVisitInfo.WARD_CODE = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstPatVisitInfos.Add(patVisitInfo);
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

        public short GetInpVisitInfos(string szDeptCode, string szPatientID, string szPatientName, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.InpVisitView.ADM_WARD_TIME);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.ALLERGY_DRUGS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.BED_CODE);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.DIAGNOSIS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.INCHARGE_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.INCHARGE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.MR_STATUS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.NURSING_CLASS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PATIENT_CONDITION);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PREPAYMENTS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.TOTAL_CHARGES);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.TOTAL_COSTS);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.VISIT_NO);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.VISIT_TIME);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.WARD_CODE);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.PATIENT_SEX);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.BIRTH_TIME);
            sbField.AppendFormat("{0},", SystemData.InpVisitView.CHARGE_TYPE);
            sbField.AppendFormat("{0}", SystemData.InpVisitView.PATIENT_NAME);

            string szCondition = string.Format("1=1");

            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.InpVisitView.DEPT_CODE
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szPatientID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.InpVisitView.PATIENT_ID
                    , szPatientID);
            }
            if (!string.IsNullOrEmpty(szPatientName))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                    , szCondition
                    , SystemData.InpVisitView.PATIENT_NAME
                    , szPatientName);
            }
            string szOrderBy = string.Format("{0},{1}", SystemData.InpVisitView.DEPT_NAME, SystemData.InpVisitView.BED_CODE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataView.INP_VISIT_V, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitInfo = new PatVisitInfo();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.InpVisitView.ADM_WARD_TIME:
                                patVisitInfo.ADM_WARD_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.InpVisitView.ALLERGY_DRUGS:
                                patVisitInfo.ALLERGY_DRUGS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.BED_CODE:
                                patVisitInfo.BED_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.BED_LABEL:
                                patVisitInfo.BED_LABEL = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.BIRTH_TIME:
                                patVisitInfo.BIRTH_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.InpVisitView.CHARGE_TYPE:
                                patVisitInfo.CHARGE_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.DEPT_CODE:
                                patVisitInfo.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.DEPT_NAME:
                                patVisitInfo.DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.DIAGNOSIS:
                                patVisitInfo.DIAGNOSIS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.IDENTITY:
                                patVisitInfo.IDENTITY = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.INCHARGE_DOCTOR:
                                patVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.INCHARGE_DOCTOR_ID:
                                patVisitInfo.INCHARGE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.INP_NO:
                                patVisitInfo.INP_NO = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.MR_STATUS:
                                patVisitInfo.MR_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.NURSING_CLASS:
                                patVisitInfo.NURSING_CLASS = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_CONDITION:
                                patVisitInfo.PATIENT_CONDITION = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_ID:
                                patVisitInfo.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_NAME:
                                patVisitInfo.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PATIENT_SEX:
                                patVisitInfo.PATIENT_SEX = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.PREPAYMENTS:
                                patVisitInfo.PREPAYMENTS = double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.InpVisitView.TOTAL_CHARGES:
                                patVisitInfo.TOTAL_CHARGES = double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.InpVisitView.TOTAL_COSTS:
                                patVisitInfo.TOTAL_COSTS = double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.InpVisitView.VISIT_ID:
                                patVisitInfo.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.VISIT_NO:
                                patVisitInfo.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.VISIT_TIME:
                                patVisitInfo.VISIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.InpVisitView.VISIT_TYPE:
                                patVisitInfo.VISIT_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.InpVisitView.WARD_CODE:
                                patVisitInfo.WARD_CODE = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstPatVisitInfos.Add(patVisitInfo);
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
        /// 获取病危病重病人的信息
        /// </summary>
        /// <param name="szDeptCode">科室编号</param>
        /// <param name="dtBeginTime">入院起始时间</param>
        /// <param name="dtEndTime">入院截止时间</param>
        /// <param name="lstPatVisitLog">病人就诊日志列表</param>
        /// <returns></returns>
        public short GetSeriousPatList(string szDeptCode, DateTime dtBeginTime, DateTime dtEndTime, ref List<EMRDBLib.PatVisitInfo> lstPatVisitLog)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("A.{0},B.{1},B.{2},B.{3},A.{4},C.{5},B.{6},B.{7},A.{8},B.{9},B.{10},A.{11},B.{12},B.{13},B.{14},B.{15}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX
                , SystemData.PatVisitView.INP_NO, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.DEPT_NAME
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.BIRTH_TIME, SystemData.AdtLogView.LOG_DATE_TIME
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.MR_STATUS
                , SystemData.InpVisitView.VISIT_NO);

            string szCondition = string.Format("A.{0}=B.{0} AND A.{1}=B.{1} AND A.{2}=C.{2}  and a.DEPT_CODE =b.DEPT_CODE", SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.DEPT_CODE);
            szCondition = string.Format("{0} AND  (B.{1}='危' OR B.{1}='急') AND {2}='IP'"
                , szCondition
                , SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.VISIT_TYPE);
            if (dtBeginTime != DateTime.Parse("1900-1-1") && dtEndTime != DateTime.Parse("1900-1-1"))
                szCondition = string.Format("{0} AND A.{1}>={2} AND A.{1}<={3} "
                    , szCondition
                    , SystemData.AdtLogView.LOG_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dtBeginTime)
                    , base.MedQCAccess.GetSqlTimeFormat(dtEndTime));

            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);

            string szTable = string.Format("{0} A,{1} B,{2} C", SystemData.DataView.ADT_LOG_V, SystemData.DataView.INP_VISIT_V
                , SystemData.DataView.DEPT_V);
            string szOrderBy = string.Format("A.dept_code,A.PATIENT_ID,A.VISIT_ID,log_date_time");

            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLog == null)
                    lstPatVisitLog = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.PATIENT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) patVisitLog.PATIENT_SEX = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.INP_NO = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.VISIT_ID = dataReader.GetValue(4).ToString();
                    if (!dataReader.IsDBNull(5)) patVisitLog.DEPT_NAME = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.DEPT_CODE = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) patVisitLog.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.LogDateTime = dataReader.GetDateTime(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.PATIENT_CONDITION = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.DIAGNOSIS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.MR_STATUS = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) patVisitLog.VISIT_NO = dataReader.GetString(15);
                    lstPatVisitLog.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetSeriousPatList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 根据住院天数获取在院患者列表
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="nInHospDays">住院天数</param>
        /// <param name="operatorType">操作符类型</param>
        /// <param name="lstPatVisitLogs">患者列表</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetPatListByInHospDays(string szDeptCode, int nInHospDays, OperatorType operatorType, ref List<EMRDBLib.PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14}"
             , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
             , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
             , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
             , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
             , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
             , SystemData.InpVisitView.VISIT_NO);
            string szCondition = "1=1";
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND A.{1}='{2}'AND A.{3}='IP'", szCondition, SystemData.PatVisitView.DEPT_CODE
                    , szDeptCode, SystemData.PatVisitView.VISIT_TYPE);
            }
            if (operatorType == OperatorType.Morethan)
                szCondition = string.Format("{0} AND {1}+{2}<SYSDATE", szCondition, SystemData.PatVisitView.VISIT_TIME, nInHospDays);
            else if (operatorType == OperatorType.Lessthan)
                szCondition = string.Format("{0} AND {1}+{2}>SYSDATE", szCondition, SystemData.PatVisitView.VISIT_TIME, nInHospDays);
            else if (operatorType == OperatorType.Equalthan)
                szCondition = string.Format("{0} AND {1}+{2}=SYSDATE", szCondition, SystemData.PatVisitView.VISIT_TIME, nInHospDays);
            else if (operatorType == OperatorType.MoreEqualthan)
                szCondition = string.Format("{0} AND {1}+{2}<=SYSDATE", szCondition, SystemData.PatVisitView.VISIT_TIME, nInHospDays);
            else if (operatorType == OperatorType.LessEqualthan)
                szCondition = string.Format("{0} AND {1}+{2}>=SYSDATE", szCondition, SystemData.PatVisitView.VISIT_TIME, nInHospDays);
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A", SystemData.DataView.INP_VISIT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLogs == null)
                    lstPatVisitLogs = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) patVisitLog.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.VISIT_NO = dataReader.GetString(14);
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByInHosptial", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 根据科室代码查询做过手术的在院患者列表
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="dtBeginTime">检索其实时间</param>
        /// <param name="dtEndTime">检索截止时间</param>
        /// <param name="szOperationCode">手术编码</param>
        /// <param name="lstPatVisitLogs">做过手术的在院患者列表</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetInpPatListByOperation(string szDeptCode, DateTime dtBeginTime, DateTime dtEndTime, string szOperationCode
            , ref List<EMRDBLib.PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.InpVisitView.VISIT_NO);

            string szCondition = string.Format("A.{0}=B.{1} AND A.{2}=B.{3}", SystemData.PatVisitView.PATIENT_ID, SystemData.OperationView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID, SystemData.OperationView.VISIT_ID);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            szCondition = string.Format("{0} AND A.{1}='IP'", szCondition, SystemData.PatVisitView.VISIT_TYPE);
            szCondition = string.Format("{0} AND A.{1}>={2} AND A.{1}<={3}", szCondition, SystemData.PatVisitView.VISIT_TIME
                , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            if (!string.IsNullOrEmpty(szOperationCode))
                szCondition = string.Format("{0} AND B.{1}='{2}'", szCondition, SystemData.OperationView.OPERATION_CODE, szOperationCode);

            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A,{1} B", SystemData.DataView.INP_VISIT_V, SystemData.DataView.OPERATION_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLogs == null)
                    lstPatVisitLogs = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) patVisitLog.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.VISIT_NO = dataReader.GetString(14);
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 根据adt_log中的病情状态获取危重患者列表
        /// </summary>
        /// <param name="dtBeginTime">起始时间</param>
        /// <param name="dtEndTime">截止时间</param>
        /// <param name="szDeptCode">当前用户所在科室代码</param>
        /// <param name="lstPatVisitLogs">该时间段内的危重患者列表</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetPatsListSeriousByAdtLog(DateTime dtBeginTime, DateTime dtEndTime, string szDeptCode, ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},B.{9},A.{10},A.{11},A.{12},A.{13},A.{14}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.AdtLogTable.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format(" A.{0}>={1} AND A.{0}<={2} AND (B.{3}='A' OR B.{3}='B')"
                , SystemData.PatVisitView.VISIT_TIME, base.MedQCAccess.GetSqlTimeFormat(dtBeginTime)
                , base.MedQCAccess.GetSqlTimeFormat(dtEndTime), SystemData.AdtLogTable.PATIENT_CONDITION);
            szCondition = string.Format("{0} AND A.{1}=B.{2} AND A.{3}=B.{4}", szCondition, SystemData.PatVisitView.PATIENT_ID
               , SystemData.AdtLogTable.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.AdtLogTable.VISIT_ID);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A,{1} B", SystemData.DataView.INP_VISIT_V, SystemData.DataView.ADT_LOG_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLogs == null)
                    lstPatVisitLogs = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9))
                    {
                        patVisitLog.PATIENT_CONDITION = dataReader.GetString(9);
                        if (patVisitLog.PATIENT_CONDITION == "A")
                            patVisitLog.PATIENT_CONDITION = "危";
                        else
                            patVisitLog.PATIENT_CONDITION = "急";
                    }
                    if (!dataReader.IsDBNull(10)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.VISIT_NO = dataReader.GetString(14);
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListSeriousByAdtLog", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }

        }

        /// <summary>
        /// 病历质控系统,根据入院时间获取危重患者列表
        /// </summary>
        /// <param name="dtBeginTime">起始时间</param>
        /// <param name="dtEndTime">截止时间</param>
        /// <param name="szDeptCode">当前用户所在科室编码</param>
        /// <param name="lstPatVisitLogs">该入院时间段内的危重患者列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatsListBySerious(DateTime dtBeginTime, DateTime dtEndTime, string szDeptCode, ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format(" A.{0}>={1} AND A.{0}<={2} AND (A.{3}='危' OR A.{3}='急')"
                , SystemData.PatVisitView.VISIT_TIME, base.MedQCAccess.GetSqlTimeFormat(dtBeginTime)
                , base.MedQCAccess.GetSqlTimeFormat(dtEndTime), SystemData.PatVisitView.PATIENT_CONDITION);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A", SystemData.DataView.INP_VISIT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLogs == null)
                    lstPatVisitLogs = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) patVisitLog.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.VISIT_NO = dataReader.GetString(14);
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListBySerious", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }

    }
}
