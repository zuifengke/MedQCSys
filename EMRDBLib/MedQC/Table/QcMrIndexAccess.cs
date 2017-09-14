// ***********************************************************
// 数据库访问层与病案索引补充表数据相关的访问类.补充病案的归档、退回、纸质接收等操作的记录
// Creator:yehui  Date:2017-4-18
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
namespace EMRDBLib.DbAccess
{

    public class QcMrIndexAccess : DBAccessBase
    {
        private static QcMrIndexAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static QcMrIndexAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcMrIndexAccess();
                return QcMrIndexAccess.m_Instance;
            }
        }

        public short GetQcMrIndex(string szPatientID, string szVisitID, ref QcMrIndex qcMrIndex)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.ARCHIVE_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.ARCHIVE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.ARCHIVE_TIME);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.PAPER_RECEIVE);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.RETURN_COUNT);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.SUBMIT_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.SUBMIT_TIME);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.QcMrIndexTable.VISIT_NO);
            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.QcMrIndexTable.PATIENT_ID
                , szPatientID
                , SystemData.QcMrIndexTable.VISIT_ID
                , szVisitID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.QC_MR_INDEX, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (qcMrIndex == null)
                    qcMrIndex = new QcMrIndex();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.QcMrIndexTable.ARCHIVE_DOCTOR:
                            qcMrIndex.ARCHIVE_DOCTOR = dataReader.GetString(i);
                            break;
                        case SystemData.QcMrIndexTable.ARCHIVE_DOCTOR_ID:
                            qcMrIndex.ARCHIVE_DOCTOR_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcMrIndexTable.ARCHIVE_TIME:
                            qcMrIndex.ARCHIVE_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.QcMrIndexTable.PAPER_RECEIVE:
                            qcMrIndex.PAPER_RECEIVE = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcMrIndexTable.PATIENT_ID:
                            qcMrIndex.PATIENT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcMrIndexTable.RETURN_COUNT:
                            qcMrIndex.RETURN_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.QcMrIndexTable.SUBMIT_DOCTOR:
                            qcMrIndex.SUBMIT_DOCTOR = dataReader.GetString(i);
                            break;
                        case SystemData.QcMrIndexTable.SUBMIT_DOCTOR_ID:
                            qcMrIndex.SUBMIT_DOCTOR_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcMrIndexTable.SUBMIT_TIME:
                            qcMrIndex.SUBMIT_TIME = dataReader.GetDateTime(i);
                            break;
                        case SystemData.QcMrIndexTable.VISIT_ID:
                            qcMrIndex.VISIT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.QcMrIndexTable.VISIT_NO:
                            qcMrIndex.VISIT_NO = dataReader.GetString(i);
                            break;
                        default: break;
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        public short Insert(QcMrIndex qcMrIndex)
        {
            if (qcMrIndex == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { qcMrIndex }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.ARCHIVE_DOCTOR);
            sbValue.AppendFormat("'{0}',", qcMrIndex.ARCHIVE_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.ARCHIVE_DOCTOR_ID);
            sbValue.AppendFormat("'{0}',", qcMrIndex.ARCHIVE_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.ARCHIVE_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(qcMrIndex.ARCHIVE_TIME));
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.PAPER_RECEIVE);
            sbValue.AppendFormat("'{0}',", qcMrIndex.PAPER_RECEIVE);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", qcMrIndex.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.RETURN_COUNT);
            sbValue.AppendFormat("{0},", qcMrIndex.RETURN_COUNT);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.SUBMIT_DOCTOR);
            sbValue.AppendFormat("'{0}',", qcMrIndex.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.SUBMIT_DOCTOR_ID);
            sbValue.AppendFormat("'{0}',", qcMrIndex.SUBMIT_DOCTOR_ID);
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.SUBMIT_TIME);
            sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(qcMrIndex.SUBMIT_TIME));
            sbField.AppendFormat("{0},", SystemData.QcMrIndexTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", qcMrIndex.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.QcMrIndexTable.VISIT_NO);
            sbValue.AppendFormat("'{0}'", qcMrIndex.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_MR_INDEX, sbField.ToString(), sbValue.ToString());
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
        public short Update(QcMrIndex qcMrIndex)
        {
            if (qcMrIndex == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { qcMrIndex }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcMrIndexTable.ARCHIVE_DOCTOR, qcMrIndex.ARCHIVE_DOCTOR);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcMrIndexTable.ARCHIVE_DOCTOR_ID, qcMrIndex.ARCHIVE_DOCTOR_ID);
            sbField.AppendFormat("{0}={1},"
                , SystemData.QcMrIndexTable.ARCHIVE_TIME, base.MedQCAccess.GetSqlTimeFormat(qcMrIndex.ARCHIVE_TIME));
            sbField.AppendFormat("{0}={1},"
                , SystemData.QcMrIndexTable.PAPER_RECEIVE, qcMrIndex.PAPER_RECEIVE);
            sbField.AppendFormat("{0}={1},"
                , SystemData.QcMrIndexTable.RETURN_COUNT, qcMrIndex.RETURN_COUNT);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcMrIndexTable.SUBMIT_DOCTOR, qcMrIndex.SUBMIT_DOCTOR);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.QcMrIndexTable.SUBMIT_DOCTOR_ID, qcMrIndex.SUBMIT_DOCTOR_ID);
            sbField.AppendFormat("{0}={1}"
                , SystemData.QcMrIndexTable.SUBMIT_TIME, base.MedQCAccess.GetSqlTimeFormat(qcMrIndex.SUBMIT_TIME));
            string szCondition = string.Format("{0}='{1}' and {2}='{3}'"
                , SystemData.QcMrIndexTable.PATIENT_ID, qcMrIndex.PATIENT_ID
                , SystemData.QcMrIndexTable.VISIT_ID, qcMrIndex.VISIT_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_MR_INDEX, sbField.ToString(), szCondition);
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
        public short GetList(List<PatVisitInfo> lstPatVisitInfo, ref List<QcMrIndex> lstQcMrIndexs)
        {
            try
            {
                if (lstQcMrIndexs == null)
                    lstQcMrIndexs = new List<QcMrIndex>();
                for (int i = 0; i < lstPatVisitInfo.Count() / 100 + 1; i++)
                {
                    var result = lstPatVisitInfo.Skip(i * 100).Take(100).ToList();
                    if (result != null && result.Count > 0)
                    {
                        string szCondition = string.Format("");
                        foreach (var item in result)
                        {
                            if (szCondition == string.Empty)
                                szCondition = string.Format("({0}='{1}' and {2}='{3}')"
                                    , SystemData.PatVisitView.PATIENT_ID, item.PATIENT_ID
                                    , SystemData.PatVisitView.VISIT_ID, item.VISIT_ID);
                            else
                                szCondition = string.Format("({0}='{1}' and {2}='{3}') or {4}"
                                     , SystemData.PatVisitView.PATIENT_ID, item.PATIENT_ID
                                    , SystemData.PatVisitView.VISIT_ID, item.VISIT_ID
                                    , szCondition);
                        }
                        List<QcMrIndex> list = null;
                        this.GetList(szCondition, ref list);
                        if (list != null)
                            lstQcMrIndexs.AddRange(list);
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
                return SystemData.ReturnValue.EXCEPTION;
            }
        }
        public short GetList(string szCondition, ref List<QcMrIndex> list)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szCondition))
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable.QC_MR_INDEX, szCondition, SystemData.QcMrIndexTable.ARCHIVE_TIME);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (list == null)
                    list = new List<QcMrIndex>();
                list.Clear();
                do
                {
                    QcMrIndex item = new QcMrIndex();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.QcMrIndexTable.ARCHIVE_DOCTOR:
                                item.ARCHIVE_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.QcMrIndexTable.ARCHIVE_DOCTOR_ID:
                                item.ARCHIVE_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcMrIndexTable.ARCHIVE_TIME:
                                item.ARCHIVE_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcMrIndexTable.PAPER_RECEIVE:
                                item.PAPER_RECEIVE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcMrIndexTable.PATIENT_ID:
                                item.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcMrIndexTable.RETURN_COUNT:
                                item.RETURN_COUNT = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcMrIndexTable.SUBMIT_DOCTOR:
                                item.SUBMIT_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.QcMrIndexTable.SUBMIT_DOCTOR_ID:
                                item.SUBMIT_DOCTOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcMrIndexTable.SUBMIT_TIME:
                                item.SUBMIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.QcMrIndexTable.VISIT_ID:
                                item.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.QcMrIndexTable.VISIT_NO:
                                item.VISIT_NO = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    list.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
    }
}