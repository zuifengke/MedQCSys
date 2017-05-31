// ***********************************************************
// 病案质控系统帮助下拉菜单控件.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;

using MedQCSys.Dialogs;
using Heren.MedQC.Core;

namespace MedQCSys.MenuBars
{
    internal class HelpMenu : MqsMenuItemBase
    {
        private MainForm m_mainForm = null;
        public virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set { this.m_mainForm = value; }
        }

        #region"帮助菜单初始化"
        private MqsMenuItemBase mnuSysHelp;
        private MqsMenuItemBase mnuAboutSys;

        private void InitializeComponent()
        {
            this.mnuSysHelp = new MqsMenuItemBase();
            this.mnuAboutSys = new MqsMenuItemBase();
            // 
            // mnuSysHelp
            // 
            this.mnuSysHelp.Name = "mnuSysHelp";
            this.mnuSysHelp.ShortcutKeys = Keys.F1;
            this.mnuSysHelp.Text = "帮助(&H)";
            this.mnuSysHelp.Click += new System.EventHandler(this.mnuSysHelp_Click);
            // 
            // mnuAboutSys
            // 
            this.mnuAboutSys.Name = "mnuAboutSys";
            this.mnuAboutSys.Text = "关于(A)...";
            this.mnuAboutSys.Click += new System.EventHandler(this.mnuAboutSys_Click);
            // 
            // menuHelp
            // 
            this.Name = "menuHelp";
            this.Text = "帮助(&H)";
            this.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuSysHelp,
                this.mnuAboutSys});
        }
        #endregion

        public HelpMenu(MainForm parent)
        {
            this.m_mainForm = parent;
            this.InitializeComponent();
        }

        private void mnuSysHelp_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("帮助", this.MainForm, null);
        }

        private void mnuAboutSys_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("关于", null, null);
        }
    }
}
