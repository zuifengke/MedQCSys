using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 脚本可执行文件表
        /// </summary>
        public struct ScriptDataTable
        {
            /// <summary>
            /// 脚本ID
            /// </summary>
            public const string SCRIPT_ID = "SCRIPT_ID";
            /// <summary>
            /// 可执行文件数据
            /// </summary>
            public const string SCRIPT_DATA = "SCRIPT_DATA";
        }
    }
}
