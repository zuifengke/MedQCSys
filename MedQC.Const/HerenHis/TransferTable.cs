
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 转科情况
        /// </summary>
        public struct TransferTable
        {
            /// <summary>
            /// 记录ID
            /// </summary>
            public const string RECORD_ID = "RECORD_ID";
            /// <summary>
            /// 患者标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 所在科室
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 所在护理单元
            /// </summary>
            public const string WARD_CODE = "WARD_CODE";
            /// <summary>
            /// 床号
            /// </summary>
            public const string BED_NO = "BED_NO";
            /// <summary>
            /// 床标号
            /// </summary>
            public const string BED_LABEL = "BED_LABEL";
            /// <summary>
            /// 入科日期及时间
            /// </summary>
            public const string ADMISSION_DATE_TIME = "ADMISSION_DATE_TIME";
            /// <summary>
            /// 入科操作人ID
            /// </summary>
            public const string ADMISSION_OPERATOR_ID = "ADMISSION_OPERATOR_ID";
            /// <summary>
            /// 入科操作人
            /// </summary>
            public const string ADMISSION_OPERATOR_NAME = "ADMISSION_OPERATOR_NAME";
            /// <summary>
            /// 出科日期及时间
            /// </summary>
            public const string DISCHARGE_DATE_TIME = "DISCHARGE_DATE_TIME";
            /// <summary>
            /// 出科操作人ID
            /// </summary>
            public const string DISCHARGE_OPERATOR_ID = "DISCHARGE_OPERATOR_ID";
            /// <summary>
            /// 出科操作人
            /// </summary>
            public const string DISCHARGE_OPERATOR_NAME = "DISCHARGE_OPERATOR_NAME";
            /// <summary>
            /// 转向科室
            /// </summary>
            public const string DEPT_TRANSFER_TO = "DEPT_TRANSFER_TO";
            /// <summary>
            /// 转科原因
            /// </summary>
            public const string TRANSFER_CAUSE = "TRANSFER_CAUSE";
            /// <summary>
            /// 经治医师姓名
            /// </summary>
            public const string CHARGER_DOCTOR_NAME = "CHARGER_DOCTOR_NAME";
            /// <summary>
            /// 经治医师ID
            /// </summary>
            public const string CHARGER_DOCTOR_ID = "CHARGER_DOCTOR_ID";
            /// <summary>
            /// 医疗组编码
            /// </summary>
            public const string MEDICAL_GROUP_NO = "MEDICAL_GROUP_NO";
            /// <summary>
            /// 操作员编码
            /// </summary>
            public const string OPERATOR_ID = "OPERATOR_ID";
            /// <summary>
            /// 操作员姓名
            /// </summary>
            public const string OPERATOR_NAME = "OPERATOR_NAME";
            /// <summary>
            /// 操作日期时间
            /// </summary>
            public const string OPERATE_DATE = "OPERATE_DATE";
            /// <summary>
            /// 备注
            /// </summary>
            public const string MEMO = "MEMO";

        }
    }
}
