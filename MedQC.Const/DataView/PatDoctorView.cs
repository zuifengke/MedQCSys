using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        public struct PatDoctorView
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊ID
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 入院时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 出院科室
            /// </summary>
            public const string DISCHARGE_DEPT_CODE = "DISCHARGE_DEPT_CODE";
            /// <summary>
            /// 床位编号
            /// </summary>
            public const string BED_CODE = "BED_CODE";
            /// <summary>
            /// 经治医师ID
            /// </summary>
            public const string REQUEST_DOCTOR_ID = "REQUEST_DOCTOR_ID";
            /// <summary>
            /// 上级医师ID
            /// </summary>
            public const string PARENT_DOCTOR_ID = "PARENT_DOCTOR_ID";
            /// <summary>
            /// 主任医师ID
            /// </summary>
            public const string SUPER_DOCTOR_ID = "SUPER_DOCTOR_ID";
            /// <summary>
            /// 病人入院时所在部门
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
        }
    }
}
