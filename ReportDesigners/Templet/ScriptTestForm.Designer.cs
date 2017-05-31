namespace Designers.Templet
{
    partial class ScriptTestForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolbtnMakeText = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
            this.formEditor1 = new Heren.Common.Forms.Editor.FormEditor();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSave,
            this.toolbtnMakeText,
            this.toolStripSeparator1,
            this.toolbtnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(744, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.Image = global::Designers.Properties.Resources.SaveDoc;
            this.toolbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSave.Name = "toolbtnSave";
            this.toolbtnSave.Size = new System.Drawing.Size(64, 22);
            this.toolbtnSave.Text = "另存为";
            this.toolbtnSave.Click += new System.EventHandler(this.toolbtnSave_Click);
            // 
            // toolbtnMakeText
            // 
            this.toolbtnMakeText.Image = global::Designers.Properties.Resources.MakeText;
            this.toolbtnMakeText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnMakeText.Name = "toolbtnMakeText";
            this.toolbtnMakeText.Size = new System.Drawing.Size(76, 22);
            this.toolbtnMakeText.Text = "编译文本";
            this.toolbtnMakeText.Click += new System.EventHandler(this.toolbtnMakeText_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnClose
            // 
            this.toolbtnClose.Image = global::Designers.Properties.Resources.Exit;
            this.toolbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnClose.Name = "toolbtnClose";
            this.toolbtnClose.Size = new System.Drawing.Size(52, 22);
            this.toolbtnClose.Text = "关闭";
            this.toolbtnClose.Click += new System.EventHandler(this.toolbtnClose_Click);
            // 
            // formEditor1
            // 
            this.formEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formEditor1.Location = new System.Drawing.Point(0, 25);
            this.formEditor1.Name = "formEditor1";
            this.formEditor1.Size = new System.Drawing.Size(744, 460);
            this.formEditor1.TabIndex = 3;
            this.formEditor1.ExecuteQuery += new Heren.Common.Forms.Editor.ExecuteQueryEventHandler(this.formEditor1_ExecuteQuery);
            this.formEditor1.ExecuteUpdate += new Heren.Common.Forms.Editor.ExecuteUpdateEventHandler(this.formEditor1_ExecuteUpdate);
            // 
            // ScriptTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 485);
            this.Controls.Add(this.formEditor1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MinimizeBox = false;
            this.Name = "ScriptTestForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模板测试";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnMakeText;
        private System.Windows.Forms.ToolStripButton toolbtnClose;
        private Heren.Common.Forms.Editor.FormEditor formEditor1;
    }
}