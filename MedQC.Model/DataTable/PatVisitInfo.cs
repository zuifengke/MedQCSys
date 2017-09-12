using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 病人就诊信息类
    /// </summary>
    [System.Serializable]
    public class PatVisitInfo : DbTypeBase
    {
        private string m_szPatientID = string.Empty;
        /// <summary>
        /// 获取或设置病人ID
        /// </summary>
        public string PATIENT_ID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }

        private string m_szPatientName = string.Empty;
        /// <summary>
        /// 获取或设置病人姓名
        /// </summary>
        public string PATIENT_NAME
        {
            get { return this.m_szPatientName; }
            set { this.m_szPatientName = value; }
        }

        private string m_szPatientSex = string.Empty;
        /// <summary>
        /// 获取或设置性别显示名
        /// </summary>
        public string PATIENT_SEX
        {
            get { return this.m_szPatientSex; }
            set { this.m_szPatientSex = value; }
        }

        private DateTime m_dtBirthTime ;
        /// <summary>
        /// 获取或设置出生时间
        /// </summary>
        public DateTime BIRTH_TIME
        {
            get { return this.m_dtBirthTime; }
            set { this.m_dtBirthTime = value; }
        }


        private string m_szFamilyAddress = string.Empty;
        /// <summary>
        /// 获取或设置家庭住址
        /// </summary>
        public string ADDRESS
        {
            get { return this.m_szFamilyAddress; }
            set { this.m_szFamilyAddress = value; }
        }

        private string m_szServiceAgency = string.Empty;
        /// <summary>
        /// 获取或设置工作单位
        /// </summary>
        public string SERVICE_AGENCY
        {
            get { return this.m_szServiceAgency; }
            set { this.m_szServiceAgency = value; }
        }

        private string m_szOccupation = string.Empty;
        /// <summary>
        /// 获取或设置职业
        /// </summary>
        public string Occupation
        {
            get { return this.m_szOccupation; }
            set { this.m_szOccupation = value; }
        }

        private string m_szChargeType = string.Empty;
        /// <summary>
        /// 获取或设置费别
        /// </summary>
        public string CHARGE_TYPE
        {
            get { return this.m_szChargeType; }
            set { this.m_szChargeType = value; }
        }

        private string m_szVisitID = string.Empty;
        /// <summary>
        /// 获取或设置就诊ID
        /// </summary>
        public string VISIT_ID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }
        /// <summary>
        /// 新军卫 就诊流水号
        /// </summary>
        public string VISIT_NO { get; set; }
        private string m_szInpNo = string.Empty;
        /// <summary>
        /// 获取或设置住院号
        /// </summary>
        public string INP_NO
        {
            get { return this.m_szInpNo; }
            set { this.m_szInpNo = value; }
        }

        private DateTime m_dtVisitTime;
        /// <summary>
        /// 获取或设置就诊时间
        /// </summary>
        public DateTime VISIT_TIME
        {
            get { return this.m_dtVisitTime; }
            set { this.m_dtVisitTime = value; }
        }
        public DateTime ADM_WARD_TIME { get; set; }

        private string m_szVisitType = "IP";
        /// <summary>
        /// 获取或设置就诊类型
        /// </summary>
        public string VISIT_TYPE
        {
            get { return this.m_szVisitType; }
            set { this.m_szVisitType = value; }
        }

        private string m_szDeptCode = string.Empty;
        /// <summary>
        /// 获取或设置就诊科室代码
        /// </summary>
        public string DEPT_CODE
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }

        private string m_szDeptName = string.Empty;
        /// <summary>
        /// 获取或设置就诊科室
        /// </summary>
        public string DEPT_NAME
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }

        private string m_szWardCode = string.Empty;
        /// <summary>
        /// 获取或设置就诊病区码
        /// </summary>
        public string WARD_CODE
        {
            get { return this.m_szWardCode; }
            set { this.m_szWardCode = value; }
        }

        private string m_szWardName = string.Empty;
        /// <summary>
        /// 获取或设置就诊病区名称
        /// </summary>
        public string WardName
        {
            get { return this.m_szWardName; }
            set { this.m_szWardName = value; }
        }
        private string m_szBedCode = string.Empty;
        /// <summary>
        /// 获取或设置床位，设置了Ward后必要
        /// </summary>
        public string BED_CODE
        {
            get { return this.m_szBedCode; }
            set { this.m_szBedCode = value; }
        }
       

        private string m_szDiagnosis = string.Empty;
        /// <summary>
        /// 获取或设置诊断名称
        /// </summary>
        public string DIAGNOSIS
        {
            get { return this.m_szDiagnosis; }
            set { this.m_szDiagnosis = value; }
        }

        private string m_allergyDrugs = null;
        /// <summary>
        /// 获取或设置过敏药物
        /// </summary>
        public string ALLERGY_DRUGS
        {
            get { return this.m_allergyDrugs; }
            set { this.m_allergyDrugs = value; }
        }
        /// <summary>
        /// 床标号
        /// </summary>
        public string BED_LABEL {get;set;}

        private string m_inchargeDoctor = null;
        /// <summary>
        /// 获取或设置经治医生
        /// </summary>
        public string INCHARGE_DOCTOR
        {
            get { return this.m_inchargeDoctor; }
            set { this.m_inchargeDoctor = value; }
        }
        /// <summary>
        /// 获取或设置经治医生ID(为系统登录账号)
        /// </summary>
        public string INCHARGE_DOCTOR_ID { get; set; }

        private string m_SuperDoctor = null;
        /// <summary>
        /// 获取或设置主任医生
        /// </summary>
        public string SUPER_DOCTOR
        {
            get { return this.m_SuperDoctor; }
            set { this.m_SuperDoctor = value; }
        }
        /// <summary>
        /// 主治医师
        /// </summary>
        public string PARENT_DOCTOR { get; set; }
        private string m_patientCondition = null;
        /// <summary>
        /// 获取或设置病情状态
        /// </summary>
        public string PATIENT_CONDITION
        {
            get { return this.m_patientCondition; }
            set { this.m_patientCondition = value; }
        }

        private string m_nursingClass = null;
        /// <summary>
        /// 获取或设置护理等级
        /// </summary>
        public string NURSING_CLASS
        {
            get { return this.m_nursingClass; }
            set { this.m_nursingClass = value; }
        }

        private string m_TotalScore = null;
        /// <summary>
        /// 获取或设置病案评分总分
        /// </summary>
        public string TotalScore
        {
            get { return this.m_TotalScore; }
            set { this.m_TotalScore = value; }
        }
        private double m_prepayments = 0;
        /// <summary>
        /// 获取或设置预交金
        /// </summary>
        public double PREPAYMENTS
        {
            get { return this.m_prepayments; }
            set { this.m_prepayments = value; }
        }

        private double m_totalCosts = 0;
        /// <summary>
        /// 获取或设置累计费用
        /// </summary>
        public double TOTAL_COSTS
        {
            get { return m_totalCosts; }
            set { m_totalCosts = value; }
        }

        private double m_totalCharges = 0;
        /// <summary>
        /// 获取或设置已结费用
        /// </summary>
        public double TOTAL_CHARGES
        {
            get { return this.m_totalCharges; }
            set { this.m_totalCharges = value; }
        }

        private DateTime m_dtDischargeTime;
        /// <summary>
        /// 获取或设置出院时间
        /// </summary>
        public DateTime DISCHARGE_TIME
        {
            get { return this.m_dtDischargeTime; }
            set { this.m_dtDischargeTime = value; }
        }

        private string m_szDischargeDeptCode = string.Empty;
        /// <summary>
        /// 获取或设置出院科室代码
        /// </summary>
        public string DischargeDeptCode 
        {
            get { return this.m_szDischargeDeptCode; }
            set { this.m_szDischargeDeptCode = value; }
        }

        private string m_szDischargeDeptName = string.Empty;
        /// <summary>
        /// 获取或设置出院科室
        /// </summary>
        public string DischargeDeptName
        {
            get { return this.m_szDischargeDeptName; }
            set { this.m_szDischargeDeptName = value; }
        }

        private string m_szDischargeMode = null;
        /// <summary>
        /// 获取或设置出院方式
        /// </summary>
        public string DISCHARGE_MODE
        {
            get { return this.m_szDischargeMode; }
            set { this.m_szDischargeMode = value; }
        }

        private string m_szAttendingDoctor = null;
        /// <summary>
        /// 获取或设置主管医师
        /// </summary>
        public string AttendingDoctor
        {
            get { return m_szAttendingDoctor; }
            set { m_szAttendingDoctor = value; }
        }
        private string m_szQCResultStatus = string.Empty;
        /// <summary>
        /// 获取或设置病案质量审查状态
        /// </summary>
        public string QCResultStatus
        {
            get { return this.m_szQCResultStatus; }
            set { this.m_szQCResultStatus = value; }
        }

        private string m_szMRStatus = string.Empty;
        /// <summary>
        /// 获取或设置归档状态
        /// </summary>
        public string MR_STATUS
        {
            get { return this.m_szMRStatus; }
            set { this.m_szMRStatus = value; }
        }

        private DateTime m_dtLogDateTime;
        /// <summary>
        /// 获取或设置报病情时间
        /// </summary>
        public DateTime LogDateTime
        {
            get { return this.m_dtLogDateTime; }
            set { this.m_dtLogDateTime = value; }
        }
        private bool m_HasWorstBug = false;

        private string m_identity = null;
        /// <summary>
        /// 获取或设置身份
        /// </summary>
        public string IDENTITY
        {
            get { return this.m_identity; }
            set { this.m_identity = value; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string ID_NO { get; set; }
        public PatVisitInfo()
        {
            this.Initialize();
        }
        private int m_nAge;
        /// <summary>
        /// 获取或设置年龄
        /// </summary>
        public int Age
        {
            get { return this.m_nAge; }
            set { this.m_nAge = value; }
        }
        /// <summary>
        /// 是否手术
        /// </summary>
        public bool IsOperation { get; set; }
        /// <summary>
        /// 是否输血
        /// </summary>
        public bool IsBlood { get; set; }

        public List<MedDocInfo> MedDocInfos { get; set; }
        /// <summary>
        /// 初始化为缺省值
        /// </summary>
        public void Initialize()
        {
            this.ADM_WARD_TIME = this.DefaultTime;
            this.m_szPatientID = string.Empty;
            this.m_szPatientName = string.Empty;
            this.m_szPatientSex = string.Empty;
            this.m_szOccupation = string.Empty;
            this.m_szServiceAgency = string.Empty;
            this.m_dtBirthTime = base.DefaultTime;
            this.m_szFamilyAddress = string.Empty;
            this.VISIT_NO = string.Empty;
            this.m_szVisitID = string.Empty;
            this.m_szInpNo = string.Empty;
            this.m_szVisitType = "IP";
            this.m_dtVisitTime = base.DefaultTime;
            this.m_szDeptCode = string.Empty;
            this.m_szDeptName = string.Empty;
            this.m_szWardCode = string.Empty;
            this.m_szWardName = string.Empty;
            this.m_szBedCode = string.Empty;
            this.m_szDiagnosis = string.Empty;
            this.m_inchargeDoctor = string.Empty;
            this.m_nursingClass = string.Empty;
            this.m_patientCondition = string.Empty;
            this.m_allergyDrugs = string.Empty;
            this.m_prepayments = 0;
            this.m_totalCharges = 0;
            this.m_totalCosts = 0;
            this.m_dtDischargeTime = base.DefaultTime;
            this.m_szDischargeMode = string.Empty;
            this.m_szDischargeDeptCode = string.Empty;
            this.m_szDischargeDeptName = string.Empty;
            this.m_dtLogDateTime = base.DefaultTime;
            this.m_szQCResultStatus = string.Empty;
            this.m_nAge = 0;
        }

        /// <summary>
        /// 已重写
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.m_szPatientName;
        }

        /// <summary>
        /// 判定指定的病人就诊信息是否是同一次就诊
        /// </summary>
        /// <param name="patVisit">待判定病人就诊信息</param>
        /// <returns>是否是同一次就诊</returns>
        public bool IsPatVisitSame(PatVisitInfo patVisit)
        {
            if (patVisit == null)
                return false;
            if (this.PATIENT_ID != patVisit.PATIENT_ID || this.VISIT_ID != patVisit.VISIT_ID)
                return false;
            if (this.VISIT_TIME != patVisit.VISIT_TIME || this.VISIT_TYPE != patVisit.VISIT_TYPE)
                return false;
            return true;
        }
    }

}
