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
    /// 缺陷内容：无麻醉记录
    /// 核查方法：全麻手术结束24小时后核查，军卫一号系统手术记录数据中需有麻醉师名称。
    /// </summary>
    public class mazuijiluCommand : AbstractCommand
    {
        public mazuijiluCommand()
        {
            this.m_name = "新军卫-无麻醉记录";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szSQl = string.Format("select a.ANAESTHESIA_METHOD_NAME,a.ANESTHESIA_DOCTOR,a.OPERATING_DATE,a.operation_desc from operation_v a where a.VISIT_NO = '{1}' and a.PATIENT_ID = '{0}' "
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_NO);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = "未找到手术记录，规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string ANAESTHESIA_METHOD_NAME = ds.Tables[0].Rows[i]["ANAESTHESIA_METHOD_NAME"].ToString();
                string ANESTHESIA_DOCTOR = ds.Tables[0].Rows[i]["ANESTHESIA_DOCTOR"].ToString();
                string OPERATING_DATE = ds.Tables[0].Rows[i]["OPERATING_DATE"].ToString();
                string operation_desc = ds.Tables[0].Rows[i]["operation_desc"].ToString();

                if (ANAESTHESIA_METHOD_NAME.IndexOf("全麻") >= 0 || ANAESTHESIA_METHOD_NAME.IndexOf("全身麻醉") >= 0)
                {
                    if (string.IsNullOrEmpty(ANESTHESIA_DOCTOR))
                    {
                        sb.AppendFormat("{0}行{1}手术,使用{2},未记录麻醉医师姓名"
                            , OPERATING_DATE
                            , operation_desc
                            , ANAESTHESIA_METHOD_NAME
                            );
                    }
                }
            }
            if (sb.Length == 0)
            {
                qcCheckResult.QC_RESULT = 1;
                qcCheckResult.QC_EXPLAIN = "规则通过";
                return true;
            }

            qcCheckResult.QC_RESULT = 0;
            qcCheckResult.QC_EXPLAIN = sb.ToString();
            qcCheckResult.ERROR_COUNT = 1;
            return true;
        }
    }
}
