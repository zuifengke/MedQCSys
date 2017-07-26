using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 质检问题类
    /// </summary>
    public class MedicalQcMsg : DbTypeBase
    {
        public string APPLY_ENV { get; set; }
        /// <summary>
        /// 获取或设置所在科室代码
        /// </summary>
        public string DEPT_STAYED { get; set; }

        /// <summary>
        /// 获取或设置所在科室名称
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 获取或设置患者的ID
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 获取或设置患者的姓名
        /// </summary>
        public string PATIENT_NAME { get; set; }
        /// <summary>
        /// 获取或设置患者的本次就诊ID
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 新军卫患者就诊流水号，其他his数据库和visit_id一样
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 获取或设置问题代码
        /// </summary>
        public string QC_MSG_CODE { get; set; }
        /// <summary>
        /// 获取或设置问题内容
        /// </summary>
        public string MESSAGE { get; set; }
        /// <summary>
        /// 获取或设置问题确认状态
        /// </summary>
        public int MSG_STATUS { get; set; }
        /// <summary>
        /// 获取或设置经治医生
        /// </summary>
        public string DOCTOR_IN_CHARGE { get; set; }
        /// <summary>
        /// 问题文档创建者账号
        /// </summary>
        public string CREATOR_ID { get; set; }
        /// <summary>
        /// 上级医生
        /// </summary>
        public string PARENT_DOCTOR { get; set; }
        /// <summary>
        /// 主任医生
        /// </summary>
        public string SUPER_DOCTOR { get; set; }
        /// <summary>
        /// 获取或设置质控检查者
        /// </summary>
        public string ISSUED_BY { get; set; }
        /// <summary>
        /// 获取或设置检查日期
        /// </summary>
        public DateTime ISSUED_DATE_TIME { get; set; }
        /// <summary>
        /// 获取或设置确认日期
        /// </summary>
        public DateTime ASK_DATE_TIME { get; set; }
        /// <summary>
        /// 获取或设置病案质控类型
        /// </summary>
        public string QC_MODULE { get; set; }
        /// <summary>
        /// 获取或设置病历主题代码
        /// </summary>
        public string TOPIC_ID { get; set; }
        /// <summary>
        /// 获取或设置病历主题
        /// </summary>
        public string TOPIC { get; set; }
        /// <summary>
        /// 获取或设置医生反馈信息
        /// </summary>
        public string DOCTOR_COMMENT { get; set; }
        /// <summary>
        /// 获取或设置扣分值
        /// </summary>
        public float POINT { get; set; }
        /// <summary>
        /// 扣分类型 0-自动扣分 1-手动输入扣分
        /// </summary>
        public int POINT_TYPE { get; set; }
        /// <summary>
        /// 添加问题时的病历状态(运行病历，终末病历)：0，在院病历，1，出院病历，2，死亡病历
        /// </summary>
        public int QCDOC_TYPE { get; set; }
        /// <summary>
        /// 添加问题者类型，0:普通医生，1专家医生
        /// </summary>
        public int ISSUED_TYPE { get; set; }
        /// <summary>
        /// 获取或设置问题大类的类型
        /// </summary>
        public string QA_EVENT_TYPE { get; set; }
        /// <summary>
        /// 主键质检问题ID
        /// </summary>
        public string MSG_ID { get; set; }
        /// <summary>
        /// 强制锁定状态，0：不锁定；1：锁定，医生必须修改问题才能创建病历
        /// </summary>
        public bool LOCK_STATUS { get; set; }
        /// <summary>
        /// 质检者ID
        /// </summary>
        public string ISSUED_ID { get; set; }
        /// <summary>
        /// 日志描述
        /// </summary>
        public string LogDesc { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        public string InpNo { get; set; }
        /// <summary>
        /// 诊断
        /// </summary>
        public string Diagnosis { get; set; }
        /// <summary>
        /// 整改通知书ID
        /// </summary>
        public string MODIFY_NOTICE_ID { get; set; }
        /// <summary>
        /// 错误次数
        /// </summary>
        public int ERROR_COUNT { get; set; }
        /// <summary>
        /// 病历ID号
        /// </summary>
        public string DOC_ID { get; set; }
        /// <summary>
        /// 责任医生ID
        /// </summary>
        public string DOCTOR_IN_CHARGE_ID { get; set; }

        public MedicalQcMsg()
        {
            this.ISSUED_DATE_TIME = this.DefaultTime;
            this.ASK_DATE_TIME = this.DefaultTime;
            this.DEPT_NAME = string.Empty;
            this.PATIENT_NAME = string.Empty;
            this.TOPIC_ID = string.Empty;
            this.DOC_ID = string.Empty;
            this.TOPIC = string.Empty;
            this.PARENT_DOCTOR = string.Empty;
            this.SUPER_DOCTOR = string.Empty;
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            this.MSG_ID = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
        public string GetMsgID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
