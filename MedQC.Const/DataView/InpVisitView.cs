using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 在院病人数据视图字段定义
        /// </summary>
        public struct InpVisitView
        {
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// 病人性别
            /// </summary>
            public const string PATIENT_SEX = "PATIENT_SEX";
            /// 身份
            /// </summary>
            public const string IDENTITY = "IDENTITY";
            /// 病人费别
            /// </summary>
            public const string CHARGE_TYPE = "CHARGE_TYPE";
            /// 病人生日
            /// </summary>
            public const string BIRTH_TIME = "BIRTH_TIME";
            /// 就诊类型
            /// </summary>
            public const string VISIT_TYPE = "VISIT_TYPE";
            /// 住院号
            /// </summary>
            public const string INP_NO = "INP_NO";
            /// 过敏药物
            /// </summary>
            public const string ALLERGY_DRUGS = "ALLERGY_DRUGS";
            /// 经治医生ID
            /// </summary>
            public const string INCHARGE_DOCTOR_ID = "INCHARGE_DOCTOR_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 床位码
            /// </summary>
            public const string BED_CODE = "BED_CODE";
            /// <summary>
            /// 床标号
            /// </summary>
            public const string BED_LABEL = "BED_LABEL";
            /// <summary>
            /// 科室码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 所在护理单元代码
            /// </summary>
            public const string WARD_CODE = "WARD_CODE";
            /// <summary>
            /// 入院时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 入科时间
            /// </summary>
            public const string ADM_WARD_TIME = "ADM_WARD_TIME";
            /// <summary>
            /// 入院诊断
            /// </summary>
            public const string DIAGNOSIS = "DIAGNOSIS";
            /// <summary>
            /// 经治医师
            /// </summary>
            public const string INCHARGE_DOCTOR = "INCHARGE_DOCTOR";
            /// <summary>
            /// 病人病情
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
            /// <summary>
            /// 护理等级名称
            /// </summary>
            public const string NURSING_CLASS = "NURSING_CLASS";
            /// <summary>
            /// 病案状态
            /// </summary>
            public const string MR_STATUS = "MR_STATUS";
            /// <summary>
            /// 预交金总额
            /// </summary>
            public const string PREPAYMENTS = "PREPAYMENTS";
            /// <summary>
            /// 累计未结费用
            /// </summary>
            public const string TOTAL_COSTS = "TOTAL_COSTS";
            /// <summary>
            /// 优惠后未结费用
            /// </summary>
            public const string TOTAL_CHARGES = "TOTAL_CHARGES";
            /// <summary>
            /// 工作单位
            /// </summary>
            public const string SERVICE_AGENCY = "SERVICE_AGENCY";
        }
    }
}
