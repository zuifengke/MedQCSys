using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 产品管理数据表字段定义
        /// </summary>
        public struct HdpProductTable
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 产品缩写
            /// </summary>
            public const string NAME_SHORT = "NAME_SHORT";
            /// <summary>
            /// 中文名称
            /// </summary>
            public const string CN_NAME = "CN_NAME";
            /// <summary>
            /// 英文名称
            /// </summary>
            public const string EN_NAME = "EN_NAME";
            /// <summary>
            /// 产品备注
            /// </summary>
            public const string PRODUCT_BAK = "PRODUCT_BAK";
        }
    }
}
