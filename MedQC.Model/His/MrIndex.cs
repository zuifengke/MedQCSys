using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 新系统科室字典
    /// </summary>
    public class MrIndex : DbTypeBase
    {
        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 就诊号
        /// </summary>
        public string VISIT_ID{ get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 病案状态
        /// </summary>
        public string MR_STATUS { get; set; }
        /// <summary>
        /// 病案类别
        /// </summary>
        public string MR_CLASS{ get; set; }
        /// <summary>
        /// 提交医生ID
        /// </summary>
        public string SUBMIT_DOCTOR_ID { get; set; }
    }
}
