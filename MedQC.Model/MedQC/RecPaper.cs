using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 纸质病历信息
    /// </summary>
    public class RecPaper : DbTypeBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string PAPER_ID { get; set; }
        /// <summary>
        /// 病历ID
        /// </summary>
        public string DOC_ID { get; set; }
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
        /// 翻拍正面
        /// </summary>
        public  string IMAGE_FRONTAGE { get; set; }
        /// <summary>
        /// 翻拍反面
        /// </summary>
        public  string IMAGE_OPPOSITE { get; set; }
        /// <summary>
        /// 纸质病历接收状态 0:未接收 1:已确认接收
        /// </summary>
        public int PAPER_STATE { get; set; }
        /// <summary>
        /// 逐份接收人ID
        /// </summary>
        public  string RECEIVE_ID { get; set; }
        /// <summary>
        /// 逐份接收人姓名
        /// </summary>
        public  string RECEIVE_NAME { get; set; }
        /// <summary>
        /// 翻拍操作人id
        /// </summary>
        public  string OPERATOR_ID { get; set; }
        /// <summary>
        /// 翻拍操作人姓名
        /// </summary>
        public  string OPERATOR_NAME { get; set; }
        public RecPaper()
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
