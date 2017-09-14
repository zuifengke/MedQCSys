using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Configuration;
using EMRDBLib;
using EMRDBLib.HerenHis;
using Heren.Common.Controls.TableView;
using EMRDBLib.DbAccess.HerenHis;
using System.Linq;
using Heren.Common.Libraries;
using EMRDBLib.DbAccess;
using EMRDBLib.BAJK;

namespace Heren.MedQC.MedRecord
{
    public partial class CodeCompasionForm : Form
    {

        public CodeCompasionForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCodeTypeName();
        }

        private void LoadCodeTypeName()
        {
            List<RecCodeCompasion> lstRecCodeCompasion = null;
            short shRet = RecCodeCompasionAccess.Instance.GetLists(true, ref lstRecCodeCompasion);
            if (lstRecCodeCompasion == null)
                return;
            this.listBox1.Items.Clear();
            foreach (var item in lstRecCodeCompasion)
            {
                this.listBox1.Items.Add(item);
            }
        }

        List<BaseCodeDict> m_lstBaseCodeDicts = null;
        List<GyGydm> m_lstGyGydm = null;
        private void LoadBaseCodeDict(RecCodeCompasion recCodeCompasion,string codeName)
        {
            if (recCodeCompasion == null)
            {
                MessageBoxEx.ShowMessage("请先选择分类");
                return;
            }
            this.Text = string.Format("病案上传编码对照-{0}", recCodeCompasion.CONFIG_NAME);
            this.dataTableView1.Rows.Clear();


            string codeTypeName = recCodeCompasion.CODETYPE_NAME;
            if (string.IsNullOrEmpty(codeTypeName))
            {
                MessageBoxEx.ShowError("字典类型代码为空");
                return;
            }
            if (this.m_lstBaseCodeDicts == null)
                this.m_lstBaseCodeDicts = new List<BaseCodeDict>();
            this.m_lstBaseCodeDicts.Clear();
            this.col_MC.Items.Clear();
            DataSet ds = null;
            short shRet = HerenHisCommonAccess.Instance.ExecuteQuery(recCodeCompasion.FORM_SQL, out ds);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (this.m_lstBaseCodeDicts == null)
                    this.m_lstBaseCodeDicts = new List<BaseCodeDict>();
                this.m_lstBaseCodeDicts.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    BaseCodeDict item = new BaseCodeDict();
                    item.CODETYPE_NAME = ds.Tables[0].Rows[i]["CODETYPE_NAME"].ToString();
                    item.CODE_NAME = ds.Tables[0].Rows[i]["CODE_NAME"].ToString();
                    item.CODE_ID = ds.Tables[0].Rows[i]["CODE_ID"].ToString();
                    this.m_lstBaseCodeDicts.Add(item);
                }
            }
            if (this.m_lstBaseCodeDicts != null && !string.IsNullOrEmpty(codeName))
                this.m_lstBaseCodeDicts = this.m_lstBaseCodeDicts.Where(m => m.CODE_NAME.Contains(codeName)).ToList();
            if (this.m_lstBaseCodeDicts != null && m_lstBaseCodeDicts.Count > 0)
            {
                Pagination(1);
            }
        }
        private void Pagination(int pageIndex)
        {
            if (this.m_lstBaseCodeDicts == null)
                return;
            this.col_MC.Items.Clear();
            this.txt_PageIndex.Text = pageIndex.ToString();

            int pageSize = int.Parse(lblPageSize.Text);
            int TotalCount = m_lstBaseCodeDicts.Count();
            int pageCount = (int)Math.Ceiling((decimal)(TotalCount) / pageSize);
            this.lbl_TotalCount.Text = TotalCount.ToString();
            this.lbl_PageCount.Text = pageCount.ToString();
            refreshUI();
            string codeTypeName = this.m_RecCodeCompasion.CODETYPE_NAME;
            List<RecCodeCompasion> lstRecCodeCompasions = null;
            short shRet = EMRDBLib.DbAccess.RecCodeCompasionAccess.Instance.GetRecCodeCompasions(codeTypeName, ref lstRecCodeCompasions);
            List<BaseCodeDict> lstBaseCodeDictPage = null;
            if (pageIndex != 0)
                lstBaseCodeDictPage = m_lstBaseCodeDicts.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            else
                lstBaseCodeDictPage = m_lstBaseCodeDicts;
            this.dataTableView1.Rows.Clear();
            WorkProcess.Instance.Initialize(this, lstBaseCodeDictPage.Count, "正在加载......");
            for (int i = 0; i < lstBaseCodeDictPage.Count; i++)
            {
                if (WorkProcess.Instance.Canceled)
                {
                    break;
                }
                BaseCodeDict gygydm = lstBaseCodeDictPage[i];
                WorkProcess.Instance.Show(i);
                int index = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[index];
                string codeID = gygydm.CODE_ID;
                string codeName = gygydm.CODE_NAME;
                row.Cells[this.col_CODE_ID.Index].Value = codeID;
                row.Cells[this.col_CODE_NAME.Index].Value = codeName;
                if (lstRecCodeCompasions != null)
                {
                    var recCodeCompasion = lstRecCodeCompasions.Where(m => m.CODE_ID == codeID && m.CODETYPE_NAME == codeTypeName).FirstOrDefault();
                    if (recCodeCompasion == null)
                        continue;
                    this.dataTableView1.SetRowState(index, RowState.Normal);
                    row.Tag = recCodeCompasion;
                    if (!string.IsNullOrEmpty(recCodeCompasion.MC))
                        row.Cells[this.col_STATUS.Index].Value = "→";
                    row.Cells[this.col_DM.Index].Value = recCodeCompasion.DM;
                    row.Cells[this.col_MC.Index].Value = recCodeCompasion.MC;
                }
            }
            WorkProcess.Instance.Close();
            if (this.col_MC.Items.Count == 0)
                LoadMC(this.m_RecCodeCompasion);
        }
        private void LoadMC(RecCodeCompasion recCodeCompasion)
        {
            if (this.col_MC.Items == null)
                return;
            //待选项
            this.col_MC.Items.Clear();
            DataSet ds = null;
            short shRet = BAJKCommonAccess.Instance.ExecuteQuery(recCodeCompasion.TO_SQL, out ds);
            if (m_lstGyGydm == null)
                m_lstGyGydm = new List<GyGydm>();
            m_lstGyGydm.Clear();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                this.m_lstGyGydm.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GyGydm item = new GyGydm();
                    item.DM = ds.Tables[0].Rows[i]["DM"].ToString();
                    item.DMLB = ds.Tables[0].Rows[i]["DMLB"].ToString();
                    item.MC = ds.Tables[0].Rows[i]["MC"].ToString();
                    m_lstGyGydm.Add(item);
                }
            }
            if (m_lstGyGydm == null)
                return;
            foreach (GyGydm item in m_lstGyGydm)
            {
                this.col_MC.Items.Add(item);
            }
        }

        private void dataTableView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataTableView1.CurrentCell.ColumnIndex == this.col_MC.Index)
            {
                FindComboBoxEditingControl control = (e.Control as FindComboBoxEditingControl);
                control.SelectedIndexChanged -= new EventHandler(colRight_SelectedIndexChanged);
                control.SelectedIndexChanged += new EventHandler(colRight_SelectedIndexChanged);
            }


            DataGridViewCell currCell = this.dataTableView1.CurrentCell;
            if (currCell == null || currCell.ColumnIndex != this.col_MC.Index)
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
            DataGridViewCell currCell = this.dataTableView1.CurrentCell;
            if (currCell == null || currCell.ColumnIndex != this.col_MC.Index)
                return;
        }
        private void colRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            Heren.Common.Controls.TableView.FindComboBoxEditingControl control = sender as Heren.Common.Controls.TableView.FindComboBoxEditingControl;
            if (control.SelectedItem != null)
            {
                GyGydm gyGydm = control.SelectedItem as GyGydm;
                this.dataTableView1.CurrentRow.Cells[this.col_DM.Index].Value = gyGydm.DM;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorkProcess.Instance.Initialize(this, this.dataTableView1.Rows.Count, "正在自动对照");
            foreach (DataGridViewRow item in this.dataTableView1.Rows)
            {
                RecCodeCompasion recCodeCompasion = item.Tag as RecCodeCompasion;
                if (recCodeCompasion != null && !string.IsNullOrEmpty(recCodeCompasion.CODE_NAME))
                {
                    continue;
                }
                WorkProcess.Instance.Show(item.Index);
                string codeName = item.Cells[this.col_CODE_NAME.Index].Value.ToString();
                var result = m_lstGyGydm.Find(m => m.MC == codeName);
                if (result == null)
                {
                    result = m_lstGyGydm.FindAll(m => m.MC.IndexOf(codeName) >= 0 || codeName.IndexOf(m.MC) >= 0).LastOrDefault();
                }
                if (result != null)
                {
                    item.Cells[this.col_DM.Index].Value = result.DM;
                    item.Cells[this.col_MC.Index].Value = result.MC;
                }
            }

            WorkProcess.Instance.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dataTableView1.Rows.Count <= 0)
                return;

            short shRet = SystemData.ReturnValue.OK;
            int count = 0;
            WorkProcess.Instance.Initialize(this, this.dataTableView1.Rows.Count, "正在保存...");
            foreach (DataTableViewRow row in this.dataTableView1.Rows)
            {
                WorkProcess.Instance.Show(row.Index);
                shRet = this.SaveRowData(row);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    row.Cells[this.col_STATUS.Index].Value = "→";
                    count++;

                }
            }
            WorkProcess.Instance.Close();
            MessageBoxEx.ShowMessage("成功保存" + count.ToString() + "条数据");
            Heren.MedQC.Core.Services.RecUploadService.Instance.InitializeDict();
        }

        private short SaveRowData(DataTableViewRow row)
        {
            if (row == null || row.Index < 0) return SystemData.ReturnValue.FAILED;
            if (this.dataTableView1.IsNormalRow(row) || this.dataTableView1.IsUnknownRow(row))
            {
                if (!this.dataTableView1.IsDeletedRow(row)) return SystemData.ReturnValue.CANCEL;
            }
            RecCodeCompasion recCodeCompasion = null;
            if (!this.MakeRowData(row, ref recCodeCompasion)) return SystemData.ReturnValue.FAILED;
            short shRet = SystemData.ReturnValue.OK;
            if (this.dataTableView1.IsModifiedRow(row))
            {

                shRet = RecCodeCompasionAccess.Instance.Update(recCodeCompasion);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataTableView1.SelectRow(row);
                    MessageBoxEx.Show("无法更新当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = recCodeCompasion;
                this.dataTableView1.SetRowState(row, RowState.Normal);
            }
            else if (this.dataTableView1.IsNewRow(row))
            {

                shRet = RecCodeCompasionAccess.Instance.Insert(recCodeCompasion);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    this.dataTableView1.SelectRow(row);
                    MessageBoxEx.Show("无法保存当前记录！");
                    return SystemData.ReturnValue.FAILED;
                }
                row.Tag = recCodeCompasion;
                this.dataTableView1.SetRowState(row, RowState.Normal);
            }

            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 获取指定行最新修改后的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="recCodeCompasion">最新修改后的数据</param>
        /// <returns>bool</returns>
        private bool MakeRowData(DataTableViewRow row, ref RecCodeCompasion recCodeCompasion)
        {
            if (row == null || row.Index < 0)
                return false;
            recCodeCompasion = row.Tag as RecCodeCompasion;
            if (recCodeCompasion == null)
            {
                recCodeCompasion = new RecCodeCompasion();
                recCodeCompasion.ID = recCodeCompasion.MakeID();
            }
            if (row.Cells[this.col_CODE_ID.Index].Value != null)
                recCodeCompasion.CODE_ID = row.Cells[this.col_CODE_ID.Index].Value.ToString();
            if (row.Cells[this.col_CODE_NAME.Index].Value != null)
                recCodeCompasion.CODE_NAME = (string)row.Cells[this.col_CODE_NAME.Index].Value;
            if (row.Cells[this.col_DM.Index].Value != null)
                recCodeCompasion.DM = (string)row.Cells[this.col_DM.Index].Value;
            else
                recCodeCompasion.DM = string.Empty;
            recCodeCompasion.DMLB = this.m_RecCodeCompasion.DMLB;
            if (row.Cells[this.col_MC.Index].Value != null)
                recCodeCompasion.MC = row.Cells[this.col_MC.Index].Value.ToString();
            else
                recCodeCompasion.MC = string.Empty;
            recCodeCompasion.CODETYPE_NAME = this.m_RecCodeCompasion.CODETYPE_NAME;
            return true;
        }
        private void refreshUI()
        {
            int TotalCount = int.Parse(lbl_TotalCount.Text);
            int pageCount = int.Parse(lbl_PageCount.Text);
            int pageSize = int.Parse(lblPageSize.Text);
            int pageIndex = int.Parse(txt_PageIndex.Text);
            if (pageIndex == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPre.Enabled = false;
            }
            if (pageIndex == pageCount)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }

            if (1 < pageIndex)
            {

                this.btnFirst.Enabled = true;
                this.btnPre.Enabled = true;
            }
            if (pageIndex < pageCount)
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }

        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(txt_PageIndex.Text);
            pageIndex--;
            this.Pagination(pageIndex);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(txt_PageIndex.Text);
            pageIndex++;
            this.Pagination(pageIndex);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.Pagination(1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int pageCount = int.Parse(this.lbl_PageCount.Text);
            this.Pagination(pageCount);
        }
        private RecCodeCompasion m_RecCodeCompasion = null;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_RecCodeCompasion = this.listBox1.SelectedItem as RecCodeCompasion;
            this.LoadBaseCodeDict(m_RecCodeCompasion,null);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxButton1_ButtonClick(object sender, EventArgs e)
        {
            string codeName = this.textBoxButton1.Text.Trim();
            this.LoadBaseCodeDict(m_RecCodeCompasion, codeName);
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            Pagination(0);
        }

        private void fbtnSettingCodeType_Click(object sender, EventArgs e)
        {
            SettingCodeTypeForm frm = new SettingCodeTypeForm();
            frm.ShowDialog();


            this.LoadCodeTypeName();

        }
    }
}