using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 缺陷点：首次病程记录未在患者入院后8小时内完成
    /// 核查内容：首次病程的医生审签时间在患者进入院8小时后。
    /// </summary>
    public class shoucibingchengjilushixiaoCommand : AbstractCommand
    {
        public shoucibingchengjilushixiaoCommand()
        {
            this.m_name = "新军卫-首次病程记录8小时内完成";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询患者指定文书类型ID号
            string szPeriodDesc = string.Empty;
            DateTime dtEndTime = TimeCheckHelper.Instance.GetWrittenPeriod(qcCheckPoint.WrittenPeriod,patVisitLog.VISIT_TIME,ref szPeriodDesc);
          
            List<MedDocInfo> documentlist = TimeCheckHelper.Instance.GetDocumentList(qcCheckPoint.DocTypeID, patVisitLog.MedDocInfos);
            foreach (var item in documentlist)
            {
                //找到文书入院记录相关的文书，判断文档创建时间是否在入院24小时之内
                if (item.DOC_TIME > dtEndTime)
                {
                    qcCheckResult.QC_RESULT = 0;
                    qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，书写{1}时间{2},结果超时", patVisitLog.VISIT_TIME.ToString(), item.DOC_TITLE, item.DOC_TIME.ToString());
                }
                else {
                    qcCheckResult.QC_RESULT = 1;
                    qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，书写{1}时间{2},结果正常", patVisitLog.VISIT_TIME.ToString(), item.DOC_TITLE, item.DOC_TIME.ToString());
                }
                qcCheckResult.DOC_TITLE = item.DOC_TITLE;
                qcCheckResult.DOC_TIME = item.DOC_TIME;
                qcCheckResult.DOC_SETID = item.DOC_SETID;
                qcCheckResult.DOCTYPE_ID = item.DOC_TYPE;
                qcCheckResult.MODIFY_TIME = item.MODIFY_TIME;
                qcCheckResult.CREATE_ID = item.CREATOR_ID;
                qcCheckResult.CREATE_NAME = item.CREATOR_NAME;
                break;
            }
            if (string.IsNullOrEmpty(qcCheckResult.QC_EXPLAIN) && DateTime.Now > dtEndTime)
            {
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，相关病历未书写，期限已到，结果超时", patVisitLog.VISIT_TIME.ToString());
            }
            else if(string.IsNullOrEmpty(qcCheckResult.QC_EXPLAIN))
            {
                qcCheckResult.QC_RESULT = 1;
                qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，相关病历未书写，期限未到，结果正常", patVisitLog.VISIT_TIME.ToString());

            }
            qcCheckResult.ERROR_COUNT = 1;
            return true;
        }
    }
}
