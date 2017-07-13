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
    /// 缺陷内容：已输血病例中无输血前4项检查报告单或化验结果记录
    /// 核查方法：从血库发血记录中查询，如当天有发血记录，在患者检验结果中检测是否有乙肝表面抗原、丙型肝炎抗体、艾滋病抗体筛查试验、梅毒螺旋体特异抗体测定四项的检验结果。
    /// </summary>
    public class ShuxueqianCommand : AbstractCommand
    {
        public ShuxueqianCommand()
        {
            this.m_name = "新军卫-输血前四项检查检验";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询本次住院是否有发血记录
            string szSQl = string.Format("select * from BLOOD_TRANSFUSION_V b where  b.PATIENT_ID = '{0}' and b.VISIT_ID = '{1}'"
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
            //患者存在输血，查找检验结果中是否有乙肝表面抗原、丙型肝炎抗体、艾滋病抗体筛查试验、梅毒螺旋体特异抗体测定四项
            szSQl = string.Format("select b.ITEM_NAME from LAB_RESULT_V b,lab_master_v a where A.PATIENT_ID = '{0}' and A.VISIT_NO = '{1}' and b.test_id=a.TEST_ID and B.ITEM_NAME in('乙肝表面抗原', '丙肝抗体', '艾滋病抗体', '梅毒血清特异抗体测定')"
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            StringBuilder description = new StringBuilder();
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                description.Append("患者有发血记录，但患者检验结果中不存在乙肝表面抗原，丙肝抗体，艾滋病抗体，梅毒血清特异抗体测定");
                qcCheckResult.QC_RESULT = 0;//不通过
                qcCheckResult.ERROR_COUNT=1;
            }
            else
            {
                description.Append("规则通过");
                qcCheckResult.QC_RESULT = 1;//通过
            }
            qcCheckResult.QC_EXPLAIN = description.ToString();
            return true;
        }
    }
}
