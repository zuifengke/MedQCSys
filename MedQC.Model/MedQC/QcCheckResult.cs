using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 自动核查缺陷结果类
    /// </summary>
    public class QcCheckResult : DbTypeBase
    {
        /// <summary>
        /// 主键序号
        /// </summary>
        public string CHECK_RESULT_ID { get; set; }
        /// <summary>
        /// 质控规则ID,有编号
        /// </summary>
        public string CHECK_POINT_ID { get; set; }
        /// <summary>
        /// 缺陷点内容
        /// </summary>
        public string MSG_DICT_MESSAGE { get; set; }
        /// <summary>
        /// 缺陷点代码
        /// </summary>
        public string MSG_DICT_CODE { get; set; }
        /// <summary>
        /// 责任科室代码
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 质控结果 1:通过 0：不通过
        /// </summary>
        public int QC_RESULT { get; set; }

        /// <summary>
        /// 病案号
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PATIENT_NAME { get; set; }
        /// <summary>
        /// 就诊次
        /// </summary>
        public string VISIT_ID { get; set; }
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int ORDER_VALUE { get; set; }
        /// <summary>
        /// 文档类型号
        /// </summary>
        public string DOCTYPE_ID { get; set; }
        /// <summary>
        /// 扣分值
        /// </summary>
        public float SCORE { get; set; }
        /// <summary>
        /// 检查者
        /// </summary>
        public string CHECKER_NAME { get; set; }
        /// <summary>
        /// 检查者ID
        /// </summary>
        public string CHECKER_ID { get; set; }
        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime CHECK_DATE { get; set; }
        /// <summary>
        /// 文档id号
        /// </summary>
        public string DOC_SETID { get; set; }
        /// <summary>
        /// 文档标题
        /// </summary>
        public string DOC_TITLE { get; set; }
        /// <summary>
        /// 文书最近的修改时间
        /// </summary>
        public DateTime MODIFY_TIME { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public string CREATE_ID { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string CREATE_NAME { get; set; }
        /// <summary> 
        /// 创建时间
        /// </summary>
        public DateTime DOC_TIME { get; set; }
        /// <summary>
        /// 检查类型：时效性 完整性 一致性 合理性 周期性
        /// </summary>
        public string CHECK_TYPE { get; set; }
        /// <summary>
        /// 错误级别 0 警告;1 错误
        /// </summary>
        public int BUG_CLASS { get; set; }
        /// <summary>
        /// 错误次数
        /// </summary>
        public int ERROR_COUNT { get; set; }
        /// <summary>
        /// 系统自动检查，给出的错误描述
        /// </summary>
        public string QC_EXPLAIN { get; set; }
        /// <summary>
        /// 责任医生
        /// </summary>
        public string INCHARGE_DOCTOR { get; set; }
        /// <summary>
        /// 责任医生ID
        /// </summary>
        public string INCHARGE_DOCTOR_ID { get; set; }
        /// <summary>
        /// 责任科室
        /// </summary>
        public string DEPT_IN_CHARGE { get; set; }
        /// <summary>
        /// 内容分类
        /// </summary>
        public string QA_EVENT_TYPE { get; set; }
        /// <summary>
        /// 病案状态 O-工作C-关闭 A-归档
        /// </summary>
        public string MR_STATUS { get; set; }
        /// <summary>
        /// 统计类型： 0-系统检查、1-人工检查
        /// </summary>
        public int STAT_TYPE { get; set; }
        /// <summary>
        /// 是否为单项否决 0:否;1:是
        /// </summary>
        public bool ISVETO { get; set; }
        /// <summary>
        /// 备注，质控人工检查时填写
        /// </summary>
        public string REMARKS { get; set; }
        /// <summary>
        /// 人工质控结果生成对应的质检反馈消息
        /// </summary>
        public string MSG_ID { get; set; }
        /// <summary>
        /// 通知单ID
        /// </summary>
        public string MODIFY_NOTICE_ID { get; set; }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
        public QcCheckResult()
        {
            CHECK_DATE = base.DefaultTime;
            MODIFY_TIME = base.DefaultTime;
            DOC_TIME = base.DefaultTime;
        }

    }
}
