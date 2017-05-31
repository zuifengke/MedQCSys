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
    /// 缺陷内容：有辅助检查结果未记录或记录有缺陷
    /// 核查方法：如果有辅助检查内容，其中内容须有“院”字，同时要有时间。（现在能检测的时间格式现有：“年”“月”“日”，“****－**－**”，“****.**.**”,“年”“月”，“****－**”，“****.**”。）
    /// </summary>
    public class fuzhujianchaCommand : AbstractCommand
    {
        public fuzhujianchaCommand()
        {
            this.m_name = "新军卫-缺辅助检查记录";
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

            XmlNode node = doc.SelectSingleNode(string.Format("//Field[@Name='{0}']", "化验及特殊检查"));
            if (node == null || string.IsNullOrEmpty(node.InnerText))//存在一项为空则直接返回不继续判断
            {
                qcCheckResult.QC_EXPLAIN = string.Format("{0}为空", "化验及特殊检查");
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
