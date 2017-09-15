// ***********************************************************
// 数据库访问层与病案索引补充表数据相关的访问类.补充病案的归档、退回、纸质接收等操作的记录
// Creator:yehui  Date:2017-4-18
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
namespace EMRDBLib.DbAccess
{

    public class VitalSignsAccess : DBAccessBase
    {
        private static VitalSignsAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static VitalSignsAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new VitalSignsAccess();
                return VitalSignsAccess.m_Instance;
            }
        }

        public short GetList(string patientID, string szVisitNO, string szVitalSigns, ref List<VitalSigns> lstVitalSigns)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' and {3}='{4}' "
                , szCondition
                , SystemData.VitalSignsView.PATIENT_ID
                , patientID
                , SystemData.VitalSignsView.VISIT_NO
                , szVisitNO);
            if (!string.IsNullOrEmpty(szVitalSigns))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.VitalSignsView.VITAL_SIGNS
                    , szVitalSigns);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataView.VITAL_SIGNS_V, szCondition, SystemData.VitalSignsView.RECORDING_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstVitalSigns == null)
                    lstVitalSigns = new List<VitalSigns>();
                lstVitalSigns.Clear();
                do
                {
                    VitalSigns item = new VitalSigns();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.VitalSignsView.MEMO:
                                item.MEMO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.VitalSignsView.PATIENT_ID:
                                item.PATIENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.VitalSignsView.RECORDING_DATE:
                                item.RECORDING_DATE = dataReader.GetDateTime(i);
                                break;
                            case SystemData.VitalSignsView.TIME_POINT:
                                item.TIME_POINT = dataReader.GetDateTime(i);
                                break;
                            case SystemData.VitalSignsView.UNITS:
                                item.UNITS = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.VitalSignsView.VISIT_ID:
                                item.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.VitalSignsView.VISIT_NO:
                                item.VISIT_NO = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.VitalSignsView.VITAL_SIGNS:
                                item.VITAL_SIGNS = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.VitalSignsView.VITAL_SIGNS_VALUES:
                                item.VITAL_SIGNS_VALUES = decimal.Parse(dataReader.GetValue(i).ToString());
                                break;
                            default: break;
                        }
                    }
                    lstVitalSigns.Add(item);
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