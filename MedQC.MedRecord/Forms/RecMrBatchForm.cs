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
    public partial class RecMrBatchForm : DockContentBase
    {
        public RecMrBatchForm(MainForm parent)
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
            string szBatchNo = string.Empty;

            if (this.cboDeptName.Text.Trim() != string.Empty && this.cboDeptName.SelectedItem != null)
            {
                szDeptCode = (this.cboDeptName.SelectedItem as DeptInfo).DEPT_CODE;
            }
            szBatchNo = this.txt_BATCH_NO.Text.Trim();
            DateTime dtSendTimeBegin = this.dtTimeBegin.Value;
            DateTime dtSendTimeEnd = this.dtTimeEnd.Value;
            List<RecMrBatch> lstRecMrBatchs = null;
            short shRet = RecMrBatchAccess.Instance.GetRecMrBatchs(dtSendTimeBegin, dtSendTimeEnd, szDeptCode, szBatchNo, ref lstRecMrBatchs);
            if (lstRecMrBatchs == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            int rowIndex = 0;
            foreach (var item in lstRecMrBatchs)
            {
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_BATCH_NO.Index].Value = item.BATCH_NO;
                row.Cells[this.col_MR_COUNT.Index].Value = item.MR_COUNT;
                row.Cells[this.col_PAPER_COUNT.Index].Value = item.PAPER_COUNT;
                row.Cells[this.col_RECEIVE_DOCTOR_NAME.Index].Value = item.RECEIVE_DOCTOR_NAME;
                if (item.RECEIVE_TIME != item.DefaultTime)
                    row.Cells[this.col_RECEIVE_TIME.Index].Value = item.RECEIVE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_REMARK.Index].Value = item.REMARK;
                row.Cells[this.col_SEND_DEPT_NAME.Index].Value = item.SEND_DEPT_NAME;
                row.Cells[this.col_SEND_DOCTOR_NAME.Index].Value = item.SEND_DOCTOR_NAME;
                if (item.SEND_TIME != item.DefaultTime)
                    row.Cells[this.col_SEND_TIME.Index].Value = item.SEND_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_WORKER_ID.Index].Value = item.WORKER_ID;
                row.Cells[this.col_WORKER_NAME.Index].Value = item.WORKER_NAME;
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
            RecMrBatch recMrBatch = this.dataTableView1.Rows[e.RowIndex].Tag as RecMrBatch;

            if (e.ColumnIndex == this.colReceive.Index)
            {
                if (recMrBatch.RECEIVE_TIME != recMrBatch.DefaultTime)
                {
                    if (MessageBoxEx.ShowConfirm("纸质病历批次已接收，是否重新接收") != DialogResult.OK)
                        return;
                }
                else
                {
                    if (MessageBoxEx.ShowConfirm("确认接收吗？") != DialogResult.OK)
                        return;
                }
                recMrBatch.RECEIVE_DEPT_CODE = SystemParam.Instance.UserInfo.DeptCode;
                recMrBatch.RECEIVE_DEPT_NAME = SystemParam.Instance.UserInfo.DeptName;
                recMrBatch.RECEIVE_DOCTOR_ID = SystemParam.Instance.UserInfo.ID;
                recMrBatch.RECEIVE_DOCTOR_NAME = SystemParam.Instance.UserInfo.Name;
                recMrBatch.RECEIVE_TIME = SysTimeHelper.Instance.Now;
                short shRet = RecMrBatchAccess.Instance.Update(recMrBatch);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowMessage("操作失败");
                    return;
                }
                row.Cells[this.col_RECEIVE_DOCTOR_NAME.Index].Value = recMrBatch.RECEIVE_DOCTOR_NAME;
                row.Cells[this.col_RECEIVE_TIME.Index].Value = recMrBatch.RECEIVE_TIME.ToString("yyyy-MM-dd HH:mm");
                MessageBoxEx.ShowMessage("操作成功");
            }

        }

    }
}
