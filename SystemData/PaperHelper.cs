// ***********************************************************
// 病历文档系统病历纸张类型配置管理辅助类
// Creator:YangMingkun  Date:2010-8-30
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Xml;
using MedDocSys.Common;

namespace MedDocSys.DataLayer
{
    public class PaperHelper
    {
        private string m_szPaperConfigFile = null;

        private static PaperHelper m_instance = null;
        public static PaperHelper Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new PaperHelper();
                return m_instance;
            }
        }
        private PaperHelper()
        {
            this.m_szPaperConfigFile = string.Concat(GlobalMethods.AppMisc.GetWorkingPath(), "\\PaperConfig.xml");
        }

        /// <summary>
        /// 获取已配置的纸张类型列表
        /// </summary>
        /// <returns>纸张类型列表</returns>
        public List<PaperInfo> GetPaperList()
        {
            List<PaperInfo> lstPaperInfos = new List<PaperInfo>();
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szPaperConfigFile);
            if (xmlDoc == null)
                return lstPaperInfos;

            XmlNodeList nodes = GlobalMethods.Xml.SelectXmlNodes(xmlDoc, "//Item");
            if (nodes == null)
                return lstPaperInfos;

            string szValue = null;
            int nValue = 0;
            for (int index = 0; index < nodes.Count; index++)
            {
                XmlNode node = nodes[index];
                PaperInfo paperInfo = new PaperInfo();
                if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Name", ref szValue))
                    continue;
                paperInfo.Name = szValue;

                if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Width", ref szValue))
                    continue;
                if (int.TryParse(szValue, out nValue))
                    paperInfo.Width = nValue;

                if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Height", ref szValue))
                    continue;
                if (int.TryParse(szValue, out nValue))
                    paperInfo.Height = nValue;

                if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Printer", ref szValue))
                    continue;
                paperInfo.Printer = szValue;

                lstPaperInfos.Add(paperInfo);
            }
            return lstPaperInfos;
        }

        /// <summary>
        /// 获取指定的病历纸张类型信息
        /// </summary>
        /// <param name="szPaperName">纸张名称</param>
        /// <returns>纸张类型信息</returns>
        public PaperInfo GetPaperInfo(string szPaperName)
        {
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szPaperConfigFile);
            if (xmlDoc == null)
                return null;

            string szXPath = string.Format("//Item[@Name='{0}']", szPaperName);
            XmlNodeList nodes = GlobalMethods.Xml.SelectXmlNodes(xmlDoc, szXPath);
            if (nodes == null || nodes.Count <= 0)
                return null;

            string szValue = null;
            int nValue = 0;
            XmlNode node = nodes[0];
            PaperInfo paperInfo = new PaperInfo();
            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Name", ref szValue))
                return null;
            paperInfo.Name = szValue;

            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Width", ref szValue))
                return null;
            if (int.TryParse(szValue, out nValue))
                paperInfo.Width = nValue;

            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Height", ref szValue))
                return null;
            if (int.TryParse(szValue, out nValue))
                paperInfo.Height = nValue;

            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Printer", ref szValue))
                return null;
            paperInfo.Printer = szValue;
            return paperInfo;
        }

        /// <summary>
        /// 获取指定的病历纸张类型信息
        /// </summary>
        /// <param name="szPaperName">纸张名称</param>
        /// <returns>纸张类型信息</returns>
        public PaperInfo GetPaperInfo(float width, float height)
        {
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szPaperConfigFile);
            if (xmlDoc == null)
                return null;

            string szXPath = string.Format("//Item[@Width='{0}' and @Height='{1}']", width.ToString(), height.ToString());
            XmlNodeList nodes = GlobalMethods.Xml.SelectXmlNodes(xmlDoc, szXPath);
            if (nodes == null || nodes.Count <= 0)
                return null;

            string szValue = null;
            int nValue = 0;
            XmlNode node = nodes[0];
            PaperInfo paperInfo = new PaperInfo();
            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Name", ref szValue))
                return null;
            paperInfo.Name = szValue;

            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Width", ref szValue))
                return null;
            if (int.TryParse(szValue, out nValue))
                paperInfo.Width = nValue;

            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Height", ref szValue))
                return null;
            if (int.TryParse(szValue, out nValue))
                paperInfo.Height = nValue;

            if (!GlobalMethods.Xml.GetXmlNodeValue(node, "./@Printer", ref szValue))
                return null;
            paperInfo.Printer = szValue;
            return paperInfo;
        }

        /// <summary>
        /// 保存纸张类型列表
        /// </summary>
        /// <param name="lstPaperInfos">纸张类型列表</param>
        public bool SavePaperList(List<PaperInfo> lstPaperInfos)
        {
            if (lstPaperInfos == null || lstPaperInfos.Count <= 0)
            {
                GlobalMethods.IO.DeleteFile(this.m_szPaperConfigFile);
                return false;
            }
            if (!GlobalMethods.Xml.CreateXmlFile(this.m_szPaperConfigFile, "PaperConfig"))
                return false;

            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szPaperConfigFile);
            if (xmlDoc == null)
                return false;

            for (int index = 0; index < lstPaperInfos.Count; index++)
            {
                PaperInfo paperInfo = lstPaperInfos[index];
                XmlNode node = GlobalMethods.Xml.CreateXmlNode(xmlDoc, null, "Item", null);
                if (node == null)
                    continue;

                if (!GlobalMethods.Xml.SetXmlAttrValue(node, "Name", paperInfo.Name))
                    continue;

                if (!GlobalMethods.Xml.SetXmlAttrValue(node, "Width", paperInfo.Width.ToString()))
                    continue;

                if (!GlobalMethods.Xml.SetXmlAttrValue(node, "Height", paperInfo.Height.ToString()))
                    continue;

                if (!GlobalMethods.Xml.SetXmlAttrValue(node, "Printer", paperInfo.Printer))
                    continue;
            }
            return GlobalMethods.Xml.SaveXmlDocument(xmlDoc, this.m_szPaperConfigFile);
        }
    }
}
