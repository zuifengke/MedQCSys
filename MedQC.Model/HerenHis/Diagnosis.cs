/***************************************************
 * 和仁HIS患者首页实体类
 * 作者：yehui
 * 时间：2017-06-05
 **************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.HerenHis
{
    /// <summary>
    /// 和仁his患者诊断信息
    /// </summary>
    public class Diagnosis : DbTypeBase
    {

        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 接诊号
        /// </summary>
        public string ENCOUNTER_NO { get; set; }
        /// <summary>
        /// 诊断类别
        /// </summary>
        public string DIAG_TYPE { get; set; }
        /// <summary>
        /// 诊断序号
        /// </summary>
        public decimal DIAG_NO { get; set; }
        /// <summary>
        /// 诊断描述
        /// </summary>
        public string DIAG_DESC { get; set; }
        /// <summary>
        /// 诊断日期
        /// </summary>
        public DateTime DIAG_DATE { get; set; }
        /// <summary>
        /// 治疗天数
        /// </summary>
        public decimal TREAT_DAYS { get; set; }
        /// <summary>
        /// 治疗结果
        /// </summary>
        public string TREAT_RESULT { get; set; }
        /// <summary>
        /// 诊断次序
        /// </summary>
        public decimal DIAGNOSIS_SORT { get; set; }
        /// <summary>
        /// 确诊标志
        /// </summary>
        public decimal DIAG_INDICATOR { get; set; }
        /// <summary>
        /// 慢病标识
        /// </summary>
        public decimal CHRONIC_DISEASE { get; set; }
        /// <summary>
        /// 诊断医师名称
        /// </summary>
        public string DIAG_DOCTOR { get; set; }
        /// <summary>
        /// 诊断医师编码
        /// </summary>
        public string DIAG_DOCTOR_ID { get; set; }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public decimal CLINIC_CATE { get; set; }
        /// <summary>
        /// 手术治疗标志
        /// </summary>
        public decimal OPER_TREAT_INDICATOR { get; set; }

    }
}
