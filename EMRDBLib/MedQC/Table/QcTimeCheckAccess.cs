// ***********************************************************
// 数据库访问层与病历时效实时检查扣分数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class QcTimeCheckAccess : DBAccessBase
    {
        private static QcTimeCheckAccess m_Instance = null;
        public static QcTimeCheckAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcTimeCheckAccess();
                return m_Instance;
            }
        }

        /// <summary>
        /// 获取病例时效检查扣分信息
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <param name="szEventID">事件ID</param>
        /// <param name="szDocTypeID">病历类型ID</param>
        /// <param name="startTime">病历书写起始时间</param>
        /// <param name="endTime">病历书写截止时间</param>
        /// <param name="qcTimeCheckInfo">病例时效检查扣分信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcTimeCheckInfo(string szPatientID, string szVisitID, string szEventID, string szDocTypeID
            , DateTime startTime, DateTime endTime, ref EMRDBLib.QCTimeCheck timeCheckInfo)
        {

            string szField = string.Format("{0},{1},{2}", SystemData.QcTimeCheckTable.POINT, SystemData.QcTimeCheckTable.CHECKER_NAME
                , SystemData.QcTimeCheckTable.CHECK_DATE);
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}={9} AND {10}={11}"
                , SystemData.QcTimeCheckTable.PATIENT_ID, szPatientID, SystemData.QcTimeCheckTable.VISIT_ID, szVisitID
                , SystemData.QcTimeCheckTable.EVENT_ID, szEventID, SystemData.QcTimeCheckTable.DOCTYPE_ID, szDocTypeID
                , SystemData.QcTimeCheckTable.BEGIN_DATE, base.MedQCAccess.GetSqlTimeFormat(startTime), SystemData.QcTimeCheckTable.END_DATE
                , base.MedQCAccess.GetSqlTimeFormat(endTime));
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataTable.QC_TIME_CHECK, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (timeCheckInfo == null)
                    timeCheckInfo = new QCTimeCheck();
                if (!dataReader.IsDBNull(0)) timeCheckInfo.Point = dataReader.GetValue(0).ToString();
                if (!dataReader.IsDBNull(1)) timeCheckInfo.CheckerName = dataReader.GetString(1).ToString();
                if (!dataReader.IsDBNull(2)) timeCheckInfo.CheckTime = dataReader.GetDateTime(2);
                timeCheckInfo.PatientID = szPatientID;
                timeCheckInfo.VisitID = szVisitID;
                timeCheckInfo.EventID = szEventID;
                timeCheckInfo.DocTypeID = szDocTypeID;
                timeCheckInfo.BeginTime = startTime;
                timeCheckInfo.EndTime = endTime;
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQcTimeCheckInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 更新病历时效扣分信息
        /// </summary>
        /// <param name="qcTimeCheckInfo">病历时效扣分信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateQCTimeCheck(QCTimeCheck qcTimeCheckInfo)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}={1},{2}='{3}',{4}={5}", SystemData.QcTimeCheckTable.POINT, qcTimeCheckInfo.Point
                , SystemData.QcTimeCheckTable.CHECKER_NAME, qcTimeCheckInfo.CheckerName, SystemData.QcTimeCheckTable.CHECK_DATE
                , base.MedQCAccess.GetSqlTimeFormat(qcTimeCheckInfo.CheckTime));
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}' AND {6}='{7}' AND {8}={9} AND {10}={11}"
                , SystemData.QcTimeCheckTable.PATIENT_ID, qcTimeCheckInfo.PatientID, SystemData.QcTimeCheckTable.VISIT_ID, qcTimeCheckInfo.VisitID
                , SystemData.QcTimeCheckTable.EVENT_ID, qcTimeCheckInfo.EventID, SystemData.QcTimeCheckTable.DOCTYPE_ID, qcTimeCheckInfo.DocTypeID
                , SystemData.QcTimeCheckTable.BEGIN_DATE, base.MedQCAccess.GetSqlTimeFormat(qcTimeCheckInfo.BeginTime), SystemData.QcTimeCheckTable.END_DATE
                , base.MedQCAccess.GetSqlTimeFormat(qcTimeCheckInfo.EndTime));
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_TIME_CHECK, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.UpdateQCTimeCheck", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("MedQCAccess.UpdateQCTimeCheck", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// 病历质控系统,保存病历时效扣分信息
        /// </summary>
        /// <param name="qcTimeCheckInfo">病历时效扣分信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveQCTimeCheck(QCTimeCheck qcTimeCheckInfo)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", SystemData.QcTimeCheckTable.PATIENT_ID
                , SystemData.QcTimeCheckTable.VISIT_ID, SystemData.QcTimeCheckTable.EVENT_ID, SystemData.QcTimeCheckTable.DOCTYPE_ID
                , SystemData.QcTimeCheckTable.BEGIN_DATE, SystemData.QcTimeCheckTable.END_DATE, SystemData.QcTimeCheckTable.POINT
                , SystemData.QcTimeCheckTable.CHECKER_NAME, SystemData.QcTimeCheckTable.CHECK_DATE);
            string szValue = string.Format("'{0}','{1}','{2}','{3}',{4},{5},{6},'{7}',{8}", qcTimeCheckInfo.PatientID, qcTimeCheckInfo.VisitID
                , qcTimeCheckInfo.EventID, qcTimeCheckInfo.DocTypeID, base.MedQCAccess.GetSqlTimeFormat(qcTimeCheckInfo.BeginTime)
                , base.MedQCAccess.GetSqlTimeFormat(qcTimeCheckInfo.EndTime), qcTimeCheckInfo.Point, qcTimeCheckInfo.CheckerName
                , base.MedQCAccess.GetSqlTimeFormat(qcTimeCheckInfo.CheckTime)
                );
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_TIME_CHECK, szField, szValue);
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.SaveQCTimeCheck", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("MedQCAccess.SaveQCTimeCheck", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

    }
}
