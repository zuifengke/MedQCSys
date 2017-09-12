using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public class LabMaster : DbTypeBase
    {
        /// <summary>
        /// 病人标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 本次住院标识
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 申请序号
        /// </summary>
        public string TEST_ID { get; set; }
        /// <summary>
        /// 检验主题
        /// </summary>
        public string SUBJECT { get; set; }
        /// <summary>
        /// 检验标本
        /// </summary>
        public string SPECIMEN { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime REQUEST_TIME { get; set; }
        /// <summary>
        /// 申请医生
        /// </summary>
        public string REQUEST_DOCTOR { get; set; }
        /// <summary>
        /// 报告状态
        /// </summary>
        public string RESULT_STATUS { get; set; }
        /// <summary>
        /// 报告时间
        /// </summary>
        public DateTime REPORT_TIME { get; set; }
        /// <summary>
        /// 报告医生
        /// </summary>
        public string REPORT_DOCTOR { get; set; }
        public LabMaster()
        {
            this.REQUEST_TIME = this.DefaultTime;
            this.REPORT_TIME = this.DefaultTime;
        }
    }
}
