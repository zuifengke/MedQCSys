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
    /// 缺陷内容：军事训练伤填写错误
    /// 核查方法：地方病人军事训练伤必须为空，军队病人不能为空。
    /// </summary>
    public class junshixunlianshangCommand : AbstractCommand
    {
        public junshixunlianshangCommand()
        {
            this.m_name = "新军卫-军事训练伤填写错误";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询患者军人标志
            string szSQl = string.Format("select a.IDENTITY,a.TRAINING_INJURY,a.MILITARY_INDICATOR from PAT_VISIT_V a where  a.PATIENT_ID = '{0}' and a.VISIT_NO = '{1}'"
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
            string MILITARY_INDICATOR = ds.Tables[0].Rows[0]["MILITARY_INDICATOR"].ToString();//军人标志0-地方 1-军人
            string IDENTITY = ds.Tables[0].Rows[0]["IDENTITY"].ToString();//军人标志0-地方 1-军人
            string TRAINING_INJURY = ds.Tables[0].Rows[0]["TRAINING_INJURY"].ToString();//训练伤0-否 1-是
            if (MILITARY_INDICATOR == "0" && !string.IsNullOrEmpty(TRAINING_INJURY))
            {
                qcCheckResult.QC_EXPLAIN = string.Format("患者身份为{0},训练伤不为空", IDENTITY);
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            if (MILITARY_INDICATOR == "1" && string.IsNullOrEmpty(TRAINING_INJURY))
            {
                qcCheckResult.QC_EXPLAIN = string.Format("患者身份为{0},训练伤为空", IDENTITY);
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
