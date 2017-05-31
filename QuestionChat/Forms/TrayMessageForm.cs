using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.MedQC.QuestionChat.Utilities;
using EMRDBLib;

namespace Heren.MedQC.QuestionChat.Forms
{
    internal partial class TrayMessageForm : MessageForm
    {
        private static TrayMessageForm m_instance = null;
        public static TrayMessageForm Instance
        {
            get
            {
                if (m_instance == null || m_instance.IsDisposed)
                    m_instance = new TrayMessageForm();
                return m_instance;
            }
        }

        private ChatListForm m_taskForm = null;
        /// <summary>
        /// 获取或设置关联的任务消息窗口
        /// </summary>
        public ChatListForm TaskForm
        {
            get { return this.m_taskForm; }
            set { this.m_taskForm = value; }
        }

        public TrayMessageForm()
        {
            this.InitializeComponent();
            this.btnTimeMessage.Click += new EventHandler(this.btnDetails_Click);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.Hide();
            e.Cancel = true;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (this.m_taskForm != null && !this.m_taskForm.IsDisposed)
                this.m_taskForm.ShowTaskForm();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        new public void Hide()
        {
            TrayIconHandler.Instance.StopTrayBlink();
            if (this.Visible)
                base.Hide();
        }

        public void Show(ChatListForm taskForm)
        {
            this.m_taskForm = taskForm;
            base.Show();
            this.Update();
            string szUserName = null;
            if (SystemParam.Instance.QChatArgs != null)
                szUserName = SystemParam.Instance.QChatArgs.Listener;
            this.Text = string.Format("病历质控沟通提醒消息 - {0}", szUserName);
           
            this.lblMessageCount.Text = string.Format("         系统共收集到{0}条消息!"
                , MessageHandler.Instance.MessageCount);
            this.btnTimeMessage.Text = string.Format("待读消息：共{0}份, 需要您查看或回复", MessageHandler.Instance.QcMsgChatLogList.Count);
        }
    }
}