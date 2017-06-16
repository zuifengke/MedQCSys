// ***********************************************************
// 护理电子病历系统,报表类型信息缓存管理器.
// 主要缓存报表类型列表,以及报表模板文件,免得重复下载
// Creator:YangMingkun  Date:2012-8-26
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using Heren.Common.Libraries;
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace Heren.MedQC.Core
{
    public class ReportCache
    {
        private static ReportCache m_instance = null;

        /// <summary>
        /// 获取ReportCache实例
        /// </summary>
        public static ReportCache Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new ReportCache();
                return m_instance;

            }
        }

        private ReportCache()
        {
            this.m_szCacheIndexFile = GlobalMethods.Misc.GetWorkingPath()
                + @"\Templets\Reports.xml";
        }

        /// <summary>
        /// 模板本地缓存索引文件路径
        /// </summary>
        private string m_szCacheIndexFile = null;

        /// <summary>
        /// 存放报表类型的哈希表
        /// </summary>
        private Dictionary<string, ReportType> m_htReportTypeTable = null;

        /// <summary>
        /// 按类别存放报表类型的哈希表
        /// </summary>
        private Dictionary<string, List<ReportType>> m_htReportClassTable = null;


        /// <summary>
        /// 加载病历类型列表
        /// </summary>
        /// <param name="szApplyEnv">应用环境</param>
        /// <returns>报表类型信息列表</returns>
        public List<ReportType> GetReportTypeList(string szApplyEnv)
        {
            if (GlobalMethods.Misc.IsEmptyString(szApplyEnv))
                return null;

            List<ReportType> lstReportTypes = null;
            short shRet = ReportTypeAccess.Instance.GetReportTypes(szApplyEnv, ref lstReportTypes);
            if (shRet != SystemData.ReturnValue.OK)
                return null;
            return lstReportTypes;
            if (this.m_htReportClassTable != null
                && this.m_htReportClassTable.ContainsKey(szApplyEnv))
            {
                return this.m_htReportClassTable[szApplyEnv];
            }


            if (lstReportTypes == null || lstReportTypes.Count <= 0)
                return new List<ReportType>();

            if (this.m_htReportClassTable == null)
                this.m_htReportClassTable = new Dictionary<string, List<ReportType>>();
            this.m_htReportClassTable.Add(szApplyEnv, lstReportTypes);

            if (this.m_htReportTypeTable == null)
                this.m_htReportTypeTable = new Dictionary<string, ReportType>();

            for (int index = 0; index < lstReportTypes.Count; index++)
            {
                ReportType ReportType = lstReportTypes[index];
                if (ReportType == null || string.IsNullOrEmpty(ReportType.ReportTypeID))
                    continue;
                if (!this.m_htReportTypeTable.ContainsKey(ReportType.ReportTypeID))
                    this.m_htReportTypeTable.Add(ReportType.ReportTypeID, ReportType);
            }
            return lstReportTypes;
        }

        /// <summary>
        /// 获取指定ID的报表类型信息
        /// </summary>
        /// <param name="szReportTypeID">报表类型代码</param>
        /// <returns>报表类型信息</returns>
        public ReportType GetReportType(string szReportTypeID)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportTypeID))
                return null;
            //重新查询获取报表类型信息
            ReportType ReportType = null;
            short shRet = ReportTypeAccess.Instance.GetReportType(szReportTypeID, ref ReportType);
            if (shRet != SystemData.ReturnValue.OK || ReportType == null)
                return null;
            //如果是子病历类型
            if (this.m_htReportTypeTable == null)
                this.m_htReportTypeTable = new Dictionary<string, ReportType>();
            if (this.m_htReportTypeTable.ContainsKey(szReportTypeID))
            {
                if (m_htReportTypeTable[szReportTypeID].ModifyTime == ReportType.ModifyTime)
                    return this.m_htReportTypeTable[szReportTypeID];
                else
                {
                    this.m_htReportTypeTable[szReportTypeID] = ReportType;
                }
            }
            else
                this.m_htReportTypeTable.Add(szReportTypeID, ReportType);
            return ReportType;
        }

        /// <summary>
        /// 获取指定应用环境下的病区报表模板
        /// </summary>
        /// <param name="szApplyEnv">应用环境</param>
        /// <returns>报表模板信息</returns>
        public ReportType GetWardReportType(string szApplyEnv)
        {
            List<ReportType> lstReportTypes = this.GetReportTypeList(szApplyEnv);
            if (lstReportTypes == null || lstReportTypes.Count <= 0)
                return null;

            //优先选取本病区可用的报表模板
            ReportType hospitalReportType = null;
            ReportType WardReportType = null;
            foreach (ReportType ReportType in lstReportTypes)
            {
                if (ReportType.IsValid && !ReportType.IsFolder)
                {
                    if (this.IshospitalReportType(ReportType.ReportTypeID))
                    {
                        if (hospitalReportType == null)
                            hospitalReportType = ReportType;
                        else
                            continue;
                    }
                    //else if (this.IsWardReportType(ReportType.ReportTypeID))
                    //    WardReportType = ReportType;
                }
            }
            if (WardReportType == null)
                return hospitalReportType;
            else
                return WardReportType;
        }

        /// <summary>
        /// 获取指定应用环境指定病区下指定名称的报表模板
        /// </summary>
        /// <param name="szApplyEnv">应用环境</param>
        /// <param name="szReportName">报告类型名称</param>
        /// <returns>报表模板信息</returns>
        public ReportType GetWardReportType(string szApplyEnv, string szReportName)
        {
            List<ReportType> lstReportTypes = this.GetReportTypeList(szApplyEnv);
            if (lstReportTypes == null)
                return null;

            //优先选取本病区指定名称的报表模板
            //1当前病区，名字完全匹配
            //2当前病区，名字前部分匹配
            //3全院，名字完全匹配
            //4全院，名字前部分匹配
            ReportType ReportType1 = null;
            ReportType ReportType2 = null;
            ReportType ReportType3 = null;
            ReportType ReportType4 = null;
            foreach (ReportType ReportType in lstReportTypes)
            {
                if (ReportType.IsValid && !ReportType.IsFolder)
                {
                    if (ReportType.ReportTypeName.StartsWith(szReportName)
                        && this.IshospitalReportType(ReportType.ReportTypeID))
                    {
                        if (ReportType.ReportTypeName == szReportName)
                            ReportType3 = ReportType;
                        if (ReportType4 == null)
                            ReportType4 = ReportType;
                    }
                    else if (ReportType.ReportTypeName.StartsWith(szReportName)
                        //&& this.IsWardReportType(ReportType.ReportTypeID)
                        )
                    {
                        if (ReportType.ReportTypeName == szReportName)
                            ReportType1 = ReportType;
                        if (ReportType2 == null)
                            ReportType2 = ReportType;
                    }
                }
            }
            if (ReportType1 != null)
                return ReportType1;
            else if (ReportType2 != null)
                return ReportType2;
            else if (ReportType3 != null)
                return ReportType3;
            else
                return ReportType4;
        }


        /// <summary>
        /// 获取指定的报表类型是否是全院的
        /// </summary>
        /// <param name="szDocTypeID">指定的报表类型</param>
        /// <returns>是否是全院的病历</returns>
        public bool IshospitalReportType(string szDocTypeID)
        {
            //if (this.m_htWardReportTable == null)
            //{
            //    if (!this.LoadWardReportTypeList())
            //        return false;
            //}
            //if (this.m_htWardReportTable == null || SystemContext.Instance.LoginUser == null)
            //    return true;
            return true;
            //如果病历类型未设置所属病区,那么认为是通用
            //if (string.IsNullOrEmpty(szDocTypeID) || !this.m_htWardReportTable.ContainsKey(szDocTypeID))
            //    return true;
            //return false;
        }

        /// <summary>
        /// 获取报表模板本地缓存路径
        /// </summary>
        /// <param name="szTempletID">模板ID</param>
        /// <returns>模板本地缓存路径</returns>
        private string GetReportCachePath(string szTempletID)
        {
            return string.Format(@"{0}\Templets\Reports\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), szTempletID);
        }

        /// <summary>
        /// 获取报表模板的修改时间
        /// </summary>
        /// <param name="szTempletID">报表模板ID(如果是报表模板)</param>
        /// <returns>DateTime</returns>
        public DateTime GetReportModifyTime(string szTempletID)
        {
            if (!System.IO.File.Exists(this.m_szCacheIndexFile))
                return DateTime.Now;

            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szCacheIndexFile);
            if (xmlDoc == null)
                return DateTime.Now;

            string szXPath = null;
            if (!GlobalMethods.Misc.IsEmptyString(szTempletID))
                szXPath = string.Format("/Reports/Templet[@ID='{0}']", szTempletID.Trim());
            else
                return DateTime.Now;

            XmlNode templetNode = GlobalMethods.Xml.SelectXmlNode(xmlDoc, szXPath);
            if (templetNode == null)
                return DateTime.Now;

            string szModifyTime = null;
            if (!GlobalMethods.Xml.GetXmlNodeValue(templetNode, "./@ModifyTime", ref szModifyTime))
                return DateTime.Now;

            DateTime dtModifyTime = DateTime.Now;
            GlobalMethods.Convert.StringToDate(szModifyTime, ref dtModifyTime);
            return dtModifyTime;
        }

        /// <summary>
        /// 根据报表模板ID,获取报表模板数据
        /// </summary>
        /// <param name="szReportTypeID">报表模板ID</param>
        /// <param name="byteTempletData">返回的模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public bool GetReportTemplet(string szReportTypeID, ref byte[] byteTempletData)
        {
            ReportType ReportType = this.GetReportType(szReportTypeID);
            if (ReportType == null)
            {
                LogManager.Instance.WriteLog("FormCache.GetReportTemplet"
                     , new string[] { "szReportTypeID" }, new object[] { szReportTypeID }, "报表不存在!");
                return false;
            }
            return this.GetReportTemplet(ReportType, ref byteTempletData);
        }

        /// <summary>
        /// 根据报表模板信息,获取报表模板数据
        /// </summary>
        /// <param name="ReportType">报表模板信息</param>
        /// <param name="byteTempletData">报表模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public bool GetReportTemplet(ReportType ReportType, ref byte[] byteTempletData)
        {
            if (ReportType == null || GlobalMethods.Misc.IsEmptyString(ReportType.ReportTypeID))
                return false;

            string szTempletPath = this.GetReportCachePath(ReportType.ReportTypeID);

            // 如果本地已经有模板缓存,那么返回本地的
            DateTime dtModifyTime = this.GetReportModifyTime(ReportType.ReportTypeID);
            if (dtModifyTime.CompareTo(ReportType.ModifyTime) == 0)
            {
                if (GlobalMethods.IO.GetFileBytes(szTempletPath, ref byteTempletData))
                    return true;
            }

            // 创建本地目录
            string szParentDir = GlobalMethods.IO.GetFilePath(szTempletPath);
            if (!GlobalMethods.IO.CreateDirectory(szParentDir))
            {
                LogManager.Instance.WriteLog("ReportCache.GetReportTemplet"
                    , new string[] { "templetInfo" }, new object[] { ReportType }, "报表模板缓存目录创建失败!", null);
                return false;
            }

            // 下载报表模板内容
            short shRet = ReportTypeAccess.Instance.GetReportData(ReportType.ReportTypeID, ref byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("ReportCache.GetReportTemplet"
                    , new string[] { "templetInfo" }, new object[] { ReportType }, "报表模板下载失败!", null);
                return false;
            }

            // 写用户模板本地索引信息
            if (!this.CacheReportTemplet(ReportType, byteTempletData))
            {
                LogManager.Instance.WriteLog("ReportCache.GetReportTemplet"
                    , new string[] { "templetInfo" }, new object[] { ReportType }, "报表模板缓存到本地失败!", null);
            }
            return true;
        }

        /// <summary>
        /// 将指定的用户模板数据缓存到本地
        /// </summary>
        /// <param name="ReportType">模板信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        private bool CacheReportTemplet(ReportType ReportType, byte[] byteTempletData)
        {
            if (ReportType == null || byteTempletData == null || byteTempletData.Length <= 0)
                return false;

            //缓存模版文件内容到本地
            string szTempletPath = this.GetReportCachePath(ReportType.ReportTypeID);
            if (!GlobalMethods.IO.WriteFileBytes(szTempletPath, byteTempletData))
            {
                LogManager.Instance.WriteLog("ReportCache.CacheReportTemplet"
                    , new string[] { "ReportType", "szTempletPath" }, new object[] { ReportType, szTempletPath }
                    , "报表模板数据缓存到本地失败!", null);
                return false;
            }

            //装载模板本地索引文件
            if (!System.IO.File.Exists(this.m_szCacheIndexFile))
            {
                if (!GlobalMethods.Xml.CreateXmlFile(this.m_szCacheIndexFile, "Reports"))
                    return false;
            }
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szCacheIndexFile);
            if (xmlDoc == null)
            {
                return false;
            }

            //添加或更新当前模板索引节点
            string szXPath = string.Format("/Reports/Templet[@ID='{0}']", ReportType.ReportTypeID);
            XmlNode templetXmlNode = null;
            try
            {
                templetXmlNode = GlobalMethods.Xml.SelectXmlNode(xmlDoc, szXPath);
                if (templetXmlNode == null)
                {
                    templetXmlNode = GlobalMethods.Xml.CreateXmlNode(xmlDoc, null, "Templet", null);
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ReportCache.CacheReportTemplet"
                    , new string[] { "ReportType" }, new string[] { ReportType.ToString() }
                    , "报表模板本地索引信息写入失败!", ex);
                return false;
            }
            if (templetXmlNode == null)
            {
                LogManager.Instance.WriteLog("ReportCache.CacheReportTemplet"
                    , new string[] { "docTypeInfo", "szXPath" }, new string[] { ReportType.ToString(), szXPath }
                    , "报表模板本地索引信息写入失败!无法创建节点!", null);
                return false;
            }

            //设置模板本地索引节点的属性值
            if (!GlobalMethods.Xml.SetXmlAttrValue(templetXmlNode, "ID", ReportType.ReportTypeID.ToString()))
                return false;
            if (!GlobalMethods.Xml.SetXmlAttrValue(templetXmlNode, "Name", ReportType.ReportTypeName))
                return false;
            if (!GlobalMethods.Xml.SetXmlAttrValue(templetXmlNode, "ModifyTime", ReportType.ModifyTime.ToString()))
                return false;
            if (!GlobalMethods.Xml.SaveXmlDocument(xmlDoc, this.m_szCacheIndexFile))
                return false;
            return true;
        }
    }
}
