namespace Heren.MedQC.ScreenSnap
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenSnapForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblPicSize = new System.Windows.Forms.Label();
            this.lblPicPosition = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbDelayTime = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripSnap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripClearImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSound = new System.Windows.Forms.ToolStripButton();
            this.ScreenSnapToolAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSnap = new System.Windows.Forms.GroupBox();
            this.rbRegion = new System.Windows.Forms.RadioButton();
            this.rbFullScreen = new System.Windows.Forms.RadioButton();
            this.btnSnap = new System.Windows.Forms.Button();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBoxSnap.SuspendLayout();
            this.groupBoxSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 2000;
            this.toolTip1.InitialDelay = 800;
            this.toolTip1.ReshowDelay = 100;
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 17);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(698, 482);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox, "单击图片可将图片复制到剪贴板");
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // lblPicSize
            // 
            this.lblPicSize.AutoSize = true;
            this.lblPicSize.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPicSize.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPicSize.Location = new System.Drawing.Point(249, 535);
            this.lblPicSize.Name = "lblPicSize";
            this.lblPicSize.Size = new System.Drawing.Size(0, 19);
            this.lblPicSize.TabIndex = 4;
            // 
            // lblPicPosition
            // 
            this.lblPicPosition.AutoSize = true;
            this.lblPicPosition.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPicPosition.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPicPosition.Location = new System.Drawing.Point(23, 535);
            this.lblPicPosition.Name = "lblPicPosition";
            this.lblPicPosition.Size = new System.Drawing.Size(0, 19);
            this.lblPicPosition.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 502);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbDelayTime,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton3,
            this.cbSound});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbDelayTime
            // 
            this.cbDelayTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbDelayTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cbDelayTime.Image = ((System.Drawing.Image)(resources.GetObject("cbDelayTime.Image")));
            this.cbDelayTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cbDelayTime.Margin = new System.Windows.Forms.Padding(0, 1, 8, 2);
            this.cbDelayTime.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.cbDelayTime.Name = "cbDelayTime";
            this.cbDelayTime.Size = new System.Drawing.Size(23, 22);
            this.cbDelayTime.Text = "toolStripButton3";
            this.cbDelayTime.ToolTipText = "延时5秒截图";
            this.cbDelayTime.Click += new System.EventHandler(this.time_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoToolTip = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSnap,
            this.toolStripSeparator1,
            this.ToolStripOpen,
            this.ToolStripSave,
            this.toolStripSeparator2,
            this.ToolStripClose});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 2);
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(36, 23);
            this.toolStripDropDownButton1.Text = "文件";
            // 
            // ToolStripSnap
            // 
            this.ToolStripSnap.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.snap;
            this.ToolStripSnap.Name = "ToolStripSnap";
            this.ToolStripSnap.Size = new System.Drawing.Size(148, 22);
            this.ToolStripSnap.Text = "新建屏幕截图";
            this.ToolStripSnap.Click += new System.EventHandler(this.ToolStripSnap_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // ToolStripOpen
            // 
            this.ToolStripOpen.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.open;
            this.ToolStripOpen.Name = "ToolStripOpen";
            this.ToolStripOpen.Size = new System.Drawing.Size(148, 22);
            this.ToolStripOpen.Text = "打开图像";
            this.ToolStripOpen.Click += new System.EventHandler(this.ToolStripOpen_Click);
            // 
            // ToolStripSave
            // 
            this.ToolStripSave.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.Save;
            this.ToolStripSave.Name = "ToolStripSave";
            this.ToolStripSave.Size = new System.Drawing.Size(148, 22);
            this.ToolStripSave.Text = "保存图像";
            this.ToolStripSave.Click += new System.EventHandler(this.ToolStripSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // ToolStripClose
            // 
            this.ToolStripClose.Name = "ToolStripClose";
            this.ToolStripClose.Size = new System.Drawing.Size(148, 22);
            this.ToolStripClose.Text = "退出";
            this.ToolStripClose.Click += new System.EventHandler(this.ToolStripClose_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AutoToolTip = false;
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripCopy,
            this.ToolStripClearImage,
            this.toolStripSeparator3});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Margin = new System.Windows.Forms.Padding(0, 0, 8, 2);
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(36, 23);
            this.toolStripDropDownButton2.Text = "编辑";
            // 
            // ToolStripCopy
            // 
            this.ToolStripCopy.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.paste;
            this.ToolStripCopy.Name = "ToolStripCopy";
            this.ToolStripCopy.Size = new System.Drawing.Size(124, 22);
            this.ToolStripCopy.Text = "复制图像";
            this.ToolStripCopy.Click += new System.EventHandler(this.ToolStripCopy_Click);
            // 
            // ToolStripClearImage
            // 
            this.ToolStripClearImage.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.Delete;
            this.ToolStripClearImage.Name = "ToolStripClearImage";
            this.ToolStripClearImage.Size = new System.Drawing.Size(124, 22);
            this.ToolStripClearImage.Text = "清除图像";
            this.ToolStripClearImage.Click += new System.EventHandler(this.ToolStripClearImage_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.AutoToolTip = false;
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripFullScreen,
            this.ToolStripRegion});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Margin = new System.Windows.Forms.Padding(0, 0, 8, 2);
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.ShowDropDownArrow = false;
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(36, 23);
            this.toolStripDropDownButton3.Text = "捕捉";
            // 
            // ToolStripFullScreen
            // 
            this.ToolStripFullScreen.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.quping;
            this.ToolStripFullScreen.Name = "ToolStripFullScreen";
            this.ToolStripFullScreen.Size = new System.Drawing.Size(100, 22);
            this.ToolStripFullScreen.Text = "全屏";
            this.ToolStripFullScreen.Click += new System.EventHandler(this.ToolStripFullScreen_Click);
            // 
            // ToolStripRegion
            // 
            this.ToolStripRegion.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.quyu;
            this.ToolStripRegion.Name = "ToolStripRegion";
            this.ToolStripRegion.Size = new System.Drawing.Size(100, 22);
            this.ToolStripRegion.Text = "区域";
            this.ToolStripRegion.Click += new System.EventHandler(this.ToolStripRegion_Click);
            // 
            // cbSound
            // 
            this.cbSound.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbSound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cbSound.Image = ((System.Drawing.Image)(resources.GetObject("cbSound.Image")));
            this.cbSound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cbSound.Name = "cbSound";
            this.cbSound.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.cbSound.Size = new System.Drawing.Size(23, 22);
            this.cbSound.ToolTipText = "关闭音乐";
            this.cbSound.Click += new System.EventHandler(this.sound_Click);
            // 
            // ScreenSnapToolAbout
            // 
            this.ScreenSnapToolAbout.Name = "ScreenSnapToolAbout";
            this.ScreenSnapToolAbout.Size = new System.Drawing.Size(32, 19);
            // 
            // groupBoxSnap
            // 
            this.groupBoxSnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSnap.Controls.Add(this.rbRegion);
            this.groupBoxSnap.Controls.Add(this.rbFullScreen);
            this.groupBoxSnap.Controls.Add(this.btnSnap);
            this.groupBoxSnap.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSnap.Location = new System.Drawing.Point(722, 28);
            this.groupBoxSnap.Name = "groupBoxSnap";
            this.groupBoxSnap.Size = new System.Drawing.Size(120, 96);
            this.groupBoxSnap.TabIndex = 5;
            this.groupBoxSnap.TabStop = false;
            // 
            // rbRegion
            // 
            this.rbRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbRegion.AutoSize = true;
            this.rbRegion.Checked = true;
            this.rbRegion.Location = new System.Drawing.Point(64, 63);
            this.rbRegion.Name = "rbRegion";
            this.rbRegion.Size = new System.Drawing.Size(50, 21);
            this.rbRegion.TabIndex = 2;
            this.rbRegion.TabStop = true;
            this.rbRegion.Text = "区域";
            this.rbRegion.UseVisualStyleBackColor = true;
            // 
            // rbFullScreen
            // 
            this.rbFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFullScreen.AutoSize = true;
            this.rbFullScreen.Location = new System.Drawing.Point(13, 63);
            this.rbFullScreen.Name = "rbFullScreen";
            this.rbFullScreen.Size = new System.Drawing.Size(50, 21);
            this.rbFullScreen.TabIndex = 1;
            this.rbFullScreen.Text = "全屏";
            this.rbFullScreen.UseVisualStyleBackColor = true;
            // 
            // btnSnap
            // 
            this.btnSnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnap.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.snap;
            this.btnSnap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnap.Location = new System.Drawing.Point(13, 22);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(95, 35);
            this.btnSnap.TabIndex = 0;
            this.btnSnap.Text = "截图";
            this.btnSnap.UseVisualStyleBackColor = true;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSave.Controls.Add(this.btnSave);
            this.groupBoxSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSave.Location = new System.Drawing.Point(722, 432);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(120, 96);
            this.groupBoxSave.TabIndex = 6;
            this.groupBoxSave.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Heren.MedQC.ScreenSnap.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(13, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ScreenSnapForm
            // 
            this.AcceptButton = this.btnSnap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 539);
            this.Controls.Add(this.groupBoxSave);
            this.Controls.Add(this.groupBoxSnap);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPicPosition);
            this.Controls.Add(this.lblPicSize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenSnapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控截屏小工具";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxSnap.ResumeLayout(false);
            this.groupBoxSnap.PerformLayout();
            this.groupBoxSave.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblPicSize;
        private System.Windows.Forms.Label lblPicPosition;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cbDelayTime;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripSnap;
        private System.Windows.Forms.ToolStripMenuItem ToolStripOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripClose;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripCopy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripClearImage;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripFullScreen;
        private System.Windows.Forms.ToolStripMenuItem ToolStripRegion;
        private System.Windows.Forms.ToolStripMenuItem ScreenSnapToolAbout;
        private System.Windows.Forms.ToolStripButton cbSound;
        private System.Windows.Forms.GroupBox groupBoxSnap;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.RadioButton rbRegion;
        private System.Windows.Forms.RadioButton rbFullScreen;
        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

