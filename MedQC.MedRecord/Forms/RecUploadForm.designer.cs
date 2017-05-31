namespace Heren.MedQC.MedRecord
{
    partial class RecUploadForm
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
            this.editor = new Heren.Common.Forms.Editor.FormEditor();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(959, 695);
            this.editor.TabIndex = 13;
            this.editor.Text = "editor";
            this.editor.ExecuteUpdate += new Heren.Common.Forms.Editor.ExecuteUpdateEventHandler(this.editor_ExecuteUpdate);
            this.editor.CloseProgressMessage += new System.EventHandler(this.editor_CloseProgressMessage);
            this.editor.UpdateProgressMessage += new Heren.Common.Forms.Editor.UpdateProgressMessageEventHandler(this.editor_UpdateProgressMessage);
            this.editor.ShowProgressMessage += new Heren.Common.Forms.Editor.ShowProgressMessageEventHandler(this.editor_ShowProgressMessage);
            // 
            // RecUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(959, 695);
            this.Controls.Add(this.editor);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecUploadForm";
            this.Text = "病案上传";
            this.ResumeLayout(false);

        }

        #endregion
        private Heren.Common.Forms.Editor.FormEditor editor;
    }
}