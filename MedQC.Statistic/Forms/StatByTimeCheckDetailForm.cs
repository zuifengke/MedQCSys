using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Report;
using EMRDBLib.DbAccess;
using Heren.MedQC.Utilities;
using EMRDBLib;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Statistic
{
    public partial class StatByTimeCheckDetailForm : DockContentBase
    {
        public StatByTimeCheckDetailForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();

            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dataGridView1.Font = new Font("宋体", 10.5f);
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
            string[] qcReuslt =  new string[]{ "正常","未书写超时","书写提前","书写超时","正常未书写"};
            this.cboQcResult.Items.Clear();
            foreach (string item in qcReuslt)
            {
                this.cboQcResult.Items.Add(item);
            }
            this.ShowStatusMessage(null);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dtBeginTime = DateTime.Parse(this.dtpBeginTime.Value.ToShortDateString());
            DateTime dtEndTime = DateTime.Parse(this.dtpEndTime.Value.AddDays(1).ToShortDateString());
            string szTimeType = string.Empty;
            if (rbtCheckTime.Checked)
                szTimeType = "Check_Date";
            else if (rbtEndTime.Checked)
                szTimeType = "END_DATE";
            string szDeptCode = string.Empty;
            string szQcResult = string.Empty;
            if (this.cboDeptName.SelectedItem != null && !string.IsNullOrEmpty(this.cboDeptName.Text.Trim()))
            {
                szDeptCode = (this.cboDeptName.SelectedItem as  DeptInfo).DEPT_CODE;
            }
            if (this.cboQcResult.SelectedItem != null)
            {
                szQcResult = EMRDBLib.SystemData.WrittenState.GetWrittenStateCode(this.cboQcResult.SelectedItem.ToString());
            }
            this.ShowStatusMessage("正在查询时效质控记录...");
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            List<EMRDBLib.QcTimeRecord> lstQcTimeRecord = null;
            short shRet = QcTimeRecordAccess.Instance.GetQcTimeRecords(dtBeginTime, dtEndTime, szTimeType, szQcResult, szDeptCode, ref lstQcTimeRecord);
            if (shRet == EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            {
                this.dataGridView1.Rows.Clear();
                this.ShowStatusMessage("未找到时效质控记录");
                WorkProcess.Instance.Close();
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK
                && shRet != EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            {
                WorkProcess.Instance.Close();
                MessageBoxEx.Show("查询失败");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }

            this.LoadQcTimeRecord(lstQcTimeRecord);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        /// <summary>
        /// 装载时效记录信息
        /// </summary>
        private void LoadQcTimeRecord(List<EMRDBLib.QcTimeRecord> lstQcTimeRecord)
        {
            this.dataGridView1.Rows.Clear();
            if (lstQcTimeRecord == null || lstQcTimeRecord.Count <= 0)
                return;
            WorkProcess.Instance.Initialize(this, lstQcTimeRecord.Count
              , string.Format("正在加载时效记录，请稍候..."));
            for (int index = 0; index < lstQcTimeRecord.Count; index++)
            {
                WorkProcess.Instance.Show(string.Format("加载到{0}，请稍候...", index.ToString()), index);
                if (WorkProcess.Instance.Canceled)
                    break;
                EMRDBLib.QcTimeRecord record = lstQcTimeRecord[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = record; //将记录信息保存到该行
                row.Cells[this.colDocTitle.Index].Value = record.DocTitle;
                row.Cells[this.colDeptName.Index].Value = record.DeptStayed;
                row.Cells[this.colDoctorInCharge.Index].Value = record.DoctorInCharge;
                row.Cells[this.colPatientName.Index].Value = record.PatientName;
                row.Cells[this.colPatientID.Index].Value = record.PatientID;
                row.Cells[this.colVisitID.Index].Value = record.VisitID;
                row.Cells[this.colBeginTime.Index].Value = record.BeginDate.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colCreateName.Index].Value = record.CreateName;
                row.Cells[this.colPoint.Index].Value = record.Point;
                row.Cells[this.colCheckDate.Index].Value = record.CheckDate.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colQcExplain.Index].Value = record.QcExplain;
                row.Cells[this.colStatus.Index].Value = EMRDBLib.SystemData.WrittenState.GetCnWrittenState(record.QcResult);
               

                //记录时间和作者
                if (record.QcResult == EMRDBLib.SystemData.WrittenState.Normal
                    || record.QcResult == EMRDBLib.SystemData.WrittenState.Timeout
                    || record.QcResult == EMRDBLib.SystemData.WrittenState.Early)
                {
                    row.Cells[this.colRecordTime.Index].Value = record.RecordTime.ToString("yyyy-MM-dd HH:mm");
                    row.Cells[this.colDocTime.Index].Value = record.DocTime.ToString("yyyy-MM-dd HH:mm");
                    row.Cells[this.colCreateName.Index].Value = record.CreateName;
                }

                row.Cells[this.colEndTime.Index].Value = record.EndDate.ToString("yyyy-MM-dd HH:mm");
                if (record.CheckDate.CompareTo(record.EndDate) < 0)
                {
                    row.Cells[this.colLeave.Index].Value = Math.Round((record.EndDate - record.CheckDate).TotalHours, 0, MidpointRounding.ToEven);
                }
                else
                {
                    if (record.QcResult != EMRDBLib.SystemData.WrittenState.Normal
                        && record.QcResult != EMRDBLib.SystemData.WrittenState.UnwriteNormal
                        && record.QcResult != EMRDBLib.SystemData.WrittenState.Early)
                        row.Cells[this.colLeave.Index].Value = "已超时";
                }
                if (record.QcResult == EMRDBLib.SystemData.WrittenState.Timeout)
                {
                    row.Cells[this.colTimeout.Index].Value = Math.Round((record.DocTime - record.EndDate).TotalHours, 0, MidpointRounding.ToEven);
                }
            }
            WorkProcess.Instance.Close();
            string szMessage = string.Format("共找到{0}条记录", lstQcTimeRecord.Count.ToString());
            this.ShowStatusMessage(szMessage);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "时效质控记录查询");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private ReportExplorerForm GetReportExplorerForm()
        {
            ReportExplorerForm reportExplorerForm = new ReportExplorerForm();
            reportExplorerForm.WindowState = FormWindowState.Maximized;
            reportExplorerForm.QueryContext +=
                new QueryContextEventHandler(this.ReportExplorerForm_QueryContext);
            reportExplorerForm.NotifyNextReport +=
                new NotifyNextReportEventHandler(this.ReportExplorerForm_NotifyNextReport);
            return reportExplorerForm;
        }
        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetGlobalDataHandler(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void ReportExplorerForm_NotifyNextReport(object sender, Heren.Common.Report.NotifyNextReportEventArgs e)
        {
            e.ReportData = this.GetReportFileData(e.ReportName);
        }
        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "时效质控记录查询");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("时效质控记录查询报表还没有制作!");
                return null;
            }
            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("时效质控记录查询报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }
        private bool GetGlobalDataHandler(string name, ref object value)
        {
            return false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > this.dataGridView1.Rows.Count - 1)
                return;
            if (e.ColumnIndex > this.dataGridView1.Columns.Count - 1)
                return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            EMRDBLib.QcTimeRecord checkResultInfo = row.Tag as EMRDBLib.QcTimeRecord;
            if (checkResultInfo == null || string.IsNullOrEmpty(checkResultInfo.DocID))
                return;
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在准备打开病历，请稍候...");

            MedDocInfo docInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(checkResultInfo.DocID, ref docInfo);
            if (shRet == EMRDBLib.SystemData.ReturnValue.OK)
                this.MainForm.OpenDocument(docInfo);
            else
                MessageBoxEx.Show("病历详细信息下载失败,无法打开病历！");
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

    }
}