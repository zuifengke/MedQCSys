using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 聊天消息数据类型
        /// </summary>
        public struct MsgChatDataType
        {
            /// <summary>
            /// 文本
            /// </summary>
            public const string ChatContent = "0";

            /// <summary>
            /// 图片
            /// </summary>
            public const string Image = "1";

        }
    }
}
