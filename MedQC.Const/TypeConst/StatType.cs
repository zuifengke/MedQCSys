using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 统计类型，系统检测或人工检测
        /// </summary>
        public struct StatType
        {
            /// <summary>
            /// 系统检测
            /// </summary>
            public const int System = 0;
            /// <summary>
            /// 人工检测
            /// </summary>
            public const int Artificial = 1;
          
            public const string CN_System = "系统检测";
          
            public const string CN_Artifical = "人工检测";
            public static int GetCode(string szCnName) {
                int nCode = 0;
                switch (szCnName)
                {
                    case StatType.CN_System:
                        nCode = StatType.System;
                        break;
                    case StatType.CN_Artifical:
                        nCode = StatType.Artificial;
                        break;
                    default:
                        nCode = StatType.System;
                        break;
                }
                return nCode;
            }
            public static string GetDesc(int nType)
            {
                if (nType==SystemData.StatType.System)
                    return StatType.CN_System;
                else if (nType == SystemData.StatType.Artificial)
                    return StatType.CN_Artifical;
                else
                    return string.Empty;
            }
        }
    }
}
