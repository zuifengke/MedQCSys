using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class InpBillDetailAccess : DBAccessBase
    {
        private static InpBillDetailAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static InpBillDetailAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new InpBillDetailAccess();
                return m_Instance;
            }
        }

        public short GetPatientBillDetails(string szPatientID, string szVisitID, ref List<InpBillDetail> lstInpBillDetails)
        {
            if (string.IsNullOrEmpty(szPatientID) || string.IsNullOrEmpty(szVisitID))
                return SystemData.ReturnValue.PARAM_ERROR;
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("SELECT AMOUNT,CHARGES,COSTS,ITEM_CLASS,ITEM_NAME,ITEM_SPEC,UNITS,CLASS_NAME,BILLING_DATE_TIME");
            sbSQL.Append("  FROM INP_BILL_VIEW");
            sbSQL.AppendFormat("  WHERE PATIENT_ID = '{0}' AND VISIT_ID = {1}", szPatientID, szVisitID);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(sbSQL.ToString());
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstInpBillDetails == null)
                    lstInpBillDetails = new List<InpBillDetail>();
                do
                {
                    InpBillDetail item = new InpBillDetail();
                    if (!dataReader.IsDBNull(0)) item.Amount = dataReader.GetDecimal(0);
                    if (!dataReader.IsDBNull(1)) item.Charges = dataReader.GetDecimal(1);
                    if (!dataReader.IsDBNull(2)) item.Costs = dataReader.GetDecimal(2);
                    if (!dataReader.IsDBNull(3)) item.Item_class = dataReader.GetValue(3).ToString();
                    if (!dataReader.IsDBNull(4)) item.Item_name = dataReader.GetValue(4).ToString();
                    if (!dataReader.IsDBNull(5)) item.Item_spec = dataReader.GetValue(5).ToString();
                    if (!dataReader.IsDBNull(6)) item.Units = dataReader.GetValue(6).ToString();
                    if (!dataReader.IsDBNull(7)) item.Class_name = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) item.Billing_date_time = dataReader.GetDateTime(8);
                    lstInpBillDetails.Add(item);
                }
                while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("InpBillDetailAccess.GetPatientBillDetails", new string[] { "SQL" }, new object[] { sbSQL.ToString() }, ex);
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
                base.DataAccess.CloseConnnection(false);
            }
        }
    }
}
