using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 转科记录字段定义
        /// </summary>
        public struct TransferView
        {
            /// <summary>
            /// 患者ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 就诊次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 所在科室代码
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 入科时间
            /// </summary>
            public const string ADMISSION_DATE_TIME = "ADMISSION_DATE_TIME";
            /// <summary>
            /// 床号
            /// </summary>
            public const string BED_NO = "BED_NO";
            /// <summary>
            /// 床标号
            /// </summary>
            public const string BED_LABEL = "BED_LABEL";
            /// <summary>
            /// 出科时间
            /// </summary>
            public const string DISCHARGE_DATE_TIME = "DISCHARGE_DATE_TIME";
            /// <summary>
            /// 转向科室代码
            /// </summary>
            public const string DEPT_TRANSFER_TO = "DEPT_TRANSFER_TO";
            /// <summary>
            /// 经治医生ID
            /// </summary>
            public const string CHARGER_DOCTOR_ID = "CHARGER_DOCTOR_ID";
            /// <summary>
            /// 经治医生姓名
            /// </summary>
            public const string CHARGER_DOCTOR_NAME = "CHARGER_DOCTOR_NAME";
            /// <summary>
            /// 医疗组编号
            /// </summary>
            public const string MEDICAL_GROUP_NO = "MEDICAL_GROUP_NO";
            /// <summary>
            /// 医疗组名称
            /// </summary>
            public const string MEDICAL_GROUP_NAME = "MEDICAL_GROUP_NAME";
        }
    }
}
