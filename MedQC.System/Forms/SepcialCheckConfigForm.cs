// ***********************************************************
// 病案质控系统患者抽检分配信息对话框.
// Creator:yehui  Date:2014-02-09
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using EMRDBLib;

using EMRDBLib.DbAccess;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Systems
{
    public partial class SepcialCheckConfigForm : DockContentBase
    {
        public SepcialCheckConfigForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }

        private void ShowStatusMessage(string szMessage)
        {
            if (MainForm != null && !MainForm.IsDisposed)
                MainForm.ShowStatusMessage(szMessage);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.tooldtpDateTo.Value = DateTime.Now;
            this.tooldtpDateFrom.Value = DateTime.Now.AddMonths(-1);
            this.GetSpecialCheckConfigList();
            string szToolTip = string.Format("标记为质检完成的抽检分配不会显示在专家质控下拉选项中！");
            this.toolTip1.SetToolTip(this.pictureBox1, szToolTip);
            this.dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }
        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            this.GetSpecialCheckConfigList();
        }

        private void GetSpecialCheckConfigList()
        {
            this.dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在查询数据，请稍候...");
            this.dataGridView1.Rows.Clear();
            List<QcSpecialCheck> lstQcSpecialCheck = null;
            DateTime dtStartTime = new DateTime(this.tooldtpDateFrom.Value.Year,
                this.tooldtpDateFrom.Value.Month,
                this.tooldtpDateFrom.Value.Day, 0, 0, 0);
            DateTime dtEndTime = new DateTime(this.tooldtpDateTo.Value.Year,
                this.tooldtpDateTo.Value.Month,
                this.tooldtpDateTo.Value.Day, 23, 59, 59);
            short shRet = SpecialAccess.Instance.GetQCSpecialCheckList(dtStartTime, dtEndTime, ref lstQcSpecialCheck);
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
            {
                this.ShowStatusMessage(null);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            for (int patindex = 0; patindex < lstQcSpecialCheck.Count; patindex++)
            {
                QcSpecialCheck qcSpecialCheck = lstQcSpecialCheck[patindex];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, qcSpecialCheck);
                if (this.dataGridView1.Rows.Count <= 40)
                {
                    this.dataGridView1.Update();
                }
            }
            this.dataGridView1.EndEdit();
            this.ShowStatusMessage(null);
            this.dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        /// <summary>
        /// 将数据信息加载到DataGridView中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="qcWorkloadStatInfo"></param>
        private void SetRowData(DataGridViewRow row, EMRDBLib.QcSpecialCheck qcSpecialCheck)
        {
            if (row == null || qcSpecialCheck == null)
                return;
            if (row.DataGridView == null)
                return;
            row.Cells[this.colCreater.Index].Value = qcSpecialCheck.Creater;
            row.Cells[this.colCreateTime.Index].Value = qcSpecialCheck.CreateTime != qcSpecialCheck.DefaultTime ? qcSpecialCheck.CreateTime.ToString("yyyy-MM-dd") : "";
            row.Cells[this.colDischargeMode.Index].Value = qcSpecialCheck.DischargeMode;
            row.Cells[this.colEndTime.Index].Value = qcSpecialCheck.EndTime != qcSpecialCheck.DefaultTime ? qcSpecialCheck.EndTime.ToString("yyyy-MM-dd") : "";
            row.Cells[this.colName.Index].Value = qcSpecialCheck.Name;
            row.Cells[this.colPatientCondition.Index].Value = qcSpecialCheck.PatientCondition;
            row.Cells[this.colPatientCount.Index].Value = qcSpecialCheck.PatientCount.ToString();
            row.Cells[this.colPerCount.Index].Value = qcSpecialCheck.PerCount;
            row.Cells[this.colSpecialCount.Index].Value = qcSpecialCheck.SpecialCount;
            row.Cells[this.colStartTime.Index].Value = qcSpecialCheck.StartTime != qcSpecialCheck.DefaultTime ? qcSpecialCheck.StartTime.ToString("yyyy-MM-dd") : "";
            row.Cells[this.colChecked.Index].Value = qcSpecialCheck.Checked;
            row.Tag = qcSpecialCheck;
        }

        private void tsbSelect_Click(object sender, EventArgs e)
        {
        }
        private void tooltbPatientCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((ToolStripTextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((ToolStripTextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.UpdateQcSpecialCheck();
        }

        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            SpecialQCForm form = new SpecialQCForm(this.MainForm);
            form.ShowDialog();
            if (form.QcSpecialCheck.ConfigID != string.Empty)
            {
                int rowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                this.SetRowData(row, form.QcSpecialCheck);
            }
        }

        private void toolbtnUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateQcSpecialCheck();
        }

        private void UpdateQcSpecialCheck()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBoxEx.ShowWarning("未选中项，无法修改！");
                return;
            }
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            QcSpecialCheck qcSpecialCheck = row.Tag as QcSpecialCheck;
            SpecialQCForm form = new SpecialQCForm(this.MainForm);
            form.QcSpecialCheck = qcSpecialCheck;
            form.ShowDialog();
            this.SetRowData(row, form.QcSpecialCheck);
        }

        private void toolbtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBoxEx.ShowWarning("未选中要删除的项!");
                return;
            }
            QcSpecialCheck qcSpecialCheck = this.dataGridView1.SelectedRows[0].Tag as QcSpecialCheck;
            if (qcSpecialCheck == null)
            {
                MessageBoxEx.ShowError("无法获取专家质控分配信息，删除失败!");
                return;
            }
            //判断此专家分配信息对应的病人是否已抽检
            //有则不允许删除，只允许不显示

            bool bChecked = false;
            short shRet = SpecialAccess.Instance.IsQCSpecialChecked(qcSpecialCheck.ConfigID, ref bChecked);
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("删除失败!");
                return;
            }
            if (bChecked)
            {
                MessageBoxEx.ShowMessage("当前抽检分配中存在已质检过的病人,不允许删除，您可以设置为质检完成!");
                return;
            }
            DialogResult result = MessageBoxEx.ShowConfirm("是否删除当前记录？");
            if (result == DialogResult.Cancel)
                return;
            shRet = SpecialAccess.Instance.DeleteQCSpecialCheck(qcSpecialCheck.ConfigID);
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("删除失败!");
                return;
            }
            MessageBoxEx.ShowMessage("删除成功!");
            this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);

        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            QcSpecialCheck qcSpecialCheck = row.Tag as QcSpecialCheck;
            short shRet = SpecialAccess.Instance.UpdateQCSpeicalCheckState(qcSpecialCheck.ConfigID, (bool)row.Cells[0].Value ? "1" : "0");
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("更新状态失败！");
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);

        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}