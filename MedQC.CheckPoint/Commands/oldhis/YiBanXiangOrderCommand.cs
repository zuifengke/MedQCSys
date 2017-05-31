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
    public class YiBanXiangOrderCommand : AbstractCommand
    {
        public YiBanXiangOrderCommand()
        {
            this.m_name = "入院记录一般项目检查";
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
         
            XmlDocument doc = new XmlDocument();
            doc.Load(szXMLFile);
            //入院记录中姓名、出生地、性别、职业、年龄、入院时间、婚姻、病史记录时间、民族、病史陈述者不能为空
            //有时候节点不是fieldelem，则采用二维数组
            string[] items =   { 
                                "病人姓名",  "病人出生地", "病人性别",
                                "部 职 别",  "病人年龄", "入院时间",
                                "病人婚姻状况",  "yyyy年M月d日 HH:mm", "病人民族",
                                "病史陈述者"
                                };
         
            for (int i =0;i< items.Length;i++)
            {
                XmlNode node = doc.SelectSingleNode(string.Format("//fieldelem[@name='{0}']", items[i]));
                if (node == null||string.IsNullOrEmpty(node.InnerText))//存在一项为空则直接返回不继续判断
                {
                    qcCheckResult.QC_EXPLAIN = string.Format("{0}为空，规则不通过", items[i]);
                    qcCheckResult.QC_RESULT = 0;
                    return true;
                }
            }


            qcCheckResult.QC_EXPLAIN = "一般项目检查都不为空，规则通过";
            qcCheckResult.QC_RESULT = 1;
            return true;

        }
    }
}
