using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 用户权限类型
    /// </summary>
    [System.Serializable]
    public enum UserRightType
    {
        /// <summary>
        /// 编辑器用户权限
        /// </summary>
        MedDoc,
        /// <summary>
        /// 质控用户权限
        /// </summary>
        MedQC
    }
}
