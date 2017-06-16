// ***********************************************************
// 数据库访问层与病历时效自动质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{

    public class QcCheckPointAccess : DBAccessBase
    {
        private static QcCheckPointAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static QcCheckPointAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcCheckPointAccess();
                return QcCheckPointAccess.m_Instance;
            }
        }

        /// <summary>
        /// 获取所有自动核查规则配置信息列表
        /// </summary>
        /// <param name="lstQcCheckPoints"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcCheckPoints(ref List<QcCheckPoint> lstQcCheckPoints)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},A.{14},{15},B.{16}"
                , SystemData.QcCheckPointTable.CHECK_POINT_ID, SystemData.QcCheckPointTable.CHECK_POINT_CONTENT
                , SystemData.QcCheckPointTable.DOCTYPE_ID, SystemData.QcCheckPointTable.DOCTYPE_NAME
                , SystemData.QcCheckPointTable.HANDLER_COMMAND, SystemData.QcCheckPointTable.IS_VALID
                , SystemData.QcCheckPointTable.MSG_DICT_CODE, SystemData.QcCheckPointTable.MSG_DICT_MESSAGE
                , SystemData.QcCheckPointTable.ORDER_VALUE, SystemData.QcCheckPointTable.SCORE
                , SystemData.QcCheckPointTable.WRITTEN_PERIOD
                , SystemData.QcCheckPointTable.QA_EVENT_TYPE, SystemData.QcCheckPointTable.EXPRESSION
                , SystemData.QcCheckPointTable.CHECK_TYPE
                , SystemData.QcCheckPointTable.EVENT_ID
                , SystemData.QcCheckPointTable.IS_REPEAT
                , SystemData.TimeEventTable.EVENT_NAME
                );
            string szTable = string.Format("{0} A,{1} B"
                , SystemData.DataTable.QC_CHECK_POINT
                , SystemData.DataTable.TIME_EVENT);
            string szCondition = string.Format("A.{0} = B.{1}(+)"
                , SystemData.QcCheckPointTable.EVENT_ID
                , SystemData.TimeEventTable.EVENT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , szField, szTable,szCondition, SystemData.TimeRuleTable.ORDER_VALUE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcCheckPoints == null)
                    lstQcCheckPoints = new List<QcCheckPoint>();
                do
                {
                    QcCheckPoint qcCheckPoint = new QcCheckPoint();
                    qcCheckPoint.CheckPointID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        qcCheckPoint.CheckPointContent = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        qcCheckPoint.DocTypeID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                        qcCheckPoint.DocTypeName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        qcCheckPoint.HandlerCommand = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5))
                        qcCheckPoint.IsValid = dataReader.GetValue(5).ToString() == "1";
                    if (!dataReader.IsDBNull(6))
                        qcCheckPoint.MsgDictCode = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7))
                        qcCheckPoint.MsgDictMessage = dataReader.GetString(7);
                    qcCheckPoint.OrderValue = int.Parse(dataReader.GetValue(8).ToString());
                    if (!dataReader.IsDBNull(9))
                        qcCheckPoint.Score = float.Parse(dataReader.GetValue(9).ToString());
                    if (!dataReader.IsDBNull(10))
                        qcCheckPoint.WrittenPeriod = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11))
                        qcCheckPoint.QaEventType = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12))
                        qcCheckPoint.Expression = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13))
                        qcCheckPoint.CheckType = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14))
                        qcCheckPoint.EventID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15))
                        qcCheckPoint.IsRepeat = dataReader.GetValue(15).ToString()=="1"?true:false;
                    if (!dataReader.IsDBNull(16))
                        qcCheckPoint.EventName = dataReader.GetString(16);
                    lstQcCheckPoints.Add(qcCheckPoint);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckPoint.GetQcCheckPoints", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 获取单条自动核查规则配置信息列表
        /// </summary>
        /// <param name="lstQcCheckPoints"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcCheckPoint(string szCheckPointID, ref QcCheckPoint qcCheckPoint)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},A.{14},{15},B.{16}"
                , SystemData.QcCheckPointTable.CHECK_POINT_ID, SystemData.QcCheckPointTable.CHECK_POINT_CONTENT
                , SystemData.QcCheckPointTable.DOCTYPE_ID, SystemData.QcCheckPointTable.DOCTYPE_NAME
                , SystemData.QcCheckPointTable.HANDLER_COMMAND, SystemData.QcCheckPointTable.IS_VALID
                , SystemData.QcCheckPointTable.MSG_DICT_CODE, SystemData.QcCheckPointTable.MSG_DICT_MESSAGE
                , SystemData.QcCheckPointTable.ORDER_VALUE, SystemData.QcCheckPointTable.SCORE
                , SystemData.QcCheckPointTable.WRITTEN_PERIOD
                , SystemData.QcCheckPointTable.QA_EVENT_TYPE, SystemData.QcCheckPointTable.EXPRESSION
                , SystemData.QcCheckPointTable.CHECK_TYPE
                , SystemData.QcCheckPointTable.EVENT_ID
                , SystemData.QcCheckPointTable.IS_REPEAT
                , SystemData.TimeEventTable.EVENT_NAME);
            
          
            string szTable = string.Format("{0} A,{1} B"
               , SystemData.DataTable.QC_CHECK_POINT
               , SystemData.DataTable.TIME_EVENT
               );

            string szCondition = string.Format("A.{0} = B.{1}(+) AND {2} = '{3}'"
                , SystemData.QcCheckPointTable.EVENT_ID
                , SystemData.TimeEventTable.EVENT_ID
                , SystemData.QcCheckPointTable.CHECK_POINT_ID, szCheckPointID);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , szField, szTable, szCondition, SystemData.TimeRuleTable.ORDER_VALUE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                qcCheckPoint = new QcCheckPoint();

                qcCheckPoint.CheckPointID = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1))
                    qcCheckPoint.CheckPointContent = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2))
                    qcCheckPoint.DocTypeID = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    qcCheckPoint.DocTypeName = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    qcCheckPoint.HandlerCommand = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    qcCheckPoint.IsValid = dataReader.GetValue(5).ToString() == "1";
                if (!dataReader.IsDBNull(6))
                    qcCheckPoint.MsgDictCode = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    qcCheckPoint.MsgDictMessage = dataReader.GetString(7);
                qcCheckPoint.OrderValue = int.Parse(dataReader.GetValue(8).ToString());
                if (!dataReader.IsDBNull(9))
                    qcCheckPoint.Score = float.Parse(dataReader.GetValue(9).ToString());
                if (!dataReader.IsDBNull(10))
                    qcCheckPoint.WrittenPeriod = dataReader.GetString(10);
                if (!dataReader.IsDBNull(11))
                    qcCheckPoint.QaEventType = dataReader.GetString(11);
                if (!dataReader.IsDBNull(12))
                    qcCheckPoint.Expression = dataReader.GetString(12);
                if (!dataReader.IsDBNull(13))
                    qcCheckPoint.CheckType = dataReader.GetString(13);
                if (!dataReader.IsDBNull(14))
                    qcCheckPoint.EventID = dataReader.GetString(14);
                if (!dataReader.IsDBNull(15))
                    qcCheckPoint.IsRepeat = dataReader.GetValue(15).ToString()=="1"?true:false;
                if (!dataReader.IsDBNull(16))
                    qcCheckPoint.EventName = dataReader.GetString(16);

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckPoint.GetQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 新增一条自动核查规则配置信息
        /// </summary>
        /// <param name="qcCheckPoint">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(QcCheckPoint qcCheckPoint)
        {
            if (qcCheckPoint == null)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.SaveQcCheckPoint", new string[] { "timeQCRule" }
                    , new object[] { qcCheckPoint }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}"
                , SystemData.QcCheckPointTable.CHECK_POINT_ID, SystemData.QcCheckPointTable.CHECK_POINT_CONTENT
                , SystemData.QcCheckPointTable.DOCTYPE_ID, SystemData.QcCheckPointTable.DOCTYPE_NAME
                , SystemData.QcCheckPointTable.HANDLER_COMMAND, SystemData.QcCheckPointTable.IS_VALID
                , SystemData.QcCheckPointTable.MSG_DICT_CODE, SystemData.QcCheckPointTable.MSG_DICT_MESSAGE
                , SystemData.QcCheckPointTable.ORDER_VALUE, SystemData.QcCheckPointTable.SCORE
                , SystemData.QcCheckPointTable.WRITTEN_PERIOD
                , SystemData.QcCheckPointTable.QA_EVENT_TYPE
                , SystemData.QcCheckPointTable.EXPRESSION
                , SystemData.QcCheckPointTable.CHECK_TYPE
                , SystemData.QcCheckPointTable.EVENT_ID
                , SystemData.QcCheckPointTable.IS_REPEAT);

            string szValue = string.Format("'{0}','{1}',{2},{3},'{4}',{5},'{6}','{7}',{8},{9},'{10}','{11}','{12}','{13}','{14}',{15}"
                , qcCheckPoint.CheckPointID
                , qcCheckPoint.CheckPointContent
                , base.MedQCAccess.GetSqlParamName("DocTypeID")
                , base.MedQCAccess.GetSqlParamName("DocTypeName")
                , qcCheckPoint.HandlerCommand
                , qcCheckPoint.IsValid ? 1 : 0
                , qcCheckPoint.MsgDictCode
                , qcCheckPoint.MsgDictMessage
                , qcCheckPoint.OrderValue.ToString()
                , qcCheckPoint.Score.ToString()
                , qcCheckPoint.WrittenPeriod
                , qcCheckPoint.QaEventType
                , qcCheckPoint.Expression
                , qcCheckPoint.CheckType
                , qcCheckPoint.EventID
                , qcCheckPoint.IsRepeat?1:0);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_CHECK_POINT, szField, szValue);

            DbParameter[] pmi = new DbParameter[2];
            pmi[0] = new DbParameter("DocTypeID", qcCheckPoint.DocTypeID == null ? string.Empty : qcCheckPoint.DocTypeID);
            pmi[1] = new DbParameter("DocTypeName", qcCheckPoint.DocTypeName == null ? string.Empty : qcCheckPoint.DocTypeName);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.SaveQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.SaveQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新一条自动核查规则配置信息
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(QcCheckPoint qcCheckPoint)
        {
            if (qcCheckPoint == null)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.UpdateQcCheckPoint", new string[] { "qcCheckPoint" }
                    , new object[] { qcCheckPoint }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}={5},{6}={7},{8}='{9}',{10}={11},{12}='{13}',{14}='{15}',{16}={17},{18}={19},{20}='{21}',{22}='{23}',{24}='{25}',{26}='{27}',{28}='{29}',{30}={31}"
                , SystemData.QcCheckPointTable.CHECK_POINT_ID, qcCheckPoint.CheckPointID
                , SystemData.QcCheckPointTable.CHECK_POINT_CONTENT, qcCheckPoint.CheckPointContent
                , SystemData.QcCheckPointTable.DOCTYPE_ID, base.MedQCAccess.GetSqlParamName("DocTypeID")
                , SystemData.QcCheckPointTable.DOCTYPE_NAME, base.MedQCAccess.GetSqlParamName("DocTypeName")
                , SystemData.QcCheckPointTable.HANDLER_COMMAND, qcCheckPoint.HandlerCommand
                , SystemData.QcCheckPointTable.IS_VALID, qcCheckPoint.IsValid ? 1 : 0
                , SystemData.QcCheckPointTable.MSG_DICT_CODE, qcCheckPoint.MsgDictCode
                , SystemData.QcCheckPointTable.MSG_DICT_MESSAGE, qcCheckPoint.MsgDictMessage
                , SystemData.QcCheckPointTable.ORDER_VALUE, qcCheckPoint.OrderValue.ToString()
                , SystemData.QcCheckPointTable.SCORE, qcCheckPoint.Score.ToString()
                , SystemData.QcCheckPointTable.WRITTEN_PERIOD, qcCheckPoint.WrittenPeriod
                , SystemData.QcCheckPointTable.QA_EVENT_TYPE, qcCheckPoint.QaEventType
                , SystemData.QcCheckPointTable.EXPRESSION, qcCheckPoint.Expression
                , SystemData.QcCheckPointTable.CHECK_TYPE, qcCheckPoint.CheckType
                , SystemData.QcCheckPointTable.EVENT_ID,qcCheckPoint.EventID
                , SystemData.QcCheckPointTable.IS_REPEAT,qcCheckPoint.IsRepeat?1:0);

            string szCondition = string.Format("{0}='{1}'", SystemData.QcCheckPointTable.CHECK_POINT_ID, qcCheckPoint.CheckPointID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_CHECK_POINT, szField, szCondition);

            DbParameter[] pmi = new DbParameter[2];
            pmi[0] = new DbParameter("DocTypeID", qcCheckPoint.DocTypeID == null ? string.Empty : qcCheckPoint.DocTypeID);
            pmi[1] = new DbParameter("DocTypeName", qcCheckPoint.DocTypeName == null ? string.Empty : qcCheckPoint.DocTypeName);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.UpdateQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.UpdateQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条自动核查规则配置信息
        /// </summary>
        /// <param name="szRuleID">自动核查规则ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szCheckPointID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szCheckPointID))
            {
                LogManager.Instance.WriteLog("ConfigAccess.DeleteTimeQCRule", new string[] { "szRuleID" }
                    , new object[] { szCheckPointID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcCheckPointTable.CHECK_POINT_ID, szCheckPointID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_CHECK_POINT, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.DeleteQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.DeleteQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
    }
}