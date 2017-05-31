using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 整改通知单信息
    /// </summary>
    public class QcModifyNotice : DbTypeBase
    {
        /// <summary>
        /// 整改通知单主键
        /// </summary>
        public string MODIFY_NOTICE_ID { get; set; }
        /// <summary>
        /// 整改通知时间
        /// </summary>
        public DateTime NOTICE_TIME { get; set; }
        /// <summary>
        /// 整改时间
        /// </summary>
        public DateTime MODIFY_TIME { get; set; }
        /// <summary>
        /// 质控人
        /// </summary>
        public string QC_MAN { get; set; }
        /// <summary>
        /// 质控人ID
        /// </summary>
        public string QC_MAN_ID { get; set; }
        /// <summary>
        /// 质控科室名称
        /// </summary>
        public string QC_DEPT_NAME { get; set; }
        /// <summary>
        /// 质控科室代码
        /// </summary>
        public string QC_DEPT_CODE { get; set; }
        /// <summary>
        /// 接收人
        /// </summary>
        public string RECEIVER { get; set; }
        /// <summary>
        /// 接收人ID
        /// </summary>
        public string RECEIVER_ID { get; set; }
        /// <summary>
        /// 接收人科室
        /// </summary>
        public string RECEIVER_DEPT_NAME { get; set; }
        /// <summary>
        /// 接收人科室代码
        /// </summary>
        public string RECEIVER_DEPT_CODE { get; set; }
        /// <summary>
        /// 通知单状态 0：草稿；1 已发送；
        /// </summary>
        public int NOTICE_STATUS { get; set; }
        /// <summary>
        /// 整改扣分
        /// </summary>
        public float MODIFY_SCORE { get; set; }
        /// <summary>
        /// 质控级别：0 环节质控；1 终末质控 ；2 专家质控 
        /// </summary>
        public int QC_LEVEL { get; set; }
        /// <summary>
        /// 整改期限
        /// </summary>
        public string MODIFY_PERIOD { get; set; }
        /// <summary>
        /// 患者病案号
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public  string PATIENT_NAME { get; set; }
        /// <summary>
        /// 患者入院次
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 患者就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 整改备注
        /// </summary>
        public string MODIFY_REMARK { get; set; }
        public QcModifyNotice()
        {
            this.NOTICE_STATUS = SystemData.NotifyStatus.Draft;
            this.MODIFY_TIME = this.DefaultTime;
            this.NOTICE_TIME = this.DefaultTime;
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
