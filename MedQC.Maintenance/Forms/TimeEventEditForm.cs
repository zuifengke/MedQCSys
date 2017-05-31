// ***********************************************************
// 病历编辑器配置管理系统时效事件编辑窗口.
// Creator:YangMingkun  Date:2012-1-3
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Controls.TableView;
using MedQCSys.Dialogs;
using EMRDBLib.Entity;
using EMRDBLib.DbAccess;
using MedQCSys.DockForms;
using MedQCSys;
using EMRDBLib;
using MedDocSys.QCEngine.TimeCheck;

namespace Heren.MedQC.Maintenance
{
    internal partial class TimeEventEditForm : DockContentBase
    {
        public TimeEventEditForm(MainForm mainForm)
            : base(mainForm)
        {
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            this.OnRefreshView();
        }

        /// <summary>
        /// 刷新当前窗口的数据显示
        /// </summary>
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (!this.CheckModifiedData())
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            this.Update();
            this.LoadGridViewData();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 读取数据库,装载当前DataGridView各行数据
        /// </summary>
        private void LoadGridViewData()
        {
            this.dataGridView1.Rows.Clear();
            List<TimeQCEvent> lstTimeQCEvents = null;
            short shRet =TimeQCEventAccess.Instance.GetTimeQCEvents(ref lstTimeQCEvents);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("病历时效事件列表下载失败!");
                return;
            }
            if (lstTimeQCEvents == null || lstTimeQCEvents.Count <= 0)
                return;

            //先将事件对象加载到哈希表
            //以便用来生成依赖事件对应的名字
            Hashtable htTimeEvent = new Hashtable();
            for (int index = 0; index < lstTimeQCEvents.Count; index++)
            {
                TimeQCEvent timeQCEvent = lstTimeQCEvents[index];
                if (timeQCEvent == null)
                    continue;
                if (!htTimeEvent.Contains(timeQCEvent.EventID))
                    htTimeEvent.Add(timeQCEvent.EventID, timeQCEvent.EventName);
            }

            for (int index = 0; index < lstTimeQCEvents.Count; index++)
            {
                TimeQCEvent timeQCEvent = lstTimeQCEvents[index];
                if (timeQCEvent == null)
                    continue;

                string szDependEvent = timeQCEvent.DependEvent;
                if (!string.IsNullOrEmpty(szDependEvent))
                {
                    if (htTimeEvent.Contains(szDependEvent))
                        szDependEvent = (string)htTimeEvent[szDependEvent];
                }
                timeQCEvent.DependEventName = szDependEvent;

                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, timeQCEvent);
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
        }

        /// <summary>
        /// 检查是否有未保存的数据
        /// </summary>
        /// <returns>bool</returns>
        public override bool HasUncommit()
        {
            int nCount = this.dataGridView1.Rows.Count;
            if (nCount <= 0)
                return false;
            for (int index = 0; index < nCount; index++)
            {
                DataTableViewRow row = this.dataGridView1.Rows[index];
                if (this.dataGridView1.IsDeletedRow(row))
                    return true;
                if (this.dataGridView1.IsNewRow(row))
                    return true;
                if (this.dataGridView1.IsModifiedRow(row))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 保存当前窗口的数据修改
        /// </summary>
        /// <returns>bool</returns>
        public override bool CommitModify()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            int index = 0;
            int count = 0;
            short shRet = SystemData.ReturnValue.OK;
            while (index < this.dataGridView1.Rows.Count)
            {
                DataTableViewRow row = this.dataGridView1.Rows[index];
                bool bIsDeletedRow = this.dataGridView1.IsDeletedRow(row);
                shRet = this.SaveRowData(row);
                if (shRet == SystemData.ReturnValue.OK)
                    count++;
                else if (shRet == SystemData.ReturnValue.FAILED)
                    break;
                if (!bIsDeletedRow) index++;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            string szMessageText = null;
            if (shRet == SystemData.ReturnValue.FAILED)
                szMessageText = string.Format("保存中止,已保存{0}条记录!", count);
            else
                szMessageText = string.Format("保存成功,已保存{0}条记录!", count);
            MessageBoxEx.Show(szMessageText, MessageBoxIcon.Information);
            return shRet == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="eventInfo">绑定的数据</param>
        private void SetRowData(DataTableViewRow row, TimeQCEvent timeQCEvent)
        {
            if (row == null || row.Index < 0 || timeQCEvent == null)
                return;
            row.Tag = timeQCEvent;
            row.Cells[this.colEventID.Index].Value = timeQCEvent.EventID;
            row.Cells[this.colEventName.Index].Value = timeQCEvent.EventName;
            row.Cells[this.colSqlText.Index].Value = timeQCEvent.SqlText;
            row.Cells[this.colCondition.Index].Value = timeQCEvent.SqlCondition;
            row.Cells[this.colDependEvent.Index].Tag = timeQCEvent.DependEvent;
            row.Cells[this.colDependEvent.Index].Value = timeQCEvent.DependEventName;
        }

        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="configInfo">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref TimeQCEvent timeQCEvent)
        {
            if (row == null || row.Index < 0)
                return false;
            timeQCEvent = new TimeQCEvent();

            object cellValue = row.Cells[this.colEventID.Index].Value;
            if (cellValue != null)
                timeQCEvent.EventID = cellValue.ToString();

            if (this.dataGridView1.IsDeletedRow(row))
                return true;

            cellValue = row.Cells[this.colEventName.Index].Value;
            if (cellValue == null || cellValue.ToString().Trim() == string.Empty)
            {
                this.dataGridView1.SelectRow(row);
                MessageBoxEx.Show("您必须输入事件名称!");
                return false;
            }
            timeQCEvent.EventName = cellValue.ToString();

            cellValue = row.Cells[this.colSqlText.Index].Value;
            if (cellValue == null || cellValue.ToString().Trim() == string.Empty)
            {
                this.dataGridView1.SelectRow(row);
                MessageBoxEx.Show("您必须输入事件数据来源SQL!");
                return false;
            }
            timeQCEvent.SqlText = cellValue.ToString();

            cellValue = row.Cells[this.colCondition.Index].Value;
            if (cellValue == null || cellValue.ToString().Trim() == string.Empty)
            {
                this.dataGridView1.SelectRow(row);
                MessageBoxEx.Show("您必须输入事件数据来源SQL条件!");
                return false;
            }
            timeQCEvent.SqlCondition = cellValue.ToString();

            cellValue = row.Cells[this.colDependEvent.Index].Tag;
            if (cellValue != null)
                timeQCEvent.DependEvent = cellValue.ToString();

            cellValue = row.Cells[this.colDependEvent.Index].Value;
            if (cellValue != null)
                timeQCEvent.DependEventName = cellValue.ToString();
            return true;
        }

        /// <summary>
        /// 保存指定行的数据到远程数据表,需要注意的是：行的删除状态会与其他状态共存
        /// </summary>
        /// <param name="row">指定行</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short SaveRowData(DataTableViewRow row)
        {
            if (row == null || row.Index < 0)
                return SystemData.ReturnValue.FAILED;

            if (this.dataGridView1.IsNormalRow(row) || this.dataGridView1.IsUnknownRow(row))
            {
                if (!this.dataGridView1.IsDeletedRow(row))
                    return SystemData.ReturnValue.CANCEL;
            }

            TimeQCEvent timeQCEvent = row.Tag as TimeQCEvent;
            if (timeQCEvent == null)
                return SystemData.ReturnValue.FAILED;
            string szEventID = timeQCEvent.EventID;
            timeQCEvent = null;
            if (!this.MakeRowData(row, ref timeQCEvent))
                return SystemData.ReturnValue.FAILED;

            short shRet = SystemData.ReturnValue.OK;
            if (this.dataGridView1.IsDeletedRow(row))
            {
                if (!this.dataGridView1.IsNewRow(row))
                    shRet =TimeQCEventAccess.Instance.DeleteTimeQCEvent(szEventID);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法删除当前记录!");
                    return SystemData.ReturnValue.FAILED;
                }
                this.dataGridView1.Rows.Remove(row);
            }
            else if (this.dataGridView1.IsModifiedRow(row))
            {
                shRet =TimeQCEventAccess.Instance.UpdateTimeQCEvent(timeQCEvent);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录!");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = timeQCEvent;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            else if (this.dataGridView1.IsNewRow(row))
            {
                shRet = TimeQCEventAccess.Instance.SaveTimeQCEvent(timeQCEvent);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录!");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = timeQCEvent;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 显示查询语句设置对话框
        /// </summary>
        /// <param name="row">指定行</param>
        private void ShowQuerySettingForm(DataTableViewRow row)
        {
            if (row == null || row.Index < 0 || this.dataGridView1.IsDeletedRow(row))
                return;
            LargeTextEditForm frmQuerySqlEdit = new LargeTextEditForm();
            frmQuerySqlEdit.Text = "编辑查询语句";
            frmQuerySqlEdit.Description =
                "注意：SELECT子句必须包含事件发生时间和最晚截止时间"
                + "(如出院或当前时间)两个字段!";

            DataGridViewCell cell = row.Cells[this.colSqlText.Index];
            if (cell.Value != null)
                frmQuerySqlEdit.LargeText = cell.Value.ToString();
            if (frmQuerySqlEdit.ShowDialog() != DialogResult.OK)
                return;

            string szSqlText = frmQuerySqlEdit.LargeText.Trim();
            if (szSqlText.EndsWith(";"))
                szSqlText = szSqlText.Remove(szSqlText.Length - 1);
            if (szSqlText.Equals(cell.Value))
                return;
            cell.Value = szSqlText;
            if (this.dataGridView1.IsNormalRowUndeleted(row))
                this.dataGridView1.SetRowState(row, RowState.Update);
        }

        /// <summary>
        /// 显示查询条件设置对话框
        /// </summary>
        /// <param name="row">指定行</param>
        private void ShowConditionSettingForm(DataTableViewRow row)
        {
            if (row == null || row.Index < 0 || this.dataGridView1.IsDeletedRow(row))
                return;
            SqlConditionForm frmSqlCondition = new SqlConditionForm();
            frmSqlCondition.Properties.Add("事件查询信息", typeof(TimeCheckQuery));

            DataGridViewCell cell = row.Cells[this.colCondition.Index];
            if (cell.Value != null)
                frmSqlCondition.SqlCondition = cell.Value.ToString();
            if (frmSqlCondition.ShowDialog() != DialogResult.OK)
                return;
            if (frmSqlCondition.SqlCondition.Equals(cell.Value))
                return;
            cell.Value = frmSqlCondition.SqlCondition;
            if (this.dataGridView1.IsNormalRowUndeleted(row))
                this.dataGridView1.SetRowState(row, RowState.Update);
        }

        /// <summary>
        /// 显示依赖事件设置对话框
        /// </summary>
        /// <param name="row">指定行</param>
        private void ShowDependEventEditForm()
        {
            TimeEventSelectForm frmDependEvent = new TimeEventSelectForm();

            //初始化病历时效事件选择列表
            int count = this.dataGridView1.Rows.Count;
            for (int index = 0; index < count; index++)
            {
                DataTableViewRow row = this.dataGridView1.Rows[index];

                TimeQCEvent timeQCEvent = new TimeQCEvent();

                object cellValue = row.Cells[this.colEventID.Index].Value;
                if (cellValue == null || cellValue.ToString().Trim() == string.Empty)
                    continue;
                timeQCEvent.EventID = cellValue.ToString();

                string szDocTypeName = string.Empty;
                cellValue = row.Cells[this.colEventName.Index].Value;
                if (cellValue == null || cellValue.ToString().Trim() == string.Empty)
                    continue;
                timeQCEvent.EventName = cellValue.ToString();

                frmDependEvent.TimeQCEvents.Add(timeQCEvent);
            }

            //设置默认选中的病历时效事件
            DataGridViewCell currCell = this.dataGridView1.CurrentCell;
            if (currCell != null)
            {
                TimeQCEvent timeQCEvent = new TimeQCEvent();
                if (currCell.Tag != null)
                    timeQCEvent.EventID = currCell.Tag.ToString();
                if (currCell.Value != null)
                    timeQCEvent.EventName = currCell.Value.ToString();
                frmDependEvent.SelectedEvent = timeQCEvent;
            }

            //更新选中所有行的病历时效事件
            if (frmDependEvent.ShowDialog() == DialogResult.OK)
            {
                TimeQCEvent timeQCEvent = frmDependEvent.SelectedEvent;
                if (timeQCEvent == null)
                    timeQCEvent = new TimeQCEvent();
                for (int index = 0; index < this.dataGridView1.SelectedRows.Count; index++)
                {
                    DataTableViewRow row = this.dataGridView1.SelectedRows[index];
                    if (row == null || row.Index < 0)
                        continue;
                    row.Cells[this.colDependEvent.Index].Tag = timeQCEvent.EventID;
                    row.Cells[this.colDependEvent.Index].Value = timeQCEvent.EventName;
                    if (!this.dataGridView1.IsNormalRowUndeleted(row))
                        continue;
                    this.dataGridView1.SetRowState(row, RowState.Update);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TimeQCEvent timeQCEvent = null;
            DataTableViewRow currRow = this.dataGridView1.CurrentRow;
            if (currRow != null && currRow.Index >= 0)
                timeQCEvent = currRow.Tag as TimeQCEvent;
            if (timeQCEvent == null)
                timeQCEvent = new TimeQCEvent();
            else
                timeQCEvent = timeQCEvent.Clone() as TimeQCEvent;
            timeQCEvent.EventID = timeQCEvent.MakeEventID();

            int nRowIndex = this.dataGridView1.Rows.Add();
            DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
            this.SetRowData(row, timeQCEvent);

            this.dataGridView1.Focus();
            this.dataGridView1.SelectRow(row);
            this.dataGridView1.SetRowState(row, RowState.New);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            this.CommitModify();
        }

        private void mnnCancelModify_Click(object sender, EventArgs e)
        {
            int nCount = this.dataGridView1.SelectedRows.Count;
            if (nCount <= 0)
                return;
            for (int index = 0; index < nCount; index++)
            {
                DataTableViewRow row = this.dataGridView1.SelectedRows[index];
                if (!this.dataGridView1.IsModifiedRow(row))
                    continue;
                this.SetRowData(row, row.Tag as TimeQCEvent);
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
        }

        private void mnuCancelDelete_Click(object sender, EventArgs e)
        {
            int nCount = this.dataGridView1.SelectedRows.Count;
            if (nCount <= 0)
                return;
            for (int index = 0; index < nCount; index++)
            {
                DataTableViewRow row = this.dataGridView1.SelectedRows[index];
                if (!this.dataGridView1.IsDeletedRow(row))
                    continue;
                if (this.dataGridView1.IsNewRow(row))
                    this.dataGridView1.SetRowState(row, RowState.New);
                else if (this.dataGridView1.IsModifiedRow(row))
                    this.dataGridView1.SetRowState(row, RowState.Update);
                else
                    this.dataGridView1.SetRowState(row, RowState.Normal);
            }
        }

        private void mnuDeleteRecord_Click(object sender, EventArgs e)
        {
            int nCount = this.dataGridView1.SelectedRows.Count;
            if (nCount <= 0)
                return;
            for (int index = 0; index < nCount; index++)
            {
                DataTableViewRow row = this.dataGridView1.SelectedRows[index];
                this.dataGridView1.SetRowState(row, RowState.Delete);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataTableViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (this.dataGridView1.IsDeletedRow(row))
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (e.ColumnIndex == this.colSqlText.Index)
                this.ShowQuerySettingForm(row);
            else if (e.ColumnIndex == this.colCondition.Index)
                this.ShowConditionSettingForm(row);
            else if (e.ColumnIndex == this.colDependEvent.Index)
                this.ShowDependEventEditForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == this.colCondition.Index || e.ColumnIndex == this.colEventID.Index)
                e.Cancel = true;
            else if (e.ColumnIndex == this.colSqlText.Index || e.ColumnIndex == this.colDependEvent.Index)
                e.Cancel = true;
        }
    }
}