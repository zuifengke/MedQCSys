// ***********************************************************
// 病案质控系统按质控者的工作量统计窗口.
// Creator:YangMingkun  Date:2009-11-13
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
using EMRDBLib;

using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using EMRDBLib.DbAccess;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.MedRecord
{
    public partial class MrScoreWorkloadStatisticForm : DockContentBase
    {
        public MrScoreWorkloadStatisticForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dtpTimeEnd.Value = DateTime.Now;
            this.dtpTimeBegin.Value = DateTime.Now.AddDays(-1);
            this.ShowStatusMessage("正在下载用户列表，请稍候...");
            if (!InitControlData.InitcboUserList(ref this.cboUserList))
            {
                MessageBoxEx.Show("用户列表下载失败！");
            }
            this.dtpTimeBegin.Value = DateTime.Now.AddMonths(-1);
            this.dtpTimeEnd.Value = DateTime.Now;
            this.ShowStatusMessage(null);
        }

        private List<UserInfo> ListUserInfo { get; set; }


        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "工作量统计清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("工作量统计清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("工作量统计清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "起始日期")
            {
                value = this.dtpTimeBegin.Value;
                return true;
            }
            if (name == "截止日期")
            {
                value = this.dtpTimeEnd.Value;
                return true;
            }
            return false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string szCheckerID = string.Empty;
            if (this.cboUserList.Text != string.Empty
                && this.cboUserList.SelectedItem != null)
            {
                UserInfo user = this.cboUserList.SelectedItem as UserInfo;
                szCheckerID = user.ID;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在统计工作量，请稍候...");
            this.dataGridView1.Rows.Clear();
            DateTime dtHosDateTimeBegin = DateTime.Parse(this.dtpTimeBegin.Value.ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtHosDateTimeEnd = DateTime.Parse(this.dtpTimeEnd.Value.ToString("yyyy-MM-dd 23:59:59"));
            List<QCScore> lstQcScores = null;
            short shRet = QcScoreAccess.Instance.GetQcScores(dtHosDateTimeBegin, dtHosDateTimeEnd, szCheckerID, ref lstQcScores);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND
                )
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("查询数据失败！");
                return;
            }
            if (lstQcScores == null || lstQcScores.Count <= 0)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("没有符合条件的数据！", MessageBoxIcon.Information);
                return;
            }
            string szPreCheckName = string.Empty;
            int nOrderNo = 0;
            for (int index = 0; index < lstQcScores.Count; index++)
            {
                EMRDBLib.QCScore qcScore = lstQcScores[index];
                if (string.IsNullOrEmpty(qcScore.HOS_QCMAN_ID))
                    continue;
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                if (szPreCheckName == string.Empty||szPreCheckName!=qcScore.HOS_QCMAN)
                {
                    szPreCheckName = qcScore.HOS_QCMAN;
                    nOrderNo = 0;
                }
                nOrderNo++;
                row.Cells[this.colOrderNo.Index].Value = nOrderNo;
                row.Cells[this.col_DEPT_NAME.Index].Value = qcScore.DEPT_NAME;
                row.Cells[this.col_HOS_ASSESS.Index].Value = qcScore.HOS_ASSESS;
                row.Cells[this.col_HOS_DATE.Index].Value = qcScore.HOS_DATE.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_PATIENT_ID.Index].Value = qcScore.PATIENT_ID;
                row.Cells[this.col_PATIENT_NAME.Index].Value = qcScore.PATIENT_NAME;
                row.Cells[this.col_SUBMIT_DOCTOR.Index].Value = qcScore.SUBMIT_DOCTOR;
                row.Cells[this.col_VISIT_ID.Index].Value = qcScore.VISIT_ID;
                row.Cells[this.col_HOS_QCMAN.Index].Value = qcScore.HOS_QCMAN;
                row.Tag = qcScore;
            }
           
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);

        }
        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            GridViewHelper.MergeColumns(this.dataGridView1, e, 0);
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "按工作量统计清单");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

    }
}