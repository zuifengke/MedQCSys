using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 整改通知单信息
    /// </summary>
    public class MrArchive : DbTypeBase
    {
        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PATIENT_NAME { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public string PATIENT_SEX { get; set; }
        /// <summary>
        /// 就诊号
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 新军卫就诊流水号，其他HIS库字段值和Visit_ID一样
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 病案状态 反映病案的存贮状态：O-工作C-关闭 A-归档 F-脱机(目前只使用工作，关闭两个状态，工作为正常病历在线的状态，关闭则为病历已提交的状态)
        /// </summary>
        public string MR_STATUS { get; set; }
        /// <summary>
        /// 病案类别
        /// </summary>
        public string MR_CLASS { get; set; }
        /// <summary>
        /// 出院科室代码
        /// </summary>
        public string DEPT_DISCHARGE_FROM { get; set; }
        /// <summary>
        /// 出院科室名称
        /// </summary>
        public string DEPT_DISCHARGE_NAME { get; set; }
        /// <summary>
        /// 出院时间
        /// </summary>
        public  DateTime DISCHARGE_DATE_TIME { get; set; }
        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 入院科室代码
        /// </summary>
        public string DEPT_ADMISSION_TO { get; set; }
        /// <summary>
        /// 入院科室名称
        /// </summary>
        public string DEPT_ADMISSION_NAME { get; set; }
        /// <summary>
        /// 提交医生ID
        /// </summary>
        public string SUBMIT_DOCTOR_ID { get; set; }
        /// <summary>
        /// 提交医生
        /// </summary>
        public string SUBMIT_DOCTOR { get; set; }
        /// <summary>
        /// 提交护士
        /// </summary>
        public string SUBMIT_NURSE { get; set; }
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
        /// <summary>
        /// 病案核对者
        /// </summary>
        public string HOS_QCMAN { get; set; }
        public MrArchive()
        {
            this.ARCHIVE_TIME = this.DefaultTime;
            this.SUBMIT_TIME = this.DefaultTime;
            this.ADMISSION_DATE_TIME = this.DefaultTime;
            this.DISCHARGE_DATE_TIME = this.DefaultTime;
        }

        public static implicit operator MrArchive(QcModifyNotice v)
        {
            throw new NotImplementedException();
        }
    }
}
