using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMRDBLib;
using EMRDBLib.Entity;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;

namespace MedQC.ChatClient
{
    public partial class ChatLogSearch : Form
    {
        public ChatLogSearch()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BindFComData();
            dtpBeginTime.Value= dtpBeginTime.Value.AddDays(-3);
        }
        /// <summary>
        /// 绑定下拉框信息
        /// </summary>
        private void BindFComData()
        {
            if (CurrentUser == null)
            {
                MessageBoxEx.Show("启动参数错误！");
                return;
            }
            List<string> lstUserID = new List<string>();
            string szListener = SystemParam.Instance.QChatArgs.Sender;//当前发送者是消息的监听者
            short shRet = QcMsgChatAccess.Instance.GetQCMsgLogUserID(CurrentUser.USER_ID, ref lstUserID);
            foreach (var item in lstUserID)
            {
                UserInfo user = SystemCache.LstUserInfo.Find(i => i.USER_ID == item);
                if (user != null && user.USER_ID != CurrentUser.USER_ID)
                    fBox.Items.Add(GlobalMethods.Convert.GetInputCode(user.USER_NAME, false, 10), user);
            }

        }

        public UserInfo CurrentUser { get; internal set; }
        public UserInfo ToUserInfo { get; internal set; }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            rtbView.Clear();
            ToUserInfo = fBox.SelectedItem as UserInfo;
            if (fBox.SelectedItem == null || string.IsNullOrEmpty(fBox.Text))
            {
                MessageBoxEx.Show("聊天对象不能为空！");
                return;
            }
            DateTime dtBeginTime = DateTime.Parse(this.dtpBeginTime.Value.ToString("yyyy-MM-dd"));
            DateTime dtEndTime = DateTime.Parse(this.dtpEndTime.Value.AddDays(1).ToString("yyyy-MM-dd"));
            List<QcMsgChatLog> QcMsgChatLogList = new List<QcMsgChatLog>();
            string szListener = CurrentUser.USER_ID;//当前发送者是消息的监听者
            short shRet = QcMsgChatAccess.Instance.GetQCMsgChatLogView(szListener, ToUserInfo.USER_ID,dtBeginTime,dtEndTime, ref QcMsgChatLogList);
            if (QcMsgChatLogList == null || QcMsgChatLogList.Count == 0)
            {
                MessageBoxEx.Show("未找到聊天记录!");
                return;
            }
            List<MessageInfo> lstMsg = CommonHelper.Instance.ConvertoMessageInfoList(QcMsgChatLogList);
            if (lstMsg == null || lstMsg.Count == 0)
                return;
            foreach (var item in lstMsg)
            {
                if (item.MessageAction == (int)ActionType.SendMessage)
                    ShowMessageText(item);
                else if (item.MessageAction == (int)ActionType.SendPIc)
                    ShowMessagePic(item,null);
            }
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
            rtbView.SelectionColor = info.MessageFrom.USER_ID == ToUserInfo.USER_ID ? Color.Red : Color.Blue;
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
            rtbView.SelectionColor = info.MessageFrom.USER_ID == ToUserInfo.USER_ID ? Color.Red : Color.Blue;
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
            //}


        }
    }
}
