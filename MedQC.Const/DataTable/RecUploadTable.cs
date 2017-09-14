using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 病案上传记录表
        /// </summary>
        public struct RecUploadTable
        {
            /// <summary>
            /// 主键
            /// </summary>
            public const string UPLOAD_ID = "UPLOAD_ID";
            /// <summary>
            /// 病历ID
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
            /// 状态 0:未上传 1已上传
            /// </summary>
            public const string UPLOAD_STATUS = "UPLOAD_STATUS";
            /// <summary>
            /// 上传日志
            /// </summary>
            public const string UPLOAD_LOG = "UPLOAD_LOG";
            /// <summary>
            /// 上传时间
            /// </summary>
            public const string UPLOAD_TIME = "UPLOAD_TIME";

        }
    }
}
