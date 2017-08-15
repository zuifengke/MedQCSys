// ***********************************************************
// 电子病历系统关联元素自动计算脚本编译器类.
// Creator: YangMingkun  Date:2011-11-10
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.CodeDom.Compiler;
using Heren.Common.Libraries;

namespace Heren.MedQC.ScriptEngine.Script
{
    public class ScriptCompiler
    {
        private static ScriptCompiler m_Instance = null;
        /// <summary>
        /// 获取脚本编译器对象
        /// </summary>
        public static ScriptCompiler Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ScriptCompiler();
                return m_Instance;
            }
        }
        private ScriptCompiler()
        {
        }

        private string m_workingPath = null;
        /// <summary>
        /// 获取或设置调试器工作路径
        /// </summary>
        [Browsable(false)]
        public string WorkingPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_workingPath))
                    return this.GetWorkingPath();
                return this.m_workingPath;
            }
            set { this.m_workingPath = value; }
        }

        /// <summary>
        /// 得到Common.ScriptEngine.dll程序的工作路径
        /// </summary>
        /// <returns>工作路径</returns>
        private string GetWorkingPath()
        {
            string path = GlobalMethods.Misc.GetWorkingPath(this.GetType());
            try
            {
                if (!System.IO.File.Exists(path + "\\MedQC.ScriptEngine.dll"))
                    path = AppDomain.CurrentDomain.RelativeSearchPath;
            }
            catch { }
            return path;
        }

        private string m_cachePath = null;
        /// <summary>
        /// 获取编译输出文件本地缓存目录
        /// </summary>
        private string CachePath
        {
            get
            {
                if (GlobalMethods.Misc.IsEmptyString(this.m_cachePath))
                    this.m_cachePath = this.WorkingPath + "\\Script\\Temp\\";
                return this.m_cachePath;
            }
        }

        /// <summary>
        /// 自动添加的脚本头部Imports语句的行数
        /// </summary>
        private int m_nScriptHeaderLineCount = 0;

        /// <summary>
        /// 获取编译参数
        /// </summary>
        /// <param name="outputFile">编译输出文件</param>
        /// <returns>CompilerParameters</returns>
        private CompilerParameters GetCompilerParameters(string outputFile)
        {
            CompilerParameters param = new CompilerParameters();
            param.GenerateExecutable = false;
            if (GlobalMethods.Misc.IsEmptyString(outputFile))
            {
                param.GenerateInMemory = true;
            }
            else
            {
                param.GenerateInMemory = false;
                param.OutputAssembly = outputFile;
            }

            param.WarningLevel = 0;
            param.TreatWarningsAsErrors = false;
            param.IncludeDebugInformation = false;
            param.CompilerOptions = "/platform:x86";

            param.ReferencedAssemblies.Add("System.dll");
            param.ReferencedAssemblies.Add("System.Data.dll");
            param.ReferencedAssemblies.Add("System.Xml.dll");
            param.ReferencedAssemblies.Add("System.Drawing.dll");
            param.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            param.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");

            string scriptEnginePath = this.WorkingPath + "\\MedQC.ScriptEngine.dll";
            if (!System.IO.File.Exists(scriptEnginePath))
                scriptEnginePath = GlobalMethods.Misc.GetWorkingPath() + "\\MedQC.ScriptEngine.dll";
            param.ReferencedAssemblies.Add(scriptEnginePath);

            scriptEnginePath = this.WorkingPath + "\\MedQC.Model.dll";
            if (!System.IO.File.Exists(scriptEnginePath))
                scriptEnginePath = GlobalMethods.Misc.GetWorkingPath() + "\\MedQC.Model.dll";
            param.ReferencedAssemblies.Add(scriptEnginePath);
            return param;
        }

        /// <summary>
        /// 获取脚本程序集文件描述器脚本
        /// </summary>
        /// <param name="language">脚本语言</param>
        /// <returns>返回属性脚本</returns>
        private string GetScriptAssemblyDescriptor(ScriptLanguage language)
        {
            if (language == ScriptLanguage.VBNET)
                return this.GetScriptAssemblyDescriptorVB();
            else
                return this.GetScriptAssemblyDescriptorCS();
        }

        /// <summary>
        /// 获取脚本程序集文件描述器VB脚本
        /// </summary>
        /// <returns>返回属性VB脚本</returns>
        private string GetScriptAssemblyDescriptorVB()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Imports System.Reflection");
            builder.AppendLine("Imports System.Runtime.CompilerServices");
            builder.AppendLine("Imports System.Runtime.InteropServices");

            builder.AppendLine("<Assembly: AssemblyTitle(\"Heren.CalcScript\")>");
            builder.AppendLine("<Assembly: AssemblyDescription(\"Heren.CalcScript\")>");
            builder.AppendLine("<Assembly: AssemblyConfiguration(\"\")>");
            builder.AppendLine("<Assembly: AssemblyCompany(\"浙江和仁科技\")>");
            builder.AppendLine("<Assembly: AssemblyProduct(\"和仁电子病历系统\")>");
            builder.AppendLine("<Assembly: AssemblyCopyright(\"版权所有 (C) 浙江和仁科技 2011\")>");
            builder.AppendLine("<Assembly: AssemblyTrademark(\"Heren Health\")>");
            builder.AppendLine("<Assembly: AssemblyCulture(\"\")>");

            string version = DateTime.Now.ToString("1.yy.MM.dd");
            builder.AppendLine(string.Format("<Assembly: AssemblyVersion(\"{0}\")>", version));
            builder.AppendLine(string.Format("<Assembly: AssemblyFileVersion(\"{0}\")>", version));
            return builder.ToString();
        }

        /// <summary>
        /// 获取脚本程序集文件描述器C#脚本
        /// </summary>
        /// <returns>返回属性C#脚本</returns>
        private string GetScriptAssemblyDescriptorCS()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("using System.Reflection;");
            builder.AppendLine("using System.Runtime.CompilerServices;");
            builder.AppendLine("using System.Runtime.InteropServices;");

            builder.AppendLine("[assembly: AssemblyTitle(\"Heren.CalcScript\")]");
            builder.AppendLine("[assembly: AssemblyDescription(\"Heren.CalcScript\")]");
            builder.AppendLine("[assembly: AssemblyConfiguration(\"\")]");
            builder.AppendLine("[assembly: AssemblyCompany(\"浙江和仁科技\")]");
            builder.AppendLine("[assembly: AssemblyProduct(\"和仁电子病历系统\")]");
            builder.AppendLine("[assembly: AssemblyCopyright(\"版权所有 (C) 浙江和仁科技 2011\")]");
            builder.AppendLine("[assembly: AssemblyTrademark(\"Heren Health\")]");
            builder.AppendLine("[assembly: AssemblyCulture(\"\")]");

            string version = DateTime.Now.ToString("1.yy.MM.dd");
            builder.AppendLine(string.Format("[assembly: AssemblyVersion(\"{0}\")]", version));
            builder.AppendLine(string.Format("[assembly: AssemblyFileVersion(\"{0}\")]", version));
            return builder.ToString();
        }

        /// <summary>
        /// 格式化传入的原始脚本,这些脚本中是不包含类定义的
        /// </summary>
        /// <param name="script">原始脚本</param>
        /// <param name="language">脚本语言</param>
        /// <returns>格式化后的脚本</returns>
        private string FormatScript(string script, ScriptLanguage language)
        {
            if (language == ScriptLanguage.VBNET)
                return this.FormatScriptVB(script);
            else
                return this.FormatScriptCS(script);
        }

        /// <summary>
        /// 格式化传入的VB原始脚本,这些脚本中是不包含类定义的
        /// </summary>
        /// <param name="script">原始VB脚本</param>
        /// <returns>格式化后的脚本</returns>
        private string FormatScriptVB(string script)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine("Imports System");
            sbScript.AppendLine("Imports System.IO");
            sbScript.AppendLine("Imports System.Xml");
            sbScript.AppendLine("Imports System.Text");
            sbScript.AppendLine("Imports System.Collections");
            sbScript.AppendLine("Imports System.Collections.Generic");
            sbScript.AppendLine("Imports System.Drawing");
            sbScript.AppendLine("Imports System.Windows.Forms");
            sbScript.AppendLine("Imports Microsoft.VisualBasic");
            sbScript.AppendLine("Imports Heren.MedQC.ScriptEngine.Script");
            sbScript.AppendLine("Imports EMRDBLib");
            sbScript.AppendLine("Imports System.Data");
            sbScript.AppendLine();
            sbScript.AppendLine("Public Class DefaultElementCalculator");
            sbScript.AppendLine("    Inherits Heren.MedQC.ScriptEngine.Script.AbstractElementCalculator");

            //注意:如果上面几行AppendLine代码行数有变化,请及时更新下面变量
            this.m_nScriptHeaderLineCount = 13;

            sbScript.AppendLine(script);
            sbScript.AppendLine("End Class");
            return sbScript.ToString();
        }

        /// <summary>
        /// 格式化传入的C#原始脚本,这些脚本中是不包含类定义的
        /// </summary>
        /// <param name="script">原始C#脚本</param>
        /// <returns>格式化后的脚本</returns>
        private string FormatScriptCS(string script)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine("using System;");
            sbScript.AppendLine("using System.IO;");
            sbScript.AppendLine("using System.Xml;");
            sbScript.AppendLine("using System.Text;");
            sbScript.AppendLine("using System.Collections;");
            sbScript.AppendLine("using System.Collections.Generic;");
            sbScript.AppendLine("using System.Drawing;");
            sbScript.AppendLine("using System.Windows.Forms;");
            sbScript.AppendLine("using Microsoft.VisualBasic;");
            sbScript.AppendLine("using Heren.Common.ScriptEngine.Script;");
            sbScript.AppendLine("using EMRDBLib;");
            sbScript.AppendLine("using System.Data;");
            sbScript.AppendLine();
            sbScript.AppendLine("public class DefaultElementCalculator");
            sbScript.AppendLine("    : Heren.Common.ScriptEngine.Script.AbstractElementCalculator");
            sbScript.AppendLine("{");

            //注意:如果上面几行AppendLine代码行数有变化,请及时更新下面变量
            this.m_nScriptHeaderLineCount = 14;

            sbScript.AppendLine(script);
            sbScript.AppendLine("}");
            return sbScript.ToString();
        }

        /// <summary>
        /// 将.NET内置的编译结果对象转换为ScriptAgent的编译结果对象
        /// </summary>
        /// <param name="results">.NET内置的编译结果对象</param>
        /// <returns>ScriptAgent的编译结果对象(永不为null)</returns>
        private CompileResults GetCompileResults(CompilerResults results)
        {
            CompileResults compileResults = new CompileResults();
            if (results == null)
                return compileResults;
            if (results.Errors != null && results.Errors.HasErrors)
            {
                foreach (CompilerError error in results.Errors)
                {
                    if (error.IsWarning)
                        compileResults.HasWarnings = true;
                    else
                        compileResults.HasErrors = true;
                    error.Line -= this.m_nScriptHeaderLineCount;
                    compileResults.Errors.Add(new CompileError(error.FileName
                        , error.Line, error.Column, error.ErrorNumber, error.ErrorText, error.IsWarning));
                }
                return compileResults;
            }
            //以裸数据的方式加载程序,防止程序集临时文件被占用导致无法清除
            byte[] byteAssemblyData = AssemblyHelper.Instance.GetAssemblyData(results.PathToAssembly);
            compileResults.CompiledAssembly = AssemblyHelper.Instance.GetScriptAssembly(byteAssemblyData);
            return compileResults;
        }

        /// <summary>
        /// 编译指定脚本源码,返回编译结果
        /// </summary>
        /// <param name="source">源码</param>
        /// <param name="language">语言</param>
        /// <returns>ScriptAgent的编译结果对象(永不为null)</returns>
        public CompileResults CompileScript(string source, ScriptLanguage language)
        {
            return this.CompileScript(source, language, null);
        }

        /// <summary>
        /// 编译指定脚本源码,返回编译结果
        /// </summary>
        /// <param name="source">源码</param>
        /// <param name="language">语言</param>
        /// <param name="outputFile">输出程序集文件</param>
        /// <returns>ScriptAgent的编译结果对象(永不为null)</returns>
        public CompileResults CompileScript(string source, ScriptLanguage language, string outputFile)
        {
            CodeDomProvider provider = null;
            switch (language)
            {
                case ScriptLanguage.VBNET:
                    provider = new Microsoft.VisualBasic.VBCodeProvider();
                    break;
                case ScriptLanguage.CSharp:
                    provider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
            }

            CompilerParameters param = this.GetCompilerParameters(outputFile);
            if (param == null)
                return new CompileResults();
            string szAssemblyDescriptor = this.GetScriptAssemblyDescriptor(language);
            CompilerResults results = null;
            try
            {
                source = this.FormatScript(source, language);
                results = provider.CompileAssemblyFromSource(param, szAssemblyDescriptor, source);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptCompiler.CompileScript", ex);
            }
            return this.GetCompileResults(results);
        }

        /// <summary>
        /// 编译指定脚本源码,返回编译结果
        /// </summary>
        /// <param name="scriptProperty">脚本配置信息</param>
        /// <returns>ScriptAgent的编译结果对象(永不为null)</returns>
        public CompileResults CompileScript(ScriptProperty scriptProperty)
        {
            if (scriptProperty == null)
                return new CompileResults();

            GlobalMethods.IO.CreateDirectory(this.CachePath);
            string szOutputFile = string.Format("{0}\\Calc.{1}.dll"
                , this.CachePath, Math.Abs(scriptProperty.ScriptText.GetHashCode()).ToString());

            CompileResults results = this.CompileScript(scriptProperty.ScriptText, scriptProperty.ScriptLang, szOutputFile);
            scriptProperty.ScriptData = AssemblyHelper.Instance.GetAssemblyData(szOutputFile);
            GlobalMethods.IO.DeleteFile(szOutputFile);
            return results;
        }
    }
}
