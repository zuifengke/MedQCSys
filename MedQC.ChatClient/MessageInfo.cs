using EMRDBLib.Entity;
using System;
using System.Collections.Generic;
using EMRDBLib;
namespace MedQC.ChatClient
{

    [Serializable]
    public class MessageInfo
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageID { get; set; }
        /// <summary>
        /// 发送操纵代码
        /// </summary>
        public int MessageAction { get; set; }
        /// <summary>
        /// 发送者
        /// </summary>
        public EMRDBLib.UserInfo MessageFrom { get; set; }
        /// <summary>
        /// 接收者
        /// </summary>
        public EMRDBLib.UserInfo MessageTo { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string MessageContent { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }
        public MessageInfo()
        {
            MessageAction = -1;
            MessageFrom = null;
            MessageTo = null;
            MessageContent = "";
            SendTime = DateTime.MinValue;
        }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }

    /// <summary>
    /// 发送操纵指令
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// 退出
        /// </summary>
        LogOut = -1,
        /// <summary>
        /// 登陆
        /// </summary>
        LogIn = 0,
        /// <summary>
        /// 发送聊天数据
        /// </summary>
        SendMessage = 1,
        /// <summary>
        /// 发送所用当前在线用户信息
        /// </summary>
        SendAllOnLineInfo = 2,
        /// <summary>
        /// 发送图片信息
        /// </summary>
        SendPIc = 3
    }

    public  class CommonHelper
    {

        private static CommonHelper m_Instance = null;

        public static CommonHelper Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new CommonHelper();
                return m_Instance;
            }
        }

        public List<MessageInfo> ConvertoMessageInfoList(List<QcMsgChatLog> lstLog)
        {
            if (lstLog == null || lstLog.Count == 0)
                return null;
            List<MessageInfo> lstMessage = new List<MessageInfo>();
            foreach (QcMsgChatLog item in lstLog)
            {
                MessageInfo info = ConvterToMessage(item);
                if (info != null)
                    lstMessage.Add(info);

            }
            return lstMessage;
        }

        public MessageInfo ConvterToMessage(QcMsgChatLog chatLog)
        {
            if (chatLog == null)
                return null;
            MessageInfo info = new MessageInfo();
            info.MessageID = chatLog.ChatID;
            info.MessageFrom = SystemCache.LstUserInfo.Find(i => i.ID == chatLog.Sender);
            info.MessageTo = SystemCache.LstUserInfo.Find(i => i.ID == chatLog.Listener);
            info.MessageContent = chatLog.ChatContent;
            info.SendTime = chatLog.ChatSendDate;
            info.MessageAction = chatLog.MsgChatDataType == "0" ? (int)ActionType.SendMessage : (int)ActionType.SendPIc;
            return info;
        }

    }
}
