namespace MedQCSys.Document
{
    partial class EMRPadXDocForm
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EPRPad2Ctrl1 = new MedDocSys.PadWrapper.EPRPad2.EPRPad2Ctrl();
            this.EMRPad3Ctrl1 = new MedDocSys.PadWrapper.EMRPad3.EMRPad3Ctrl();
            this.SuspendLayout();
            // 
            // EPRPad2Ctrl1
            // 
            this.EPRPad2Ctrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EPRPad2Ctrl1.Location = new System.Drawing.Point(0, 2);
            this.EPRPad2Ctrl1.Name = "EPRPad2Ctrl1";
            this.EPRPad2Ctrl1.Size = new System.Drawing.Size(744, 500);
            this.EPRPad2Ctrl1.TabIndex = 0;
            // 
            // EMRPad3Ctrl1
            // 
            this.EMRPad3Ctrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EMRPad3Ctrl1.Location = new System.Drawing.Point(0, 2);
            this.EMRPad3Ctrl1.Name = "EMRPad3Ctrl1";
            this.EMRPad3Ctrl1.Size = new System.Drawing.Size(744, 500);
            this.EMRPad3Ctrl1.TabIndex = 0;
            // 
            // EMRPadXDocForm
            // 
            this.ClientSize = new System.Drawing.Size(771, 463);
            this.Controls.Add(this.EPRPad2Ctrl1);
            this.Controls.Add(this.EMRPad3Ctrl1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "EMRPadXDocForm";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "²¡Àú´°¿Ú";
            this.ResumeLayout(false);

        }

        #endregion

        private MedDocSys.PadWrapper.EPRPad2.EPRPad2Ctrl EPRPad2Ctrl1;
        private MedDocSys.PadWrapper.EMRPad3.EMRPad3Ctrl EMRPad3Ctrl1;
    }
}