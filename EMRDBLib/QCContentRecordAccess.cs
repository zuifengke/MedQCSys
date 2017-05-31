// ***********************************************************
// 数据库访问层与病历内容质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using MDSDBLib;

namespace EMRDBLib.DbAccess 
{
    public class QcContentRecordAccess : DBAccessBase
    {
        private static QcContentRecordAccess m_Instance = null;
        public static QcContentRecordAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcContentRecordAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 根据文档ID删除对应内容检查记录
        /// </summary>
        /// <param name="szDocID"></param>
        /// <returns></returns>
        public short DeleteContentRecord(string szDocSetID)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szDocSetID))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szSQL = string.Format(" DELETE FROM QC_CONTENT_RECORD_T WHERE DOC_SETID='{0}' ", szDocSetID);
            try
            {
                int i = base.DataAccess.ExecuteNonQuery(szSQL);
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QCContentRecordAccess.DeleteContentRecord", new string[] { "szSQL" }
                    , new object[] { szSQL }, "删除记录失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.DataAccess.CloseConnnection(false);
            }

        }

        public short SaveQCContentRecord(List<EMRDBLib.Entity.QcContentRecord> lstQcContentRecord)
        {
            if (lstQcContentRecord == null || lstQcContentRecord.Count == 0)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = string.Empty;
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (var item in lstQcContentRecord)
            {
                sb.Append("INTO QC_CONTENT_RECORD_T");
                sb.AppendFormat("({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})",
                    "CONTENT_RECORD_ID", "PATIENT_ID", "VISIT_ID",
                    "DOCTYPE_ID", "POINT",
                     "DOC_SETID", "DOC_TITLE",
                    "MODIFY_TIME", "BUG_CLASS",
                    "QC_EXPLAIN", "DOCTOR_IN_CHARGE",
                    "DEPT_IN_CHARGE", "PATIENT_NAME", "DOC_TIME", "BUG_TYPE", "DEPT_CODE", "BUG_CREATE_ITME", "CREATE_ID", "CREATE_NAME"
                    );
                sb.Append("VALUES");
                if (GetNextVal(ref index) != SystemData.ReturnValue.OK)
                    throw new Exception("获取 GetNextVal 失败!");
                sb.AppendFormat("({0},'{1}','{2}','{3}',{4},'{5}','{6}',{7},'{8}','{9}','{10}','{11}','{12}',{13},'{14}','{15}',{16},'{17}','{18}')",
                    index, item.PatientID, item.VisitID,
                    item.DocTypeID, item.Point, item.DocSetID, item.DocTitle,
                    base.DataAccess.GetSqlTimeFormat(item.ModifyTime),
                    item.BugClass, item.QCExplain, item.DocIncharge,
                   item.DeptIncharge, item.PatientName, base.DataAccess.GetSqlTimeFormat(item.DocTime), item.BugType, item.DeptCode,
                   base.DataAccess.GetSqlTimeFormat(item.BugCreateTime),item.CreateID,item.CreateName);
            }
            szSQL = string.Format("INSERT ALL  {0}  SELECT * FROM dual", sb.ToString());
            try
            {
                int i = base.DataAccess.ExecuteNonQuery(szSQL);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QCContentRecordAccess.SaveQCContentRecord", new string[] { "szSQL" }
                   , new object[] { szSQL }, "删除记录失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.DataAccess.CloseConnnection(false);
            }
            return SystemData.ReturnValue.OK;
        }

        public short GetNextVal(ref int index)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szSQL = "select SEQ_CONTENT_RECORD_ID.NEXTVAL from dual";

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                index = int.Parse(dataReader.GetValue(0).ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetNextVal", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
            return SystemData.ReturnValue.OK;
        }

        public short GetQcContentRecordByPidVid(string szPatientId, string szVisitId, ref List<QcContentRecord> lstQcContentRecord)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szPatientId) || string.IsNullOrEmpty(szVisitId))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = "CONTENT_RECORD_ID,PATIENT_ID,VISIT_ID,DOCTYPE_ID,POINT,CHECKER_NAME," +
                             "CHECK_DATE,DOC_SETID,DOC_TITLE,MODIFY_TIME,BUG_CLASS,CREATE_ID,CREATE_NAME," +
                             "QC_EXPLAIN,DOCTOR_IN_CHARGE,DEPT_IN_CHARGE,PATIENT_NAME,DOC_TIME,BUG_TYPE,BUG_CREATE_ITME,DEPT_CODE";
            string szSQL = string.Format("SELECT {0} FROM QC_CONTENT_RECORD_T WHERE PATIENT_ID='{1}' AND VISIT_ID='{2}'",
                              szField, szPatientId, szVisitId);
            IDataReader reader = null;
            try
            {
                reader = base.DataAccess.ExecuteReader(szSQL);
                if (reader == null || reader.IsClosed || !reader.Read())
                    return SystemData.ReturnValue.EXCEPTION;
                if (lstQcContentRecord == null)
                    lstQcContentRecord = new List<QcContentRecord>();
                do
                {
                    QcContentRecord item = new QcContentRecord();
                    if (!reader.IsDBNull(0)) item.ContentRecordID = Convert.ToInt32(reader.GetValue(0));
                    if (!reader.IsDBNull(1)) item.PatientID = reader.GetString(1);
                    if (!reader.IsDBNull(2)) item.VisitID = reader.GetString(2);
                    if (!reader.IsDBNull(3)) item.DocTypeID = reader.GetString(3);
                    if (!reader.IsDBNull(4)) item.Point = float.Parse(reader.GetValue(4).ToString());
                    if (!reader.IsDBNull(5)) item.CheckerName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) item.CheckDate = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7)) item.DocSetID = reader.GetString(7);
                    if (!reader.IsDBNull(8)) item.DocTitle = reader.GetString(8);
                    if (!reader.IsDBNull(9)) item.ModifyTime = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10)) item.BugClass = Convert.ToInt32(reader.GetValue(10));
                    if (!reader.IsDBNull(11)) item.CreateID = reader.GetString(11);
                    if (!reader.IsDBNull(12)) item.CreateName = reader.GetString(12);
                    if (!reader.IsDBNull(13)) item.QCExplain = reader.GetString(13);
                    if (!reader.IsDBNull(14)) item.DocIncharge = reader.GetString(14);
                    if (!reader.IsDBNull(15)) item.DeptIncharge = reader.GetString(15);
                    if (!reader.IsDBNull(16)) item.PatientName = reader.GetString(16);
                    if (!reader.IsDBNull(17)) item.DocTime = reader.GetDateTime(17);
                    if (!reader.IsDBNull(18)) item.BugType = reader.GetString(18);
                    if (!reader.IsDBNull(19)) item.BugCreateTime = reader.GetDateTime(19);
                    if (!reader.IsDBNull(20)) item.DeptCode = reader.GetString(20);
                    lstQcContentRecord.Add(item);
                } while (reader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQcContentRecordByPidVid", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.DataAccess.CloseConnnection(false);
            }

        }
        /// <summary>
        /// 获取文档内容质检
        /// </summary>
        /// <param name="dtpModifyBeginTime">文档修改开始时间</param>
        /// <param name="dtpModifyEndTime">文档修改结束时间</param>
        /// <param name="szDeptName"></param>
        /// <param name="szPatientId"></param>
        /// <param name="szVisitId"></param>
        /// <param name="lstQcContentRecord"></param>
        /// <returns></returns>
        public short GetQcContentRecord(DateTime dtpModifyBeginTime, DateTime dtpModifyEndTime, string szDeptName, string szPatientId, string szVisitId, ref List<QcContentRecord> lstQcContentRecord)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("MODIFY_TIME >={0} and MODIFY_TIME <{1}",
                base.DataAccess.GetSqlTimeFormat(dtpModifyBeginTime), base.DataAccess.GetSqlTimeFormat(dtpModifyEndTime));
            if (!string.IsNullOrEmpty(szDeptName))
                szCondition += string.Format(" AND DEPT_IN_CHARGE='{0}'", szDeptName);
            if (!string.IsNullOrEmpty(szPatientId))
                szCondition += string.Format(" AND PATIENT_ID='{0}'", szPatientId);
            if (!string.IsNullOrEmpty(szVisitId))
                szCondition += string.Format(" AND VISIT_ID='{0}'", szVisitId);

            string szField = "CONTENT_RECORD_ID,PATIENT_ID,VISIT_ID,DOCTYPE_ID,POINT,CHECKER_NAME," +
                             "CHECK_DATE,DOC_SETID,DOC_TITLE,MODIFY_TIME,BUG_CLASS,CREATE_ID,CREATE_NAME," +
                            "QC_EXPLAIN,DOCTOR_IN_CHARGE,DEPT_IN_CHARGE,PATIENT_NAME,DOC_TIME,BUG_TYPE,BUG_CREATE_ITME,CHECKER_ID,DEPT_CODE";

            string szSQL = string.Format("SELECT {0} FROM QC_CONTENT_RECORD_T WHERE {1}",
                               szField, szCondition);

            IDataReader reader = null;
            try
            {
                reader = base.DataAccess.ExecuteReader(szSQL);
                if (reader == null || reader.IsClosed || !reader.Read())
                    return SystemData.ReturnValue.EXCEPTION;
                if (lstQcContentRecord == null)
                    lstQcContentRecord = new List<QcContentRecord>();
                do
                {
                    QcContentRecord item = new QcContentRecord();
                    if (!reader.IsDBNull(0)) item.ContentRecordID = Convert.ToInt32(reader.GetValue(0));
                    if (!reader.IsDBNull(1)) item.PatientID = reader.GetString(1);
                    if (!reader.IsDBNull(2)) item.VisitID = reader.GetString(2);
                    if (!reader.IsDBNull(3)) item.DocTypeID = reader.GetString(3);
                    if (!reader.IsDBNull(4)) item.Point = float.Parse(reader.GetValue(4).ToString());
                    if (!reader.IsDBNull(5)) item.CheckerName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) item.CheckDate = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7)) item.DocSetID = reader.GetString(7);
                    if (!reader.IsDBNull(8)) item.DocTitle = reader.GetString(8);
                    if (!reader.IsDBNull(9)) item.ModifyTime = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10)) item.BugClass = Convert.ToInt32(reader.GetValue(10));
                    if (!reader.IsDBNull(11)) item.CreateID = reader.GetString(11);
                    if (!reader.IsDBNull(12)) item.CreateName = reader.GetString(12);
                    if (!reader.IsDBNull(13)) item.QCExplain = reader.GetString(13);
                    if (!reader.IsDBNull(14)) item.DocIncharge = reader.GetString(14);
                    if (!reader.IsDBNull(15)) item.DeptIncharge = reader.GetString(15);
                    if (!reader.IsDBNull(16)) item.PatientName = reader.GetString(16);
                    if (!reader.IsDBNull(17)) item.DocTime = reader.GetDateTime(17);
                    if (!reader.IsDBNull(18)) item.BugType = reader.GetString(18);
                    if (!reader.IsDBNull(19)) item.BugCreateTime = reader.GetDateTime(19);
                    if (!reader.IsDBNull(20)) item.CheckerID = reader.GetString(20);
                    if (!reader.IsDBNull(21)) item.DeptCode = reader.GetString(21);
                    lstQcContentRecord.Add(item);
                } while (reader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQcContentRecord", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.DataAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 获取文档内容质检
        /// </summary>
        /// <param name="dtpModifyBeginTime">文档修改开始时间</param>
        /// <param name="dtpModifyEndTime">文档修改结束时间</param>
        /// <param name="szDeptName"></param>
        /// <param name="szPatientId"></param>
        /// <param name="szVisitId"></param>
        /// <param name="lstQcContentRecord"></param>
        /// <returns></returns>
        public short GetQcContentRecord(DateTime dtBeginTime, DateTime dtEndTime, string szDeptCode, ref List<QcContentRecord> lstQcContentRecord)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("BUG_CREATE_ITME >={0} and BUG_CREATE_ITME <{1}",
                base.DataAccess.GetSqlTimeFormat(dtBeginTime), base.DataAccess.GetSqlTimeFormat(dtEndTime));
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition += string.Format(" AND DEPT_CODE='{0}'", szDeptCode);

            string szField = "CONTENT_RECORD_ID,PATIENT_ID,VISIT_ID,DOCTYPE_ID,POINT,CHECKER_NAME," +
                             "CHECK_DATE,DOC_SETID,DOC_TITLE,MODIFY_TIME,BUG_CLASS,CREATE_ID,CREATE_NAME," +
                            "QC_EXPLAIN,DOCTOR_IN_CHARGE,DEPT_IN_CHARGE,PATIENT_NAME,DOC_TIME,BUG_TYPE,BUG_CREATE_ITME,CHECKER_ID,DEPT_CODE";
            string szOrderby = string.Format("{0}"
                ,"DOC_SETID");
            string szSQL = string.Format("SELECT {0} FROM QC_CONTENT_RECORD_T WHERE {1} ORDER BY {2}",
                               szField, szCondition,szOrderby);

            IDataReader reader = null;
            try
            {
                reader = base.DataAccess.ExecuteReader(szSQL);
                if (reader == null || reader.IsClosed || !reader.Read())
                    return SystemData.ReturnValue.EXCEPTION;
                if (lstQcContentRecord == null)
                    lstQcContentRecord = new List<QcContentRecord>();
                do
                {
                    QcContentRecord item = new QcContentRecord();
                    if (!reader.IsDBNull(0)) item.ContentRecordID = Convert.ToInt32(reader.GetValue(0));
                    if (!reader.IsDBNull(1)) item.PatientID = reader.GetString(1);
                    if (!reader.IsDBNull(2)) item.VisitID = reader.GetString(2);
                    if (!reader.IsDBNull(3)) item.DocTypeID = reader.GetString(3);
                    if (!reader.IsDBNull(4)) item.Point = float.Parse(reader.GetValue(4).ToString());
                    if (!reader.IsDBNull(5)) item.CheckerName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) item.CheckDate = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7)) item.DocSetID = reader.GetString(7);
                    if (!reader.IsDBNull(8)) item.DocTitle = reader.GetString(8);
                    if (!reader.IsDBNull(9)) item.ModifyTime = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10)) item.BugClass = Convert.ToInt32(reader.GetValue(10));
                    if (!reader.IsDBNull(11)) item.CreateID = reader.GetString(11);
                    if (!reader.IsDBNull(12)) item.CreateName = reader.GetString(12);
                    if (!reader.IsDBNull(13)) item.QCExplain = reader.GetString(13);
                    if (!reader.IsDBNull(14)) item.DocIncharge = reader.GetString(14);
                    if (!reader.IsDBNull(15)) item.DeptIncharge = reader.GetString(15);
                    if (!reader.IsDBNull(16)) item.PatientName = reader.GetString(16);
                    if (!reader.IsDBNull(17)) item.DocTime = reader.GetDateTime(17);
                    if (!reader.IsDBNull(18)) item.BugType = reader.GetString(18);
                    if (!reader.IsDBNull(19)) item.BugCreateTime = reader.GetDateTime(19);
                    if (!reader.IsDBNull(20)) item.CheckerID = reader.GetString(20);
                    if (!reader.IsDBNull(21)) item.DeptCode = reader.GetString(21);
                    lstQcContentRecord.Add(item);
                } while (reader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQcContentRecord", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.DataAccess.CloseConnnection(false);
            }
        }

        public short GetQcContentRecord(DateTime dtModifyBeginTime, DateTime dtModifyEndTime, List<DeptInfo> lstDeptInfos, bool bIsChecked, ref List<QcContentRecord> lstQcContentRecord)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("MODIFY_TIME >={0} and MODIFY_TIME <{1}",
                base.DataAccess.GetSqlTimeFormat(dtModifyBeginTime), base.DataAccess.GetSqlTimeFormat(dtModifyEndTime));
            if (lstDeptInfos != null && lstDeptInfos.Count > 0)
            {
                StringBuilder sb = new StringBuilder();   
                sb.Append(" AND DEPT_IN_CHARGE IN (");
                for (int index = 0; index < lstDeptInfos.Count; index++)
                {
                    DeptInfo item = lstDeptInfos[index];
                    sb.Append(string.Format("'{0}'", item.DeptName));
                    if (index != lstDeptInfos.Count - 1)
                        sb.Append(",");

                }
                sb.Append(") ");
                szCondition += sb.ToString();
            }

            if (bIsChecked)
            {
                szCondition += "AND CHECKER_ID IS NOT NULL";
            }
            else
            {
                szCondition += "AND CHECKER_ID IS  NULL";
            }

            string szField = "CONTENT_RECORD_ID,PATIENT_ID,VISIT_ID," +
                             "DOCTYPE_ID,POINT,CHECKER_NAME," +
                             "CHECK_DATE,DOC_SETID,DOC_TITLE," +
                             "MODIFY_TIME,BUG_CLASS,CREATE_ID," +
                             "CREATE_NAME,QC_EXPLAIN,DOCTOR_IN_CHARGE," +
                             "PATIENT_NAME,DOC_TIME,BUG_TYPE," +
                             "BUG_CREATE_ITME,CHECKER_ID,DEPT_IN_CHARGE,Dept_Code";
            string szSQL = string.Format("SELECT {0} FROM QC_CONTENT_RECORD_T WHERE {1}",
                              szField, szCondition);
            //关联文档状态
            szSQL = string.Format("SELECT A.*,B.SIGN_CODE FROM ({0}) A,EMR_DOC_T B WHERE A.DOC_SETID=B.DOC_SETID", szSQL);
            IDataReader reader = null;
            try
            {
                reader = base.DataAccess.ExecuteReader(szSQL);
                if (reader == null || reader.IsClosed || !reader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                if (lstQcContentRecord == null)
                    lstQcContentRecord = new List<QcContentRecord>();
                do
                {
                    QcContentRecord item = new QcContentRecord();
                    if (!reader.IsDBNull(0)) item.ContentRecordID = Convert.ToInt32(reader.GetValue(0));
                    if (!reader.IsDBNull(1)) item.PatientID = reader.GetString(1);
                    if (!reader.IsDBNull(2)) item.VisitID = reader.GetString(2);
                    if (!reader.IsDBNull(3)) item.DocTypeID = reader.GetString(3);
                    if (!reader.IsDBNull(4)) item.Point = float.Parse(reader.GetValue(4).ToString());
                    if (!reader.IsDBNull(5)) item.CheckerName = reader.GetString(5);
                    if (!reader.IsDBNull(6)) item.CheckDate = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7)) item.DocSetID = reader.GetString(7);
                    if (!reader.IsDBNull(8)) item.DocTitle = reader.GetString(8);
                    if (!reader.IsDBNull(9)) item.ModifyTime = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10)) item.BugClass = Convert.ToInt32(reader.GetValue(10));
                    if (!reader.IsDBNull(11)) item.CreateID = reader.GetString(11);
                    if (!reader.IsDBNull(12)) item.CreateName = reader.GetString(12);
                    if (!reader.IsDBNull(13)) item.QCExplain = reader.GetString(13);
                    if (!reader.IsDBNull(14)) item.DocIncharge = reader.GetString(14);
                    if (!reader.IsDBNull(15)) item.PatientName = reader.GetString(15);
                    if (!reader.IsDBNull(16)) item.DocTime = reader.GetDateTime(16);
                    if (!reader.IsDBNull(17)) item.BugType = reader.GetString(17);
                    if (!reader.IsDBNull(18)) item.BugCreateTime = reader.GetDateTime(18);
                    if (!reader.IsDBNull(19)) item.CheckerID = reader.GetString(19);
                    if (!reader.IsDBNull(20)) item.DeptIncharge = reader.GetString(20);
                    if (!reader.IsDBNull(21)) item.DeptCode = reader.GetString(21);
                    if (!reader.IsDBNull(22)) item.SignCode = reader.GetString(22);
                    lstQcContentRecord.Add(item);
                } while (reader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQcContentRecord", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.DataAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 更新内容质控质检信息
        /// </summary>
        /// <param name="szDocSetId"></param>
        /// <param name="szUserId"></param>
        /// <param name="szUserName"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public short UpdateQCContentRecord(string szDocSetId, string szUserId, string szUserName, DateTime now)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szDocSetId) || string.IsNullOrEmpty(szUserId) || string.IsNullOrEmpty(szUserName))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format(" CHECKER_ID='{0}',CHECKER_NAME='{1}',CHECK_DATE={2}"
               , szUserId, szUserName, base.DataAccess.GetSqlTimeFormat(now));
            string szWhere = string.Format(" DOC_SETID='{0}' AND CHECKER_ID IS NULL", szDocSetId);
            string szSQL = string.Format(SystemData.SQL.UPDATE, "QC_CONTENT_RECORD_T", szField, szWhere);
            try
            {
                int i = base.DataAccess.ExecuteNonQuery(szSQL);
                if (i >= 0)
                    return SystemData.ReturnValue.OK;
                else
                    return SystemData.ReturnValue.EXCEPTION;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.UpdateQCContentRecord", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.DataAccess.CloseConnnection(false);
            }

            return SystemData.ReturnValue.OK;
        }
    }
}
