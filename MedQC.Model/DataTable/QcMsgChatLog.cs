using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 质控内容缺陷检查记录类
    /// </summary>
    [Serializable]
    public class QcMsgChatLog : EMRDBLib.DbTypeBase
    {
        private string m_szChatID = string.Empty;
        /// <summary>
        /// 消息编号
        /// </summary>
        public string ChatID
        {
            get { return this.m_szChatID; }
            set { this.m_szChatID = value; }
        }
        private string m_szPatientID = string.Empty;
        /// <summary>
        /// 获取或设置患者的ID
        /// </summary>
        public string PatientID
        {
            get { return this.m_szPatientID; }
            set { this.m_szPatientID = value; }
        }

        private string m_szVisitID = string.Empty;
        /// <summary>
        /// 获取或设置患者的本次就诊ID
        /// </summary>
        public string VisitID
        {
            get { return this.m_szVisitID; }
            set { this.m_szVisitID = value; }
        }
        private string m_szSenderID = string.Empty;

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
        private string m_szChatContent = string.Empty;
        /// <summary>
        /// 沟通消息内容
        /// </summary>
        public string ChatContent
        {
            get { return this.m_szChatContent; }
            set { this.m_szChatContent = value; }
        }
        private byte[] m_bChatImage = null;
        /// <summary>
        /// 图片
        /// </summary>
        public byte[] ChatImage
        {
            get { return this.m_bChatImage; }
            set { this.m_bChatImage = value; }
        }
        private DateTime m_dtChatSendDate = DateTime.Now;
        /// <summary>
        /// 沟通消息发送时间
        /// </summary>
        public DateTime ChatSendDate
        {
            get { return this.m_dtChatSendDate; }
            set { this.m_dtChatSendDate = value; }
        }
        private bool m_bIsRead = false;
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead
        {
            get { return this.m_bIsRead; }
            set { this.m_bIsRead = value; }
        }
        private string m_MsgChatDataType = "0";
        /// <summary>
        /// 文字0，图片1
        /// </summary>
        public string MsgChatDataType
        {
            get { return this.m_MsgChatDataType; }
            set { this.m_MsgChatDataType = value; }
        }

        private string m_MsgID = string.Empty;
        public string MsgID
        {
            get { return this.m_MsgID; }
            set { this.m_MsgID = value; }
        }
        public string MakeChatID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
