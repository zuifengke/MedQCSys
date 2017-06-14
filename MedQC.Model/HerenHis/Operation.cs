using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.HerenHis
{
    /// <summary>
    /// 新系统手术记录
    /// </summary>
    public class Operation : DbTypeBase
    {
        /// <summary>
        /// 病人标识号
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
        /// 手术序号
        /// </summary>
        public decimal OPERATION_NO { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_DESC { get; set; }
        /// <summary>
        /// 手术编码
        /// </summary>
        public string OPERATION_CODE { get; set; }
        /// <summary>
        /// 编码体系
        /// </summary>
        public string CODE_VERSION { get; set; }
        /// <summary>
        /// 切口等级
        /// </summary>
        public string WOUND_GRADE { get; set; }
        /// <summary>
        /// 切口愈合情况
        /// </summary>
        public string HEAL { get; set; }
        /// <summary>
        /// 手术日期
        /// </summary>
        public DateTime OPERATING_DATE { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANAESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 手术医师
        /// </summary>
        public string OPERATOR { get; set; }
        /// <summary>
        /// 第一手术助手
        /// </summary>
        public string FIRST_ASSISTANT { get; set; }
        /// <summary>
        /// 第二手术助手
        /// </summary>
        public string SECOND_ASSISTANT { get; set; }
        /// <summary>
        /// 麻醉医师
        /// </summary>
        public string ANAESTHESIA_DOCTOR { get; set; }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public decimal CLINIC_CATE { get; set; }
    }
}
