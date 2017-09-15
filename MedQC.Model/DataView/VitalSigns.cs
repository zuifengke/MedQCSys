using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 体征记录
    /// </summary>
    public class VitalSigns : DbTypeBase
    {
        /// <summary>
        /// 病人标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 就诊次
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RECORDING_DATE { get; set; }
        /// <summary>
        /// 时间点
        /// </summary>
        public DateTime TIME_POINT { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string VITAL_SIGNS { get; set; }
        /// <summary>
        /// 项目值
        /// </summary>
        public decimal VITAL_SIGNS_VALUES { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO { get; set; }
    }
}
