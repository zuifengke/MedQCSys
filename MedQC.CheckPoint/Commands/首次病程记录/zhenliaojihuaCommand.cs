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
    /// 缺陷内容：诊疗计划用套话、无针对性、不具体
    /// 核查方法：诊疗计划中，有“相关检查”或“相关内容” 或“完善辅助检查”内容的，一行上不能少于10个字。
    /// </summary>
    public class zhenliaojihuaCommand : AbstractCommand
    {
        public zhenliaojihuaCommand()
        {
            this.m_name = "新军卫-诊疗计划";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            //查询患者指定文书类型ID号
            List<MedDocInfo> documentlist = TimeCheckHelper.Instance.GetDocumentList(qcCheckPoint.DocTypeID, patVisitLog.MedDocInfos);
            if (documentlist == null || documentlist.Count == 0)
            {
                qcCheckResult.QC_EXPLAIN = "未写首次病程记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //获取文书xml内容
            string szXMLFile = null;
            MedXMLAccess.Instance.GetDocXml(documentlist[0], ref szXMLFile);
            if (string.IsNullOrEmpty(szXMLFile))
            {
                qcCheckResult.QC_EXPLAIN = "未写首次病程记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            qcCheckResult.DOC_SETID = documentlist[0].DOC_SETID;
            qcCheckResult.DOC_TITLE = documentlist[0].DOC_TITLE;
            qcCheckResult.DOCTYPE_ID = documentlist[0].DOC_TYPE;
            qcCheckResult.DOC_TIME = documentlist[0].DOC_TIME;
            XmlDocument doc = new XmlDocument();
            doc.Load(szXMLFile);

            XmlNode node = doc.SelectSingleNode(string.Format("/EmrDoc/Body/Section[@ID='{0}']", documentlist[0].DOC_ID));
            if (node == null)
            {
                qcCheckResult.QC_EXPLAIN = "首次病程记录内容在病程中未找到，该规则默认通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
           
            XmlNodeList childs = node.SelectNodes(string.Format("//Field[@Name='{0}']/Text","诊疗计划"));

            StringBuilder sb = new StringBuilder();
            foreach (XmlNode item in childs)
            {
                if (item.InnerText.Contains("相关检查") && item.InnerText.Length < 10)
                {
                    sb.AppendLine("相关检查不具体");
                }
                if (item.InnerText.Contains("相关内容") && item.InnerText.Length < 10)
                {
                    sb.AppendLine("相关内容不具体");
                }
                if (item.InnerText.Contains("完善辅助检查") && item.InnerText.Length < 10)
                {
                    sb.AppendLine("完善辅助检查不具体");
                }
            }
            if (sb.ToString() != string.Empty)
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
