using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MedQC.ChatClient;
using EMRDBLib;
using Heren.Common.Libraries;
using EMRDBLib.DbAccess;
namespace MedQC.ChatServer
{
    public partial class ChatServer : Form
    {
        //声明将要用到的类
        private IPEndPoint ServerInfo;//存放服务器的IP和端口信息
        private Socket ServerSocket;//服务端运行的SOCKET
        private Thread ServerThread;//服务端运行的线程
        private List<ChatClientInfo> lstClientInfo;//为客户端建立的SOCKET连接
        private EMRDBLib.UserInfo m_Server = null;
        private DateTime ServerStartTime { get; set; }//服务开启时间
        public UserInfo Server
        {
            get
            {
                if (m_Server == null)
                {
                    m_Server = new UserInfo();
                    m_Server.USER_ID = "Server";
                    m_Server.USER_NAME = "Server";
                }
                return m_Server;
            }
        }

        public ChatServer()
        {
            InitializeComponent();
            //允许子线程刷新数据//不捕获对错误线程的调用
            CheckForIllegalCrossThreadCalls = false;
            LogManager.Instance.TextLogOnly = true;
        }

        private void MenuItemConfig_Click(object sender, EventArgs e)
        {
            Dialogs.SetPortForm form = new Dialogs.SetPortForm();
            form.ShowDialog();
        }

        private void MenuItemStartService_Click(object sender, EventArgs e)
        {
            if (ServerSocket != null && ServerSocket.Connected)
            {
                MessageBoxEx.Show("服务正在运行！");
                return;
            }

            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //提供一个 IP 地址，指示服务器应侦听所有网络接口上的客户端活动
            IPAddress ip = this.GetIp();
            int iPort = this.GetPort();
            if (ip == null)
            {
                MessageBoxEx.Show("获取本机IP地址失败");
                return;
            }
            if (iPort < 0)
            {
                MessageBoxEx.Show("开启服务前请先设置端口号！");
                return;
            }
            ServerInfo = new IPEndPoint(ip, iPort);
            ServerSocket.Bind(ServerInfo);//将SOCKET接口和IP端口绑定
            ServerSocket.Listen(10);//开始监听，并且挂起数为10

            lstClientInfo = new List<ChatClientInfo>();//为客户端提供连接个数

            ServerThread = new Thread(new ThreadStart(RecieveAccept));//将接受客户端连接的方法委托给线程
            ServerThread.IsBackground = true;
            ServerThread.Start();//线程开始运行
            SetStatus(string.Format("服务正在运行...IP地址{0}， 运行端口：{1}", ip, iPort.ToString()));
            AddLog("服务已开启...");
            ServerStartTime = DateTime.Now;
            menuItemClose.Enabled = true;
            menuItemOpen.Enabled = false;
            timer1.Enabled = true;
            gBoxUser.Text = string.Format("在线用户：{0}人", lstClientInfo.Count);
            UpdateConfigInfo(ip, iPort);
        }

        private void UpdateConfigInfo(IPAddress ip, int port)
        {
            List<ConfigInfo> lst = null;
            short shRet = ConfigAccess.Instance.GetConfigData("CHAT_OPTION", "IP", ref lst);

            if (lst == null || lst.Count == 0)
            {
                ConfigInfo ipConfig = new ConfigInfo()
                { GroupName = "CHAT_OPTION", ConfigName = "IP", ConfigValue = ip.ToString(), ConfigDesc = "沟通工具IP地址" };
                ConfigAccess.Instance.AddConfigData(ipConfig);
            }
            else
            {
                if (lst[0].ConfigValue != ip.ToString())
                {
                    lst[0].ConfigValue = ip.ToString();
                    ConfigAccess.Instance.UpdateConfigData(lst[0]);
                }
            }
            lst = null;
            shRet = ConfigAccess.Instance.GetConfigData("CHAT_OPTION", "PORT", ref lst);
            if (lst == null || lst.Count == 0)
            {
                ConfigInfo portConfig = new ConfigInfo()
                { GroupName = "CHAT_OPTION", ConfigName = "PORT", ConfigValue = port.ToString(), ConfigDesc = "沟通工具端口" };
                ConfigAccess.Instance.AddConfigData(portConfig);
            }
            else
            {
                if (lst[0].ConfigValue != port.ToString())
                {
                    lst[0].ConfigValue = port.ToString();
                    ConfigAccess.Instance.UpdateConfigData(lst[0]);
                }
            }
        }

        private IPAddress GetIp()
        {
            string ip = string.Empty;
            foreach (IPAddress item in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (item.AddressFamily.ToString() == "InterNetwork")
                    return item;
            }
            return null;
        }


        /// <summary>
        /// 获取配置文件端口
        /// </summary>
        /// <returns></returns>
        private int GetPort()
        {
            string value = System.Configuration.ConfigurationManager.AppSettings["port"];
            try
            {
                int port = -1;
                if (int.TryParse(value, out port))
                {
                    return port;
                }
                else
                    return -1;

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("GetPort失败", ex);
            }
            return -1;
        }

        /// <summary>
        /// 接受客户端连接的方法
        /// </summary>
        private void RecieveAccept()
        {
            try
            {
                while (true)
                {
                    //Accept 以同步方式从侦听套接字的连接请求队列中提取第一个挂起的连接请求，然后创建并返回新的 Socket。
                    //在阻止模式中，Accept 将一直处于阻止状态，直到传入的连接尝试排入队列。连接被接受后，原来的 Socket 继续将传入的连接请求排入队列，直到您关闭它。
                    ChatClientInfo clientInfo = new ChatClientInfo();
                    clientInfo.SocketClient = ServerSocket.Accept();
                    lstClientInfo.Add(clientInfo);//添加至客户端列表

                    clientInfo.SocketClient.BeginReceive(clientInfo.MsgBuffer, 0, clientInfo.MsgBuffer.Length, SocketFlags.None,
                    new AsyncCallback(RecieveCallBack), clientInfo.SocketClient);
                    clientInfo.SocketClient.Send(GetOnLineUserInfos());
                }
            }
            catch (SocketException ex)
            {
                LogManager.Instance.WriteLog("RecieveAccept失败", ex);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RecieveAccept失败", ex);
            }
        }

        private byte[] GetOnLineUserInfos()
        {
            MessageInfo info = new MessageInfo();
            info.MessageAction = (int)ActionType.SendAllOnLineInfo;
            info.MessageFrom = Server;
            info.SendTime = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            foreach (var item in lstClientInfo)
            {
                sb.Append(item.UesrID + "|");
            }
            info.MessageContent = sb.ToString();
            return SerilizeContent(info);
        }



        //回发数据给客户端
        private void RecieveCallBack(IAsyncResult AR)
        {
            try
            {
                Socket RSocket = (Socket)AR.AsyncState;
                int REnd = RSocket.EndReceive(AR);
                if (REnd <= 0)//
                    return;
                ChatClientInfo clientInfo = lstClientInfo.Find(i => i.SocketClient.Handle == RSocket.Handle);
                if (clientInfo == null)
                    return;
                //同时接收客户端回发的数据，用于回发
                RSocket.BeginReceive(clientInfo.MsgBuffer, 0, clientInfo.MsgBuffer.Length, 0, new AsyncCallback(RecieveCallBack), RSocket);
                MessageInfo info = DeserializeObject(clientInfo.MsgBuffer) as MessageInfo;
                HandleMessage(clientInfo, info);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RecieveCallBack失败", ex);
            }

        }
        /// <summary>
        /// 处理信息
        /// </summary>
        /// <param name="info"></param>
        private void HandleMessage(ChatClientInfo clientInfo, MessageInfo info)
        {
            if (info == null || clientInfo == null)
                return;
            switch (info.MessageAction)
            {
                case (int)ActionType.LogIn:
                    HandleLogInMessage(clientInfo, info); break;
                case (int)ActionType.LogOut:
                    HandleLogOutMessage(clientInfo, info); break;
                case (int)ActionType.SendMessage:
                case (int)ActionType.SendPIc:
                    HandleSendMessage(info); break;
                default: break;

            }
        }

        /// <summary>
        /// 发送聊天消息给客户端
        /// </summary>
        /// <param name="info"></param>
        private void HandleSendMessage(MessageInfo info)
        {
            if (info == null)
                return;

            ChatClientInfo clientInfo = lstClientInfo.Find(i => i.UesrID == info.MessageTo.USER_ID);//获取接收端socket信息
            if (clientInfo == null || !clientInfo.SocketClient.Connected)
                return;
            clientInfo.SocketClient.Send(SerilizeContent(info));
        }

        /// <summary>
        /// 处理用户登录
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="info"></param>
        private void HandleLogInMessage(ChatClientInfo clientInfo, MessageInfo info)
        {
            if (!string.IsNullOrEmpty(clientInfo.UesrID))
                return;
            if (!lstClientInfo.Exists(i => i.UesrID == info.MessageFrom.USER_ID))//不存在则登陆
            {
                AddLogInUser(clientInfo, info);
                //更新完新增连接用户后通知其他在线用户
                SendMessageUpdateOnLineUserInfo(info);
            }
            else //已存在该用户连接，则删除后在登陆
            {
                //退出
                ChatClientInfo existClientInfo = lstClientInfo.Find(i => i.UesrID == info.MessageFrom.USER_ID);
                info.MessageAction = (int)ActionType.LogOut;
                HandleLogOutMessage(existClientInfo, info);
                //重新登录
                info.MessageAction = (int)ActionType.LogIn;
                AddLogInUser(clientInfo, info);
                //更新完新增连接用户后通知其他在线用户
                SendMessageUpdateOnLineUserInfo(info);
            }
           
        }

        /// <summary>
        /// 处理用户登出
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="info"></param>
        private void HandleLogOutMessage(ChatClientInfo clientInfo, MessageInfo info)
        {
            RemoveLogOutUser(clientInfo, info);
            //更新完新增连接用户后通知其他在线用户
            SendMessageUpdateOnLineUserInfo(info);
            lstClientInfo.Remove(clientInfo);
        }
        /// <summary>
        /// 通知当前连接客户端，更新在线用户
        /// </summary>
        private void SendMessageUpdateOnLineUserInfo(MessageInfo info)
        {
            if (info == null)
                return;
            MessageInfo message = new MessageInfo();
            message.MessageAction = info.MessageAction;
            message.MessageFrom = info.MessageFrom;
            message.SendTime = DateTime.Now;
            byte[] msgBuff = SerilizeContent(message);
            foreach (var item in lstClientInfo)
            {
                if (!string.IsNullOrEmpty(item.UesrID) && item.UesrID == info.MessageFrom.USER_ID)//不必要通知消息发送者
                    continue;
                item.SocketClient.Send(msgBuff);
            }
        }


        /// <summary>
        /// 更新用户登录后界面信息
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="info"></param>
        private void AddLogInUser(ChatClientInfo clientInfo, MessageInfo info)
        {
            if (info == null || clientInfo == null)
                return;
            clientInfo.UesrID = info.MessageFrom.USER_ID;
            tViewUser.BeginInvoke(new Action(() =>
                {
                    TreeNode node = new TreeNode();
                    node.Text = string.Format("{0}-{1}({2})", info.MessageFrom.DEPT_NAME, info.MessageFrom.USER_NAME, info.MessageFrom.USER_ID);
                    node.Tag = info.MessageFrom;
                    tViewUser.Nodes.Add(node);
                }));
            gBoxUser.BeginInvoke(new Action(() =>
            {
                gBoxUser.Text = string.Format("在线用户：{0}人", lstClientInfo.Count);
            }));
            rtbServerLog.BeginInvoke(new Action(() =>
            {
                rtbServerLog.Text += string.Format("用户{0}从{1}成功连接服务器. {2}{3}",
                    string.Format("{0}-{1}({2})", info.MessageFrom.DEPT_NAME, info.MessageFrom.USER_NAME, info.MessageFrom.USER_ID),
                    clientInfo.SocketClient.RemoteEndPoint.ToString(),
                    DateTime.Now.ToString("yyyy MM-dd HH:mm:ss"), Environment.NewLine);
            }));

        }

        /// <summary>
        /// 更新用户登出后界面信息
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="info"></param>
        private void RemoveLogOutUser(ChatClientInfo clientInfo, MessageInfo info)
        {
            if (info == null || clientInfo == null)
                return;
            clientInfo.UesrID = info.MessageFrom.USER_ID;
            tViewUser.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < tViewUser.Nodes.Count; i++)
                {
                    TreeNode item = tViewUser.Nodes[i];
                    EMRDBLib.UserInfo user = item.Tag as EMRDBLib.UserInfo;
                    if (user.USER_ID == clientInfo.UesrID)
                    { tViewUser.Nodes.Remove(item); break; }
                }
            }));
            gBoxUser.BeginInvoke(new Action(() =>
            {
                gBoxUser.Text = string.Format("在线用户：{0}人", lstClientInfo.Count);
            }));
            rtbServerLog.BeginInvoke(new Action(() =>
            {
                rtbServerLog.Text += string.Format("用户{0}从{1}成功退出服务器. {2}{3}",
                    string.Format("{0}-{1}({2})", info.MessageFrom.DEPT_NAME, info.MessageFrom.USER_NAME, info.MessageFrom.USER_ID),
                    clientInfo.SocketClient.RemoteEndPoint.ToString(),
                    DateTime.Now.ToString("yyyy MM-dd HH:mm:ss"), Environment.NewLine);
            }));

        }

        private void MenuItemStopService_Click(object sender, EventArgs e)
        {
            StopServer();
            menuItemClose.Enabled = false;
            menuItemOpen.Enabled = true;
            timer1.Enabled = false;
            tViewUser.Nodes.Clear();
            gBoxUser.Text = string.Format("在线用户：{0}人", lstClientInfo.Count);
        }

        protected override void OnClosed(EventArgs e)
        {
            CloseClient();
            StopServer();
            base.OnClosed(e);
        }

        private void CloseClient()
        {
            if (lstClientInfo == null || lstClientInfo.Count == 0)
                return;
            foreach (var item in lstClientInfo)
            {
                if (item.SocketClient.Connected)
                {
                    //禁用发送和接受
                    item.SocketClient.Shutdown(SocketShutdown.Both);
                    //关闭套接字，不允许重用
                    item.SocketClient.Disconnect(false);
                    item.SocketClient.Close();
                }
            }
            lstClientInfo.Clear();
        }

        private void StopServer()
        {
            if (ServerThread != null)
                ServerThread.Abort();//线程终止
            if (ServerSocket != null)
                ServerSocket.Close();//关闭socket
            ServerSocket = null;
            lstClientInfo.Clear();
            AddLog("服务已关闭...");
            SetStatus("服务已关闭...");
        }
        /// <summary>
        /// 显示状态栏信息
        /// </summary>
        /// <param name="value"></param>
        private void SetStatus(string value)
        {
            this.toolStripStatusLabel1.Text = value;
        }
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="value"></param>
        private void AddLog(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                lock (this.rtbServerLog)
                {
                    this.rtbServerLog.Text += value + "  " + DateTime.Now.ToString("yyyy MM-dd HH:mm：ss ") + Environment.NewLine;
                }
            }
        }

        private byte[] SerilizeContent(object messageInfo)
        {
            if (messageInfo == null)
                return null;
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, messageInfo);
            ms.Position = 0;
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            return bytes;
        }

        /// <summary>
        /// 把字节数组反序列化成对象
        /// </summary>
        public static object DeserializeObject(byte[] bytes)
        {
            object obj = null;
            if (bytes == null)
                return obj;
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms);
            ms.Close();
            return obj;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long i = (DateTime.Now - ServerStartTime).Ticks;
            TimeSpan t = DateTime.Now - ServerStartTime;
            if (t.TotalDays >= 1 && DateTime.Now.Hour == 0)//每天凌晨清理下日志
            {
                rtbServerLog.Clear();
            }
        }
    }
}
