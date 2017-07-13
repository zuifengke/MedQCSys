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
    /// 缺陷内容：外部损伤原因诊断和军事训练伤不一致
    /// 核查方法：外部损伤原因中如果为X59.801和W28.801的，军事训练伤必须为是
    /// </summary>
    public class waibusunshangyuanyinCommand : AbstractCommand
    {
        public waibusunshangyuanyinCommand()
        {
            this.m_name = "新军卫-外部损伤原因诊断和军事训练伤不一致";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szSQl = string.Format("select b.DIAGNOSIS_CODE,a.DIAG_TYPE,a.DIAG_DESC from DIAGNOSIS_V where a.DIAG_DESC =b.DIAGNOSIS_NAME(+) and a.VISIT_NO ='{1}' and a.PATIENT_ID ='{0}' and a.DIAG_TYPE = 7 "
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
            string DIAGNOSIS_CODE = ds.Tables[0].Rows[0]["DIAGNOSIS_CODE"].ToString();
            string DIAG_TYPE = ds.Tables[0].Rows[0]["DIAG_TYPE"].ToString();
            string DIAG_DESC = ds.Tables[0].Rows[0]["DIAG_DESC"].ToString();
            if (DIAGNOSIS_CODE != "X59.801" && DIAGNOSIS_CODE != "W28.801")
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            szSQl = string.Format("select TRAINING_INJURY from INP_VISIT a where a.PATIENT_ID='{0}' and a.VISIT_NO='{1}'");
            shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            string TRAINING_INJURY = ds.Tables[0].Rows[0]["TRAINING_INJURY"].ToString();
            if (string.IsNullOrEmpty(TRAINING_INJURY) || TRAINING_INJURY == "0")
            {
                qcCheckResult.QC_EXPLAIN = string.Format("外部损伤原因诊断编码为{0},但军事训练上不为是", DIAGNOSIS_CODE);
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            qcCheckResult.QC_RESULT = 1;
            qcCheckResult.QC_EXPLAIN = "规则通过";
            return true;
        }
    }
}
