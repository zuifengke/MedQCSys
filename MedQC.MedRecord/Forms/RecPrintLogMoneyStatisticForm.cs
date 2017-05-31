/********************************************************
 * @FileName   : PatOutHospitalListForm.cs
 * @Description: 病案管理系统之病案归档
 * @Author     : 叶慧(Yehui)
 * @Date       : 2017-04-17 11:06:51
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using MedQCSys.Utility;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls.TableView;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;
using System.Collections;
using MedQCSys.PatPage;

namespace Heren.MedQC.MedRecord
{
    public partial class RecPrintLogMoneyStatisticForm : DockContentBase
    {
        public RecPrintLogMoneyStatisticForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dtTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtTimeEnd.Value = DateTime.Now;

        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载，请稍候...");
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            DateTime dtPrintTimeBegin = SystemParam.Instance.DefaultTime;
            DateTime dtPrintTimeEnd = SystemParam.Instance.DefaultTime;
            dtPrintTimeBegin = this.dtTimeBegin.Value;
            dtPrintTimeEnd = this.dtTimeEnd.Value;
            List<RecPrintLog> lstRecPrintLogs = null;
            short shRet = RecPrintLogAccess.Instance.GetRecPrintLogs(dtPrintTimeBegin, dtPrintTimeEnd, string.Empty, ref lstRecPrintLogs);
            if (lstRecPrintLogs == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            float fSumMoney=0;
            float fInvoiceMoney=0;
            float fUnInvoiceMoney=0;
            foreach (var item in lstRecPrintLogs)
            {
                fSumMoney  += item.MONEY;
                if (item.INVOICE)
                    fInvoiceMoney += item.MONEY;
                else
                    fUnInvoiceMoney  += item.MONEY;
            }
            lblSumMoney.Text = fSumMoney.ToString("F2");
            lbl_InvoiceMoney.Text = fInvoiceMoney.ToString("F2");
            lbl_UnInvoiceMoney.Text = fUnInvoiceMoney.ToString("F2");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}
