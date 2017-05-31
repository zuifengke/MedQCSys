using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 用户等级枚举
    /// </summary>
    public enum UserLevel
    {
        /// <summary>
        /// 正常,主治医师
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 上级医师
        /// </summary>
        Higher = 1,
        /// <summary>
        /// 主任医师
        /// </summary>
        Chief = 2
    }

}
