using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {



        /// <summary>
        /// 病人就诊视图
        /// </summary>
        public struct PatVisitView
        {
            /// <summary>
            /// 病人标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 病人性别
            /// </summary>
            public const string PATIENT_SEX = "PATIENT_SEX";
            /// <summary>
            /// 病人生日
            /// </summary>
            public const string BIRTH_TIME = "BIRTH_TIME";
            /// <summary>
            /// 住址
            /// </summary>
            public const string ADDRESS = "ADDRESS";
            /// <summary>
            /// 工作单位
            /// </summary>
            public const string SERVICE_AGENCY = "SERVICE_AGENCY";
            /// <summary>
            /// 费别
            /// </summary>
            public const string CHARGE_TYPE = "CHARGE_TYPE";
            /// <summary>
            /// 入院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 新军卫就诊流水号，其他HIS数据库和VISIT_ID一样 
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 就诊时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 就诊类型(IP-住院 OP-门诊)
            /// </summary>
            public const string VISIT_TYPE = "VISIT_TYPE";
            /// <summary>
            /// 住院号
            /// </summary>
            public const string INP_NO = "INP_NO";
            /// <summary>
            /// 主治医师
            /// </summary>
            public const string PARENT_DOCTOR = "PARENT_DOCTOR";
            /// <summary>
            /// 主任医师
            /// </summary>
            public const string SUPER_DOCTOR = "SUPER_DOCTOR";
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 床号
            /// </summary>
            public const string BED_CODE = "BED_CODE";
            /// <summary>
            /// 床标号
            /// </summary>
            public const string BED_LABEL = "BED_LABEL";
            /// <summary>
            /// 病人病情
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
            /// <summary>
            /// 经治医师
            /// </summary>
            public const string INCHARGE_DOCTOR = "INCHARGE_DOCTOR";
            /// <summary>
            /// 经治医师ID(是系统登录账号，非员工编号)
            /// </summary>
            public const string INCHARGE_DOCTOR_ID = "INCHARGE_DOCTOR_ID";
            /// <summary>
            /// 病情诊断
            /// </summary>
            public const string DIAGNOSIS = "DIAGNOSIS";
            /// <summary>
            /// 出院日期
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 出院方式
            /// </summary>
            public const string DISCHARGE_MODE = "DISCHARGE_MODE";
            /// <summary>
            /// 出院科室代码
            /// </summary>
            public const string DEPT_DISCHARGE_FROM = "DEPT_DISCHARGE_FROM";
            /// <summary>
            /// 病案归档状态
            /// </summary>
            public const string MR_STATUS = "MR_STATUS";
            /// <summary>
            /// 过敏药物
            /// </summary>
            public const string ALLERGY_DRUGS = "ALLERGY_DRUGS";
            ///<summary>
            ///病人身份
            ///</summary>
            public const string IDENTITY = "IDENTITY";
            ///<summary>
            ///病人身份证号码
            ///</summary>
            public const string ID_NO = "ID_NO";
            /// <summary>
            /// 护理等级
            /// </summary>
            public const string NURSING_CLASS = "NURSING_CLASS";
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

        }
    }
}
