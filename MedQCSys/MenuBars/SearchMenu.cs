// ***********************************************************
// 病案质控系统统计下拉菜单控件.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using EMRDBLib;
using MedQCSys.Utility;
using Heren.MedQC.Core;

namespace MedQCSys.MenuBars
{
    internal class SearchMenu : MqsMenuItemBase
    {
        private MainForm m_mainForm = null;
        public virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set { this.m_mainForm = value; }
        }

        #region"查询菜单初始化"
        private MqsMenuItemBase mnuDelayNoCommitDoc;
        private MqsMenuItemBase mnuStatBySeriousCtitical;
        private MqsMenuItemBase mnuStatByDeath;
        private MqsMenuItemBase mnuStatByOutPatient;
        private MqsMenuItemBase mnuStatByOperation;
        private void InitializeComponent()
        {
            this.mnuDelayNoCommitDoc = new MqsMenuItemBase();
            this.mnuStatBySeriousCtitical = new MqsMenuItemBase();
            this.mnuStatByDeath = new MqsMenuItemBase();
            this.mnuStatByOutPatient = new MqsMenuItemBase();
            this.mnuStatByOperation = new MqsMenuItemBase();

            //
            //延期未提交病历查询
            //
            this.mnuDelayNoCommitDoc.Name = "mnuDelayNoCommitDoc";
            this.mnuDelayNoCommitDoc.Text = "延期未提交病历查询";
            this.mnuDelayNoCommitDoc.Click += new EventHandler(this.mnuDelayNoCommitDoc_Click);

            //
            //危重患者查询
            //
            this.mnuStatBySeriousCtitical.Name = "mnuStatBySeriousCtitical";
            this.mnuStatBySeriousCtitical.Text = "危重患者查询";
            this.mnuStatBySeriousCtitical.Click += new EventHandler(this.mnuStatBySeriousCtitical_Click);
            //
            //死亡患者查询
            //
            this.mnuStatByDeath.Name = "mnuStatByDeath";
            this.mnuStatByDeath.Text = "死亡患者查询";
            this.mnuStatByDeath.Click += new EventHandler(this.mnuStatByDeath_Click);
            //
            //出院患者查询
            //
            this.mnuStatByOutPatient.Name = "mnuStatByOutPatient";
            this.mnuStatByOutPatient.Text = "出院患者查询";
            this.mnuStatByOutPatient.Click += new EventHandler(this.mnuStatByOutPatient_Click);
            //
            //手术患者查询
            //
            this.mnuStatByOperation.Name = "mnuStatByOutPatient";
            this.mnuStatByOperation.Text = "手术患者查询";
            this.mnuStatByOperation.Click += new EventHandler(this.mnuStatByOperation_Click);

            // 
            // menuStatistic
            // 
            this.Name = "menuStatistic";
            this.Text = "查询(&C)";
            this.DropDownItems.AddRange(new ToolStripItem[] {
                this.mnuStatBySeriousCtitical,
                this.mnuStatByDeath,
                this.mnuStatByOutPatient,
                this.mnuStatByOperation,
                new ToolStripSeparator(),
                this.mnuDelayNoCommitDoc,
            });
        }
        #endregion

        public SearchMenu(MainForm parent)
        {
            this.m_mainForm = parent;

            this.InitializeComponent();
        }
        private void mnuDelayNoCommitDoc_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("延期未提交病历查询", this.MainForm, null);
        }
        private void mnuStatBySeriousCtitical_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("危重患者查询", this.MainForm, null);
        }

        private void mnuStatByDeath_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("死亡患者查询",this.MainForm,null);
        }
        private void mnuStatByOutPatient_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("出院患者查询", this.MainForm, null);
        }
        private void mnuStatByOperation_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("手术患者查询", this.MainForm, null);
        }
        protected override void OnDropDownOpened(EventArgs e)
        {
            base.OnDropDownOpened(e);
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
        }
    }
}
