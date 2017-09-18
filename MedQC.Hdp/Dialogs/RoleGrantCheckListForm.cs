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
    public partial class RoleGrantCheckListForm : DockContentBase
    {
        private Dictionary<string, string> m_DicResource;
        private HdpRole m_roleInfo = null;
        private Dictionary<string, HdpRoleGrant> dicHdpRoleGrant = null;
        public HdpRole RoleInfo
        {
            get { return this.m_roleInfo; }
            set { this.m_roleInfo = value; }
        }
        public RoleGrantCheckListForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.OnRefreshView();
            if (this.m_roleInfo != null)
                this.Text = string.Format("正在给{0}授权", this.m_roleInfo.RoleName);
        }
        public override void OnRefreshView()
        {

            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            if (!this.LoadCboProducts())
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            this.LoadHdpRoleGrantList();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        private bool LoadCboProducts()
        {
            this.cboProduct.Items.Clear();
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
            for (int index = 0; index < lstHdpProducts.Count; index++)
            {
                HdpProduct hdpProduct = lstHdpProducts[index];
                cboProduct.Items.Add(hdpProduct);
                if (DataCache.Instance.HdpProduct.NAME_SHORT == hdpProduct.NAME_SHORT)
                {
                    cboProduct.SelectedIndex = index;
                }
            }
            if (this.cboProduct.SelectedIndex == -1)
                this.cboProduct.SelectedIndex = 0;
            return true;
        }
        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        private void LoadHdpRoleGrantList()
        {

            if (this.cboProduct.SelectedItem == null)
                return;
            string szProduct = (this.cboProduct.SelectedItem as HdpProduct).NAME_SHORT;
            List<HdpRoleGrant> lstHdpRoleGrant = null;
            short shRet = HdpRoleGrantAccess.Instance.GetHdpRoleGrantList(this.m_roleInfo.RoleCode, null, ref lstHdpRoleGrant);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("无法获取角色权限！");
                return;
            }
            if (dicHdpRoleGrant == null)
                dicHdpRoleGrant = new Dictionary<string, HdpRoleGrant>();

            dicHdpRoleGrant.Clear();
            if (lstHdpRoleGrant == null || lstHdpRoleGrant.Count <= 0)
                return;

            for (int index = 0; index < lstHdpRoleGrant.Count; index++)
            {
                HdpRoleGrant hdpRoleGrant = lstHdpRoleGrant[index];
                if (dicHdpRoleGrant.ContainsKey(hdpRoleGrant.RoleRightKey))
                    continue;
                dicHdpRoleGrant.Add(hdpRoleGrant.RoleRightKey, hdpRoleGrant);

            }
        }
        private void LoadFlpGrantCheckList()
        {
            this.flpGrant.Controls.Clear();
            if (this.cboProduct.SelectedItem == null)
            {
                return;
            }
            string szProduct = (this.cboProduct.SelectedItem as HdpProduct).NAME_SHORT;
            RightPoint[] rights = RightResource.GetRightPoints(szProduct);
            if (rights != null)
            {
                foreach (RightPoint point in rights)
                {
                    CheckBox chk = new CheckBox();
                    chk.Width = 260;
                    chk.Text = point.RightDesc;
                    chk.Tag = point;
                    if (dicHdpRoleGrant.ContainsKey(point.RightKey))
                        chk.Checked = true;
                    this.flpGrant.Controls.Add(chk);
                }
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboProduct.SelectedItem == null)
                return;
            this.chkAll.Checked = false;
            this.LoadHdpRoleGrantList();
            this.LoadFlpGrantCheckList();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cboProduct.SelectedItem == null)
            {
                MessageBoxEx.Show("请选择产品");
                return;
            }

            string szProduct = (this.cboProduct.SelectedItem as HdpProduct).NAME_SHORT;
            List<HdpRoleGrant> lstHdpRoleGrant = new List<HdpRoleGrant>();
            foreach (Control item in this.flpGrant.Controls)
            {
                CheckBox chk = item as CheckBox;
                if (item == null)
                    continue;
                if (chk.Checked == false)
                    continue;
                RightPoint point = chk.Tag as RightPoint;
                HdpRoleGrant hdpRoleGrant = new HdpRoleGrant();
                hdpRoleGrant.GrantID = hdpRoleGrant.MakeGrantID();
                hdpRoleGrant.RoleCode = this.m_roleInfo.RoleCode;
                hdpRoleGrant.Product = szProduct;
                hdpRoleGrant.RoleRightCommand = point.RightCommand;
                hdpRoleGrant.RoleRightDesc = point.RightDesc;
                hdpRoleGrant.RoleRightKey = point.RightKey;
                lstHdpRoleGrant.Add(hdpRoleGrant);

            }
            short shRet = HdpRoleGrantAccess.Instance.SaveHdpRoleGrantList(this.m_roleInfo.RoleCode, szProduct, lstHdpRoleGrant);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("授权失败！");
                return;
            }
            MessageBoxEx.ShowMessage("授权成功！");
            this.DialogResult = DialogResult.OK;
        }

        private void btnCopyGrant_Click(object sender, EventArgs e)
        {
            if (this.cboProduct.SelectedItem == null)
                return;
            HdpProduct hdpProduct = this.cboProduct.SelectedItem as HdpProduct;
            CopyRoleGrantForm form = new CopyRoleGrantForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                List<HdpRoleGrant> lstHdpRoleGrant = form.lstHdpRoleGrant;
                foreach (HdpRoleGrant hdpRoleGrant in form.lstHdpRoleGrant)
                {
                    if (dicHdpRoleGrant.ContainsKey(hdpRoleGrant.RoleRightKey))
                        continue;
                    foreach (Control item in this.flpGrant.Controls)
                    {
                        CheckBox chk = item as CheckBox;
                        //if ((chk.Tag as RightPoint).RightKey == hdpRoleGrant.RoleRightKey)
                        //{
                        //    chk.Checked = true;
                        //    break;
                        //}
                    }
                }
            }
        }
    }
}