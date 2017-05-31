using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.ChatClient
{
    public static class SystemCache
    {
        private static List<UserInfo> m_lstUserInfo = null;

        /// <summary>
        /// 所有用户信息
        /// </summary>
        public static List<UserInfo> LstUserInfo
        {
            get
            {
                if (m_lstUserInfo == null)
                {
                    if (UserAccess.Instance.GetAllUserInfos(ref m_lstUserInfo) != SystemData.ReturnValue.OK)
                    {
                        m_lstUserInfo = new List<UserInfo>();
                    }
                }
                return m_lstUserInfo;
            }
        }
    }
}
