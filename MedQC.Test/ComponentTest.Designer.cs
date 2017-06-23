namespace MedQC.Test
{
    partial class ComponentTest
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
            this.cardPanel1 = new MedQC.Test.CardPanel();
            this.SuspendLayout();
            // 
            // cardPanel1
            // 
            this.cardPanel1.Location = new System.Drawing.Point(28, 27);
            this.cardPanel1.Name = "cardPanel1";
            this.cardPanel1.Size = new System.Drawing.Size(414, 294);
            this.cardPanel1.TabIndex = 2;
            this.cardPanel1.Text = "dddd";
            this.cardPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.cardPanel1.TitleText = "";
            // 
            // ComponentTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 348);
            this.Controls.Add(this.cardPanel1);
            this.Name = "ComponentTest";
            this.Text = "ComponentTest";
            this.ResumeLayout(false);

        }

        #endregion

        private CardPanel cardPanel1;
    }
}