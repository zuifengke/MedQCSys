using EMRDBLib;
using EMRDBLib.DbAccess;
using MedDocSys.QCEngine.TimeCheck;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;


using Heren.MedQC.Core;
namespace Heren.MedQC.CheckPoint.Commands
{
    /// <summary>
    /// 缺陷内容：缺死亡记录或未在患者出院后24小时内完成
    /// 核查方法：患者死亡24小时后无名称为“死亡记录”的病历文件。死亡时间以死亡医嘱下达时间为准。患者“死亡记录”病历文件的医生审签时间在患者死亡24小时后。死亡时间以死亡医嘱下达时间为准。
    /// </summary>
    public class siwangjilushixiaoCommand : AbstractCommand
    {
        public siwangjilushixiaoCommand()
        {
            this.m_name = "新军卫-缺死亡记录或未在患者出院后24小时内完成";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);

            QcCheckResult qcCheckResult = result as QcCheckResult;
            string szPeriodDesc = string.Empty;
            //通过时效帮助类，创建一张病历正常书写的用于比对的时效检查时间表
            List<TimeCheckResult> lstTimeCheckResults = TimeCheckHelper.Instance.CreateTimeCheckTable(qcCheckPoint, patVisitLog);
            if (lstTimeCheckResults == null || lstTimeCheckResults.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            DateTime dtEndTime = lstTimeCheckResults[0].EndTime;
            DateTime dtStartTime = lstTimeCheckResults[0].StartTime;
            //查询患者指定文书类型ID号
            List<MedDocInfo> documentlist = TimeCheckHelper.Instance.GetDocumentList(qcCheckPoint.DocTypeID, patVisitLog.MedDocInfos);
            if (documentlist == null || documentlist.Count == 0)
            {
                if (dtEndTime > DateTime.Now)
                {
                    qcCheckResult.QC_EXPLAIN = "死亡记录书写期限未到";
                    qcCheckResult.QC_RESULT = 1;
                    return true;
                }
                qcCheckResult.QC_EXPLAIN = "期限已到,未写死亡记录";
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            qcCheckResult.DOC_SETID = documentlist[0].DOC_SETID;
            qcCheckResult.DOC_TITLE = documentlist[0].DOC_TITLE;
            qcCheckResult.DOCTYPE_ID = documentlist[0].DOC_TYPE;
            qcCheckResult.DOC_TIME = documentlist[0].DOC_TIME;
            qcCheckResult.DOC_SETID = documentlist[0].DOC_SETID;
            qcCheckResult.MODIFY_TIME = documentlist[0].MODIFY_TIME;
            qcCheckResult.CREATE_ID = documentlist[0].CREATOR_ID;
            qcCheckResult.CREATE_NAME = documentlist[0].CREATOR_NAME;

            if (documentlist[0].DOC_TIME > dtEndTime)
            {
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.QC_EXPLAIN = string.Format("患者{0}下达死亡医嘱，书写{1}时间{2},截止时间{3},结果超时"
                    , dtStartTime.ToString("yyyy-MM-dd HH:mm")
                    , documentlist[0].DOC_TITLE
                    , documentlist[0].DOC_TIME.ToString()
                    , dtEndTime.ToString("yyyy-MM-dd HH:mm")
                    );
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            qcCheckResult.QC_RESULT = 1;
            qcCheckResult.QC_EXPLAIN = string.Format("患者{0}下达死亡医嘱，书写{1}时间{2},截止时间{3},结果正常"
               , dtStartTime.ToString("yyyy-MM-dd HH:mm")
                    , documentlist[0].DOC_TITLE
                    , documentlist[0].DOC_TIME.ToString()
                    , dtEndTime.ToString("yyyy-MM-dd HH:mm")
                );

            qcCheckResult.QC_EXPLAIN = "规则通过";
            qcCheckResult.QC_RESULT = 1;
            return true;
        }
    }
}
