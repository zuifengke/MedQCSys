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
   
    public class 元素空项检查Command : AbstractCommand
    {
        public 元素空项检查Command()
        {
            this.m_name = "通用-和仁编辑器-元素空项检查";
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
            if (string.IsNullOrEmpty(qcCheckPoint.ELEMENT_NAME))
            {
                qcCheckResult.QC_EXPLAIN = "内容项目未设置，规则通过";
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
            XmlNode docNode = null;
            if(documentlist[0].DOC_ID!=documentlist[0].DOC_SETID)
            {
                 docNode = doc.SelectSingleNode(string.Format("//Section[@ID='{0}']", documentlist[0].DOC_ID));

            }
            XmlNode node = null;
            if (docNode != null)
            {
                node = docNode.SelectSingleNode(string.Format("//Field[@Name='{0}']", qcCheckPoint.ELEMENT_NAME));
            }
            else
            {
                node = doc.SelectSingleNode(string.Format("//Field[@Name='{0}']", qcCheckPoint.ELEMENT_NAME));
            }
            if (node == null || string.IsNullOrEmpty(node.InnerText))//存在一项为空则直接返回不继续判断
            {
                qcCheckResult.QC_EXPLAIN = string.Format("{0}为空", qcCheckPoint.ELEMENT_NAME);
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
