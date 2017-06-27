using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.HomePage.PageCards
{
    public partial class MedicalQcMsgCard : BaseCard
    {
        public MedicalQcMsgCard()
        {
            InitializeComponent();
            this.Title = "质检问题状态监控";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public override bool  RefreshCard()
        {
            
            return true;
        }
        public override bool Export()
        {
            
            return true;
        }
        private void cardPanel1_Enter(object sender, EventArgs e)
        {

        }
    }
}
