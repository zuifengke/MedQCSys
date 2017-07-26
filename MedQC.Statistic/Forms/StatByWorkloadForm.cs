// ***********************************************************
// 病案质控系统按质控者的工作量统计窗口.
// Creator:YangMingkun  Date:2009-11-13
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
using EMRDBLib;

using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using Heren.Common.DockSuite;
using EMRDBLib.DbAccess;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Statistic
{
    public partial class StatByWorkloadForm : DockContentBase
    {
        public StatByWorkloadForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dtpStatTimeEnd.Value = DateTime.Now;
            this.dtpStatTimeBegin.Value = DateTime.Now.AddDays(-1);
            this.ShowStatusMessage("正在下载用户列表，请稍候...");
            if (!InitControlData.InitcboUserList(ref this.cboUserList))
            {
                MessageBoxEx.Show("用户列表下载失败！");
            }
            this.ShowStatusMessage(null);
        }

        private List<UserInfo> ListUserInfo { get; set; }

        /// <summary>
        /// 将数据信息加载到DataGridView中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="qcWorkloadStatInfo"></param>
        private void SetRowData(DataGridViewRow row, EMRDBLib.QCWorkloadStatInfo qcWorkloadStatInfo)
        {
            if (row == null || qcWorkloadStatInfo == null)
                return;
            if (row.DataGridView == null)
                return;

            row.Cells[this.numOfCheckDataGridViewTextBoxColumn.Index].Value = qcWorkloadStatInfo.NumOfCheck;
            row.Cells[this.numOfDocDataGridViewTextBoxColumn.Index].Value = qcWorkloadStatInfo.NumOfDoc;
            row.Cells[this.numOfQuestionDataGridViewTextBoxColumn.Index].Value = qcWorkloadStatInfo.NumOfQuestion;

            UserInfo userInfo = null;
            UserAccess.Instance.GetUserInfo(qcWorkloadStatInfo.CheckerID, ref userInfo);
            row.Cells[this.colCheckID.Index].Value = userInfo != null ? userInfo.USER_ID : "";
            row.Cells[this.checkerDataGridViewTextBoxColumn.Index].Value = userInfo != null ? userInfo.USER_NAME : "";
            row.Cells[this.colDeptName.Index].Value = userInfo != null ? userInfo.DEPT_NAME : "";
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
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "工作量统计清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("工作量统计清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("工作量统计清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "起始日期")
            {
                value = this.dtpStatTimeBegin.Value;
                return true;
            }
            if (name == "截止日期")
            {
                value = this.dtpStatTimeEnd.Value;
                return true;
            }
            return false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string szCheckerID = string.Empty;
            if (this.cboUserList.Text != string.Empty
                && this.cboUserList.SelectedItem!=null)
            {
                UserInfo user = this.cboUserList.SelectedItem as UserInfo;
                szCheckerID = user.USER_ID;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在统计工作量，请稍候...");
            this.dataGridView1.Rows.Clear();
            //质检问题没有保存质检者ID导致工作量统计时，重名的工作量统计错误
            //现在加入质检者ID,但是直接改为根据ID统计时老数据统计错误
            //根据配置配置先通过姓名统计，当老数据不再需要统计时，按照ID统计更为准确
            List<EMRDBLib.QCWorkloadStatInfo> lstQCWorkloadStatInfos = null;
            short shRet = MedQCAccess.Instance.GetQCStatisticsByWorkload(szCheckerID, DateTime.Parse(dtpStatTimeBegin.Value.ToString("yyyy-M-d 00:00:00")),
                DateTime.Parse(dtpStatTimeEnd.Value.ToString("yyyy-M-d 23:59:59")), ref lstQCWorkloadStatInfos);
            if (shRet != SystemData.ReturnValue.OK
                &&
                shRet != SystemData.ReturnValue.RES_NO_FOUND
                ) 
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("查询数据失败！");
                return;
            }
            if (lstQCWorkloadStatInfos == null || lstQCWorkloadStatInfos.Count <= 0)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("没有符合条件的数据！", MessageBoxIcon.Information);
                return;
            }
            for (int index = 0; index < lstQCWorkloadStatInfos.Count; index++)
            {
                EMRDBLib.QCWorkloadStatInfo qcWorkloadStatInfo = lstQCWorkloadStatInfos[index];
                if (string.IsNullOrEmpty(qcWorkloadStatInfo.CheckerID))
                    continue;
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, qcWorkloadStatInfo);
            }

            this.ShowStatusMessage(null);
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
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "按工作量统计清单");
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