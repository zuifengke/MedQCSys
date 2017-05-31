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

            string szSQl = string.Format("select a.ANAESTHESIA_METHOD,b.CODE_NAME,a.ANESTHESIA_DOCTOR,a.END_DATE_TIME from OPERATION_MASTER@link_emr a,BASE_CODE_DICT@link_emr b where b.CODETYPE_NAME = 'ANAESTHESIA_DICT' and a.ANAESTHESIA_METHOD = b.CODE_ID and a.VISIT_NO = '{1}' and a.PATIENT_ID = '{0}' "
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
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
                string CODE_NAME = ds.Tables[0].Rows[i]["CODE_NAME"].ToString();
                string ANESTHESIA_DOCTOR = ds.Tables[0].Rows[i]["ANESTHESIA_DOCTOR"].ToString();
                string END_DATE_TIME = ds.Tables[0].Rows[i]["END_DATE_TIME"].ToString();

                if (CODE_NAME.IndexOf("全麻") >= 0 || CODE_NAME.IndexOf("全身麻醉") >= 0)
                {
                    if (string.IsNullOrEmpty(ANESTHESIA_DOCTOR))
                    {
                        sb.AppendFormat("{0}手术,使用{1},记录缺麻醉医师姓名"
                            , END_DATE_TIME
                            , CODE_NAME
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
