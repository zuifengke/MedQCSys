using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMRDBLib;
using EMRDBLib.Entity;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;

using EMRDBLib.DbAccess;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;
namespace Heren.MedQC.Statistic
{
    public partial class StatByQCContentRecordForm : DockContentBase
    {
        public StatByQCContentRecordForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();

            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            InitDept();
        }

        private void InitDept()
        {

            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();

            dtpBeginTime.Value = Convert.ToDateTime(dtpBeginTime.Value.ToString("yyyy/MM/dd 00:00:00"));
            dtpEndTime.Value = Convert.ToDateTime(dtpEndTime.Value.ToString("yyyy/MM/dd 23:59:59"));
            string szDeptName = this.cboDeptName.SelectedItem == null || this.cboDeptName.SelectedIndex == 0 ? "" : this.cboDeptName.Text;
            List<QcContentRecord> lstQcContentRecord = null;
            QcContentRecordAccess.Instance.GetQcContentRecord(dtpBeginTime.Value, dtpEndTime.Value, szDeptName, this.txtPatientID.Text.Trim(),
                this.txtVisitID.Text.Trim(), ref lstQcContentRecord);


            if (lstQcContentRecord == null || lstQcContentRecord.Count == 0)
            {
                MessageBoxEx.Show("没有查询到符合条件的数据！", MessageBoxIcon.Information);
                return;
            }

            foreach (var item in lstQcContentRecord)
            {
                int iRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[iRowIndex];
                SetRowData(row, item);
            }
        }

        private void SetRowData(DataGridViewRow row, QcContentRecord item)
        {
            if (item == null)
                return;
            row.Tag = item;
            row.Cells[this.colBugClass.Index].Value = item.BugClass == 0 ? "警告" : "错误";
            row.Cells[this.colBugType.Index].Value = item.BugType == "1" ? "内容" : "元素";
            row.Cells[this.colCheckDate.Index].Value = item.CheckDate==item.DefaultTime?"":item.CheckDate.ToString();
            row.Cells[this.colCheckName.Index].Value = item.CheckerName;
            row.Cells[this.colCreateID.Index].Value = item.CreateID;
            row.Cells[this.colCreateName.Index].Value = item.CreateName;
            row.Cells[this.colDeptIncharge.Index].Value = item.DeptIncharge;
            row.Cells[this.colDocID.Index].Value = item.DocSetID;
            row.Cells[this.colDocIncharge.Index].Value = item.DocIncharge;
            row.Cells[this.colDocTime.Index].Value = item.DocTime;
            row.Cells[this.colDocTitle.Index].Value = item.DocTitle;
            row.Cells[this.colDocTypeID.Index].Value = item.DocTypeID;
            row.Cells[this.colModifyTime.Index].Value = item.ModifyTime;
            row.Cells[this.colPaitentID.Index].Value = item.PatientID;
            row.Cells[this.colPatientName.Index].Value = item.PatientName;
            row.Cells[this.colPoint.Index].Value = item.Point;
            row.Cells[this.colQCExpalin.Index].Value = item.QCExplain;
            row.Cells[this.colVisitID.Index].Value = item.VisitID;
            row.Cells[this.colBugCreateTime.Index].Value = item.BugCreateTime;
        }

        private void btnExcleOut_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "系统病历内容检查详情");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string szDocID = this.dataGridView1.Rows[e.RowIndex].Cells[this.colDocID.Index].Value != null
                ? this.dataGridView1.Rows[e.RowIndex].Cells[this.colDocID.Index].Value.ToString()
                : string.Empty;
            if (string.IsNullOrEmpty(szDocID))
                return;
             MedDocInfo docInfo = null ;
            EmrDocAccess.Instance.GetDocInfo(szDocID, ref docInfo);
            this.MainForm.OpenDocument(docInfo);
        }
    }
}
