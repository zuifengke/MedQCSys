using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {


        /// <summary>
        /// 医疗组视图
        /// </summary>
        public struct DoctorGroupView
        {
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 医疗组名称
            /// </summary>
            public const string GROUP_NAME = "GROUP_NAME";
        }
    }
}
