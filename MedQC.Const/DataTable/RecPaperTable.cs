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
        public struct RecPaperTable
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public const string PAPER_ID = "PAPER_ID";
            /// <summary>
            /// 病历ID
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 病案号
            /// </summary>
            public const string PATIENT_ID   = "PATIENT_ID";
            /// <summary>
            /// 入院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 翻拍正面
            /// </summary>
            public const string IMAGE_FRONTAGE = "IMAGE_FRONTAGE";
            /// <summary>
            /// 翻拍反面
            /// </summary>
            public const string IMAGE_OPPOSITE = "IMAGE_OPPOSITE";
            /// <summary>
            /// 纸质病历接收状态 0:未接收 1:已确认接收
            /// </summary>
            public const string PAPER_STATE = "PAPER_STATE";
            /// <summary>
            /// 逐份接收人ID
            /// </summary>
            public const string RECEIVE_ID = "RECEIVE_ID";
            /// <summary>
            /// 逐份接收人姓名
            /// </summary>
            public const string RECEIVE_NAME = "RECEIVE_NAME";
            /// <summary>
            /// 翻拍操作人id
            /// </summary>
            public const string OPERATOR_ID = "OPERATOR_ID";
            /// <summary>
            /// 翻拍操作人姓名
            /// </summary>
            public const string OPERATOR_NAME = "OPERATOR_NAME";
        }
    }
}
