using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案索引表
        /// </summary>
        public struct MrIndexView
        {
            /// <summary>
            /// 患者标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 新军卫就诊流水号，其他HIS库字段值和Visit_ID一样
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 病案状态 反映病案的存贮状态：O-工作C-关闭 A-归档 F-脱机(目前只使用工作，关闭两个状态，工作为正常病历在线的状态，关闭则为病历已提交的状态)
            /// </summary>
            public const string MR_STATUS = "MR_STATUS";
            /// <summary>
            /// 病案类别
            /// </summary>
            public const string MR_CLASS = "MR_CLASS";
            /// <summary>
            /// 提交医生ID
            /// </summary>
            public const string SUBMIT_DOCTOR_ID = "SUBMIT_DOCTOR_ID";
        }
    }
}
