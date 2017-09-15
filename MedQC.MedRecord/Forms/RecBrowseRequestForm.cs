// 病案质控系统患者信息窗口.
// Creator:LiChunYing  Date:2011-09-28
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;

using EMRDBLib.DbAccess;
using EMRDBLib.Entity;
using EMRDBLib;
using Heren.MedQC.Core;
using MedQCSys.DockForms;
using MedQCSys;
using System.Linq;
using Heren.Common.Forms.Editor;
using Heren.MedQC.Utilities;
using Heren.Common.Controls.TableView;
using Heren.MedQC.Core.Services;
using Heren.MedQC.Model;

namespace Heren.MedQC.MedRecord
{
    public partial class RecBrowseRequestForm : DockContentBase
    {
        public RecBrowseRequestForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;

        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.dtpTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtpTimeEnd.Value = DateTime.Now;

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
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            if (this.IsHidden)
                return;

            if (this.DockState == DockState.DockBottomAutoHide
                || this.DockState == DockState.DockTopAutoHide
                || this.DockState == DockState.DockLeftAutoHide
                || this.DockState == DockState.DockRightAutoHide)
            {
                if (SystemParam.Instance.PatVisitInfo != null)
                    this.DockHandler.Activate();
            }
            this.Update();

            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
                this.OnRefreshView();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            Search();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void Search()
        {
            try
            {

                this.XDataGrid1.Rows.Clear();
                this.chkAll.Checked = false;
                DateTime dtRequestTimeBegin = dtpTimeBegin.Value;
                DateTime dtRequestTimeEnd = dtpTimeEnd.Value;
                string szPatientID = txt_PATIENT_ID.Text.Trim();
                string szStatus = cboStatus.Text;
                List<RecBrowseRequest> lstRecBrowseRequest = null;
                short shRet = RecBrowseRequestAccess.Instance.GetList(szStatus, dtRequestTimeBegin, dtRequestTimeEnd, szPatientID, ref lstRecBrowseRequest);
                if (lstRecBrowseRequest == null)
                {
                    this.lbl_msg.Text = "未找到记录";
                    return;
                }
                this.XDataGrid1.Rows.Clear();
                int nRowIndex = 0;
                foreach (var item in lstRecBrowseRequest)
                {
                    nRowIndex = this.XDataGrid1.Rows.Add();
                    DataTableViewRow row = this.XDataGrid1.Rows[nRowIndex];
                    row.Tag = item;
                    row.Cells[this.col_APPROVAL_NAME.Index].Value = item.APPROVAL_NAME;
                    if (item.APPROVAL_TIME != item.DefaultTime)
                        row.Cells[this.col_APPROVAL_TIME.Index].Value = DateTimeExtensions.ToDefaultString(item.APPROVAL_TIME);
                    if (item.DISCHARGE_TIME != item.DefaultTime)
                        row.Cells[this.col_DISCHARGE_TIME.Index].Value = DateTimeExtensions.ToDefaultString(item.DISCHARGE_TIME);
                    row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
                    row.Cells[this.col_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                    row.Cells[this.col_REMARK.Index].Value = item.REMARK;
                    row.Cells[this.col_REQUEST_NAME.Index].Value = item.REQUEST_NAME;
                    if (item.REQUEST_TIME != item.DefaultTime)
                        row.Cells[this.col_REQUEST_TIME.Index].Value = DateTimeExtensions.ToDefaultString(item.REQUEST_TIME);
                    row.Cells[this.col_STATUS.Index].Value = SystemData.BrowseRequestStatus.GetStatusName(item.STATUS);
                    row.Cells[this.col_VISIT_ID.Index].Value = item.VISIT_ID;
                    row.Cells[this.col_VISIT_NO.Index].Value = item.VISIT_NO;

                }

                this.lbl_msg.Text = string.Format("共{0}条申请记录", lstRecBrowseRequest.Count);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
        }

        ///将选择的病区装换成字符串 用于查询
        private string GetStrWards(DataTable dtWardInfos)
        {
            string strwards = string.Empty;
            foreach (DataRow dr in dtWardInfos.Rows)
            {
                strwards += "'" + dr[0].ToString() + "',";
            }
            if (string.IsNullOrEmpty(strwards))
                return string.Empty;
            strwards = strwards.Substring(0, strwards.Length - 1);
            return strwards;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.XDataGrid1.Rows.Count <= 0)
                return;
            RecUploadService.Instance.InitializeDict();
            foreach (DataTableViewRow row in this.XDataGrid1.Rows)
            {
                if (row.Cells[this.col_Chk.Index].Value != null
                    && row.Cells[this.col_Chk.Index].Value.ToString().ToLower() == "true")
                    RecUploadLog(row.Index);
            }
        }

        private void RecUploadLog(int index)
        {

        }

        private void XDataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.XDataGrid1.Rows.Count <= 0)
                return;
            if (this.chkAll.Checked)
            {
                foreach (DataTableViewRow item in this.XDataGrid1.Rows)
                {
                    item.Cells[this.col_Chk.Index].Value = true;
                }
            }
            else
            {
                foreach (DataTableViewRow item in this.XDataGrid1.Rows)
                {
                    item.Cells[this.col_Chk.Index].Value = false;
                }
            }

        }

        private void XDataGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = this.XDataGrid1.Rows[e.RowIndex];
            if (row.Cells[this.col_Chk.Index].Value == null || row.Cells[this.col_Chk.Index].Value.ToString().ToLower() == "false")
                row.Cells[this.col_Chk.Index].Value = true;
            else
                row.Cells[this.col_Chk.Index].Value = false;
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            BrowseRequestDone(SystemData.BrowseRequestStatus.Approval);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            BrowseRequestDone(SystemData.BrowseRequestStatus.Reject);
        }

        private void BrowseRequestDone(decimal status)
        {
            if (this.XDataGrid1.Rows.Count <= 0)
                return;

            short shRet = SystemData.ReturnValue.OK;
            string error = string.Empty;
            foreach (DataTableViewRow row in this.XDataGrid1.Rows)
            {
                if (row.Cells[this.col_Chk.Index].Value != null
                    && row.Cells[this.col_Chk.Index].Value.ToString().ToLower() == "true")
                {
                    RecBrowseRequest recBrowseRequest = row.Tag as RecBrowseRequest;
                    recBrowseRequest.APPROVAL_NAME = SystemParam.Instance.UserInfo.USER_NAME;
                    recBrowseRequest.APPROVAL_TIME = SysTimeHelper.Instance.Now;
                    recBrowseRequest.STATUS = status;
                    shRet = RecBrowseRequestAccess.Instance.Update(recBrowseRequest);
                    if (shRet == SystemData.ReturnValue.OK)
                    {
                        row.Cells[this.col_APPROVAL_NAME.Index].Value = recBrowseRequest.APPROVAL_NAME;
                        row.Cells[this.col_APPROVAL_TIME.Index].Value = DateTimeExtensions.ToDefaultString(recBrowseRequest.APPROVAL_TIME);
                        row.Cells[this.col_STATUS.Index].Value = SystemData.BrowseRequestStatus.GetStatusName(recBrowseRequest.STATUS);
                    }
                    else
                    {
                        error += string.Format("第{0}行患者{1}病历审批处理失败；", row.Index + 1, recBrowseRequest.PATIENT_NAME);
                    }
                }
            }
            if (error != string.Empty)
            {
                MessageBoxEx.ShowError(error);
                return;
            }
        }
    }
}