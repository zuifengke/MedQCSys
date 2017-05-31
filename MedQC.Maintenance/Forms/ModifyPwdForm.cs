// ***********************************************************
// 病案质控系统用户密码修改对话框.
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
using System.Drawing.Drawing2D;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;

using EMRDBLib.DbAccess;
using EMRDBLib;

namespace Heren.MedQC.Maintenance
{
    public partial class ModifyPwdForm : HerenForm
    {
        public ModifyPwdForm()
        {
            this.InitializeComponent();
            this.Icon =Heren.MedQC.Maintenance.Properties.Resources.LoginIcon;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SystemParam.Instance.UserInfo == null)
            {
                MessageBoxEx.Show("您还没有登录系统,不能修改口令!");
                return;
            }

            string szOldPwd = this.txtOldPwd.Text;
            string szNewPwd = this.txtNewPwd.Text;
            string szConfirmPwd = this.txtConfirmPwd.Text;
            if (szNewPwd.CompareTo(szConfirmPwd) != 0)
            {
                MessageBoxEx.Show("您输入的确认口令不正确!");
                this.txtConfirmPwd.Focus();
                this.txtConfirmPwd.SelectAll();
                return;
            }

            string szUserID = SystemParam.Instance.UserInfo.ID;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            short shRet = RightAccess.Instance.ModifyUserPwd(szUserID, szOldPwd, szNewPwd);

            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            if (shRet == SystemData.ReturnValue.CANCEL)
            {
                MessageBoxEx.Show("您没有权限修改口令!");
                return;
            }
            if (shRet == SystemData.ReturnValue.FAILED)
            {
                MessageBoxEx.Show("您输入的原始口令不正确!");
                this.txtOldPwd.Focus();
                this.txtOldPwd.SelectAll();
                return;
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("登录口令修改失败,发生内部错误!");
            }
            else
            {
                MessageBoxEx.Show("登录口令修改成功!", MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //
            Rectangle rect = new Rectangle(0, 0, this.Width, 72);
            Color beginColor = Color.RoyalBlue;
            Color endColor = Color.CornflowerBlue;
            LinearGradientBrush brush = new LinearGradientBrush(rect, beginColor, endColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, rect);
            brush.Dispose();
            //
            Image img =Heren.MedQC.Maintenance.Properties.Resources.LoginBgImage;
            e.Graphics.DrawImage(img, 24, 18);
            //
            Font font = new Font("宋体", 9, FontStyle.Bold);
            SolidBrush solidBrush = new SolidBrush(Color.White);
            e.Graphics.DrawString("请输入您的原始口令和新口令...", font, solidBrush, 68, 32);
            solidBrush.Dispose();
            font.Dispose();
        }
    }
}