namespace MedQCSys.Document
{
    internal partial class WinWordDocForm
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
            this.winWordCtrl1 = new MedDocSys.PadWrapper.WinWord.WinWordCtrl();
            this.SuspendLayout();
            // 
            // winWordCtrl1
            // 
            this.winWordCtrl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.winWordCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winWordCtrl1.Location = new System.Drawing.Point(0, 2);
            this.winWordCtrl1.Name = "winWordCtrl1";
            this.winWordCtrl1.Size = new System.Drawing.Size(771, 461);
            this.winWordCtrl1.TabIndex = 0;
            // 
            // WordDocumentForm
            // 
            this.ClientSize = new System.Drawing.Size(771, 463);
            this.Controls.Add(this.winWordCtrl1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "WordDocumentForm";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "²¡Àú´°¿Ú";
            this.ResumeLayout(false);

        }

        #endregion

        private MedDocSys.PadWrapper.WinWord.WinWordCtrl winWordCtrl1;

    }
}