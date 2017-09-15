/********************************************************
 * @FileName   : PatOutHospitalListForm.cs
 * @Description: 病案管理系统之出院患者列表
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
using Heren.MedQC.MedRecord.Dialogs;

namespace Heren.MedQC.MedRecord
{
    public partial class PatOutHospitalListForm : DockContentBase
    {
        public PatOutHospitalListForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = false;
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
            if (!InitControlData.InitcboUserList(ref this.cboUserList))
            {
                MessageBoxEx.ShowError("加载质控医生列表失败");
            }
            this.dtTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtTimeEnd.Value = DateTime.Now;
            this.Text = "出院患者";

        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载医嘱记录，请稍候...");
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
            string szPatientID = this.txtPatientID.Text.Trim();
            string szPatientName = this.txtName.Text.Trim();
            string szMsgState = string.Empty;
            string szDichargeMode = string.Empty;
            if (this.cboDeptName.Text.Trim() != string.Empty && this.cboDeptName.SelectedItem != null)
            {
                szDeptCode = (this.cboDeptName.SelectedItem as DeptInfo).DEPT_CODE;
            }
            if (this.cboUserList.Text.Trim() != string.Empty && this.cboUserList.SelectedItem != null)
            {
                szUserID = (this.cboUserList.SelectedItem as UserInfo).USER_ID;
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
            if (this.chkDeath.Checked)
            {
                szDichargeMode = "死亡";
            }
            List<PatVisitInfo> lstPatVisitInfo = null;
            short shRet = PatVisitAccess.Instance.GetPatVisits(szDeptCode, szUserID, szPatientID, szPatientName, dtVisitTimeBegin, dtVisitTimeEnd, dtDischargeTimeBegin, dtDischargeTimeEnd, szDichargeMode, ref lstPatVisitInfo);
            if (lstPatVisitInfo == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            int rowIndex = 0;
            foreach (var item in lstPatVisitInfo)
            {
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_1_BED_NO.Index].Value = item.BED_CODE;
                row.Cells[this.col_DISCHARGE_MODE.Index].Value = item.DISCHARGE_MODE;
                row.Cells[this.col_1_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                row.Cells[this.col_AGE.Index].Value = GlobalMethods.SysTime.GetAgeText(item.BIRTH_TIME);
                row.Cells[this.col_DIAGNOSIS.Index].Value = item.DIAGNOSIS;
                row.Cells[this.col_INCHARGE_DOCTOR.Index].Value = item.INCHARGE_DOCTOR;
                row.Cells[this.col_MR_STATUS.Index].Value = SystemData.MrStatus.GetMrStatusName(item.MR_STATUS);
                row.Cells[this.col_1_DEPT_NAME.Index].Value = item.DEPT_NAME;
                row.Cells[this.col_VISIT_TIME.Index].Value = item.VISIT_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_INCHARGE_DOCTOR.Index].Value = item.INCHARGE_DOCTOR;
                row.Cells[this.col_PATIENT_SEX.Index].Value = item.PATIENT_SEX;
                row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
                if (item.DISCHARGE_TIME != SystemParam.Instance.DefaultTime)
                    row.Cells[this.col_DISCHARGE_TIME.Index].Value = item.DISCHARGE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_DISCHARGE_MODE.Index].Value = item.DISCHARGE_MODE;

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
            PatVisitInfo patVisitInfo = this.dataTableView1.Rows[e.RowIndex].Tag as PatVisitInfo;
            if (patVisitInfo == null)
                return;
            this.MainForm.SwitchPatient(patVisitInfo);
        }

        private void tsBrowseRequest_Click(object sender, EventArgs e)
        {
            if (this.dataTableView1.SelectedRows.Count <= 0)
            {
                MessageBoxEx.ShowMessage("请选择申请浏览病历");
                return;
            }
            PatVisitInfo patVisitInfo = this.dataTableView1.SelectedRows[0].Tag as PatVisitInfo;
            if (patVisitInfo == null)
                return;
            string szPatientID = patVisitInfo.PATIENT_ID;
            string szVisitID = patVisitInfo.VISIT_ID;
            string szPatientName = patVisitInfo.PATIENT_NAME;
            string szRequestID = SystemParam.Instance.UserInfo.USER_ID;
            List<RecBrowseRequest> lstRecBrowseRequest = null;
            short shRet = RecBrowseRequestAccess.Instance.GetList(szPatientID, szVisitID, szRequestID, ref lstRecBrowseRequest);
            if (lstRecBrowseRequest != null
                && lstRecBrowseRequest.Count > 0
                && lstRecBrowseRequest[0].STATUS == 1)
            {
                MessageBoxEx.ShowMessage("审核已经通过，可直接打开浏览");
                return;
            }

            RecBrowseRequestDialog dialog = new RecBrowseRequestDialog();
            RecBrowseRequest recBrowseRequest = null;
            if (lstRecBrowseRequest == null)
            {
                recBrowseRequest = new RecBrowseRequest();
                recBrowseRequest.DISCHARGE_TIME = patVisitInfo.DISCHARGE_TIME;
                recBrowseRequest.PATIENT_ID = patVisitInfo.PATIENT_ID;
                recBrowseRequest.VISIT_ID = patVisitInfo.VISIT_ID;
                recBrowseRequest.VISIT_NO = patVisitInfo.VISIT_NO;
                recBrowseRequest.PATIENT_NAME = patVisitInfo.PATIENT_NAME;
                recBrowseRequest.REQUEST_ID = SystemParam.Instance.UserInfo.USER_ID;
                recBrowseRequest.REQUEST_NAME = SystemParam.Instance.UserInfo.USER_NAME;
                recBrowseRequest.REQUEST_TIME = SysTimeHelper.Instance.Now;
            }
            else
                recBrowseRequest = lstRecBrowseRequest[0];
            dialog.RecBrowseRequest = recBrowseRequest;
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }

        }
    }
}
