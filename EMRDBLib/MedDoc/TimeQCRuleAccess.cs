using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class TimeQCRuleAccess : DBAccessBase
    {
        private static TimeQCRuleAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static TimeQCRuleAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new TimeQCRuleAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取所有病历时效规则配置信息列表
        /// </summary>
        /// <param name="lstTimeQCRules">时效规则配置信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetTimeQCRules(ref List<TimeQCRule> lstTimeQCRules)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}"
                , SystemData.TimeRuleTable.RULE_ID, SystemData.TimeRuleTable.EVENT_ID
                , SystemData.TimeRuleTable.DOCTYPE_ID, SystemData.TimeRuleTable.DOCTYPE_NAME
                , SystemData.TimeRuleTable.DOCTYPE_ALIAS, SystemData.TimeRuleTable.WRITTEN_PERIOD
                , SystemData.TimeRuleTable.IS_REPEAT, SystemData.TimeRuleTable.IS_VALID
                , SystemData.TimeRuleTable.QC_SCORE, SystemData.TimeRuleTable.ORDER_VALUE
                , SystemData.TimeRuleTable.RULE_DESC);

            string szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC
                    , szField, SystemData.DataTable.TIME_RULE, SystemData.TimeRuleTable.ORDER_VALUE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstTimeQCRules == null)
                    lstTimeQCRules = new List<TimeQCRule>();
                do
                {
                    TimeQCRule timeQCRule = new TimeQCRule();
                    timeQCRule.RuleID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1))
                        timeQCRule.EventID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        timeQCRule.DocTypeID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                        timeQCRule.DocTypeName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        timeQCRule.DocTypeAlias = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5))
                        timeQCRule.WrittenPeriod = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6))
                        timeQCRule.IsRepeat = dataReader.GetValue(6).ToString() == "1";
                    if (!dataReader.IsDBNull(7))
                        timeQCRule.IsValid = dataReader.GetValue(7).ToString() == "1";
                    if (!dataReader.IsDBNull(8))
                        timeQCRule.QCScore = float.Parse(dataReader.GetValue(8).ToString());
                    if (!dataReader.IsDBNull(9))
                        timeQCRule.OrderValue = int.Parse(dataReader.GetValue(9).ToString());
                    if (!dataReader.IsDBNull(10))
                        timeQCRule.RuleDesc = dataReader.GetString(10);
                    lstTimeQCRules.Add(timeQCRule);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.GetTimeQCRules", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 新增一条病历时效规则配置信息
        /// </summary>
        /// <param name="timeQCRule">病历时效规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveTimeQCRule(TimeQCRule timeQCRule)
        {
            if (timeQCRule == null)
            {
                LogManager.Instance.WriteLog("ConfigAccess.SaveTimeQCRule", new string[] { "timeQCRule" }
                    , new object[] { timeQCRule }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}"
                , SystemData.TimeRuleTable.RULE_ID, SystemData.TimeRuleTable.EVENT_ID
                , SystemData.TimeRuleTable.DOCTYPE_ID, SystemData.TimeRuleTable.DOCTYPE_NAME
                , SystemData.TimeRuleTable.DOCTYPE_ALIAS, SystemData.TimeRuleTable.WRITTEN_PERIOD
                , SystemData.TimeRuleTable.IS_REPEAT, SystemData.TimeRuleTable.IS_VALID
                , SystemData.TimeRuleTable.QC_SCORE, SystemData.TimeRuleTable.ORDER_VALUE
                , SystemData.TimeRuleTable.RULE_DESC);

            string szValue = string.Format("'{0}','{1}',{2},{3},'{4}','{5}',{6},{7},{8},{9},'{10}'"
                , timeQCRule.RuleID, timeQCRule.EventID, base.MeddocAccess.GetSqlParamName("DocTypeID")
                , base.MeddocAccess.GetSqlParamName("DocTypeName")
                , timeQCRule.DocTypeAlias, timeQCRule.WrittenPeriod, timeQCRule.IsRepeat ? 1 : 0
                , timeQCRule.IsValid ? 1 : 0, timeQCRule.QCScore.ToString()
                , timeQCRule.OrderValue.ToString(), timeQCRule.RuleDesc);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.TIME_RULE, szField, szValue);

            DbParameter[] pmi = new DbParameter[2];
            pmi[0] = new DbParameter("DocTypeID", timeQCRule.DocTypeID);
            pmi[1] = new DbParameter("DocTypeName", timeQCRule.DocTypeName);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.SaveTimeQCRule", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("ConfigAccess.SaveTimeQCRule", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新一条病历时效规则配置信息
        /// </summary>
        /// <param name="timeQCRule">病历时效规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateTimeQCRule(TimeQCRule timeQCRule)
        {
            if (timeQCRule == null)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateTimeQCRule", new string[] { "timeQCRule" }
                    , new object[] { timeQCRule }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}={5},{6}={7},{8}='{9}',{10}='{11}',{12}={13},{14}={15},{16}={17},{18}={19},{20}='{21}'"
                , SystemData.TimeRuleTable.RULE_ID, timeQCRule.RuleID
                , SystemData.TimeRuleTable.EVENT_ID, timeQCRule.EventID
                , SystemData.TimeRuleTable.DOCTYPE_ID, base.MeddocAccess.GetSqlParamName("DocTypeID")
                , SystemData.TimeRuleTable.DOCTYPE_NAME, base.MeddocAccess.GetSqlParamName("DocTypeName")
                , SystemData.TimeRuleTable.DOCTYPE_ALIAS, timeQCRule.DocTypeAlias
                , SystemData.TimeRuleTable.WRITTEN_PERIOD, timeQCRule.WrittenPeriod
                , SystemData.TimeRuleTable.IS_REPEAT, timeQCRule.IsRepeat ? 1 : 0
                , SystemData.TimeRuleTable.IS_VALID, timeQCRule.IsValid ? 1 : 0
                , SystemData.TimeRuleTable.QC_SCORE, timeQCRule.QCScore.ToString()
                , SystemData.TimeRuleTable.ORDER_VALUE, timeQCRule.OrderValue.ToString()
                , SystemData.TimeRuleTable.RULE_DESC, timeQCRule.RuleDesc);

            string szCondition = string.Format("{0}='{1}'", SystemData.TimeRuleTable.RULE_ID, timeQCRule.RuleID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.TIME_RULE, szField, szCondition);

            DbParameter[] pmi = new DbParameter[2];
            pmi[0] = new DbParameter("DocTypeID", timeQCRule.DocTypeID);
            pmi[1] = new DbParameter("DocTypeName", timeQCRule.DocTypeName);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateTimeQCRule", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateTimeQCRule", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条病历时效规则配置信息
        /// </summary>
        /// <param name="szRuleID">时效规则ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteTimeQCRule(string szRuleID)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szRuleID))
            {
                LogManager.Instance.WriteLog("ConfigAccess.DeleteTimeQCRule", new string[] { "szRuleID" }
                    , new object[] { szRuleID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.TimeRuleTable.RULE_ID, szRuleID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.TIME_RULE, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.DeleteTimeQCRule", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("ConfigAccess.DeleteTimeQCRule", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
    }
}
