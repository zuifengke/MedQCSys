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
    public partial class QcCheckResultCard : BaseCard
    {
        public QcCheckResultCard()
        {
            InitializeComponent();
            this.Title = "环节病历质量监测";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public override bool  RefreshCard()
        {
            chart1.Series["Series1"].Points.Clear();
            Random rand = new Random();
            for (int index = 1; index < 100; index++)
            {
                chart1.Series["Series1"].Points.AddY(rand.Next(1, 1000));
            }
            return true;
        }
        public override bool Export()
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            if (path.ShowDialog() == DialogResult.OK)
            {
                string filepath = string.Format("{0}//{1}.png", path.SelectedPath,DateTime.Now.ToString("yyyyMMddHHmmss"));
                this.chart1.SaveImage(filepath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            }
            return true;
        }
        private void cardPanel1_Enter(object sender, EventArgs e)
        {

        }
    }
}
