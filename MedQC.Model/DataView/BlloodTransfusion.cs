using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 手术操作字典
    /// </summary>
    public class BlloodTransfusion : DbTypeBase
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 就诊号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 全血
        /// </summary>
        public string WHOLE_BLOOD { get; set; }
        /// <summary>
        /// 红细胞悬液
        /// </summary>
        public string RED_CELL { get; set; }

    }
}
