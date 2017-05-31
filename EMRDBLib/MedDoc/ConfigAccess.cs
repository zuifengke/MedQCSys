using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;
using System.Data;
using Heren.Common.Libraries.Ftp;

namespace EMRDBLib.DbAccess
{
    public class ConfigAccess : DBAccessBase
    {
        private static ConfigAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static ConfigAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ConfigAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取文档存储模式
        /// </summary>
        /// <returns></returns>
        public StorageMode GetStorageMode()
        {
            List<ConfigInfo> lstConfigInfos = null;
            short shRet = this.GetConfigData(SystemData.ConfigKey.STORAGE_MODE, SystemData.ConfigKey.STORAGE_MODE, ref lstConfigInfos);
            if (shRet == SystemData.ReturnValue.RES_NO_FOUND)
                return StorageMode.Unknown;

            if (shRet != SystemData.ReturnValue.OK || lstConfigInfos == null || lstConfigInfos.Count <= 0)
                return StorageMode.Unknown;

            ConfigInfo configInfo = lstConfigInfos[0];
            if (GlobalMethods.Misc.IsEmptyString(configInfo.ConfigValue))
                return StorageMode.Unknown;

            configInfo.ConfigValue = configInfo.ConfigValue.Trim().ToUpper();
            return (configInfo.ConfigValue == SystemData.ConfigKey.STORAGE_MODE_FTP) ? StorageMode.FTP : StorageMode.DB;
        }

        /// <summary>
        /// 判断QC是否能保存病历
        /// </summary>
        /// <returns></returns>
        public bool CheckQCCanSaveDoc()
        {
            List<ConfigInfo> lstConfigInfos = null;
            short shRet = this.GetConfigData(SystemData.ConfigKey.SYSTEM_OPTION, SystemData.ConfigKey.QC_SAVE_DOC_ENABLE, ref lstConfigInfos);
            if (lstConfigInfos != null && lstConfigInfos.Count > 0)
            {
                return lstConfigInfos[0].ConfigValue == "1";
            }
            return false;
        }

        /// <summary>
        /// 获取配置字典表中FTP服务器的访问参数
        /// </summary>
        /// <param name="ftpConfig">IP地址</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocFtpParams(ref FtpConfig ftpConfig)
        {
            List<ConfigInfo> lstConfigInfos = null;
            short shRet = this.GetConfigData(SystemData.ConfigKey.DOC_FTP, null, ref lstConfigInfos);

            ftpConfig = new FtpConfig();
            if (lstConfigInfos == null || lstConfigInfos.Count <= 0)
                return shRet;

            for (int index = 0; index < lstConfigInfos.Count; index++)
            {
                ConfigInfo configInfo = lstConfigInfos[index];
                if (GlobalMethods.Misc.IsEmptyString(configInfo.ConfigName))
                    continue;

                if (GlobalMethods.Misc.IsEmptyString(configInfo.ConfigValue))
                    configInfo.ConfigValue = string.Empty;

                configInfo.ConfigName = configInfo.ConfigName.Trim().ToUpper();

                if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_IP))
                {
                    ftpConfig.FtpIP = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_PORT))
                {
                    int nPort = 0;
                    if (int.TryParse(configInfo.ConfigValue, out nPort))
                        ftpConfig.FtpPort = nPort;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_USER))
                {
                    ftpConfig.FtpUser = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_PWD))
                {
                    ftpConfig.FtpPwd = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_MODE))
                {
                    if (configInfo.ConfigValue == "1")
                        ftpConfig.FtpMode = FtpMode.PORT;
                }
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 获取配置字典表中FTP服务器的访问参数
        /// </summary>
        /// <param name="ftpConfig">IP地址</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetRecPaperFtpParams(ref FtpConfig ftpConfig)
        {
            List<ConfigInfo> lstConfigInfos = null;
            short shRet = this.GetConfigData(SystemData.ConfigKey.RECPAPER_FTP, null, ref lstConfigInfos);

            ftpConfig = new FtpConfig();
            if (lstConfigInfos == null || lstConfigInfos.Count <= 0)
                return shRet;

            for (int index = 0; index < lstConfigInfos.Count; index++)
            {
                ConfigInfo configInfo = lstConfigInfos[index];
                if (GlobalMethods.Misc.IsEmptyString(configInfo.ConfigName))
                    continue;

                if (GlobalMethods.Misc.IsEmptyString(configInfo.ConfigValue))
                    configInfo.ConfigValue = string.Empty;

                configInfo.ConfigName = configInfo.ConfigName.Trim().ToUpper();

                if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_IP))
                {
                    ftpConfig.FtpIP = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_PORT))
                {
                    int nPort = 0;
                    if (int.TryParse(configInfo.ConfigValue, out nPort))
                        ftpConfig.FtpPort = nPort;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_USER))
                {
                    ftpConfig.FtpUser = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_PWD))
                {
                    ftpConfig.FtpPwd = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_MODE))
                {
                    if (configInfo.ConfigValue == "1")
                        ftpConfig.FtpMode = FtpMode.PORT;
                }
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取配置字典表中XDB FTP服务器的访问参数
        /// </summary>
        /// <param name="ftpConfig">IP地址</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetXDBFtpParams(ref FtpConfig ftpConfig)
        {
            List<ConfigInfo> lstConfigInfos = null;
            short shRet = this.GetConfigData(SystemData.ConfigKey.XML_DB, null, ref lstConfigInfos);

            ftpConfig = new FtpConfig();
            if (lstConfigInfos == null || lstConfigInfos.Count <= 0)
                return shRet;

            for (int index = 0; index < lstConfigInfos.Count; index++)
            {
                ConfigInfo configInfo = lstConfigInfos[index];
                if (GlobalMethods.Misc.IsEmptyString(configInfo.ConfigName))
                    continue;

                if (GlobalMethods.Misc.IsEmptyString(configInfo.ConfigValue))
                    configInfo.ConfigValue = string.Empty;

                configInfo.ConfigName = configInfo.ConfigName.Trim().ToUpper();

                if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_IP))
                {
                    ftpConfig.FtpIP = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_PORT))
                {
                    int nPort = 0;
                    if (int.TryParse(configInfo.ConfigValue, out nPort))
                        ftpConfig.FtpPort = nPort;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_USER))
                {
                    ftpConfig.FtpUser = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_PWD))
                {
                    ftpConfig.FtpPwd = configInfo.ConfigValue;
                }
                else if (configInfo.ConfigName.Equals(SystemData.ConfigKey.FTP_MODE))
                {
                    if (configInfo.ConfigValue == "1")
                        ftpConfig.FtpMode = FtpMode.PORT;
                }
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 查询配置字典表获取指定的配置数据
        /// </summary>
        /// <param name="szGroupName">配置组名称</param>
        /// <param name="szConfigName">配置项名称(为空时返回该组所有配置项)</param>
        /// <param name="lstConfigInfos">返回的配置项及其配置数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetConfigData(string szGroupName, string szConfigName, ref List<ConfigInfo> lstConfigInfos)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3}"
                , SystemData.ConfigDictTable.GROUP_NAME, SystemData.ConfigDictTable.CONFIG_NAME
                , SystemData.ConfigDictTable.CONFIG_VALUE, SystemData.ConfigDictTable.CONFIG_DESC);

            string szCondition = null;
            if (!GlobalMethods.Misc.IsEmptyString(szGroupName))
            {
                szCondition = string.Format("{0}='{1}'", SystemData.ConfigDictTable.GROUP_NAME, szGroupName);
                if (!GlobalMethods.Misc.IsEmptyString(szConfigName))
                {
                    szCondition = string.Format("{0} AND {1}='{2}'", szCondition
                        , SystemData.ConfigDictTable.CONFIG_NAME, szConfigName);
                }
            }

            string szOrder = string.Format("{0},{1}"
                , SystemData.ConfigDictTable.GROUP_NAME, SystemData.ConfigDictTable.CONFIG_NAME);

            string szSQL = null;
            if (string.IsNullOrEmpty(szCondition))
            {
                szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC
                    , szField, SystemData.DataTable.CONFIG_DICT, szOrder);
            }
            else
            {
                szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , szField, SystemData.DataTable.CONFIG_DICT, szCondition, szOrder);
            }

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstConfigInfos == null)
                    lstConfigInfos = new List<ConfigInfo>();
                do
                {
                    ConfigInfo configInfo = new ConfigInfo();
                    configInfo.GroupName = dataReader.GetString(0);
                    configInfo.ConfigName = dataReader.GetString(1);
                    configInfo.ConfigValue = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3))
                        configInfo.ConfigDesc = dataReader.GetString(3);
                    lstConfigInfos.Add(configInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.GetConfigData", new string[] { "szGroupName", "szConfigName", "SQL" }
                        , new object[] { szGroupName, szConfigName, szSQL }, "没有查询到记录!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 查询配置字典表获取指定的配置数据
        /// </summary>
        /// <param name="configInfo">返回的配置项及其配置数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateConfigData(ConfigInfo configInfo)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (configInfo == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(configInfo.ConfigName) || string.IsNullOrEmpty(configInfo.GroupName))
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(configInfo.ConfigValue) || string.IsNullOrEmpty(configInfo.ConfigDesc))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("{0}='{1}',{2}='{3}'"
                , SystemData.ConfigDictTable.CONFIG_VALUE, configInfo.ConfigValue,
                SystemData.ConfigDictTable.CONFIG_DESC, configInfo.ConfigDesc);

            string szCondition = null;

            szCondition = string.Format("{0}='{1}'", SystemData.ConfigDictTable.GROUP_NAME, configInfo.GroupName);
            szCondition = string.Format("{0} AND {1}='{2}'", szCondition, SystemData.ConfigDictTable.CONFIG_NAME, configInfo.ConfigName);

            string szSQL = null;
            szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.CONFIG_DICT, szField, szCondition);
            try
            {
                int i = base.DataAccess.ExecuteNonQuery(szSQL, CommandType.Text);
                if (i <= 0)
                {
                    return SystemData.ReturnValue.FAILED;
                }

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateConfigData", new string[] { "configInfo", "SQL" }
                        , new object[] { configInfo, szSQL }, "没有查询到记录!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 查询配置字典表获取指定的配置数据
        /// </summary>
        /// <param name="configInfo">返回的配置项及其配置数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short AddConfigData(ConfigInfo configInfo)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (configInfo == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(configInfo.ConfigName) || string.IsNullOrEmpty(configInfo.GroupName))
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(configInfo.ConfigValue) || string.IsNullOrEmpty(configInfo.ConfigDesc))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("{0},{1},{2},{3}"
                  , SystemData.ConfigDictTable.GROUP_NAME , SystemData.ConfigDictTable.CONFIG_NAME
                , SystemData.ConfigDictTable.CONFIG_VALUE, SystemData.ConfigDictTable.CONFIG_DESC);

            string szValue = string.Format("'{0}','{1}','{2}','{3}'"
                  , configInfo.GroupName, configInfo.ConfigName
                , configInfo.ConfigValue, configInfo.ConfigDesc);
            
            string szSQL = null;
            szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.CONFIG_DICT, szField, szValue);
            try
            {
                int i = base.DataAccess.ExecuteNonQuery(szSQL, CommandType.Text);
                if (i <= 0)
                {
                    return SystemData.ReturnValue.FAILED;
                }

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConfigAccess.UpdateConfigData", new string[] { "configInfo", "SQL" }
                        , new object[] { configInfo, szSQL }, "没有查询到记录!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
    }
}
