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

namespace Heren.MedQC.Systems
{
    public partial class SpecialDoctorForm : HerenForm
    {
        private SpecialQCForm m_SpecialQCForm;
        public SpecialDoctorForm(SpecialQCForm parent)
        {
            this.m_SpecialQCForm = parent;
            this.InitializeComponent();
            this.dataGridView1.Font = new Font("宋体", 10.5f);
            this.dataGridView1.AutoReadonly = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.RefreshView();
        }

        public void RefreshView()
        {
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在获取病案专家资源，请稍候...");
            this.LoadRoleResourceList();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ShowStatusMessage(string p)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 装载专家资源库列表信息
        /// </summary>
        private void LoadRoleResourceList()
        {
            this.dataGridView1.Rows.Clear();
            List<Specialist> lstSpecialist = null;
            //老质控系统没有角色系统，质控专家信息在后台工具质控用户权限的一个权限点
            // short shRet = DataAccess.SpecialAccess.GetSpecialistResource(ref lstSpecialist);
            List<UserRightBase> lstUserRight = null;
            short shRet = EMRDBLib.DbAccess.RightAccess.Instance.GetUserRight(UserRightType.MedQC, ref lstUserRight);
            lstSpecialist = new List<Specialist>();
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("获取专家资源列表失败！");
                return;
            }
            foreach (QCUserRight user in lstUserRight)
            {
                //质控专家不会很，循环查询
                bool IsSpecialDoc = user.IsSpecialDoc.Value ;
                if (!IsSpecialDoc)
                    continue;
                UserInfo  userInfo=null;
                shRet =UserAccess.Instance.GetUserInfo(user.UserID, ref userInfo);
                if (shRet ==SystemData.ReturnValue.OK && userInfo != null)
                {
                    Specialist item = new Specialist();
                    item.UserID = userInfo.USER_ID;
                    item.UserName = userInfo.USER_NAME;
                    item.DeptCode=userInfo.DEPT_CODE;
                    item.DeptName=userInfo.DEPT_NAME;
                    lstSpecialist.Add(item);
                }
            }
           
            if (lstSpecialist == null || lstSpecialist.Count <= 0)
                return;
            for (int index = 0; index < lstSpecialist.Count; index++)
            {
                Specialist specialist = lstSpecialist[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                row.Tag = specialist; //将记录信息保存到该行
                this.SetRowData(row, specialist);
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
        }



        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="qcEventType">绑定的数据</param>
        /// <returns>bool</returns>
        private bool SetRowData(DataGridViewRow row, EMRDBLib.Specialist specialist)
        {
            if (row == null || row.Index < 0 || specialist == null)
                return false;
            row.Tag = specialist;
            row.Cells[this.colCheckBox.Index].Value = false;
            row.Cells[this.colUserID.Index].Value = specialist.UserID;
            row.Cells[this.colUserName.Index].Value = specialist.UserName;
            row.Cells[this.colDeptName.Index].Value = specialist.DeptName;
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            bool bchekced = bool.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[this.colCheckBox.Index].Value.ToString());
            this.dataGridView1.Rows[e.RowIndex].Cells[this.colCheckBox.Index].Value = !bchekced;

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[this.colCheckBox.Index].Value = this.chkAll.Checked;
            }
        }
        private List<EMRDBLib.Specialist> m_lstSpecialist = null;
        /// <summary>
        /// 选中的专家人员
        /// </summary>
        public List<EMRDBLib.Specialist> SelectedSpecial
        {
            get
            {
                if (this.m_lstSpecialist == null)
                    this.m_lstSpecialist = new List<EMRDBLib.Specialist>();
                return this.m_lstSpecialist;
            }
        }
        private void toolbtnConfirm_Click(object sender, EventArgs e)
        {
            if (this.m_lstSpecialist == null)
                this.m_lstSpecialist = new List<Specialist>();
            this.m_lstSpecialist.Clear();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                bool bchecked = bool.Parse(row.Cells[this.colCheckBox.Index].Value.ToString());
                if (bchecked)
                {
                    Specialist specialist = row.Tag as Specialist;
                    if (specialist == null)
                        continue;
                    this.m_lstSpecialist.Add(specialist);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void toolbtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}