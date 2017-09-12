using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 手术记录
    /// </summary>
    public class Operation : DbTypeBase
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次
        /// </summary>
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PATIENT_NAME { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public string PATIENT_SEX { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo { get; set; }
        /// <summary>
        /// 二助
        /// </summary>
        public string SECOND_ASSISTANT { get; set; }
        
        public string Sex { get; set; }
        public string Diagnosis { get; set; }
        public string DeptName { get; set; }
        /// <summary>
        /// 一助
        /// </summary>
        public string FIRST_ASSISTANT { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DEPT_CODE { get; set; }
        public int OPERATION_NO { get; set; }
        public string Age { get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string OPERATION_DESC { get; set; }
        /// <summary>
        /// 手术代码
        /// </summary>
        public string OPERATION_CODE { get; set; }
        /// <summary>
        /// 愈合情况
        /// </summary>
        public string HEAL { get; set; }
        /// <summary>
        /// 切口等级
        /// </summary>
        public string WOUND_GRADE { get; set; }
        /// <summary>
        /// 手术级别
        /// </summary>
        public string OPERATION_SCALE { get; set; }
        public DateTime OPERATING_DATE { get; set; }
        public string ANAESTHESIA_METHOD { get; set; }
        public string OPERATOR { get; set; }
        public string ANESTHESIA_DOCTOR { get; set; }

    }
}
