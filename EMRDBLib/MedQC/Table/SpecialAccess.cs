using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using System.Data.OleDb;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{ /// <summary>
  /// 专家质控相关
  /// </summary>
    public class SpecialAccess : DBAccessBase
    {
        private static SpecialAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SpecialAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SpecialAccess();
                return m_Instance;
            }
        }
        #region 专家资源库数据库操作
        

        #endregion

        #region 病人获取
        /// <summary>
        /// 获取患者列表信息列表
        /// </summary>
        /// <param name="lstQCScoreCheck"></param>
        /// <returns></returns>
        public short GetPatientList(string szPatientCondition, string szDischargeMode, string szDeptCode, DateTime dtStartTime, DateTime dtEndTime, string szPatientCount,
            string szInDaysBegin, string szInDaysEnd, string szRequestDoctorID, string szParentDoctorID, ref List<PatVisitInfo> lstPatVisitLog)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtStartTime == null || dtEndTime == null
                || string.IsNullOrEmpty(szPatientCount))
            {
                LogManager.Instance.WriteLog("DbAccess.GetPatientList", new string[] { "dtStartTime", "dtEndTime", "szPatientCount" }
                    , new object[] { dtStartTime, dtEndTime, szPatientCount }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" select t.PATIENT_ID,t.PATIENT_NAME,t.PATIENT_SEX,t.INP_NO,t.VISIT_ID,t.VISIT_TIME,t.DEPT_CODE,t.DEPT_NAME,t.PATIENT_CONDITION,t.DISCHARGE_MODE,t.INCHARGE_DOCTOR,t.DISCHARGE_TIME from  ");
            sbSql.Append(" ( ");
            //如果关联医生，关联PAT_DOCTOR_V
            if (string.IsNullOrEmpty(szRequestDoctorID) && string.IsNullOrEmpty(szParentDoctorID))
            {
                sbSql.Append(" select t1.PATIENT_ID,t1.PATIENT_NAME,t1.PATIENT_SEX,t1.INP_NO,t1.VISIT_ID,t1.VISIT_TIME,t1.DEPT_CODE,t1.DEPT_NAME,t1.PATIENT_CONDITION,t1.DISCHARGE_MODE,t1.INCHARGE_DOCTOR,t1.DISCHARGE_TIME from  pat_visit_v t1");
                sbSql.Append(" where 1=1");
            }
            else
            {
                sbSql.Append(" select t1.PATIENT_ID,t1.PATIENT_NAME,t1.PATIENT_SEX,t1.INP_NO,t1.VISIT_ID,t1.VISIT_TIME,t1.DEPT_CODE,t1.DEPT_NAME,t1.PATIENT_CONDITION,t1.DISCHARGE_MODE,t1.INCHARGE_DOCTOR,t1.DISCHARGE_TIME from  pat_visit_v t1,PAT_DOCTOR_V t2 ");
                sbSql.Append(" where 1=1 and t1.PATIENT_ID=t2.PATIENT_ID and t1.VISIT_ID=t2.VISIT_ID");
                if (!string.IsNullOrEmpty(szRequestDoctorID))
                    sbSql.AppendFormat(" and t2.REQUEST_DOCTOR_ID='{0}'", szRequestDoctorID);
                if (!string.IsNullOrEmpty(szParentDoctorID))
                    sbSql.AppendFormat(" and t2.PARENT_DOCTOR_ID='{0}'", szParentDoctorID);
            }

            if (!string.IsNullOrEmpty(szDischargeMode))
            {
                sbSql.AppendFormat(" and t1.DISCHARGE_MODE ='{0}' ", szDischargeMode);
            }
            //如果关联出院病人病情，关联ADT_LOG_V视图
            if (!string.IsNullOrEmpty(szPatientCondition))
            {
                //sbSql.AppendFormat(" and t1.PATIENT_CONDITION_code = '{0}' ", SystemData.ArrPatientCondition.GetPatientConditionCode(szPatientCondition));
                string szPatientConditionTable = "";
                if (szPatientCondition == "一般")
                {
                    szPatientConditionTable = "SELECT DISTINCT PATIENT_ID, VISIT_ID FROM ADT_LOG_V MINUS SELECT DISTINCT PATIENT_ID, VISIT_ID FROM ADT_LOG_V WHERE PATIENT_CONDITION IN ('A', 'B') ";
                }
                else if (szPatientCondition == "急")
                {
                    szPatientConditionTable = "SELECT DISTINCT PATIENT_ID, VISIT_ID FROM ADT_LOG_V WHERE PATIENT_CONDITION in ('A', 'B') MINUS SELECT DISTINCT PATIENT_ID, VISIT_ID FROM ADT_LOG_V WHERE PATIENT_CONDITION = 'A'";
                }
                else if (szPatientCondition == "危")
                {
                    szPatientConditionTable = "SELECT DISTINCT PATIENT_ID, VISIT_ID  FROM ADT_LOG_V WHERE PATIENT_CONDITION = 'A'";
                }
                sbSql.Replace("pat_visit_v t1", string.Format("pat_visit_v t1,({0}) t3", szPatientConditionTable));
                sbSql.Append(" AND t1.PATIENT_ID=t3.PATIENT_ID AND t1.VISIT_ID=t3.VISIT_ID ");
            }
            if (!string.IsNullOrEmpty(szDeptCode))
            {
                sbSql.AppendFormat(" and t1.DEPT_CODE = '{0}' ", szDeptCode);
            }
            if (!string.IsNullOrEmpty(szInDaysBegin))
            {
                sbSql.AppendFormat(" and TRUNC(t1.DISCHARGE_TIME-t1.VISIT_TIME)>={0}", szInDaysBegin);
            }
            if (!string.IsNullOrEmpty(szInDaysEnd))
            {
                sbSql.AppendFormat(" and TRUNC(t1.DISCHARGE_TIME-t1.VISIT_TIME)<={0}", szInDaysEnd);
            }
            sbSql.AppendFormat(" and t1.DISCHARGE_TIME <=to_date('{0}','YYYY/MM/DD HH24:MI:SS') ", dtEndTime.ToString("yyyy/MM/dd HH:mm:ss"));
            sbSql.AppendFormat(" and t1.DISCHARGE_TIME >=to_date('{0}','YYYY/MM/DD HH24:MI:SS') ", dtStartTime.ToString("yyyy/MM/dd HH:mm:ss"));
            sbSql.Append(" and t1.VISIT_TYPE='IP' ");
            sbSql.Append(" order by dbms_random.value ");
            sbSql.Append(" ) t");
            sbSql.AppendFormat(" where rownum<={0}", szPatientCount);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(sbSql.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLog == null)
                    lstPatVisitLog = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0))
                        patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        patVisitLog.PATIENT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        patVisitLog.PATIENT_SEX = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                        patVisitLog.INP_NO = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        patVisitLog.VISIT_ID = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5))
                        patVisitLog.VISIT_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6))
                        patVisitLog.DEPT_CODE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7))
                        patVisitLog.DEPT_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8))
                        patVisitLog.PATIENT_CONDITION = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9))
                        patVisitLog.DISCHARGE_MODE = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10))
                        patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11))
                        patVisitLog.DISCHARGE_TIME = dataReader.GetDateTime(11);
                    lstPatVisitLog.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetPatientList", new string[] { "sbSql.ToString()" }, new object[] { sbSql.ToString() }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 通过病案分配批次号，获取患者列表信息列表
        /// </summary>
        /// <param name="lstPatVisitLog"></param>
        /// <returns></returns>
        public short GetPatientList(string szConfigID, string szUserID, ref List<PatVisitInfo> lstPatVisitLog)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szConfigID))
            {
                LogManager.Instance.WriteLog("DbAccess.GetPatientList", new string[] { "szConfigID" }
                    , new object[] { szConfigID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szPidVidValuesCondition = string.Empty;
            short shRet = this.GetPidVidValues(szConfigID, szUserID, ref szPidVidValuesCondition);
            if (shRet != SystemData.ReturnValue.OK || string.IsNullOrEmpty(szPidVidValuesCondition))
                return SystemData.ReturnValue.RES_NO_FOUND;
            string[] conditions = szPidVidValuesCondition.Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries);
            if (conditions == null || conditions.Length == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            lstPatVisitLog = new List<PatVisitInfo>();
            foreach (string s in conditions)
            {
                PatVisitInfo patVisitLog = null;
                GetPatVisitLog(s, ref patVisitLog);
                if (patVisitLog != null)
                    lstPatVisitLog.Add(patVisitLog);
            }

            if (lstPatVisitLog.Count == 0)
                return SystemData.ReturnValue.RES_NO_FOUND;
            else
                return SystemData.ReturnValue.OK;

            //按照科室排序
        }

        private short GetPatVisitLog(string szPidVidValuesCondition, ref PatVisitInfo patVisitLog)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" select t.PATIENT_ID,t.PATIENT_NAME,t.PATIENT_SEX,t.INP_NO,t.VISIT_ID,t.VISIT_TIME,t.DEPT_CODE,t.DEPT_NAME,t.PATIENT_CONDITION,t.DISCHARGE_MODE,t.INCHARGE_DOCTOR,t.DISCHARGE_TIME   ");
            sbSql.Append(" from pat_visit_v t ");
            sbSql.Append(" where " + szPidVidValuesCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(sbSql.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                patVisitLog = new PatVisitInfo();
                if (!dataReader.IsDBNull(0))
                    patVisitLog.PATIENT_ID = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1))
                    patVisitLog.PATIENT_NAME = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2))
                    patVisitLog.PATIENT_SEX = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    patVisitLog.INP_NO = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    patVisitLog.VISIT_ID = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    patVisitLog.VISIT_TIME = dataReader.GetDateTime(5);
                if (!dataReader.IsDBNull(6))
                    patVisitLog.DEPT_CODE = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    patVisitLog.DEPT_NAME = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    patVisitLog.PATIENT_CONDITION = dataReader.GetString(8);
                if (!dataReader.IsDBNull(9))
                    patVisitLog.DISCHARGE_MODE = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(10);
                if (!dataReader.IsDBNull(11))
                    patVisitLog.DISCHARGE_TIME = dataReader.GetDateTime(11);
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetPatientList", new string[] { "sbSql.ToString()" }, new object[] { sbSql.ToString() }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        private short GetPidVidValues(string szConfigID, string szUserID, ref string szPidVidValuesCondition)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szConfigID))
            {
                LogManager.Instance.WriteLog("DbAccess.GetPatientList", new string[] { "szConfigID" }
                    , new object[] { szConfigID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" select PATIENT_ID,VISIT_ID");
            sbSql.Append(" from qc_special_detail_t B ");
            sbSql.AppendFormat(" where B.Config_Id='{0}' ", szConfigID);
            if (!string.IsNullOrEmpty(szUserID))
                sbSql.AppendFormat(" and B.SPECIAL_ID='{0}' ", szUserID);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(sbSql.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                do
                {
                    szPidVidValuesCondition += string.Format(" (PATIENT_ID='{0}' AND VISIT_ID='{1}') OR", dataReader.GetString(0), dataReader.GetString(1));
                } while (dataReader.Read());
                if (!string.IsNullOrEmpty(szPidVidValuesCondition))
                {
                    int index = szPidVidValuesCondition.LastIndexOf("OR");
                    szPidVidValuesCondition = szPidVidValuesCondition.Remove(index);
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetPatientList", new string[] { "sbSql.ToString()" }, new object[] { sbSql.ToString() }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        #endregion

        #region 专家质控病案分配主表
        /// <summary>
        /// 获取专家质控病案分配主表信息列表
        /// </summary>
        /// <param name="lstQcSpecialCheck"></param>
        /// <returns></returns>
        public short GetQCSpecialCheckList(DateTime dtStartTime, DateTime dtEndTime, ref List<QcSpecialCheck> lstQcSpecialCheck)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtEndTime == null || dtStartTime == null)
            {
                LogManager.Instance.WriteLog("DbAccess.GetQCSpecialCheckList", new string[] { "dtStartTime", "dtEndTime" }
                    , new object[] { dtStartTime, dtEndTime }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}"
                , SystemData.QcSpecialCheckTable.CONFIG_ID
                , SystemData.QcSpecialCheckTable.DISCHARGE_MODE
                , SystemData.QcSpecialCheckTable.END_TIME
                , SystemData.QcSpecialCheckTable.NAME
                , SystemData.QcSpecialCheckTable.PATIENT_CONDITION
                , SystemData.QcSpecialCheckTable.PATIENT_COUNT
                , SystemData.QcSpecialCheckTable.PER_COUNT
                , SystemData.QcSpecialCheckTable.SPECIAL_COUNT
                , SystemData.QcSpecialCheckTable.START_TIME
                , SystemData.QcSpecialCheckTable.CREATER
                , SystemData.QcSpecialCheckTable.CREATE_TIME
                , SystemData.QcSpecialCheckTable.CHECKED

                );
            string szCondition = string.Format("1=1 and {0} >={1} and {0} <= {2} "
                , SystemData.QcSpecialCheckTable.CREATE_TIME
                , base.MedQCAccess.GetSqlTimeFormat(dtStartTime)
                , base.MedQCAccess.GetSqlTimeFormat(dtEndTime)
                );
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , szField, SystemData.DataTable.QC_SPECIAL_CHECK, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcSpecialCheck == null)
                    lstQcSpecialCheck = new List<QcSpecialCheck>();
                do
                {
                    QcSpecialCheck qcSpecialCheck = new QcSpecialCheck();
                    if (!dataReader.IsDBNull(0))
                        qcSpecialCheck.ConfigID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        qcSpecialCheck.DischargeMode = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        qcSpecialCheck.EndTime = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3))
                        qcSpecialCheck.Name = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        qcSpecialCheck.PatientCondition = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5))
                        qcSpecialCheck.PatientCount = int.Parse(dataReader.GetValue(5).ToString());
                    if (!dataReader.IsDBNull(6))
                        qcSpecialCheck.PerCount = int.Parse(dataReader.GetValue(6).ToString());
                    if (!dataReader.IsDBNull(7))
                        qcSpecialCheck.SpecialCount = int.Parse(dataReader.GetValue(7).ToString());
                    if (!dataReader.IsDBNull(8))
                        qcSpecialCheck.StartTime = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9))
                        qcSpecialCheck.Creater = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10))
                        qcSpecialCheck.CreateTime = dataReader.GetDateTime(10);
                    if (!dataReader.IsDBNull(11))
                        qcSpecialCheck.Checked = dataReader.GetString(11) == "1";
                    lstQcSpecialCheck.Add(qcSpecialCheck);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetQCScoreCheck", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 新增一条专家质控病案分配主记录
        /// </summary>
        /// <param name="qcSpecialCheck"></param>
        /// <returns></returns>
        public short SaveQCSpecialCheck(QcSpecialCheck qcSpecialCheck)
        {
            if (qcSpecialCheck == null)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveQCSpecialCheck", new string[] { "qcSpecialCheck" }
                    , new object[] { qcSpecialCheck }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}"
                , SystemData.QcSpecialCheckTable.CONFIG_ID
                , SystemData.QcSpecialCheckTable.DISCHARGE_MODE
                , SystemData.QcSpecialCheckTable.END_TIME
                , SystemData.QcSpecialCheckTable.NAME
                , SystemData.QcSpecialCheckTable.PATIENT_CONDITION
                , SystemData.QcSpecialCheckTable.PATIENT_COUNT
                , SystemData.QcSpecialCheckTable.PER_COUNT
                , SystemData.QcSpecialCheckTable.SPECIAL_COUNT
                , SystemData.QcSpecialCheckTable.START_TIME
                , SystemData.QcSpecialCheckTable.CREATER
                , SystemData.QcSpecialCheckTable.CREATE_TIME);

            string szValue = string.Format("'{0}','{1}',{2},'{3}','{4}',{5},{6},{7},{8},'{9}',{10}"
                , qcSpecialCheck.ConfigID
                , qcSpecialCheck.DischargeMode
                , base.MedQCAccess.GetSqlTimeFormat(qcSpecialCheck.EndTime)
                , qcSpecialCheck.Name
                , qcSpecialCheck.PatientCondition
                , qcSpecialCheck.PatientCount.ToString()
                , qcSpecialCheck.PerCount.ToString()
                , qcSpecialCheck.SpecialCount.ToString()
                , base.MedQCAccess.GetSqlTimeFormat(qcSpecialCheck.StartTime)
                , qcSpecialCheck.Creater
                , base.MedQCAccess.GetSqlTimeFormat(qcSpecialCheck.CreateTime));

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_SPECIAL_CHECK, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveQCScoreCheck", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveQCScoreCheck", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.ACCESS_ERROR;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 更新一条专家质控病案分配记录
        /// </summary>
        /// <param name="qcScoreCheck"></param>
        /// <returns></returns>
        public short UpdateQCSpecialCheck(QcSpecialCheck qcSpecialCheck)
        {
            if (qcSpecialCheck == null)
            {
                LogManager.Instance.WriteLog("DbAccess.UpdateQCScoreCheck", new string[] { "qcScoreCheck" }
                    , new object[] { qcSpecialCheck }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}={3},{4}='{5}',{6}='{7}',{8}={9},{10}={11},{12}={13},{14}={15},{16}='{17}',{18}={19}"
                , SystemData.QcSpecialCheckTable.DISCHARGE_MODE, qcSpecialCheck.DischargeMode
                , SystemData.QcSpecialCheckTable.END_TIME, base.MedQCAccess.GetSqlTimeFormat(qcSpecialCheck.EndTime)
                , SystemData.QcSpecialCheckTable.NAME, qcSpecialCheck.Name
                , SystemData.QcSpecialCheckTable.PATIENT_CONDITION, qcSpecialCheck.PatientCondition
                , SystemData.QcSpecialCheckTable.PATIENT_COUNT, qcSpecialCheck.PatientCount.ToString()
                , SystemData.QcSpecialCheckTable.PER_COUNT, qcSpecialCheck.PerCount.ToString()
                , SystemData.QcSpecialCheckTable.SPECIAL_COUNT, qcSpecialCheck.SpecialCount.ToString()
                , SystemData.QcSpecialCheckTable.START_TIME, base.MedQCAccess.GetSqlTimeFormat(qcSpecialCheck.StartTime)
                , SystemData.QcSpecialCheckTable.CREATER, qcSpecialCheck.Creater
                , SystemData.QcSpecialCheckTable.CREATE_TIME, base.MedQCAccess.GetSqlTimeFormat(qcSpecialCheck.CreateTime)
                );

            string szCondition = string.Format("{0}='{1}'", SystemData.QcSpecialCheckTable.CONFIG_ID, qcSpecialCheck.ConfigID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_SPECIAL_CHECK, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.UpdateQCSpecialCheck", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("DbAccess.UpdateQCSpecialCheck", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.ACCESS_ERROR;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新专家分配是否已完成质检状态
        /// </summary>
        /// <param name="configID"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public short UpdateQCSpeicalCheckState(string szConfigID, string szStateCode)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szConfigID) || GlobalMethods.Misc.IsEmptyString(szStateCode))
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCSpecialCheck", new string[] { "szConfigID", "szStateCode" }
                    , new object[] { szConfigID, szStateCode }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcSpecialCheckTable.CONFIG_ID, szConfigID);
            string szField = string.Format("{0}='{1}'", SystemData.QcSpecialCheckTable.CHECKED, szStateCode);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_SPECIAL_CHECK, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.UpdateQCSpeicalCheckState", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("DbAccess.UpdateQCSpeicalCheckState", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.ACCESS_ERROR;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 检查对应的分配结果是否已经被质检过
        /// </summary>
        /// <param name="configID"></param>
        /// <returns></returns>
        public short IsQCSpecialChecked(string szConfigID, ref bool bChecked)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szConfigID))
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCScoreCheck", new string[] { "szConfigID" }
                    , new object[] { szConfigID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            StringBuilder szSQL = new StringBuilder();
            szSQL.Append("SELECT COUNT(*) COUNT FROM QC_MSG_V M, (SELECT PATIENT_ID, VISIT_ID  FROM QC_SPECIAL_CHECK_T A, QC_SPECIAL_DETAIL_T B");
            szSQL.Append(" WHERE A.CONFIG_ID = B.CONFIG_ID");
            szSQL.AppendFormat(" AND A.CONFIG_ID = '{0}') N", szConfigID);
            szSQL.Append(" WHERE M.PATIENT_ID = N.PATIENT_ID AND M.VISIT_ID = N.VISIT_ID  AND M.ISSUED_TYPE = 1");

            IDataReader reader = null;
            try
            {
                reader = base.MedQCAccess.ExecuteReader(szSQL.ToString(), CommandType.Text);
                if (reader == null || reader.IsClosed || !reader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (!reader.IsDBNull(0)) bChecked = Convert.ToInt32(reader.GetValue(0)) != 0;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.IsQCSpecialChecked", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }

            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 删除一条专家质控病案分配记录
        /// </summary>
        /// <param name="szConfigID"></param>
        /// <returns></returns>
        public short DeleteQCSpecialCheck(string szConfigID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szConfigID))
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCSpecialCheck", new string[] { "szConfigID" }
                    , new object[] { szConfigID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcSpecialCheckTable.CONFIG_ID, szConfigID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_SPECIAL_CHECK, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCSpecialCheck", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCSpecialCheck", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.ACCESS_ERROR;
            }
            return SystemData.ReturnValue.OK;
        }

        #endregion

        #region 专家质控病案分配详情表
        /// <summary>
        /// 获取专家质控病案分配详情表信息列表
        /// </summary>
        /// <param name="lstQcSpecialCheck"></param>
        /// <returns></returns>
        public short GetQCSpecialDetailList(string szConfigID, ref List<QcSpecialDetail> lstQcSpecialDetail)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szConfigID))
            {
                LogManager.Instance.WriteLog("DbAccess.GetQCSpecialDetailList", new string[] { "szConfigID" }
                    , new object[] { szConfigID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.QcSpecialDetailTable.CONFIG_ID
                , SystemData.QcSpecialDetailTable.PATIENT_ID
                , SystemData.QcSpecialDetailTable.SPECIAL_ID
                , SystemData.QcSpecialDetailTable.SPECIAL_NAME
                , SystemData.QcSpecialDetailTable.VISIT_ID

                );
            string szCondition = string.Format("1=1 And {0}='{1}'"
                , SystemData.QcSpecialDetailTable.CONFIG_ID, szConfigID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , szField, SystemData.DataTable.QC_SPECIAL_DETAIL, szCondition
                    , SystemData.QcSpecialDetailTable.SPECIAL_ID);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcSpecialDetail == null)
                    lstQcSpecialDetail = new List<QcSpecialDetail>();
                do
                {
                    QcSpecialDetail qcSpecialDetail = new QcSpecialDetail();
                    if (!dataReader.IsDBNull(0))
                        qcSpecialDetail.ConfigID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        qcSpecialDetail.PatientID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        qcSpecialDetail.SpecialID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                        qcSpecialDetail.SpecialName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        qcSpecialDetail.VisitID = dataReader.GetString(4);
                    lstQcSpecialDetail.Add(qcSpecialDetail);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetQCSpecialDetailList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 新增一条专家质控病案分配详情记录
        /// </summary>
        /// <param name="qcSpecialCheck"></param>
        /// <returns></returns>
        public short SaveQCSpecialDetail(QcSpecialDetail qcSpecialDetail)
        {
            if (qcSpecialDetail == null)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveQCSpecialDetail", new string[] { "qcSpecialDetail" }
                    , new object[] { qcSpecialDetail }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.QcSpecialDetailTable.CONFIG_ID
                , SystemData.QcSpecialDetailTable.PATIENT_ID
                , SystemData.QcSpecialDetailTable.SPECIAL_ID
                , SystemData.QcSpecialDetailTable.SPECIAL_NAME
                , SystemData.QcSpecialDetailTable.VISIT_ID);

            string szValue = string.Format("'{0}','{1}','{2}','{3}','{4}'"
                , qcSpecialDetail.ConfigID
                , qcSpecialDetail.PatientID
                , qcSpecialDetail.SpecialID
                , qcSpecialDetail.SpecialName
                , qcSpecialDetail.VisitID);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_SPECIAL_DETAIL, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveQCSpecialDetail", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveQCSpecialDetail", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.ACCESS_ERROR;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条专家质控病案分配记录
        /// </summary>
        /// <param name="szConfigID"></param>
        /// <returns></returns>
        public short DeleteQCSpecialDetail(string szConfigID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szConfigID))
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCSpecialCheck", new string[] { "szConfigID" }
                    , new object[] { szConfigID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcSpecialDetailTable.CONFIG_ID, szConfigID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_SPECIAL_DETAIL, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCSpecialDetail", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQCSpecialDetail", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.ACCESS_ERROR;
            }
            return SystemData.ReturnValue.OK;
        }

        #endregion

        #region 病人信息
        /// <summary>
        /// 获取病人的基本信息
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <param name="patBasicInfo">病人基本信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatVisitInfo(string szPatientID, string szVisitID, ref PatVisitInfo patVisitLog)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}", SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.SERVICE_AGENCY
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.ADDRESS
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.INCHARGE_DOCTOR
                , SystemData.PatVisitView.DISCHARGE_MODE);
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
                if (patVisitLog == null)
                    patVisitLog = new PatVisitInfo();
                do
                {
                    if (!dataReader.IsDBNull(0)) patVisitLog.INP_NO = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.PATIENT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.CHARGE_TYPE = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.DEPT_NAME = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.BED_CODE = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) patVisitLog.DIAGNOSIS = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) patVisitLog.SERVICE_AGENCY = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) patVisitLog.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.DISCHARGE_TIME = dataReader.GetDateTime(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.ADDRESS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.PATIENT_ID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.VISIT_ID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) patVisitLog.DISCHARGE_MODE = dataReader.GetString(16);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatVisitInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        #endregion
    }
}
