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
    /// 缺陷点：会诊记录单未陈诉会诊申请理由及目的
    /// 核查内容：会诊记录单”会诊科室“、”会诊医师姓名及职称“、“会诊目的”，”会诊时间“，”会诊所见“，”会诊诊断“，”治疗意见“标题后不能为空。
    /// </summary>
    public class huizhenjiludanCommand : AbstractCommand
    {
        public huizhenjiludanCommand()
        {
            this.m_name = "新军卫-会诊记录单未陈诉会诊申请理由及目的";
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
                qcCheckResult.QC_EXPLAIN = "未写会诊记录单,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            qcCheckResult.DOC_SETID = documentlist[0].DOC_SETID;
            qcCheckResult.DOC_TITLE = documentlist[0].DOC_TITLE;
            qcCheckResult.DOCTYPE_ID = documentlist[0].DOC_TYPE;
            qcCheckResult.DOC_TIME = documentlist[0].DOC_TIME;
            StringBuilder sb = new StringBuilder();
            string[] keyNames = new string[] { "会诊科室", "会诊医师姓名及职称", "会诊目的", "会诊时间", "会诊所见", "会诊诊断", "治疗意见" };
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
                sb.AppendFormat("{0}书写会诊记录：",item.DOC_TIME.ToString());
                foreach (var key in keyNames)
                {
                    
                    XmlNode node = doc.SelectSingleNode(string.Format("/EmrDoc/Body/Section[@ID='{0}']//Field[@Name='{1}']", item.DOC_ID,key));
                    if (node == null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(node.InnerText))
                    {
                        sb.AppendFormat("{0}为空，",key);
                        continue;
                    }
                }
                sb.AppendLine(";");
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
