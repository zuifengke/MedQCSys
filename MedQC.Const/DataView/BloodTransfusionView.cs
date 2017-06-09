using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 手术操作字典视图
        /// </summary>
        public struct BloodTransfusionView
        {
            /// <summary>
            /// 患者ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 入院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 全血
            /// </summary>
            public const string WHOLE_BLOOD = "WHOLE_BLOOD";
            /// <summary>
            /// 红细胞悬液
            /// </summary>
            public const string RED_CELL = "RED_CELL";
        }
    }
}
