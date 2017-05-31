using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 检查主表字段定义
        /// </summary>
        public struct ExamMasterView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 申请序号
            /// </summary>
            public const string EXAM_ID = "EXAM_ID";
            /// <summary>
            /// 检查类别
            /// </summary>
            public const string SUBJECT = "SUBJECT";
            /// <summary>
            /// 申请日期
            /// </summary>
            public const string REQUEST_TIME = "REQUEST_TIME";
            /// <summary>
            /// 申请医生
            /// </summary>
            public const string REQUEST_DOCTOR = "REQUEST_DOCTOR";
            /// <summary>
            /// 报告状态
            /// </summary>
            public const string RESULT_STATUS = "RESULT_STATUS";
            /// <summary>
            /// 报告日期
            /// </summary>
            public const string REPORT_TIME = "REPORT_TIME";
            /// <summary>
            /// 报告人
            /// </summary>
            public const string REPORT_DOCTOR = "REPORT_DOCTOR";
        }
    }
}
