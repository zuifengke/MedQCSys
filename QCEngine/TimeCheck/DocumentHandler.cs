// ***********************************************************
// 病历时效质控引擎病历列表分析器
// 主要用来分析病历的书写时间是否是超时、未书写
// Creator:YangMingkun  Date:2012-1-3
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;
using EMRDBLib.Entity;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace MedDocSys.QCEngine.TimeCheck
{
    internal class DocumentHandler : IDisposable
    {
        private static DocumentHandler m_instance = null;
        /// <summary>
        /// 获取已写病历列表处理器实例
        /// </summary>
        public static DocumentHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new DocumentHandler();
                return m_instance;
            }
        }
        private DocumentHandler()
        {
        }

        /// <summary>
        /// 用来缓存病历类型与病历对应关系的字典
        /// </summary>
        private Dictionary<string, MedDocList> m_dicDocInfos = null;


        /// <summary>
        /// 释放引用的资源
        /// </summary>
        public void Dispose()
        {
            if (this.m_dicDocInfos != null)
                this.m_dicDocInfos.Clear();
            this.m_dicDocInfos = null;
        }

        /// <summary>
        /// 清除缓存的病历列表
        /// </summary>
        public void ClearDocumentList()
        {
            if (this.m_dicDocInfos != null)
                this.m_dicDocInfos.Clear();
            //这里置空,以便重新加载
            this.m_dicDocInfos = null;
        }

       

        /// <summary>
        /// 根据文档DocTime进行比较
        /// </summary>
        /// <param name="docInfo1"></param>
        /// <param name="docInfo2"></param>
        /// <returns></returns>
        private int CompareByDocTime(MedDocInfo docInfo1, MedDocInfo docInfo2)
        {
            return docInfo1.DOC_TIME.CompareTo(docInfo2.DOC_TIME);
        }
        /// <summary>
        /// 根据文档RecordTime进行比较
        /// </summary>
        /// <param name="docInfo1"></param>
        /// <param name="docInfo2"></param>
        /// <returns></returns>
        private int CompareByRecordTime(MedDocInfo docInfo1,MedDocInfo docInfo2)
        {
            return docInfo1.RECORD_TIME.CompareTo(docInfo2.RECORD_TIME);
        }


        /// <summary>
        /// 根据指定时效规则以及规则对应的时效事件执行结果,检查已写病历列表
        /// </summary>
        /// <param name="timeQCRule">时效规则</param>
        /// <param name="lstTimeQCEventResults">规则对应的时效事件执行结果</param>
        /// <returns>已写病历列表时效检查结果</returns>
        public List<TimeCheckResult> CheckDocumentTime(TimeQCRule timeQCRule
            , List<TimeQCEventResult> lstTimeQCEventResults)
        {
            if (timeQCRule == null || string.IsNullOrEmpty(timeQCRule.DocTypeID))
                return null;

            //获取时效事件名称等信息
            TimeQCEvent timeQCEvent =
                TimeEventHandler.Instance.GetTimeQCEvent(timeQCRule.EventID);
            if (timeQCEvent == null)
                return null;

            //创建应书写的病历时间表
            List<TimeCheckResult> lstTimeCheckResults =
                this.CreateTimeCheckTable(timeQCRule, lstTimeQCEventResults);
            if (lstTimeCheckResults == null || lstTimeCheckResults.Count <= 0)
                return null;
            //附加本规则未书写的病历数到未写病历计数器
            TimeCheckEngine.Instance.UnwriteCount += lstTimeCheckResults.Count;
            List<MedDocInfo> lstDocInfos = null;
            for (int index = 0; index < lstTimeCheckResults.Count; index++)
            {
                TimeCheckResult timeCheckResult = lstTimeCheckResults[index];
                if (timeCheckResult == null)
                    continue;
                timeCheckResult.EventID = timeQCEvent.EventID;
                timeCheckResult.EventName = timeQCEvent.EventName;
                timeCheckResult.IsVeto = timeQCRule.IsVeto;

                //查找当前时效检查表记录对应的文档
                string szDocTypeIDList = timeCheckResult.DocTypeID;
                lstDocInfos = this.GetDocumentList(szDocTypeIDList);
                if (lstDocInfos == null || lstDocInfos.Count <= 0)
                {
                    timeCheckResult.WrittenState = WrittenState.Unwrite;
                    continue;
                }
                lstDocInfos.Sort(this.CompareByDocTime);
                //核对病历内部时间以及实际书写时间
                for (int nDocIndex = 0; nDocIndex < lstDocInfos.Count; nDocIndex++)
                {
                    MedDocInfo docInfo = lstDocInfos[nDocIndex];

                    //RecordTime作为文档补写依据。文档内部时间在时效规则开始时间和截止时间之间的作为补写文档
                    //然后通过DocTime文档的真实时间来判断超时情况。
                    if (docInfo.RECORD_TIME != docInfo.DefaultTime
                        && timeCheckResult.IsRepeat
                        && (docInfo.RECORD_TIME < timeCheckResult.StartTime || docInfo.RECORD_TIME > timeCheckResult.EndTime))
                        continue;
                    if (timeCheckResult.EventTime > docInfo.DOC_TIME
                        && timeCheckResult.EventTime.AddHours(-3) > docInfo.RECORD_TIME
                        && (docInfo.DOC_TITLE.Contains("首次病程记录") || docInfo.DOC_TITLE.Contains("手术记录") || docInfo.DOC_TITLE.Contains("术后")))
                    {
                        continue;
                    }
                    if ((docInfo.DOC_TITLE.Contains("术前小结") || docInfo.DOC_TITLE.Contains("术前讨论"))
                        && timeCheckResult.EventTime > docInfo.RECORD_TIME.AddDays(3))
                    {
                        //术前三天以上的术前讨论和术前小结，不作为本次手术的文档
                        continue;
                    }
                    long nCurrSpan = timeCheckResult.TimeSpan(docInfo); //DocTime-StartTime
                    if (nCurrSpan < 0)
                    {
                        timeCheckResult.WrittenState = WrittenState.Early;
                    }
                    else if (docInfo.DOC_TIME.CompareTo(timeCheckResult.EndTime) <= 0)
                    {
                        timeCheckResult.WrittenState = WrittenState.Normal;
                    }
                    else
                    {
                        timeCheckResult.WrittenState = WrittenState.Timeout;
                    }
                    timeCheckResult.DocTime = docInfo.DOC_TIME;
                    timeCheckResult.RecordTime = docInfo.RECORD_TIME;
                    timeCheckResult.DocID = docInfo.DOC_ID;
                    timeCheckResult.CreatorName = docInfo.CREATOR_NAME;
                    timeCheckResult.CreatorID = docInfo.CREATOR_ID;
                    break;
                }
            }

            //病历书写情况统计
            foreach (TimeCheckResult result in lstTimeCheckResults)
            {
                switch (result.WrittenState)
                {
                    case WrittenState.Early:
                        TimeCheckEngine.Instance.EarlyCount += 1;
                        break;
                    case WrittenState.Normal:
                        TimeCheckEngine.Instance.NormalCount += 1;
                        break;
                    case WrittenState.Unwrite:
                        TimeCheckEngine.Instance.UnwriteCount += 1;
                        break;
                    case WrittenState.Timeout:
                        TimeCheckEngine.Instance.TimeoutCount += 1;
                        break;
                    case WrittenState.Uncheck:
                        result.WrittenState = WrittenState.Unwrite;
                        break;
                    default:
                        break;
                }
            }
            return lstTimeCheckResults;
        }
        /// <summary>
        /// 创建一张病历正常书写的用于比对的时效检查时间表
        /// </summary>
        /// <param name="timeQCRule">指定时效规则</param>
        /// <param name="lstTimeQCEventResults">时效事件执行结果</param>
        /// <returns>时效检查时间表列表</returns>
        private List<TimeCheckResult> CreateTimeCheckTable(TimeQCRule timeQCRule
            , List<TimeQCEventResult> lstTimeQCEventResults)
        {
            if (lstTimeQCEventResults == null || lstTimeQCEventResults.Count <= 0)
                return null;
            if (TimeEventHandler.Instance.TimeCheckQuery == null)
                return null;

            List<TimeCheckResult> lstTimeCheckResults = new List<TimeCheckResult>();
            string szPatientID = TimeEventHandler.Instance.TimeCheckQuery.PatientID;
            string szPatientName = TimeEventHandler.Instance.TimeCheckQuery.PatientName;
            string szVisitID = TimeEventHandler.Instance.TimeCheckQuery.VisitID;
            string szBedCode = TimeEventHandler.Instance.TimeCheckQuery.BedCode;
            DateTime dtVisitTime = TimeEventHandler.Instance.TimeCheckQuery.VisitTime;

            //创建一张病历正常书写的时间表
            for (int index = 0; index < lstTimeQCEventResults.Count; index++)
            {
                TimeQCEventResult timeQCEventResult = lstTimeQCEventResults[index];
                if (timeQCEventResult == null)
                    continue;
                if (!timeQCEventResult.EventTime.HasValue)
                    continue;
                if (!timeQCEventResult.EndTime.HasValue)
                    continue;
                DateTime dtPeriodTime = timeQCEventResult.EventTime.Value;
                ////根据书写规则定义标准，修改循环退出判断逻辑
                //bool IsRuleAsDocCommited = DataLayer.SystemParam.Instance.SystemOption.DocWriteRule == "2";
                do
                {
                    TimeCheckResult timeCheckResult = new TimeCheckResult();
                    timeCheckResult.PatientID = szPatientID;
                    timeCheckResult.VisitID = szVisitID;
                    timeCheckResult.PatientName = szPatientName;
                    timeCheckResult.DocTypeID = timeQCRule.DocTypeID;
                    timeCheckResult.DocTypeName = timeQCRule.DocTypeName;
                    timeCheckResult.BedCode = szBedCode;
                    timeCheckResult.VisitTime = dtVisitTime;
                    if (!GlobalMethods.Misc.IsEmptyString(timeQCRule.DocTypeAlias))
                        timeCheckResult.DocTypeName = timeQCRule.DocTypeAlias;
                    timeCheckResult.DocTitle = timeCheckResult.DocTypeName;
                    timeCheckResult.QCScore = timeQCRule.QCScore;
                    timeCheckResult.ResultDesc = timeQCRule.RuleDesc;
                    timeCheckResult.IsRepeat = timeQCRule.IsRepeat;
                    timeCheckResult.IsStopRight = timeQCRule.IsStopRight;
                    timeCheckResult.WrittenState = WrittenState.Uncheck;
                    timeCheckResult.EventTime = timeQCEventResult.EventTime.Value;
                    //timeCheckResult.InnerTime = timeCheckResult.DocTime;
                    timeCheckResult.StartTime = dtPeriodTime;
                    string szWrittenPeriod = timeQCRule.WrittenPeriod;
                    string szPeriodDesc = null;
                    timeCheckResult.EndTime =
                        this.GetWrittenPeriod(szWrittenPeriod, dtPeriodTime, ref szPeriodDesc);
                    timeCheckResult.WrittenPeriod = szPeriodDesc;
                    timeCheckResult.DoctorLevel = timeQCEventResult.DoctorLevel;
                    lstTimeCheckResults.Add(timeCheckResult);
                    dtPeriodTime = timeCheckResult.EndTime;
                } while (timeQCRule.IsRepeat && dtPeriodTime < timeQCEventResult.EndTime && dtPeriodTime < timeQCRule.ValidateTime);//当转院，死亡等事件发生后，
                //不用再循环创建应书写病历，所以需要  dtPeriodTime < timeQCEventResult.EndTime（timeQCEventResult.EndTime：转院或死亡等事件发生时间）

                //while (timeQCRule.IsRepeat && dtPeriodTime < timeQCEventResult.EndTime && (!IsRuleAsDocCommited || (IsRuleAsDocCommited && dtPeriodTime < timeQCRule.ValidateTime))); 
            }
            return lstTimeCheckResults;
        }

        /// <summary>
        /// 获取已书写的指定病历类型的病历列表
        /// </summary>
        /// <param name="szDocTypeIDList">指定病历类型列表</param>
        /// <returns>已书写的指定病历类型的病历列表</returns>
        private List<MedDocInfo> GetDocumentList(string szDocTypeIDList)
        {
            if (this.m_dicDocInfos == null)
                this.InitDocumentDict();
            if (this.m_dicDocInfos == null || this.m_dicDocInfos.Count <= 0)
                return null;
            //高效拆分ID号
            List<MedDocInfo> lstWrittenDocInfos =
                new List< MedDocInfo>();

            //如何doctypeidlist为空,则所有文书
            if (string.IsNullOrEmpty(szDocTypeIDList))
            {
                foreach (List< MedDocInfo> item in this.m_dicDocInfos.Values)
                {
                    lstWrittenDocInfos.AddRange(item);
                }
            }


            StringBuilder sbDocTypeID = new StringBuilder();
            int index = 0;
            int count = szDocTypeIDList.Length;
            while (index < count)
            {
                char ch = szDocTypeIDList[index++];
                if (ch != ';')
                {
                    if (ch != ' ')
                        sbDocTypeID.Append(ch);
                    if (index < count)
                        continue;
                }
                if (sbDocTypeID.Length > 0)
                {
                    List<MedDocInfo> lstCurrDocInfos = null;
                    if (this.m_dicDocInfos.ContainsKey(sbDocTypeID.ToString()))
                        lstCurrDocInfos = this.m_dicDocInfos[sbDocTypeID.ToString()];
                    if (lstCurrDocInfos != null && lstCurrDocInfos.Count > 0)
                        lstWrittenDocInfos.AddRange(lstCurrDocInfos);
                    sbDocTypeID.Remove(0, sbDocTypeID.Length);
                }
            }

            return lstWrittenDocInfos;
        }

        /// <summary>
        /// 初始化已写病历字典表
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        private short InitDocumentDict()
        {
            if (TimeEventHandler.Instance.TimeCheckQuery == null)
                return SystemData.ReturnValue.OK;
            if (this.m_dicDocInfos != null)
                return SystemData.ReturnValue.OK;
            if (this.m_dicDocInfos != null && this.m_dicDocInfos.Count <= 0)
                return SystemData.ReturnValue.CANCEL;

            this.m_dicDocInfos = new Dictionary<string,MedDocList>();

            string szPatientID = TimeEventHandler.Instance.TimeCheckQuery.PatientID;
            string szVisitID = TimeEventHandler.Instance.TimeCheckQuery.VisitNO;//编辑器将visit_id存成了visit_no
            MedDocList lstDocInfos = null;
            short shRet = EmrDocAccess.Instance.GetDocInfos(szPatientID, szVisitID
                , SystemData.VisitType.IP, DateTime.Now, null, ref lstDocInfos);
            if (shRet != SystemData.ReturnValue.OK)
                return shRet;
            if (lstDocInfos == null || lstDocInfos.Count <= 0)
                return SystemData.ReturnValue.CANCEL;

            lstDocInfos.SortByTime(false);
            for (int index = 0; index < lstDocInfos.Count; index++)
            {
                string szDocTypeID = lstDocInfos[index].DOC_TYPE;
                MedDocList lstCurrTypeDocInfos = null;
                if (this.m_dicDocInfos.ContainsKey(szDocTypeID))
                {
                    lstCurrTypeDocInfos = this.m_dicDocInfos[szDocTypeID];
                    lstCurrTypeDocInfos.Add(lstDocInfos[index]);
                }
                else
                {
                    lstCurrTypeDocInfos = new MedDocList();
                    lstCurrTypeDocInfos.Add(lstDocInfos[index]);
                    this.m_dicDocInfos.Add(szDocTypeID, lstCurrTypeDocInfos);
                }
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 将用户设置的期限字符串转换成文档书写期限时间
        /// </summary>
        /// <param name="szWrittenPeriod">期限字符串</param>
        /// <param name="dtBaseTime">基准时间点</param>
        /// <param name="szPeriodDesc">返回解析后的缺陷描述</param>
        /// <returns>文档书写期限时间</returns>
        private DateTime GetWrittenPeriod(string szWrittenPeriod, DateTime dtBaseTime, ref string szPeriodDesc)
        {
            int nPeriodTime = 24;
            if (szWrittenPeriod == null)
                goto EXCEPTION_LABEL;
            szWrittenPeriod = szWrittenPeriod.Trim();
            if (szWrittenPeriod.Length <= 1 || szWrittenPeriod.Length > 4)
                goto EXCEPTION_LABEL;

            //获取时间间隔数值
            string szPeriodTimeValue = szWrittenPeriod.Substring(0, szWrittenPeriod.Length - 1);
            if (!int.TryParse(szPeriodTimeValue, out nPeriodTime))
                goto EXCEPTION_LABEL;

            if (szWrittenPeriod.EndsWith("H"))
            {
                szPeriodDesc = nPeriodTime.ToString() + "小时";
                return dtBaseTime.AddHours(nPeriodTime);
            }
            else if (szWrittenPeriod.EndsWith("D"))
            {
                szPeriodDesc = nPeriodTime.ToString() + "天";
                DateTime dtEndTime = dtBaseTime.AddDays(nPeriodTime);
                return DateTime.Parse(dtEndTime.ToString("yyyy-MM-dd 23:59:59"));
            }
            else if (szWrittenPeriod.EndsWith("M"))
            {
                szPeriodDesc = nPeriodTime.ToString() + "月";
                DateTime dtEndTime = dtBaseTime.AddMonths(nPeriodTime);
                int nMonthDays = DateTime.DaysInMonth(dtEndTime.Year, dtEndTime.Month);
                return DateTime.Parse(string.Format("{0}-{1}-{2} 23:59:59", dtEndTime.Year, dtEndTime.Month, nMonthDays));
            }

            EXCEPTION_LABEL:
            szPeriodDesc = nPeriodTime.ToString() + "小时";
            LogManager.Instance.WriteLog("DocumentHandler.GetDocPeriodTime", new string[] { "szWrittenPeriod", "dtBaseTime" }
                    , new object[] { szWrittenPeriod, dtBaseTime }, "日期时间限格式错误!");
            return dtBaseTime.AddHours(nPeriodTime);
        }
    }
}
