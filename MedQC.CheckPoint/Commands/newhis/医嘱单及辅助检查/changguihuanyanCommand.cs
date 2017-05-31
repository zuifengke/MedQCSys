using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 缺陷内容：患者出院时无血尿常规化验结果；也未转抄门诊化验结果
    /// 核查方法：出院时核查有无血、尿、便常规检验结果，如没有检验结果需在入院记录中有“血常规”、“尿常规”、“粪常规”或“便常规”或“大便常规”关键词记录。
    /// </summary>
    public class changguihuayanCommand : AbstractCommand
    {
        
        public changguihuayanCommand()
        {
            this.m_name = "新军卫-患者出院时无血尿常规化验结果";
        }
        public override bool Execute(object param, object data, out object result)
        {
            
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            if (patVisitLog.DISCHARGE_TIME == DateTime.Parse("1900-01-01"))
            {
                qcCheckResult.QC_EXPLAIN = "患者未出院，规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            List<MedDocInfo> documentlist = TimeCheckHelper.Instance.GetDocumentList(qcCheckPoint.DocTypeID, patVisitLog.MedDocInfos);
            if (documentlist != null && documentlist.Count > 0)
            {
                string szXMLFile = null;
                MedXMLAccess.Instance.GetDocXml(documentlist[0], ref szXMLFile);
                XmlDocument doc = new XmlDocument();
                doc.Load(szXMLFile);
                XmlNode node = doc.SelectSingleNode(string.Format("//Field[@Name='{0}']", "化验及特殊检查"));
                if (node != null && !string.IsNullOrEmpty(node.InnerText))
                {
                    if (node.InnerText.Contains("血常规") && node.InnerText.Contains("尿常规") && node.InnerText.Contains("便常规"))
                    {
                        qcCheckResult.QC_EXPLAIN = string.Format("入院记录已转抄门诊化验结果，规则通过");
                        qcCheckResult.QC_RESULT = 1;
                        return true;
                    }
                }
            }
            //入院记录中未转抄，则检查本次住院的化验结果
            DataSet ds = null;
            string szSQl = string.Format("select b.REPORT_ITEM_NAME from doctor_orders@link_emr a,LAB_RESULT@link_emr b where a.PATIENT_ID = '{0}' and a.VISIT_NO = '{1}' and a.ORDER_ID = b.ORDER_ID and(b.REPORT_ITEM_NAME like '%血常规%' or b.REPORT_ITEM_NAME like '%尿常规%' or b.REPORT_ITEM_NAME like '%便常规%')"
                , patVisitLog.PATIENT_ID
                , patVisitLog.VISIT_ID);
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            StringBuilder description = new StringBuilder();
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = "患者出院时无血尿常规化验，也未在入院记录中转抄门诊化验结果记录";
                qcCheckResult.QC_RESULT = 0;//不通过
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            string str = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string REPORT_ITEM_NAME=ds.Tables[0].Rows[i]["REPORT_ITEM_NAME"].ToString();
                str += REPORT_ITEM_NAME;
            }
            StringBuilder sb = new StringBuilder();
            if (!str.Contains("血常规"))
            {
                sb.Append("缺血常规;");
            }
            if (!str.Contains("尿常规"))
            {
                sb.Append("缺尿常规;");
            }
            if (!str.Contains("便常规"))
            {
                sb.Append("缺便常规;");
            }
            if (sb.Length>0)
            {
                qcCheckResult.QC_EXPLAIN = sb.ToString();
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
