using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 系统配置字典表各字段定义
        /// </summary>
        public struct ConfigDictTable
        {
            /// <summary>
            /// 配置组名称
            /// </summary>
            public const string GROUP_NAME = "GROUP_NAME";
            /// <summary>
            /// 配置项名称
            /// </summary>
            public const string CONFIG_NAME = "CONFIG_NAME";
            /// <summary>
            /// 配置项值
            /// </summary>
            public const string CONFIG_VALUE = "CONFIG_VALUE";
            /// <summary>
            /// 配置项描述
            /// </summary>
            public const string CONFIG_DESC = "CONFIG_DESC";
        }
    }
}
