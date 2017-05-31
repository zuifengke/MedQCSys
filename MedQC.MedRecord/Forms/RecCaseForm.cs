/********************************************************
 * @FileName   : PatOutHospitalListForm.cs
 * @Description: 病案管理系统之病历装箱
 * @Author     : 叶慧(Yehui)
 * @Date       : 2017-05-09 11:06:51
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
using Heren.MedQC.Core;

namespace Heren.MedQC.MedRecord
{
    public partial class RecCaseForm : DockContentBase
    {
        public RecCaseForm(MainForm parent)
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
            this.txt_PACK_NO.Focus();
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();

            this.ShowStatusMessage("正在下载，请稍候...");
            this.ShowStatusMessage(null);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            string szDeptCode = string.Empty;
            string szUserID = string.Empty;
            string szMsgStatus = string.Empty;
            string szBatchNo = string.Empty;
        }

        private void dataTableView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            List<MedicalQcMsg> lstMedicalQcMsg = null;
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

        }

        private void dataTableView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            string szDocID = this.txtCaseNo.Text.Trim();
            MedDocInfo docInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(szDocID, ref docInfo);
            if (docInfo == null)
                return;
            string szPatientID = docInfo.PATIENT_ID;
            string szVisitNo = docInfo.VISIT_ID;//文书VisitID存了 VisitNo
            PatVisitInfo patVisitInfos = null;
            shRet = PatVisitAccess.Instance.GetPatVisit(szPatientID, szVisitNo, ref patVisitInfos);

            List<MedDocInfo> lstMedDocInfos = null;
            shRet = EmrDocAccess.Instance.GetDocList(szPatientID, szVisitNo, ref lstMedDocInfos);
            if (lstMedDocInfos == null)
                return;
            List<RecPaper> lstRecPapers = new List<RecPaper>();
            shRet = RecPaperAccess.Instance.GetRecPapers(szPatientID, szVisitNo, ref lstRecPapers);
           
            string[] arrSignKeyName = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.SignKeyName]!=null?null: DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.SignKeyName].Split('|');
            int rowIndex = 0;
            this.dataGridView1.Rows.Clear();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex == this.colCheckBox.Index)
            {
                if (row.Cells[this.colCheckBox.Index].Value == null
                    || row.Cells[this.colCheckBox.Index].Value.ToString().ToLower() == "false")
                    row.Cells[this.colCheckBox.Index].Value = true;
                else
                    row.Cells[this.colCheckBox.Index].Value = false;
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return;
            short shRet = SystemData.ReturnValue.OK;
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                RecPaper recPaper = item.Cells[this.colCheckBox.Index].Tag as RecPaper;
                MedDocInfo doc = item.Tag as MedDocInfo;
                if (item.Cells[this.colCheckBox.Index].Value != null
                    && item.Cells[this.colCheckBox.Index].Value.ToString().ToLower() == "true")
                {
                    if (recPaper != null)
                    {
                        recPaper.PAPER_STATE = SystemData.PaperState.Receive;
                        shRet = RecPaperAccess.Instance.Update(recPaper);
                    }
                    else
                    {
                        recPaper = new RecPaper();
                        recPaper.PAPER_ID = recPaper.MakeID();
                        recPaper.DOC_ID = doc.DOC_ID;
                        recPaper.VISIT_ID = doc.VISIT_ID;
                        recPaper.VISIT_NO = doc.VISIT_ID;
                        recPaper.PAPER_STATE = SystemData.PaperState.Receive;
                        recPaper.PATIENT_ID = doc.PATIENT_ID;
                        shRet = RecPaperAccess.Instance.Insert(recPaper);
                    }
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.ShowError("操作失败");
                        return;
                    }
                    //item.Cells[this.colCheckBox.Index].Value = true;
                }
                else
                {
                    if (recPaper != null)
                    {
                        recPaper.PAPER_STATE = SystemData.PaperState.UnReceive;
                        shRet = RecPaperAccess.Instance.Update(recPaper);
                    }
                    //item.Cells[this.colCheckBox.Index].Value = false;
                }
            }
            MessageBoxEx.ShowMessage("操作成功");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void xGraphView1_Click(object sender, EventArgs e)
        {

        }

        private void txt_PACK_NO_TextChanged(object sender, EventArgs e)
        {

            string szPackNo = this.txt_PACK_NO.Text.Trim();
            if (szPackNo == string.Empty)
                return;
            List<RecPack> lstRecPacks = null;
            short shRet = RecPackAccess.Instance.GetRecPacksByPackNo(szPackNo, ref lstRecPacks);
            if (lstRecPacks == null || lstRecPacks.Count <= 0)
            {
                return;
            }
            string szCaseNo = lstRecPacks[0].CASE_NO;
            if (string.IsNullOrEmpty(szCaseNo)
                && this.txtCaseNo.Text.Trim() == string.Empty)
            {
                MessageBoxEx.ShowMessage("包号未设置");
                return;
            }
            if (this.txtCaseNo.Text.Trim() == string.Empty)
            {
                this.txtCaseNo.Text = szCaseNo;
            }
            else
            {
                szCaseNo = this.txtCaseNo.Text.Trim();
                shRet = RecPackAccess.Instance.UpdateCaseNo(szPackNo, szCaseNo);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    this.lbl_CaseResult.Text = "装箱成功";
                }
                else
                {
                    this.lbl_CaseResult.Text = "装箱失败";
                }
            }
            lstRecPacks.Clear();

            shRet = RecPackAccess.Instance.GetRecPacksByCaseNo(szCaseNo, ref lstRecPacks);
            if (lstRecPacks == null)
                return;
            this.txtPackCount.Text = lstRecPacks.Count.ToString();
            int patientCount = 0;//病历份数
            int paperCount = 0;//病历张数
            int rowIndex = 0;
            string prePackNo = string.Empty;
            this.dataGridView1.Rows.Clear();
            foreach (var item in lstRecPacks)
            {
                if (prePackNo != item.PACK_NO)
                {
                    rowIndex = this.dataGridView1.Rows.Add();
                    if (prePackNo != string.Empty)
                    {
                        this.dataGridView1.Rows[rowIndex-1].Cells[this.colPatientCount.Index].Value = patientCount;
                        this.dataGridView1.Rows[rowIndex-1].Cells[this.colPaperCount.Index].Value = paperCount;
                    }
                    patientCount = 0;
                    paperCount = 0;
                    prePackNo = item.PACK_NO;
                    if (szPackNo == item.PACK_NO)
                        this.dataGridView1.Rows[rowIndex].Cells[this.colCheckBox.Index].Value = true;
                    this.dataGridView1.Rows[rowIndex].Cells[this.col_PACKER.Index].Value = item.PACKER;
                    this.dataGridView1.Rows[rowIndex].Cells[this.col_CASE_NO.Index].Value = item.CASE_NO;
                    this.dataGridView1.Rows[rowIndex].Cells[this.col_PACK_NO.Index].Value = item.PACK_NO;
                    this.dataGridView1.Rows[rowIndex].Cells[this.col_PACK_TIME.Index].Value = item.PACK_TIME.ToShortDateString();
                }
                patientCount++;
                paperCount += item.PAPER_NUMBER;
                if (rowIndex == lstRecPacks.Count - 1)
                {
                    this.dataGridView1.Rows[rowIndex].Cells[this.colPatientCount.Index].Value = patientCount;
                    this.dataGridView1.Rows[rowIndex].Cells[this.colPaperCount.Index].Value = paperCount;
                }
            }

        }

        private void btnPrintNewCaseNo_Click(object sender, EventArgs e)
        {
            //生成新箱号
            int caseNo= RecPackAccess.Instance.GetNextCaseNo();
            this.txtCaseNo.Text = caseNo.ToString();
        }

        private void btnPringCaseNo_Click(object sender, EventArgs e)
        {

        }

        private void btnRemovePack_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return;
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells[this.colCheckBox.Index].Value != null
                    && item.Cells[this.colCheckBox.Index].Value.ToString().ToLower() == "true")
                {
                    string szPackNo = item.Cells[this.col_PACK_NO.Index].Value.ToString();
                    short shRet= RecPackAccess.Instance.UpdateCaseNo(szPackNo, string.Empty);
                    if (shRet == SystemData.ReturnValue.OK)
                    {
                        item.Cells[this.col_CASE_NO.Index].Value = string.Empty;
                    }
                }
            }
        }
    }
}
