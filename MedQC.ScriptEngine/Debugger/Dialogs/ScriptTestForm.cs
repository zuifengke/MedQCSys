// ***********************************************************
// 电子病历系统关联元素自动计算脚本测试窗口.
// Creator: YangMingkun  Date:2011-11-10
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.Controls.TableView;
using Heren.MedQC.ScriptEngine.Script;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class ScriptTestForm : HerenForm
    {
        private List<IElementCalculator> m_lstElementCalculators = null;
        private string m_szScriptSource = null;
        private ToolTip m_toolTip = null;

        public ScriptTestForm()
        {
            this.InitializeComponent();
            this.btnAdd.Image = Properties.Resources.Add;
            this.btnDelete.Image = Properties.Resources.Delete;
            this.m_lstElementCalculators = new List<IElementCalculator>();
        }

        public DialogResult ShowDialog(string scriptName, string scriptText)
        {
            this.Text = "脚本测试 - " + scriptName;
            this.m_szScriptSource = scriptText;
            return base.ShowDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadElementList();
            this.InitElementCalculators();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 分析脚本源代码,提取所有引号所包含的元素名称字符串
        /// </summary>
        private void LoadElementList()
        {
            this.dataGridView1.Rows.Clear();
            if (string.IsNullOrEmpty(this.m_szScriptSource))
                return;
            StringBuilder sbElementName = new StringBuilder();
            int index = 0;
            int count = this.m_szScriptSource.Length;
            bool bHasColonSign = false;
            while (index < count)
            {
                char ch = this.m_szScriptSource[index];
                index++;

                if (!bHasColonSign && ch == '\"')
                {
                    bHasColonSign = true;
                    continue;
                }
                if (bHasColonSign && ch != '\"')
                {
                    sbElementName.Append(ch);
                    continue;
                }
                if (bHasColonSign && ch == '\"')
                {
                    bHasColonSign = false;
                    if (sbElementName.Length > 0)
                        this.NewRow(sbElementName.ToString(), string.Empty);
                    sbElementName.Remove(0, sbElementName.Length);
                }
            }
        }

        /// <summary>
        /// 初始化元素名称列表过程中,校验元素是否已经被加入到列表
        /// </summary>
        /// <param name="szElementName">元素名称</param>
        /// <returns>bool</returns>
        private bool IsElementNameExist(string szElementName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szElementName))
                return false;
            foreach (DataTableViewRow row in this.dataGridView1.Rows)
            {
                object value = row.Cells[this.colElementName.Index].Value;
                if (value == null)
                    continue;
                if (value.ToString().Equals(szElementName))
                    return true;
            }
            return false;
        }

        private void NewRow(string szElementName, string szElementValue)
        {
            if (this.IsElementNameExist(szElementName))
                return;
            int index = this.dataGridView1.Rows.Add();
            DataTableViewRow row = this.dataGridView1.Rows[index];
            row.Cells[this.colElementName.Index].Value = szElementName;
            row.Cells[this.colScriptValue.Index].Value = szElementValue;
            this.dataGridView1.SetRowState(row, RowState.New);
        }

        private void DeleteSelectedRow()
        {
            int count = this.dataGridView1.SelectedRows.Count;
            if (count <= 0)
                return;
            DataTableViewRow[] selectedRows = new DataTableViewRow[count];
            this.dataGridView1.SelectedRows.CopyTo(selectedRows, 0);
            for (int index = 0; index < selectedRows.Length; index++)
            {
                this.dataGridView1.Rows.Remove(selectedRows[index]);
            }
        }

        private void InitElementCalculators()
        {
            this.m_lstElementCalculators.Clear();
            if (GlobalMethods.Misc.IsEmptyString(this.m_szScriptSource))
                return;
            ScriptProperty scriptProperty = new ScriptProperty();
            scriptProperty.ScriptText = this.m_szScriptSource;
            CompileResults results = null;
            try
            {
                results = ScriptCompiler.Instance.CompileScript(scriptProperty);
                if (results.HasErrors)
                    return;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ScriptTestForm.InitElementCalculators", ex);
                MessageBoxEx.Show("无法编译脚本，测试失败！");
                return;
            }
            foreach (IElementCalculator elementCalculator in results.ElementCalculators)
            {
                elementCalculator.GetElementValueCallback = new GetElementValueCallback(this.GetElementValue);
                elementCalculator.SetElementValueCallback = new SetElementValueCallback(this.SetElementValue);
                elementCalculator.HideElementTipCallback = new HideElementTipCallback(this.HideElementTip);
                elementCalculator.ShowElementTipCallback = new ShowElementTipCallback(this.ShowElementTip);
                this.m_lstElementCalculators.Add(elementCalculator);
            }
        }

        private void TestScript(string szElementName)
        {
            if (this.m_lstElementCalculators.Count <= 0)
                return;
            foreach (IElementCalculator elementCalculator in this.m_lstElementCalculators)
            {
                try
                {
                    elementCalculator.Calculate(szElementName);
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("无法执行脚本,脚本中存在逻辑异常.异常信息为：\r\n"
                        + ex.Message + "\r\n您可以使用Try..Catch..End Try语句来处理可能的异常!"
                        , MessageBoxIcon.Information);
                }
            }
        }

        #region"元素计算接口实现"
        private bool GetElementValue(string szElementName, out string szElementValue)
        {
            szElementValue = string.Empty;
            if (this.dataGridView1.Rows.Count <= 0)
                return false;
            for (int index = 0; index < this.dataGridView1.Rows.Count; index++)
            {
                DataTableViewRow row = this.dataGridView1.Rows[index];
                if (row == null)
                    continue;
                if (row.Cells[this.colElementName.Index].Value == null)
                    continue;
                string szName = row.Cells[this.colElementName.Index].Value.ToString();
                if (szName != szElementName)
                    continue;

                if (row.Cells[this.colScriptValue.Index].Value != null)
                    szElementValue = row.Cells[this.colScriptValue.Index].Value.ToString();
                DataGridViewCell cell = this.dataGridView1.CurrentCell;
                if (cell.RowIndex == index && cell != null && cell.IsInEditMode)
                {
                    TextBox cellTextBox = this.dataGridView1.EditingControl as TextBox;
                    if (cellTextBox != null)
                        szElementValue = cellTextBox.Text.Trim();
                }
                break;
            }
            return true;
        }

        private bool SetElementValue(string szElementName, string szElementValue)
        {
            if (this.dataGridView1.Rows.Count <= 0)
                return false;
            for (int index = 0; index < this.dataGridView1.Rows.Count; index++)
            {
                DataTableViewRow row = this.dataGridView1.Rows[index];
                if (row == null)
                    continue;
                if (row.Cells[this.colElementName.Index].Value == null)
                    continue;
                string szName = row.Cells[this.colElementName.Index].Value.ToString();
                if (szName != szElementName)
                    continue;
                row.Cells[this.colScriptValue.Index].Value = szElementValue;
                break;
            }
            return true;
        }

        private bool ShowElementTip(string szTitle, string szText)
        {
            if (this.m_toolTip == null)
            {
                this.m_toolTip = new ToolTip();
                this.m_toolTip.IsBalloon = true;
                this.m_toolTip.ToolTipIcon = ToolTipIcon.Warning;
            }
            this.m_toolTip.RemoveAll();
            Control editingControl = this.dataGridView1.EditingControl;
            if (editingControl == null || editingControl.IsDisposed)
                return false;

            NativeStructs.POINT nPoint = new NativeStructs.POINT();
            if (!NativeMethods.User32.GetCaretPos(ref nPoint))
                return false;

            Graphics graphics = editingControl.CreateGraphics();
            SizeF size = graphics.MeasureString(szText, editingControl.Font);
            graphics.Dispose();

            Point point = new Point(nPoint.x - 20, nPoint.y - 60 - (int)size.Height);
            this.m_toolTip.ToolTipTitle = szTitle;
            this.m_toolTip.Show(szText, editingControl, point, 3000);
            return true;
        }

        private bool HideElementTip()
        {
            if (this.m_toolTip != null)
                this.m_toolTip.RemoveAll();
            return true;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.NewRow(string.Empty, string.Empty);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.DeleteSelectedRow();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void CellTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox cellTextBox = sender as TextBox;
            if (cellTextBox == null || cellTextBox.IsDisposed)
                return;
            if (!cellTextBox.Visible)
                return;
            DataGridViewCell cell = this.dataGridView1.CurrentCell;
            if (cell == null || cell.ColumnIndex != this.colScriptValue.Index)
                return;
            DataTableViewRow row = this.dataGridView1.Rows[cell.RowIndex];
            if (row.Cells[this.colElementName.Index].Value == null)
                return;
            this.TestScript(row.Cells[this.colElementName.Index].Value.ToString());
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewCell cell = this.dataGridView1.CurrentCell;
            if (cell == null || cell.ColumnIndex != this.colScriptValue.Index)
                return;
            TextBox cellTextBox = e.Control as TextBox;
            if (cellTextBox == null || cellTextBox.IsDisposed)
                return;
            cellTextBox.TextChanged -= new EventHandler(this.CellTextBox_TextChanged);
            cellTextBox.TextChanged += new EventHandler(this.CellTextBox_TextChanged);
        }
    }
}