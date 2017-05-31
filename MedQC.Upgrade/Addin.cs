using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Heren.MedQC.Upgrade
{
    public class Addin
    {
        private string m_name = null;
        /// <summary>
        /// 获取或设置插件识别名称
        /// </summary>
        public string Name
        {
            get { return this.m_name; }
            set { this.m_name = value; }
        }

        private string m_text = null;
        /// <summary>
        /// 获取或设置插件显示文本
        /// </summary>
        public string Text
        {
            get { return this.m_text; }
            set { this.m_text = value; }
        }

        private string m_keys = null;
        /// <summary>
        /// 获取或设置插件快捷键
        /// </summary>
        public string Keys
        {
            get { return this.m_keys; }
            set { this.m_keys = value; }
        }

        private string m_size = null;
        /// <summary>
        /// 获取或设置工具按钮大小
        /// </summary>
        public string Size
        {
            get { return this.m_size; }
            set { this.m_size = value; }
        }

        private string m_icon = null;
        /// <summary>
        /// 获取或设置插件显示图标
        /// </summary>
        public string Icon
        {
            get { return this.m_icon; }
            set { this.m_icon = value; }
        }

        private bool m_iconAboveText = false;
        /// <summary>
        /// 获取或设置插件图标文本关系
        /// </summary>
        public bool IconAboveText
        {
            get { return this.m_iconAboveText; }
            set { this.m_iconAboveText = value; }
        }

        private bool m_enabled = true;
        /// <summary>
        /// 获取或设置插件是否可用
        /// </summary>
        public bool Enabled
        {
            get { return this.m_enabled; }
            set { this.m_enabled = value; }
        }

        private bool m_visible = true;
        /// <summary>
        /// 获取或设置插件是否可见
        /// </summary>
        public bool Visible
        {
            get { return this.m_visible; }
            set { this.m_visible = value; }
        }

        private string m_type = null;
        /// <summary>
        /// 获取或设置插件控件类型
        /// </summary>
        public string Type
        {
            get { return this.m_type; }
            set { this.m_type = value; }
        }

        private string m_toolTip = null;
        /// <summary>
        /// 获取或设置插件工具提示
        /// </summary>
        public string ToolTip
        {
            get { return this.m_toolTip; }
            set { this.m_toolTip = value; }
        }

        private string m_assembly = null;
        /// <summary>
        /// 获取或设置插件关联的程序集全名
        /// </summary>
        public string Assembly
        {
            get { return this.m_assembly; }
            set { this.m_assembly = value; }
        }

        private string m_class = null;
        /// <summary>
        /// 获取或设置插件关联的实体类全名
        /// </summary>
        public string Class
        {
            get { return this.m_class; }
            set { this.m_class = value; }
        }

        private bool m_breakOnFailed = false;
        /// <summary>
        /// 获取或设置当执行失败时,是否中断后续同级插件
        /// </summary>
        public bool BreakOnFailed
        {
            get { return this.m_breakOnFailed; }
            set { this.m_breakOnFailed = value; }
        }

        private bool m_breakOnSuccess = false;
        /// <summary>
        /// 获取或设置当执行成功后,是否中断后续同级插件
        /// </summary>
        public bool BreakOnSuccess
        {
            get { return this.m_breakOnSuccess; }
            set { this.m_breakOnSuccess = value; }
        }

        private Dictionary<string, string> m_attributes = null;
        public Addin()
        {
            this.m_attributes = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Name))
                return this.Name;
            if (!string.IsNullOrEmpty(this.Text))
                return this.Text;
            if (!string.IsNullOrEmpty(this.Class))
                return this.Class;
            return base.ToString();
        }

        /// <summary>
        /// 添加属性到插件的属性字典
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性字典</param>
        public bool AppendAttribute(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            if (!this.m_attributes.ContainsKey(name))
                this.m_attributes.Add(name, value);
            return true;
        }

        /// <summary>
        /// 获取指定名称的字符串属性值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串属性值</returns>
        public string GetAttributeValue(string name, string defaultValue)
        {
            if (this.m_attributes.ContainsKey(name))
                return this.m_attributes[name];
            return defaultValue;
        }

        /// <summary>
        /// 获取指定名称的字符串属性值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>整数属性值</returns>
        public int GetAttributeValue(string name, int defaultValue)
        {
            string value = this.GetAttributeValue(name, null);
            return GlobalMethods.Convert.StringToValue(value, defaultValue);
        }

        /// <summary>
        /// 获取指定名称的字符串属性值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>布尔属性值</returns>
        public bool GetAttributeValue(string name, bool defaultValue)
        {
            string value = this.GetAttributeValue(name, null);
            return GlobalMethods.Convert.StringToValue(value, defaultValue);
        }

        /// <summary>
        /// 根据插件配置XML节点创建插件
        /// </summary>
        /// <param name="node">XML节点</param>
        /// <returns>插件对象</returns>
        public static Addin Create(XmlNode node)
        {
            Addin addin = new Addin();
            Type type = addin.GetType();
            foreach (XmlAttribute nodeAttribute in node.Attributes)
            {
                string name = nodeAttribute.Name;
                string value = nodeAttribute.Value;
                if (!addin.AppendAttribute(name, value))
                    continue;

                PropertyInfo property = GlobalMethods.Reflect.GetPropertyInfo(type, name);
                if (property != null)
                    GlobalMethods.Reflect.SetPropertyValue(addin, property, value);
            }
            return addin;
        }

    }
}
