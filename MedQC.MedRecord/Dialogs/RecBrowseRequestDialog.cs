using EMRDBLib;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.MedRecord.Dialogs
{
    public partial class RecBrowseRequestDialog : Form
    {
        public RecBrowseRequest RecBrowseRequest { get; set; }
        public RecBrowseRequestDialog()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.RecBrowseRequest == null)
                return;
            this.txt_PATIENT_ID.Text = this.RecBrowseRequest.PATIENT_ID;
            this.txt_PATIENT_NAME.Text = this.RecBrowseRequest.PATIENT_NAME;
            this.txt_REMARK.Text = this.RecBrowseRequest.REMARK;
            if (this.RecBrowseRequest.DISCHARGE_TIME != this.RecBrowseRequest.DefaultTime)
                this.txt_DISCHARGE_TIME.Text = this.RecBrowseRequest.DISCHARGE_TIME.ToString("yyyy-MM-dd HH:mm");
            if (this.RecBrowseRequest.REQUEST_TIME != this.RecBrowseRequest.DefaultTime)
                this.txt_REQUEST_TIME.Text = this.RecBrowseRequest.REQUEST_TIME.ToString("yyyy-MM-dd HH:mm");

        }
        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (this.RecBrowseRequest == null)
            {
                MessageBoxEx.ShowError("发送失败");
                return;
            }
            short shRet = SystemData.ReturnValue.OK;
            this.RecBrowseRequest.REMARK = this.txt_REMARK.Text.Trim();
            if (string.IsNullOrEmpty(this.RecBrowseRequest.ID))
            {
                this.RecBrowseRequest.ID = this.RecBrowseRequest.MakeID();
                shRet = RecBrowseRequestAccess.Instance.Insert(RecBrowseRequest);
            }
            else
            {
                shRet = RecBrowseRequestAccess.Instance.Update(RecBrowseRequest);
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("发送失败");
                return;
            }
            MessageBoxEx.ShowMessage("发送成功");
        }
    }
}
