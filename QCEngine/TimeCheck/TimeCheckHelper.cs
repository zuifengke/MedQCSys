using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedDocSys.QCEngine.TimeCheck
{
    public class TimeCheckHelper 
    {
        private static TimeCheckHelper m_Instance = null;
        public static TimeCheckHelper Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new TimeCheckHelper();
                return m_Instance;
            }
        }
        public short GenerateTimeRecord(PatVisitInfo item,DateTime now)
        {
            short shRet = SystemData.ReturnValue.OK;
            if (string.IsNullOrEmpty(item.INCHARGE_DOCTOR))
            {
                string szDoctorIncharge = string.Empty;
                //通过病人视图无法取到责任医生，由于首页未录入造成，通过最近书写的一份文书去取
                shRet = EmrDocAccess.Instance.GetDoctorInChargeByEmrDoc(item.PATIENT_ID, item.VISIT_ID,
                    ref szDoctorIncharge);
                if (shRet == SystemData.ReturnValue.OK)
                    item.INCHARGE_DOCTOR = szDoctorIncharge;
            }
            TimeCheckQuery timeCheckQuery = new TimeCheckQuery();
            timeCheckQuery.PatientID = item.PATIENT_ID;
            //timeCheckQuery.VisitID = item.VISIT_ID;
            //timeCheckQuery.VisitID = SystemParam.Instance.PatVisitLog.VISIT_ID;
            //编辑器VISIT_NO=VISIT_ID
            timeCheckQuery.VisitID = item.VISIT_NO;
            timeCheckQuery.VisitNO = item.VISIT_NO;
            timeCheckQuery.PatientName = item.PATIENT_NAME;
            timeCheckQuery.DeptCode = item.DEPT_CODE;
            try
            {
                TimeCheckEngine.Instance.PerformTimeCheck(timeCheckQuery);
            }
            catch (Exception ex)
            {
               
                
                LogManager.Instance.WriteLog("TimeCheckEngine.Instance.PerformTimeCheck 时效接口调用失败", ex);
                
                return SystemData.ReturnValue.EXCEPTION;
            }
            //获取已经保存在数据库QC_TIME_RECORD_T表里面的时效结果
            List<QcTimeRecord> lstExitQCTimeRecord = new List<QcTimeRecord>();
            QcTimeRecordAccess.Instance.GetQcTimeRecords(item.PATIENT_ID, item.VISIT_ID, ref lstExitQCTimeRecord);

            //保存时效质控分析结果
            List<TimeCheckResult> lstCheckResults = TimeCheckEngine.Instance.TimeCheckResults;

            if (lstCheckResults == null)
                return SystemData.ReturnValue.RES_NO_FOUND;
            List<QcTimeRecord> lstQcTimeRecord = new List<QcTimeRecord>();
            for (int index = 0; index < lstCheckResults.Count; index++)
            {
                QcTimeRecord qcTimeRecord = new QcTimeRecord();
                TimeCheckResult resultInfo = lstCheckResults[index];
                resultInfo.VisitID = item.VISIT_ID;
                qcTimeRecord.BeginDate = resultInfo.StartTime;
                qcTimeRecord.CheckDate = now;
                qcTimeRecord.CheckName = "系统自动";
                qcTimeRecord.CreateID = resultInfo.CreatorID;
                qcTimeRecord.CreateName = resultInfo.CreatorName;
                qcTimeRecord.DeptInCharge = item.DEPT_CODE;
                qcTimeRecord.DeptStayed = item.DEPT_NAME;
                qcTimeRecord.DocID = resultInfo.DocID;
                qcTimeRecord.DocTitle = resultInfo.DocTitle;
                qcTimeRecord.DoctorInCharge = item.INCHARGE_DOCTOR;
                qcTimeRecord.DocTypeID = resultInfo.DocTypeID;
                qcTimeRecord.DocTypeName = resultInfo.DocTypeName;
                qcTimeRecord.EndDate = resultInfo.EndTime;
                qcTimeRecord.EventID = resultInfo.EventID;
                qcTimeRecord.EventName = resultInfo.EventName;
                qcTimeRecord.EventTime = resultInfo.EventTime;
                qcTimeRecord.PatientID = item.PATIENT_ID;
                qcTimeRecord.PatientName = item.PATIENT_NAME;
                qcTimeRecord.Point = resultInfo.QCScore;
                qcTimeRecord.DischargeTime = item.DISCHARGE_TIME;
                qcTimeRecord.QcExplain = resultInfo.ResultDesc;
                qcTimeRecord.IsVeto = resultInfo.IsVeto;
                if (resultInfo.WrittenState == WrittenState.Early)
                    qcTimeRecord.QcResult = SystemData.WrittenState.Early;
                if (resultInfo.WrittenState == WrittenState.Normal)
                    qcTimeRecord.QcResult = SystemData.WrittenState.Normal;
                if (resultInfo.WrittenState == WrittenState.Timeout)
                    qcTimeRecord.QcResult = SystemData.WrittenState.Timeout;
                if (resultInfo.WrittenState == WrittenState.Unwrite)
                {
                    //根据海总需求，将未书写的文书分成两种状态：一种是未书写，另一种是正常未书写。第一种代表已经超时了，需要进行扣分。
                    if (resultInfo.EndTime < now)
                    {
                        //病历未书写超过截止时间，状态为未书写超时
                        qcTimeRecord.QcResult = SystemData.WrittenState.Unwrite;
                    }
                    else
                    {
                        qcTimeRecord.QcResult = SystemData.WrittenState.UnwriteNormal;
                    }
                }
                // qcTimeRecord.QcResult = SystemData.WrittenState.Unwrite;
                qcTimeRecord.RecNo = "0"; //未做处理
                qcTimeRecord.RecordTime = resultInfo.RecordTime;
                qcTimeRecord.DocTime = resultInfo.DocTime;
                qcTimeRecord.VisitID = resultInfo.VisitID;
                if (!resultInfo.IsRepeat)
                {
                    qcTimeRecord.QcExplain = string.Format("病人{0}{1},{2}内书写{3}"
                        , resultInfo.EventTime.ToString("yyyy-M-d HH:mm")
                        , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                }
                else
                {
                    qcTimeRecord.QcExplain = string.Format("病人{0}{1},每{2}书写一次{3}"
                        , resultInfo.EventTime.ToString("yyyy-M-d HH:mm")
                        , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                }

                //判断是否已短信通知，海总需求：时效记录已存在的会写入个人统计表，进行短信通知，所以主键相同的已存数据将标记为短信通知，通过该字段避免写入统计到个人的表从而解决重复短信发送的问题。
                if (lstExitQCTimeRecord != null && lstExitQCTimeRecord.Count > 0)
                {
                    foreach (QcTimeRecord exitTimeRecord in lstExitQCTimeRecord)
                    {
                        //QCTimeRecord主键为PatientId,VisitID,DocTypeID,BeginDate,EndDate,QcResult,EventTime
                        if (exitTimeRecord.PatientID == qcTimeRecord.PatientID
                            && exitTimeRecord.VisitID == qcTimeRecord.VisitID
                            && exitTimeRecord.DocTypeID == qcTimeRecord.DocTypeID
                            && exitTimeRecord.BeginDate == qcTimeRecord.BeginDate
                            && exitTimeRecord.EndDate == qcTimeRecord.EndDate
                            && exitTimeRecord.QcResult == qcTimeRecord.QcResult
                            && exitTimeRecord.EventTime == qcTimeRecord.EventTime)
                        {
                            //已存在的记录为当天的，则短信通知仍旧为未通知,主要是测试中会在当天运行两次以上
                            //实际情况是每日只会运行一次
                            if (qcTimeRecord.CheckDate.ToShortDateString() !=
                                exitTimeRecord.CheckDate.ToShortDateString())
                                qcTimeRecord.MessageNotify = true;
                        }
                    }
                }
                lstQcTimeRecord.Add(qcTimeRecord);
            }
            shRet = QcTimeRecordAccess.Instance.SavePatientQcTimeRecord(item.PATIENT_ID, item.VISIT_ID, lstQcTimeRecord);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog(string.Format("病人{0} 时效质控记录生成失败", item.PATIENT_NAME));
                
            }
            return shRet;
        }
    }
}
