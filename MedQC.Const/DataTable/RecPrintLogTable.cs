using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 纸质病历信息表
        /// </summary>
        public struct RecPrintLogTable
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public const string PRINT_ID = "PRINT_ID";
            /// <summary>
            /// 病案号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 入院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 患者身份证
            /// </summary>
            public const string PATIENT_ID_NO = "PATIENT_ID_NO";
            /// <summary>
            /// 复印人姓名
            /// </summary>
            public const string PRINT_NAME = "PRINT_NAME";
            /// <summary>
            /// 复印人身份证
            /// </summary>
            public const string PRINT_ID_NO = "PRINT_ID_NO";
            /// <summary>
            /// 与患者关系
            /// </summary>
            public const string RELATIONSHIP_PATIENT = "RELATIONSHIP_PATIENT";
            /// <summary>
            /// 打印内容
            /// </summary>
            public const string PRINT_CONTENT = "PRINT_CONTENT";
            /// <summary>
            /// 备注
            /// </summary>
            public const string REMARKS = "REMARKS";
            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 金额
            /// </summary>
            public const string MONEY = "MONEY";
            /// <summary>
            /// 是否开发票
            /// </summary>
            public const string INVOICE = "INVOICE";
            /// <summary>
            /// 复印时间
            /// </summary>
            public const string PRINT_TIME = "PRINT_TIME";
        }
    }
}
