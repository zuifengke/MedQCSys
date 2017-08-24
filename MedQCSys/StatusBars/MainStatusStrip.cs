// ***********************************************************
// 病案质控系统主窗口状态条控件.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using EMRDBLib;

namespace MedQCSys.StatusBars
{
    internal class MainStatusStrip : StatusStrip
    {
        private MainForm m_mainForm = null;
        public virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set { this.m_mainForm = value; }
        }

        #region"主状态条初始化"
        private ToolStripStatusLabel statuslblSystemInfo;
        private ToolStripStatusLabel statuslblTime;
        private Timer timer1;

        private void InitializeComponent()
        {
            this.statuslblSystemInfo = new ToolStripStatusLabel();
            this.statuslblTime = new ToolStripStatusLabel();
            this.timer1 = new Timer();
            // 
            // statuslblSystemInfo
            // 
            this.statuslblSystemInfo.Name = "statuslblSystemInfo";
            this.statuslblSystemInfo.Size = new System.Drawing.Size(777, 17);
            this.statuslblSystemInfo.Spring = true;
            this.statuslblSystemInfo.Text = "就绪";
            this.statuslblSystemInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statuslblTime
            // 
            this.statuslblTime.AutoSize = false;
            this.statuslblTime.Name = "statuslblTime";
            this.statuslblTime.Size = new System.Drawing.Size(200, 17);
            this.statuslblTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainStatusStrip
            // 
            this.Items.AddRange(new ToolStripItem[] {
                this.statuslblSystemInfo,
                this.statuslblTime});
            this.Size = new System.Drawing.Size(823, 22);
            this.Location = new System.Drawing.Point(0, 498);
        }
        #endregion

        public MainStatusStrip()
            : this(null)
        {
        }

        public MainStatusStrip(MainForm parent)
        {
            this.m_mainForm = parent;
            this.InitializeComponent();
        }

        public void ShowStatusMessage(string szMessage)
        {
            if (szMessage == null || szMessage.Trim() == string.Empty)
                szMessage = "就绪";
            this.statuslblSystemInfo.Text = szMessage;
            this.Update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (EMRDBLib.SystemParam.Instance.UserInfo == null)
                return;
            this.statuslblTime.Text =SysTimeHelper.Instance.Now.ToString("yyyy年M月d日 HH:mm:ss dddd");
        }
    }
}
