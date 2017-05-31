// ***********************************************************
// 护理病历配置管理系统,服务器报表属性信息编辑对话框.
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
using EMRDBLib;
 

namespace Designers.Report
{
    internal partial class ReportInfoForm : HerenForm
    {
        private ReportType m_reportTypeInfo = null;

        /// <summary>
        /// 获取或设置当前报表类型信息
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [Description("获取或设置当前报表类型信息")]
        public ReportType ReportTypeInfo
        {
            get { return this.m_reportTypeInfo; }
            set { this.m_reportTypeInfo = value; }
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

       

        public ReportInfoForm()
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
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadDocTypeInfo();
            //this.LoadWardDocType();
            this.txtTempletName.Focus();
            this.txtTempletName.SelectAll();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void LoadDocTypeInfo()
        {
            this.txtTempletID.Text = string.Empty;
            this.txtTempletName.Text = string.Empty;
            this.chkIsValid.Checked = true;
            if (this.m_reportTypeInfo == null)
                return;
            this.txtTempletID.Text = this.m_reportTypeInfo.ReportTypeID;
            this.txtTempletName.Text = this.m_reportTypeInfo.ReportTypeName;
            this.chkIsValid.Checked = this.m_reportTypeInfo.IsValid;
        }
        

        /// <summary>
        /// 生成待保存的文档类型信息
        /// </summary>
        /// <returns>bool</returns>
        private bool MakeDocTypeInfo()
        {
            if (this.m_reportTypeInfo == null)
                this.m_reportTypeInfo = new ReportType();

            if (this.txtTempletID.Text.Trim() == string.Empty)
            {
                MessageBoxEx.ShowError("请输入表单类型ID号");
                return false;
            }

            if (this.txtTempletName.Text.Trim() == string.Empty)
            {
                MessageBoxEx.ShowError("请输入表单类型名称");
                return false;
            }

            this.m_reportTypeInfo.ReportTypeID = this.txtTempletID.Text.Trim();
            this.m_reportTypeInfo.ReportTypeName = this.txtTempletName.Text.Trim();
            this.m_reportTypeInfo.IsValid = this.chkIsValid.Checked;
            return true;
        }
        

        private void txtWardList_DoubleClick(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
           // this.ShowDeptListEditForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.MakeDocTypeInfo())
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.DialogResult = DialogResult.OK;
        }
    }
}
