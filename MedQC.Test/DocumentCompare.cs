using Heren.MedQC.Utilities;
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
    public partial class DocumentCompare : Form
    {
        public DocumentCompare()
        {
            InitializeComponent();
            this.richTextBox1.AppendText("");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = this.richTextBox1.Text;
            string text2 = this.richTextBox2.Text;
            StringHelper.SimilarityResult similarityResult = StringHelper.SimilarityRate(text1, text2);
            this.lbl_Result.Text = string.Format("相似度为：{0}，消耗时间：{1}毫秒", (similarityResult.Rate * 100).ToString("f2"), similarityResult.ExeTime);
        }
    }
}
