using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Drawing.Imaging;
//using MedQC.ChatClient.Access;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls.VirtualTreeView;
using EMRDBLib.Entity;
using Heren.Common.Libraries;

namespace MedQC.ChatClient
{
    public partial class ChatClient : Form
    {
        #region 属性参数
        private UserInfo m_CurrentUser = null;
        private UserInfo m_ToUserInfo = null;
        private IPEndPoint ServerInfo;
        private Socket ClientSocket;
        /// <summary>
        ///正在聊天hashtable
        /// </summary>
        private Hashtable htChating = new Hashtable();
        /// <summary>
        /// 当前聊天对方信息
        /// </summary>
        private UserInfo ToUserInfo
        {
            get { return m_ToUserInfo; }
            set
            {
                if (value != null)
                {
                    m_ToUserInfo = value;
                    lblUserInfo.Text = string.Format("{0}-{1}", value.DeptName, value.Name);
                    if (htChating.Contains(value.ID))
                    {
                        lblUserInfo.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblUserInfo.ForeColor = Color.Gray;
                    }
                }
                else
                {
                    lblUserInfo.ForeColor = Color.Gray;
                    lblUserInfo.Text = "";
                }
            }
        }

        private List<MessageInfo> m_ListMessageInfo = null;
        private List<MessageInfo> ListMessageInfo
        {
            get
            {
                if (m_ListMessageInfo == null)
                    m_ListMessageInfo = new List<MessageInfo>();
                return m_ListMessageInfo;
            }
            set
            {
                m_ListMessageInfo = value;
            }
        }
        /// <summary>
        /// 信息接收缓存
        /// </summary>
        private byte[] MsgBuffer;
        /// <summary>
        /// 信息发送存储
        /// </summary>
        private byte[] MsgSend;
        private bool m_bMessageHandling = false;

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public UserInfo CurrentUser
        {
            get
            {
                return m_CurrentUser;
            }

            set
            {
                if (value != null)
                {
                    m_CurrentUser = value;
                    this.Text = string.Format("病案问题沟通   {0}-{1}", value.DeptName, value.Name);
                }
            }
        }
        #endregion


        public ChatClient()
        {
            TrayIconHandler.Instance.ShowTaskTray(this);
            InitializeComponent();
            //允许子线程刷新数据
            CheckForIllegalCrossThreadCalls = false;
            lblUserInfo.Text = "";

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            InitVirtualTree();
            //初始化聊天双方信息
            CurrentUser = SystemCache.LstUserInfo.Find(i => i.ID == SystemParam.Instance.QChatArgs.Sender);
            if (CurrentUser != null)
            {
                ConnetServer();
            }
            else
            {
                MessageBoxEx.Show("启动参数错误！");
                return;
            }
            ToUserInfo = SystemCache.LstUserInfo.Find(i => i.ID == SystemParam.Instance.QChatArgs.Listener);
            DeleteChatContent();//删除上次本地缓存聊天记录
            if (SystemParam.Instance.QChatArgs.ArgType == "1")
                this.Close();
        }

        private void InitVirtualTree()
        {
            //左侧
            vTreeChating.SuspendLayout();
            vTreeChating.ShowColumnHeader = false;
            vTreeChating.Columns.Add(new VirtualColumn("用户信息", vTreeChating.Width - 35, ContentAlignment.MiddleCenter));
            vTreeChating.Columns.Add(new VirtualColumn("消息", 30, ContentAlignment.MiddleCenter));
            vTreeChating.ImageList.Images.Add(global::MedQC.ChatClient.Properties.Resources.offline);
            vTreeChating.ImageList.Images.Add(global::MedQC.ChatClient.Properties.Resources.online);
            vTreeChating.PerformLayout();

            //右侧
            vTreeAlluser.SuspendLayout();
            vTreeAlluser.ShowColumnHeader = false;
            // vTreeAlluser.Columns.Add(new VirtualColumn("用户信息", vTreeAlluser.Width - 5, ContentAlignment.MiddleCenter));
            vTreeAlluser.ImageList.Images.Add(global::MedQC.ChatClient.Properties.Resources.offline);
            vTreeAlluser.ImageList.Images.Add(global::MedQC.ChatClient.Properties.Resources.online);
            vTreeAlluser.PerformLayout();
        }

        /// <summary>
        /// 绑定所有用户
        /// </summary>
        private void BindAllUserInfo()
        {
            if (SystemCache.LstUserInfo == null || SystemCache.LstUserInfo.Count == 0)
                return;
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "所有用户";
            SystemCache.LstUserInfo.Sort(delegate (UserInfo a, UserInfo b) { return string.Compare(a.DeptName, b.DeptName, StringComparison.CurrentCulture); });

            //加载所有户用
            vTreeAlluser.SuspendLayout();

            VirtualNode dept = new VirtualNode();
            dept.Text = SystemCache.LstUserInfo[0].DeptName;
            dept.ForeColor = Color.Blue;
            foreach (UserInfo userInfo in SystemCache.LstUserInfo)
            {
                if (string.IsNullOrEmpty(userInfo.Name) || string.IsNullOrEmpty(userInfo.DeptName))
                    continue;
                if (dept.Text != userInfo.DeptName)
                {
                    vTreeAlluser.Nodes.Add(dept);
                    dept = new VirtualNode();
                    dept.ForeColor = Color.Blue;
                    dept.Text = userInfo.DeptName;
                }
                VirtualNode userNode = new VirtualNode(userInfo.Name);
                userNode.ForeColor = Color.Gray;
                userNode.ImageIndex = 0;
                userNode.Tag = userInfo;
                dept.Nodes.Add(userNode);
            }
            vTreeAlluser.PerformLayout();
            vTreeAlluser.BringToFront();
        }

        private void ConnetServer()
        {
            //定义一个IPV4，TCP模式的Socket
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MsgBuffer = new Byte[65535];
            MsgSend = new Byte[65535];

            string szIP = string.Empty;
            string szPort = string.Empty;
            GetIpPort(ref szIP, ref szPort);
            if (string.IsNullOrEmpty(szIP) || string.IsNullOrEmpty(szPort))
            {
                MessageBoxEx.Show("获取服务端IP地址和端口失败！");
                return;
            }
            IPAddress ip = IPAddress.Parse(szIP);
            ServerInfo = new IPEndPoint(ip, Convert.ToInt32(szPort));

            try
            {
                //客户端连接服务端指定IP端口，Sockket
                ClientSocket.Connect(ServerInfo);
                //开始从连接的Socket异步读取数据。接收来自服务器，其他客户端转发来的信息
                //AsyncCallback引用在异步操作完成时调用的回调方法
                ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);
                //将用户登录信息发送至服务器，由此可以让其他客户端获知
                ClientSocket.Send(SerilizeContent(GetLogInConetent()));
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ConnetServer", ex.Message);
                MessageBoxEx.Show(ex.Message);
            }
        }

        private void GetIpPort(ref string szIp, ref string szPort)
        {
            List<ConfigInfo> lst = null;
            short shRet = ConfigAccess.Instance.GetConfigData("CHAT_OPTION", "", ref lst);
            if (lst == null || lst.Count != 2)
                return;
            if (lst[0].ConfigName.ToUpper() == "IP")
            {
                szIp = lst[0].ConfigValue;
                szPort = lst[1].ConfigValue;
            }
            else
            {
                szIp = lst[1].ConfigValue;
                szPort = lst[0].ConfigValue;
            }
        }

        private void ReceiveCallBack(IAsyncResult AR)
        {
            try
            {
                //结束挂起的异步读取，返回接收到的字节数。 AR，它存储此异步操作的状态信息以及所有用户定义数据
                if (!ClientSocket.Connected)
                    return;
                int REnd = ClientSocket.EndReceive(AR);
                if (REnd <= 0)
                    return;
                ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
                MessageInfo info = DeserializeObject(MsgBuffer) as MessageInfo;
                HandleMessage(info);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ReceiveCallBack", ex.Message);
                this.Close();
            }
        }

        private void HandleMessage(MessageInfo info)
        {
            if (info == null)
                return;
            switch (info.MessageAction)
            {
                case (int)ActionType.SendAllOnLineInfo:
                    {
                        AddAllOnLineInfo(info);
                        BindUnReadMessage();
                        SelectTabChating();
                        break;
                    }
                case (int)ActionType.LogIn:
                    AddChatingInfo(info); break;
                case (int)ActionType.LogOut:
                    RemoveChaingUserInfo(info); break;
                case (int)ActionType.SendMessage:
                case (int)ActionType.SendPIc:
                    {
                        HandleSendMessage(info);
                        SelectTabChating();
                        break;
                    }

                default:
                    break;
            }
        }

        private void SelectTabChating()
        {
            tab.SelectTab(tabChating);
        }

        /// <summary>
        /// 绑定未读消息
        /// </summary>
        private void BindUnReadMessage()
        {
            List<QcMsgChatLog> lstLog = null;
            QcMsgChatAccess.Instance.GetQCMsgChatLogList(CurrentUser.ID, false, ref lstLog);
            List<MessageInfo> lstMsg = CommonHelper.Instance.ConvertoMessageInfoList(lstLog);
            if (lstMsg == null || lstMsg.Count == 0)
                return;
            lstMsg.Sort(delegate (MessageInfo a, MessageInfo b) { return a.SendTime.CompareTo(b.SendTime); });
            foreach (var item in lstMsg)
            {
                HandleSendMessage(item);
            }
        }

        /// <summary>
        /// 接收聊天数据
        /// </summary>
        /// <param name="info"></param>
        private void HandleSendMessage(MessageInfo info)
        {
            if (info == null)
                return;
            //接收到的消息缓存至ht内容中
            ListMessageInfo.Add(info);
            //更新对应节点显示信息
            UpdateChatingTreeMessage(info);
            //跳图标
            TrayIconHandler.Instance.StartTrayBlink();
        }

        /// <summary>
        /// 更新消息对应的用户节点显示信息
        /// </summary>
        /// <param name="info"></param>
        private void UpdateChatingTreeMessage(MessageInfo info)
        {
            if (info == null)
                return;
            //找到消息对应节点
            VirtualNode userNode = null;
            UserInfo userInfo = null;
            foreach (VirtualNode item in vTreeChating.Nodes)
            {
                userInfo = item.Tag as UserInfo;
                if (userInfo != null && userInfo.ID == info.MessageFrom.ID)
                {
                    userNode = item;
                    break;
                }
            }
            if (userNode == null)//添加离线节点
            {
                userInfo = SystemCache.LstUserInfo.Find(i => i.ID == info.MessageFrom.ID);
                userNode = AddChatingTreeNode(userInfo, 0);
            }
            if (userNode == null || userInfo == null || string.IsNullOrEmpty(userInfo.ID))
                return;
            //获取发送用户的消息
            List<MessageInfo> lstInfo = new List<MessageInfo>();
            lstInfo = ListMessageInfo.FindAll(i => i.MessageFrom.ID == userInfo.ID);
            vTreeChating.SuspendLayout();
            userNode.SubItems[0].Text = string.Format("{0}", lstInfo.Count == 0 ? "" : string.Format("{0}", lstInfo.Count));
            vTreeChating.PerformLayout();
        }

        /// <summary>
        /// 聊天信息显示内容
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private void ShowMessageText(MessageInfo info)
        {
            if (info == null)
                return;
            StringBuilder sbTime = new StringBuilder();
            if (info.SendTime.Year != DateTime.Now.Year)
                sbTime.Append(info.SendTime.Year + "/");
            if (info.SendTime.DayOfYear != DateTime.Now.DayOfYear)
                sbTime.Append(info.SendTime.ToString("M/d "));
            sbTime.Append(info.SendTime.ToString("HH:mm:ss"));

            //发送时间
            rtbView.AppendText(" ");
            rtbView.SelectionFont = new Font(Font, FontStyle.Regular);
            rtbView.SelectionColor = Color.DarkGray;
            rtbView.AppendText("                                " + sbTime.ToString());
            rtbView.AppendText(Environment.NewLine);
            //发送者
            Font font = new Font("宋体", 10, FontStyle.Bold);
            rtbView.SelectionFont = font;
            rtbView.SelectionColor = info.MessageFrom.ID == ToUserInfo.ID ? Color.Red : Color.Blue;
            rtbView.AppendText(info.MessageFrom + ":");
            rtbView.AppendText(Environment.NewLine);

            ///内容
            rtbView.SelectionFont = new Font(Font, FontStyle.Regular);
            rtbView.SelectionColor = Color.Black;
            rtbView.AppendText(info.MessageContent);
            rtbView.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// 聊天信息显示图片
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private void ShowMessagePic(MessageInfo info, Bitmap image)
        {
            if (info == null)
                return;
            StringBuilder sbTime = new StringBuilder();
            if (info.SendTime.Year != DateTime.Now.Year)
                sbTime.Append(info.SendTime.Year + "/");
            if (info.SendTime.DayOfYear != DateTime.Now.DayOfYear)
                sbTime.Append(info.SendTime.ToString("M/d "));
            sbTime.Append(info.SendTime.ToString("HH:mm:ss"));

            //发送时间
            rtbView.AppendText(" ");
            rtbView.SelectionFont = new Font(Font, FontStyle.Regular);
            rtbView.SelectionColor = Color.DarkGray;
            rtbView.AppendText("                                " + sbTime.ToString());
            rtbView.AppendText(Environment.NewLine);
            //发送者
            Font font = new Font("宋体", 10, FontStyle.Bold);
            rtbView.SelectionFont = font;
            rtbView.SelectionColor = info.MessageFrom.ID == ToUserInfo.ID ? Color.Red : Color.Blue;
            rtbView.AppendText(info.MessageFrom + ":");
            rtbView.AppendText(Environment.NewLine);

            ///内容
            ///
            if (image == null)
            {
                byte[] byteImage = null;
                QcMsgChatAccess.Instance.GetQCMsgChatInfoImage(info.MessageID, ref byteImage);
                if (byteImage != null && byteImage.Length > 0)
                {
                    Clipboard.Clear();
                    image = ImageAccess.Instance.BufferToImage(byteImage);
                }
                else
                {
                    rtbView.AppendText(Environment.NewLine);
                    return;
                }
            }
            rtbView.ReadOnly = false;
            Clipboard.SetImage(image);
            rtbView.Paste();
            Clipboard.Clear();
            rtbView.ReadOnly = true;
            rtbView.AppendText(Environment.NewLine);
            //using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(info.MessageContent)))
            //{
            //    image = Bitmap.FromStream(ms) as Bitmap;
            //    if (image == null)
            //    {
            //        rtbView.AppendText("插入图片失败！");
            //        rtbView.AppendText(Environment.NewLine);
            //        return;
            //    }
            //    rtbView.ReadOnly = false;
            //    Clipboard.SetImage(image);
            //    rtbView.Paste();
            //    Clipboard.Clear();
            //    rtbView.ReadOnly = true;
            //}


        }

        /// <summary>
        /// 移除一个在线用户信息
        /// </summary>
        /// <param name="info"></param>
        private void RemoveChaingUserInfo(MessageInfo info)
        {
            string szUserID = info.MessageFrom.ID;
            //更换成离线图片
            vTreeChating.BeginInvoke(new Action(() =>
            {
                UpdateChatingTreeInOff(info.MessageFrom, 0);
            }));

            vTreeAlluser.BeginInvoke(new Action(() =>
            {
                UpdateAllUserNode(info.MessageFrom, 0);
            }));

            if (ToUserInfo.ID == szUserID)
                ToUserInfo = info.MessageFrom;
        }

        /// <summary>
        /// 添加一个聊天用户信息
        /// </summary>
        /// <param name="info"></param>
        private void AddChatingInfo(MessageInfo info)
        {
            string szUserID = info.MessageFrom.ID;
            UserInfo userInfo = SystemCache.LstUserInfo.Find(i => i.ID == szUserID);
            if (userInfo == null)
                return;
            //更新右侧所用用户
            vTreeAlluser.BeginInvoke(new Action(() =>
            {
                UpdateAllUserNode(userInfo, 1);
            }));



            if (htChating.Contains(szUserID))//更新
            {
                vTreeChating.BeginInvoke(new Action(() =>
                {
                    UpdateChatingTreeInOff(userInfo, 1);
                }));
            }

            else//添加
            {
                vTreeChating.BeginInvoke(new Action(() =>
                {
                    AddChatingTreeNode(userInfo, 1);
                }));
            }


        }

        /// <summary>
        /// 更新一个正在聊天用户节点在线，离线状态
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="iOnLine">1,在线，0，离线</param>
        private void UpdateChatingTreeInOff(UserInfo user, int iOnLine)
        {
            VirtualNode userNode = null;
            UserInfo itemInfo = null;
            foreach (VirtualNode item in vTreeChating.Nodes)
            {
                itemInfo = item.Tag as UserInfo;
                if (itemInfo != null && itemInfo.ID == user.ID)
                {
                    userNode = item;
                    break;
                }
            }
            if (userNode != null)
            {
                vTreeChating.SuspendLayout();
                userNode.ForeColor = iOnLine == 1 ? Color.Blue : Color.Gray;
                userNode.ImageIndex = iOnLine;
                vTreeChating.PerformLayout();
            }
        }



        /// <summary>
        /// 增加一个正在聊天用户节点
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="iOnLine">1,在线，0，离线</param>
        private VirtualNode AddChatingTreeNode(UserInfo userInfo, int iOnLine)
        {
            if (userInfo.ID == CurrentUser.ID)
                return null;
            if (!htChating.ContainsKey(userInfo.ID))
                htChating.Add(userInfo.ID, userInfo);
            else
                return null;

            //在线用户树中添加该用户
            vTreeChating.SuspendLayout();
            VirtualNode userNode = new VirtualNode();
            userNode.Text = string.Format("{0}", userInfo.Name);
            userNode.ToolTipText = string.Format("{0}-{1}", userInfo.DeptName, userInfo.Name);
            userNode.Tag = userInfo;
            userNode.ForeColor = iOnLine == 1 ? Color.Blue : Color.Gray;
            userNode.ImageIndex = iOnLine;
            userNode.SubItems.Add(new VirtualSubItem() { ForeColor = Color.Red });//未读消息列
            vTreeChating.Nodes.Add(userNode);
            vTreeChating.PerformLayout();
            return userNode;
        }
        /// <summary>
        /// 更改所有用户中的用户现在离线状态
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="iOnLine">1,在线，0，离线</param>
        private void UpdateAllUserNode(UserInfo userInfo, int iOnLine)
        {
            //所有用户中更改该用户状态
            vTreeAlluser.SuspendLayout();
            foreach (VirtualNode deptNode in vTreeAlluser.Nodes)
            {
                foreach (VirtualNode itemNode in deptNode.Nodes)
                {
                    if (itemNode.Text != userInfo.Name)//判断名字相同之后再判断拆箱判断ID
                        continue;
                    UserInfo itemUser = itemNode.Tag as UserInfo;
                    if (itemUser == null)
                        continue;
                    if (itemUser.ID == userInfo.ID)
                    {
                        itemNode.ImageIndex = iOnLine;
                        itemNode.ForeColor = iOnLine == 1 ? Color.Blue : Color.Gray;
                        break;
                    }
                }
            }
            vTreeAlluser.PerformLayout();
        }

        /// <summary>
        /// 添加当前所有在线用户信息
        /// </summary>
        /// <param name="info"></param>
        private void AddAllOnLineInfo(MessageInfo info)
        {
            if (info == null)
                return;
            string[] szUserIDs = info.MessageContent.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            if (szUserIDs == null || szUserIDs.Length == 0)
                return;

            vTreeChating.BeginInvoke(new Action(() =>
          {
              foreach (var item in szUserIDs)
              {
                  UserInfo userInfo = SystemCache.LstUserInfo.Find(i => i.ID == item);
                  if (userInfo == null)
                      continue;
                  AddChatingTreeNode(userInfo, 1);
              }
          }));
            //所用用户
            vTreeAlluser.BeginInvoke(new Action(() =>
            {
                foreach (var item in szUserIDs)
                {
                    UserInfo userInfo = SystemCache.LstUserInfo.Find(i => i.ID == item);
                    if (userInfo == null)
                        continue;
                    UpdateAllUserNode(userInfo, 1);
                }
            }));
        }
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (ToUserInfo == null)
            {
                MessageBoxEx.Show("请选择聊天对象！");
                return;
            }
            if (string.IsNullOrEmpty(this.rtbEdit.Text))
            {
                MessageBoxEx.Show("发送内容不能为空！");
                return;
            }

            MessageInfo message = GetTextContent(rtbEdit.Text);
            MsgSend = SerilizeContent(message);
            if (ClientSocket != null && ClientSocket.Connected)
            {
                //将数据发送到连接的 System.Net.Sockets.Socket。
                ClientSocket.Send(MsgSend);
                this.rtbEdit.Text = "";
                ShowMessageText(message);
                //保存聊天记录
                SaveChatContentToDB(message);
            }
            else
            {
                MessageBoxEx.Show("当前与服务器断开连接，无法发送信息！");
            }

        }

        private void SaveChatContentToDB(MessageInfo message)
        {
            QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
            qcMsgChatLog.ChatID = message.MessageID;
            qcMsgChatLog.ChatContent = message.MessageContent;
            qcMsgChatLog.ChatSendDate = message.SendTime;
            qcMsgChatLog.Sender = message.MessageFrom.ID;
            qcMsgChatLog.Listener = message.MessageTo.ID;
            byte[] byteChatImage = null;
            short shRet = QcMsgChatAccess.Instance.SaveQCMsgChatLog(qcMsgChatLog, byteChatImage);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("消息发送失败");
                return;
            }
        }

        private void SaveChatPicToDB(MessageInfo message, Bitmap image)
        {
            QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
            qcMsgChatLog.ChatID = message.MessageID;
            qcMsgChatLog.ChatContent = message.MessageContent;
            qcMsgChatLog.ChatSendDate = message.SendTime;
            qcMsgChatLog.Sender = message.MessageFrom.ID;
            qcMsgChatLog.Listener = message.MessageTo.ID;
            qcMsgChatLog.MsgChatDataType = "1";
            byte[] byteChatImage = ImageAccess.Instance.ImageToBuffer(image, ImageFormat.Png);
            short shRet = QcMsgChatAccess.Instance.SaveQCMsgChatLog(qcMsgChatLog, byteChatImage);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("消息发送失败");
                return;
            }
        }

        /// <summary>
        /// 获取发送图片信息的聊天内容
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private MessageInfo GetPicMessageInfo(Bitmap image)
        {
            if (image == null)
                return null;
            MessageInfo message = new MessageInfo();
            message.MessageID = message.MakeID();
            message.MessageAction = (int)ActionType.SendPIc;
            message.MessageFrom = CurrentUser;
            message.MessageTo = ToUserInfo;
            message.SendTime = DateTime.Now;
            return message;
        }
        private MessageInfo GetTextContent(string szText)
        {
            MessageInfo message = new MessageInfo();
            message.MessageID = message.MakeID();
            message.MessageAction = (int)ActionType.SendMessage;
            message.MessageFrom = CurrentUser;
            message.MessageTo = ToUserInfo;
            message.SendTime = DateTime.Now;
            message.MessageContent = szText;
            return message;
        }
        private MessageInfo GetLogInConetent()
        {
            MessageInfo message = new MessageInfo();
            message.MessageID = message.MakeID();
            message.MessageAction = (int)ActionType.LogIn;
            message.MessageFrom = CurrentUser;
            message.SendTime = DateTime.Now;
            message.MessageContent = string.Format("{0}已登录.", CurrentUser.ID);
            return message;
        }
        private MessageInfo GetLogOutConetent()
        {
            MessageInfo message = new MessageInfo();
            message.MessageID = message.MakeID();
            message.MessageAction = (int)ActionType.LogOut;
            message.MessageFrom = CurrentUser;
            message.SendTime = DateTime.Now;
            message.MessageContent = string.Format("{0}已退出.", CurrentUser.ID);
            return message;
        }

        public string MsgContent { set { rtbEdit.Text = value; } }
        public void CloseClient()
        {
            try
            {
                if (ClientSocket != null && ClientSocket.Connected)
                {
                    MessageInfo message = GetLogOutConetent();
                    MsgSend = SerilizeContent(message);
                    ClientSocket.Send(MsgSend);
                    //禁用发送和接受
                    ClientSocket.Shutdown(SocketShutdown.Both);
                    //关闭套接字，不允许重用
                    ClientSocket.Disconnect(false);
                    ClientSocket.Close();
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CloseClient", ex.Message);
            }
        }

        private byte[] SerilizeContent(MessageInfo messageInfo)
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
        public object DeserializeObject(byte[] bytes)
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


        /// <summary>
        /// 保存聊天内容到本地
        /// </summary>
        private void SaveChatContentToLocal()
        {
            if (ToUserInfo == null)
                return;
            string szText = rtbView.Rtf;
            if (!Directory.Exists("ChatCache"))
                Directory.CreateDirectory("ChatCache");
            string szFileName = string.Format("ChatCache\\{0}_{1}.txt", ToUserInfo.ID, CurrentUser.ID);
            using (FileStream fs = new FileStream(szFileName, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(szText);
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 加载本地聊天记录
        /// </summary>
        private void LoadChatContent()
        {
            rtbView.Clear();
            string szFileName = string.Format("ChatCache\\{0}_{1}.txt", ToUserInfo.ID, CurrentUser.ID);
            if (!File.Exists(szFileName))
                return;
            rtbView.Rtf = File.ReadAllText(szFileName);
        }

        /// <summary>
        /// 删除本地聊天文件
        /// </summary>
        private void DeleteChatContent()
        {
            if (!Directory.Exists("ChatCache"))
                return;
            string[] fileArry = Directory.GetFiles("ChatCache");
            if (fileArry.Length == 0)
                return;
            foreach (string item in fileArry)
            {
                File.Delete(item);
            }
        }

        /// <summary>
        /// 窗体激活时显示将正在聊天的新内容展示到显示框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatClient_Activated(object sender, EventArgs e)
        {
            if (ToUserInfo == null)
                return;
            if (vTreeChating.SelectedNode == null)
                return;
            //获取节点用户发送过来的未读消息
            List<MessageInfo> lstInfo = new List<MessageInfo>();
            lstInfo = ListMessageInfo.FindAll(i => i.MessageFrom.ID == ToUserInfo.ID);
            if (lstInfo == null || lstInfo.Count == 0)
                return;
            foreach (MessageInfo item in lstInfo)
            {
                if (item.MessageAction == (int)ActionType.SendMessage)
                    ShowMessageText(item);
                else if (item.MessageAction == (int)ActionType.SendPIc)
                {
                    ShowMessagePic(item, null);
                }
                //从缓存list中移除
                ListMessageInfo.Remove(item);
                //设置消息已读
                UpdateChatLog(item);
            }
            //更新当前聊天对象信息
            vTreeChating.SuspendLayout();
            VirtualNode node = vTreeChating.SelectedNode;
            node.SubItems[0].Text = "";
            vTreeChating.PerformLayout();
        }

        private void UpdateChatLog(MessageInfo item)
        {
            QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
            qcMsgChatLog.ChatID = item.MessageID;
            qcMsgChatLog.IsRead = true;
            short shRet = QcMsgChatAccess.Instance.UpdateQCMsgChatLog(qcMsgChatLog);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("消息更新失败");
                return;
            }
        }

        private void Screenshot()
        {
            ScreenSnapForm form = new ScreenSnapForm(this);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (form.image == null)
                    return;
            }
            if (result != DialogResult.OK)
                return;
            MessageInfo info = null;
            Bitmap image = form.image;
            if (ClientSocket != null && ClientSocket.Connected)
            {
                //将数据发送到连接的 System.Net.Sockets.Socket。
                info = GetPicMessageInfo(image);
                ShowMessagePic(info, image);
                MsgSend = SerilizeContent(info);
                ClientSocket.Send(MsgSend);
                SaveChatPicToDB(info, image);
            }
            else
            {
                MessageBoxEx.Show("当前与服务器断开连接，无法发送信息！");
            }
        }

        private void vTreeAlluser_NodeMouseDoubleClick(object sender, VirtualTreeEventArgs e)
        {
            if (CurrentUser == null)
                return;
            UserInfo userInfo = vTreeAlluser.SelectedNode.Tag as UserInfo;
            if (userInfo == null || userInfo.ID == CurrentUser.ID)
                return;

            //保存当前聊天内容到本地
            SaveChatContentToLocal();
            ToUserInfo = userInfo;
            //加载本地已有聊天记录
            LoadChatContent();
            if (!htChating.ContainsKey(ToUserInfo.ID))
                return;
            //获取节点用户发送过来的未读消息
            List<MessageInfo> lstInfo = new List<MessageInfo>();
            lstInfo = ListMessageInfo.FindAll(i => i.MessageFrom.ID == ToUserInfo.ID);
            foreach (MessageInfo item in lstInfo)
            {
                if (item.MessageAction == (int)ActionType.SendMessage)
                    ShowMessageText(item);
                else if (item.MessageAction == (int)ActionType.SendPIc)
                {
                    ShowMessagePic(item, null);
                }
                //从缓存list中移除
                ListMessageInfo.Remove(item);
                //设置消息已读
                UpdateChatLog(item);
            }
        }

        private void vTreeChating_NodeMouseDoubleClick(object sender, VirtualTreeEventArgs e)
        {
            //保存当前聊天内容到本地
            SaveChatContentToLocal();
            //替换聊天对象
            ToUserInfo = vTreeChating.SelectedNode.Tag as UserInfo;
            if (ToUserInfo == null)
                return;
            vTreeChating.SuspendLayout();
            vTreeChating.SelectedNode.SubItems[0].Text = "";
            vTreeChating.PerformLayout();
            //加载本地已有聊天记录
            LoadChatContent();
            //获取节点用户发送过来的未读消息
            List<MessageInfo> lstInfo = new List<MessageInfo>();
            lstInfo = ListMessageInfo.FindAll(i => i.MessageFrom.ID == ToUserInfo.ID);
            foreach (MessageInfo item in lstInfo)
            {
                if (item.MessageAction == (int)ActionType.SendMessage)
                    ShowMessageText(item);
                else if (item.MessageAction == (int)ActionType.SendPIc)
                {
                    ShowMessagePic(item, null);
                }
                //从缓存list中移除
                ListMessageInfo.Remove(item);
                //设置消息已读
                UpdateChatLog(item);
            }
        }

        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClientSocket == null || ClientSocket.Connected)
            {
                HideClientForm();
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 隐藏任务列表窗口
        /// </summary>
        internal void HideClientForm()
        {
            if (this.WindowState != FormWindowState.Minimized)
                this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeConstants.WM_COPYDATA)
            {
                if (this.m_bMessageHandling)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
                this.m_bMessageHandling = true;
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                HandleWndProcMessage(m.LParam);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.m_bMessageHandling = false;
            }
            base.WndProc(ref m);
        }

        private void HandleWndProcQuit(IntPtr lParam)
        {
            string szArgsData = GlobalMethods.Win32.PtrToString(lParam);
            if (string.IsNullOrEmpty(szArgsData))
                return;
           
            if (szArgsData.ToUpper() == "QUIT")
            {
                CloseClient();
                this.Close();
            }
        }

        private void HandleWndProcMessage(IntPtr lParam)
        {
            HandleWndProcQuit(lParam);
            string szArgsData = GlobalMethods.Win32.PtrToString(lParam);
            if (string.IsNullOrEmpty(szArgsData))
                return;
            string[] args = szArgsData.Split(new string[] { ";" }, StringSplitOptions.None);
            if (args == null || args.Length != 3)
            {
                MessageBoxEx.Show("沟通参数出错！");
                return;
            }
            if (CurrentUser == null || CurrentUser.ID != args[0])
            {
                CurrentUser = SystemCache.LstUserInfo.Find(i => i.ID == args[0]);
            }
            if (ToUserInfo == null || ToUserInfo.ID != args[0])
            {
                ToUserInfo = SystemCache.LstUserInfo.Find(i => i.ID == args[1]);
            }
            rtbEdit.Text = args[2];
            this.Show();
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tab = sender as TabControl;
            if (tab.SelectedIndex == 1 && vTreeAlluser.Nodes.Count == 0)
            {
                tab.SelectedTab.SuspendLayout();
                BindAllUserInfo();
                tab.SelectedTab.PerformLayout();
                tab.SelectedTab.Update();
            }
        }
        
        private void 聊天记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatLogSearch logSerch = new ChatLogSearch();
            logSerch.CurrentUser = CurrentUser;
            logSerch.ShowDialog();
        }

        private void 导入截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ToUserInfo == null)
            {
                MessageBoxEx.Show("请选择聊天对象。。。");
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "图片文件(*.PNG)|*.png";
            MessageInfo info = null;
            Bitmap image = null;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                image = Bitmap.FromFile(dialog.FileName) as Bitmap;
                if (image == null)
                    return;
            }
            if (ClientSocket != null && ClientSocket.Connected)
            {
                //将数据发送到连接的 System.Net.Sockets.Socket。
                info = GetPicMessageInfo(image);
                if (info == null || image == null)
                    return;
                ShowMessagePic(info, image);
                MsgSend = SerilizeContent(info);
                ClientSocket.Send(MsgSend);
                SaveChatPicToDB(info, image);
            }
            else
            {
                MessageBoxEx.Show("当前与服务器断开连接，无法发送信息！");
            }
        }

        private void 截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Screenshot();
        }
    }
}
