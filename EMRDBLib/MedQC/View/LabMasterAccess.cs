using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 方法只支持新系统
    /// </summary>
    public class LabMasterAccess : DBAccessBase
    {
        private static LabMasterAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static LabMasterAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new LabMasterAccess();
                return LabMasterAccess.m_Instance;
            }
        } /// <summary>
          /// 根据病人ID和就诊号，获取该次住院的检验信息列表
          /// </summary>
          /// <param name="szPatientID">病人编号</param>
          /// <param name="nVisitID">就诊号</param>
          /// <param name="lstLabTestInfo">检验信息列表</param>
          /// <returns>SystemData.ReturnValue</returns>
        public short GetList(string szPatientID, string szVisitID, ref List<LabMaster> lstLabTestInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetInpLabTestList", "查询参数为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (lstLabTestInfo == null)
                lstLabTestInfo = new List<LabMaster>();
            else
                lstLabTestInfo.Clear();

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
                , SystemData.LabMasterView.TEST_ID, SystemData.LabMasterView.SUBJECT
                , SystemData.LabMasterView.SPECIMEN, SystemData.LabMasterView.REQUEST_TIME
                , SystemData.LabMasterView.REQUEST_DOCTOR, SystemData.LabMasterView.RESULT_STATUS
                , SystemData.LabMasterView.REPORT_TIME, SystemData.LabMasterView.REPORT_DOCTOR);
            string szTable = SystemData.DataView.LAB_MASTER;
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'"
                , SystemData.LabMasterView.PATIENT_ID, szPatientID, SystemData.LabMasterView.VISIT_ID, szVisitID);
            string szOrderField = SystemData.LabMasterView.REQUEST_TIME;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderField);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                do
                {
                    LabMaster labTestInfo = new LabMaster();
                    if (!dataReader.IsDBNull(0)) labTestInfo.TEST_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) labTestInfo.SUBJECT = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) labTestInfo.SPECIMEN = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) labTestInfo.REQUEST_TIME = dataReader.GetDateTime(3);
                    if (!dataReader.IsDBNull(4)) labTestInfo.REQUEST_DOCTOR = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) labTestInfo.RESULT_STATUS = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) labTestInfo.REPORT_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) labTestInfo.REPORT_DOCTOR = dataReader.GetString(7);
                    lstLabTestInfo.Add(labTestInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "查询检验信息时出现异常!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
    }
}
