// ***********************************************************
// 数据库访问层与质控评分数据相关的访问类.
// Creator:yehui  Date:2017-3-22
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
    public class QcScoreAccess : DBAccessBase
    {
        private static QcScoreAccess m_Instance = null;
        public static QcScoreAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcScoreAccess();
                return m_Instance;
            }
        }
        #region"质控评分接口"
        public short GetQcScores(DateTime dtHosDateTimeBegin, DateTime dtHosDateTimeEnd, string szHosQCManID,  ref List<QCScore> lstQCScores)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.DOC_LEVEL);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_ASSESS);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_DATE);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_QCMAN);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_QCMAN_ID);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.SUBMIT_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.QCScoreTable.VISIT_NO);
            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1} >= {2} AND {1} <= {3}"
                , szCondition
                , SystemData.QCScoreTable.HOS_DATE
                , base.MedQCAccess.GetSqlTimeFormat(dtHosDateTimeBegin)
                , base.MedQCAccess.GetSqlTimeFormat(dtHosDateTimeEnd));
            if (!string.IsNullOrEmpty(szHosQCManID))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.QCScoreTable.HOS_QCMAN_ID
                    , szHosQCManID);
            }
            string szOrderBy = string.Format("{0},{1},{2}"
                , SystemData.QCScoreTable.HOS_QCMAN
                , SystemData.QCScoreTable.DEPT_NAME
                , SystemData.QCScoreTable.PATIENT_NAME);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable.QC_SCORE, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCScores == null)
                    lstQCScores = new List<QCScore>();
                do
                {
                    QCScore qcScore = new QCScore();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.QCScoreTable.DEPT_NAME:
                                qcScore.DEPT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QCScoreTable.DOC_LEVEL:
                                qcScore.DOC_LEVEL = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.HOS_DATE:
                                qcScore.HOS_DATE = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QCScoreTable.HOS_ASSESS:
                                qcScore.HOS_ASSESS = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QCScoreTable.PATIENT_ID:
                                qcScore.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.PATIENT_NAME:
                                qcScore.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.VISIT_ID:
                                qcScore.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.VISIT_NO:
                                qcScore.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.SUBMIT_DOCTOR:
                                qcScore.SUBMIT_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.SUBMIT_DOCTOR_ID:
                                qcScore.SUBMIT_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.HOS_QCMAN:
                                qcScore.HOS_QCMAN = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.HOS_QCMAN_ID:
                                qcScore.HOS_QCMAN_ID = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstQCScores.Add(qcScore);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 病历质控系统,获取病案质量问题分类信息字典列表
        /// </summary>
        /// <param name="lstQCEventTypes">病案质量问题分类信息字典列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCScore(string szPatientID,string szVisitID, ref QCScore qcScore)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}"
               , SystemData.QCScoreTable.DOC_LEVEL
               , SystemData.QCScoreTable.HOS_ASSESS
               , SystemData.QCScoreTable.HOS_DATE
               , SystemData.QCScoreTable.HOS_QCMAN
               , SystemData.QCScoreTable.PATIENT_ID
               , SystemData.QCScoreTable.SUBMIT_DOCTOR
               , SystemData.QCScoreTable.SUBMIT_DOCTOR_ID
               , SystemData.QCScoreTable.VISIT_ID
               , SystemData.QCScoreTable.VISIT_NO);
            string szCondtion = string.Format("{0} = '{1}' AND {2}='{3}' "
                , SystemData.QCScoreTable.PATIENT_ID, szPatientID
                , SystemData.QCScoreTable.VISIT_ID,szVisitID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField
                , SystemData.DataTable.QC_SCORE, szCondtion);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (qcScore == null)
                    qcScore = new QCScore();
                if (!dataReader.IsDBNull(0)) qcScore.DOC_LEVEL = dataReader.GetValue(0).ToString();
                if (!dataReader.IsDBNull(1)) qcScore.HOS_ASSESS =float.Parse(dataReader.GetValue(1).ToString());
                if (!dataReader.IsDBNull(2)) qcScore.HOS_DATE = dataReader.GetDateTime(2) ;
                if (!dataReader.IsDBNull(3)) qcScore.HOS_QCMAN = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4)) qcScore.PATIENT_ID =dataReader.GetString(4);
                if (!dataReader.IsDBNull(5)) qcScore.SUBMIT_DOCTOR = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6)) qcScore.SUBMIT_DOCTOR_ID = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7)) qcScore.VISIT_ID = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8)) qcScore.VISIT_NO = dataReader.GetString(8);
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
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        public short Save(QCScore qcScore)
        {
            short shRet = SystemData.ReturnValue.OK;
            QCScore oldQcScore = null;
            shRet = this.GetQCScore(qcScore.PATIENT_ID, qcScore.VISIT_ID, ref oldQcScore);
            if (oldQcScore != null)
            {
                shRet = this.Update(qcScore);
            }
            else
                shRet = this.Insert(qcScore);
            return shRet;
        }
        /// <summary>
        /// 病历质控系统,新插入一条病案评分结果
        /// </summary>
        /// <param name="qcEventType">病案质控问题类别</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(QCScore qcScore)
        {
            if (qcScore == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "timeQCRule" }
                    , new object[] { qcScore }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.DOC_LEVEL);
            sbValue.AppendFormat("'{0}',", qcScore.DOC_LEVEL);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.DEPT_NAME);
            sbValue.AppendFormat("'{0}',", qcScore.DEPT_NAME);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_ASSESS);
            sbValue.AppendFormat("{0},", qcScore.HOS_ASSESS);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_DATE);
            sbValue.AppendFormat("{0},",base.MedQCAccess.GetSqlTimeFormat(qcScore.HOS_DATE));
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_QCMAN);
            sbValue.AppendFormat("'{0}',", qcScore.HOS_QCMAN);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.HOS_QCMAN_ID);
            sbValue.AppendFormat("'{0}',", qcScore.HOS_QCMAN_ID);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", qcScore.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.PATIENT_NAME);
            sbValue.AppendFormat("'{0}',", qcScore.PATIENT_NAME);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.SUBMIT_DOCTOR);
            sbValue.AppendFormat("'{0}',", qcScore.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.SUBMIT_DOCTOR_ID);
            sbValue.AppendFormat("'{0}',", qcScore.SUBMIT_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.QCScoreTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", qcScore.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.QCScoreTable.VISIT_NO);
            sbValue.AppendFormat("'{0}'", qcScore.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_SCORE, sbField.ToString(), sbValue.ToString());
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        /// 病历质控系统,修改一条病案质控问题类别
        /// </summary>
        /// <param name="qcScore">病案质控问题类别</param>
        /// <param name="szOldEventType">旧的病案质控问题类别名称</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(QCScore qcScore)
        {
            if (qcScore == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "qcScore" }
                    , new object[] { qcScore }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.QCScoreTable.DEPT_NAME,qcScore.DEPT_NAME);
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.QCScoreTable.DOC_LEVEL, qcScore.DOC_LEVEL);
            sbField.AppendFormat("{0}={1},"
               , SystemData.QCScoreTable.HOS_ASSESS, qcScore.HOS_ASSESS);
            sbField.AppendFormat("{0}={1},"
               , SystemData.QCScoreTable.HOS_DATE,base.MedQCAccess.GetSqlTimeFormat(qcScore.HOS_DATE));
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.QCScoreTable.HOS_QCMAN, qcScore.HOS_QCMAN);
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.QCScoreTable.HOS_QCMAN_ID, qcScore.HOS_QCMAN_ID);
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.QCScoreTable.PATIENT_NAME, qcScore.PATIENT_NAME);
            sbField.AppendFormat("{0}='{1}',"
               , SystemData.QCScoreTable.SUBMIT_DOCTOR, qcScore.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0}='{1}'"
               , SystemData.QCScoreTable.SUBMIT_DOCTOR_ID, qcScore.SUBMIT_DOCTOR_ID);

            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'"
                , SystemData.QCScoreTable.PATIENT_ID, qcScore.PATIENT_ID
                , SystemData.QCScoreTable.VISIT_ID,qcScore.VISIT_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_SCORE, sbField.ToString(), szCondition);
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        ///  病历质控系统,根据反馈信息代码,删除指定病案质控问题类别
        /// </summary>
        /// <param name="szEventType">病案质控问题类别名称</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szPatientID,string szVisitID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;


            string szCondition = string.Format("{0}='{1}'"
                , SystemData.QCScoreTable.PATIENT_ID,szPatientID
                , SystemData.QCScoreTable.VISIT_ID,szVisitID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_SCORE, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        #endregion

        /// <summary>
        /// 获取缺陷率统计所需的基础数据
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcScores(DateTime dtDischargeTimeBegin, DateTime dtDischargeTimeEnd, ref List<QCScore> lstQCScores)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select t1.PATIENT_ID,t1.DEPT_NAME,t1.VISIT_NO,t1.VISIT_ID,t1.PATIENT_NAME,t1.DEPT_CODE,t1.DISCHARGE_TIME,t2.hos_assess ");
            sbSql.Append(" from pat_visit_v t1,qc_score t2 ");
            sbSql.Append(" where t1.PATIENT_ID=t2.patient_id(+) and t1.VISIT_ID = t2.visit_id(+)");
            sbSql.AppendFormat("and t1.DISCHARGE_TIME > {0} and t1.DISCHARGE_TIME < {1}"
                ,base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeBegin)
                ,base.MedQCAccess.GetSqlTimeFormat(dtDischargeTimeEnd)
                );
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(sbSql.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCScores == null)
                    lstQCScores = new List<QCScore>();
                lstQCScores.Clear();
                do
                {
                    QCScore qcScore = new QCScore();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.PatVisitView.DEPT_NAME:
                                qcScore.DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.PATIENT_ID:
                                qcScore.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.VISIT_ID:
                                qcScore.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.VISIT_NO:
                                qcScore.VISIT_NO = dataReader.GetString(i);
                                break;
                            case SystemData.QCScoreTable.HOS_ASSESS:
                                qcScore.HOS_ASSESS =float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.PatVisitView.PATIENT_NAME:
                                qcScore.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.DEPT_CODE:
                                qcScore.DeptCode = dataReader.GetString(i);
                                break;
                            case SystemData.PatVisitView.DISCHARGE_TIME:
                                qcScore.DischargeTime = dataReader.GetDateTime(i);
                                break;
                            default: break;
                        }
                    }
                    lstQCScores.Add(qcScore);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { sbSql.ToString() }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
    }
}
