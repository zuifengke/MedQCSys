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
    public class OperationDictAccess : DBAccessBase
    {
        private static OperationDictAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static OperationDictAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new OperationDictAccess();
                return OperationDictAccess.m_Instance;
            }
        }/// <summary>
         /// 获取手术操作字典数据列表
         /// </summary>
         /// <param name="lstOperationDict">手术操作字典数据列表</param>
         /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetOperationDict(ref List<EMRDBLib.OperationDict> lstOperationDict)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2}", SystemData.OperationDictView.OPERATION_CODE, SystemData.OperationDictView.OPERATION_NAME
                , SystemData.OperationDictView.INPUT_CODE);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM, szField, SystemData.DataView.OPERATION_DICT_V);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstOperationDict == null)
                    lstOperationDict = new List<OperationDict>();
                do
                {
                    OperationDict operationDict = new OperationDict();
                    if (!dataReader.IsDBNull(0))
                        operationDict.OperationCode = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        operationDict.OperationName = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        operationDict.InputCode = dataReader.GetString(2);
                    lstOperationDict.Add(operationDict);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
    }
}
