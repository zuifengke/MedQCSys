using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using EMRDBLib;
using EMRDBLib.DbAccess;
using MedQCSys;
using MedQCSys.DockForms;
using Heren.MedQC.Core;

namespace Heren.MedQC.Hdp
{
    public partial class AdminDeptsForm : DockContentBase
    {
        private Dictionary<string, string> m_DicResource;
        private HdpRole m_roleInfo = null;
        private Dictionary<string, QcAdminDepts> dicAdminDepts = null;

        public UserInfo UserInfo { get; set; }
        public AdminDeptsForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.OnRefreshView();
            if (this.m_roleInfo != null)
                this.Text = string.Format("正在给{0}设置管辖科室", this.UserInfo.Name);
        }
        public override void OnRefreshView()
        {

            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadAdminDeptsList();
            this.LoadDeptCheckBox();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void LoadDeptCheckBox()
        {
            List<DeptInfo> lstDeptInfo = null;
            short shRet = DeptAccess.Instance.GetClinicInpDeptList(ref lstDeptInfo);
            foreach (var item in lstDeptInfo)
            {
                CheckBox chk = new CheckBox();
                chk.Width = 160;
                chk.Text = item.DEPT_NAME;
                chk.Tag = item;
                if (dicAdminDepts.ContainsKey(item.DEPT_CODE))
                    chk.Checked = true;
                this.flpGrant.Controls.Add(chk);
            }
        }

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        private void LoadAdminDeptsList()
        {
            ListQcAdminDepts.Clear();
            short shRet = QcAdminDeptsAccess.Instance.GetQcAdminDeptsList(this.UserInfo.ID, ref ListQcAdminDepts);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("无法获取角色权限！");
                return;
            }
            if (dicAdminDepts == null)
                dicAdminDepts = new Dictionary<string, QcAdminDepts>();

            dicAdminDepts.Clear();
            if (ListQcAdminDepts == null || ListQcAdminDepts.Count <= 0)
                return;

            for (int index = 0; index < ListQcAdminDepts.Count; index++)
            {
                QcAdminDepts qcAdminDepts = ListQcAdminDepts[index];
                if (dicAdminDepts.ContainsKey(qcAdminDepts.DEPT_CODE))
                    continue;
                dicAdminDepts.Add(qcAdminDepts.DEPT_CODE, qcAdminDepts);
            }
        }


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAll.Checked)
            {
                foreach (Control item in this.flpGrant.Controls)
                {
                    if (item is CheckBox)
                    {
                        (item as CheckBox).Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control item in this.flpGrant.Controls)
                {
                    if (item is CheckBox)
                    {
                        (item as CheckBox).Checked = false;
                    }
                }
            }
        }
        public List<QcAdminDepts> ListQcAdminDepts = new List<QcAdminDepts>();
        private void btnSave_Click(object sender, EventArgs e)
        {
            ListQcAdminDepts.Clear();
            foreach (Control item in this.flpGrant.Controls)
            {
                CheckBox chk = item as CheckBox;
                if (item == null)
                    continue;
                if (chk.Checked == false)
                    continue;
                DeptInfo dpetDict = chk.Tag as DeptInfo;
                QcAdminDepts qcAdminDepts = new QcAdminDepts();
                qcAdminDepts.DEPT_CODE = dpetDict.DEPT_CODE;
                qcAdminDepts.DEPT_NAME = dpetDict.DEPT_NAME;
                qcAdminDepts.USER_ID = this.UserInfo.ID;
                qcAdminDepts.USER_NAME = this.UserInfo.Name;
                ListQcAdminDepts.Add(qcAdminDepts);
            }
            short shRet = QcAdminDeptsAccess.Instance.SaveQcAdminDeptsList(this.UserInfo.ID, ListQcAdminDepts);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("管辖科室设置失败！");
                return;
            }
            MessageBoxEx.ShowMessage("管辖科室设置成功！");
        }
        
    }
}