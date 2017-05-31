using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 专家质控病案分配详情表结构
        /// </summary>
        public struct QcSpecialDetailTable
        {
            /// <summary>
            /// 抽检批次号
            /// </summary>
            public const string CONFIG_ID = "CONFIG_ID";
            /// <summary>
            /// 专家账号
            /// </summary>
            public const string SPECIAL_ID = "SPECIAL_ID";
            /// <summary>
            /// 专家姓名
            /// </summary>
            public const string SPECIAL_NAME = "SPECIAL_NAME";
            /// <summary>
            /// 病人ID号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
        }
    }
}
