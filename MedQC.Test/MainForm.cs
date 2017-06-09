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
using EMRDBLib;
using Heren.MedQC.MedRecord;
using EMRDBLib.BAJK;
using Heren.MedQC.Core.Services;

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

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append(" select * from dbo.gy_gydm");
            DataSet ds = null;
            BAJKCommonAccess.Instance.ExecuteQuery(sbsql.ToString(), out ds);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CodeCompasionForm form = new CodeCompasionForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BAJK08 bajk08 = null;
            BAJK08Access.Instance.GetBAJK08s("1", "1", ref bajk08);
            Random random = new Random();
            bajk08.KEY0801 = random.Next(100000,999999);
            bajk08.COL0805 = DateTime.Now;
            BAJK08Access.Instance.Insert(bajk08);
            bajk08.COL0806 = 9;
            short shRet =BAJK08Access.Instance.Update(bajk08);
            shRet = BAJK08Access.Instance.Delete(bajk08.KEY0801.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string szPatientID = "10030";
            string szVisitID = "1";
            RecUploadService.Instance.InitializeDict();
            bool result= RecUploadService.Instance.Upload(szPatientID, szVisitID);
        }
    }
}
