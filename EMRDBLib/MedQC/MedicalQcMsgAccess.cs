// ***********************************************************
// 数据库访问层与质检问题数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class MedicalQcMsgAccess : DBAccessBase
    {
        private static MedicalQcMsgAccess m_Instance = null;
        public static MedicalQcMsgAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new MedicalQcMsgAccess();
                return m_Instance;
            }
        }

        #region"质控反馈问题相关接口"
        /// <summary>
        /// 获取某个ID的质检问题
        /// </summary>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetMedicalQcMsg(string szMsgID, ref MedicalQcMsg qcQuestionInfo)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szMsgID))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}"
               , SystemData.MedicalQcMsgTable.PATIENT_ID
               , SystemData.MedicalQcMsgTable.VISIT_ID
               , SystemData.MedicalQcMsgTable.DEPT_STAYED
               , SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE
               , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
               , SystemData.MedicalQcMsgTable.QC_MSG_CODE
               , SystemData.MedicalQcMsgTable.MESSAGE
               , SystemData.MedicalQcMsgTable.ISSUED_BY
               , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
               , SystemData.MedicalQcMsgTable.MSG_STATUS
               , SystemData.MedicalQcMsgTable.ASK_DATE_TIME
               , SystemData.MedicalQcMsgTable.QC_MODULE
               , SystemData.MedicalQcMsgTable.TOPIC_ID
               , SystemData.MedicalQcMsgTable.TOPIC
               , SystemData.MedicalQcMsgTable.DOCTOR_COMMENT
               , SystemData.MedicalQcMsgTable.POINT
               , SystemData.MedicalQcMsgTable.POINT_TYPE
               , SystemData.MedicalQcMsgTable.MSG_ID
               , SystemData.MedicalQcMsgTable.VISIT_NO
               , SystemData.MedicalQcMsgTable.PATIENT_NAME);
            string szCondition = string.Format("{0}='{1}'"
                , SystemData.MedicalQcMsgTable.MSG_ID, szMsgID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField
                , SystemData.DataTable.MEDICAL_QC_MSG, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                qcQuestionInfo = new MedicalQcMsg();
                if (!dataReader.IsDBNull(0)) qcQuestionInfo.PATIENT_ID = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1)) qcQuestionInfo.VISIT_ID = dataReader.GetValue(1).ToString();
                if (!dataReader.IsDBNull(2)) qcQuestionInfo.DEPT_STAYED = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3)) qcQuestionInfo.DOCTOR_IN_CHARGE = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4)) qcQuestionInfo.QA_EVENT_TYPE = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5)) qcQuestionInfo.QC_MSG_CODE = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6)) qcQuestionInfo.MESSAGE = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7)) qcQuestionInfo.ISSUED_BY = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8)) qcQuestionInfo.ISSUED_DATE_TIME = dataReader.GetDateTime(8);
                if (!dataReader.IsDBNull(9)) qcQuestionInfo.MSG_STATUS = int.Parse(dataReader.GetValue(9).ToString());
                if (!dataReader.IsDBNull(10)) qcQuestionInfo.ASK_DATE_TIME = dataReader.GetDateTime(10);
                if (!dataReader.IsDBNull(11)) qcQuestionInfo.QC_MODULE = dataReader.GetString(11);
                if (!dataReader.IsDBNull(12)) qcQuestionInfo.TOPIC_ID = dataReader.GetString(12);
                if (!dataReader.IsDBNull(13)) qcQuestionInfo.TOPIC = dataReader.GetString(13);
                if (!dataReader.IsDBNull(14)) qcQuestionInfo.DOCTOR_COMMENT = dataReader.GetString(14);
                if (!dataReader.IsDBNull(15)) qcQuestionInfo.POINT = float.Parse(dataReader.GetValue(15).ToString());
                if (!dataReader.IsDBNull(16)) qcQuestionInfo.POINT_TYPE = int.Parse(dataReader.GetValue(16).ToString());
                if (!dataReader.IsDBNull(17)) qcQuestionInfo.MSG_ID = dataReader.GetString(17);
                if (!dataReader.IsDBNull(18)) qcQuestionInfo.VISIT_NO = dataReader.GetString(18);
                if (!dataReader.IsDBNull(19)) qcQuestionInfo.PATIENT_NAME = dataReader.GetString(19);

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCQuestionByID", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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

        /// <summary>
        /// 获取全院或者某个科室内指定时间范围内的问题清单
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="dateBegin">开始日期</param>
        /// <param name="dateEnd">终止日期</param>
        /// <param name="szOrderValue">排序值，默认为问题类型</param>
        /// <param name="lstQcMsg">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetMedicalQcMsgList(string szDeptCode, string szMsgState, DateTime dateBegin, DateTime dateEnd, ref List<MedicalQcMsg> lstQcMsg)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29}"
                , SystemData.MedicalQcMsgTable.APPLY_ENV
                , SystemData.MedicalQcMsgTable.ASK_DATE_TIME
                , SystemData.MedicalQcMsgTable.CREATOR_ID
                , SystemData.MedicalQcMsgTable.DEPT_NAME
                , SystemData.MedicalQcMsgTable.DEPT_STAYED
                , SystemData.MedicalQcMsgTable.DOCTOR_COMMENT
                , SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE
                , SystemData.MedicalQcMsgTable.ISSUED_BY
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
                , SystemData.MedicalQcMsgTable.ISSUED_ID
                , SystemData.MedicalQcMsgTable.ISSUED_TYPE
                , SystemData.MedicalQcMsgTable.LOCK_STATUS
                , SystemData.MedicalQcMsgTable.MESSAGE
                , SystemData.MedicalQcMsgTable.MSG_ID
                , SystemData.MedicalQcMsgTable.MSG_STATUS
                , SystemData.MedicalQcMsgTable.PARENT_DOCTOR
                , SystemData.MedicalQcMsgTable.PATIENT_ID
                , SystemData.MedicalQcMsgTable.PATIENT_NAME
                , SystemData.MedicalQcMsgTable.POINT
                , SystemData.MedicalQcMsgTable.POINT_TYPE
                , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.QCDOC_TYPE
                , SystemData.MedicalQcMsgTable.QC_MODULE
                , SystemData.MedicalQcMsgTable.QC_MSG_CODE
                , SystemData.MedicalQcMsgTable.SUPER_DOCTOR
                , SystemData.MedicalQcMsgTable.TOPIC
                , SystemData.MedicalQcMsgTable.TOPIC_ID
                , SystemData.MedicalQcMsgTable.VISIT_ID
                , SystemData.MedicalQcMsgTable.VISIT_NO
                , SystemData.MedicalQcMsgTable.MODIFY_NOTICE_ID
                );

            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} >= {2} AND {1} < ={3} AND {4}='MEDDOC' "
                , szCondition, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME,
                base.QCAccess.GetSqlTimeFormat(dateBegin), base.QCAccess.GetSqlTimeFormat(dateEnd), SystemData.MedicalQcMsgTable.APPLY_ENV);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.MedicalQcMsgTable.DEPT_STAYED, szDeptCode);
            if (!string.IsNullOrEmpty(szMsgState))
                szCondition = string.Format("{0} AND {1} in( {2} )", szCondition, SystemData.MedicalQcMsgTable.MSG_STATUS, szMsgState);
            string szTable = string.Format("{0}", SystemData.DataTable.MEDICAL_QC_MSG);

            string szOrderBy = string.Format("{0},{1},{2},{3}",
                SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.PATIENT_ID, SystemData.MedicalQcMsgTable.VISIT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsg == null)
                    lstQcMsg = new List<MedicalQcMsg>();
                do
                {
                    MedicalQcMsg item = new MedicalQcMsg();
                    if (!dataReader.IsDBNull(0)) item.APPLY_ENV = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) item.ASK_DATE_TIME = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) item.CREATOR_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) item.DEPT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) item.DEPT_STAYED = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) item.DOCTOR_COMMENT = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) item.DOCTOR_IN_CHARGE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) item.ISSUED_BY = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) item.ISSUED_DATE_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) item.ISSUED_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) item.ISSUED_TYPE = int.Parse(dataReader.GetValue(10).ToString());
                    if (!dataReader.IsDBNull(11)) item.LOCK_STATUS = dataReader.GetValue(11).ToString() == "1";
                    if (!dataReader.IsDBNull(12)) item.MESSAGE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) item.MSG_ID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) item.MSG_STATUS = int.Parse(dataReader.GetValue(14).ToString());
                    if (!dataReader.IsDBNull(15)) item.PARENT_DOCTOR = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) item.PATIENT_ID = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) item.PATIENT_NAME = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) item.POINT = float.Parse(dataReader.GetValue(18).ToString());
                    if (!dataReader.IsDBNull(19)) item.POINT_TYPE = int.Parse(dataReader.GetValue(19).ToString());
                    if (!dataReader.IsDBNull(20)) item.QA_EVENT_TYPE = dataReader.GetString(20);
                    if (!dataReader.IsDBNull(21)) item.QCDOC_TYPE = int.Parse(dataReader.GetValue(21).ToString());
                    if (!dataReader.IsDBNull(22)) item.QC_MODULE = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) item.QC_MSG_CODE = dataReader.GetString(23);
                    if (!dataReader.IsDBNull(24)) item.SUPER_DOCTOR = dataReader.GetString(24);
                    if (!dataReader.IsDBNull(25)) item.TOPIC = dataReader.GetString(25);
                    if (!dataReader.IsDBNull(26)) item.TOPIC_ID = dataReader.GetString(26);
                    if (!dataReader.IsDBNull(27)) item.VISIT_ID = dataReader.GetString(27);
                    if (!dataReader.IsDBNull(28)) item.VISIT_NO = dataReader.GetString(28);
                    if (!dataReader.IsDBNull(29)) item.MODIFY_NOTICE_ID = dataReader.GetValue(29).ToString();
                    lstQcMsg.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// <summary>
        /// 获取全院或者某个科室内指定时间范围内的问题清单
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="dateBegin">开始日期</param>
        /// <param name="dateEnd">终止日期</param>
        /// <param name="szOrderValue">排序值，默认为问题类型</param>
        /// <param name="lstQcMsg">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetMedicalQcMsgList(string szDeptCode, string szUserID, string szPatientID, string szPatientName, string szMsgState, DateTime dateBegin, DateTime dateEnd, ref List<MedicalQcMsg> lstQcMsg)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28}"
                , SystemData.MedicalQcMsgTable.APPLY_ENV
                , SystemData.MedicalQcMsgTable.ASK_DATE_TIME
                , SystemData.MedicalQcMsgTable.CREATOR_ID
                , SystemData.MedicalQcMsgTable.DEPT_NAME
                , SystemData.MedicalQcMsgTable.DEPT_STAYED
                , SystemData.MedicalQcMsgTable.DOCTOR_COMMENT
                , SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE
                , SystemData.MedicalQcMsgTable.ISSUED_BY
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
                , SystemData.MedicalQcMsgTable.ISSUED_ID
                , SystemData.MedicalQcMsgTable.ISSUED_TYPE
                , SystemData.MedicalQcMsgTable.LOCK_STATUS
                , SystemData.MedicalQcMsgTable.MESSAGE
                , SystemData.MedicalQcMsgTable.MSG_ID
                , SystemData.MedicalQcMsgTable.MSG_STATUS
                , SystemData.MedicalQcMsgTable.PARENT_DOCTOR
                , SystemData.MedicalQcMsgTable.PATIENT_ID
                , SystemData.MedicalQcMsgTable.PATIENT_NAME
                , SystemData.MedicalQcMsgTable.POINT
                , SystemData.MedicalQcMsgTable.POINT_TYPE
                , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.QCDOC_TYPE
                , SystemData.MedicalQcMsgTable.QC_MODULE
                , SystemData.MedicalQcMsgTable.QC_MSG_CODE
                , SystemData.MedicalQcMsgTable.SUPER_DOCTOR
                , SystemData.MedicalQcMsgTable.TOPIC
                , SystemData.MedicalQcMsgTable.TOPIC_ID
                , SystemData.MedicalQcMsgTable.VISIT_ID
                , SystemData.MedicalQcMsgTable.VISIT_NO);

            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} >= {2} AND {1} < ={3} AND {4}='MEDDOC' "
                , szCondition, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME,
                base.QCAccess.GetSqlTimeFormat(dateBegin), base.QCAccess.GetSqlTimeFormat(dateEnd), SystemData.MedicalQcMsgTable.APPLY_ENV);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.MedicalQcMsgTable.DEPT_STAYED, szDeptCode);
            if (!string.IsNullOrEmpty(szMsgState))
                szCondition = string.Format("{0} AND {1} in( {2} )", szCondition, SystemData.MedicalQcMsgTable.MSG_STATUS, szMsgState);
            string szTable = string.Format("{0}", SystemData.DataTable.MEDICAL_QC_MSG);

            string szOrderBy = string.Format("{0},{1},{2},{3}",
                SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.PATIENT_ID, SystemData.MedicalQcMsgTable.VISIT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsg == null)
                    lstQcMsg = new List<MedicalQcMsg>();
                do
                {
                    MedicalQcMsg item = new MedicalQcMsg();
                    if (!dataReader.IsDBNull(0)) item.APPLY_ENV = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) item.ASK_DATE_TIME = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) item.CREATOR_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) item.DEPT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) item.DEPT_STAYED = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) item.DOCTOR_COMMENT = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) item.DOCTOR_IN_CHARGE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) item.ISSUED_BY = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) item.ISSUED_DATE_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) item.ISSUED_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) item.ISSUED_TYPE = int.Parse(dataReader.GetValue(10).ToString());
                    if (!dataReader.IsDBNull(11)) item.LOCK_STATUS = dataReader.GetValue(11).ToString() == "1";
                    if (!dataReader.IsDBNull(12)) item.MESSAGE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) item.MSG_ID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) item.MSG_STATUS = int.Parse(dataReader.GetValue(14).ToString());
                    if (!dataReader.IsDBNull(15)) item.PARENT_DOCTOR = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) item.PATIENT_ID = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) item.PATIENT_NAME = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) item.POINT = float.Parse(dataReader.GetValue(18).ToString());
                    if (!dataReader.IsDBNull(19)) item.POINT_TYPE = int.Parse(dataReader.GetValue(19).ToString());
                    if (!dataReader.IsDBNull(20)) item.QA_EVENT_TYPE = dataReader.GetString(20);
                    if (!dataReader.IsDBNull(21)) item.QCDOC_TYPE = int.Parse(dataReader.GetValue(21).ToString());
                    if (!dataReader.IsDBNull(22)) item.QC_MODULE = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) item.QC_MSG_CODE = dataReader.GetString(23);
                    if (!dataReader.IsDBNull(24)) item.SUPER_DOCTOR = dataReader.GetString(24);
                    if (!dataReader.IsDBNull(25)) item.TOPIC = dataReader.GetString(25);
                    if (!dataReader.IsDBNull(26)) item.TOPIC_ID = dataReader.GetString(26);
                    if (!dataReader.IsDBNull(27)) item.VISIT_ID = dataReader.GetString(27);
                    if (!dataReader.IsDBNull(28)) item.VISIT_NO = dataReader.GetString(28);
                    lstQcMsg.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// <summary>
        /// 获取全院或者某个科室内指定时间范围内的问题清单
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="dateBegin">开始日期</param>
        /// <param name="dateEnd">终止日期</param>
        /// <param name="szOrderValue">排序值，默认为问题类型</param>
        /// <param name="lstQcMsg">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetMedicalQcMsgList(string szDeptCode, DateTime dateBegin, DateTime dateEnd, ref List<MedicalQcMsg> lstQcMsg)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28}"
                , SystemData.MedicalQcMsgTable.APPLY_ENV
                , SystemData.MedicalQcMsgTable.ASK_DATE_TIME
                , SystemData.MedicalQcMsgTable.CREATOR_ID
                , SystemData.MedicalQcMsgTable.DEPT_NAME
                , SystemData.MedicalQcMsgTable.DEPT_STAYED
                , SystemData.MedicalQcMsgTable.DOCTOR_COMMENT
                , SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE
                , SystemData.MedicalQcMsgTable.ISSUED_BY
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
                , SystemData.MedicalQcMsgTable.ISSUED_ID
                , SystemData.MedicalQcMsgTable.ISSUED_TYPE
                , SystemData.MedicalQcMsgTable.LOCK_STATUS
                , SystemData.MedicalQcMsgTable.MESSAGE
                , SystemData.MedicalQcMsgTable.MSG_ID
                , SystemData.MedicalQcMsgTable.MSG_STATUS
                , SystemData.MedicalQcMsgTable.PARENT_DOCTOR
                , SystemData.MedicalQcMsgTable.PATIENT_ID
                , SystemData.MedicalQcMsgTable.PATIENT_NAME
                , SystemData.MedicalQcMsgTable.POINT
                , SystemData.MedicalQcMsgTable.POINT_TYPE
                , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.QCDOC_TYPE
                , SystemData.MedicalQcMsgTable.QC_MODULE
                , SystemData.MedicalQcMsgTable.QC_MSG_CODE
                , SystemData.MedicalQcMsgTable.SUPER_DOCTOR
                , SystemData.MedicalQcMsgTable.TOPIC
                , SystemData.MedicalQcMsgTable.TOPIC_ID
                , SystemData.MedicalQcMsgTable.VISIT_ID
                , SystemData.MedicalQcMsgTable.VISIT_NO);

            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} >= {2} AND {1} < ={3} AND {4}='MEDDOC' "
                , szCondition, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME,
                base.QCAccess.GetSqlTimeFormat(dateBegin), base.QCAccess.GetSqlTimeFormat(dateEnd), SystemData.MedicalQcMsgTable.APPLY_ENV);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.MedicalQcMsgTable.DEPT_STAYED, szDeptCode);
            string szTable = string.Format("{0}", SystemData.DataTable.MEDICAL_QC_MSG);

            string szOrderBy = string.Format("{0},{1},{2},{3}",
                SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.PATIENT_ID, SystemData.MedicalQcMsgTable.VISIT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsg == null)
                    lstQcMsg = new List<MedicalQcMsg>();
                do
                {
                    MedicalQcMsg item = new MedicalQcMsg();
                    if (!dataReader.IsDBNull(0)) item.APPLY_ENV = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) item.ASK_DATE_TIME = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) item.CREATOR_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) item.DEPT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) item.DEPT_STAYED = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) item.DOCTOR_COMMENT = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) item.DOCTOR_IN_CHARGE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) item.ISSUED_BY = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) item.ISSUED_DATE_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) item.ISSUED_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) item.ISSUED_TYPE = int.Parse(dataReader.GetValue(10).ToString());
                    if (!dataReader.IsDBNull(11)) item.LOCK_STATUS = dataReader.GetValue(11).ToString() == "1";
                    if (!dataReader.IsDBNull(12)) item.MESSAGE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) item.MSG_ID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) item.MSG_STATUS = int.Parse(dataReader.GetValue(14).ToString());
                    if (!dataReader.IsDBNull(15)) item.PARENT_DOCTOR = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) item.PATIENT_ID = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) item.PATIENT_NAME = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) item.POINT = float.Parse(dataReader.GetValue(18).ToString());
                    if (!dataReader.IsDBNull(19)) item.POINT_TYPE = int.Parse(dataReader.GetValue(19).ToString());
                    if (!dataReader.IsDBNull(20)) item.QA_EVENT_TYPE = dataReader.GetString(20);
                    if (!dataReader.IsDBNull(21)) item.QCDOC_TYPE = int.Parse(dataReader.GetValue(21).ToString());
                    if (!dataReader.IsDBNull(22)) item.QC_MODULE = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) item.QC_MSG_CODE = dataReader.GetString(23);
                    if (!dataReader.IsDBNull(24)) item.SUPER_DOCTOR = dataReader.GetString(24);
                    if (!dataReader.IsDBNull(25)) item.TOPIC = dataReader.GetString(25);
                    if (!dataReader.IsDBNull(26)) item.TOPIC_ID = dataReader.GetString(26);
                    if (!dataReader.IsDBNull(27)) item.VISIT_ID = dataReader.GetString(27);
                    if (!dataReader.IsDBNull(28)) item.VISIT_NO = dataReader.GetString(28);
                    lstQcMsg.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// <summary>
        /// 获取全院或者某个科室内指定时间范围内的问题清单
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="dateBegin">开始日期</param>
        /// <param name="dateEnd">终止日期</param>
        /// <param name="szOrderValue">排序值，默认为问题类型</param>
        /// <param name="lstQcMsg">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetMedicalQcMsgList(string szPatientID, string szVisitID, ref List<MedicalQcMsg> lstQcMsg)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28}"
                , SystemData.MedicalQcMsgTable.APPLY_ENV
                , SystemData.MedicalQcMsgTable.ASK_DATE_TIME
                , SystemData.MedicalQcMsgTable.CREATOR_ID
                , SystemData.MedicalQcMsgTable.DEPT_NAME
                , SystemData.MedicalQcMsgTable.DEPT_STAYED
                , SystemData.MedicalQcMsgTable.DOCTOR_COMMENT
                , SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE
                , SystemData.MedicalQcMsgTable.ISSUED_BY
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
                , SystemData.MedicalQcMsgTable.ISSUED_ID
                , SystemData.MedicalQcMsgTable.ISSUED_TYPE
                , SystemData.MedicalQcMsgTable.LOCK_STATUS
                , SystemData.MedicalQcMsgTable.MESSAGE
                , SystemData.MedicalQcMsgTable.MSG_ID
                , SystemData.MedicalQcMsgTable.MSG_STATUS
                , SystemData.MedicalQcMsgTable.PARENT_DOCTOR
                , SystemData.MedicalQcMsgTable.PATIENT_ID
                , SystemData.MedicalQcMsgTable.PATIENT_NAME
                , SystemData.MedicalQcMsgTable.POINT
                , SystemData.MedicalQcMsgTable.POINT_TYPE
                , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.QCDOC_TYPE
                , SystemData.MedicalQcMsgTable.QC_MODULE
                , SystemData.MedicalQcMsgTable.QC_MSG_CODE
                , SystemData.MedicalQcMsgTable.SUPER_DOCTOR
                , SystemData.MedicalQcMsgTable.TOPIC
                , SystemData.MedicalQcMsgTable.TOPIC_ID
                , SystemData.MedicalQcMsgTable.VISIT_ID
                , SystemData.MedicalQcMsgTable.VISIT_NO);

            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1}='{2}' AND {3}='{4}'"
                , szCondition
                , SystemData.MedicalQcMsgTable.PATIENT_ID, szPatientID
                , SystemData.MedicalQcMsgTable.VISIT_ID, szVisitID);
            string szTable = string.Format("{0}", SystemData.DataTable.MEDICAL_QC_MSG);

            string szOrderBy = string.Format("{0},{1},{2},{3}",
                SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.PATIENT_ID, SystemData.MedicalQcMsgTable.VISIT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition
                , szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsg == null)
                    lstQcMsg = new List<MedicalQcMsg>();
                do
                {
                    MedicalQcMsg item = new MedicalQcMsg();
                    if (!dataReader.IsDBNull(0)) item.APPLY_ENV = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) item.ASK_DATE_TIME = dataReader.GetDateTime(1);
                    if (!dataReader.IsDBNull(2)) item.CREATOR_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) item.DEPT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) item.DEPT_STAYED = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) item.DOCTOR_COMMENT = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) item.DOCTOR_IN_CHARGE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) item.ISSUED_BY = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) item.ISSUED_DATE_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) item.ISSUED_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) item.ISSUED_TYPE = int.Parse(dataReader.GetValue(10).ToString());
                    if (!dataReader.IsDBNull(11)) item.LOCK_STATUS = dataReader.GetValue(11).ToString() == "1";
                    if (!dataReader.IsDBNull(12)) item.MESSAGE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) item.MSG_ID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) item.MSG_STATUS = int.Parse(dataReader.GetValue(14).ToString());
                    if (!dataReader.IsDBNull(15)) item.PARENT_DOCTOR = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) item.PATIENT_ID = dataReader.GetString(16);
                    if (!dataReader.IsDBNull(17)) item.PATIENT_NAME = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) item.POINT = float.Parse(dataReader.GetValue(18).ToString());
                    if (!dataReader.IsDBNull(19)) item.POINT_TYPE = int.Parse(dataReader.GetValue(19).ToString());
                    if (!dataReader.IsDBNull(20)) item.QA_EVENT_TYPE = dataReader.GetString(20);
                    if (!dataReader.IsDBNull(21)) item.QCDOC_TYPE = int.Parse(dataReader.GetValue(21).ToString());
                    if (!dataReader.IsDBNull(22)) item.QC_MODULE = dataReader.GetString(22);
                    if (!dataReader.IsDBNull(23)) item.QC_MSG_CODE = dataReader.GetString(23);
                    if (!dataReader.IsDBNull(24)) item.SUPER_DOCTOR = dataReader.GetString(24);
                    if (!dataReader.IsDBNull(25)) item.TOPIC = dataReader.GetString(25);
                    if (!dataReader.IsDBNull(26)) item.TOPIC_ID = dataReader.GetString(26);
                    if (!dataReader.IsDBNull(27)) item.VISIT_ID = dataReader.GetString(27);
                    if (!dataReader.IsDBNull(28)) item.VISIT_NO = dataReader.GetString(28);
                    lstQcMsg.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// <summary>
        /// 获取整改通知书
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetMedicalQcMsgs(string szModifyNoticeID, ref List<MedicalQcMsg> lstMedicalQcMsg)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.MODIFY_NOTICE_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.APPLY_ENV);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.ASK_DATE_TIME);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.CREATOR_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.DEPT_STAYED);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.DOCTOR_COMMENT);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.ISSUED_BY);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.ISSUED_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.ISSUED_TYPE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.LOCK_STATUS);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.MESSAGE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.MODIFY_NOTICE_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.MSG_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.MSG_STATUS);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.PARENT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.POINT);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.POINT_TYPE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.QA_EVENT_TYPE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.QCDOC_TYPE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.QC_MODULE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.QC_MSG_CODE);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.SUPER_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.TOPIC);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.TOPIC_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.VISIT_ID);
            sbField.AppendFormat("{0},", SystemData.MedicalQcMsgTable.ERROR_COUNT);
            sbField.AppendFormat("{0}", SystemData.MedicalQcMsgTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = {2}"
                , szCondition
                , SystemData.MedicalQcMsgTable.MODIFY_NOTICE_ID
                , szModifyNoticeID);
            string szOrderBy = string.Format("{0}", SystemData.MedicalQcMsgTable.MSG_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable.MEDICAL_QC_MSG, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstMedicalQcMsg == null)
                    lstMedicalQcMsg = new List<MedicalQcMsg>();
                do
                {
                    MedicalQcMsg medicalQcMsg = new MedicalQcMsg();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.MedicalQcMsgTable.APPLY_ENV:
                                medicalQcMsg.APPLY_ENV = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.ASK_DATE_TIME:
                                medicalQcMsg.ASK_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MedicalQcMsgTable.CREATOR_ID:
                                medicalQcMsg.CREATOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.DEPT_NAME:
                                medicalQcMsg.DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.DEPT_STAYED:
                                medicalQcMsg.DEPT_STAYED = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.DOCTOR_COMMENT:
                                medicalQcMsg.DOCTOR_COMMENT = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE:
                                medicalQcMsg.DOCTOR_IN_CHARGE = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.ISSUED_BY:
                                medicalQcMsg.ISSUED_BY = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME:
                                medicalQcMsg.ISSUED_DATE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.MedicalQcMsgTable.ISSUED_ID:
                                medicalQcMsg.ISSUED_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.ISSUED_TYPE:
                                medicalQcMsg.ISSUED_TYPE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MedicalQcMsgTable.ERROR_COUNT:
                                medicalQcMsg.ERROR_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MedicalQcMsgTable.LOCK_STATUS:
                                medicalQcMsg.LOCK_STATUS = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.MedicalQcMsgTable.MESSAGE:
                                medicalQcMsg.MESSAGE = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.MODIFY_NOTICE_ID:
                                medicalQcMsg.MODIFY_NOTICE_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.MedicalQcMsgTable.MSG_ID:
                                medicalQcMsg.MSG_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.MSG_STATUS:
                                medicalQcMsg.MSG_STATUS = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MedicalQcMsgTable.PARENT_DOCTOR:
                                medicalQcMsg.PARENT_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.PATIENT_ID:
                                medicalQcMsg.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.PATIENT_NAME:
                                medicalQcMsg.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.POINT:
                                medicalQcMsg.POINT = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MedicalQcMsgTable.POINT_TYPE:
                                medicalQcMsg.POINT_TYPE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MedicalQcMsgTable.QA_EVENT_TYPE:
                                medicalQcMsg.QA_EVENT_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.QCDOC_TYPE:
                                medicalQcMsg.QCDOC_TYPE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.MedicalQcMsgTable.QC_MODULE:
                                medicalQcMsg.QC_MODULE = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.QC_MSG_CODE:
                                medicalQcMsg.QC_MSG_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.SUPER_DOCTOR:
                                medicalQcMsg.SUPER_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.TOPIC:
                                medicalQcMsg.TOPIC = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.TOPIC_ID:
                                medicalQcMsg.TOPIC_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.VISIT_ID:
                                medicalQcMsg.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.MedicalQcMsgTable.VISIT_NO:
                                medicalQcMsg.VISIT_NO = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstMedicalQcMsg.Add(medicalQcMsg);
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
        #endregion


        /// <summary>
        /// 病历质控系统,保存一条病案质量监控信息
        /// </summary>
        /// <param name="medicalQcMsg">病案质量监控信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(MedicalQcMsg medicalQcMsg)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            medicalQcMsg.APPLY_ENV = "MEDDOC";
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30}"
               , SystemData.MedicalQcMsgTable.APPLY_ENV
               , SystemData.MedicalQcMsgTable.ASK_DATE_TIME
               , SystemData.MedicalQcMsgTable.CREATOR_ID
               , SystemData.MedicalQcMsgTable.DEPT_NAME
               , SystemData.MedicalQcMsgTable.DEPT_STAYED
               , SystemData.MedicalQcMsgTable.DOCTOR_COMMENT
               , SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE
               , SystemData.MedicalQcMsgTable.ISSUED_BY
               , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
               , SystemData.MedicalQcMsgTable.ISSUED_ID
               , SystemData.MedicalQcMsgTable.ISSUED_TYPE
               , SystemData.MedicalQcMsgTable.LOCK_STATUS
               , SystemData.MedicalQcMsgTable.MESSAGE
               , SystemData.MedicalQcMsgTable.MSG_ID
               , SystemData.MedicalQcMsgTable.MSG_STATUS
               , SystemData.MedicalQcMsgTable.PARENT_DOCTOR
               , SystemData.MedicalQcMsgTable.PATIENT_ID
               , SystemData.MedicalQcMsgTable.PATIENT_NAME
               , SystemData.MedicalQcMsgTable.POINT
               , SystemData.MedicalQcMsgTable.POINT_TYPE
               , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
               , SystemData.MedicalQcMsgTable.QCDOC_TYPE
               , SystemData.MedicalQcMsgTable.QC_MODULE
               , SystemData.MedicalQcMsgTable.QC_MSG_CODE
               , SystemData.MedicalQcMsgTable.SUPER_DOCTOR
               , SystemData.MedicalQcMsgTable.TOPIC
               , SystemData.MedicalQcMsgTable.TOPIC_ID
               , SystemData.MedicalQcMsgTable.VISIT_ID
               , SystemData.MedicalQcMsgTable.VISIT_NO
               , SystemData.MedicalQcMsgTable.MODIFY_NOTICE_ID
               , SystemData.MedicalQcMsgTable.ERROR_COUNT);

            string szValue = string.Format("'{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}',{10},'{11}','{12}','{13}',{14},'{15}','{16}','{17}',{18},{19},'{20}',{21},'{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}',{30}"
                , medicalQcMsg.APPLY_ENV
                , base.QCAccess.GetSqlTimeFormat(medicalQcMsg.ASK_DATE_TIME)
                , medicalQcMsg.CREATOR_ID
                , medicalQcMsg.DEPT_NAME
                , medicalQcMsg.DEPT_STAYED
                , medicalQcMsg.DOCTOR_COMMENT
                , medicalQcMsg.DOCTOR_IN_CHARGE
                , medicalQcMsg.ISSUED_BY
                , base.QCAccess.GetSqlTimeFormat(medicalQcMsg.ISSUED_DATE_TIME)
                , medicalQcMsg.ISSUED_ID
                , medicalQcMsg.ISSUED_TYPE
                , medicalQcMsg.LOCK_STATUS ? 1 : 0
                , medicalQcMsg.MESSAGE
                , medicalQcMsg.MSG_ID
                , medicalQcMsg.MSG_STATUS
                , medicalQcMsg.PARENT_DOCTOR
                , medicalQcMsg.PATIENT_ID
                , medicalQcMsg.PATIENT_NAME
                , medicalQcMsg.POINT
                , medicalQcMsg.POINT_TYPE
                , medicalQcMsg.QA_EVENT_TYPE
                , medicalQcMsg.QCDOC_TYPE
                , medicalQcMsg.QC_MODULE
                , medicalQcMsg.QC_MSG_CODE
                , medicalQcMsg.SUPER_DOCTOR
                , medicalQcMsg.TOPIC
                , medicalQcMsg.TOPIC_ID
                , medicalQcMsg.VISIT_ID
                , medicalQcMsg.VISIT_NO
                , medicalQcMsg.MODIFY_NOTICE_ID
                , medicalQcMsg.ERROR_COUNT);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.MEDICAL_QC_MSG, szField, szValue);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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

        /// <summary>
        /// 病历质控系统,修改一条病案质量监控信息
        /// </summary>
        /// <param name="qcQuestionInfo">病案质量监控信息</param>
        /// <param name="dtCheckTime">质检查时间</param>
        /// <param name="szMessageCode">旧的监控信息代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(MedicalQcMsg qcQuestionInfo)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}={3},{4}='{5}',{6}='{7}',{8}='{9}',{10}='{11}',{12}='{13}',{14}='{15}',{16}={17},{18}='{19}',{20}='{21}',{22}={23},{24}='{25}',{26}={27},{28}='{29}',{30}='{31}',{32}='{33}',{34}={35},{36}={37},{38}='{39}',{40}={41},{42}='{43}',{44}='{45}',{46}='{47}',{48}='{49}',{50}='{51}',{52}='{53}',{54}='{55}'"
                , SystemData.MedicalQcMsgTable.APPLY_ENV, qcQuestionInfo.APPLY_ENV
                , SystemData.MedicalQcMsgTable.ASK_DATE_TIME, base.QCAccess.GetSqlTimeFormat(qcQuestionInfo.ASK_DATE_TIME)
                , SystemData.MedicalQcMsgTable.CREATOR_ID, qcQuestionInfo.CREATOR_ID
                , SystemData.MedicalQcMsgTable.DEPT_NAME, qcQuestionInfo.DEPT_NAME
                , SystemData.MedicalQcMsgTable.DEPT_STAYED, qcQuestionInfo.DEPT_STAYED
                , SystemData.MedicalQcMsgTable.DOCTOR_COMMENT, qcQuestionInfo.DOCTOR_COMMENT
                , SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE, qcQuestionInfo.DOCTOR_IN_CHARGE
                , SystemData.MedicalQcMsgTable.ISSUED_BY, qcQuestionInfo.ISSUED_BY
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.QCAccess.GetSqlTimeFormat(qcQuestionInfo.ISSUED_DATE_TIME)
                , SystemData.MedicalQcMsgTable.ISSUED_ID, qcQuestionInfo.ISSUED_ID
                , SystemData.MedicalQcMsgTable.ISSUED_TYPE, qcQuestionInfo.ISSUED_TYPE
                , SystemData.MedicalQcMsgTable.LOCK_STATUS, qcQuestionInfo.LOCK_STATUS ? 1 : 0
                , SystemData.MedicalQcMsgTable.MESSAGE, qcQuestionInfo.MESSAGE
                , SystemData.MedicalQcMsgTable.MSG_STATUS, qcQuestionInfo.MSG_STATUS
                , SystemData.MedicalQcMsgTable.PARENT_DOCTOR, qcQuestionInfo.PARENT_DOCTOR
                , SystemData.MedicalQcMsgTable.PATIENT_ID, qcQuestionInfo.PATIENT_ID
                , SystemData.MedicalQcMsgTable.PATIENT_NAME, qcQuestionInfo.PATIENT_NAME
                , SystemData.MedicalQcMsgTable.POINT, qcQuestionInfo.POINT
                , SystemData.MedicalQcMsgTable.POINT_TYPE, qcQuestionInfo.POINT_TYPE
                , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE, qcQuestionInfo.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.QCDOC_TYPE, qcQuestionInfo.QCDOC_TYPE
                , SystemData.MedicalQcMsgTable.QC_MODULE, qcQuestionInfo.QC_MODULE
                , SystemData.MedicalQcMsgTable.QC_MSG_CODE, qcQuestionInfo.QC_MSG_CODE
                , SystemData.MedicalQcMsgTable.SUPER_DOCTOR, qcQuestionInfo.SUPER_DOCTOR
                , SystemData.MedicalQcMsgTable.TOPIC, qcQuestionInfo.TOPIC
                , SystemData.MedicalQcMsgTable.TOPIC_ID, qcQuestionInfo.TOPIC_ID
                , SystemData.MedicalQcMsgTable.VISIT_ID, qcQuestionInfo.VISIT_ID
                , SystemData.MedicalQcMsgTable.VISIT_NO, qcQuestionInfo.VISIT_NO);

            string szCondition = string.Format("{0}='{1}'", SystemData.MedicalQcMsgTable.MSG_ID, qcQuestionInfo.MSG_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.MEDICAL_QC_MSG, szField, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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

        /// <summary>
        /// 病历质控系统,修改一条病案质量监控信息
        /// </summary>
        /// <param name="qcQuestionInfo">病案质量监控信息</param>
        /// <param name="dtCheckTime">质检查时间</param>
        /// <param name="szMessageCode">旧的监控信息代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateMesageLockStatus(bool nLockStatus, string szMsgID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}={1}"
                , SystemData.MedicalQcMsgTable.LOCK_STATUS, nLockStatus ? 1 : 0);

            string szCondition = string.Format("{0}='{1}'", SystemData.MedicalQcMsgTable.MSG_ID, szMsgID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.MEDICAL_QC_MSG, szField, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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

        /// <summary>
        ///  删除质检信息
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szMsgID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szMsgID))
            {
                LogManager.Instance.WriteLog("MedicalQcMsgAccess.Delete", new string[] { "szEventType" }
                    , new object[] { szMsgID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.MedicalQcMsgTable.MSG_ID, szMsgID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.MEDICAL_QC_MSG, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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

        /// <summary>
        /// 按质量问题分类统计反馈信息
        /// </summary>
        /// <param name="szDeptName">科室名称</param>
        /// <param name="szEventType">质量问题分类</param>
        /// <param name="userID">用户ID</param>
        /// <param name="dataBegin">起始时间</param>
        /// <param name="dataEnd">终止时间</param>
        /// <param name="lstQuestionInfo">返回列表</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetQCQuestionListByQaEventType(string szDeptName, string szEventType, string szUserID, DateTime dateBegin, DateTime dateEnd
            , ref List<EMRDBLib.MedicalQcMsg> lstQuestionInfo)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("B.{0},C.{1},B.{2},A.{3},B.{4},B.{5},B.{6},B.{7},B.{8},B.{9},B.{10},B.{11},B.{12},B.{13},B.{14},B.{15}",
                                SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.DeptView.DEPT_NAME, SystemData.MedicalQcMsgTable.PATIENT_ID,
                                SystemData.PatVisitView.PATIENT_NAME, SystemData.MedicalQcMsgTable.MESSAGE, SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE,
                                SystemData.MedicalQcMsgTable.ISSUED_BY, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, SystemData.MedicalQcMsgTable.ASK_DATE_TIME,
                                SystemData.MedicalQcMsgTable.QC_MSG_CODE, SystemData.MedicalQcMsgTable.VISIT_ID, SystemData.MedicalQcMsgTable.QA_EVENT_TYPE,
                                SystemData.MedicalQcMsgTable.MSG_STATUS, SystemData.MedicalQcMsgTable.PARENT_DOCTOR, SystemData.MedicalQcMsgTable.MSG_ID,
                                SystemData.MedicalQcMsgTable.TOPIC_ID);
            string szCondition = string.Format("A.{0} = B.{1} AND A.{2}=B.{2} AND B.{3} = C.{4} AND B.{5} >= {6} AND B.{7} < {8}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.MedicalQcMsgTable.PATIENT_ID, SystemData.MedicalQcMsgTable.VISIT_ID
                , SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.DeptView.DEPT_CODE, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
                , base.QCAccess.GetSqlTimeFormat(dateBegin), SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.QCAccess.GetSqlTimeFormat(dateEnd));
            szCondition = string.Format("{0} AND {1}='IP'", szCondition, SystemData.PatVisitView.VISIT_TYPE);
            if (!GlobalMethods.Misc.IsEmptyString(szEventType))
                szCondition = string.Format(" {0} AND B.{1}='{2}'", szCondition, SystemData.MedicalQcMsgTable.QA_EVENT_TYPE, szEventType);
            if (!GlobalMethods.Misc.IsEmptyString(szUserID))
                szCondition = string.Format(" {0} AND B.{1}='{2}'", szCondition, SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE, szUserID);
            if (!GlobalMethods.Misc.IsEmptyString(szDeptName))
                szCondition = string.Format("{0} AND C.{1}='{2}'", szCondition, SystemData.DeptView.DEPT_NAME, szDeptName);
            szCondition = string.Format("{0} AND {1}='IP' AND B.{2}='MEDDOC' ", szCondition, SystemData.PatVisitView.VISIT_TYPE, SystemData.MedicalQcMsgTable.APPLY_ENV);
            string szTable = string.Format("{0} A,{1} B,{2} C"
                , SystemData.DataView.PAT_VISIT_V, SystemData.DataView.QC_MSG_V, SystemData.DataView.DEPT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQuestionInfo == null)
                    lstQuestionInfo = new List<MedicalQcMsg>();
                do
                {
                    MedicalQcMsg qcQuestionInfo = new MedicalQcMsg();
                    if (!dataReader.IsDBNull(0)) qcQuestionInfo.DEPT_STAYED = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) qcQuestionInfo.DEPT_NAME = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) qcQuestionInfo.PATIENT_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcQuestionInfo.PATIENT_NAME = dataReader.GetValue(3).ToString();
                    if (!dataReader.IsDBNull(4)) qcQuestionInfo.MESSAGE = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcQuestionInfo.DOCTOR_IN_CHARGE = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcQuestionInfo.ISSUED_BY = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcQuestionInfo.ISSUED_DATE_TIME = dataReader.GetDateTime(7);
                    if (!dataReader.IsDBNull(8)) qcQuestionInfo.ASK_DATE_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) qcQuestionInfo.QC_MSG_CODE = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) qcQuestionInfo.VISIT_ID = dataReader.GetValue(10).ToString();
                    if (!dataReader.IsDBNull(11)) qcQuestionInfo.QA_EVENT_TYPE = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) qcQuestionInfo.MSG_STATUS = int.Parse(dataReader.GetValue(12).ToString());
                    if (!dataReader.IsDBNull(13)) qcQuestionInfo.PARENT_DOCTOR = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) qcQuestionInfo.MSG_ID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) qcQuestionInfo.TOPIC_ID = dataReader.GetString(15);
                    lstQuestionInfo.Add(qcQuestionInfo);
                } while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCQuestionListByQaEventType", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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

        /// <summary>
        /// 获取指定时间范围内指定检查者检查的问题清单
        /// </summary>
        /// <param name="szChecker">检查者</param>
        /// <param name="dateBegin">开始日期</param>
        /// <param name="dateEnd">终止日期</param>
        /// <param name="lstQCQuestionInfos">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCQuestionListByChecker(string szChecker, DateTime dateBegin, DateTime dateEnd, ref List<MedicalQcMsg> lstQCQuestionInfos)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},B.{1},A.{2},C.{3},A.{4},A.{5},A.{6},A.{7},A.{8},C.{9},C.{10},C.{11},A.{12},A.{13},A.{14},A.{15},A.{16}",
                SystemData.MedicalQcMsgTable.DEPT_STAYED
                , SystemData.DeptView.DEPT_NAME, SystemData.MedicalQcMsgTable.PATIENT_ID,
                SystemData.PatVisitView.PATIENT_NAME, SystemData.MedicalQcMsgTable.MESSAGE, SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE,
                SystemData.MedicalQcMsgTable.ISSUED_BY, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, SystemData.MedicalQcMsgTable.ASK_DATE_TIME,
                SystemData.PatVisitView.INP_NO, SystemData.PatVisitView.DIAGNOSIS
                , SystemData.PatVisitView.VISIT_ID
                , SystemData.MedicalQcMsgTable.PARENT_DOCTOR
                , SystemData.MedicalQcMsgTable.MSG_ID
                , SystemData.MedicalQcMsgTable.TOPIC_ID
                , SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.MedicalQcMsgTable.TOPIC);
            string szCondition = string.Format("C.{0}=A.{1} AND C.{2}=A.{2} AND A.{3}=B.{4} AND A.{5} >= {6} AND A.{7} <  {8} "
                , SystemData.PatVisitView.PATIENT_ID, SystemData.MedicalQcMsgTable.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.DeptView.DEPT_CODE, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
                , base.QCAccess.GetSqlTimeFormat(dateBegin), SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.QCAccess.GetSqlTimeFormat(dateEnd));
            if (!string.IsNullOrEmpty(szChecker.Trim()))
            {
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.MedicalQcMsgTable.ISSUED_BY, szChecker.Trim());
            }
            szCondition = string.Format("{0} AND {1}='IP' AND A.{2}='MEDDOC' ", szCondition, SystemData.PatVisitView.VISIT_TYPE, SystemData.MedicalQcMsgTable.APPLY_ENV);
            string szTable = string.Format("{0} A,{1} B,{2} C"
                , SystemData.DataView.QC_MSG_V, SystemData.DataView.DEPT_V, SystemData.DataView.PAT_VISIT_V);
            string szSort = string.Format("B.{0},C.{1}", SystemData.DeptView.DEPT_NAME, SystemData.PatVisitView.PATIENT_NAME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szSort);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCQuestionInfos == null)
                    lstQCQuestionInfos = new List<MedicalQcMsg>();
                do
                {
                    MedicalQcMsg qcQuestionInfo = new MedicalQcMsg();
                    if (!dataReader.IsDBNull(0)) qcQuestionInfo.DEPT_STAYED = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) qcQuestionInfo.DEPT_NAME = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) qcQuestionInfo.PATIENT_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcQuestionInfo.PATIENT_NAME = dataReader.GetValue(3).ToString();
                    if (!dataReader.IsDBNull(4)) qcQuestionInfo.MESSAGE = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcQuestionInfo.DOCTOR_IN_CHARGE = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcQuestionInfo.ISSUED_BY = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcQuestionInfo.ISSUED_DATE_TIME = dataReader.GetDateTime(7);
                    if (!dataReader.IsDBNull(8)) qcQuestionInfo.ASK_DATE_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) qcQuestionInfo.InpNo = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) qcQuestionInfo.Diagnosis = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) qcQuestionInfo.VISIT_ID = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) qcQuestionInfo.PARENT_DOCTOR = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) qcQuestionInfo.MSG_ID = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) qcQuestionInfo.TOPIC_ID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) qcQuestionInfo.QA_EVENT_TYPE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) qcQuestionInfo.TOPIC = dataReader.GetString(16);
                    lstQCQuestionInfos.Add(qcQuestionInfo);
                } while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCQuestionListByChecker", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
