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
using Quartz.Server;
using MedDocSys.QCEngine.TimeCheck;
using Heren.MedQC.Utilities;
using EMRDBLib.DbAccess;
using Heren.MedQC.ScriptEngine.Debugger;
using Heren.MedQC.CheckPoint;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.IO;

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
            bajk08.KEY0801 = random.Next(100000, 999999);
            bajk08.COL0805 = DateTime.Now;
            BAJK08Access.Instance.Insert(bajk08);
            bajk08.COL0806 = 9;
            short shRet = BAJK08Access.Instance.Update(bajk08);
            shRet = BAJK08Access.Instance.Delete(bajk08.KEY0801.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string szPatientID = "10030";
            string szVisitID = "1";
            RecUploadService.Instance.InitializeDict();
            bool result = RecUploadService.Instance.Upload(szPatientID, szVisitID);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PatVisitInfo patVisitInfo = new PatVisitInfo();
            patVisitInfo.PATIENT_ID = "P101210";
            patVisitInfo.VISIT_NO = "20170300005";
            patVisitInfo.VISIT_ID = "2";
            patVisitInfo.PATIENT_NAME = "孔明";

            short shRet = MedDocSys.QCEngine.TimeCheck.TimeCheckHelper.Instance.GenerateTimeRecord(patVisitInfo, DateTime.Now);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GenerateCode frm = new GenerateCode();
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ComponentTest frm = new ComponentTest();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //StringHelper.SimilarityResult similarityResult = StringHelper.SimilarityRate("我是中国浙江人", "我是美国纽约人");
            //Console.Write(string.Format("相似度为：{0}，消耗时间：{1}", similarityResult.Rate, similarityResult.ExeTime));
            DocumentCompare frm = new DocumentCompare();
            frm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string szPatientID = this.textBox1.Text;
            string szVisitID = this.textBox2.Text;
            PatVisitInfo patVisitInfo = new PatVisitInfo();
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(szPatientID, szVisitID, ref patVisitInfo);
            QcCheckPoint qcCheckPoint = null;
            string szQcCheckPointID = "P201608281312459709";
            shRet = QcCheckPointAccess.Instance.GetQcCheckPoint(szQcCheckPointID, ref qcCheckPoint);
            DebuggerForm frm = new DebuggerForm();
            frm.PatVisitInfo = patVisitInfo;
            frm.QcCheckPoint = qcCheckPoint;
            QcCheckResult qcCheckResult = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitInfo);
            frm.QcCheckResult = qcCheckResult;
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = "user id=medqc;password=medqc;data source=192.168.152.128/meddoczh";
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select SCRIPT_DATA,script_id from SCRIPT_DATA_T where script_id='201708141526353047'";
            cmd.Connection = con;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            do
            {
                
                byte[] source ;
                if (!reader.IsDBNull(0))
                    source = (byte[])reader.GetValue(0);

            } while (reader.Read());
            
                
            //OracleDataAdapter da = new OracleDataAdapter();
            //da.SelectCommand = cmd;
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            con.Close();
            reader.Dispose();
            cmd.Dispose();
            con.Dispose();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                ShareFolderRead.Download(@"\\129.88.47.11\ris\report\PDF\FSK\2017-08-30\9337401.pdf", @"D:\download\9337401.pdf", "129.88.47.11", "ris", "maroland");
                bool status = false;
               
                //连接共享文件夹
                status = ShareFolderRead.connectState(@"\\DESKTOP-L0DIMB0\share", "zuifengke111@outlook.com", "yehui198971");
                if (status)
                {
                    //共享文件夹的目录
                    DirectoryInfo theFolder = new DirectoryInfo(@"\\DESKTOP-L0DIMB0\share");
                    //相对共享文件夹的路径
                    string fielpath = @"\test";
                    //获取保存文件的路径
                    string filename = theFolder.ToString() + fielpath;
                    //执行方法
                    ShareFolderRead.Transport(filename + @"\11.txt", @"D:\download\", "11.txt");

                }
                else
                {
                    //ListBox1.Items.Add("未能连接！");
                }

                status = false;

                //连接共享文件夹
                status = ShareFolderRead.connectState(@"\\129.88.47.11", "ris", "maroland");
                if (status)
                {
                    //共享文件夹的目录
                    DirectoryInfo theFolder = new DirectoryInfo(@"\\129.88.47.11\ris");
                    //相对共享文件夹的路径
                    string fielpath = @"\report\PDF\FSK\2017-08-30\";
                    //获取保存文件的路径
                    string filename = theFolder.ToString() + fielpath;
                    //执行方法
                    ShareFolderRead.Transport(filename + @"\9337401.pdf", @"D:\download\", "9337401.pdf");

                }
                else
                {
                    //ListBox1.Items.Add("未能连接！");
                }
               

            }
            catch (Exception ex)
            {

            }
        }
    }
}
