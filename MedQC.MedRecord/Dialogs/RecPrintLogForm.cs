using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using Heren.MedQC.Core;
using Heren.MedQC.Utilities.IDCardRead;
using MetroFramework.Controls;
using MetroFramework.Forms;
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
    public partial class RecPrintLogForm : MetroForm
    {
        public RecPrintLogForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!string.IsNullOrEmpty(DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.PrintContent]))
            {
                string[] arrPrintContent = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.PrintContent].Split('|');
                foreach (var item in arrPrintContent)
                {
                    if (item == string.Empty)
                        continue;
                    MetroCheckBox chk = new MetroCheckBox();
                    chk.Text = item;
                    chk.Name = item;
                    chk.Width = 20 + item.Length * 20;
                    p_PRINT_CONTENT.Controls.Add(chk);
                }
            }
            this.txt_PATIENT_ID.Text = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            this.txt_PATIENT_NAME.Text = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            if (SystemParam.Instance.PatVisitInfo.DISCHARGE_TIME != SysTimeHelper.Instance.DefaultTime)
                this.txt_DISCHARGE_TIME.Text = SystemParam.Instance.PatVisitInfo.DISCHARGE_TIME.ToString("yyyy-MM-dd HH:mm");
            this.txt_PATIENT_IDENTIFICATION.Text = SystemParam.Instance.PatVisitInfo.ID_NO;
            this.GetGridData();

        }
        private void xPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RecPrintLog recPrintLog = this.Tag as RecPrintLog;
            if (recPrintLog == null)
                recPrintLog = new RecPrintLog();
            recPrintLog.DISCHARGE_TIME = SystemParam.Instance.PatVisitInfo.DISCHARGE_TIME;
            if (this.rbtn_INVOICE1.Checked)
                recPrintLog.INVOICE = true;
            else
                recPrintLog.INVOICE = false;
            if (!string.IsNullOrEmpty(txt_MONEY.Text.Trim()))
                recPrintLog.MONEY = float.Parse(this.txt_MONEY.Text.Trim());
            StringBuilder sbPrintContent = new StringBuilder();
            foreach (Control item in this.p_PRINT_CONTENT.Controls)
            {
                MetroCheckBox chk = item as MetroCheckBox;
                if (chk == null)
                    continue;
                if (chk.Checked)
                    sbPrintContent.Append(chk.Text + "|");
            }
            recPrintLog.PRINT_CONTENT = sbPrintContent.ToString();
            recPrintLog.PATIENT_ID = txt_PATIENT_ID.Text;
            recPrintLog.PATIENT_ID_NO = txt_PATIENT_IDENTIFICATION.Text;
            recPrintLog.PATIENT_NAME = txt_PATIENT_NAME.Text;
            recPrintLog.PRINT_ID_NO = txt_PRINT_IDENTIFICATION.Text.Trim();
            recPrintLog.PRINT_NAME = txt_PRINT_NAME.Text;
            recPrintLog.PRINT_TIME = DateTime.Now;
            recPrintLog.RELATIONSHIP_PATIENT = txt_RELATIONSHIP_PATIENT.Text;
            recPrintLog.REMARKS = txt_REMARKS.Text;
            recPrintLog.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            recPrintLog.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            short shRet = SystemData.ReturnValue.OK;
            if (!string.IsNullOrEmpty(recPrintLog.PRINT_ID))
            {
                shRet = RecPrintLogAccess.Instance.Update(recPrintLog);
            }
            else
            {
                recPrintLog.PRINT_ID = recPrintLog.MakeID();
                shRet = RecPrintLogAccess.Instance.Insert(recPrintLog);
            }

            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("操作失败");
                return;
            }
            MessageBoxEx.ShowMessage("保存成功");
            this.GetGridData();
        }

        private void GetGridData()
        {
            this.dataTableView1.Rows.Clear();
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitNo = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            List<RecPrintLog> lstRecPrintLog = null;
            short shRet = RecPrintLogAccess.Instance.GetRecPrintLogs(szPatientID, szVisitNo, ref lstRecPrintLog);
            if (lstRecPrintLog == null)
                return;
            int rowIndex = 0;
            foreach (var item in lstRecPrintLog)
            {
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_MONEY.Index].Value = item.MONEY;
                row.Cells[this.col_PRINT_NAME.Index].Value = item.PRINT_NAME;
                row.Cells[this.col_PRINT_TIME.Index].Value = item.PRINT_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colEdit.Index].Value = "编辑";
                row.Cells[this.colDelete.Index].Value = "删除";
                row.Tag = item;
            }
        }

        private void txt_MONEY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符  
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || this.txt_MONEY.Text.Length == 0)//小数点  
                {
                    e.Handled = true;
                }
                if (this.txt_MONEY.Text.LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void dataTableView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            RecPrintLog recPrintLog = this.dataTableView1.Rows[e.RowIndex].Tag as RecPrintLog;
            if (e.ColumnIndex == this.colEdit.Index)
            {
                if (recPrintLog.DISCHARGE_TIME != recPrintLog.DefaultTime)
                    this.txt_DISCHARGE_TIME.Text = recPrintLog.DISCHARGE_TIME.ToString("yyyy-MM-dd HH:mm");
                txt_MONEY.Text = recPrintLog.MONEY.ToString();
                txt_PATIENT_ID.Text = recPrintLog.PATIENT_ID;
                txt_PATIENT_IDENTIFICATION.Text = recPrintLog.PATIENT_ID_NO;
                txt_PATIENT_NAME.Text = recPrintLog.PATIENT_NAME;
                txt_PRINT_IDENTIFICATION.Text = recPrintLog.PRINT_ID_NO;
                if (!string.IsNullOrEmpty(recPrintLog.PRINT_CONTENT))
                {
                    foreach (var item in this.p_PRINT_CONTENT.Controls)
                    {
                        var chk = item as MetroCheckBox;
                        if (chk == null)
                            continue;
                        chk.Checked = false;
                        if (recPrintLog.PRINT_CONTENT.IndexOf(chk.Text) >= 0)
                            chk.Checked = true;
                    }
                }
                txt_RELATIONSHIP_PATIENT.Text = recPrintLog.RELATIONSHIP_PATIENT;
                txt_REMARKS.Text = recPrintLog.REMARKS;
                this.Tag = recPrintLog;
            }
            else if (e.ColumnIndex == this.colDelete.Index)
            {
                if (MessageBoxEx.ShowConfirm("确定删除吗？") != DialogResult.OK)
                {
                    return;
                }
                short shRet = RecPrintLogAccess.Instance.Delete(recPrintLog.PRINT_ID);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    this.dataTableView1.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    MessageBoxEx.ShowError("删除失败");
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CardInfo cardInfo = null;
            string szResult = IDCardRead.GetCardInfo(ref cardInfo);
            if (!string.IsNullOrEmpty(szResult))
            {
                MessageBoxEx.ShowMessage(szResult);
                return;
            }
            this.txt_PRINT_IDENTIFICATION.Text = cardInfo.ID;
            this.txt_PRINT_NAME.Text = cardInfo.Name;
        }
    }
}
