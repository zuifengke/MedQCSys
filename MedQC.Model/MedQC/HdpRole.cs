using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{


    /// <summary>
    /// 角色管理表
    /// </summary>
    public class HdpRole : DbTypeBase
    {
        private string m_szSerialNo = string.Empty;
        private string m_szRoleName = string.Empty;
        private string m_szRoleCode = string.Empty;
        private string m_szRoleBak = string.Empty;
        private string m_szStatus = string.Empty;

        /// <summary>
        /// 获取或设置序号
        /// </summary>
        public string SerialNo
        {
            get { return this.m_szSerialNo; }
            set { this.m_szSerialNo = value; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return this.m_szRoleName; }
            set { this.m_szRoleName = value; }
        }
        /// <summary>
        /// 角色代码
        /// </summary>
        public string RoleCode
        {
            get { return this.m_szRoleCode; }
            set { this.m_szRoleCode = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get { return this.m_szStatus; }
            set { this.m_szStatus = value; }
        }
        /// <summary>
        /// 角色备注
        /// </summary> 
        public string RoleBak
        {
            get { return this.m_szRoleBak; }
            set { this.m_szRoleBak = value; }
        }

        public override string ToString()
        {
            return this.m_szRoleName;
        }
    }

}
