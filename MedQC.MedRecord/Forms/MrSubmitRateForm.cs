/********************************************************
 * @FileName   : PatOutHospitalListForm.cs
 * @Description: 病案管理系统之病案归档
 * @Author     : 叶慧(Yehui)
 * @Date       : 2017-04-17 11:06:51
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using MedQCSys.Utility;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls.TableView;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;
using System.Collections;
using MedQCSys.PatPage;

namespace Heren.MedQC.MedRecord
{
    public partial class MrSubmitRateForm : DockContentBase
    {
        public MrSubmitRateForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dtTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtTimeEnd.Value = DateTime.Now;
            this.dataTableView1.Columns[this.col_TotalCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataTableView1.Columns[this.col_2DaySubmitCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_2DaySubmitRate.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_4DaySubmitCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_4DaySubmitRate.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_7DaySubmitCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_7DaySubmitRate.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            int nGroupIndex = this.dataTableView1.Groups.Add();
            this.dataTableView1.Groups[nGroupIndex].BeginColumn = 2;
            this.dataTableView1.Groups[nGroupIndex].EndColumn = 3;
            this.dataTableView1.Groups[nGroupIndex].Text = "小于2天";
            nGroupIndex = this.dataTableView1.Groups.Add();
            this.dataTableView1.Groups[nGroupIndex].BeginColumn = 4;
            this.dataTableView1.Groups[nGroupIndex].EndColumn = 5;
            this.dataTableView1.Groups[nGroupIndex].Text = "小于4天";
            nGroupIndex = this.dataTableView1.Groups.Add();
            this.dataTableView1.Groups[nGroupIndex].BeginColumn = 6;
            this.dataTableView1.Groups[nGroupIndex].EndColumn = 7;
            this.dataTableView1.Groups[nGroupIndex].Text = "小于7天";
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载，请稍候...");
            this.dataTableView1.Rows.Clear();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.dataTableView1.Rows.Clear();
            DateTime dtVisitTimeBegin = SystemParam.Instance.DefaultTime;
            DateTime dtVisitTimeEnd = SystemParam.Instance.DefaultTime;
            DateTime dtDischargeTimeBegin = SystemParam.Instance.DefaultTime;
            DateTime dtDischargeTimeEnd = SystemParam.Instance.DefaultTime;
            if (this.cboTimeType.Text == "入院日期")
            {
                dtVisitTimeBegin = this.dtTimeBegin.Value;
                dtVisitTimeEnd = this.dtTimeEnd.Value.AddDays(1).AddSeconds(-1);
            }
            else
            {
                dtDischargeTimeBegin = this.dtTimeBegin.Value;
                dtDischargeTimeEnd = this.dtTimeEnd.Value;
            }
            List<MrArchive> lstMrArchives = null;
            short shRet = MrArchiveAccess.Instance.GetMrArchives(dtVisitTimeBegin, dtVisitTimeEnd, dtDischargeTimeBegin, dtDischargeTimeEnd, null, null, null, null, ref lstMrArchives);
            if (lstMrArchives == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            int rowIndex = 0;
            List<DeptInfo> lstDeptInfo = null;
            shRet = DeptAccess.Instance.GetClinicInpDeptList(ref lstDeptInfo);
            List<HolidayKeyValue> lstHolidayKeyValue = null;
            shRet = KeyValueDataAccess.Instance.GetHolidays(ref lstHolidayKeyValue);
            WorkProcess.Instance.Initialize(this, lstDeptInfo.Count, "正在计算提交率......");
            foreach (var item in lstDeptInfo)
            {
                string szDeptName = string.Empty;
                int totalCount = 0;
                int day2Count = 0;
                int day4Count = 0;
                int day7Count = 0;
                if (WorkProcess.Instance.Canceled)
                    break;
                WorkProcess.Instance.Show(string.Format("正在计算{0}提交率...", item.DEPT_NAME), lstDeptInfo.IndexOf(item), true);
                var result = lstMrArchives.Where(m => m.DEPT_ADMISSION_TO == item.DEPT_CODE).ToList();
                szDeptName = item.DEPT_NAME;
                if (result.Count > 0)
                    totalCount = result.Count;
                int nHolidayCount = 0;
                foreach (var mrArchive in result)
                {
                    if (mrArchive.SUBMIT_TIME == SystemParam.Instance.DefaultTime)
                        continue;
                    if (lstHolidayKeyValue != null)
                    {
                        nHolidayCount = lstHolidayKeyValue.Where(m => m.DATA_VALUE > mrArchive.DISCHARGE_DATE_TIME && m.DATA_VALUE < mrArchive.SUBMIT_TIME).Count();
                    }
                    if (mrArchive.DISCHARGE_DATE_TIME.AddDays(2+nHolidayCount) > mrArchive.SUBMIT_TIME)
                        day2Count++;
                    if (mrArchive.DISCHARGE_DATE_TIME.AddDays(4+nHolidayCount) > mrArchive.SUBMIT_TIME)
                        day4Count++;
                    if (mrArchive.DISCHARGE_DATE_TIME.AddDays(7+nHolidayCount) > mrArchive.SUBMIT_TIME)
                        day7Count++;
                }
                decimal rate2 = totalCount == 0 ? 0 : Math.Round((decimal)day2Count / totalCount, 2) * 100;
                decimal rate4 = totalCount == 0 ? 0 : Math.Round((decimal)day4Count / totalCount, 2) * 100;
                decimal rate7 = totalCount == 0 ? 0 : Math.Round((decimal)day7Count / totalCount, 2) * 100;
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_2DaySubmitCount.Index].Value = day2Count;
                row.Cells[this.col_2DaySubmitRate.Index].Value = rate2;
                row.Cells[this.col_4DaySubmitCount.Index].Value = day4Count;
                row.Cells[this.col_4DaySubmitRate.Index].Value = rate4;
                row.Cells[this.col_7DaySubmitCount.Index].Value = day7Count;
                row.Cells[this.col_7DaySubmitRate.Index].Value = rate7;
                row.Cells[this.col_DEPT_ADMISSION_NAME.Index].Value = szDeptName;
                row.Cells[this.col_TotalCount.Index].Value = totalCount;
            }
            WorkProcess.Instance.Close();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataTableView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            QcModifyNotice item = this.dataTableView1.Rows[e.RowIndex].Tag as QcModifyNotice;
            if (item == null)
                return;

            List<MedicalQcMsg> lstMedicalQcMsg = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgs(item.MODIFY_NOTICE_ID, ref lstMedicalQcMsg);
            if (lstMedicalQcMsg == null || lstMedicalQcMsg.Count <= 0)
                return;
            int rowIndex = 0;
            if (string.IsNullOrEmpty(lstMedicalQcMsg[0].TOPIC_ID))
            {
                return;
            }
        }

        private void dataTableView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            MrArchive mrArchive = this.dataTableView1.Rows[e.RowIndex].Tag as MrArchive;
            if (mrArchive == null)
                return;
            this.MainForm.SwitchPatient(mrArchive.PATIENT_ID, mrArchive.VISIT_ID);
        }

        private void dataTableView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = this.dataTableView1.Rows[e.RowIndex];
            MrArchive mrAchive = this.dataTableView1.Rows[e.RowIndex].Tag as MrArchive;

        }

        private void btnArchive_Click(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.dataTableView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataTableView1, "病案提交率统计");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}
