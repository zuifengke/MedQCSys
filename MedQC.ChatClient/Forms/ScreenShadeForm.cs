// ***********************************************************
// 截图工具屏幕遮罩
// Creator:yehui  Date:2014-11-19
// Copyright:supconhealth
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MedQC.ChatClient
{
    public partial class ScreenShadeForm : Form
    {
        int x, y, nowX, nowY, width, height;
        bool isMouthDown = false;
        Graphics g;

        public ScreenShadeForm()
        {
            InitializeComponent();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            x = MousePosition.X;
            y = MousePosition.Y;
            isMouthDown = true;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouthDown)
            {
                width = Math.Abs(MousePosition.X - x);
                height = Math.Abs(MousePosition.Y - y);
                g = CreateGraphics();
                g.Clear(BackColor);
                g.FillRectangle(Brushes.CornflowerBlue, x<MousePosition.X?x:MousePosition.X, y<MousePosition.Y?y:MousePosition.Y, width + 1, height + 1);
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            nowX = MousePosition.X + 1;
            nowY = MousePosition.Y + 1;
            this.Close();
            ScreenSnapForm.pcurrentWin.Snap(x < nowX ? x : nowX, y < nowY ? y : nowY, Math.Abs(nowX - x), Math.Abs(nowY - y));
            ScreenSnapForm.pcurrentWin.QCchatForm.Show();
            ScreenSnapForm.pcurrentWin.Show();
            
        }

    }
}
