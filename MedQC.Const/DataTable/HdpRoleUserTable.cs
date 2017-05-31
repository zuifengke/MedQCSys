using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 用户角色关联数据表字段定义
        /// </summary>
        public struct HdpRoleUserTable
        {
            /// <summary>
            /// 用户账号
            /// </summary>
            public const string USER_ID = "USER_ID";
            /// <summary>
            /// 角色代码
            /// </summary>
            public const string ROLE_CODE = "ROLE_CODE";
            /// <summary>
            /// 角色名称
            /// </summary>
            public const string ROLE_NAME = "ROLE_NAME";

        }
    }
}
