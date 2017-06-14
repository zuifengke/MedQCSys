using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 手术记录
        /// </summary>
        public struct OperationTable
        {
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
            /// 手术序号
            /// </summary>
            public const string OPERATION_NO = "OPERATION_NO";
            /// <summary>
            /// 手术名称
            /// </summary>
            public const string OPERATION_DESC = "OPERATION_DESC";
            /// <summary>
            /// 手术编码
            /// </summary>
            public const string OPERATION_CODE = "OPERATION_CODE";
            /// <summary>
            /// 编码体系
            /// </summary>
            public const string CODE_VERSION = "CODE_VERSION";
            /// <summary>
            /// 切口等级
            /// </summary>
            public const string WOUND_GRADE = "WOUND_GRADE";
            /// <summary>
            /// 切口愈合情况
            /// </summary>
            public const string HEAL = "HEAL";
            /// <summary>
            /// 手术日期
            /// </summary>
            public const string OPERATING_DATE = "OPERATING_DATE";
            /// <summary>
            /// 麻醉方法
            /// </summary>
            public const string ANAESTHESIA_METHOD = "ANAESTHESIA_METHOD";
            /// <summary>
            /// 手术医师
            /// </summary>
            public const string OPERATOR = "OPERATOR";
            /// <summary>
            /// 第一手术助手
            /// </summary>
            public const string FIRST_ASSISTANT = "FIRST_ASSISTANT";
            /// <summary>
            /// 第二手术助手
            /// </summary>
            public const string SECOND_ASSISTANT = "SECOND_ASSISTANT";
            /// <summary>
            /// 麻醉医师
            /// </summary>
            public const string ANAESTHESIA_DOCTOR = "ANAESTHESIA_DOCTOR";
            /// <summary>
            /// 医疗类别
            /// </summary>
            public const string CLINIC_CATE = "CLINIC_CATE";
            
        }
    }
}
