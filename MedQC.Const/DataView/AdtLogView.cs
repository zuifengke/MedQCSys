using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病情状态日志视图
        /// </summary>
        public struct AdtLogView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病情状态发烧时间
            /// </summary>
            public const string LOG_DATE_TIME = "LOG_DATE_TIME";
        }
    }
}
