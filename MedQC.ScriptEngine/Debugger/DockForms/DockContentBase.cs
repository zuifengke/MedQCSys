// ***********************************************************
// 电子病历系统配置管理系统可停靠窗口基类.
// Creator:YangMingkun  Date:2010-11-29
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class DockContentBase : DockContent
    {
        private DebuggerForm m_DebuggerForm = null;
        /// <summary>
        /// 获取或设置主程序窗口
        /// </summary>
        [Browsable(false)]
        protected virtual DebuggerForm DebuggerForm
        {
            get { return this.m_DebuggerForm; }
            set { this.m_DebuggerForm = value; }
        }

        public DockContentBase()
            : this(null)
        {
        }

        public DockContentBase(DebuggerForm parent)
        {
            this.m_DebuggerForm = parent;
        }

        //对于需要记忆位置的停靠窗口,请将控件创建代码放入Load事件内
        //这样当窗口被构造时,就不会加载界面元素,用以提高系统启动速度
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.TabPageContextMenuStrip = this.contextMenuStrip;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                return this.CommitModify();
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 刷新视图方法
        /// </summary>
        public virtual void OnRefreshView()
        {
        }

        /// <summary>
        /// 获取是否有未保存的记录
        /// </summary>
        public virtual bool HasUncommit()
        {
            return false;
        }

        /// <summary>
        /// 保存当前对记录的修改
        /// </summary>
        /// <returns></returns>
        public virtual bool CommitModify()
        {
            return true;
        }

        /// <summary>
        /// 检查是否有需要保存的数据
        /// </summary>
        /// <returns>是否保存成功</returns>
        public virtual bool CheckModifiedData()
        {
            if (!this.HasUncommit())
                return true;
            this.DockHandler.Activate();
            DialogResult result = MessageBoxEx.ShowQuestion("当前有未保存的修改,是否保存？");
            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                return this.CommitModify();
            return true;
        }

        protected void ShowStatusMessage(string szMessage)
        {
            if (this.m_DebuggerForm != null && !this.m_DebuggerForm.IsDisposed)
                this.m_DebuggerForm.ShowStatusMessage(szMessage);
        }

        private void contextMenuStrip_Opened(object sender, EventArgs e)
        {
            bool visible = true;
            if (!this.CloseButtonVisible)
                visible = false;
            if (this.mnuClose.Visible != visible)
                this.mnuClose.Visible = visible;
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            if (this.DockHandler == null)
            {
                this.Close();
            }
            else
            {
                this.Pane.Focus();
                this.DockHandler.Close();
            }
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            this.OnRefreshView();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = !this.CheckModifiedData();
        }
    }
}