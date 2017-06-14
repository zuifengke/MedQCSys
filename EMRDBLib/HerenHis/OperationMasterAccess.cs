using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 方法只支持新系统
    /// </summary>
    public class OperationMasterAccess : DBAccessBase
    {
        private static OperationMasterAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static OperationMasterAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new OperationMasterAccess();
                return OperationMasterAccess.m_Instance;
            }
        }
        public DateTime GetOperationTime(string szPatientID, string szVisitID)
        {
            DateTime operationBeginTime = DateTime.Parse("1900-01-01");
            IDataReader dataReader = null;
            string szSQL = string.Format("select start_date_time from operation_master  t where t.patient_id ='{0}' and t.visit_id ={1}"
                   , szPatientID
                   , szVisitID);
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return operationBeginTime;
                }
                if (!dataReader.IsDBNull(0)) operationBeginTime = dataReader.GetDateTime(0);
                return operationBeginTime;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DbAccess.GetOperationTime", new string[] { "SQL" }
                        , new object[] { szSQL }, "查询失败!", ex);
                return operationBeginTime;
            }
            finally { base.HerenHisAccess.CloseConnnection(false); }
        }
        public short GetOperationMasters(string szPatientID, string szVisitID, ref List<OperationMaster> lstOperationMaster)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (string.IsNullOrEmpty(szPatientID) && string.IsNullOrEmpty(szVisitID))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("*");
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPatientID))
                szCondition = string.Format("{0} AND A.{1}='{2}'"
                , szCondition
                , SystemData.OperationView.PATIENT_ID
                , szPatientID
                );
            string szTable = string.Format("{0} A", SystemData.DataTable_HerenHis.OPERATION_MASTER);
            string szOrderBy = string.Format(SystemData.OperationMasterTable.OPER_NO);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstOperationMaster == null)
                    lstOperationMaster = new List<OperationMaster>();
                do
                {
                    OperationMaster model = new OperationMaster();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        PropertyInfo property = Reflect.GetPropertyInfo(typeof(OperationMaster), dataReader.GetName(i));
                        bool result = Reflect.SetPropertyValue(model, property, dataReader.GetValue(i));
                    }
                    lstOperationMaster.Add(model);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("OperationMasterAccess.GetOperationMasters", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.HerenHisAccess.CloseConnnection(false);
            }

        }

        public short GetOperationMaster(string szOperNo, ref OperationMaster operationMaster)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (string.IsNullOrEmpty(szOperNo))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},{57},{58},{59},{60},{61},{62},{63},{64},{65}"
                , SystemData.OperationMasterTable.ACK_DIRECTION
                , SystemData.OperationMasterTable.ANAESTHESIA_METHOD
                , SystemData.OperationMasterTable.ANESTHESIA_DOCTOR
                , SystemData.OperationMasterTable.ANESTHESIA_DOCTOR_ID
                , SystemData.OperationMasterTable.APPLY_STATUS
                , SystemData.OperationMasterTable.BLOOD_DOCTOR
                , SystemData.OperationMasterTable.BLOOD_DOCTOR_ID
                , SystemData.OperationMasterTable.BLOOD_LOSSED
                , SystemData.OperationMasterTable.BLOOD_TRANSFERED
                , SystemData.OperationMasterTable.CANCEL_DATE_TIME
                , SystemData.OperationMasterTable.CANCEL_DOCTOR
                , SystemData.OperationMasterTable.CANCEL_MEMO
                , SystemData.OperationMasterTable.CHARGE_INDICATOR
                , SystemData.OperationMasterTable.CLINIC_CATE
                , SystemData.OperationMasterTable.DEPT_STAYED
                , SystemData.OperationMasterTable.DIAG_AFTER_OPERATION
                , SystemData.OperationMasterTable.DIAG_BEFORE_OPERATION
                , SystemData.OperationMasterTable.EMERGENCY_FLAG
                , SystemData.OperationMasterTable.END_DATE_TIME
                , SystemData.OperationMasterTable.ENTERED_BY
                , SystemData.OperationMasterTable.ENTERED_BY_ID
                , SystemData.OperationMasterTable.ENTERED_DATE
                , SystemData.OperationMasterTable.FIRST_ANESTHESIA
                , SystemData.OperationMasterTable.FIRST_ANESTHESIA_ID
                , SystemData.OperationMasterTable.FIRST_ASSISTANT
                , SystemData.OperationMasterTable.FIRST_ASSISTANT_ID
                , SystemData.OperationMasterTable.FIRST_OPERATION_NURSE
                , SystemData.OperationMasterTable.FIRST_OPERATION_NURSE_ID
                , SystemData.OperationMasterTable.FIRST_SUPPLY_NURSE
                , SystemData.OperationMasterTable.FIRST_SUPPLY_NURSE_ID
                , SystemData.OperationMasterTable.FOUR_ASSISTANT
                , SystemData.OperationMasterTable.FOUR_ASSISTANT_ID
                , SystemData.OperationMasterTable.IN_FLUIDS_AMOUNT
                , SystemData.OperationMasterTable.ISOLATION_FLAG
                , SystemData.OperationMasterTable.NOTES_ON_OPERATION
                , SystemData.OperationMasterTable.NURSE_SHIFT_INDICATOR
                , SystemData.OperationMasterTable.OPERATING_DEPT
                , SystemData.OperationMasterTable.OPERATING_ROOM
                , SystemData.OperationMasterTable.OPERATING_SCALE
                , SystemData.OperationMasterTable.OPERATION_ROOM_NO
                , SystemData.OperationMasterTable.OPERATION_SEQUENCE
                , SystemData.OperationMasterTable.OPERATOR_DOCTOR
                , SystemData.OperationMasterTable.OPERATOR_DOCTOR_ID
                , SystemData.OperationMasterTable.OPER_NO
                , SystemData.OperationMasterTable.ORDER_ID
                , SystemData.OperationMasterTable.OUT_FLUIDS_AMOUNT
                , SystemData.OperationMasterTable.PATIENT_CONDITION
                , SystemData.OperationMasterTable.PATIENT_ID
                , SystemData.OperationMasterTable.REQ_DATE_TIME
                , SystemData.OperationMasterTable.SATISFACTION_DEGREE
                , SystemData.OperationMasterTable.SCHEDULED_DATE_TIME
                , SystemData.OperationMasterTable.SCHEDULE_ID
                , SystemData.OperationMasterTable.SECOND_ANESTHESIA
                , SystemData.OperationMasterTable.SECOND_ANESTHESIA_ID
                , SystemData.OperationMasterTable.SECOND_ASSISTANT
                , SystemData.OperationMasterTable.SECOND_ASSISTANT_ID
                , SystemData.OperationMasterTable.SECOND_OPERATION_NURSE
                , SystemData.OperationMasterTable.SECOND_OPERATION_NURSE_ID
                , SystemData.OperationMasterTable.SECOND_SUPPLY_NURSE
                , SystemData.OperationMasterTable.SECOND_SUPPLY_NURSE_ID
                , SystemData.OperationMasterTable.SMOOTH_INDICATOR
                , SystemData.OperationMasterTable.START_DATE_TIME
                , SystemData.OperationMasterTable.THREE_ASSISTANT
                , SystemData.OperationMasterTable.THREE_ASSISTANT_ID
                , SystemData.OperationMasterTable.VISIT_ID
                , SystemData.OperationMasterTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szOperNo))
                szCondition = string.Format("{0} AND {1}='{2}'"
                , szCondition
                , SystemData.OperationMasterTable.OPER_NO
                , szOperNo
                );
            string szTable = string.Format("{0} "
                , SystemData.DataTable_HerenHis.OPERATION_MASTER);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                , szField, szTable, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                operationMaster = new OperationMaster();
                if (!dataReader.IsDBNull(0)) operationMaster.ACK_DIRECTION = int.Parse(dataReader.GetValue(0).ToString());
                if (!dataReader.IsDBNull(1)) operationMaster.ANAESTHESIA_METHOD = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2)) operationMaster.ANESTHESIA_DOCTOR = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3)) operationMaster.ANESTHESIA_DOCTOR_ID = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4)) operationMaster.APPLY_STATUS = dataReader.GetValue(4).ToString();
                if (!dataReader.IsDBNull(5)) operationMaster.BLOOD_DOCTOR = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6)) operationMaster.BLOOD_DOCTOR_ID = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7)) operationMaster.BLOOD_LOSSED = int.Parse(dataReader.GetValue(7).ToString());
                if (!dataReader.IsDBNull(8)) operationMaster.BLOOD_TRANSFERED = int.Parse(dataReader.GetValue(8).ToString());
                if (!dataReader.IsDBNull(9)) operationMaster.CANCEL_DATE_TIME = dataReader.GetDateTime(9);
                if (!dataReader.IsDBNull(10)) operationMaster.CANCEL_DOCTOR = dataReader.GetString(10);
                if (!dataReader.IsDBNull(11)) operationMaster.CANCEL_MEMO = dataReader.GetString(11);
                if (!dataReader.IsDBNull(12)) operationMaster.CHARGE_INDICATOR = int.Parse
                        (dataReader.GetValue(12).ToString());
                if (!dataReader.IsDBNull(13)) operationMaster.CLINIC_CATE = int.Parse(dataReader.GetValue(0).ToString());
                if (!dataReader.IsDBNull(14)) operationMaster.DEPT_STAYED = dataReader.GetString(14);
                if (!dataReader.IsDBNull(15)) operationMaster.DIAG_AFTER_OPERATION = dataReader.GetString(15);
                if (!dataReader.IsDBNull(16)) operationMaster.DIAG_BEFORE_OPERATION = dataReader.GetString(16);
                if (!dataReader.IsDBNull(17)) operationMaster.EMERGENCY_FLAG = dataReader.GetString(17);
                if (!dataReader.IsDBNull(18)) operationMaster.END_DATE_TIME = dataReader.GetDateTime(18);
                if (!dataReader.IsDBNull(19)) operationMaster.ENTERED_BY = dataReader.GetString(19);
                if (!dataReader.IsDBNull(20)) operationMaster.ENTERED_BY_ID = dataReader.GetString(20);
                if (!dataReader.IsDBNull(21)) operationMaster.ENTERED_DATE = dataReader.GetDateTime(21);
                if (!dataReader.IsDBNull(22)) operationMaster.FIRST_ANESTHESIA = dataReader.GetString(22);
                if (!dataReader.IsDBNull(23)) operationMaster.FIRST_ANESTHESIA_ID = dataReader.GetString(23);
                if (!dataReader.IsDBNull(24)) operationMaster.FIRST_ASSISTANT = dataReader.GetString(24);
                if (!dataReader.IsDBNull(25)) operationMaster.FIRST_ASSISTANT_ID = dataReader.GetString(25);
                if (!dataReader.IsDBNull(26)) operationMaster.FIRST_OPERATION_NURSE = dataReader.GetString(26);
                if (!dataReader.IsDBNull(27)) operationMaster.FIRST_OPERATION_NURSE_ID = dataReader.GetString(27);
                if (!dataReader.IsDBNull(28)) operationMaster.FIRST_SUPPLY_NURSE = dataReader.GetString(28);
                if (!dataReader.IsDBNull(29)) operationMaster.FIRST_SUPPLY_NURSE_ID = dataReader.GetString(29);
                if (!dataReader.IsDBNull(30)) operationMaster.FOUR_ASSISTANT = dataReader.GetString(30);
                if (!dataReader.IsDBNull(31)) operationMaster.FOUR_ASSISTANT_ID = dataReader.GetString(31);
                if (!dataReader.IsDBNull(32)) operationMaster.IN_FLUIDS_AMOUNT = int.Parse(dataReader.GetValue(32).ToString());
                if (!dataReader.IsDBNull(33)) operationMaster.ISOLATION_FLAG = dataReader.GetString(33);
                if (!dataReader.IsDBNull(34)) operationMaster.NOTES_ON_OPERATION = dataReader.GetString(34);
                if (!dataReader.IsDBNull(35)) operationMaster.NURSE_SHIFT_INDICATOR = int.Parse(dataReader.GetValue(35).ToString());
                if (!dataReader.IsDBNull(36)) operationMaster.OPERATING_DEPT = dataReader.GetString(36);
                if (!dataReader.IsDBNull(37)) operationMaster.OPERATING_ROOM = dataReader.GetString(37);
                if (!dataReader.IsDBNull(38)) operationMaster.OPERATING_SCALE = dataReader.GetString(38);
                if (!dataReader.IsDBNull(39)) operationMaster.OPERATION_ROOM_NO = dataReader.GetString(39);
                if (!dataReader.IsDBNull(40)) operationMaster.OPERATION_SEQUENCE = int.Parse(dataReader.GetValue(40).ToString());
                if (!dataReader.IsDBNull(41)) operationMaster.OPERATOR_DOCTOR = dataReader.GetString(41);
                if (!dataReader.IsDBNull(42)) operationMaster.OPERATOR_DOCTOR_ID = dataReader.GetString(42);
                if (!dataReader.IsDBNull(43)) operationMaster.OPER_NO = dataReader.GetString(43);
                if (!dataReader.IsDBNull(44)) operationMaster.ORDER_ID = dataReader.GetString(44);
                if (!dataReader.IsDBNull(45)) operationMaster.OUT_FLUIDS_AMOUNT = int.Parse(dataReader.GetValue(45).ToString());
                if (!dataReader.IsDBNull(46)) operationMaster.PATIENT_CONDITION = dataReader.GetString(46);
                if (!dataReader.IsDBNull(47)) operationMaster.PATIENT_ID = dataReader.GetString(47);
                if (!dataReader.IsDBNull(48)) operationMaster.REQ_DATE_TIME = dataReader.GetDateTime(48);
                if (!dataReader.IsDBNull(49)) operationMaster.SATISFACTION_DEGREE = int.Parse(dataReader.GetValue(49).ToString());
                if (!dataReader.IsDBNull(50)) operationMaster.SCHEDULED_DATE_TIME = dataReader.GetDateTime(50);
                if (!dataReader.IsDBNull(51)) operationMaster.SCHEDULE_ID = int.Parse(dataReader.GetValue(51).ToString());
                if (!dataReader.IsDBNull(52)) operationMaster.SECOND_ANESTHESIA = dataReader.GetString(52);
                if (!dataReader.IsDBNull(53)) operationMaster.SECOND_ANESTHESIA_ID = dataReader.GetString(53);
                if (!dataReader.IsDBNull(54)) operationMaster.SECOND_ASSISTANT = dataReader.GetString(54);
                if (!dataReader.IsDBNull(55)) operationMaster.SECOND_ASSISTANT_ID = dataReader.GetString(55);
                if (!dataReader.IsDBNull(56)) operationMaster.SECOND_OPERATION_NURSE = dataReader.GetString(56);
                if (!dataReader.IsDBNull(57)) operationMaster.SECOND_OPERATION_NURSE_ID = dataReader.GetString(57);
                if (!dataReader.IsDBNull(58)) operationMaster.SECOND_SUPPLY_NURSE = dataReader.GetString(58);
                if (!dataReader.IsDBNull(59)) operationMaster.SECOND_SUPPLY_NURSE_ID = dataReader.GetString(59);
                if (!dataReader.IsDBNull(60)) operationMaster.SMOOTH_INDICATOR = int.Parse(dataReader.GetValue(60).ToString());
                if (!dataReader.IsDBNull(61)) operationMaster.START_DATE_TIME = dataReader.GetDateTime(61);
                if (!dataReader.IsDBNull(62)) operationMaster.THREE_ASSISTANT = dataReader.GetString(62);
                if (!dataReader.IsDBNull(63)) operationMaster.THREE_ASSISTANT_ID = dataReader.GetString(63);
                if (!dataReader.IsDBNull(64)) operationMaster.VISIT_ID = int.Parse(dataReader.GetValue(64).ToString());
                if (!dataReader.IsDBNull(65)) operationMaster.VISIT_NO = dataReader.GetString(65);

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("OperationMasterAccess.GetOperationMasters", new string[] { "szSQL" }, new object[] { szSQL
    }, ex);
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
                base.HerenHisAccess.CloseConnnection(false);
            }

        }
    }
}
