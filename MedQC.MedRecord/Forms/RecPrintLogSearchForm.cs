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
using Heren.MedQC.Core;

namespace Heren.MedQC.MedRecord
{
    public partial class RecPrintLogSearchForm : DockContentBase
    {
        public RecPrintLogSearchForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = false;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dtTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtTimeEnd.Value = DateTime.Now;
            //插入打印内容列
            string szPrintContent = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.PrintContent];
            if (!string.IsNullOrEmpty(szPrintContent))
            {
                string[] arrPrintContent = szPrintContent.Split('|');
                foreach (var item in arrPrintContent)
                {
                    if (item == string.Empty)
                        continue;
                    DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                    column.HeaderText = item;
                    column.Name = item;
                    column.Width = item.Length * 20;
                    this.dataTableView1.Columns.Add(column);
                }
            }
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载，请稍候...");
            this.dataTableView1.Rows.Clear();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.dataTableView1.Rows.Clear();
            DateTime dtPrintTimeBegin = SystemParam.Instance.DefaultTime;
            DateTime dtPrintTimeEnd = SystemParam.Instance.DefaultTime;
            dtPrintTimeBegin = this.dtTimeBegin.Value;
            dtPrintTimeEnd = this.dtTimeEnd.Value;
            string szPatientName = this.txt_PATIENT_NAME.Text.Trim();
            List<RecPrintLog> lstRecPrintLogs = null;
            short shRet = RecPrintLogAccess.Instance.GetRecPrintLogs(dtPrintTimeBegin, dtPrintTimeEnd, szPatientName, ref lstRecPrintLogs);
            if (lstRecPrintLogs == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            int rowIndex = 0;
            foreach (var item in lstRecPrintLogs)
            {
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                if (item.DISCHARGE_TIME != item.DefaultTime)
                    row.Cells[this.col_DISCHARGE_TIME.Index].Value = item.DISCHARGE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_INVOICE.Index].Value = item.INVOICE ? "是" : "否";
                row.Cells[this.col_MONEY.Index].Value = item.MONEY;
                row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
                row.Cells[this.col_PATIENT_ID_NO.Index].Value = item.PATIENT_ID_NO;
                row.Cells[this.col_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                if (!string.IsNullOrEmpty(item.PRINT_CONTENT))
                {
                    string[] arrPrintContent = item.PRINT_CONTENT.Split('|');
                    foreach (var content in arrPrintContent)
                    {
                        if (string.IsNullOrEmpty(content))
                            continue;
                        if (this.dataTableView1.Columns[content] != null)
                            row.Cells[content].Value = true;
                    }
                }
                row.Cells[this.col_PRINT_ID_NO.Index].Value = item.PRINT_ID_NO;
                row.Cells[this.col_PRINT_NAME.Index].Value = item.PRINT_NAME;
                if (item.PRINT_TIME != item.DefaultTime)
                    row.Cells[this.col_PRINT_TIME.Index].Value = item.PRINT_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_RELATIONSHIP_PATIENT.Index].Value = item.RELATIONSHIP_PATIENT;
                row.Cells[this.col_REMARKS.Index].Value = item.REMARKS;
                row.Tag = item;
            }
            base.ShowStatusMessage(string.Format("共{0}条记录",lstRecPrintLogs.Count));
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataTableView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;
            //QcModifyNotice item = this.dataTableView1.Rows[e.RowIndex].Tag as QcModifyNotice;
            //if (item == null)
            //    return;

            //List<MedicalQcMsg> lstMedicalQcMsg = null;
            //short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgs(item.MODIFY_NOTICE_ID, ref lstMedicalQcMsg);
            //if (lstMedicalQcMsg == null || lstMedicalQcMsg.Count <= 0)
            //    return;
            //int rowIndex = 0;
            //if (string.IsNullOrEmpty(lstMedicalQcMsg[0].TOPIC_ID))
            //{
            //    return;
            //}
        }

        private void dataTableView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    if (e.RowIndex < 0)
            //        return;
            //    MrArchive mrArchive = this.dataTableView1.Rows[e.RowIndex].Tag as MrArchive;
            //    if (mrArchive == null)
            //        return;
            //    this.MainForm.SwitchPatient(mrArchive.PATIENT_ID, mrArchive.VISIT_ID);
        }

        private void dataTableView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;
            //DataGridViewRow row = this.dataTableView1.Rows[e.RowIndex];
            //MrArchive mrAchive = this.dataTableView1.Rows[e.RowIndex].Tag as MrArchive;
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {

        }
    }
}
