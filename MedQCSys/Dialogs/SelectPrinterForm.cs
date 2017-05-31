// ***********************************************************
// 打印机选择窗口
// Creator:tangcheng  Date:2011-02-17
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;

namespace MedQCSys.Dialogs
{
    internal partial class SelectPrinterForm : HerenForm
    {
        private string m_SelectedPrinter = string.Empty;
        /// <summary>
        /// 获取或设置当前选择的打印机
        /// </summary>
        public string SelectedPrinter
        {
            get
            {
                this.m_SelectedPrinter = this.cmbBoxPrinter.Text.Trim();
                return this.m_SelectedPrinter;
            }
            set { this.m_SelectedPrinter = value; }
        }

        public SelectPrinterForm()
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Update();
            this.DisplayPrinterInfo();
            this.LoadLocalPrinters();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void LoadLocalPrinters()
        {
            string[] arrPrintList = GlobalMethods.Win32.GetPrinterList();
            if (arrPrintList == null || arrPrintList.Length == 0)
                return;
            this.cmbBoxPrinter.SelectedIndexChanged -=
                new System.EventHandler(this.cmbBoxPrinter_SelectedIndexChanged);
            this.cmbBoxPrinter.Items.Clear();
            for (int i = 0; i < arrPrintList.Length; i++)
            {
                this.cmbBoxPrinter.Items.Add(arrPrintList[i].Trim());
                if (arrPrintList[i].Trim() == this.m_SelectedPrinter)
                    this.cmbBoxPrinter.SelectedIndex = i;
            }
            this.DisplayPrinterInfo();
            this.cmbBoxPrinter.SelectedIndexChanged +=
                new System.EventHandler(this.cmbBoxPrinter_SelectedIndexChanged);
        }

        private void DisplayPrinterInfo()
        {
            this.lblStatus.Text = string.Empty;
            this.lblURL.Text = string.Empty;
            this.lblType.Text = string.Empty;
            this.lblRemarks.Text = string.Empty;
            if (this.cmbBoxPrinter.SelectedIndex < 0)
                return;
            this.Update();
            string strPrinterName = this.cmbBoxPrinter.Text.Trim();
            NativeMethods.WinSpool.PRINTER_INFO printerInfo = 
                new NativeMethods.WinSpool.PRINTER_INFO();
            if (!GlobalMethods.Win32.GetPrinterInfo(strPrinterName, ref printerInfo))
                return;

            this.lblStatus.Text = GlobalMethods.Win32.GetPrinterStatus((int)printerInfo.Status);
            this.lblType.Text = printerInfo.pDriverName;
            this.lblURL.Text = printerInfo.pPortName;
            this.lblRemarks.Text = printerInfo.pComment;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmbBoxPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.DisplayPrinterInfo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}