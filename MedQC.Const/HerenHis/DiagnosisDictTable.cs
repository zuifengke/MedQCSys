
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        public struct DiagnosisDictTable
        {
            /// <summary>
            /// 诊断代码
            /// </summary>
            public const string DIAGNOSIS_CODE = "DIAGNOSIS_CODE";
            /// <summary>
            /// 诊断名称
            /// </summary>
            public const string DIAGNOSIS_NAME = "DIAGNOSIS_NAME";
            /// <summary>
            /// 正名标志
            /// </summary>
            public const string STD_INDICATOR = "STD_INDICATOR";
            /// <summary>
            /// 标准化标志
            /// </summary>
            public const string APPROVED_INDICATOR = "APPROVED_INDICATOR";
            /// <summary>
            /// 编码体系
            /// </summary>
            public const string CODE_VERSION = "CODE_VERSION";
            /// <summary>
            /// 健康水平
            /// </summary>
            public const string HEALTH_LEVEL = "HEALTH_LEVEL";
            /// <summary>
            /// 感染标志
            /// </summary>
            public const string INFECT_INDICATOR = "INFECT_INDICATOR";
            /// <summary>
            /// 创建日期
            /// </summary>
            public const string CREATE_DATE = "CREATE_DATE";
            /// <summary>
            /// 拼音输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
            /// <summary>
            /// 五笔输入码
            /// </summary>
            public const string INPUT_CODE_WB = "INPUT_CODE_WB";
            /// <summary>
            /// 数字输入码
            /// </summary>
            public const string INPUT_CODE_NO = "INPUT_CODE_NO";
        }
    }
}
