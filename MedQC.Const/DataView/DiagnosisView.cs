using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人诊断信息视图数据字段
        /// </summary>
        public struct DiagnosisView
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
            /// 诊断类别代码
            /// </summary>
            public const string DIAGNOSIS_TYPE = "DIAGNOSIS_TYPE";
            /// <summary>
            /// 诊断类别
            /// </summary>
            public const string DIAGNOSIS_TYPE_NAME = "DIAGNOSIS_TYPE_NAME";
            /// <summary>
            /// 诊断序号
            /// </summary>
            public const string DIAGNOSIS_NO = "DIAGNOSIS_NO";
            /// <summary>
            /// 诊断描述
            /// </summary>
            public const string DIAGNOSIS_DESC = "DIAGNOSIS_DESC";
            /// <summary>
            /// 诊断日期
            /// </summary>
            public const string DIAGNOSIS_DATE = "DIAGNOSIS_DATE";
            /// <summary>
            /// 治疗结果
            /// </summary>
            public const string TREAT_RESULT = "TREAT_RESULT";
        }

    }
}
