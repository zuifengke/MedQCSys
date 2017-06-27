using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedQCSys.DockForms;
using Heren.MedQC.HomePage.PageCards;
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
            //this.dataGridView1.AutoReadonly = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            QcTimeCheckCard qcTimeCheckCard = new QcTimeCheckCard();
            qcTimeCheckCard.RefreshCard();
            this.flowLayoutPanel1.Controls.Add(qcTimeCheckCard);

            QcCheckResultCard qcCheckResultCard = new QcCheckResultCard();
            qcCheckResultCard.RefreshCard();
            this.flowLayoutPanel1.Controls.Add(qcCheckResultCard);

            MedicalQcMsgCard medicalQcMsgCard = new MedicalQcMsgCard();
            medicalQcMsgCard.RefreshCard();
            this.flowLayoutPanel1.Controls.Add(medicalQcMsgCard);
        }
        public override void OnRefreshView()
        {
            if (this.flowLayoutPanel1.IsDisposed)
                return;
            if (this.flowLayoutPanel1.HasChildren)
            {
                foreach (ICardControl item in this.flowLayoutPanel1.Controls)
                {
                    if (item != null)
                        item.RefreshCard();
                }

            }
        }
    }
}
