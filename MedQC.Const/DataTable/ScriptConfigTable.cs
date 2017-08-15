using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 脚本配置表
        /// </summary>
        public struct ScriptConfigTable
        {
            /// <summary>
            /// 脚本ID
            /// </summary>
            public const string SCRIPT_ID = "SCRIPT_ID";
            /// <summary>
            /// 语言类型
            /// </summary>
            public const string SCRIPT_LANG = "SCRIPT_LANG";
            /// <summary>
            /// 功能描述
            /// </summary>
            public const string SCRIPT_NAME = "SCRIPT_NAME";
            /// <summary>
            /// 脚本引用的外部程序集
            /// </summary>
            public const string SCRIPT_USING = "SCRIPT_USING";
            /// <summary>
            /// 创建者ID
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";
            /// <summary>
            /// 创建者名称
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";
            /// <summary>
            /// 创建时间
            /// </summary>
            public const string CREATE_TIME = "CREATE_TIME";
            /// <summary>
            /// 修改者ID
            /// </summary>
            public const string MODIFIER_ID = "MODIFIER_ID";
            /// <summary>
            /// 修改者名称
            /// </summary>
            public const string MODIFIER_NAME = "MODIFIER_NAME";
            /// <summary>
            /// 修改日期
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";
            /// <summary>
            /// 脚本源码
            /// </summary>
            public const string SCRIPT_SOURCE = "SCRIPT_SOURCE";
            /// <summary>
            /// 上级节点
            /// </summary>
            public const string PARENT_ID = "PARENT_ID";
            /// <summary>
            /// 是否是文件夹 
            /// </summary>
            public const string IS_FOLDER = "IS_FOLDER";
            /// <summary>
            /// 顺序号
            /// </summary>
            public const string SCRIPT_NO = "SCRIPT_NO";
        }
    }
}
