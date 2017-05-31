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
    /// 缺陷内容：检查结果有血型首页未填
    /// 核查方法：如果检查结果中有血型，则首页必须填，且必须一致。如果没有血型检验结果则可不填。
    /// </summary>
    public class xuexingCommand : AbstractCommand
    {
        public xuexingCommand()
        {
            this.m_name = "新军卫-检查结果有血型首页未填";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询是否有检验记录
            string szSQl = string.Format("select b.ITEM_RESULT from LAB_MASTER_V a,LAB_RESULT_V b where a.TEST_ID = b.TEST_ID and b.ITEM_NAME like '%血型%' and a.PATIENT_ID = '{0}' and a.VISIT_ID = '{1}' "
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
            string ITEM_RESULT = ds.Tables[0].Rows[0]["ITEM_RESULT"].ToString();
            if (string.IsNullOrEmpty(ITEM_RESULT))
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //查询首页血型填写情况
            szSQl = string.Format("select BLOOD_TYPE,b.CODE_NAME from INP_VISIT@link_emr a,BASE_CODE_DICT@link_emr b where b.CODETYPE_NAME = 'BLOOD_ABO_TYPE_DICT' and a.BLOOD_TYPE = b.CODE_ID(+) and a.PATIENT_ID ='{0}' and a.VISIT_NO ='{1}'"
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = string.Format("检验记录中有血型结果{0}型，但首页未填", ITEM_RESULT);
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            string CODE_NAME = ds.Tables[0].Rows[0]["CODE_NAME"].ToString();
            if (CODE_NAME != ITEM_RESULT)
            {
                qcCheckResult.QC_EXPLAIN = string.Format("检验记录中有血型结果{0}型，首页填写血型为{1}型", ITEM_RESULT,CODE_NAME);
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
