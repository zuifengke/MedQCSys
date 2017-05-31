// **************************************************************
// 平台公用模块之权限控制器
// Creator:yehui  Date:2014-10-24
// Copyright : Heren Health Services Co.,Ltd.
// **************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;
using System.Xml;
using EMRDBLib;

namespace Heren.MedQC.Core
{
    public class RightHandler
    {
        private static RightHandler m_instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RightHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new RightHandler();
                return m_instance;
            }
        }
        private List<HdpRoleGrant> m_lstHdpRoleGrant = null;
        public List<HdpRoleGrant> LstHdpRoleGrant
        {
            get { return this.m_lstHdpRoleGrant; }
            set { this.m_lstHdpRoleGrant = value; }
        }

        private RightHandler()
        {
        }
        public bool HasRight(string szRightKey)
        {
            if (this.m_lstHdpRoleGrant == null)
                return false;
            if (string.IsNullOrEmpty(szRightKey) )
                return true;
            var result = LstHdpRoleGrant.Exists(m => m.RoleRightKey == szRightKey);
            return result;
        }
    }
}
