// ***********************************************************
// 病历文档系统文档内容缺陷质控引擎
// Creator:YangMingkun  Date:2009-8-18
// Copyright:supconhealth
// ***********************************************************
using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;

namespace MedDocSys.QCEngine.BugCheck
{
    public class BugCheckEngine : IDisposable
    {
        #region"属性定义"
        private UserInfo m_userInfo = null;
        /// <summary>
        /// 获取或设置用户信息
        /// </summary>
        public UserInfo UserInfo
        {
            get { return this.m_userInfo; }
            set { this.m_userInfo = value; }
        }

        private PatientInfo m_patientInfo = null;
        /// <summary>
        /// 获取或设置病人信息
        /// </summary>
        public PatientInfo PatientInfo
        {
            get { return this.m_patientInfo; }
            set { this.m_patientInfo = value; }
        }

        private VisitInfo m_visitInfo = null;
        /// <summary>
        /// 获取或设置就诊信息
        /// </summary>
        public VisitInfo VisitInfo
        {
            get { return this.m_visitInfo; }
            set { this.m_visitInfo = value; }
        }

        private string m_szDocType = string.Empty;
        /// <summary>
        /// 获取或设置文档类型
        /// </summary>
        public string DocType
        {
            get { return this.m_szDocType; }
            set { this.m_szDocType = value; }
        }

        private string m_szDocText = string.Empty;
        /// <summary>
        /// 获取或设置文档纯文本数据
        /// </summary>
        public string DocText
        {
            get { return this.m_szDocText; }
            set { this.m_szDocText = value; }
        }

        private List<OutlineInfo> m_lstOutlineInfos = null;
        /// <summary>
        /// 获取或设置文档Section列表
        /// </summary>
        public List<OutlineInfo> OutlineInfos
        {
            get { return this.m_lstOutlineInfos; }
            set { this.m_lstOutlineInfos = value; }
        }
        #endregion

        /// <summary>
        /// 初始化质控引擎
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short InitializeEngine()
        {
            if (BugCheckRuleManager.RuleTable != null && BugCheckRuleManager.RuleTable.Count > 0)
                return SystemData.ReturnValue.OK;

            //初始化规则Entry列表
            List<MedQCEntry> lstQCEntryList = null;
            short shRet =MedQCEntryAccess.Instance.GetQCEntryList(ref lstQCEntryList);
            if (shRet != SystemData.ReturnValue.OK)
                return SystemData.ReturnValue.FAILED;
            if (lstQCEntryList == null || lstQCEntryList.Count <= 0)
                return SystemData.ReturnValue.CANCEL;

            for (int index = 0; index < lstQCEntryList.Count; index++)
            {
                BugCheckEntryManager.AddEntry(this, lstQCEntryList[index]);
            }

            //初始化规则列表
            List<MedQCRule> lstQCRuleList = null;
            shRet =MedQCRuleAccess.Instance.GetQCRuleList(ref lstQCRuleList);
            if (shRet != SystemData.ReturnValue.OK)
                return SystemData.ReturnValue.FAILED;
            if (lstQCRuleList == null || lstQCRuleList.Count <= 0)
                return SystemData.ReturnValue.CANCEL;

            for (int index = 0; index < lstQCRuleList.Count; index++)
            {
                BugCheckRuleManager.AddRule(lstQCRuleList[index]);
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 执行文档缺陷检查
        /// </summary>
        /// <param name="lstBugList">文档缺陷列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public List<DocuemntBugInfo> PerformBugCheck()
        {
            BugCheckEntryManager.ComputeEntryOccurCount();
            return BugCheckRuleManager.ExecuteRule();
        }

        public void Dispose()
        {
            BugCheckEntryManager.Dispose();
            BugCheckRuleManager.Dispose();
        }
    }
}
