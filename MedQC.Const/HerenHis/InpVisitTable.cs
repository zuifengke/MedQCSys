
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 患者首页信息表
        /// </summary>
        public struct InpVisitTable
        {
            /// <summary>
            /// 院区
            /// </summary>
            public const string BRANCH_HOSP = "BRANCH_HOSP";
            /// <summary>
            /// 婴儿总数
            /// </summary>
            public const string BABY_NO = "BABY_NO";
            /// <summary>
            /// 有出院31天内再住院计划
            /// </summary>
            public const string HAS_ADMISSION_AGAIN_PLAN = "HAS_ADMISSION_AGAIN_PLAN";
            /// <summary>
            /// 入院前颅脑损伤患者昏迷时间（天）
            /// </summary>
            public const string COMA_DATE_DAYS_BEFORE = "COMA_DATE_DAYS_BEFORE";
            /// <summary>
            /// 入院前颅脑损伤患者昏迷时间（小时）
            /// </summary>
            public const string COMA_DATE_HOURS_BEFORE = "COMA_DATE_HOURS_BEFORE";
            /// <summary>
            /// 入院前颅脑损伤患者昏迷时间（分）
            /// </summary>
            public const string COMA_DATE_MINUTES_BEFORE = "COMA_DATE_MINUTES_BEFORE";
            /// <summary>
            /// 入院后颅脑损伤患者昏迷时间（天）
            /// </summary>
            public const string COMA_DATE_DAYS_AFTER = "COMA_DATE_DAYS_AFTER";
            /// <summary>
            /// 入院后颅脑损伤患者昏迷时间（小时）
            /// </summary>
            public const string COMA_DATE_HOURS_AFTER = "COMA_DATE_HOURS_AFTER";
            /// <summary>
            /// 入院后颅脑损伤患者昏迷时间（分）
            /// </summary>
            public const string COMA_DATE_MINUTES_AFTER = "COMA_DATE_MINUTES_AFTER";
            /// <summary>
            /// 单病种管理
            /// </summary>
            public const string SINGLE_DISEASE_MANAGE = "SINGLE_DISEASE_MANAGE";
            /// <summary>
            /// 临床路径管理
            /// </summary>
            public const string CP_MANAGE = "CP_MANAGE";
            /// <summary>
            /// 转归情况
            /// </summary>
            public const string PROGNOSIS = "PROGNOSIS";
            /// <summary>
            /// 转入医疗机构名称
            /// </summary>
            public const string TO_MEDICAL_INSTITUTION = "TO_MEDICAL_INSTITUTION";
            /// <summary>
            /// 再入院目的
            /// </summary>
            public const string FOR_INPATIENT_PURPOSES = "FOR_INPATIENT_PURPOSES";
            /// <summary>
            /// 收费方案ID
            /// </summary>
            public const string CHARGE_PRICE_SCHEDULE_ID = "CHARGE_PRICE_SCHEDULE_ID";
            /// <summary>
            /// 责任护士
            /// </summary>
            public const string BY_NURSE = "BY_NURSE";
            /// <summary>
            /// 责任护士姓名
            /// </summary>
            public const string BY_NURSE_NAME = "BY_NURSE_NAME";
            /// <summary>
            /// 无效患者标识 0或null：有效 1表示无效
            /// </summary>
            public const string INVALID_PATIENT = "INVALID_PATIENT";
            /// <summary>
            /// 住院流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 患者标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 住院号
            /// </summary>
            public const string INP_NO = "INP_NO";
            /// <summary>
            /// 患者本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string NAME = "NAME";
            /// <summary>
            /// 患者性别
            /// </summary>
            public const string SEX = "SEX";
            /// <summary>
            /// 患者年龄
            /// </summary>
            public const string AGE = "AGE";
            /// <summary>
            /// 患者本次入院费别
            /// </summary>
            public const string CHARGE_TYPE = "CHARGE_TYPE";
            /// <summary>
            /// 身份
            /// </summary>
            public const string IDENTITY = "IDENTITY";
            /// <summary>
            /// 医疗保障类型
            /// </summary>
            public const string SECURITY_TYPE = "SECURITY_TYPE";
            /// <summary>
            /// 医疗保障帐号
            /// </summary>
            public const string SECURITY_NO = "SECURITY_NO";
            /// <summary>
            /// 入院科室
            /// </summary>
            public const string DEPT_ADMISSION_TO = "DEPT_ADMISSION_TO";
            /// <summary>
            /// 入院日期及时间
            /// </summary>
            public const string ADMISSION_DATE_TIME = "ADMISSION_DATE_TIME";
            /// <summary>
            /// 出院科室
            /// </summary>
            public const string DEPT_DISCHARGE_FROM = "DEPT_DISCHARGE_FROM";
            /// <summary>
            /// 出院日期及时间
            /// </summary>
            public const string DISCHARGE_DATE_TIME = "DISCHARGE_DATE_TIME";
            /// <summary>
            /// 职业
            /// </summary>
            public const string OCCUPATION = "OCCUPATION";
            /// <summary>
            /// 婚姻状况
            /// </summary>
            public const string MARITAL_STATUS = "MARITAL_STATUS";
            /// <summary>
            /// 军种（人员类别）
            /// </summary>
            public const string ARMED_SERVICES = "ARMED_SERVICES";
            /// <summary>
            /// 勤务
            /// </summary>
            public const string DUTY = "DUTY";
            /// <summary>
            /// 合同单位
            /// </summary>
            public const string UNIT_IN_CONTRACT = "UNIT_IN_CONTRACT";
            /// <summary>
            /// 在职标志
            /// </summary>
            public const string WORKING_STATUS = "WORKING_STATUS";
            /// <summary>
            /// 训练伤
            /// </summary>
            public const string TRAINING_INJURY = "TRAINING_INJURY";
            /// <summary>
            /// 工作单位
            /// </summary>
            public const string SERVICE_AGENCY = "SERVICE_AGENCY";
            /// <summary>
            /// 工作单位地址
            /// </summary>
            public const string WORKING_ADDRESS = "WORKING_ADDRESS";
            /// <summary>
            /// 工作单位地址邮编
            /// </summary>
            public const string WORKING_ADDRESS_ZIPCODE = "WORKING_ADDRESS_ZIPCODE";
            /// <summary>
            /// 单位电话号码
            /// </summary>
            public const string PHONE_NUMBER_BUSINESS = "PHONE_NUMBER_BUSINESS";
            /// <summary>
            /// 隶属大单位
            /// </summary>
            public const string TOP_UNIT = "TOP_UNIT";
            /// <summary>
            /// 医疗体系患者标志
            /// </summary>
            public const string SERVICE_SYSTEM_INDICATOR = "SERVICE_SYSTEM_INDICATOR";
            /// <summary>
            /// 联系人姓名
            /// </summary>
            public const string NEXT_OF_KIN = "NEXT_OF_KIN";
            /// <summary>
            /// 与联系人关系
            /// </summary>
            public const string RELATIONSHIP = "RELATIONSHIP";
            /// <summary>
            /// 联系人地址
            /// </summary>
            public const string NEXT_OF_KIN_ADDR = "NEXT_OF_KIN_ADDR";
            /// <summary>
            /// 联系人邮政编码
            /// </summary>
            public const string NEXT_OF_KIN_ZIPCODE = "NEXT_OF_KIN_ZIPCODE";
            /// <summary>
            /// 联系人电话
            /// </summary>
            public const string NEXT_OF_KIN_PHONE = "NEXT_OF_KIN_PHONE";
            /// <summary>
            /// 入院方式
            /// </summary>
            public const string PATIENT_CLASS = "PATIENT_CLASS";
            /// <summary>
            /// 住院目的
            /// </summary>
            public const string ADMISSION_CAUSE = "ADMISSION_CAUSE";
            /// <summary>
            /// 入院病情
            /// </summary>
            public const string PAT_ADM_CONDITION = "PAT_ADM_CONDITION";
            /// <summary>
            /// 门诊接诊日期
            /// </summary>
            public const string CONSULTING_DATE = "CONSULTING_DATE";
            /// <summary>
            /// 门诊接诊医师ID
            /// </summary>
            public const string CONSULTING_DOCTOR_ID = "CONSULTING_DOCTOR_ID";
            /// <summary>
            /// 门诊就诊流水号
            /// </summary>
            public const string OUTP_VISIT_NO = "OUTP_VISIT_NO";
            /// <summary>
            /// 在院流转状态
            /// </summary>
            public const string ADT_STATUS = "ADT_STATUS";
            /// <summary>
            /// 住院业务类型
            /// </summary>
            public const string VISIT_TYPE = "VISIT_TYPE";
            /// <summary>
            /// 备注
            /// </summary>
            public const string NOTES = "NOTES";
            /// <summary>
            /// 办理入院登记的操作员ID
            /// </summary>
            public const string OPERATOR_ID = "OPERATOR_ID";
            /// <summary>
            /// 办理入院登记的时间
            /// </summary>
            public const string OPERATOR_DATE_TIME = "OPERATOR_DATE_TIME";
            /// <summary>
            /// 抢救次数
            /// </summary>
            public const string EMER_TREAT_TIMES = "EMER_TREAT_TIMES";
            /// <summary>
            /// 抢救成功次数
            /// </summary>
            public const string ESC_EMER_TIMES = "ESC_EMER_TIMES";
            /// <summary>
            /// 病重天数
            /// </summary>
            public const string SERIOUS_COND_DAYS = "SERIOUS_COND_DAYS";
            /// <summary>
            /// 病危天数
            /// </summary>
            public const string CRITICAL_COND_DAYS = "CRITICAL_COND_DAYS";
            /// <summary>
            /// ICU天数
            /// </summary>
            public const string ICU_DAYS = "ICU_DAYS";
            /// <summary>
            /// CCU天数
            /// </summary>
            public const string CCU_DAYS = "CCU_DAYS";
            /// <summary>
            /// 特别护理天数
            /// </summary>
            public const string SPEC_LEVEL_NURS_DAYS = "SPEC_LEVEL_NURS_DAYS";
            /// <summary>
            /// 一级护理天数
            /// </summary>
            public const string FIRST_LEVEL_NURS_DAYS = "FIRST_LEVEL_NURS_DAYS";
            /// <summary>
            /// 二级护理天数
            /// </summary>
            public const string SECOND_LEVEL_NURS_DAYS = "SECOND_LEVEL_NURS_DAYS";
            /// <summary>
            /// 尸检标识
            /// </summary>
            public const string AUTOPSY_INDICATOR = "AUTOPSY_INDICATOR";
            /// <summary>
            /// 血型
            /// </summary>
            public const string BLOOD_TYPE = "BLOOD_TYPE";
            /// <summary>
            /// RH血型
            /// </summary>
            public const string BLOOD_TYPE_RH = "BLOOD_TYPE_RH";
            /// <summary>
            /// 输液反应次数
            /// </summary>
            public const string INFUSION_REACT_TIMES = "INFUSION_REACT_TIMES";
            /// <summary>
            /// 输血次数
            /// </summary>
            public const string BLOOD_TRAN_TIMES = "BLOOD_TRAN_TIMES";
            /// <summary>
            /// 输血总量
            /// </summary>
            public const string BLOOD_TRAN_VOL = "BLOOD_TRAN_VOL";
            /// <summary>
            /// 输血反应次数
            /// </summary>
            public const string BLOOD_TRAN_REACT_TIMES = "BLOOD_TRAN_REACT_TIMES";
            /// <summary>
            /// 发生褥疮次数
            /// </summary>
            public const string DECUBITAL_ULCER_TIMES = "DECUBITAL_ULCER_TIMES";
            /// <summary>
            /// 过敏药物
            /// </summary>
            public const string ALERGY_DRUGS = "ALERGY_DRUGS";
            /// <summary>
            /// 不良反应药物
            /// </summary>
            public const string ADVERSE_REACTION_DRUGS = "ADVERSE_REACTION_DRUGS";
            /// <summary>
            /// 病案价值
            /// </summary>
            public const string MR_VALUE = "MR_VALUE";
            /// <summary>
            /// 病案质量
            /// </summary>
            public const string MR_QUALITY = "MR_QUALITY";
            /// <summary>
            /// 随诊标志
            /// </summary>
            public const string FOLLOW_INDICATOR = "FOLLOW_INDICATOR";
            /// <summary>
            /// 随诊期限
            /// </summary>
            public const string FOLLOW_INTERVAL = "FOLLOW_INTERVAL";
            /// <summary>
            /// 随诊期限单位
            /// </summary>
            public const string FOLLOW_INTERVAL_UNITS = "FOLLOW_INTERVAL_UNITS";
            /// <summary>
            /// 科主任
            /// </summary>
            public const string DIRECTOR = "DIRECTOR";
            /// <summary>
            /// 主治医师
            /// </summary>
            public const string ATTENDING_DOCTOR = "ATTENDING_DOCTOR";
            /// <summary>
            /// 经治医师
            /// </summary>
            public const string DOCTOR_IN_CHARGE = "DOCTOR_IN_CHARGE";
            /// <summary>
            /// 主（副主）任医师
            /// </summary>
            public const string CHIEF_DOCTOR = "CHIEF_DOCTOR";
            /// <summary>
            /// 进修医师
            /// </summary>
            public const string ADVANCED_STUDIES_DOCTOR = "ADVANCED_STUDIES_DOCTOR";
            /// <summary>
            /// 研究生实习医师
            /// </summary>
            public const string PRACTICE_DOCTOR_OF_GRADUATE = "PRACTICE_DOCTOR_OF_GRADUATE";
            /// <summary>
            /// 实习医师
            /// </summary>
            public const string PRACTICE_DOCTOR = "PRACTICE_DOCTOR";
            /// <summary>
            /// 质控护士
            /// </summary>
            public const string NURSE_OF_CONTROL_QUALITY = "NURSE_OF_CONTROL_QUALITY";
            /// <summary>
            /// 质控日期
            /// </summary>
            public const string DATE_OF_CONTROL_QUALITY = "DATE_OF_CONTROL_QUALITY";
            /// <summary>
            /// 质控医师
            /// </summary>
            public const string DOCTOR_OF_CONTROL_QUALITY = "DOCTOR_OF_CONTROL_QUALITY";
            /// <summary>
            /// HBSAG
            /// </summary>
            public const string HBSAG_INDICATOR = "HBSAG_INDICATOR";
            /// <summary>
            /// HCV-AB
            /// </summary>
            public const string HCV_AB_INDICATOR = "HCV_AB_INDICATOR";
            /// <summary>
            /// HIV-AB
            /// </summary>
            public const string HIV_AB_INDICATOR = "HIV_AB_INDICATOR";
            /// <summary>
            /// 是否为本院第一例
            /// </summary>
            public const string FIRST_CASE_INDICATOR = "FIRST_CASE_INDICATOR";
            /// <summary>
            /// 出院方式
            /// </summary>
            public const string DISCHARGE_DISPOSITION = "DISCHARGE_DISPOSITION";
            /// <summary>
            /// 总费用
            /// </summary>
            public const string TOTAL_COSTS = "TOTAL_COSTS";
            /// <summary>
            /// 实付费用
            /// </summary>
            public const string TOTAL_PAYMENTS = "TOTAL_PAYMENTS";
            /// <summary>
            /// 编目日期
            /// </summary>
            public const string CATALOG_DATE = "CATALOG_DATE";
            /// <summary>
            /// 编目人
            /// </summary>
            public const string CATALOGER = "CATALOGER";
            /// <summary>
            /// 示教病历
            /// </summary>
            public const string TEACHING_MR = "TEACHING_MR";
            /// <summary>
            /// 是否自身输血
            /// </summary>
            public const string AUTOTRANSFUSION = "AUTOTRANSFUSION";
            /// <summary>
            /// 医疗付款方式
            /// </summary>
            public const string MEDICAL_PAYMENT = "MEDICAL_PAYMENT";
            /// <summary>
            /// 门诊接诊医师
            /// </summary>
            public const string CONSULTING_DOCTOR = "CONSULTING_DOCTOR";
            /// <summary>
            /// 科主任ID
            /// </summary>
            public const string DIRECTOR_ID = "DIRECTOR_ID";
            /// <summary>
            /// 主治医师ID
            /// </summary>
            public const string ATTENDING_DOCTOR_ID = "ATTENDING_DOCTOR_ID";
            /// <summary>
            /// 经治医师ID
            /// </summary>
            public const string DOCTOR_IN_CHARGE_ID = "DOCTOR_IN_CHARGE_ID";
            /// <summary>
            /// 主（副主）任医师
            /// </summary>
            public const string CHIEF_DOCTOR_ID = "CHIEF_DOCTOR_ID";

        }
    }
}
