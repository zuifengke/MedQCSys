using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.Entity
{
    /// <summary>
    /// 沟通平台内部参数
    /// </summary>
    public class QChatArgs : DbTypeBase
    {
        private string m_szPatientID = string.Empty;
        public string PatientID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }
        private string m_szVisitID = string.Empty;
        public string VisitID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }
        private string m_szSender = string.Empty;
        /// <summary>
        /// 发送者ID
        /// </summary>
        public string Sender
        {
            get { return this.m_szSender; }
            set { this.m_szSender = value; }
        }
        private string m_szListener = string.Empty;
        /// <summary>
        /// 接收者ID
        /// </summary>
        public string Listener
        {
            get { return this.m_szListener; }
            set { this.m_szListener = value; }
        }
        private string m_szUserType = "0";
        /// <summary>
        /// 用户类型 0代表医生 1 代表质控科 
        /// </summary>
        public string UserType
        {
            get { return this.m_szUserType; }
            set { this.m_szUserType = value; }
        }
        private string m_szArgType = string.Empty;
        /// <summary>
        /// 调用模式 0或者空 则直接弹出消息窗口 1 有提醒和消息列表 
        /// </summary>
        public string ArgType
        {
            get { return this.m_szArgType; }
            set { this.m_szArgType = value; }
        }
        private string m_szMsgID = string.Empty;

        /// <summary>
        /// 质检消息ID
        /// </summary>
        public string MsgID
        {
            get { return m_szMsgID; }
            set { m_szMsgID = value; }
        }

        public string MsgContent { get; set; }

        /// <summary>
        /// 把用户信息对象解析为字符串形式
        /// </summary>
        /// <param name="userInfo">用户信息对象</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>用户信息字符串</returns>
        public static string GetStrFromQChatArgs(QChatArgs qChatArgs, string szSplitChar)
        {
            if (qChatArgs == null)
                qChatArgs = new QChatArgs();

            StringBuilder sbQChatArgs = new StringBuilder();
            sbQChatArgs.Append(qChatArgs.PatientID);
            sbQChatArgs.Append(szSplitChar);
            sbQChatArgs.Append(qChatArgs.VisitID);
            sbQChatArgs.Append(szSplitChar);
            sbQChatArgs.Append(qChatArgs.Sender);
            sbQChatArgs.Append(szSplitChar);
            sbQChatArgs.Append(qChatArgs.Listener);
            sbQChatArgs.Append(szSplitChar);
            sbQChatArgs.Append(qChatArgs.ArgType);
            sbQChatArgs.Append(szSplitChar);
            return sbQChatArgs.ToString();
        }
        /// <summary>
        /// 把字符串表达的沟通消息内部参数解析为消息内部参数对象
        /// </summary>
        /// <param name="szUserInfoData">字符串表达的沟通消息</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>UserInfo</returns>
        public static QChatArgs GetQChatArgsFromStr(string szQChatArgsData, string szSplitChar)
        {
            if (GlobalMethods.Misc.IsEmptyString(szQChatArgsData))
                throw new Exception("用户信息数据不能为空!");

            QChatArgs qChatArgs = new QChatArgs();

            string[] arrQChatArgs = szQChatArgsData.Split(new string[] { szSplitChar }, StringSplitOptions.None);
            if (arrQChatArgs.Length > 0)
                qChatArgs.Sender = arrQChatArgs[0];

            if (arrQChatArgs.Length > 1)
                qChatArgs.Listener = arrQChatArgs[1];

           

            //if (arrQChatArgs.Length > 0)
            //    qChatArgs.PatientID = arrQChatArgs[0];

            //if (arrQChatArgs.Length > 1)
            //    qChatArgs.VisitID = arrQChatArgs[1];

            //if (arrQChatArgs.Length > 2)
            //    qChatArgs.Sender = arrQChatArgs[2];

            //if (arrQChatArgs.Length > 3)
            //    qChatArgs.Listener = arrQChatArgs[3];

            //if (arrQChatArgs.Length > 4)
            //    qChatArgs.ArgType = arrQChatArgs[4];

            //if (arrQChatArgs.Length > 5)
            //    qChatArgs.UserType = arrQChatArgs[5];

            //if (arrQChatArgs.Length > 6)
            //    qChatArgs.MsgID = arrQChatArgs[6];

            return qChatArgs;
        }
    }
}
