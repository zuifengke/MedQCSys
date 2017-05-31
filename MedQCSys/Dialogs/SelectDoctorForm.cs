using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Controls;
using System.Collections;

namespace MedQCSys.Dialogs
{
    public partial class SelectDoctorForm : HerenForm
    {
        private string m_szDoctorID = string.Empty;
        /// <summary>
        /// Ò½ÉúId
        /// </summary>
        public string DoctorID
        {
            set { m_szDoctorID = value; }
            get { return m_szDoctorID;}
        }
        public SelectDoctorForm(Dictionary<string,string> doctors)
        {
            InitializeComponent();
            InitDoctors(doctors);
        }

        private void InitDoctors(Dictionary<string, string> doctors)
        {
            ArrayList arr = new ArrayList();
            foreach (KeyValuePair<string, string> item in doctors)
            {
                arr.Add(item);
            }
            this.cbxDoctors.DataSource = arr;
            this.cbxDoctors.DisplayMember = "Value";
            this.cbxDoctors.ValueMember = "Key";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.m_szDoctorID = this.cbxDoctors.SelectedValue.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}