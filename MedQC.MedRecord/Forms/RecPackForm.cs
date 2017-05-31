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
using Heren.MedQC.Utilities.Dialogs;
using System.IO;

namespace Heren.MedQC.MedRecord
{
    public partial class RecPackForm : DockContentBase
    {
        public RecPackForm(MainForm parent)
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
            this.txtDocID.Focus();
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            this.txtDocID.Focus();
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

        private void btnNewPackNo_Click(object sender, EventArgs e)
        {
            this.txt_PACK_NO.Focus();
            this.txt_PACK_NO.Text = this.MakePackNo();
            this.ClearControl();
        }

        private void ClearControl()
        {
            this.txtDocID.Text = string.Empty;
            this.dataGridView1.Rows.Clear();
            this.txt_DEPT_NAME.Text = string.Empty;
            this.txt_DISCHARGE_TIME.Text = string.Empty;
            this.txt_HOSPITAL_DISTRICT.Text = string.Empty;
            this.txt_PACKER.Text = string.Empty;
            this.txt_PaperCount.Text = string.Empty;
            this.txt_PatientCount.Text = string.Empty;
            this.txt_PATIENT_ID.Text = string.Empty;
            this.txt_PATIENT_NAME.Text = string.Empty;
            this.txt_PACKER.Text = string.Empty;
            this.lbl_PaperCount.Text = string.Empty;
            this.lbl_PackResult.Text = "未扫描";
        }

        /// <summary>
        /// 生成包号
        /// </summary>
        /// <returns></returns>
        public string MakePackNo()
        {
            //取工号，每个工号起始数字不同
            int nBegin = 0;
#if DEBUG
            nBegin = 1000;
#endif 
            string szUserID = SystemParam.Instance.UserInfo.ID;
            //从数据库获得最新包号，然后加1
            List<RecPack> lstRecPacks = new List<RecPack>();
            short shRet = RecPackAccess.Instance.GetRecPacks(szUserID, ref lstRecPacks);
            if (lstRecPacks != null && lstRecPacks.Count > 0)
            {
                RecPack recPack = lstRecPacks.OrderByDescending(m => m.PACK_NO).First();
                nBegin = int.Parse(recPack.PACK_NO) + 1;
                return nBegin.ToString();
            }
            return nBegin.ToString();
        }
        private void RecPackForm_Activated(object sender, EventArgs e)
        {
            this.txtDocID.Focus();
        }

        private void txtDocID_TextChanged(object sender, EventArgs e)
        {
            
            string szDocID = this.txtDocID.Text;
            MedDocInfo docInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(szDocID, ref docInfo);
            if (docInfo == null)
            {
                return;
            }
            //显示文本框信息
            string szPatientID = docInfo.PATIENT_ID;
            string szVisitNo = docInfo.VISIT_ID;
            string szPatientName = docInfo.PATIENT_NAME;
            PatVisitInfo patVisitInfo = null;
            shRet = PatVisitAccess.Instance.GetPatVisit(szPatientID, szVisitNo, ref patVisitInfo);
            if (patVisitInfo != null && patVisitInfo.DISCHARGE_TIME != patVisitInfo.DefaultTime)
                this.txt_DISCHARGE_TIME.Text = patVisitInfo.DISCHARGE_TIME.ToShortDateString();
            this.txt_PATIENT_ID.Text = docInfo.PATIENT_ID;
            this.txt_PATIENT_NAME.Text = docInfo.PATIENT_NAME;
            this.txt_DEPT_NAME.Text = docInfo.DEPT_NAME;
            //显示纸质病历列表
            List<MedDocInfo> lstMedDocInfos = null;
            shRet = EmrDocAccess.Instance.GetDocList(szPatientID, szVisitNo, ref lstMedDocInfos);
            if (lstMedDocInfos == null)
                return;
            List<RecPaper> lstRecPapers = new List<RecPaper>();
            shRet = RecPaperAccess.Instance.GetRecPapers(szPatientID, szVisitNo, ref lstRecPapers);
            string[] arrSignKeyName = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.SignKeyName].Split('|');
            int rowIndex = 0;
            this.dataGridView1.Rows.Clear();
            //张数
            int paperNumber = 0;
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
                                //病历确认接收后才算一张
                                paperNumber++;
                                if (recPaper.PAPER_STATE == SystemData.PaperState.Receive)
                                {
                                    row.Cells[this.colCheckBox.Index].Value = true;
                                }
                                if (!string.IsNullOrEmpty(recPaper.IMAGE_FRONTAGE))
                                {
                                    row.Cells[this.col_IMAGE_FRONTAGE.Index].Value = MedQC.MedRecord.Properties.Resources.docuemt;
                                    row.Cells[this.col_IMAGE_FRONTAGE.Index].Tag = recPaper.IMAGE_FRONTAGE;
                                }
                                if (!string.IsNullOrEmpty(recPaper.IMAGE_OPPOSITE))
                                {
                                    row.Cells[this.col_IMAGE_OPPOSITE.Index].Value = MedQC.MedRecord.Properties.Resources.docuemt;
                                    row.Cells[this.col_IMAGE_OPPOSITE.Index].Tag = recPaper.IMAGE_OPPOSITE;
                                }

                                row.Cells[this.colCheckBox.Index].Tag = recPaper;
                            }
                        }
                    }
                }
            }
            //查询是否已存在打包信息
            RecPack recPack = null;
            shRet = RecPackAccess.Instance.GetRecPack(szPatientID, szVisitNo, ref recPack);
            if (recPack == null)
            {
                if (this.txt_PACK_NO.Text == string.Empty)
                {
                    MessageBoxEx.ShowMessage("包号未设置");
                    return;
                }
                recPack = new RecPack();
                recPack.CASE_NO = string.Empty;
                recPack.DISCHARGE_TIME = patVisitInfo.DISCHARGE_TIME;
                recPack.HOSPITAL_DISTRICT = string.Empty;//院区字段不明
                recPack.PACKER = SystemParam.Instance.UserInfo.Name;
                recPack.PACKER_ID = SystemParam.Instance.UserInfo.ID;
                recPack.PACK_ID = recPack.MakeID();
                recPack.PACK_NO = this.txt_PACK_NO.Text;
                recPack.PACK_TIME = SysTimeHelper.Instance.Now;
                recPack.PAPER_NUMBER = paperNumber;
                recPack.PATIENT_ID = szPatientID;
                recPack.PATIENT_NAME = szPatientName;
                recPack.VISIT_ID = patVisitInfo.VISIT_ID;
                recPack.VISIT_NO = patVisitInfo.VISIT_NO;
                shRet = RecPackAccess.Instance.Insert(recPack);
            }
            else
            {
                recPack.PACK_TIME = SysTimeHelper.Instance.Now;
                recPack.PACKER = SystemParam.Instance.UserInfo.Name;
                recPack.PACKER_ID = SystemParam.Instance.UserInfo.ID;
                recPack.PAPER_NUMBER = paperNumber;
                shRet = RecPackAccess.Instance.Update(recPack);
                this.txt_PACK_NO.Text = recPack.PACK_NO;
            }
            if(shRet!=SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("打包失败");
                return;
            }
            this.lbl_PackResult.Text = "打包成功";
            this.txt_PACKER.Text = recPack.PACKER;
            this.lbl_PaperCount.Text = paperNumber.ToString();
            this.txt_HOSPITAL_DISTRICT.Text = recPack.HOSPITAL_DISTRICT;
            this.CalPaperCount(recPack.PACK_NO);
        }
        private void CalPaperCount(string szPackNo)
        {
            List<RecPack> lstRecPack = null;
            short shRet = RecPackAccess.Instance.GetRecPacksByPackNo(szPackNo, ref lstRecPack);
            if (lstRecPack == null || lstRecPack.Count <= 0)
                return;
            int patientCount = lstRecPack.Count;
            int paperCount= lstRecPack.Sum(m => m.PAPER_NUMBER);
            this.txt_PatientCount.Text = patientCount.ToString();
            this.txt_PaperCount.Text = paperCount.ToString();
        }

        private void txt_PACK_NO_TextChanged(object sender, EventArgs e)
        {
            string szPackNo = this.txt_PACK_NO.Text.Trim();
            if (string.IsNullOrEmpty(szPackNo))
                return;
            this.txt_PaperCount.Text = string.Empty;
            this.txt_PatientCount.Text = string.Empty;
            this.CalPaperCount(szPackNo);
        }

        private void btnModifyCaseNo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_ChangePackNo.Text))
            {
                MessageBoxEx.ShowMessage("包号未设置");
                return;
            }
            if (string.IsNullOrEmpty(this.txt_ChangeCaseNo.Text))
            {
                MessageBoxEx.ShowMessage("箱号未设置");
                return;
            }
            string szPackNo = this.txt_ChangePackNo.Text;
            string szCaseNo = this.txt_ChangeCaseNo.Text;
            short shRet= RecPackAccess.Instance.UpdateCaseNo(szPackNo, szCaseNo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("更新失败");
                return;
            }
            MessageBoxEx.ShowMessage("更新成功");
            return;
        }
    }
}
