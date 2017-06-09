// ***********************************************************
// 数据库访问层与病历时效自动质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    
    public class QcTimeRecordAccess : DBAccessBase
    {
        private static QcTimeRecordAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static QcTimeRecordAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcTimeRecordAccess();
                return QcTimeRecordAccess.m_Instance;
            }
        }


        #region 时效检查
        #region 时效质控记录操作
        /// <summary>
        /// 时效质控记录表查询
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcTimeRecords(ref List<QcTimeRecord> lstQcTimeRecords)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24}"
                , SystemData.QcTimeRecordTable.BEGIN_DATE
                , SystemData.QcTimeRecordTable.CHECK_DATE
                , SystemData.QcTimeRecordTable.CHECKER_NAME
                , SystemData.QcTimeRecordTable.CREATE_ID
                , SystemData.QcTimeRecordTable.CREATE_NAME
                , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
                , SystemData.QcTimeRecordTable.DEPT_STAYED
                , SystemData.QcTimeRecordTable.DOC_ID
                , SystemData.QcTimeRecordTable.DOC_TITLE
                , SystemData.QcTimeRecordTable.DOCTOR_IN_CHARGE
                , SystemData.QcTimeRecordTable.DOCTYPE_ID
                , SystemData.QcTimeRecordTable.DOCTYPE_NAME
                , SystemData.QcTimeRecordTable.END_DATE
                , SystemData.QcTimeRecordTable.EVENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_NAME
                , SystemData.QcTimeRecordTable.POINT
                , SystemData.QcTimeRecordTable.QC_EXPLAIN
                , SystemData.QcTimeRecordTable.QC_RESULT
                , SystemData.QcTimeRecordTable.REC_NO
                , SystemData.QcTimeRecordTable.RECORD_TIME
                , SystemData.QcTimeRecordTable.VISIT_ID
                , SystemData.QcTimeRecordTable.EVENT_NAME
                , SystemData.QcTimeRecordTable.EVENT_TIME
                , SystemData.QcTimeRecordTable.DOC_TIME);

            string szCondition = String.Format("1=1");

            string szSQL = null;

            szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                , szField, SystemData.DataTable.QC_TIME_RECORD, szCondition);


            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcTimeRecords == null)
                    lstQcTimeRecords = new List<QcTimeRecord>();
                do
                {
                    QcTimeRecord record = new QcTimeRecord();
                    if (!dataReader.IsDBNull(0)) record.BeginDate = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) record.CheckDate = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) record.CheckName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) record.CreateID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) record.CreateName = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) record.DeptInCharge = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) record.DeptStayed = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) record.DocID = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) record.DocTitle = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) record.DoctorInCharge = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) record.DocTypeID = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) record.DocTypeName = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) record.EndDate = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) record.EventID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) record.PatientID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) record.PatientName = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) record.Point = float.Parse(dataReader.GetValue(16).ToString());
                    if (!dataReader.IsDBNull(17)) record.QcExplain = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) record.QcResult = dataReader.GetValue(18).ToString();
                    if (!dataReader.IsDBNull(19)) record.RecNo = dataReader.GetValue(19).ToString();
                    if (!dataReader.IsDBNull(20)) record.RecordTime = dataReader.GetDateTime(20);
                    if (!dataReader.IsDBNull(21)) record.VisitID = dataReader.GetString(21);
                    if (!dataReader.IsDBNull(22)) record.EventName = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) record.EventTime = dataReader.GetDateTime(23);
                    if (!dataReader.IsDBNull(24)) record.DocTime = dataReader.GetDateTime(24);
                    lstQcTimeRecords.Add(record);

                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetQcTimeRecords", new string[] { "szGroupName", "szConfigName", "SQL" }
                        , new object[] { szSQL }, "没有查询到记录!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 查询个人本次入院的时效质控记录
        /// </summary>
        /// <param name="szPatientID">病人ID号</param>
        /// <param name="szVisitID">就诊号</param>
        /// <param name="lstQcTimeRecords"></param>
        /// <returns></returns>
        public short GetQcTimeRecords(string szPatientID, string szVisitID, ref List<QcTimeRecord> lstQcTimeRecords)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szPatientID)
                || string.IsNullOrEmpty(szVisitID))
            {
                LogManager.Instance.WriteLog("GetQcTimeRecords", new string[] { "szPateintID", "szVisitID" }, new object[] { szPatientID, szVisitID }, "查询个人本次入院的时效质控记录参数错误");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25}"
                , SystemData.QcTimeRecordTable.BEGIN_DATE
                , SystemData.QcTimeRecordTable.CHECK_DATE
                , SystemData.QcTimeRecordTable.CHECKER_NAME
                , SystemData.QcTimeRecordTable.CREATE_ID
                , SystemData.QcTimeRecordTable.CREATE_NAME
                , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
                , SystemData.QcTimeRecordTable.DEPT_STAYED
                , SystemData.QcTimeRecordTable.DOC_ID
                , SystemData.QcTimeRecordTable.DOC_TITLE
                , SystemData.QcTimeRecordTable.DOCTOR_IN_CHARGE
                , SystemData.QcTimeRecordTable.DOCTYPE_ID
                , SystemData.QcTimeRecordTable.DOCTYPE_NAME
                , SystemData.QcTimeRecordTable.END_DATE
                , SystemData.QcTimeRecordTable.EVENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_NAME
                , SystemData.QcTimeRecordTable.POINT
                , SystemData.QcTimeRecordTable.QC_EXPLAIN
                , SystemData.QcTimeRecordTable.QC_RESULT
                , SystemData.QcTimeRecordTable.REC_NO
                , SystemData.QcTimeRecordTable.RECORD_TIME
                , SystemData.QcTimeRecordTable.VISIT_ID
                , SystemData.QcTimeRecordTable.EVENT_NAME
                , SystemData.QcTimeRecordTable.EVENT_TIME
                , SystemData.QcTimeRecordTable.MESSAGE_NOTIFY
                , SystemData.QcTimeRecordTable.DOC_TIME);

            string szCondition = String.Format("1=1 AND {0} ='{1}' AND {2} ='{3}'"
                , SystemData.QcTimeRecordTable.PATIENT_ID, szPatientID
                , SystemData.QcTimeRecordTable.VISIT_ID, szVisitID);

            string szSQL = null;

            szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                , szField, SystemData.DataTable.QC_TIME_RECORD, szCondition);


            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcTimeRecords == null)
                    lstQcTimeRecords = new List<QcTimeRecord>();
                do
                {
                    QcTimeRecord record = new QcTimeRecord();
                    if (!dataReader.IsDBNull(0)) record.BeginDate = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) record.CheckDate = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) record.CheckName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) record.CreateID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) record.CreateName = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) record.DeptInCharge = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) record.DeptStayed = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) record.DocID = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) record.DocTitle = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) record.DoctorInCharge = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) record.DocTypeID = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) record.DocTypeName = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) record.EndDate = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) record.EventID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) record.PatientID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) record.PatientName = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) record.Point = float.Parse(dataReader.GetValue(16).ToString());
                    if (!dataReader.IsDBNull(17)) record.QcExplain = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) record.QcResult = dataReader.GetValue(18).ToString();
                    if (!dataReader.IsDBNull(19)) record.RecNo = dataReader.GetValue(19).ToString();
                    if (!dataReader.IsDBNull(20)) record.RecordTime = dataReader.GetDateTime(20);
                    if (!dataReader.IsDBNull(21)) record.VisitID = dataReader.GetString(21);
                    if (!dataReader.IsDBNull(22)) record.EventName = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) record.EventTime = dataReader.GetDateTime(23);
                    if (!dataReader.IsDBNull(24)) record.MessageNotify = dataReader.GetValue(24).ToString() == "1" ? true : false;
                    if (!dataReader.IsDBNull(25)) record.DocTime = dataReader.GetDateTime(25);
                    lstQcTimeRecords.Add(record);

                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetQcTimeRecords", new string[] { "szGroupName", "szConfigName", "SQL" }
                        , new object[] { szSQL }, "查询个人本次入院的时效质控记录失败", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 保存一条时效质控记录
        /// </summary>
        /// <param name="configInfo">配置项及其配置数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short SaveQcTimeRecord(QcTimeRecord record)
        {
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27}"
                , SystemData.QcTimeRecordTable.BEGIN_DATE
                , SystemData.QcTimeRecordTable.CHECK_DATE
                , SystemData.QcTimeRecordTable.CHECKER_NAME
                , SystemData.QcTimeRecordTable.CREATE_ID
                , SystemData.QcTimeRecordTable.CREATE_NAME
                , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
                , SystemData.QcTimeRecordTable.DEPT_STAYED
                , SystemData.QcTimeRecordTable.DOC_ID
                , SystemData.QcTimeRecordTable.DOC_TITLE
                , SystemData.QcTimeRecordTable.DOCTOR_IN_CHARGE
                , SystemData.QcTimeRecordTable.DOCTYPE_ID
                , SystemData.QcTimeRecordTable.DOCTYPE_NAME
                , SystemData.QcTimeRecordTable.END_DATE
                , SystemData.QcTimeRecordTable.EVENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_NAME
                , SystemData.QcTimeRecordTable.POINT
                , SystemData.QcTimeRecordTable.QC_EXPLAIN
                , SystemData.QcTimeRecordTable.QC_RESULT
                , SystemData.QcTimeRecordTable.REC_NO
                , SystemData.QcTimeRecordTable.RECORD_TIME
                , SystemData.QcTimeRecordTable.VISIT_ID
                , SystemData.QcTimeRecordTable.EVENT_NAME
                , SystemData.QcTimeRecordTable.EVENT_TIME
                , SystemData.QcTimeRecordTable.MESSAGE_NOTIFY
                , SystemData.QcTimeRecordTable.DOC_TIME
                , SystemData.QcTimeRecordTable.IS_VETO
                , SystemData.QcTimeRecordTable.VISIT_NO);

            string szValue = string.Format("{0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}','{14}','{15}',{16},'{17}',{18},{19},{20},'{21}','{22}',{23},{24},{25},{26},'{27}'"
                , base.QCAccess.GetSqlTimeFormat(record.BeginDate), base.QCAccess.GetSqlTimeFormat(record.CheckDate)
                , record.CheckName, record.CreateID
                , record.CreateName, record.DeptInCharge
                , record.DeptStayed, record.DocID
                , record.DocTitle, record.DoctorInCharge
                , record.DocTypeID, record.DocTypeName
                , base.QCAccess.GetSqlTimeFormat(record.EndDate), record.EventID
                , record.PatientID, record.PatientName
                , record.Point, record.QcExplain
                , record.QcResult, record.RecNo
                , base.QCAccess.GetSqlTimeFormat(record.RecordTime), record.VisitID
                , record.EventName, base.QCAccess.GetSqlTimeFormat(record.EventTime)
                , record.MessageNotify ? "1" : "0"
                , base.QCAccess.GetSqlTimeFormat(record.DocTime)
                , record.IsVeto ? "1" : "0"
                , record.VISIT_NO
               );
            if (record.DischargeTime != SystemParam.Instance.DefaultTime)
            {
                szField = string.Format("{0},{1}"
                    , szField, SystemData.QcTimeRecordTable.DISCHARGE_TIME);
                szValue = string.Format("{0},{1}"
                    , szValue, base.QCAccess.GetSqlTimeFormat(record.DischargeTime));
            }
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_TIME_RECORD, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveQcTimeRecord", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }


        /// <summary>
        /// 删除质控时效质控记录
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteQcTimeRecord(string szPatientID, string szVisitID)
        {
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'"
                , SystemData.QcTimeRecordTable.PATIENT_ID, szPatientID
                , SystemData.QcTimeRecordTable.VISIT_ID, szVisitID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_TIME_RECORD, szCondition);

            int count = 0;
            try
            {
                count = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteQcTimeRecord", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }
        /// <summary>
        /// 保存时效质控记录
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short SavePatientQcTimeRecord(string szPatientID, string szVisitID, List<QcTimeRecord> lstQcTimeRecord)
        {
            if (string.IsNullOrEmpty(szPatientID) || string.IsNullOrEmpty(szVisitID))
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstQcTimeRecord == null || lstQcTimeRecord.Count <= 0)
                return SystemData.ReturnValue.OK;
            if (!base.QCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            short shRet = this.DeleteQcTimeRecord(szPatientID, szVisitID);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
                return shRet;

            foreach (QcTimeRecord item in lstQcTimeRecord)
            {
                try
                {
                    shRet = this.SaveQcTimeRecord(item);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        LogManager.Instance.WriteLog("DbAccess.SavePatientQcTimeRecord", "事物回滚" + item.PatientName + "时效生成失败");
                        base.QCAccess.AbortTransaction();
                        return SystemData.ReturnValue.EXCEPTION;
                    }
                }
                catch (Exception ex)
                {
                    base.QCAccess.AbortTransaction();
                    LogManager.Instance.WriteLog("DbAccess.SaveQcTimeRecord", ex);
                    return SystemData.ReturnValue.EXCEPTION;
                }
            }
            base.QCAccess.CommitTransaction(true);
            return SystemData.ReturnValue.OK;
        }

        #endregion

        #region 病案筛选
        /// <summary>
        /// 病历质控系统,获取在院病人
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPatsListByInHosptial(ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.QCAccess == null)
            {
                LogManager.Instance.WriteLog("TimeCheckGener.DbAccess.GetPatsListByInHosptial"
                    , "base.QCAccess == null ");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE);

            string szCondition = string.Format(" 1=1 ");
            string szTable = string.Format("{0} A", SystemData.DataView.INP_VISIT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition
                );
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
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
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("TimeCheckGener.DbAccess.GetPatsListByInHosptial", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.QCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 按出院日期查询出院患者列表
        /// </summary>
        /// <param name="lstPatVisitLogs">病区列表</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short GetPatsListByOutHosptial(DateTime dtDischargeBeginTime, DateTime dtDischargeEndTime, ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtDischargeBeginTime == SystemParam.Instance.DefaultTime
                || dtDischargeEndTime == SystemParam.Instance.DefaultTime)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.IDENTITY
                , SystemData.PatVisitView.NURSING_CLASS
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE);

            string szCondition = string.Format(" 1=1 ");
            szCondition = string.Format("{0} AND {1} >= {2} AND {1} <= {3}"
                , szCondition
                , SystemData.PatVisitView.DISCHARGE_TIME
                , base.QCAccess.GetSqlTimeFormat(dtDischargeBeginTime)
                , base.QCAccess.GetSqlTimeFormat(dtDischargeEndTime));
            string szOrderBy = string.Format("A.{0},A.{1}", SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.BED_CODE);
            string szTable = string.Format("{0} A", SystemData.DataView.PAT_VISIT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
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
                    if (!dataReader.IsDBNull(13)) patVisitLog.IDENTITY = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.NURSING_CLASS = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) patVisitLog.DISCHARGE_TIME = dataReader.GetDateTime(15);
                    if (!dataReader.IsDBNull(16)) patVisitLog.DISCHARGE_MODE = dataReader.GetString(16);
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
                base.QCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 按出院日期查询出院患者列表
        /// </summary>
        /// <param name="lstPatVisitLogs">病区列表</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short GetPatVisitLog(string szPatientID, string szVisitID, ref PatVisitInfo patVisitLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (szPatientID == string.Empty
                || szVisitID == string.Empty)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME
                , SystemData.PatVisitView.CHARGE_TYPE, SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.PATIENT_CONDITION, SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.DEPT_CODE, SystemData.PatVisitView.IDENTITY
                , SystemData.PatVisitView.NURSING_CLASS
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE);

            string szCondition = string.Format(" 1=1 ");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.PatVisitView.PATIENT_ID
                , szPatientID
                , SystemData.PatVisitView.VISIT_ID
                , szVisitID);
            string szTable = string.Format("{0} A", SystemData.DataView.PAT_VISIT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition
                );
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (patVisitLog == null)
                    patVisitLog = new PatVisitInfo();

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
                if (!dataReader.IsDBNull(13)) patVisitLog.IDENTITY = dataReader.GetString(13);
                if (!dataReader.IsDBNull(14)) patVisitLog.NURSING_CLASS = dataReader.GetString(14);
                if (!dataReader.IsDBNull(15)) patVisitLog.DISCHARGE_TIME = dataReader.GetDateTime(15);
                if (!dataReader.IsDBNull(16)) patVisitLog.DISCHARGE_MODE = dataReader.GetString(16);

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatVisitLog", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.QCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 保存时效性统计结果到个人
        /// </summary>
        /// <param name="dtTime"></param>
        /// <returns></returns>
        public short SaveTimeRecordStatByPatient(DateTime dtTime)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtTime == SystemParam.Instance.DefaultTime)
            {
                LogManager.Instance.WriteLog("DbAccess.SaveTimeRecordStatByPatient", "时效检查时间参数错误");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (!base.QCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            //删除详细到个人的时效统计，避免重复插入统计数据
            short shRet = this.DeleteTimeRecordStatByPatient(dtTime);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                base.QCAccess.AbortTransaction();
                return shRet;
            }
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.AppendFormat(" insert into  {0}", SystemData.DataTable.QC_TIMERECORD_STATBYPATIENT);
            sbSQL.AppendFormat(" select * from (select t.check_date,t.dept_in_charge as dept_code,t.dept_stayed as dept_name,t.patient_id,t.visit_id,t.patient_name,t.doc_title,t.doctype_id,case when t.qc_result =1 then '未书写' when t.qc_result =0 then '正常'  when t.qc_result = 2 then '书写提前' when t.qc_result =3 then '书写超时' when t.qc_result = 4 then  '正常未书写' end qc_result ,count(*) as count from QC_TIME_RECORD_T t");
            sbSQL.AppendFormat(" where t.check_date ={0}  And t.message_notify = 0 ", base.QCAccess.GetSqlTimeFormat(dtTime));
            sbSQL.Append(" group by t.check_date,t.dept_in_charge ,t.dept_stayed ,t.patient_id,t.visit_id,t.patient_name,t.doc_title,t.qc_result,t.doctype_id");
            sbSQL.Append(" order by t.dept_in_charge, t.patient_id,t.visit_id)  t");
            try
            {
                base.QCAccess.ExecuteNonQuery(sbSQL.ToString(), CommandType.Text);

                //提交数据库更新
                if (!base.QCAccess.CommitTransaction(true))
                    return SystemData.ReturnValue.EXCEPTION;

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QCAccess.SaveTimeRecordStatByPatient", new string[] { "SQL" }, new object[] { sbSQL.ToString() }, ex);
                base.QCAccess.AbortTransaction();
                return SystemData.ReturnValue.EXCEPTION;
            }
        }

        /// <summary>
        /// 避免重复插入，删除已统计的
        /// </summary>
        /// <param name="dtTime"></param>
        /// <returns></returns>
        private short DeleteTimeRecordStatByPatient(DateTime dtTime)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtTime == SystemParam.Instance.DefaultTime)
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteTimeRecordStatByPatient", "时效检查时间参数错误");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.AppendFormat("delete from {0} t where to_char(t.check_date,'yyyy-MM-dd') = '{1}'"
                , SystemData.DataTable.QC_TIMERECORD_STATBYPATIENT, dtTime.ToString("yyyy-MM-dd"));
            try
            {
                int count = base.QCAccess.ExecuteNonQuery(sbSQL.ToString(), CommandType.Text);
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QCAccess.DeleteTimeRecordStatByPatient", new string[] { "SQL" }, new object[] { sbSQL.ToString() }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
        }
        #endregion

        #region 统计到科室
        

        public short SaveTimeRecordStatByDept(DateTime now)
        {

            List<QcTimeRecordStatByDept> lstQcTimeRecordStatByDept = new List<QcTimeRecordStatByDept>();
            short shRet = this.GetTimeRecordStatByDeptList(now, lstQcTimeRecordStatByDept);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("获取统计到科室的时效问题数量失败！");
                return shRet;

            }
            //统计科室在院人数
            shRet = this.LoadDeptPatientCount(lstQcTimeRecordStatByDept);
            //统计未完成病历涉及的患者数
            shRet = this.LoadUnDoPatientCount(now, lstQcTimeRecordStatByDept);
            //删掉已经统计好的数据
            shRet = this.DeleteTimeRecordStatByDepts(now);
            //保存统计到科室的结果
            shRet = this.SaveStatByDeptList(lstQcTimeRecordStatByDept);

            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 保存统计到科室的结果
        /// </summary>
        /// <param name="lstQcTimeRecordStatByDept"></param>
        /// <returns></returns>
        private short SaveStatByDeptList(List<QcTimeRecordStatByDept> lstQcTimeRecordStatByDept)
        {
            short shRet = SystemData.ReturnValue.OK;
            foreach (QcTimeRecordStatByDept item in lstQcTimeRecordStatByDept)
            {
                shRet = this.AddTimeRecordStatByDept(item);
                if (shRet != SystemData.ReturnValue.OK)
                    return shRet;
            }
            return shRet;
        }

        private short AddTimeRecordStatByDept(QcTimeRecordStatByDept item)
        {
            if (base.QCAccess == null)
            {
                LogManager.Instance.WriteLog("AddTimeRecordStatByDept base.QCAccess == null");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}"
               , SystemData.QcTimeRecordStatByDeptTable.CHECK_DATE
               , SystemData.QcTimeRecordStatByDeptTable.DEPT_CODE
               , SystemData.QcTimeRecordStatByDeptTable.DEPT_NAME
               , SystemData.QcTimeRecordStatByDeptTable.DEPTPATIENTCOUNT
               , SystemData.QcTimeRecordStatByDeptTable.DOC_TITLE
               , SystemData.QcTimeRecordStatByDeptTable.EARLY
               , SystemData.QcTimeRecordStatByDeptTable.NEEDCOUNT
               , SystemData.QcTimeRecordStatByDeptTable.NORMAL
               , SystemData.QcTimeRecordStatByDeptTable.TIMEOUT
               , SystemData.QcTimeRecordStatByDeptTable.UNDOPATIENTCOUNT
               , SystemData.QcTimeRecordStatByDeptTable.UNWRITE
               , SystemData.QcTimeRecordStatByDeptTable.UNWRITE_NORMAL);

            string szValue = string.Format("{0},'{1}','{2}',{3},'{4}',{5},{6},{7},{8},{9},{10},{11}"
                , base.QCAccess.GetSqlTimeFormat(item.CheckDate), item.DeptCode
                , item.DeptName, item.DeptPatientCount
                , item.DocTitle, item.Early
                , item.NeedCount, item.Normal
                , item.TimeOut, item.UnDoPatientCount
                , item.UnWrite
                , item.UnWriteNormal
               );

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_TIMERECORD_STATBYDEPT, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.AddTimeRecordStatByDept", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        private short DeleteTimeRecordStatByDepts(DateTime now)
        {
            if (base.QCAccess == null)
            {
                LogManager.Instance.WriteLog("DeleteTimeRecordStatByDepts base.QCAccess == null");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szCondition = string.Format(" to_char(check_date,'yyyy-MM-dd') = '{0}'"
              , now.ToString("yyyy-MM-dd"));
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_TIMERECORD_STATBYDEPT, szCondition);

            int count = 0;
            try
            {
                count = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
                //LogManager.Instance.WriteLog(string.Format("SQL:{0} Count:{1}", szSQL, count.ToString()),null,LogType.Information);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.DeleteTimeRecordStatByDepts", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }

        private short LoadUnDoPatientCount(DateTime now, List<QcTimeRecordStatByDept> lstQcTimeRecordStatByDept)
        {
            if (lstQcTimeRecordStatByDept == null || lstQcTimeRecordStatByDept.Count <= 0)
                return SystemData.ReturnValue.OK;
            string szDeptCode = string.Empty;
            short shRet = SystemData.ReturnValue.OK;
            Dictionary<string, int> dicDeptPatientCount = new Dictionary<string, int>();
            shRet = this.GetUnDoPatientCount(now, ref dicDeptPatientCount);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                LogManager.Instance.WriteLog("获取未完成病历涉及的患者数失败！");
                return shRet;
            }
            if (dicDeptPatientCount == null ||
                dicDeptPatientCount.Count <= 0)
                return SystemData.ReturnValue.OK;
            foreach (QcTimeRecordStatByDept item in lstQcTimeRecordStatByDept)
            {
                if (dicDeptPatientCount.ContainsKey(item.DeptCode))
                    item.UnDoPatientCount = dicDeptPatientCount[item.DeptCode];
            }

            return shRet;
        }

        private short LoadDeptPatientCount(List<QcTimeRecordStatByDept> lstQcTimeRecordStatByDept)
        {
            if (lstQcTimeRecordStatByDept == null || lstQcTimeRecordStatByDept.Count <= 0)
                return SystemData.ReturnValue.OK;
            string szDeptCode = string.Empty;
            short shRet = SystemData.ReturnValue.OK;
            Dictionary<string, int> dicDeptPatientCount = new Dictionary<string, int>();
            shRet = this.GetDeptPatientCount(ref dicDeptPatientCount);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("获取科室病人数量失败");
                return shRet;
            }
            foreach (QcTimeRecordStatByDept item in lstQcTimeRecordStatByDept)
            {
                if (dicDeptPatientCount.ContainsKey(item.DeptCode))
                    item.DeptPatientCount = dicDeptPatientCount[item.DeptCode];
            }
            return shRet;
        }
        /// <summary>
        /// 获取未完成病历涉及的患者数
        /// </summary>
        /// <param name="nDeptPatientCount"></param>
        /// <param name="szDeptCode"></param>
        /// <returns></returns>
        private short GetUnDoPatientCount(DateTime now, ref Dictionary<string, int> dicDeptPatientCount)
        {
            if (base.QCAccess == null)
            {
                LogManager.Instance.WriteLog(" base.QCAccess == null");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.AppendFormat(" select t1.dept_in_charge,count(patient_id) from(select distinct  t.dept_in_charge,  t.patient_id from qc_time_record_t t where t.check_date = {0} and t.qc_result = 4 order by t.dept_in_charge )t1 group by t1.dept_in_charge order by t1.dept_in_charge"
                , base.QCAccess.GetSqlTimeFormat(now));
            IDataReader dataReader = null;

            try
            {
                dataReader = base.QCAccess.ExecuteReader(sbSQL.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (dicDeptPatientCount == null)
                    dicDeptPatientCount = new Dictionary<string, int>();
                do
                {
                    string szKeyname = string.Empty;
                    int nPatientCount = 0;
                    if (!dataReader.IsDBNull(0)) szKeyname = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) nPatientCount = int.Parse(dataReader.GetValue(1).ToString());
                    if (szKeyname != string.Empty && !dicDeptPatientCount.ContainsKey(szKeyname))
                    {
                        dicDeptPatientCount.Add(szKeyname, nPatientCount);
                    }
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QCAccess.GetUnDoPatientCount", new string[] { "szSQL" }, new object[] { sbSQL.ToString() }, ex);
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
                base.QCAccess.CloseConnnection(false);
            }

        }

        /// <summary>
        /// 获取当前在院的科室病人数量
        /// </summary>
        /// <param name="nDeptPatientCount"></param>
        /// <param name="szDeptCode"></param>
        /// <returns></returns>
        private short GetDeptPatientCount(ref Dictionary<string, int> dicDeptPatientCount)
        {
            if (base.QCAccess == null)
            {
                LogManager.Instance.WriteLog(" base.QCAccess == null");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" select v.DEPT_CODE, count(v.PATIENT_ID) as deptPatientCount from inp_visit_v v group by v.DEPT_CODE");
            IDataReader dataReader = null;

            try
            {
                dataReader = base.QCAccess.ExecuteReader(sbSQL.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (dicDeptPatientCount == null)
                    dicDeptPatientCount = new Dictionary<string, int>();
                do
                {
                    string szDeptCode = string.Empty;
                    int nDeptPatientCount = 0;
                    if (!dataReader.IsDBNull(0)) szDeptCode = dataReader.GetString(0);

                    if (!dataReader.IsDBNull(1)) nDeptPatientCount = int.Parse(dataReader.GetValue(1).ToString());
                    if (szDeptCode != string.Empty && !dicDeptPatientCount.ContainsKey(szDeptCode))
                    {
                        dicDeptPatientCount.Add(szDeptCode, nDeptPatientCount);
                    }
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QCAccess.GetDeptPatientCount", new string[] { "szSQL" }, new object[] { sbSQL.ToString() }, ex);
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
                base.QCAccess.CloseConnnection(false);
            }

        }

        private short GetTimeRecordStatByDeptList(DateTime dtCheckDate, List<QcTimeRecordStatByDept> lstQcTimeRecordStatByDept)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstQcTimeRecordStatByDept == null)
            {
                lstQcTimeRecordStatByDept = new List<QcTimeRecordStatByDept>();
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select t1.{0},t1.{1},t1.{2}, t1.{3},"
                , SystemData.QcTimeRecordStatByDeptTable.CHECK_DATE
                , SystemData.QcTimeRecordStatByDeptTable.DEPT_CODE
                , SystemData.QcTimeRecordStatByDeptTable.DEPT_NAME
                , SystemData.QcTimeRecordStatByDeptTable.DOC_TITLE);
            sb.AppendFormat(" sum(decode(qc_result,0, count,0)) {0} ,sum(decode(qc_result,1, count,0)) {1} , sum(decode(qc_result,2, count,0)) {2}, sum(decode(qc_result,3, count,0)) {3}, sum(decode(qc_result,4, count,0)) {4}, sum(count) as {5} "
                , SystemData.QcTimeRecordStatByDeptTable.NORMAL
                , SystemData.QcTimeRecordStatByDeptTable.UNWRITE
                , SystemData.QcTimeRecordStatByDeptTable.EARLY
                , SystemData.QcTimeRecordStatByDeptTable.TIMEOUT
                , SystemData.QcTimeRecordStatByDeptTable.UNWRITE_NORMAL
                , SystemData.QcTimeRecordStatByDeptTable.NEEDCOUNT);
            sb.AppendFormat(" from (select t.check_date, t.dept_in_charge as dept_code,t.dept_stayed as dept_name,doc_title , t.qc_result,count(t.patient_id) as count,t.patient_id,t.visit_id,t.patient_name from qc_time_record_t t where t.check_date ={0} group by t.check_date,t.dept_in_charge,t.dept_stayed,t.doc_title,t.qc_result,t.patient_id,t.visit_id,t.patient_name order by t.dept_in_charge) t1 group by  t1.check_date, t1.dept_code,t1.dept_name,t1.doc_title order by t1.dept_code "
                , base.QCAccess.GetSqlTimeFormat(dtCheckDate));
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(sb.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcTimeRecordStatByDept == null)
                    lstQcTimeRecordStatByDept = new List<QcTimeRecordStatByDept>();
                do
                {
                    QcTimeRecordStatByDept qcTimeRecordStatByDept = new QcTimeRecordStatByDept();
                    if (!dataReader.IsDBNull(0)) qcTimeRecordStatByDept.CheckDate = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) qcTimeRecordStatByDept.DeptCode = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcTimeRecordStatByDept.DeptName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcTimeRecordStatByDept.DocTitle = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) qcTimeRecordStatByDept.Normal = int.Parse(dataReader.GetValue(4).ToString());
                    if (!dataReader.IsDBNull(5)) qcTimeRecordStatByDept.UnWrite = int.Parse(dataReader.GetValue(5).ToString());
                    if (!dataReader.IsDBNull(6)) qcTimeRecordStatByDept.Early = int.Parse(dataReader.GetValue(6).ToString());
                    if (!dataReader.IsDBNull(7)) qcTimeRecordStatByDept.TimeOut = int.Parse(dataReader.GetValue(7).ToString());
                    if (!dataReader.IsDBNull(8)) qcTimeRecordStatByDept.UnWriteNormal = int.Parse(dataReader.GetValue(8).ToString());
                    if (!dataReader.IsDBNull(9)) qcTimeRecordStatByDept.NeedCount = int.Parse(dataReader.GetValue(9).ToString());
                    lstQcTimeRecordStatByDept.Add(qcTimeRecordStatByDept);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatsListByInHosptial", new string[] { "szSQL" }, new object[] { sb.ToString() }, ex);
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
                base.QCAccess.CloseConnnection(false);
            }
            return SystemData.ReturnValue.OK;
        }
        #endregion



        #endregion
        #region 时效质控记录操作
        /// <summary>
        /// 时效质控记录表查询
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcTimeRecords(DateTime dtBeginTime, DateTime dtEndTime, string szTimeType, string szQcResult
            , string szDeptCode, ref List<QcTimeRecord> lstQcTimeRecords)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24}"
                , SystemData.QcTimeRecordTable.BEGIN_DATE
                , SystemData.QcTimeRecordTable.CHECK_DATE
                , SystemData.QcTimeRecordTable.CHECKER_NAME
                , SystemData.QcTimeRecordTable.CREATE_ID
                , SystemData.QcTimeRecordTable.CREATE_NAME
                , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
                , SystemData.QcTimeRecordTable.DEPT_STAYED
                , SystemData.QcTimeRecordTable.DOC_ID
                , SystemData.QcTimeRecordTable.DOC_TITLE
                , SystemData.QcTimeRecordTable.DOCTOR_IN_CHARGE
                , SystemData.QcTimeRecordTable.DOCTYPE_ID
                , SystemData.QcTimeRecordTable.DOCTYPE_NAME
                , SystemData.QcTimeRecordTable.END_DATE
                , SystemData.QcTimeRecordTable.EVENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_ID
                , SystemData.QcTimeRecordTable.PATIENT_NAME
                , SystemData.QcTimeRecordTable.POINT
                , SystemData.QcTimeRecordTable.QC_EXPLAIN
                , SystemData.QcTimeRecordTable.QC_RESULT
                , SystemData.QcTimeRecordTable.REC_NO
                , SystemData.QcTimeRecordTable.RECORD_TIME
                , SystemData.QcTimeRecordTable.VISIT_ID
                , SystemData.QcTimeRecordTable.EVENT_NAME
                , SystemData.QcTimeRecordTable.EVENT_TIME
                , SystemData.QcTimeRecordTable.DOC_TIME);

            string szCondition = String.Format("1=1");
            if (!string.IsNullOrEmpty(szTimeType))
            {
                szCondition = string.Format("{0} AND {1} >= {2} AND {1} <={3}"
                  , szCondition
                  , szTimeType
                  , base.QCAccess.GetSqlTimeFormat(dtBeginTime)
                  , base.QCAccess.GetSqlTimeFormat(dtEndTime)
                  );

            }
            else
                szCondition = string.Format("{0} AND {1} >= {2} AND {1} <={3}"
                    , szCondition
                    , SystemData.QcTimeRecordTable.CHECK_DATE
                    , base.QCAccess.GetSqlTimeFormat(dtBeginTime)
                    , base.QCAccess.GetSqlTimeFormat(dtEndTime)
                    );
            if (!GlobalMethods.Misc.IsEmptyString(szQcResult))
            {
                szCondition = string.Format("{0} AND {1} in({2})"
                    , szCondition
                    , SystemData.QcTimeRecordTable.QC_RESULT
                    , szQcResult
                );
            }
            if (!GlobalMethods.Misc.IsEmptyString(szDeptCode))
            {
                szCondition = string.Format("{0} AND {1} = '{2}' "
                    , szCondition
                    , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE
                    , szDeptCode
                );
            }
            string szOrderBy = string.Format("{0},{1},{2}"
                , SystemData.QcTimeRecordTable.DEPT_IN_CHARGE, SystemData.QcTimeRecordTable.PATIENT_ID
                , SystemData.QcTimeRecordTable.VISIT_ID);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataTable.QC_TIME_RECORD, szCondition, szOrderBy);



            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcTimeRecords == null)
                    lstQcTimeRecords = new List<QcTimeRecord>();
                do
                {
                    QcTimeRecord record = new QcTimeRecord();
                    if (!dataReader.IsDBNull(0)) record.BeginDate = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) record.CheckDate = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) record.CheckName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) record.CreateID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) record.CreateName = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) record.DeptInCharge = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) record.DeptStayed = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) record.DocID = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) record.DocTitle = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) record.DoctorInCharge = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) record.DocTypeID = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) record.DocTypeName = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) record.EndDate = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) record.EventID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) record.PatientID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) record.PatientName = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) record.Point = float.Parse(dataReader.GetValue(16).ToString());
                    if (!dataReader.IsDBNull(17)) record.QcExplain = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) record.QcResult = dataReader.GetValue(18).ToString();
                    if (!dataReader.IsDBNull(19)) record.RecNo = dataReader.GetValue(19).ToString();
                    if (!dataReader.IsDBNull(20)) record.RecordTime = dataReader.GetDateTime(20);
                    if (!dataReader.IsDBNull(21)) record.VisitID = dataReader.GetString(21);
                    if (!dataReader.IsDBNull(22)) record.EventName = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) record.EventTime = dataReader.GetDateTime(23);
                    if (!dataReader.IsDBNull(24)) record.DocTime = dataReader.GetDateTime(24);
                    lstQcTimeRecords.Add(record);

                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetQcTimeRecords", new string[] { "szGroupName", "szConfigName", "SQL" }
                        , new object[] { szSQL }, "没有查询到记录!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        #endregion

        #region 时效记录统计到科室
        /// <summary>
        /// 统计当日合格率，由于科室问题病人数分文档类型，所以每个科室取最大数
        /// </summary>
        /// <param name="dtCheckDate"></param>
        /// <param name="lstQcTimeRecordStatByDept"></param>
        /// <returns></returns>
        public short GetTimeRecordStatByDeptList(DateTime dtCheckDate, ref List<QcTimeRecordStatByDept> lstQcTimeRecordStatByDept)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstQcTimeRecordStatByDept == null)
            {
                lstQcTimeRecordStatByDept = new List<QcTimeRecordStatByDept>();
            }
            if (lstQcTimeRecordStatByDept.Count > 0)
                lstQcTimeRecordStatByDept.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select check_date,dept_code, dept_name, undo_patient_count, dept_patient_count ");
            sb.AppendFormat(" from (select t.check_date, t.dept_code, ");
            sb.AppendFormat(" t.dept_name,");
            sb.AppendFormat(" t.doc_title,");
            sb.AppendFormat(" t.undo_patient_count,");
            sb.AppendFormat(" t.dept_patient_count,");
            sb.AppendFormat(" row_number() over(partition by t.dept_code order by t.dept_code, t.undo_patient_count desc) rn");
            sb.AppendFormat(" from qc_timerecord_statbydept_t t");
            sb.AppendFormat(" where to_char(t.check_date, 'yyyy/MM/dd') = '{0}')  where rn <= 1 "
                    , dtCheckDate.ToString("yyyy/MM/dd"));
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(sb.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcTimeRecordStatByDept == null)
                    lstQcTimeRecordStatByDept = new List<QcTimeRecordStatByDept>();
                do
                {
                    QcTimeRecordStatByDept qcTimeRecordStatByDept = new QcTimeRecordStatByDept();
                    if (!dataReader.IsDBNull(0)) qcTimeRecordStatByDept.CheckDate = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1)) qcTimeRecordStatByDept.DeptCode = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcTimeRecordStatByDept.DeptName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcTimeRecordStatByDept.UnDoPatientCount = int.Parse(dataReader.GetValue(3).ToString());
                    if (!dataReader.IsDBNull(4)) qcTimeRecordStatByDept.DeptPatientCount = int.Parse(dataReader.GetValue(4).ToString());
                    lstQcTimeRecordStatByDept.Add(qcTimeRecordStatByDept);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetTimeRecordStatByDeptList", new string[] { "szSQL" }, new object[] { sb.ToString() }, ex);
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
                base.QCAccess.CloseConnnection(false);
            }

        }
        #endregion
    }
}