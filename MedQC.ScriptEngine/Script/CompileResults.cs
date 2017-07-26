// ***********************************************************
// 电子病历系统关联元素自动计算脚本编译器编译结果类
// 我们自建此类,而不用.NET内置的编译器结果类,主要考虑到代码安
// 全,需要对ScriptAgent.dll以外屏蔽所有与编译有关的.NET对象和
// 操作方法
// Creator : YangMingkun  Date : 2011-11-29
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Heren.Common.ScriptEngine.Script
{
    public class CompileResults
    {
        private CompileErrorCollection m_compileErrors = null;
        /// <summary>
        /// 获取或设置编译过程中的错误(永不为null)
        /// </summary>
        public CompileErrorCollection Errors
        {
            get { return this.m_compileErrors; }
            set
            {
                if (value == null)
                    this.m_compileErrors.Clear();
                else
                    this.m_compileErrors = value;
            }
        }

        private bool m_hasErrors = false;
        /// <summary>
        /// 获取编译是否有错误
        /// </summary>
        public bool HasErrors
        {
            get { return this.m_hasErrors; }
            internal set { this.m_hasErrors = value; }
        }

        private bool m_hasWarnings = false;
        /// <summary>
        /// 获取编译是否有警告
        /// </summary>
        public bool HasWarnings
        {
            get { return this.m_hasWarnings; }
            internal set { this.m_hasWarnings = value; }
        }

        private Assembly m_compiledAssembly = null;
        /// <summary>
        /// 获取或设置编译输出的程序集
        /// </summary>
        public Assembly CompiledAssembly
        {
            get { return this.m_compiledAssembly; }
            set { this.m_compiledAssembly = value; }
        }

        private List<IElementCalculator> m_elementCalculators = null;
        /// <summary>
        /// 获取编译生成的元素计算器集合(永不为null)
        /// </summary>
        public List<IElementCalculator> ElementCalculators
        {
            get
            {
                if (this.m_elementCalculators == null)
                    this.m_elementCalculators = AssemblyHelper.Instance.GetElementCalculator(this.m_compiledAssembly);
                return this.m_elementCalculators == null ?
                    new List<IElementCalculator>() : this.m_elementCalculators;
            }
        }

        public CompileResults()
        {
            this.m_compileErrors = new CompileErrorCollection();
        }
    }

    /// <summary>
    /// 编译器错误信息集合
    /// </summary>
    [Serializable]
    public class CompileErrorCollection : List<CompileError>
    {
    }

    /// <summary>
    /// 编译器错误信息
    /// </summary>
    [Serializable]
    public class CompileError
    {
        private string m_fileName = string.Empty;
        /// <summary>
        /// 获取或设置错误对应的源代码文件
        /// </summary>
        public string FileName
        {
            get { return this.m_fileName; }
            set { this.m_fileName = value; }
        }

        private int m_line = 0;
        /// <summary>
        /// 获取或设置错误对应的行号
        /// </summary>
        public int Line
        {
            get { return this.m_line; }
            set { this.m_line = value; }
        }

        private int m_column = 0;
        /// <summary>
        /// 获取或设置错误对应的列号
        /// </summary>
        public int Column
        {
            get { return this.m_column; }
            set { this.m_column = value; }
        }

        private string m_errorNumber = string.Empty;
        /// <summary>
        /// 获取或设置错误对应的编号
        /// </summary>
        public string ErrorNumber
        {
            get { return this.m_errorNumber; }
            set { this.m_errorNumber = value; }
        }

        private string m_errorText = string.Empty;
        /// <summary>
        /// 获取或设置错误对应的文本
        /// </summary>
        public string ErrorText
        {
            get { return this.m_errorText; }
            set { this.m_errorText = value; }
        }

        private bool m_isWarning = false;
        /// <summary>
        /// 获取或设置是否是警告错误
        /// </summary>
        public bool IsWarning
        {
            get { return this.m_isWarning; }
            set { this.m_isWarning = value; }
        }

        public CompileError()
        {
        }

        public CompileError(string fileName, int line, int column, string errorNumber, string errorText)
            : this(fileName, line, column, errorNumber, errorText, false)
        {
        }

        public CompileError(string fileName, int line, int column, string errorNumber, string errorText, bool isWarning)
        {
            this.m_fileName = fileName;
            this.m_line = line;
            this.m_column = column;
            this.m_errorNumber = errorNumber;
            this.m_errorText = errorText;
            this.m_isWarning = isWarning;
        }

        public override string ToString()
        {
            return string.Format("FileName={0}, Line={1}, Column={2}, ErrorText={3} "
                , this.m_fileName, this.m_line, this.m_column, this.m_errorText);
        }
    }
}
