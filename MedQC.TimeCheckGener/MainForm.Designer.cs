namespace MedQC.TimeCheckGener
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nudQCBeginMinute = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nudQCBeginHour = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.nudNormalDisCharge = new System.Windows.Forms.NumericUpDown();
            this.QCProgressBar = new System.Windows.Forms.ProgressBar();
            this.chkTimeCheckRunning = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BugProgressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.chkContentCheckRunning = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBugBeginMinute = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBugBeginHour = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudDocContentDay = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mainStatusStrip1 = new Heren.MedQC.TimeCheckGener.Forms.MainStatusStrip();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQCBeginMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQCBeginHour)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormalDisCharge)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBugBeginMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBugBeginHour)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocContentDay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(604, 326);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(116, 42);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.nudQCBeginMinute);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.nudQCBeginHour);
            this.groupBox5.Location = new System.Drawing.Point(6, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(307, 72);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "生成定时";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 12);
            this.label14.TabIndex = 35;
            this.label14.Text = "开始生成时间每日：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(248, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 34;
            this.label15.Text = "分";
            // 
            // nudQCBeginMinute
            // 
            this.nudQCBeginMinute.Location = new System.Drawing.Point(200, 30);
            this.nudQCBeginMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudQCBeginMinute.Name = "nudQCBeginMinute";
            this.nudQCBeginMinute.Size = new System.Drawing.Size(45, 21);
            this.nudQCBeginMinute.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(178, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "时";
            // 
            // nudQCBeginHour
            // 
            this.nudQCBeginHour.Location = new System.Drawing.Point(129, 30);
            this.nudQCBeginHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudQCBeginHour.Name = "nudQCBeginHour";
            this.nudQCBeginHour.Size = new System.Drawing.Size(45, 21);
            this.nudQCBeginHour.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.nudNormalDisCharge);
            this.groupBox4.Location = new System.Drawing.Point(345, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 72);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "病案范围";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(164, 32);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 37;
            this.label23.Text = "内";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "病人入科至";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(78, 32);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 35;
            this.label28.Text = "出院";
            // 
            // nudNormalDisCharge
            // 
            this.nudNormalDisCharge.Location = new System.Drawing.Point(113, 30);
            this.nudNormalDisCharge.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNormalDisCharge.Name = "nudNormalDisCharge";
            this.nudNormalDisCharge.Size = new System.Drawing.Size(45, 21);
            this.nudNormalDisCharge.TabIndex = 10;
            this.nudNormalDisCharge.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // QCProgressBar
            // 
            this.QCProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QCProgressBar.Location = new System.Drawing.Point(6, 136);
            this.QCProgressBar.Name = "QCProgressBar";
            this.QCProgressBar.Size = new System.Drawing.Size(697, 13);
            this.QCProgressBar.TabIndex = 34;
            // 
            // chkTimeCheckRunning
            // 
            this.chkTimeCheckRunning.AutoSize = true;
            this.chkTimeCheckRunning.Checked = true;
            this.chkTimeCheckRunning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTimeCheckRunning.Location = new System.Drawing.Point(6, 111);
            this.chkTimeCheckRunning.Name = "chkTimeCheckRunning";
            this.chkTimeCheckRunning.Size = new System.Drawing.Size(120, 16);
            this.chkTimeCheckRunning.TabIndex = 35;
            this.chkTimeCheckRunning.Text = "开启病历时效检查";
            this.chkTimeCheckRunning.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "时效问题检查测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.chkTimeCheckRunning);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.QCProgressBar);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 160);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病案时效";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(281, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "病案时效将检查所有符合条件病人的病历时效问题！";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BugProgressBar);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.chkContentCheckRunning);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(709, 146);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病案内容";
            // 
            // BugProgressBar
            // 
            this.BugProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BugProgressBar.Location = new System.Drawing.Point(6, 121);
            this.BugProgressBar.Name = "BugProgressBar";
            this.BugProgressBar.Size = new System.Drawing.Size(697, 13);
            this.BugProgressBar.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "内容问题检查测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkContentCheckRunning
            // 
            this.chkContentCheckRunning.AutoSize = true;
            this.chkContentCheckRunning.Location = new System.Drawing.Point(6, 96);
            this.chkContentCheckRunning.Name = "chkContentCheckRunning";
            this.chkContentCheckRunning.Size = new System.Drawing.Size(120, 16);
            this.chkContentCheckRunning.TabIndex = 35;
            this.chkContentCheckRunning.Text = "开启病历内容检查";
            this.chkContentCheckRunning.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nudBugBeginMinute);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.nudBugBeginHour);
            this.groupBox3.Location = new System.Drawing.Point(6, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 72);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生成定时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "开始生成时间每日：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "分";
            // 
            // nudBugBeginMinute
            // 
            this.nudBugBeginMinute.Location = new System.Drawing.Point(200, 30);
            this.nudBugBeginMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudBugBeginMinute.Name = "nudBugBeginMinute";
            this.nudBugBeginMinute.Size = new System.Drawing.Size(45, 21);
            this.nudBugBeginMinute.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "时";
            // 
            // nudBugBeginHour
            // 
            this.nudBugBeginHour.Location = new System.Drawing.Point(129, 30);
            this.nudBugBeginHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudBugBeginHour.Name = "nudBugBeginHour";
            this.nudBugBeginHour.Size = new System.Drawing.Size(45, 21);
            this.nudBugBeginHour.TabIndex = 10;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudDocContentDay);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Location = new System.Drawing.Point(352, 14);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(326, 72);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "病案范围";
            // 
            // nudDocContentDay
            // 
            this.nudDocContentDay.Location = new System.Drawing.Point(51, 32);
            this.nudDocContentDay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDocContentDay.Name = "nudDocContentDay";
            this.nudDocContentDay.Size = new System.Drawing.Size(45, 21);
            this.nudDocContentDay.TabIndex = 10;
            this.nudDocContentDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "天内刚创建或修改过的病历";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 37;
            this.label9.Text = "检查前";
            // 
            // mainStatusStrip1
            // 
            this.mainStatusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.mainStatusStrip1.Location = new System.Drawing.Point(0, 368);
            this.mainStatusStrip1.MainForm = null;
            this.mainStatusStrip1.Name = "mainStatusStrip1";
            this.mainStatusStrip1.Size = new System.Drawing.Size(733, 22);
            this.mainStatusStrip1.TabIndex = 19;
            this.mainStatusStrip1.Text = "mainStatusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainStatusStrip1);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控后台监控服务程序";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQCBeginMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQCBeginHour)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormalDisCharge)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBugBeginMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBugBeginHour)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocContentDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private Heren.MedQC.TimeCheckGener.Forms.MainStatusStrip mainStatusStrip1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudQCBeginMinute;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudQCBeginHour;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown nudNormalDisCharge;
        private System.Windows.Forms.ProgressBar QCProgressBar;
        private System.Windows.Forms.CheckBox chkTimeCheckRunning;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBugBeginMinute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBugBeginHour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar BugProgressBar;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown nudDocContentDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkContentCheckRunning;
    }
}

