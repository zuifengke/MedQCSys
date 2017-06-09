
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 联众病案统计接口库病人诊断情况
        /// </summary>
        public struct BAJK09Table
        {
            /// <summary>
            /// 病人序号
            /// </summary>
            public const string KEY0901 = "KEY0901";
            /// <summary>
            /// 诊断类别
            /// </summary>
            public const string KEY0902 = "KEY0902";
            /// <summary>
            /// 顺序号
            /// </summary>
            public const string KEY0903 = "KEY0903";
            /// <summary>
            /// 疾病序号
            /// </summary>
            public const string COL0901 = "COL0901";
            /// <summary>
            /// 转归情况
            /// </summary>
            public const string COL0902 = "COL0902";
            /// <summary>
            /// 诊断情况
            /// </summary>
            public const string COL0903 = "COL0903";
            /// <summary>
            /// 入院病情
            /// </summary>
            public const string COL0904 = "COL0904";
        }
    }
}
