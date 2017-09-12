using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 转科记录
    /// </summary>
    public class Transfer : DbTypeBase
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 就诊次
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 所在科室代码
        /// </summary>
        public string DEPT_STAYED { get; set; }
        /// <summary>
        /// 入科时间
        /// </summary>
        public DateTime ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO { get; set; }
        /// <summary>
        /// 床标号
        /// </summary>
        public string BED_LABEL { get; set; }
        /// <summary>
        /// 出科时间
        /// </summary>
        public DateTime DISCHARGE_DATE_TIME { get; set; }
        /// <summary>
        /// 转向科室代码
        /// </summary>
        public string DEPT_TRANSFER_TO { get; set; }
        /// <summary>
        /// 经治医生ID
        /// </summary>
        public string CHARGER_DOCTOR_ID { get; set; }
        /// <summary>
        /// 经治医生姓名
        /// </summary>
        public string CHARGER_DOCTOR_NAME { get; set; }
        /// <summary>
        /// 医疗组编号
        /// </summary>
        public string MEDICAL_GROUP_NO { get; set; }
        /// <summary>
        /// 医疗组名称
        /// </summary>
        public string MEDICAL_GROUP_NAME { get; set; }
        public Transfer() {
            this.ADMISSION_DATE_TIME = this.DefaultTime;
            this.DISCHARGE_DATE_TIME = this.DefaultTime;
        }
    }
}
