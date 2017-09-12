// ***********************************************************
// 数据库访问层通用操作有关的数据访问接口.
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using EMRDBLib.DbAccess;
using EMRDBLib.BAJK;
using System.Reflection;
using EMRDBLib.HerenHis;
using System.Linq;
namespace EMRDBLib
{

    public class TransferAccess : DBAccessBase
    {
        public const string TableName = SystemData.DataView.TRANSFER_V;
        private static TransferAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static TransferAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new TransferAccess();
                return m_Instance;
            }
        }

        public short GetList(string patientID, string szVisitNO, ref List<Transfer> lstTransfer)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' and {3}='{4}' "
                , szCondition
                , SystemData.TransferView.PATIENT_ID
                , patientID
                , SystemData.TransferView.VISIT_NO
                , szVisitNO);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), TableName, szCondition, SystemData.TransferView.ADMISSION_DATE_TIME);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstTransfer == null)
                    lstTransfer = new List<Transfer>();
                lstTransfer.Clear();
                do
                {
                    Transfer item = new Transfer();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.TransferView.ADMISSION_DATE_TIME:
                                item.ADMISSION_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.TransferView.BED_LABEL:
                                item.BED_LABEL = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.BED_NO:
                                item.BED_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.CHARGER_DOCTOR_ID:
                                item.CHARGER_DOCTOR_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.CHARGER_DOCTOR_NAME:
                                item.CHARGER_DOCTOR_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.DEPT_STAYED:
                                item.DEPT_STAYED = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.DEPT_TRANSFER_TO:
                                item.DEPT_TRANSFER_TO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.DISCHARGE_DATE_TIME:
                                item.DISCHARGE_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.TransferView.MEDICAL_GROUP_NAME:
                                item.MEDICAL_GROUP_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.MEDICAL_GROUP_NO:
                                item.MEDICAL_GROUP_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.PATIENT_ID:
                                item.PATIENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.VISIT_ID:
                                item.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.VISIT_NO:
                                item.VISIT_NO = dataReader.GetValue(i).ToString();
                                break;
                            default: break;
                        }
                    }
                    lstTransfer.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        public short GetList(List<PatVisitInfo> lstPatVisitInfo, ref List<Transfer> lstTransfers)
        {
            try
            {
                if (lstTransfers == null)
                    lstTransfers = new List<Transfer>();
                for (int i = 0; i < lstPatVisitInfo.Count() / 100 + 1; i++)
                {
                    var result = lstPatVisitInfo.Skip(i * 100).Take(100).ToList();
                    if (result != null && result.Count > 0)
                    {
                        string szCondition = string.Format("");
                        foreach (var item in result)
                        {
                            if (szCondition == string.Empty)
                                szCondition = string.Format("({0}='{1}' and {2}='{3}')"
                                    , SystemData.PatVisitView.PATIENT_ID, item.PATIENT_ID
                                    , SystemData.PatVisitView.VISIT_ID, item.VISIT_ID);
                            else
                                szCondition = string.Format("({0}='{1}' and {2}='{3}') or {4}"
                                     , SystemData.PatVisitView.PATIENT_ID, item.PATIENT_ID
                                    , SystemData.PatVisitView.VISIT_ID, item.VISIT_ID
                                    , szCondition);
                        }
                        List<Transfer> lstTransfer = null;
                        this.GetList(szCondition, ref lstTransfer);
                        if (lstTransfer != null)
                            lstTransfers.AddRange(lstTransfer);
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
                return SystemData.ReturnValue.EXCEPTION;
            }
        }
        public short GetList(string szCondition, ref List<Transfer> lstTransfer)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szCondition))
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), TableName, szCondition,SystemData.TransferView.ADMISSION_DATE_TIME);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstTransfer == null)
                    lstTransfer = new List<Transfer>();
                lstTransfer.Clear();
                do
                {
                    Transfer item = new Transfer();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.TransferView.ADMISSION_DATE_TIME:
                                item.ADMISSION_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.TransferView.BED_LABEL:
                                item.BED_LABEL = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.BED_NO:
                                item.BED_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.CHARGER_DOCTOR_ID:
                                item.CHARGER_DOCTOR_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.CHARGER_DOCTOR_NAME:
                                item.CHARGER_DOCTOR_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.DEPT_STAYED:
                                item.DEPT_STAYED = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.DEPT_TRANSFER_TO:
                                item.DEPT_TRANSFER_TO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.DISCHARGE_DATE_TIME:
                                item.DISCHARGE_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.TransferView.MEDICAL_GROUP_NAME:
                                item.MEDICAL_GROUP_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.MEDICAL_GROUP_NO:
                                item.MEDICAL_GROUP_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.PATIENT_ID:
                                item.PATIENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.VISIT_ID:
                                item.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TransferView.VISIT_NO:
                                item.VISIT_NO = dataReader.GetValue(i).ToString();
                                break;
                            default: break;
                        }
                    }
                    lstTransfer.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

    }
}
