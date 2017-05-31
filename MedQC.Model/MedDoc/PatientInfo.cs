using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{



    /// <summary>
    /// 病人信息，只在病历文书接口调用时使用，质控系统数据访问使用PatVisitInfo类
    /// </summary>
    public class PatientInfo : ICloneable
    {
        private string m_szID = string.Empty; //病人号
        private string m_szName = string.Empty;  //病人姓名

        private string m_szGenderCode = string.Empty; //性别码
        private string m_szGender = string.Empty; //性别显示名

        private DateTime m_dtBirthTime = DateTime.Now; //出生时间

        private string m_szMaritalCode = string.Empty; //婚姻状况码
        private string m_szMarital = string.Empty; //婚姻状况显示名

        private string m_szBirthPlace = string.Empty; //出生地
        private string m_szFamilyAddr = string.Empty; //家庭住址
        private string m_szDepartment = string.Empty; //工作单位(部门)

        private string m_szOccupationCode = string.Empty; //职业代码
        private string m_szOccupation = string.Empty; //职业

        private string m_szRaceCode = string.Empty; //民族代码
        private string m_szRaceName = string.Empty; //民族

        private string m_szConfidCode = string.Empty; //机密性代码

        /// <summary>
        /// 获取或设置病人ID
        /// </summary>
        public string ID
        {
            get { return this.m_szID; }
            set { this.m_szID = value; }
        }
        /// <summary>
        /// 获取或设置病人姓名
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }
        /// <summary>
        /// 获取或设置性别码
        /// </summary>
        public string GenderCode
        {
            get { return this.m_szGenderCode; }
            set { this.m_szGenderCode = value; }
        }
        /// <summary>
        /// 获取或设置性别显示名
        /// </summary>
        public string Gender
        {
            get { return this.m_szGender; }
            set { this.m_szGender = value; }
        }
        /// <summary>
        /// 获取或设置出生时间
        /// </summary>
        public DateTime BirthTime
        {
            get { return this.m_dtBirthTime; }
            set { this.m_dtBirthTime = value; }
        }
        /// <summary>
        /// 获取病人年龄数值
        /// </summary>
        public int AgeValue
        {
            get
            {
                return (int)GlobalMethods.SysTime.DateDiff(DateInterval.Year, this.m_dtBirthTime, DateTime.Now);
            }
        }
        /// <summary>
        /// 获取或设置婚姻状况码
        /// </summary>
        public string MaritalCode
        {
            get { return this.m_szMaritalCode; }
            set { this.m_szMaritalCode = value; }
        }
        /// <summary>
        /// 获取或设置婚姻状况
        /// </summary>
        public string Marital
        {
            get { return this.m_szMarital; }
            set { this.m_szMarital = value; }
        }
        /// <summary>
        /// 获取或设置出生地
        /// </summary>
        public string BirthPlace
        {
            get { return this.m_szBirthPlace; }
            set { this.m_szBirthPlace = value; }
        }
        /// <summary>
        /// 获取或设置家庭住址
        /// </summary>
        public string FamilyAddr
        {
            get { return this.m_szFamilyAddr; }
            set { this.m_szFamilyAddr = value; }
        }
        /// <summary>
        /// 获取或设置工作单位
        /// </summary>
        public string Department
        {
            get { return this.m_szDepartment; }
            set { this.m_szDepartment = value; }
        }
        /// <summary>
        /// 获取或设置职业代码
        /// </summary>
        public string OccupationCode
        {
            get { return this.m_szOccupationCode; }
            set { this.m_szOccupationCode = value; }
        }
        /// <summary>
        /// 获取或设置职业
        /// </summary>
        public string Occupation
        {
            get { return this.m_szOccupation; }
            set { this.m_szOccupation = value; }
        }
        /// <summary>
        /// 获取或设置民族码
        /// </summary>
        public string RaceCode
        {
            get { return this.m_szRaceCode; }
            set { this.m_szRaceCode = value; }
        }
        /// <summary>
        /// 获取或设置民族
        /// </summary>
        public string RaceName
        {
            get { return this.m_szRaceName; }
            set { this.m_szRaceName = value; }
        }
        /// <summary>
        /// 获取或设置病人机密性代码
        /// </summary>
        public string ConfidCode
        {
            get { return this.m_szConfidCode; }
            set { this.m_szConfidCode = value; }
        }

        public PatientInfo()
        {
        }

        public object Clone()
        {
            PatientInfo patientInfo = new PatientInfo();
            patientInfo.ID = this.m_szID;
            patientInfo.Name = this.m_szName;
            patientInfo.GenderCode = this.m_szGenderCode;
            patientInfo.Gender = this.m_szGender;
            patientInfo.BirthTime = this.m_dtBirthTime;
            patientInfo.MaritalCode = this.m_szMaritalCode;
            patientInfo.Marital = this.m_szMarital;
            patientInfo.BirthPlace = this.m_szBirthPlace;
            patientInfo.FamilyAddr = this.m_szFamilyAddr;
            patientInfo.Department = this.m_szDepartment;
            patientInfo.OccupationCode = this.m_szOccupationCode;
            patientInfo.Occupation = this.m_szOccupation;
            patientInfo.RaceCode = this.m_szRaceCode;
            patientInfo.RaceName = this.m_szRaceName;
            patientInfo.ConfidCode = this.m_szConfidCode;
            return patientInfo;
        }

        /// <summary>
        /// 初始化为缺省值
        /// </summary>
        public void Initialize()
        {
            this.m_szID = string.Empty;
            this.m_szName = string.Empty;
            this.m_szGenderCode = string.Empty;
            this.m_dtBirthTime = DateTime.Now;
            this.m_szMaritalCode = string.Empty;
            this.m_szMarital = string.Empty;
            this.m_szBirthPlace = string.Empty;
            this.m_szFamilyAddr = string.Empty;
            this.m_szDepartment = string.Empty;
            this.m_szOccupation = string.Empty;
            this.m_szRaceCode = string.Empty;
            this.m_szRaceName = string.Empty;
            this.m_szConfidCode = string.Empty;
        }
        /// <summary>
        /// 比较两个PatientInfo对象
        /// </summary>
        /// <param name="clsPatientInfo">比较的PatientInfo对象</param>
        /// <returns>bool</returns>
        public bool Equals(PatientInfo clsPatientInfo)
        {
            if (clsPatientInfo == null)
                return false;

            return ((this.m_szID == clsPatientInfo.ID)
                && (this.m_szName == clsPatientInfo.Name)
                && (this.m_szGenderCode == clsPatientInfo.GenderCode)
                && (DateTime.Compare(this.m_dtBirthTime, clsPatientInfo.BirthTime) == 0)
                && (this.m_szMaritalCode == clsPatientInfo.MaritalCode)
                && (this.m_szBirthPlace == clsPatientInfo.BirthPlace)
                && (this.m_szFamilyAddr == clsPatientInfo.FamilyAddr)
                && (this.m_szDepartment == clsPatientInfo.Department)
                && (this.m_szOccupation == clsPatientInfo.Occupation)
                && (this.m_szRaceCode == clsPatientInfo.RaceCode)
                && (this.m_szRaceName == clsPatientInfo.RaceName)
                && (this.m_szConfidCode == clsPatientInfo.ConfidCode));
        }
        /// <summary>
        /// 验证PatientInfo数据的合法性(抛出异常信息)
        /// </summary>
        public static void Validate(PatientInfo patientInfo)
        {
            if (patientInfo == null)
                throw new Exception("病人信息参数不能为空!");
            if (GlobalMethods.Misc.IsEmptyString(patientInfo.ID))
                throw new Exception("病人ID参数不能为空!");
            if (GlobalMethods.Misc.IsEmptyString(patientInfo.Name))
                throw new Exception("病人姓名参数不能为空!");
            if (GlobalMethods.Misc.IsEmptyString(patientInfo.Gender))
                throw new Exception("病人性别参数不能为空!");
        }
        /// <summary>
        /// 已重写
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.m_szName;
        }
      
       
    }
}
