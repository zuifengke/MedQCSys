using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class ScriptNewForm : HerenForm
    {
        private ScriptEditForm m_ScriptEditForm = null;
        private TempletListForm m_TempletListForm = null;

        private string m_szFileName = null;
        /// <summary>
        /// 获取选中模板的文件全路径
        /// </summary>
        public string FileName
        {
            get { return this.m_szFileName; }
        }

        private string m_szScriptTitle = "新建脚本";
        /// <summary>
        /// 获取设置的脚本名称
        /// </summary>
        internal string ScriptTitle
        {
            get { return this.txtScriptName.Text.Trim(); }
        }

        public ScriptNewForm()
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowScriptEditForm();
            this.ShowTempletListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ShowTempletListForm()
        {
            if (this.m_TempletListForm == null || this.m_TempletListForm.IsDisposed)
            {
                this.m_TempletListForm = new TempletListForm(null);
                this.m_TempletListForm.TopLevel = false;
                this.m_TempletListForm.FormBorderStyle = FormBorderStyle.None;
                this.m_TempletListForm.Dock = DockStyle.Fill;
                this.m_TempletListForm.Parent = this.panel1;
                this.m_TempletListForm.AfterSelected +=
                    new TreeViewEventHandler(this.TempletListForm_AfterSelected);
                this.m_TempletListForm.NodeDoubleClick +=
                    new TreeNodeMouseClickEventHandler(this.TempletListForm_NodeDoubleClick);
            }
            this.m_TempletListForm.Show();
            this.m_TempletListForm.BringToFront();
            this.m_TempletListForm.OnRefreshView();
        }

        private void ShowScriptEditForm()
        {
            if (this.m_ScriptEditForm == null || this.m_ScriptEditForm.IsDisposed)
            {
                this.m_ScriptEditForm = new ScriptEditForm(null);
                this.m_ScriptEditForm.SetAsReadonly();
                this.m_ScriptEditForm.TopLevel = false;
                this.m_ScriptEditForm.FormBorderStyle = FormBorderStyle.None;
                this.m_ScriptEditForm.Dock = DockStyle.Fill;
                this.m_ScriptEditForm.Parent = this.panel2;
            }
            this.m_ScriptEditForm.Show();
            this.m_ScriptEditForm.OnRefreshView();
            this.m_ScriptEditForm.BringToFront();
        }

        private void TempletListForm_AfterSelected(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            string szScriptFullName = e.Node.Tag.ToString();
            this.txtScriptName.Text = GlobalMethods.IO.GetFileName(szScriptFullName, false);
            if (this.m_ScriptEditForm == null || this.m_ScriptEditForm.IsDisposed)
                return;
            this.m_ScriptEditForm.OpenScriptFile(szScriptFullName);
        }

        private void TempletListForm_NodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.btnOk.PerformClick();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.m_TempletListForm == null || this.m_TempletListForm.IsDisposed)
                return;
            this.m_szScriptTitle = this.txtScriptName.Text.Trim();
            if (this.m_TempletListForm.SelectedNode == null)
                this.m_szFileName = null;
            else if (this.m_TempletListForm.SelectedNode.Tag == null)
                this.m_szFileName = null;
            else
                this.m_szFileName = this.m_TempletListForm.SelectedNode.Tag.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}