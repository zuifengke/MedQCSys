using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class MedicalQcLogAccess : DBAccessBase
    {
        private static MedicalQcLogAccess m_instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static MedicalQcLogAccess Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new MedicalQcLogAccess();
                return m_instance;
            }
        }

        /// <summary>
        /// 获取某份病历的最新质控记录
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCLogInfo(string szDocSetID, int nLogType, ref MedicalQcLog qcActionLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3}"
                , SystemData.MedicalQCLogTable.DOC_SETID
                , SystemData.MedicalQCLogTable.CHECK_DATE
                , SystemData.MedicalQCLogTable.CHECKED_ID
                , SystemData.MedicalQCLogTable.CHECKED_BY);
            string szCondition = string.Format("{0} ='{1}' AND {2}={3}"
                , SystemData.MedicalQCLogTable.DOC_SETID, szDocSetID
                , SystemData.MedicalQCLogTable.LOG_TYPE, nLogType);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_DESC, szField, SystemData.DataTable.MEDICAL_QC_LOG, szCondition
                , SystemData.MedicalQCLogTable.CHECK_DATE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (qcActionLog == null)
                    qcActionLog = new MedicalQcLog();
                if (!dataReader.IsDBNull(0))
                    qcActionLog.DOC_SETID = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1))
                    qcActionLog.CHECK_DATE = dataReader.GetDateTime(1);
                if (!dataReader.IsDBNull(2))
                    qcActionLog.CHECKED_ID = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    qcActionLog.CHECKED_BY = dataReader.GetString(3);


                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetQCActionLogInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 根据病人ID和就诊号获取病历最近一次被操作的相关信息
        /// </summary>
        ///<param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊号</param>
        /// <param name="nLogType">日志类型</param>
        /// <param name="nOperateType">病历操作类型</param>
        /// <param name="lstEmrLogs">病历读写日志信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCLogInfo(string szPatientID, string szVisitID, int nLogType, int nOperateType, ref List<MedicalQcLog> lstQcLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},MAX({1})"
                , SystemData.MedicalQCLogTable.DOC_SETID, SystemData.MedicalQCLogTable.CHECK_DATE);
            string szCondition = string.Format("{0} ='{1}' AND {2}='{3}' AND {4}={5} AND {6}={7}"
                , SystemData.MedicalQCLogTable.PATIENT_ID, szPatientID
                , SystemData.MedicalQCLogTable.VISIT_ID, szVisitID
                , SystemData.MedicalQCLogTable.LOG_TYPE, nLogType
                , SystemData.MedicalQCLogTable.CHECK_TYPE, nOperateType);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM_WHERE_GROUP, szField, SystemData.DataTable.MEDICAL_QC_LOG, szCondition
                , SystemData.MedicalQCLogTable.DOC_SETID);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcLog == null)
                    lstQcLog = new List<MedicalQcLog>();
                do
                {
                    MedicalQcLog qcLog = new MedicalQcLog();
                    if (!dataReader.IsDBNull(0))
                        qcLog.DOC_SETID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        qcLog.CHECK_DATE = dataReader.GetDateTime(1);
                    lstQcLog.Add(qcLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetQCLogInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }

        #region"质控操作日志访问接口"
        /// <summary>
        ///  病历质控系统,保存一条病案质量监控日志
        /// </summary>
        /// <param name="qcActionLog">病案质量监控日志</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(MedicalQcLog qcActionLog)
        {
            if (qcActionLog == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "timeQCRule" }
                    , new object[] { qcActionLog }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}"
                , SystemData.MedicalQCLogTable.CHECKED_BY
                , SystemData.MedicalQCLogTable.CHECKED_ID
                , SystemData.MedicalQCLogTable.CHECK_DATE
                , SystemData.MedicalQCLogTable.CHECK_TYPE
                , SystemData.MedicalQCLogTable.DEPT_CODE
                , SystemData.MedicalQCLogTable.DEPT_NAME
                , SystemData.MedicalQCLogTable.DEPT_STAYED
                , SystemData.MedicalQCLogTable.DOC_SETID
                , SystemData.MedicalQCLogTable.LOG_DESC
                , SystemData.MedicalQCLogTable.LOG_TYPE
                , SystemData.MedicalQCLogTable.PATIENT_ID
                , SystemData.MedicalQCLogTable.VISIT_ID
                , SystemData.MedicalQCLogTable.QC_MSG_CODE);

            string szValue = string.Format("'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}'"
                , qcActionLog.CHECKED_BY
                , qcActionLog.CHECKED_ID
                , base.QCAccess.GetSqlTimeFormat(qcActionLog.CHECK_DATE)
                , qcActionLog.CHECK_TYPE
                , qcActionLog.DEPT_CODE
                , qcActionLog.DEPT_NAME
                , qcActionLog.DEPT_STAYED
                , qcActionLog.DOC_SETID
                , qcActionLog.LOG_DESC
                , qcActionLog.LOG_TYPE
                , qcActionLog.PATIENT_ID
                , qcActionLog.VISIT_ID
                , qcActionLog.QC_MSG_CODE);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.MEDICAL_QC_LOG, szField, szValue);
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

        #endregion
    }
}
