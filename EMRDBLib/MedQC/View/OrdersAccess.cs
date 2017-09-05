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
    public class OrdersAccess : DBAccessBase
    {
        private static OrdersAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static OrdersAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new OrdersAccess();
                return OrdersAccess.m_Instance;
            }
        }
        /// <summary>
        /// 根据指定的就诊信息，获取该次就诊时，产生的医嘱数据列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="nOrderFlag">医嘱标识(0-医生下达的医嘱 1-护士转抄的医嘱)</param>
        /// <param name="lstOrderInfo">医嘱信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetInpOrderList(string szPatientID, string szVisitID, string szOrderText, int nOrderFlag, ref List<MedOrderInfo> lstOrderInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetInpOrderList", "查询参数为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (lstOrderInfo == null)
                lstOrderInfo = new List<MedOrderInfo>();
            else
                lstOrderInfo.Clear();

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}"
                , SystemData.OrdersView.ORDER_NO, SystemData.OrdersView.ORDER_SUB_NO
                , SystemData.OrdersView.REPEAT_INDICATOR, SystemData.OrdersView.ORDER_CLASS
                , SystemData.OrdersView.ENTER_DATE_TIME, SystemData.OrdersView.ORDER_TEXT
                , SystemData.OrdersView.DRUG_BILLING_ATTR, SystemData.OrdersView.DOSAGE
                , SystemData.OrdersView.DOSAGE_UNITS, SystemData.OrdersView.ADMINISTRATION
                , SystemData.OrdersView.FREQUENCY, SystemData.OrdersView.FREQ_DETAIL
                , SystemData.OrdersView.END_DATE_TIME, SystemData.OrdersView.PACK_COUNT
                , SystemData.OrdersView.DOCTOR, SystemData.OrdersView.NURSE
                , SystemData.OrdersView.START_STOP_INDICATOR, SystemData.OrdersView.ORDER_STATUS);
            string szTable = SystemData.DataView.ORDERS;
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'"
                , SystemData.OrdersView.PATIENT_ID, szPatientID, SystemData.OrdersView.VISIT_ID, szVisitID);
            if (!string.IsNullOrEmpty(szOrderText))
            {
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                , szCondition
                , SystemData.OrdersView.ORDER_TEXT, szOrderText);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                do
                {
                    MedOrderInfo orderInfo = new MedOrderInfo();
                    if (!dataReader.IsDBNull(0)) orderInfo.OrderNO = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) orderInfo.OrderSubNO = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) orderInfo.IsRepeat = dataReader.GetValue(2).ToString().Equals("1");
                    if (!dataReader.IsDBNull(3)) orderInfo.OrderClass = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) orderInfo.EnterTime = dataReader.GetDateTime(4);
                    if (!dataReader.IsDBNull(5)) orderInfo.OrderText = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) orderInfo.DrugBillingAttr = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) orderInfo.Dosage = float.Parse(dataReader.GetValue(7).ToString());
                    if (!dataReader.IsDBNull(8)) orderInfo.DosageUnits = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) orderInfo.Administration = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) orderInfo.Frequency = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) orderInfo.FreqDetail = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) orderInfo.StopTime = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) orderInfo.PackCount = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) orderInfo.Doctor = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) orderInfo.Nurse = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) orderInfo.IsStartStop = dataReader.GetValue(16).ToString().Equals("1");
                    if (!dataReader.IsDBNull(17)) orderInfo.OrderStatus = dataReader.GetString(17);
                    lstOrderInfo.Add(orderInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetInpOrderList", new string[] { "szSQL" }, new object[] { szSQL }, "查询住院医嘱时出现异常!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 医嘱检索，获取有相关医嘱的在院患者列表
        /// </summary>
        /// <param name="szOrderText"></param>
        /// <param name="szDeptCode"></param>
        /// <param name="lstPatVisitLog"></param>
        /// <returns></returns>
        public short GetPatientListByOrderText(string szOrderText, string szDeptCode, ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (string.IsNullOrEmpty(szOrderText) || string.IsNullOrEmpty(szOrderText))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8}"
                , SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME
                , SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DEPT_NAME
                , SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX);

            string szCondition = string.Format(" 1=1  AND B.{0} like '%{1}%'"
                , SystemData.OrdersView.ORDER_TEXT, szOrderText);
            szCondition = string.Format("{0} AND A.{1}=B.{2} AND A.{3}=B.{4}", szCondition, SystemData.PatVisitView.PATIENT_ID
               , SystemData.AdtLogTable.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.AdtLogTable.VISIT_ID);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szGroupBy = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8}"
                , SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME
                , SystemData.PatVisitView.PATIENT_NAME
                , SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DEPT_NAME
                , SystemData.PatVisitView.BED_CODE
                , SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX);
            string szOrderBy = string.Format("A.{0}", SystemData.PatVisitView.DEPT_CODE);

            string szTable = string.Format("{0} A,{1} B", SystemData.DataView.INP_VISIT_V, SystemData.DataView.ORDERS);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM_WHERE_GROUP_ORDER_ASC, szField, szTable, szCondition, szGroupBy, szOrderBy);
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
                    if (!dataReader.IsDBNull(4)) patVisitLog.DEPT_CODE = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.DEPT_NAME = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.BED_CODE = dataReader.GetValue(6).ToString();
                    if (!dataReader.IsDBNull(7)) patVisitLog.INP_NO = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.PATIENT_SEX = dataReader.GetString(8);
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatientListByOrderText", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
