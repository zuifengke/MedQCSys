// ***********************************************************
// 病案质控系统菜单项控件基类.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;

namespace MedQCSys.MenuBars
{
    internal class MqsMenuItemBase : ToolStripMenuItem
    {
        private Padding m_DefaultPadding = Padding.Empty;

        protected override Padding DefaultPadding
        {
            get
            {
                if (this.m_DefaultPadding == Padding.Empty)
                {
                    Padding padding = base.DefaultPadding;
                    this.m_DefaultPadding = new Padding(padding.Left, padding.Top + 2, padding.Right, padding.Bottom + 2);
                }
                return this.m_DefaultPadding;
            }
        }
    }
}
