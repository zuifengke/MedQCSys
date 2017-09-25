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
            /// 0开立未提交
            /// </summary>
            public const string UnSubmit = "0";
            /// <summary>
            /// 1新开
            /// </summary>
            public const string New = "1";
            /// <summary>
            /// 2执行
            /// </summary>
            public const string Process = "2";
            /// <summary>
            /// 3停止
            /// </summary>
            public const string Stop = "3";
            /// <summary>
            /// 4作废
            /// </summary>
            public const string Delete = "4";
            /// <summary>
            /// 7审核未通过
            /// </summary>
            public const string UnCheck = "7";
            /// <summary>
            /// 0开立未提交
            /// </summary>
            public const string CnUnSubmit = "开立未提交";
            /// <summary>
            /// 1新开
            /// </summary>
            public const string CnNew = "新开";
            /// <summary>
            /// 2执行
            /// </summary>
            public const string CnProcess = "执行";
            /// <summary>
            /// 3停止
            /// </summary>
            public const string CnStop = "停止";
            /// <summary>
            /// 4作废
            /// </summary>
            public const string CnDelete = "作废";
            /// <summary>
            /// 7审核未通过
            /// </summary>
            public const string CnUnCheck = "审核未通过";

            public static string GetOrderStatusDesc(string szOrderStatus)
            {
                if (szOrderStatus == OrderStatus.New)
                    return OrderStatus.CnNew;
                else if (szOrderStatus == OrderStatus.Process)
                    return OrderStatus.CnProcess;
                else if (szOrderStatus == OrderStatus.Stop)
                    return OrderStatus.CnStop;
                else if (szOrderStatus == OrderStatus.Delete)
                    return OrderStatus.CnDelete;
                else if (szOrderStatus == OrderStatus.UnCheck)
                    return OrderStatus.CnUnCheck;
                else if (szOrderStatus == OrderStatus.UnSubmit)
                    return OrderStatus.CnUnSubmit;
                else
                    return string.Empty;
            }
        }
    }
}
