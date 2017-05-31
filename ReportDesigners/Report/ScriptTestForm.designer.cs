namespace Designers.Report
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnClose = new System.Windows.Forms.ToolStripButton();
            this.reportDesigner1 = new Heren.Common.Report.ReportDesigner();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSave,
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
            this.toolbtnSave.Size = new System.Drawing.Size(61, 22);
            this.toolbtnSave.Text = "另存为";
            this.toolbtnSave.Click += new System.EventHandler(this.toolbtnSave_Click);
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
            this.toolbtnClose.Size = new System.Drawing.Size(49, 22);
            this.toolbtnClose.Text = "关闭";
            this.toolbtnClose.Click += new System.EventHandler(this.toolbtnClose_Click);
            // 
            // reportDesigner1
            // 
            this.reportDesigner1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.reportDesigner1.AutoScrollMinSize = new System.Drawing.Size(818, 1147);
            this.reportDesigner1.CanvasCenter = true;
            this.reportDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportDesigner1.Location = new System.Drawing.Point(0, 25);
            this.reportDesigner1.Name = "reportDesigner1";
            this.reportDesigner1.Size = new System.Drawing.Size(744, 460);
            this.reportDesigner1.TabIndex = 3;
            this.reportDesigner1.ExecuteUpdate += new Heren.Common.Report.ExecuteUpdateEventHandler(this.reportDesigner1_ExecuteUpdate);
            this.reportDesigner1.ExecuteQuery += new Heren.Common.Report.ExecuteQueryEventHandler(this.reportDesigner1_ExecuteQuery);
            // 
            // ScriptTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 485);
            this.Controls.Add(this.reportDesigner1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
        private System.Windows.Forms.ToolStripButton toolbtnClose;
        private Heren.Common.Report.ReportDesigner reportDesigner1;
    }
}