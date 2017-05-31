using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 病案评分信息类
    /// </summary>
    public class QCScore : DbTypeBase
    {
        /// <summary>
        /// 获取或设置病人ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        //患者姓名
        public string PATIENT_NAME { get; set; }
        /// <summary>
        /// 获取或设置就诊ID
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 获取或设置就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 获取或设置病历等级
        /// </summary>
        public string DOC_LEVEL { get; set; }
        /// <summary>
        /// 获取或设置院评分数
        /// </summary>
        public float HOS_ASSESS { get; set; }
        /// <summary>
        /// 获取或设置院评日期
        /// </summary>
        public DateTime HOS_DATE { get; set; }
        /// <summary>
        /// 获取或设置院评质控人
        /// </summary>
        public string HOS_QCMAN { get; set; }
        /// <summary>
        /// 院评质控员ID
        /// </summary>
        public string HOS_QCMAN_ID { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public string SUBMIT_DOCTOR_ID { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string SUBMIT_DOCTOR { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 科室
        /// </summary>
        public DateTime DischargeTime { get; set; }
        public QCScore() {
            this.VISIT_NO = string.Empty;
            this.DOC_LEVEL = string.Empty;
            this.HOS_ASSESS = 100;
            this.DischargeTime = base.DefaultTime;
        }
        
    }
}
