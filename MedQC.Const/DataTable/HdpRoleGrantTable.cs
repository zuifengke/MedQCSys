using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 角色权限管理数据表字段定义
        /// </summary>
        public struct HdpRoleGrantTable
        {
            /// <summary>
            /// 编号
            /// </summary>
            public const string GRANT_ID = "GRANT_ID";
            /// <summary>
            /// 角色代码
            /// </summary>
            public const string ROLE_CODE = "ROLE_CODE";
            /// <summary>
            /// 权限点
            /// </summary>
            public const string ROLE_RIGHT_KEY = "ROLE_RIGHT_KEY";
            /// <summary>
            /// 权限点说明
            /// </summary>
            public const string ROLE_RIGHT_DESC = "ROLE_RIGHT_DESC";
            /// <summary>
            /// 关联的命令
            /// </summary>
            public const string ROLE_RIGHT_COMMAND = "ROLE_RIGHT_COMMAND";
            /// <summary>
            /// 产品
            /// </summary>
            public const string PRODUCT = "PRODUCT";


        }
    }
}
