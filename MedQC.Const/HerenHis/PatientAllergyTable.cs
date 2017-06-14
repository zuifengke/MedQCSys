
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 过敏史和不良反映史
        /// </summary>
        public struct PatientAllergyTable
        {
            /// <summary>
            /// 患者标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 序号
            /// </summary>
            public const string ALLERGY_NO = "ALLERGY_NO";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 接诊号
            /// </summary>
            public const string ENCOUNTER_NO = "ENCOUNTER_NO";
            /// <summary>
            /// 过敏原类型
            /// </summary>
            public const string ALLERGY_TYPE = "ALLERGY_TYPE";
            /// <summary>
            /// 过敏原
            /// </summary>
            public const string ALLERGEN = "ALLERGEN";
            /// <summary>
            /// 过敏程度
            /// </summary>
            public const string ALLERGEN_DEGREE = "ALLERGEN_DEGREE";
            /// <summary>
            /// 过敏症状
            /// </summary>
            public const string ALLERGEN_SYMPTOM = "ALLERGEN_SYMPTOM";
            /// <summary>
            /// 当前状态
            /// </summary>
            public const string ALLERGEN_STATUS = "ALLERGEN_STATUS";
            /// <summary>
            /// 开始日期
            /// </summary>
            public const string BEGIN_DATE = "BEGIN_DATE";
            /// <summary>
            /// 结束日期
            /// </summary>
            public const string END_DATE = "END_DATE";
            /// <summary>
            /// 记录医师
            /// </summary>
            public const string RECORD_DOCTOR = "RECORD_DOCTOR";
            /// <summary>
            /// 记录医师编码
            /// </summary>
            public const string RECORD_DOCTOR_ID = "RECORD_DOCTOR_ID";
            /// <summary>
            /// 记录日期
            /// </summary>
            public const string RECORD_DATE = "RECORD_DATE";
            /// <summary>
            /// 诊断医师编码
            /// </summary>
            public const string DIAG_DOCTOR_ID = "DIAG_DOCTOR_ID";
            /// <summary>
            /// 医疗类别
            /// </summary>
            public const string CLINIC_CATE = "CLINIC_CATE";
            /// <summary>
            /// 自述标识
            /// </summary>
            public const string OWN_COMPLAINT_DISEASE = "OWN_COMPLAINT_DISEASE";
            /// <summary>
            /// 本院标识
            /// </summary>
            public const string INHOSPITAL_DISEASE = "INHOSPITAL_DISEASE";
            /// <summary>
            /// 过敏药物分类
            /// </summary>
            public const string ALLERGEN_DRUG_CLASS = "ALLERGEN_DRUG_CLASS";
            /// <summary>
            /// 过敏药品编码
            /// </summary>
            public const string ALLERGEN_DRUG_CODE = "ALLERGEN_DRUG_CODE";
            /// <summary>
            /// 药品类型
            /// </summary>
            public const string DRUG_TYPE = "DRUG_TYPE";

        }
    }
}
