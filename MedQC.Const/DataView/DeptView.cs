using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 科室字段表字段定义
        /// </summary>
        public struct DeptView
        {
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 是临床科室
            /// </summary>
            public const string IS_CLINIC = "IS_CLINIC";
            /// <summary>
            /// 是门诊科室
            /// </summary>
            public const string IS_OUTP = "IS_OUTP";
            /// <summary>
            /// 是病区
            /// </summary>
            public const string IS_WARD = "IS_WARD";
            /// <summary>
            /// 是护理单元
            /// </summary>
            public const string IS_NURSE = "IS_NURSE";
            /// <summary>
            /// 输入码
            /// </summary>
            public const string INPUT_CODE = "INPUT_CODE";
        }
    }
}
