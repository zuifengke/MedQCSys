using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace EMRDBLib.DbAccess
{
    public class MedXMLAccess : DBAccessBase
    {
        private static MedXMLAccess m_MedXMLAccess = null;


        public static MedXMLAccess Instance
        {
            get
            {
                if (m_MedXMLAccess == null)
                    m_MedXMLAccess = new MedXMLAccess();
                return m_MedXMLAccess;
            }
        }

        public short GetDocXml(MedDocInfo docInfo, ref string szXMLFile)
        {
            string szCacheFile = string.Format("{0}\\Cache\\DAL\\{1}.{2}", SystemParam.Instance.WorkPath
                , docInfo.DOC_ID, SystemData.FileExt.XML_DOCUMENT);

            //对比本地文件，XML是否是最新的，不然则重新下载最新的XML文档
            if (!IsNeedDoanLoadXml(docInfo, szCacheFile))
            {
                szXMLFile = szCacheFile;
                return SystemData.ReturnValue.OK;
            }
            string szRemoteFile = SystemParam.Instance.GetFtpDocPath(docInfo, SystemData.FileExt.XML_DOCUMENT);
            if (DownLoadXml(szRemoteFile, szCacheFile) != SystemData.ReturnValue.OK)
                return SystemData.ReturnValue.EXCEPTION;
            szXMLFile = szCacheFile;
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 判断是否需要下载最新的XML文档
        /// </summary>
        /// <param name="docInfo"></param>
        /// <param name="szCacheFile"></param>
        /// <returns></returns>
        private bool IsNeedDoanLoadXml(MedDocInfo docInfo, string szCacheFile)
        {
            //不存在文件则重新下载
            if (!System.IO.File.Exists(szCacheFile))
                return true;
            XmlDocument doc = new XmlDocument();
            doc.Load(szCacheFile);
            XmlNode node = null;
            if (docInfo.EMR_TYPE != "HEREN")
            {
                node = doc.SelectSingleNode("EmrDoc/DocHeader/DocInfo/ModifyTime");
            }
            else
            {
                node = doc.SelectSingleNode("EmrDoc/DocInfo/ModifyTime");
            }
            if (node == null)
                return true;
            DateTime modifyTime = docInfo.DefaultTime;
            DateTime.TryParse(node.InnerText, out modifyTime);
            if (docInfo.MODIFY_TIME > modifyTime)
                return true;
            return false;
        }

        /// <summary>
        /// 下载XML文档
        /// </summary>
        /// <param name="szRemoteFile"></param>
        /// <param name="szCacheFile"></param>
        /// <returns></returns>
        private short DownLoadXml(string szRemoteFile, string szCacheFile)
        {
            if (string.IsNullOrEmpty(szRemoteFile) || string.IsNullOrEmpty(szRemoteFile))
                return SystemData.ReturnValue.PARAM_ERROR;
            if (base.XDBFtpAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (!base.XDBFtpAccess.OpenConnection())
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (!base.XDBFtpAccess.Download(szRemoteFile, szCacheFile))
            {
                base.XDBFtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }
            base.FtpAccess.CloseConnection();
            return SystemData.ReturnValue.OK;
        }

    }
}
