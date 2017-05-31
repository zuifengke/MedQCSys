using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 质控管辖科室表
        /// </summary>
        public struct QcAdminDeptsTable
        {
            /// <summary>
            /// 用户账号
            /// </summary>
            public const string USER_ID = "USER_ID";
            /// <summary>
            /// 用户姓名
            /// </summary>
            public const string USER_NAME = "USER_NAME";
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
        }
    }
}
