using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Resources;
using Heren.Common.Libraries;

namespace Heren.MedQC.Hdp
{
    public partial class IconSelectForm : Form
    {
        
        public IconSelectForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            FileInfo[] fileInfos= GlobalMethods.IO.GetFiles(GlobalMethods.Misc.GetWorkingPath() + "//Icon");
            foreach (FileInfo file in fileInfos)
            {
                byte[] bytedata;
                Image image = new Bitmap(file.FullName);
                PictureBox picBox = new PictureBox();
                picBox.Size = image.Size;
                picBox.Image = image;
                picBox.Name = "pic1_" + file.Name;
                picBox.Tag = file.Name;
                picBox.Click += new EventHandler(picBox_Click);
                this.flowLayoutPanel1.Controls.Add(picBox);
            }
        }

        private void picBox_Click(object sender, System.EventArgs e)
        {
            PictureBox pic= sender as PictureBox;
            foreach (PictureBox item in this.flowLayoutPanel1.Controls)
            {
                if (item == null)
                    continue;
                item.BorderStyle = BorderStyle.None;
            }
            pic.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox1.Image = pic.Image;
            this.pictureBox1.Tag = pic.Tag;
            this.pictureBox1.Size = pic.Image.Size;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
            {
                MessageBoxEx.ShowError("Î´Ñ¡ÖÐÍ¼±ê");
                return;
            }
            this.DialogResult = DialogResult.OK;
            
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }


}