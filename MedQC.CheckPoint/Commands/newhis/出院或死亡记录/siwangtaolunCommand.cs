using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;


using Heren.MedQC.Core;
namespace Heren.MedQC.CheckPoint.Commands
{
    /// <summary>
    /// 缺陷内容：死亡病例讨论记录不规范
    /// 核查方法：按照标题查询日期、主持人、参加人员、讨论意见，有标题和内容。
    /// </summary>
    public class siwangtaolunCommand : AbstractCommand
    {
        public siwangtaolunCommand()
        {
            this.m_name = "新军卫-死亡病例讨论记录不规范";
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
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //获取文书xml内容
            string szXMLFile = null;
            MedXMLAccess.Instance.GetDocXml(documentlist[0], ref szXMLFile);
            if (string.IsNullOrEmpty(szXMLFile))
            {
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            qcCheckResult.DOC_SETID = documentlist[0].DOC_SETID;
            qcCheckResult.DOC_TITLE = documentlist[0].DOC_TITLE;
            qcCheckResult.DOCTYPE_ID = documentlist[0].DOC_TYPE;
            qcCheckResult.DOC_TIME = documentlist[0].DOC_TIME;
            XmlDocument doc = new XmlDocument();
            doc.Load(szXMLFile);
                      
            XmlNode node = doc.SelectSingleNode(string.Format("/EmrDoc/Body/Section[@ID='{0}']",documentlist[0].DOC_ID));
            if (node == null)
            {
                qcCheckResult.QC_EXPLAIN = "死亡讨论内容在病程中未找到，该规则默认通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //死亡记录中死亡原因，死亡时间不能为空
            string[] items =   {
                                "记录时间",  "主持人","参加人员","讨论意见"
                                };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                XmlNode child = node.SelectSingleNode(string.Format("//Field[@Name='{0}']", items[i]));
                if (child == null)
                    continue;
                if (child == null || string.IsNullOrEmpty(child.InnerText))//存在一项为空则直接返回不继续判断
                {
                    sb.AppendFormat("{0}为空，", items[i]);
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
