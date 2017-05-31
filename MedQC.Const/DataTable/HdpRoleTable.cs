using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 角色管理数据表字段定义
        /// </summary>
        public struct HdpRoleTable
        {
            /// <summary>
            /// 序号
            /// </summary>
            public const string SERIAL_NO = "SERIAL_NO";
            /// <summary>
            /// 角色名称
            /// </summary>
            public const string ROLE_NAME = "ROLE_NAME";
            /// <summary>
            /// 角色代码
            /// </summary>
            public const string ROLE_CODE = "ROLE_CODE";
            /// <summary>
            /// 角色备注
            /// </summary>
            public const string ROLE_BAK = "ROLE_BAK";
            /// <summary>
            /// 状态 0 关闭 1 正常
            /// </summary>
            public const string STATUS = "STATUS";

        }
    }
}
