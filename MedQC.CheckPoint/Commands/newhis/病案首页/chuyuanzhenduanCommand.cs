using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.MedQC.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 缺陷内容：出院诊断缺确诊日期、出院情况、治疗天数
    /// 核查方法：出院诊断ICD10编码中有S、T开头的，必须填写损伤原因
    /// </summary>
    public class chuyuanzhenduanCommand : AbstractCommand
    {
        public chuyuanzhenduanCommand()
        {
            this.m_name = "新军卫-出院诊断缺确诊日期、出院情况、治疗天数";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result= CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szSQl = string.Format("select DIAG_DATE, TREAT_DAYS, TREAT_RESULT from DIAGNOSIS@link_emr t where t.patient_id ='{0}' and t.visit_no = '{1}' and t.DIAG_TYPE = 3 "
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                if (!string.IsNullOrEmpty(patVisitLog.DISCHARGE_MODE))
                {
                    qcCheckResult.QC_EXPLAIN = "出院诊断未填";
                    qcCheckResult.QC_RESULT = 0;
                    qcCheckResult.ERROR_COUNT = 1;
                }
                else
                {
                    qcCheckResult.QC_EXPLAIN = "患者未出院，规则通过";
                    qcCheckResult.QC_RESULT = 1;
                }
                return true;
            }
            StringBuilder description = new StringBuilder();
            string DIAG_DATE = ds.Tables[0].Rows[0]["DIAG_DATE"].ToString();
            if (string.IsNullOrEmpty(DIAG_DATE))
            {
                description.Append("确诊日期为空；");
            }
            string TREAT_DAYS = ds.Tables[0].Rows[0]["TREAT_DAYS"].ToString();
            if (string.IsNullOrEmpty(TREAT_DAYS))
            {
                description.Append("治疗天数为空;");
            }
            string TREAT_RESULT = ds.Tables[0].Rows[0]["TREAT_RESULT"].ToString();
            if (string.IsNullOrEmpty(TREAT_RESULT))
            {
                description.Append("出院情况为空;");
            }
            if (description.Length == 0)
                qcCheckResult.QC_RESULT = 1;
            else
            {
                qcCheckResult.ERROR_COUNT = 1;
                qcCheckResult.QC_RESULT = 0;
            }
            qcCheckResult.QC_EXPLAIN = description.ToString();
            
            return true;
        }
    }
}
