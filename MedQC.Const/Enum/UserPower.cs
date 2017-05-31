using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 用户权限枚举
    /// </summary>
    public enum UserPower
    {
        /// <summary>
        /// 不可见(0)
        /// </summary>
        Invisible = 0,
        /// <summary>
        /// 只读(1)
        /// </summary>
        ReadOnly = 1,
        /// <summary>
        /// 只读和打印(2)
        /// </summary>
        ReadPrint = 2,
        /// <summary>
        /// 只读打印和导出(3)
        /// </summary>
        ReadPrintExport = 3,
        /// <summary>
        /// 可编辑(4)
        /// </summary>
        Editable = 4
    }

}
