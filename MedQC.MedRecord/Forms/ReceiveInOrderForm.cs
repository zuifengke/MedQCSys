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
using Heren.MedQC.Core;
using System.IO;

namespace Heren.MedQC.MedRecord
{
    public partial class ReceiveInOrderForm : DockContentBase
    {
        public ReceiveInOrderForm(MainForm parent)
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
            string szDocID = this.txtDocID.Text.Trim();
            MedDocInfo docInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(szDocID, ref docInfo);
            PatVisitInfo patVisit = null;
            if (docInfo == null)
            {
                string szPatientID = this.txtDocID.Text.Trim();
                List<PatVisitInfo> lstPatVisitInfo = null;
                PatVisitAccess.Instance.GetPatVisitInfos(szPatientID, ref lstPatVisitInfo);
                if (lstPatVisitInfo == null)
                    return;
                patVisit = lstPatVisitInfo.LastOrDefault();
            }
            else
            {
                string szPatientID = docInfo.PATIENT_ID;
                string szVisitNo = docInfo.VISIT_ID;//文书VisitID存了 VisitNo
                shRet = PatVisitAccess.Instance.GetPatVisit(szPatientID, szVisitNo, ref patVisit);
            }
            if (patVisit == null)
                return;
            this.txt_DEPT_NAME.Text = patVisit.DEPT_NAME;
            this.txt_PATIENT_ID.Text = patVisit.PATIENT_ID;
            this.txt_PATIENT_NAME.Text = patVisit.PATIENT_NAME;
            this.txt_DISCHARGE_TIME.Text = patVisit.DISCHARGE_TIME.ToShortDateString();
            List<MedDocInfo> lstMedDocInfos = null;
            shRet = EmrDocAccess.Instance.GetDocList(patVisit.PATIENT_ID, patVisit.VISIT_NO, ref lstMedDocInfos);
            if (lstMedDocInfos == null)
                return;
            List<RecPaper> lstRecPapers = new List<RecPaper>();
            shRet = RecPaperAccess.Instance.GetRecPapers(patVisit.PATIENT_ID, patVisit.VISIT_NO, ref lstRecPapers);
            string[] arrSignKeyName = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.SignKeyName].Split('|');
            int rowIndex = 0;
            this.dataGridView1.Rows.Clear();
            foreach (var item in arrSignKeyName)
            {
                foreach (var doc in lstMedDocInfos)
                {
                    if (doc.DOC_TITLE.Contains(item))
                    {
                        rowIndex = this.dataGridView1.Rows.Add();
                        DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                        row.Cells[this.colDocTitle.Index].Value = doc.DOC_TITLE;
                        row.Cells[this.colRecordTime.Index].Value = doc.RECORD_TIME.ToString("yyyy-MM-dd HH:mm");
                        row.Tag = doc;
                        if (lstRecPapers != null && lstRecPapers.Count > 0)
                        {
                            var recPaper = lstRecPapers.Where(m => m.DOC_ID == doc.DOC_ID).FirstOrDefault();
                            if (recPaper != null)
                            {
                                if (recPaper.PAPER_STATE == SystemData.PaperState.Receive)
                                {
                                    row.Cells[this.colCheckBox.Index].Value = true;

                                }
                                if (!string.IsNullOrEmpty(recPaper.IMAGE_FRONTAGE))
                                {
                                    row.Cells[this.col_IMAGE_FRONTAGE.Index].Value = Heren.MedQC.MedRecord.Properties.Resources.docuemt;
                                    row.Cells[this.col_IMAGE_FRONTAGE.Index].Tag = recPaper.IMAGE_FRONTAGE;
                                }
                                if (!string.IsNullOrEmpty(recPaper.IMAGE_OPPOSITE))
                                {
                                    row.Cells[this.col_IMAGE_OPPOSITE.Index].Value = Heren.MedQC.MedRecord.Properties.Resources.docuemt;
                                    row.Cells[this.col_IMAGE_OPPOSITE.Index].Tag = recPaper.IMAGE_OPPOSITE;
                                }
                                row.Cells[this.colCheckBox.Index].Tag = recPaper;
                            }
                        }
                    }
                }
            }

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
            if (e.ColumnIndex == this.col_IMAGE_FRONTAGE.Index
                || e.ColumnIndex == this.col_IMAGE_OPPOSITE.Index)
            {
                string szImageName = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as string;
                RecPaper recPaper = row.Cells[this.colCheckBox.Index].Tag as RecPaper;
                if (string.IsNullOrEmpty(szImageName))
                    return;
                string szPath = szImageName;

                GlobalMethods.UI.SetCursor(this.dataGridView1, Cursors.WaitCursor);
                szPath = RecPaperAccess.Instance.GetImageLocalFile(szImageName);
                if (!File.Exists(szPath))
                {
                    short shRet = RecPaperAccess.Instance.GetImageFromFtp(recPaper, szImageName, ref szPath);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show("预览图片失败");
                        return;
                    }
                }
                GlobalMethods.UI.SetCursor(this.dataGridView1, Cursors.Default);

                Heren.MedQC.Utilities.Dialogs.ImageViewerDialog diglog = new Utilities.Dialogs.ImageViewerDialog();
                diglog.ImagePath = szPath;
                diglog.ShowDialog();
            }
        }
        private string GetRecPaperRemoteDir(RecPaper recPaperInfo)
        {
            //链接病人根目录
            StringBuilder ftpPath = new StringBuilder();
            ftpPath.Append("/RECPAPER");

            if (recPaperInfo == null || recPaperInfo.PATIENT_ID == null)
                return ftpPath.ToString();

            string szPatientID = recPaperInfo.PATIENT_ID.PadLeft(10, '0');
            for (int index = 0; index < 10; index += 2)
            {
                ftpPath.Append("/");
                ftpPath.Append(szPatientID.Substring(index, 2));
            }

            //链接就诊目录
            ftpPath.Append("/");
            ftpPath.Append("IP_");
            ftpPath.Append(recPaperInfo.VISIT_ID);
            ftpPath.Append("/");
            return ftpPath.ToString();
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
    }
}
