// ***********************************************************
// 病案质控系统延期未提交病历查询窗口.
// Creator:LiChunYing  Date:2012-03-15
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;

using Heren.Common.Report;
using Heren.Common.VectorEditor;
using MedQCSys.Utility;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Search
{
    public partial class SearchDelayUnCommitDocForm : DockContentBase
    {
        public SearchDelayUnCommitDocForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }

        public override void OnRefreshView()
        {
            this.Update();
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
        }

        private void LoadDelyUnCommitDocInfos(List<EMRDBLib.PatVisitInfo> lstPatVisitLog)
        {
            for (int index = 0; index < lstPatVisitLog.Count; index++)
            {
                EMRDBLib.PatVisitInfo patVisitLog = lstPatVisitLog[index];
                if (patVisitLog == null)
                    continue;
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Cells[this.colPatientID.Index].Value = patVisitLog.PATIENT_ID;
                row.Cells[this.colVisitID.Index].Value = patVisitLog.VISIT_ID;
                row.Cells[this.colDeptName.Index].Value = patVisitLog.DEPT_NAME;
                row.Cells[this.colPatName.Index].Value = patVisitLog.PATIENT_NAME;
                row.Cells[this.colAdmissionDate.Index].Value = patVisitLog.VISIT_TIME.ToString("yyyy-MM-dd");
                if (patVisitLog.DISCHARGE_TIME != patVisitLog.DefaultTime)
                {
                    row.Cells[this.colDischargeDate.Index].Value = patVisitLog.DISCHARGE_TIME.ToString("yyyy-MM-dd");
                    row.Cells[this.colDelayDays.Index].Value = (DateTime.Now - patVisitLog.DISCHARGE_TIME).Days;
                }
                row.Tag = patVisitLog;
            }
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

        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "延期未提交病历查询清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("延期未提交病历查询清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("延期未提交病历查询清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "所在科室")
            {
                string szDeptName = null;
                if (!string.IsNullOrEmpty(this.cboDeptName.Text.Trim()))
                    szDeptName = this.cboDeptName.Text;
                else
                    szDeptName = "全院";
                value = szDeptName;
                return true;
            }
            if (name == "出院天数")
            {
                value = this.numericUpDown1.Value;
                return true;
            }
            return false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在统计延期未提交病历信息，请稍候...");
            this.dataGridView1.Rows.Clear();
            DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
            string szDeptCode = null;
            if (deptInfo != null)
                szDeptCode = deptInfo.DEPT_CODE;
            if (string.IsNullOrEmpty(this.cboDeptName.Text))
                szDeptCode = null;
            string szDelayDays = this.numericUpDown1.Value.ToString();
            List<EMRDBLib.PatVisitInfo> lstPatVisitLog = null;
            short shRet = SystemData.ReturnValue.OK;
            shRet = MedQCAccess.Instance.GetDelayUnCommitDocInfos(szDeptCode, szDelayDays, ref lstPatVisitLog);
            if (shRet != SystemData.ReturnValue.OK || lstPatVisitLog == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.ShowStatusMessage(null);
                return;
            }
            this.LoadDelyUnCommitDocInfos(lstPatVisitLog);
            this.dataGridView1.Tag = "延期未提交病历查询清单";
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "延期未提交病历查询清单");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可打印内容！");
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            byte[] byteReportData = this.GetReportFileData(null);
            if (byteReportData != null)
            {
                System.Data.DataTable table = GlobalMethods.Table.GetDataTable(this.dataGridView1, false, 0);
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.ReportFileData = byteReportData;
                explorerForm.ReportParamData.Add("是否续打", false);
                explorerForm.ReportParamData.Add("打印数据", table);
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void ReportExplorerForm_NotifyNextReport(object sender, Heren.Common.Report.NotifyNextReportEventArgs e)
        {
            e.ReportData = this.GetReportFileData(e.ReportName);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string szPId = this.dataGridView1.Rows[e.RowIndex].Cells[this.colPatientID.Index].Value != null ?
                this.dataGridView1.Rows[e.RowIndex].Cells[this.colPatientID.Index].Value.ToString() : "";
            string szVid = this.dataGridView1.Rows[e.RowIndex].Cells[this.colVisitID.Index].Value != null ?
              this.dataGridView1.Rows[e.RowIndex].Cells[this.colVisitID.Index].Value.ToString() : "";
            if (string.IsNullOrEmpty(szPId) || string.IsNullOrEmpty(szVid))
                return;

            if (SystemParam.Instance.LocalConfigOption.IsNewTheme)
            {
                PatVisitInfo patVisit = new PatVisitInfo() { PATIENT_ID = szPId, VISIT_ID = szVid };
                this.MainForm.SwitchPatient(patVisit);
                return;
            }
            this.MainForm.OpenDocument(string.Empty, szPId, szVid);
        }
    }
}