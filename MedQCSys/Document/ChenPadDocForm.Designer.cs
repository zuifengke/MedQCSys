namespace MedQCSys.Document
{
    partial class ChenPadDocForm
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
            this.medEditor1 = new MedDocSys.PadWrapper.ChenPad.ChenPadCtrl();
            this.SuspendLayout();
            // 
            // medEditor1
            // 
            this.medEditor1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.medEditor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.medEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medEditor1.ElementTagColor = System.Drawing.Color.Empty;
            this.medEditor1.Location = new System.Drawing.Point(0, 2);
            this.medEditor1.Name = "medEditor1";
            this.medEditor1.Readonly = true;
            this.medEditor1.ShowInternalMenuStrip = false;
            this.medEditor1.ShowInternalPopupMenu = false;
            this.medEditor1.ShowInternalToolStrip = false;
            this.medEditor1.Size = new System.Drawing.Size(744, 500);
            this.medEditor1.TabIndex = 0;
            // 
            // ChenPadDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 502);
            this.Controls.Add(this.medEditor1);
            this.Name = "ChenPadDocForm";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "²¡ÀúÎÄµµ";
            this.ResumeLayout(false);

        }

        #endregion

        private MedDocSys.PadWrapper.ChenPad.ChenPadCtrl medEditor1;
    }
}