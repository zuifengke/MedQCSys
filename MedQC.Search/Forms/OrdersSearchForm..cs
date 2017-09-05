// ***********************************************************
// 病案质控系统病危病重病人统计窗口.
// Creator:LiChunYing  Date:2012-04-20
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
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using Heren.Common.DockSuite;
using MedQCSys.DockForms;
using EMRDBLib;
using Heren.MedQC.Utilities;
using EMRDBLib.DbAccess;

namespace Heren.MedQC.Search.Forms
{
    public partial class OrdersSearchForm : DockContentBase
    {
        public OrdersSearchForm()
        {
          
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.OnRefreshView();
        }

        public override void OnRefreshView()
        {
            this.Update();
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");

            List<DeptInfo> lstDeptInfos = null;
            InitControlData.InitCboDeptName(ref cboDeptName);
            this.ShowStatusMessage(null);
        }

        private void ShowStatusMessage(string szMessage)
        {
            object result = null;
            //CommandHandler.Instance.SendCommand("SHOW_WIN_STATUS_MSG", "PATTIENT_SEARCH_FORM", szMessage, out result);
        }

        /// <summary>
        /// 将数据信息加载到DataGridView中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="qcWorkloadStatInfo"></param>
        private void SetRowData(DataGridViewRow row,  PatVisitInfo patVisitLog)
        {
            if (row == null || patVisitLog == null)
                return;
            if (row.DataGridView == null)
                return;

            row.Cells[this.colDeptName.Index].Value = patVisitLog.DEPT_NAME;
            row.Cells[this.colSex.Index].Value = patVisitLog.PATIENT_SEX;
            row.Cells[this.colPatientName.Index].Value = patVisitLog.PATIENT_NAME;
            row.Cells[this.colInpNO.Index].Value = patVisitLog.INP_NO;
            row.Cells[this.colBedNO.Index].Value = patVisitLog.BED_CODE;
            row.Cells[this.colVisitTime.Index].Value = patVisitLog.VISIT_TIME.ToString("yyyy-MM-dd HH:mm");
            row.Cells[this.colPatientID.Index].Value = patVisitLog.PATIENT_ID;
            row.Cells[this.colVisitID.Index].Value = patVisitLog.VISIT_ID;
            row.Tag = patVisitLog;
        }

        
        private void btnQuery_Click(object sender, EventArgs e)
        {
            DeptInfo deptInfo = this.cboDeptName.SelectedItem as  DeptInfo;
            string szDeptCode = null;
            if (deptInfo != null)
                szDeptCode = deptInfo.DEPT_CODE;
            if (string.IsNullOrEmpty(this.cboDeptName.Text))
                szDeptCode = null;
            string szOrderText = this.txtOrderText.Text.Trim();
            if (string.IsNullOrEmpty(szDeptCode))
            {
                MessageBoxEx.Show("医嘱数据量过大，请先选择科室！");
                return;
            }
            if(string.IsNullOrEmpty(szOrderText))
            {
                MessageBoxEx.Show("检索必须输入医嘱内容！");
                return;
            }
            
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在查询数据，请稍候...");
            this.dataGridView1.Rows.Clear();
            List<PatVisitInfo> lstPatVisitLog = null;
            short shRet =OrdersAccess.Instance.GetPatientListByOrderText(szOrderText,szDeptCode,  ref lstPatVisitLog);
            if (shRet != SystemData.ReturnValue.OK)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("查询数据失败！");
                this.ShowStatusMessage(null);
                return;
            }
            if (lstPatVisitLog == null || lstPatVisitLog.Count <= 0)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("没有符合条件的数据！", MessageBoxIcon.Information);
                this.ShowStatusMessage(null);
                return;
            }
            for (int index = 0; index < lstPatVisitLog.Count; index++)
            {
                 PatVisitInfo patVisitLog = lstPatVisitLog[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, patVisitLog);
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1)
                return;
            PatVisitInfo patVisitLog = this.dataGridView1.Rows[e.RowIndex].Tag as PatVisitInfo;
            if (patVisitLog == null)
            {
                MessageBoxEx.Show("获取病人信息失败");
                return;
            }
            //GlobalDataHandler.Instance.PatVisitLog = patVisitLog;
            //object result = null;
            //CommandHandler.Instance.SendCommand("SHOW_ORDERS_FORM", null, null, out result);
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
            DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "全院医嘱检索");
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
        private bool GetGlobalDataHandler(string name, ref object value)
        {
            if (name == "查询科室")
            {
                string szDeptName = null;
                if (!string.IsNullOrEmpty(this.cboDeptName.Text.Trim()))
                    szDeptName = this.cboDeptName.Text;
                else
                    szDeptName = "全院";
                value = szDeptName;
                return true;
            }
            if (name == "医嘱内容")
            {
                value = this.txtOrderText.Text.Trim() ;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "全院医嘱检索");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("全院医嘱检索报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("全院医嘱检索报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

       
    }
}