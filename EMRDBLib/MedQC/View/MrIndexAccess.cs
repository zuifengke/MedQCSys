using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class MrIndexAccess : DBAccessBase
    {
        private static MrIndexAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static MrIndexAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new MrIndexAccess();
                return MrIndexAccess.m_Instance;
            }
        }

        public short UpdateMrStatus(MrIndex mrIndex)
        {
            string szDoctorID = string.Empty;
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            DbParameter[] pmi = new DbParameter[5];
            pmi[0] = new DbParameter("patientID", mrIndex.PATIENT_ID);
            pmi[1] = new DbParameter("visitNO", mrIndex.VISIT_NO);
            pmi[2] = new DbParameter("visitID", mrIndex.VISIT_ID);
            pmi[3] = new DbParameter("mrStatus", mrIndex.MR_STATUS);
            pmi[4] = new DbParameter("rcount", 0, ParameterDirection.Output);
            int nResult = 0;
            int rcount = 0;
            try
            {
                nResult = base.QCAccess.ExecuteNonQuery("UPDATE_MR_INDEX", CommandType.StoredProcedure, ref pmi);
                rcount = int.Parse(pmi[4].Value.ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
            return rcount <= 0 ? SystemData.ReturnValue.OTHER_ERROR : SystemData.ReturnValue.OK;
        }
        public short GetMrIndex(string szPatientID, string szVisitID, ref MrIndex mrIndex)
        {
            IDataReader dataReader = null;
            string szField = string.Format("{0},{1},{2},{3},{4},{5}"
                , SystemData.MrIndexView.MR_CLASS
                , SystemData.MrIndexView.MR_STATUS
                , SystemData.MrIndexView.PATIENT_ID
                , SystemData.MrIndexView.SUBMIT_DOCTOR_ID
                , SystemData.MrIndexView.VISIT_ID
                , SystemData.MrIndexView.VISIT_NO);
            string szCondition = string.Format("1=1 AND {0}='{1}' AND {2}='{3}'"
                , SystemData.MrIndexView.PATIENT_ID,szPatientID
                , SystemData.MrIndexView.VISIT_ID,szVisitID
                );
            string szTable = SystemData.DataView.MR_INDEX_V;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (mrIndex == null)
                    mrIndex = new MrIndex();
                if (!dataReader.IsDBNull(0)) mrIndex.MR_CLASS = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1)) mrIndex.MR_STATUS = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2)) mrIndex.PATIENT_ID = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3)) mrIndex.SUBMIT_DOCTOR_ID = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4)) mrIndex.VISIT_ID = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5)) mrIndex.VISIT_NO = dataReader.GetString(5);

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "SQL" }
                        , new object[] { szSQL }, "查询失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        public short GetMrIndexList(string szDeptCode, ref DeptDict deptDict)
        {

            return SystemData.ReturnValue.OK;
        }
       
    }
}
