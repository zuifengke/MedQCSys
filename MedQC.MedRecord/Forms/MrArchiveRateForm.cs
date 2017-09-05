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
    public partial class MrArchiveRateForm : DockContentBase
    {
        public MrArchiveRateForm(MainForm parent)
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
            this.dataTableView1.Columns[this.col_3DayArchiveCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_3DayArchiveRate.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_7DayArchiveCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataTableView1.Columns[this.col_7DayArchiveRate.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            int nGroupIndex = this.dataTableView1.Groups.Add();
            this.dataTableView1.Groups[nGroupIndex].BeginColumn = 2;
            this.dataTableView1.Groups[nGroupIndex].EndColumn = 3;
            this.dataTableView1.Groups[nGroupIndex].Text = "3天内";
            nGroupIndex = this.dataTableView1.Groups.Add();
            this.dataTableView1.Groups[nGroupIndex].BeginColumn = 4;
            this.dataTableView1.Groups[nGroupIndex].EndColumn = 5;
            this.dataTableView1.Groups[nGroupIndex].Text = "7天内";
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
            List<HolidayKeyValue> lstHolidayKeyValue = null;
            shRet = KeyValueDataAccess.Instance.GetHolidays(ref lstHolidayKeyValue);

            int rowIndex = 0;
            List<DeptInfo> lstDeptInfo = null;
            shRet = DeptAccess.Instance.GetClinicInpDeptList(ref lstDeptInfo);
           
            WorkProcess.Instance.Initialize(this, lstDeptInfo.Count, "正在计算归档率......");
            foreach (var item in lstDeptInfo)
            {
                string szDeptName = string.Empty;
                int totalCount = 0;
                int day3Count = 0;
                int day7Count = 0;
                if (WorkProcess.Instance.Canceled)
                    break;
                WorkProcess.Instance.Show(string.Format("正在计算{0}归档率...",item.DEPT_NAME),lstDeptInfo.IndexOf(item), true);
                var result = lstMrArchives.Where(m => m.DEPT_ADMISSION_TO == item.DEPT_CODE).ToList();
                szDeptName = item.DEPT_NAME;
                if (result.Count > 0)
                    totalCount = result.Count;
                int holidayCount = 0;//节假日天数
                foreach (var mrArchive in result)
                {
                    if (mrArchive.ARCHIVE_TIME == SystemParam.Instance.DefaultTime)
                        continue;
                    if (lstHolidayKeyValue != null)
                        holidayCount = lstHolidayKeyValue.Where(m => m.DATA_VALUE >= mrArchive.DISCHARGE_DATE_TIME && m.DATA_VALUE <= mrArchive.ARCHIVE_TIME).Count();
                    if (mrArchive.DISCHARGE_DATE_TIME.AddDays(3).AddDays(holidayCount) > mrArchive.ARCHIVE_TIME)
                        day3Count++;
                    if (mrArchive.DISCHARGE_DATE_TIME.AddDays(7).AddDays(holidayCount) > mrArchive.ARCHIVE_TIME)
                        day7Count++;
                    holidayCount = 0;
                }
                decimal rate3 =totalCount==0?0: Math.Round((decimal)day3Count / totalCount, 4) * 100;
                decimal rate7 = totalCount == 0 ? 0 : Math.Round((decimal)day7Count / totalCount, 4) * 100;
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_3DayArchiveCount.Index].Value = day3Count;
                row.Cells[this.col_3DayArchiveRate.Index].Value = rate3;
                row.Cells[this.col_7DayArchiveCount.Index].Value = day7Count;
                row.Cells[this.col_7DayArchiveRate.Index].Value = rate7;
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
            StatExpExcelHelper.Instance.ExportToExcel(this.dataTableView1, "病案归档率统计");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}
