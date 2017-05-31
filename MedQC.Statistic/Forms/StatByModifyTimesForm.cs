// ***********************************************************
// 病历修改次数统计显示窗口.
// Creator:YangMingkun  Date:2009-11-13
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

using System.Collections;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Statistic
{
    public partial class StatByModifyTimesForm : DockContentBase
    {
        public StatByModifyTimesForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dgvMainList.Font = new Font("宋体", 10.5f);
            this.dgvDetailList.Font = new Font("宋体", 10.5f);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dtpStatTimeEnd.Value = DateTime.Now;
            this.dtpStatTimeBegin.Value = DateTime.Now.AddDays(-1);
        }

        public override void OnRefreshView()
        {
            this.Update();
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
             DeptInfo deptInfo = this.cboDeptName.SelectedItem as  DeptInfo;
            string szDeptCode = null;
            if (deptInfo != null)
                szDeptCode = deptInfo.DEPT_CODE;
            if (szDeptCode == null)
            {
                MessageBoxEx.Show("请选择一个科室！", MessageBoxIcon.Warning);
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在按科室统计病历修改次数，请稍候...");
            this.dgvMainList.Rows.Clear();
            this.dgvDetailList.Rows.Clear();
            List< UserInfo> lstUserInfo = null;
            short shRet =UserAccess.Instance.GetDeptUserList(szDeptCode, ref lstUserInfo);
            if (shRet != SystemData.ReturnValue.OK || lstUserInfo == null)
            {
                this.ShowStatusMessage(null);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
             DateTime dtBegin = this.dtpStatTimeBegin.Value;
            DateTime dtEnd = this.dtpStatTimeEnd.Value;
            for (int index = 0; index < lstUserInfo.Count; index++)
            {
                this.ShowStatusMessage(string.Format("正在查询{0}第{1}/{2}患者病历修改次数，请稍候...", deptInfo.DEPT_NAME,index + 1, lstUserInfo.Count));
                 UserInfo userInfo = lstUserInfo[index];
                List< MedDocInfo> lstDocInfo = null;
                shRet =EmrDocAccess.Instance.GetDocInfos(userInfo.ID, DateTime.Parse(dtpStatTimeBegin.Value.ToString("yyyy-M-d 00:00:00")),
                DateTime.Parse(dtpStatTimeEnd.Value.ToString("yyyy-M-d 23:59:59")), ref lstDocInfo);
                if (shRet != SystemData.ReturnValue.OK)
                    continue;
                if (lstDocInfo == null)
                    continue;

                this.BindDocList(lstDocInfo);
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 把查询结果绑定到列表
        /// </summary>
        /// <param name="lstDocInfo">病历数据列表</param>
        private void BindDocList(List< MedDocInfo> lstDocInfo)
        {
            Hashtable htDocInfo = new Hashtable();
            List< MedDocInfo> docInfoList = null;
            for (int index = 0; index < lstDocInfo.Count; index++)
            {
                 MedDocInfo docInfo = lstDocInfo[index];
                if (!htDocInfo.ContainsKey(docInfo.DOC_SETID))
                {
                    docInfoList = new List< MedDocInfo>();
                    docInfoList.Add(docInfo);
                    htDocInfo.Add(docInfo.DOC_SETID, docInfoList);
                }
                else
                {
                    docInfoList = htDocInfo[docInfo.DOC_SETID] as List< MedDocInfo>;
                    if (docInfoList == null)
                        continue;
                    htDocInfo.Remove(docInfo.DOC_SETID);
                    docInfoList.Add(docInfo);
                    htDocInfo.Add(docInfo.DOC_SETID, docInfoList);
                }
            }
            foreach (DictionaryEntry dicEntry in htDocInfo)
            {
               docInfoList = dicEntry.Value as List< MedDocInfo>;
               if (docInfoList == null || docInfoList.Count <= 0)
                    continue;
                 MedDocInfo docInfo = docInfoList[docInfoList.Count - 1];
                int rowIndex = this.dgvMainList.Rows.Add();
                DataGridViewRow row = this.dgvMainList.Rows[rowIndex];
                row.Cells[this.colDocTitle.Index].Value = docInfo.DOC_TITLE;
                row.Cells[this.colModifyName.Index].Value = docInfo.MODIFIER_NAME;
                row.Cells[this.colModifyTimes.Index].Value = docInfoList.Count;
                row.Cells[this.colCreatorName.Index].Value = docInfo.CREATOR_NAME;
                row.Cells[this.colPatientName.Index].Value = docInfo.PATIENT_NAME;
                row.Tag = docInfo;
            }
        }

        /// <summary>
        /// 根据文档集ID查询病历列表并显示在列表中
        /// </summary>
        /// <param name="szDocSetID">文档集ID</param>
        /// <param name="szModifierID">修改者ID</param>
        private void LoadDocList(string szDocSetID, string szModifierID)
        {
            this.dgvDetailList.Rows.Clear();
            if (string.IsNullOrEmpty(szDocSetID))
                return;
            List< MedDocInfo> lstDocInfo = null;
            short shRet =EmrDocAccess.Instance.GetDocInfoBySetID(szDocSetID, ref lstDocInfo);
            if (shRet != SystemData.ReturnValue.OK || lstDocInfo == null)
                return;

            for (int index = 0; index < lstDocInfo.Count; index++)
            {
                 MedDocInfo docInfo = lstDocInfo[index];
                if (docInfo.DOC_VERSION == 1)
                    continue;
                if (docInfo.MODIFIER_ID != szModifierID)
                    continue;

                int rowIndex = this.dgvDetailList.Rows.Add();
                DataGridViewRow row = this.dgvDetailList.Rows[rowIndex];
                row.Cells[this.colModifyDate.Index].Value = docInfo.MODIFY_TIME;
                row.Cells[this.colDeptName.Index].Value = docInfo.DEPT_NAME;
                row.Cells[this.colCreateTime.Index].Value = docInfo.DOC_TIME;
                row.Tag = docInfo;
            }
        }

        private void dgvMainList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (this.dgvMainList.SelectedRows.Count <= 0)
            {
                this.dgvDetailList.SuspendLayout();
                this.dgvDetailList.Rows.Clear();
                this.dgvDetailList.ResumeLayout();
                return;
            }
            this.ShowStatusMessage("正在下载病历文档数据，请稍候...");
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

             MedDocInfo docInfo = this.dgvMainList.SelectedRows[0].Tag as  MedDocInfo;
            if (docInfo != null)
                this.LoadDocList(docInfo.DOC_SETID, docInfo.MODIFIER_ID);
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dgvDocList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

             MedDocInfo docInfo = this.dgvDetailList.Rows[e.RowIndex].Tag as  MedDocInfo;
            if (docInfo == null)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载并打开病历，请稍候...");
            this.MainForm.OpenDocument(docInfo);
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuOpenDoc_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            DataGridViewRow selectRow = this.dgvDetailList.SelectedRows[0];
            if (selectRow == null)
                return;

             MedDocInfo docInfo = selectRow.Tag as  MedDocInfo;
            if (docInfo == null)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载并打开病历，请稍候...");
            this.MainForm.OpenDocument(docInfo);
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);

        }

        private void mnuOpenAllDoc_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (this.dgvDetailList.Rows.Count <= 0)
                return;
            DataGridViewRow selectRow = this.dgvDetailList.SelectedRows[0];
            if (selectRow == null)
                return;

             MedDocList lstDocInfo = new  MedDocList();
             MedDocInfo docInfo =null;
            for (int index = 0; index < this.dgvDetailList.Rows.Count; index++)
            {
                selectRow = this.dgvDetailList.Rows[index];
                docInfo = selectRow.Tag as  MedDocInfo;
                if (docInfo == null)
                    continue;
                lstDocInfo.Add(docInfo);
            }
            if (lstDocInfo.Count <= 0)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载并打开病历，请稍候...");
            this.MainForm.OpenDocument(lstDocInfo);
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dgvMainList.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            Hashtable htNoExportColunms = new Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dgvMainList, "病历修改次数");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}