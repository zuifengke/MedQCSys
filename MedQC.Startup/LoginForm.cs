// ***********************************************************
// 病案质控系统用户登录对话框.
// Creator:LiChunYing  Date:2012-03-29
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Heren.Common.Controls;
using Heren.Common.Libraries;

using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Core;

namespace MedQCSys.Dialogs
{
    public partial class LoginForm : HerenForm
    {
        public LoginForm()
        {
            this.InitializeComponent();
            this.Icon = Properties.Resources.LoginIcon;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            string key = SystemData.ConfigKey.DEFAULT_LOGIN_USERID;
            this.txtUserID.Text = SystemConfig.Instance.Get(key, null);
            if (GlobalMethods.Misc.IsEmptyString(this.txtUserID.Text))
                this.txtUserID.Focus();
            else
                this.txtUserPwd.Focus();
            this.txtUserID.ImeMode = ImeMode.Alpha;
            this.LoadCboProduct();
        }

        private void LoadCboProduct()
        {
            string product = SystemConfig.Instance.Get(SystemData.ConfigKey.DEFAULT_LOGIN_PRODUCT, "");
            List<HdpProduct> lstHdpProduct = new List<HdpProduct>();
            short shRet = HdpProductAccess.Instance.GetHdpProductList(ref lstHdpProduct);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            this.cboProduct.Items.Clear();
            for (int index = 0; index < lstHdpProduct.Count; index++)
            {
                this.cboProduct.Items.Add(lstHdpProduct[index]);
                if (product == lstHdpProduct[index].NAME_SHORT)
                {
                    this.cboProduct.SelectedIndex = index;
                }
            }
            if (product == string.Empty)
                this.cboProduct.SelectedIndex = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //if (!SystemParam.Instance.LocalConfigOption.HdpUse)
            //    DrawProductInfo(e);
            //else
                DrawProductInfoNew(e);
        }
        /// <summary>
        /// 绘制产品信息
        /// </summary>
        /// <param name="e"></param>
        private void DrawProductInfo(PaintEventArgs e)
        {
            // 边界
            Rectangle rect = this.ClientRectangle;
            ControlPaint.DrawBorder3D(e.Graphics, rect, Border3DStyle.RaisedOuter);

            // 产品版本
            rect = new Rectangle(8, 245, 255, 16);
            Font font = new Font("宋体", 9, FontStyle.Regular);
            Color color = Color.FromArgb(154, 171, 193);
            SolidBrush brush = new SolidBrush(color);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Near;
            string szProductVersion = "MedQCSys,版本：" + Application.ProductVersion;
            e.Graphics.DrawString(szProductVersion, font, brush, rect, stringFormat);
            font.Dispose();
            brush.Dispose();
            stringFormat.Dispose();
        }

        /// <summary>
        /// 绘制产品信息
        /// </summary>
        /// <param name="e"></param>
        private void DrawProductInfoNew(PaintEventArgs e)
        {
            string szProduct = SystemConfig.Instance.Get(SystemData.ConfigKey.DEFAULT_LOGIN_PRODUCT, "");
            HdpProduct hdpProduct = null;
            short shRet = HdpProductAccess.Instance.GetHdpProduct(szProduct, ref hdpProduct);
            if (hdpProduct == null)
            {
                this.DrawProductInfo(e);
                return;
            }
            // 边界
            Rectangle rect = this.ClientRectangle;
            ControlPaint.DrawBorder3D(e.Graphics, rect, Border3DStyle.RaisedOuter);
            DataCache.Instance.HdpProduct = hdpProduct;
            // 产品名称
            rect = new Rectangle(8, 220, 255, 32);
            Font font = new Font("黑体", 15, FontStyle.Regular);
            Color color = Color.WhiteSmoke;
            SolidBrush brush = new SolidBrush(color);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Near;
            string szProductCnName = hdpProduct.CN_NAME;
            e.Graphics.DrawString(szProductCnName, font, brush, rect, stringFormat);
            // 产品版本
            rect = new Rectangle(8, 245, 255, 16);
            font = new Font("宋体", 9, FontStyle.Regular);
            color = Color.FromArgb(154, 171, 193);
            brush = new SolidBrush(color);
            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.LineAlignment = StringAlignment.Near;
            string szProductVersion = hdpProduct.PRODUCT_BAK;
            e.Graphics.DrawString(szProductVersion, font, brush, rect, stringFormat);
            font.Dispose();
            brush.Dispose();
            stringFormat.Dispose();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string szUserID = this.txtUserID.Text.Trim().ToUpper();

            if (GlobalMethods.Misc.IsEmptyString(szUserID))
            {
                MessageBoxEx.Show("请输入您的用户ID!");
                this.txtUserID.Focus();
                this.txtUserID.SelectAll();
                return;
            }
            this.Cursor = Cursors.WaitCursor;

            //获取用户信息
            UserInfo userInfo = null;
            if (szUserID.ToUpper() == "ADMINISTRATOR")
            {
                szUserID = "administrator";//管理员账户要小写
                userInfo = new UserInfo();
                userInfo.USER_ID = szUserID;
                userInfo.USER_NAME = "管理员";
                goto ADMINISTRATOR_LOGIN;
            }
            short shRet = UserAccess.Instance.GetUserInfo(szUserID, ref userInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("登录失败,系统无法获取用户信息!");
                this.Cursor = Cursors.Default;
                return;
            }
            if (userInfo == null)
            {
                MessageBoxEx.Show("您输入的账号非法!");
                this.txtUserID.Focus();
                this.txtUserID.SelectAll();
                this.Cursor = Cursors.Default;
                return;
            }

            //查询用户权限信息
            UserRightType rightType = UserRightType.MedQC;
            UserRightBase userRightBase = null;
            shRet = RightAccess.Instance.GetUserRight(szUserID, rightType, ref userRightBase);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("登录失败,系统无法获取用户权限!");
                this.Cursor = Cursors.Default;
                return;
            }
          
            //验证用户输入的密码
            ADMINISTRATOR_LOGIN:
            shRet = RightAccess.Instance.VerifyUser(szUserID, this.txtUserPwd.Text);
            if (shRet == SystemData.ReturnValue.FAILED)
            {
                MessageBoxEx.Show("您输入的登录口令错误!");
                this.txtUserPwd.Focus();
                this.txtUserPwd.SelectAll();
                this.Cursor = Cursors.Default;
                return;
            }
            if (shRet != SystemData.ReturnValue.OK
                && shRet!=SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("登录失败,系统无法验证用户信息!");
                this.Cursor = Cursors.Default;
                return;
            }
            this.Cursor = Cursors.Default;
            SystemParam.Instance.UserInfo = userInfo;
            SystemConfig.Instance.Write(SystemData.ConfigKey.DEFAULT_LOGIN_USERID, szUserID);
            HdpProduct hdpProduct = (this.cboProduct.SelectedItem as HdpProduct);
            if (hdpProduct == null)
            {
                MessageBoxEx.Show("网络出现异常!");
                return;
            }
            string szProduct = hdpProduct.NAME_SHORT;
            SystemConfig.Instance.Write(SystemData.ConfigKey.DEFAULT_LOGIN_PRODUCT, szProduct);
            DataCache.Instance.HdpProduct = this.cboProduct.SelectedItem as HdpProduct;

            //查找用户角色
            List<HdpRoleUser> lstHdpRoleUser = null;
            shRet = HdpRoleUserAccess.Instance.GetHdpRoleUserList(szUserID, ref lstHdpRoleUser);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("登录失败,系统无法获取用户权限!");
                this.Cursor = Cursors.Default;
                return;
            }
            //缓存用户角色权限信息
            List<HdpRoleGrant> lstHdpAllRoleGrant = new List<HdpRoleGrant>();
            foreach (HdpRoleUser item in lstHdpRoleUser)
            {
                List<HdpRoleGrant> lstHdpRoleGrant = new List<HdpRoleGrant>();
                shRet = HdpRoleGrantAccess.Instance.GetHdpRoleGrantList(item.RoleCode, string.Empty, ref lstHdpRoleGrant);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    lstHdpAllRoleGrant.AddRange(lstHdpRoleGrant);
                }
            }
            DataCache.Instance.QcAdminDepts = null;
            DataCache.Instance.DicHdpParameter = null;
            RightHandler.Instance.LstHdpRoleGrant = lstHdpAllRoleGrant;

            this.DialogResult = DialogResult.OK;
        }
    }
}