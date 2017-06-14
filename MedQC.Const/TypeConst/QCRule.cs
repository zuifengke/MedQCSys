using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 文档内容质控规则相关常量
        /// </summary>
        public struct QCRule
        {
            /// <summary>
            /// ENTRY类型之DOCUMENT
            /// </summary>
            public const string ENTRY_TYPE_DOCUMENT = "DOCUMENT";
            /// <summary>
            /// ENTRY类型之REFLECTION
            /// </summary>
            public const string ENTRY_TYPE_REFLECTION = "REFLECTION";

            /// <summary>
            /// ENTRY值类型之int
            /// </summary>
            public const string ENTRY_VALUE_TYPE_INT = "int";
            /// <summary>
            /// ENTRY值类型之bool
            /// </summary>
            public const string ENTRY_VALUE_TYPE_BOOL = "bool";
            /// <summary>
            /// ENTRY值类型之datetime
            /// </summary>
            public const string ENTRY_VALUE_TYPE_DATE = "datetime";
            /// <summary>
            /// ENTRY值类型之string
            /// </summary>
            public const string ENTRY_VALUE_TYPE_TEXT = "string";

            #region"数据显示值与实际值转换"
            /// <summary>
            /// 获取ENTRY类型之中文名称(用于界面显示)
            /// </summary>
            /// <param name="szEntryType">ENTRY类型英文名称</param>
            /// <returns>ENTRY类型中文名称</returns>
            public static string GetEntryTypeZH(string szEntryType)
            {
                if (GlobalMethods.Misc.IsEmptyString(szEntryType))
                    return "从文档提取";
                if (szEntryType.Trim() == QCRule.ENTRY_TYPE_REFLECTION)
                    return "从系统映射";
                else
                    return "从文档提取";
            }

            /// <summary>
            /// 获取ENTRY类型之英文名称(用于数据存储)
            /// </summary>
            /// <param name="szEntryType">ENTRY类型中文名称</param>
            /// <returns>ENTRY类型英文名称</returns>
            public static string GetEntryTypeEN(string szEntryType)
            {
                if (GlobalMethods.Misc.IsEmptyString(szEntryType))
                    return QCRule.ENTRY_TYPE_DOCUMENT;
                if (szEntryType.Trim() == "从系统映射")
                    return QCRule.ENTRY_TYPE_REFLECTION;
                else
                    return QCRule.ENTRY_TYPE_DOCUMENT;
            }

            /// <summary>
            /// 获取ENTRY值数据类型之中文名称(用于界面显示)
            /// </summary>
            /// <param name="szValueType">ENTRY值数据类型英文名称</param>
            /// <returns>ENTRY值数据类型之中文名称</returns>
            public static string GetValueTypeZH(string szValueType)
            {
                if (GlobalMethods.Misc.IsEmptyString(szValueType))
                    return "字符串";
                szValueType = szValueType.Trim().ToLower();
                if (szValueType.Trim() == QCRule.ENTRY_VALUE_TYPE_INT)
                    return "数值";
                else if (szValueType.Trim() == QCRule.ENTRY_VALUE_TYPE_BOOL)
                    return "布尔值";
                else if (szValueType.Trim() == QCRule.ENTRY_VALUE_TYPE_DATE)
                    return "日期时间";
                else
                    return "字符串";
            }

            /// <summary>
            /// 获取ENTRY值数据类型之英文名称(用于数据存储)
            /// </summary>
            /// <param name="szValueType">ENTRY值数据类型中文名称</param>
            /// <returns>ENTRY值数据类型之中文名称</returns>
            public static string GetValueTypeEN(string szValueType)
            {
                if (GlobalMethods.Misc.IsEmptyString(szValueType))
                    return QCRule.ENTRY_VALUE_TYPE_TEXT;
                szValueType = szValueType.Trim().ToLower();
                if (szValueType.Trim() == "数值")
                    return QCRule.ENTRY_VALUE_TYPE_INT;
                else if (szValueType.Trim() == "布尔值")
                    return QCRule.ENTRY_VALUE_TYPE_BOOL;
                else if (szValueType.Trim() == "日期时间")
                    return QCRule.ENTRY_VALUE_TYPE_DATE;
                else
                    return QCRule.ENTRY_VALUE_TYPE_TEXT;
            }
            #endregion
        }

    }
}
