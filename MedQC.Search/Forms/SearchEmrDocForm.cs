// ***********************************************************
// �����ʿ�ϵͳ��������ͳ�ƴ���.
// Creator:LiChunYing  Date:2013-08-04
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Linq;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using Heren.Common.DockSuite;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;
using MedQCSys.Dialogs;

namespace Heren.MedQC.Search
{
    public partial class SearchEmrDocForm : DockContentBase
    {
        public SearchEmrDocForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("����", 10.5f);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dtpStatTimeEnd.Value = DateTime.Now;
            this.dtpStatTimeBegin.Value = DateTime.Now.AddDays(-7);
            this.OnRefreshView();

        }

        public override void OnRefreshView()
        {
            this.Update();
            this.ShowStatusMessage("���������ٴ������б������Ժ�...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("���ؿ����б�ʧ��");
            }
            this.ShowStatusMessage(null);
        }

        /// <summary>
        /// ��������Ϣ���ص�DataGridView��
        /// </summary>
        /// <param name="row"></param>
        /// <param name="qcWorkloadStatInfo"></param>
        private void SetRowData(DataGridViewRow row, MedDocInfo docInfo)
        {
            if (row == null || docInfo == null)
                return;
            if (row.DataGridView == null)
                return;

            row.Cells[this.colDeptName.Index].Value = docInfo.DEPT_NAME;
            row.Cells[this.colPatientID.Index].Value = docInfo.PATIENT_ID;
            row.Cells[this.colPatientName.Index].Value = docInfo.PATIENT_NAME;
            row.Cells[this.colVisitTime.Index].Value = docInfo.VISIT_TIME.ToString("yyyy-MM-dd HH:mm");
            row.Cells[this.col_DOC_TIME.Index].Value = docInfo.DOC_TIME.ToString("yyyy-MM-dd HH:mm");
            row.Cells[this.col_DOC_TITLE.Index].Value = docInfo.DOC_TITLE;
            row.Cells[this.col_RECORD_TIME.Index].Value = docInfo.RECORD_TIME.ToString("yyyy-MM-dd HH:mm");
            row.Cells[this.col_CREATOR_NAME.Index].Value = docInfo.CREATOR_NAME;
            if(docInfo.DischargeTime != docInfo.DefaultTime)
                row.Cells[this.colDischargeTime.Index].Value = docInfo.DischargeTime.ToString("yyyy-MM-dd HH:mm");
            row.Tag = docInfo;
        }

        private ReportExplorerForm GetReportExplorerForm()
        {
            ReportExplorerForm reportExplorerForm = new ReportExplorerForm();
            reportExplorerForm.WindowState = FormWindowState.Maximized;
            reportExplorerForm.QueryContext +=
                new QueryContextEventHandler(this.ReportExplorerForm_QueryContext);
            reportExplorerForm.NotifyNextReport +=
                new NotifyNextReportEventHandler(this.ReportExplorerForm_NotifyNextReport);
            return reportExplorerForm;
        }

        /// <summary>
        /// ���ش�ӡģ��
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "��Ժ����ͳ���嵥");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("��Ժ����ͳ���嵥������û������!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("��������ͳ���嵥������������ʧ��!");
                return null;
            }
            return byteTempletData;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "���ڿ���")
            {
                string szDeptName = null;
                if (!string.IsNullOrEmpty(this.cboDeptName.Text.Trim()))
                    szDeptName = this.cboDeptName.Text;
                else
                    szDeptName = "ȫԺ";
                value = szDeptName;
                return true;
            }
            if (name == "��ʼ����")
            {
                value = this.dtpStatTimeBegin.Value;
                return true;
            }
            if (name == "��ֹ����")
            {
                value = this.dtpStatTimeEnd.Value;
                return true;
            }
            return false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
            string szDeptCode = null;
            if (deptInfo != null)
                szDeptCode = deptInfo.DEPT_CODE;
            if (string.IsNullOrEmpty(this.cboDeptName.Text))
                szDeptCode = null;

            string szDocTypeIDList = txtDocType.Tag as string;
            if (string.IsNullOrEmpty(szDocTypeIDList))
            {
                MessageBoxEx.ShowMessage("�������࣬����ѡ��������");
                return;
            }
            String[] arrDocType = szDocTypeIDList.Split(';');
            string szDocTypeIDListCondition = "";
            foreach (string item in arrDocType)
            {
                if (szDocTypeIDListCondition == string.Empty)
                    szDocTypeIDListCondition = "'" + item + "'";
                else
                    szDocTypeIDListCondition += ",'" + item + "'";
            }
            DateTime dtBeginTime = dtpStatTimeBegin.Value;
            DateTime dtEndTime = dtpStatTimeEnd.Value;
            string szTimeType = string.Empty;
            if (rbtnDischargeTime.Checked)
            {
                szTimeType = "DISCHARGE_TIME";
            }
            else
                szTimeType = "RECORD_TIME";
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("���ڲ�ѯ���ݣ����Ժ�...");
            this.dataGridView1.Rows.Clear();
            List<MedDocInfo> lstMedDocInfos = null;
            short shRet = EmrDocAccess.Instance.GetEmrDocList(szTimeType,szDocTypeIDListCondition, dtBeginTime, dtEndTime, szDeptCode, ref lstMedDocInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("��ѯ����ʧ�ܣ�");
                return;
            }
            if (lstMedDocInfos == null || lstMedDocInfos.Count <= 0)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("û�з������������ݣ�", MessageBoxIcon.Information);
                return;
            }
            int nRowIndex = 0;
            for (int index = 0; index < lstMedDocInfos.Count; index++)
            {
                MedDocInfo item = lstMedDocInfos[index];
                nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, item);
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("��ǰû�пɵ��������ݣ�", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "��Ժ����ͳ���嵥");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("��ǰû�пɴ�ӡ���ݣ�");
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            byte[] byteReportData = this.GetReportFileData(null);
            if (byteReportData != null)
            {
                System.Data.DataTable table = GlobalMethods.Table.GetDataTable(this.dataGridView1, false, 0);
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.ReportFileData = byteReportData;
                explorerForm.ReportParamData.Add("�Ƿ�����", false);
                explorerForm.ReportParamData.Add("��ӡ����", table);
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void ReportExplorerForm_NotifyNextReport(object sender, Heren.Common.Report.NotifyNextReportEventArgs e)
        {
            e.ReportData = this.GetReportFileData(e.ReportName);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            MedDocInfo docInfo = row.Tag as MedDocInfo;
            PatVisitInfo patVisitInfo = null;
            short shRet = PatVisitAccess.Instance.GetPatVisit(docInfo.PATIENT_ID, docInfo.VISIT_ID, ref patVisitInfo);
            if (patVisitInfo == null)
            {
                MessageBoxEx.ShowMessage("������Ϣ��ȡʧ��,�޷��򿪲���");
                return;

            }

            if (SystemParam.Instance.LocalConfigOption.IsNewTheme)
            {
                this.MainForm.SwitchPatient(patVisitInfo,docInfo);
                return;
            }
            this.MainForm.OpenDocument(string.Empty, patVisitInfo.PATIENT_ID, patVisitInfo.VISIT_ID);
        }

        private void txtDocType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowDocTypeSelectForm();
        }
        /// <summary>
        /// ��ʾ�ĵ��������öԻ���
        /// </summary>
        /// <param name="row">ָ����</param>
        private void ShowDocTypeSelectForm()
        {
            TempletSelectForm templetSelectForm = new TempletSelectForm();
            templetSelectForm.DefaultDocTypeID = txtDocType.Tag as string;
            templetSelectForm.MultiSelect = true;
            templetSelectForm.Text = "ѡ��������";
            templetSelectForm.Description = "��ѡ��Ӧ��д�Ĳ������ͣ�";
            if (templetSelectForm.ShowDialog() != DialogResult.OK)
                return;
            List<DocTypeInfo> lstDocTypeInfos = templetSelectForm.SelectedDocTypes;
            if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
            {
                return;
            }

            StringBuilder sbDocTypeIDList = new StringBuilder();
            StringBuilder sbDocTypeNameList = new StringBuilder();
            for (int index = 0; index < lstDocTypeInfos.Count; index++)
            {
                DocTypeInfo docTypeInfo = lstDocTypeInfos[index];
                if (docTypeInfo == null)
                    continue;
                sbDocTypeIDList.Append(docTypeInfo.DocTypeID);
                if (index < lstDocTypeInfos.Count - 1)
                    sbDocTypeIDList.Append(";");
                sbDocTypeNameList.Append(docTypeInfo.DocTypeName);
                if (index < lstDocTypeInfos.Count - 1)
                    sbDocTypeNameList.Append(";");
            }
            txtDocType.Text = sbDocTypeNameList.ToString();
            txtDocType.Tag = sbDocTypeIDList.ToString();
        }

    }
}