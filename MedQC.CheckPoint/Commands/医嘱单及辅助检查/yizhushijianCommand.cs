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
    /// 缺陷内容：医嘱开具或停止时间不明确 
    /// 核查方法：患者出院后在患者医嘱中，非作废医嘱须有开始时间和结束时间。
    /// </summary>
    public class yizhushijianCommand : AbstractCommand
    {
        public yizhushijianCommand()
        {
            this.m_name = "新军卫-医嘱开具或停止时间不明确";
        }
        public override bool Execute(object param, object data, out object result)
        {

            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            if (patVisitLog.DISCHARGE_TIME == DateTime.Parse("1900-01-01"))
            {
                qcCheckResult.QC_EXPLAIN = "患者未出院，规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            string szSQl = string.Format("select a.order_text,a.END_DATE_TIME,a.START_DATE_TIME from orders_v a where a.VISIT_ID ='{1}' and a.PATIENT_ID ='{0}' and a.ORDER_STATUS not in (4,7) and (END_DATE_TIME is null or START_DATE_TIME is null)"
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_RESULT = 1;//通过
                qcCheckResult.QC_EXPLAIN = "规则通过";
                return true;
            }
            StringBuilder sb = new StringBuilder();
            for (int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                string order_text = ds.Tables[0].Rows[i]["order_text"].ToString();
                string END_DATE_TIME = ds.Tables[0].Rows[i]["END_DATE_TIME"].ToString();
                string START_DATE_TIME = ds.Tables[0].Rows[i]["START_DATE_TIME"].ToString();
                sb.AppendFormat("医嘱{0}，开始时间为{1}，停止时间为{2};"
                    , order_text
                    , string.IsNullOrEmpty(START_DATE_TIME) ? "空" : START_DATE_TIME
                    , string.IsNullOrEmpty(END_DATE_TIME) ? "空" : END_DATE_TIME);
                sb.AppendLine();
            }
            qcCheckResult.QC_EXPLAIN = sb.ToString();
            qcCheckResult.QC_RESULT = 0;//通过
            qcCheckResult.ERROR_COUNT = 1;
            return true;
        }
    }
}
