using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.ScriptEngine.Script;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class ErrorsListForm : DockContentBase
    {
        private CompileErrorCollection m_compileErrors = null;
        /// <summary>
        /// 获取或设置编译错误列表
        /// </summary>
        internal CompileErrorCollection CompileErrors
        {
            get { return this.m_compileErrors; }
            set { this.m_compileErrors = value; }
        }

        private ScriptEditForm m_ScriptEditForm = null;
        /// <summary>
        /// 获取或设置当前发生错误的文档对象
        /// </summary>
        internal ScriptEditForm ScriptEditForm
        {
            get { return this.m_ScriptEditForm; }
            set { this.m_ScriptEditForm = value; }
        }

        public ErrorsListForm(DebuggerForm mainForm)
            : base(mainForm)
        {
            this.ShowHint = DockState.DockBottom;
            this.DockAreas = DockAreas.DockBottom | DockAreas.DockRight;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            this.Icon = Properties.Resources.ScriptErrorIcon;
        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadErrorList();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void LoadErrorList()
        {
            this.listView1.Items.Clear();
            if (this.m_compileErrors == null)
                return;
            foreach (CompileError error in this.m_compileErrors)
            {
                if (error == null)
                    continue;
                ListViewItem item = new ListViewItem();
                item.Tag = error;
                item.ImageIndex = error.IsWarning ? 0 : 1;
                item.SubItems.Add(error.ErrorText);
                item.SubItems.Add(error.Line.ToString());
                item.SubItems.Add(error.Column.ToString());
                this.listView1.Items.Add(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count <= 0)
                return;
            CompileError error = this.listView1.SelectedItems[0].Tag as CompileError;
            if (error == null)
                return;
            if (this.m_ScriptEditForm != null && !this.m_ScriptEditForm.IsDisposed)
                this.m_ScriptEditForm.LocateTo(error.Line, error.Column);
        }
    }
}