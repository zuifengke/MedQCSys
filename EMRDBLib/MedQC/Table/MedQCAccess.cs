// ***********************************************************
// 数据库访问层与病历内容质控有关的数据的访问类.
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class MedQCAccess : DBAccessBase
    {
        private static MedQCAccess m_Instance = null;
        public static MedQCAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new MedQCAccess();
                return m_Instance;
            }
        }
        #region"质控反馈问题统计相关接口"
        /// <summary>
        /// 按问题类型统计质量问题
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="dateBegin">起始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="lstQCTypeStatInfos">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCStatisticsByType(string szDeptCode, DateTime dateBegin, DateTime dateEnd, ref List<QCTypeStatInfo> lstQCTypeStatInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},B.{1},C.{2},count(*)", SystemData.MedicalQcMsgTable.QA_EVENT_TYPE
                , SystemData.QcMsgDictTable.MESSAGE, SystemData.DeptView.DEPT_NAME);
            string szCondition = string.Format("A.{0} = B.{1} AND A.{2}=C.{3} AND A.{4} >= {5} AND A.{6} < {7} AND A.{8}='MEDDOC' "
                , SystemData.MedicalQcMsgTable.QC_MSG_CODE, SystemData.QcMsgDictTable.QC_MSG_CODE
                , SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.DeptView.DEPT_CODE
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dateBegin)
                , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dateEnd)
                , SystemData.MedicalQcMsgTable.APPLY_ENV);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.MedicalQcMsgTable.DEPT_STAYED, szDeptCode);
            string szTable = string.Format("{0} A,{1} B,{2} C"
                , SystemData.DataView.QC_MSG_V, SystemData.DataTable.QC_MSG_DICT, SystemData.DataView.DEPT_V);
            string szGroup = string.Format("A.{0}, B.{1},C.{2}", SystemData.MedicalQcMsgTable.QA_EVENT_TYPE, SystemData.QcMsgDictTable.MESSAGE
                , SystemData.DeptView.DEPT_NAME);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM_WHERE_GROUP, szField, szTable, szCondition, szGroup);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCTypeStatInfos == null)
                    lstQCTypeStatInfos = new List<QCTypeStatInfo>();
                do
                {
                    QCTypeStatInfo qcTypeStatInfo = new QCTypeStatInfo();
                    if (!dataReader.IsDBNull(0)) qcTypeStatInfo.QuestionType = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) qcTypeStatInfo.QuestionMsg = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) qcTypeStatInfo.DeptName = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcTypeStatInfo.Count = dataReader.GetValue(3).ToString();
                    lstQCTypeStatInfos.Add(qcTypeStatInfo);
                } while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCStatisticsByType", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 按科室统计质量问题
        /// </summary>
        /// <param name="dateBegin">起始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="lstQCDeptStatInfos">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCStatisticsByDept(string szDeptCode, DateTime dateBegin, DateTime dateEnd, ref List<QCDeptStatInfo> lstQCDeptStatInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("B.{0},C.{1},B.{2},A.{3},B.{4},B.{5},B.{6},B.{7},B.{8},B.{9},B.{10},B.{11},A.{12},A.{13},B.{14}",
                                SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.DeptView.DEPT_NAME, SystemData.MedicalQcMsgTable.PATIENT_ID,
                                SystemData.PatVisitView.PATIENT_NAME, SystemData.MedicalQcMsgTable.MESSAGE, SystemData.MedicalQcMsgTable.DOCTOR_IN_CHARGE,
                                SystemData.MedicalQcMsgTable.ISSUED_BY, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, SystemData.MedicalQcMsgTable.ASK_DATE_TIME,
                                SystemData.MedicalQcMsgTable.PARENT_DOCTOR, SystemData.MedicalQcMsgTable.SUPER_DOCTOR, SystemData.MedicalQcMsgTable.TOPIC_ID,
                                SystemData.MedicalQcMsgTable.VISIT_ID, SystemData.PatVisitView.INP_NO, SystemData.MedicalQcMsgTable.QA_EVENT_TYPE);
            string szCondition = string.Format("A.{0} = B.{1} AND A.{2}=B.{2} AND B.{3} = C.{4} AND B.{5} >= {6} AND B.{7} < {8}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.MedicalQcMsgTable.PATIENT_ID, SystemData.MedicalQcMsgTable.VISIT_ID
                , SystemData.MedicalQcMsgTable.DEPT_STAYED, SystemData.DeptView.DEPT_CODE, SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME
                , base.MedQCAccess.GetSqlTimeFormat(dateBegin), SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND C.{1}='{2}'", szCondition, SystemData.DeptView.DEPT_CODE, szDeptCode);
            szCondition = string.Format("{0} AND {1}='IP' AND B.{2}='MEDDOC' ", szCondition, SystemData.PatVisitView.VISIT_TYPE, SystemData.MedicalQcMsgTable.APPLY_ENV);
            string szTable = string.Format("{0} A,{1} B,{2} C"
                , SystemData.DataView.PAT_VISIT_V, SystemData.DataView.QC_MSG_V, SystemData.DataView.DEPT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, "C.DEPT_NAME, A.PATIENT_NAME");

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCDeptStatInfos == null)
                    lstQCDeptStatInfos = new List<QCDeptStatInfo>();
                do
                {
                    QCDeptStatInfo clsQCDeptStatInfo = new QCDeptStatInfo();
                    if (!dataReader.IsDBNull(0)) clsQCDeptStatInfo.Dept_Code = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) clsQCDeptStatInfo.Dept_Name = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) clsQCDeptStatInfo.PatientID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) clsQCDeptStatInfo.PatientName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) clsQCDeptStatInfo.Message = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) clsQCDeptStatInfo.DoctorInCharge = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) clsQCDeptStatInfo.CheckerName = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) clsQCDeptStatInfo.CheckTime = dataReader.GetDateTime(7);
                    if (!dataReader.IsDBNull(8)) clsQCDeptStatInfo.ConfirmTime = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) clsQCDeptStatInfo.ParentDoctor = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) clsQCDeptStatInfo.SuperDoctor = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) clsQCDeptStatInfo.DocSetID = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) clsQCDeptStatInfo.VisitID = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) clsQCDeptStatInfo.InpNo = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) clsQCDeptStatInfo.QaEventType = dataReader.GetString(14);
                    lstQCDeptStatInfos.Add(clsQCDeptStatInfo);
                } while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCStatisticsByDept", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 按工作量统计
        /// </summary>
        /// <param name="szCheckerName">检查者姓名</param>
        /// <param name="dateBegin">起始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="lstQCWorkloadStatInfos">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCStatisticsByWorkload(string szCheckerID, DateTime dateBegin, DateTime dateEnd
            , ref List<QCWorkloadStatInfo> lstQCWorkloadStatInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0}, count( distinct rpad({1},10,' ') || to_char({2},'99') ), count(*), 0,A.{3}"
                , SystemData.MedicalQCLogTable.CHECKED_BY
                , SystemData.MedicalQCLogTable.PATIENT_ID
                , SystemData.MedicalQCLogTable.VISIT_ID
                , SystemData.MedicalQCLogTable.CHECKED_ID);
            string szCondition = string.Format("A.{0} >= to_date('{1}','yyyy-mm-dd') AND A.{2} < (to_date('{3}','yyyy-mm-dd') + 1)"
                , SystemData.MedicalQCLogTable.CHECK_DATE, dateBegin.ToString("yyyy-MM-dd")
                , SystemData.MedicalQCLogTable.CHECK_DATE, dateEnd.ToString("yyyy-MM-dd"));
            szCondition = string.Format("{0} AND ({1}=1 OR {1} IS NULL)  and check_type = 5"
                , szCondition
                , SystemData.MedicalQCLogTable.LOG_TYPE);
            if (!string.IsNullOrEmpty(szCheckerID))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.MedicalQCLogTable.CHECKED_ID, szCheckerID);

            string szTable = string.Format("{0} A", SystemData.DataTable.MEDICAL_QC_LOG);
            string szGroup = string.Format("A.{0},A.{1}"
                , SystemData.MedicalQCLogTable.CHECKED_BY
                , SystemData.MedicalQCLogTable.CHECKED_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM_WHERE_GROUP, szField, szTable, szCondition, szGroup);


            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCWorkloadStatInfos == null)
                    lstQCWorkloadStatInfos = new List<QCWorkloadStatInfo>();
                do
                {
                    QCWorkloadStatInfo clsQCWorkloadStatInfo = new QCWorkloadStatInfo();
                    if (!dataReader.IsDBNull(0)) clsQCWorkloadStatInfo.CheckerName = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) clsQCWorkloadStatInfo.NumOfDoc = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) clsQCWorkloadStatInfo.NumOfCheck = dataReader.GetValue(2).ToString();
                    if (!dataReader.IsDBNull(3)) clsQCWorkloadStatInfo.NumOfQuestion = dataReader.GetValue(3).ToString();
                    if (!dataReader.IsDBNull(4)) clsQCWorkloadStatInfo.CheckerID = dataReader.GetString(4).ToString();
                    lstQCWorkloadStatInfos.Add(clsQCWorkloadStatInfo);
                }
                while (dataReader.Read());

                ///获取问题数
                szField = string.Format("A.{0}, count(*)",
                                    SystemData.MedicalQcMsgTable.ISSUED_ID);
                szCondition = string.Format("A.{0} >= {1} AND A.{2} < {3} AND A.{4}='MEDDOC' "
                    , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dateBegin)
                    , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dateEnd)
                    , SystemData.MedicalQcMsgTable.APPLY_ENV);
                szTable = string.Format("{0} A", SystemData.DataView.QC_MSG_V);
                szGroup = string.Format("A.{0}", SystemData.MedicalQcMsgTable.ISSUED_ID);
                szSQL = string.Format(SystemData.SQL.SELECT_FROM_WHERE_GROUP, szField, szTable, szCondition, szGroup);

                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.OK;
                }
                string szIssedBy = string.Empty;
                do
                {
                    if (!dataReader.IsDBNull(0)) szIssedBy = dataReader.GetString(0);
                    foreach (QCWorkloadStatInfo clsQCWorkloadStatInfo in lstQCWorkloadStatInfos)
                    {
                        if (clsQCWorkloadStatInfo.CheckerID.CompareTo(szIssedBy.Trim()) != 0)
                            continue;
                        if (!dataReader.IsDBNull(1))
                            clsQCWorkloadStatInfo.NumOfQuestion = dataReader.GetValue(1).ToString();
                        break;
                    }
                }
                while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCStatisticsByWorkLoad", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 按科室工作量统计
        /// </summary>
        /// <param name="dateBegin">起始时间</param>
        /// <param name="dateEnd">终止时间</param>
        /// <param name="lstQCWorkloadStatInfos">返回列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCStatisticsByDeptWorkload(string szDeptCode, DateTime dateBegin, DateTime dateEnd, ref List<QCWorkloadStatInfo> lstQCWorkloadStatInfos)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},B.DEPT_NAME, count( distinct rpad({1},10,' ') || to_char({2},'99') ), count(*), 0",
                                SystemData.MedicalQCLogTable.DEPT_STAYED, SystemData.MedicalQCLogTable.PATIENT_ID, SystemData.MedicalQCLogTable.VISIT_ID);
            string szCondition = string.Format("A.{0} >= {1} AND A.{2} < {3} AND A.DEPT_STAYED =B.dept_code"
                , SystemData.MedicalQCLogTable.CHECK_DATE, base.MedQCAccess.GetSqlTimeFormat(dateBegin)
                , SystemData.MedicalQCLogTable.CHECK_DATE, base.MedQCAccess.GetSqlTimeFormat(dateEnd));
            szCondition = string.Format("{0} AND ({1}=0 OR {1} IS NULL) AND ({2}=1 OR {2} IS NULL)", szCondition
                , SystemData.MedicalQCLogTable.CHECK_TYPE, SystemData.MedicalQCLogTable.LOG_TYPE);

            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.DEPT_STAYED='{1}'", szCondition, szDeptCode);
            string szTable = string.Format("{0} A,{1} B", SystemData.DataTable.MEDICAL_QC_LOG, SystemData.DataView.DEPT_V);
            string szGroup = string.Format("A.{0},B.DEPT_NAME", SystemData.MedicalQcMsgTable.DEPT_STAYED);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM_WHERE_GROUP, szField, szTable, szCondition, szGroup);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCWorkloadStatInfos == null)
                    lstQCWorkloadStatInfos = new List<QCWorkloadStatInfo>();
                do
                {
                    QCWorkloadStatInfo clsQCWorkloadStatInfo = new QCWorkloadStatInfo();
                    if (!dataReader.IsDBNull(0)) clsQCWorkloadStatInfo.DeptCode = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) clsQCWorkloadStatInfo.DeptName = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) clsQCWorkloadStatInfo.NumOfDoc = dataReader.GetValue(2).ToString();
                    if (!dataReader.IsDBNull(3)) clsQCWorkloadStatInfo.NumOfCheck = dataReader.GetValue(3).ToString();
                    if (!dataReader.IsDBNull(4)) clsQCWorkloadStatInfo.NumOfQuestion = dataReader.GetValue(4).ToString();
                    lstQCWorkloadStatInfos.Add(clsQCWorkloadStatInfo);
                }
                while (dataReader.Read());

                ///获取问题数
                szField = string.Format("A.{0},B.DEPT_NAME, count(*)",
                                    SystemData.MedicalQcMsgTable.DEPT_STAYED);
                szCondition = string.Format("A.{0} >= {1} AND A.{2} < {3} AND A.DEPT_STAYED =B.dept_code AND A.{4}='MEDDOC' "
                    , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dateBegin)
                    , SystemData.MedicalQcMsgTable.ISSUED_DATE_TIME, base.MedQCAccess.GetSqlTimeFormat(dateEnd)
                    , SystemData.MedicalQcMsgTable.APPLY_ENV);
                if (!string.IsNullOrEmpty(szDeptCode))
                    szCondition = string.Format("{0} AND A.DEPT_STAYED='{1}'", szCondition, szDeptCode);
                szTable = string.Format("{0} A,{1} B", SystemData.DataView.QC_MSG_V, SystemData.DataView.DEPT_V);
                szGroup = string.Format("A.{0},B.DEPT_NAME", SystemData.MedicalQcMsgTable.DEPT_STAYED);
                szSQL = string.Format(SystemData.SQL.SELECT_FROM_WHERE_GROUP, szField, szTable, szCondition, szGroup);

                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                string szDeptBy = string.Empty;
                do
                {
                    if (!dataReader.IsDBNull(0)) szDeptBy = dataReader.GetString(0);
                    foreach (QCWorkloadStatInfo clsQCWorkloadStatInfo in lstQCWorkloadStatInfos)
                    {
                        if (clsQCWorkloadStatInfo.DeptCode.CompareTo(szDeptBy.Trim()) != 0)
                            continue;
                        if (!dataReader.IsDBNull(2))
                            clsQCWorkloadStatInfo.NumOfQuestion = dataReader.GetValue(2).ToString();
                        break;
                    }
                }
                while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCStatisticsByDeptWorkload", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 获取延期未提交病历信息
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="szDischargeDays">出院天数</param>
        ///<param name="lstPatVisitLog">病人就诊信息</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetDelayUnCommitDocInfos(string szDeptCode, string szDischargeDays, ref List<PatVisitInfo> lstPatVisitLog)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7}", SystemData.PatVisitView.DEPT_NAME
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.DISCHARGE_TIME);
            string szCondition = string.Format("A.{0}=B.{0} AND A.{1}=B.{1} AND A.{2} IS NOT NULL AND A.{2}<SYSDATE-{3} AND B.{4}='O'"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID, SystemData.PatVisitView.DISCHARGE_TIME
                , szDischargeDays, SystemData.QCScoreTable.HOS_QCMAN);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1}='{2}'", szCondition, SystemData.PatVisitView.DEPT_CODE, szDeptCode);
            string szTable = string.Format("{0} A,{1} B", SystemData.DataView.PAT_VISIT_V, SystemData.DataTable.QC_SCORE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, SystemData.PatVisitView.DEPT_CODE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLog == null)
                    lstPatVisitLog = new List<PatVisitInfo>();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.DEPT_NAME = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.PATIENT_ID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) patVisitLog.VISIT_ID = dataReader.GetValue(2).ToString();
                    if (!dataReader.IsDBNull(3)) patVisitLog.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.DISCHARGE_TIME = dataReader.GetDateTime(7);
                    lstPatVisitLog.Add(patVisitLog);
                } while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetDelayUnCommitDocInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        #endregion

        /// <summary>
        /// 获取指定病人病案的质控结果状态
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">住院标识</param>
        /// <param name="fScore">病历总扣分</param>
        /// <param name="szQCResultStatus">质控结果状态</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCResultStatus(string szPatientID, string szVisitID, ref float fScore, ref string szQCResultStatus)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = "SELECT COUNT(*) FROM MEDICAL_QC_LOG WHERE PATIENT_ID = '{0}' AND VISIT_ID = {1}";
            szSQL = string.Format(szSQL, szPatientID, szVisitID);

            try
            {
                object objRet = base.MedQCAccess.ExecuteScalar(szSQL, CommandType.Text);
                if (objRet == null || objRet == System.DBNull.Value || int.Parse(objRet.ToString()) <= 0)
                {
                    szQCResultStatus = SystemData.MedQCStatus.NO_CHECK;
                    return SystemData.ReturnValue.OK;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCResultStatus", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }

            szSQL = "SELECT COUNT(*), SUM(POINT) "
                    + "FROM MEDICAL_QC_MSG  "
                    + "WHERE PATIENT_ID = '{0}' AND VISIT_ID = {1} "
                    + "AND APPLY_ENV='MEDDOC' ";
            szSQL = string.Format(szSQL, szPatientID, szVisitID);

            int nMsgCount = 0;
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    szQCResultStatus = SystemData.MedQCStatus.NO_CHECK;
                    return SystemData.ReturnValue.OK;
                }
                if (!dataReader.IsDBNull(0)) nMsgCount = int.Parse(dataReader.GetValue(0).ToString());
                if (!dataReader.IsDBNull(1)) fScore = float.Parse(dataReader.GetValue(1).ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCResultStatus", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
            if (nMsgCount <= 0)
            {
                szQCResultStatus = SystemData.MedQCStatus.PASS;
                return SystemData.ReturnValue.OK;
            }
            else
            {
                szQCResultStatus = SystemData.MedQCStatus.EXIST_BUG;
            }
            if (fScore > (100 - SystemParam.Instance.LocalConfigOption.GradingLow))
            {
                szQCResultStatus = SystemData.MedQCStatus.SERIOUS_BUG;
            }
            return SystemData.ReturnValue.OK;
        }


        /// <summary>
        /// 批量获取病案质量状态
        /// </summary>
        /// <param name="lstPatVisitLogs"></param>
        /// <param name="lstPatVisistQCStatus"></param>
        public short GetQCResultStatus(ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (lstPatVisitLogs == null || lstPatVisitLogs.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitLogs.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') ", lstPatVisitLogs[index].PATIENT_ID, lstPatVisitLogs[index].VISIT_ID);
                if (index != lstPatVisitLogs.Count - 1)
                    sb.Append(" or ");
            }

            string szSQL = "SELECT COUNT(*),PATIENT_ID,VISIT_ID FROM MEDICAL_QC_LOG WHERE " + sb.ToString() + " GROUP BY PATIENT_ID,VISIT_ID";
            IDataReader dataReader = null;
            string szPId = string.Empty;
            string szVId = string.Empty;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL);
                //暂时设置成未检查
                foreach (PatVisitInfo item in lstPatVisitLogs)
                {
                    item.QCResultStatus = SystemData.MedQCStatus.NO_CHECK;
                }
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())//没有查到数据，则这一批都没有检查
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }

                do
                {

                    szPId = string.Empty;
                    szVId = string.Empty;
                    if (!dataReader.IsDBNull(1))
                        szPId = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                    {
                        szVId = dataReader.GetValue(2).ToString();
                    }

                    if (!string.IsNullOrEmpty(szPId) && !string.IsNullOrEmpty(szVId))//判断是否在
                    {
                        PatVisitInfo pat = lstPatVisitLogs.Find(i => i.PATIENT_ID == szPId && i.VISIT_ID == szVId);
                        if (pat != null)
                            pat.QCResultStatus = SystemData.MedQCStatus.PASS;//默认设定为PASS
                    }

                } while (dataReader.Read());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCResultStatus", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            //从已检查的病人中检查质检问题
            sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitLogs.Count; index++)
            {
                if (lstPatVisitLogs[index].QCResultStatus != SystemData.MedQCStatus.PASS)//过滤NO_CHECK，查询暂时设定为PASS的患者
                    continue;
                sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') ", lstPatVisitLogs[index].PATIENT_ID, lstPatVisitLogs[index].VISIT_ID);
                sb.Append(" or ");
            }
            sb.Remove(sb.ToString().LastIndexOf("or"), 2);
            if (sb.Length <= 0)
                return SystemData.ReturnValue.OK;
            szSQL = "SELECT COUNT(*), SUM(POINT) ,PATIENT_ID,VISIT_ID"
                    + " FROM MEDICAL_QC_MSG "
                    + " WHERE  " + sb.ToString()
                    + " AND  MEDICAL_QC_MSG.APPLY_ENV='MEDDOC' "
                    + " GROUP BY PATIENT_ID,VISIT_ID";

            int nMsgCount = 0;
            float fScore = 0.0f;
            dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.OK;
                }
                do
                {
                    if (!dataReader.IsDBNull(0)) nMsgCount = int.Parse(dataReader.GetValue(0).ToString());
                    if (!dataReader.IsDBNull(1)) fScore = float.Parse(dataReader.GetValue(1).ToString());
                    szPId = string.Empty;
                    szVId = string.Empty;
                    if (!dataReader.IsDBNull(2))
                        szPId = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                    {
                        szVId = dataReader.GetValue(3).ToString();
                    }
                    PatVisitInfo pat = lstPatVisitLogs.Find(i => i.PATIENT_ID == szPId && i.VISIT_ID == szVId);
                    if (pat != null)
                    {
                        if (nMsgCount <= 0)
                        {
                            pat.QCResultStatus = SystemData.MedQCStatus.PASS;
                        }
                        else
                        {
                            pat.QCResultStatus = SystemData.MedQCStatus.EXIST_BUG;
                        }
                        if (fScore > (100 - SystemParam.Instance.LocalConfigOption.GradingLow))
                        {
                            pat.QCResultStatus = SystemData.MedQCStatus.SERIOUS_BUG;
                        }
                    }
                } while (dataReader.Read());

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCResultStatus", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取病案评分
        /// </summary>
        /// <param name="szDeptCode"></param>
        /// <param name="szCheckerName"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="bDischareTime"></param>
        /// <param name="lstQCScore"></param>
        /// <returns></returns>
        public short GetPatQCScores(string szDeptCode, string szCheckerName, DateTime dtBegin, DateTime dtEnd, bool bDischareTime, ref List<QCScore> lstQCScore)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szSQL = string.Empty;
            StringBuilder SB = new StringBuilder();

            SB.Append("SELECT A.DEPT_NAME, A.DEPT_CODE, B.PATIENT_ID, B.VISIT_ID, C.HOS_ASSESS,C.DOC_LEVEL");
            SB.Append(" FROM DEPT_V A, PAT_VISIT_V B, QC_SCORE C");
            SB.Append(" WHERE B.PATIENT_ID = C.PATIENT_ID");
            SB.Append("   AND B.VISIT_ID = C.VISIT_ID");
            if (bDischareTime)
                SB.AppendFormat(" AND B.DISCHARGE_TIME >={0} AND B.DISCHARGE_TIME<{1} AND B.DEPT_DISCHARGE_FROM=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dtBegin), base.MedQCAccess.GetSqlTimeFormat(dtEnd));
            else
                SB.AppendFormat(" AND B.VISIT_TIME >={0} AND B.VISIT_TIME<{1} AND B.DEPT_CODE=A.DEPT_CODE"
                    , base.MedQCAccess.GetSqlTimeFormat(dtBegin), base.MedQCAccess.GetSqlTimeFormat(dtEnd));
            SB.Append(" AND C.HOS_ASSESS>=0");//>=0才被评过分
            if (!string.IsNullOrEmpty(szCheckerName))
                SB.AppendFormat(" AND C.HOS_QCMAN='{0}'", szCheckerName);
            if (!string.IsNullOrEmpty(szDeptCode))
                SB.AppendFormat(" AND B.DEPT_CODE='{0}'", szDeptCode);
            szSQL = SB.ToString();
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.OK;
                }
                lstQCScore = new List<QCScore>();
                do
                {
                    QCScore qcScore = new QCScore();
                    if (!dataReader.IsDBNull(0)) qcScore.DEPT_NAME = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) qcScore.DeptCode = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcScore.PATIENT_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcScore.VISIT_ID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) qcScore.HOS_ASSESS = GlobalMethods.Convert.StringToValue(dataReader.GetValue(4).ToString(), 0f);
                    if (!dataReader.IsDBNull(5)) qcScore.DOC_LEVEL = dataReader.GetString(5);
                    lstQCScore.Add(qcScore);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetPatQCScores", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 批量获取病人分数
        /// </summary>
        /// <param name="lstPatVisitLogs"></param>
        /// <returns></returns>
        public short GetPatQCScore(ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (lstPatVisitLogs == null || lstPatVisitLogs.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitLogs.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') ", lstPatVisitLogs[index].PATIENT_ID, lstPatVisitLogs[index].VISIT_ID);
                if (index != lstPatVisitLogs.Count - 1)
                    sb.Append(" or ");
            }
            string szField = string.Format("{0},{1},{2}", SystemData.QCScoreTable.PATIENT_ID, SystemData.QCScoreTable.VISIT_ID,
              SystemData.QCScoreTable.HOS_ASSESS);
            string szCondition = string.Format("{0}", sb.ToString());
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataTable.QC_SCORE, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }

                string szPatientID = string.Empty;
                string szVisitID = string.Empty;
                float fHosAssess = -1f;
                do
                {
                    if (!dataReader.IsDBNull(0)) szPatientID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) szVisitID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) fHosAssess = float.Parse(dataReader.GetValue(2).ToString());
                    PatVisitInfo pat = lstPatVisitLogs.Find(i => i.PATIENT_ID == szPatientID && i.VISIT_ID == szVisitID);
                    if (fHosAssess >= 0 && pat != null)
                    {
                        pat.TotalScore = fHosAssess.ToString();
                    }
                    //重置
                    szPatientID = string.Empty;
                    szVisitID = string.Empty;
                    fHosAssess = -1f;
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatQCScore", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 批量获取病人分数
        /// </summary>
        /// <param name="lstPatVisitLogs"></param>
        /// <returns></returns>
        public short GetPatOperation(ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (lstPatVisitLogs == null || lstPatVisitLogs.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitLogs.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') ", lstPatVisitLogs[index].PATIENT_ID, lstPatVisitLogs[index].VISIT_ID);
                if (index != lstPatVisitLogs.Count - 1)
                    sb.Append(" or ");
            }
            string szField = string.Format("{0},{1}", SystemData.OperationNameTable.PATIENT_ID, SystemData.OperationNameTable.VISIT_ID);
            string szCondition = string.Format("{0}", sb.ToString());
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.OPERATION_NAME_V, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }

                string szPatientID = string.Empty;
                string szVisitID = string.Empty;
                do
                {
                    if (!dataReader.IsDBNull(0)) szPatientID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) szVisitID = dataReader.GetValue(1).ToString();
                    PatVisitInfo pat = lstPatVisitLogs.Find(i => i.PATIENT_ID == szPatientID && i.VISIT_ID == szVisitID);
                    pat.IsOperation = true;
                    szPatientID = string.Empty;
                    szVisitID = string.Empty;
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatQCScore", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 批量获取病人分数
        /// </summary>
        /// <param name="lstPatVisitLogs"></param>
        /// <returns></returns>
        public short GetPatBloodTransfusion(ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (lstPatVisitLogs == null || lstPatVisitLogs.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < lstPatVisitLogs.Count; index++)
            {
                sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') ", lstPatVisitLogs[index].PATIENT_ID, lstPatVisitLogs[index].VISIT_ID);
                if (index != lstPatVisitLogs.Count - 1)
                    sb.Append(" or ");
            }
            string szField = string.Format("{0},{1}", SystemData.BloodTransfusionView.PATIENT_ID, SystemData.BloodTransfusionView.VISIT_ID);
            string szCondition = string.Format("{0}", sb.ToString());
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.BLOOD_TRANSFUSION_V, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }

                string szPatientID = string.Empty;
                string szVisitID = string.Empty;
                do
                {
                    if (!dataReader.IsDBNull(0)) szPatientID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) szVisitID = dataReader.GetValue(1).ToString();
                    PatVisitInfo pat = lstPatVisitLogs.Find(i => i.PATIENT_ID == szPatientID && i.VISIT_ID == szVisitID);
                    pat.IsBlood = true;
                    szPatientID = string.Empty;
                    szVisitID = string.Empty;
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatQCScore", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 获取病人内容质控中的单项否决个数
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="visitId"></param>
        /// <param name="iVetoContentCount"></param>
        /// <returns></returns>
        public short GetContentVetoCount(string patientId, string visitId, ref int Count)
        {
            if (base.MedQCAccess == null)
            {
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (string.IsNullOrEmpty(patientId) || string.IsNullOrEmpty(visitId))
            {
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szSQL = string.Format("SELECT count(*) FROM MEDICAL_QC_LOG A, QC_MSG_DICT B"
                                  + " WHERE A.QC_MSG_CODE = B.QC_MSG_CODE AND B.ISVETO = '1'"
                                  + " AND A.PATIENT_ID = '{0}' AND A.VISIT_ID = '{1}'", patientId, visitId);

            IDataReader reader = null;
            try
            {
                reader = base.MedQCAccess.ExecuteReader(szSQL);
                if (((reader == null) || reader.IsClosed) || !reader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                Count = Convert.ToInt32(reader.GetValue(0));
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetContentVetoCount", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
            return SystemData.ReturnValue.OK;
        }
    }
}
