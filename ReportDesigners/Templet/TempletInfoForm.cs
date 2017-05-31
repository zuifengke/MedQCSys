// ***********************************************************
// 护理病历配置管理系统,服务器表单属性信息编辑对话框.
// Author : YangMingkun, Date : 2012-7-30
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Controls;
using Heren.Common.Controls.TableView;
using Heren.Common.VectorEditor.Shapes;
using EMRDBLib;

namespace Designers.Templet
{
    internal partial class TempletInfoForm : HerenForm
    {
        private TempletType m_docTypeInfo = null;

        /// <summary>
        /// 获取或设置当前表单类型信息
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [Description("获取或设置当前表单类型信息")]
        public TempletType DocTypeInfo
        {
            get { return this.m_docTypeInfo; }
            set { this.m_docTypeInfo = value; }
        }

        private bool m_bIsNew = false;

        /// <summary>
        /// 获取或设置当前是否是新建
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        [Description("获取或设置当前是否是新建")]
        public bool IsNew
        {
            get { return this.m_bIsNew; }
            set { this.m_bIsNew = value; }
        }

        private bool m_bIsFolder = false;

        /// <summary>
        /// 获取或设置当前是否是目录
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        [Description("获取或设置当前是否是目录")]
        public bool IsFolder
        {
            get { return this.m_bIsFolder; }
            set { this.m_bIsFolder = value; }
        }
        public TempletInfoForm()
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            if (this.m_bIsFolder)
            {
                this.Text = "目录信息";
                this.chkIsValid.Enabled = false;
                this.chkIsRepeat.Enabled = false;
                this.chkListPrintable.Enabled = false;
                this.chkFormPrintable.Enabled = false;
            }
           
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            this.LoadDocTypeInfo();
            this.txtTempletName.Focus();
            this.txtTempletName.SelectAll();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void LoadDocTypeInfo()
        {
            this.txtTempletID.Text = string.Empty;
            this.txtTempletName.Text = string.Empty;
            this.chkIsValid.Checked = true;
            this.chkIsVisible.Checked = true;
            this.chkIsRepeat.Checked = true;
            this.chkFormPrintable.Checked = false;
            this.chkListPrintable.Checked = false;
            this.txtDocTypeNo.Text = string.Empty;
            if (this.m_docTypeInfo == null)
                return;
            this.txtTempletID.Text = this.m_docTypeInfo.DocTypeID;
            this.txtTempletName.Text = this.m_docTypeInfo.DocTypeName;
            this.chkIsValid.Checked = this.m_docTypeInfo.IsValid;
            this.chkIsVisible.Checked = this.m_docTypeInfo.IsVisible;
            this.chkIsRepeat.Checked = this.m_docTypeInfo.IsRepeated;
            this.txtDocTypeNo.Text = this.m_docTypeInfo.DocTypeNo.ToString();


            if (this.m_docTypeInfo.PrintMode == FormPrintMode.Form
                || this.m_docTypeInfo.PrintMode == FormPrintMode.FormAndList)
                this.chkFormPrintable.Checked = true;
            if (this.m_docTypeInfo.PrintMode == FormPrintMode.List
                || this.m_docTypeInfo.PrintMode == FormPrintMode.FormAndList)
                this.chkListPrintable.Checked = true;
        }


        /// <summary>
        /// 生成待保存的文档类型信息
        /// </summary>
        /// <returns>bool</returns>
        private bool MakeDocTypeInfo()
        {
            if (this.m_docTypeInfo == null)
                this.m_docTypeInfo = new TempletType();

            if (this.txtTempletID.Text.Trim() == string.Empty)
            {
                MessageBoxEx.ShowError("请输入病历类型ID号");
                return false;
            }

            if (this.txtTempletName.Text.Trim() == string.Empty)
            {
                MessageBoxEx.ShowError("请输入病历类型名称");
                return false;
            }

            this.m_docTypeInfo.DocTypeID = this.txtTempletID.Text.Trim();
            this.m_docTypeInfo.DocTypeName = this.txtTempletName.Text.Trim();
            this.m_docTypeInfo.IsRepeated = this.chkIsRepeat.Checked;
            this.m_docTypeInfo.IsVisible = this.chkIsVisible.Checked;
            this.m_docTypeInfo.IsValid = this.chkIsValid.Checked;

            this.m_docTypeInfo.PrintMode = FormPrintMode.None;
            if (this.chkFormPrintable.Checked)
                this.m_docTypeInfo.PrintMode = FormPrintMode.Form;
            if (this.chkListPrintable.Checked)
                this.m_docTypeInfo.PrintMode = FormPrintMode.List;
            if (this.chkFormPrintable.Checked && this.chkListPrintable.Checked)
                this.m_docTypeInfo.PrintMode = FormPrintMode.FormAndList;
            this.m_docTypeInfo.DocTypeNo =
                GlobalMethods.Convert.StringToValue(this.txtDocTypeNo.Text.Trim(), 0);
            return true;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.MakeDocTypeInfo())
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.DialogResult = DialogResult.OK;
        }

        private void chkDocTypeNo_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDocTypeNo.Enabled = this.chkDocTypeNo.Checked;
        }

    }
}
