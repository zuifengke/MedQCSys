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
    /// 缺陷内容：缺项或写错或不规范
    /// 核查方法：入院记录中姓名、出生地、性别、职业、年龄、入院时间、婚姻、病史记录时间、民族、病史陈述者不能为空
    /// </summary>
    public class quexiangCommand : AbstractCommand
    {
        public quexiangCommand()
        {
            this.m_name = "新军卫-缺项或写错或不规范";
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
            //入院记录中姓名、出生地、性别、职业、年龄、入院时间、婚姻、病史记录时间、民族、病史陈述者不能为空
            string[] items =   {
                                "病人姓名",  "病人出生地", "病人性别",
                                "病人职业",  "病人年龄", "入院时间",
                                "病人婚姻状况",  "记录时间", "病人民族",
                                "病史陈述者"
                                };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                XmlNode node = doc.SelectSingleNode(string.Format("//Field[@Name='{0}']", items[i]));
                if (node == null || string.IsNullOrEmpty(node.InnerText))//存在一项为空则直接返回不继续判断
                {
                    sb.AppendFormat("{0}为空，", items[i]);
                  
                }
            }
            if (sb.ToString() != string.Empty)
            {
                qcCheckResult.QC_EXPLAIN = sb.ToString();
                qcCheckResult.QC_RESULT = 0;
                return true;
            }
            qcCheckResult.QC_EXPLAIN = "规则通过";
            qcCheckResult.QC_RESULT = 1;
            return true;
        }
    }
}
