using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 模板审核状态
    /// </summary>
    [System.Serializable]
    public enum TempletCheckStatus
    {
        /// <summary>
        /// 未审核
        /// </summary>
        None = 0,
        /// <summary>
        /// 有缺陷
        /// </summary>
        HasBug = 1,
        /// <summary>
        /// 已确认
        /// </summary>
        Affirm = 2,
        /// <summary>
        /// 审核通过
        /// </summary>
        Passed = 3,
        /// <summary>
        /// 暂存不提交审核
        /// </summary>
        Saved = 4,
        /// <summary>
        /// 科室审核通过
        /// </summary>
        DeptPassed = 5
    }
}
