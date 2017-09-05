/***************************************************
 * 和仁HIS患者首页实体类
 * 作者：yehui
 * 时间：2017-06-05
 **************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.HerenHis
{
    /// <summary>
    /// 患者首页信息
    /// </summary>
    public class InpVisit : DbTypeBase
    {
        /// <summary>
        /// 住院流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 患者标识号
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO { get; set; }
        /// <summary>
        /// 患者本次住院标识
        /// </summary>
        public decimal VISIT_ID { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 患者年龄
        /// </summary>
        public string AGE { get; set; }
        /// <summary>
        /// 患者本次入院费别
        /// </summary>
        public string CHARGE_TYPE { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string IDENTITY { get; set; }
        /// <summary>
        /// 医疗保障类型
        /// </summary>
        public string SECURITY_TYPE { get; set; }
        /// <summary>
        /// 医疗保障帐号
        /// </summary>
        public string SECURITY_NO { get; set; }
        /// <summary>
        /// 入院科室
        /// </summary>
        public string DEPT_ADMISSION_TO { get; set; }
        /// <summary>
        /// 入院日期及时间
        /// </summary>
        public DateTime ADMISSION_DATE_TIME { get; set; }
        /// <summary>
        /// 出院科室
        /// </summary>
        public string DEPT_DISCHARGE_FROM { get; set; }
        /// <summary>
        /// 出院日期及时间
        /// </summary>
        public DateTime DISCHARGE_DATE_TIME { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string OCCUPATION { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string MARITAL_STATUS { get; set; }
        /// <summary>
        /// 军种（人员类别）
        /// </summary>
        public string ARMED_SERVICES { get; set; }
        /// <summary>
        /// 勤务
        /// </summary>
        public string DUTY { get; set; }
        /// <summary>
        /// 合同单位
        /// </summary>
        public string UNIT_IN_CONTRACT { get; set; }
        /// <summary>
        /// 在职标志
        /// </summary>
        public decimal WORKING_STATUS { get; set; }
        /// <summary>
        /// 训练伤
        /// </summary>
        public decimal TRAINING_INJURY { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string SERVICE_AGENCY { get; set; }
        /// <summary>
        /// 工作单位地址
        /// </summary>
        public string WORKING_ADDRESS { get; set; }
        /// <summary>
        /// 工作单位地址邮编
        /// </summary>
        public string WORKING_ADDRESS_ZIPCODE { get; set; }
        /// <summary>
        /// 单位电话号码
        /// </summary>
        public string PHONE_NUMBER_BUSINESS { get; set; }
        /// <summary>
        /// 隶属大单位
        /// </summary>
        public string TOP_UNIT { get; set; }
        /// <summary>
        /// 医疗体系患者标志
        /// </summary>
        public decimal SERVICE_SYSTEM_INDICATOR { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string NEXT_OF_KIN { get; set; }
        /// <summary>
        /// 与联系人关系
        /// </summary>
        public string RELATIONSHIP { get; set; }
        /// <summary>
        /// 联系人地址
        /// </summary>
        public string NEXT_OF_KIN_ADDR { get; set; }
        /// <summary>
        /// 联系人邮政编码
        /// </summary>
        public string NEXT_OF_KIN_ZIPCODE { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string NEXT_OF_KIN_PHONE { get; set; }
        /// <summary>
        /// 入院方式
        /// </summary>
        public string PATIENT_CLASS { get; set; }
        /// <summary>
        /// 住院目的
        /// </summary>
        public string ADMISSION_CAUSE { get; set; }
        /// <summary>
        /// 入院病情
        /// </summary>
        public string PAT_ADM_CONDITION { get; set; }
        /// <summary>
        /// 门诊接诊日期
        /// </summary>
        public DateTime CONSULTING_DATE { get; set; }
        /// <summary>
        /// 门诊接诊医师ID
        /// </summary>
        public string CONSULTING_DOCTOR_ID { get; set; }
        /// <summary>
        /// 门诊就诊流水号
        /// </summary>
        public string OUTP_VISIT_NO { get; set; }
        /// <summary>
        /// 在院流转状态
        /// </summary>
        public decimal ADT_STATUS { get; set; }
        /// <summary>
        /// 住院业务类型
        /// </summary>
        public string VISIT_TYPE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string NOTES { get; set; }
        /// <summary>
        /// 办理入院登记的操作员ID
        /// </summary>
        public string OPERATOR_ID { get; set; }
        /// <summary>
        /// 办理入院登记的时间
        /// </summary>
        public DateTime OPERATOR_DATE_TIME { get; set; }
        /// <summary>
        /// 抢救次数
        /// </summary>
        public decimal EMER_TREAT_TIMES { get; set; }
        /// <summary>
        /// 抢救成功次数
        /// </summary>
        public decimal ESC_EMER_TIMES { get; set; }
        /// <summary>
        /// 病危天数
        /// </summary>
        public decimal CRITICAL_COND_DAYS { get; set; }
        /// <summary>
        /// 病重天数
        /// </summary>
        public decimal SERIOUS_COND_DAYS { get; set; }
        /// <summary>
        /// ICU天数
        /// </summary>
        public decimal ICU_DAYS { get; set; }
        /// <summary>
        /// CCU天数
        /// </summary>
        public decimal CCU_DAYS { get; set; }
        /// <summary>
        /// 特别护理天数
        /// </summary>
        public decimal SPEC_LEVEL_NURS_DAYS { get; set; }
        /// <summary>
        /// 一级护理天数
        /// </summary>
        public decimal FIRST_LEVEL_NURS_DAYS { get; set; }
        /// <summary>
        /// 二级护理天数
        /// </summary>
        public decimal SECOND_LEVEL_NURS_DAYS { get; set; }
        /// <summary>
        /// 尸检标识
        /// </summary>
        public decimal AUTOPSY_INDICATOR { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        public string BLOOD_TYPE { get; set; }
        /// <summary>
        /// RH血型
        /// </summary>
        public string BLOOD_TYPE_RH { get; set; }
        /// <summary>
        /// 输液反应次数
        /// </summary>
        public decimal INFUSION_REACT_TIMES { get; set; }
        /// <summary>
        /// 输血次数
        /// </summary>
        public decimal BLOOD_TRAN_TIMES { get; set; }
        /// <summary>
        /// 输血总量
        /// </summary>
        public decimal BLOOD_TRAN_VOL { get; set; }

        /// <summary>
        /// 输血反应次数
        /// </summary>
        public decimal BLOOD_TRAN_REACT_TIMES { get; set; }

        /// <summary>
        /// 发生褥疮次数
        /// </summary>
        public decimal DECUBITAL_ULCER_TIMES { get; set; }

        /// <summary>
        /// 过敏药物
        /// </summary>
        public string ALERGY_DRUGS { get; set; }

        /// <summary>
        /// 不良反应药物
        /// </summary>
        public string ADVERSE_REACTION_DRUGS { get; set; }

        /// <summary>
        /// 病案价值
        /// </summary>
        public string MR_VALUE { get; set; }
        /// <summary>
        /// 病案质量
        /// </summary>
        public string MR_QUALITY { get; set; }
        /// <summary>
        /// 随诊标志
        /// </summary>
        public decimal FOLLOW_INDICATOR { get; set; }
        /// <summary>
        /// 随诊期限
        /// </summary>
        public decimal FOLLOW_decimalERVAL { get; set; }
        /// <summary>
        /// 随诊期限单位
        /// </summary>
        public string FOLLOW_decimalERVAL_UNITS { get; set; }
        /// <summary>
        /// 科主任
        /// </summary>
        public string DIRECTOR { get; set; }
        /// <summary>
        /// 主治医师
        /// </summary>
        public string ATTENDING_DOCTOR { get; set; }
        /// <summary>
        /// 经治医师
        /// </summary>
        public string DOCTOR_IN_CHARGE { get; set; }

        /// <summary>
        /// 质控护士
        /// </summary>
        public string NURSE_OF_CONTROL_QUALITY { get; set; }
        /// <summary>
        /// 实习医师
        /// </summary>
        public string PRACTICE_DOCTOR { get; set; }
        /// <summary>
        /// 研究生实习医师
        /// </summary>
        public string PRACTICE_DOCTOR_OF_GRADUATE { get; set; }
        /// <summary>
        /// 进修医师
        /// </summary>
        public string ADVANCED_STUDIES_DOCTOR { get; set; }
        /// <summary>
        /// 主（副主）任医师
        /// </summary>
        public string CHIEF_DOCTOR { get; set; }
        /// <summary>
        /// HBSAG
        /// </summary>
        public decimal HBSAG_INDICATOR { get; set; }
        /// <summary>
        /// 质控医师
        /// </summary>
        public string DOCTOR_OF_CONTROL_QUALITY { get; set; }
        /// <summary>
        /// 质控日期
        /// </summary>
        public DateTime DATE_OF_CONTROL_QUALITY { get; set; }
        /// <summary>
        /// 是否为本院第一例
        /// </summary>
        public string FIRST_CASE_INDICATOR { get; set; }
        /// <summary>
        ///   HIV-AB
        /// </summary>
        public decimal HIV_AB_INDICATOR { get; set; }
        /// <summary>
        ///   HCV-AB
        /// </summary>
        public decimal HCV_AB_INDICATOR { get; set; }
        /// <summary>
        /// Y 主（副主）任医师
        /// </summary>
        public string CHIEF_DOCTOR_ID { get; set; }
        /// <summary>
        /// 经治医师ID
        /// </summary>
        public string DOCTOR_IN_CHARGE_ID { get; set; }
        /// <summary>
        /// 主治医师ID
        /// </summary>
        public string ATTENDING_DOCTOR_ID { get; set; }
        /// <summary>
        /// 科主任ID
        /// </summary>
        public string DIRECTOR_ID { get; set; }
        /// <summary>
        /// 门诊接诊医师
        /// </summary>
        public string CONSULTING_DOCTOR { get; set; }
        /// <summary>
        /// 医疗付款方式
        /// </summary>
        public string MEDICAL_PAYMENT { get; set; }
        /// <summary>
        /// 是否自身输血
        /// </summary>
        public decimal AUTOTRANSFUSION { get; set; }
        /// <summary>
        /// 示教病历
        /// </summary>
        public decimal TEACHING_MR { get; set; }
        /// <summary>
        /// 编目人
        /// </summary>
        public string CATALOGER { get; set; }
        /// <summary>
        /// 编目日期进行ICD分类或录入日期
        /// </summary>
        public DateTime CATALOG_DATE { get; set; }
        /// <summary>
        /// 实付费用
        /// </summary>
        public decimal TOTAL_PAYMENTS { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal TOTAL_COSTS { get; set; }
        /// <summary>
        /// 出院方式
        /// </summary>
        public string DISCHARGE_DISPOSITION { get; set; }
        public string INVALID_PATIENT { get; set; }
    }
}
