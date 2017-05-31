// ***********************************************************
// 病历文档系统文档质控引擎,质控规则管理器
// 负责创建规则树和执行规则
// Creator:YangMingkun  Date:2009-8-19
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;
using EMRDBLib;

namespace MedDocSys.QCEngine.BugCheck
{
    internal class BugCheckRuleManager
    {
        private static Hashtable m_htRuleTable = null;
        public static Hashtable RuleTable
        {
            get { return m_htRuleTable; }
        }

        public static void AddRule(MedQCRule medQCRule)
        {
            if (m_htRuleTable == null)
                m_htRuleTable = new Hashtable();

            string szRuleID = medQCRule.RuleID.Trim();
            BugCheckRule qcRule = m_htRuleTable[szRuleID] as BugCheckRule;
            if (qcRule == null)
            {
                qcRule = new BugCheckRule();
                qcRule.RuleID = szRuleID;
                m_htRuleTable.Add(szRuleID, qcRule);
            }
            qcRule.Operator = medQCRule.Operator;
            qcRule.BugKey = string.Empty;
            qcRule.BugLevel = (BugLevel)medQCRule.BugLevel;
            qcRule.BugDesc = medQCRule.BugDesc;
            qcRule.Response = medQCRule.Response;

            if (!GlobalMethods.Misc.IsEmptyString(medQCRule.RuleID1))
            {
                string szSubRule1ID = medQCRule.RuleID1.Trim();
                BugCheckRule qcSubRule1 = m_htRuleTable[szSubRule1ID] as BugCheckRule;
                if (qcSubRule1 == null)
                {
                    qcSubRule1 = new BugCheckRule();
                    qcSubRule1.RuleID = szSubRule1ID;
                    m_htRuleTable.Add(szSubRule1ID, qcSubRule1);
                }
                qcRule.SubRule1 = qcSubRule1;
            }


            if (!GlobalMethods.Misc.IsEmptyString(medQCRule.RuleID2))
            {
                string szSubRule2ID = medQCRule.RuleID2.Trim();
                BugCheckRule qcSubRule2 = m_htRuleTable[szSubRule2ID] as BugCheckRule;
                if (qcSubRule2 == null)
                {
                    qcSubRule2 = new BugCheckRule();
                    qcSubRule2.RuleID = szSubRule2ID;
                    m_htRuleTable.Add(szSubRule2ID, qcSubRule2);
                }
                qcRule.SubRule2 = qcSubRule2;
            }

            if (!GlobalMethods.Misc.IsEmptyString(medQCRule.EntryID))
            {
                string szEntryID = medQCRule.EntryID.Trim();
                BugCheckEntry qcEntry = BugCheckEntryManager.GetEntry(szEntryID);
                if (qcEntry == null)
                    return;
                qcRule.RuleEntry = qcEntry;
            }

            if (!GlobalMethods.Misc.IsEmptyString(medQCRule.RefRuleID))
            {
                string szResultRuleID = medQCRule.RefRuleID.Trim();
                BugCheckRule qcResultRule = m_htRuleTable[szResultRuleID] as BugCheckRule;
                if (qcResultRule == null)
                {
                    qcResultRule = new BugCheckRule();
                    qcResultRule.RuleID = szResultRuleID;
                    m_htRuleTable.Add(szResultRuleID, qcResultRule);
                }
                qcRule.RefRule = qcResultRule;
            }
        }

        public static List<DocuemntBugInfo> ExecuteRule()
        {
            List<DocuemntBugInfo> lstBugList = null;
            foreach (object obj in m_htRuleTable.Values)
            {
                BugCheckRule qcRule = obj as BugCheckRule;
                if(qcRule == null)
                    continue;

                qcRule.OccurCount = 0;
                if (qcRule.RuleEntry != null || qcRule.RefRule == null)
                    continue;
                qcRule.Execute();
                if (qcRule.OccurCount <= 0)
                    continue;

                for (int nBugIndex = 0; nBugIndex < qcRule.OccurCount; nBugIndex++)
                {
                    DocuemntBugInfo bugInfo = new DocuemntBugInfo();
                    bugInfo.BugKey = qcRule.BugKey;
                    bugInfo.BugIndex = nBugIndex;
                    bugInfo.BugDesc = qcRule.BugDesc;
                    bugInfo.BugLevel = qcRule.BugLevel;
                    bugInfo.Response = qcRule.Response;
                    if (lstBugList == null)
                        lstBugList = new List<DocuemntBugInfo>();
                    lstBugList.Add(bugInfo);
                }
            }
            return lstBugList;
        }

        public static void Dispose()
        {
            if (m_htRuleTable == null || m_htRuleTable.Count <= 0)
                return;
            m_htRuleTable.Clear();
        }
    }
}
