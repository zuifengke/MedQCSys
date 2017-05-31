// ***********************************************************
// 护理电子病历系统,表单类型信息缓存管理器.
// 主要缓存表单类型列表,以及表单模板文件,免得重复下载
// Creator:YangMingkun  Date:2012-8-26
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Heren.Common.Libraries;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace Heren.MedQC.Core
{
    public class FormCache
    {
        private static FormCache m_instance = null;

        /// <summary>
        /// 获取DocTypeCache实例
        /// </summary>
        public static FormCache Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new FormCache();
                return m_instance;
            }
        }

        private FormCache()
        {
            this.m_szCacheIndexFile = GlobalMethods.Misc.GetWorkingPath()
                + @"\Templets\Forms.xml";
        }

        /// <summary>
        /// 模板本地缓存索引文件路径
        /// </summary>
        private string m_szCacheIndexFile = null;

        /// <summary>
        /// 存放表单文档类型的哈希表
        /// </summary>
        private Dictionary<string, TempletType> m_htDocTypeTable = null;

        /// <summary>
        /// 按类别存放表单文档类型的哈希表
        /// </summary>
        private Dictionary<string, List<TempletType>> m_htDocClassTable = null;

        ///// <summary>
        ///// 判断文档类型所属病区时使用的Hash表
        ///// </summary>
        //private Dictionary<string, WardDocType> m_htWardDocTable = null;

        /// <summary>
        /// 加载病历类型列表
        /// </summary>
        /// <param name="szApplyEnv">应用环境</param>
        /// <returns>文档类型信息列表</returns>
        public List<TempletType> GetDocTypeList(string szApplyEnv)
        {
            if (GlobalMethods.Misc.IsEmptyString(szApplyEnv))
                return null;
            if (this.m_htDocClassTable != null
                && this.m_htDocClassTable.ContainsKey(szApplyEnv))
            {
                return this.m_htDocClassTable[szApplyEnv];
            }

            List<TempletType> lstDocTypeInfos = null;
            short shRet = TempletTypeAccess.Instance.GetTempletTypes(szApplyEnv, ref lstDocTypeInfos);
            if (shRet != SystemData.ReturnValue.OK)
                return null;

            if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
                return new List<TempletType>();

            if (this.m_htDocClassTable == null)
                this.m_htDocClassTable = new Dictionary<string, List<TempletType>>();
            this.m_htDocClassTable.Add(szApplyEnv, lstDocTypeInfos);

            if (this.m_htDocTypeTable == null)
                this.m_htDocTypeTable = new Dictionary<string, TempletType>();

            for (int index = 0; index < lstDocTypeInfos.Count; index++)
            {
                TempletType docTypeInfo = lstDocTypeInfos[index];
                if (docTypeInfo == null || string.IsNullOrEmpty(docTypeInfo.DocTypeID))
                    continue;
                if (!this.m_htDocTypeTable.ContainsKey(docTypeInfo.DocTypeID))
                    this.m_htDocTypeTable.Add(docTypeInfo.DocTypeID, docTypeInfo);
            }
            return lstDocTypeInfos;
        }

        /// <summary>
        /// 获取指定ID的文档类型信息
        /// </summary>
        /// <param name="szDocTypeID">文档类型代码</param>
        /// <returns>文档类型信息</returns>
        public TempletType GetDocTypeInfo(string szDocTypeID)
        {
            if (GlobalMethods.Misc.IsEmptyString(szDocTypeID))
                return null;

            //如果是子病历类型
            if (this.m_htDocTypeTable == null)
                this.m_htDocTypeTable = new Dictionary<string, TempletType>();
            if (this.m_htDocTypeTable.ContainsKey(szDocTypeID))
                return this.m_htDocTypeTable[szDocTypeID];

            //重新查询获取文档类型信息
            TempletType docTypeInfo = null;
            short shRet = TempletTypeAccess.Instance.GetTempletType(szDocTypeID, ref docTypeInfo);
            if (shRet != SystemData.ReturnValue.OK || docTypeInfo == null)
                return null;
            this.m_htDocTypeTable.Add(szDocTypeID, docTypeInfo);
            return docTypeInfo;
        }

        /// <summary>
        /// 获取指定应用环境下的病区文档模板
        /// </summary>
        /// <param name="szApplyEnv">应用环境</param>
        /// <returns>文档模板信息</returns>
        public TempletType GetWardDocType(string szApplyEnv)
        {
            List<TempletType> lstDocTypeInfos = this.GetDocTypeList(szApplyEnv);
            if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
                return null;

            //优先选取本病区可用的表单模板
            TempletType hospitalDocTypeInfo = null;
            foreach (TempletType docTypeInfo in lstDocTypeInfos)
            {
                if (docTypeInfo.IsValid && !docTypeInfo.IsFolder)
                {
                    hospitalDocTypeInfo = docTypeInfo;
                    if (this.IsWardDocType(docTypeInfo.DocTypeID))
                        return docTypeInfo;
                }
            }
            return hospitalDocTypeInfo;
        }

        /// <summary>
        /// 获取指定应用环境指定病区下指定名称的表单模板
        /// </summary>
        /// <param name="szApplyEnv">应用环境</param>
        /// <param name="szDocTypeName">表单类型名称</param>
        /// <returns>表单模板信息</returns>
        public TempletType GetWardDocType(string szApplyEnv, string szDocTypeName)
        {
            List<TempletType> lstDocTypeInfos = this.GetDocTypeList(szApplyEnv);
            if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
                return null;

            //优先选取本病区指定名称的表单模板
            TempletType docTypeInfo1 = null;
            TempletType docTypeInfo2 = null;
            foreach (TempletType docTypeInfo in lstDocTypeInfos)
            {
                if (docTypeInfo.IsValid && !docTypeInfo.IsFolder)
                {
                    if (docTypeInfo.DocTypeName.StartsWith(szDocTypeName))
                        docTypeInfo1 = docTypeInfo;
                    if (this.IsWardDocType(docTypeInfo.DocTypeID))
                        docTypeInfo2 = docTypeInfo;
                }
            }
            if (docTypeInfo2 != null && docTypeInfo2.DocTypeName.StartsWith(szDocTypeName))
                return docTypeInfo2;
            return docTypeInfo1;
        }

        /// <summary>
        /// 加载当前病区的病历类型列表
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        private bool LoadWardDocTypeList()
        {
            if (SystemParam.Instance.UserInfo == null)
                return false;

            //List<WardDocType> lstWardDocTypes = null;
            //short shRet = DocTypeService.Instance.GetWardDocTypeList(string.Empty, ref lstWardDocTypes);
            //if (shRet != SystemConst.ReturnValue.OK)
            //    return false;

            //if (this.m_htWardDocTable == null)
            //    this.m_htWardDocTable = new Dictionary<string, WardDocType>();
            //this.m_htWardDocTable.Clear();

            //if (lstWardDocTypes == null || lstWardDocTypes.Count <= 0)
            //    return true;

            //string szWardDocType = null;
            //for (int index = 0; index < lstWardDocTypes.Count; index++)
            //{
            //    WardDocType wardDocType = lstWardDocTypes[index];
            //    if (wardDocType == null || string.IsNullOrEmpty(wardDocType.DocTypeID))
            //        continue;

            //    //将病历类型的第一个所属病区信息加入到hash表
            //    //以便后续较方便的判断该病历类型是否设置了所属病区
            //    if (!this.m_htWardDocTable.ContainsKey(wardDocType.DocTypeID))
            //        this.m_htWardDocTable.Add(wardDocType.DocTypeID, wardDocType);

            //    //同时将病历类型与病区的对应关系加入到hash表
            //    szWardDocType = string.Concat(wardDocType.DocTypeID, "_", wardDocType.WardCode);
            //    if (!this.m_htWardDocTable.ContainsKey(szWardDocType))
            //        this.m_htWardDocTable.Add(szWardDocType, wardDocType);
            //}
            //return true;
            return false;
        }

        /// <summary>
        /// 获取指定的文档类型是否是当前用户病区的
        /// </summary>
        /// <param name="szDocTypeID">指定的文档类型</param>
        /// <returns>是否是当前病区病历</returns>
        public bool IsWardDocType(string szDocTypeID)
        {
            //if (this.m_htWardDocTable == null)
            //{
            //    if (!this.LoadWardDocTypeList())
            //        return false;
            //}
            //if (this.m_htWardDocTable == null || SystemContext.Instance.LoginUser == null)
            //    return true;

            ////如果病历类型未设置所属病区,那么认为是通用
            //if (string.IsNullOrEmpty(szDocTypeID) || !this.m_htWardDocTable.ContainsKey(szDocTypeID))
            //    return true;

            ////返回该病历类型所属病区中是否有当前用户病区
            //string szWardDocType = string.Concat(szDocTypeID, "_", SystemContext.Instance.LoginUser.WardCode);
            //if (this.m_htWardDocTable.ContainsKey(szWardDocType))
            //    return true;

            ////返回该病历类型所属用户组中是否有该用户所在的小组
            //return RightController.Instance.CanOpenNurDoc(m_htWardDocTable, szDocTypeID);
            return true;
        }

        /// <summary>
        /// 获取指定的文档类型对应的表单是否已设置为允许打印
        /// </summary>
        /// <param name="szDocTypeID">文档类型ID</param>
        /// <returns>是否允许打印</returns>
        public bool IsFormPrintable(string szDocTypeID)
        {
            TempletType docTypeInfo = FormCache.Instance.GetDocTypeInfo(szDocTypeID);
            if (docTypeInfo == null)
                return false;
            if (docTypeInfo.PrintMode == FormPrintMode.Form || docTypeInfo.PrintMode == FormPrintMode.FormAndList)
                return true;
            return false;
        }

        /// <summary>
        /// 获取指定的文档类型对应的已写表单列表是否已设置为允许打印
        /// </summary>
        /// <param name="szDocTypeID">文档类型ID</param>
        /// <returns>是否允许打印</returns>
        public bool IsFormListPrintable(string szDocTypeID)
        {
            TempletType docTypeInfo = FormCache.Instance.GetDocTypeInfo(szDocTypeID);
            if (docTypeInfo == null)
                return false;
            if (docTypeInfo.PrintMode == FormPrintMode.List || docTypeInfo.PrintMode == FormPrintMode.FormAndList)
                return true;
            return false;
        }

        /// <summary>
        /// 获取表单模板本地缓存路径
        /// </summary>
        /// <param name="szDocTypeID">文档类型ID</param>
        /// <returns>模板本地缓存路径</returns>
        private string GetFormCachePath(string szDocTypeID)
        {
            return string.Format(@"{0}\Templets\Forms\{1}.hndt", GlobalMethods.Misc.GetWorkingPath(), szDocTypeID);
        }

        /// <summary>
        /// 获取文档模板的修改时间
        /// </summary>
        /// <param name="szDocTypeID">表单类型ID(如果是表单模板)</param>
        /// <returns>DateTime</returns>
        public DateTime GetFormModifyTime(string szDocTypeID)
        {
            if (!System.IO.File.Exists(this.m_szCacheIndexFile))
                return DateTime.Now;

            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szCacheIndexFile);
            if (xmlDoc == null)
                return DateTime.Now;

            string szXPath = null;
            if (!GlobalMethods.Misc.IsEmptyString(szDocTypeID))
                szXPath = string.Format("/Forms/Templet[@ID='{0}']", szDocTypeID.Trim());
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
        /// 获取指定表单类型对应的表单模板数据
        /// </summary>
        /// <param name="szDocTypeID">文档类型ID</param>
        /// <param name="byteTempletData">返回的模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public bool GetFormTemplet(string szDocTypeID, ref byte[] byteTempletData)
        {
            TempletType docTypeInfo = this.GetDocTypeInfo(szDocTypeID);
            if (docTypeInfo == null)
            {
                LogManager.Instance.WriteLog("FormCache.GetFormTemplet"
                     , new string[] { "szDocTypeID" }, new object[] { szDocTypeID }, "表单不存在!");
                return false;
            }
            return this.GetFormTemplet(docTypeInfo, ref byteTempletData);
        }

        /// <summary>
        /// 获取指定表单类型对应的表单模板数据
        /// </summary>
        /// <param name="docTypeInfo">文档类型信息</param>
        /// <param name="byteTempletData">返回的模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public bool GetFormTemplet(TempletType docTypeInfo, ref byte[] byteTempletData)
        {
            if (docTypeInfo == null || GlobalMethods.Misc.IsEmptyString(docTypeInfo.DocTypeID))
                return false;

            string szTempletPath = this.GetFormCachePath(docTypeInfo.DocTypeID);

            // 如果本地已经有模板缓存,那么返回本地的
            DateTime dtModifyTime = this.GetFormModifyTime(docTypeInfo.DocTypeID);
            if (dtModifyTime.CompareTo(docTypeInfo.ModifyTime) == 0)
            {
                if (GlobalMethods.IO.GetFileBytes(szTempletPath, ref byteTempletData))
                    return true;
            }

            // 创建本地目录
            string szParentDir = GlobalMethods.IO.GetFilePath(szTempletPath);
            if (!GlobalMethods.IO.CreateDirectory(szParentDir))
            {
                LogManager.Instance.WriteLog("FormCache.GetFormTemplet"
                    , new string[] { "docTypeInfo" }, new object[] { docTypeInfo }, "表单模板缓存目录创建失败!", null);
                return false;
            }

            // 下载文档模板内容
            short shRet = TempletTypeAccess.Instance.GetTempletData(docTypeInfo.DocTypeID, ref byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("FormCache.GetFormTemplet"
                    , new string[] { "docTypeInfo" }, new object[] { docTypeInfo }, "表单模板下载失败!", null);
                return false;
            }

            // 写用户模板本地索引信息
            if (!this.CacheFormTemplet(docTypeInfo, byteTempletData))
            {
                LogManager.Instance.WriteLog("FormCache.GetFormTemplet"
                    , new string[] { "docTypeInfo" }, new object[] { docTypeInfo }, "表单模板缓存到本地失败!", null);
            }
            return true;
        }

        /// <summary>
        /// 将指定的系统模板数据缓存到本地
        /// </summary>
        /// <param name="docTypeInfo">文档类型信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        private bool CacheFormTemplet(TempletType docTypeInfo, byte[] byteTempletData)
        {
            if (docTypeInfo == null || byteTempletData == null || byteTempletData.Length <= 0)
                return false;

            //缓存系统模板内容到本地
            string szTempletPath = this.GetFormCachePath(docTypeInfo.DocTypeID);
            if (!GlobalMethods.IO.WriteFileBytes(szTempletPath, byteTempletData))
            {
                LogManager.Instance.WriteLog("FormCache.CacheFormTemplet"
                    , new string[] { "docTypeInfo", "szTempletPath" }, new object[] { docTypeInfo, szTempletPath }
                    , "表单模板数据缓存到本地失败!", null);
                return false;
            }

            //装载模板本地索引文件
            if (!System.IO.File.Exists(this.m_szCacheIndexFile))
            {
                if (!GlobalMethods.Xml.CreateXmlFile(this.m_szCacheIndexFile, "Forms"))
                    return false;
            }
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(this.m_szCacheIndexFile);
            if (xmlDoc == null)
            {
                return false;
            }

            // 添加或更新模板本地索引节点
            string szXPath = string.Format("/Forms/Templet[@ID='{0}']", docTypeInfo.DocTypeID);
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
                LogManager.Instance.WriteLog("FormCache.CacheFormTemplet"
                    , new string[] { "docTypeInfo" }, new object[] { docTypeInfo }, "表单模板本地索引信息写入失败!", ex);
                return false;
            }
            if (templetXmlNode == null)
            {
                LogManager.Instance.WriteLog("FormCache.CacheFormTemplet"
                    , new string[] { "docTypeInfo", "szXPath" }, new object[] { docTypeInfo, szXPath }
                    , "表单模板本地索引信息写入失败!无法创建节点!", null);
                return false;
            }

            //设置模板索引节点的属性值
            if (!GlobalMethods.Xml.SetXmlAttrValue(templetXmlNode, "ID", docTypeInfo.DocTypeID))
                return false;
            if (!GlobalMethods.Xml.SetXmlAttrValue(templetXmlNode, "Name", docTypeInfo.DocTypeName))
                return false;
            if (!GlobalMethods.Xml.SetXmlAttrValue(templetXmlNode, "ModifyTime", docTypeInfo.ModifyTime.ToString()))
                return false;
            if (!GlobalMethods.Xml.SaveXmlDocument(xmlDoc, this.m_szCacheIndexFile))
                return false;
            return true;
        }
    }
}
