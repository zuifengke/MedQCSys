// ***********************************************************
// 护理病历配置管理系统,表单模板设计器窗口.
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Forms.Loader;
using Heren.Common.Forms.Designer;
using Heren.Common.VectorEditor.Shapes;
using Heren.Common.Forms;
using EMRDBLib;
using Designers.Report;

namespace Designers.Templet
{
    internal partial class DesignEditForm : DockContentBase, IDesignEditForm
    {
        private TempletType m_docTypeInfo = null;

        /// <summary>
        /// 获取当打开的是服务器文件时,
        /// 设计器窗口当前关联的服务器文件信息
        /// </summary>
        public TempletType DocTypeInfo
        {
            get { return this.m_docTypeInfo; }
        }

        private string m_hndfFile = null;

        /// <summary>
        /// 获取当打开的是本地文件时,
        /// 设计器窗口当前关联的本地文件路径
        /// </summary>
        public string HndfFile
        {
            get { return this.m_hndfFile; }
        }

        private string m_flagCode = null;

        /// <summary>
        /// 获取或设置当前窗口的唯一标识,
        /// 仅用于查找到对应的脚本编辑窗口
        /// </summary>
        public string FlagCode
        {
            get { return this.m_flagCode; }
            set { this.m_flagCode = value; }
        }

        /// <summary>
        /// 获取当前表单设计器控件
        /// </summary>
        public FormDesigner FormDesigner
        {
            get { return this.formDesigner1; }
        }

        private PropertyGrid m_PropertyGrid = null;

        /// <summary>
        /// 获取或设置表单设计器的属性编辑窗口
        /// </summary>
        public PropertyGrid PropertyGrid
        {
            get
            {
                return this.m_PropertyGrid;
            }

            set
            {
                this.m_PropertyGrid = value;
                this.formDesigner1.PropertyGrid = value;
            }
        }

        /// <summary>
        /// 标识当前脚本是否已经被修改过
        /// </summary>
        public bool IsModified
        {
            get { return this.formDesigner1.IsModified; }
            set { this.formDesigner1.IsModified = value; }
        }

        public DesignEditForm(DesignForm mainForm)
            : base(mainForm)
        {
            this.InitializeComponent();

            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }

        /// <summary>
        /// 检查是否有未保存的数据
        /// </summary>
        /// <returns>bool</returns>
        public override bool HasUncommit()
        {
            return this.IsModified;
        }

        /// <summary>
        /// 保存当前窗口的数据修改
        /// </summary>
        /// <returns>bool</returns>
        public override bool CommitModify()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            bool success = TempletHandler.Instance.SaveTemplet();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            return success;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                TempletHandler.Instance.ShowScriptTestForm();
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return true;
            }
            else if (keyData == Keys.F12)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                this.cmenuRebuild.Show(MousePosition);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        

        #region"工具栏"
        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            TempletHandler.Instance.SaveTemplet();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnUndo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Undo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnRedo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Redo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnCopy_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Copy();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnCut_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Cut();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnPaste_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Paste();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnDelete_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Delete();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnShowGrid_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.ShowGrid();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnProperty_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowPropertyEditForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnToolbox_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowToolboxListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnMakeReport_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            List<ElementBase> elements = this.formDesigner1.GetReportElement();
            ReportHandler.Instance.CreateReport(elements);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnDebug_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            TempletHandler.Instance.ShowScriptTestForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        #endregion

        #region"右键菜单"
        private void cmenuDesigner_Opening(object sender, CancelEventArgs e)
        {
            if (this.mnuSelectObject.DropDownItems.Count > 0)
                this.mnuSelectObject.DropDownItems.Clear();
            IComponent[] components = this.formDesigner1.GetParentControls();
            if (components == null || components.Length <= 1)
            {
                if (this.mnuSelectObject.Visible)
                    this.mnuSelectObject.Visible = false;
                return;
            }
            if (!this.mnuSelectObject.Visible)
                this.mnuSelectObject.Visible = true;
            foreach (IComponent component in components)
            {
                if (component == null || component.Site == null)
                    continue;
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Tag = component;
                menuItem.Text = component.Site.Name;
                menuItem.Click += new EventHandler(this.mnuSelectObject_Click);
                this.mnuSelectObject.DropDownItems.Add(menuItem);
            }
        }

        private void mnuSelectObject_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            this.formDesigner1.Select(menuItem.Tag as IComponent);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuScript_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            TempletHandler.Instance.OpenScriptEditForm(this);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuBringToFront_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.BringControlToFront();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuSendToBack_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.SendControlToBack();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Undo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Redo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Cut();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Copy();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Paste();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.formDesigner1.Delete();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuProperty_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowPropertyEditForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuToolbox_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowToolboxListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCopyControlName_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            object[] controls = this.formDesigner1.GetSelectedControls();
            if (controls == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            StringBuilder sbControlNames = new StringBuilder();
            int count = controls.Length;
            for (int index = 0; index < count; index++)
            {
                IComponent component = controls[index] as IComponent;
                if (component != null && component.Site != null)
                {
                    sbControlNames.Append(component.Site.Name);
                    if (index < count - 1) sbControlNames.AppendLine();
                }
            }
            GlobalMethods.Clipbrd.SetData(sbControlNames.ToString());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        #endregion

        #region F12 快捷带单菜单

        private void mnuReNameCb_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ReNameContols("XCheckBox");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuReNameDt_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ReNameContols("XDateTime");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuReNameRdb_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ReNameContols("XRadioButton");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuReNametxt_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ReNameContols("XTextBox");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuReNameCmb_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ReNameContols("XComboBox");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuReNameAll_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ReNameContols(string.Empty);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ReNameContols(string ControlType)
        {
            bool IsReNameAll = GlobalMethods.Misc.IsEmptyString(ControlType);
            IControl control = null;
            if (ControlType == "XCheckBox" || IsReNameAll)
            {
                control = new XCheckBox();
                this.RefreshContols(control, "XCheckBox");
            }
            if (ControlType == "XDateTime" || IsReNameAll)
            {
                control = new XDateTime();
                this.RefreshContols(control, "XDateTime");
            }
            if (ControlType == "XRadioButton" || IsReNameAll)
            {
                control = new XRadioButton();
                this.RefreshContols(control, "XRadioButton");
            }
            if (ControlType == "XTextBox" || IsReNameAll)
            {
                control = new XTextBox();
                this.RefreshContols(control, "XTextBox");
            }
            if (ControlType == "XComboBox" || IsReNameAll)
            {
                control = new XComboBox();
                this.RefreshContols(control, "XComboBox");
            }
        }

        private void RefreshContols(object ControlType, string szControlName)
        {
            int bgeinIndex = 1;
            foreach (Control control in this.formDesigner1.Controls)
            {
                this.RefreshContols(control, ControlType, szControlName, ref bgeinIndex);
            }
            MessageBox.Show(szControlName + "：" + bgeinIndex.ToString());
        }

        private void RefreshContols(Control control, object ControlType, string szControlName, ref int beginIndex)
        {
            if (control == null || control.IsDisposed)
                return;
            if (control.GetType() == ControlType.GetType())
            {
                control.Name = szControlName + beginIndex.ToString();
                beginIndex++;
            }
            else
            {
                foreach (Control childControl in control.Controls)
                {
                    this.RefreshContols(childControl, ControlType, szControlName, ref beginIndex);
                }
            }
        }
        #endregion

        /// <summary>
        /// 刷新表单标题
        /// </summary>
        private void RefreshFormText()
        {
            string title = string.Empty;
            string subhead = string.Empty;
            if (this.m_docTypeInfo == null)
            {
                title = "新模板";
            }
            if (this.m_hndfFile != null)
            {
                title = GlobalMethods.IO.GetFileName(this.m_hndfFile, true);
            }
            if (this.m_docTypeInfo != null)
            {
                title = this.m_docTypeInfo.DocTypeName;
                subhead = "更新时间:"
                    + this.m_docTypeInfo.ModifyTime.ToString("yyyy年M月d日 HH:mm");
            }
            if (!this.formDesigner1.IsModified)
                this.Text = title + "(设计)";
            else
                this.Text = title + "(设计) *";
            this.TabSubhead = subhead;
        }

        public bool Open(TempletType docTypeInfo)
        {
            return this.Open(docTypeInfo, null);
        }

        public bool Open(string szHndfFile)
        {
            return this.Open(null, szHndfFile);
        }

        public bool Open(TempletType docTypeInfo, string szHndfFile)
        {
            this.m_hndfFile = szHndfFile;
            this.m_docTypeInfo = docTypeInfo;
            this.RefreshFormText();
            if (this.MainForm == null)
                return false;

            FormFileParser parser = new FormFileParser();
            string szDesignData = null;
            if (System.IO.File.Exists(szHndfFile))
                szDesignData = parser.GetDesignData(szHndfFile);
            this.formDesigner1.OpenDesignData(szDesignData);
            return true;
        }

        public bool Save(string szDesignFile)
        {
            return this.formDesigner1.SaveDesignFile(szDesignFile);
        }

        public bool Save(ref string szDesignData)
        {
            return this.formDesigner1.SaveDesignData(ref szDesignData);
        }

        private void formDesigner1_DocumentChanged(object sender, EventArgs e)
        {
            this.RefreshFormText();
        }

        private void formDesigner1_ComponentDbClick(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            //显示属性
            this.MainForm.ShowPropertyEditForm();

            //复制名称
            object[] controls = this.formDesigner1.GetSelectedControls();
            if (controls != null && controls.Length > 0)
            {
                IComponent component = controls[0] as IComponent;
                if (component != null && component.Site != null)
                    GlobalMethods.Clipbrd.SetData(component.Site.Name);
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void formDesigner1_SelectionChanged(object sender, EventArgs e)
        {
            Control control = this.formDesigner1.GetPrimarySelection() as Control;
            if (control != null)
                this.ShowStatusMessage("主选中控件:" + control.Name);
        }
    }
}
