namespace MedQCSys.Dialogs
{
    partial class SystemAboutForm
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
            this.picSoftwareLogo = new System.Windows.Forms.PictureBox();
            this.txtSoftware = new System.Windows.Forms.TextBox();
            this.txtCopyrightCH = new System.Windows.Forms.TextBox();
            this.txtCopyrightEN = new System.Windows.Forms.TextBox();
            this.txtCertText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVersionInfo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSoftwareLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picSoftwareLogo
            // 
            this.picSoftwareLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSoftwareLogo.Location = new System.Drawing.Point(0, 0);
            this.picSoftwareLogo.Name = "picSoftwareLogo";
            this.picSoftwareLogo.Size = new System.Drawing.Size(647, 98);
            this.picSoftwareLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSoftwareLogo.TabIndex = 0;
            this.picSoftwareLogo.TabStop = false;
            this.picSoftwareLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picSoftwareLogo_Paint);
            // 
            // txtSoftware
            // 
            this.txtSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoftware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtSoftware.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoftware.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoftware.Location = new System.Drawing.Point(7, 104);
            this.txtSoftware.Name = "txtSoftware";
            this.txtSoftware.ReadOnly = true;
            this.txtSoftware.Size = new System.Drawing.Size(632, 15);
            this.txtSoftware.TabIndex = 1;
            this.txtSoftware.Text = "软件信息";
            // 
            // txtCopyrightCH
            // 
            this.txtCopyrightCH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyrightCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCopyrightCH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCopyrightCH.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopyrightCH.Location = new System.Drawing.Point(7, 126);
            this.txtCopyrightCH.Name = "txtCopyrightCH";
            this.txtCopyrightCH.ReadOnly = true;
            this.txtCopyrightCH.Size = new System.Drawing.Size(632, 15);
            this.txtCopyrightCH.TabIndex = 2;
            this.txtCopyrightCH.Text = "版权中文信息";
            // 
            // txtCopyrightEN
            // 
            this.txtCopyrightEN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyrightEN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCopyrightEN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCopyrightEN.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopyrightEN.Location = new System.Drawing.Point(7, 148);
            this.txtCopyrightEN.Name = "txtCopyrightEN";
            this.txtCopyrightEN.ReadOnly = true;
            this.txtCopyrightEN.Size = new System.Drawing.Size(632, 15);
            this.txtCopyrightEN.TabIndex = 3;
            this.txtCopyrightEN.Tag = "";
            this.txtCopyrightEN.Text = "版权英文信息";
            // 
            // txtCertText
            // 
            this.txtCertText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCertText.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCertText.Location = new System.Drawing.Point(7, 170);
            this.txtCertText.Name = "txtCertText";
            this.txtCertText.ReadOnly = true;
            this.txtCertText.Size = new System.Drawing.Size(632, 15);
            this.txtCertText.TabIndex = 4;
            this.txtCertText.Tag = "";
            this.txtCertText.Text = "授权许可";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "产品版本发布信息：";
            // 
            // txtVersionInfo
            // 
            this.txtVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersionInfo.BackColor = System.Drawing.Color.White;
            this.txtVersionInfo.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersionInfo.HideSelection = false;
            this.txtVersionInfo.Location = new System.Drawing.Point(7, 210);
            this.txtVersionInfo.Name = "txtVersionInfo";
            this.txtVersionInfo.ReadOnly = true;
            this.txtVersionInfo.Size = new System.Drawing.Size(634, 237);
            this.txtVersionInfo.TabIndex = 6;
            this.txtVersionInfo.Text = "";
            this.txtVersionInfo.WordWrap = false;
            this.txtVersionInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtVersionInfo_LinkClicked);
            // 
            // SystemAboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 453);
            this.Controls.Add(this.picSoftwareLogo);
            this.Controls.Add(this.txtSoftware);
            this.Controls.Add(this.txtCopyrightEN);
            this.Controls.Add(this.txtCopyrightCH);
            this.Controls.Add(this.txtCertText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVersionInfo);
            this.MinimizeBox = false;
            this.Name = "SystemAboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于病案质控系统";
            ((System.ComponentModel.ISupportInitialize)(this.picSoftwareLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSoftwareLogo;
        private System.Windows.Forms.TextBox txtSoftware;
        private System.Windows.Forms.TextBox txtCopyrightCH;
        private System.Windows.Forms.TextBox txtCopyrightEN;
        private System.Windows.Forms.TextBox txtCertText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtVersionInfo;
    }
}