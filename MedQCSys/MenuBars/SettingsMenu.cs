// ***********************************************************
// 病案质控系统设置下拉菜单控件.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;

using EMRDBLib;
using Heren.MedQC.Core;

namespace MedQCSys.MenuBars
{
    internal class SettingsMenu : MqsMenuItemBase
    {
        private MainForm m_mainForm = null;
        public virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set
            {
                this.m_mainForm = value;
                if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                    return;
                this.m_mainForm.AllDockWindowHidden +=
                    new MainForm.AllDockWindowHiddenHandler(this.MainForm_AllDockWindowHidden);
            }
        }

        #region"系统设置菜单初始化"
        private MqsMenuItemBase mnuDocDisplayMode;
        private MqsMenuItemBase mnuShowAsPopup;
        private MqsMenuItemBase mnuShowAsEmbed;
        private MqsMenuItemBase mnuShowToolStrip;
        private MqsMenuItemBase mnuShowStatusStrip;
        private MqsMenuItemBase mnuDocListDisplayMode;
        private MqsMenuItemBase mnuShowPatDocList;
        private MqsMenuItemBase mnuShowPatsDocList;
        private MqsMenuItemBase mnuHideAllDockWindow;
        private ToolStripSeparator toolStripSeparator1;

        private void InitializeComponent()
        {
            this.mnuDocDisplayMode = new MqsMenuItemBase();
            this.mnuShowAsPopup = new MqsMenuItemBase();
            this.mnuShowAsEmbed = new MqsMenuItemBase();
            this.mnuShowToolStrip = new MqsMenuItemBase();
            this.mnuShowStatusStrip = new MqsMenuItemBase();
            this.mnuHideAllDockWindow = new MqsMenuItemBase();
            this.mnuDocListDisplayMode = new MqsMenuItemBase();
            this.mnuShowPatsDocList = new MqsMenuItemBase();
            this.mnuShowPatDocList = new MqsMenuItemBase();
            this.toolStripSeparator1 = new ToolStripSeparator();
            // 
            // mnuShowAsPopup
            // 
            this.mnuShowAsPopup.Name = "mnuShowAsPopup";
            this.mnuShowAsPopup.Text = "弹出独立窗口";
            this.mnuShowAsPopup.Click += new System.EventHandler(this.mnuShowAsPopup_Click);
            // 
            // mnuShowAsEmbed
            // 
            this.mnuShowAsEmbed.Name = "mnuShowAsEmbed";
            this.mnuShowAsEmbed.Text = "嵌入到主窗口";
            this.mnuShowAsEmbed.Click += new System.EventHandler(this.mnuShowAsEmbed_Click);

            // 
            // mnuShowPatDocList
            // 
            this.mnuShowPatDocList.Name = "mnuShowPatDocList";
            this.mnuShowPatDocList.Text = "单患者形式";
            this.mnuShowPatDocList.Click += new EventHandler(this.mnuShowPatDocList_Click);

            // 
            // mnuShowPatsDocList
            // 
            this.mnuShowPatsDocList.Name = "mnuShowPatsDocList";
            this.mnuShowPatsDocList.Text = "多患者形式";
            this.mnuShowPatsDocList.Click += new EventHandler(this.mnuShowPatsDocList_Click);
            // 
            // mnuDocDisplayMode
            // 
            this.mnuDocDisplayMode.Name = "mnuDocDisplayMode";
            this.mnuDocDisplayMode.Text = "病历窗口样式";
            this.mnuDocDisplayMode.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuShowAsPopup, 
                this.mnuShowAsEmbed });
            // 
            // mnuShowToolStrip
            // 
            this.mnuShowToolStrip.Name = "mnuShowToolStrip";
            this.mnuShowToolStrip.Text = "隐藏/显示工具栏";
            this.mnuShowToolStrip.Click += new System.EventHandler(this.mnuShowToolStrip_Click);
            // 
            // mnuShowStatusStrip
            // 
            this.mnuShowStatusStrip.Name = "mnuShowStatusStrip";
            this.mnuShowStatusStrip.Text = "隐藏/显示状态栏";
            this.mnuShowStatusStrip.Click += new System.EventHandler(this.mnuShowStatusStrip_Click);
            // 
            // mnuShowPatDocStrip
            // 
            this.mnuDocListDisplayMode.Name = "mnuShowPatDocList";
            this.mnuDocListDisplayMode.Text = "病历文书窗口显示样式";
            this.mnuDocListDisplayMode.DropDownItems.AddRange(new ToolStripItem[]{
                this.mnuShowPatDocList,
                this.mnuShowPatsDocList});
            // 
            // mnuHideAllDockWindow
            // 
            this.mnuHideAllDockWindow.Name = "mnuHideAllDockWindow";
            this.mnuHideAllDockWindow.Text = "隐藏/显示所有停靠窗口";
            this.mnuHideAllDockWindow.Click += new System.EventHandler(this.mnuHideAllDockWindow_Click);
            
            // 
            // menuSettings
            // 
            this.Name = "menuSettings";
            this.Text = "设置(&O)";
            this.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuShowToolStrip,
                this.mnuShowStatusStrip,
                this.mnuHideAllDockWindow,
                this.toolStripSeparator1,
                this.mnuDocDisplayMode,
                this.mnuDocListDisplayMode});
        }
        #endregion

        public SettingsMenu(MainForm parent)
        {
            this.MainForm = parent;
            this.InitializeComponent();
        }

        protected override void OnDropDownShow(EventArgs e)
        {
            base.OnDropDownShow(e);
            this.mnuShowAsPopup.Checked = false;
            this.mnuShowAsEmbed.Checked = false;
            if (SystemConfig.Instance.Get(SystemData.ConfigKey.DOCUMENT_FORM_EMBED, true))
                this.mnuShowAsEmbed.Checked = true;
            else
                this.mnuShowAsPopup.Checked = true;
            if (SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_MANY_PATIENT_DOCLIST, true))
                this.mnuShowPatsDocList.Checked = true;
            else
                this.mnuShowPatDocList.Checked = true;
            this.mnuShowStatusStrip.Checked = SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_STATUS_STRIP, true);
            this.mnuShowToolStrip.Checked = SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_TOOL_STRIP, true);
        }

        private void mnuShowAsPopup_Click(object sender, EventArgs e)
        {
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            if (this.mnuShowAsPopup.Checked)
                return;
            this.mnuShowAsPopup.Checked = true;
            this.mnuShowAsEmbed.Checked = false;

            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            this.m_mainForm.Update();
            SystemConfig.Instance.Write(SystemData.ConfigKey.DOCUMENT_FORM_EMBED, false.ToString());
            this.m_mainForm.SwitchDocumentFormMode(false);
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void mnuShowAsEmbed_Click(object sender, EventArgs e)
        {
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            if (this.mnuShowAsEmbed.Checked)
                return;
            this.mnuShowAsPopup.Checked = false;
            this.mnuShowAsEmbed.Checked = true;

            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            this.m_mainForm.Update();
            SystemConfig.Instance.Write(SystemData.ConfigKey.DOCUMENT_FORM_EMBED, true.ToString());
            this.m_mainForm.SwitchDocumentFormMode(true);
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void mnuShowPatDocList_Click(object sender, EventArgs e)
        {
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            if (this.mnuShowPatDocList.Checked)
                return;
            this.mnuShowPatsDocList.Checked = false;
            this.mnuShowPatDocList.Checked = true;
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            this.m_mainForm.Update();
            SystemConfig.Instance.Write(SystemData.ConfigKey.SHOW_MANY_PATIENT_DOCLIST, false.ToString());
            this.m_mainForm.OnPatientInfoChanged(EventArgs.Empty);
            this.m_mainForm.SwitchDocumentListFormMode(false);
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void mnuShowPatsDocList_Click(object sender, EventArgs e)
        {
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            if (this.mnuShowPatsDocList.Checked)
                return;
            this.mnuShowPatsDocList.Checked = true;
            this.mnuShowPatDocList.Checked = false;
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            this.m_mainForm.Update();
            SystemConfig.Instance.Write(SystemData.ConfigKey.SHOW_MANY_PATIENT_DOCLIST, true.ToString());
            this.m_mainForm.OnPatientInfoChanged(EventArgs.Empty);
            this.m_mainForm.SwitchDocumentListFormMode(true);
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void mnuShowToolStrip_Click(object sender, EventArgs e)
        {
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            this.mnuShowToolStrip.Checked = !this.mnuShowToolStrip.Checked;
            this.m_mainForm.ShowToolStrip(this.mnuShowToolStrip.Checked);
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void mnuRoleManage_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            CommandHandler.Instance.SendCommand("角色管理", this.m_mainForm, null);
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void mnuShowStatusStrip_Click(object sender, EventArgs e)
        {
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            this.mnuShowStatusStrip.Checked = !this.mnuShowStatusStrip.Checked;
            this.m_mainForm.ShowStatusStrip(this.mnuShowStatusStrip.Checked);
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void mnuHideAllDockWindow_Click(object sender, EventArgs e)
        {
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.WaitCursor);
            if (!this.mnuHideAllDockWindow.Checked)
                this.m_mainForm.HideAllDockWindow();
            else
                this.m_mainForm.RestoreAllDockWindow();
            GlobalMethods.UI.SetCursor(this.m_mainForm, Cursors.Default);
        }

        private void MainForm_AllDockWindowHidden(bool bIsHidden)
        {
            if (this.mnuHideAllDockWindow != null && !this.mnuHideAllDockWindow.IsDisposed)
                this.mnuHideAllDockWindow.Checked = bIsHidden;
        }
    }
}
