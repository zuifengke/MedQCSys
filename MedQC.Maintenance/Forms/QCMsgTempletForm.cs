// ***********************************************************
// 病案质控系统质控问题模板维护窗口.
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
using System.Text.RegularExpressions;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Controls;
using Heren.Common.Controls.TableView;

using EMRDBLib.DbAccess;
using EMRDBLib;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Maintenance
{
    public partial class QCMsgTempletForm : DockContentBase
    {
        public QCMsgTempletForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
            //this.dataGridView1.AutoReadonly = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.OnRefreshView();
        }

        /// <summary>
        /// 刷新病案质量问题分类信息列表
        /// </summary>
        public override void OnRefreshView()
        {
            if (!this.SaveUncommitedChange())
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在刷新质控质检问题字典，请稍候...");

            this.LoadQCMessageTempletList();
            this.UpdateUIState();

            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 装载反馈质控信息字典
        /// </summary>
        private void LoadQCMessageTempletList()
        {
            this.dataGridView1.Rows.Clear();
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            List<EMRDBLib.QcMsgDict> lstQCMessageTemplets = null;
            short shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(ref lstQCMessageTemplets);
            if (shRet == SystemData.ReturnValue.RES_NO_FOUND)
            {
                this.MainForm.ShowStatusMessage("未找到记录");
                return;
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("获取反馈质控信息字典失败！");
                return;
            }
            if (lstQCMessageTemplets == null || lstQCMessageTemplets.Count <= 0)
                return;
            this.RefreshQCEventTypeColumn();
            for (int index = 0; index < lstQCMessageTemplets.Count; index++)
            {
                EMRDBLib.QcMsgDict qcMessageTemplet = lstQCMessageTemplets[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = qcMessageTemplet;
                this.SetRowData(row, qcMessageTemplet);
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
        }

        /// <summary>
        /// 刷新下拉列表加载项
        /// </summary>
        private void RefreshQCEventTypeColumn()
        {
            this.colQCEventType.Items.Clear();
            List<EMRDBLib.QaEventTypeDict> lstQCEventTypes = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQCEventTypes);
            if (shRet == SystemData.ReturnValue.RES_NO_FOUND)
            {
                this.MainForm.ShowStatusMessage("未找到记录");
                return;
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("获取病案质量问题分类字典失败！");
                return;
            }
            if (lstQCEventTypes == null || lstQCEventTypes.Count <= 0)
                return;
            for (int index = 0; index < lstQCEventTypes.Count; index++)
            {
                if (!string.IsNullOrEmpty(lstQCEventTypes[index].PARENT_CODE))
                    continue;
                EMRDBLib.QaEventTypeDict qcEventType = lstQCEventTypes[index];
                this.colQCEventType.Items.Add(qcEventType.QA_EVENT_TYPE);
            }
            this.colQCEventType.DisplayStyle = ComboBoxStyle.DropDownList;
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
                if (this.dataGridView1.IsNormalRow(currRow) || this.dataGridView1.IsModifiedRow(currRow))
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
        public override bool HasUncommit()
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
        public override bool CommitModify()
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
        /// <param name="qcMessageTemplet">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataGridViewRow row, EMRDBLib.QcMsgDict qcMessageTemplet)
        {
            if (row == null || row.Index < 0 || qcMessageTemplet == null)
                return false;
            row.Tag = qcMessageTemplet;
            row.Cells[this.colSerialNO.Index].Value = qcMessageTemplet.SERIAL_NO;
            row.Cells[this.colQCEventType.Index].Value = qcMessageTemplet.QA_EVENT_TYPE;
            row.Cells[this.colQCMsgCode.Index].Value = qcMessageTemplet.QC_MSG_CODE;
            row.Cells[this.colMessage.Index].Value = qcMessageTemplet.MESSAGE;
            row.Cells[this.colMessageTitle.Index].Value = qcMessageTemplet.MESSAGE_TITLE;
            row.Cells[this.colScore.Index].Value =
                Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcMessageTemplet.SCORE, 0f)), 1).ToString("F1");
            row.Cells[this.colIsVeto.Index].Value = qcMessageTemplet.ISVETO ? "是" : "否";
            return true;
        }

        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="qcMessageTemplet">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref EMRDBLib.QcMsgDict qcMessageTemplet)
        {
            if (row == null || row.Index < 0)
                return false;
            qcMessageTemplet = new EMRDBLib.QcMsgDict();
            EMRDBLib.QcMsgDict oldQCMessageTemplet = row.Tag as EMRDBLib.QcMsgDict;
            if (!this.dataGridView1.IsNewRow(row))
            {
                if (oldQCMessageTemplet == null)
                {
                    MessageBoxEx.Show("质控质检问题字典行数据信息为空！");
                    return false;
                }
            }

            if (this.dataGridView1.IsDeletedRow(row))
            {
                qcMessageTemplet = oldQCMessageTemplet;
                return true;
            }
            object cellValue = row.Cells[this.colSerialNO.Index].Value;
            if (cellValue == null || GlobalMethods.Misc.IsEmptyString(cellValue.ToString()))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colSerialNO.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您必须设置序号！");
                return false;
            }

            cellValue = row.Cells[this.colQCEventType.Index].Value;
            if (cellValue == null || GlobalMethods.Misc.IsEmptyString(cellValue.ToString()))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colQCEventType.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您必须设置问题类型！");
                return false;
            }

            cellValue = row.Cells[this.colQCMsgCode.Index].Value;
            if (cellValue == null || GlobalMethods.Misc.IsEmptyString(cellValue.ToString()))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colQCEventType.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您必须设置问题代码！");
                return false;
            }
            cellValue = row.Cells[this.colScore.Index].Value;

            if (cellValue == null)
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colScore.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您必须设置分数！");
                return false;
            }
            string szRegexString = "^[0-9]+(.[0-9]{0,2})?$";
            Match m = Regex.Match((string)cellValue, szRegexString);
            if (!m.Success)
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colScore.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您输入的分数不正确！");
                return false;
            }

            if (qcMessageTemplet == null)
                qcMessageTemplet = new EMRDBLib.QcMsgDict();
            qcMessageTemplet.SERIAL_NO = int.Parse(row.Cells[this.colSerialNO.Index].Value.ToString());
            qcMessageTemplet.QA_EVENT_TYPE = (string)row.Cells[this.colQCEventType.Index].Value;
            qcMessageTemplet.QC_MSG_CODE = (string)row.Cells[this.colQCMsgCode.Index].Value;
            qcMessageTemplet.MESSAGE = (string)row.Cells[this.colMessage.Index].Value;
            qcMessageTemplet.MESSAGE_TITLE = row.Cells[this.colMessageTitle.Index].Value == null ?
                string.Empty : (string)row.Cells[this.colMessageTitle.Index].Value;
            qcMessageTemplet.SCORE = float.Parse(row.Cells[this.colScore.Index].Value.ToString());
            qcMessageTemplet.ISVETO = (string)row.Cells[this.colIsVeto.Index].Value == "是";
            qcMessageTemplet.APPLY_ENV = "MEDDOC";
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

            EMRDBLib.QcMsgDict qcMessageTemplet = row.Tag as EMRDBLib.QcMsgDict;
            if (qcMessageTemplet == null)
                return SystemData.ReturnValue.FAILED;
            string szQCMsgCode = qcMessageTemplet.QC_MSG_CODE;

            qcMessageTemplet = null;
            if (!this.MakeRowData(row, ref qcMessageTemplet))
                return SystemData.ReturnValue.FAILED;

            short shRet = SystemData.ReturnValue.OK;
            if (this.dataGridView1.IsDeletedRow(row))
            {
                if (!this.dataGridView1.IsNewRow(row))
                    shRet = QcMsgDictAccess.Instance.Delete(szQCMsgCode);
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
                shRet = QcMsgDictAccess.Instance.Update(qcMessageTemplet, szQCMsgCode);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = qcMessageTemplet;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            else if (this.dataGridView1.IsNewRow(row))
            {
                shRet = QcMsgDictAccess.Instance.Insert(qcMessageTemplet);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = qcMessageTemplet;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 增加一行记录
        /// </summary>
        private void AddNewItem()
        {
            if (SystemParam.Instance.UserRight == null)
                return;

            ////创建数据
            //EMRDBLib.QCMessageTemplet qcMessageInfo = new EMRDBLib.QCMessageTemplet();
            ////创建行
            //int index = this.dataGridView1.Rows.Add();
            //DataTableViewRow row = this.dataGridView1.Rows[index];
            //row.Tag = qcMessageInfo;
            //this.dataGridView1.SetRowState(row, RowState.New);
            //this.UpdateUIState();

            //this.dataGridView1.CurrentCell = row.Cells[this.colSerialNO.Index];
            //this.dataGridView1.BeginEdit(true);


            EMRDBLib.QcMsgDict qcMessageTemplet = null;
            DataTableViewRow currRow = this.dataGridView1.CurrentRow;
            if (currRow != null && currRow.Index >= 0)
                qcMessageTemplet = currRow.Tag as EMRDBLib.QcMsgDict;
            if (qcMessageTemplet == null)
                qcMessageTemplet = new QcMsgDict();
            else
                qcMessageTemplet = qcMessageTemplet.Clone() as QcMsgDict;

            int nRowIndex = this.dataGridView1.Rows.Add();
            DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
            this.SetRowData(row, qcMessageTemplet);
            this.dataGridView1.Focus();
            this.dataGridView1.SelectRow(row);
            this.dataGridView1.SetRowState(row, RowState.New);
            this.dataGridView1.CurrentCell = row.Cells[this.colSerialNO.Index];
            this.dataGridView1.BeginEdit(true);
        }

        /// <summary>
        ///修改选中行数据
        /// </summary>
        private void ModifySelectedItem()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;

            if (SystemParam.Instance.UserRight == null)
                return;

           

            DataTableViewRow row = this.dataGridView1.SelectedRows[0];
            if (this.dataGridView1.IsNormalRow(row))
            {
                this.dataGridView1.SetRowState(row, RowState.Update);
            }
            else if (this.dataGridView1.IsModifiedRow(row))
            {
                this.dataGridView1.SetRowState(row, RowState.Normal);
                this.SetRowData(row, row.Tag as EMRDBLib.QcMsgDict);
            }
            this.UpdateUIState();
            this.dataGridView1.CurrentCell = row.Cells[this.colSerialNO.Index];
            this.dataGridView1.BeginEdit(true);
        }

        /// <summary>
        /// 删除选中行记录
        /// </summary>
        private void DeleteSelectedItem()
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;

            if (SystemParam.Instance.UserRight == null)
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
            if (SystemParam.Instance.UserRight == null)
                return;

           
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
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (e.ColumnIndex == this.colMessageTitle.Index && !row.ReadOnly)
            {
                if (row.Cells[this.colQCEventType.Index].Value == null)
                {
                    MessageBoxEx.Show("选择问题子类前请先选择问题大类！", MessageBoxIcon.Warning);
                    return;
                }
                RefreshMessageTitleColumn(row);
            }
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

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (e.ColumnIndex == this.colQCEventType.Index)
            {
                this.ShowStatusMessage("正在刷新质量问题分类字典，请稍候...");
                this.RefreshQCEventTypeColumn();
            }

            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        //刷新问题分类对应的子类问题字典
        private void RefreshMessageTitleColumn(DataGridViewRow row)
        {
            string szQCEventType = row.Cells[this.colQCEventType.Index].Value.ToString();
            this.colMessageTitle.Items.Clear();
            List<EMRDBLib.QaEventTypeDict> lstQCEventTypes = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQCEventTypes);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("获取病案质量问题分类字典失败！");
                return;
            }
            if (lstQCEventTypes == null || lstQCEventTypes.Count <= 0)
                return;
            EMRDBLib.QaEventTypeDict selectedQCEventType = lstQCEventTypes.Find(delegate (EMRDBLib.QaEventTypeDict item) { return item.QA_EVENT_TYPE == szQCEventType; });
            if (selectedQCEventType == null || !string.IsNullOrEmpty(selectedQCEventType.PARENT_CODE))
                return;
            for (int index = 0; index < lstQCEventTypes.Count; index++)
            {
                if (selectedQCEventType.INPUT_CODE != lstQCEventTypes[index].PARENT_CODE)
                    continue;
                EMRDBLib.QaEventTypeDict qcEventType = lstQCEventTypes[index];
                this.colMessageTitle.Items.Add(qcEventType.QA_EVENT_TYPE);
            }
            this.colMessageTitle.DisplayStyle = ComboBoxStyle.DropDownList;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell currCell = this.dataGridView1.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colQCEventType.Index
                 || currCell.ColumnIndex == this.colMessage.Index)
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
            DataGridViewCell currCell = this.dataGridView1.CurrentCell;
            if (currCell == null)
                return;

            if (currCell.ColumnIndex == this.colQCMsgCode.Index)
            {
                if (e.KeyChar == (char)((int)Keys.Back))
                    return;
                if (e.KeyChar.CompareTo('0') >= 0 && e.KeyChar.CompareTo('9') <= 0)
                    return;
                if (e.KeyChar.CompareTo('a') >= 0 && e.KeyChar.CompareTo('z') <= 0)
                {
                    char chRet = e.KeyChar;
                    char.TryParse(e.KeyChar.ToString().ToUpper(), out chRet);
                    e.KeyChar = chRet;
                    return;
                }
                if (e.KeyChar.CompareTo('A') >= 0 && e.KeyChar.CompareTo('Z') <= 0)
                    return;
                e.Handled = true;
            }
            else if (currCell.ColumnIndex == this.colSerialNO.Index || currCell.ColumnIndex == this.colScore.Index)
            {
                if (e.KeyChar == (char)((int)Keys.Back))
                    return;
                if (e.KeyChar.CompareTo('0') >= 0 && e.KeyChar.CompareTo('9') <= 0)
                    return;
                if (currCell.ColumnIndex == this.colScore.Index && e.KeyChar.CompareTo('.') == 0)
                    return;
                e.Handled = true;
            }
        }
    }
}