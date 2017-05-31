// ***********************************************************
// 病历文档系统数据访问层接口封装类.
// Creator:YangMingkun  Date:2009-6-22
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using MedDocSys.Common;

namespace MedDocSys.DataLayer
{
    public class DataAccess
    {
        private static MDSDBLib.DbAccess.CommonAccess m_CommonAccess = null;
        private static MDSDBLib.DbAccess.ConfigAccess m_ConfigAccess = null;
        private static MDSDBLib.DbAccess.DocTypeAccess m_DocTypeAccess = null;
        private static MDSDBLib.DbAccess.MedDocAccess m_MedDocAccess = null;
        private static MDSDBLib.DbAccess.EMRDBAccess m_EMRDBAccess = null;
        private static MDSDBLib.DbAccess.MedQCAccess m_MedQCAccess = null;
        private static MDSDBLib.DbAccess.TempletAccess m_TempletAccess = null;

        protected static MDSDBLib.DbAccess.ConfigAccess ConfigAccess
        {
            get
            {
                if (m_ConfigAccess == null)
                    m_ConfigAccess = new MDSDBLib.DbAccess.ConfigAccess();
                return m_ConfigAccess;
            }
        }

        protected static MDSDBLib.DbAccess.CommonAccess CommonAccess
        {
            get
            {
                if (m_CommonAccess == null)
                    m_CommonAccess = new MDSDBLib.DbAccess.CommonAccess();
                return m_CommonAccess;
            }
        }

        protected static MDSDBLib.DbAccess.DocTypeAccess DocTypeAccess
        {
            get
            {
                if (m_DocTypeAccess == null)
                    m_DocTypeAccess = new MDSDBLib.DbAccess.DocTypeAccess();
                return m_DocTypeAccess;
            }
        }

        protected static MDSDBLib.DbAccess.MedDocAccess MedDocAccess
        {
            get
            {
                if (m_MedDocAccess == null)
                    m_MedDocAccess = new MDSDBLib.DbAccess.MedDocAccess();
                return m_MedDocAccess;
            }
        }

        protected static MDSDBLib.DbAccess.EMRDBAccess EMRDBAccess
        {
            get
            {
                if (m_EMRDBAccess == null)
                    m_EMRDBAccess = new MDSDBLib.DbAccess.EMRDBAccess();
                return m_EMRDBAccess;
            }
        }

        protected static MDSDBLib.DbAccess.MedQCAccess MedQCAccess
        {
            get
            {
                if (m_MedQCAccess == null)
                    m_MedQCAccess = new MDSDBLib.DbAccess.MedQCAccess();
                return m_MedQCAccess;
            }
        }

        protected static MDSDBLib.DbAccess.TempletAccess TempletAccess
        {
            get
            {
                if (m_TempletAccess == null)
                    m_TempletAccess = new MDSDBLib.DbAccess.TempletAccess();
                return m_TempletAccess;
            }
        }

        /// <summary>
        /// 获取MDSDBAccess异常错误代码对应的错误信息
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <returns>错误信息</returns>
        protected static string GetDBAccessError(short errorCode)
        {
            string szErrorInfo = "发生未知异常错误!";
            switch (errorCode)
            {
                case 1:
                    { szErrorInfo = "传入参数错误!"; break; }
                case 2:
                    { szErrorInfo = "数据库访问异常!"; break; }
                case 3:
                    { szErrorInfo = "接口内部异常!"; break; }
                case 4:
                    { szErrorInfo = "资源未发现!"; break; }
                case 5:
                    { szErrorInfo = "资源已经存在!"; break; }
                case 6:
                    { szErrorInfo = "插入记录失败!"; break; }
            }
            return szErrorInfo;
        }

        private static string m_OcxConnectionString = string.Empty;
        /// <summary>
        /// 获取宝典数据库连接串
        /// </summary>
        public static string OcxConnectionString
        {
            get
            {
                if (DataAccess.ConfigAccess == null)
                    return string.Empty;
                if (GlobalMethods.AppMisc.IsEmptyString(m_OcxConnectionString))
                    m_OcxConnectionString = ConfigAccess.GetBaodianConnectionString();
                return m_OcxConnectionString;
            }
        }

        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <param name="dtSysDate">数据库服务器时间</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetServerTime(ref DateTime dtSysDate)
        {
            dtSysDate = DateTime.Now;

            if (DataAccess.CommonAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = CommonAccess.GetServerTime(ref dtSysDate);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetServerTime", DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取OCX控件认证服务器访问参数
        /// </summary>
        /// <param name="szIP">认证服务器IP</param>
        /// <param name="nPort">认证服务端口</param>
        /// <param name="nMode">认证模式</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetBaodianConfig(ref string szIP, ref int nPort, ref int nMode)
        {
            if (DataAccess.ConfigAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = ConfigAccess.GetBaodianConfig(ref szIP, ref nPort, ref nMode);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetOcxAuthenSrv", DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档归类信息(门诊医生、住院医生、护士或者其他)，获取对应的所有主文档类型信息列表
        /// </summary>
        /// <param name="szDocRight">文档创建权限类别</param>
        /// <param name="szApplyEvn">应用环境</param>
        /// <param name="lstDocTypeInfos">文档类型信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetHostDocTypeInfos(string szDocRight, string szApplyEvn, ref List<MDSDBLib.DocTypeInfo> lstDocTypeInfos)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.GetHostDocTypeInfos(szDocRight, szApplyEvn, ref lstDocTypeInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetHostDocTypeInfos", new string[] { "szDocRight", "szApplyEvn" }
                    , new object[] { szDocRight, szApplyEvn }, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据主文档类型Code，获取子文档类型信息列表
        /// </summary>
        /// <param name="szTypeCode">主文档类型代码</param>
        /// <param name="lstDocTypeInfos">文档类型信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetSubDocTypeInfos(string szTypeCode, ref List<MDSDBLib.DocTypeInfo> lstDocTypeInfos)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.GetSubDocTypeInfos(szTypeCode, ref lstDocTypeInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetSubDocTypeInfos", new string[] { "szTypeCode" }
                    , new object[] { szTypeCode }, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定文档类型代码获取文档类型信息
        /// </summary>
        /// <param name="szDocTypeID">文档类型代码</param>
        /// <param name="docTypeInfo">文档类型信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocTypeInfo(string szDocTypeID, ref MDSDBLib.DocTypeInfo docTypeInfo)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.GetDocTypeInfo(szDocTypeID, ref docTypeInfo);
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocTypeInfo", new string[] { "szDocTypeID" }
                    , new object[] { szDocTypeID }, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取可用的文档类型信息列表
        /// </summary>
        /// <param name="lstDocTypeInfos">文档类型信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocTypeInfos(ref List<MDSDBLib.DocTypeInfo> lstDocTypeInfos)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.GetDocTypeInfos(ref lstDocTypeInfos);
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocTypeInfos", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档类型Code，用户ID，获取用户自定义的文档模板信息列表
        /// </summary>
        /// <param name="szDeptCode">科室代码,为空时返回所有科室</param>
        /// <param name="szTypeCode">文档类型代码,为空时返回所有类型的模板</param>
        /// <param name="szUserID">用户ID,为空时返回所有用户的模板</param>
        /// <param name="lstTempletInfos">文档模板信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetUserTempletInfos(string szDeptCode, string szTypeCode, string szUserID, ref List<MDSDBLib.TempletInfo> lstTempletInfos)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            if (lstTempletInfos == null)
                lstTempletInfos = new List<MDSDBLib.TempletInfo>();

            short shRet = TempletAccess.GetUserTempletInfos(szDeptCode, szTypeCode, szUserID, ref lstTempletInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetUserTempletInfos", new string[] { "szDeptCode", "szTypeCode", "szUserID" }
                    , new object[] { szDeptCode, szTypeCode, szUserID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档模板ID获取文档模板信息
        /// </summary>
        /// <param name="szTempletID">文档模板ID</param>
        /// <param name="templetInfo">文档模板信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetUserTempletInfo(string szTempletID, ref MDSDBLib.TempletInfo templetInfo)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetUserTempletInfo(szTempletID, ref templetInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetUserTempletInfo", new string[] { "szTempletID" }
                    , new object[] { szTempletID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定就诊，指定病人，指定类型中已有文档详细信息列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="szVisitType">就诊类型</param>
        /// <param name="dtVisitTime">就诊时间</param>
        /// <param name="szDocTypeID">文档类型代码</param>
        /// <param name="lstDocInfos">文档信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocInfos(string szPatientID, string szVisitID, string szVisitType, DateTime dtVisitTime, string szDocTypeID, ref List<MDSDBLib.MedDocInfo> lstDocInfos)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetDocInfos(szPatientID, szVisitID, szVisitType, dtVisitTime, szDocTypeID, ref lstDocInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocInfos", new string[] { "szPatientID", "szVisitID", "szVisitType", "dtVisitTime", "szDocTypeID" }
                    , new object[] { szPatientID, szVisitID, szVisitType, dtVisitTime, szDocTypeID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档ID，获取文档基本信息
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="clsDocInfo">文档信息类</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocInfo(string szDocID, ref MDSDBLib.MedDocInfo clsDocInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetDocInfo(szDocID, ref clsDocInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocInfo", new string[] { "szDocID" }
                    , new object[] { szDocID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取文档摘要信息
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="szSummary">文档摘要信息串</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocSummary(string szDocID, ref string szSummary)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetDocSummary(szDocID, ref szSummary);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocSummary", new string[] { "szDocID" }
                    , new object[] { szDocID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定就诊，指定病人，指定类型中已有文档详细信息列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="szVisitType">就诊类型</param>
        /// <param name="dtVisitTime">就诊时间</param>
        /// <param name="szDocTypeID">文档类型代码</param>
        /// <param name="lstDocInfos">文档信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetActiveDocInfo(string szPatientID, string szVisitID, string szVisitType, DateTime dtVisitTime, string szDocTypeID, ref MDSDBLib.MedDocInfo docInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetActiveDocInfo(szPatientID, szVisitID, szVisitType, dtVisitTime, szDocTypeID, ref docInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetActiveDocInfo", new string[] { "szPatientID", "szVisitID", "szVisitType", "dtVisitTime", "szDocTypeID" }
                    , new object[] { szPatientID, szVisitID, szVisitType, dtVisitTime, szDocTypeID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定文档集中最新的文档版本信息
        /// </summary>
        /// <param name="szDocSetID">文档集ID</param>
        /// <param name="docInfo">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetLatestDocID(string szDocSetID, ref MDSDBLib.MedDocInfo docInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetLatestDocID(szDocSetID, ref docInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetLatestDocID", new string[] { "szDocSetID" }, new object[] { szDocSetID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取系统自带的指定文档类型的文档模板内容
        /// </summary>
        /// <param name="szDocTypeID">文档类型代码</param>
        /// <param name="byteTempletData">模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetSystemTemplet(string szDocTypeID, ref byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetSystemTemplet(szDocTypeID, ref byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetSystemTemplet", new string[] { "szDocTypeID" }
                    , new object[] { szDocTypeID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取用户自定义的文档模板内容
        /// </summary>
        /// <param name="szTempletID">文档模板ID</param>
        /// <param name="byteTempletData">模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetUserTemplet(string szTempletID, ref byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetUserTemplet(szTempletID, ref byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetUserTemplet", new string[] { "szTempletID" }
                    , new object[] { szTempletID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存用户自定义的文档模板内容
        /// </summary>
        /// <param name="templetInfo">文档模板信息</param>
        /// <param name="byteTempletData">模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SaveUserTemplet(MDSDBLib.TempletInfo templetInfo, byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.SaveUserTemplet(templetInfo, byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveUserTemplet", new string[] { "templetInfo" }
                    , new object[] { templetInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存系统默认模板
        /// </summary>
        /// <param name="szDocTypeID">文档类型代码</param>
        /// <param name="byteTempletData">模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SaveSystemTemplet(string szDocTypeID, byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.SaveSystemTemplet(szDocTypeID, byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveSystemTemplet", new string[] { "szDocTypeID" }
                    , new object[] { szDocTypeID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定文档类型代码更新文档类型信息
        /// </summary>
        /// <param name="docTypeInfo">文档类型信息</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short ModifyDocTypeInfo(MDSDBLib.DocTypeInfo docTypeInfo)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.ModifyDocTypeInfo(docTypeInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifyDocTypeInfo", new string[] { "docTypeInfo" }
                    , new object[] { docTypeInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改用户模板共享等级
        /// </summary>
        /// <param name="szTempletID">用户模板ID</param>
        /// <param name="szShareLevel">模板新的共享级别</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifyUserTempletShareLevel(string szTempletID, string szShareLevel)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifyUserTempletShareLevel(szTempletID, szShareLevel);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifyUserTempletShareLevel", new string[] { "szTempletID", "szShareLevel" }
                    , new object[] { szTempletID, szShareLevel }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改用户模板名称
        /// </summary>
        /// <param name="szTempletID">用户模板ID</param>
        /// <param name="szTempletName">模板新的名称</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifyUserTempletName(string szTempletID, string szTempletName)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifyUserTempletName(szTempletID, szTempletName);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifyUserTempletName", new string[] { "szTempletID", "szTempletName" }
                    , new object[] { szTempletID, szTempletName }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改用户模板父目录
        /// </summary>
        /// <param name="szTempletID">用户模板ID</param>
        /// <param name="szTempletName">模板新的父目录ID</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifyUserTempletParentID(string szTempletID, string szParentID)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifyUserTempletParentID(szTempletID, szParentID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifyUserTempletParentID", new string[] { "szTempletID", "szParentID" }
                    , new object[] { szTempletID, szParentID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除指定的一个用户模板
        /// </summary>
        /// <param name="szTempletID">用户模板ID</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short DeleteUserTemplet(string szTempletID)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.DeleteUserTemplet(szTempletID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteUserTemplet", new string[] { "szTempletID" }
                    , new object[] { szTempletID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除指定的一系列用户模板
        /// </summary>
        /// <param name="lstTempletID">用户模板ID列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short DeleteUserTemplet(List<string> lstTempletID)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.DeleteUserTemplet(lstTempletID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteUserTemplet", new string[] { "lstTempletID" }
                    , new object[] { lstTempletID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档ID获取文档内容
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocByID(string szDocID, ref byte[] byteDocData)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetDocByID(szDocID, ref byteDocData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocByID", new string[] { "szDocID" }
                    , new object[] { szDocID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存新文档
        /// </summary>
        /// <param name="oDocInfo">文档信息</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SaveDoc(MDSDBLib.MedDocInfo oDocInfo, byte[] byteDocData)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.SaveDoc(oDocInfo, byteDocData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveDoc", new string[] { "oDocInfo" }
                    , new object[] { oDocInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新已有文档
        /// </summary>
        /// <param name="szOldDocID">被更新文档编号</param>
        /// <param name="oNewDocInfo">新文档信息类</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short UpdateDoc(string szOldDocID, MDSDBLib.MedDocInfo oNewDocInfo, byte[] byteDocData)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.UpdateDoc(szOldDocID, oNewDocInfo, byteDocData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.UpdateDoc", new string[] { "szOldDocID", "oNewDocInfo" }
                    , new object[] { szOldDocID, oNewDocInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改病历标题
        /// </summary>
        /// <param name="szDocID">被修改的病历编号</param>
        /// <param name="szDocTitle">新的病历标题</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifyDocTitle(string szDocID, string szDocTitle)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.ModifyDocTitle(szDocID, szDocTitle);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifyDocTitle", new string[] { "szDocID", "szDocTitle" }
                    , new object[] { szDocID, szDocTitle }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 作废已有文档
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="szModifierID">文档修改者编号</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short CancelDoc(ref MDSDBLib.DocStatusInfo docStatusInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.SetDocStatusInfo(ref docStatusInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.CancelDoc", new string[] { "docStatusInfo" }
                    , new object[] { docStatusInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定文档状态信息
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="szModifierID">文档修改者编号</param>
        /// <param name="szModifierName">文档修改者姓名</param>
        /// <param name="szDeptCode">文档修改者所在科室编号</param>
        /// <param name="szDeptName">文档修改者所在科室代码</param>
        /// <param name="szDocStatus">文档状态</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocStatusInfo(string szDocID, ref MDSDBLib.DocStatusInfo docStatusInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetDocStatusInfo(szDocID, ref docStatusInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocStatusInfo", new string[] { "szDocID" }
                    , new object[] { szDocID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 设置指定文档状态信息
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="szModifierID">文档修改者编号</param>
        /// <param name="szModifierName">文档修改者姓名</param>
        /// <param name="szDeptCode">文档修改者所在科室编号</param>
        /// <param name="szDeptName">文档修改者所在科室代码</param>
        /// <param name="szDocStatus">文档状态</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SetDocStatusInfo(ref MDSDBLib.DocStatusInfo docStatusInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.SetDocStatusInfo(ref docStatusInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SetDocStatusInfo", new string[] { "docStatusInfo" }
                    , new object[] { docStatusInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定病人指定就诊下的以往病程记录
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <param name="lstPastDocInfos">以往病程记录</param>
        /// <returns>MedDocSys.Common.CommonData.ReturnValue</returns>
        public static short GetPastDocList(string szPatientID, string szVisitID, ref List<MDSDBLib.MedDocInfo> lstPastDocInfos)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetPastDocList(szPatientID, szVisitID, ref lstPastDocInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetPastDocList", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定病人的就诊列表
        /// </summary>
        /// <param name="szPatientID">病人编号</param>
        /// <param name="lstVisitInfo">就诊信息列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetPatVisitList(string szPatientID, ref List<MDSDBLib.VisitInfo> lstVisitInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetPatVisitList(szPatientID, ref lstVisitInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetVisitList", new string[] { "szPatientID" }
                    , new object[] { szPatientID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据病人ID和就诊号，获取该次住院的检验信息列表
        /// </summary>
        /// <param name="szPatientID">病人编号</param>
        /// <param name="szVisitID">就诊号</param>
        /// <param name="lstLabTestInfo">检验信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetInpLabTestList(string szPatientID, string szVisitID, ref List<MDSDBLib.LabTestInfo> lstLabTestInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetInpLabTestList(szPatientID, szVisitID, ref lstLabTestInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetInpLabTestList", new string[] { "szPatientID", "szVisitID", }
                    , new object[] { szPatientID, szVisitID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        ///  根据病人ID和就诊时间区间，获取该次门诊的检验信息列表
        /// </summary>
        /// <param name="szPatientID">病人编号</param>
        /// <param name="dtVisitDateTime">该次就诊时间</param>
        /// <param name="dtNextVisitDateTime">下次就诊时间</param>
        /// <param name="lstLabTestInfo">检验信息列表</param>
        /// <returns>Common.CommonData.ReturnValu</returns>
        public static short GetClinicLabTestList(string szPatientID, DateTime dtVisitTime, DateTime dtNextVisitTime, ref List<MDSDBLib.LabTestInfo> lstLabTestInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetClinicLabTestList(szPatientID, dtVisitTime, dtNextVisitTime, ref lstLabTestInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetClinicLabTestList", new string[] { "szPatientID", "dtVisitDateTime", "dtNextVisitDateTime" }
                    , new object[] { szPatientID, dtVisitTime, dtNextVisitTime }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定的申请序号，获取检验结果列表
        /// </summary>
        /// <param name="szTestNo">申请序号</param>
        /// <param name="lstTestResultInfo">检验结果信息类</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetTestResultList(string szTestNo, ref List<MDSDBLib.TestResultInfo> lstTestResultInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetTestResultList(szTestNo, ref lstTestResultInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetTestResultList", new string[] { "szTestNo" }
                    , new object[] { szTestNo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定的就诊信息，获取该次就诊时，产生的处方列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="szVisitType">就诊类型</param>
        /// <param name="dtVisitTime">就诊时间</param>
        /// <param name="lstRxInfo">处方信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetClinicRxList(string szPatientID, ref List<MDSDBLib.MedRxInfo> lstRxInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetClinicRxList(szPatientID, ref lstRxInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetVisitRxList", new string[] { "szPatientID" }
                    , new object[] { szPatientID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定的病人和就诊信息，获取该次就诊时，产生的生命体征信息列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <param name="lstVitalSigns">生命体征列表信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetVitalSignsList(string szPatientID, string szVisitID, ref List<MDSDBLib.VitalSignsInfo> lstVitalSigns)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetVitalSignsList(szPatientID, szVisitID, ref lstVitalSigns);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetVitalSignsList", new string[] { "szPatientID", "szVisitID", }
                    , new object[] { szPatientID, szVisitID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定的就诊信息，获取该次就诊时，产生的医嘱数据列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="lstOrderInfo">医嘱信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetInpOrderList(string szPatientID, string szVisitID, ref List<MDSDBLib.MedOrderInfo> lstOrderInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetInpOrderList(szPatientID, szVisitID, ref lstOrderInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetVisitOrderList", new string[] { "szPatientID", "szVisitID" }
                    , new object[] { szPatientID, szVisitID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定的就诊信息，获取该次住院产生的检查数据列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="lstOrderInfo">检查信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetClinicExamList(string szPatientID, DateTime dtVisitTime, DateTime dtNextVisitTime, ref List<MDSDBLib.ExamInfo> lstExamInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetClinicExamList(szPatientID, dtVisitTime, dtNextVisitTime, ref lstExamInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetClinicExamList", new string[] { "szPatientID", "dtVisitTime", "dtNextVisitTime" }
                    , new object[] { szPatientID, dtVisitTime, dtNextVisitTime }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定的就诊信息，获取该次门诊产生的检查数据列表
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="dtVisitTime">该次就诊时间</param>
        /// <param name="dtNextDateTime">下次就诊时间</param>
        /// <param name="lstOrderInfo">检查信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetInpExamList(string szPatientID, string szVisitID, ref List<MDSDBLib.ExamInfo> lstExamInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetInpExamList(szPatientID, szVisitID, ref lstExamInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.CANCEL;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetInpExamList", new string[] { "szPatientID", "szVisitID" }
                    , new object[] { szPatientID, szVisitID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据指定的就诊信息，获取该次就诊时，产生的检查报告详细信息
        /// </summary>
        /// <param name="szExamNo">申请序号</param>
        /// <param name="examReportInfo">检查报告信息</param>
        /// <returns>MedDocSys.Common.CommonData.ReturnValue</returns>
        public static short GetExamResultInfo(string szExamNo, ref MDSDBLib.ExamResultInfo examReportInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetExamResultInfo(szExamNo, ref examReportInfo);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("MqsDbAccess.GetExamReportDetialInfo", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 从文档索引表中获取指定病人的就诊信息列表
        /// </summary>
        /// <param name="szPatientID">病人编号</param>
        /// <param name="lstVisitInfos">就诊信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetDocVisitInfoList(string szPatientID, ref List<MDSDBLib.VisitInfo> lstVisitInfos)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.GetDocVisitInfoList(szPatientID, ref lstVisitInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDocVisitInfoList", new string[] { "szPatientID" }
                    , new object[] { szPatientID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取自定义医学术语集合。<br/>
        /// 如果UserID为空,那么返回DeptCode指定的科室共享的术语<br/>
        /// 如果两者都为空,那么返回全院共享的术语
        /// </summary>
        /// <param name="szUserID">返回指定用户的术语列表</param>
        /// <param name="szDeptCode">返回指定科室共享等级的术语列表</param>
        /// <param name="lstMedTerms">医学术语信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetUserMedTerms(string szUserID, string szDeptCode, ref List<MDSDBLib.MedTermInfo> lstMedTerms)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetUserMedTerms(szUserID, szDeptCode, ref lstMedTerms);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetUserMedTerms", new string[] { "szUserID", "szDeptCode" }
                    , new object[] { szUserID, szDeptCode }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定术语的内容
        /// </summary>
        /// <param name="szTermID">术语ID</param>
        /// <param name="szTermText">术语内容</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetUserMedTermText(string szTermID, ref string szTermText)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetUserMedTermText(szTermID, ref szTermText);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetUserMedTermText", new string[] { "szTermID" }
                    , new object[] { szTermID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据术语ID删除一条术语
        /// </summary>
        /// <param name="szTermID">术语ID</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short DeleteUserMedTerm(string szTermID)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.DeleteUserMedTerm(szTermID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteUserMedTerm", new string[] { "szTermID" }
                    , new object[] { szTermID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存一条用户术语
        /// </summary>
        /// <param name="medTermInfo">术语信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SaveUserMedTerm(MDSDBLib.MedTermInfo medTermInfo)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.SaveUserMedTerm(medTermInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveUserMedTerm", new string[] { "medTermInfo" }
                    , new object[] { medTermInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新一条用户术语
        /// </summary>
        /// <param name="medTermInfo">术语信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifyUserMedTerm(MDSDBLib.MedTermInfo medTermInfo)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifyUserMedTerm(medTermInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveUserMedTerm", new string[] { "medTermInfo" }
                    , new object[] { medTermInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 指定结构化检索SQL语句,检索文档,并返回文档列表
        /// </summary>
        /// <param name="queryInfo">结构化检索条件信息</param>
        /// <param name="lstDocInfos">文档信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SearchStructDocument(MDSDBLib.StructQueryInfo queryInfo, ref List<MDSDBLib.MedDocInfo> lstDocInfos)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            //short shRet = EMRDBAccess.SearchStructDocument(queryInfo, ref lstDocInfos);
            //if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            //    return SystemData.ReturnValue.OK;
            //if (shRet != SystemData.ReturnValue.OK)
            //{
            //    LogManager.Instance.WriteLog("DataAccess.GetStructDocInfos", new string[] { "queryInfo" }
            //        , new object[] { queryInfo }, DataAccess.GetDBAccessError(shRet));
            //    return shRet;
            //}
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取文档质控规则Entry列表
        /// </summary>
        /// <param name="lstQCRules">Entry列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetQCEntryList(ref List<MDSDBLib.MedQCEntry> lstQCEntrys)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.GetQCEntryList(ref lstQCEntrys);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetQCEntryList", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取文档质控规则列表
        /// </summary>
        /// <param name="lstQCRules">规则列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetQCRuleList(ref List<MDSDBLib.MedQCRule> lstQCRules)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.GetQCRuleList(ref lstQCRules);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetQCRuleList", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存一条原子规则
        /// </summary>
        /// <param name="qcEntry"></param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SaveQCEntry(MDSDBLib.MedQCEntry qcEntry, MDSDBLib.MedQCRule qcRule)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.SaveQCEntry(qcEntry, qcRule);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveQCEntry", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存一条复合规则
        /// </summary>
        /// <param name="qcRule">规则信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SaveQCRule(MDSDBLib.MedQCRule qcRule)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.SaveQCRule(qcRule);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveQCRule", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改一条原子规则
        /// </summary>
        /// <param name="qcEntry">原子规则信息</param>
        /// <param name="qcRule">原子规则对应的规则信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifyQCEntry(MDSDBLib.MedQCEntry qcEntry, MDSDBLib.MedQCRule qcRule)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.ModifyQCEntry(qcEntry, qcRule);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifyQCEntry", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改一条复合规则
        /// </summary>
        /// <param name="qcRule">规则信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifyQCRule(MDSDBLib.MedQCRule qcRule)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.ModifyQCRule(qcRule);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifyQCRule", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条原子规则
        /// </summary>
        /// <param name="szEntryID">表QC_Entry规则ID</param>
        /// <param name="szRuleID">表QC_Rule规则ID</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short DeleteQCEntry(string szEntryID, string szRuleID)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.DeleteQCEntry(szEntryID, szRuleID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteQCEntry", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除一条复合规则
        /// </summary>
        /// <param name="szRuleID"></param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short DeleteQCRule(string szRuleID)
        {
            if (DataAccess.MedQCAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedQCAccess.DeleteQCRule(szRuleID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteQCRule", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 按文档类型获取绑定数据查询语句列表
        /// </summary>
        /// <param name="szDocTypeID">文档类型ID</param>
        /// <param name="lstStructBindConfigInfos">数据查询语句列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetElementBindConfig(string szDocTypeID, ref List<MDSDBLib.StructBindConfigInfo> lstStructBindConfigInfos)
        {
            if (DataAccess.ConfigAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = ConfigAccess.GetElementBindConfig(szDocTypeID, ref lstStructBindConfigInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetStructBindConfig", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 执行文档绑定数据查询语句
        /// </summary>
        /// <param name="szQuerySQL">文档绑定数据查询语句</param>
        /// <param name="lstAliasText">绑定数据值列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetStructBindData(string szQuerySQL, ref String[] arrBindData)
        {
            if (DataAccess.ConfigAccess == null)
                return SystemData.ReturnValue.FAILED;

            //short shRet = m_MdsDbAccess.GetStructBindData(szQuerySQL, ref arrBindData);
            //if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            //    return SystemData.ReturnValue.OK;
            //if (shRet != SystemData.ReturnValue.OK)
            //{
            //    LogManager.Instance.WriteLog("DataAccess.GetStructBindData", null, null, DataAccess.GetDBAccessError(shRet));
            //    return shRet;
            //}
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取Word格式的病历服务器的访问参数
        /// </summary>
        /// <param name="szServerIP">Word病历服务器IP地址</param>
        /// <param name="szRootPath">Word病历服务器根目录</param>
        /// <returns>MedDocSys.Common.CommonData.ReturnValue</returns>
        public static short GetMedFileSrvConfig(ref string szServerIP, ref string szRootPath)
        {
            if (DataAccess.ConfigAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = ConfigAccess.GetMedFileSrvConfig(ref szServerIP, ref szRootPath);
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetWordEmrConfig", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 将指定就诊的所有文档的状态更新为已归档状态
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊号</param>
        /// <param name="dtVisitTime">就诊时间</param>
        /// <param name="szVisitType">就诊类型</param>
        /// <param name="szOperatorID">操作者ID</param>
        /// <param name="szOperatorName">操作者姓名</param>
        /// <param name="szExceptionInfo">操作异常信息</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short ArchiveDocument(string szPatientID, string szVisitID, DateTime dtVisitTime, string szVisitType, string szOperatorID, string szOperatorName, ref string szExceptionInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.ArchiveDocument(szPatientID, szVisitID, dtVisitTime, szVisitType, szOperatorID, szOperatorName, ref szExceptionInfo);
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ArchiveDocument", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 将指定就诊的所有文档的状态更新为正常状态
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊号</param>
        /// <param name="dtVisitTime">就诊时间</param>
        /// <param name="szVisitType">就诊类型</param>
        /// <param name="szOperatorID">操作者ID</param>
        /// <param name="szOperatorName">操作者姓名</param>
        /// <param name="szExceptionInfo">操作异常信息</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short RollbackDocument(string szPatientID, string szVisitID, DateTime dtVisitTime, string szVisitType, string szOperatorID, string szOperatorName, ref string szExceptionInfo)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.RollbackDocument(szPatientID, szVisitID, dtVisitTime, szVisitType, szOperatorID, szOperatorName, ref szExceptionInfo);
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.RollbackDocument", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定的结构化小模板的内容
        /// </summary>
        /// <param name="szTempletID">模板ID</param>
        /// <param name="byteTempletData">模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetSmallTemplet(string szTempletID, ref byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetSmallTemplet(szTempletID, ref byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetUserTemplet", new string[] { "szTempletID" }
                    , new object[] { szTempletID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存结构化小模板信息及内容
        /// </summary>
        /// <param name="templetInfo">模板信息</param>
        /// <param name="byteTempletData">模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short SaveSmallTemplet(MDSDBLib.SmallTempletInfo templetInfo, byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.SaveSmallTemplet(templetInfo, byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveSmallTemplet", new string[] { "templetInfo" }
                    , new object[] { templetInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新结构化小模板信息及内容
        /// </summary>
        /// <param name="templetInfo">模板信息</param>
        /// <param name="byteTempletData">模板数据</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short UpdateSmallTemplet(MDSDBLib.SmallTempletInfo templetInfo, byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.UpdateSmallTemplet(templetInfo, byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.UpdateSmallTemplet", new string[] { "templetInfo" }
                    , new object[] { templetInfo }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改指定的结构化小模板共享等级
        /// </summary>
        /// <param name="szTempletID">用户模板ID</param>
        /// <param name="szShareLevel">模板新的共享级别</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifySmallTempletShareLevel(string szTempletID, string szShareLevel)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifySmallTempletShareLevel(szTempletID, szShareLevel);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifySmallTempletShareLevel", new string[] { "szTempletID", "szShareLevel" }
                    , new object[] { szTempletID, szShareLevel }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改指定的结构化小模板名称
        /// </summary>
        /// <param name="szTempletID">模板ID</param>
        /// <param name="szTempletName">模板新的名称</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifySmallTempletName(string szTempletID, string szTempletName)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifySmallTempletName(szTempletID, szTempletName);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifySmallTempletName", new string[] { "szTempletID", "szTempletName" }
                    , new object[] { szTempletID, szTempletName }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改指定的结构化小模板的父目录
        /// </summary>
        /// <param name="szTempletID">模板ID</param>
        /// <param name="szTempletName">模板新的父目录ID</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short ModifySmallTempletParentID(string szTempletID, string szParentID)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifySmallTempletParentID(szTempletID, szParentID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.ModifySmallTempletParentID", new string[] { "szTempletID", "szParentID" }
                    , new object[] { szTempletID, szParentID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除指定的一个结构化小模板
        /// </summary>
        /// <param name="szTempletID">小模板ID</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short DeleteSmallTemplet(string szTempletID)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.DeleteSmallTemplet(szTempletID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteSmallTemplet", new string[] { "szTempletID" }
                    , new object[] { szTempletID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 删除指定的一系列结构化小模板
        /// </summary>
        /// <param name="lstTempletID">小模板ID列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short DeleteSmallTemplet(List<string> lstTempletID)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.DeleteSmallTemplet(lstTempletID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteSmallTemplet", new string[] { "lstTempletID" }
                    , new object[] { lstTempletID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定用户ID的小模板列表
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="lstTempletInfos">小模板列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetPersonalSmallTempletInfos(string szUserID, ref List<MDSDBLib.SmallTempletInfo> lstTempletInfos)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetPersonalSmallTempletInfos(szUserID, ref lstTempletInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetPersonalSmallTempletInfos", new string[] { "szUserID" }
                    , new object[] { szUserID }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定科室的小模板列表
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="bOnlyDeptShare">是否仅返回标记为科室共享的小模板</param>
        /// <param name="lstTempletInfos">小模板列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetDeptSmallTempletInfos(string szDeptCode, bool bOnlyDeptShare, ref List<MDSDBLib.SmallTempletInfo> lstTempletInfos)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetDeptSmallTempletInfos(szDeptCode, bOnlyDeptShare, ref lstTempletInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetDeptSmallTempletInfos", new string[] { "szDeptCode", "bOnlyDeptShare" }
                    , new object[] { szDeptCode, bOnlyDeptShare }, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取全院小模板列表
        /// </summary>
        /// <param name="lstTempletInfos">小模板列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetHospitalSmallTempletInfos(ref List<MDSDBLib.SmallTempletInfo> lstTempletInfos)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetHospitalSmallTempletInfos(ref lstTempletInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetHospitalSmallTempletInfos", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取系统自带的小模板列表
        /// </summary>
        /// <param name="lstTempletInfos">小模板列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetSystemSmallTempletInfos(ref List<MDSDBLib.SmallTempletInfo> lstTempletInfos)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetSystemSmallTempletInfos(ref lstTempletInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetSystemSmallTempletInfos", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 循环指定的文档ID列表，按顺序更新这些文档记录的ORDER_VALUE字段
        /// </summary>
        /// <param name="lstDocIDList">文档ID列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short UpdateDocOrder(List<string> lstDocIDList)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = MedDocAccess.UpdateDocOrder(lstDocIDList);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.UpdateDocOrder", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取配置字典表中有关元素别名的配置列表
        /// </summary>
        /// <param name="lstConfigInfo">有关元素别名的配置列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetElementAliasList(ref List<MDSDBLib.ConfigInfo> lstConfigInfo)
        {
            if (DataAccess.ConfigAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = ConfigAccess.GetElementAliasList(ref lstConfigInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetElementAliasList", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取配置字典表中嘉和编辑器控件第一版相关配置参数
        /// </summary>
        /// <param name="szRegCode">注册码</param>
        /// <param name="szOcxTag1">编辑器标识1</param>
        /// <param name="szOcxTag2">编辑器标识2</param>
        /// <param name="szUserCode">注册用户代码</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetEPRPad2Config(ref string szRegCode, ref string szOcxTag1, ref string szOcxTag2, ref string szUserCode)
        {
            if (DataAccess.ConfigAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = ConfigAccess.GetEPRPad2Config(ref szRegCode, ref szOcxTag1, ref szOcxTag2, ref szUserCode);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetEMRPad3Config", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取配置字典表中嘉和编辑器控件第二版相关配置参数
        /// </summary>
        /// <param name="szRegCode">注册码</param>
        /// <param name="szOcxTag1">编辑器标识1</param>
        /// <param name="szOcxTag2">编辑器标识2</param>
        /// <param name="szUserCode">注册用户代码</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetEMRPad3Config(ref string szRegCode, ref string szOcxTag1, ref string szOcxTag2, ref string szUserCode)
        {
            if (DataAccess.ConfigAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = ConfigAccess.GetEMRPad3Config(ref szRegCode, ref szOcxTag1, ref szOcxTag2, ref szUserCode);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetEMRPad3Config", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 保存某个用户的常用病历文书信息
        /// </summary>
        /// <param name="szDocTypeID">用户ID</param>
        /// <param name="docTypeInfo">病历信息</param>
        /// <returns></returns>
        public static short SaveCommonUseTemplet(string szUserID, string szDocTypeID)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.SaveCommonUseTemplet(szUserID, szDocTypeID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.SaveCommonUseTemplet", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取某个用户常用的病历文书列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="lstSubDocTypeInfo">返回列表</param>
        /// <returns></returns>
        public static short GetCommonDocInfosByUserID(string szUserID, ref List<MDSDBLib.DocTypeInfo> lstSubDocTypeInfo)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.GetCommonDocInfosByUserID(szUserID, ref lstSubDocTypeInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetCommonDocInfosByUserID", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档类型ID和用户ID删除常用病历
        /// </summary>
        /// <param name="szDocTypeID">文档类型ID</param>
        /// <param name="szUserID">用户ID</param>
        /// <returns></returns>
        public static short DeleteCommonUseTempletByDocTypeID(string szDocTypeID, string szUserID)
        {
            if (DataAccess.DocTypeAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = DocTypeAccess.DeleteCommonUseTempletByDocTypeID(szDocTypeID, szUserID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.DeleteCommonUseTempletByDocTypeID", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 把xml格式的病历文本保存到XDB数据库中
        /// </summary>
        /// <param name="szDocID">旧的文档ID</param>
        /// <param name="szLocalFile">文档信息</param>
        /// <param name="szLocalFile">xml病历字符串</param>
        /// <returns></returns>
        public static short SaveToXDB(string szOldDocID, MDSDBLib.MedDocInfo szDocInfo, string szXmlData)
        {
            if (DataAccess.MedDocAccess == null)
                return SystemData.ReturnValue.FAILED;

            //short shRet = m_MdsDbAccess.SaveToXDB(szOldDocID, szDocInfo, szXmlData);
            //if (shRet != SystemData.ReturnValue.OK)
            //{
            //    LogManager.Instance.WriteLog("DataAccess.SaveToXDB", null, null, DataAccess.GetDBAccessError(shRet));
            //    return shRet;
            //}
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取指定的用户信息
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="userInfo">返回的用户信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public static short GetUserInfo(string szUserID, ref UserInfo userInfo)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            MDSDBLib.UserInfo dbUserInfo = null;
            short shRet = EMRDBAccess.GetUserInfo(szUserID, ref dbUserInfo);

            //没有查询到
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.FAILED;

            //查询出异常
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetUserInfo", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.EXCEPTION;
            }

            //转换用户信息为客户端对象
            if (dbUserInfo != null)
            {
                if (userInfo == null) userInfo = new UserInfo();
                userInfo.ID = dbUserInfo.ID;
                userInfo.Name = dbUserInfo.Name;
                userInfo.DeptCode = dbUserInfo.DeptCode;
                userInfo.DeptName = dbUserInfo.DeptName;
                userInfo.Password = dbUserInfo.Password;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 校验用户和密码,校验成功后返回用户信息
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="szUserPwd">密码</param>
        /// <returns>MedDocSys.Common.GlobalData.ReturnValue</returns>
        public static short UserVerify(string szUserID, string szUserPwd)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.VerifyUser(szUserID, szUserPwd);
            if (shRet != MDSDBLib.SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.UserVerify", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 修改用户模板审核相关信息
        /// </summary>
        /// <param name="templetInfo">用户模板信息</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short ModifyTempletCheckInfo(MDSDBLib.TempletInfo templetInfo)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.ModifyUserTempletCheckInfo(templetInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("MtsDbAccess.ModifyTempletCheckInfo", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新用户模板文件
        /// </summary>
        /// <param name="templetInfo">用户模板信息</param>
        /// <param name="byteTempletData">用户模板文件数据</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short UpdateUserTemplet(MDSDBLib.TempletInfo templetInfo, byte[] byteTempletData)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.UpdateUserTemplet(templetInfo, byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("MtsDbAccess.UpdateUserTemplet", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取临床科室信息列表
        /// </summary>
        /// <param name="lstDeptInfos">科室信息列表</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public static short GetClinicDeptList(ref List<MDSDBLib.DeptInfo> lstDeptInfos)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetClinicDeptList(ref lstDeptInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("DataAccess.GetClinicDeptList", null, null, DataAccess.GetDBAccessError(shRet));
                return shRet;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取住院科室列表
        /// </summary>
        /// <param name="lstDeptInfos">住院科室列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetWardDeptList(ref List<MDSDBLib.DeptInfo> lstDeptInfos)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetWardDeptList(ref lstDeptInfos);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("MtsDbAccess.GetInpDeptList", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取门诊科室列表
        /// </summary>
        /// <param name="lstDeptInfos">门诊科室列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetOutPDeptList(ref List<MDSDBLib.DeptInfo> lstDeptInfos)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetOutPDeptList(ref lstDeptInfos);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("MtsDbAccess.GetOutpDeptList", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取护理单元科室列表
        /// </summary>
        /// <param name="lstDeptInfos">护理单元科室列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetNurseDeptList(ref List<MDSDBLib.DeptInfo> lstDeptInfos)
        {
            if (DataAccess.EMRDBAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = EMRDBAccess.GetNurseDeptList(ref lstDeptInfos);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("MtsDbAccess.GetNurseDeptList", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取科室内指定时间段内创建的所有模板信息
        /// </summary>
        /// <param name="szDeptCode">指定科室代码</param>
        /// <param name="dtBeginTime">指定创建开始时间</param>
        /// <param name="dtEndTime">指定创建结束时间</param>
        /// <param name="lstTempletInfos">文档模板信息列表</param>
        /// <returns>CommonConst.ReturnValue</returns>
        public static short GetUserTempletInfos(string szDeptCode, DateTime dtBeginTime, DateTime dtEndTime, ref List<MDSDBLib.TempletInfo> lstTempletInfos)
        {
            if (DataAccess.TempletAccess == null)
                return SystemData.ReturnValue.FAILED;

            short shRet = TempletAccess.GetUserTempletInfos(szDeptCode, dtBeginTime, dtEndTime, ref lstTempletInfos);
            if (shRet == MDSDBLib.SystemData.ReturnValue.RES_NO_FOUND)
                return SystemData.ReturnValue.OK;
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("MtsDbAccess.GetTempletInfos", null, null, DataAccess.GetDBAccessError(shRet));
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }
    }
}