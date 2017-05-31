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
    /// 缺陷内容：未完成术前常规检查 过程复杂，未实现
    /// 核查方法：择期中等全麻手术开始前，在检验结果中须有“肝功”、“肾功”、“出凝血时间”、“输血前四项”、“血常规”、“尿常规”项目的检验结果，并且报告返回时间在手术开始之前。在检查记录中需有心电图或动态心电图之一和胸片、胸透、胸部CT之一的检验报告，并且报告返回时间在手术开始之前。如无上述检查检验报告，需在入院记录辅助检查中有“血常规”、“尿常规”、“肝功”、“肾功”、“出凝血时间”、“输血”、“心电图”和“胸片”、“胸透”、“胸部CT”三者之一的关键词。
    /// </summary>
    public class shuqianjianchaCommand : AbstractCommand
    {
        
        public shuqianjianchaCommand()
        {
            this.m_name = "新军卫-未完成术前常规检查";
        }
        public override bool Execute(object param, object data, out object result)
        {
            
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询本次住院是否有发血记录，通过用血申请单医嘱判断
            string szSQl = string.Format("select * from BLOOD_ORDERS@link_emr A,DOCTOR_ORDERS@link_emr B where a.ORDER_ID = b.ORDER_ID and b.PATIENT_ID = '{0}' and b.VISIT_NO = '{1}'"
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_RESULT = 1;//通过
                qcCheckResult.QC_EXPLAIN = "不存在输血医嘱，规则通过";
                return true;
            }
            //患者存在输血，查找检验结果中是否有乙肝表面抗原、丙型肝炎抗体、艾滋病抗体筛查试验、梅毒螺旋体特异抗体测定四项
            szSQl = string.Format("select B.REPORT_ITEM_NAME from DOCTOR_ORDERS@link_emr A,LAB_RESULT@link_emr B where a.ORDER_ID = b.ORDER_ID and A.PATIENT_ID = '{0}' and A.VISIT_NO = '{1}' and B.REPORT_ITEM_NAME in('乙肝表面抗原', '丙肝抗体', '艾滋病抗体', '梅毒血清特异抗体测定')"
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            StringBuilder description = new StringBuilder();
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                description.Append("患者有发血记录，但患者检验结果中不存在乙肝表面抗原，丙肝抗体，艾滋病抗体，梅毒血清特异抗体测定");
                qcCheckResult.QC_RESULT = 0;//不通过
                qcCheckResult.ERROR_COUNT = 1;
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
