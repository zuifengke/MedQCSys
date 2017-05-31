// ***********************************************************
// 文档窗口工厂类
// Creator:YangMingkun  Date:2010-11-17
// Copyright:supconhealth
// ***********************************************************
using System;
using Heren.Common.Controls;
using MedDocSys.DataLayer;
using Heren.Common.Libraries;
using EMRDBLib;

namespace MedQCSys.Document
{
    internal class DocFormFactory
    {
        private static DocFormFactory m_instance = null;
        /// <summary>
        /// 获取DocFormFactory实例
        /// </summary>
        public static DocFormFactory Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new DocFormFactory();
                return m_instance;
            }
        }
        private DocFormFactory()
        {
        }

        public IDocumentForm CreateDocForm(MainForm mainForm,MedDocInfo docInfo)
        {
            if (mainForm == null || docInfo == null)
                return null;

            if (GlobalMethods.Misc.IsEmptyString(docInfo.PATIENT_ID))
                return null;

            if (GlobalMethods.Misc.IsEmptyString(docInfo.VISIT_ID))
                return null;

            if (docInfo.EMR_TYPE == "EMRPADX")
                return new EMRPadXDocForm(mainForm);
            else if (docInfo.EMR_TYPE == "WINWORD")
                return new WinWordDocForm(mainForm);
            else if (docInfo.EMR_TYPE == "CHENPAD")
                return new ChenPadDocForm(mainForm);
            else if (docInfo.EMR_TYPE == "HEREN")
                return new HerenDocForm(mainForm);
            else
                return new BaodianDocForm(mainForm);
        }

        public IDocumentForm CreateDocForm(MainForm mainForm, MedDocList lstDocInfos)
        {
            return (lstDocInfos == null || lstDocInfos.Count <= 0) ? null : this.CreateDocForm(mainForm, lstDocInfos[0]);
        }
    }
}
