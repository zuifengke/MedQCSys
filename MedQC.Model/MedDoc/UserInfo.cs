using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 用户信息类
    /// </summary>
    [System.Serializable]
    public class UserInfo : DbTypeBase
    {
        private string m_szID = string.Empty;            //用户ID
        private string m_szName = string.Empty;        //用户姓名
        private string m_szDeptCode = string.Empty;       //科室编码
        private string m_szDeptName = string.Empty;     //科室名称
        protected string m_szPassword = string.Empty;        //用户密码
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
        /// 获取或设置用户姓名
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }
        /// <summary>
        /// 获取或设置科室编码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        /// <summary>
        /// 获取或设置科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        protected string m_szGrade = string.Empty;        //用户等级
        /// <summary>
        /// 用户等级
        /// </summary>
        public string Grade
        {
            get { return this.m_szGrade; }
            set { this.m_szGrade = value; }
        }
        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string Password
        {
            get { return this.m_szPassword; }
            set { this.m_szPassword = value; }
        }
        private UserRole m_eRole = UserRole.Other;
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
        /// 与患者相关的医生级别，经治医生或上级医生或是主任医生
        /// </summary>
        public UserLevel Level
        {
            get { return this.m_eLevel; }
            set { this.m_eLevel = value; }
        }
        public UserPower Power
        {
            get { return this.m_ePower; }
            set { this.m_ePower = value; }
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
        public override string ToString()
        {
            return this.Name;
        }
    }

}
