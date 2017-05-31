using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 纸质病历批次发送信息
        /// </summary>
        public struct RecMrBatchTable
        {
            /// <summary>
            /// 批次号
            /// </summary>
            public const string BATCH_NO = "BATCH_NO";
            /// <summary>
            /// 住院号集合
            /// </summary>
            public const string INP_NOS = "INP_NOS";
            /// <summary>
            /// 张数
            /// </summary>
            public const string PAPER_COUNT = "PAPER_COUNT";
            /// <summary>
            /// 病案份数
            /// </summary>
            public const string MR_COUNT = "MR_COUNT";
            /// <summary>
            /// 发送科室名称
            /// </summary>
            public const string SEND_DEPT_NAME = "SEND_DEPT_NAME";
            /// <summary>
            /// 发送医生姓名
            /// </summary>
            public const string SEND_DOCTOR_NAME = "SEND_DOCTOR_NAME";
            /// <summary>
            /// 发送人登录账号
            /// </summary>
            public const string SEND_DOCTOR_ID = "SEND_DOCTOR_ID";
            /// <summary>
            /// 发送科室代码
            /// </summary>
            public const string SEND_DEPT_CODE = "SEND_DEPT_CODE";
            /// <summary>
            /// 发送时间
            /// </summary>
            public const string SEND_TIME = "SEND_TIME";
            /// <summary>
            /// 工人工号
            /// </summary>
            public const string WORKER_ID = "WORKER_ID";
            /// <summary>
            /// 工人姓名
            /// </summary>
            public const string WORKER_NAME = "WORKER_NAME";
            /// <summary>
            /// 备注
            /// </summary>
            public const string REMARK = "REMARK";
            /// <summary>
            /// 接受科室名称
            /// </summary>
            public const string RECEIVE_DEPT_NAME = "RECEIVE_DEPT_NAME";
            /// <summary>
            /// 接收科室代码
            /// </summary>
            public const string RECEIVE_DEPT_CODE = "RECEIVE_DEPT_CODE";
            /// <summary>
            /// 接收人登录账号
            /// </summary>
            public const string RECEIVE_DOCTOR_ID = "RECEIVE_DOCTOR_ID";
            /// <summary>
            /// 接收人姓名
            /// </summary>
            public const string RECEIVE_DOCTOR_NAME = "RECEIVE_DOCTOR_NAME";
            /// <summary>
            /// 就诊流水号集合 以字符 | 隔开
            /// </summary>
            public const string VISIT_NOS = "VISIT_NOS";
            /// <summary>
            /// 接收时间
            /// </summary>
            public const string RECEIVE_TIME = "RECEIVE_TIME";
        }
    }
}
