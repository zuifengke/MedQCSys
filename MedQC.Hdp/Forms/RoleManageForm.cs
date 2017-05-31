// ***********************************************************
// 病案质控系统质控问题类型维护窗口.
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
using Heren.Common.Controls.TableView;
using Heren.Common.DockSuite;
using MedQCSys.DockForms;
using EMRDBLib;
using EMRDBLib.DbAccess;
using MedQCSys;

namespace Heren.MedQC.Hdp
{
    public partial class RoleManageForm : DockContentBase
    {
        public RoleManageForm(MainForm form):base(form)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dgvRoleList.Font = new Font("宋体", 10.5f);
            //this.dataGridView1.AutoReadonly = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.OnRefreshView();
        }

        public override void OnRefreshView()
        {
            if (!this.SaveUncommitedChange())
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在刷新质量问题分类字典，请稍候...");
            //if (this.colApplyEnv.Items.Count > 0)
            //    this.colApplyEnv.Items.Clear();
            //this.colApplyEnv.Items.Add(string.Empty);
            //if (GlobalDataHandler.Instance.QCUserRight.BrowseDocumentList.Value)
            //    this.colApplyEnv.Items.Add("医生文书");
            //if (GlobalDataHandler.Instance.QCUserRight.BrowseNurDocList.Value)
            //    this.colApplyEnv.Items.Add("护理文书");
            this.LoadHdpRoleList();
            this.UpdateUIState();

            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ShowStatusMessage(string p)
        {
            //throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 检查是否有需要保存的数据
        /// </summary>
        /// <returns>是否保存成功</returns>
        public virtual bool SaveUncommitedChange()
        {
            if (!this.HasUncommit())
                return true;
            this.DockHandler.Activate();
            DialogResult result = MessageBoxEx.Show("当前有未保存的修改,是否保存？"
                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                return this.CommitModify();
            return true;
        }
        /// <summary>
        /// 装载病案质量问题分类信息
        /// </summary>
        private void LoadHdpRoleList()
        {
            this.dgvRoleList.Rows.Clear();
            List<HdpRole> lstHdpRoles = null;
            short shRet =HdpRoleAccess.Instance.GetHdpRoleList(string.Empty,ref lstHdpRoles);
            if (shRet != SystemData.ReturnValue.OK
                && shRet!=SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取病案质量问题分类字典失败！");
                return;
            }
            if (lstHdpRoles == null || lstHdpRoles.Count <= 0)
                return;
            for (int index = 0; index < lstHdpRoles.Count; index++)
            {
                HdpRole hdpRole = lstHdpRoles[index];

                int nRowIndex = this.dgvRoleList.Rows.Add();
                DataTableViewRow row = this.dgvRoleList.Rows[nRowIndex];
                row.Tag = hdpRole; //将记录信息保存到该行
                this.SetRowData(row, hdpRole);
                this.dgvRoleList.SetRowState(row, RowState.Normal);
            }
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
            this.toolbtnAuthority.Enabled = false;

            if (this.dgvRoleList.SelectedRows.Count <= 0) return;
            DataTableViewRow currRow = this.dgvRoleList.SelectedRows[0];
            if (!this.dgvRoleList.IsDeletedRow(currRow))
            {
                if (this.dgvRoleList.IsNormalRow(currRow) || this.dgvRoleList.IsModifiedRow(currRow))
                {
                    this.toolbtnModify.Enabled = true;
                    this.mnuModifyItem.Enabled = true;
                    this.toolbtnAuthority.Enabled = true;
                }
            }

            this.toolbtnDelete.Text = "删除";
            this.mnuDeleteItem.Text = "删除";
            this.toolbtnModify.Text = "修改";
            this.mnuModifyItem.Text = "修改";
            if (this.dgvRoleList.IsDeletedRow(currRow))
            {
                this.toolbtnDelete.Text = "取消删除";
                this.mnuDeleteItem.Text = "取消删除";
            }
            else if (this.dgvRoleList.IsModifiedRow(currRow))
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
        /// 检查是否有未提交的修改
        /// </summary>
        /// <returns>bool</returns>
        public  bool HasUncommit()
        {
            if (this.dgvRoleList.Rows.Count <= 0)
                return false;
            foreach (DataTableViewRow row in this.dgvRoleList.Rows)
            {
                if (this.dgvRoleList.IsDeletedRow(row))
                    return true;
                if (this.dgvRoleList.IsNewRow(row))
                    return true;
                if (this.dgvRoleList.IsModifiedRow(row))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 保存质控反馈问题类型列表的修改
        /// </summary>
        /// <returns>bool</returns>
        public  bool CommitModify()
        {
            if (this.dgvRoleList.Rows.Count <= 0) return true;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            int index = 0;
            int count = 0;
            short shRet = SystemData.ReturnValue.OK;
            this.dgvRoleList.EndEdit();
            while (index < this.dgvRoleList.Rows.Count)
            {
                DataTableViewRow row = this.dgvRoleList.Rows[index];
                bool bIsDeletedRow = this.dgvRoleList.IsDeletedRow(row);
                shRet = this.SaveRowData(row);
                if (shRet == SystemData.ReturnValue.OK) count++;
                else if (shRet == SystemData.ReturnValue.FAILED) break;
                if (!bIsDeletedRow) index++;
            }
            this.UpdateUIState();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            string szMessageText = null;
            if (shRet == SystemData.ReturnValue.FAILED) szMessageText = string.Format("保存中止,已保存{0}条记录！", count);
            else szMessageText = string.Format("保存成功,已保存{0}条记录！", count);
            MessageBoxEx.Show(szMessageText, MessageBoxIcon.Information);
            return shRet == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="hdpRole">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataGridViewRow row,  HdpRole hdpRole)
        {
            if (row == null || row.Index < 0 || hdpRole == null)
                return false;
            row.Tag = hdpRole;
            row.Cells[this.colSerialNO.Index].Value = hdpRole.SerialNo;
            row.Cells[this.colRoleName.Index].Value = hdpRole.RoleName;
            row.Cells[this.colRoleCode.Index].Value = hdpRole.RoleCode;
            row.Cells[this.colStatus.Index].Value = hdpRole.Status=="1"?"开启":"关闭";
            row.Cells[this.colRoleBak.Index].Value = hdpRole.RoleBak;

            return true;
        }

        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="hdpRole">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref  HdpRole hdpRole)
        {
            if (row == null || row.Index < 0)
                return false;
            hdpRole = new  HdpRole();
             HdpRole oldHdpRole = row.Tag as  HdpRole;
            if (!this.dgvRoleList.IsNewRow(row))
            {
                if (oldHdpRole == null)
                {
                    MessageBoxEx.Show("质量问题分类字典行数据信息为空！");
                    return false;
                }
            }

            if (this.dgvRoleList.IsDeletedRow(row))
            {
                hdpRole = oldHdpRole;
                return true;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colSerialNO.Index].Value))
            {
                this.dgvRoleList.CurrentCell = row.Cells[this.colSerialNO.Index];
                this.dgvRoleList.BeginEdit(true);
                MessageBoxEx.Show("您必须设置序号！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colRoleName.Index].Value))
            {
                this.dgvRoleList.CurrentCell = row.Cells[this.colRoleName.Index];
                this.dgvRoleList.BeginEdit(true);
                MessageBoxEx.Show("您必须设置角色名称！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colRoleCode.Index].Value))
            {
                this.dgvRoleList.CurrentCell = row.Cells[this.colRoleCode.Index];
                this.dgvRoleList.BeginEdit(true);
                MessageBoxEx.Show("您必须设置角色代码！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colStatus.Index].Value))
            {
                MessageBoxEx.Show("您必须设置状态！");
                return false;
            }
            if (hdpRole == null)
                hdpRole = new  HdpRole();
            hdpRole.SerialNo = (string)row.Cells[this.colSerialNO.Index].Value;
            hdpRole.RoleName = (string)row.Cells[this.colRoleName.Index].Value;
            hdpRole.RoleCode = (string)row.Cells[this.colRoleCode.Index].Value;
            hdpRole.Status = (string)row.Cells[this.colStatus.Index].Value=="开启"?"1":"0";
            hdpRole.RoleBak = row.Cells[this.colRoleBak.Index].Value == null ? "" : (string)row.Cells[this.colRoleBak.Index].Value;
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
            if (this.dgvRoleList.IsNormalRow(row) || this.dgvRoleList.IsUnknownRow(row))
            {
                if (!this.dgvRoleList.IsDeletedRow(row))
                    return SystemData.ReturnValue.CANCEL;
            }

             HdpRole hdpRole = row.Tag as  HdpRole;
            if (hdpRole == null)
                return SystemData.ReturnValue.FAILED;
            string szRoleCode = hdpRole.RoleCode;

            hdpRole = null;
            if (!this.MakeRowData(row, ref hdpRole))
                return SystemData.ReturnValue.FAILED;

            short shRet = SystemData.ReturnValue.OK;
            if (this.dgvRoleList.IsDeletedRow(row))
            {
                if (!this.dgvRoleList.IsNewRow(row))

                    shRet = HdpRoleAccess.Instance.DeleteHdpRole(szRoleCode);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dgvRoleList.SelectRow(row);
                    MessageBoxEx.Show("无法删除当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                this.dgvRoleList.Rows.Remove(row);
            }
            else if (this.dgvRoleList.IsModifiedRow(row))
            {

                shRet =HdpRoleAccess.Instance.ModifyHdpRole(szRoleCode,hdpRole);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dgvRoleList.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = hdpRole;
                this.dgvRoleList.SetRowState(row, RowState.Normal);
            }
            else if (this.dgvRoleList.IsNewRow(row))
            {

                shRet = HdpRoleAccess.Instance.SaveHdpRole(hdpRole);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dgvRoleList.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = hdpRole;
                this.dgvRoleList.SetRowState(row, RowState.Normal);
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 增加一行记录
        /// </summary>
        private void AddNewItem()
        {
            //创建数据
             HdpRole qcEventInfo = new  HdpRole();
            //创建行
            int index = this.dgvRoleList.Rows.Add();
            DataTableViewRow row = this.dgvRoleList.Rows[index];
            row.Tag = qcEventInfo;
            this.dgvRoleList.SetRowState(row, RowState.New);
            this.UpdateUIState();

            this.dgvRoleList.CurrentCell = row.Cells[this.colSerialNO.Index];
            this.dgvRoleList.BeginEdit(true);
        }

        /// <summary>
        ///修改选中行数据
        /// </summary>
        private void ModifySelectedItem()
        {
            if (this.dgvRoleList.SelectedRows.Count <= 0)
                return;

            
            DataTableViewRow row = this.dgvRoleList.SelectedRows[0];
            if (this.dgvRoleList.IsNormalRow(row))
            {
                this.dgvRoleList.SetRowState(row, RowState.Update);
            }
            else if (this.dgvRoleList.IsModifiedRow(row))
            {
                this.dgvRoleList.SetRowState(row, RowState.Normal);
                this.SetRowData(row, row.Tag as  HdpRole);
            }
            this.UpdateUIState();
            this.dgvRoleList.CurrentCell = row.Cells[this.colSerialNO.Index];
            this.dgvRoleList.BeginEdit(true);
        }

        /// <summary>
        /// 删除选中行记录
        /// </summary>
        private void DeleteSelectedItem()
        {
            if (this.dgvRoleList.SelectedRows.Count <= 0)
                return;

            
            DataTableViewRow row = this.dgvRoleList.SelectedRows[0];
            if (this.dgvRoleList.IsDeletedRow(row))
            {
                if (this.dgvRoleList.IsNewRow(row))
                    this.dgvRoleList.SetRowState(row, RowState.New);
                else if (this.dgvRoleList.IsModifiedRow(row))
                    this.dgvRoleList.SetRowState(row, RowState.Update);
                else if (this.dgvRoleList.IsNormalRow(row))
                    this.dgvRoleList.SetRowState(row, RowState.Normal);
                else
                    this.dgvRoleList.SetRowState(row, RowState.Unknown);
            }
            else
            {
                this.dgvRoleList.SetRowState(row, RowState.Delete);
            }
            this.UpdateUIState();
        }

        private void toolbtnNew_Click(object sender, EventArgs e)
        {
            this.AddNewItem();
        }

        private void toolbtnModify_Click(object sender, EventArgs e)
        {
            this.ModifySelectedItem();
        }

        private void toolbtnDelete_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedItem();
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            this.Focus();
            this.CommitModify();
        }

        private void mnuAddItem_Click(object sender, EventArgs e)
        {
            this.AddNewItem();
        }

        private void mnuModifyItem_Click(object sender, EventArgs e)
        {
            this.ModifySelectedItem();
        }

        private void mnuDeleteItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedItem();
        }

        private void mnuSaveItems_Click(object sender, EventArgs e)
        {
            this.CommitModify();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvRoleList.CurrentCell != null)
                this.dgvRoleList.BeginEdit(true);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.UpdateUIState();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            //不允许修改已删除行
            DataTableViewRow row = this.dgvRoleList.Rows[e.RowIndex];
            if (this.dgvRoleList.IsDeletedRow(row))
            {
                e.Cancel = true;
                return;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell currCell = this.dgvRoleList.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colRoleCode.Index)
                return;

            TextBox textBoxExitingControl = e.Control as TextBox;
            if (textBoxExitingControl == null || textBoxExitingControl.IsDisposed)
                return;
            textBoxExitingControl.ImeMode = ImeMode.Alpha;
            textBoxExitingControl.KeyPress -= new KeyPressEventHandler(this.TextBoxExitingControl_KeyPress);
            textBoxExitingControl.KeyPress += new KeyPressEventHandler(this.TextBoxExitingControl_KeyPress);
        }

        private void TextBoxExitingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewCell currCell = this.dgvRoleList.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colRoleCode.Index)
                return;

            if (currCell.ColumnIndex == this.colSerialNO.Index)
            {
                if (e.KeyChar == (char)((int)Keys.Back))
                    return;
                if (e.KeyChar.CompareTo('0') >= 0 && e.KeyChar.CompareTo('9') <= 0)
                    return;
                e.Handled = true;
            }
            
        }

        private void toolbtnAuthority_Click(object sender, EventArgs e)
        {
            if(this.dgvRoleList.SelectedRows.Count<=0)
                return;
            HdpRole hdpRole=this.dgvRoleList.SelectedRows[0].Tag as HdpRole;
            if (hdpRole == null)
            {
                MessageBoxEx.Show("获取角色信息失败");
                return;
            }
            //RoleGrantForm form = new RoleGrantForm();
            RoleGrantCheckListForm form = new RoleGrantCheckListForm();
            form.RoleInfo = hdpRole;
            form.ShowDialog();
        }
    }
}