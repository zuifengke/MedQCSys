using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 质控级别
        /// </summary>
        public struct NotifyStatus
        {
            /// <summary>
            /// 草稿
            /// </summary>
            public const int Draft = 0;
            /// <summary>
            /// 已发送
            /// </summary>
            public const int Sended = 1;
            public const string CnDraft = "草稿";
            public const string CnSended = "已发送";
            public static string GetCnName(int code)
            {
                string szResult = string.Empty;
                switch (code)
                {
                    case NotifyStatus.Draft:
                        szResult = NotifyStatus.CnDraft;
                        break;
                    case NotifyStatus.Sended:
                        szResult = NotifyStatus.CnSended;
                        break;
                    default:
                    break;
                }
                return szResult;
            }
        }
    }
}
