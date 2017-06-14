using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 新系统手术名称
    /// </summary>
    public class OperationName : DbTypeBase
    {
        /// <summary>
        /// 手术申请号
        /// </summary>
        public string OPER_NO { get; set; }
        /// <summary>
        /// 医嘱号
        /// </summary>
        public string ORDER_ID { get; set; }
        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 患者就诊流水标识
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 病人本次住院标识
        /// </summary>
        public decimal VISIT_ID { get; set; }
        /// <summary>
        /// 手术安排标识
        /// </summary>
        public decimal SCHEDULE_ID { get; set; }
        /// <summary>
        /// 手术序号
        /// </summary>
        public decimal OPERATION_NO { get; set; }
        /// <summary>
        /// 手术
        /// </summary>
        public string OPERATION { get; set; }
        /// <summary>
        /// 手术操作码
        /// </summary>
        public string OPERATION_CODE { get; set; }
        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPERATION_SCALE { get; set; }
        /// <summary>
        /// 切口等级
        /// </summary>
        public string WOUND_GRADE { get; set; }
    }
}
