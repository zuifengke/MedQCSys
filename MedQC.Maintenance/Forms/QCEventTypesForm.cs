// ***********************************************************
// 病案质控系统质控问题类型维护窗口.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.Controls.TableView;
using Heren.Common.DockSuite;

using EMRDBLib.DbAccess;
using EMRDBLib;
using MedQCSys;
using MedQCSys.DockForms;

namespace Heren.MedQC.Maintenance
{
    public partial class QCEventTypesForm : DockContentBase
    {
        public QCEventTypesForm(MainForm parent)
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

        public override void OnRefreshView()
        {
            if (!this.SaveUncommitedChange())
                return;
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在刷新质量问题分类字典，请稍候...");

            this.LoadQCEventTypeList();
            this.UpdateUIState();

            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 装载病案质量问题分类信息
        /// </summary>
        private void LoadQCEventTypeList()
        {
            this.dataGridView1.Rows.Clear();
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
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            for (int index = 0; index < lstQCEventTypes.Count; index++)
            {
                //跳过子类问题
                if (!string.IsNullOrEmpty(lstQCEventTypes[index].PARENT_CODE))
                    continue;

                EMRDBLib.QaEventTypeDict qcEventType = lstQCEventTypes[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = qcEventType; //将记录信息保存到该行
                this.SetRowData(row, qcEventType);
                this.dataGridView1.SetRowState(row, RowState.Normal);

                //加载子类问题类型
                if (!ht.Contains(qcEventType.INPUT_CODE))
                {
                    for (int index2 = 0; index2 < lstQCEventTypes.Count; index2++)
                    {
                        EMRDBLib.QaEventTypeDict secQcEventType = lstQCEventTypes[index2];
                        if (secQcEventType.PARENT_CODE != qcEventType.INPUT_CODE)
                            continue;
                        int nRowIndex2 = this.dataGridView1.Rows.Add();
                        DataTableViewRow secRow = this.dataGridView1.Rows[nRowIndex2];
                        secRow.Tag = qcEventType; //将记录信息保存到该行
                        this.SetRowData(secRow, secQcEventType);
                        this.dataGridView1.SetRowState(secRow, RowState.Normal);
                    }
                    ht.Add(qcEventType.INPUT_CODE, qcEventType.QA_EVENT_TYPE);
                }
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
        /// <param name="qcEventType">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataGridViewRow row, EMRDBLib.QaEventTypeDict qcEventType)
        {
            if (row == null || row.Index < 0 || qcEventType == null)
                return false;
            row.Tag = qcEventType;
            row.Cells[this.colSerialNO.Index].Value = qcEventType.SERIAL_NO;
            row.Cells[this.colTypeDesc.Index].Value = qcEventType.QA_EVENT_TYPE;
            row.Cells[this.colInputCode.Index].Value = qcEventType.INPUT_CODE;
            row.Cells[this.colMaxScore.Index].Value = qcEventType.MAX_SCORE;
            if (!string.IsNullOrEmpty(qcEventType.PARENT_CODE))
                row.Cells[this.colSerialNO.Index].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            return true;
        }

        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="qcEventType">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref EMRDBLib.QaEventTypeDict qcEventType)
        {
            if (row == null || row.Index < 0)
                return false;
            qcEventType = new EMRDBLib.QaEventTypeDict();
            EMRDBLib.QaEventTypeDict oldQCEventType = row.Tag as EMRDBLib.QaEventTypeDict;
            if (!this.dataGridView1.IsNewRow(row))
            {
                if (oldQCEventType == null)
                {
                    MessageBoxEx.Show("质量问题分类字典行数据信息为空！");
                    return false;
                }
            }

            if (this.dataGridView1.IsDeletedRow(row))
            {
                qcEventType = oldQCEventType;
                return true;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colSerialNO.Index].Value.ToString()))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colSerialNO.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您必须设置序号！");
                return false;
            }
            if (GlobalMethods.Misc.IsEmptyString((string)row.Cells[this.colTypeDesc.Index].Value))
            {
                this.dataGridView1.CurrentCell = row.Cells[this.colTypeDesc.Index];
                this.dataGridView1.BeginEdit(true);
                MessageBoxEx.Show("您必须设置问题类型！");
                return false;
            }
            if (qcEventType == null)
                qcEventType = new EMRDBLib.QaEventTypeDict();
            qcEventType.SERIAL_NO =int.Parse(row.Cells[this.colSerialNO.Index].Value.ToString());
            qcEventType.QA_EVENT_TYPE = (string)row.Cells[this.colTypeDesc.Index].Value;
            qcEventType.INPUT_CODE = (string)row.Cells[this.colInputCode.Index].Value;
            qcEventType.MAX_SCORE = Convert.ToDouble(row.Cells[this.colMaxScore.Index].Value);
            qcEventType.PARENT_CODE = oldQCEventType.PARENT_CODE;
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

            EMRDBLib.QaEventTypeDict qcEventType = row.Tag as EMRDBLib.QaEventTypeDict;
            if (qcEventType == null)
                return SystemData.ReturnValue.FAILED;
            string szInputCode = qcEventType.INPUT_CODE;

            qcEventType = null;
            if (!this.MakeRowData(row, ref qcEventType))
                return SystemData.ReturnValue.FAILED;

            short shRet = SystemData.ReturnValue.OK;
            if (this.dataGridView1.IsDeletedRow(row))
            {
                if (!this.dataGridView1.IsNewRow(row))
                    shRet = QaEventTypeDictAccess.Instance.Delete(szInputCode);
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
                shRet = QaEventTypeDictAccess.Instance.Update(qcEventType, szInputCode);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录，输入码可能重复！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = qcEventType;
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
            else if (this.dataGridView1.IsNewRow(row))
            {
                shRet = QaEventTypeDictAccess.Instance.Insert(qcEventType);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataGridView1.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录，输入码可能重复！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = qcEventType;
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

            
            EMRDBLib.QaEventTypeDict qcEventInfo = null;
            DataTableViewRow currRow = this.dataGridView1.CurrentRow;
            if (currRow != null && currRow.Index >= 0)
                qcEventInfo = currRow.Tag as EMRDBLib.QaEventTypeDict;
            if (qcEventInfo == null)
                qcEventInfo = new QaEventTypeDict();
            else
                qcEventInfo = qcEventInfo.Clone() as QaEventTypeDict;

            int nRowIndex = this.dataGridView1.Rows.Add();
            DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
            this.SetRowData(row, qcEventInfo);
            this.dataGridView1.Focus();
            this.dataGridView1.SelectRow(row);
            this.dataGridView1.SetRowState(row, RowState.New);
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
                this.SetRowData(row, row.Tag as EMRDBLib.QaEventTypeDict);
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
            DataGridViewCell currCell = this.dataGridView1.CurrentCell;
            if (currCell == null || currCell.ColumnIndex == this.colTypeDesc.Index)
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
            if (currCell == null || currCell.ColumnIndex == this.colTypeDesc.Index)
                return;

            if (currCell.ColumnIndex == this.colSerialNO.Index)
            {
                if (e.KeyChar == (char)((int)Keys.Back))
                    return;
                if (e.KeyChar.CompareTo('0') >= 0 && e.KeyChar.CompareTo('9') <= 0)
                    return;
                e.Handled = true;
            }
            else if (currCell.ColumnIndex == this.colInputCode.Index)
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
            else if (currCell.ColumnIndex == this.colMaxScore.Index)
            {
                if (e.KeyChar == (char)((int)Keys.Back))
                    return;
                if (e.KeyChar.CompareTo('.') == 0)
                    return;
                if (e.KeyChar.CompareTo('0') >= 0 && e.KeyChar.CompareTo('9') <= 0)
                    return;
                e.Handled = true;
            }
        }

        private void toolBtnSecNew_Click(object sender, EventArgs e)
        {
            
            this.AddSecNewItem();
        }
        /// <summary>
        /// 新增子类问题类型行
        /// </summary>
        private void AddSecNewItem()
        {
            if (SystemParam.Instance.UserRight == null)
                return;

           
            //判断当前选中行是否是一级问题类型
            DataTableViewRow selectedRow = this.dataGridView1.SelectedRows[0];
            if (selectedRow == null)
            {
                MessageBoxEx.Show("添加子类问题前请选择问题分类！", MessageBoxIcon.Warning);
                return;
            }
            EMRDBLib.QaEventTypeDict selectedQCEventType = selectedRow.Tag as EMRDBLib.QaEventTypeDict;
            if (selectedQCEventType == null || !string.IsNullOrEmpty(selectedQCEventType.PARENT_CODE))
            {
                MessageBoxEx.Show("子类问题下不再允许添加问题分类！", MessageBoxIcon.Warning);
                return;
            }
            //创建数据
            EMRDBLib.QaEventTypeDict qcEventInfo = new EMRDBLib.QaEventTypeDict();
            qcEventInfo.PARENT_CODE = selectedQCEventType.INPUT_CODE;
            //创建行
            int index = selectedRow.Index + 1;
            DataTableViewRow row = new DataTableViewRow();
            this.dataGridView1.Rows.Insert(index, row);
            row = dataGridView1.Rows[index];
            row.Tag = qcEventInfo;

            row.Cells[this.colSerialNO.Index].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.SetRowState(row, RowState.New);
            this.UpdateUIState();

            this.dataGridView1.CurrentCell = row.Cells[this.colSerialNO.Index];
            this.dataGridView1.BeginEdit(true);
        }

        private void tsBtnAutoSerialNo_Click(object sender, EventArgs e)
        {
            //序号根据问题分类生成
            //字典排序规则，先按分类序号，在按代码
            List<QaEventTypeDict> lstQaEventTypeDict = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQaEventTypeDict);
            List<QcMsgDict> lstQcMsgDict = null;
            shRet = QcMsgDictAccess.Instance.GetAllQcMsgDictList(ref lstQcMsgDict);
            WorkProcess.Instance.Initialize(this, lstQcMsgDict.Count, "正在按分类排序生成问题字典序号");
            foreach (QcMsgDict item in lstQcMsgDict)
            {
                if(WorkProcess.Instance.Canceled)
                {
                    WorkProcess.Instance.Close();
                    break;
                }
                WorkProcess.Instance.Show(string.Format("已完成{0}条...",lstQcMsgDict.IndexOf(item)),lstQcMsgDict.IndexOf(item), true);
                QaEventTypeDict qaEventTypeDict = null;
                if (string.IsNullOrEmpty(item.MESSAGE_TITLE))
                {
                    qaEventTypeDict = lstQaEventTypeDict.Where(m => m.QA_EVENT_TYPE == item.QA_EVENT_TYPE && m.PARENT_CODE == null).FirstOrDefault();
                }
                else
                {
                    qaEventTypeDict = lstQaEventTypeDict.Where(m => m.QA_EVENT_TYPE == item.MESSAGE_TITLE && m.PARENT_CODE != null).FirstOrDefault();
                }
                if (qaEventTypeDict == null)
                    continue;
                item.SERIAL_NO = qaEventTypeDict.SERIAL_NO;
                shRet = QcMsgDictAccess.Instance.Update(item, item.QC_MSG_CODE);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowError("生成失败");
                    WorkProcess.Instance.Close();
                    return;
                }
            }
            WorkProcess.Instance.Close();
            this.OnRefreshView();
        }
    }
}