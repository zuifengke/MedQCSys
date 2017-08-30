using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Heren.MedQC.Core;
using EMRDBLib;
using Heren.Common.Libraries;
using Heren.Common.Report;
using System.Windows.Forms;

namespace Heren.MedQC.Utilities
{
    public class ReportPrintHelper
    {
        private static ReportPrintHelper m_Instance = null;
        public static ReportPrintHelper Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ReportPrintHelper();
                return m_Instance;
            }
        }
        public string DeptName { get; set; }
        public DateTime StatTimeBegin { get; set; }
        public DateTime StatTimeEnd { get; set; }
        public ReportType ReportType { get; set; }
        public bool ShowPrintView(DataTable table, string reportName)
        {
            this.ReportType = ReportCache.Instance.GetWardReportType(SystemData.ReportTypeApplyEnv.STATISTIC, reportName);
            if (this.ReportType == null)
            {
                MessageBoxEx.ShowMessage("打印报表还没有制作");
                return false;
            }
            byte[] byteReportData = null;
            ReportCache.Instance.GetReportTemplet(this.ReportType, ref byteReportData);
            if (byteReportData != null)
            {

                ReportExplorerForm reportExplorerForm = new ReportExplorerForm();
                reportExplorerForm.WindowState = FormWindowState.Maximized;
                reportExplorerForm.QueryContext +=
                    new QueryContextEventHandler(this.ReportExplorerForm_QueryContext);
                reportExplorerForm.NotifyNextReport +=
                    new NotifyNextReportEventHandler(this.ReportExplorerForm_NotifyNextReport);
                reportExplorerForm.ReportFileData = byteReportData;
                reportExplorerForm.ReportParamData.Add("是否续打", false);
                reportExplorerForm.ReportParamData.Add("打印数据", table);
                reportExplorerForm.ShowDialog();
            }

            return true;
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
        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            byte[] byteReportData = null;
            ReportCache.Instance.GetReportTemplet(this.ReportType, ref byteReportData);
            return byteReportData;
        }
        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "所在科室")
            {
                string szDeptName = null;
                if (!string.IsNullOrEmpty(this.DeptName))
                    szDeptName = this.DeptName;
                else
                    szDeptName = "全院";
                value = szDeptName;
                return true;
            }
            if (name == "起始日期")
            {
                value = this.StatTimeBegin;
                return true;
            }
            if (name == "截止日期")
            {
                value = this.StatTimeEnd;
                return true;
            }
            return false;
        }

    }
}
