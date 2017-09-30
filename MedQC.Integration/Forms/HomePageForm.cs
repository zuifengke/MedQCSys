using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedQCSys.DockForms;
using MedQCSys;
using Heren.Common.DockSuite;
namespace Heren.MedQC.HomePage.Forms
{
    public partial class HomePageForm : DockContentBase
    {

        public HomePageForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
          
        }
        public override void OnRefreshView()
        {
            
        }
    }
}
