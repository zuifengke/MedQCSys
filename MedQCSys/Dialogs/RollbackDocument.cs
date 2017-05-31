using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Controls;
using Heren.Common.Libraries;

namespace MedQCSys.Dialogs
{
    public partial class RollbackDocument : HerenForm
    {
        private string m_szReason = string.Empty;
        /// <summary>
        /// 退回原因
        /// </summary>
        public string Reason
        {
            set { this.m_szReason = value; }
            get { return this.m_szReason; }
        }
        public RollbackDocument()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.m_szReason = txtReason.Text.Trim();
            if (txtReason.Text.Trim() == string.Empty)
            {
                MessageBoxEx.Show("请输入病历退回原因", MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}