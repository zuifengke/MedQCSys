namespace Heren.MedQC.QuestionChat.Forms
{
    partial class SettingsForm
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
            this.chkShowPopupTip = new System.Windows.Forms.CheckBox();
            this.chkTrayIconBlink = new System.Windows.Forms.CheckBox();
            this.chkIsAutoPopupWindow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRefreshInterval = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.separateStrip1 = new Heren.Common.Controls.SeparateStrip();
            this.btnOK = new Heren.Common.Controls.HerenButton();
            this.btnClose = new Heren.Common.Controls.HerenButton();
            this.SuspendLayout();
            // 
            // chkShowPopupTip
            // 
            this.chkShowPopupTip.AutoSize = true;
            this.chkShowPopupTip.Location = new System.Drawing.Point(20, 16);
            this.chkShowPopupTip.Name = "chkShowPopupTip";
            this.chkShowPopupTip.Size = new System.Drawing.Size(156, 16);
            this.chkShowPopupTip.TabIndex = 0;
            this.chkShowPopupTip.Text = "自动浮动出消息提示窗口";
            this.chkShowPopupTip.UseVisualStyleBackColor = true;
            // 
            // chkTrayIconBlink
            // 
            this.chkTrayIconBlink.AutoSize = true;
            this.chkTrayIconBlink.Location = new System.Drawing.Point(20, 44);
            this.chkTrayIconBlink.Name = "chkTrayIconBlink";
            this.chkTrayIconBlink.Size = new System.Drawing.Size(96, 16);
            this.chkTrayIconBlink.TabIndex = 1;
            this.chkTrayIconBlink.Text = "托盘图标闪动";
            this.chkTrayIconBlink.UseVisualStyleBackColor = true;
            // 
            // chkIsAutoPopupWindow
            // 
            this.chkIsAutoPopupWindow.AutoSize = true;
            this.chkIsAutoPopupWindow.Location = new System.Drawing.Point(20, 72);
            this.chkIsAutoPopupWindow.Name = "chkIsAutoPopupWindow";
            this.chkIsAutoPopupWindow.Size = new System.Drawing.Size(354, 16);
            this.chkIsAutoPopupWindow.TabIndex = 3;
            this.chkIsAutoPopupWindow.Text = "当病历系统切换病人时,自动接收并弹出有关该病人的任务信息";
            this.chkIsAutoPopupWindow.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "任务列表自动刷新间隔：";
            // 
            // cboRefreshInterval
            // 
            this.cboRefreshInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRefreshInterval.FormattingEnabled = true;
            this.cboRefreshInterval.Location = new System.Drawing.Point(156, 95);
            this.cboRefreshInterval.Name = "cboRefreshInterval";
            this.cboRefreshInterval.Size = new System.Drawing.Size(69, 20);
            this.cboRefreshInterval.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "分钟(0-不自动刷新)";
            // 
            // separateStrip1
            // 
            this.separateStrip1.ForeColor = System.Drawing.Color.MediumBlue;
            this.separateStrip1.Location = new System.Drawing.Point(12, 125);
            this.separateStrip1.Name = "separateStrip1";
            this.separateStrip1.Size = new System.Drawing.Size(359, 12);
            this.separateStrip1.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(94, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(209, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭(&E)";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(381, 184);
            this.Controls.Add(this.chkShowPopupTip);
            this.Controls.Add(this.chkTrayIconBlink);
            this.Controls.Add(this.chkIsAutoPopupWindow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboRefreshInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.separateStrip1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowPopupTip;
        private System.Windows.Forms.CheckBox chkTrayIconBlink;
        private System.Windows.Forms.CheckBox chkIsAutoPopupWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRefreshInterval;
        private System.Windows.Forms.Label label2;
        private Heren.Common.Controls.SeparateStrip separateStrip1;
        private Heren.Common.Controls.HerenButton btnOK;
        private Heren.Common.Controls.HerenButton btnClose;
    }
}