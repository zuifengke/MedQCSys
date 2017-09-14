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
            /// 病人就诊次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病人就诊次
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
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
            /// <summary>
            /// 治疗天数
            /// </summary>
            public const string TREAT_DAYS = "TREAT_DAYS";
            /// <summary>
            /// 0：确诊诊断，1疑似诊断
            /// </summary>
            public const string DIAG_INDICATOR = "DIAG_INDICATOR";
            /// <summary>
            /// 诊断代码
            /// </summary>
            public const string DIAGNOSIS_CODE = "DIAGNOSIS_CODE";
        }

    }
}
