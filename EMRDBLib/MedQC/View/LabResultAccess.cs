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
    public class LabResultAccess : DBAccessBase
    {
        private static LabResultAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static LabResultAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new LabResultAccess();
                return LabResultAccess.m_Instance;
            }
        }
        /// <summary>
        /// 根据指定的申请序号，获取检验结果列表
        /// </summary>
        /// <param name="szTestID">申请序号</param>
        /// <param name="lstTestResultInfo">检验结果列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetLabResultList(string szTestID, ref List<LabResult> lstTestResultInfo)
        {
            if (szTestID == null || szTestID.Trim() == "")
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetTestResultList", "查询参数为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (lstTestResultInfo == null)
                lstTestResultInfo = new List<LabResult>();
            else
                lstTestResultInfo.Clear();

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6}"
                , SystemData.LabResultView.TEST_ID, SystemData.LabResultView.ITEM_NO
                , SystemData.LabResultView.ITEM_NAME, SystemData.LabResultView.ITEM_RESULT
                , SystemData.LabResultView.ITEM_UNITS, SystemData.LabResultView.ITEM_REFER
                , SystemData.LabResultView.ABNORMAL_INDICATOR);
            string szTable = SystemData.DataView.LAB_RESULT;
            string szCondition = string.Format("{0}='{1}'", SystemData.LabResultView.TEST_ID, szTestID);
            string szOrderField = SystemData.LabResultView.ITEM_NO;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderField);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                do
                {
                    LabResult testResultInfo = new LabResult();
                    if (!dataReader.IsDBNull(0)) testResultInfo.TEST_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) testResultInfo.ITEM_NO = int.Parse(dataReader.GetValue(1).ToString());
                    if (!dataReader.IsDBNull(2)) testResultInfo.ITEM_NAME = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) testResultInfo.ITEM_RESULT = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) testResultInfo.ITEM_UNITS = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) testResultInfo.ITEM_REFER = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) testResultInfo.ABNORMAL_INDICATOR = dataReader.GetString(6);
                    lstTestResultInfo.Add(testResultInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetTestResultList", new string[] { "szSQL" }, new object[] { szSQL }, "查询检验结果列表时出现异常!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
    }
}
