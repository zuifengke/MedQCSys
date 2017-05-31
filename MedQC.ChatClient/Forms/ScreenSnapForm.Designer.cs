namespace MedQC.ChatClient
{
    partial class ScreenSnapForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenSnapForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.fbtnSend = new System.Windows.Forms.Button();
            this.fbtnCancel = new System.Windows.Forms.Button();
            this.fbtnScreenshot = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(895, 491);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // fbtnSend
            // 
            this.fbtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnSend.Image = global::MedQC.ChatClient.Properties.Resources.send;
            this.fbtnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fbtnSend.Location = new System.Drawing.Point(820, 8);
            this.fbtnSend.Name = "fbtnSend";
            this.fbtnSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fbtnSend.Size = new System.Drawing.Size(72, 22);
            this.fbtnSend.TabIndex = 5;
            this.fbtnSend.Text = "发送";
            this.fbtnSend.Click += new System.EventHandler(this.fbtnSend_Click);
            // 
            // fbtnCancel
            // 
            this.fbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnCancel.Image = global::MedQC.ChatClient.Properties.Resources.cancel1;
            this.fbtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fbtnCancel.Location = new System.Drawing.Point(640, 8);
            this.fbtnCancel.Name = "fbtnCancel";
            this.fbtnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fbtnCancel.Size = new System.Drawing.Size(75, 22);
            this.fbtnCancel.TabIndex = 5;
            this.fbtnCancel.Text = "取消";
            this.fbtnCancel.Click += new System.EventHandler(this.fbtnCancel_Click);
            // 
            // fbtnScreenshot
            // 
            this.fbtnScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnScreenshot.Image = global::MedQC.ChatClient.Properties.Resources.Refresh;
            this.fbtnScreenshot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fbtnScreenshot.Location = new System.Drawing.Point(721, 8);
            this.fbtnScreenshot.Name = "fbtnScreenshot";
            this.fbtnScreenshot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fbtnScreenshot.Size = new System.Drawing.Size(93, 22);
            this.fbtnScreenshot.TabIndex = 5;
            this.fbtnScreenshot.Text = "重新截图";
            this.fbtnScreenshot.Click += new System.EventHandler(this.fbtnScreenshot_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fbtnSend);
            this.panel1.Controls.Add(this.fbtnScreenshot);
            this.panel1.Controls.Add(this.fbtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 491);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 33);
            this.panel1.TabIndex = 6;
            // 
            // ScreenSnapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 524);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenSnapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "截图预览";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button fbtnSend;
        private System.Windows.Forms.Button fbtnCancel;
        private System.Windows.Forms.Button fbtnScreenshot;
        private System.Windows.Forms.Panel panel1;
    }
}