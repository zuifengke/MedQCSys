// ***********************************************************
// 病案质控系统文档时效自动检查结果窗口.
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

using MedDocSys.QCEngine.TimeCheck;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
namespace MedQCSys.DockForms
{
    public partial class DocumentTimeForm : DockContentBase
    {
        public DocumentTimeForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }

        public DocumentTimeForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent,patientPageControl)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }
        /// <summary>
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            this.dataGridView1.Rows.Clear();
            if (this.IsHidden)
                return;
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
                this.OnRefreshView();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            List<DeptInfo> lstDeptInfos = null;
            if (EMRDBAccess.Instance.GetWardDeptList(ref lstDeptInfos) != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("临床科室列表下载失败!");
                return;
            }
            if (lstDeptInfos == null || lstDeptInfos.Count <= 0)
            {
                return;
            }
            for (int index = 0; index < lstDeptInfos.Count; index++)
            {
                DeptInfo deptInfo = lstDeptInfos[index];
                this.cboDept.Items.Add(deptInfo.InputCode.ToLower(), deptInfo);
            }
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

        /// <summary>
        /// 加载QC时效检查记录
        /// </summary>
        private void LoadTimeCheckResult()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在检查病历时效，请稍候...");
            this.Update();

            TimeCheckQuery timeCheckQuery = new TimeCheckQuery();
            if (SystemParam.Instance.PatVisitInfo != null)
            {
                timeCheckQuery.PatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                timeCheckQuery.PatientName = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                //timeCheckQuery.VisitID = SystemParam.Instance.PatVisitLog.VISIT_ID;
                //编辑器VISIT_NO=VISIT_ID
                timeCheckQuery.VisitID = SystemParam.Instance.PatVisitInfo.VISIT_NO;
                timeCheckQuery.VisitNO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
                timeCheckQuery.DoctorLevel = "1";//默认只检查经治医生提交情况
            }
            if (this.cboDept.SelectedItem != null)
            {
                MDSDBLib.DeptInfo dept = this.cboDept.SelectedItem as MDSDBLib.DeptInfo;
                timeCheckQuery.DeptCode = dept.DeptCode;
            }
            try
            {
                TimeCheckEngine.Instance.PerformTimeCheck(timeCheckQuery);
            }
            catch (Exception ex)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                LogManager.Instance.WriteLog("DocumentTimeForm.OnRefreshView", ex);
                return;
            }

            List<TimeCheckResult> lstCheckResults = TimeCheckEngine.Instance.TimeCheckResults;
            lstCheckResults.Sort(new Comparison<TimeCheckResult>(this.Compare));
            if (lstCheckResults == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.ShowStatusMessage(null);
                return;
            }
            this.colPatientName.Visible = false;
            SetGridData(lstCheckResults);
        }

        private void SetGridData(List<TimeCheckResult> lstCheckResults)
        {
            DateTime now = DateTime.Now;
            for (int index = 0; index < lstCheckResults.Count; index++)
            {
                TimeCheckResult resultInfo = lstCheckResults[index];

                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = resultInfo;

                row.Cells[this.colPatientName.Index].Value = resultInfo.PatientName;
                row.Cells[this.colDocTitle.Index].Value = resultInfo.DocTitle;

                if (resultInfo.WrittenState == WrittenState.Timeout)
                {
                    row.Cells[this.colStatus.Index].Value = "书写超时";
                }
                else if (resultInfo.WrittenState == WrittenState.Unwrite)
                {
                    row.Cells[this.colStatus.Index].Value = "未书写";
                }
                else if (resultInfo.WrittenState == WrittenState.Early)
                {
                    row.Cells[this.colStatus.Index].Value = "书写提前";
                }
                else if (resultInfo.WrittenState == WrittenState.Normal)
                {
                    row.Cells[this.colStatus.Index].Value = "正常";
                }
                if (resultInfo.WrittenState != WrittenState.Unwrite)
                {
                    if (resultInfo.RecordTime != resultInfo.DefaultTime)
                        row.Cells[this.colRecordTime.Index].Value = resultInfo.RecordTime.ToString("yyyy-MM-dd HH:mm");//.ToString("yyyy-M-d HH:mm");
                    row.Cells[this.colCreator.Index].Value = resultInfo.CreatorName;
                }

                row.Cells[this.colEndTime.Index].Value = resultInfo.EndTime.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colBeginTime.Index].Value = resultInfo.StartTime.ToString("yyyy-MM-dd HH:mm");
                if (now.CompareTo(resultInfo.EndTime) < 0)
                {
                    row.Cells[this.colLeave.Index].Value = Math.Round((resultInfo.EndTime - now).TotalHours, 0, MidpointRounding.ToEven);
                }
                else
                {
                    if (resultInfo.WrittenState == WrittenState.Timeout || resultInfo.WrittenState == WrittenState.Unwrite)
                        row.Cells[this.colLeave.Index].Value = "已超时";
                    else
                        row.Cells[this.colLeave.Index].Value = "0";
                }
                if (resultInfo.WrittenState == WrittenState.Timeout)
                {
                    row.Cells[this.colTimeout.Index].Value = Math.Round((resultInfo.DocTime - resultInfo.EndTime).TotalHours, 0, MidpointRounding.ToEven);
                }
                if (!resultInfo.IsRepeat)
                {
                    row.Cells[this.colCheckBasis.Index].Value = string.Format("患者{0}{1},{2}内书写{3}"
                        , resultInfo.EventTime.ToString("yyyy-MM-dd HH:mm")
                        , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                }
                else
                {
                    row.Cells[this.colCheckBasis.Index].Value = string.Format("患者{0}{1},每{2}书写一次{3}"
                        , resultInfo.EventTime.ToString("yyyy-MM-dd HH:mm")
                        , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                }
                if (resultInfo.DocTime != resultInfo.DefaultTime)
                    row.Cells[this.colDocTime.Index].Value = resultInfo.DocTime.ToString("yyyy-MM-dd HH:mm");
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            this.ShowStatusMessage(null);
        }

        /// <summary>
        ///  截止时间比较器
        /// </summary>
        /// <param name="result1"></param>
        /// <param name="result2"></param>
        /// <returns></returns>
        public int Compare(TimeCheckResult result1, TimeCheckResult result2)
        {
            if (result1 == null)
            {
                if (result2 == null)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (result2 == null)
            {
                return 1;
            }
            else
            {
                if (result1.EndTime.CompareTo(DateTime.Now) > 0)
                {
                    if (result2.EndTime.CompareTo(DateTime.Now) > 0)
                    {
                        return result1.EndTime.CompareTo(result2.EndTime);
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (result2.EndTime.CompareTo(DateTime.Now) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.dataGridView1.Rows.Clear();
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            this.LoadTimeCheckResult();
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
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "病历时效检查清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("病历时效检查清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("病历时效检查清单报表内容下载失败!");
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > this.dataGridView1.Rows.Count - 1)
                return;
            if (e.ColumnIndex > this.dataGridView1.Columns.Count - 1)
                return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            TimeCheckResult checkResultInfo = row.Tag as TimeCheckResult;
            if (checkResultInfo == null || GlobalMethods.Misc.IsEmptyString(checkResultInfo.DocID))
                return;
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在准备打开病历，请稍候...");

            MedDocInfo docInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(checkResultInfo.DocID, ref docInfo);
            if (shRet == SystemData.ReturnValue.OK)
                this.MainForm.OpenDocument(docInfo);
            else
                MessageBoxEx.Show("病历详细信息下载失败,无法打开病历！");

            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column != this.colRecordTime && e.Column != this.colEndTime)
            {
                return;
            }
            if (e.CellValue1 == null || e.CellValue2 == null)
                return;
            e.Handled = true;
            DateTime dtDateValue1 = DateTime.Now;
            DateTime dtDateValue2 = DateTime.Now;
            DateTime.TryParse(e.CellValue1.ToString(), out dtDateValue1);
            DateTime.TryParse(e.CellValue2.ToString(), out dtDateValue2);
            e.SortResult = DateTime.Compare(dtDateValue1, dtDateValue2);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (e.RowIndex < 0 || e.RowIndex >= this.dataGridView1.RowCount)
                return;
            if (e.ColumnIndex < 0 || e.ColumnIndex >= this.dataGridView1.ColumnCount)
                return;
            this.dataGridView1.Rows[e.RowIndex].Selected = true;
            Point ptMousePos = this.dataGridView1.PointToClient(Control.MousePosition);
            this.cmenuDocTime.Show(this.dataGridView1, ptMousePos);
        }

        private void mnuCopyCheckBasis_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            try
            {
                if (row.Cells[this.colCheckBasis.Index].Value == null)
                    Clipboard.Clear();
                else
                    Clipboard.SetDataObject(row.Cells[this.colCheckBasis.Index].Value.ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DocumentTimeForm.mnuCopyCheckBasis_Click", ex);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            Hashtable htNoExportColunms = new Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "病历时效统计清单");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.colPatientName.Visible = true;
            this.dataGridView1.Rows.Clear();
            string dept = string.Empty;
            if (this.cboDept.SelectedItem != null)
            {
                MDSDBLib.DeptInfo deptInfo = this.cboDept.SelectedItem as MDSDBLib.DeptInfo;
                dept = deptInfo.DeptCode;
            }
            if (string.IsNullOrEmpty(dept))
            {
                return;
            }

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在检查病历时效，请稍候...");
            this.Update();

            DateTime dtBegin = SystemConfig.Instance.Get(SystemData.ConfigKey.DEPT_DEFAULT_ADMISSION_BEGIN, DateTime.MinValue);
            DateTime dtEnd = SystemConfig.Instance.Get(SystemData.ConfigKey.DEPT_DEFAULT_ADMISSION_END, DateTime.MaxValue);

            List<EMRDBLib.PatVisitInfo> lstPatVisitLogs = new List<EMRDBLib.PatVisitInfo>();
            PatVisitAccess.Instance.GetPatVisitList(dept, EMRDBLib.PatientType.PatInHosptial, dtBegin, dtEnd, ref lstPatVisitLogs);

            List<TimeCheckResult> lstCheckResults = new List<TimeCheckResult>();
            TimeCheckQuery timeCheckQuery = new TimeCheckQuery();
            foreach (EMRDBLib.PatVisitInfo log in lstPatVisitLogs)
            {
                timeCheckQuery.PatientID = log.PATIENT_ID;
                timeCheckQuery.PatientName = log.PATIENT_NAME;
               // timeCheckQuery.VisitID = log.VISIT_ID;
                //timeCheckQuery.VisitID = SystemParam.Instance.PatVisitLog.VISIT_ID;
                //编辑器VISIT_NO=VISIT_ID
                timeCheckQuery.VisitID = log.VISIT_NO;
                TimeCheckEngine.Instance.PerformTimeCheck(timeCheckQuery);
                lstCheckResults.AddRange(TimeCheckEngine.Instance.TimeCheckResults);
            }
            lstCheckResults.Sort(new Comparison<TimeCheckResult>(this.Compare));


            if (lstCheckResults == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.ShowStatusMessage(null);
                return;
            }
            SetGridData(lstCheckResults);
        }
    }
}