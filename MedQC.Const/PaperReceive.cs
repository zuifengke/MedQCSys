using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案状态常量
        /// </summary>
        public struct PaperReceive
        {
            /// <summary>
            /// 未发送
            /// </summary>
            public const int UnSend = 0;
            /// <summary>
            /// 已发送
            /// </summary>
            public const int Sended = 1;
            /// <summary>
            /// 已接收
            /// </summary>
            public const int Received = 2;
            public static string GetPaperReceiveDesc(int nCode)
            {
                string szName = string.Empty;
                switch (nCode)
                {
                    case PaperReceive.UnSend:
                        szName = "未发送";
                        break;
                    case PaperReceive.Sended:
                        szName = "已发送";
                        break;
                    case PaperReceive.Received:
                        szName = "已接收";
                        break;
                    default:
                        szName = "未知";
                        break;
                }
                return szName;
            }
        }
    }
}
