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

namespace MedQC.ChatServer
{
    public partial class MainForm : Form
    {
        //声明将要用到的类
        private IPEndPoint ServerInfo;//存放服务器的IP和端口信息
        private Socket ServerSocket;//服务端运行的SOCKET
        private Thread ServerThread;//服务端运行的线程
        private List<ChatClientInfo> lstClientInfo;//为客户端建立的SOCKET连接
                                                   //  private byte[] MsgBuffer;//存放消息数据
        public MainForm()
        {
            InitializeComponent();
            //允许子线程刷新数据//不捕获对错误线程的调用
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MenuItemConfig_Click(object sender, EventArgs e)
        {
            Dialogs.SetPortForm form = new Dialogs.SetPortForm();
            form.ShowDialog();
        }

        private void MenuItemStartService_Click(object sender, EventArgs e)
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //提供一个 IP 地址，指示服务器应侦听所有网络接口上的客户端活动
            IPAddress ip = IPAddress.Parse("10.10.78.232");
            int iPort = this.GetPort();
            if (iPort < 0)
            {
                MessageBox.Show("开启服务前请先设置端口号！");
                return;
            }
            ServerInfo = new IPEndPoint(ip, iPort);
            ServerSocket.Bind(ServerInfo);//将SOCKET接口和IP端口绑定
            ServerSocket.Listen(10);//开始监听，并且挂起数为10

            lstClientInfo = new List<ChatClientInfo>(); ;//为客户端提供连接个数
            //MsgBuffer = new byte[65535];//消息数据大小

            ServerThread = new Thread(new ThreadStart(RecieveAccept));//将接受客户端连接的方法委托给线程
            ServerThread.IsBackground = true;
            ServerThread.Start();//线程开始运行
            SetStatus(string.Format("服务正在运行...IP地址{0}， 运行端口：{1}", ip, iPort.ToString()));
            AddLog("服务已开启...");
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
            catch (Exception)
            {
                throw;
            }
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
                    lstClientInfo.Add(clientInfo);
                    clientInfo.SocketClient.BeginReceive(clientInfo.MsgBuffer, 0, clientInfo.MsgBuffer.Length, SocketFlags.None,
                    new AsyncCallback(RecieveCallBack), clientInfo.SocketClient);
                    //Object o = DeserializeObject(clientInfo.MsgBuffer);
                    //MedQC.ChatClient.MessageInfo message = (ChatClient.MessageInfo)o;
                    //tViewUser.BeginInvoke(new EventHandler(delegate { ClientInfo_Login(clientInfo, message); }));
                    AddLog(clientInfo.SocketClient.RemoteEndPoint.ToString() + " 成功连接服务器.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClientInfo_Login(ChatClientInfo client, ChatClient.MessageInfo message)
        {
            if (client == null || message == null)
                return;
            //更新在线信息
            if (message.MessageAction != (int)MedQC.ChatClient.ActionType.LogIn)
                return;
            client.UesrID = message.MessageFrom;
            TreeNode node = new TreeNode();
            node.Text = client.UesrID;
            tViewUser.Nodes.Add(node);

            gBoxUser.Text = string.Format("在线用户：{0}人", tViewUser.Nodes.Count);
        }

        //回发数据给客户端
        private void RecieveCallBack(IAsyncResult AR)
        {
            try
            {
                Socket RSocket = (Socket)AR.AsyncState;
                int REnd = RSocket.EndReceive(AR);
                //对每一个侦听的客户端端口信息进行接收和回发
                foreach (var item in lstClientInfo)
                {
                    if (item.SocketClient.Connected)
                    {
                        //回发数据到客户端
                        item.SocketClient.Send(item.MsgBuffer, 0, REnd, SocketFlags.None);
                    }
                    //同时接收客户端回发的数据，用于回发
                    RSocket.BeginReceive(item.MsgBuffer, 0, item.MsgBuffer.Length, 0, new AsyncCallback(RecieveCallBack), RSocket);

                    MedQC.ChatClient.MessageInfo info = DeserializeObject(item.MsgBuffer) as ChatClient.MessageInfo;
                    AddLog(info.MessageContent);
                    string text = Encoding.UTF8.GetString(item.MsgBuffer);
                    //object o = DeserializeObject(item.MsgBuffer);
                    //MedQC.ChatClient.MessageInfo message = (ChatClient.MessageInfo)o;
                    AddLog(text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void MenuItemStopService_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        protected override void OnClosed(EventArgs e)
        {
            StopServer();
            base.OnClosed(e);
        }

        private void StopServer()
        {
            if (ServerThread != null)
                ServerThread.Abort();//线程终止
            if (ServerSocket != null)
                ServerSocket.Close();//关闭socket
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
                lock (this.txtBoxLog)
                {
                    this.txtBoxLog.Text += value + "  " + DateTime.Now.ToString("yyyy MM-dd HH:mm：ss ") + Environment.NewLine;
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
    }
}
