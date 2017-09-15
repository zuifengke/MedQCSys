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
    public partial class RecPackSearchForm : DockContentBase
    {
        public RecPackSearchForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = false;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dataGridView1.Font = new Font("宋体", 10.5F);
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (item.Index == this.col_CASE_NO.Index
                    || item.Index == this.col_PACK_NO.Index)
                    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (item.Index == this.col_PAPER_NUMBER.Index)
                    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
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

            string szUserID = SystemParam.Instance.UserInfo.USER_ID;
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
            this.txt_PATIENT_ID.Text = docInfo.PATIENT_ID;
            SearchRecPack();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRecPack();
        }

        private void SearchRecPack()
        {
            this.dataGridView1.Rows.Clear();
            string szCaseNo = this.txt_CASE_NO.Text.Trim();
            string szPackNo = this.txt_PACK_NO.Text.Trim();
            string szPatientID = this.txt_PATIENT_ID.Text.Trim();
            if (string.IsNullOrEmpty(szCaseNo)
                && string.IsNullOrEmpty(szPackNo)
                && string.IsNullOrEmpty(szPatientID))
            {
                return;
            }
            List<RecPack> lstRecPacks = null;
            short shRet = RecPackAccess.Instance.GetRecPacks(szCaseNo, szPackNo, szPatientID, ref lstRecPacks);
            if (lstRecPacks == null || lstRecPacks.Count <= 0)
            {
                MessageBoxEx.ShowMessage("未查询到结果");
                return;
            }
                
            lstRecPacks = lstRecPacks.OrderByDescending(m => m.PACK_TIME).ToList();
            int paperCount = 0;
            int rowIndex = 0;
            foreach (var item in lstRecPacks)
            {
                rowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                row.Cells[this.colOrderNo.Index].Value = rowIndex + 1;
                row.Cells[this.col_CASE_NO.Index].Value = item.CASE_NO;
                if (item.DISCHARGE_TIME != item.DefaultTime)
                    row.Cells[this.col_DISCHARGE_TIME.Index].Value = item.DISCHARGE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_PAPER_NUMBER.Index].Value = item.PAPER_NUMBER;
                row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;
                row.Cells[this.col_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                row.Cells[this.col_PACK_NO.Index].Value = item.PACK_NO;
                row.Cells[this.col_PACKER.Index].Value = item.PACKER;
                row.Cells[this.col_PACK_TIME.Index].Value = item.PACK_TIME.ToString("yyyy-MM-dd HH:mm");
                paperCount += item.PAPER_NUMBER;
            }
            this.lbl_Result.Text = string.Format("共{0}份，共{1}张", lstRecPacks.Count, paperCount);
        }
    }
}
