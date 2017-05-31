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
        public struct OrderStatus
        {
            /// <summary>
            /// 新开
            /// </summary>
            public const string New = "新开";
            /// <summary>
            /// 执行
            /// </summary>
            public const string Process = "执行";
            /// <summary>
            /// 停止
            /// </summary>
            public const string Stop = "停止";
            /// <summary>
            /// 作废
            /// </summary>
            public const string Delete = "作废";

            public static string GetOrderStatusDesc(string szOrderStatus)
            {
                if (szOrderStatus == "1")
                    return OrderStatus.New;
                else if (szOrderStatus == "2")
                    return OrderStatus.Process;
                else if (szOrderStatus == "3")
                    return OrderStatus.Stop;
                else if (szOrderStatus == "4")
                    return OrderStatus.Delete;
                else
                    return string.Empty;
            }
        }
    }
}
