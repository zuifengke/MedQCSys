using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 医生医嘱表字段定义
        /// </summary>
        public struct OrdersView
        {
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 医嘱序号
            /// </summary>
            public const string ORDER_NO = "ORDER_NO";
            /// <summary>
            /// 医嘱子序号
            /// </summary>
            public const string ORDER_SUB_NO = "ORDER_SUB_NO";
            /// <summary>
            /// 长期医嘱标志
            /// </summary>
            public const string REPEAT_INDICATOR = "REPEAT_INDICATOR";
            /// <summary>
            /// 医嘱类别
            /// </summary>
            public const string ORDER_CLASS = "ORDER_CLASS";
            /// <summary>
            /// 医嘱下达时间
            /// </summary>
            public const string ENTER_DATE_TIME = "ENTER_DATE_TIME";
            /// <summary>
            /// 医嘱内容
            /// </summary>
            public const string ORDER_TEXT = "ORDER_TEXT";
            /// <summary>
            /// 是否自带药
            /// </summary>
            public const string DRUG_BILLING_ATTR = "DRUG_BILLING_ATTR";
            /// <summary>
            /// 剂量
            /// </summary>
            public const string DOSAGE = "DOSAGE";
            /// <summary>
            /// 计量单位
            /// </summary>
            public const string DOSAGE_UNITS = "DOSAGE_UNITS";
            /// <summary>
            /// 途径
            /// </summary>
            public const string ADMINISTRATION = "ADMINISTRATION";
            /// <summary>
            /// 频次
            /// </summary>
            public const string FREQUENCY = "FREQUENCY";
            /// <summary>
            /// 医生说明
            /// </summary>
            public const string FREQ_DETAIL = "FREQ_DETAIL";
            /// <summary>
            /// 带药量
            /// </summary>
            public const string PACK_COUNT = "PACK_COUNT";
            /// <summary>
            /// 医嘱停止时间
            /// </summary>
            public const string END_DATE_TIME = "END_DATE_TIME";
            /// <summary>
            /// 医生
            /// </summary>
            public const string DOCTOR = "DOCTOR";
            /// <summary>
            /// 护士
            /// </summary>
            public const string NURSE = "NURSE";
            /// <summary>
            /// 新开停止医嘱标志
            /// </summary>
            public const string START_STOP_INDICATOR = "START_STOP_INDICATOR";
            /// <summary>
            /// 医嘱状态
            /// </summary>
            public const string ORDER_STATUS = "ORDER_STATUS";
            /// <summary>
            /// 医嘱标识
            /// </summary>
            public const string ORDER_FLAG = "ORDER_FLAG";
        }
    }
}
