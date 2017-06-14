using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 和仁新HIS过敏史
    /// </summary>
    public class PatientAllergy : DbTypeBase
    {
        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public decimal ALLERGY_NO { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 接诊号
        /// </summary>
        public string ENCOUNTER_NO { get; set; }
        /// <summary>
        /// 过敏原类型
        /// </summary>
        public string ALLERGY_TYPE { get; set; }
        /// <summary>
        /// 过敏原
        /// </summary>
        public string ALLERGEN { get; set; }
        /// <summary>
        /// 过敏程度 轻、中、重
        /// </summary>
        public string ALLERGEN_DEGREE { get; set; }
        /// <summary>
        /// 过敏症状
        /// </summary>
        public string ALLERGEN_SYMPTOM { get; set; }
        /// <summary>
        /// 当前状态 0：未治愈 1：治愈
        /// </summary>
        public decimal ALLERGEN_STATUS { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public string BEGIN_DATE { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string END_DATE { get; set; }
        /// <summary>
        /// 记录医师
        /// </summary>
        public string RECORD_DOCTOR { get; set; }
        /// <summary>
        /// 记录医师编码
        /// </summary>
        public string RECORD_DOCTOR_ID { get; set; }
        /// <summary>
        /// 记录日期
        /// </summary>
        public string RECORD_DATE { get; set; }
        /// <summary>
        /// 诊断医师编码
        /// </summary>
        public string DIAG_DOCTOR_ID { get; set; }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public decimal CLINIC_CATE { get; set; }
        /// <summary>
        /// 自述标识
        /// </summary>
        public decimal OWN_COMPLAINT_DISEASE { get; set; }
        /// <summary>
        /// 本院标识
        /// </summary>
        public decimal INHOSPITAL_DISEASE { get; set; }
        /// <summary>
        /// 过敏药物分类
        /// </summary>
        public string ALLERGEN_DRUG_CLASS { get; set; }
        /// <summary>
        /// 过敏药品编码
        /// </summary>
        public string ALLERGEN_DRUG_CODE { get; set; }
        /// <summary>
        /// 药品类型
        /// </summary>
        public decimal DRUG_TYPE { get; set; }
    }
}
