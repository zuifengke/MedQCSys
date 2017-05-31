using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 检查报告表字段定义
        /// </summary>
        public struct ExamResultView
        {
            /// <summary>
            /// 申请序号
            /// </summary>
            public const string EXAM_ID = "EXAM_ID";
            /// <summary>
            /// 检查参数
            /// </summary>
            public const string PARAMETERS = "PARAMETERS";
            /// <summary>
            /// 检查所见
            /// </summary>
            public const string DESCRIPTION = "DESCRIPTION";
            /// <summary>
            /// 检查印象
            /// </summary>
            public const string IMPRESSION = "IMPRESSION";
            /// <summary>
            /// 检查建议
            /// </summary>
            public const string RECOMMENDATION = "RECOMMENDATION";
            /// <summary>
            /// 是否阳性
            /// </summary>
            public const string IS_ABNORMAL = "IS_ABNORMAL";
            /// <summary>
            /// 使用仪器
            /// </summary>
            public const string DEVICE = "DEVICE";
            /// <summary>
            /// 报告中图象编号
            /// </summary>
            public const string USE_IMAGE = "USE_IMAGE";
        }
    }
}
