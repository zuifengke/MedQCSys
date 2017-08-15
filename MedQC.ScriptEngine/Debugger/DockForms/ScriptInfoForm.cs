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
using EMRDBLib;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class ScriptInfoForm : HerenForm
    {
        private ScriptConfig m_docTypeInfo = null;

        /// <summary>
        /// 获取或设置当前表单类型信息
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [Description("获取或设置当前表单类型信息")]
        public ScriptConfig DocTypeInfo
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
        public ScriptInfoForm()
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
            this.txtTempletName.Focus();
            this.txtTempletName.SelectAll();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void LoadDocTypeInfo()
        {
            this.txtTempletID.Text = string.Empty;
            this.txtTempletName.Text = string.Empty;
            if (this.m_docTypeInfo == null)
                return;
            this.txtTempletID.Text = this.m_docTypeInfo.SCRIPT_ID;
            this.txtTempletName.Text = this.m_docTypeInfo.SCRIPT_NAME;
        }


        /// <summary>
        /// 生成待保存的文档类型信息
        /// </summary>
        /// <returns>bool</returns>
        private bool MakeDocTypeInfo()
        {
            if (this.m_docTypeInfo == null)
                this.m_docTypeInfo = new ScriptConfig();

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
            this.DocTypeInfo.SCRIPT_NAME = this.txtTempletName.Text;
            this.DocTypeInfo.SCRIPT_ID = this.txtTempletID.Text;
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

        }

    }
}
