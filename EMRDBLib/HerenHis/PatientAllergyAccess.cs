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

namespace EMRDBLib
{
    /// <summary>
    /// 过敏史数据访问类
    /// </summary>
    public class PatientAllergyAccess : DBAccessBase
    {
        public const string TableName = SystemData.DataTable_HerenHis.PATIENT_ALLERGY;
        private static PatientAllergyAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static PatientAllergyAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new PatientAllergyAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取过敏史列表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="szVisitNO"></param>
        /// <param name="lstPatientAllergy"></param>
        /// <returns></returns>
        public short GetList(string patientID, string szVisitNO, ref List<PatientAllergy> lstPatientAllergy)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' and {3}='{4}' "
                , szCondition
                , SystemData.PatientAllergyTable.PATIENT_ID
                , patientID
                , SystemData.PatientAllergyTable.VISIT_NO
                , szVisitNO);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), TableName, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatientAllergy == null)
                    lstPatientAllergy = new List<PatientAllergy>();
                lstPatientAllergy.Clear();
                do
                {
                    PatientAllergy model = new PatientAllergy();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        PropertyInfo property = Reflect.GetPropertyInfo(typeof(PatientAllergy), dataReader.GetName(i));
                        bool result = Reflect.SetPropertyValue(model, property, dataReader.GetValue(i));
                    }
                    lstPatientAllergy.Add(model);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.HerenHisAccess.CloseConnnection(false); }
        }

    }
}
