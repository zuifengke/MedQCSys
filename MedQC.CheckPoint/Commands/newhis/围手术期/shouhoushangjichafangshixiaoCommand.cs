using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using MedDocSys.QCEngine.TimeCheck;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 缺陷点：新军卫-手术后3天内未完成上级医师查房记录
    /// 核查内容：中等以上手术，术后3天内有上级医师查房记录。病历内容中有关键词“主任”或“副主任”或“主任医师”或“副主任医师”或“主治医师”或“上级医师”或“上级医生”的可计算为上级医生查房记录。并且查房的上级医生姓名为医院三级医师配置目录中的二级、三级医生姓名。
    /// </summary>
    public class shouhoushangjichafangshixiaoCommand : AbstractCommand
    {
        public shouhoushangjichafangshixiaoCommand()
        {
            this.m_name = "新军卫-手术后3天内未完成上级医师查房记录";
        }
        public override bool Execute(object param, object data, out object result)
        {
            try
            {
                QcCheckPoint qcCheckPoint = param as QcCheckPoint;
                PatVisitInfo patVisitLog = data as PatVisitInfo;
                result = null;
                if (qcCheckPoint.EventID == string.Empty)
                    return false;
                result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
                QcCheckResult qcCheckResult = result as QcCheckResult;
                //通过时效帮助类，创建一张病历正常书写的用于比对的时效检查时间表
                List<TimeCheckResult> lstTimeCheckResults = TimeCheckHelper.Instance.CreateTimeCheckTable(qcCheckPoint, patVisitLog);
                if (lstTimeCheckResults == null)
                {
                    qcCheckResult.QC_EXPLAIN = "规则通过";
                    qcCheckResult.QC_RESULT = 1;
                    return true;
                }
                //查询患者指定文书类型ID号

                List<MedDocInfo> documentlist = TimeCheckHelper.Instance.GetDocumentList(qcCheckPoint.DocTypeID, patVisitLog.MedDocInfos);
                int nErrorCount = 0;
                for (int index = 0; index < lstTimeCheckResults.Count; index++)
                {
                    TimeCheckResult timeCheckResult = lstTimeCheckResults[index];
                    if (timeCheckResult == null)
                        continue;
                    if (documentlist == null || documentlist.Count <= 0)
                    {
                        timeCheckResult.WrittenState = WrittenState.Unwrite;
                        continue;
                    }
                    //核对病历内部时间以及实际书写时间
                    for (int nDocIndex = 0; nDocIndex < documentlist.Count; nDocIndex++)
                    {
                        MedDocInfo docInfo = documentlist[nDocIndex];
                        if (docInfo.RECORD_TIME != docInfo.DefaultTime
                            && (docInfo.RECORD_TIME < timeCheckResult.StartTime || docInfo.RECORD_TIME > timeCheckResult.EndTime))
                            continue;
                        if (docInfo.DOC_TIME < timeCheckResult.StartTime)
                            timeCheckResult.WrittenState = WrittenState.Early;
                        else if (docInfo.DOC_TIME > timeCheckResult.EndTime)
                            timeCheckResult.WrittenState = WrittenState.Timeout;
                        else
                            timeCheckResult.WrittenState = WrittenState.Normal;

                        timeCheckResult.DocTime = docInfo.DOC_TIME;
                        timeCheckResult.RecordTime = docInfo.RECORD_TIME;
                        timeCheckResult.DocID = docInfo.DOC_ID;
                        timeCheckResult.CreatorName = docInfo.CREATOR_NAME;
                        timeCheckResult.CreatorID = docInfo.CREATOR_ID;
                        break;
                    }
                }
                StringBuilder sbQcExplain = new StringBuilder();
                foreach (var item in lstTimeCheckResults)
                {
                    if (item.WrittenState == WrittenState.Timeout)
                    {
                        sbQcExplain.AppendFormat("患者{0}{1}，书写{2}时间{3},开始时间{4}截止时间{5},结果超时"
                          , item.EventTime.ToString()
                          , item.EventName
                          , item.DocTitle
                          , item.DocTime.ToString()
                          , item.StartTime.ToString()
                          , item.EndTime.ToString()
                          );
                        sbQcExplain.AppendLine();
                        nErrorCount++;
                    }
                    else if (item.WrittenState == WrittenState.Unwrite || item.WrittenState == WrittenState.Uncheck)
                    {
                        if (item.EndTime < DateTime.Now)
                        {
                            sbQcExplain.AppendFormat("患者{0}{1}，{2}未书写,开始时间{3}截止时间{4},期限已到，结果超时"
                              , item.EventTime.ToString()
                              , item.EventName
                              , item.DocTitle
                              , item.StartTime.ToString()
                              , item.EndTime.ToString()
                              );
                            sbQcExplain.AppendLine();
                            nErrorCount++;
                        }
                    }
                }
                //找到文书入院记录相关的文书，判断文档创建时间是否在入院24小时之内
                if (nErrorCount > 0)
                {
                    qcCheckResult.QC_RESULT = 0;
                }
                else
                {
                    qcCheckResult.QC_RESULT = 1;

                }
                qcCheckResult.DOC_TITLE = qcCheckPoint.DocTypeName;
                qcCheckResult.DOCTYPE_ID = qcCheckPoint.DocTypeID;
                qcCheckResult.QC_EXPLAIN = sbQcExplain.Length > 2000 ? sbQcExplain.ToString().Substring(0, 2000) : sbQcExplain.ToString();
                qcCheckResult.ERROR_COUNT = nErrorCount;
                return true;
            }
            catch (Exception ex)
            {
                result = null;
                LogManager.Instance.WriteLog("新军卫-缺术后第三天病程记录命令发生异常", ex);
                return false;
            }
        }
    }
}
