namespace Designers
{
    partial class DesignForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.打开报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.报表列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.打开表单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建表单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new Heren.Common.DockSuite.DockPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblSystemStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.表单管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(845, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开报表ToolStripMenuItem,
            this.新建报表ToolStripMenuItem,
            this.报表列表ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripDropDownButton1.Text = "报表设计";
            // 
            // 打开报表ToolStripMenuItem
            // 
            this.打开报表ToolStripMenuItem.Image = global::Designers.Properties.Resources.OpenDoc;
            this.打开报表ToolStripMenuItem.Name = "打开报表ToolStripMenuItem";
            this.打开报表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开报表ToolStripMenuItem.Text = "打开报表";
            this.打开报表ToolStripMenuItem.Click += new System.EventHandler(this.打开报表ToolStripMenuItem_Click);
            // 
            // 新建报表ToolStripMenuItem
            // 
            this.新建报表ToolStripMenuItem.Image = global::Designers.Properties.Resources.Templet;
            this.新建报表ToolStripMenuItem.Name = "新建报表ToolStripMenuItem";
            this.新建报表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建报表ToolStripMenuItem.Text = "新建报表";
            this.新建报表ToolStripMenuItem.Click += new System.EventHandler(this.新建报表ToolStripMenuItem_Click);
            // 
            // 报表列表ToolStripMenuItem
            // 
            this.报表列表ToolStripMenuItem.Name = "报表列表ToolStripMenuItem";
            this.报表列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.报表列表ToolStripMenuItem.Text = "报表管理";
            this.报表列表ToolStripMenuItem.Click += new System.EventHandler(this.报表列表ToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开表单ToolStripMenuItem,
            this.新建表单ToolStripMenuItem,
            this.表单管理ToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::Designers.Properties.Resources.Templet;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(69, 22);
            this.toolStripDropDownButton2.Text = "表单设计";
            // 
            // 打开表单ToolStripMenuItem
            // 
            this.打开表单ToolStripMenuItem.Image = global::Designers.Properties.Resources.OpenDoc;
            this.打开表单ToolStripMenuItem.Name = "打开表单ToolStripMenuItem";
            this.打开表单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开表单ToolStripMenuItem.Text = "打开表单";
            this.打开表单ToolStripMenuItem.Click += new System.EventHandler(this.打开表单ToolStripMenuItem_Click);
            // 
            // 新建表单ToolStripMenuItem
            // 
            this.新建表单ToolStripMenuItem.Image = global::Designers.Properties.Resources.Templet;
            this.新建表单ToolStripMenuItem.Name = "新建表单ToolStripMenuItem";
            this.新建表单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新建表单ToolStripMenuItem.Text = "新建表单";
            this.新建表单ToolStripMenuItem.Click += new System.EventHandler(this.新建表单ToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.dockPanel1.DockBackColor = System.Drawing.Color.Gray;
            this.dockPanel1.DocumentStyle = Heren.Common.DockSuite.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 22);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.ShowDocumentSubhead = true;
            this.dockPanel1.Size = new System.Drawing.Size(845, 462);
            this.dockPanel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblSystemStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(845, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblSystemStatus
            // 
            this.tsslblSystemStatus.Name = "tsslblSystemStatus";
            this.tsslblSystemStatus.Size = new System.Drawing.Size(830, 17);
            this.tsslblSystemStatus.Spring = true;
            this.tsslblSystemStatus.Text = "就绪";
            this.tsslblSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 表单管理ToolStripMenuItem
            // 
            this.表单管理ToolStripMenuItem.Name = "表单管理ToolStripMenuItem";
            this.表单管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.表单管理ToolStripMenuItem.Text = "表单管理";
            this.表单管理ToolStripMenuItem.Click += new System.EventHandler(this.表单管理ToolStripMenuItem_Click);
            // 
            // DesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 503);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DesignForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设计器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Heren.Common.DockSuite.DockPanel dockPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblSystemStatus;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 打开报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem 打开表单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建表单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报表列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表单管理ToolStripMenuItem;
    }
}

