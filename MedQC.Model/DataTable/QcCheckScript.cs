using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 质控缺陷检查脚本
    /// </summary>
    public class QcCheckScript
    {
        public string ScriptID { get; set; }
        public string ScriptLang { get; set; }
        public string ScriptName { get; set; }
        public string ScriptUsing { get; set; }
        public string CreatorID { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreateTime { get; set; }
        public string ModifierID { get; set; }
        public string ModifierName { get; set; }
        public DateTime ModifyTime { get; set; }
        public byte[] ScriptSource { get; set; }
    }
}
