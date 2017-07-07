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
using MedQCSys;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.MedQC.Core;

namespace Heren.MedQC.Hdp
{
    public partial class MenuConfigForm : DockContentBase
    {
        public MenuConfigForm(MainForm form) : base(form)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }
        private Dictionary<string, string> m_dicResource;
        private Dictionary<string, string> m_dicOperationType;
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

            if (!this.LoadCboProducts())
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }

            this.UpdateUIState();

            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 绑定
        /// </summary>
        private void LoadGridComboBoxItem()
        {
            if (this.toolcboProduct.SelectedItem == null)
                return;
            string szProduct = (this.toolcboProduct.SelectedItem as HdpProduct).NAME_SHORT;

            RightPoint[] rights = RightResource.GetRightPoints(szProduct);
            if (rights != null)
            {
                this.colRightKey.Items.AddRange(rights);
            }
            //命令
            this.colUICommand.Items.Clear();
            if (CommandHandler.Instance.Commands.Count > 0)
            {
                foreach (string item in CommandHandler.Instance.Commands.Keys)
                {
                    this.colUICommand.Items.Add(item);
                }
            }
            //快捷键
            this.colShortCuts.Items.Clear();
            string[] arrShortcutKeys = SystemData.ShortcutKeys.GetArrShortcutKeys();
            if (arrShortcutKeys.Length > 0)
            {
                foreach (string item in arrShortcutKeys)
                {
                    this.colShortCuts.Items.Add(item);
                }
            }

        }
        private bool LoadCboProducts()
        {
            this.toolcboProduct.Items.Clear();
            this.Update();
            List<HdpProduct> lstHdpProducts = null;
            short shRet = HdpProductAccess.Instance.GetHdpProductList(ref lstHdpProducts);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取产品信息失败！");
                return false;
            }
            if (lstHdpProducts == null || lstHdpProducts.Count <= 0)
                return false;
            int selectedIndex = 0;
            for (int index = 0; index < lstHdpProducts.Count; index++)
            {
                HdpProduct hdpProduct = lstHdpProducts[index];
                toolcboProduct.Items.Add(hdpProduct);
                if (hdpProduct.NAME_SHORT == DataCache.Instance.HdpProduct.NAME_SHORT)
                {
                    selectedIndex = index;
                }
            }
            this.toolcboProduct.SelectedIndex = selectedIndex;
            return true;
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
        private void LoadHdpUIConfigList()
        {
            this.dataGridView1.Rows.Clear();
            if (this.toolcboProduct.SelectedItem == null)
                return;
            string szProduct = (this.toolcboProduct.SelectedItem as HdpProduct).NAME_SHORT;
            List<HdpUIConfig> lstHdpUIConfigs = null;
            string szUIType = SystemData.UIType.MENU;
            string szPopMenuResource = string.Empty;
            szUIType = SystemData.UIType.MENU;
            if (szPopMenuResource == string.Empty && szUIType == SystemData.UIType.POPMENU)
                return;
            short shRet = HdpUIConfigAccess.Instance.GetHdpUIConfigList(szProduct, szUIType, szPopMenuResource, ref lstHdpUIConfigs);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取产品信息失败！");
                return;
            }
            if (lstHdpUIConfigs == null || lstHdpUIConfigs.Count <= 0)
                return;
            for (int index = 0; index < lstHdpUIConfigs.Count; index++)
            {
                HdpUIConfig hdpUIConfig = lstHdpUIConfigs[index];

                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = hdpUIConfig; //将记录信息保存到该行
                this.SetRowData(row, hdpUIConfig);
                this.dataGridView1.SetRowState(row, RowState.Normal);
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
        /// 检查是否有未提交的修改
        /// </summary>
        /// <returns>bool</returns>
        public bool HasUncommit()
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return false;
            foreach (DataTableViewRow row in this.dataGridView1.Rows)
            {
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
        /// 保存质控反馈问题类型列表的修改
        /// </summary>
        /// <returns>bool</returns>
        public bool CommitModify()
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return true;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            int index = 0;
            int count = 0;
            short shRet = SystemData.ReturnValue.OK;
            this.dataGridView1.EndEdit();
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
            this.UpdateUIState();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            string szMessageText = null;
            if (shRet == SystemData.ReturnValue.FAILED)
            {
                szMessageText = string.Format("保存中止,已保存{0}条记录！", count);
                MessageBoxEx.Show(szMessageText, MessageBoxIcon.Information);
            }
            else
                szMessageText = string.Format("保存成功,已保存{0}条记录！", count);

            return shRet == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="hdpUIConfig">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataGridViewRow row, HdpUIConfig hdpUIConfig)
        {
            if (row == null || row.Index < 0 || hdpUIConfig == null)
                return false;
            row.Tag = hdpUIConfig;
            //级别标记为空格
            string flag = string.Empty;
            for (int index = 0; index < hdpUIConfig.UIGrade; index++)
            {
                flag += "  ";
            }
            row.Cells[this.colShowName.Index].Value = flag + hdpUIConfig.ShowName;
            row.Cells[this.colShortCuts.Index].Value = hdpUIConfig.ShortCuts;
            row.Cells[this.colRightKey.Index].Value = hdpUIConfig.UIRightKey;
            row.Cells[this.colRightDesc.Index].Value = hdpUIConfig.UIRightDesc;
            row.Cells[this.colUICommand.Index].Value = hdpUIConfig.UICommand;
            row.Cells[this.colUIIcon.Index].Value = hdpUIConfig.UIIcon;
            row.Cells[this.colMicroHelp.Index].Value = hdpUIConfig.MicroHelp;
            row.Cells[this.colUIIconSize.Index].Value = hdpUIConfig.UIIconSize;

            return true;
        }



        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="hdpUIConfig">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref HdpUIConfig hdpUIConfig)
        {
            if (row == null || row.Index < 0)
                return false;
            hdpUIConfig = new HdpUIConfig();
            HdpUIConfig oldHdpUIConfig = row.Tag as HdpUIConfig;

            if (!this.dataGridView1.IsNewRow(row))
            {
                if (oldHdpUIConfig == null)
                {
                    MessageBoxEx.Show("质量问题分类字典行数据信息为空！");
                    return false;
                }
            }

            if (this.dataGridView1.IsDeletedRow(row))
            {
                hdpUIConfig = oldHdpUIConfig;
                return true;
            }
            if (this.toolcboProduct.SelectedItem == null || this.toolcboProduct.Text == string.Empty)
            {
                MessageBoxEx.Show("您必须选择产品！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colShowName.Index].Value))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colShowName.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您必须设置菜单显示名称！");
                return false;
            }

            if (hdpUIConfig == null)
                hdpUIConfig = new HdpUIConfig();
            hdpUIConfig.UIConfigID = oldHdpUIConfig.UIConfigID;
            hdpUIConfig.Product = (this.toolcboProduct.SelectedItem as HdpProduct).NAME_SHORT;
            hdpUIConfig.ShowName = row.Cells[this.colShowName.Index].Value.ToString().Trim();
            if (row.Cells[this.colShortCuts.Index].Value != null)
                hdpUIConfig.ShortCuts = (string)row.Cells[this.colShortCuts.Index].Value;


            if (row.Cells[this.colRightKey.Index].Value != null)
                hdpUIConfig.UIRightKey = (string)row.Cells[this.colRightKey.Index].Value;
            if (row.Cells[this.colRightDesc.Index].Value != null)
                hdpUIConfig.UIRightDesc = (string)row.Cells[this.colRightDesc.Index].Value;
            if (row.Cells[this.colUICommand.Index].Value != null)
                hdpUIConfig.UICommand = (string)row.Cells[this.colUICommand.Index].Value;
            else
                hdpUIConfig.UICommand = string.Empty;
            if (row.Cells[this.colUIIcon.Index].Value != null)
                hdpUIConfig.UIIcon = (string)row.Cells[this.colUIIcon.Index].Value;
            if (row.Cells[this.colUIIconSize.Index].Value != null)
                hdpUIConfig.UIIconSize = (string)row.Cells[this.colUIIconSize.Index].Value;
            if (row.Cells[this.colMicroHelp.Index].Value != null)
                hdpUIConfig.MicroHelp = (string)row.Cells[this.colMicroHelp.Index].Value;
            hdpUIConfig.SortIndex = row.Index;
            hdpUIConfig.UIGrade = oldHdpUIConfig.UIGrade;
            if (this.toolbtnMenu.Checked)
                hdpUIConfig.UIType = SystemData.UIType.MENU;
            //向上一行找父级菜单
            for (int index = row.Index; index >= 0; index--)
            {
                if (index <= 0)
                    break;
                HdpUIConfig preHdpUIConfig = this.dataGridView1.Rows[index - 1].Tag as HdpUIConfig;

                if (preHdpUIConfig.UIGrade < hdpUIConfig.UIGrade)
                {
                    hdpUIConfig.ParentID = preHdpUIConfig.UIConfigID;
                    break;
                }
            }
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

            HdpUIConfig hdpUIConfig = row.Tag as HdpUIConfig;
            if (hdpUIConfig == null)
                return SystemData.ReturnValue.FAILED;
            string szUIConfigID = hdpUIConfig.UIConfigID;

            hdpUIConfig = null;
            if (!this.MakeRowData(row, ref hdpUIConfig))
                return SystemData.ReturnValue.FAILED;

            short shRet = SystemData.ReturnValue.OK;
            if (this.dataGridView1.IsDeletedRow(row))
            {
                if (!this.dataGridView1.IsNewRow(row))

                    shRet = HdpUIConfigAccess.Instance.DeleteHdpUIConfig(szUIConfigID);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法删除当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                this.dataGridView1.Rows.Remove(row);
            }
            else if (this.dataGridView1.IsModifiedRow(row))
            {

                shRet = HdpUIConfigAccess.Instance.ModifyHdpUIConfig(hdpUIConfig);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = hdpUIConfig;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            else if (this.dataGridView1.IsNewRow(row))
            {
                shRet = HdpUIConfigAccess.Instance.SaveHdpUIConfig(hdpUIConfig);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = hdpUIConfig;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 增加一行记录
        /// </summary>
        private void AddNewItem()
        {
            int index = 0;
            if (this.dataGridView1.SelectedRows.Count > 0)
                index = this.dataGridView1.SelectedRows[0].Index + 1;
            //创建数据
            HdpUIConfig hdpUIConfig = new HdpUIConfig();
            //创建行
            //int index = this.dataGridView1.Rows.Add();
            DataTableViewRow row = new DataTableViewRow();
            this.dataGridView1.Rows.Insert(index, row);
            //DataTableViewRow row = this.dataGridView1.Rows[index];
            hdpUIConfig.UIConfigID = hdpUIConfig.MakeUIConfigID();
            row.Tag = hdpUIConfig;
            this.dataGridView1.SetRowState(row, RowState.New);
            this.UpdateUIState();

            this.dataGridView1.CurrentCell = row.Cells[this.colShowName.Index];
            this.dataGridView1.BeginEdit(true);
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
                this.SetRowData(row, row.Tag as HdpUIConfig);
            }
            this.UpdateUIState();
            this.dataGridView1.CurrentCell = row.Cells[this.colShowName.Index];
            this.dataGridView1.BeginEdit(true);
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
            if (this.dataGridView1.CurrentCell != null)
                this.dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.UpdateUIState();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            //不允许修改已删除行
            DataTableViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (this.dataGridView1.IsDeletedRow(row))
            {
                e.Cancel = true;
                return;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.ColumnIndex == this.colRightKey.Index)
            {
                FindComboBoxEditingControl control = (e.Control as FindComboBoxEditingControl);
                control.SelectedIndexChanged -= new EventHandler(colRight_SelectedIndexChanged);
                control.SelectedIndexChanged += new EventHandler(colRight_SelectedIndexChanged);
            }


            DataGridViewCell currCell = this.dataGridView1.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colShowName.Index)
                return;
            TextBox textBoxExitingControl = e.Control as TextBox;
            if (textBoxExitingControl == null || textBoxExitingControl.IsDisposed)
                return;
            textBoxExitingControl.ImeMode = ImeMode.Alpha;
            textBoxExitingControl.KeyPress -= new KeyPressEventHandler(this.TextBoxExitingControl_KeyPress);
            textBoxExitingControl.KeyPress += new KeyPressEventHandler(this.TextBoxExitingControl_KeyPress);

        }
        private void colRight_SelectedIndexChanged(object sender, EventArgs e)
        {

            Heren.Common.Controls.TableView.FindComboBoxEditingControl control = sender as Heren.Common.Controls.TableView.FindComboBoxEditingControl;
            if (control.SelectedItem != null)
            {
                RightPoint rightPoint = control.SelectedItem as RightPoint;
                this.dataGridView1.CurrentRow.Cells[this.colRightDesc.Index].Value = rightPoint.RightDesc;
                this.dataGridView1.CurrentRow.Cells[this.colUICommand.Index].Value = rightPoint.RightCommand;
            }
        }

        private void TextBoxExitingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewCell currCell = this.dataGridView1.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colShowName.Index)
                return;
        }

        private void toolcboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadGridComboBoxItem();
            this.LoadHdpUIConfigList();
        }

        private void toolbtnMoveUp_Click(object sender, EventArgs e)
        {
            DataTableViewRow currRow = this.dataGridView1.CurrentRow;
            if (currRow == null)
                return;
            int index = currRow.Index;
            if (!this.dataGridView1.MoveRow(currRow, index - 1))
                return;
            this.dataGridView1.SetRowState(index, RowState.Update);
            this.dataGridView1.SetRowState(index - 1, RowState.Update);
        }

        private void toolbtnMoveDown_Click(object sender, EventArgs e)
        {
            DataTableViewRow currRow = this.dataGridView1.CurrentRow;
            if (currRow == null)
                return;
            int index = currRow.Index;
            if (!this.dataGridView1.MoveRow(currRow, index + 1))
                return;
            this.dataGridView1.SetRowState(index, RowState.Update);
            this.dataGridView1.SetRowState(index + 1, RowState.Update);
        }

        private void toolbtnLeft_Click(object sender, EventArgs e)
        {
            DataTableViewRow currRow = this.dataGridView1.CurrentRow;
            if (currRow == null)
                return;
            int rowIndex = currRow.Index;
            string szShowName = this.dataGridView1.Rows[rowIndex].Cells[this.colShowName.Index].Value.ToString();

            HdpUIConfig hdpUIConfig = this.dataGridView1.Rows[rowIndex].Tag as HdpUIConfig;
            //升级处理
            if (hdpUIConfig.UIGrade <= 0)
                return;
            hdpUIConfig.UIGrade = hdpUIConfig.UIGrade - 1;
            //级别标记为空格
            string flag = string.Empty;
            for (int index = 0; index < hdpUIConfig.UIGrade; index++)
            {
                flag += "  ";
            }
            this.dataGridView1.Rows[rowIndex].Cells[this.colShowName.Index].Value = flag + hdpUIConfig.ShowName;
            this.dataGridView1.SetRowState(rowIndex, RowState.Update);
        }

        private void toolbtnRight_Click(object sender, EventArgs e)
        {
            DataTableViewRow currRow = this.dataGridView1.CurrentRow;
            if (currRow == null)
                return;
            int rowIndex = currRow.Index;
            HdpUIConfig hdpUIConfig = this.dataGridView1.Rows[rowIndex].Tag as HdpUIConfig;
            string szShowName = string.Empty;
            if (this.dataGridView1.Rows[rowIndex].Cells[this.colShowName.Index].Value != null)
            {

                hdpUIConfig.ShowName = this.dataGridView1.Rows[rowIndex].Cells[this.colShowName.Index].Value.ToString().Trim();
            }
            //降级处理
            hdpUIConfig.UIGrade = hdpUIConfig.UIGrade + 1;
            //级别标记为空格
            string flag = string.Empty;
            for (int index = 0; index < hdpUIConfig.UIGrade; index++)
            {
                flag += "  ";
            }
            this.dataGridView1.Rows[rowIndex].Cells[this.colShowName.Index].Value = flag + hdpUIConfig.ShowName;
            this.dataGridView1.SetRowState(rowIndex, RowState.Update);
        }

        private void MenuConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void toolbtnMenu_Click(object sender, EventArgs e)
        {
            this.toolbtnMenu.Checked = true;
            this.LoadHdpUIConfigList();

        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.dataGridView1.Rows[e.RowIndex].IsNormalRow)
            //    return;
            if (e.ColumnIndex == this.colUIIcon.Index)
            {
                IconSelectForm form = new IconSelectForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[this.colUIIcon.Index].Value = form.pictureBox1.Tag.ToString();
                    this.dataGridView1.Rows[e.RowIndex].Cells[this.colUIIconSize.Index].Value = form.pictureBox1.Image.Size.ToString();
                    this.dataGridView1.SetRowState(e.RowIndex, RowState.Update);
                }
            }
        }

        private void toolcboResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadHdpUIConfigList();
        }
    }
}