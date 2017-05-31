using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace MedQC.ChatServer
{
    public class ChatClientInfo
    {
        public ChatClientInfo()
        {

        }
        private Socket m_SocketClient = null;
        private string szUesrID = string.Empty;
        private byte[] m_MsgBuffer = new byte[65535];//存放消息数据
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UesrID
        {
            get
            {
                return szUesrID;
            }
            set
            {
                szUesrID = value;
            }
        }

        public Socket SocketClient
        {
            get
            {
                return m_SocketClient;
            }

            set
            {
                m_SocketClient = value;
            }
        }

        public byte[] MsgBuffer
        {
            get
            {
                return m_MsgBuffer;
            }

            set
            {
                m_MsgBuffer = value;
            }
        }
    }
}
