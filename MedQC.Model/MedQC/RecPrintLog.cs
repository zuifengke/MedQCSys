using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 病案复印记录表
    /// </summary>
    public class RecPrintLog : DbTypeBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string PRINT_ID { get; set; }
        /// <summary>
        /// 病案号
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
        public string PATIENT_NAME { get; set; }
        /// <summary>
        /// 患者身份证
        /// </summary>
        public string PATIENT_ID_NO { get; set; }
        /// <summary>
        /// 复印人姓名
        /// </summary>
        public string PRINT_NAME { get; set; }
        /// <summary>
        /// 复印人身份证
        /// </summary>
        public string PRINT_ID_NO { get; set; }
        /// <summary>
        /// 与患者关系
        /// </summary>
        public string RELATIONSHIP_PATIENT { get; set; }
        /// <summary>
        /// 打印内容
        /// </summary>
        public string PRINT_CONTENT { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARKS { get; set; }
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DISCHARGE_TIME { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public float MONEY { get; set; }
        /// <summary>
        /// 是否开发票
        /// </summary>
        public bool INVOICE { get; set; }
        /// <summary>
        /// 复印时间
        /// </summary>
        public DateTime PRINT_TIME { get; set; }
        public RecPrintLog()
        {
            this.DISCHARGE_TIME = base.DefaultTime;
            this.PRINT_TIME = base.DefaultTime;
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
