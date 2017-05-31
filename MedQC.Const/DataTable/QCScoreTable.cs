using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案评分视图数据字段
        /// </summary>
        public struct QCScoreTable
        {
            /// <summary>
            /// 获取或设置病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";

            /// <summary>
            /// 获取或设置就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 新军卫就诊就诊流水号，其他his数据库和Visit_ID一样
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 获取或设置病历等级
            /// </summary>
            public const string DOC_LEVEL = "DOC_LEVEL";
            /// <summary>
            /// 获取或设置院评分数
            /// </summary>
            public const string HOS_ASSESS = "HOS_ASSESS";
            /// <summary>
            /// 获取或设置院评日期
            /// </summary>
            public const string HOS_DATE ="HOS_DATE";
            /// <summary>
            /// 获取或设置院评质控人
            /// </summary>
            public const string HOS_QCMAN = "HOS_QCMAN";
            public const string HOS_QCMAN_ID = "HOS_QCMAN_ID";
            public const string SUBMIT_DOCTOR_ID = "SUBMIT_DOCTOR_ID";
            public const string SUBMIT_DOCTOR = "SUBMIT_DOCTOR";
            public const string DEPT_NAME = "DEPT_NAME";
            public const string PATIENT_NAME = "PATIENT_NAME";
        }
    }
}
