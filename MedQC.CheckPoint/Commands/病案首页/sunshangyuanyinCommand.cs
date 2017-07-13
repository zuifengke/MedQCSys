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
    /// 缺陷内容：首页缺损伤原因
    /// 核查方法：出院诊断ICD10编码中有S、T开头的，必须填写损伤原因
    /// </summary>
    public class sunshangyuanyinCommand : AbstractCommand
    {
        public sunshangyuanyinCommand()
        {
            this.m_name = "新军卫-首页缺损伤原因";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szSQl = string.Format("select DIAGNOSIS_CODE,a.DIAG_TYPE,a.DIAG_DESC from DIAGNOSIS_V A where a.DIAG_DESC =b.DIAGNOSIS_NAME(+) and a.VISIT_NO ='{1}' and a.PATIENT_ID ='{0}' and (a.DIAG_TYPE =3 or a.DIAG_TYPE = 7) "
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_NO);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string DIAGNOSIS_CODE = ds.Tables[0].Rows[i]["DIAGNOSIS_CODE"].ToString();
                string DIAG_TYPE = ds.Tables[0].Rows[i]["DIAG_TYPE"].ToString();
                string DIAG_DESC = ds.Tables[0].Rows[i]["DIAG_DESC"].ToString();
                if (DIAG_TYPE == "7")
                {
                    qcCheckResult.QC_EXPLAIN = "规则通过";
                    qcCheckResult.QC_RESULT = 1;
                    return true;
                }
                if (!string.IsNullOrEmpty(DIAGNOSIS_CODE) && (DIAGNOSIS_CODE.IndexOf("S") >= 0 || DIAGNOSIS_CODE.IndexOf("T") >= 0))
                {
                    //诊断编码包含S、T
                    qcCheckResult.QC_EXPLAIN = "诊断编码包含S、T，损伤原因未填，规则不通过";
                    qcCheckResult.QC_RESULT = 0;
                    qcCheckResult.ERROR_COUNT = 1;
                }
            }
            return true;
        }
    }
}
