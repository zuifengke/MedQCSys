using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
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
    public class JiaZuShiOrderCommand : AbstractCommand
    {
        public JiaZuShiOrderCommand()
        {
            this.m_name = "家族史父母关键字，遗传检查";
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
            XmlNode node = doc.SelectSingleNode("//section[@name='t家族史']");//查找既往史段落中的药物过敏史
            if (node == null)
            {
                qcCheckResult.QC_EXPLAIN = "没有药物过敏史,规则不通过";
                qcCheckResult.QC_RESULT = 0;
                return true;
            }

            if (patVisitLog.Age == 0)
            {
                patVisitLog.Age = (int)((patVisitLog.VISIT_TIME- patVisitLog.BIRTH_TIME ).TotalDays/365);
            }
            if (patVisitLog.Age < 50)
            {
                if (!node.InnerText.Contains("父") && !node.InnerText.Contains("母"))
                {
                    qcCheckResult.QC_EXPLAIN = "家族史患者年龄小于50岁不包含父母关键字，规则不通过";
                    qcCheckResult.QC_RESULT = 0;
                    return true;
                }
                if (!node.InnerText.Contains("遗传"))
                {
                    qcCheckResult.QC_EXPLAIN = "家族史不包含遗传关键字，规则不通过";
                    qcCheckResult.QC_RESULT = 0;
                    return true;
                }
            }

            qcCheckResult.QC_EXPLAIN = "家族史中包含父母、遗传关键词,规则通过";
            qcCheckResult.QC_RESULT = 1;
            return true;
        }
    }
}
