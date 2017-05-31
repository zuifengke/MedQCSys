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
    /// 缺陷内容：缺药物过敏史，或与首页不一致
    /// 核查方法：从入院记录中查询是否有“对****药物过敏”“有****药物过敏”关键内容，从“对到药物过敏”、从“有到药物过敏”字数不超过20个字，如能查询到，则首页中的过敏不能为空。
    /// </summary>
    public class guominshiCommand : AbstractCommand
    {
        public guominshiCommand()
        {
            this.m_name = "新军卫-缺药物过敏史，或与首页不一致";
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
                      
            XmlNode node = doc.SelectSingleNode(string.Format("//Field[@Name='{0}']", "过敏史－多选"));
            if (node == null || string.IsNullOrEmpty(node.InnerText))//不存在过敏
            {
                qcCheckResult.QC_EXPLAIN = "规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            //存在过敏，则对比首页过敏信息
            string szSQl = string.Format("select ALERGY_DRUGS from inp_visit@link_emr t where t.patient_id ='{0}' and t.visit_no = '{1}'"
              , patVisitLog.PATIENT_ID
              , patVisitLog.VISIT_ID);
            DataSet ds = null;
            short shRet = CommonAccess.Instance.ExecuteQuery(szSQl, out ds);
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                qcCheckResult.QC_EXPLAIN = "患者信息未找到，规则通过";
                qcCheckResult.QC_RESULT = 1;
                return true;
            }
            StringBuilder description = new StringBuilder();
            string ALERGY_DRUGS = ds.Tables[0].Rows[0]["ALERGY_DRUGS"].ToString();
            if (string.IsNullOrEmpty(ALERGY_DRUGS))
            {
                qcCheckResult.QC_EXPLAIN = string.Format("入院记录内过敏史内容存在{0},但首页过敏药物为空",node.InnerText);
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
