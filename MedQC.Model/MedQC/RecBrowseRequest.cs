using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 病历浏览申请记录
    /// </summary>
    public class RecBrowseRequest : DbTypeBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

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
        /// 申请人ID
        /// </summary>
        public string REQUEST_ID { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string REQUEST_NAME { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime REQUEST_TIME { get; set; }

        /// <summary>
        /// 审批人ID
        /// </summary>
        public string APPROVAL_ID { get; set; }

        /// <summary>
        /// 审批人姓名
        /// </summary>
        public string APPROVAL_NAME { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime APPROVAL_TIME { get; set; }

        /// <summary>
        /// 申请状态，0：未通过 1：审批通过
        /// </summary>
        public decimal STATUS { get; set; }

        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DISCHARGE_TIME { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK { get; set; }


        public RecBrowseRequest()
        {
            this.DISCHARGE_TIME = base.DefaultTime;
            this.REQUEST_TIME = base.DefaultTime;
            this.APPROVAL_TIME = base.DefaultTime;
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
