using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 病案上传
    /// </summary>
    public class RecUpload : DbTypeBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string UPLOAD_ID { get; set; }
        /// <summary>
        /// 病历ID
        /// </summary>
        public  string PATIENT_ID { get; set; }
        /// <summary>
        /// 入院次
        /// </summary>
        public  string VISIT_ID { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public  string VISIT_NO { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public  string PATIENT_NAME { get; set; }
        /// <summary>
        /// 上传日志
        /// </summary>
        public string UPLOAD_LOG { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UPLOAD_TIME { get; set; }
        /// <summary>
        /// 状态 0:未上传 1已上传
        /// </summary>
        public  int UPLOAD_STATUS { get; set; }
        /// <summary>
        /// 患者诊断
        /// </summary>
        public string Diagnosis { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string PatientSex { get; set; }
        /// <summary>
        /// 就诊时间
        /// </summary>
        public DateTime VisitTime { get; set; }
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DischargeTime { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 责任医生
        /// </summary>
        public string InchargeDoctor { get; set; }

        public RecUpload()
        {
            this.DischargeTime = base.DefaultTime;
            this.UPLOAD_TIME = base.DefaultTime;
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
