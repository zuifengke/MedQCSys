// ***********************************************************
// 病案质控系统工具条控件基类.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Heren.Common.Controls;
using Heren.Common.Libraries;

namespace MedQCSys.ToolBars
{
    public class MqsToolStripBase : ToolStrip
    {
        private MainForm m_mainForm = null;
        public virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set
            {
                this.m_mainForm = value;
                if (this.m_mainForm != null && !this.m_mainForm.IsDisposed)
                    this.m_mainForm.AllDockWindowHidden += new MainForm.AllDockWindowHiddenHandler(this.MainForm_AllDockWindowHidden);
            }
        }

        public MqsToolStripBase()
            : this(null)
        {

        }

        public MqsToolStripBase(MainForm parent)
        {
            this.MainForm = parent;

            this.Renderer = new ToolBarRenderer();
            this.Dock = DockStyle.None;
            this.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        }

        private void MainForm_AllDockWindowHidden(bool bIsHidden)
        {
            this.OnAllDockWindowHidden(bIsHidden);
        }

        protected virtual void OnAllDockWindowHidden(bool bIsHidden)
        {

        }
    
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            //实现click-through
            if (m.Msg == NativeConstants.WM_MOUSEACTIVATE)
            {
                if (m.Result == (IntPtr)NativeConstants.MA_ACTIVATEANDEAT)
                {
                    m.Result = (IntPtr)NativeConstants.MA_ACTIVATE;
                }
            }
        }
    }
}
