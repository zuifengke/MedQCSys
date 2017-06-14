
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人转科情况
        /// </summary>
        public struct BAJK13Table
        {
            /// <summary>
            /// 病人序号
            /// </summary>
            public const string KEY1301 = "KEY1301";
            /// <summary>
            /// 顺序号
            /// </summary>
            public const string KEY1302 = "KEY1302";
            /// <summary>
            /// 转科日期
            /// </summary>
            public const string COL1301 = "COL1301";
            /// <summary>
            /// 转入科室代码
            /// </summary>
            public const string COL1302 = "COL1302";
            /// <summary>
            /// 转出日期
            /// </summary>
            public const string COL1303 = "COL1303";

        }
    }
}
