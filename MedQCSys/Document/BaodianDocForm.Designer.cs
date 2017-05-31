namespace MedQCSys.Document
{
    partial class BaodianDocForm
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
            this.medEditor1 = new MedDocSys.PadWrapper.Baodian.BaodianCtrl();
            this.SuspendLayout();
            // 
            // medEditor1
            // 
            this.medEditor1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.medEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medEditor1.ElementTagColor = System.Drawing.Color.Fuchsia;
            this.medEditor1.Location = new System.Drawing.Point(0, 2);
            this.medEditor1.Name = "medEditor1";
            this.medEditor1.Size = new System.Drawing.Size(744, 500);
            this.medEditor1.TabIndex = 0;
            // 
            // BaodianDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(744, 502);
            this.Controls.Add(this.medEditor1);
            this.Name = "BaodianDocForm";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "²¡ÀúÎÄµµ";
            this.ResumeLayout(false);

        }

        #endregion

        private MedDocSys.PadWrapper.Baodian.BaodianCtrl medEditor1;


    }
}