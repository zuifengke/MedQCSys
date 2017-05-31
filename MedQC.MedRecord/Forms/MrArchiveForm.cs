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
    public partial class MrArchiveForm : DockContentBase
    {
        public MrArchiveForm(MainForm parent)
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
            this.chkAll.Checked = false;
            string szDeptCode = string.Empty;
            string szUserID = string.Empty;
            string szPatientID = this.txtPatientID.Text.Trim();
            string szPatientName = this.txtPatientName.Text.Trim();
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
            short shRet = MrArchiveAccess.Instance.GetMrArchives(dtVisitTimeBegin, dtVisitTimeEnd, dtDischargeTimeBegin, dtDischargeTimeEnd, szMsgStatus, szDeptCode, szPatientID, szPatientName, ref lstMrArchives);
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
                row.Cells[this.col_PATIENT_SEX.Index].Value = item.PATIENT_SEX;
                row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
                if (item.DISCHARGE_DATE_TIME != SystemParam.Instance.DefaultTime)
                    row.Cells[this.col_DISCHARGE_DATE_TIME.Index].Value = item.DISCHARGE_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_HOS_QCMAN.Index].Value = item.HOS_QCMAN;
                row.Cells[this.col_PAPER_RECEIVE.Index].Value = item.PAPER_RECEIVE;
                if (item.RETURN_COUNT != 0)
                {
                    string szFlag = string.Empty;
                    for (int i = 0; i < item.RETURN_COUNT; i++)
                    {
                        szFlag += "🏁 ";
                    }
                    row.Cells[this.col_RETURN_COUNT.Index].Value = szFlag;
                    row.Cells[this.col_RETURN_COUNT.Index].Style.ForeColor = Color.Red;
                }
                if (item.SUBMIT_TIME != item.DefaultTime)
                {
                    row.Cells[this.col_SUBMIT_TIME.Index].Value = item.SUBMIT_TIME.ToString("yyyy-MM-dd HH:mm");
                }
                if (item.ARCHIVE_TIME != item.DefaultTime)
                {
                    row.Cells[this.col_ARCHIVE_TIME.Index].Value = item.ARCHIVE_TIME.ToString("yyyy-MM-dd HH:mm");
                }
                row.Cells[this.col_PAPER_RECEIVE.Index].Value = SystemData.PaperReceive.GetPaperReceiveDesc(item.PAPER_RECEIVE);
                row.Cells[this.col_SUBMIT_DOCTOR.Index].Value = item.SUBMIT_DOCTOR;
                row.Cells[this.col_SUBMIT_NURSE.Index].Value = item.SUBMIT_NURSE;

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
            if (e.ColumnIndex == this.colReject.Index)
            {
                if (MessageBoxEx.ShowConfirm("确认驳回吗？") != DialogResult.OK)
                    return;
                //修改病案状态
                MrIndex mrIndex = new MrIndex();
                mrIndex.MR_STATUS = SystemData.MrStatus.Online;
                mrIndex.PATIENT_ID = mrAchive.PATIENT_ID;
                mrIndex.VISIT_ID = mrAchive.VISIT_ID;
                mrIndex.VISIT_NO = mrAchive.VISIT_NO;
                short shRet = MrIndexAccess.Instance.UpdateMrStatus(mrIndex);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowMessage("驳回失败");
                    return;
                }
                QcMrIndex qcMrIndex = new QcMrIndex(mrAchive);
                qcMrIndex.RETURN_COUNT = mrAchive.RETURN_COUNT + 1;
                shRet = QcMrIndexAccess.Instance.Update(qcMrIndex);
                MessageBoxEx.ShowMessage("驳回成功");
                mrAchive.RETURN_COUNT = qcMrIndex.RETURN_COUNT;
                mrAchive.MR_STATUS = mrIndex.MR_STATUS;
                if (mrAchive.RETURN_COUNT != 0)
                {
                    string szFlag = string.Empty;
                    for (int i = 0; i < mrAchive.RETURN_COUNT; i++)
                    {
                        szFlag += "🏁 ";
                    }
                    row.Cells[this.col_RETURN_COUNT.Index].Value = szFlag;
                    row.Cells[this.col_RETURN_COUNT.Index].Style.ForeColor = Color.Red;
                }
                this.dataTableView1.Rows[e.RowIndex].Cells[this.col_ARCHIVE_TIME.Index].Value = null;
                this.dataTableView1.Rows[e.RowIndex].Cells[this.col_MR_STATUS.Index].Value = SystemData.MrStatus.GetMedMrStatusDesc(mrAchive.MR_STATUS);
            }
            else if (e.ColumnIndex == this.colArchive.Index)
            {
                if (MessageBoxEx.ShowConfirm("确认归档吗？") != DialogResult.OK)
                    return;
                //修改病案状态
                MrIndex mrIndex = new MrIndex();
                mrIndex.MR_STATUS = SystemData.MrStatus.Archive;
                mrIndex.PATIENT_ID = mrAchive.PATIENT_ID;
                mrIndex.VISIT_ID = mrAchive.VISIT_ID;
                mrIndex.VISIT_NO = mrAchive.VISIT_NO;
                short shRet = MrIndexAccess.Instance.UpdateMrStatus(mrIndex);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowMessage("归档失败");
                    return;
                }
                QcMrIndex qcMrIndex = null;
                shRet = QcMrIndexAccess.Instance.GetQcMrIndex(mrAchive.PATIENT_ID, mrAchive.VISIT_ID, ref qcMrIndex);
                if (qcMrIndex == null)
                {
                    qcMrIndex = new QcMrIndex(mrAchive);
                }
                qcMrIndex.ARCHIVE_DOCTOR = SystemParam.Instance.UserInfo.Name;
                qcMrIndex.ARCHIVE_DOCTOR_ID = SystemParam.Instance.UserInfo.ID;
                qcMrIndex.ARCHIVE_TIME = SysTimeHelper.Instance.Now;
                if (shRet == SystemData.ReturnValue.RES_NO_FOUND)
                {
                    shRet = QcMrIndexAccess.Instance.Insert(qcMrIndex);
                }
                else if (shRet == SystemData.ReturnValue.OK)
                {
                    shRet = QcMrIndexAccess.Instance.Update(qcMrIndex);
                }
                MessageBoxEx.ShowMessage("归档成功");
                mrAchive.MR_STATUS = mrIndex.MR_STATUS;
                mrAchive.ARCHIVE_DOCTOR = qcMrIndex.ARCHIVE_DOCTOR;
                mrAchive.ARCHIVE_DOCTOR_ID = qcMrIndex.ARCHIVE_DOCTOR_ID;
                mrAchive.ARCHIVE_TIME = qcMrIndex.ARCHIVE_TIME;
                this.dataTableView1.Rows[e.RowIndex].Cells[this.col_ARCHIVE_TIME.Index].Value = mrAchive.ARCHIVE_TIME.ToString("yyyy-MM-dd HH:mm");
                this.dataTableView1.Rows[e.RowIndex].Cells[this.col_MR_STATUS.Index].Value = SystemData.MrStatus.GetMedMrStatusDesc(mrAchive.MR_STATUS);
            }
            else if (e.ColumnIndex == this.col_CheckBox.Index)
            {
                if (row.Cells[this.col_CheckBox.Index].Value != null && row.Cells[this.col_CheckBox.Index].Value.ToString() == "True")
                {
                    row.Cells[this.col_CheckBox.Index].Value = false;
                }
                else
                {
                    row.Cells[this.col_CheckBox.Index].Value = true;
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
            {
                foreach (DataGridViewRow item in this.dataTableView1.Rows)
                {
                    item.Cells[this.col_CheckBox.Index].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow item in this.dataTableView1.Rows)
                {
                    item.Cells[this.col_CheckBox.Index].Value = false;
                }

            }
        }
        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.ShowConfirm("确认归档选中的病案吗？") != DialogResult.OK)
                return;
            StringBuilder errorMessage = new StringBuilder();
            foreach (DataGridViewRow row in this.dataTableView1.Rows)
            {
                if (row.Cells[this.col_CheckBox.Index].Value == null ||
                    row.Cells[this.col_CheckBox.Index].Value.ToString().ToLower() == "false")
                {
                    continue;
                }
                MrArchive mrArchive = row.Tag as MrArchive;
                if (mrArchive == null)
                    continue;
                //修改病案状态
                MrIndex mrIndex = new MrIndex();
                mrIndex.MR_STATUS = SystemData.MrStatus.Archive;
                mrIndex.PATIENT_ID = mrArchive.PATIENT_ID;
                mrIndex.VISIT_ID = mrArchive.VISIT_ID;
                mrIndex.VISIT_NO = mrArchive.VISIT_NO;
                short shRet = MrIndexAccess.Instance.UpdateMrStatus(mrIndex);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    errorMessage.AppendFormat("{0}\r\n", mrArchive.PATIENT_NAME);
                    continue;
                }
                QcMrIndex qcMrIndex = null;
                shRet = QcMrIndexAccess.Instance.GetQcMrIndex(mrArchive.PATIENT_ID, mrArchive.VISIT_ID, ref qcMrIndex);
                if (qcMrIndex == null)
                {
                    qcMrIndex = new QcMrIndex(mrArchive);
                }
                qcMrIndex.ARCHIVE_DOCTOR = SystemParam.Instance.UserInfo.Name;
                qcMrIndex.ARCHIVE_DOCTOR_ID = SystemParam.Instance.UserInfo.ID;
                qcMrIndex.ARCHIVE_TIME = SysTimeHelper.Instance.Now;
                if (shRet == SystemData.ReturnValue.RES_NO_FOUND)
                {
                    shRet = QcMrIndexAccess.Instance.Insert(qcMrIndex);
                }
                else if (shRet == SystemData.ReturnValue.OK)
                {
                    shRet = QcMrIndexAccess.Instance.Update(qcMrIndex);
                }
                mrArchive.MR_STATUS = mrIndex.MR_STATUS;
                mrArchive.ARCHIVE_DOCTOR = qcMrIndex.ARCHIVE_DOCTOR;
                mrArchive.ARCHIVE_DOCTOR_ID = qcMrIndex.ARCHIVE_DOCTOR_ID;
                mrArchive.ARCHIVE_TIME = qcMrIndex.ARCHIVE_TIME;
                row.Cells[this.col_MR_STATUS.Index].Value = SystemData.MrStatus.GetMedMrStatusDesc(mrArchive.MR_STATUS);
                row.Cells[this.col_ARCHIVE_TIME.Index].Value = mrArchive.ARCHIVE_TIME.ToString("yyyy-MM-dd HH:mm");
            }
            if (errorMessage.ToString() != string.Empty)
            {
                MessageBoxEx.ShowError("以下病案归档失败：\n"+errorMessage.ToString());
                return;
            }
            MessageBoxEx.ShowMessage("归档成功");
        }
    }
}
