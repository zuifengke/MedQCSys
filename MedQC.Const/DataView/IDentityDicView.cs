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
        public struct IDentityDicView
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 身份代码
            /// </summary>
            public const string IDENTITY_CODE = "IDENTITY_CODE";
            /// <summary>
            /// 身份名称
            /// </summary>
            public const string IDENTITY_NAME = "IDENTITY_NAME";
            /// <summary>
            /// 优先标志
            /// </summary>
            public const string PRIORITY_INDICATOR = "PRIORITY_INDICATOR";

        }
    }
}
