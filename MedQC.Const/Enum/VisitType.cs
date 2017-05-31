using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 就诊类型枚举
    /// </summary>
    public enum VisitType
    {
        /// <summary>
        /// 门诊(0)
        /// </summary>
        OP = 0,
        /// <summary>
        /// 急诊(1)
        /// </summary>
        EP = 1,
        /// <summary>
        /// 住院(2)
        /// </summary>
        IP = 2,
        /// <summary>
        /// 其他(3)
        /// </summary>
        Other = 3
    }

}
