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
    /// 缺陷点：择期中等以上手术无术前讨论记录
    /// 核查内容：中等以上手术，需要有术前讨论记录。急诊手术需在术后三天内完成。
    /// </summary>
    public class shuqiantaolunshixiaoCommand : AbstractCommand
    {
        public shuqiantaolunshixiaoCommand()
        {
            this.m_name = "新军卫-择期中等以上手术无术前讨论记录";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询患者指定文书类型ID号
            string szSQl = string.Format("select a.OPERATING_SCALE,a.START_DATE_TIME, a.end_date_time  from operation_master_v a where a.VISIT_NO ='{0}' and a.PATIENT_ID ='{1}' and a.OPERATING_SCALE in ('中','大','特') and a.START_DATE_TIME is not null"
                , patVisitLog.VISIT_NO
                , patVisitLog.PATIENT_ID);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_RESULT = 1;
                qcCheckResult.QC_EXPLAIN = "规则通过";
                return true;
            }

            string szPeriodDesc = string.Empty;
            List<MedDocInfo> documentlist = TimeCheckHelper.Instance.GetDocumentList(qcCheckPoint.DocTypeID, patVisitLog.MedDocInfos);
            StringBuilder sb = new StringBuilder();
            bool exist = false;
            int errorCount = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DateTime START_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[i]["START_DATE_TIME"].ToString());
                foreach (var item in documentlist)
                {
                    if (item.RECORD_TIME < START_DATE_TIME && item.DOC_TIME < START_DATE_TIME)
                    {
                        exist = true;
                        sb.AppendFormat("患者{0}开始手术,{1}书写术前讨论,结果正常"
                            , START_DATE_TIME.ToString("yyyy-MM-dd HH:mm")
                            , item.DOC_TIME.ToString("yyyy-MM-dd HH:mm"));
                        sb.AppendLine();
                        break;
                    }
                }
                if (!exist)
                {
                    errorCount++;
                    sb.AppendFormat("患者{0}开始手术,无术前讨论"
                         , START_DATE_TIME.ToString("yyyy-MM-dd HH:mm"));
                    sb.AppendLine();
                }
            }
            if (errorCount > 0)
            {
                qcCheckResult.QC_EXPLAIN = sb.ToString();
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.ERROR_COUNT = errorCount;
            }
            else
            {
                qcCheckResult.QC_EXPLAIN = "规则通过："+sb.ToString();
                qcCheckResult.QC_RESULT = 1;
                qcCheckResult.ERROR_COUNT = 0;
            }
            return true;
        }
    }
}
