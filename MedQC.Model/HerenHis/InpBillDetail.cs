using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.HerenHis
{
    /// <summary>
    /// 费用表
    /// </summary>
    public class InpBillDetail : DbTypeBase
    {
        /// <summary>
        /// 明细编号
        /// </summary>
        public string DETAIL_NO { get; set; }

        /// <summary>
        /// 医嘱费用项目编号
        /// </summary>
        public string COSTS_NO { get; set; }

        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }

        /// <summary>
        /// 病人标识
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
        public string RECIPE_NO { get; set; }

        /// <summary>
        /// 医嘱ID
        /// </summary>
        public string ORDER_ID { get; set; }

        /// <summary>
        /// 申请单项目号
        /// </summary>
        public decimal APPLY_ITEM_NO { get; set; }

        /// <summary>
        /// 医嘱组号
        /// </summary>
        public string GROUP_NO { get; set; }

        /// <summary>
        /// 医嘱组子号
        /// </summary>
        public decimal GROUP_SUB_NO { get; set; }

        /// <summary>
        /// 价表项目分类
        /// </summary>
        public string ITEM_CLASS { get; set; }

        /// <summary>
        /// 项目编码
        /// </summary>
        public string ITEM_ID { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        public string ITEM_CODE { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }

        /// <summary>
        /// 项目规格
        /// </summary>
        public string ITEM_SPEC { get; set; }

        /// <summary>
        /// 厂商编码
        /// </summary>
        public string FIRM_ID { get; set; }

        /// <summary>
        /// 项目单价
        /// </summary>
        public decimal PRICE { get; set; }

        /// <summary>
        /// 项目应收单价
        /// </summary>
        public decimal CHARGE_PRICE { get; set; }

        /// <summary>
        /// 付数
        /// </summary>
        public decimal REPETITION { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal AMOUNT { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string UNITS { get; set; }

        /// <summary>
        /// 业务实际时间
        /// </summary>
        public DateTime ORDERED_DATE { get; set; }

        /// <summary>
        /// 费用合计
        /// </summary>
        public decimal COSTS { get; set; }

        /// <summary>
        /// 应收费用
        /// </summary>
        public decimal CHARGES { get; set; }

        /// <summary>
        /// 开单科室
        /// </summary>
        public string ORDERED_BY_DEPT { get; set; }

        /// <summary>
        /// 开单人员编号
        /// </summary>
        public string ORDERED_EMP_ID { get; set; }

        /// <summary>
        /// 执行科室
        /// </summary>
        public string PERFORMED_BY { get; set; }

        /// <summary>
        /// 对应的收据费用分类
        /// </summary>
        public string CLASS_ON_OUTP_RCPT { get; set; }

        /// <summary>
        /// 对应的住院收据费用分类
        /// </summary>
        public string CLASS_ON_INP_RCPT { get; set; }

        /// <summary>
        /// 对应的会计科目
        /// </summary>
        public string SUBJ_CODE { get; set; }

        /// <summary>
        /// 对应的病案首页费用分类
        /// </summary>
        public string CLASS_ON_MR { get; set; }

        /// <summary>
        /// 执行数量
        /// </summary>
        public decimal AMOUNT_EXEC { get; set; }

        /// <summary>
        /// 结算号
        /// </summary>
        public string SETTLE_NO { get; set; }

        /// <summary>
        /// 对应退费明细编号
        /// </summary>
        public string RETURN_DETAIL_NO { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime ENTER_DATE { get; set; }

        /// <summary>
        /// 录入人员
        /// </summary>
        public string OPERATOR_ID { get; set; }

        /// <summary>
        /// 累计已退费数量
        /// </summary>
        public decimal AMOUNT_RETURN { get; set; }



    }
}
