using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using MedQCSys;
using Heren.Common.DockSuite;
using Designers;

namespace Heren.MedQC.Designers
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowHomePageCommand : AbstractCommand
    {
        public ShowHomePageCommand()
        {
            this.m_name = "设计器";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContent item in form.DockPanel.Contents)
            {
                if (item is DesignForm)
                {
                    item.Activate();
                    return true;
                }
            }
            DesignForm role = new DesignForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
}
