using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
namespace MedQCSys.DockForms
{
    public partial class WebBrowerForm : DockContentBase
    {
        ChromiumWebBrowser m_chromeBrowser = null;
        public WebBrowerForm(MainForm parent) : base(parent)
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
          
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Cef.Initialize();
            m_chromeBrowser = new ChromiumWebBrowser("http://www.baidu.com");

            panel2.Controls.Add(m_chromeBrowser);
            ChromeDevToolsSystemMenu.CreateSysMenu(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.m_chromeBrowser.Load(this.textBox1.Text);
        }
    }
}
