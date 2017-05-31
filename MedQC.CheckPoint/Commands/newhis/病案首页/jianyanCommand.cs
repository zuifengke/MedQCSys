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
    /// 缺陷内容：乙肝HBSAG\丙肝HIV-AB\艾滋HIV-AB与检验结果不一致
    /// 核查方法：乙肝HBSAG\丙肝HCV-AB\艾滋病HIV-AB 与检验结果一致（从患者检验结果中核查，如果有检验需与检验结果一致，如果没有需填未填）
    /// </summary>
    public class jianyanCommand : AbstractCommand
    {
        public jianyanCommand()
        {
            this.m_name = "新军卫-乙肝HBSAG丙肝HIV-AB艾滋HIV-AB与检验结果不一致";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szSQl = string.Format("select t.HBSAG_INDICATOR, t.HCV_AB_INDICATOR, t.HIV_AB_INDICATOR from INP_VISIT@link_emr t where t.PATIENT_ID = '{0}' and t.VISIT_NO = '{1}' "
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
            //检验结果乙肝表面抗原、丙肝抗体、艾滋病抗体，还不太清楚如何判断阳性，规则默认为通过
            qcCheckResult.QC_EXPLAIN = "规则通过";
            qcCheckResult.QC_RESULT = 1;
            return true;
        }
    }
}
