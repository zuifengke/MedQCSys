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
using Heren.MedQC.Hdp.Properties;

namespace Heren.MedQC.Hdp
{
    public partial class ProductManageForm : DockContentBase
    {
        public ProductManageForm(MainForm form) : base(form)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dgvProductList.Font = new Font("宋体", 10.5f);
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
            this.LoadHdpProductList();
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
        private void LoadHdpProductList()
        {
            this.dgvProductList.Rows.Clear();
            List<HdpProduct> lstHdpProducts = null;
            short shRet = HdpProductAccess.Instance.GetHdpProductList(ref lstHdpProducts);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取病案质量问题分类字典失败！");
                return;
            }
            if (lstHdpProducts == null || lstHdpProducts.Count <= 0)
                return;
            for (int index = 0; index < lstHdpProducts.Count; index++)
            {
                HdpProduct hdpProduct = lstHdpProducts[index];

                int nRowIndex = this.dgvProductList.Rows.Add();
                DataTableViewRow row = this.dgvProductList.Rows[nRowIndex];
                row.Tag = hdpProduct; //将记录信息保存到该行
                this.SetRowData(row, hdpProduct);
                this.dgvProductList.SetRowState(row, RowState.Normal);
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

            if (this.dgvProductList.SelectedRows.Count <= 0)
                return;
            DataTableViewRow currRow = this.dgvProductList.SelectedRows[0];
            if (!this.dgvProductList.IsDeletedRow(currRow))
            {
                if (this.dgvProductList.IsNormalRow(currRow)
                    || this.dgvProductList.IsModifiedRow(currRow))
                {
                    this.toolbtnModify.Enabled = true;
                    this.mnuModifyItem.Enabled = true;
                  
                }
            }

            this.toolbtnDelete.Text = "删除";
            this.mnuDeleteItem.Text = "删除";
            this.toolbtnModify.Text = "修改";
            this.mnuModifyItem.Text = "修改";
            if (this.dgvProductList.IsDeletedRow(currRow))
            {
                this.toolbtnDelete.Text = "取消删除";
                this.mnuDeleteItem.Text = "取消删除";
            }
            else if (this.dgvProductList.IsModifiedRow(currRow))
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
            if (this.dgvProductList.Rows.Count <= 0)
                return false;
            foreach (DataTableViewRow row in this.dgvProductList.Rows)
            {
                if (this.dgvProductList.IsDeletedRow(row))
                    return true;
                if (this.dgvProductList.IsNewRow(row))
                    return true;
                if (this.dgvProductList.IsModifiedRow(row))
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
            if (this.dgvProductList.Rows.Count <= 0) return true;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            int index = 0;
            int count = 0;
            short shRet = SystemData.ReturnValue.OK;
            this.dgvProductList.EndEdit();
            while (index < this.dgvProductList.Rows.Count)
            {
                DataTableViewRow row = this.dgvProductList.Rows[index];
                bool bIsDeletedRow = this.dgvProductList.IsDeletedRow(row);
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
                szMessageText = string.Format("保存中止,已保存{0}条记录！", count);
            else
                szMessageText = string.Format("保存成功,已保存{0}条记录！", count);
            MessageBoxEx.Show(szMessageText, MessageBoxIcon.Information);
            return shRet == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="hdpProduct">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataGridViewRow row, HdpProduct hdpProduct)
        {
            if (row == null || row.Index < 0 || hdpProduct == null)
                return false;
            row.Tag = hdpProduct;
            row.Cells[this.colSerialNO.Index].Value = hdpProduct.SERIAL_NO;
            row.Cells[this.colCnName.Index].Value = hdpProduct.CN_NAME;
            row.Cells[this.colEnName.Index].Value = hdpProduct.EN_NAME;
            row.Cells[this.colNameShort.Index].Value = hdpProduct.NAME_SHORT;
            row.Cells[this.colProductBak.Index].Value = hdpProduct.PRODUCT_BAK;

            return true;
        }

        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="hdpProduct">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref HdpProduct hdpProduct)
        {
            if (row == null || row.Index < 0)
                return false;
            hdpProduct = new HdpProduct();
            HdpProduct oldHdpProduct = row.Tag as HdpProduct;
            if (!this.dgvProductList.IsNewRow(row))
            {
                if (oldHdpProduct == null)
                {
                    MessageBoxEx.Show("质量问题分类字典行数据信息为空！");
                    return false;
                }
            }

            if (this.dgvProductList.IsDeletedRow(row))
            {
                hdpProduct = oldHdpProduct;
                return true;
            }
            if (GlobalMethods.Misc.IsEmptyString(row.Cells[this.colSerialNO.Index].Value.ToString()))
            {
                this.dgvProductList.CurrentCell = row.Cells[this.colSerialNO.Index];
                this.dgvProductList.BeginEdit(true);
                MessageBoxEx.Show("您必须设置序号！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colNameShort.Index].Value))
            {
                this.dgvProductList.CurrentCell = row.Cells[this.colNameShort.Index];
                this.dgvProductList.BeginEdit(true);
                MessageBoxEx.Show("您必须设置产品缩写！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colEnName.Index].Value))
            {
                this.dgvProductList.CurrentCell = row.Cells[this.colEnName.Index];
                this.dgvProductList.BeginEdit(true);
                MessageBoxEx.Show("您必须设置英文名称！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colCnName.Index].Value))
            {
                MessageBoxEx.Show("您必须设置中文名称！");
                return false;
            }
            if (hdpProduct == null) hdpProduct = new HdpProduct();
            hdpProduct.SERIAL_NO = row.Cells[this.colSerialNO.Index].Value.ToString();
            hdpProduct.NAME_SHORT = (string)row.Cells[this.colNameShort.Index].Value;
            hdpProduct.CN_NAME = (string)row.Cells[this.colCnName.Index].Value;
            hdpProduct.EN_NAME = (string)row.Cells[this.colEnName.Index].Value;
            hdpProduct.PRODUCT_BAK = row.Cells[this.colProductBak.Index].Value == null ? "" : (string)row.Cells[this.colProductBak.Index].Value;
            return true;
        }

        /// <summary>
        /// 保存指定行的数据到远程数据表,需要注意的是：行的删除状态会与其他状态共存
        /// </summary>
        /// <param name="row">指定行</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short SaveRowData(DataTableViewRow row)
        {
            if (row == null || row.Index < 0) return SystemData.ReturnValue.FAILED;
            if (this.dgvProductList.IsNormalRow(row) || this.dgvProductList.IsUnknownRow(row))
            {
                if (!this.dgvProductList.IsDeletedRow(row)) return SystemData.ReturnValue.CANCEL;
            }

            HdpProduct hdpProduct = row.Tag as HdpProduct;
            if (hdpProduct == null) return SystemData.ReturnValue.FAILED;
            string szNameShort = hdpProduct.NAME_SHORT;

            hdpProduct = null;
            if (!this.MakeRowData(row, ref hdpProduct)) return SystemData.ReturnValue.FAILED;

            short shRet = SystemData.ReturnValue.OK;
            if (this.dgvProductList.IsDeletedRow(row))
            {
                if (!this.dgvProductList.IsNewRow(row)) shRet = HdpProductAccess.Instance.DeleteHdpProduct(szNameShort);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dgvProductList.SelectRow(row);
                    MessageBoxEx.Show("无法删除当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                this.dgvProductList.Rows.Remove(row);
            }
            else if (this.dgvProductList.IsModifiedRow(row))
            {

                shRet = HdpProductAccess.Instance.ModifyHdpProduct(hdpProduct, szNameShort);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dgvProductList.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = hdpProduct;
                this.dgvProductList.SetRowState(row, RowState.Normal);
            }
            else if (this.dgvProductList.IsNewRow(row))
            {

                shRet = HdpProductAccess.Instance.SaveHdpProduct(hdpProduct);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dgvProductList.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = hdpProduct;
                this.dgvProductList.SetRowState(row, RowState.Normal);
            }
    
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 增加一行记录
        /// </summary>
        private void AddNewItem()
        {
            //创建数据
            HdpProduct qcEventInfo = new HdpProduct();
            //创建行
            int maxNo = 0;
            foreach (DataTableViewRow oneRow in dgvProductList.Rows)
            {
                string szSerialNO = oneRow.Cells[this.colSerialNO.Index].Value.ToString();
                if (!string.IsNullOrEmpty(szSerialNO) && maxNo < int.Parse(szSerialNO)) maxNo = int.Parse(szSerialNO);
            }
            int index = this.dgvProductList.Rows.Add();
            DataTableViewRow row = this.dgvProductList.Rows[index];
            row.Cells[this.colSerialNO.Index].Value = maxNo + 1;
            row.Tag = qcEventInfo;
            this.dgvProductList.SetRowState(row, RowState.New);
            this.UpdateUIState();
            this.dgvProductList.CurrentCell = row.Cells[this.colNameShort.Index];
            this.dgvProductList.BeginEdit(true);
        }

        /// <summary>
        ///修改选中行数据
        /// </summary>
        private void ModifySelectedItem()
        {
            if (this.dgvProductList.SelectedRows.Count <= 0)
                return;


            DataTableViewRow row = this.dgvProductList.SelectedRows[0];
          
            if (this.dgvProductList.IsNormalRow(row))
            {
                this.dgvProductList.SetRowState(row, RowState.Update);
            }
            else if (this.dgvProductList.IsModifiedRow(row))
            {
                this.dgvProductList.SetRowState(row, RowState.Normal);
                this.SetRowData(row, row.Tag as HdpProduct);
            }
            this.UpdateUIState();
            this.dgvProductList.CurrentCell = row.Cells[this.colNameShort.Index];
            this.dgvProductList.BeginEdit(true);
        }

        /// <summary>
        /// 删除选中行记录
        /// </summary>
        private void DeleteSelectedItem()
        {
            if (this.dgvProductList.SelectedRows.Count <= 0)
                return;


            DataTableViewRow row = this.dgvProductList.SelectedRows[0];
            if (this.dgvProductList.IsDeletedRow(row))
            {
                if (this.dgvProductList.IsNewRow(row))
                    this.dgvProductList.SetRowState(row, RowState.New);
                else if (this.dgvProductList.IsModifiedRow(row))
                    this.dgvProductList.SetRowState(row, RowState.Update);
                else if (this.dgvProductList.IsNormalRow(row))
                    this.dgvProductList.SetRowState(row, RowState.Normal);
                else
                    this.dgvProductList.SetRowState(row, RowState.Unknown);
            }
            else
            {
                this.dgvProductList.SetRowState(row, RowState.Delete);
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
            if (this.dgvProductList.CurrentCell != null)
                this.dgvProductList.BeginEdit(true);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.UpdateUIState();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            //不允许修改已删除行
            DataTableViewRow row = this.dgvProductList.Rows[e.RowIndex];
            if (this.dgvProductList.IsDeletedRow(row))
            {
                e.Cancel = true;
                return;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell currCell = this.dgvProductList.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colNameShort.Index)
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
            DataGridViewCell currCell = this.dgvProductList.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colNameShort.Index)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModifySelectedItem();
        }

        private void tsbSetDefault_Click(object sender, EventArgs e)
        {
            if (this.dgvProductList.SelectedRows.Count <= 0)
                return;
            DataGridViewRow selectedRow = this.dgvProductList.SelectedRows[0];
            if (selectedRow == null)
                return;
        }
    }
}