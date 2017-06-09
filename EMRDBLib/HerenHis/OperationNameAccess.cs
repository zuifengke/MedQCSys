using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 方法只支持新系统
    /// </summary>
    public class OperationNameAccess : DBAccessBase
    {
        private const string TableName = SystemData.DataTable_HerenHis.OPERATION_NAME;
        private static OperationNameAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static OperationNameAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new OperationNameAccess();
                return OperationNameAccess.m_Instance;
            }
        }


        public short GetModel(string szOperNO, ref OperationName model)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' "
                , szCondition
                , SystemData.OperationNameTable.OPER_NO
                , szOperNO);
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
                if (model == null)
                    model = new OperationName();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    PropertyInfo property = Reflect.GetPropertyInfo(typeof(OperationName), dataReader.GetName(i));
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

        /// <summary>
        /// 获取手术名称
        /// </summary>
        /// <param name="szPatientID"></param>
        /// <param name="szVisitNo"></param>
        /// <param name="lstOperationNames"></param>
        /// <returns></returns>
        public short GetOperationNames(string szPatientID, string szVisitNo, ref List<OperationName> lstOperationNames)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (string.IsNullOrEmpty(szPatientID) && string.IsNullOrEmpty(szVisitNo))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2}"
                , SystemData.OperationNameTable.OPERATION
                , SystemData.OperationNameTable.OPERATION_SCALE
                , SystemData.OperationNameTable.OPER_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPatientID))
                szCondition = string.Format("{0} AND {1}='{2}' AND {3}='{4}'"
                , szCondition
                , SystemData.OperationNameTable.PATIENT_ID
                , szPatientID
                , SystemData.OperationNameTable.VISIT_NO
                , szVisitNo
                );
            string szTable = string.Format("{0}", SystemData.DataTable_HerenHis.OPERATION_NAME);
            string szOrderBy = string.Format("OPERATION_NO");

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstOperationNames == null)
                    lstOperationNames = new List<OperationName>();
                do
                {
                    OperationName operation = new OperationName();
                    if (!dataReader.IsDBNull(0)) operation.OPERATION = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) operation.OPERATION_SCALE = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) operation.OPER_NO = dataReader.GetString(2);
                    lstOperationNames.Add(operation);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("OperationNameAccess.GetOperationNames", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.HerenHisAccess.CloseConnnection(false);
            }
        }
    }
}
