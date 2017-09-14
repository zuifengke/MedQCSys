using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 患者诊断信息类
    /// </summary>
    [System.Serializable]
    public class Diagnosis : DbTypeBase
    {
        /// <summary>
        /// 获取或设置病人ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 获取或设置就诊ID
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 获取或设置就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 获取或设置诊断类型
        /// </summary>
        public string DIAGNOSIS_TYPE { get; set; }
        /// <summary>
        /// 获取或设置就诊类型名称
        /// </summary>
        public string DIAGNOSIS_TYPE_NAME { get; set; }
        /// <summary>
        /// 获取或设置诊断编号
        /// </summary>
        public int DIAGNOSIS_NO { get; set; }
        /// <summary>
        /// 获取或设置就诊描述
        /// </summary>
        public string DIAGNOSIS_DESC { get; set; }
        /// <summary>
        /// 获取或设置就诊日期
        /// </summary>
        public DateTime DIAGNOSIS_DATE { get; set; }
        /// <summary>
        /// 获取或设置治疗结果
        /// </summary>
        public string TREAT_RESULT { get; set; }
        /// <summary>
        /// 治疗天数
        /// </summary>
        public decimal TREAT_DAYS { get; set; }
        /// <summary>
        /// 诊断代码
        /// </summary>
        public string DIAGNOSIS_CODE { get; set; }
        /// <summary>
        /// 0：确诊诊断，1疑似诊断
        /// </summary>
        public decimal DIAG_INDICATOR { get; set; }

    }
}
