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
    /// 缺陷内容：诊断对照符合情况未填写
    /// 核查方法：门诊与出院诊断、入院与出院诊断、术前与术后、临床与病理诊断、放射与病历诊断符合情况必须填写不能为空。
    /// </summary>
    public class zhenduanfuheqingkuangCommand : AbstractCommand
    {
        public zhenduanfuheqingkuangCommand()
        {
            this.m_name = "新军卫-诊断对照符合情况未填写";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
           
            string szSQl = string.Format("select a.DIAG_CORRESPONDENCE,b.CODE_NAME from DIAG_COMPARING@link_emr a,BASE_CODE_DICT@link_emr b where b.CODETYPE_NAME='DIAG_COMP_GROUP_DICT' and b.CODE_ID =a.DIAG_COMPARE_GROUP_CODE and a.PATIENT_ID ='{0}' and a.VISIT_NO ='{1}'"
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
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string DIAG_CORRESPONDENCE = ds.Tables[0].Rows[i]["DIAG_CORRESPONDENCE"].ToString();//诊断符合情况
                string CODE_NAME = ds.Tables[0].Rows[i]["CODE_NAME"].ToString();//诊断符合情况名
                if (string.IsNullOrEmpty(DIAG_CORRESPONDENCE))
                {
                    sb.AppendFormat("{0}诊断符合情况未填；", CODE_NAME);
                }
            }
            if (sb.Length > 0)
            {
                qcCheckResult.QC_EXPLAIN = sb.ToString();
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
