// ***********************************************************
// 检验记录显示窗口.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using EMRDBLib;
using Heren.MedQC.Utilities;
using EMRDBLib.DbAccess;

namespace MedQCSys.DockForms
{
    public partial class TestResultListForm : DockContentBase
    {
        private List<DataTable> m_lstTestInfo = null;
        public TestResultListForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
            this.ResultList.Font = new Font("宋体", 10.5f);
            this.LabTestInfoList.Font = new Font("宋体", 10.5f);
        }

        public TestResultListForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent,patientPageControl)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
            this.ResultList.Font = new Font("宋体", 10.5f);
            this.LabTestInfoList.Font = new Font("宋体", 10.5f);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!SystemParam.Instance.LocalConfigOption.PrintAndExcel)
            {
                this.btnExportExcel.Visible = false;
                this.btnPrint.Visible = false;
                this.colNeedPrint.Visible = false;
                this.chkPrintAll.Visible = false;
            }
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载检验主记录，请稍候...");

            this.LoadLabTestList();
            this.UnselectedAllRows();

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

        /// <summary>
        /// 取消选中所有数据行
        /// </summary>
        private void UnselectedAllRows()
        {
            while (this.LabTestInfoList.SelectedRows.Count > 0)
            {
                this.LabTestInfoList.SelectedRows[0].Selected = false;
            }
        }
        
        private void LoadLabTestList()
        {
            this.LabTestInfoList.SuspendLayout();
            this.LabTestInfoList.Rows.Clear();
            this.LabTestInfoList.ResumeLayout();

            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            List<LabMaster> lstLabTestInfo = null;

            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
            {
                return;
            }
            short shRet = LabMasterAccess.Instance.GetInpLabTestList(szPatientID, szVisitID, ref lstLabTestInfo);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("检验主记录数据下载失败！");
                return;
            }
            if (lstLabTestInfo == null || lstLabTestInfo.Count <= 0)
                return;

            this.LabTestInfoList.SuspendLayout();
            for (int index = lstLabTestInfo.Count - 1; index >= 0; index--)
            {
                LabMaster labTestInfo = lstLabTestInfo[index];
                if (labTestInfo == null)
                    continue;
                int nRowIndex = this.LabTestInfoList.Rows.Add();
                DataGridViewRow row = this.LabTestInfoList.Rows[nRowIndex];
                row.Tag = labTestInfo;
                row.Cells[this.colSpecimen.Index].Value = labTestInfo.SPECIMEN;
                if (labTestInfo.REQUEST_TIME != labTestInfo.DefaultTime)
                    row.Cells[this.colRequestTime.Index].Value = labTestInfo.REQUEST_TIME.ToString("yyyy-MM-dd");
                row.Cells[this.colRequestDoctor.Index].Value = labTestInfo.REQUEST_DOCTOR;
                row.Cells[this.colResultStatus.Index].Value = labTestInfo.RESULT_STATUS;
                if (labTestInfo.REPORT_TIME != labTestInfo.DefaultTime)
                    row.Cells[this.colReportTime.Index].Value = labTestInfo.REPORT_TIME.ToString("yyyy-MM-dd");
                row.Cells[this.colReportDoctor.Index].Value = labTestInfo.REPORT_DOCTOR;
                row.Cells[this.colSubject.Index].Value = labTestInfo.SUBJECT;
                List<LabResult> lstResultInfo = null;
                shRet = LabResultAccess.Instance.GetLabResultList(labTestInfo.TEST_ID, ref lstResultInfo);
                if (shRet != SystemData.ReturnValue.OK
                    && lstResultInfo == null)
                {
                    MessageBoxEx.Show("检验记录数据下载失败！");
                    continue;
                }
                if (lstResultInfo == null || lstResultInfo.Count <= 0)
                    continue;

                for (int index1 = 0; index1 < lstResultInfo.Count; index1++)
                {
                    LabResult resultInfo = lstResultInfo[index1];
                    if (resultInfo == null)
                        continue;

                    if (resultInfo.ABNORMAL_INDICATOR.Trim().Contains("危机"))//危机值标红
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    if (resultInfo.ABNORMAL_INDICATOR.Trim().Contains("高")
                        || resultInfo.ABNORMAL_INDICATOR.Contains("低"))
                    {
                        row.Cells[this.colYiChang.Index].Value = "！";
                        row.Cells[this.colYiChang.Index].Style.ForeColor = Color.Red;
                    }
                }
            }
            this.LabTestInfoList.ResumeLayout();
        }

        /// <summary>
        /// 加载检验记录列表
        /// </summary>
        private void LoadResultList(string testNo)
        {
            this.ResultList.SuspendLayout();
            this.ResultList.Rows.Clear();
            this.ResultList.ResumeLayout();

            if (testNo == string.Empty)
                return;
            List<LabResult> lstResultInfo = null;
            short shRet =LabResultAccess.Instance.GetLabResultList(testNo, ref lstResultInfo);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("检验记录数据下载失败！");
                return;
            }
            if (lstResultInfo == null || lstResultInfo.Count <= 0)
                return;

            this.ResultList.SuspendLayout();
            for (int index = lstResultInfo.Count - 1; index >= 0; index--)
            {
                LabResult resultInfo = lstResultInfo[index];
                if (resultInfo == null)
                    continue;
                int nRowIndex = this.ResultList.Rows.Add();
                DataGridViewRow row = this.ResultList.Rows[nRowIndex];
                row.Cells[this.colItemName.Index].Value = resultInfo.ITEM_NAME;
                row.Cells[this.colResult.Index].Value = resultInfo.ITEM_RESULT;
                row.Cells[this.colUnit.Index].Value = resultInfo.ITEM_UNITS;
               
                if (!string.IsNullOrEmpty(resultInfo.ABNORMAL_INDICATOR))
                {
                    row.Cells[this.colAbnormal.Index].Style.ForeColor = Color.Red;
                }
                row.Cells[this.colReferContext.Index].Value = resultInfo.ITEM_REFER;
                if (resultInfo.ABNORMAL_INDICATOR.Contains("高"))
                {
                    row.Cells[this.colAbnormal.Index].Value = "↑";
                    row.Cells[this.colAbnormal.Index].Style.ForeColor = Color.Red;
                }
                if (resultInfo.ABNORMAL_INDICATOR.Contains("低")) {
                    row.Cells[this.colAbnormal.Index].Value = "↓";
                    row.Cells[this.colAbnormal.Index].Style.ForeColor = Color.Red;
                }
            }
            this.ResultList.CurrentCell = null;
            this.ResultList.ResumeLayout();
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

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "report1_deptName")
            {
                value = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                return true;
            }
            if (name == "report1_PatientID")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            if (name == "report1_AdmissionTime")
            {
                value = SystemParam.Instance.PatVisitInfo.VISIT_TIME.ToString("yyyy年MM月dd日");
                return true;
            }
            if (name == "report1_PatientName")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                return true;
            }
            if (name == "report1_patientSex")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_SEX;
                return true;
            }
            if (name == "report1_patientAge")
            {
                value = GlobalMethods.SysTime.GetAgeText(SystemParam.Instance.PatVisitInfo.BIRTH_TIME, SystemParam.Instance.PatVisitInfo.VISIT_TIME);
                return true;
            }
            if (name == "report1_Diagnosis")
            {
                value = SystemParam.Instance.PatVisitInfo.DIAGNOSIS;
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
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "检验报告单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("检验报告单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("检验报告单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private void LabTestInfoList_SelectionChanged(object sender, EventArgs e)
        {
            if (this.LabTestInfoList.SelectedRows.Count <= 0)
            {
                this.ResultList.SuspendLayout();
                this.ResultList.Rows.Clear();
                this.ResultList.ResumeLayout();
                return;
            }
            this.ShowStatusMessage("正在下载检验记录数据，请稍候...");
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            LabMaster labTestInfo = (LabMaster)this.LabTestInfoList.SelectedRows[0].Tag;
            if (labTestInfo != null)
                this.LoadResultList(labTestInfo.TEST_ID);

            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            if (this.m_lstTestInfo == null)
                this.m_lstTestInfo = new List<DataTable>();
            else
                this.m_lstTestInfo.Clear();

            if (this.LabTestInfoList.Rows.Count <= 0)
                return;

            for (int index = 0; index < this.LabTestInfoList.Rows.Count; index++)
            {
                DataGridViewRow row = this.LabTestInfoList.Rows[index];
                MDSDBLib.LabTestInfo labTestInfo = row.Tag as MDSDBLib.LabTestInfo;

                if (labTestInfo == null)
                    continue;
                DataGridViewCell cell = row.Cells[this.colNeedPrint.Index];
                if (cell == null)
                    continue;
                object objValue = cell.Value;
                if (objValue == null || !bool.Parse(objValue.ToString()))
                    continue;

                List<MDSDBLib.TestResultInfo> lstResultInfo = null;
                short shRet = MedDocSys.DataLayer.DataAccess.GetTestResultList(labTestInfo.TestID, ref lstResultInfo);
                if (shRet != SystemData.ReturnValue.OK)
                    continue;
                if (lstResultInfo == null || lstResultInfo.Count <= 0)
                    continue;

                DataTable dtResult = this.CreateResultData(lstResultInfo);
                dtResult = this.CreateTestData(labTestInfo, dtResult);
                this.m_lstTestInfo.Add(dtResult);
            }
            if (this.m_lstTestInfo.Count <= 0)
            {
                MessageBoxEx.Show("请勾选需要打印记录左边的复选框！");
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            byte[] byteReportData = this.GetReportFileData(null);
            if (byteReportData != null)
            {
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.ReportFileData = byteReportData;
                explorerForm.ReportParamData.Add("是否续打", false);
                explorerForm.ReportParamData.Add("打印数据", this.m_lstTestInfo);
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 把检验信息保存到DataTable中
        /// </summary>
        /// <param name="testInfo">testInfo</param>
        /// <param name="dtResult">目标容器</param>
        /// <returns>DaTaTable</returns>
        private DataTable CreateTestData(MDSDBLib.LabTestInfo testInfo, DataTable dtResult)
        {
            if (dtResult.Rows.Count <= 0)
                return dtResult;

            dtResult.Rows[0]["检验号"] = testInfo.TestID;
            dtResult.Rows[0]["报告医生"] = testInfo.ReportDoctor;
            dtResult.Rows[0]["申请医生"] = testInfo.RequestDoctor;
            dtResult.Rows[0]["报告时间"] = testInfo.ReportTime;
            dtResult.Rows[0]["申请时间"] = testInfo.RequestTime;
            dtResult.Rows[0]["标本名称"] = testInfo.Specimen;
            dtResult.Rows[0]["主题"] = testInfo.Subject;
            return dtResult;
        }

        /// <summary>
        /// 把检验明细结果保存到DaTaTable中
        /// </summary>
        /// <param name="lstTestResultInfo">检查明细结果</param>
        /// <returns>DaTaTable</returns>
        private DataTable CreateResultData(List<MDSDBLib.TestResultInfo> lstTestResultInfo)
        {
            DataTable dt = new DataTable();
            DataColumn column = new DataColumn("检验号");
            dt.Columns.Add(column);
            column = new DataColumn("报告医生");
            dt.Columns.Add(column);
            column = new DataColumn("申请医生");
            dt.Columns.Add(column);
            column = new DataColumn("报告时间");
            dt.Columns.Add(column);
            column = new DataColumn("申请时间");
            dt.Columns.Add(column);
            column = new DataColumn("标本名称");
            dt.Columns.Add(column);
            column = new DataColumn("主题");
            dt.Columns.Add(column);
            //表格列
            column = new DataColumn("项目");
            dt.Columns.Add(column);
            column = new DataColumn("结果");
            dt.Columns.Add(column);
            column = new DataColumn("参考值");
            dt.Columns.Add(column);
            for (int index = lstTestResultInfo.Count - 1; index >= 0; index--)
            {
                MDSDBLib.TestResultInfo resultInfo = lstTestResultInfo[index];
                if (resultInfo == null)
                    continue;

                DataRow row = dt.NewRow();
                row["项目"] = resultInfo.ItemName;
                row["结果"] = resultInfo.ItemResult;
                if (string.IsNullOrEmpty(resultInfo.AbnormalIndecator))
                    row["参考值"] = resultInfo.ItemRefer + resultInfo.ItemUnits;
                else
                    row["参考值"] = string.Format("{0} {1}{2}", resultInfo.AbnormalIndecator, resultInfo.ItemRefer, resultInfo.ItemUnits);
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void ckbPrintAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.LabTestInfoList.Rows.Count <= 0)
                return;

            bool bIsSelectAll = false;
            if (this.chkPrintAll.Checked)
                bIsSelectAll = true;
            for (int index = 0; index < this.LabTestInfoList.Rows.Count; index++)
            {
                DataGridViewRow row = this.LabTestInfoList.Rows[index];
                DataGridViewCell cell = row.Cells[this.colNeedPrint.Index];
                if (cell == null)
                    continue;
                if (CanPrint(index))
                    cell.Value = bIsSelectAll;
                else
                    cell.Value = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.LabTestInfoList.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            Hashtable htNoExportColunms = new Hashtable();
            htNoExportColunms.Add(3, "0");
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            string szPatientName = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            string szTitle = string.Format("{0}第{1}次就诊的{2}", szPatientName, szVisitID, "检验记录清单");
            StatExpExcelHelper.Instance.ExportTestResultToExcel(this.LabTestInfoList, this.ResultList, szTitle);
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

        private void LabTestInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (!CanPrint(e.RowIndex))
            {
                this.LabTestInfoList.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            }
        }

        private bool CanPrint(int rowIndex)
        {
            DataGridViewRow row = this.LabTestInfoList.Rows[rowIndex];
            MDSDBLib.LabTestInfo labTestInfo = row.Tag as MDSDBLib.LabTestInfo;

            if (labTestInfo == null)
                return false;
            DataGridViewCell cell = row.Cells[this.colNeedPrint.Index];
            if (cell == null)
                return false;
            List<MDSDBLib.TestResultInfo> lstResultInfo = null;
            short shRet = MedDocSys.DataLayer.DataAccess.GetTestResultList(labTestInfo.TestID, ref lstResultInfo);
            if (shRet != SystemData.ReturnValue.OK)
                return false;
            if (lstResultInfo == null || lstResultInfo.Count <= 0)
                return false;

            return true;
        }
    }
}