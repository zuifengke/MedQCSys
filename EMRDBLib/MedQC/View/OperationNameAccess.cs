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
    public class OperationNameAccess : DBAccessBase
    {
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
        /// <summary>
        /// 获取手术名称
        /// </summary>
        /// <param name="szPatientID"></param>
        /// <param name="szVisitNo"></param>
        /// <param name="lstOperationNames"></param>
        /// <returns></returns>
        public short GetOperationNames(string szPatientID, string szVisitNo, ref List<OperationName> lstOperationNames)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (string.IsNullOrEmpty(szPatientID) && string.IsNullOrEmpty(szVisitNo))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2}"
                , SystemData.OperationNameView.OPERATION
                , SystemData.OperationNameView.OPERATION_SCALE
                , SystemData.OperationNameView.OPER_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPatientID))
                szCondition = string.Format("{0} AND {1}='{2}' AND {3}='{4}'"
                , szCondition
                , SystemData.OperationNameView.PATIENT_ID
                , szPatientID
                , SystemData.OperationNameView.VISIT_NO
                , szVisitNo
                );
            string szTable = string.Format("{0}", SystemData.DataView.OPERATION_NAME_V);
            string szOrderBy = string.Format("OPERATION_NO");

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
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
                base.QCAccess.CloseConnnection(false);
            }
        }
    }
}
