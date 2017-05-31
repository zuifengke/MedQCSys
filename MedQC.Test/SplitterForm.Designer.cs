namespace MedQC.Test
{
    partial class SplitterForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.xSplitter1 = new Heren.Common.Forms.XSplitter();
            this.xSplitter2 = new Heren.Common.Forms.XSplitter();
            this.xPanel1 = new Heren.Common.Forms.XPanel();
            this.xButton1 = new Heren.Common.Forms.XButton();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 395);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(565, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 395);
            this.panel2.TabIndex = 1;
            // 
            // xSplitter1
            // 
            this.xSplitter1.Location = new System.Drawing.Point(178, 0);
            this.xSplitter1.Name = "xSplitter1";
            this.xSplitter1.Size = new System.Drawing.Size(12, 395);
            this.xSplitter1.TabIndex = 2;
            this.xSplitter1.TabStop = false;
            // 
            // xSplitter2
            // 
            this.xSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.xSplitter2.Location = new System.Drawing.Point(553, 0);
            this.xSplitter2.Name = "xSplitter2";
            this.xSplitter2.Size = new System.Drawing.Size(12, 395);
            this.xSplitter2.TabIndex = 3;
            this.xSplitter2.TabStop = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xButton1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(190, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(363, 395);
            this.xPanel1.TabIndex = 4;
            // 
            // xButton1
            // 
            this.xButton1.Location = new System.Drawing.Point(107, 76);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(75, 23);
            this.xButton1.TabIndex = 0;
            this.xButton1.Text = "xButton1";
            this.xButton1.UseVisualStyleBackColor = true;
            // 
            // SplitterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 395);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xSplitter2);
            this.Controls.Add(this.xSplitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SplitterForm";
            this.Text = "SplitterForm";
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Heren.Common.Forms.XSplitter xSplitter1;
        private Heren.Common.Forms.XSplitter xSplitter2;
        private Heren.Common.Forms.XPanel xPanel1;
        private Heren.Common.Forms.XButton xButton1;
    }
}