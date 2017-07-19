using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 费别字典视图字段定义
        /// </summary>
        public struct ChargeTypeDicView
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 费别代码
            /// </summary>
            public const string CHARGE_TYPE_CODE = "CHARGE_TYPE_CODE";
            /// <summary>
            /// 费别名称
            /// </summary>
            public const string CHARGE_TYPE_NAME = "CHARGE_TYPE_NAME";
            /// <summary>
            /// 享受优惠价格标志
            /// </summary>
            public const string CHARGE_PRICE_INDICATOR = "CHARGE_PRICE_INDICATOR";

        }
    }
}
