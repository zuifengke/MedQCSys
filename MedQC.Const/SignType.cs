using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病历文档数据签名类型标识
        /// </summary>
        public struct SignType
        {
            /// <summary>
            /// 病历文档不签名
            /// </summary>
            public const string NONE = "NS";
            /// <summary>
            /// 病历文档假签名
            /// </summary>
            public const string VIRTUAL = "VS";
            /// <summary>
            /// 病历文档模拟签名
            /// </summary>
            public const string DIGITAL = "DS";

            /// <summary>
            /// 病历文档不签名
            /// </summary>
            public const string NONE_CH = "不签名";
            /// <summary>
            /// 病历文档模拟签名
            /// </summary>
            public const string VIRTUAL_CH = "模拟签名";
            /// <summary>
            /// 病历文档真正数字签名
            /// </summary>
            public const string DIGITAL_CH = "数字签名";
        }
    }
}
