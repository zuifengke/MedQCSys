using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// 质控问题沟通信息记录表
        /// </summary>
        public struct QCMsgChatTable
        {
            /// <summary>
            /// 消息编号
            /// </summary>
            public const string CHAT_ID = "CHAT_ID";
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 沟通内容
            /// </summary>
            public const string CHAT_CONTENT = "CONTENT";
            /// <summary>
            /// 消息图片
            /// </summary>
            public const string CHAT_IMAGE = "IMAGE";
            /// <summary>
            /// 沟通消息发出时间
            /// </summary>
            public const string CHAT_SEND_DATE = "SEND_DATE";
            /// <summary>
            /// 沟通消息发出人
            /// </summary>
            public const string SENDER = "SENDER";
            /// <summary>
            /// 消息接收者
            /// </summary>
            public const string LISTENER = "LISTENER";
            /// <summary>
            /// 是否已读
            /// </summary>
            public const string IS_READ = "IS_READ";
            /// <summary>
            /// 聊天消息数据类型 
            /// </summary>
            public const string MSG_CHAT_DATA_TYPE = "DATA_TYPE";


        }
    }
}
