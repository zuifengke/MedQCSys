
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 诊断对照记录
    /// </summary>
    public class DiagComparing : DbTypeBase
    {
        /// <summary>
        /// 病人标识
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }

        /// <summary>
        /// 诊断对照组
        /// </summary>
        public string DIAG_COMPARE_GROUP_CODE { get; set; }

        /// <summary>
        /// 诊断符合情况
        /// </summary>
        public string DIAG_CORRESPONDENCE { get; set; }

    }
}
