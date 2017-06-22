using System;
using System.Collections.Generic;
using System.Text;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using MedDocSys.QCEngine.TimeCheck;
using EMRDBLib.Entity;
using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint
{
    /// <summary>
    /// 时效性缺陷处理帮助类
    /// </summary>
    public class TimeCheckHelper
    {
        private static TimeCheckHelper _Instance = null;
        public static TimeCheckHelper Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new TimeCheckHelper();
                return _Instance;
            }

        }
        /// <summary>
        /// 初始化规则检查前的患者资料基础数据
        /// </summary>
        public void InitPatientInfo(PatVisitInfo patVisitLog)
        {
            //1.患者基本信息
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, ref patVisitLog);
            //2.初始化文书列表
            List<MedDocInfo> lstMedDocInfo= new List<MedDocInfo>();
            shRet = EmrDocAccess.Instance.GetDocList(patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, ref lstMedDocInfo);
            patVisitLog.MedDocInfos = lstMedDocInfo;
        }
        /// <summary>
        /// 运行某患者病案自动检查缺陷内容
        /// </summary>
        public void CheckPatient(PatVisitInfo patVisitLog)
        {
            //获取缺陷自动检查配置规则列表
            List<QcCheckPoint> lstQcCheckPoint = null;
            short shRet = QcCheckPointAccess.Instance.GetQcCheckPoints(ref lstQcCheckPoint);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            foreach (var item in lstQcCheckPoint)
            {
                if (string.IsNullOrEmpty(item.HandlerCommand))
                    continue;
                object result = null;
                CommandHandler.Instance.SendCommand(item.HandlerCommand, item, patVisitLog, out result);
                QcCheckResult qcCheckResult = result as QcCheckResult;
                if (qcCheckResult == null)
                    continue;
                QcCheckResultAccess.Instance.SaveQcCheckResult(qcCheckResult);

            }
        }

        /// <summary>
        /// 将用户设置的期限字符串转换成文档书写期限时间
        /// </summary>
        /// <param name="szWrittenPeriod">期限字符串</param>
        /// <param name="dtBaseTime">基准时间点</param>
        /// <param name="szPeriodDesc">返回解析后的缺陷描述</param>
        /// <returns>文档书写期限时间</returns>
        public DateTime GetWrittenPeriod(string szWrittenPeriod, DateTime dtBaseTime, ref string szPeriodDesc)
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

        /// <summary>
        /// 获取已书写的指定病历类型的病历列表
        /// </summary>
        /// <param name="szDocTypeIDList">指定病历类型列表</param>
        /// <param name="lstMedDocInfo">患者所有病历文书</param>
        /// <returns>已书写的指定病历类型的病历列表</returns>
        public List<MedDocInfo> GetDocumentList(string szDocTypeIDList, List<MedDocInfo> lstMedDocInfo)
        {
            List<MedDocInfo> lstWrittenDocInfos =
                new List<MedDocInfo>();
            string[] arrDocTypeIDs = szDocTypeIDList.Split(';');
            foreach (var item in arrDocTypeIDs)
            {
                var result = lstMedDocInfo.FindAll(m => m.DOC_TYPE == item);
                if (result != null)
                    lstWrittenDocInfos.AddRange(result);
            }
            return lstWrittenDocInfos;
        }

        /// <summary>
        /// 创建一张病历正常书写的用于比对的时效检查时间表
        /// </summary>
        /// <param name="qcCheckPoint">指定时效规则</param>
        /// <param name="lstTimeQCEventResults">时效事件执行结果</param>
        /// <returns>时效检查时间表列表</returns>
        public List<TimeCheckResult> CreateTimeCheckTable(QcCheckPoint qcCheckPoint
            , PatVisitInfo patVisitLog)
        {
            //查询事件结果
            TimeEventHandler.Instance.TimeCheckQuery = new TimeCheckQuery();
            TimeEventHandler.Instance.TimeCheckQuery.PatientID = patVisitLog.PATIENT_ID;
            TimeEventHandler.Instance.TimeCheckQuery.PatientName = patVisitLog.PATIENT_NAME;
            TimeEventHandler.Instance.TimeCheckQuery.VisitID = patVisitLog.VISIT_ID;
            TimeEventHandler.Instance.TimeCheckQuery.BedCode = patVisitLog.BED_CODE;
            TimeEventHandler.Instance.TimeCheckQuery.VisitTime = patVisitLog.VISIT_TIME;

            List<TimeQCEventResult> lstTimeQCEventResults = TimeEventHandler.Instance.PerformTimeEvent(qcCheckPoint.EventID);
            if (lstTimeQCEventResults == null || lstTimeQCEventResults.Count <= 0)
                return null;
            if (TimeEventHandler.Instance.TimeCheckQuery == null)
                return null;

            DateTime dtEndValidTime = patVisitLog.DISCHARGE_TIME == patVisitLog.DefaultTime ? DateTime.Now : patVisitLog.DISCHARGE_TIME;
            List <TimeCheckResult> lstTimeCheckResults = new List<TimeCheckResult>();
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
            
                do
                {
                    TimeCheckResult timeCheckResult = new TimeCheckResult();
                    timeCheckResult.PatientID = szPatientID;
                    timeCheckResult.VisitID = szVisitID;
                    timeCheckResult.EventID = qcCheckPoint.EventID;
                    timeCheckResult.EventName = qcCheckPoint.EventName;
                    timeCheckResult.PatientName = szPatientName;
                    timeCheckResult.DocTypeID = qcCheckPoint.DocTypeID;
                    timeCheckResult.DocTypeName = qcCheckPoint.DocTypeName;
                    timeCheckResult.BedCode = szBedCode;
                    timeCheckResult.VisitTime = dtVisitTime;
                    timeCheckResult.DocTitle = timeCheckResult.DocTypeName;
                    timeCheckResult.QCScore = qcCheckPoint.Score;
                    timeCheckResult.ResultDesc = qcCheckPoint.MsgDictMessage;
                    timeCheckResult.IsRepeat = qcCheckPoint.IsRepeat;
                    timeCheckResult.WrittenState = WrittenState.Uncheck;
                    timeCheckResult.EventTime = timeQCEventResult.EventTime.Value;
                    //timeCheckResult.InnerTime = timeCheckResult.DocTime;
                    timeCheckResult.StartTime = dtPeriodTime;
                    string szWrittenPeriod = qcCheckPoint.WrittenPeriod;
                    string szPeriodDesc = null;
                    timeCheckResult.EndTime =
                        this.GetWrittenPeriod(szWrittenPeriod, dtPeriodTime, ref szPeriodDesc);
                    timeCheckResult.WrittenPeriod = szPeriodDesc;
                    timeCheckResult.DoctorLevel = timeQCEventResult.DoctorLevel;
                    lstTimeCheckResults.Add(timeCheckResult);
                    dtPeriodTime = timeCheckResult.EndTime;
                } while (qcCheckPoint.IsRepeat && dtPeriodTime < timeQCEventResult.EndTime && dtPeriodTime < dtEndValidTime);
                //当转院，死亡等事件发生后，不用再循环创建应书写病历，所以需要  dtPeriodTime < timeQCEventResult.EndTime（timeQCEventResult.EndTime：转院或死亡等事件发生时间）
               
            }
            return lstTimeCheckResults;
        }
    }
}
