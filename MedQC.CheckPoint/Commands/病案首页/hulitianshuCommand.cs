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
    /// 缺陷内容：护理天数之和大于住院天数
    /// 核查方法：特级、一级护理、二级护理、三级护理之和不能大于住院天数（当天出院除外）
    /// </summary>
    public class hulitianshuCommand : AbstractCommand
    {
        public hulitianshuCommand()
        {
            this.m_name = "新军卫-护理天数之和大于住院天数";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szSQl = string.Format("select t.SPEC_LEVEL_NURS_DAYS,t.FIRST_LEVEL_NURS_DAYS,t.SECOND_LEVEL_NURS_DAYS,t.ADMISSION_DATE_TIME,t.DISCHARGE_DATE_TIME from INP_VISIT@link_emr t where t.PATIENT_ID = '{0}' and t.VISIT_NO = '{1}' "
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            string SPEC_LEVEL_NURS_DAYS = ds.Tables[0].Rows[0]["SPEC_LEVEL_NURS_DAYS"].ToString();
            string FIRST_LEVEL_NURS_DAYS = ds.Tables[0].Rows[0]["FIRST_LEVEL_NURS_DAYS"].ToString();
            string SECOND_LEVEL_NURS_DAYS = ds.Tables[0].Rows[0]["SECOND_LEVEL_NURS_DAYS"].ToString();
            string ADMISSION_DATE_TIME = ds.Tables[0].Rows[0]["ADMISSION_DATE_TIME"].ToString();
            string DISCHARGE_DATE_TIME = ds.Tables[0].Rows[0]["DISCHARGE_DATE_TIME"].ToString();
            if (string.IsNullOrEmpty(DISCHARGE_DATE_TIME)||string.IsNullOrEmpty(ADMISSION_DATE_TIME))
            {
                qcCheckResult.QC_EXPLAIN = "患者未出院，规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            DateTime dtAdmisson = DateTime.Parse(ADMISSION_DATE_TIME);
            DateTime dtDischarge = DateTime.Parse(DISCHARGE_DATE_TIME);
            int period = (dtDischarge - dtAdmisson).Days;
            int nspec = 0;
            int nfirst = 0;
            int nsecond = 0;
            int.TryParse(SPEC_LEVEL_NURS_DAYS, out nspec);
            int.TryParse(FIRST_LEVEL_NURS_DAYS, out nfirst);
            int.TryParse(SECOND_LEVEL_NURS_DAYS, out nsecond);
            if (period<(nspec+nfirst+nsecond))
            {
                qcCheckResult.QC_EXPLAIN = "特级、一级护理、二级护理、三级护理之和大于住院天数";
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            qcCheckResult.QC_EXPLAIN = "规则通过";
            qcCheckResult.QC_RESULT = 1;
            return true;
        }
    }
}
