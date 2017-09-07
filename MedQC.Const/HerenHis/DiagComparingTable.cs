
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        public struct DiagComparingTable
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 诊断对照组
            /// </summary>
            public const string DIAG_COMPARE_GROUP_CODE = "DIAG_COMPARE_GROUP_CODE";
            /// <summary>
            /// 诊断符合情况
            /// </summary>
            public const string DIAG_CORRESPONDENCE = "DIAG_CORRESPONDENCE";
        }
    }
}
