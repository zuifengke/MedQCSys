using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using Heren.Common.DockSuite;
using MedQCSys.Dialogs;
using Heren.Common.Libraries;
using System.Windows.Forms;
using EMRDBLib;
using MedQCSys.DockForms;

namespace MedQCSys
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowSystemCommand1 : AbstractCommand
    {
        public ShowSystemCommand1()
        {
            this.m_name = "切换账号";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                form.InitMainForm();
                return true;
            }
            return false;
        }
    }
}
