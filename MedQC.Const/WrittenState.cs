using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {   /// <summary>
        /// 时效规则类型
        /// </summary>
        public struct WrittenState
        {
            /// <summary>
            /// 正常
            /// </summary>
            public const string CnNormal = "正常";

            /// <summary>
            /// 未书写超时
            /// </summary>
            public const string CnUnwrite = "未书写超时";

            /// <summary>
            /// 书写超时
            /// </summary>
            public const string CnTimeout = "书写超时";

            /// <summary>
            /// 书写提前
            /// </summary>
            public const string CnEarly = "书写提前";

            /// <summary>
            /// 正常未书写
            /// </summary>
            public const string CnUnwriteNormal = "正常未书写";

            /// <summary>
            /// 正常
            /// </summary>
            public const string Normal = "0";
            /// <summary>
            /// 未书写超时
            /// </summary>
            public const string Unwrite = "1";
            /// <summary>
            /// 书写提前
            /// </summary>
            public const string Early = "2";
            /// <summary>
            /// 书写超时
            /// </summary>
            public const string Timeout = "3";
            /// <summary>
            /// 正常未书写
            /// </summary>
            public const string UnwriteNormal = "4";

            public static string GetCnWrittenState(string szStateCode)
            {
                string szWrittenState = string.Empty;
                switch (szStateCode)
                {
                    case WrittenState.Early:
                        szWrittenState = WrittenState.CnEarly;
                        break;

                    case WrittenState.Normal:
                        szWrittenState = WrittenState.CnNormal;
                        break;

                    case WrittenState.Timeout:
                        szWrittenState = WrittenState.CnTimeout;
                        break;

                    case WrittenState.UnwriteNormal:
                        szWrittenState = WrittenState.CnUnwriteNormal;
                        break;

                    case WrittenState.Unwrite:
                        szWrittenState = WrittenState.CnUnwrite;
                        break;

                    default:
                        break;
                }
                return szWrittenState;
            }
            public static string GetWrittenStateCode(string szState)
            {
                string szWrittenState = string.Empty;
                switch (szState)
                {
                    case WrittenState.CnEarly:
                        szWrittenState = WrittenState.Early;
                        break;

                    case WrittenState.CnNormal:
                        szWrittenState = WrittenState.Normal;
                        break;

                    case WrittenState.CnTimeout:
                        szWrittenState = WrittenState.Timeout;
                        break;

                    case WrittenState.CnUnwrite:
                        szWrittenState = WrittenState.Unwrite;
                        break;

                    case WrittenState.CnUnwriteNormal:
                        szWrittenState = WrittenState.UnwriteNormal;
                        break;

                    default:
                        break;
                }
                return szWrittenState;
            }
        }
    }
}
