
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 病案索引补充表
    /// </summary>
    public class QcMrIndex:DbTypeBase
    {
        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 提交医生ID
        /// </summary>
        public string SUBMIT_DOCTOR_ID { get; set; }
        /// <summary>
        /// 提交医生姓名
        /// </summary>
        public string SUBMIT_DOCTOR { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SUBMIT_TIME { get; set; }
        /// <summary>
        /// 归档时间
        /// </summary>
        public DateTime ARCHIVE_TIME { get; set; }
        /// <summary>
        /// 归档医生
        /// </summary>
        public string ARCHIVE_DOCTOR { get; set; }
        /// <summary>
        /// 归档医生ID
        /// </summary>
        public string ARCHIVE_DOCTOR_ID { get; set; }
        /// <summary>
        /// 退回次数
        /// </summary>
        public int RETURN_COUNT { get; set; }
        /// <summary>
        /// 纸质接收 0-未发送 1-已发送 2-已接收
        /// </summary>
        public int PAPER_RECEIVE { get; set; }
        public QcMrIndex(){
            this.ARCHIVE_TIME = this.DefaultTime;
            this.SUBMIT_TIME = this.DefaultTime;
        }
        public QcMrIndex(MrArchive mrArchive)
        {
            if (mrArchive == null)
                return;
            this.ARCHIVE_DOCTOR = mrArchive.ARCHIVE_DOCTOR;
            this.ARCHIVE_DOCTOR_ID = mrArchive.ARCHIVE_DOCTOR_ID;
            this.ARCHIVE_TIME = mrArchive.ARCHIVE_TIME;
            this.PAPER_RECEIVE = mrArchive.PAPER_RECEIVE;
            this.PATIENT_ID = mrArchive.PATIENT_ID;
            this.RETURN_COUNT = mrArchive.RETURN_COUNT;
            this.SUBMIT_DOCTOR = mrArchive.SUBMIT_DOCTOR;
            this.SUBMIT_DOCTOR_ID = mrArchive.SUBMIT_DOCTOR_ID;
            this.SUBMIT_TIME = mrArchive.SUBMIT_TIME;
            this.VISIT_ID = mrArchive.VISIT_ID;
            this.VISIT_NO = mrArchive.VISIT_NO;
        }
    }
}
