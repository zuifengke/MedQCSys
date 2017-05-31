using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 用户角色枚举
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// 住院医生(0)IP doctor
        /// </summary>
        InDoctor = 0,
        /// <summary>
        /// 门诊医生(1)OP doctor
        /// </summary>
        OutDoctor = 1,
        /// <summary>
        /// 护士(2)
        /// </summary>
        Nurse = 2,
        /// <summary>
        /// 其他人员(3)
        /// </summary>
        Other = 3
    }

}
