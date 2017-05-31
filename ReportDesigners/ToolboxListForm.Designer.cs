namespace Designers
{
    partial class ToolboxListForm
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
            this.toolbox1 = new Heren.Common.Forms.Toolbox();
            this.SuspendLayout();
            // 
            // toolbox1
            // 
            this.toolbox1.AutoSize = false;
            this.toolbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolbox1.DesignerHost = null;
            this.toolbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbox1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbox1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolbox1.Location = new System.Drawing.Point(6, 1);
            this.toolbox1.Name = "toolbox1";
            this.toolbox1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolbox1.SelectedCategory = null;
            this.toolbox1.Size = new System.Drawing.Size(266, 490);
            this.toolbox1.TabIndex = 0;
            this.toolbox1.Text = "toolbox1";
            // 
            // ToolboxListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(272, 491);
            this.Controls.Add(this.toolbox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ToolboxListForm";
            this.Padding = new System.Windows.Forms.Padding(6, 1, 0, 0);
            this.Text = "工具窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Forms.Toolbox toolbox1;
    }
}