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
    /// 缺陷内容：抢救次数不合理
    /// 核查方法：抢救次数需合理，总抢救次数-成功次数<=1。
    /// </summary>
    public class qiangjiucishuCommand : AbstractCommand
    {
        public qiangjiucishuCommand()
        {
            this.m_name = "新军卫-抢救次数不合理";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询是否有检验记录
            string szSQl = string.Format("select EMER_TREAT_TIMES,ESC_EMER_TIMES from inp_visit@link_emr a where a.PATIENT_ID ='{0}' and a.VISIT_NO ='{1}'"
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
            string EMER_TREAT_TIMES = ds.Tables[0].Rows[0]["EMER_TREAT_TIMES"].ToString();//抢救次数
            string ESC_EMER_TIMES = ds.Tables[0].Rows[0]["ESC_EMER_TIMES"].ToString();//抢救成功次数

            if (string.IsNullOrEmpty(EMER_TREAT_TIMES) || string.IsNullOrEmpty(ESC_EMER_TIMES))
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            int nEmer = 0;
            int.TryParse(EMER_TREAT_TIMES, out nEmer);
            int nEsc = 0;
            int.TryParse(ESC_EMER_TIMES, out nEsc);
            if (nEmer < nEsc)
            {
                qcCheckResult.QC_EXPLAIN = string.Format("首页填写抢救次数为{0}，抢救成功次数为{1}", nEmer, nEsc);
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
