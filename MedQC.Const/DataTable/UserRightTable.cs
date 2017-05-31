using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 用户权限控制表
        /// </summary>
        public struct UserRightTable
        {
            /// <summary>
            /// 用户代码
            /// </summary>
            public const string USER_ID = "USER_ID";
            /// <summary>
            /// 用户密码
            /// </summary>
            public const string USER_PWD = "USER_PWD";
            /// <summary>
            /// 权限二进制位编码字符串
            /// </summary>
            public const string RIGHT_CODE = "RIGHT_CODE";
            /// <summary>
            /// 权限类型
            /// </summary>
            public const string RIGHT_TYPE = "RIGHT_TYPE";
            /// <summary>
            /// 权限描述
            /// </summary>
            public const string RIGHT_DESC = "RIGHT_DESC";
        }
    }
}
