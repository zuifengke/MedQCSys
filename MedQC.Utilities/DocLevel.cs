using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 统计类型，系统检测或人工检测
    /// </summary>
    public struct DocLevel
    {
        public const string One = "甲";
        public const string Two = "乙";
        public const string Three = "丙";

        public static string GetDocLevel(float nScore)
        {
            string szDocLevel = string.Empty;
            if (SystemParam.Instance.LocalConfigOption.GradingHigh <= nScore)
            {
                szDocLevel = DocLevel.One;
            }
            else if (SystemParam.Instance.LocalConfigOption.GradingHigh > nScore &&
                SystemParam.Instance.LocalConfigOption.GradingLow <= nScore)
            {
                szDocLevel = DocLevel.Two;
            }
            else
                szDocLevel = DocLevel.Three;

            return szDocLevel;
        }
    }

}
