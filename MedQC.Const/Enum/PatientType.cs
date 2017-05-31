using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 检索病人类型
    /// </summary>
    public enum PatientType
    {
        /// <summary>
        /// 所有病人
        /// </summary>
        AllPatient = 0,
        /// <summary>
        /// 在院病人
        /// </summary>
        PatInHosptial = 1,
        /// <summary>
        /// 出院病人
        /// </summary>
        PatOutHosptal = 2,
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown = 4
    }
}
