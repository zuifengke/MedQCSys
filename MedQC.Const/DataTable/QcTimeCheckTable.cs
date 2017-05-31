using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病历时效扣分表
        /// </summary>
        public struct QcTimeCheckTable
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 事件ID
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 文档类型ID
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 病历书写起始日期
            /// </summary>
            public const string BEGIN_DATE = "BEGIN_DATE";
            /// <summary>
            /// 病历书写截止日期
            /// </summary>
            public const string END_DATE = "END_DATE";
            /// <summary>
            /// 扣分值
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 检查者姓名
            /// </summary>
            public const string CHECKER_NAME = "CHECKER_NAME";
            /// <summary>
            /// 检查日期
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
        }
    }
}
