using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Heren.MedQC.QuestionChat.Forms
{
    public partial class ScreenSnapForm : Form
    {
        public Bitmap image;
        private QCQuestionChatForm m_qchatForm = null;
        public QCQuestionChatForm QCchatForm
        {
            get { return this.m_qchatForm; }
        }
        public ScreenSnapForm(QCQuestionChatForm qchatForm)
        {
            InitializeComponent();
            this.m_qchatForm = qchatForm;
            pcurrentWin = this;
        }
        public static ScreenSnapForm
           pcurrentWin = null;
        private void fbtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ScreenSnap();
        }
        private void fbtnScreenshot_Click(object sender, EventArgs e)
        {
            ScreenSnap();
        }

        public void ScreenSnap()
        {
            this.Hide();
            this.m_qchatForm.Hide();
            Thread.Sleep(3000);
            ScreenShadeForm form2 = new ScreenShadeForm();
            form2.ShowDialog();

        }

        private void fbtnSend_Click(object sender, EventArgs e)
        {
            if (this.image != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("无法发送截图给对方");
                this.DialogResult = DialogResult.Cancel;
            }

        }

        public void Snap(int x, int y, int width, int height)
        {
            try
            {
                pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
                image = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(image);
                g.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width, height));

                if (width < pictureBox.Width && height < pictureBox.Height)
                    pictureBox.BackgroundImageLayout = ImageLayout.Center;
                pictureBox.BackgroundImage = image;
            }
            catch { }
        }
    }
}