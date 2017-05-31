using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Configuration;


namespace Heren.MedQC.Test
{
    public partial class IDReadForm : Form
    {
        byte[] Data = new byte[256];
        char[] charData = new char[256];

        public IDReadForm()
        {
            InitializeComponent();
        }
        ~IDReadForm()
        {
            Data = null;
            charData = null;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("termb.dll", EntryPoint = "InitCommExt")]
        public static extern int InitCommExt();

        [DllImport("termb.dll", EntryPoint = "InitComm")]
        public static extern int InitComm(int port);

        [DllImport("termb.dll", EntryPoint = "Authenticate")]
        public static extern int Authenticate();

        [DllImport("termb.dll", EntryPoint = "Read_Content")]
        public static extern int Read_Content(int Active);

        [DllImport("termb.dll", EntryPoint = "Read_Content_Path")]
        public static extern int Read_Content_Path(string cPath, int Active);

        [DllImport("termb.dll", EntryPoint = "CloseComm")]
        public static extern int CloseComm();

        private void button1_Click(object sender, EventArgs e)
        {
            int Comm_stat = InitCommExt();
            if (Comm_stat != 0)
            {
                switch (Comm_stat)
                {
                    case 1:
                        label2.Text = "串口1使用中！";
                        break;
                    case 2:
                        label2.Text = "串口2使用中！";
                        break;
                    case 3:
                        label2.Text = "串口3使用中！";
                        break;
                    case 4:
                        label2.Text = "串口4使用中！";
                        break;
                    case 1001:
                        label2.Text = "USB1使用中！";
                        break;
                    case 1002:
                        label2.Text = "USB2使用中！";
                        break;
                    case 1003:
                        label2.Text = "USB3使用中！";
                        break;
                    case 1004:
                        label2.Text = "USB4使用中！";
                        break;
                    default:
                        label2.Text = "未知错误！";
                        return;
                }
            }
            else
            {
                label1.Text = "端口初始化错误！检查是否正确连接设备或拔下设备线路重新插入，再读取数据。";
                return;
            }




           int Auth_stat= Authenticate();
           if (Auth_stat!=1)
           {
               label1.Text = "鉴权失败，请重新放置卡片！";
               if (CloseComm() != 1)
               {
                   label1.Text = "关闭串口失败！";
               }
               return;
           }


           int Read_stat = Read_Content_Path("D:\\", 1);
           //int Read_stat = Read_Content(1); //读取卡片信息的另一种方式，注意数据存储位置。
           if (Read_stat != 1)
           {
               switch (Read_stat)
               {
                   case 0:
                       label1.Text = "读卡失败！";
                       break;
                   case 2:
                       label1.Text = "没有最新注册信息！";
                       break;
                   case -1:
                       label1.Text = "相片解码错误！";
                       break;
                   case -2:
                       label1.Text = "wlt 文件后缀错误！";
                       break;
                   case -3:
                       label1.Text = "wlt 文件打开错误！";
                       break;
                   case -4:
                       label1.Text = "wlt 文件格式错误！";
                       break;
                   case -5:
                       label1.Text = "软件未授权！";
                       break;
                   case -11:
                       label1.Text = "无效参数！";
                       break;
                   case -12:
                       label1.Text = "路径太长！";
                       break;
               }
               if (CloseComm() != 1)
               {
                   label1.Text = "关闭串口失败！";
               }
               return;
           }
           else
           {
               label1.Text = "信息正确保存！请放入下一张卡，点击读卡按钮！";
           }


           if (CloseComm() != 1)
           {
               label1.Text = "关闭串口失败！";
           }
           //读取文件信息
           ////////////////////////////////////////////////////////////////////
           try
           {
               using (FileStream sFile = new FileStream("D:\\wz.txt", FileMode.Open))
               {
                   sFile.Read(Data, 0, 256);
                   sFile.Close();
               }
           }
           catch (IOException ex)
           {
               Console.WriteLine("An IO exception has been thrown!");
               Console.WriteLine(ex.ToString());
               label1.Text = "文件读取出错！请确保文件没有被其他人占用。";
               return;
           }
           //把Data数组转成大端模式
           /////////////////////////////////////////////////////////////
           byte a;
           for(int i=0; i<256; i++)
           {
                if(i%2==0)

                {
                    a = Data[i];
                    Data[i] = Data[i + 1];
                    Data[i + 1] = a;
                }
           }

           //解码大端模式
           ////////////////////////////////////////////////////
           Decoder d = Encoding.BigEndianUnicode.GetDecoder();
           d.GetChars(Data, 0, Data.Length, charData, 0);

           ////////////////////////////////////////////////////
           string value = new string(charData);

           //解析各个数据项
           //////////////////////////////////////////////////
           string name = value.Substring(0, 15).Trim();
           string sex = value.Substring(15, 1).Trim();
           string nation = value.Substring(16, 2).Trim();
           string birth = value.Substring(18, 8).Trim();
           string addr = value.Substring(26, 35).Trim();
           string idNo = value.Substring(61, 18).Trim();
           string signGov = value.Substring(79, 15).Trim();
           string startDate = value.Substring(94, 8).Trim();
           string endDate = value.Substring(102, 8).Trim();

           long zplength = Public_class.Getzplength();
           if (-1 == zplength)
           {
               label1.Text ="获取照片大小失败！";
               return;
           }
           byte[] bmp = new byte[zplength];

           //读取zp.bmp信息数据
           try
           {
               using (FileStream zpFile = new FileStream("D:\\zp.bmp", FileMode.Open))
               {

                  zpFile.Seek(0, SeekOrigin.Begin);
                  for (int i = 0; i < zpFile.Length; i++)
                      bmp[i] =(byte)zpFile.ReadByte();
                  
                  zpFile.Close();
               }
           }
           catch (IOException ex)
           {
               Console.WriteLine("An IO exception has been thrown!");
               Console.WriteLine(ex.ToString());
               label1.Text = "照片文件读取出错！";
               return;
           }
           // MessageBox.Show(new string(bmp));
           //显示数据
           touxiang.ImageLocation = "D:\\zp.bmp";
           lname.Text = name;
           lsex.Text = Public_class.Fsex(int.Parse(sex));
           lnation.Text = Public_class.Fminzu(int.Parse(nation));
           lbirth.Text = birth;
           laddr.Text = addr;
           lidNo.Text = idNo;
           lsignGov.Text = signGov;
           lstartDate.Text = startDate;
           lendDate.Text = endDate;

           //把读出来的照片信息重新创建一个bmp文件
           try
           {
               using (FileStream zpFile = new FileStream("D:\\test.bmp", FileMode.Create))
               {
                   zpFile.Seek(0, SeekOrigin.Begin);
                   for (int i = 0; i < bmp.Length; i++)
                   {
                       zpFile.WriteByte(bmp[i]);
                   }
                   zpFile.Close();
               }
           }
           catch (IOException ex)
           {
               Console.WriteLine("An IO exception has been thrown!");
               Console.WriteLine(ex.ToString());
               label1.Text = "照片文件创建出错！";
               return;
           }

           //内存回收
           value = null;
           bmp = null;
           GC.Collect();

        }
    }
}