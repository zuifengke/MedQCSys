using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 规则计算脚本配置
    /// </summary>
    public class ScriptData : DbTypeBase
    {
        /// <summary>
        /// 脚本ID
        /// </summary>
        public string SCRIPT_ID { get; set; }
        /// <summary>
        /// 可执行文件数据
        /// </summary>
        public byte[] SCRIPT_LANG { get; set; }
    }
}
