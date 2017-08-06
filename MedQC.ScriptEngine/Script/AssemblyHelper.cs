// ***********************************************************
// 电子病历系统关联元素自动计算脚本输出程序集辅助类.
// 主要负责从程序集中解析出继承于元素计算器接口的对象
// Creator: YangMingkun Date:2011-11-10
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Heren.Common.Libraries;

namespace Heren.MedQC.ScriptEngine.Script
{
    public class AssemblyHelper
    {
        private static AssemblyHelper m_Instance = null;
        /// <summary>
        /// 获取对象实例辅助类单实例
        /// </summary>
        public static AssemblyHelper Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new AssemblyHelper();
                return m_Instance;
            }
        }
        private AssemblyHelper()
        {
        }

        /// <summary>
        /// 从执行程序集文件加载程序集
        /// </summary>
        /// <param name="assemblyFile">程序集文件</param>
        /// <returns>Assembly</returns>
        public Assembly GetScriptAssembly(string assemblyFile)
        {
            try
            {
                return Assembly.LoadFile(assemblyFile);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("AssemblyHelper.GetScriptAssembly", ex);
                return null;
            }
        }

        /// <summary>
        /// 从执行程序集裸数据加载程序集
        /// </summary>
        /// <param name="assemblyRawData">程序集裸数据</param>
        /// <returns>Assembly</returns>
        public Assembly GetScriptAssembly(byte[] assemblyRawData)
        {
            try
            {
                return Assembly.Load(assemblyRawData);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("AssemblyHelper.GetScriptAssembly", ex);
                return null;
            }
        }

        /// <summary>
        /// 获取指定程序集文件的二进制数据
        /// </summary>
        /// <param name="assemblyFile">程序集文件</param>
        /// <returns>byte[]</returns>
        public byte[] GetAssemblyData(string assemblyFile)
        {
            byte[] byteScriptData = null;
            if (!GlobalMethods.IO.GetFileBytes(assemblyFile, ref byteScriptData))
                return new byte[0];
            return byteScriptData;
        }

        /// <summary>
        /// 从指定的计算脚本程序集文件中获取计算接口列表
        /// </summary>
        /// <param name="assemblyFile">计算脚本程序集文件</param>
        /// <returns>计算接口列表</returns>
        public List<IElementCalculator> GetElementCalculator(string assemblyFile)
        {
            return this.GetElementCalculator(this.GetScriptAssembly(assemblyFile));
        }

        /// <summary>
        /// 从指定的计算脚本程序集中获取计算接口列表
        /// </summary>
        /// <param name="assemblyFile">计算脚本程序集文件</param>
        /// <returns>计算接口列表</returns>
        public List<IElementCalculator> GetElementCalculator(Assembly scriptAssembly)
        {
            List<IElementCalculator> elementCalculators = new List<IElementCalculator>();
            if (scriptAssembly == null)
                return elementCalculators;

            Type[] types = scriptAssembly.GetExportedTypes();
            if (types == null)
                return elementCalculators;
            foreach (Type type in types)
            {
                try
                {
                    Type interfaceClass = type.GetInterface(typeof(IElementCalculator).FullName);
                    if (interfaceClass == typeof(IElementCalculator))
                        elementCalculators.Add(scriptAssembly.CreateInstance(type.FullName) as IElementCalculator);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteLog("AssemblyHelper.GetElementCalculator", ex);
                }
            }
            return elementCalculators;
        }
    }
}
