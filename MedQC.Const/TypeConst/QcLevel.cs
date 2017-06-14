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
        public struct QcLevel
        {
            /// <summary>
            /// 环节质控
            /// </summary>
            public const int LINK = 0;
            /// <summary>
            /// 终末质控
            /// </summary>
            public const int FINAL = 1;
            /// <summary>
            /// 专家质控
            /// </summary>
            public const int EXPERT = 2;
            public const string CN_LINK = "环节质控";
            public const string CN_FINAL = "终末质控";
            public const string CN_EXPERT = "专家质控";
            public static int GetCodeByMrStatus(string szMrStatus)
            {
                int result = 0;
                switch (szMrStatus)
                {
                    case MrStatus.Online:
                        result = QcLevel.LINK;
                        break;
                    case MrStatus.Close:
                        result = QcLevel.FINAL;
                        break;
                    case MrStatus.Archive:
                        result = QcLevel.EXPERT;
                        break;
                    default:
                        break;
                }
                return result;
            }
            public static string GetCnName(int code)
            {
                string szResult = string.Empty;
                switch (code)
                {
                    case QcLevel.LINK:
                        szResult = QcLevel.CN_LINK;
                        break;
                    case QcLevel.FINAL:
                        szResult = QcLevel.CN_FINAL;
                        break;
                    case QcLevel.EXPERT:
                        szResult = QcLevel.CN_EXPERT;
                        break;
                    default:
                        break;
                }
                return szResult;
            }
        }

    }
}
