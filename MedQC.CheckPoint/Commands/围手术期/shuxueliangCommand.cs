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
    /// 缺陷内容：手术记录与术后首次病程输血量不一致
    /// 核查方法：核查手术记录和术后首次病程的术中输血量是否一致。
    /// </summary>
    public class shuxueliangCommand : AbstractCommand
    {
        public shuxueliangCommand()
        {
            this.m_name = "新军卫-手术记录与术后首次病程输血量不一致";
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
                qcCheckResult.QC_EXPLAIN = "未写围手术期记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            string 手术记录输血量 = string.Empty;
            string 术后首次病程输血量 = string.Empty;
            foreach (var docinfo in documentlist)
            {
                //获取文书xml内容
                string szXMLFile = null;
                MedXMLAccess.Instance.GetDocXml(docinfo, ref szXMLFile);
                if (string.IsNullOrEmpty(szXMLFile))
                {
                    qcCheckResult.QC_EXPLAIN = "未写围手术期记录,规则通过";
                    qcCheckResult.QC_RESULT = 1;
                    return true;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(szXMLFile);
                XmlNode node = doc.SelectSingleNode(string.Format("/EmrDoc/Body/Section[@ID='{0}']//Field[@Name='术中输血量']", docinfo.DOC_ID));
               
                if (node != null && !string.IsNullOrEmpty(node.InnerText))
                {
                    if (docinfo.DOC_TITLE == "手术记录")
                    {
                        手术记录输血量 = node.InnerText;
                    }
                    else if (docinfo.DOC_TITLE == "术后首次病程")
                    {
                        术后首次病程输血量 = node.InnerText;
                    }
                }
            }
            if(手术记录输血量!=术后首次病程输血量)
            {
                qcCheckResult.QC_EXPLAIN = string.Format("手术记录内填写{0}ml输血量,术后首次病程内填写{1}ml输血量，两者不一致", 手术记录输血量, 术后首次病程输血量);
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
