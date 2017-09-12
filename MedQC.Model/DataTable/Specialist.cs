using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    [System.Serializable]
    public class Specialist
    {
        private string m_szUserID = string.Empty;
        /// <summary>
        /// 获取或设置用户ID
        /// </summary>
        public string UserID
        {
            get { return this.m_szUserID; }
            set { this.m_szUserID = value; }
        }

        private string m_szUserName = string.Empty;
        /// <summary>
        /// 获取或设置病人姓名
        /// </summary>
        public string UserName
        {
            get { return this.m_szUserName; }
            set { this.m_szUserName = value; }
        }

        private string m_szDeptCode = string.Empty;
        /// <summary>
        /// 获取或设置科室编号
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }

        private string m_szDeptName = string.Empty;
        /// <summary>
        /// 获取或设置科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }

        private string m_szRoleCode = string.Empty;
        /// <summary>
        /// 获取或设置角色代码
        /// </summary>
        public string RoleCode
        {
            get { return this.m_szRoleCode; }
            set { this.m_szRoleCode = value; }
        }

        private string m_szRoleName = string.Empty;
        /// <summary>
        /// 获取或设置角色名称
        /// </summary>
        public string RoleName
        {
            get { return this.m_szRoleName; }
            set { this.m_szRoleName = value; }
        }

    }


}
