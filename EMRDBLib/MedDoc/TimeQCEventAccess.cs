using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class TimeQCEventAccess : DBAccessBase
    {
        private static TimeQCEventAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static TimeQCEventAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new TimeQCEventAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取所有病历时效事件配置信息
        /// </summary>
        /// <param name="lstTimeQCEvents">时效事件配置信息列表</param>
        /// <returns>SystemData.ExecuteResult</returns>
        public short GetTimeQCEvents(ref List<TimeQCEvent> lstTimeQCEvents)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.TimeEventTable.EVENT_ID, SystemData.TimeEventTable.EVENT_NAME
                , SystemData.TimeEventTable.SQL_TEXT, SystemData.TimeEventTable.SQL_CONDITON
                , SystemData.TimeEventTable.DEPEND_EVENT);

            string szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC
                , szField, SystemData.DataTable.TIME_EVENT, SystemData.TimeEventTable.EVENT_NAME);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstTimeQCEvents == null)
                    lstTimeQCEvents = new List<TimeQCEvent>();
                do
                {
                    TimeQCEvent timeQCEvent = new TimeQCEvent();
                    timeQCEvent.EventID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        timeQCEvent.EventName = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        timeQCEvent.SqlText = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                        timeQCEvent.SqlCondition = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        timeQCEvent.DependEvent = dataReader.GetString(4);
                    lstTimeQCEvents.Add(timeQCEvent);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.GetTimeQCEvents", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 新增一条时效事件配置信息
        /// </summary>
        /// <param name="timeQCEvent">时效事件配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveTimeQCEvent(TimeQCEvent timeQCEvent)
        {
            if (timeQCEvent == null)
            {
                LogManager.Instance.WriteLog("ConfigAccess.SaveTimeQCEvent", new string[] { "timeQCEvent" }
                    , new object[] { timeQCEvent }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.TimeEventTable.EVENT_ID, SystemData.TimeEventTable.EVENT_NAME
                , SystemData.TimeEventTable.SQL_TEXT, SystemData.TimeEventTable.SQL_CONDITON
                , SystemData.TimeEventTable.DEPEND_EVENT);
            string szValue = string.Format("'{0}','{1}',{2},{3},'{4}'"
                , timeQCEvent.EventID, timeQCEvent.EventName, base.DataAccess.GetSqlParamName("SqlText")
                , base.DataAccess.GetSqlParamName("SqlCondition"), timeQCEvent.DependEvent);

            DbParameter[] pmi = new DbParameter[2];
            pmi[0] = new DbParameter("SqlText", timeQCEvent.SqlText);
            pmi[1] = new DbParameter("SqlCondition", timeQCEvent.SqlCondition);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.TIME_EVENT, szField, szValue);
            int nCount = 0;
            try
            {
                nCount = base.DataAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.SaveTimeQCEvent", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("ConfigAccess.SaveTimeQCEvent", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新一条时效事件配置信息
        /// </summary>
        /// <param name="timeQCEvent">时效事件配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateTimeQCEvent(TimeQCEvent timeQCEvent)
        {
            if (timeQCEvent == null)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateTimeQCEvent", new string[] { "timeQCEvent" }
                    , new object[] { timeQCEvent }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}={5},{6}={7},{8}='{9}'"
                , SystemData.TimeEventTable.EVENT_ID, timeQCEvent.EventID
                , SystemData.TimeEventTable.EVENT_NAME, timeQCEvent.EventName
                , SystemData.TimeEventTable.SQL_TEXT, base.DataAccess.GetSqlParamName("SqlText")
                , SystemData.TimeEventTable.SQL_CONDITON, base.DataAccess.GetSqlParamName("SqlCondition")
                , SystemData.TimeEventTable.DEPEND_EVENT, timeQCEvent.DependEvent);

            DbParameter[] pmi = new DbParameter[2];
            pmi[0] = new DbParameter("SqlText", timeQCEvent.SqlText);
            pmi[1] = new DbParameter("SqlCondition", timeQCEvent.SqlCondition);

            string szCondition = string.Format("{0}='{1}'", SystemData.TimeEventTable.EVENT_ID, timeQCEvent.EventID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.TIME_EVENT, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.DataAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateTimeQCEvent", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateTimeQCEvent", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条时效事件配置信息
        /// </summary>
        /// <param name="szEventID">时效事件配置CODE</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteTimeQCEvent(string szEventID)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.TimeEventTable.EVENT_ID, szEventID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.TIME_EVENT, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.DataAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.DeleteTimeQCEvent", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("ConfigAccess.DeleteTimeQCEvent", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 执行时效事件配置的SQL语句
        /// </summary>
        /// <param name="szSQL">事件SQL</param>
        /// <param name="lstTimeQCEventResults">事件数据来源SQL返回结果信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short ExecuteTimeEventSQL(string szSQL, ref List<TimeQCEventResult> lstTimeQCEventResults)
        {
            if (GlobalMethods.Misc.IsEmptyString(szSQL)
                || !szSQL.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
            {
                LogManager.Instance.WriteLog("ConfigAccess.ExecuteTimeEventSQL", new string[] { "szSQL" }
                    , new object[] { szSQL }, "禁止执行非select语句!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                if (lstTimeQCEventResults == null)
                    lstTimeQCEventResults = new List<TimeQCEventResult>();
                lstTimeQCEventResults.Clear();
                do
                {
                    TimeQCEventResult timeQCEventResult = new TimeQCEventResult();
                    if (!dataReader.IsDBNull(0))
                        timeQCEventResult.EventTime = dataReader.GetDateTime(0);
                    if (!dataReader.IsDBNull(1))
                        timeQCEventResult.EndTime = dataReader.GetDateTime(1);
                    lstTimeQCEventResults.Add(timeQCEventResult);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.ExecuteTimeEventSQL", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
    }
}
