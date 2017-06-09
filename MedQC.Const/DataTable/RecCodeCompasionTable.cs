using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案上传编码对照表
        /// </summary>
        public struct RecCodeCompasionTable
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string ID = "ID";
            /// <summary>
            /// 联众代码类别
            /// </summary>
            public const string DMLB = "DMLB";
            /// <summary>
            /// 联众字典代码
            /// </summary>
            public const string DM = "DM";
            /// <summary>
            /// 联众字典名称
            /// </summary>
            public const string MC = "MC";
            /// <summary>
            /// 和仁字典代码
            /// </summary>
            public const string CODE_ID = "CODE_ID";
            /// <summary>
            /// 和仁字典名称
            /// </summary>
            public const string CODE_NAME = "CODE_NAME";
            /// <summary>
            /// 和仁代码类别
            /// </summary>
            public const string CODETYPE_NAME = "CODETYPE_NAME";
            /// <summary>
            /// 是否为配置类别 0 否 1是
            /// </summary>
            public const string IS_CONFIG = "IS_CONFIG";
            /// <summary>
            /// 查询来源代码sql配置
            /// </summary>
            public const string FORM_SQL = "FORM_SQL";
            /// <summary>
            /// 查询目标代码sql配置
            /// </summary>
            public const string TO_SQL = "TO_SQL";
            /// <summary>
            /// 字典类别名称
            /// </summary>
            public const string CONFIG_NAME = "CONFIG_NAME";
        }
    }
}
