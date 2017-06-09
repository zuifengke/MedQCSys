
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 联众疾病代码表
        /// </summary>
        public struct BaIcdDMTable
        {
            /// <summary>
            /// 疾病序号
            /// </summary>
            public const string JBXH = "JBXH";
            /// <summary>
            /// 疾病名称
            /// </summary>
            public const string JBMC = "JBMC";
            /// <summary>
            /// ICD9码
            /// </summary>
            public const string ICD9 = "ICD9";
            /// <summary>
            /// ICD10码
            /// </summary>
            public const string ICD10 = "ICD10";
        }
    }
}
