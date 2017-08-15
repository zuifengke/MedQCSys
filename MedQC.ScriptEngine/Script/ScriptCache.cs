/********************************************************
 * @FileName   : ScriptCache.cs
 * @Description: 病历文书系统之自动计算插件脚本缓存处理
 * @Author     : 杨明坤(YangMingkun)
 * @Date       : 2015-12-29 12:56:30
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using System;
using System.Text;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using Heren.Common.Libraries;
using Heren.MedQC.ScriptEngine.Script;
using Heren.MedQC.Core;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace Heren.MedQC.ScriptEngine.Script
{
    public class ScriptCache
    {
        private static ScriptCache m_instance = null;
        /// <summary>
        /// 获取TempletCache实例
        /// </summary>
        public static ScriptCache Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new ScriptCache();
                return m_instance;
            }
        }
        private ScriptCache()
        {
        }

        /// <summary>
        /// 存储脚本Dll的实例化对象
        /// </summary>
        private Hashtable m_htScriptInstance = null;
        /// <summary>
        /// 脚本Dll本地缓存索引文件路径
        /// </summary>
        private string m_cacheIndexFile = null;

        private List<ScriptConfig> m_scriptInfoList = null;
        /// <summary>
        /// 获取所有脚本配置信息
        /// </summary>
        private List<ScriptConfig> ScriptInfoList
        {
            get
            {
                if (this.m_scriptInfoList == null)
                    ScriptConfigAccess.Instance.GetScriptConfigs(ref this.m_scriptInfoList);
                if (this.m_scriptInfoList == null)
                    this.m_scriptInfoList = new List<ScriptConfig>();
                return this.m_scriptInfoList;
            }
        }

        /// <summary>
        /// 关联元素自动计算必须调用此方法
        /// </summary>
        public void Initialize()
        {
            this.LoadScriptData();
        }

        public void Dispose()
        {
            if (this.m_scriptInfoList != null)
            {
                this.m_scriptInfoList.Clear();
                this.m_scriptInfoList = null;
            }
            if (this.m_htScriptInstance != null)
            {
                this.m_htScriptInstance.Clear();
                this.m_htScriptInstance = null;
            }
        }

        /// <summary>
        /// 获取指定病历类型的所有脚本DLL实例化对象
        /// </summary>
        /// <param name="szExecuteTime">执行时机</param>
        /// <param name="szDocTypeID">病历类型</param>
        /// <param name="elementCalculators">实例化对象列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetScriptInstances(string szDocTypeID
            , ref List<IElementCalculator> elementCalculators)
        {
            if (this.ScriptInfoList == null)
                return SystemData.ReturnValue.FAILED;

            if (elementCalculators == null)
                elementCalculators = new List<IElementCalculator>();

            short result = SystemData.ReturnValue.OK;
            for (int index = 0; index < this.ScriptInfoList.Count; index++)
            {
                ScriptConfig scriptInfo = this.ScriptInfoList[index];
                if (scriptInfo == null)
                    continue;

             
                bool docTypeMatched = scriptInfo.SCRIPT_ID == szDocTypeID;
                if (string.IsNullOrEmpty(scriptInfo.SCRIPT_ID))
                    docTypeMatched = true;
                if ( docTypeMatched)
                {
                    List<IElementCalculator> elementCalculatorList = null;
                    result = this.GetScriptInstance(scriptInfo, ref elementCalculatorList);
                    if (elementCalculatorList != null && elementCalculatorList.Count > 0)
                        elementCalculators.AddRange(elementCalculatorList);
                }
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 初始化加载工作
        /// </summary>
        private void LoadScriptData()
        {
            if (this.ScriptInfoList == null || this.ScriptInfoList.Count == 0)
                return;
            for (int index = 0; index < this.ScriptInfoList.Count; index++)
            {
                ScriptConfig scriptInfo = this.ScriptInfoList[index];
                this.DownLoadScript(scriptInfo);
            }
        }

        /// <summary>
        /// 获取指定脚本ID的实例化对象
        /// </summary>
        /// <param name="szSCRIPT_ID">脚本配置信息</param>
        /// <param name="elementCalculators">实例化对象</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short GetScriptInstance(ScriptConfig scriptInfo, ref List<IElementCalculator> elementCalculators)
        {
            if (scriptInfo == null)
                return SystemData.ReturnValue.FAILED;
            if (GlobalMethods.Misc.IsEmptyString(scriptInfo.SCRIPT_ID))
                return SystemData.ReturnValue.FAILED;
            if (this.m_htScriptInstance == null)
                this.m_htScriptInstance = new Hashtable();

            if (this.m_htScriptInstance.Contains(scriptInfo.SCRIPT_ID))
            {
                elementCalculators = this.m_htScriptInstance[scriptInfo.SCRIPT_ID] as List<IElementCalculator>;
                return SystemData.ReturnValue.OK;
            }

            short result = SystemData.ReturnValue.OK;
            if (!this.CheckDllIsNewest(scriptInfo))
            {
                result = this.DownLoadScript(scriptInfo);
                if (result != SystemData.ReturnValue.OK)
                    return SystemData.ReturnValue.FAILED;
            }

            string fileName = this.GetScriptCachePath(scriptInfo.SCRIPT_ID);
            elementCalculators = AssemblyHelper.Instance.GetElementCalculator(fileName);
            if (elementCalculators == null || elementCalculators.Count <= 0)
                return SystemData.ReturnValue.FAILED;
            if (!this.m_htScriptInstance.Contains(scriptInfo.SCRIPT_ID))
                this.m_htScriptInstance.Add(scriptInfo.SCRIPT_ID, elementCalculators);
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取本地脚本DLL配置xml全文件路径
        /// </summary>
        /// <returns></returns>
        private string GetDllCacheIndexFilePath()
        {
            if (GlobalMethods.Misc.IsEmptyString(this.m_cacheIndexFile))
            {
                this.m_cacheIndexFile = GlobalMethods.Misc.GetWorkingPath()
                    + @"\Addins\AutoCalc\Script\Caches\ScriptConfig.xml";
            }
            return this.m_cacheIndexFile;
        }

        /// <summary>
        /// 获取脚本DLL本地缓存全文件路径
        /// </summary>
        /// <param name="SCRIPT_ID">脚本ID</param>
        /// <returns>脚本DLL本地缓存全文件路径</returns>
        private string GetScriptCachePath(string SCRIPT_ID)
        {
            return string.Format(@"{0}\Addins\AutoCalc\Script\Caches\Dll\Calc.{1}.dll"
                , GlobalMethods.Misc.GetWorkingPath(), SCRIPT_ID);
        }

        /// <summary>
        /// 检测本地Dll文件是不是最新版本
        /// </summary>
        /// <param name="scriptInfo">脚本配置信息</param>
        /// <returns>true/false</returns>
        private bool CheckDllIsNewest(ScriptConfig scriptInfo)
        {
            if (scriptInfo == null)
                return false;

            //1 加载本地的配置文件
            string szConfigFile = this.GetDllCacheIndexFilePath();
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(szConfigFile);

            //2 配置文件不存在，则说明本地没有任何DLL，故直接下载
            if (xmlDoc == null)
                return false;

            //3 本地有配置文件，但不存在当前指定的DLL，故直接下载
            string szXPath = string.Format("/ScriptConfig/Dll[@Name=\"{0}\"]", scriptInfo.SCRIPT_ID);
            XmlNode dllNode = GlobalMethods.Xml.SelectXmlNode(xmlDoc, szXPath);
            if (dllNode == null)
                return false;

            //4 本地有配置文件，且存在当前指定的脚本，则进行更新日期的比较
            string szUpdateTime = null;
            if (!GlobalMethods.Xml.GetXmlNodeValue(dllNode, "./@UpdateTime", ref szUpdateTime))
            {
                LogManager.Instance.WriteLog("ScriptCache.CheckDllIsNewest", "读取本地配置文件失败！");
                return false;
            }

            //5 本地有配置文件，且存在当前指定的脚本，但更新日期不一致，则重新下载
            DateTime dtUpdateTime = DateTime.Now;
            GlobalMethods.Convert.StringToDate(szUpdateTime, ref dtUpdateTime);
            return GlobalMethods.SysTime.CompareTime(scriptInfo.MODIFY_TIME, dtUpdateTime);
        }

        /// <summary>
        /// 下载指定配置信息的脚本Dll
        /// </summary>
        /// <param name="scriptInfo">配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DownLoadScript(ScriptConfig scriptInfo)
        {
            if (scriptInfo == null)
                return SystemData.ReturnValue.FAILED;
            byte[] byteScriptData = null;
            short result =ScriptDataAccess.Instance.GetScriptData(scriptInfo.SCRIPT_ID, ref byteScriptData);
            if (result != SystemData.ReturnValue.OK)
                return SystemData.ReturnValue.FAILED;

            result = this.SaveScriptConfig(scriptInfo);
            if (result != SystemData.ReturnValue.OK)
                return SystemData.ReturnValue.FAILED;
            string fileName = this.GetScriptCachePath(scriptInfo.SCRIPT_ID);
            return GlobalMethods.IO.WriteFileBytes(fileName, byteScriptData) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        }

        /// <summary>
        /// 保存脚本配置信息到本地XML文件
        /// </summary>
        /// <param name="scriptInfo">脚本配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short SaveScriptConfig(ScriptConfig scriptInfo)
        {
            if (scriptInfo == null)
                return SystemData.ReturnValue.FAILED;
            string szConfigXml = this.GetDllCacheIndexFilePath();
            if (GlobalMethods.Misc.IsEmptyString(szConfigXml))
            {
                LogManager.Instance.WriteLog("ScriptCache.SaveScriptConfig", "文件名称为空！");
                return SystemData.ReturnValue.FAILED;
            }

            //1 读取XML文件，若为空，则创建
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(szConfigXml);
            if (xmlDoc == null)
                xmlDoc = GlobalMethods.Xml.CreateXmlDocument("ScriptConfig");
            if (xmlDoc == null)
                return SystemData.ReturnValue.FAILED;

            //2 读取指定节点，若为空，则创建
            string szDllXPath = string.Format("/ScriptConfig/Dll[@Name=\"{0}\"]", scriptInfo.SCRIPT_ID);
            XmlNode node = GlobalMethods.Xml.SelectXmlNode(xmlDoc, szDllXPath);
            if (node == null)
            {
                node = GlobalMethods.Xml.CreateXmlNode(xmlDoc, null, "Dll", null);
            }
            if (node == null)
                return SystemData.ReturnValue.FAILED;

            //3 设置属性值
            if (!GlobalMethods.Xml.SetXmlAttrValue(node, "Name", scriptInfo.SCRIPT_ID))
                return SystemData.ReturnValue.FAILED;
            string szUpdateTime = scriptInfo.MODIFY_TIME.ToString();
            if (!GlobalMethods.Xml.SetXmlAttrValue(node, "UpdateTime", szUpdateTime))
                return SystemData.ReturnValue.FAILED;

            //4 保存
            bool isSuccess = GlobalMethods.Xml.SaveXmlDocument(xmlDoc, szConfigXml);
            return isSuccess ? SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        }
    }
}
