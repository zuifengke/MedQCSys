using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public class ExamMaster : DbTypeBase
    {
        /// <summary>
        /// 病人标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 本次住院标识
        /// </summary>
        public  string VISIT_ID { get; set; }
        /// <summary>
        /// 申请序号
        /// </summary>
        public  string EXAM_ID { get; set; }
        /// <summary>
        /// 检查类别
        /// </summary>
        public  string SUBJECT { get; set; }
        /// <summary>
        /// 申请日期
        /// </summary>
        public  DateTime REQUEST_TIME { get; set; }
        /// <summary>
        /// 申请医生
        /// </summary>
        public  string REQUEST_DOCTOR { get; set; }
        /// <summary>
        /// 报告状态
        /// </summary>
        public  string RESULT_STATUS { get; set; }
        /// <summary>
        /// 报告日期
        /// </summary>
        public  DateTime REPORT_TIME { get; set; }
        /// <summary>
        /// 报告人
        /// </summary>
        public  string REPORT_DOCTOR { get; set; }
        public  ExamMaster()
        {
            this.REQUEST_TIME = this.DefaultTime;
            this.REPORT_TIME = this.DefaultTime;
        }
    }
}
