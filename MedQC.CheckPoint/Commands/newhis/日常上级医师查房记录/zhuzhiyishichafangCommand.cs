using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using MedDocSys.QCEngine.TimeCheck;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 缺陷点：主治医师日常查房无内容、无分析及处理意见
    /// 核查内容：标题有“主治医师查房记录”或内容有“主治医师”和“查”，必须有“示”、“指”、“分析”、“嘱”其中任一个关键词。
    /// </summary>
    public class zhuzhiyishichafangCommand : AbstractCommand
    {
        public zhuzhiyishichafangCommand()
        {
            this.m_name = "新军卫-主治医师日常查房无内容";
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
                qcCheckResult.QC_EXPLAIN = "未写主治医师日常查房记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            qcCheckResult.DOC_SETID = documentlist[0].DOC_SETID;
            qcCheckResult.DOC_TITLE = documentlist[0].DOC_TITLE;
            qcCheckResult.DOCTYPE_ID = documentlist[0].DOC_TYPE;
            qcCheckResult.DOC_TIME = documentlist[0].DOC_TIME;
            StringBuilder sb = new StringBuilder();
            foreach (var item in documentlist)
            {
                //获取文书xml内容
                string szXMLFile = null;
                MedXMLAccess.Instance.GetDocXml(item, ref szXMLFile);
                if (string.IsNullOrEmpty(szXMLFile))
                {
                    continue;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(szXMLFile);
                XmlNode node = doc.SelectSingleNode(string.Format("/EmrDoc/Body/Section[@ID='{0}']//Field[@Name='查房记录内容']", item.DOC_ID));
                if (node == null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(node.InnerText))
                {
                    sb.AppendFormat("主治医师日常查房无内容");
                    continue;
                }
                if (node.InnerText.IndexOf("示") < 0
                    && node.InnerText.IndexOf("指") < 0
                    && node.InnerText.IndexOf("分析") < 0
                    && node.InnerText.IndexOf("嘱") < 0)
                {
                    sb.AppendFormat("主治医师日常查房无分析及处理意见,内容不包含示、指、分析、嘱任一关键词");
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
