// ***********************************************************
// 护理病历配置管理系统,脚本编辑器查找替换窗口.
// Author : YangMingkun, Date : 2013-5-4
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using EMRDBLib;
using Heren.MedQC.ScriptEngine.Debugger;

namespace Heren.MedQC.ScriptEngine.FindReplace
{
    internal partial class FindResultForm : DockContentBase 
    {
        private ScriptEditForm m_ScriptEditForm = null;

        /// <summary>
        /// 获取或设置查找的目标脚本窗口
        /// </summary>
        public ScriptEditForm ScriptEditForm
        {
            get { return this.m_ScriptEditForm; }
            set { this.m_ScriptEditForm = value; }
        }

        private string m_findText = string.Empty;

        /// <summary>
        /// 获取或设置查找的原始文本
        /// </summary>
        public string FindText
        {
            get { return this.m_findText; }
            set { this.m_findText = value; }
        }

        private List<FindResult> m_results = null;

        /// <summary>
        /// 获取或设置查找到的结果集列表
        /// </summary>
        public List<FindResult> Results
        {
            get { return this.m_results; }
            set { this.m_results = value; }
        }

        private bool m_showFileName = false;

        public bool ShowFileName
        {
            get
            {
                return this.m_showFileName;
            }

            set
            {
                this.m_showFileName = value;
                if (m_showFileName)
                {
                    this.colFileName.Visible = true;
                }
                else
                {
                    this.colFileName.Visible = false;
                }
            }
        }

        public FindResultForm(DebuggerForm mainForm)
            : base(mainForm)
        {
            this.HideOnClose = true;
            this.ShowHint = DockState.DockBottom;
            this.DockAreas = DockAreas.DockLeft | DockAreas.DockRight
                | DockAreas.DockTop | DockAreas.DockBottom;
        }

        //对于需要记忆位置的停靠窗口,请将控件创建代码放入Load事件内
        //这样当窗口被构造时,就不会加载界面元素,用以提高系统启动速度
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            //this.Icon = Properties.Resources.FindIcon;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.OnRefreshView();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F3)
                this.RefreshResultList();
            return base.ProcessDialogKey(keyData);
        }

        public override void OnRefreshView()
        {
            this.dataTableView1.Rows.Clear();
            this.Update();
            if (this.m_results == null || this.m_results.Count <= 0)
                return;
            foreach (FindResult result in this.m_results)
            {
                int rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Tag = result;
                row.Cells[this.colNo.Index].Value = rowIndex + 1;
                row.Cells[this.colContent.Index].Value = result.Text;
                row.Cells[this.colLineNo.Index].Value = result.Line + 1;
                row.Cells[this.colFileName.Index].Value = result.TempletName;
            }
        }

        private void RefreshResultList()
        {
            int selectedIndex = 0;
            if (this.dataTableView1.SelectedRows.Count > 0)
                selectedIndex = this.dataTableView1.SelectedRows[0].Index;

            if (this.ScriptEditForm != null)
                this.ScriptEditForm.FindText(this.m_findText, false);
            this.dataTableView1.SelectRow(selectedIndex);
        }

        private void dataTableView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataTableView1.Rows[e.RowIndex];
            if (row == null || row.Index < 0)
                return;
            FindResult result = row.Tag as FindResult;

           
            if (result.FileType == SystemData.FileType.SCRIPT)
            {
                ScriptConfig scriptConfig = new ScriptConfig();
                scriptConfig.SCRIPT_ID = result.TempletID;
                scriptConfig.SCRIPT_NAME = result.TempletName;
                this.m_ScriptEditForm = ScriptHandler.Instance.GetScriptForm(scriptConfig); 
                if (this.m_ScriptEditForm == null)
                {
                    ScriptHandler.Instance.OpenScriptConfig(scriptConfig);
                    this.m_ScriptEditForm = this.DebuggerForm.ActiveScriptForm;
                    Application.DoEvents();
                }
            }
            if (result == null)
                return;
            if (this.m_ScriptEditForm != null && !this.m_ScriptEditForm.IsDisposed)
                this.m_ScriptEditForm.LocateToText(result.Offset, result.Length);
            this.dataTableView1.SelectRow(e.RowIndex);
        }
    }
}
