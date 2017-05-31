// ***********************************************************
// 病历模板维护系统用户登录对话框.
// Creator:YangMingkun  Date:2010-3-30
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using EMRDBLib.DbAccess;
using EMRDBLib;
using EMRDBLib.Entity;

namespace MedQC.ChatClient
{
    internal partial class LoginForm : HerenForm
    {
        public LoginForm()
        {
            this.InitializeComponent();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.txtUserID.Text =
                SystemConfig.Instance.Get(SystemData.ConfigKey.MEDTASK_DEFAULT_USERID, null);
            if (GlobalMethods.Misc.IsEmptyString(this.txtUserID.Text))
                this.txtUserID.Focus();
            else
                this.txtUserPwd.Focus();
            this.txtUserID.ImeMode = ImeMode.Alpha;

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //
            Rectangle rect = new Rectangle(0, 0, this.Width, 72);
            Color beginColor = Color.RoyalBlue;
            Color endColor = Color.CornflowerBlue;
            LinearGradientBrush brush =
                new LinearGradientBrush(rect, beginColor, endColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, rect);
            brush.Dispose();
            //
            Image img = global::MedQC.ChatClient.Properties.Resources.LoginBgImage;
            e.Graphics.DrawImage(img, 24, 18);
            //
            Font font = new Font("宋体", 9, FontStyle.Bold);
            SolidBrush solidBrush = new SolidBrush(Color.White);
            e.Graphics.DrawString("请输入您的登录ID和口令...", font, solidBrush, 68, 32);
            solidBrush.Dispose();
            font.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string szUserID = this.txtUserID.Text.Trim();
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
            short shRet;

            szUserID = szUserID.ToUpper();
            shRet =UserAccess.Instance.GetUserInfo(szUserID, ref userInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("登录失败,系统无法获取用户信息!");
                this.Cursor = Cursors.Default;
                return;
            }
            if (userInfo == null)
            {
                MessageBoxEx.Show("您输入的用户ID号错误!");
                this.txtUserID.Focus();
                this.txtUserID.SelectAll();
                this.Cursor = Cursors.Default;
                return;
            }

            //验证用户输入的密码
            shRet =RightAccess.Instance.VerifyUser(szUserID, this.txtUserPwd.Text);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("您输入的登录口令错误!");
                this.txtUserPwd.Focus();
                this.txtUserPwd.SelectAll();
                this.Cursor = Cursors.Default;
                return;
            }
            if (shRet == SystemData.ReturnValue.EXCEPTION)
            {
                MessageBoxEx.Show("您没有权限登录质控信息提醒系统!");
                this.txtUserID.Focus();
                this.txtUserID.SelectAll();
                this.Cursor = Cursors.Default;
                return;
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("登录失败,系统无法验证用户信息!");
                this.txtUserPwd.Focus();
                this.txtUserPwd.SelectAll();
                this.Cursor = Cursors.Default;
                return;
            }
            this.Cursor = Cursors.Default;
            SystemParam.Instance.QChatArgs = new QChatArgs();
            SystemParam.Instance.QChatArgs.Listener = string.Empty;
            SystemParam.Instance.QChatArgs.Sender = userInfo.ID;
            SystemParam.Instance.QChatArgs.ArgType = "2";
            SystemConfig.Instance.Write(SystemData.ConfigKey.MEDTASK_DEFAULT_USERID, szUserID);
            this.DialogResult = DialogResult.OK;
        }
    }
}