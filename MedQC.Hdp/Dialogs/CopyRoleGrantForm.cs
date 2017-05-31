using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Controls.TableView;
using Heren.Common.Libraries;
using EMRDBLib;
using EMRDBLib.DbAccess;
namespace Heren.MedQC.Hdp
{
    public partial class CopyRoleGrantForm : Form
    {
        private List<HdpRoleGrant> m_lstHdpRoleGrant = null;
        public List<HdpRoleGrant> lstHdpRoleGrant
        {
            get { return this.m_lstHdpRoleGrant; }
        }
        public CopyRoleGrantForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadHdpRoleList();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void LoadHdpRoleList()
        {
            this.dataGridView1.Rows.Clear();
            List<HdpRole> lstHdpRoles = null;
            short shRet =HdpRoleAccess.Instance.GetHdpRoleList(string.Empty, ref lstHdpRoles);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取角色列表！");
                return;
            }
            if (lstHdpRoles == null || lstHdpRoles.Count <= 0)
                return;
            for (int index = 0; index < lstHdpRoles.Count; index++)
            {
                HdpRole hdpRole = lstHdpRoles[index];

                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = hdpRole; //将记录信息保存到该行
                this.SetRowData(row, hdpRole);
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
        }
        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="hdpRole">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataGridViewRow row, HdpRole hdpRole)
        {
            if (row == null || row.Index < 0 || hdpRole == null)
                return false;
            row.Tag = hdpRole;
            row.Cells[this.colRoleName.Index].Value = hdpRole.RoleName;
            row.Cells[this.colRoleCode.Index].Value = hdpRole.RoleCode;
            row.Cells[this.colCheckBox.Index].Value = false;

            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int index = 0; index < this.dataGridView1.Rows.Count; index++)
            {
                if (this.dataGridView1.SelectedRows[0].Index == index)
                    this.dataGridView1.Rows[index].Cells[this.colCheckBox.Index].Value = true;
                else
                    this.dataGridView1.Rows[index].Cells[this.colCheckBox.Index].Value = false;
            }
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            HdpRole hdpRole = this.dataGridView1.SelectedRows[0].Tag as HdpRole;
            short shRet =HdpRoleGrantAccess.Instance.GetHdpRoleGrantList(hdpRole.RoleCode, string.Empty, ref this.m_lstHdpRoleGrant);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("该角色未找到授权信息，无法复制");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}