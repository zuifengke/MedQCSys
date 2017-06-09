using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 新系统手术名称视图数据字段
        /// </summary>
        public struct OperationNameTable
        {
            /// <summary>
            /// 手术申请号
            /// </summary>
            public const string OPER_NO = "OPER_NO";
            /// <summary>
            /// 医嘱号
            /// </summary>
            public const string ORDER_ID = "ORDER_ID";
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 患者就诊流水标识
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 手术安排标识
            /// </summary>
            public const string SCHEDULE_ID = "SCHEDULE_ID";
            /// <summary>
            /// 手术序号
            /// </summary>
            public const string OPERATION_NO = "OPERATION_NO";
            /// <summary>
            /// 手术
            /// </summary>
            public const string OPERATION = "OPERATION";
            /// <summary>
            /// 手术操作码
            /// </summary>
            public const string OPERATION_CODE = "OPERATION_CODE";
            /// <summary>
            /// 手术等级
            /// </summary>
            public const string OPERATION_SCALE = "OPERATION_SCALE";
            /// <summary>
            /// 切口等级
            /// </summary>
            public const string WOUND_GRADE = "WOUND_GRADE";
        }
    }
}
