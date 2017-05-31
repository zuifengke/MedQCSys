using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 程序单实例运行映射名称
        /// </summary>
        public struct MappingName
        {
            /// <summary>
            /// 病历质控系统
            /// </summary>
            public const string MEDQC_SYS = "MedQcSys";
            /// <summary>
            /// 病历编辑器系统
            /// </summary>
            public const string MEDDOC_SYS = "MedDocSys";
            /// <summary>
            /// 病历提醒系统
            /// </summary>
            public const string MEDTASK_SYS = "MedTask";
            /// <summary>
            /// 质检问题提醒系统
            /// </summary>
            public const string QUESTION_CHAT_SYS = "QuestionChat";
            /// <summary>
            /// 病历模板系统
            /// </summary>
            public const string TEMPLET_SYS = "MedTemplet";
            /// <summary>
            /// 配置管理程序
            /// </summary>
            public const string CONFIG_SYS = "MdsConfig";
            /// <summary>
            /// 病历检索系统
            /// </summary>
            public const string SEARCH_SYS = "MedSearch";
            /// <summary>
            /// 脚本调试程序
            /// </summary>
            public const string SCRIPT_DEBUG_SYS = "ScriptDebuger";
            /// <summary>
            /// 自动升级程序
            /// </summary>
            public const string UPGRADE_SYS = "Upgrade";

            public const string QUESTION_CHAT_CLIENT_SYS = "ChatClient";
        }
    }
}
