// ***********************************************************
// 病历编辑器配置管理系统后台配置字典表配置管理窗口.
// Creator:YangMingkun  Date:2010-11-29
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Controls.TableView;
using MedQCSys;
using MedQCSys.DockForms;
using EMRDBLib;
using EMRDBLib.DbAccess;
using MedQCSys.Dialogs;

namespace Heren.MedQC.MedRecord
{
    internal partial class SettingCodeTypeForm : Form
    {
        public SettingCodeTypeForm()
        {
            this.InitializeComponent();
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }
        

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadParameterList();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
           
        }
        
        private void LoadParameterList()
        {
            this.dataGridView1.Rows.Clear();
          
         
            List<RecCodeCompasion> lstHdpParameter = null;

            short shRet = RecCodeCompasionAccess.Instance.GetLists(true, ref lstHdpParameter);
            if (shRet == SystemData.ReturnValue.RES_NO_FOUND)
                return;
            if (shRet != SystemData.ReturnValue.OK)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("配置字典表加载失败!");
            }
            if (lstHdpParameter == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }

            for (int index = 0; index < lstHdpParameter.Count; index++)
            {
                RecCodeCompasion recCodeCompasion = lstHdpParameter[index];
                if (recCodeCompasion == null)
                    continue;
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, recCodeCompasion);
                this.dataGridView1.SetRowState(row, RowState.Normal);

                if (nRowIndex <= 0)
                    continue;
            }
        }
        /// <summary>
        /// 检查是否有未保存的数据
        /// </summary>
        /// <returns>bool</returns>
        public  bool HasUncommit()
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
        public  bool CommitModify()
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
            if (count > 0)
                szMessageText += "\r\n系统配置已被更改,将在重新登录后生效!";
            this.UpdateUIState();
            MessageBoxEx.Show(szMessageText, MessageBoxIcon.Information);
            return shRet == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="configInfo">绑定的数据</param>
        private bool SetRowData(DataTableViewRow row, RecCodeCompasion parameter)
        {
            if (row == null || row.Index < 0 || parameter == null)
                return false;
            row.Tag = parameter;
            row.Cells[this.col_CODE_TYPE_NAME.Index].Value = parameter.CODETYPE_NAME;
            row.Cells[this.col_CONFIG_NAME.Index].Value = parameter.CONFIG_NAME;
            row.Cells[this.col_dmlb.Index].Value = parameter.DMLB;
            row.Cells[this.col_FORM_SQL.Index].Value = parameter.FORM_SQL;
            row.Cells[this.col_TO_SQL.Index].Value = parameter.TO_SQL;
            return true;
        }

        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="configInfo">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref RecCodeCompasion recCodeCompasion)
        {
            
            if (row == null || row.Index < 0)
                return false;
            recCodeCompasion = new RecCodeCompasion();

            object cellValue = row.Cells[this.col_CONFIG_NAME.Index].Value;
            if (GlobalMethods.Misc.IsEmptyString(cellValue))
            {
                this.dataGridView1.SelectRow(row);
                MessageBoxEx.Show("您必须输入类别名称!");
                return false;
            }
            recCodeCompasion.CONFIG_NAME = cellValue.ToString();
           
            cellValue = row.Cells[this.col_CODE_TYPE_NAME.Index].Value;
            if (!GlobalMethods.Misc.IsEmptyString(cellValue))
            {
                recCodeCompasion.CODETYPE_NAME = cellValue.ToString();
            }
            cellValue = row.Cells[this.col_dmlb.Index].Value;
            if (!GlobalMethods.Misc.IsEmptyString(cellValue))
            {
                recCodeCompasion.DMLB = cellValue.ToString();
            }
            cellValue = row.Cells[this.col_FORM_SQL.Index].Value;
            if (!GlobalMethods.Misc.IsEmptyString(cellValue))
            {
                recCodeCompasion.FORM_SQL = cellValue.ToString();
            }
            cellValue = row.Cells[this.col_TO_SQL.Index].Value;
            if (!GlobalMethods.Misc.IsEmptyString(cellValue))
            {
                recCodeCompasion.TO_SQL = cellValue.ToString();
            }
            recCodeCompasion.IS_CONFIG = 1;
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

            RecCodeCompasion recCodeCompasion = row.Tag as RecCodeCompasion;
            if (recCodeCompasion == null)
                return SystemData.ReturnValue.FAILED;
            string id = recCodeCompasion.ID;
            recCodeCompasion = null;
            if (!this.MakeRowData(row, ref recCodeCompasion))
                return SystemData.ReturnValue.FAILED;
            recCodeCompasion.ID = id;
            short shRet = SystemData.ReturnValue.OK;
            if (this.dataGridView1.IsDeletedRow(row))
            {
                if (!this.dataGridView1.IsNewRow(row))
                    shRet = RecCodeCompasionAccess.Instance.Delete(id);
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
                shRet = RecCodeCompasionAccess.Instance.Update(recCodeCompasion);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录!");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = recCodeCompasion;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            else if (this.dataGridView1.IsNewRow(row))
            {
                shRet =RecCodeCompasionAccess.Instance.Insert(recCodeCompasion);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录!");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = recCodeCompasion;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 显示查询语句设置对话框
        /// </summary>
        /// <param name="row">指定行</param>
        private void ShowFromSqlEditForm(DataTableViewRow row)
        {
            if (row == null || row.Index < 0 || this.dataGridView1.IsDeletedRow(row))
                return;
            if (this.dataGridView1.EditingControl != null)
                this.dataGridView1.EndEdit();
            LargeTextEditForm frmConfigValueEdit = new LargeTextEditForm();
            frmConfigValueEdit.Text = "编辑配置数据";
            DataGridViewCell cell = row.Cells[this.col_FORM_SQL.Index];
            if (cell.Value != null)
                frmConfigValueEdit.LargeText = cell.Value.ToString();
            if (frmConfigValueEdit.ShowDialog() != DialogResult.OK)
                return;
            string szConfigValue = frmConfigValueEdit.LargeText;
            if (szConfigValue.Equals(cell.Value))
                return;
            cell.Value = szConfigValue;
            if (this.dataGridView1.IsNormalRowUndeleted(row))
                this.dataGridView1.SetRowState(row, RowState.Update);
        }

        private void ShowToSqlEditForm(DataTableViewRow row)
        {
            if (row == null || row.Index < 0 || this.dataGridView1.IsDeletedRow(row))
                return;
            if (this.dataGridView1.EditingControl != null)
                this.dataGridView1.EndEdit();
            LargeTextEditForm frmConfigDescEdit = new LargeTextEditForm();
            frmConfigDescEdit.Text = "编辑联众代码查询sql";
            DataGridViewCell cell = row.Cells[this.col_TO_SQL.Index];
            if (cell.Value != null)
                frmConfigDescEdit.LargeText = cell.Value.ToString();
            if (frmConfigDescEdit.ShowDialog() != DialogResult.OK)
                return;
            string szConfigDesc = frmConfigDescEdit.LargeText.Trim();
            if (szConfigDesc.Equals(cell.Value))
                return;
            cell.Value = szConfigDesc;
            if (this.dataGridView1.IsNormalRowUndeleted(row))
                this.dataGridView1.SetRowState(row, RowState.Update);
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
                this.SetRowData(row, row.Tag as RecCodeCompasion);
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

        private void btnCommit_Click(object sender, EventArgs e)
        {
            this.CommitModify();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            DataTableViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex == this.col_FORM_SQL.Index)
                this.ShowFromSqlEditForm(row);
            else if (e.ColumnIndex == this.col_TO_SQL.Index)
                this.ShowToSqlEditForm(row);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnNew_Click(object sender, EventArgs e)
        {
            this.AddNewItem();
        }
        /// <summary>
        /// 修改界面按钮状态
        /// </summary>
        private void UpdateUIState()
        {
            this.toolbtnModify.Enabled = false;
            this.mnuModifyItem.Enabled = false;
            this.toolbtnDelete.Enabled = false;
            this.mnuDeleteItem.Enabled = false;

            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            DataTableViewRow currRow = this.dataGridView1.SelectedRows[0];
            if (!this.dataGridView1.IsDeletedRow(currRow))
            {
                if (this.dataGridView1.IsNormalRow(currRow)
                    || this.dataGridView1.IsModifiedRow(currRow))
                {
                    this.toolbtnModify.Enabled = true;
                    this.mnuModifyItem.Enabled = true;
                }
            }

            this.toolbtnDelete.Text = "删除";
            this.mnuDeleteItem.Text = "删除";
            this.toolbtnModify.Text = "修改";
            this.mnuModifyItem.Text = "修改";
            if (this.dataGridView1.IsDeletedRow(currRow))
            {
                this.toolbtnDelete.Text = "取消删除";
                this.mnuDeleteItem.Text = "取消删除";
            }
            else if (this.dataGridView1.IsModifiedRow(currRow))
            {
                this.toolbtnModify.Text = "取消修改";
                this.mnuModifyItem.Text = "取消修改";
            }
            this.toolbtnDelete.Enabled = true;
            this.mnuDeleteItem.Enabled = true;
            this.toolbtnSave.Enabled = true;
            this.mnuSaveItems.Enabled = true;
        }
        /// <summary>
        /// 增加一行记录
        /// </summary>
        private void AddNewItem()
        {
            RecCodeCompasion rec = this.dataGridView1.SelectedRows[0].Tag as RecCodeCompasion;
            //创建数据
            RecCodeCompasion recCodeCompasion = new RecCodeCompasion();
            //创建行
            int index = this.dataGridView1.Rows.Add();
            DataTableViewRow row = this.dataGridView1.Rows[index];
            recCodeCompasion.ID = recCodeCompasion.MakeID();
            row.Tag = recCodeCompasion;
            if (rec != null)
            {
                row.Cells[this.col_FORM_SQL.Index].Value = rec.FORM_SQL;
                row.Cells[this.col_TO_SQL.Index].Value = rec.TO_SQL;
            }
            this.dataGridView1.SetRowState(row, RowState.New);
            this.UpdateUIState();

            this.dataGridView1.CurrentCell = row.Cells[this.col_CONFIG_NAME.Index];
            this.dataGridView1.BeginEdit(true);
        }

        private void mnuAddItem_Click(object sender, EventArgs e)
        {
            this.AddNewItem();
        }

        private void mnuModifyItem_Click(object sender, EventArgs e)
        {
            this.ModifySelectedItem();
        }

        private void toolbtnModify_Click(object sender, EventArgs e)
        {
            this.ModifySelectedItem();
        }
        /// <summary>
        ///修改选中行数据
        /// </summary>
        private void ModifySelectedItem()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            DataTableViewRow row = this.dataGridView1.SelectedRows[0];
            if (this.dataGridView1.IsNormalRow(row))
            {
                this.dataGridView1.SetRowState(row, RowState.Update);
            }
            else if (this.dataGridView1.IsModifiedRow(row))
            {
                this.dataGridView1.SetRowState(row, RowState.Normal);
                this.SetRowData(row, row.Tag as RecCodeCompasion);
            }
            this.UpdateUIState();
            this.dataGridView1.CurrentCell = row.Cells[this.col_CONFIG_NAME.Index];
            this.dataGridView1.BeginEdit(true);
        }

        private void toolbtnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedItem();
        }

        private void mnuDeleteItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedItem();
        }
        /// <summary>
        /// 删除选中行记录
        /// </summary>
        private void DeleteSelectedItem()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            DataTableViewRow row = this.dataGridView1.SelectedRows[0];
            if (this.dataGridView1.IsDeletedRow(row))
            {
                if (this.dataGridView1.IsNewRow(row))
                    this.dataGridView1.SetRowState(row, RowState.New);
                else if (this.dataGridView1.IsModifiedRow(row))
                    this.dataGridView1.SetRowState(row, RowState.Update);
                else if (this.dataGridView1.IsNormalRow(row))
                    this.dataGridView1.SetRowState(row, RowState.Normal);
                else
                    this.dataGridView1.SetRowState(row, RowState.Unknown);
            }
            else
            {
                this.dataGridView1.SetRowState(row, RowState.Delete);
            }
            this.UpdateUIState();
        }

        private void mnuSaveItems_Click(object sender, EventArgs e)
        {
            this.CommitModify();
        }
        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            this.CommitModify();
        }

        private void toolcboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadParameterList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.UpdateUIState();
        }
    }
}