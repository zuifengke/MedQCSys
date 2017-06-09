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
    public class ExamMasterAccess : DBAccessBase
    {
        private static ExamMasterAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static ExamMasterAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ExamMasterAccess();
                return ExamMasterAccess.m_Instance;
            }
        }
        /// <summary>
        /// 根据病人ID和就诊号，获取该次住院的检查信息列表
        /// </summary>
        /// <param name="szPatientID">病人编号</param>
        /// <param name="nVisitID">就诊号</param>
        /// <param name="lstExamInfo">检查信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetInpExamList(string szPatientID, string szVisitID, ref List<ExamMaster> lstExamInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetInpExamList", "查询参数为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (lstExamInfo == null)
                lstExamInfo = new List<ExamMaster>();
            else
                lstExamInfo.Clear();

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6}"
                , SystemData.ExamMasterView.EXAM_ID, SystemData.ExamMasterView.SUBJECT
                , SystemData.ExamMasterView.REQUEST_TIME, SystemData.ExamMasterView.REQUEST_DOCTOR
                , SystemData.ExamMasterView.RESULT_STATUS, SystemData.ExamMasterView.REPORT_TIME
                , SystemData.ExamMasterView.REPORT_DOCTOR);
            string szTable = SystemData.DataView.EXAM_MASTER;
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'"
                , SystemData.ExamMasterView.PATIENT_ID, szPatientID, SystemData.ExamMasterView.VISIT_ID, szVisitID);
            string szExamField = SystemData.ExamMasterView.REQUEST_TIME;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szExamField);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                do
                {
                    ExamMaster examInfo = new ExamMaster();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.ExamMasterView.EXAM_ID:
                                examInfo.EXAM_ID = dataReader.GetString(i);
                                break;
                            case SystemData.ExamMasterView.PATIENT_ID:
                                examInfo.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.ExamMasterView.REPORT_DOCTOR:
                                examInfo.REPORT_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.ExamMasterView.REPORT_TIME:
                                examInfo.REPORT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.ExamMasterView.REQUEST_DOCTOR:
                                examInfo.REQUEST_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.ExamMasterView.REQUEST_TIME:
                                examInfo.REQUEST_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.ExamMasterView.RESULT_STATUS:
                                examInfo.RESULT_STATUS = dataReader.GetString(i);
                                break;
                            case SystemData.ExamMasterView.SUBJECT:
                                examInfo.SUBJECT = dataReader.GetString(i);
                                break;
                            case SystemData.ExamMasterView.VISIT_ID:
                                examInfo.VISIT_ID = dataReader.GetString(i);
                                break;
                            default:  break;
                        }
                    }
                    lstExamInfo.Add(examInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetInpExamList", new string[] { "szSQL" }, new object[] { szSQL }, "查询检查列表时出现异常!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
    }
}
