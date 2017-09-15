using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 用户数据视图字段定义
        /// </summary>
        public struct UserView
        {
            /// <summary>
            /// 用户Id
            /// </summary>
            public const string USER_ID = "USER_ID";
            /// <summary>
            /// 用户姓名
            /// </summary>
            public const string USER_NAME = "USER_NAME";
            /// <summary>
            /// 科室编码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 用户密码
            /// </summary>
            public const string USER_PWD = "USER_PWD";
            /// <summary>
            /// 员工编号
            /// </summary>
            public const string EMP_NO = "EMP_NO";
            /// <summary>
            /// 用户等级
            /// </summary>
            public const string USER_GRADE = "USER_GRADE";
        }
    }
}
