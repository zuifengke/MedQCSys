namespace Heren.MedQC.Utilities.Dialogs
{
    partial class ImageViewerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kpImageViewer1 = new KaiwaProjects.KpImageViewer();
            this.SuspendLayout();
            // 
            // kpImageViewer1
            // 
            this.kpImageViewer1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.kpImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpImageViewer1.GifAnimation = false;
            this.kpImageViewer1.Image = null;
            this.kpImageViewer1.Location = new System.Drawing.Point(0, 0);
            this.kpImageViewer1.MenuColor = System.Drawing.Color.LightSteelBlue;
            this.kpImageViewer1.MenuPanelColor = System.Drawing.Color.LightSteelBlue;
            this.kpImageViewer1.MinimumSize = new System.Drawing.Size(454, 145);
            this.kpImageViewer1.Name = "kpImageViewer1";
            this.kpImageViewer1.NavigationPanelColor = System.Drawing.Color.LightSteelBlue;
            this.kpImageViewer1.NavigationTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.kpImageViewer1.OpenButton = true;
            this.kpImageViewer1.PreviewButton = true;
            this.kpImageViewer1.PreviewPanelColor = System.Drawing.Color.LightSteelBlue;
            this.kpImageViewer1.PreviewText = "Preview";
            this.kpImageViewer1.PreviewTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.kpImageViewer1.Rotation = 0;
            this.kpImageViewer1.ShowPreview = false;
            this.kpImageViewer1.Size = new System.Drawing.Size(612, 587);
            this.kpImageViewer1.TabIndex = 0;
            this.kpImageViewer1.TextColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // ImageViewerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 587);
            this.Controls.Add(this.kpImageViewer1);
            this.Name = "ImageViewerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "照片浏览器";
            this.ResumeLayout(false);

        }

        #endregion

        private KaiwaProjects.KpImageViewer kpImageViewer1;
    }
}