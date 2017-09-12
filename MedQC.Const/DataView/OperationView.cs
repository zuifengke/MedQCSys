using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人手术视图数据字段
        /// </summary>
        public struct OperationView
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
            /// 就诊ID
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 出院科室
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 患者性别
            /// </summary>
            public const string SEX = "SEX";
            /// <summary>
            /// 出院科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
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
            /// 手术级别
            /// </summary>
            public const string OPERATION_SCALE = "OPERATION_SCALE";
            /// <summary>
            /// 切口愈合情况
            /// </summary>
            public const string HEAL = "HEAL";
            /// <summary>
            /// 切口等级
            /// </summary>
            public const string WOUND_GRADE = "WOUND_GRADE";
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
            ///第二手术助手 
            /// </summary>
            public const string SECOND_ASSISTANT = "SECOND_ASSISTANT";
            /// <summary>
            /// 麻醉医师
            /// </summary>
            public const string ANESTHESIA_DOCTOR = "ANESTHESIA_DOCTOR";
        }
    }
}
