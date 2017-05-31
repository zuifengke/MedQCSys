using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人病情状态常量
        /// </summary>
        public struct PatientCondition
        {
            /// <summary>
            /// 一般
            /// </summary>
            public const string REGULAR = "一般";
            /// <summary>
            /// 病重
            /// </summary>
            public const string SERIOUS = "急";
            /// <summary>
            /// 病危
            /// </summary>
            public const string CRITICAL = "危";

            /// <summary>
            /// 获取病人状态中文描述
            /// </summary>
            /// <param name="szConditionCode">病人病情状态代码</param>
            /// <returns>病人状态中文描述</returns>
            public static string GetConditionDesc(string szConditionCode)
            {
                if (szConditionCode == "2")
                    return PatientCondition.SERIOUS;
                else if (szConditionCode == "1")
                    return PatientCondition.CRITICAL;
                else
                    return PatientCondition.REGULAR;
            }
        }

    }
}
