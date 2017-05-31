using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

using Heren.MedQC.Core;
namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 处理规则：主诉不得超过20字
    /// </summary>
    public class ZhuSu20OrderCommand : AbstractCommand
    {
        public ZhuSu20OrderCommand()
        {
            this.m_name = "既往史过敏关键词检查";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;

            result = new QcCheckResult();
            QcCheckResult qcCheckResult = result as QcCheckResult;

            string szXMLFile = null;
            List<MedDocInfo> lstDocInfos = null;
            EmrDocAccess.Instance.GetDocInfos(patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, "", DateTime.Now, qcCheckPoint.DocTypeID, ref lstDocInfos);
            if (lstDocInfos == null || lstDocInfos.Count == 0)
            {
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            MedDocInfo docInfo = lstDocInfos[0];
            MedXMLAccess.Instance.GetDocXml(docInfo, ref szXMLFile);
            if (string.IsNullOrEmpty(szXMLFile))
            {
                qcCheckResult.QC_EXPLAIN = "未写入院记录,规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //分析元素
            qcCheckResult.SCORE = qcCheckPoint.Score;
            StringBuilder sb = new StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.Load(szXMLFile);
            XmlNode node = doc.SelectSingleNode("//section[@name='药物过敏史']");//查找既往史段落中的药物过敏史
            if (node == null)
            {
                qcCheckResult.QC_EXPLAIN = "没有药物过敏史,规则不通过";
                qcCheckResult.QC_RESULT = 0;
                return true;
            }
            else
            {
                if (node.InnerText.Contains("过敏"))
                {
                    qcCheckResult.QC_EXPLAIN = "包含过敏关键词,规则通过";
                    qcCheckResult.QC_RESULT = 1;
                    return true;
                }
                else
                {
                    qcCheckResult.QC_EXPLAIN = "不包含过敏关键词,规则不通过";
                    qcCheckResult.QC_RESULT = 0;
                    return true;
                }
              
            }
            
        }
    }
}
