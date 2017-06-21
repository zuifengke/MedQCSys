using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 质控反馈信息字典表相关字段定义
        /// </summary>
        public struct QcMsgDictTable
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 反馈信息代码
            /// </summary>
            public const string QC_MSG_CODE = "QC_MSG_CODE";
            /// <summary>
            /// 问题分类
            /// </summary>
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            /// <summary>
            /// 信息描述
            /// </summary>
            public const string MESSAGE = "MESSAGE";
            /// <summary>
            /// 信息标题
            /// </summary>
            public const string MESSAGE_TITLE = "MESSAGE_TITLE";
            /// <summary>
            /// 扣分
            /// </summary>
            public const string SCORE = "SCORE";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
            /// <summary>
            /// 应用环境
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
            /// <summary>
            /// 单项否决
            /// </summary>
            public const string ISVETO = "ISVETO";
            /// <summary>
            /// 是否有效
            /// </summary>
            public const string IS_VALID = "IS_VALID";
        }
    }
}
