// ***********************************************************
// 数据库访问层与病人就诊有关的数据的访问类.
// Creator:YangMingkun  Date:2010-11-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using System.Data.OleDb;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class PatVisitAccess : DBAccessBase
    {
        private static PatVisitAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static PatVisitAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new PatVisitAccess();
                return m_Instance;
            }
        }


        /// <summary>
        /// 病历质控系统,获取指定科室的患者列表
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="patientType">病人类型(所有病人、出院病人或在院病人)</param>
        /// <param name="dtBeginTime">入院时间开始时间</param>
        /// <param name="dtEndTime">入院时间截止时间</param>
        /// <param name="lstPatVisitInfos">该科室在院患者列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatVisitList(string szDeptCode, PatientType patientType, DateTime dtBeginTime, DateTime dtEndTime
            , ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            if (patientType == PatientType.PatInHosptial)
                return InpVisitAccess.Instance.GetInpVisitInfos(szDeptCode, dtBeginTime, dtEndTime, ref lstPatVisitInfos);

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.ALLERGY_DRUGS
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format("{0}='IP'", SystemData.PatVisitView.VISIT_TYPE);
            if (patientType == PatientType.AllPatient)
            {
                szCondition = string.Format("{0} AND {1}>={2} AND {1}<={3}", szCondition, SystemData.PatVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            }
            else if (patientType == PatientType.PatOutHosptal)
            {
                szCondition = string.Format("{0} AND {1}>={2} AND {1}<={3}", szCondition, SystemData.PatVisitView.DISCHARGE_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
                szCondition = string.Format("{0} AND {1} IS NOT NULL", szCondition, SystemData.PatVisitView.DISCHARGE_TIME);
            }
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataView.PAT_VISIT_V
                , szCondition, SystemData.PatVisitView.BED_CODE);

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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10))
                        PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.ALLERGY_DRUGS = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.VISIT_NO = dataReader.GetString(18);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByDept", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 病历质控系统,根据死亡时间获取死亡患者列表
        /// </summary>
        /// <param name="dtBeginTime">起始时间</param>
        /// <param name="dtEndTime">截止时间</param>
        /// <param name="szDeptCode">当前用户所在科室代码</param>
        /// <param name="lstPatVisitInfos">该时间段内的死亡患者列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatsListByDeadTime(DateTime dtBeginTime, DateTime dtEndTime, string szDeptCode, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}"
                , SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME
                , SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX
                , SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME
                , SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR
                , SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME
                , SystemData.PatVisitView.DISCHARGE_MODE
                , SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format("{0}>={1} AND {0}<={2} AND {3}='死亡' AND {4}='IP'", SystemData.PatVisitView.DISCHARGE_TIME
                , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime)
                , SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.VISIT_TYPE);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataView.PAT_VISIT_V, szCondition
                , SystemData.PatVisitView.DEPT_CODE);
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10))
                        PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.VISIT_NO = dataReader.GetString(17);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByDeadTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 病历质控系统,根据入院时间获取患者列表
        /// </summary>
        /// <param name="dtBeginTime">起始时间</param>
        /// <param name="dtEndTime">截止时间</param>
        /// <param name="patientType">病人类型(所有病人、出院病人或在院病人)</param>
        /// <param name="szDeptCode">当前用户所在科室代码</param>
        /// <param name="lstPatVisitInfos">该入院时间段内的患者列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatsListByAdmTime(DateTime dtBeginTime, DateTime dtEndTime, PatientType patientType, string szDeptCode
            , ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            if (patientType == PatientType.PatInHosptial)
                return InpVisitAccess.Instance.GetInpVisitInfos(szDeptCode, dtBeginTime, dtEndTime, ref lstPatVisitInfos);

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format("{0}='IP'", SystemData.PatVisitView.VISIT_TYPE);
            if (patientType == PatientType.AllPatient)
            {
                szCondition = string.Format("{0} AND {1}>={2} AND {1}<={3}", szCondition, SystemData.PatVisitView.VISIT_TIME
                     , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            }

            //入院日期检索方式下检索已出院病人
            //加上入院日期起始时间
            if (patientType == PatientType.PatOutHosptal)
            {
                szCondition = string.Format("{0} AND {1}>={2} AND {1}<={3} AND {4} IS NOT NULL",
                    szCondition, SystemData.PatVisitView.VISIT_TIME,
                    base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime),
                    SystemData.PatVisitView.DISCHARGE_TIME);
            }

            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szOrderBy = string.Format("{0},{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataView.PAT_VISIT_V
                , szCondition, szOrderBy);
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10))
                        PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    lstPatVisitInfos.Add(PatVisitInfo);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.VISIT_NO = dataReader.GetString(17);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByAdmTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 病历质控系统,根据出院时间获取患者列表
        /// </summary>
        /// <param name="dtBeginTime">起始时间</param>
        /// <param name="dtEndTime">截止时间</param>
        /// <param name="szDeptCode">当前用户所在科室代码</param>
        /// <param name="lstPatVisitInfos">该入院时间段内的患者列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatientListByDisChargeTime(DateTime dtBeginTime, DateTime dtEndTime, string szDeptCode, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.VISIT_NO
                , SystemData.PatVisitView.TOTAL_COSTS);

            string szCondition = string.Format("{0}>={1} AND {0}<={2} AND {3}='IP'", SystemData.PatVisitView.DISCHARGE_TIME
                , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime), SystemData.PatVisitView.VISIT_TYPE);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szOrderBy = string.Format("{0},{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.PATIENT_NAME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataView.PAT_VISIT_V, szCondition, szOrderBy);

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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10))
                        PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.VISIT_NO = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.TOTAL_COSTS =double.Parse(dataReader.GetValue(18).ToString());
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByDisTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取死亡病人的信息
        /// </summary>
        /// <param name="szDeptCode">科室编号</param>
        /// <param name="dtBeginTime">入院起始时间</param>
        /// <param name="dtEndTime">入院截止时间</param>
        /// <param name="lstPatVisitInfo">病人就诊日志列表</param>
        /// <returns></returns>
        public short GetDeathPatList(string szDeptCode, DateTime dtBeginTime, DateTime dtEndTime, ref List<EMRDBLib.PatVisitInfo> lstPatVisitInfo)
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
                , SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.INCHARGE_DOCTOR
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format("A.{0}=B.{0} AND A.{1}=B.{1} AND A.{2}=C.{2}", SystemData.PatVisitView.PATIENT_ID
              , SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.DEPT_CODE);
            szCondition = string.Format("{0} AND A.{1}>={2} AND A.{1}<={3} AND (A.{4}='H') AND {5}='IP'", szCondition
                , SystemData.AdtLogView.LOG_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dtBeginTime)
                , base.MedQCAccess.GetSqlTimeFormat(dtEndTime), SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.VISIT_TYPE);

            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);

            string szTable = string.Format("{0} A,{1} B,{2} C", SystemData.DataView.ADT_LOG_V, SystemData.DataView.PAT_VISIT_V
                , SystemData.DataView.DEPT_V);
            string szOrderBy = string.Format("A.{0}", SystemData.PatVisitView.DEPT_CODE);

            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.INP_NO = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.VISIT_ID = dataReader.GetValue(4).ToString();
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.DEPT_NAME = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_CODE = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.LogDateTime = dataReader.GetDateTime(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.VISIT_NO = dataReader.GetString(15);
                    lstPatVisitInfo.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetDeathPatList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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

        /// 获取科室病历质量统计信息
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="szCheckerName">检查者姓名</param>
        /// <param name="dateBegin">出院起始日期</param>
        /// <param name="dataEnd">出院截止日期</param>
        /// <param name="bDischareTime">是否是出院日期</param>
        /// <param name="szScoreH">甲级标准分</param>
        /// <param name="szScoreL">乙级标准分</param>
        /// <param name="lstDeptDocScoreInfo">科室病历质量统计信息</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetDeptDocScoreInfo(string szDeptCode, string szCheckerName, DateTime dateBegin, DateTime dateEnd
            , bool bDischareTime, string szScoreH, string szScoreL, ref List<EMRDBLib.DeptDocScoreInfo> lstDeptDocScoreInfo)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("SELECT DEPT_NAME,DEPT_CODE,SUM(SCOREANUM),SUM(SCOREBNUM),SUM(SCORECNUM) FROM ( ");
            strBuilder.Append("SELECT A.DEPT_NAME,A.DEPT_CODE,COUNT(*) AS SCOREANUM,");
            strBuilder.Append("0 AS SCOREBNUM,0 AS SCORECNUM FROM DEPT_V A,PAT_VISIT_V B,QC_SCORE_V C");
            strBuilder.Append(" WHERE B.PATIENT_ID=C.PATIENT_ID AND B.VISIT_ID=C.VISIT_ID");
            if (bDischareTime)
                strBuilder.AppendFormat(" AND B.DISCHARGE_TIME >={0} AND B.DISCHARGE_TIME<{1} AND B.DEPT_DISCHARGE_FROM=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dateBegin), base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            else
                strBuilder.AppendFormat(" AND B.VISIT_TIME >={0} AND B.VISIT_TIME<{1} AND B.DEPT_CODE=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dateBegin), base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            strBuilder.AppendFormat(" AND C.HOS_ASSESS>={0}", szScoreH);
            if (!string.IsNullOrEmpty(szCheckerName))
                strBuilder.AppendFormat(" AND C.HOS_QCMAN='{0}'", szCheckerName);
            strBuilder.Append(" GROUP BY A.DEPT_CODE,A.DEPT_NAME");
            strBuilder.Append(" UNION ");
            strBuilder.Append("SELECT A.DEPT_NAME,A.DEPT_CODE,0 AS SCOREANUM,");
            strBuilder.Append("COUNT(*) AS SCOREBNUM,0 AS SCORECNUM FROM DEPT_V A,PAT_VISIT_V B,QC_SCORE_V C");
            strBuilder.Append(" WHERE B.PATIENT_ID=C.PATIENT_ID AND B.VISIT_ID=C.VISIT_ID");
            if (bDischareTime)
                strBuilder.AppendFormat(" AND B.DISCHARGE_TIME >={0} AND B.DISCHARGE_TIME<{1} AND B.DEPT_DISCHARGE_FROM=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dateBegin), base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            else
                strBuilder.AppendFormat(" AND B.VISIT_TIME >={0} AND B.VISIT_TIME<{1} AND B.DEPT_CODE=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dateBegin), base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            strBuilder.AppendFormat(" AND C.HOS_ASSESS>={0} AND C.HOS_ASSESS<{1}", szScoreL, szScoreH);
            if (!string.IsNullOrEmpty(szCheckerName))
                strBuilder.AppendFormat(" AND C.HOS_QCMAN='{0}'", szCheckerName);
            strBuilder.Append(" GROUP BY A.DEPT_CODE,A.DEPT_NAME");
            strBuilder.Append(" UNION ");
            strBuilder.Append("SELECT A.DEPT_NAME,A.DEPT_CODE,0 AS SCOREANUM,");
            strBuilder.Append("0 AS SCOREBNUM,COUNT(*) AS SCORECNUM FROM DEPT_V A,PAT_VISIT_V B,QC_SCORE_V C");
            strBuilder.Append(" WHERE B.PATIENT_ID=C.PATIENT_ID AND B.VISIT_ID=C.VISIT_ID");
            if (bDischareTime)
                strBuilder.AppendFormat(" AND B.DISCHARGE_TIME >={0} AND B.DISCHARGE_TIME<{1} AND B.DEPT_DISCHARGE_FROM=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dateBegin), base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            else
                strBuilder.AppendFormat(" AND B.VISIT_TIME >={0} AND B.VISIT_TIME<{1} AND B.DEPT_CODE=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dateBegin), base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            strBuilder.AppendFormat(" AND C.HOS_ASSESS<{0}", szScoreL);
            if (!string.IsNullOrEmpty(szCheckerName))
                strBuilder.AppendFormat(" AND C.HOS_QCMAN='{0}'", szCheckerName);
            strBuilder.Append(" GROUP BY A.DEPT_CODE,A.DEPT_NAME ) SCORETABLE");
            if (!string.IsNullOrEmpty(szDeptCode))
                strBuilder.AppendFormat(" WHERE DEPT_CODE='{0}'", szDeptCode);
            strBuilder.Append(" GROUP BY DEPT_CODE,DEPT_NAME");
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(strBuilder.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDeptDocScoreInfo == null)
                    lstDeptDocScoreInfo = new List<DeptDocScoreInfo>();
                do
                {
                    DeptDocScoreInfo deptDocScore = new DeptDocScoreInfo();
                    if (!dataReader.IsDBNull(0)) deptDocScore.DeptName = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) deptDocScore.DeptCode = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) deptDocScore.ScoreANum = GlobalMethods.Convert.StringToValue(dataReader.GetValue(2).ToString(), 0f);
                    if (!dataReader.IsDBNull(3)) deptDocScore.ScoreBNum = GlobalMethods.Convert.StringToValue(dataReader.GetValue(3).ToString(), 0f);
                    if (!dataReader.IsDBNull(4)) deptDocScore.ScoreCNum = GlobalMethods.Convert.StringToValue(dataReader.GetValue(4).ToString(), 0f); ;
                    lstDeptDocScoreInfo.Add(deptDocScore);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetDeptDocScoreInfo", new string[] { "szSQL" }, new object[] { strBuilder.ToString() }, ex);
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
        /// 病历质控系统,根据病人ID、病人住院号或病人姓名获取患者列表
        /// </summary>
        /// <param name="szPatientIDOrInpNo">病人ID或者住院号</param>
        /// <param name="bIsPatientID">指示第一个参数是否是病人ID</param>
        /// <param name="szPatientName">病人姓名</param>
        /// <param name="szDeptCode">当前用户所在科室代码</param>
        /// <param name="lstPatVisitInfos">病人ID或者姓名对应的患者列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatsListByPatient(string szPatientIDOrInpNo, bool bIsPatientID, string szPatientName, string szDeptCode
            , ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Empty;
            if (string.IsNullOrEmpty(szPatientName))
            {
                if (bIsPatientID)
                    szCondition = string.Format("{0}='{1}'", SystemData.PatVisitView.PATIENT_ID, szPatientIDOrInpNo);
                else
                    szCondition = string.Format("{0}='{1}'", SystemData.PatVisitView.INP_NO, szPatientIDOrInpNo);
            }
            else
                szCondition = string.Format("{0}='{1}'", SystemData.PatVisitView.PATIENT_NAME, szPatientName);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);

            szCondition = string.Format("{0} AND {1}='IP'", szCondition, SystemData.PatVisitView.VISIT_TYPE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.PAT_VISIT_V, szCondition);
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.VISIT_NO = dataReader.GetString(17);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByPatient", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 根据科室代码查询做过手术的患者列表
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="patientType">病人类型</param>
        /// <param name="dtBeginTime">检索其实时间</param>
        /// <param name="dtEndTime">检索截止时间</param>
        /// <param name="szOperationCode">手术编码</param>
        /// <param name="lstPatVisitInfos">做过手术的患者列表</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetPatListByOperation(string szDeptCode, PatientType patientType, DateTime dtBeginTime, DateTime dtEndTime
            , string szOperationCode, ref List<EMRDBLib.PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            if (patientType == PatientType.PatInHosptial)
                return InpVisitAccess.Instance.GetInpPatListByOperation(szDeptCode, dtBeginTime, dtEndTime, szOperationCode, ref lstPatVisitInfos);

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17}"
               , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
               , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
               , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
               , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
               , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
               , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS
               , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format("A.{0}=B.{1} AND A.{2}=B.{3}", SystemData.PatVisitView.PATIENT_ID, SystemData.OperationView.PATIENT_ID
               , SystemData.PatVisitView.VISIT_ID, SystemData.OperationView.VISIT_ID);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            szCondition = string.Format("{0} AND {1}='IP'", szCondition, SystemData.PatVisitView.VISIT_TYPE);
            if (patientType == PatientType.AllPatient)
            {
                szCondition = string.Format("{0} AND A.{1}>={2} AND A.{1}<={3}", szCondition, SystemData.PatVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            }
            else if (patientType == PatientType.PatOutHosptal)
            {
                szCondition = string.Format("{0} AND A.{1}>={2} AND A.{1}<={3}", szCondition, SystemData.PatVisitView.DISCHARGE_TIME
                   , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
                szCondition = string.Format("{0} AND A.{1} IS NOT NULL", szCondition, SystemData.PatVisitView.DISCHARGE_TIME);
            }
            if (!string.IsNullOrEmpty(szOperationCode))
                szCondition = string.Format("{0} AND B.{1}='{2}'", szCondition, SystemData.OperationView.OPERATION_CODE, szOperationCode);

            string szTable = string.Format("{0} A,{1} B", SystemData.DataView.PAT_VISIT_V, SystemData.DataView.OPERATION_V);
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.VISIT_NO = dataReader.GetString(17);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByOperation", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 根据住院天数获取患者列表
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="nInHospDays">住院天数</param>
        /// <param name="operatorType">操作符类型</param>
        /// <param name="patientType">病人类型</param>
        /// <param name="lstPatVisitInfos">患者列表</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetPatListByInHospDays(string szDeptCode, int nInHospDays, OperatorType operatorType, PatientType patientType
            , ref List<EMRDBLib.PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (patientType == PatientType.PatInHosptial)
                return InpVisitAccess.Instance.GetPatListByInHospDays(szDeptCode, nInHospDays, operatorType, ref lstPatVisitInfos);

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS);
            string szCondition = "1=1";
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1}='{2}' AND {3}='IP'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode
                    , SystemData.PatVisitView.VISIT_TYPE);
            }
            if (operatorType == OperatorType.Morethan)
            {
                szCondition = string.Format("{0} AND (({1}+{2}<{3} AND {3} IS NOT NULL) OR {1}+{2}<SYSDATE)", szCondition
                    , SystemData.PatVisitView.VISIT_TIME, nInHospDays, SystemData.PatVisitView.DISCHARGE_TIME);
            }
            else if (operatorType == OperatorType.Lessthan)
            {
                szCondition = string.Format("{0} AND (({1}+{2}>{3} AND {3} IS NOT NULL) OR {1}+{2}>SYSDATE)", szCondition
                    , SystemData.PatVisitView.VISIT_TIME, nInHospDays, SystemData.PatVisitView.DISCHARGE_TIME);
            }
            else if (operatorType == OperatorType.Equalthan)
            {
                szCondition = string.Format("{0} AND (({1}+{2}={3} AND {3} IS NOT NULL) OR {1}+{2}=SYSDATE)", szCondition
                    , SystemData.PatVisitView.VISIT_TIME, nInHospDays, SystemData.PatVisitView.DISCHARGE_TIME);
            }
            else if (operatorType == OperatorType.MoreEqualthan)
            {
                szCondition = string.Format("{0} AND (({1}+{2}<={3} AND {3} IS NOT NULL) OR {1}+{2}<=SYSDATE)", szCondition
                    , SystemData.PatVisitView.VISIT_TIME, nInHospDays, SystemData.PatVisitView.DISCHARGE_TIME);
            }
            else if (operatorType == OperatorType.LessEqualthan)
            {
                szCondition = string.Format("{0} AND (({1}+{2}>={3} AND {3} IS NOT NULL) OR {1}+{2}>=SYSDATE)", szCondition
                    , SystemData.PatVisitView.VISIT_TIME, nInHospDays, SystemData.PatVisitView.DISCHARGE_TIME);
            }
            string szOrderBy = string.Format("{0},{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField, SystemData.DataView.PAT_VISIT_V
                , szCondition, szOrderBy);
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByInHospDays", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取病人的诊断信息
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">住院标识</param>
        /// <param name="lstDiagnosisInfo">诊断信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDiagnosisInfo(string szPatientID, string szVisitID, ref List<Diagnosis> lstDiagnosisInfo)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5}", SystemData.DiagnosisView.DIAGNOSIS_TYPE, SystemData.DiagnosisView.DIAGNOSIS_TYPE_NAME
                , SystemData.DiagnosisView.DIAGNOSIS_NO, SystemData.DiagnosisView.DIAGNOSIS_DESC, SystemData.DiagnosisView.DIAGNOSIS_DATE
                , SystemData.DiagnosisView.TREAT_RESULT);

            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'", SystemData.DiagnosisView.PATIENT_ID, szPatientID
              , SystemData.DiagnosisView.VISIT_ID, szVisitID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataView.DIAGNOSIS_V, szCondition
                , SystemData.DiagnosisView.DIAGNOSIS_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDiagnosisInfo == null)
                    lstDiagnosisInfo = new List<Diagnosis>();
                do
                {
                    Diagnosis diagnosisInfo = new Diagnosis();
                    if (!dataReader.IsDBNull(0)) diagnosisInfo.DIAGNOSIS_TYPE = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) diagnosisInfo.DIAGNOSIS_TYPE_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) diagnosisInfo.DIAGNOSIS_NO = int.Parse(dataReader.GetValue(2).ToString());
                    if (!dataReader.IsDBNull(3)) diagnosisInfo.DIAGNOSIS_DESC = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) diagnosisInfo.DIAGNOSIS_DATE = dataReader.GetDateTime(4);
                    if (!dataReader.IsDBNull(5)) diagnosisInfo.TREAT_RESULT = dataReader.GetString(5);
                    lstDiagnosisInfo.Add(diagnosisInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetDiagnosisInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取病人的基本信息
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <param name="patBasicInfo">病人基本信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatVisitInfo(string szPatientID, string szVisitID, ref PatVisitInfo PatVisitInfo)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}", SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.SERVICE_AGENCY
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.DISCHARGE_TIME
                , SystemData.PatVisitView.ADDRESS, SystemData.PatVisitView.MR_STATUS, SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.INCHARGE_DOCTOR
                , SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.VISIT_NO
                , SystemData.PatVisitView.INCHARGE_DOCTOR_ID
                , SystemData.PatVisitView.ID_NO);
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='IP'", SystemData.PatVisitView.PATIENT_ID, szPatientID
                , SystemData.PatVisitView.VISIT_ID, szVisitID, SystemData.PatVisitView.VISIT_TYPE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.PAT_VISIT_V, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (PatVisitInfo == null)
                    PatVisitInfo = new PatVisitInfo();
                do
                {
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.INP_NO = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.DEPT_NAME = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.BED_CODE = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.SERVICE_AGENCY = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.ADDRESS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.PATIENT_ID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.VISIT_ID = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.DEPT_CODE = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.VISIT_NO = dataReader.GetString(18);
                    if (!dataReader.IsDBNull(19)) PatVisitInfo.INCHARGE_DOCTOR_ID = dataReader.GetString(19);
                    if (!dataReader.IsDBNull(20)) PatVisitInfo.ID_NO = dataReader.GetString(20);
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
        /// 获取病人的基本信息
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitNo">就诊流水号</param>
        /// <param name="patBasicInfo">病人基本信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatVisit(string szPatientID, string szVisitNo, ref PatVisitInfo PatVisitInfo)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}", SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.SERVICE_AGENCY
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.DISCHARGE_TIME
                , SystemData.PatVisitView.ADDRESS, SystemData.PatVisitView.MR_STATUS, SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.INCHARGE_DOCTOR
                , SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.VISIT_NO
                , SystemData.PatVisitView.INCHARGE_DOCTOR_ID
                , SystemData.PatVisitView.ID_NO
                , SystemData.PatVisitView.ALLERGY_DRUGS);
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='IP'", SystemData.PatVisitView.PATIENT_ID, szPatientID
                , SystemData.PatVisitView.VISIT_NO, szVisitNo, SystemData.PatVisitView.VISIT_TYPE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.PAT_VISIT_V, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (PatVisitInfo == null)
                    PatVisitInfo = new PatVisitInfo();
                do
                {
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.INP_NO = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.DEPT_NAME = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.BED_CODE = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.SERVICE_AGENCY = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.ADDRESS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.PATIENT_ID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.VISIT_ID = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.DEPT_CODE = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.VISIT_NO = dataReader.GetString(18);
                    if (!dataReader.IsDBNull(19)) PatVisitInfo.INCHARGE_DOCTOR_ID = dataReader.GetString(19);
                    if (!dataReader.IsDBNull(20)) PatVisitInfo.ID_NO = dataReader.GetString(20);
                    if (!dataReader.IsDBNull(21)) PatVisitInfo.ALLERGY_DRUGS = dataReader.GetString(21);
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

        public short GetPatVisitInfos(string szPatientID, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.DEPT_DISCHARGE_FROM
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Empty;
            szCondition = string.Format("{0}='{1}' and {2}='IP'"
                , SystemData.PatVisitView.PATIENT_ID, szPatientID, SystemData.PatVisitView.VISIT_TYPE);

            //, SystemData.PatVisitView.DEPT_DISCHARGE_FROM, szDeptCode);
            //szCondition = string.Format("{0} AND {1}='IP'", szCondition, SystemData.PatVisitView.VISIT_TYPE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataView.PAT_VISIT_V, szCondition, SystemData.PatVisitView.VISIT_TIME);
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.MR_STATUS = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.DischargeDeptCode = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.VISIT_NO = dataReader.GetString(18);

                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByPatient", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 更新联机病历描述MR_ON_LINE信息表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <param name="szStatus">病历状态</param>
        /// <param name="szRequestDoctorID">请求医生</param>
        /// <param name="dtRequestTime">请求时间</param>
        /// <param name="nOperFlag">操作标识 1-插入 2-更新 3-删除</param>
        public short UpdateMrOnLineInfo(string szPatientID, string szVisitID, string szStatus, string szRequestDoctorID
            , DateTime dtRequestTime, int nOperFlag)
        {
            string szDoctorID = string.Empty;
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            DbParameter[] pmi = new DbParameter[6];
            pmi[0] = new DbParameter("patientID", szPatientID);
            pmi[1] = new DbParameter("visitID", szVisitID);
            pmi[2] = new DbParameter("mrStatus", szStatus);
            pmi[3] = new DbParameter("requestDoctorID", szRequestDoctorID);
            pmi[4] = new DbParameter("requestDateTime", dtRequestTime);
            pmi[5] = new DbParameter("operFlag", nOperFlag.ToString());
            int nInsertResult = 0;
            try
            {
                nInsertResult = base.MedQCAccess.ExecuteNonQuery("UPDATE_MR_ON_LINE", CommandType.StoredProcedure, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.UpdateMrOnLineInfo执行失败,存储过程UPDATE_MR_ON_LINE执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nInsertResult <= 0 ? SystemData.ReturnValue.OTHER_ERROR : SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 获取指定病人的三级医生
        /// </summary>
        /// <param name="lstPatDoctorInfos"></param>
        /// <returns></returns>
        public short GetPatDoctors(ref List<PatDoctorInfo> lstPatDoctorInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstPatDoctorInfos == null | lstPatDoctorInfos.Count <= 0)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatDoctorInfos.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') ", lstPatDoctorInfos[index].PatientID, lstPatDoctorInfos[index].VisitID);
                if (index != lstPatDoctorInfos.Count - 1)
                    sb.Append(" or ");
            }

            string szField = string.Format("{0},{1},{2},{3},{4}",
                SystemData.PatDoctorView.PATIENT_ID, SystemData.PatDoctorView.VISIT_ID
                , SystemData.PatDoctorView.REQUEST_DOCTOR_ID, SystemData.PatDoctorView.PARENT_DOCTOR_ID
                , SystemData.PatDoctorView.SUPER_DOCTOR_ID);

            string szCondition = sb.ToString();
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.PAT_DOCTOR_V, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                //初始化传入变量
                lstPatDoctorInfos = null;
                lstPatDoctorInfos = new List<PatDoctorInfo>();
                do
                {
                    PatDoctorInfo patDoctorInfo = new PatDoctorInfo();
                    if (!dataReader.IsDBNull(0)) patDoctorInfo.PatientID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patDoctorInfo.VisitID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) patDoctorInfo.RequestDoctorID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) patDoctorInfo.ParentDoctorID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patDoctorInfo.SuperDoctorID = dataReader.GetString(4);
                    lstPatDoctorInfos.Add(patDoctorInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatDoctors", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 根据质检病历信息获取患者列表 
        /// </summary>
        public short GetPatListByCheckedDoc(string szCheckerName, DateTime dtBeginTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.INP_NO, SystemData.PatVisitView.DISCHARGE_TIME);
            string szTableB = string.Format("SELECT DISTINCT PATIENT_ID, VISIT_ID  FROM MEDICAL_QC_MSG" +
                                         " WHERE ISSUED_DATE_TIME >= {0}  AND ISSUED_DATE_TIME < {1} ",
                                         base.MedQCAccess.GetSqlTimeFormat(dtBeginTime),
                                         base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            if (!string.IsNullOrEmpty(szCheckerName))
            {
                szTableB += string.Format(" AND ISSUED_BY = '{0}'", szCheckerName);
            }
            string szCondition = " A.PATIENT_ID=B.PATIENT_ID AND A.VISIT_ID=B.VISIT_ID";
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A,({1}) B ", SystemData.DataView.PAT_VISIT_V, szTableB);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);
            IDataReader dataReader = null;
            try
            {
                LogManager.Instance.WriteLog("szSQL:" + szSQL);
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.INP_NO = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByCheckedDoc", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取出院病人病情
        /// </summary>
        /// <param name="lstPatVistLogs"></param>
        /// <returns></returns>
        public short GetOutPatientCondition(List<PatVisitInfo> lstPatVistLogs, ref List<PatVisitInfo> newlstPatVistLogs)
        {
            if (lstPatVistLogs == null || lstPatVistLogs.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            foreach (PatVisitInfo item in lstPatVistLogs)
            {
                sb.AppendFormat(" (PATIENT_ID='{0}' AND VISIT_ID='{1}') OR ", item.PATIENT_ID, item.VISIT_ID);
            }
            int index = sb.ToString().LastIndexOf("OR");
            string szConditon = sb.ToString().Remove(index, 2);
            string szSQL = "SELECT PATIENT_ID,VISIT_ID,PATIENT_CONDITION FROM Adt_Log_v WHERE ";
            szSQL += szConditon;
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (newlstPatVistLogs == null)
                    newlstPatVistLogs = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(2);
                    newlstPatVistLogs.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetOutPatientCondition", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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

        public short GetPatListByMutiVisit(DateTime dtStartTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            short shRet = GetPidByMutiVisit(dtStartTime, dtEndTime, ref lstPatVisitInfos);
            if (lstPatVisitInfos == null || lstPatVisitInfos.Count <= 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szPids = GetPidList(lstPatVisitInfos);
            if (string.IsNullOrEmpty(szPids))
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.INP_NO, SystemData.PatVisitView.DISCHARGE_TIME
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format(" ({0}) AND A.Discharge_time > {1} AND A.VISIT_TIME <={2}",
                                                 szPids, base.MedQCAccess.GetSqlTimeFormat(dtStartTime), base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A ", SystemData.DataView.PAT_VISIT_V);
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
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                lstPatVisitInfos.Clear();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.INP_NO = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.VISIT_NO = dataReader.GetValue(16).ToString();
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByMutiVisit", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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



        private short GetPidByMutiVisit(DateTime dtStartTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = string.Format("SELECT PATIENT_ID  FROM PAT_VISIT_V" +
                                            " WHERE discharge_time > {0}" +
                                            " AND VISIT_TIME <={1}" +
                                            " AND VISIT_TYPE = 'IP'" +
                                            " GROUP BY PATIENT_ID HAVING COUNT(PATIENT_ID) >= 2",
                                         base.MedQCAccess.GetSqlTimeFormat(dtStartTime),
                                         base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
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
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    //if (!dataReader.IsDBNull(1)) PatVisitInfo.VisitID = dataReader.GetValue(1).ToString();
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPidByMutiVisit", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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

        public short GetPatListByTransferTime(DateTime dtStartTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            short shRet = GetPidVidByTransferTime(dtStartTime, dtEndTime, ref lstPatVisitInfos);
            if (lstPatVisitInfos == null || lstPatVisitInfos.Count <= 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szPidVids = GetPidVidList(lstPatVisitInfos);
            if (string.IsNullOrEmpty(szPidVids))
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.INP_NO, SystemData.PatVisitView.DISCHARGE_TIME);

            string szCondition = szPidVids;
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A ", SystemData.DataView.PAT_VISIT_V);
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
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                lstPatVisitInfos.Clear();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.INP_NO = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByTransferTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 待复审病历浏览
        /// </summary>
        /// <param name="dtStartTime">问题提交开始时间</param>
        /// <param name="dtEndTime">问题提交结束时间</param>
        /// <param name="lstPatVisitInfos"></param>
        /// <returns></returns>
        public short GetPatListByDocReview(DateTime dtStartTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.MR_STATUS
                , SystemData.PatVisitView.INP_NO, SystemData.PatVisitView.DISCHARGE_TIME
                , SystemData.PatVisitView.VISIT_NO);

            string szCondition = string.Format("1=1 AND A.{0}=B.{1} AND A.{2} = B.{3}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.MedicalQcMsgTable.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID, SystemData.MedicalQcMsgTable.VISIT_ID);
            szCondition = string.Format("{0} AND {1}>={2} AND {1}<={3} "
                , szCondition
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dtStartTime)
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
            szCondition = string.Format("{0} AND {1} = 2"
                , szCondition, SystemData.MedicalQcMsgTable.MSG_STATUS);
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A,{1} B ", SystemData.DataView.PAT_VISIT_V, SystemData.DataView.QC_MSG_V);
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
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                lstPatVisitInfos.Clear();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.MR_STATUS = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.INP_NO = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.VISIT_NO = dataReader.GetString(16);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByDocReview", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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

        private string GetPidList(List<PatVisitInfo> lstPatVisitInfos)
        {
            if (lstPatVisitInfos == null || lstPatVisitInfos.Count == 0)
                return string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (PatVisitInfo item in lstPatVisitInfos)
                {
                    sb.AppendFormat("(PATIENT_ID='{0}') OR ", item.PATIENT_ID);
                }
                int index = sb.ToString().LastIndexOf("OR");
                return sb.ToString().Remove(index, 2);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPidVidList", ex);
            }
            return string.Empty;
        }

        private string GetPidVidList(List<PatVisitInfo> lstPatVisitInfos)
        {
            if (lstPatVisitInfos == null || lstPatVisitInfos.Count == 0)
                return string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (PatVisitInfo item in lstPatVisitInfos)
                {
                    sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') OR ", item.PATIENT_ID, item.VISIT_ID);
                }
                int index = sb.ToString().LastIndexOf("OR");
                return sb.ToString().Remove(index, 2);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPidVidList", ex);
            }
            return string.Empty;
        }

        private short GetPidVidByTransferTime(DateTime dtStartTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = string.Format("SELECT DISTINCT PATIENT_ID,VISIT_ID FROM TRANSFER_V" +
                                            " WHERE DISCHARGE_DATE_TIME > {0}" +
                                            " AND DISCHARGE_DATE_TIME <={1}" +
                                            " AND dept_transfer_to IS NOT NULL",
                                         base.MedQCAccess.GetSqlTimeFormat(dtStartTime),
                                         base.MedQCAccess.GetSqlTimeFormat(dtEndTime));
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
                lstPatVisitInfos.Clear();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPidVidByTransferTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取病人第一个出院诊断
        /// </summary>
        /// <param name="lstPatVisitInfo"></param>
        /// <returns></returns>
        public short GetOutPatientFirstDiagnosis(List<PatVisitInfo> lstPatVisitInfos, List<EMRDBLib.Diagnosis> lstDiagnosInfo)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstPatVisitInfos == null || lstPatVisitInfos.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitInfos.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID = '{0}' AND VISIT_ID = {1})",
                    lstPatVisitInfos[index].PATIENT_ID,
                    lstPatVisitInfos[index].VISIT_ID);
                if (index + 1 != lstPatVisitInfos.Count)
                    sb.Append(" OR ");
            }
            string szSQL = string.Format("SELECT PATIENT_ID,VISIT_ID,DIAGNOSIS_DESC,TREAT_RESULT" +
                                          " FROM (SELECT * FROM DIAGNOSIS_V WHERE {0} ) WHERE  DIAGNOSIS_TYPE_NAME = '主要诊断' AND DIAGNOSIS_NO = 1",
                                         sb.ToString());
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDiagnosInfo == null)
                    lstDiagnosInfo = new List<Diagnosis>();
                lstDiagnosInfo.Clear();
                do
                {
                    Diagnosis diag = new Diagnosis();
                    if (!dataReader.IsDBNull(0)) diag.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) diag.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) diag.DIAGNOSIS_DESC = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) diag.TREAT_RESULT = dataReader.GetString(3);
                    lstDiagnosInfo.Add(diag);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetOutPatientFirstDiagnosis", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取病人主诊断
        /// </summary>
        /// <param name="lstPatVisitInfo"></param>
        /// <returns></returns>
        public short GetPatientMainDiagnosis(List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstPatVisitInfos == null || lstPatVisitInfos.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitInfos.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID = '{0}' AND VISIT_ID = {1})",
                    lstPatVisitInfos[index].PATIENT_ID,
                    lstPatVisitInfos[index].VISIT_ID);
                if (index + 1 != lstPatVisitInfos.Count)
                    sb.Append(" OR ");
            }
            string szSQL = string.Format("SELECT PATIENT_ID,VISIT_ID,DIAGNOSIS_DESC" +
                                          " FROM (SELECT * FROM DIAGNOSIS_V WHERE {0} ) WHERE  DIAGNOSIS_TYPE_NAME = '主要诊断' AND DIAGNOSIS_NO = 1",
                                         sb.ToString());
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
                lstPatVisitInfos.Clear();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(2);
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetOutPatientFirstDiagnosis", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取出院病人的费用信息
        /// </summary>
        /// <param name="lstPatConstInfo"></param>
        public short GetPatConstInfo(ref List<EMRDBLib.PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstPatVisitInfos == null || lstPatVisitInfos.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitInfos.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID = '{0}' AND VISIT_ID = {1})",
                    lstPatVisitInfos[index].PATIENT_ID,
                    lstPatVisitInfos[index].VISIT_ID);
                if (index + 1 != lstPatVisitInfos.Count)
                    sb.Append(" OR ");
            }
            string szSQL = string.Format("SELECT PATIENT_ID,VISIT_ID,TOTAL_COSTS,TOTAL_PAYMENTS FROM PAT_COST_V WHERE {0}",
                                         sb.ToString());
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
                lstPatVisitInfos.Clear();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.TOTAL_COSTS = float.Parse(dataReader.GetValue(2).ToString()); ;
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PREPAYMENTS = float.Parse(dataReader.GetValue(3).ToString()); ;
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatConstInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        public short GetOutPatientCondition(List<PatVisitInfo> lstPatVistLogs)
        {
            List<PatVisitInfo> newlstPatVistLogs = null;
            short shRet = this.GetOutPatientCondition(lstPatVistLogs, ref newlstPatVistLogs);
            if (shRet == EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;

            if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
            {
                return SystemData.ReturnValue.FAILED;
            }
            //A为病危，B为病重
            foreach (PatVisitInfo item in lstPatVistLogs)
            {
                EMRDBLib.PatVisitInfo patConditionA = newlstPatVistLogs.Find(delegate (EMRDBLib.PatVisitInfo p)
                {
                    if (p.PATIENT_ID == item.PATIENT_ID && p.VISIT_ID == item.VISIT_ID && p.PATIENT_CONDITION == "A")
                        return true;
                    else
                        return false;
                });
                EMRDBLib.PatVisitInfo patConditionB = newlstPatVistLogs.Find(delegate (EMRDBLib.PatVisitInfo p)
                {
                    if (p.PATIENT_ID == item.PATIENT_ID && p.VISIT_ID == item.VISIT_ID && p.PATIENT_CONDITION == "B")
                        return true;
                    else
                        return false;
                });
                item.PATIENT_CONDITION = "一般";
                if (patConditionB != null)
                    item.PATIENT_CONDITION = "急";
                if (patConditionA != null)
                    item.PATIENT_CONDITION = "危";
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定病人的三级医生信息
        /// </summary>
        /// <param name="lstPatDoctorInfos"></param>
        /// <returns></returns>
        public short GetPatSanjiDoctors(ref List<PatDoctorInfo> lstPatDoctorInfos)
        {
            List<UserInfo> lstUserInfo = null;
            short shRet = UserAccess.Instance.GetAllUserInfos(ref lstUserInfo);
            if (shRet != SystemData.ReturnValue.OK)
                return SystemData.ReturnValue.FAILED;
            shRet = this.GetPatDoctors(ref lstPatDoctorInfos);
            foreach (PatDoctorInfo patDoctorInfo in lstPatDoctorInfos)
            {
                UserInfo requestUser = lstUserInfo.Find(delegate (UserInfo p) { return p.USER_ID == patDoctorInfo.RequestDoctorID; });
                UserInfo parentUser = lstUserInfo.Find(delegate (UserInfo p) { return p.USER_ID == patDoctorInfo.ParentDoctorID; });
                UserInfo superUser = lstUserInfo.Find(delegate (UserInfo p) { return p.USER_ID == patDoctorInfo.SuperDoctorID; });

                if (requestUser != null)
                    patDoctorInfo.RequestDoctorName = requestUser.USER_NAME;
                else
                    patDoctorInfo.RequestDoctorName = patDoctorInfo.RequestDoctorID;

                if (parentUser != null)
                    patDoctorInfo.ParentDoctorName = parentUser.USER_NAME;
                else
                    patDoctorInfo.ParentDoctorName = patDoctorInfo.ParentDoctorID;

                if (superUser != null)
                    patDoctorInfo.SuperDoctorName = superUser.USER_NAME;
                else
                    patDoctorInfo.SuperDoctorName = patDoctorInfo.SuperDoctorID;
            }
            return SystemData.ReturnValue.OK;
        }
        public short GetPatVisits(string szDeptCode, string szUserID, string szPatientID, string szPatientName, DateTime dtVisitTimeBegin, DateTime dtVisitTimeEnd, DateTime dtDischargeTimeBegin, DateTime dtDischargeTimeEnd, string szDischargeMode, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.PatVisitView.ADDRESS);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.ALLERGY_DRUGS);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.PARENT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.SUPER_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.BED_CODE);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.CHARGE_TYPE);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.DEPT_CODE);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.DEPT_DISCHARGE_FROM);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.DIAGNOSIS);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.DISCHARGE_MODE);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.DISCHARGE_TIME);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.IDENTITY);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.INCHARGE_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.INCHARGE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.INP_NO);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.MR_STATUS);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.NURSING_CLASS);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.PATIENT_CONDITION);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.PATIENT_SEX);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.SERVICE_AGENCY);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.VISIT_NO);
            sbField.AppendFormat("{0},", SystemData.PatVisitView.VISIT_TIME);
            sbField.AppendFormat("{0}", SystemData.PatVisitView.VISIT_TYPE);

            string szCondition = string.Format("1=1 AND {0} is not NULL"
                , SystemData.PatVisitView.DISCHARGE_TIME);

            if (!string.IsNullOrEmpty(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.PatVisitView.DEPT_CODE
                    , szDeptCode);
            }
            if (!string.IsNullOrEmpty(szUserID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.PatVisitView.INCHARGE_DOCTOR_ID
                    , szUserID);
            }
            if (!string.IsNullOrEmpty(szPatientID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.PatVisitView.PATIENT_ID
                    , szPatientID);
            }
            if (!string.IsNullOrEmpty(szDischargeMode))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.PatVisitView.DISCHARGE_MODE
                    , szDischargeMode);
            }
            if (!string.IsNullOrEmpty(szPatientName))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                    , szCondition
                    , SystemData.PatVisitView.PATIENT_NAME
                    , szPatientName);
            }
            if (dtVisitTimeBegin != SystemParam.Instance.DefaultTime
                && dtVisitTimeEnd != SystemParam.Instance.DefaultTime)
            {
                szCondition = string.Format("{0} AND {1} > {2} AND {1} < {3} "
                    , szCondition
                    , SystemData.PatVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            if (dtDischargeTimeBegin != SystemParam.Instance.DefaultTime
                && dtDischargeTimeEnd != SystemParam.Instance.DefaultTime)
            {
                szCondition = string.Format("{0} AND {1} > {2} AND {1} < {3}"
                      , szCondition
                      , SystemData.PatVisitView.DISCHARGE_TIME
                      , base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeBegin)
                      , base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeEnd));
            }
            string szOrderBy = string.Format("{0},{1}", SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.DISCHARGE_TIME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataView.PAT_VISIT_V, szCondition, szOrderBy);

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
                            case SystemData.PatVisitView.ADDRESS:
                                patVisitInfo.ADDRESS = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.DISCHARGE_MODE:
                                patVisitInfo.DISCHARGE_MODE = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.ALLERGY_DRUGS:
                                patVisitInfo.ALLERGY_DRUGS = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.BED_CODE:
                                patVisitInfo.BED_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.BED_LABEL:
                                patVisitInfo.BED_LABEL = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.BIRTH_TIME:
                                patVisitInfo.BIRTH_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.PatVisitView.CHARGE_TYPE:
                                patVisitInfo.CHARGE_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.DISCHARGE_TIME:
                                patVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.PatVisitView.DEPT_CODE:
                                patVisitInfo.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.DEPT_NAME:
                                patVisitInfo.DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.DIAGNOSIS:
                                patVisitInfo.DIAGNOSIS = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.IDENTITY:
                                patVisitInfo.IDENTITY = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.INCHARGE_DOCTOR:
                                patVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.INCHARGE_DOCTOR_ID:
                                patVisitInfo.INCHARGE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.INP_NO:
                                patVisitInfo.INP_NO = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.MR_STATUS:
                                patVisitInfo.MR_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.NURSING_CLASS:
                                patVisitInfo.NURSING_CLASS = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.PATIENT_CONDITION:
                                patVisitInfo.PATIENT_CONDITION = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.PATIENT_ID:
                                patVisitInfo.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.PATIENT_NAME:
                                patVisitInfo.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.PATIENT_SEX:
                                patVisitInfo.PATIENT_SEX = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.SERVICE_AGENCY:
                                patVisitInfo.SERVICE_AGENCY = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.TOTAL_CHARGES:
                                patVisitInfo.TOTAL_CHARGES = double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.PatVisitView.TOTAL_COSTS:
                                patVisitInfo.TOTAL_COSTS = double.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.PatVisitView.VISIT_ID:
                                patVisitInfo.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.VISIT_NO:
                                patVisitInfo.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.VISIT_TIME:
                                patVisitInfo.VISIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.PatVisitView.VISIT_TYPE:
                                patVisitInfo.VISIT_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.PARENT_DOCTOR:
                                patVisitInfo.PARENT_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.SUPER_DOCTOR:
                                patVisitInfo.SUPER_DOCTOR = dataReader.GetString(i);
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
        public short GetPatsListByComplexSearch(string szPatientStatus, string szDeptCode, string szPatientID, string szPatientName
           , string szDoctor, string szDiagnosis, string szNursingClass, string szPatientCondition
           , string szIdentity, string szChargeType, int nBeginAge, int nEndAge
           , DateTime dtVisitTimeBegin, DateTime dtVisitTimeEnd
           , DateTime dtStartDischargeTime, DateTime dtEndDischargeTime, ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17},floor(MONTHS_BETWEEN(A.visit_time,A.BIRTH_TIME)/12) as {18}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.IDENTITY
                , SystemData.PatVisitView.NURSING_CLASS
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE
                , SystemData.PatVisitView.INP_NO,"AGE");

            string szCondition = string.Format(" 1=1 AND {0}='IP'", SystemData.PatVisitView.VISIT_TYPE);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            if (!string.IsNullOrEmpty(szPatientID))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.PATIENT_ID, szPatientID);
            if (!string.IsNullOrEmpty(szPatientName))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.PATIENT_NAME, szPatientName);
            if (!string.IsNullOrEmpty(szDoctor))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.INCHARGE_DOCTOR, szDoctor);
            if (!string.IsNullOrEmpty(szDiagnosis))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.DIAGNOSIS, szDiagnosis);
            if (!string.IsNullOrEmpty(szNursingClass))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.NURSING_CLASS, szNursingClass);
            if (!string.IsNullOrEmpty(szPatientCondition))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.PATIENT_CONDITION, szPatientCondition);
            if (!string.IsNullOrEmpty(szIdentity))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.IDENTITY, szIdentity);
            if (!string.IsNullOrEmpty(szChargeType))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.CHARGE_TYPE, szChargeType);

            if (dtVisitTimeBegin != DateTime.Parse("1900-1-1")
                && dtVisitTimeEnd != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            if (dtStartDischargeTime != DateTime.Parse("1900-1-1")
                && dtEndDischargeTime != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.DISCHARGE_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtStartDischargeTime)
                    , base.MedQCAccess.GetSqlTimeFormat(dtEndDischargeTime));
            }
            if (!string.IsNullOrEmpty(szPatientStatus))
            {
                if (szPatientStatus == "在院病人")
                    szCondition = string.Format("{0} AND  A.{1} is null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);
                else if (szPatientStatus == "出院病人")
                    szCondition = string.Format("{0} AND  A.{1} is not null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);

            }
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A", SystemData.DataView.PAT_VISIT_V);
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
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.IDENTITY = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.NURSING_CLASS = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.INP_NO = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.Age = int.Parse(dataReader.GetValue(18).ToString());

                    if (nBeginAge != 0 && nBeginAge > PatVisitInfo.Age)
                        continue;
                    if (nEndAge != 0 && nEndAge < PatVisitInfo.Age)
                        continue;
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByComplexSearch", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 根据科室代码查询做过手术的患者列表
        /// </summary>
        /// <param name="szDeptCode"></param>
        /// <param name="szPatientID"></param>
        /// <param name="szPatientName"></param>
        /// <param name="szDoctor"></param>
        /// <param name="szDiagnosis"></param>
        /// <param name="szNursingClass"></param>
        /// <param name="szPatientCondition"></param>
        /// <param name="szIdentity"></param>
        /// <param name="szChargeType"></param>
        /// <param name="nBeginAge"></param>
        /// <param name="nEndAge"></param>
        /// <param name="szOperationCode"></param>
        /// <param name="lstPatVisitInfos"></param>
        /// <returns></returns>
        public short GetPatsListByComplexSearchWithOperation(string szPatientStatus, string szDeptCode, string szPatientID, string szPatientName
           , string szDoctor, string szDiagnosis, string szNursingClass, string szPatientCondition
           , string szIdentity, string szChargeType, int nBeginAge, int nEndAge, string szOperationCode
            , DateTime dtVisitTimeBegin, DateTime dtVisitTimeEnd
             , DateTime dtStartDischargeTime, DateTime dtEndDischargeTime
            , ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17},floor(MONTHS_BETWEEN(A.visit_time,A.BIRTH_TIME)/12) as {18}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.IDENTITY
                , SystemData.PatVisitView.NURSING_CLASS
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.INP_NO
                , "AGE");

            string szCondition = string.Format("A.{0}=B.{1} AND A.{2}=B.{3} AND VISIT_TYPE ='IP'", SystemData.PatVisitView.PATIENT_ID, SystemData.OperationView.PATIENT_ID
               , SystemData.PatVisitView.VISIT_ID, SystemData.OperationView.VISIT_ID);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            if (!string.IsNullOrEmpty(szPatientID))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.PATIENT_ID, szPatientID);
            if (!string.IsNullOrEmpty(szPatientName))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.PATIENT_NAME, szPatientName);
            if (!string.IsNullOrEmpty(szDoctor))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.INCHARGE_DOCTOR, szDoctor);
            if (!string.IsNullOrEmpty(szDiagnosis))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.DIAGNOSIS, szDiagnosis);
            if (!string.IsNullOrEmpty(szNursingClass))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.NURSING_CLASS, szNursingClass);
            if (!string.IsNullOrEmpty(szPatientCondition))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.PATIENT_CONDITION, szPatientCondition);
            if (!string.IsNullOrEmpty(szIdentity))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.IDENTITY, szIdentity);
            if (!string.IsNullOrEmpty(szChargeType))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.CHARGE_TYPE, szChargeType);

            if (!string.IsNullOrEmpty(szOperationCode))
                szCondition = string.Format("{0} AND B.{1}='{2}'", szCondition, SystemData.OperationView.OPERATION_CODE, szOperationCode);
            if (dtVisitTimeBegin != DateTime.Parse("1900-1-1")
               && dtVisitTimeEnd != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            if (dtEndDischargeTime != DateTime.Parse("1900-1-1")
                && dtStartDischargeTime != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.DISCHARGE_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtStartDischargeTime)
                    , base.MedQCAccess.GetSqlTimeFormat(dtEndDischargeTime));
            }
            if (!string.IsNullOrEmpty(szPatientStatus))
            {
                if (szPatientStatus == "在院病人")
                    szCondition = string.Format("{0} AND  A.{1} is null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);
                else if (szPatientStatus == "出院病人")
                    szCondition = string.Format("{0} AND  A.{1} is not null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);

            }
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A,{1} B", SystemData.DataView.PAT_VISIT_V, SystemData.DataView.OPERATION_V);
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
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.IDENTITY = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.NURSING_CLASS = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.INP_NO = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.Age = int.Parse(dataReader.GetValue(18).ToString());
                    if (nBeginAge != 0 && nBeginAge > PatVisitInfo.Age)
                        continue;
                    if (nEndAge != 0 && nEndAge < PatVisitInfo.Age)
                        continue;
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByComplexSearchWithOperation", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 复合条件查询诊断相关的患者列表
        /// </summary>
        /// <param name="szDeptCode"></param>
        /// <param name="szPatientID"></param>
        /// <param name="szPatientName"></param>
        /// <param name="szDoctor"></param>
        /// <param name="szDiagnosis"></param>
        /// <param name="szNursingClass"></param>
        /// <param name="szPatientCondition"></param>
        /// <param name="szIdentity"></param>
        /// <param name="szChargeType"></param>
        /// <param name="nBeginAge"></param>
        /// <param name="nEndAge"></param>
        /// <param name="szOperationCode"></param>
        /// <param name="lstPatVisitInfos"></param>
        /// <returns></returns>
        public short GetPatsListByComplexSearchWithDiagnosis(string szPatientStatus, string szDeptCode, string szPatientID, string szPatientName
           , string szDoctor, string szDiagnosis, string szNursingClass, string szPatientCondition
           , string szIdentity, string szChargeType, int nBeginAge, int nEndAge, string szOperationCode
            , DateTime dtVisitTimeBegin, DateTime dtVisitTimeEnd
             , DateTime dtStartDischargeTime, DateTime dtEndDischargeTime
            , ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("DISTINCT A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17},floor(MONTHS_BETWEEN(A.visit_time,A.BIRTH_TIME)/12) as {18}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.IDENTITY
                , SystemData.PatVisitView.NURSING_CLASS
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.INP_NO
                , "AGE");

            string szCondition = string.Format("A.{0}=B.{1} AND A.{2}=B.{3} AND VISIT_TYPE ='IP'", SystemData.PatVisitView.PATIENT_ID, SystemData.DiagnosisView.PATIENT_ID
               , SystemData.PatVisitView.VISIT_ID, SystemData.DiagnosisView.VISIT_ID);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            if (!string.IsNullOrEmpty(szPatientID))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.PATIENT_ID, szPatientID);
            if (!string.IsNullOrEmpty(szPatientName))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.PATIENT_NAME, szPatientName);
            if (!string.IsNullOrEmpty(szDoctor))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.INCHARGE_DOCTOR, szDoctor);
            if (!string.IsNullOrEmpty(szDiagnosis))
                szCondition = string.Format("{0} AND  B.{1} like '%{2}%' AND B.{3} ='2'", szCondition, SystemData.DiagnosisView.DIAGNOSIS_DESC, szDiagnosis, SystemData.DiagnosisView.DIAGNOSIS_TYPE);
            if (!string.IsNullOrEmpty(szNursingClass))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.NURSING_CLASS, szNursingClass);
            if (!string.IsNullOrEmpty(szPatientCondition))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.PATIENT_CONDITION, szPatientCondition);
            if (!string.IsNullOrEmpty(szIdentity))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.IDENTITY, szIdentity);
            if (!string.IsNullOrEmpty(szChargeType))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.CHARGE_TYPE, szChargeType);
            if (dtVisitTimeBegin != DateTime.Parse("1900-1-1")
               && dtVisitTimeEnd != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            if (dtEndDischargeTime != DateTime.Parse("1900-1-1")
                && dtStartDischargeTime != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.DISCHARGE_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtStartDischargeTime)
                    , base.MedQCAccess.GetSqlTimeFormat(dtEndDischargeTime));
            }
            if (!string.IsNullOrEmpty(szPatientStatus))
            {
                if (szPatientStatus == "在院病人")
                    szCondition = string.Format("{0} AND  A.{1} is null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);
                else if (szPatientStatus == "出院病人")
                    szCondition = string.Format("{0} AND  A.{1} is not null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);

            }
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A,{1} B", SystemData.DataView.PAT_VISIT_V, SystemData.DataView.DIAGNOSIS_V);
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
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.IDENTITY = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.NURSING_CLASS = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.INP_NO = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.Age = int.Parse(dataReader.GetValue(18).ToString());
                    if (nBeginAge != 0 && nBeginAge > PatVisitInfo.Age)
                        continue;
                    if (nEndAge != 0 && nEndAge < PatVisitInfo.Age)
                        continue;
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByComplexSearchWithOperation", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 根据复杂查询条件获取检验异常的患者列表
        /// </summary>
        /// <param name="szDeptCode"></param>
        /// <param name="szPatientID"></param>
        /// <param name="szPatientName"></param>
        /// <param name="szDoctor"></param>
        /// <param name="szDiagnosis"></param>
        /// <param name="szNursingClass"></param>
        /// <param name="szPatientCondition"></param>
        /// <param name="szIdentity"></param>
        /// <param name="szChargeType"></param>
        /// <param name="nBeginAge"></param>
        /// <param name="nEndAge"></param>
        /// <param name="szOperationCode"></param>
        /// <param name="lstPatVisitInfos"></param>
        /// <returns></returns>
        public short GetPatsListByComplexSearchWithLabResult(string szPatientStatus, string szDeptCode, string szPatientID, string szPatientName
           , string szDoctor, string szDiagnosis, string szNursingClass, string szPatientCondition
           , string szIdentity, string szChargeType, int nBeginAge, int nEndAge
            , DateTime dtVisitTimeBegin, DateTime dtVisitTimeEnd
             , DateTime dtStartDischargeTime, DateTime dtEndDischargeTime
            , ref List<PatVisitInfo> lstPatVisitInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("distinct A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17},floor(MONTHS_BETWEEN(A.visit_time,A.BIRTH_TIME)/12) as {18}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.IDENTITY
                , SystemData.PatVisitView.NURSING_CLASS
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE
                , SystemData.PatVisitView.INP_NO, "AGE");

            string szCondition = string.Format("1=1 AND VISIT_TYPE ='IP'");
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            if (!string.IsNullOrEmpty(szPatientID))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.PATIENT_ID, szPatientID);
            if (!string.IsNullOrEmpty(szPatientName))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.PATIENT_NAME, szPatientName);
            if (!string.IsNullOrEmpty(szDoctor))
                szCondition = string.Format("{0} AND  A.{1}='{2}'", szCondition, SystemData.PatVisitView.INCHARGE_DOCTOR, szDoctor);
            if (!string.IsNullOrEmpty(szDiagnosis))
                szCondition = string.Format("{0} AND  A.{1} like '%{2}%'", szCondition, SystemData.PatVisitView.DIAGNOSIS, szDiagnosis);
            if (!string.IsNullOrEmpty(szNursingClass))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.NURSING_CLASS, szNursingClass);
            if (!string.IsNullOrEmpty(szPatientCondition))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.PATIENT_CONDITION, szPatientCondition);
            if (!string.IsNullOrEmpty(szIdentity))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.IDENTITY, szIdentity);
            if (!string.IsNullOrEmpty(szChargeType))
                szCondition = string.Format("{0} AND  A.{1} = '{2}'", szCondition, SystemData.PatVisitView.CHARGE_TYPE, szChargeType);

            if (dtVisitTimeBegin != DateTime.Parse("1900-1-1")
               && dtVisitTimeEnd != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.VISIT_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeBegin)
                    , base.MedQCAccess.GetSqlTimeFormat(dtVisitTimeEnd));
            }
            if (dtEndDischargeTime != DateTime.Parse("1900-1-1")
                && dtStartDischargeTime != DateTime.Parse("1900-1-1"))
            {
                szCondition = string.Format("{0} AND  A.{1} >= {2} AND A.{1} <= {3}"
                    , szCondition, SystemData.PatVisitView.DISCHARGE_TIME
                    , base.MedQCAccess.GetSqlTimeFormat(dtStartDischargeTime)
                    , base.MedQCAccess.GetSqlTimeFormat(dtEndDischargeTime));
            }
            if (!string.IsNullOrEmpty(szPatientStatus))
            {
                if (szPatientStatus == "在院病人")
                    szCondition = string.Format("{0} AND  A.{1} is null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);
                else if (szPatientStatus == "出院病人")
                    szCondition = string.Format("{0} AND  A.{1} is not null "
                        , szCondition, SystemData.PatVisitView.DISCHARGE_TIME);

            }
            szCondition = string.Format("{4} AND A.{0}=B.{1} AND A.{2}=B.{3} AND B.test_id =C.test_id AND C.abnormal_indicator is not null ", SystemData.PatVisitView.PATIENT_ID, SystemData.OperationView.PATIENT_ID
               , SystemData.PatVisitView.VISIT_ID, SystemData.OperationView.VISIT_ID
               , szCondition);

            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A,{1} B,{2} C", SystemData.DataView.PAT_VISIT_V, "lab_master_v", "lab_result_v");
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
                if (lstPatVisitInfos == null)
                    lstPatVisitInfos = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo PatVisitInfo = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) PatVisitInfo.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) PatVisitInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) PatVisitInfo.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) PatVisitInfo.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) PatVisitInfo.PATIENT_SEX = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) PatVisitInfo.BIRTH_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) PatVisitInfo.CHARGE_TYPE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) PatVisitInfo.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) PatVisitInfo.BED_CODE = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) PatVisitInfo.PATIENT_CONDITION = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) PatVisitInfo.INCHARGE_DOCTOR= dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) PatVisitInfo.DIAGNOSIS = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) PatVisitInfo.DEPT_CODE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) PatVisitInfo.IDENTITY = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) PatVisitInfo.NURSING_CLASS = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) PatVisitInfo.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) PatVisitInfo.DISCHARGE_MODE = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) PatVisitInfo.INP_NO = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) PatVisitInfo.Age = int.Parse(dataReader.GetValue(18).ToString());
                    if (nBeginAge != 0 && nBeginAge > PatVisitInfo.Age)
                        continue;
                    if (nEndAge != 0 && nEndAge < PatVisitInfo.Age)
                        continue;
                    lstPatVisitInfos.Add(PatVisitInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByComplexSearchWithOperation", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
