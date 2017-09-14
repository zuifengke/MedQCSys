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

namespace Heren.MedQC.MedRecord
{
    public partial class RecUploadNewForm : DockContentBase
    {
        public RecUploadNewForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;

        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.dtpTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtpTimeEnd.Value = DateTime.Now;
            this.dataGridView1.Rows.Clear();

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
        private void XTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool multiSelected = false;

            multiSelected = GlobalMethods.Convert.StringToValue("true", false);
            DataTable table = this.txt_DEPT_NAME.Tag as DataTable;
            if (table == null)
                table = new DataTable();
            table = UtilitiesHandler.Instance.ShowDeptSelectDialog(0, true, table);
            this.txt_DEPT_NAME.Tag = table;
            string strDeptNames = string.Empty;
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow item in table.Rows)
                {
                    if (strDeptNames == string.Empty)
                        strDeptNames = item[1].ToString();
                    else
                        strDeptNames = strDeptNames + ";" + item[1].ToString();
                }
            }
            else
            {
                strDeptNames = "全院<可双击修改>";
            }
            this.txt_DEPT_NAME.Text = strDeptNames;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            Search();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void Search()
        {
            this.dataGridView1.Rows.Clear();
            this.chkAll.Checked = false;
            DateTime dtTimeBegin = dtpTimeBegin.Value;
            DateTime dtTimeEnd = dtpTimeEnd.Value;
            string patientID = txt_PATIENT_ID.Text.Trim();
            string szStatus = cboStatus.Text;
            string szTimeType = string.Empty;
            string szDeptCodes = string.Empty;
            if (cboTimeType.Text == "入院日期")
            {
                szTimeType = "VISIT_TIME";
            }
            else
            {
                szTimeType = "DISCHARGE_TIME";
            }
            DataTable dtWardList = this.txt_DEPT_NAME.Tag as DataTable;
            if (dtWardList != null && dtWardList.Rows.Count > 0)
            {
                szDeptCodes = GetStrWards(dtWardList);
            }
            List<RecUpload> lstRecUpload = null;
            short shRet = RecUploadAccess.Instance.GetRecUploads(patientID, szStatus, szTimeType, dtTimeBegin, dtTimeEnd, szDeptCodes, ref lstRecUpload);
            if (lstRecUpload == null || lstRecUpload.Count <= 0)
            {
                this.lbl_msg.Text = string.Format("未找到患者病历");
                return;
            }
            if (lstRecUpload != null && lstRecUpload.Count > 0)
            {
                foreach (RecUpload item in lstRecUpload)
                {
                    int i = this.dataGridView1.Rows.Add();
                    DataTableViewRow row = this.dataGridView1.Rows[i];
                    row.Cells[this.col_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                    row.Cells[this.col_UPLOAD.Index].Value = item.UPLOAD_STATUS == 1 ? "已上传" : "未上传";
                    row.Cells[this.col_DOCTOR_IN_CHARGE.Index].Value = item.InchargeDoctor;
                    row.Cells[this.col_VISIT_TIME.Index].Value = item.VisitTime.ToString("yyyy-MM-dd HH:mm");
                    row.Cells[this.col_VISIT_ID.Index].Value = item.VISIT_ID;
                    if (item.DischargeTime != item.DefaultTime)
                        row.Cells[this.col_DISCHARGE_TIME.Index].Value = item.DischargeTime.ToString("yyyy-MM-dd HH:mm");
                    row.Cells[this.col_VISIT_NO.Index].Value = item.VISIT_NO;
                    row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
                    row.Cells[this.col_DEPT_NAME.Index].Value = item.DeptName;
                    row.Cells[this.col_UPLOAD_LOG.Index].Value = item.UPLOAD_LOG;
                    if (item.UPLOAD_TIME != item.DefaultTime)
                        row.Cells[this.col_UPLOAD_TIME.Index].Value = item.UPLOAD_TIME.ToString("yyyy-MM-dd HH:mm");
                    row.Tag = item;
                }
            }
            this.lbl_msg.Text = string.Format("共{0}份患者病历", lstRecUpload.Count);
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
            if (this.dataGridView1.Rows.Count <= 0)
                return;
            RecUploadService.Instance.InitializeDict();
            int nFail = 0;
            int nSuccess = 0;
            WorkProcess.Instance.Initialize(this, this.dataGridView1.Rows.Count, "正在上传....");
            foreach (DataTableViewRow row in this.dataGridView1.Rows)
            {
                WorkProcess.Instance.Show(row.Index, true);
                if (row.Cells[this.col_Chk.Index].Value != null
                    && row.Cells[this.col_Chk.Index].Value.ToString().ToLower() == "true")
                {
                    if (RecUploadRow(row))
                        nSuccess++;
                    else
                        nFail++;
                }
            }
            WorkProcess.Instance.Close();
            if (nFail > 0)
                MessageBoxEx.ShowMessage(string.Format("本次上传结束，成功{0}个，失败{1}个。详情见上传日志列"
                    , nSuccess, nFail));
            else
                this.ShowStatusMessage(string.Format("本次上传结束，成功{0}个", nSuccess));
        }


        private void XDataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == this.col_UPLOAD.Index)
            {
                if (!RecUploadRow(this.dataGridView1.Rows[e.RowIndex])) { this.dataGridView1.SelectRow(e.RowIndex); }
                //MessageBoxEx.ShowMessage(string.Format("本次上传失败"));
            }
            if (e.ColumnIndex == this.col_Chk.Index)
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null
                    || this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToLower() == "false")
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
                else
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
            }
        }
        private bool RecUploadRow(DataGridViewRow row)
        {
            RecUpload recUpload = row.Tag as RecUpload;
            string szUploadLog = "";
            bool result = RecUploadService.Instance.Upload(recUpload.PATIENT_ID, recUpload.VISIT_ID, ref szUploadLog);
            if (!result)
            {
                recUpload.UPLOAD_STATUS = 0;
                row.Cells[this.col_UPLOAD.Index].Value = "上传失败";

                row.Cells[this.col_UPLOAD_LOG.Index].Style.ForeColor = Color.Red;
            }
            else
            {
                recUpload.UPLOAD_STATUS = 1;
                row.Cells[this.col_UPLOAD.Index].Value = "已上传";
            }
            recUpload.UPLOAD_LOG = szUploadLog;
            recUpload.UPLOAD_TIME = SysTimeHelper.Instance.Now;
            row.Cells[this.col_UPLOAD_LOG.Index].Value = szUploadLog;
            row.Cells[this.col_UPLOAD_TIME.Index].Value = recUpload.UPLOAD_TIME.ToString("yyyy-MM-dd HH:mm");
            if (string.IsNullOrEmpty(recUpload.UPLOAD_ID))
            {
                recUpload.UPLOAD_ID = recUpload.MakeID();
                short shRet = RecUploadAccess.Instance.Insert(recUpload);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    row.Cells[this.col_UPLOAD_LOG.Index].Value = "更新上传记录失败";
                    return false;
                }
            }
            else
            {
                short shRet = RecUploadAccess.Instance.Update(recUpload);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    row.Cells[this.col_UPLOAD_LOG.Index].Value = "更新上传记录失败";
                    return false;
                }
            }
            return result;
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return;
            if (this.chkAll.Checked)
            {
                foreach (DataTableViewRow item in this.dataGridView1.Rows)
                {
                    item.Cells[this.col_Chk.Index].Value = true;
                }
            }
            else
            {
                foreach (DataTableViewRow item in this.dataGridView1.Rows)
                {
                    item.Cells[this.col_Chk.Index].Value = false;
                }
            }

        }

        private void XDataGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string patient_id = this.dataGridView1.Rows[e.RowIndex].Cells[this.col_PATIENT_ID.Index].Value.ToString();
            string visit_id = this.dataGridView1.Rows[e.RowIndex].Cells[this.col_VISIT_ID.Index].Value.ToString();
            PatVisitInfo patVisit = new PatVisitInfo() { PATIENT_ID = patient_id, VISIT_ID = visit_id };
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(patVisit.PATIENT_ID, patVisit.VISIT_ID, ref patVisit);
            this.MainForm.ShowPatientPageForm(patVisit);
        }
    }
}