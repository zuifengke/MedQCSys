/********************************************************
 * @FileName   : QcTrackForm.cs
 * @Description: 病案管理系统之在院患者列表
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
    public partial class PatInHospitalListForm : DockContentBase
    {
        public PatInHospitalListForm(MainForm parent)
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
            this.Text = "在院患者";

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
        public PatInHospitalListForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataTableView1.Rows.Clear();
            string szDeptCode = string.Empty;
            string szUserID = string.Empty;
            string szPatientID = this.txtPatientID.Text.Trim();
            string szPatientName = this.txtName.Text.Trim();
            string szMsgState = string.Empty;
        
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
            if (this.chkVisitTime.Checked)
            {
                dtVisitTimeBegin = this.dtTimeBegin.Value;
                dtVisitTimeEnd = this.dtTimeEnd.Value.AddDays(1).AddSeconds(-1);
            }
            List<PatVisitInfo> lstPatVisitInfo = null;
            short shRet = InpVisitAccess.Instance.GetInpVisitInfos(szDeptCode,szUserID,szPatientID,szPatientName,dtVisitTimeBegin,dtVisitTimeEnd, ref lstPatVisitInfo);
            if (lstPatVisitInfo == null)
                return;
            int rowIndex = 0;
            foreach (var item in lstPatVisitInfo)
            {
                rowIndex= this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_1_BED_NO.Index].Value = item.BED_CODE;
                row.Cells[this.col_1_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                row.Cells[this.col_AGE.Index].Value = GlobalMethods.SysTime.GetAgeText(item.BIRTH_TIME);
                row.Cells[this.col_DIAGNOSIS.Index].Value = item.DIAGNOSIS;
                row.Cells[this.col_INCHARGE_DOCTOR.Index].Value = item.INCHARGE_DOCTOR;
                row.Cells[this.col_MR_STATUS.Index].Value = SystemData.MrStatus.GetMrStatusName(item.MR_STATUS);
                row.Cells[this.col_1_DEPT_NAME.Index].Value = item.DEPT_NAME ;
                row.Cells[this.col_VISIT_TIME.Index].Value = item.VISIT_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_INCHARGE_DOCTOR.Index].Value = item.INCHARGE_DOCTOR;
                row.Cells[this.col_PATIENT_SEX.Index].Value = item.PATIENT_SEX;
                row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
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
        

        private void RefreshDataTable1(MedicalQcMsg qcMsg)
        {
            this.dataTableView1.SelectedRows[0].Tag = qcMsg;
        }


        private void dataTableView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            
            PatVisitInfo patVisitInfo= this.dataTableView1.Rows[e.RowIndex].Tag as PatVisitInfo;
            if (patVisitInfo == null)
                return;
            this.MainForm.SwitchPatient(patVisitInfo);
        }

    }
}
