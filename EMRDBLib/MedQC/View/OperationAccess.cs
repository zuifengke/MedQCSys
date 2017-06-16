// ***********************************************************
// 病案质控系统手术患者查询数据访问层
// Creator:yehui  Date:2016-12-20
// Copyright:heren
// ***********************************************************
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class OperationAccess : DBAccessBase
    {
        private static OperationAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static OperationAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new OperationAccess();
                return OperationAccess.m_Instance;
            }
        }
        public short GetOperations(string szDeptCode, DateTime dtBeginTime, DateTime dtEndTime, ref List<Operation> lstOperations)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}"
                 , SystemData.OperationView.ANAESTHESIA_METHOD
                 , SystemData.OperationView.DEPT_NAME
                 , SystemData.OperationView.HEAL
                 , SystemData.OperationView.OPERATION_CODE
                 , SystemData.OperationView.OPERATING_DATE
                 , SystemData.OperationView.OPERATION_DESC
                 , SystemData.OperationView.OPERATION_NO
                 , SystemData.OperationView.OPERATOR
                 , SystemData.OperationView.VISIT_ID
                 , SystemData.OperationView.WOUND_GRADE
                 , SystemData.OperationView.SEX
                 , SystemData.OperationView.PATIENT_NAME
                 , SystemData.OperationView.PATIENT_ID);

            string szCondition = string.Format("1=1"
                , SystemData.PatVisitView.PATIENT_ID
                , SystemData.PatVisitView.VISIT_ID);
            szCondition = string.Format("{0} AND {1}>{2} and {1} <{3} "
                , szCondition
                , SystemData.OperationView.OPERATING_DATE
                , base.MedQCAccess.GetSqlTimeFormat(dtBeginTime)
                , base.MedQCAccess.GetSqlTimeFormat(dtEndTime)
                );

            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.OperationView.DEPT_CODE, szDeptCode);

            string szTable = string.Format("{0} ", SystemData.DataView.OPERATION_V, SystemData.DataView.PAT_VISIT_V);
            string szOrderBy = string.Format("PATIENT_ID,VISIT_ID,OPERATION_NO");

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstOperations == null)
                    lstOperations = new List<Operation>();
                do
                {
                    Operation item = new Operation();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.OperationView.ANAESTHESIA_METHOD:
                                item.AnaesthesiaMethod = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.ANESTHESIA_DOCTOR:
                                item.ANESTHESIA_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.DEPT_CODE:
                                item.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.DEPT_NAME:
                                item.DeptName = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.FIRST_ASSISTANT:
                                item.FIRST_ASSISTANT = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.OPERATING_DATE:
                                item.OperationDate = dataReader.GetDateTime(i);
                                break;
                            case SystemData.OperationView.OPERATION_CODE:
                                item.OperationCode = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.OPERATION_DESC:
                                item.OperationDesc = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.OPERATION_NO:
                                item.OperationNo = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.OperationView.OPERATOR:
                                item.Operator = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.PATIENT_ID:
                                item.PatientID = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.PATIENT_NAME:
                                item.PatientName = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.SEX:
                                item.Sex = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.SECOND_ASSISTANT:
                                item.SECOND_ASSISTANT = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.VISIT_ID:
                                item.VisitID = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.OperationView.WOUND_GRADE:
                                item.WoundGrade = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstOperations.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetOperations", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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

        public short GetOperations(string szPatientID, string szPatientName, ref List<Operation> lstOperations)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (string.IsNullOrEmpty(szPatientID) && string.IsNullOrEmpty(szPatientName))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}"
                , SystemData.OperationView.ANAESTHESIA_METHOD
                , SystemData.OperationView.DEPT_NAME
                , SystemData.OperationView.HEAL
                , SystemData.OperationView.OPERATION_CODE
                , SystemData.OperationView.OPERATING_DATE
                , SystemData.OperationView.OPERATION_DESC
                , SystemData.OperationView.OPERATION_NO
                , SystemData.OperationView.OPERATOR
                , SystemData.OperationView.VISIT_ID
                , SystemData.OperationView.WOUND_GRADE
                , SystemData.OperationView.SEX
                , SystemData.OperationView.PATIENT_NAME
                , SystemData.OperationView.PATIENT_ID);

            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPatientID))

                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                , szCondition
                , SystemData.OperationView.PATIENT_ID
                , szPatientID
                );
            if (!string.IsNullOrEmpty(szPatientName))
                szCondition = string.Format("{0} AND {1} like '%{2}%'"
                , szCondition
                , SystemData.OperationView.PATIENT_NAME
                , szPatientName
                );

            string szTable = string.Format("{0} ", SystemData.DataView.OPERATION_V);
            string szOrderBy = string.Format("PATIENT_ID,VISIT_ID,OPERATION_NO");

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstOperations == null)
                    lstOperations = new List<Operation>();
                do
                {
                    Operation item = new Operation();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.OperationView.ANAESTHESIA_METHOD:
                                item.AnaesthesiaMethod = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.ANESTHESIA_DOCTOR:
                                item.ANESTHESIA_DOCTOR = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.DEPT_CODE:
                                item.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.DEPT_NAME:
                                item.DeptName = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.FIRST_ASSISTANT:
                                item.FIRST_ASSISTANT = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.OPERATING_DATE:
                                item.OperationDate = dataReader.GetDateTime(i);
                                break;
                            case SystemData.OperationView.OPERATION_CODE:
                                item.OperationCode = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.OPERATION_DESC:
                                item.OperationDesc = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.OPERATION_NO:
                                item.OperationNo = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.OperationView.OPERATOR:
                                item.Operator = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.PATIENT_ID:
                                item.PatientID = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.PATIENT_NAME:
                                item.PatientName = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.SEX:
                                item.Sex = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.SECOND_ASSISTANT:
                                item.SECOND_ASSISTANT = dataReader.GetString(i);
                                break;
                            case SystemData.OperationView.VISIT_ID:
                                item.VisitID = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.OperationView.WOUND_GRADE:
                                item.WoundGrade = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstOperations.Add(item);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetOperations", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
    }
}
