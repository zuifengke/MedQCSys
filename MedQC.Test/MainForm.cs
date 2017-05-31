using Heren.MedQC.Test;
using Heren.MedQC.Utilities.IDCardRead;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedQC.Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            SplitterForm frm = new SplitterForm();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDReadForm card = new IDReadForm();
            card.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CardInfo cardInfo = null;
            MessageBox.Show(IDCardRead.GetCardInfo(ref cardInfo));
        }
    }
}
