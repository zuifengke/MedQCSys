using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Utilities.Dialogs
{
    public partial class ImageViewerDialog : Form
    {
        public string ImagePath { get; set; }
        public ImageViewerDialog()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (string.IsNullOrEmpty(ImagePath))
                return;
            this.kpImageViewer1.ImagePath = this.ImagePath;
        }
    }
}
