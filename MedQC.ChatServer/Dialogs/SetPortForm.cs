using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;

namespace MedQC.ChatServer.Dialogs
{
    public partial class SetPortForm : Form
    {
        public SetPortForm()
        {
            InitializeComponent();
            txtBoxPort.Text = System.Configuration.ConfigurationManager.AppSettings["port"];
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                int port = -1;
                if (int.TryParse(txtBoxPort.Text.Trim(), out port))
                {
                    if (port > 1024 && port < 65535)
                    {
                        System.Configuration.Configuration ss = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
                        ss.AppSettings.Settings["port"].Value = port.ToString();
                        ss.Save();
                        System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                        this.Close();
                    }
                    else
                    {
                        MessageBoxEx.Show("请输入1014~65535之内未使用的端口号！");
                        return;
                    }
                }
                else
                {
                    MessageBoxEx.Show("请输入正确数字端口！");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
