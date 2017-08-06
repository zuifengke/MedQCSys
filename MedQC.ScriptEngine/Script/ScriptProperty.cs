using System;
using System.Collections.Generic;
using System.Text;

namespace Heren.MedQC.ScriptEngine.Script
{
    public enum ScriptLanguage
    {
        VBNET,
        CSharp
    }

    public class ScriptProperty : ICloneable
    {
        private string m_szScriptName = null;
        /// <summary>
        /// 获取或设置脚本名称
        /// </summary>
        public string ScriptName
        {
            get { return this.m_szScriptName; }
            set { this.m_szScriptName = value; }
        }

        private string m_szScriptText = null;
        /// <summary>
        /// 获取或设置脚本代码
        /// </summary>
        public string ScriptText
        {
            get { return this.m_szScriptText; }
            set { this.m_szScriptText = value; }
        }

        private ScriptLanguage m_scriptLang = ScriptLanguage.VBNET;
        /// <summary>
        /// 获取或设置脚本语言
        /// </summary>
        public ScriptLanguage ScriptLang
        {
            get { return this.m_scriptLang; }
            set { this.m_scriptLang = value; }
        }

        private string m_szFilePath = null;
        /// <summary>
        /// 获取或设置脚本文件路径
        /// </summary>
        public string FilePath
        {
            get { return this.m_szFilePath; }
            set
            {
                this.m_szFilePath = value;
                this.UpdateScriptLanguage(this.m_szFilePath);
            }
        }

        private byte[] m_byteScriptData = null;
        /// <summary>
        /// 获取或设置脚本可执行文件数据
        /// </summary>
        public byte[] ScriptData
        {
            get { return this.m_byteScriptData; }
            set { this.m_byteScriptData = value; }
        }

        public ScriptProperty()
        {
        }

        public ScriptProperty(string name, string text, string file)
        {
            this.m_szScriptName = name;
            this.m_szScriptText = text;
            this.m_szFilePath = file;
        }

        public object Clone()
        {
            ScriptProperty scriptProperty = new ScriptProperty();
            scriptProperty.FilePath = this.m_szFilePath;
            scriptProperty.ScriptLang = this.m_scriptLang;
            scriptProperty.ScriptName = this.m_szScriptName;
            scriptProperty.ScriptText = this.m_szScriptText;
            scriptProperty.ScriptData = this.m_byteScriptData;
            return scriptProperty;
        }

        public void UpdateScriptLanguage(string szFileName)
        {
            this.m_scriptLang = ScriptLanguage.VBNET;
            if (this.m_szFilePath != null && this.m_szFilePath.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                this.m_scriptLang = ScriptLanguage.CSharp;
        }
    }
}
