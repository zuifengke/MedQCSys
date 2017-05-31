using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Report;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
using MedQCSys;

namespace Heren.MedQC.Statistic
{
    public partial class StatByQcCheckResultForm : MedQCSys.DockForms.DockContentBase
    {
        public StatByQcCheckResultForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();

            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dataGridView1.Font = new Font("宋体", 10.5f);
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
            this.dtpBeginTime.Value = DateTime.Now.AddMonths(-1);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.ShowStatusMessage(null);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dtBeginTime = DateTime.Parse(this.dtpBeginTime.Value.ToShortDateString());
            DateTime dtEndTime = DateTime.Parse(this.dtpEndTime.Value.AddDays(1).ToShortDateString());

            string szDeptCode = string.Empty;
            if (this.cboDeptName.SelectedItem != null && !string.IsNullOrEmpty(this.cboDeptName.Text.Trim()))
            {
                szDeptCode = (this.cboDeptName.SelectedItem as  DeptInfo).DEPT_CODE;
            }
            string szMrStatus = SystemData.MrStatus.GetMrStatusCode(this.cboQcMrStatus.Text);
            int nStatType = SystemData.StatType.GetCode(this.cboStatType.Text);
            this.ShowStatusMessage("正在查询缺陷自动检查记录...");
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            List<EMRDBLib.QcCheckResult> lstQcCheckResult = null;
            string szOrderBy = string.Format("{0},{1},{2},{3},{4}"
          , SystemData.QcCheckResultTable.DEPT_CODE
          , SystemData.QcCheckResultTable.INCHARGE_DOCTOR
          , SystemData.QcCheckResultTable.PATIENT_ID
          , SystemData.QcCheckResultTable.VISIT_ID
          , SystemData.QcCheckResultTable.ORDER_VALUE);
            short shRet = QcCheckResultAccess.Instance.GetQcCheckResults(dtBeginTime, dtEndTime, null, null, szDeptCode, szOrderBy,szMrStatus,nStatType, ref lstQcCheckResult);
            if (shRet == EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            {
                this.dataGridView1.Rows.Clear();
                this.ShowStatusMessage("未找到自动检查缺陷记录");
                WorkProcess.Instance.Close();
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK
                && shRet != EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            {
                WorkProcess.Instance.Close();
                MessageBoxEx.Show("查询失败");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }

            this.LoadQcCheckResult(lstQcCheckResult);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        /// <summary>
        /// 装载时效记录信息
        /// </summary>
        private void LoadQcCheckResult(List<EMRDBLib.QcCheckResult> lstQcCheckResult)
        {
            this.dataGridView1.Rows.Clear();
            if (lstQcCheckResult == null || lstQcCheckResult.Count <= 0)
                return;
            WorkProcess.Instance.Initialize(this, lstQcCheckResult.Count
              , string.Format("正在加载，请稍候..."));
            string szDeptCode = string.Empty;
            string szDoctor = string.Empty;
            string szPatientID = string.Empty;
            string szVisitID = string.Empty;
            string szQaEventType = string.Empty;
            for (int index = 0; index < lstQcCheckResult.Count; index++)
            {
                WorkProcess.Instance.Show(string.Format("加载到{0}，请稍候...", index.ToString()), index);

                EMRDBLib.QcCheckResult record = lstQcCheckResult[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = record;
                row.Cells[this.colDeptName.Index].Value = record.DEPT_IN_CHARGE;
                row.Cells[this.colDoctorInCharge.Index].Value = record.INCHARGE_DOCTOR;
                row.Cells[this.colPatientName.Index].Value = record.PATIENT_NAME;
                row.Cells[this.colPatientID.Index].Value = record.PATIENT_ID;
                row.Cells[this.colVisitID.Index].Value = record.VISIT_ID;
                row.Cells[this.colVisitID.Index].Value = "1";
                row.Cells[this.colQaEventType.Index].Value = record.QA_EVENT_TYPE;
                row.Cells[this.colDocTitle.Index].Value = record.DOC_TITLE;
                row.Cells[this.colCreateName.Index].Value = record.CREATE_NAME;
                row.Cells[this.colPoint.Index].Value = record.SCORE;
                row.Cells[this.colErrorCount.Index].Value = record.ERROR_COUNT;
                if (record.DOC_TIME != record.DefaultTime)
                    row.Cells[this.colCreateTime.Index].Value = record.DOC_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colCheckDate.Index].Value = record.CHECK_DATE.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colQcExplain.Index].Value = record.QC_EXPLAIN;
                row.Cells[this.colQcResult.Index].Value = record.QC_RESULT == 1 ? "通过" : "不通过";
                row.Cells[this.colMsgDictMessage.Index].Value = record.MSG_DICT_MESSAGE;

            }
            WorkProcess.Instance.Close();
            string szMessage = string.Format("共找到{0}条记录", lstQcCheckResult.Count.ToString());
            this.ShowStatusMessage(szMessage);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "缺陷自动检查记录查询");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetGlobalDataHandler(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private bool GetGlobalDataHandler(string name, ref object value)
        {
            return false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > this.dataGridView1.Rows.Count - 1)
                return;
            if (e.ColumnIndex > this.dataGridView1.Columns.Count - 1)
                return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            EMRDBLib.QcTimeRecord checkResultInfo = row.Tag as EMRDBLib.QcTimeRecord;
            if (checkResultInfo == null || string.IsNullOrEmpty(checkResultInfo.DocID))
                return;
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在准备打开病历，请稍候...");

             MedDocInfo docInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(checkResultInfo.DocID, ref docInfo);
            if (shRet == EMRDBLib.SystemData.ReturnValue.OK)
                this.MainForm.OpenDocument(docInfo);
            else
                MessageBoxEx.Show("病历详细信息下载失败,无法打开病历！");
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

    }
}