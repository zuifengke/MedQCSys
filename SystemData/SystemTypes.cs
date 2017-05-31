// ***********************************************************
// 封装客户端解决方案内共享的类型集合
// Creator:YangMingkun  Date:2009-6-22
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;
using MedDocSys.Common;

namespace MedDocSys.DataLayer
{
    #region "enum"
    /// <summary>
    /// 用户角色枚举
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// 住院医生(0)IP doctor
        /// </summary>
        InDoctor = 0,
        /// <summary>
        /// 门诊医生(1)OP doctor
        /// </summary>
        OutDoctor = 1,
        /// <summary>
        /// 护士(2)
        /// </summary>
        Nurse = 2,
        /// <summary>
        /// 其他人员(3)
        /// </summary>
        Other = 3
    }

    /// <summary>
    /// 用户等级枚举
    /// </summary>
    public enum UserLevel
    {
        /// <summary>
        /// 正常,主治医师
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 上级医师
        /// </summary>
        Higher = 1,
        /// <summary>
        /// 主任医师
        /// </summary>
        Chief = 2
    }

    /// <summary>
    /// 用户权限枚举
    /// </summary>
    public enum UserPower
    {
        /// <summary>
        /// 不可见(0)
        /// </summary>
        Invisible = 0,
        /// <summary>
        /// 只读(1)
        /// </summary>
        ReadOnly = 1,
        /// <summary>
        /// 只读和打印(2)
        /// </summary>
        ReadPrint = 2,
        /// <summary>
        /// 只读打印和导出(3)
        /// </summary>
        ReadPrintExport = 3,
        /// <summary>
        /// 可编辑(4)
        /// </summary>
        Editable = 4
    }

    /// <summary>
    /// 就诊类型枚举
    /// </summary>
    public enum VisitType
    {
        /// <summary>
        /// 门诊(0)
        /// </summary>
        OP = 0,
        /// <summary>
        /// 急诊(1)
        /// </summary>
        EP = 1,
        /// <summary>
        /// 住院(2)
        /// </summary>
        IP = 2,
        /// <summary>
        /// 其他(3)
        /// </summary>
        Other = 3
    }

    /// <summary>
    /// 数据库文档状态
    /// </summary>
    public enum ServerDocState
    {
        /// <summary>
        /// 未知状态(0)
        /// </summary>
        None = 0,
        /// <summary>
        /// 正常(1)
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 锁定(2)
        /// </summary>
        Locked = 2,
        /// <summary>
        /// 归档(3)
        /// </summary>
        Archived = 3,
        /// <summary>
        /// 作废(4)
        /// </summary>
        Canceled = 4
    }

    /// <summary>
    /// 客户端文档状态
    /// </summary>
    public enum DocumentState
    {
        /// <summary>
        /// 未知状态(0)
        /// </summary>
        None = 0,
        /// <summary>
        /// 新建状态(1)
        /// </summary>
        New = 1,
        /// <summary>
        /// 编辑状态(2)
        /// </summary>
        Edit = 2,
        /// <summary>
        /// 修订状态(3)
        /// </summary>
        Revise = 3,
        /// <summary>
        /// 浏览状态(4)
        /// </summary>
        View = 4
    }

    /// <summary>
    /// 页面布局样式
    /// </summary>
    public enum PageLayout
    {
        /// <summary>
        /// 普通
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 装订线在顶端
        /// </summary>
        TopMirrored = 1,
        /// <summary>
        /// 装订线在左端
        /// </summary>
        LeftMirrored = 2
    }

    /// <summary>
    /// 页脚文本布局样式
    /// </summary>
    public enum PageFooterAlign
    {
        /// <summary>
        /// 居中
        /// </summary>
        Middle = 0,
        /// <summary>
        /// 靠左侧
        /// </summary>
        Left = 1,
        /// <summary>
        /// 靠右侧
        /// </summary>
        Right = 2
    }

    /// <summary>
    /// 文档历史版本
    /// </summary>
    public enum HistoryVersion
    {
        /// <summary>
        /// 第一个版本
        /// </summary>
        First,
        /// <summary>
        /// 前一个版本
        /// </summary>
        Prevision,
        /// <summary>
        /// 下一个版本
        /// </summary>
        Next,
        /// <summary>
        /// 最新版本
        /// </summary>
        Latest
    }
    #endregion

    #region "class"
    /// <summary>
    /// 字体大小结构
    /// </summary>
    public class FontSize
    {
        public string m_szName = "楷体";
        public float m_fSize = 14f;
        /// <summary>
        /// 获取或设置字号名称
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }
        /// <summary>
        /// 获取或设置字号浮点大小
        /// </summary>
        public float Size
        {
            get { return this.m_fSize; }
            set { this.m_fSize = value; }
        }

        public FontSize(string name, float size)
        {
            Name = name;
            Size = size;
        }

        public override string ToString()
        {
            return this.m_szName;
        }
    }

    /// <summary>
    /// 系统用户信息
    /// </summary>
    public class UserInfo : ICloneable
    {
        protected string m_szID = string.Empty;         //用户ID
        protected string m_szName = string.Empty;       //用户名
        protected string m_szDeptCode = string.Empty;   //科室代码
        protected int m_nDeptCode = 0;                  //哈希值表示的科室代码
        protected string m_szDeptName = string.Empty;   //科室名称
        protected string m_szPwd = string.Empty;        //用户密码
        protected UserRole m_eRole = UserRole.Other;    //用户角色
        protected UserLevel m_eLevel = UserLevel.Normal;//用户等级
        protected UserPower m_ePower = UserPower.Invisible;  //用户权限

        /// <summary>
        /// 获取或设置用户ID
        /// </summary>
        public string ID
        {
            get { return this.m_szID; }
            set { this.m_szID = value; }
        }
        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }
        /// <summary>
        /// 获取或设置用户的科室代码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set
            {
                this.m_nDeptCode = 0;
                this.m_szDeptCode = value;
            }
        }
        /// <summary>
        /// 获取或设置用户的科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string Password
        {
            get { return this.m_szPwd; }
            set { this.m_szPwd = value; }
        }
        /// <summary>
        /// 获取或设置用户角色
        /// </summary>
        public UserRole Role
        {
            get { return this.m_eRole; }
            set { this.m_eRole = value; }
        }
        /// <summary>
        /// 获取或设置用户等级
        /// </summary>
        public UserLevel Level
        {
            get { return this.m_eLevel; }
            set { this.m_eLevel = value; }
        }
        /// <summary>
        /// 获取或设置用户权限
        /// </summary>
        public UserPower Power
        {
            get { return this.m_ePower; }
            set { this.m_ePower = value; }
        }

        public UserInfo()
        {
            this.Initialize();
        }

        public object Clone()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.ID = this.m_szID;
            userInfo.Name = this.m_szName;
            userInfo.DeptCode = this.m_szDeptCode;
            userInfo.DeptName = this.m_szDeptName;
            userInfo.Password = this.m_szPwd;
            userInfo.Role = this.m_eRole;
            userInfo.Level = this.m_eLevel;
            userInfo.Power = this.m_ePower;
            return userInfo;
        }

        /// <summary>
        /// 初始化为缺省值
        /// </summary>
        public void Initialize()
        {
            this.m_szID = string.Empty;
            this.m_szName = string.Empty;
            this.m_szPwd = string.Empty;

            this.m_ePower = UserPower.Invisible;
            this.m_eRole = UserRole.Other;
            this.m_eLevel = UserLevel.Normal;

            this.m_nDeptCode = 0;
            this.m_szDeptCode = string.Empty;
            this.m_szDeptName = string.Empty;
        }

        /// <summary>
        /// 比较两个UserInfo对象
        /// </summary>
        /// <param name="clsUserInfo">比较的UserInfo对象</param>
        /// <returns>bool</returns>
        public bool Equals(UserInfo clsUserInfo)
        {
            if (clsUserInfo == null)
                return false;

            return ((this.m_szID == clsUserInfo.ID)
                && (this.m_szName == clsUserInfo.Name)
                && (this.m_szDeptCode == clsUserInfo.DeptCode)
                && (this.m_szDeptName == clsUserInfo.DeptName)
                && (this.m_szPwd == clsUserInfo.Password)
                && (this.m_eRole == clsUserInfo.Role)
                && (this.m_eLevel == clsUserInfo.Level)
                && (this.m_ePower == clsUserInfo.Power));
        }

        /// <summary>
        /// 获取文档创建权限类型
        /// </summary>
        /// <returns></returns>
        public static string GetDocRight(UserInfo userInfo)
        {
            if (userInfo == null)
                return SystemData.UserType.OTHER;
            if (userInfo.Role == UserRole.InDoctor)
                return SystemData.UserType.IP_DOCTOR;
            else if (userInfo.Role == UserRole.OutDoctor)
                return SystemData.UserType.OP_DOCTOR;
            else if (userInfo.Role == UserRole.Nurse)
                return SystemData.UserType.NURSE;
            return SystemData.UserType.OTHER;
        }

        /// <summary>
        /// 根据用户角色代码获取角色枚举
        /// </summary>
        /// <param name="szRole">用户角色代码</param>
        /// <param name="eUserRole">返回的用户角色枚举</param>
        /// <returns>bool</returns>
        public static bool GetRoleEnum(string szRole, ref UserRole eUserRole)
        {
            if (GlobalMethods.AppMisc.IsEmptyString(szRole))
                return false;
            try
            {
                short shRole = short.Parse(szRole);
                eUserRole = (UserRole)shRole;
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据用户等级代码获取等级枚举
        /// </summary>
        /// <param name="szLevel">用户等级代码</param>
        /// <param name="eUserLevel">返回的用户等级枚举</param>
        /// <returns>bool</returns>
        public static bool GetLevelEnum(string szLevel, ref UserLevel eUserLevel)
        {
            if (GlobalMethods.AppMisc.IsEmptyString(szLevel))
                return false;
            try
            {
                short shLevel = short.Parse(szLevel);
                eUserLevel = (UserLevel)shLevel;
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据权限代码获取权限枚举
        /// </summary>
        /// <param name="shType">用户权限代码</param>
        /// <returns>bool</returns>
        public static bool GetPowerEnum(string szPower, ref UserPower eUserPower)
        {
            if (GlobalMethods.AppMisc.IsEmptyString(szPower))
                return false;
            try
            {
                short shPower = short.Parse(szPower);
                eUserPower = (UserPower)shPower;
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证UserInfo数据的合法性(抛出异常信息)
        /// </summary>
        public static void Validate(UserInfo userInfo)
        {
            if (userInfo == null)
                throw new Exception("用户信息数据不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(userInfo.ID))
                throw new Exception("用户ID参数不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(userInfo.Name))
                throw new Exception("用户姓名参数不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(userInfo.DeptCode))
                throw new Exception("用户所属科室代码参数不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(userInfo.DeptName))
                throw new Exception("用户所属科室名称参数不能为空!");
        }

        /// <summary>
        /// 获取科室代码对应的哈希值
        /// </summary>
        /// <returns>哈希值</returns>
        public int GetHashDeptCode()
        {
            if (string.IsNullOrEmpty(this.m_szDeptCode))
                return 0;
            if (this.m_nDeptCode == 0)
                this.m_nDeptCode = Math.Abs(this.m_szDeptCode.GetHashCode());
            return this.m_nDeptCode;
        }

        /// <summary>
        /// 已重写
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.m_szName;
        }

        /// <summary>
        /// 把用户信息对象解析为字符串形式
        /// </summary>
        /// <param name="userInfo">用户信息对象</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>用户信息字符串</returns>
        public static string GetStrFromUserInfo(UserInfo userInfo, string szSplitChar)
        {
            if (userInfo == null)
                userInfo = new UserInfo();

            StringBuilder sbUserInfo = new StringBuilder();
            sbUserInfo.Append(userInfo.ID);
            sbUserInfo.Append(szSplitChar);
            sbUserInfo.Append(userInfo.Name);
            sbUserInfo.Append(szSplitChar);
            sbUserInfo.Append(userInfo.Password);
            sbUserInfo.Append(szSplitChar);
            sbUserInfo.Append(userInfo.DeptCode);
            sbUserInfo.Append(szSplitChar);
            sbUserInfo.Append(userInfo.DeptName);
            sbUserInfo.Append(szSplitChar);
            sbUserInfo.Append(((int)userInfo.Role));
            sbUserInfo.Append(szSplitChar);
            sbUserInfo.Append(((int)userInfo.Level));
            sbUserInfo.Append(szSplitChar);
            sbUserInfo.Append(((int)userInfo.Power));
            sbUserInfo.Append(szSplitChar);

            return sbUserInfo.ToString();
        }

        /// <summary>
        /// 把字符串表达的用户信息解析为用户信息对象
        /// </summary>
        /// <param name="szUserInfoData">字符串表达的用户信息</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>UserInfo</returns>
        public static UserInfo GetUserInfoFromStr(string szUserInfoData, string szSplitChar)
        {
            if (GlobalMethods.AppMisc.IsEmptyString(szUserInfoData))
                throw new Exception("用户信息数据不能为空!");

            UserInfo userInfo = new UserInfo();

            string[] arrUserData = szUserInfoData.Split(new string[] { szSplitChar }, StringSplitOptions.None);

            if (arrUserData.Length > 0)
                userInfo.ID = arrUserData[0];

            if (arrUserData.Length > 1)
                userInfo.Name = arrUserData[1];

            if (arrUserData.Length > 2)
                userInfo.Password = arrUserData[2];

            if (arrUserData.Length > 3)
                userInfo.DeptCode = arrUserData[3];

            if (arrUserData.Length > 4)
                userInfo.DeptName = arrUserData[4];

            if (arrUserData.Length > 5)
            {
                UserRole eRole = UserRole.InDoctor;
                if (!UserInfo.GetRoleEnum(arrUserData[5], ref eRole))
                {
                    throw new Exception("用户角色代码参数非法!");
                }
                userInfo.Role = eRole;
            }

            if (arrUserData.Length > 6)
            {
                UserLevel eLevel = UserLevel.Normal;
                if (!UserInfo.GetLevelEnum(arrUserData[6], ref eLevel))
                {
                    throw new Exception("用户等级代码参数非法!");
                }
                userInfo.Level = eLevel;
            }

            if (arrUserData.Length > 7)
            {
                UserPower ePower = UserPower.Invisible;
                if (!UserInfo.GetPowerEnum(arrUserData[7], ref ePower))
                {
                    throw new Exception("用户权限代码参数非法!");
                }
                userInfo.Power = ePower;
            }
            return userInfo;
        }
    }

    /// <summary>
    /// 病人信息
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
                return (int)GlobalMethods.SysTime.DateDiff(DateInterval.Year, this.m_dtBirthTime, SysTimeHelper.Instance.Now);
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
            if (GlobalMethods.AppMisc.IsEmptyString(patientInfo.ID))
                throw new Exception("病人ID参数不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(patientInfo.Name))
                throw new Exception("病人姓名参数不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(patientInfo.Gender))
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
        /// <summary>
        /// 把病人信息对象解析为一个字符串
        /// </summary>
        /// <param name="patientInfo">病人信息对象</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>string</returns>
        public static string GetStrFromPatientInfo(PatientInfo patientInfo, string szSplitChar)
        {
            if (patientInfo == null)
                patientInfo = new PatientInfo();

            StringBuilder sbPatientInfo = new StringBuilder();
            sbPatientInfo.Append(patientInfo.ID);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.Name);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.GenderCode);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.Gender);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.BirthTime);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.BirthPlace);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.FamilyAddr);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.MaritalCode);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.Marital);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.Department);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.OccupationCode);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.Occupation);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.RaceCode);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.RaceName);
            sbPatientInfo.Append(szSplitChar);
            sbPatientInfo.Append(patientInfo.ConfidCode);
            sbPatientInfo.Append(szSplitChar);

            return sbPatientInfo.ToString();
        }
        /// <summary>
        /// 把字符串表达的病人信息对象转换成病人信息对象
        /// </summary>
        /// <param name="szPatientData">病人信息字符串</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>PatientInfo</returns>
        public static PatientInfo GetPatientInfoFromStr(string szPatientData, string szSplitChar)
        {
            PatientInfo patientInfo = new PatientInfo();

            string[] arrPatientData = szPatientData.Split(new string[] { szSplitChar }, StringSplitOptions.None);

            if (arrPatientData.Length > 0)
                patientInfo.ID = arrPatientData[0];

            if (arrPatientData.Length > 1)
                patientInfo.Name = arrPatientData[1];

            if (arrPatientData.Length > 2)
                patientInfo.GenderCode = arrPatientData[2];

            if (arrPatientData.Length > 3)
                patientInfo.Gender = arrPatientData[3];

            if (arrPatientData.Length > 4)
            {
                try
                {
                    patientInfo.BirthTime = DateTime.Parse(arrPatientData[4]);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteLog("PatientInfo.GetPatientInfoFromStr", new string[] { "szPatientData" }
                        , new object[] { szPatientData }, ex);
                    throw new Exception("病人出生日期参数非法!");
                }
            }

            if (arrPatientData.Length > 5)
                patientInfo.BirthPlace = arrPatientData[5];

            if (arrPatientData.Length > 6)
                patientInfo.FamilyAddr = arrPatientData[6];

            if (arrPatientData.Length > 7)
                patientInfo.MaritalCode = arrPatientData[7];

            if (arrPatientData.Length > 8)
                patientInfo.Marital = arrPatientData[8];

            if (arrPatientData.Length > 9)
                patientInfo.Department = arrPatientData[9];

            if (arrPatientData.Length > 10)
                patientInfo.OccupationCode = arrPatientData[10];

            if (arrPatientData.Length > 11)
                patientInfo.Occupation = arrPatientData[11];

            if (arrPatientData.Length > 12)
                patientInfo.RaceCode = arrPatientData[12];

            if (arrPatientData.Length > 13)
                patientInfo.RaceName = arrPatientData[13];

            if (arrPatientData.Length > 14)
                patientInfo.ConfidCode = arrPatientData[14];

            return patientInfo;
        }
    }

    /// <summary>
    /// 就诊信息
    /// </summary>
    public class VisitInfo : ICloneable
    {
        private string m_szID = string.Empty;       //就诊号
        private string m_szInpID = string.Empty;     //住院号
        private VisitType m_eType = VisitType.OP;   //就诊类型：0门诊 1急诊 2入院
        private DateTime m_dtTime = DateTime.Now;   //就诊时间
        private string m_szDeptCode = string.Empty; //就诊科室码
        private string m_szDeptName = string.Empty; //就诊科室名称
        private string m_szWardCode = string.Empty; //就诊病区码
        private string m_szWardName = string.Empty; //就诊病区名称
        private string m_szCareCode = string.Empty; //就诊护理单元码
        private string m_szCareName = string.Empty; //就诊护理单元名称
        private string m_szBedCode = string.Empty;  //床位码
        /// <summary>
        /// 获取或设置就诊号(对于住院：传入第几次入院;对于门诊：传入门诊序号)
        /// </summary>
        public string ID
        {
            get { return this.m_szID; }
            set { this.m_szID = value; }
        }
        /// <summary>
        /// 获取或设置住院号
        /// </summary>
        public string InpID
        {
            get { return this.m_szInpID; }
            set { this.m_szInpID = value; }
        }
        /// <summary>
        /// 获取或设置就诊类型
        /// </summary>
        public VisitType Type
        {
            get { return this.m_eType; }
            set { this.m_eType = value; }
        }
        /// <summary>
        /// 获取或设置就诊时间
        /// </summary>
        public DateTime Time
        {
            get { return this.m_dtTime; }
            set { this.m_dtTime = value; }
        }
        /// <summary>
        /// 获取或设置就诊科室码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        /// <summary>
        /// 获取或设置就诊病区码
        /// </summary>
        public string WardCode
        {
            get { return this.m_szWardCode; }
            set { this.m_szWardCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊病区名称
        /// </summary>
        public string WardName
        {
            get { return this.m_szWardName; }
            set { this.m_szWardName = value; }
        }
        /// <summary>
        /// 获取或设置床位，设置了Ward后必要
        /// </summary>
        public string BedCode
        {
            get { return this.m_szBedCode; }
            set { this.m_szBedCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊护理单元码
        /// </summary>
        public string CareCode
        {
            get { return this.m_szCareCode; }
            set { this.m_szCareCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊护理单元名称
        /// </summary>
        public string CareName
        {
            get { return this.m_szCareName; }
            set { this.m_szCareName = value; }
        }

        public VisitInfo()
        {
            this.Initialize();
        }

        public object Clone()
        {
            VisitInfo visitInfo = new VisitInfo();
            visitInfo.ID = this.m_szID;
            visitInfo.InpID = this.m_szInpID;
            visitInfo.Type = this.m_eType;
            visitInfo.Time = this.m_dtTime;
            visitInfo.DeptCode = this.m_szDeptCode;
            visitInfo.DeptName = this.m_szDeptName;
            visitInfo.WardCode = this.m_szWardCode;
            visitInfo.WardName = this.m_szWardName;
            visitInfo.CareCode = this.m_szCareCode;
            visitInfo.CareName = this.m_szCareName;
            visitInfo.BedCode = this.m_szBedCode;
            return visitInfo;
        }

        /// <summary>
        /// 初始化为缺省值
        /// </summary>
        public void Initialize()
        {
            this.m_szID = string.Empty;
            this.m_szInpID = string.Empty;
            this.m_eType = VisitType.OP;
            this.m_dtTime = DateTime.Now;
            this.m_szDeptCode = string.Empty;
            this.m_szDeptName = string.Empty;
            this.m_szWardCode = string.Empty;
            this.m_szWardName = string.Empty;
            this.m_szBedCode = string.Empty;
            this.m_szCareCode = string.Empty;
            this.m_szCareName = string.Empty;
        }
        /// <summary>
        /// 验证VisitInfo数据的合法性(抛出异常信息)
        /// </summary>
        public static void Validate(VisitInfo visitInfo)
        {
            if (visitInfo == null)
                throw new Exception("病人就诊信息数据不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(visitInfo.ID))
                throw new Exception("病人就诊ID参数不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(visitInfo.DeptCode))
                throw new Exception("病人就诊科室代码参数不能为空!");
            if (GlobalMethods.AppMisc.IsEmptyString(visitInfo.DeptName))
                throw new Exception("病人就诊科室名称参数不能为空!");
        }
        /// <summary>
        /// 比较两个VisitInfo对象
        /// </summary>
        /// <param name="clsVisitInfo">比较的VisitInfo对象</param>
        /// <returns>bool</returns>
        public bool Equals(VisitInfo clsVisitInfo)
        {
            if (clsVisitInfo == null)
                return false;

            return ((this.m_szID == clsVisitInfo.ID)
                && (this.m_szInpID == clsVisitInfo.InpID)
                && (this.m_eType == clsVisitInfo.Type)
                && (DateTime.Compare(this.m_dtTime, clsVisitInfo.Time) == 0)
                && (this.m_szDeptCode == clsVisitInfo.DeptCode)
                && (this.m_szDeptName == clsVisitInfo.DeptName)
                && (this.m_szWardCode == clsVisitInfo.WardCode)
                && (this.m_szWardName == clsVisitInfo.WardName)
                && (this.m_szBedCode == clsVisitInfo.BedCode)
                && (this.m_szCareCode == clsVisitInfo.CareCode)
                && (this.m_szCareName == clsVisitInfo.CareName));
        }
        /// <summary>
        /// 根据就诊类型代码获取就诊类型枚举
        /// </summary>
        /// <param name="shType">就诊类型代码</param>
        /// <returns>bool</returns>
        public static bool GetTypeEnum(string szType, ref VisitType eVisitType)
        {
            if (GlobalMethods.AppMisc.IsEmptyString(szType))
                return false;
            try
            {
                short shType = short.Parse(szType);
                eVisitType = (VisitType)shType;
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取就诊类型对应的所写
        /// </summary>
        /// <returns></returns>
        public static string GetVisitTypeStr(VisitInfo visitInfo)
        {
            if (visitInfo == null)
                return SystemData.VisitType.IP;
            if (visitInfo.Type == VisitType.OP || visitInfo.Type == VisitType.EP)
                return SystemData.VisitType.OP;
            else
                return SystemData.VisitType.IP;
        }
        /// <summary>
        /// 已重写
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.m_szID;
        }
        /// <summary>
        /// 把就诊信息对象转换成就诊信息字符串
        /// </summary>
        /// <param name="visitInfo">就诊信息对象</param>
        /// <param name="szSplitChar">就诊信息字符串</param>
        /// <returns>string</returns>
        public static string GetStrFromVisitInfo(VisitInfo visitInfo, string szSplitChar)
        {
            if (visitInfo == null)
                visitInfo = new VisitInfo();

            StringBuilder sbVisitInfo = new StringBuilder();
            sbVisitInfo.Append(visitInfo.ID);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.InpID);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(((int)visitInfo.Type).ToString());
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.Time);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.DeptCode);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.DeptName);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.WardCode);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.WardName);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.CareCode);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.CareName);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.BedCode);
            sbVisitInfo.Append(szSplitChar);

            return sbVisitInfo.ToString();
        }
        /// <summary>
        /// 把字符串表达的就诊信息转换为就诊信息对象
        /// </summary>
        /// <param name="szVisitData">字符串表达的就诊信息</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>就诊信息对象</returns>
        public static VisitInfo GetVisitInfoFromStr(string szVisitData, string szSplitChar)
        {
            VisitInfo visitInfo = new VisitInfo();

            string[] arrVisitData = szVisitData.Split(new string[] { szSplitChar }, StringSplitOptions.None);

            if (arrVisitData.Length > 0)
                visitInfo.ID = arrVisitData[0];

            if (arrVisitData.Length > 1)
                visitInfo.InpID = arrVisitData[1];

            if (arrVisitData.Length > 2)
            {
                VisitType eType = VisitType.OP;
                if (!VisitInfo.GetTypeEnum(arrVisitData[2], ref eType))
                {
                    throw new Exception("就诊类型参数非法!");
                }
                visitInfo.Type = eType;
            }

            if (arrVisitData.Length > 3)
            {
                try
                {
                    visitInfo.Time = DateTime.Parse(arrVisitData[3]);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteLog("VisitInfo.GetVisitInfoFromStr", new string[] { "szVisitData" }
                        , new object[] { szVisitData }, ex);
                    throw new Exception("就诊时间参数非法!");
                }
            }

            if (arrVisitData.Length > 4)
                visitInfo.DeptCode = arrVisitData[4];

            if (arrVisitData.Length > 5)
                visitInfo.DeptName = arrVisitData[5];

            if (arrVisitData.Length > 6)
                visitInfo.WardCode = arrVisitData[6];

            if (arrVisitData.Length > 7)
                visitInfo.WardName = arrVisitData[7];

            if (arrVisitData.Length > 8)
                visitInfo.CareCode = arrVisitData[8];

            if (arrVisitData.Length > 9)
                visitInfo.CareName = arrVisitData[9];

            if (arrVisitData.Length > 10)
                visitInfo.BedCode = arrVisitData[10];

            return visitInfo;
        }
    }

    /// <summary>
    /// 页面和纸张信息类
    /// </summary>
    public class PageSettings : ICloneable
    {
        private int m_nWidth = 210;
        private int m_nHeight = 297;
        private bool m_bLandscape = false;
        private int m_nLeftMargin = 15;
        private int m_nRightMargin = 15;
        private int m_nTopMargin = 20;
        private int m_nBottomMargin = 20;
        private int m_nStartPageNo = 1;
        private int m_nOffsetTop = 0;
        private PageLayout m_ePageLayout = PageLayout.Normal;
        private string m_szFooterText = string.Empty;
        private bool m_bFooterLine = false;
        private PageFooterAlign m_eFooterAlign = PageFooterAlign.Middle;

        /// <summary>
        /// 获取或设置纸张宽度
        /// </summary>
        public int Width
        {
            get { return this.m_nWidth; }
            set { this.m_nWidth = value; }
        }

        /// <summary>
        /// 获取或设置纸张宽度
        /// </summary>
        public int Height
        {
            get { return this.m_nHeight; }
            set { this.m_nHeight = value; }
        }

        /// <summary>
        /// 获取或设置纸张是否是横向的
        /// </summary>
        public bool Landscape
        {
            get { return this.m_bLandscape; }
            set { this.m_bLandscape = value; }
        }

        /// <summary>
        /// 获取或设置页面左边距
        /// </summary>
        public int LeftMargin
        {
            get { return this.m_nLeftMargin; }
            set { this.m_nLeftMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面右边距
        /// </summary>
        public int RightMargin
        {
            get { return this.m_nRightMargin; }
            set { this.m_nRightMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面上边距
        /// </summary>
        public int TopMargin
        {
            get { return this.m_nTopMargin; }
            set { this.m_nTopMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面下边距
        /// </summary>
        public int BottomMargin
        {
            get { return this.m_nBottomMargin; }
            set { this.m_nBottomMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面布局
        /// </summary>
        public PageLayout PageLayout
        {
            get { return this.m_ePageLayout; }
            set { this.m_ePageLayout = value; }
        }

        /// <summary>
        /// 获取或设置文档起始页码
        /// </summary>
        public int StartPageNo
        {
            get { return this.m_nStartPageNo; }
            set { this.m_nStartPageNo = value; }
        }

        /// <summary>
        /// 获取或设置顶端打印偏移量
        /// </summary>
        public int OffsetTop
        {
            get { return this.m_nOffsetTop; }
            set { this.m_nOffsetTop = value; }
        }

        /// <summary>
        /// 获取或设置页脚上是否显示一条横线
        /// </summary>
        public bool FooterLine
        {
            get { return this.m_bFooterLine; }
            set { this.m_bFooterLine = value; }
        }

        /// <summary>
        /// 获取或设置页脚显示的文本
        /// </summary>
        public string FooterText
        {
            get { return this.m_szFooterText; }
            set { this.m_szFooterText = value; }
        }

        /// <summary>
        /// 获取或设置页脚文本的对齐样式
        /// </summary>
        public PageFooterAlign FooterAlign
        {
            get { return this.m_eFooterAlign; }
            set { this.m_eFooterAlign = value; }
        }

        public void Initialize()
        {
            this.m_nWidth = 210;
            this.m_nHeight = 297;
            this.m_bLandscape = false;
            this.m_nLeftMargin = 25;
            this.m_nRightMargin = 10;
            this.m_nTopMargin = 16;
            this.m_nBottomMargin = 16;
            this.m_nStartPageNo = 1;
            this.m_nOffsetTop = 0;
            this.m_ePageLayout = PageLayout.Normal;
            this.m_eFooterAlign = PageFooterAlign.Middle;
            this.m_bFooterLine = false;
            this.m_szFooterText = string.Empty;
        }

        public object Clone()
        {
            PageSettings pageSettings = new PageSettings();
            pageSettings.Width = this.m_nWidth;
            pageSettings.Height = this.m_nHeight;
            pageSettings.Landscape = this.m_bLandscape;
            pageSettings.PageLayout = this.m_ePageLayout;
            pageSettings.LeftMargin = this.m_nLeftMargin;
            pageSettings.RightMargin = this.m_nRightMargin;
            pageSettings.TopMargin = this.m_nTopMargin;
            pageSettings.BottomMargin = this.m_nBottomMargin;
            pageSettings.OffsetTop = this.m_nOffsetTop;
            pageSettings.StartPageNo = this.m_nStartPageNo;
            pageSettings.FooterAlign = this.m_eFooterAlign;
            pageSettings.FooterLine = this.m_bFooterLine;
            pageSettings.FooterText = this.m_szFooterText;
            return pageSettings;
        }
    }

    /// <summary>
    /// 纸张信息类
    /// </summary>
    public class PaperInfo : ICloneable
    {
        private string m_szName = string.Empty;
        private float m_fWidth = 0f;
        private float m_fHeight = 0f;
        private string m_szPrinter = string.Empty;
        /// <summary>
        /// 获取或设置纸张名称
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }
        /// <summary>
        /// 获取或设置纸张宽
        /// </summary>
        public float Width
        {
            get { return this.m_fWidth; }
            set { this.m_fWidth = value; }
        }
        /// <summary>
        /// 获取或设置纸张高
        /// </summary>
        public float Height
        {
            get { return this.m_fHeight; }
            set { this.m_fHeight = value; }
        }
        /// <summary>
        /// 获取或设置该纸张对应的打印机
        /// </summary>
        public string Printer
        {
            get { return this.m_szPrinter; }
            set { this.m_szPrinter = value; }
        }

        public PaperInfo()
        {
        }
        /// <summary>
        /// 实例化纸张信息
        /// </summary>
        /// <param name="name">纸张名称</param>
        /// <param name="width">纸张宽</param>
        /// <param name="height">纸张高</param>
        public PaperInfo(string name, float width, float height)
        {
            this.m_szName = name;
            this.m_fWidth = width;
            this.m_fHeight = height;
        }
        /// <summary>
        /// 实例化纸张信息
        /// </summary>
        /// <param name="name">纸张名称</param>
        /// <param name="width">纸张宽</param>
        /// <param name="height">纸张高</param>
        /// <param name="printer">纸张对应的打印机</param>
        public PaperInfo(string name, float width, float height, string printer)
            : this (name, width, height)
        {
            this.m_szPrinter = printer;
        }
        /// <summary>
        /// 返回纸张名称
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.m_szName;
        }

        public object Clone()
        {
            return new PaperInfo(this.m_szName, this.m_fWidth, this.m_fHeight, this.m_szPrinter);
        }
    }

    /// <summary>
    /// 文档主条目信息
    /// </summary>
    public class DocumentSectionInfo : ICloneable
    {
        private string m_szID = null;
        /// <summary>
        /// 获取或设置文档主条目ID
        /// </summary>
        public string ID
        {
            get { return this.m_szID; }
            set { this.m_szID = value; }
        }

        private string m_szName = null;
        /// <summary>
        /// 获取或设置文档主条目名称
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }

        private string m_szText = null;
        /// <summary>
        /// 获取或设置文档主条目下用户输入的文本
        /// </summary>
        public string Text
        {
            get { return this.m_szText; }
            set { this.m_szText = value; }
        }

        public DocumentSectionInfo()
        {
        }

        public DocumentSectionInfo(string szSectionID, string szSectionName)
        {
            this.m_szID = szSectionID;
            this.m_szName = szSectionName;
        }

        public object Clone()
        {
            DocumentSectionInfo sectionInfo = new DocumentSectionInfo();
            sectionInfo.ID = this.m_szID;
            sectionInfo.Name = this.m_szName;
            sectionInfo.Text = this.m_szText;
            return sectionInfo;
        }
    }
    #endregion
}
