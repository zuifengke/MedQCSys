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
    /// 缺陷内容：死亡记录缺某一部分内容
    /// 核查方法：通过标题检测入院情况、入院诊断、诊疗过程、死亡诊断、死亡原因、治疗结果项目是否书写，通过关键词“抢救”查询是否记录抢救经过，查询死亡时间是否有并且是否记录到分钟。。
    /// </summary>
    public class siwangCommand : AbstractCommand
    {
        public siwangCommand()
        {
            this.m_name = "新军卫-死亡记录缺某一部分内容";
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
                qcCheckResult.QC_EXPLAIN = "未写出院记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //获取文书xml内容
            string szXMLFile = null;
            MedXMLAccess.Instance.GetDocXml(documentlist[0], ref szXMLFile);

            if (string.IsNullOrEmpty(szXMLFile))
            {
                qcCheckResult.QC_EXPLAIN = "未写出院记录,规则通过";
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
                qcCheckResult.QC_EXPLAIN = "死亡记录内容在病程中未找到，该规则默认通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            string[] items =   {
                                "症状",  "初步诊断内容","住院诊治经过","死亡诊断内容","死亡原因","死亡时间"
                                };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                XmlNode child = doc.SelectSingleNode(string.Format("//Field[@Name='{0}']", items[i]));
                if (child == null || string.IsNullOrEmpty(child.InnerText))//存在一项为空则直接返回不继续判断
                {
                    sb.AppendFormat("{0}为空，", items[i]);
                    continue;
                }
                if (items[i] == "住院诊治经过" && !child.InnerText.Contains("抢救"))
                {
                    sb.Append("未记录抢救经过；");
                }
                if (items[i] == "死亡时间")
                {
                    DateTime diedTime;
                    DateTime.TryParse(child.InnerText, out diedTime);
                    if (diedTime.Hour == 0 && diedTime.Minute == 0 && diedTime.Second == 0)
                    {
                        sb.Append("死亡时间未记录到时分");
                    }
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
