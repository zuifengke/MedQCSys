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
    public class ExamResultAccess : DBAccessBase
    {
        private static ExamResultAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static ExamResultAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ExamResultAccess();
                return ExamResultAccess.m_Instance;
            }
        }
        /// <summary>
        /// 根据指定的就诊信息，获取该次就诊时，产生的检查报告详细信息
        /// </summary>
        /// <param name="szExamID">申请序号</param>
        /// <param name="examResultInfo">检查报告信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetExamResultInfo(string szExamID, ref ExamResult examResultInfo)
        {
            if (szExamID == null || szExamID.Trim() == "")
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetExamResultInfo", "查询参数为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
                , SystemData.ExamResultView.EXAM_ID, SystemData.ExamResultView.PARAMETERS
                , SystemData.ExamResultView.DESCRIPTION, SystemData.ExamResultView.IMPRESSION
                , SystemData.ExamResultView.RECOMMENDATION, SystemData.ExamResultView.IS_ABNORMAL
                , SystemData.ExamResultView.DEVICE, SystemData.ExamResultView.USE_IMAGE);
            string szTable = SystemData.DataView.EXAM_RESULT;
            string szCondition = string.Format("{0}='{1}'", SystemData.ExamResultView.EXAM_ID, szExamID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                do
                {
                    if (examResultInfo == null)
                        examResultInfo = new ExamResult();
                    if (!dataReader.IsDBNull(0)) examResultInfo.EXAM_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) examResultInfo.PARAMETERS = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) examResultInfo.DESCRIPTION = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) examResultInfo.IMPRESSION = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) examResultInfo.RECOMMENDATION = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) examResultInfo.IS_ABNORMAL = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) examResultInfo.DEVICE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) examResultInfo.USE_IMAGE = dataReader.GetString(7);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetExamResultInfo", new string[] { "szSQL" }, new object[] { szSQL }, "查询检查报告信息时出现异常!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
    }
}
