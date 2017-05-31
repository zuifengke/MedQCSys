using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using MedQCSys;
using Heren.Common.DockSuite;

namespace Heren.MedQC.ScreenSnap
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowHomePageCommand : AbstractCommand
    {
        public ShowHomePageCommand()
        {
            this.m_name = "截图";
        }
        public override bool Execute(object param, object data)
        {
            ScreenSnapForm frm = new ScreenSnapForm();
            frm.Show();
            return true;
        }
    }
}
