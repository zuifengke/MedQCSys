/********************************************************
 * @FileName   : QcTrackForm.cs
 * @Description: 病案质控系统之质控追踪功能
 * @Author     : 叶慧(Yehui)
 * @Date       : 2017-01-14 11:06:51
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

namespace Heren.MedQC.Systems
{
    public partial class QcTrackForm : DockContentBase
    {
        public QcTrackForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
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
            this.dtIssuedBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtIssuedEnd.Value = DateTime.Now;
            this.col_2_btnPass.Image = Properties.Resources.confirm;
            this.col_2_btnReject.Image = Properties.Resources._return;

        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载医嘱记录，请稍候...");
            this.dataTableView1.Rows.Clear();
            this.dataTableView2.Rows.Clear();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        public QcTrackForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataTableView2.Rows.Clear();
            this.dataTableView1.Rows.Clear();
            string szDeptCode = string.Empty;
            string szUserID = string.Empty;
            string szPatientID = this.txtPatientID.Text.Trim();
            string szPatientName = this.txtName.Text.Trim();
            List<string> lstMsgState = new List<string>();
            string szMsgState = string.Empty;
            if (this.chkUnCheck.Checked)
                lstMsgState.Add(SystemData.MsgStatus.UnCheck.ToString());
            if (this.chkModified.Checked)
                lstMsgState.Add(SystemData.MsgStatus.Modified.ToString());
            if (this.chkPass.Checked)
                lstMsgState.Add(SystemData.MsgStatus.Pass.ToString());
            if (this.cboDeptName.Text.Trim() != string.Empty && this.cboDeptName.SelectedItem != null)
            {
                szDeptCode = (this.cboDeptName.SelectedItem as DeptInfo).DEPT_CODE;
            }
            if (this.cboUserList.Text.Trim() != string.Empty && this.cboUserList.SelectedItem != null)
            {
                szUserID = (this.cboUserList.SelectedItem as UserInfo).USER_ID;
            }
            if (lstMsgState.Count == 0)
            {
                MessageBoxEx.Show("必须选中一项质检信息状态");
                return;
            }
            szMsgState = string.Join(",", lstMsgState.ToArray());
            DateTime dtNoticeTimeBegin = dtIssuedBegin.Value.Date;
            DateTime dtNoticeTimeEnd = dtIssuedEnd.Value.Date.AddDays(1).AddSeconds(-1);
            List<QcModifyNotice> lstQcModifyNotice = null;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            short shRet = QcModifyNoticeAccess.Instance.GetQcModifyNotices(dtNoticeTimeBegin, dtNoticeTimeEnd, szDeptCode, szUserID, szPatientID, szPatientName, ref lstQcModifyNotice);
            if (lstQcModifyNotice == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            List<MedicalQcMsg> lstMedicalQcMsg = null;
            shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szDeptCode, szMsgState, dtNoticeTimeBegin, dtNoticeTimeEnd, ref lstMedicalQcMsg);

            foreach (var item in lstQcModifyNotice)
            {
                if (lstMedicalQcMsg == null)
                    break;
                if (lstMedicalQcMsg.Where(m => m.MODIFY_NOTICE_ID == item.MODIFY_NOTICE_ID).Count() <= 0)
                    continue;
                int rowIndex = this.dataTableView1.Rows.Add();
                DataTableViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_1_DischargeTime.Index].Value = string.Empty;
                row.Cells[this.col_1_MODIFY_REMARK.Index].Value = item.MODIFY_REMARK;
                row.Cells[this.col_1_NOTICE_TIME.Index].Value = item.NOTICE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_1_PATIENT_ID.Index].Value = item.PATIENT_ID;
                row.Cells[this.col_1_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                row.Cells[this.col_1_QC_DEPT_NAME.Index].Value = item.QC_DEPT_NAME;
                row.Cells[this.col_1_QC_LEVEL.Index].Value = SystemData.QcLevel.GetCnName(item.QC_LEVEL);
                row.Cells[this.col_1_QC_MAN.Index].Value = item.QC_MAN;
                row.Cells[this.col_1_RECEIVER_DEPT_NAME.Index].Value = item.RECEIVER_DEPT_NAME;
                row.Tag = item;
            }
            if (this.dataTableView1.Rows.Count > 0)
                this.dataTableView1.Rows[0].Selected = true;
            this.dataTableView2.Rows.Clear();

            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataTableView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            QcModifyNotice item = this.dataTableView1.Rows[e.RowIndex].Tag as QcModifyNotice;
            if (item == null)
                return;
            if (e.ColumnIndex == col_1_btnDelete.Index)
            {
                this.DeleteQcModifyNotice(item);
                return;
            }
            this.dataTableView2.Rows.Clear();
            List<MedicalQcMsg> lstMedicalQcMsg = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgs(item.MODIFY_NOTICE_ID, ref lstMedicalQcMsg);
            if (lstMedicalQcMsg == null || lstMedicalQcMsg.Count <= 0)
                return;

            int rowIndex = 0;
            foreach (var medicalQcMsg in lstMedicalQcMsg)
            {
                rowIndex = this.dataTableView2.Rows.Add();
                DataTableViewRow row = this.dataTableView2.Rows[rowIndex];
                row.Cells[this.col_2_DoctorComment.Index].Value = medicalQcMsg.DOCTOR_COMMENT;
                row.Cells[this.col_2_doctorInCharge.Index].Value = medicalQcMsg.DOCTOR_IN_CHARGE;
                row.Cells[this.col_2_Point.Index].Value = medicalQcMsg.POINT;
                row.Cells[this.col_2_QA_EVENT_TYPE.Index].Value = medicalQcMsg.QA_EVENT_TYPE;
                row.Cells[this.col_2_QcMsgDict.Index].Value = medicalQcMsg.MESSAGE;
                row.Cells[this.col_2_ERROR_COUNT.Index].Value = medicalQcMsg.ERROR_COUNT;
                row.Cells[this.col_2_MSG_STATUS.Index].Value = SystemData.MsgStatus.GetCnMsgState(medicalQcMsg.MSG_STATUS);
                if (medicalQcMsg.MSG_STATUS == SystemData.MsgStatus.Modified)
                {
                    row.Cells[this.col_2_MSG_STATUS.Index].Style.ForeColor = Color.Blue;
                }
                else if (medicalQcMsg.MSG_STATUS == SystemData.MsgStatus.Pass)
                {
                    row.Cells[this.col_2_MSG_STATUS.Index].Style.ForeColor = Color.Green;
                }
                else if (medicalQcMsg.MSG_STATUS == SystemData.MsgStatus.UnCheck)
                {
                    row.Cells[this.col_2_MSG_STATUS.Index].Style.ForeColor = Color.Red;
                }
                else if (medicalQcMsg.MSG_STATUS == SystemData.MsgStatus.Checked)
                {
                    row.Cells[this.col_2_MSG_STATUS.Index].Style.ForeColor = Color.Yellow;
                }
                if (medicalQcMsg.ASK_DATE_TIME != SystemParam.Instance.DefaultTime)
                    row.Cells[this.col_2_AskDateTime.Index].Value = medicalQcMsg.ASK_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Selected = false;
                row.Tag = medicalQcMsg;
            }
            this.dataTableView2.Rows[0].Selected = true;
            if (string.IsNullOrEmpty(lstMedicalQcMsg[0].TOPIC_ID))
            {
                return;
            }

        }

        private void DeleteQcModifyNotice(QcModifyNotice qcModifyNotice)
        {
            if (MessageBoxEx.ShowConfirm("您确定删除该条整改通知书吗？") == DialogResult.OK)
            {
                short shRet = QcModifyNoticeAccess.Instance.Delete(qcModifyNotice.MODIFY_NOTICE_ID);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    List<MedicalQcMsg> lstMedicalQcMsg = null;
                    shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgs(qcModifyNotice.MODIFY_NOTICE_ID, ref lstMedicalQcMsg);
                    foreach (var item in lstMedicalQcMsg)
                    {
                        MedicalQcMsgAccess.Instance.Delete(item.MSG_ID);
                    }
                    MessageBoxEx.ShowMessage("删除操作成功");
                    this.dataTableView1.Rows.RemoveAt(dataTableView1.SelectedRows[0].Index);
                    this.dataTableView2.Rows.Clear();
                }
            }
        }

        private void dataTableView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataTableView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.col_2_btnPass.Index)
            {
                MedicalQcMsg qcMsg = this.dataTableView2.Rows[e.RowIndex].Tag as MedicalQcMsg;
                PassQcMsg(qcMsg);
            }
            if (e.ColumnIndex == this.col_2_btnReject.Index)
            {
                MedicalQcMsg qcMsg = this.dataTableView2.Rows[e.RowIndex].Tag as MedicalQcMsg;
                RejectQcMsg(qcMsg);
            }
        }

        private void PassQcMsg(MedicalQcMsg qcMsg)
        {
            if (MessageBoxEx.ShowConfirm("您对该问题整改情况确认合格吗？") == DialogResult.OK)
            {
                qcMsg.MSG_STATUS = SystemData.MsgStatus.Pass;
                short shRet = MedicalQcMsgAccess.Instance.Update(qcMsg);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowMessage("确认合格操作成功");
                    RefreshDataTable1(qcMsg);
                }
                else
                    MessageBoxEx.ShowError("确认合格操作失败");
            }
        }

        private void RefreshDataTable1(MedicalQcMsg qcMsg)
        {
            this.dataTableView1.SelectedRows[0].Tag = qcMsg;
            this.dataTableView2.SelectedRows[0].Tag = qcMsg;
        }

        private void RejectQcMsg(MedicalQcMsg qcMsg)
        {
            if (MessageBoxEx.ShowConfirm("您对该问题整改情况驳回重改吗？") == DialogResult.OK)
            {
                qcMsg.MSG_STATUS = SystemData.MsgStatus.UnCheck;
                short shRet = MedicalQcMsgAccess.Instance.Update(qcMsg);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowMessage("操作成功");
                    RefreshDataTable1(qcMsg);
                }
                else
                    MessageBoxEx.ShowError("驳回操作失败");
            }
        }

        private void dataTableView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            QcModifyNotice qcModifyNotice = this.dataTableView1.Rows[e.RowIndex].Tag as QcModifyNotice;
            if (qcModifyNotice == null)
                return;
            PatVisitInfo patVisitInfo = new PatVisitInfo();
            patVisitInfo.PATIENT_ID = qcModifyNotice.PATIENT_ID;
            patVisitInfo.VISIT_ID = qcModifyNotice.VISIT_ID;
            this.MainForm.SwitchPatient(patVisitInfo);
        }

        private void dataTableView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            MedicalQcMsg medicalQcMsg = this.dataTableView2.Rows[e.RowIndex].Tag as MedicalQcMsg;
            if (medicalQcMsg == null)
                return;
            QcMsgDict qcMsgDict = null;
            QcMsgDictAccess.Instance.GetQcMsgDict(medicalQcMsg.QC_MSG_CODE, ref qcMsgDict);
            PatVisitInfo patVisit = new PatVisitInfo();
            patVisit.PATIENT_ID = medicalQcMsg.PATIENT_ID;
            patVisit.VISIT_ID = medicalQcMsg.VISIT_ID;
            patVisit.VISIT_NO = medicalQcMsg.VISIT_NO;
            this.MainForm.SwitchPatient(patVisit);
            PatientPageForm patientPageForm = this.MainForm.GetPatientPageForm(patVisit);
            if (string.IsNullOrEmpty(qcMsgDict.MESSAGE_TITLE) || qcMsgDict.QA_EVENT_TYPE.Contains("入院记录"))
                patientPageForm.LoadModule(medicalQcMsg.QA_EVENT_TYPE);
            else
                patientPageForm.LoadModule(qcMsgDict.MESSAGE_TITLE);
        }
    }
}
