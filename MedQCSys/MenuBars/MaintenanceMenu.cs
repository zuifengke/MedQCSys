// ***********************************************************
// 病案质控系统系统基础数据维护下拉菜单.
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
    internal class MaintenanceMenu : MqsMenuItemBase
    {
        private MainForm m_mainForm = null;
        public virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set { this.m_mainForm = value; }
        }

        #region"维护菜单初始化"
        private MqsMenuItemBase mnuModifyPwd;
        private MqsMenuItemBase mnuQCMsgTemplet;
        private MqsMenuItemBase mnuQCEventTypes;
        private MqsMenuItemBase mnuTimeCheckRuleConfig;
        private MqsMenuItemBase mnuTimeEventEdit;
        private MqsMenuItemBase mnuStandardTerm;
        private MqsMenuItemBase mnuQcCheckPoint;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private MqsMenuItemBase mnuRoleManage;
        private MqsMenuItemBase mnuUserManage;
        private MqsMenuItemBase mnuProductManage;
        private MqsMenuItemBase mnuMenuManage;

        private void InitializeComponent()
        {
            this.mnuModifyPwd = new MqsMenuItemBase();
            this.mnuQCMsgTemplet = new MqsMenuItemBase();
            this.mnuQCEventTypes = new MqsMenuItemBase();
            this.mnuTimeCheckRuleConfig = new MqsMenuItemBase();
            this.mnuTimeEventEdit = new MqsMenuItemBase();
            this.mnuStandardTerm = new MqsMenuItemBase();
            this.mnuQcCheckPoint = new MqsMenuItemBase();
            this.mnuRoleManage = new MqsMenuItemBase();
            this.mnuUserManage = new MqsMenuItemBase();
            this.mnuProductManage = new MqsMenuItemBase();
            this.mnuMenuManage = new MqsMenuItemBase();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripSeparator2 = new ToolStripSeparator();
            // 
            // mnuModifyPwd
            // 
            this.mnuModifyPwd.Name = "mnuModifyPwd";
            this.mnuModifyPwd.Text = "修改口令";
            this.mnuModifyPwd.Click += new EventHandler(this.mnuModifyPwd_Click);
           
            // 
            // mnuQCMsgTemplet
            // 
            this.mnuQCMsgTemplet.Name = "mnuQCMessageDict";
            this.mnuQCMsgTemplet.ShortcutKeys = Keys.F4;
            this.mnuQCMsgTemplet.Text = "修改质检问题字典";
            this.mnuQCMsgTemplet.Click += new EventHandler(this.mnuQCMsgTemplet_Click);
            // 
            // mnuQCEventTypes
            // 
            this.mnuQCEventTypes.Name = "mnuQCEventTypeDict";
            this.mnuQCEventTypes.Text = "修改问题分类字典";
            this.mnuQCEventTypes.Click += new EventHandler(this.mnuQCEventTypes_Click);
            // 
            // mnuTimeCheckRuleConfig
            // 
            this.mnuTimeCheckRuleConfig.Name = "mnuTimeCheckRuleConfig";
            this.mnuTimeCheckRuleConfig.Text = "时效规则配置";
            this.mnuTimeCheckRuleConfig.Click += new EventHandler(this.mnuTimeCheckRuleConfig_Click);
            // 
            // mnuTimeEventEdit
            // 
            this.mnuTimeEventEdit.Name = "mnuTimeEventEdit";
            this.mnuTimeEventEdit.Text = "时效事件配置";
            this.mnuTimeEventEdit.Click += new EventHandler(this.mnuTimeEventEdit_Click);
            // 
            // mnuQcCheckPoint
            // 
            this.mnuQcCheckPoint.Name = "mnuTimeEventEdit";
            this.mnuQcCheckPoint.Text = "缺陷规则配置";
            this.mnuQcCheckPoint.Click += new EventHandler(this.mnuQcCheckPoint_Click);
            // 
            // 
            // mnuStandardTerm
            // 
            this.mnuStandardTerm.Name = "mnuStandardTerm";
            this.mnuStandardTerm.ShortcutKeys = Keys.F5;
            this.mnuStandardTerm.Text = "ICD10标准诊断库";
            this.mnuStandardTerm.Click += new EventHandler(this.mnuStandardTerm_Click);
         
            // 
            // menuMaintenance
            // 
            this.Name = "menuMaintenance";
            this.Text = "维护(&M)";
            this.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuModifyPwd,
                this.toolStripSeparator1,
                this.mnuQCEventTypes,
                this.mnuQCMsgTemplet,
                this.toolStripSeparator1,
                this.mnuTimeEventEdit,
                this.mnuTimeCheckRuleConfig,
                this.mnuQcCheckPoint,
                this.toolStripSeparator2,
                this.mnuStandardTerm});
        }

        #endregion

        public MaintenanceMenu(MainForm parent)
        {
            this.m_mainForm = parent;

            this.InitializeComponent();
        }

        private void mnuModifyPwd_Click(object sender, System.EventArgs e)
        {
            CommandHandler.Instance.SendCommand("修改口令", this.MainForm, null);
        }
        private void mnuQCMsgTemplet_Click(object sender, System.EventArgs e)
        {
            CommandHandler.Instance.SendCommand("修改质检问题字典", this.MainForm, null);
        }
        private void mnuQCEventTypes_Click(object sender, System.EventArgs e)
        {
            CommandHandler.Instance.SendCommand("修改问题分类字典", this.MainForm, null);
        }
        private void mnuTimeCheckRuleConfig_Click(object sender, System.EventArgs e)
        {

            CommandHandler.Instance.SendCommand("时效规则配置", this.MainForm, null);
        }
        private void mnuTimeEventEdit_Click(object sender, System.EventArgs e)
        {

            CommandHandler.Instance.SendCommand("时效事件配置", this.MainForm, null);
        }

        private void mnuQcCheckPoint_Click(object sender, System.EventArgs e)
        {
            CommandHandler.Instance.SendCommand("缺陷规则配置", this.MainForm, null);
        }
        private void mnuStandardTerm_Click(object sender, System.EventArgs e)
        {

            CommandHandler.Instance.SendCommand("ICD10标准诊断库", this.MainForm, null);
        }

        protected override void OnDropDownOpened(EventArgs e)
        {
            base.OnDropDownOpened(e);
           
            
        }
    }
}
