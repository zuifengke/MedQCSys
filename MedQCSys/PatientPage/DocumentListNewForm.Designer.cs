namespace MedQCSys.DockForms
{
    partial class DocumentListNewForm
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddFeedInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dockPanel1 = new Heren.Common.DockSuite.DockPanel();
            this.arrowSplitter1 = new Heren.Common.Controls.ArrowSplitter();
            this.virtualTree1 = new Heren.Common.Controls.VirtualTreeView.VirtualTree();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddFeedInfo});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuAddFeedInfo
            // 
            this.mnuAddFeedInfo.Name = "mnuAddFeedInfo";
            this.mnuAddFeedInfo.Size = new System.Drawing.Size(148, 22);
            this.mnuAddFeedInfo.Text = "新增质检问题";
            this.mnuAddFeedInfo.Click += new System.EventHandler(this.mnuAddFeedInfo_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dockPanel1);
            this.panel1.Controls.Add(this.arrowSplitter1);
            this.panel1.Controls.Add(this.virtualTree1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 548);
            this.panel1.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.ControlDark;
            this.dockPanel1.DocumentStyle = Heren.Common.DockSuite.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(201, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(651, 544);
            this.dockPanel1.TabIndex = 4;
            this.dockPanel1.ContentRemoved += new System.EventHandler<Heren.Common.DockSuite.DockContentEventArgs>(this.dockPanel1_ContentRemoved);
            // 
            // arrowSplitter1
            // 
            this.arrowSplitter1.Location = new System.Drawing.Point(189, 0);
            this.arrowSplitter1.Name = "arrowSplitter1";
            this.arrowSplitter1.Size = new System.Drawing.Size(12, 544);
            this.arrowSplitter1.TabIndex = 3;
            this.arrowSplitter1.TabStop = false;
            // 
            // virtualTree1
            // 
            this.virtualTree1.AutoScrollMinSize = new System.Drawing.Size(189, 24);
            this.virtualTree1.ContextMenuStrip = this.contextMenuStrip1;
            this.virtualTree1.Dock = System.Windows.Forms.DockStyle.Left;
            this.virtualTree1.Location = new System.Drawing.Point(0, 0);
            this.virtualTree1.Name = "virtualTree1";
            this.virtualTree1.ShowToolTip = false;
            this.virtualTree1.Size = new System.Drawing.Size(189, 544);
            this.virtualTree1.TabIndex = 2;
            this.virtualTree1.Text = "virtualTree2";
            this.virtualTree1.NodeMouseClick += new Heren.Common.Controls.VirtualTreeView.VirtualTreeEventHandler(this.virtualTree1_NodeMouseClick);
            this.virtualTree1.NodeMouseDoubleClick += new Heren.Common.Controls.VirtualTreeView.VirtualTreeEventHandler(this.virtualTree1_NodeMouseDoubleClick);
            // 
            // DocumentListNewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(864, 556);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "DocumentListNewForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "病历文书";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Heren.Common.Controls.VirtualTreeView.VirtualTree virtualTree1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddFeedInfo;
        private Heren.Common.DockSuite.DockPanel dockPanel1;
        private Heren.Common.Controls.ArrowSplitter arrowSplitter1;
    }
}