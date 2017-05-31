// ***********************************************************
// 病历文档系统关于窗口
// Creator:YangMingkun  Date:2011-6-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
 
using EMRDBLib;

namespace MedQCSys.Dialogs
{
    internal partial class SystemAboutForm : HerenForm
    {
        public SystemAboutForm()
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            string szLogoFile = GlobalMethods.Misc.GetWorkingPath() + "\\Skins\\About.png";
            this.picSoftwareLogo.Image = Image.FromFile(szLogoFile);

            Assembly assembly = this.GetType().Assembly;
            string szVersionText = assembly.GetName().Version.ToString();
            DateTime dtModifyTime = DateTime.Now;
            GlobalMethods.IO.GetFileLastModifyTime(assembly.Location, ref dtModifyTime);
            this.txtSoftware.Text = string.Format("和仁电子病历质控系统 (MedQCSys)  v{0},  Build {1}",
                szVersionText, dtModifyTime.ToString("yyMMddHHmm"));

            this.txtCopyrightCH.Text = "本产品及各项专利  浙江和仁科技股份有限公司版权所有";
            this.txtCopyrightEN.Text = string.Format("Copyright(C) {0} Heren Health Service(SUPCON)."
                , DateTime.Now.Year.ToString()) + "  All Rights Reserved.";

            if (SystemParam.Instance.UserInfo == null)
            {
                this.txtCertText.Text = "未检测到产品授权许可信息";
            }

            this.txtVersionInfo.Focus();
            string szVersionFile = this.GetVersionFile();
            if (GlobalMethods.Misc.IsEmptyString(szVersionFile))
            {
                this.txtVersionInfo.AppendText("版本信息文件不存在！");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            try
            {
                this.txtVersionInfo.LoadFile(szVersionFile, RichTextBoxStreamType.RichText);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
            catch (Exception ex)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.txtVersionInfo.Text = "软件版本发布信息文件加载失败！异常信息是：\n" + ex.ToString();
            }
        }

        private string GetVersionFile()
        {
            string szVersionFile = GlobalMethods.Misc.GetWorkingPath() + "\\Versions.dat";
            return szVersionFile;
        }

        private void picSoftwareLogo_Paint(object sender, PaintEventArgs e)
        {
            Image logoImage = Properties.Resources.CompanyLogo;
            e.Graphics.DrawImage(logoImage, 8, 4);

            SolidBrush brush = new SolidBrush(Color.YellowGreen);
            Point ptLocation = new Point(8, logoImage.Height + 8);
            e.Graphics.DrawString("浙江和仁科技股份有限公司", this.Font, brush, ptLocation);
            brush.Dispose();
        }

        private void txtVersionInfo_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (GlobalMethods.Misc.IsEmptyString(e.LinkText))
                return;
            string szLinkText = e.LinkText;
            try
            {
                szLinkText = szLinkText.Replace("{app_path}", GlobalMethods.Misc.GetWorkingPath());
                System.Diagnostics.Process.Start(szLinkText);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(string.Format("无法打开此链接“{0}”!\r\n{1}", szLinkText, ex.Message));
            }
        }
    }
}