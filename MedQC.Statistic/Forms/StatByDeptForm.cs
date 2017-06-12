// ***********************************************************
// 病案质控系统按科室统计窗口.
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
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.Report;
using Heren.Common.VectorEditor;

using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Statistic
{
    public partial class StatByDeptForm : DockContentBase
    {
        public StatByDeptForm(MainForm parent)
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
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "按科室统计问题清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("按科室统计问题清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("按科室统计问题清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        /// <summary>
        /// 将数据信息加载到DataGridView中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="qcDeptStatInfo"></param>
        private void SetRowData(DataGridViewRow row, EMRDBLib.QCDeptStatInfo qcDeptStatInfo)
        {
            if (row == null || qcDeptStatInfo == null)
                return;
            if (row.DataGridView == null)
                return;
            if (IsNeedShowSamePatientColumn(row.Index, qcDeptStatInfo))
            {
                row.Cells[this.colInpNO.Index].Value = qcDeptStatInfo.InpNo;
                row.Cells[this.patientIDDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.PatientID;
                row.Cells[this.patientNameDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.PatientName;
                row.Cells[this.colVisitID.Index].Value = qcDeptStatInfo.VisitID;
            }
            row.Cells[this.msgDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.Message;
            row.Cells[this.docInChargeDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.DoctorInCharge;
            row.Cells[this.colQCEventType.Index].Value = qcDeptStatInfo.QaEventType;
            row.Cells[this.colParentDotor.Index].Value = qcDeptStatInfo.ParentDoctor;

            //显示权限改到质控权限控制
            //if (SystemConfig.Instance.Get(SystemData.ConfigKey.STAT_SHOW_CHECKER_NAME, false))
           
                row.Cells[this.checkerDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.CheckerName;
           
            if (qcDeptStatInfo.CheckTime != qcDeptStatInfo.DefaultTime)
                row.Cells[this.dateCheckedDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.CheckTime;
            if (qcDeptStatInfo.ConfirmTime != qcDeptStatInfo.DefaultTime)
                row.Cells[this.dateConfirmedDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.ConfirmTime;
            row.Tag = qcDeptStatInfo;
        }

        /// <summary>
        /// 是否需要显示同一患者的相同列
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool IsNeedShowSamePatientColumn(int rowIndex, EMRDBLib.QCDeptStatInfo currentQCDeptStatInfo)
        {
            if (SystemParam.Instance.LocalConfigOption.IsShowSameColumn)
            {
                return true;
            }
            else//判断是否是同一个患者，是则不需要显示
            {
                if (rowIndex == 0 || currentQCDeptStatInfo == null)
                    return true;
                EMRDBLib.QCDeptStatInfo preQCDeptStatInfo = this.dataGridView1.Rows[rowIndex - 1].Tag as EMRDBLib.QCDeptStatInfo;
                if (preQCDeptStatInfo == null)
                    return true;
                if (preQCDeptStatInfo.PatientID == currentQCDeptStatInfo.PatientID
                    && preQCDeptStatInfo.VisitID == currentQCDeptStatInfo.VisitID)
                    return false;
                else
                    return true;
            }
        }


        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "所在科室")
            {
                string szDeptName = "全科";
                 DeptInfo deptInfo = this.cboDeptName.SelectedItem as  DeptInfo;
                if (deptInfo != null)
                    szDeptName = deptInfo.DEPT_NAME;
                if (string.IsNullOrEmpty(this.cboDeptName.Text))
                    szDeptName = "全科";
                value = szDeptName;
                return true;
            }
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
             DeptInfo deptInfo = this.cboDeptName.SelectedItem as  DeptInfo;
            string szDeptCode = null;
            if (deptInfo != null && !string.IsNullOrEmpty(this.cboDeptName.Text))
                szDeptCode = deptInfo.DEPT_CODE;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在按科室统计质检问题，请稍候...");
            this.dataGridView1.Rows.Clear();

            List<EMRDBLib.QCDeptStatInfo> lstQCDeptStatInfos = null;
            short shRet = MedQCAccess.Instance.GetQCStatisticsByDept(szDeptCode, DateTime.Parse(dtpStatTimeBegin.Value.ToString("yyyy-M-d 00:00:00")),
                DateTime.Parse(dtpStatTimeEnd.Value.ToString("yyyy-M-d 23:59:59")), ref lstQCDeptStatInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("查询数据失败！");
                return;
            }
            if (lstQCDeptStatInfos == null || lstQCDeptStatInfos.Count <= 0)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("没有符合条件的数据！", MessageBoxIcon.Information);
                return;
            }
            int deptQCount = 0;
            Hashtable htDept = new Hashtable();
            //计算科室病历份数
            Hashtable htPidVid = new Hashtable();
            for (int index = 0; index < lstQCDeptStatInfos.Count; index++)
            {
                EMRDBLib.QCDeptStatInfo qcDeptStatInfo = lstQCDeptStatInfos[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                if (!htDept.ContainsKey(lstQCDeptStatInfos[index].Dept_Code))
                {
                    htDept.Add(lstQCDeptStatInfos[index].Dept_Code, lstQCDeptStatInfos[index].Dept_Name);
                    row.Cells[this.Dept_NameDataGridViewTextBoxColumn.Index].Value = qcDeptStatInfo.Dept_Name;
                }
                if (!htPidVid.ContainsKey(lstQCDeptStatInfos[index].PatientID + lstQCDeptStatInfos[index].VisitID))
                {
                    htPidVid.Add(lstQCDeptStatInfos[index].PatientID + lstQCDeptStatInfos[index].VisitID,
                        lstQCDeptStatInfos[index].PatientID + lstQCDeptStatInfos[index].VisitID);
                }
                this.SetRowData(row, qcDeptStatInfo);
                deptQCount++;
                if ((index + 1) == lstQCDeptStatInfos.Count
                    || (lstQCDeptStatInfos[index].Dept_Code != lstQCDeptStatInfos[index + 1].Dept_Code))
                {
                    nRowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow sumrow = this.dataGridView1.Rows[nRowIndex];
                    sumrow.Cells[0].Value = "合计";
                    sumrow.Cells[1].Value = "检查例数：";
                    sumrow.Cells[2].Value = deptQCount.ToString();
                    sumrow.Cells[3].Value = "病历份数：";
                    sumrow.Cells[4].Value = htPidVid.Count;
                    sumrow.DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                    deptQCount = 0;
                    htPidVid.Clear();
                }
            }
            this.dataGridView1.Tag = this.cboDeptName.Text;

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
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "按科室统计问题清单");
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
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            EMRDBLib.QCDeptStatInfo info = row.Tag as EMRDBLib.QCDeptStatInfo;
            if (info == null)
                return;
            this.MainForm.OpenDocument(info.DocSetID, info.PatientID, info.VisitID);
        }
    }
}