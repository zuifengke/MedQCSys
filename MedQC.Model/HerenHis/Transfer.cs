using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.HerenHis
{
    /// <summary>
    /// 和仁his患者转科记录
    /// </summary>
    public class Transfer : DbTypeBase
    {

        /// <summary>
        /// 记录ID
        /// </summary>
        public decimal RECORD_ID { get; set; }
        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 所在科室
        /// </summary>
        public string DEPT_STAYED { get; set; }
        /// <summary>
        /// 所在护理单元
        /// </summary>
        public string WARD_CODE { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public decimal BED_NO { get; set; }
        /// <summary>
        /// 床标号
        /// </summary>
        public string BED_LABEL { get; set; }
        /// <summary>
        /// 入科日期及时间
        /// </summary>
        public DateTime ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 入科操作人ID
        /// </summary>
        public string ADMISSION_OPERATOR_ID { get; set; }
        /// <summary>
        /// 入科操作人
        /// </summary>
        public string ADMISSION_OPERATOR_NAME { get; set; }
        /// <summary>
        /// 出科日期及时间
        /// </summary>
        public DateTime DISCHARGE_DATE_TIME { get; set; }
        /// <summary>
        /// 出科操作人ID
        /// </summary>
        public string DISCHARGE_OPERATOR_ID { get; set; }
        /// <summary>
        /// 出科操作人
        /// </summary>
        public string DISCHARGE_OPERATOR_NAME { get; set; }
        /// <summary>
        /// 转向科室
        /// </summary>
        public string DEPT_TRANSFER_TO { get; set; }
        /// <summary>
        /// 转科原因
        /// </summary>
        public string TRANSFER_CAUSE { get; set; }
        /// <summary>
        /// 经治医师姓名
        /// </summary>
        public string CHARGER_DOCTOR_NAME { get; set; }
        /// <summary>
        /// 经治医师ID
        /// </summary>
        public string CHARGER_DOCTOR_ID { get; set; }
        /// <summary>
        /// 医疗组编码
        /// </summary>
        public string MEDICAL_GROUP_NO { get; set; }
        /// <summary>
        /// 操作员编码
        /// </summary>
        public string OPERATOR_ID { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OPERATOR_NAME { get; set; }
        /// <summary>
        /// 操作日期时间
        /// </summary>
        public DateTime OPERATE_DATE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO { get; set; }

    }
}
