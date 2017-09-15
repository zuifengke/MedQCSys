using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 体征视图
        /// </summary>
        public struct VitalSignsView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 记录时间
            /// </summary>
            public const string RECORDING_DATE = "RECORDING_DATE";
            /// <summary>
            /// 时间点
            /// </summary>
            public const string TIME_POINT = "TIME_POINT";
            /// <summary>
            /// 项目名称
            /// </summary>
            public const string VITAL_SIGNS = "VITAL_SIGNS";
            /// <summary>
            /// 项目值
            /// </summary>
            public const string VITAL_SIGNS_VALUES = "VITAL_SIGNS_VALUES";
            /// <summary>
            /// 单位
            /// </summary>
            public const string UNITS = "UNITS";
            /// <summary>
            /// 备注
            /// </summary>
            public const string MEMO = "MEMO";

        }
    }
}
