// ***********************************************************
// 病历文档系统病历时效审核引擎
// Creator:Tangcheng  Date:2011-12-21
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Collections;
using Heren.Common.Libraries;
using EMRDBLib.Entity;
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace MedDocSys.QCEngine.TimeCheck
{
    public class TimeCheckEngine : IDisposable
    {
        private List<TimeQCRule> m_lstTimeQCRules = null;

        private string m_szPatientID = string.Empty;
        private string m_szVisitID = string.Empty;

        private List<TimeCheckResult> m_lstTimeCheckResults = null;

        /// <summary>
        /// 获取时效检查结果信息列表
        /// </summary>
        public List<TimeCheckResult> TimeCheckResults
        {
            get { return this.m_lstTimeCheckResults; }
        }

        private int m_nEarlyCount = 0;
        /// <summary>
        /// 获取或设置提前书写病历总数之和
        /// </summary>
        public int EarlyCount
        {
            get { return this.m_nEarlyCount; }
            set { this.m_nEarlyCount = value; }
        }


        private int m_nNormalCount = 0;
        /// <summary>
        /// 获取或设置病历正常书写总数之和
        /// </summary>
        public int NormalCount
        {
            get { return this.m_nNormalCount; }
            set { this.m_nNormalCount = value; }
        }

        private int m_nTimeoutCount = 0;
        /// <summary>
        /// 获取或设置病历超时书写总数之和
        /// </summary>
        public int TimeoutCount
        {
            get { return this.m_nTimeoutCount; }
            set { this.m_nTimeoutCount = value; }
        }

        private int m_nUnwriteCount = 0;
        /// <summary>
        /// 获取或设置病历未书写病历总数之和
        /// </summary>
        public int UnwriteCount
        {
            get { return this.m_nUnwriteCount; }
            set { this.m_nUnwriteCount = value; }
        }

        private static TimeCheckEngine m_instance = null;
        /// <summary>
        /// 获取时效检查引擎实例
        /// </summary>
        public static TimeCheckEngine Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new TimeCheckEngine();
                return m_instance;
            }
        }
        private TimeCheckEngine()
        {
            this.m_lstTimeCheckResults = new List<TimeCheckResult>();
        }

        /// <summary>
        /// 释放引用的资源
        /// </summary>
        public void Dispose()
        {
            if (this.m_lstTimeCheckResults != null)
                this.m_lstTimeCheckResults.Clear();
            this.m_lstTimeCheckResults = null;
            TimeEventHandler.Instance.Dispose();
            DocumentHandler.Instance.Dispose();
        }

        /// <summary>
        /// 执行病历时效审核计算
        /// </summary>
        /// <param name="arrTimeCheckQuery">患者列表</param>
        /// <returns>检查结果列表</returns>
        public short PerformTimeCheck(params TimeCheckQuery[] arrTimeCheckQuery)
        {
            short shRet = 0;
            if (this.m_lstTimeCheckResults == null)
                this.m_lstTimeCheckResults = new List<TimeCheckResult>();
            this.m_lstTimeCheckResults.Clear();
            if (arrTimeCheckQuery == null || arrTimeCheckQuery.Length <= 0)
                return SystemData.ReturnValue.CANCEL;

            if (this.m_lstTimeQCRules == null || arrTimeCheckQuery[0].PatientID != this.m_szPatientID || arrTimeCheckQuery[0].VisitID != this.m_szVisitID)
            {
                if (this.m_lstTimeQCRules == null)
                {

                    shRet = TimeQCRuleAccess.Instance.GetTimeQCRules(ref this.m_lstTimeQCRules);
                    if (shRet != SystemData.ReturnValue.OK)
                        return shRet;
                    if (this.m_lstTimeQCRules == null)
                        return shRet;
                }

                this.m_szPatientID = arrTimeCheckQuery[0].PatientID;
                this.m_szVisitID = arrTimeCheckQuery[0].VisitID;
            }

            for (int index = 0; index < arrTimeCheckQuery.Length; index++)
            {
                TimeCheckQuery timeCheckQuery = arrTimeCheckQuery[index];
                if (timeCheckQuery == null)
                    continue;
                TimeEventHandler.Instance.TimeCheckQuery = timeCheckQuery;
                TimeEventHandler.Instance.ClearEventResult();
                DocumentHandler.Instance.ClearDocumentList();
                for (int ruleIndex = 0; ruleIndex < this.m_lstTimeQCRules.Count; ruleIndex++)
                {
                    TimeQCRule timeQCRule = this.m_lstTimeQCRules[ruleIndex];
                    List<TimeCheckResult> lstTimeCheckResults = this.PerformTimeRule(timeQCRule);
                    if (lstTimeCheckResults != null && lstTimeCheckResults.Count > 0)
                        this.m_lstTimeCheckResults.AddRange(lstTimeCheckResults);
                }
            }
            this.m_lstTimeQCRules.Clear();
            this.m_lstTimeQCRules = null;
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 执行指定的时效检查规则
        /// </summary>
        /// <param name="timeQCRule">时效规则信息</param>
        private List<TimeCheckResult> PerformTimeRule(TimeQCRule timeQCRule)
        {
            if (timeQCRule == null || !timeQCRule.IsValid)
                return null;

            List<TimeQCEventResult> lstTimeQCEventResults = null;
            lstTimeQCEventResults = TimeEventHandler.Instance.PerformTimeEvent(timeQCRule.EventID);
            if (lstTimeQCEventResults == null || lstTimeQCEventResults.Count <= 0)
                return null;

            return DocumentHandler.Instance.CheckDocumentTime(timeQCRule, lstTimeQCEventResults);
        }

        public List<TimeCheckResult> GetUnwriteDoc(string szPatientID, string szVisitID)
        {
            TimeCheckQuery timeCheckQuery = new TimeCheckQuery();
            timeCheckQuery.PatientID = szPatientID;
            timeCheckQuery.VisitID = szVisitID;
            this.PerformTimeCheck(timeCheckQuery);
            List<TimeCheckResult> lstCheckResults = this.TimeCheckResults;
            List<TimeCheckResult> m_lstUnWriteResults = new List<TimeCheckResult>();

            for (int index = 0; index < lstCheckResults.Count; index++)
            {
                TimeCheckResult resultInfo = lstCheckResults[index];
                if (resultInfo.WrittenState == WrittenState.Unwrite)
                    m_lstUnWriteResults.Add(resultInfo);
            }
            return m_lstUnWriteResults;
        }
    }
}
