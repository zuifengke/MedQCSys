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

    public class DiagComparingAccess : DBAccessBase
    {
        public const string TableName = SystemData.DataTable_HerenHis.DIAG_COMPARING;
        private static DiagComparingAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static DiagComparingAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new DiagComparingAccess();
                return m_Instance;
            }
        }

        public short GetList(string szPatientID,string szVisitNo, ref List<DiagComparing> lstDiagnosisDict)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3}='{4}'"
                , szCondition
                , SystemData.DiagComparingTable.PATIENT_ID
                , szPatientID
                , SystemData.DiagComparingTable.VISIT_NO
                , szVisitNo);
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
                if (lstDiagnosisDict == null)
                    lstDiagnosisDict = new List<DiagComparing>();
                lstDiagnosisDict.Clear();
                do
                {
                    DiagComparing model = new DiagComparing();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        PropertyInfo property = Reflect.GetPropertyInfo(typeof(DiagComparing), dataReader.GetName(i));
                        bool result = Reflect.SetPropertyValue(model, property, dataReader.GetValue(i));
                    }
                    lstDiagnosisDict.Add(model);
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


        public short GetModel(string diagnosisName, ref DiagComparing model)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}'"
                , szCondition
                , SystemData.DiagnosisDictTable.DIAGNOSIS_NAME
                , diagnosisName);
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
                model = new DiagComparing();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    PropertyInfo property = Reflect.GetPropertyInfo(typeof(DiagnosisDict), dataReader.GetName(i));
                    bool result = Reflect.SetPropertyValue(model, property, dataReader.GetValue(i));
                }
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
