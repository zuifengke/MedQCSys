using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 系统配置信息类
    /// </summary>
    [System.Serializable]
    public class ConfigInfo : DbTypeBase, ICloneable
    {
        private string m_szGroupName = string.Empty;
        /// <summary>
        /// 获取或设置配置组的名称
        /// </summary>
        public string GroupName
        {
            get { return this.m_szGroupName; }
            set { this.m_szGroupName = value; }
        }

        private string m_szConfigName = string.Empty;
        /// <summary>
        /// 获取或设置配置项的名称
        /// </summary>
        public string ConfigName
        {
            get { return this.m_szConfigName; }
            set { this.m_szConfigName = value; }
        }

        private string m_szConfigValue = string.Empty;
        /// <summary>
        /// 获取或设置配置项的值
        /// </summary>
        public string ConfigValue
        {
            get { return this.m_szConfigValue; }
            set { this.m_szConfigValue = value; }
        }

        private string m_szConfigDesc = string.Empty;
        /// <summary>
        /// 获取或设置配置项的描述
        /// </summary>
        public string ConfigDesc
        {
            get { return this.m_szConfigDesc; }
            set { this.m_szConfigDesc = value; }
        }

        public object Clone()
        {
            ConfigInfo configInfo = new ConfigInfo();
            configInfo.GroupName = this.m_szGroupName;
            configInfo.ConfigName = this.m_szConfigName;
            configInfo.ConfigValue = this.m_szConfigValue;
            configInfo.ConfigDesc = this.m_szConfigDesc;
            return configInfo;
        }
    }

}
