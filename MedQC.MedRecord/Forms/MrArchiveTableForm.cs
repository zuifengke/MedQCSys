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
    public partial class MrArchiveTableForm : DockContentBase
    {
        public MrArchiveTableForm(MainForm parent)
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
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.ShowError("加载科室列表失败");
            }
            this.dtTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtTimeEnd.Value = DateTime.Now;
            this.dataTableView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            string szDeptCode = string.Empty;
            string szUserID = string.Empty;
            string szMsgStatus = string.Empty;
            string szDichargeMode = string.Empty;
            if (this.cboDeptName.Text.Trim() != string.Empty && this.cboDeptName.SelectedItem != null)
            {
                szDeptCode = (this.cboDeptName.SelectedItem as DeptInfo).DEPT_CODE;
            }
            if (this.cboMrStatus.Text.Trim() != string.Empty && this.cboMrStatus.SelectedItem != null)
            {

                szMsgStatus = SystemData.MrStatus.GetMrStatusCode2(this.cboMrStatus.Text);
            }
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
            short shRet = MrArchiveAccess.Instance.GetMrArchives(dtVisitTimeBegin, dtVisitTimeEnd, dtDischargeTimeBegin, dtDischargeTimeEnd, szMsgStatus, szDeptCode,  ref lstMrArchives);
            if (lstMrArchives == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            int rowIndex = 0;
            foreach (var item in lstMrArchives)
            {
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_MR_STATUS.Index].Value = SystemData.MrStatus.GetMedMrStatusDesc(item.MR_STATUS);
                row.Cells[this.col_1_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                row.Cells[this.col_VISIT_ID.Index].Value = item.VISIT_ID;
                row.Cells[this.col_DEPT_ADMISSION_NAME.Index].Value = item.DEPT_ADMISSION_NAME;
                row.Cells[this.col_ADMISSION_DATE_TIME.Index].Value = item.ADMISSION_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
                if (item.DISCHARGE_DATE_TIME != SystemParam.Instance.DefaultTime)
                    row.Cells[this.col_DISCHARGE_DATE_TIME.Index].Value = item.DISCHARGE_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
                if (item.SUBMIT_TIME != item.DefaultTime)
                {
                    row.Cells[this.col_SUBMIT_TIME.Index].Value = item.SUBMIT_TIME.ToString("yyyy-MM-dd HH:mm");
                }
                if (item.ARCHIVE_TIME != item.DefaultTime)
                {
                    row.Cells[this.col_ARCHIVE_TIME.Index].Value = item.ARCHIVE_TIME.ToString("yyyy-MM-dd HH:mm");
                }
               
                row.Tag = item;
            }
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

    }
}
