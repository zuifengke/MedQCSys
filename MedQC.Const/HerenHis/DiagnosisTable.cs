
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        public struct DiagnosisTable
        {
            /// <summary>
            /// 患者标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 接诊号
            /// </summary>
            public const string ENCOUNTER_NO = "ENCOUNTER_NO";
            /// <summary>
            /// 诊断类别
            /// </summary>
            public const string DIAG_TYPE = "DIAG_TYPE";
            /// <summary>
            /// 诊断序号
            /// </summary>
            public const string DIAG_NO = "DIAG_NO";
            /// <summary>
            /// 诊断描述
            /// </summary>
            public const string DIAG_DESC = "DIAG_DESC";
            /// <summary>
            /// 诊断日期
            /// </summary>
            public const string DIAG_DATE = "DIAG_DATE";
            /// <summary>
            /// 治疗天数
            /// </summary>
            public const string TREAT_DAYS = "TREAT_DAYS";
            /// <summary>
            /// 治疗结果
            /// </summary>
            public const string TREAT_RESULT = "TREAT_RESULT";
            /// <summary>
            /// 诊断次序
            /// </summary>
            public const string DIAGNOSIS_SORT = "DIAGNOSIS_SORT";
            /// <summary>
            /// 确诊标志
            /// </summary>
            public const string DIAG_INDICATOR = "DIAG_INDICATOR";
            /// <summary>
            /// 慢病标识
            /// </summary>
            public const string CHRONIC_DISEASE = "CHRONIC_DISEASE";
            /// <summary>
            /// 诊断医师名称
            /// </summary>
            public const string DIAG_DOCTOR = "DIAG_DOCTOR";
            /// <summary>
            /// 诊断医师编码
            /// </summary>
            public const string DIAG_DOCTOR_ID = "DIAG_DOCTOR_ID";
            /// <summary>
            /// 医疗类别
            /// </summary>
            public const string CLINIC_CATE = "CLINIC_CATE";
            /// <summary>
            /// 手术治疗标志
            /// </summary>
            public const string OPER_TREAT_INDICATOR = "OPER_TREAT_INDICATOR";
            /// <summary>
            /// 诊断代码
            /// </summary>
            public const string DIAG_CODE = "DIAG_CODE";
            /// <summary>
            /// 入院病情
            /// </summary>
            public const string ADMISSION_CONDITION = "ADMISSION_CONDITION";
        }
    }
}
