using EMRDBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.MedQC.CheckPoint;
using Heren.MedQC.Core;

namespace Quartz.Server
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();

        }
        QuartzServer server = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.button1.Enabled = true;
            this.button4.Enabled = false;
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            SystemConfig.Instance.ConfigFile = SystemParam.Instance.ConfigFile;
            CommandHandler.Instance.Initialize();
            this.button1_Click(null, null);//自动触发启动

        }
        private void button1_Click(object sender, EventArgs e)
        {
            server = QuartzServerFactory.CreateServer();
            server.Initialize();
            server.Start();
            ChangeBtnStatus();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            server.Stop();
            ChangeBtnStatus();
        }
        private void ChangeBtnStatus()
        {
            string status= server.GetSchedulerStatus();
            switch (status)
            {
                case "started":
                    this.button1.Enabled = false;
                    this.button4.Enabled = true;
                    break;
             
                case "stoped":
                    this.button1.Enabled = true;
                    this.button4.Enabled = false;
                    break;
                default:
                    this.button1.Enabled = true;
                    this.button4.Enabled = false;
                    break;
            }
            this.timer1.Enabled = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LoadLogText();
        }

        private void LoadLogText()
        {
            try
            {
                byte[] byData = new byte[100];
                char[] charData = new char[1000];
                string fileName = string.Format("{0}\\Logs\\Server\\{1}.txt", SystemParam.Instance.WorkPath, DateTime.Now.ToString("yyyyMMdd"));
                if (!File.Exists(fileName))
                    return;
                System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
                fs.Seek(0, SeekOrigin.Begin);
                //fs.Read(byData, 0, 100); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
                //Decoder d = Encoding.Default.GetDecoder();
                //d.GetChars(byData, 0, byData.Length, charData, 0);
                this.richTextBox1.Clear();
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                String line;
                this.richTextBox1.ForeColor = Color.Black;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.ToString().IndexOf("失败") >= 0)
                    {
                        this.richTextBox1.AppendText(line.ToString());
                        this.richTextBox1.SelectionColor = Color.Red;
                    }
                    else
                    {
                        this.richTextBox1.AppendText(line.ToString() + System.Environment.NewLine);
                    }
                }
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();
            }

            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Heren.MedQC.CheckPoint.Form1 frm = new Heren.MedQC.CheckPoint.Form1();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadLogText();
        }
    }
}
