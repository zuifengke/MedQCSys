using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 检索类型枚举
    /// </summary>
    public enum PatSearchType
    {
        /// <summary>
        /// 按科室检索
        /// </summary>
        Department = 0,
        /// <summary>
        /// 按入院时间检索
        /// </summary>
        Admission = 1,
        /// <summary>
        /// 按危重病例检索
        /// </summary>
        SeriousAndCritical = 2,
        /// <summary>
        /// 按死亡病例检索
        /// </summary>
        Death = 3,
        /// <summary>
        /// 按病人ID检索
        /// </summary>
        PatientID = 4,
        /// <summary>
        /// 按住院号检索
        /// </summary>
        InHospitalID = 5,
        /// <summary>
        /// 按出院时间检索
        /// </summary>
        Discharge = 6,
        /// <summary>
        /// 病人姓名
        /// </summary>
        PatientName = 7,
        /// <summary>
        /// 做过手术的病人
        /// </summary>
        OperationPatient = 8,
        /// <summary>
        /// 病人住院天数检索
        /// </summary>
        InHospitalDays = 9,
        /// <summary>
        /// 未知检索类型
        /// </summary>
        Unknown = 10,
        /// <summary>
        /// 质控病历检索类型
        /// </summary>
        CheckedDoc = 11,
        /// <summary>
        /// 专家质检
        /// </summary>
        SpecialQC = 12,
        /// <summary>
        /// 文书类型
        /// </summary>
        DocType = 13,
        /// <summary>
        /// 重复入院
        /// </summary>
        MutiVisit = 14,
        /// <summary>
        /// 转科病人
        /// </summary>
        TransferPatient = 15,
        /// <summary>
        /// 待复审
        /// </summary>
        Review = 16,
        /// <summary>
        /// 资料组
        /// </summary>
        DoctorGroup

    }
}
