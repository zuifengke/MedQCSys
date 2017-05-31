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
    /// 缺陷内容：头颈五官、胸、腹、四肢及神经系统检查缺任何一项
    /// 核查方法：入院记录体格检查中体温（T）与℃（度）、脉（P）搏与次／分、呼吸（R）与次／分、血压与mmHg（kPa） 之间必须有数字或内容，不能为空。项目名称可以是中文，也可以大写的英文字母。
    /// 需包含关键词“头”，“眼”，“耳”，“口”，“鼻”，“颈”，“胸”，“腹”，“肢”，“反射”十个关键词。（其中的关键词在专科检查中可以）
    /// 对于体温核查时，如果“体温”和“脉搏”之间，有关键词“不升”或“测”，也算满足要求。
    /// 对于血压核查时，如果患者的年龄小于5岁，不进行血压检测。
    /// </summary>
    public class tigejianchaCommand : AbstractCommand
    {
        public tigejianchaCommand()
        {
            this.m_name = "新军卫-检查缺任何一项";
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

            XmlNode node = doc.SelectSingleNode(string.Format("//Field[@Name='{0}']", "体格检查"));
            if (node == null || string.IsNullOrEmpty(node.InnerText))//存在一项为空则直接返回不继续判断
            {
                qcCheckResult.QC_EXPLAIN = string.Format("{0}为空", "体格检查");
                qcCheckResult.QC_RESULT = 0;
                qcCheckResult.ERROR_COUNT = 1;
                return true;
            }
            
            if (node.InnerText.IndexOf("头") < 0 
                || node.InnerText.IndexOf("头") < 0
                || node.InnerText.IndexOf("眼") < 0
                || node.InnerText.IndexOf("耳") < 0
                || node.InnerText.IndexOf("口") < 0
                || node.InnerText.IndexOf("鼻") < 0
                || node.InnerText.IndexOf("颈") < 0
                || node.InnerText.IndexOf("胸") < 0
                || node.InnerText.IndexOf("腹") < 0
                || node.InnerText.IndexOf("肢") < 0
                || node.InnerText.IndexOf("反射") < 0)
            {
                qcCheckResult.QC_EXPLAIN = string.Format("体格检查缺“头”，“眼”，“耳”，“口”，“鼻”，“颈”，“胸”，“腹”，“肢”，“反射”其一项");
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
