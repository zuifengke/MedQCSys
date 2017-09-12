using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 纸质病历信息
    /// </summary>
    public class RecPack : DbTypeBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string PACK_ID { get; set; }
        /// <summary>
        /// 包号
        /// </summary>
        public string PACK_NO { get; set; }
        /// <summary>
        /// 病案号
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
        /// 患者姓名
        /// </summary>
        public string PATIENT_NAME { get; set; }
        /// <summary>
        /// 患者出院时间
        /// </summary>
        public DateTime DISCHARGE_TIME { get; set; }
        /// <summary>
        /// 张数
        /// </summary>
        public int PAPER_NUMBER { get; set; }
        /// <summary>
        /// 打包人
        /// </summary>
        public string PACKER { get; set; }
        /// <summary>
        /// 打包人ID
        /// </summary>
        public string PACKER_ID { get; set; }
        /// <summary>
        /// 打包时间
        /// </summary>
        public DateTime PACK_TIME { get; set; }
        /// <summary>
        /// 院区
        /// </summary>
        public string HOSPITAL_DISTRICT { get; set; }
        /// <summary>
        /// 箱号
        /// </summary>
        public string CASE_NO { get; set; }
        public RecPack()
        {
            this.DISCHARGE_TIME = base.DefaultTime;
            this.PACK_TIME = base.DefaultTime;
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
