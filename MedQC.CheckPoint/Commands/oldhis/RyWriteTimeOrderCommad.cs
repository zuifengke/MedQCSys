using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

using Heren.MedQC.Core;
namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 处理规则：主诉不得超过20字
    /// </summary>
    public class RyWriteTimeOrderCommad : AbstractCommand
    {
        public RyWriteTimeOrderCommad()
        {
            this.m_name = "24小时内入院记录书写时间检查";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;

            result = new QcCheckResult();
            QcCheckResult qcCheckResult = result as QcCheckResult;

            //是否已过24小时
            DateTime dt = DateTime.Now;
            CommonAccess.Instance.GetServerTime(ref dt);
            if ((dt - patVisitLog.VISIT_TIME).TotalHours <= 24)
            {
                qcCheckResult.QC_EXPLAIN = "未到24小时,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }


            List<MedDocInfo> lstDocInfos = null;
            EmrDocAccess.Instance.GetDocInfos(patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, "", DateTime.Now, "", ref lstDocInfos);
            if (lstDocInfos == null || lstDocInfos.Count == 0)
            {
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则不通过";
                qcCheckResult.QC_RESULT = 0;
                return true;
            }
            //过滤文档类型
            lstDocInfos = lstDocInfos.FindAll(i => qcCheckPoint.DocTypeID.Contains(i.DOC_TYPE));
            if (lstDocInfos.Count == 0)
            {
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则不通过";
                qcCheckResult.QC_RESULT = 0;
                return true;
            }
            //过滤时间
            lstDocInfos = lstDocInfos.FindAll(i => (i.DOC_TIME - patVisitLog.VISIT_TIME).TotalHours <= 24);
            if (lstDocInfos.Count == 0)
            {
                qcCheckResult.QC_EXPLAIN = "书写入院时间超过24小时,规则不通过";
                qcCheckResult.QC_RESULT = 0;
                return true;
            }
            qcCheckResult.QC_EXPLAIN = "书写入院时间在24小时内,规则通过";
            qcCheckResult.QC_RESULT = 1;
            return true;
        }
    }
}
