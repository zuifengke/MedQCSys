using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 文件扩展名常量
        /// </summary>
        public struct WorklistType
        {
            /// <summary>
            /// 入科
            /// </summary>
            public const string 入科 = "1";
            /// <summary>
            /// 出科
            /// </summary>
            public const string 出科 = "2";
            /// <summary>
            ///出院
            /// </summary>
            public const string 出院 = "3";
            /// <summary>
            /// 今日手术
            /// </summary>
            public const string 今日手术 = "4";
            /// <summary>
            /// 明日手术
            /// </summary>
            public const string 明日手术 = "5";
            /// <summary>
            /// 接收会诊
            /// </summary>
            public const string 接收会诊 = "6";
            /// <summary>
            /// 会诊确认
            /// </summary>
            public const string 会诊确认 = "7";
            /// <summary>
            /// 检查报告返回
            /// </summary>
            public const string 检查报告返回 = "8";
            /// <summary>
            /// 检验报告返回
            /// </summary>
            public const string 检验报告返回 = "9";
            /// <summary>
            /// 检验报告异常值
            /// </summary>
            public const string 检验报告异常值 = "10";
            /// <summary>
            /// 护士医嘱回退
            /// </summary>
            public const string 护士医嘱回退 = "11";
            /// <summary>
            /// 药房摆药审核
            /// </summary>
            public const string 药房摆药审核 = "12";
            /// <summary>
            /// 质控数据返回
            /// </summary>
            public const string 质控数据返回 = "13";
            /// <summary>
            /// 病情变化
            /// </summary>
            public const string 病情变化 = "14";
            /// <summary>
            /// 体征变化 
            /// </summary>
            public const string 体征变化 = "15";
            /// <summary>
            /// 病案 
            /// </summary>
            public const string 病案 = "16";
        }
    }
}
