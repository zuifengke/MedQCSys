using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 专家质控表结构
        /// </summary>
        public struct QcSpecialCheckTable
        {
            /// <summary>
            /// 抽检批次号
            /// </summary>
            public const string CONFIG_ID = "CONFIG_ID";
            /// <summary>
            /// 名称
            /// </summary>
            public const string NAME = "NAME";
            /// <summary>
            /// 开始时间
            /// </summary>
            public const string START_TIME = "START_TIME";
            /// <summary>
            /// 结束时间
            /// </summary>
            public const string END_TIME = "END_TIME";
            /// <summary>
            /// 病人病情
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
            /// <summary>
            /// 出院方式
            /// </summary>
            public const string DISCHARGE_MODE = "DISCHARGE_MODE";
            /// <summary>
            /// 每科室抽取
            /// </summary>
            public const string PER_COUNT = "PER_COUNT";
            /// <summary>
            /// 病案样本总数
            /// </summary>
            public const string PATIENT_COUNT = "PATIENT_COUNT";
            /// <summary>
            /// 专家人数
            /// </summary>
            public const string SPECIAL_COUNT = "SPECIAL_COUNT";
            /// <summary>
            /// 创建人
            /// </summary>
            public const string CREATER = "CREATER";
            /// <summary>
            /// 创建时间
            /// </summary>
            public const string CREATE_TIME = "CREATE_TIME";
            /// <summary>
            /// 完成质检
            /// </summary>
            public const string CHECKED = "CHECKED";
        }
    }
}
