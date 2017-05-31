// ***********************************************************
// 护理病历配置管理系统,脚本编辑器查找替换窗口.
// Author : YangMingkun, Date : 2013-5-4
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Forms.Loader;
using Designers;
using Designers.Report;
using Designers;

namespace Designers.FindReplace
{
    internal partial class FindReplaceForm : DockContentBase 
    {
        public FindReplaceForm(DesignForm mainForm)
            : base(mainForm)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.ShowHint = DockState.Float;
            this.DockAreas = DockAreas.DockLeft | DockAreas.DockRight
                | DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Float;
        }

        /// <summary>
        /// 获取或设置缺省查找文本
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public string DefaultFindText
        {
            get
            {
                return this.txtFindText.Text;
            }

            set
            {
                this.txtFindText.Text = value;
                this.txtFindText.SelectAll();
            }
        }

        //对于需要记忆位置的停靠窗口,请将控件创建代码放入Load事件内
        //这样当窗口被构造时,就不会加载界面元素,用以提高系统启动速度
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           // this.UpdateBounds();
            this.Icon = Designers.Properties.Resources.FindIcon;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.OnRefreshView();

            this.txtFindText.Focus();
            this.txtFindText.SelectAll();
        }
        public override void OnRefreshView()
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
            {
                this.btnFind.Enabled = false;
                this.btnReplace.Enabled = false;
                this.btnReplaceAll.Enabled = false;
                this.txtFindText.Enabled = false;
                this.txtReplaceText.Enabled = false;
                this.chkMatchCase.Enabled = false;
                return;
            }

            IDockContent activeDocument = this.MainForm.ActiveDocument;
            if (activeDocument == null
                || !(activeDocument is IScriptEditForm))
            {
                this.btnFind.Enabled = false;
                this.btnReplace.Enabled = false;
                this.btnReplaceAll.Enabled = false;
                this.txtFindText.Enabled = false;
                this.txtReplaceText.Enabled = false;
                this.chkMatchCase.Enabled = false;
            }
            else
            {
                if (!this.txtFindText.Enabled)
                    this.txtFindText.Enabled = true;

                if (this.txtFindText.Text == string.Empty)
                {
                    this.btnFind.Enabled = false;
                    this.btnReplace.Enabled = false;
                    this.btnReplaceAll.Enabled = false;
                    this.txtReplaceText.Enabled = false;
                    return;
                }

                if (!this.btnFind.Enabled)
                    this.btnFind.Enabled = true;

                if (!this.chkMatchCase.Enabled)
                    this.chkMatchCase.Enabled = true;

                if (!this.txtReplaceText.Enabled)
                    this.txtReplaceText.Enabled = true;
                if (this.txtFindText.Text != this.txtReplaceText.Text)
                {
                    if (!this.btnReplace.Enabled)
                        this.btnReplace.Enabled = true;
                    if (!this.btnReplaceAll.Enabled)
                        this.btnReplaceAll.Enabled = true;
                }
                else
                {
                    if (this.btnReplace.Enabled)
                        this.btnReplace.Enabled = false;
                    if (this.btnReplaceAll.Enabled)
                        this.btnReplaceAll.Enabled = false;
                }
            }
        }

        private void txtFindText_TextChanged(object sender, EventArgs e)
        {
            this.OnRefreshView();
        }

        private void txtReplaceText_TextChanged(object sender, EventArgs e)
        {
            this.OnRefreshView();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            IScriptEditForm scriptEditForm = this.MainForm.ActiveDocument as IScriptEditForm;
            if (this.chkCheckAllTemple.Checked)
            {
                if (scriptEditForm != null && !scriptEditForm.IsDisposed)
                    scriptEditForm.FindTextInAllTemplet(this.txtFindText.Text, this.chkMatchCase.Checked);
                return;
            }
            if (scriptEditForm != null && !scriptEditForm.IsDisposed)
                scriptEditForm.FindText(this.txtFindText.Text, this.chkMatchCase.Checked);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;

            IScriptEditForm scriptEditForm = this.MainForm.ActiveDocument as IScriptEditForm;
            if (scriptEditForm != null && !scriptEditForm.IsDisposed)
                scriptEditForm.ReplaceText(this.txtFindText.Text, this.txtReplaceText.Text, this.chkMatchCase.Checked, false);
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;

            IScriptEditForm scriptEditForm = this.MainForm.ActiveDocument as IScriptEditForm;
            if (scriptEditForm != null && !scriptEditForm.IsDisposed)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                scriptEditForm.ReplaceText(this.txtFindText.Text, this.txtReplaceText.Text, this.chkMatchCase.Checked, true);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
        }
    }
}
