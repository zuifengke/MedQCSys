using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 纸质病历批次发送信息
    /// </summary>
    public class RecMrBatch : DbTypeBase
    {
        /// <summary>
        /// 批次号
        /// </summary>
        public string BATCH_NO { get; set; }
        /// <summary>
        /// 住院号集合
        /// </summary>
        public string INP_NOS { get; set; }
        /// <summary>
        /// 张数
        /// </summary>
        public int PAPER_COUNT { get; set; }
        /// <summary>
        /// 病案份数
        /// </summary>
        public int MR_COUNT { get; set; }
        /// <summary>
        /// 发送科室名称
        /// </summary>
        public string SEND_DEPT_NAME { get; set; }
        /// <summary>
        /// 发送医生姓名
        /// </summary>
        public string SEND_DOCTOR_NAME { get; set; }
        /// <summary>
        /// 发送人登录账号
        /// </summary>
        public  string SEND_DOCTOR_ID { get; set; }
        /// <summary>
        /// 发送科室代码
        /// </summary>
        public  string SEND_DEPT_CODE { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SEND_TIME { get; set; }
        /// <summary>
        /// 工人工号
        /// </summary>
        public  string WORKER_ID { get; set; }
        /// <summary>
        /// 工人姓名
        /// </summary>
        public  string WORKER_NAME { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public  string REMARK { get; set; }
        /// <summary>
        /// 接受科室名称
        /// </summary>
        public  string RECEIVE_DEPT_NAME { get; set; }
        /// <summary>
        /// 接收科室代码
        /// </summary>
        public  string RECEIVE_DEPT_CODE { get; set; }
        /// <summary>
        /// 接收人登录账号
        /// </summary>
        public  string RECEIVE_DOCTOR_ID { get; set; }
        /// <summary>
        /// 接收人姓名
        /// </summary>
        public  string RECEIVE_DOCTOR_NAME { get; set; }
        /// <summary>
        /// 就诊流水号集合 以字符 | 隔开
        /// </summary>
        public  string VISIT_NOS { get; set; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public  DateTime RECEIVE_TIME { get; set; }
        public RecMrBatch()
        {
            this.RECEIVE_TIME = this.DefaultTime;
            this.SEND_TIME = this.DefaultTime;
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
        public string MakeBatchNo(string szDeptCode)
        {
            return string.Format("{0}_{1}", szDeptCode, DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}
