using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 检验结果表字段定义
        /// </summary>
        public struct LabResultView
        {
            /// <summary>
            /// 申请序号
            /// </summary>
            public const string TEST_ID = "TEST_ID";
            /// <summary>
            /// 检验报告项目名称
            /// </summary>
            public const string ITEM_NO = "ITEM_NO";
            /// <summary>
            /// 检验报告项目名称
            /// </summary>
            public const string ITEM_NAME = "ITEM_NAME";
            /// <summary>
            /// 检验结果值
            /// </summary>
            public const string ITEM_RESULT = "ITEM_RESULT";
            /// <summary>
            /// 检验结果单位
            /// </summary>
            public const string ITEM_UNITS = "ITEM_UNITS";
            /// <summary>
            /// 检验结果参考值
            /// </summary>
            public const string ITEM_REFER = "ITEM_REFER";
            /// <summary>
            /// 结果正常标志
            /// </summary>
            public const string ABNORMAL_INDICATOR = "ABNORMAL_INDICATOR";
        }
    }
}
