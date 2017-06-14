
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 住院费用情况
        /// </summary>
        public struct InpBillDetailTable
        {
            /// <summary>
            /// 明细编号
            /// </summary>
            public const string DETAIL_NO = "DETAIL_NO";
            /// <summary>
            /// 医嘱费用项目编号
            /// </summary>
            public const string COSTS_NO = "COSTS_NO";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 单据号
            /// </summary>
            public const string RECIPE_NO = "RECIPE_NO";
            /// <summary>
            /// 医嘱ID
            /// </summary>
            public const string ORDER_ID = "ORDER_ID";
            /// <summary>
            /// 申请单项目号
            /// </summary>
            public const string APPLY_ITEM_NO = "APPLY_ITEM_NO";
            /// <summary>
            /// 医嘱组号
            /// </summary>
            public const string GROUP_NO = "GROUP_NO";
            /// <summary>
            /// 医嘱组子号
            /// </summary>
            public const string GROUP_SUB_NO = "GROUP_SUB_NO";
            /// <summary>
            /// 价表项目分类
            /// </summary>
            public const string ITEM_CLASS = "ITEM_CLASS";
            /// <summary>
            /// 项目编码
            /// </summary>
            public const string ITEM_ID = "ITEM_ID";
            /// <summary>
            /// 项目代码
            /// </summary>
            public const string ITEM_CODE = "ITEM_CODE";
            /// <summary>
            /// 项目名称
            /// </summary>
            public const string ITEM_NAME = "ITEM_NAME";
            /// <summary>
            /// 项目规格
            /// </summary>
            public const string ITEM_SPEC = "ITEM_SPEC";
            /// <summary>
            /// 厂商编码
            /// </summary>
            public const string FIRM_ID = "FIRM_ID";
            /// <summary>
            /// 项目单价
            /// </summary>
            public const string PRICE = "PRICE";
            /// <summary>
            /// 项目应收单价
            /// </summary>
            public const string CHARGE_PRICE = "CHARGE_PRICE";
            /// <summary>
            /// 付数
            /// </summary>
            public const string REPETITION = "REPETITION";
            /// <summary>
            /// 数量
            /// </summary>
            public const string AMOUNT = "AMOUNT";
            /// <summary>
            /// 单位
            /// </summary>
            public const string UNITS = "UNITS";
            /// <summary>
            /// 业务实际时间
            /// </summary>
            public const string ORDERED_DATE = "ORDERED_DATE";
            /// <summary>
            /// 费用合计
            /// </summary>
            public const string COSTS = "COSTS";
            /// <summary>
            /// 应收费用
            /// </summary>
            public const string CHARGES = "CHARGES";
            /// <summary>
            /// 开单科室
            /// </summary>
            public const string ORDERED_BY_DEPT = "ORDERED_BY_DEPT";
            /// <summary>
            /// 开单人员编号
            /// </summary>
            public const string ORDERED_EMP_ID = "ORDERED_EMP_ID";
            /// <summary>
            /// 执行科室
            /// </summary>
            public const string PERFORMED_BY = "PERFORMED_BY";
            /// <summary>
            /// 对应的收据费用分类
            /// </summary>
            public const string CLASS_ON_OUTP_RCPT = "CLASS_ON_OUTP_RCPT";
            /// <summary>
            /// 对应的住院收据费用分类
            /// </summary>
            public const string CLASS_ON_INP_RCPT = "CLASS_ON_INP_RCPT";
            /// <summary>
            /// 对应的会计科目
            /// </summary>
            public const string SUBJ_CODE = "SUBJ_CODE";
            /// <summary>
            /// 对应的病案首页费用分类
            /// </summary>
            public const string CLASS_ON_MR = "CLASS_ON_MR";
            /// <summary>
            /// 执行数量
            /// </summary>
            public const string AMOUNT_EXEC = "AMOUNT_EXEC";
            /// <summary>
            /// 结算号
            /// </summary>
            public const string SETTLE_NO = "SETTLE_NO";
            /// <summary>
            /// 对应退费明细编号
            /// </summary>
            public const string RETURN_DETAIL_NO = "RETURN_DETAIL_NO";
            /// <summary>
            /// 录入时间
            /// </summary>
            public const string ENTER_DATE = "ENTER_DATE";
            /// <summary>
            /// 录入人员
            /// </summary>
            public const string OPERATOR_ID = "OPERATOR_ID";
            /// <summary>
            /// 累计已退费数量
            /// </summary>
            public const string AMOUNT_RETURN = "AMOUNT_RETURN";

        }
    }
}
