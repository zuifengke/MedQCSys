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
    public partial class MrDefectRateForm : DockContentBase
    {
        public MrDefectRateForm(MainForm parent)
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
            this.dataTableView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in this.dataTableView1.Columns)
            {
                if (item.Index == this.col_DEPT_ADMISSION_NAME.Index)
                    continue;
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
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
            DateTime dtDischargeTimeBegin = SystemParam.Instance.DefaultTime;
            DateTime dtDischargeTimeEnd = SystemParam.Instance.DefaultTime;
            dtDischargeTimeBegin = this.dtTimeBegin.Value;
            dtDischargeTimeEnd = this.dtTimeEnd.Value;
            List<DeptInfo> lstDeptInfo = null;
            short shRet = DeptAccess.Instance.GetClinicInpDeptList(ref lstDeptInfo);
            WorkProcess.Instance.Initialize(this, lstDeptInfo.Count, "正在计算缺陷率......");
            List<QCScore> lstQCScores = null;
            shRet = QcScoreAccess.Instance.GetQcScores(dtDischargeTimeBegin, dtDischargeTimeEnd, ref lstQCScores);
            if (lstQCScores == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                WorkProcess.Instance.Close();
                return;
            }
            int rowIndex = 0;

            foreach (var item in lstDeptInfo)
            {
                string szDeptName = string.Empty;
                int totalCount = 0;
                int defectCount = 0;
                if (WorkProcess.Instance.Canceled)
                    break;
                WorkProcess.Instance.Show(string.Format("正在计算{0}缺陷率...", item.DEPT_NAME), lstDeptInfo.IndexOf(item), true);
                var result = lstQCScores.Where(m => m.DeptCode == item.DEPT_CODE).ToList();
                szDeptName = item.DEPT_NAME;
                if (result.Count > 0)
                    totalCount = result.Count;
                foreach (var qcscore in result)
                {
                    if (qcscore.HOS_ASSESS > 0 && qcscore.HOS_ASSESS < 100)
                        defectCount++;
                }
                decimal defectRate = totalCount == 0 ? 0 : Math.Round((decimal)defectCount / totalCount, 4) * 100;
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_DEPT_ADMISSION_NAME.Index].Value = szDeptName;
                row.Cells[this.col_DischargeCount.Index].Value = totalCount;
                row.Cells[this.col_DefectCount.Index].Value = defectCount;
                row.Cells[this.col_DefectRate.Index].Value = defectRate;
                row.Cells[this.col_DEPT_ADMISSION_NAME.Index].Tag = item.DEPT_CODE;
            }
            this.dataTableView1.Tag = lstQCScores;
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
            this.dataTableView2.Rows.Clear();
            List<QCScore> lstQCScore = this.dataTableView1.Tag as List<QCScore>;
            if (lstQCScore == null)
                return;
            string szDeptCode = this.dataTableView1.Rows[e.RowIndex].Cells[this.col_DEPT_ADMISSION_NAME.Index].Tag as string;
            var result = lstQCScore.Where(m => m.DeptCode == szDeptCode).ToList();
            this.dataTableView2.Rows.Clear();
            if (result != null && result.Count > 0)
            {
                int rowIndex = 0;
                foreach (var item in result)
                {
                    rowIndex = this.dataTableView2.Rows.Add();
                    DataGridViewRow row = this.dataTableView2.Rows[rowIndex];
                    row.Cells[this.col_2_DEPT_NAME.Index].Value = item.DEPT_NAME;
                    row.Cells[this.col_2_DISCHARGE_TIME.Index].Value = item.DischargeTime.ToString("yyyy-MM-dd HH:mm");
                    row.Cells[this.col_2_HOS_ASSESS.Index].Value = item.HOS_ASSESS;
                    if (item.HOS_ASSESS < 100)
                        row.DefaultCellStyle.BackColor = Color.Red;
                    row.Cells[this.col_2_PATIENT_ID.Index].Value = item.PATIENT_ID;
                    row.Cells[this.col_2_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                    row.Tag = item;
                }
            }
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

        private void dataTableView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            QCScore qcScore = this.dataTableView2.Rows[e.RowIndex].Tag as QCScore;
            if (qcScore == null)
                return;
            this.MainForm.SwitchPatient(qcScore.PATIENT_ID, qcScore.VISIT_ID);
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
            StatExpExcelHelper.Instance.ExportToExcel(this.dataTableView1, "病案缺陷率统计");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}
