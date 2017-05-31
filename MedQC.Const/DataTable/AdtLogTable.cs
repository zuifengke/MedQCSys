using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人入出转状态表
        /// </summary>
        public struct AdtLogTable
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病情状态
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
        }
    }
}
