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
        public struct MrStatus
        {
            /// <summary>
            /// 工作
            /// </summary>
            public const string Online = "O";
            /// <summary>
            /// 关闭
            /// </summary>
            public const string Close = "C";
            /// <summary>
            /// 归档
            /// </summary>
            public const string Archive = "A";
            /// <summary>
            /// 脱机
            /// </summary>
            public const string Offline = "F";

            public static string GetMrStatusName(string szCode)
            {
                string szName = string.Empty;
                switch (szCode)
                {
                    case MrStatus.Online:
                        szName = "工作";
                        break;
                    case MrStatus.Close:
                        szName = "关闭";
                        break;
                    case MrStatus.Archive:
                        szName = "归档";
                        break;
                    case MrStatus.Offline:
                        szName = "脱机";
                        break;
                    default:
                        szName = "未知";
                        break;
                }
                return szName;
            }
            public static string GetMedMrStatusDesc(string szCode)
            {
                string szName = string.Empty;
                switch (szCode)
                {
                    case MrStatus.Online:
                        szName = "未提交";
                        break;
                    case MrStatus.Close:
                        szName = "已提交";
                        break;
                    case MrStatus.Archive:
                        szName = "已归档";
                        break;
                    default:
                        break;
                }
                return szName;
            }
            public static string GetQcMrStatusName(string szCode)
            {
                string szName = string.Empty;
                switch (szCode)
                {
                    case MrStatus.Online:
                        szName = "运行病历";
                        break;
                    case MrStatus.Close:
                        szName = "终末病历";
                        break;
                    case MrStatus.Archive:
                        szName = "归档病历";
                        break;
                    default:
                        break;
                }
                return szName;
            }
            public static string GetMrStatusCode(string szQcMrStatusName)
            {
                string szCode = string.Empty;
                switch (szQcMrStatusName)
                {
                    case "运行病历":
                        szCode = MrStatus.Online;
                        break;
                    case "终末病历":
                        szCode = MrStatus.Close;
                        break;
                    case "归档病历":
                        szCode = MrStatus.Archive;
                        break;
                    default:
                        break;
                }
                return szCode;
            }

            public static string GetMrStatusCode2(string szQcMrStatusName)
            {
                string szCode = string.Empty;
                switch (szQcMrStatusName)
                {
                    case "未提交":
                        szCode = MrStatus.Online;
                        break;
                    case "已提交":
                        szCode = MrStatus.Close;
                        break;
                    case "已归档":
                        szCode = MrStatus.Archive;
                        break;
                    default:
                        break;
                }
                return szCode;
            }
        }
    }
}
