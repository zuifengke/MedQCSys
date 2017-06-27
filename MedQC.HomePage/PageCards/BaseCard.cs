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
    public partial class BaseCard : UserControl, ICardControl
    {
        [
          Category("Card")
            , Description("标题文本")
        ]
        private String title = string.Empty;
        public String Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public BaseCard()
        {
            InitializeComponent();
            this.fbtnRefresh.Image = Properties.Resources.Update;
            this.fbtnExport.Image = Properties.Resources.export;
            this.fbtnDelete.Image = Properties.Resources.Delete;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.mlinkTitle.Text = this.title;
        }
        public virtual bool RefreshCard()
        {
            return false;
        }
        public virtual bool Export()
        {
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RefreshCard();
        }

        private void fbtnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshCard();
        }

        private void fbtnExport_Click(object sender, EventArgs e)
        {
            this.Export();
        }

        private void fbtnDelete_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                //Panel panel = this.Parent as Panel;
                this.Parent.Controls.Remove(this);
                this.Dispose();
            }
        }
    }
}
