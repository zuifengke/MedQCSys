/*************************************************
* 和仁HIS库病案首页信息数据访问类
* 作者：yehui
* 时间：2017-06-05
*************************************************/

using EMRDBLib.Entity;
using EMRDBLib.HerenHis;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace EMRDBLib.DbAccess.HerenHis
{

    public class InpVisitAccess : DBAccessBase
    {
        private static InpVisitAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static InpVisitAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new InpVisitAccess();
                return InpVisitAccess.m_Instance;
            }
        }

        public short GetInpVisit(string szPatientID, string szVisitID, ref InpVisit inpVisit)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = {4}"
                , szCondition
                , SystemData.InpVisitTable.PATIENT_ID
                , szPatientID
                , SystemData.InpVisitTable.VISIT_ID
                , szVisitID);
            string szOrderBy = string.Format("{0}", SystemData.InpVisitTable.PATIENT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable_HerenHis.INP_VISIT, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (inpVisit == null)
                    inpVisit = new InpVisit();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    PropertyInfo property = Reflect.GetPropertyInfo(typeof(InpVisit), dataReader.GetName(i));
                    bool result = Reflect.SetPropertyValue(inpVisit, property, dataReader.GetValue(i));
                    //switch (dataReader.GetName(i))
                    //{
                    //    case SystemData.InpVisitTable.ADMISSION_CAUSE:
                    //        inpVisit.ADMISSION_CAUSE = dataReader.GetValue(i).ToString();
                    //        break;
                    //    case SystemData.InpVisitTable.ADMISSION_DATE_TIME:
                    //        inpVisit.ADMISSION_DATE_TIME = dataReader.GetDateTime(i);
                    //        break;
                    //    case SystemData.InpVisitTable.ADT_STATUS:
                    //        inpVisit.ADT_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.ADVANCED_STUDIES_DOCTOR:
                    //        inpVisit.ADVANCED_STUDIES_DOCTOR = dataReader.GetValue(i).ToString();
                    //        break;
                    //    case SystemData.InpVisitTable.ADVERSE_REACTION_DRUGS:
                    //        inpVisit.ADVERSE_REACTION_DRUGS = dataReader.GetValue(i).ToString();
                    //        break;
                    //    case SystemData.InpVisitTable.AGE:
                    //        inpVisit.AGE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.ALERGY_DRUGS:
                    //        inpVisit.ALERGY_DRUGS = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.ARMED_SERVICES:
                    //        inpVisit.ARMED_SERVICES = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.ATTENDING_DOCTOR:
                    //        inpVisit.ATTENDING_DOCTOR = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.ATTENDING_DOCTOR_ID:
                    //        inpVisit.ATTENDING_DOCTOR_ID = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.AUTOPSY_INDICATOR:
                    //        inpVisit.AUTOPSY_INDICATOR = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.AUTOTRANSFUSION:
                    //        inpVisit.AUTOTRANSFUSION = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.BLOOD_TRAN_REACT_TIMES:
                    //        inpVisit.BLOOD_TRAN_REACT_TIMES = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.BLOOD_TRAN_TIMES:
                    //        inpVisit.BLOOD_TRAN_TIMES = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.BLOOD_TRAN_VOL:
                    //        inpVisit.BLOOD_TRAN_VOL = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.BLOOD_TYPE:
                    //        inpVisit.BLOOD_TYPE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.BLOOD_TYPE_RH:
                    //        inpVisit.BLOOD_TYPE_RH = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.CATALOGER:
                    //        inpVisit.CATALOGER = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.CATALOG_DATE:
                    //        inpVisit.CATALOG_DATE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.CCU_DAYS:
                    //        inpVisit.CCU_DAYS = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.CHARGE_TYPE:
                    //        inpVisit.CHARGE_TYPE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.CHIEF_DOCTOR:
                    //        inpVisit.CHIEF_DOCTOR = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.PAT_ADM_CONDITION:
                    //        inpVisit.PAT_ADM_CONDITION = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.PHONE_NUMBER_BUSINESS:
                    //        inpVisit.PHONE_NUMBER_BUSINESS = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.PRACTICE_DOCTOR:
                    //        inpVisit.PRACTICE_DOCTOR = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.PRACTICE_DOCTOR_OF_GRADUATE:
                    //        inpVisit.PRACTICE_DOCTOR_OF_GRADUATE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.RELATIONSHIP:
                    //        inpVisit.RELATIONSHIP = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.SECOND_LEVEL_NURS_DAYS:
                    //        inpVisit.SECOND_LEVEL_NURS_DAYS = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.SECURITY_NO:
                    //        inpVisit.SECURITY_NO = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.SECURITY_TYPE:
                    //        inpVisit.SECURITY_TYPE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.SERIOUS_COND_DAYS:
                    //        inpVisit.SERIOUS_COND_DAYS = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.SERVICE_AGENCY:
                    //        inpVisit.SERVICE_AGENCY = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.SERVICE_SYSTEM_INDICATOR:
                    //        inpVisit.SERVICE_SYSTEM_INDICATOR = int.Parse(dataReader.GetString(i));
                    //        break;
                    //    case SystemData.InpVisitTable.SEX:
                    //        inpVisit.SEX = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.SPEC_LEVEL_NURS_DAYS:
                    //        inpVisit.SPEC_LEVEL_NURS_DAYS = int.Parse(dataReader.GetString(i));
                    //        break;
                    //    case SystemData.InpVisitTable.TEACHING_MR:
                    //        inpVisit.TEACHING_MR = int.Parse(dataReader.GetString(i));
                    //        break;
                    //    case SystemData.InpVisitTable.TOP_UNIT:
                    //        inpVisit.TOP_UNIT = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.TOTAL_COSTS:
                    //        inpVisit.TOTAL_COSTS = double.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.TOTAL_PAYMENTS:
                    //        inpVisit.TOTAL_PAYMENTS = double.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.TRAINING_INJURY:
                    //        inpVisit.TRAINING_INJURY = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.UNIT_IN_CONTRACT:
                    //        inpVisit.UNIT_IN_CONTRACT = dataReader.GetValue(i).ToString();
                    //        break;
                    //    case SystemData.InpVisitTable.VISIT_ID:
                    //        inpVisit.VISIT_ID = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.VISIT_NO:
                    //        inpVisit.VISIT_NO = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.VISIT_TYPE:
                    //        inpVisit.VISIT_TYPE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.WORKING_ADDRESS:
                    //        inpVisit.WORKING_ADDRESS = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.WORKING_ADDRESS_ZIPCODE:
                    //        inpVisit.WORKING_ADDRESS_ZIPCODE = dataReader.GetString(i);
                    //        break;
                    //    case SystemData.InpVisitTable.WORKING_STATUS:
                    //        inpVisit.WORKING_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                    //        break;
                    //    case SystemData.InpVisitTable.NAME:
                    //        inpVisit.NAME =dataReader.GetValue(i).ToString();
                    //        break;
                    //    default: break;
                    //}

                } while (dataReader.Read()) ;
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.HerenHisAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 更新患者是否为病案统计时的无效病人
        /// </summary>
        /// <param name="inpVisit"></param>
        /// <returns></returns>
        public short UpdateInValid(InpVisit inpVisit)
        {
            if (inpVisit == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { inpVisit }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}={1},"
                , SystemData.InpVisitTable.INVALID_PATIENT, inpVisit.INVALID_PATIENT);
          
            string szCondition = string.Format("{0}='{1}'", SystemData.InpVisitTable.VISIT_NO, inpVisit.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable_HerenHis.INP_VISIT, sbField.ToString(), szCondition);
            int nCount = 0;
            try
            {
                nCount = base.HerenHisAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
    }
}