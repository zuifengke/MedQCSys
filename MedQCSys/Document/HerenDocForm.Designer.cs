namespace MedQCSys.Document
{
    partial class HerenDocForm
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
            this.components = new System.ComponentModel.Container();
            this.textEditor1 = new Heren.Common.RichEditor.TextEditor();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // textEditor1
            // 
            this.textEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditor1.Location = new System.Drawing.Point(0, 2);
            this.textEditor1.Name = "textEditor1";
            this.textEditor1.Size = new System.Drawing.Size(744, 500);
            this.textEditor1.TabIndex = 0;
            this.textEditor1.TextBackColor = System.Drawing.Color.Transparent;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // HerenDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 502);
            this.ContextMenuStrip = this.PopupMenu;
            this.Controls.Add(this.textEditor1);
            this.Name = "HerenDocForm";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "²¡ÀúÎÄµµ";
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.RichEditor.TextEditor textEditor1;
        private System.Windows.Forms.ContextMenuStrip PopupMenu;

    }
}