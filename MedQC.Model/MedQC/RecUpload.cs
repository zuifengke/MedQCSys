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
        /// 状态 0:未上传 1已上传
        /// </summary>
        public  int STATUS { get; set; }
        public RecUpload()
        {
           
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
