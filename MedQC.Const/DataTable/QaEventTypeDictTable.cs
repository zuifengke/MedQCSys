using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 病案质量问题分类字典表相关字段定义
        /// </summary>
        public struct QaEventTypeDictTable 
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 问题分类
            /// </summary>
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
            /// <summary>
            /// 上级输入码
            /// </summary>
            public const string PARENT_CODE = "PARENT_CODE";
            /// <summary>
            /// 最大扣分数
            /// </summary>
            public const string MAX_SCORE = "MAX_SCORE";
            /// <summary>
            /// 应用环境
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
        }
    }
}
