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
    public class JiwangshiGuomingOrderCommand : AbstractCommand
    {
        public JiwangshiGuomingOrderCommand()
        {
            this.m_name = "个人史描述遗漏";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;

            result = new QcCheckResult();
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szXMLFile = null;
            List<MedDocInfo> lstDocInfos = null;
            EmrDocAccess.Instance.GetDocInfos(patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, "", DateTime.Now, qcCheckPoint.DocTypeID, ref lstDocInfos);
            if (lstDocInfos == null || lstDocInfos.Count == 0)
            {
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            MedDocInfo docInfo = lstDocInfos[0];
            MedXMLAccess.Instance.GetDocXml(docInfo, ref szXMLFile);
            if (string.IsNullOrEmpty(szXMLFile))
            {
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //分析元素
            StringBuilder sb = new StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.Load(szXMLFile);
            
            XmlNode node = doc.SelectSingleNode("//fieldelem[@name='t个人史']");
            if (node == null)
            {
                qcCheckResult.QC_EXPLAIN = "没有个人史元素内容,规则不通过";
                qcCheckResult.QC_RESULT = 0;
                return true;
            }
            else
            {
                
                
            }

            qcCheckResult.SCORE = qcCheckPoint.Score;
            if (sb.Length > 0)
            {
                qcCheckResult.QC_EXPLAIN = sb.ToString();
                qcCheckResult.QC_RESULT = 0;
            }
            else
            {
                qcCheckResult.QC_EXPLAIN = "主诉字长小于20且没有发现标点符号,规则通过";
                qcCheckResult.QC_RESULT = 1;
            }
            return true;
        }
    }
}
