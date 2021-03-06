﻿using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 缺陷内容：某项未填写、填写不规范、填写错误
    /// 核查方法：入院诊断、确诊日期、确诊天数、住院天数、出院科室、入院科室及时间必填
    /// </summary>
    public class BinganShouye_firstCommand : AbstractCommand
    {
        public BinganShouye_firstCommand()
        {
            this.m_name = "新军卫-某项未填写、填写不规范、填写错误";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            string szSQl = string.Format("select DEPT_DISCHARGE_FROM,DEPT_ADMISSION_TO,ADMISSION_DATE_TIME from pat_visit_v t where t.patient_id ='{0}' and t.visit_no = '{1}'"
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_NO);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_RESULT = 1;
                return false;
            }
            StringBuilder description = new StringBuilder();
            string DEPT_DISCHARGE_FROM = ds.Tables[0].Rows[0]["DEPT_DISCHARGE_FROM"].ToString();
            if (string.IsNullOrEmpty(DEPT_DISCHARGE_FROM))
            {
                description.Append("出院科室为空；");
            }
            string DEPT_ADMISSION_TO = ds.Tables[0].Rows[0]["DEPT_ADMISSION_TO"].ToString();
            if (string.IsNullOrEmpty(DEPT_ADMISSION_TO))
            {
                description.Append("入院科室为空;");
            }
            string ADMISSION_DATE_TIME = ds.Tables[0].Rows[0]["ADMISSION_DATE_TIME"].ToString();
            if (string.IsNullOrEmpty(ADMISSION_DATE_TIME))
            {
                description.Append("入院时间为空;");
            }
            if (description.Length == 0)
            {
                qcCheckResult.QC_RESULT = 1;
                qcCheckResult.QC_EXPLAIN = "规则通过";
                return true;
            }

            qcCheckResult.QC_RESULT = 0;
            qcCheckResult.QC_EXPLAIN = description.ToString();
            qcCheckResult.ERROR_COUNT = 1;
            return true;
        }
    }
}
