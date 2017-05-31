using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries.Ftp;

namespace EMRDBLib
{

    /// <summary>
    /// FTP配置信息类
    /// </summary>
    [System.Serializable]
    public class FtpConfig : DbTypeBase
    {
        private string m_szFtpIP = null;
        /// <summary>
        /// 获取或设置FTP的访问IP地址
        /// </summary>
        public string FtpIP
        {
            get { return this.m_szFtpIP; }
            set { this.m_szFtpIP = value; }
        }

        private int m_nFtpPort = -1;
        /// <summary>
        /// 获取或设置FTP的访问端口号
        /// </summary>
        public int FtpPort
        {
            get { return this.m_nFtpPort; }
            set { this.m_nFtpPort = value; }
        }

        private string m_szFtpUser = null;
        /// <summary>
        /// 获取或设置FTP的访问用户名称
        /// </summary>
        public string FtpUser
        {
            get { return this.m_szFtpUser; }
            set { this.m_szFtpUser = value; }
        }

        private string m_szFtpPwd = null;
        /// <summary>
        /// 获取或设置FTP的访问用户密码
        /// </summary>
        public string FtpPwd
        {
            get { return this.m_szFtpPwd; }
            set { this.m_szFtpPwd = value; }
        }

        private FtpMode m_nFtpMode = FtpMode.PASV;
        /// <summary>
        /// 获取或设置FTP协议模式
        /// </summary>
        public FtpMode FtpMode
        {
            get { return this.m_nFtpMode; }
            set { this.m_nFtpMode = value; }
        }
    }


}
