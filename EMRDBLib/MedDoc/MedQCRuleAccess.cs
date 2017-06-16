// ***********************************************************
// 数据库访问层与用户相关数据的访问类.
// Creator:YangAiping  Date:2014-05-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using System.Data.OleDb;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class MedQCRuleAccess : DBAccessBase
    {
        private static MedQCRuleAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static MedQCRuleAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new MedQCRuleAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取文档质控规则列表
        /// </summary>
        /// <param name="lstQCRules">质控规则列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCRuleList(ref List<MedQCRule> lstQCRules)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}"
                , SystemData.QCRuleTable.RULE_ID, SystemData.QCRuleTable.RULE_ID1, SystemData.QCRuleTable.OPERATOR
                , SystemData.QCRuleTable.RULE_ID2, SystemData.QCRuleTable.ENTRY_ID, SystemData.QCRuleTable.REF_RULE
                , SystemData.QCRuleTable.BUG_LEVEL, SystemData.QCRuleTable.BUG_DESC, SystemData.QCRuleTable.RESPONSE);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM, szField, SystemData.DataTable.QC_RULE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCRules == null)
                    lstQCRules = new List<MedQCRule>();
                do
                {
                    MedQCRule clsQCRule = new MedQCRule();
                    clsQCRule.RuleID = dataReader.GetString(0).Trim();
                    if (!dataReader.IsDBNull(1))
                        clsQCRule.RuleID1 = dataReader.GetString(1).Trim();
                    if (!dataReader.IsDBNull(2))
                        clsQCRule.Operator = dataReader.GetString(2).Trim();
                    if (!dataReader.IsDBNull(3))
                        clsQCRule.RuleID2 = dataReader.GetString(3).Trim();
                    if (!dataReader.IsDBNull(4))
                        clsQCRule.EntryID = dataReader.GetString(4).Trim();
                    if (!dataReader.IsDBNull(5))
                        clsQCRule.RefRuleID = dataReader.GetString(5).Trim();
                    if (!dataReader.IsDBNull(6))
                        clsQCRule.BugLevel = int.Parse(dataReader.GetValue(6).ToString());
                    if (!dataReader.IsDBNull(7))
                        clsQCRule.BugDesc = dataReader.GetString(7).Trim();
                    if (!dataReader.IsDBNull(8))
                        clsQCRule.Response = dataReader.GetString(8).Trim();
                    lstQCRules.Add(clsQCRule);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCRuleList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
    }
}
