using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace MedQC.Test
{
    public partial class PrintDemo : Form
    {
        EncodingOptions options = null;
        BarcodeWriter writer = null;
        public PrintDemo()
        {
            InitializeComponent();
            options = new EncodingOptions
            {
                //DisableECI = true,  
                //CharacterSet = "UTF-8",  
                Width = pictureBoxQr.Width,
                Height = pictureBoxQr.Height,
                PureBarcode = true
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.CODE_93;
            writer.Options = options;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_93,
                Options = new EncodingOptions
                {
                    Height = pictureBoxQr.Height,
                    Width = pictureBoxQr.Width
                }
            };
            pictureBoxQr.Image = writer.Write(this.textBoxText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = printDocument1;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument1.Print();
                }
                catch
                {   //停止打印
                    printDocument1.PrintController.OnEndPrint(printDocument1, new System.Drawing.Printing.PrintEventArgs());
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             e.Graphics.DrawImage(this.pictureBoxQr.Image, 20, 20);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.PrintPreviewControl.Document = this.printDocument1;
            this.printPreviewDialog1.ShowDialog();
        }
    }
}
