using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using EMRDBLib;
using Heren.MedQC.Core;
namespace Heren.MedQC.ScreenSnap
{
    public partial class ScreenSnapForm : Form
    {
        Bitmap image;
        Thread playWav;
        int imageNum = 1;
        bool isFirstTimeShow = true;

        public ScreenSnapForm()
        {
            InitializeComponent();
            playWav = new Thread(new ThreadStart(playStartWav));
            playWav.Start();
            Snap(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            playWav.Abort();
            pcurrentWin = this;
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            if (rbFullScreen.Checked == false)
            {
                this.Hide();
                Thread.Sleep(300);
                if (cbDelayTime.Checked == true)
                    Thread.Sleep(5000);
                ScreenShadeForm form2 = new ScreenShadeForm();
                form2.ShowDialog();
            }
            else
            {
                this.Hide();
                Thread.Sleep(300);
                if (cbDelayTime.Checked == true)
                    Thread.Sleep(5000);
                Snap(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                this.Show();
            }
        }

        public static ScreenSnapForm
            pcurrentWin = null;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox.BackgroundImage != null)
            {
                playWav = new Thread(new ThreadStart(playSaveWav));
                playWav.Start();
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "png";
                dlg.Filter = "Png Files|*.png";
                if (SystemParam.Instance.PatVisitInfo!= null)
                {
                    dlg.FileName = string.Format("{0}_{1}_{2}", SystemParam.Instance.PatVisitInfo.DEPT_NAME, SystemParam.Instance.PatVisitInfo.PATIENT_NAME, SystemParam.Instance.PatVisitInfo.PATIENT_ID);
                }
                else
                {
                    dlg.FileName = "ScreenSnap" + imageNum.ToString();
                }
                DialogResult res = dlg.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox.BackgroundImage.Save(dlg.FileName, ImageFormat.Png);
                    imageNum++;
                }
                playWav.Abort();
            }
        }

        public void Snap(int x, int y, int width, int height)
        {
            try
            {
                if (isFirstTimeShow == false)   //如果程序是第一次运行, 则不播放快门声
                {
                    playWav = new Thread(new ThreadStart(playSuccessWav));
                    playWav.Start();
                }

                isFirstTimeShow = false;
                pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
                image = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(image);
                g.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width, height));
                lblPicPosition.Visible = true;
                lblPicSize.Visible = true;
                lblPicPosition.Text = "Start Position:  ( " + x.ToString() + ", " + y.ToString() + " )";
                lblPicSize.Text = "Size:  " + width.ToString() + " * " + height.ToString();
                if (width < pictureBox.Width && height < pictureBox.Height)
                    pictureBox.BackgroundImageLayout = ImageLayout.Center;
                pictureBox.BackgroundImage = image;
            }
            catch { }
        }

        private void ToolStripOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "png|jpg|bmp";
            dlg.Filter = "Png Files|*.png|Jpg Files|*.jpg|Bmp Files|*.bmp";
            dlg.FileName = "ScreenSnap" + imageNum.ToString();
            DialogResult res = dlg.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox.BackgroundImage = Image.FromFile(dlg.FileName);
                lblPicPosition.Visible = false;
                lblPicSize.Visible = true;
                lblPicSize.Text = "Size:  " + pictureBox.BackgroundImage.Width.ToString() + " * " + pictureBox.BackgroundImage.Height.ToString();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            //单击PictureBox, 当图像不为空的时候, 将图像复制到剪贴板
            //if (pictureBox.BackgroundImage != null)
            //{
            //    try
            //    {
            //        Clipboard.SetImage(pictureBox.BackgroundImage);
            //        MessageBox.Show("图片已复制到剪贴板","",MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch { }
            //}
        }

        private void ToolStripCopy_Click(object sender, EventArgs e)
        {
            pictureBox_Click(sender, e);
        }
        private void time_Click(object sender, EventArgs e)
        {
            cbDelayTime.Checked = !cbDelayTime.Checked;
        }

        private void sound_Click(object sender, EventArgs e)
        {
            cbSound.Checked = !cbSound.Checked;
        }

        private void ToolStripFullScreen_Click(object sender, EventArgs e)
        {
            rbFullScreen.Checked = true;
            btnSnap_Click(sender, e);
        }

        private void ToolStripRegion_Click(object sender, EventArgs e)
        {
            rbRegion.Checked = true;
            btnSnap_Click(sender, e);
        }

        private void ToolStripClearImage_Click(object sender, EventArgs e)
        {
            image = null;
            pictureBox.BackgroundImage = null;
            lblPicPosition.Visible = false;
            lblPicSize.Visible = false;
        }

        private void ToolStripSnap_Click(object sender, EventArgs e)
        {
            btnSnap_Click(sender, e);
        }

        private void ToolStripClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripSave_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        
        [System.Runtime.InteropServices.DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

        [System.Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }

        public void playStartWav()
        {
            if (this.cbSound.Checked == false)
            {
                try
                {
                    PlaySound(@"Resources\startSnap.wav", new System.IntPtr(), PlaySoundFlags.SND_SYNC);
                }
                catch { }
            }
        }

        public void playSaveWav()
        {
            if (cbSound.Checked == false)
            {
                try
                {
                    PlaySound(@"Resources\save.wav", new System.IntPtr(), PlaySoundFlags.SND_SYNC);
                }
                catch { }
            }
        }

        public void playSuccessWav()
        {
            if (cbSound.Checked == false)
            {
                try
                {
                    PlaySound(@"Resources\success.wav", new System.IntPtr(), PlaySoundFlags.SND_SYNC);
                }
                catch { }
            }
        }

       
    }
}
