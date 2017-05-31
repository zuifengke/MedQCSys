
using EMRDBLib;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Heren.MedQC.Core
{
    public class CommandHandler
    {
        private static CommandHandler m_instance = null;
        /// <summary>
        /// 获取命令处理器实例
        /// </summary>
        public static CommandHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new CommandHandler();
                return m_instance;
            }
        }

        private Dictionary<string, Dictionary<ICommand, int>> m_commands = null;

        public Dictionary<string, Dictionary<ICommand, int>> Commands
        {
            get { return this.m_commands; }
        }
        public void Initialize()
        {
            this.ReadAutoCommands();
        }
        /// <summary>
        /// 读取插件命令，每新建一个插件需要在此处注册下
        /// </summary>
        private void ReadAutoCommands()
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(@"MedQC.CheckPoint.exe");
                if (assembly == null)
                    return;
                Type[] types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.Hdp.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.HomePage.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.Search.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.Statistic.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.Frame.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"mrqc.exe");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.Maintenance.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.Systems.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.MedRecord.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"Designers.exe");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
                assembly = Assembly.LoadFrom(@"MedQC.ScreenSnap.dll");
                if (assembly == null)
                    return;
                types = assembly.GetExportedTypes();
                foreach (var item in types)
                {
                    this.RegisterCommand(item);
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("命令初始化出错", ex);
            }

        }

        public bool RegisterCommand(Type commandType)
        {
            object instance = null;
            try
            {
                instance = Activator.CreateInstance(commandType);
            }
            catch { return false; }
            return this.RegisterCommand(instance as ICommand);
        }

        public bool RegisterCommand(ICommand command)
        {
            if (command == null)
                return false;
            if (string.IsNullOrEmpty(command.Name) || command == null)
                return false;
            if (this.m_commands == null)
                this.m_commands = new Dictionary<string, Dictionary<ICommand, int>>();
            if (!this.m_commands.ContainsKey(command.Name))
                this.m_commands[command.Name] = new Dictionary<ICommand, int>();
            this.m_commands[command.Name].Add(command, 1);
            return true;
        }

        public bool SendCommand(string commandName, object param, object data, out object result)
        {
            result = null;
            if (string.IsNullOrEmpty(commandName) || this.m_commands == null)
                return false;
            if (!this.m_commands.ContainsKey(commandName))
                return false;
            Dictionary<ICommand, int> commands = this.m_commands[commandName];
            if (commands != null && commands.Count > 0)
            {
                if (commands.Count > 1)
                {
                    List<KeyValuePair<ICommand, int>> lst = new List<KeyValuePair<ICommand, int>>(commands);
                    lst.Sort(delegate (KeyValuePair<ICommand, int> s1, KeyValuePair<ICommand, int> s2)
                    {
                        return s2.Value.CompareTo(s1.Value);
                    });
                    foreach (KeyValuePair<ICommand, int> kvp in lst)
                    {
                        ICommand command = kvp.Key;
                        if (!command.Execute(param, data, out result))
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    foreach (ICommand command in commands.Keys)
                    {
                        if (!command.Execute(param, data, out result)) return false;
                    }
                }
            }
            return true;
        }

        public bool SendCommand(string commandName, object param, object data)
        {
            if (string.IsNullOrEmpty(commandName) || this.m_commands == null)
                return false;
            if (!this.m_commands.ContainsKey(commandName))
                return false;
            Dictionary<ICommand, int> commands = this.m_commands[commandName];
            if (commands != null && commands.Count > 0)
            {
                if (commands.Count > 1)
                {
                    List<KeyValuePair<ICommand, int>> lst = new List<KeyValuePair<ICommand, int>>(commands);
                    lst.Sort(delegate (KeyValuePair<ICommand, int> s1, KeyValuePair<ICommand, int> s2)
                    {
                        return s2.Value.CompareTo(s1.Value);
                    });
                    foreach (KeyValuePair<ICommand, int> kvp in lst)
                    {
                        ICommand command = kvp.Key;
                        if (!command.Execute(param, data))
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    foreach (ICommand command in commands.Keys)
                    {
                        if (!command.Execute(param, data)) return false;
                    }
                }
            }
            return true;
        }
    }
}
