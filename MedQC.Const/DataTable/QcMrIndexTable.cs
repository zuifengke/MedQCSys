using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案索引补充表
        /// </summary>
        public struct QcMrIndexTable
        {
            /// <summary>
            /// 患者标识
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
            /// 提交医生ID
            /// </summary>
            public const string SUBMIT_DOCTOR_ID = "SUBMIT_DOCTOR_ID";
            /// <summary>
            /// 提交医生姓名
            /// </summary>
            public const string SUBMIT_DOCTOR = "SUBMIT_DOCTOR";
            /// <summary>
            /// 提交时间
            /// </summary>
            public const string SUBMIT_TIME = "SUBMIT_TIME";
            /// <summary>
            /// 归档时间
            /// </summary>
            public const string ARCHIVE_TIME = "ARCHIVE_TIME";
            /// <summary>
            /// 归档医生
            /// </summary>
            public const string ARCHIVE_DOCTOR = "ARCHIVE_DOCTOR";
            /// <summary>
            /// 归档医生ID
            /// </summary>
            public const string ARCHIVE_DOCTOR_ID = "ARCHIVE_DOCTOR_ID";
            /// <summary>
            /// 退回次数
            /// </summary>
            public const string RETURN_COUNT = "RETURN_COUNT";
            /// <summary>
            /// 纸质接收 0-未发送 1-已发送 2-已接收
            /// </summary>
            public const string PAPER_RECEIVE = "PAPER_RECEIVE";
        }
    }
}
