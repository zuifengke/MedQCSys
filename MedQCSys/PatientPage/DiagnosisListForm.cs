// ***********************************************************
// 诊断记录显示窗口.
// Creator:LiChunYing  Date:2012-01-04
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Controls;
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;

namespace MedQCSys.DockForms
{
    public partial class DiagnosisListForm : DockContentBase
    {
        public DiagnosisListForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }

        public DiagnosisListForm(MainForm mainForm,PatPage.PatientPageControl patientPageControl)
            : base(mainForm,patientPageControl)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!SystemParam.Instance.LocalConfigOption.PrintAndExcel)
            {
                this.btnExport.Visible = false;
                this.btnPrint.Visible = false;
            }
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载诊断记录，请稍候...");
            this.LoadDiagnosisResult();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            if (this.IsHidden)
                return;
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
                this.OnRefreshView();
        }

        /// <summary>
        /// 当切换活动文档时刷新数据
        /// </summary>
        protected override void OnActiveContentChanged()
        {
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this && this.NeedRefreshView)
                this.OnRefreshView();
            
        }

        private void LoadDiagnosisResult()
        {
            this.dataGridView1.SuspendLayout();
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.ResumeLayout();
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;

            List<EMRDBLib.Diagnosis> lstDiagnosisInfo = null;
            short shRet = PatVisitAccess.Instance.GetDiagnosisInfo(szPatientID, szVisitID, ref lstDiagnosisInfo);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            if (lstDiagnosisInfo == null || lstDiagnosisInfo.Count <= 0)
                return;

            int nRowIndex = 0;
            DataGridViewRow row = null;
            for (int index = 0; index < lstDiagnosisInfo.Count; index++)
            {
                EMRDBLib.Diagnosis diagnosisInfo = lstDiagnosisInfo[index];
                nRowIndex = this.dataGridView1.Rows.Add();
                row = this.dataGridView1.Rows[nRowIndex];
                row.Cells[this.colDiagnosisDate.Index].Value =
                    diagnosisInfo.DIAGNOSIS_DATE.ToString("yyyy-M-d HH:mm");
                row.Cells[this.colDiagnosisType.Index].Value = diagnosisInfo.DIAGNOSIS_TYPE_NAME;
                row.Cells[this.colNum.Index].Value = diagnosisInfo.DIAGNOSIS_NO;
                row.Cells[this.colDiagnosisDesc.Index].Value = diagnosisInfo.DIAGNOSIS_DESC;
                row.Tag = diagnosisInfo;
            }
            this.dataGridView1.Tag = SystemParam.Instance.PatVisitInfo;
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
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "诊断信息清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("诊断信息清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("诊断信息清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "患者姓名")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                return true;
            }
            if (name == "患者ID")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            if (name == "所在科室")
            {
                value = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                return true;
            }
            return false;
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


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            Hashtable htNoExportColunms = new Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "诊断记录清单");
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
    }
}