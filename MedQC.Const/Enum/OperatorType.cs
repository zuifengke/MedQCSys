using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 操作符类型
    /// </summary>
    public enum OperatorType
    {
        /// <summary>
        /// 大于
        /// </summary>
        Morethan = 0,
        /// <summary>
        /// 小于
        /// </summary>
        Lessthan = 1,
        /// <summary>
        /// 等于
        /// </summary>
        Equalthan = 2,
        /// <summary>
        /// 大于等于
        /// </summary>
        MoreEqualthan = 3,
        /// <summary>
        /// 小于等于
        /// </summary>
        LessEqualthan = 4,
        /// <summary>
        /// 未知
        /// </summary>
        UnKnown = 5
    }
}
