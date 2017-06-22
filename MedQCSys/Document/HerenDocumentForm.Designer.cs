namespace MedQCSys.Document
{
    partial class HerenDocumentForm
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
            this.herenEditor1 = new Heren.MedQC.Frame.Document.HerenEditor();
            this.SuspendLayout();
            // 
            // herenEditor1
            // 
            this.herenEditor1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.herenEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.herenEditor1.Location = new System.Drawing.Point(0, 0);
            this.herenEditor1.Name = "herenEditor1";
            this.herenEditor1.Size = new System.Drawing.Size(814, 553);
            this.herenEditor1.TabIndex = 0;
            this.herenEditor1.Text = "herenEditor1";
            // 
            // HerenDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 553);
            this.Controls.Add(this.herenEditor1);
            this.Name = "HerenDocumentForm";
            this.Text = "和仁病历窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.MedQC.Frame.Document.HerenEditor herenEditor1;
    }
}