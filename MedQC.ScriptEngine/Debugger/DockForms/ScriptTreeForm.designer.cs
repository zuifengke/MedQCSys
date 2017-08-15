namespace Heren.MedQC.ScriptEngine.DockForms
{
    partial class ScriptTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptTreeForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolbtnImport = new System.Windows.Forms.ToolStripButton();
            this.toolbtnExport = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new Heren.Common.Controls.TreeViewControl();
            this.cmenuTempletTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewTemplet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTempletProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.cmenuTempletTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnOpen,
            this.toolbtnImport,
            this.toolbtnExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(281, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnOpen
            // 
            this.toolbtnOpen.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.OpenDoc;
            this.toolbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnOpen.Name = "toolbtnOpen";
            this.toolbtnOpen.Size = new System.Drawing.Size(52, 22);
            this.toolbtnOpen.Text = "打开";
            this.toolbtnOpen.Click += new System.EventHandler(this.toolbtnOpen_Click);
            // 
            // toolbtnImport
            // 
            this.toolbtnImport.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Import;
            this.toolbtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnImport.Name = "toolbtnImport";
            this.toolbtnImport.Size = new System.Drawing.Size(52, 22);
            this.toolbtnImport.Text = "导入";
            this.toolbtnImport.Visible = false;
            this.toolbtnImport.Click += new System.EventHandler(this.toolbtnImport_Click);
            // 
            // toolbtnExport
            // 
            this.toolbtnExport.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Export;
            this.toolbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExport.Name = "toolbtnExport";
            this.toolbtnExport.Size = new System.Drawing.Size(52, 22);
            this.toolbtnExport.Text = "导出";
            this.toolbtnExport.Click += new System.EventHandler(this.toolbtnExport_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.ContextMenuStrip = this.cmenuTempletTree;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(281, 470);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // cmenuTempletTree
            // 
            this.cmenuTempletTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewFolder,
            this.mnuNewTemplet,
            this.mnuTempletProperty,
            this.toolStripSeparator1,
            this.mnuDelete});
            this.cmenuTempletTree.Name = "contextMenuStrip1";
            this.cmenuTempletTree.Size = new System.Drawing.Size(137, 98);
            // 
            // mnuNewFolder
            // 
            this.mnuNewFolder.Name = "mnuNewFolder";
            this.mnuNewFolder.Size = new System.Drawing.Size(136, 22);
            this.mnuNewFolder.Text = "新建目录";
            this.mnuNewFolder.Click += new System.EventHandler(this.mnuNewFolder_Click);
            // 
            // mnuNewTemplet
            // 
            this.mnuNewTemplet.Name = "mnuNewTemplet";
            this.mnuNewTemplet.Size = new System.Drawing.Size(152, 22);
            this.mnuNewTemplet.Text = "新建脚本";
            this.mnuNewTemplet.Click += new System.EventHandler(this.mnuNewTemplet_Click);
            // 
            // mnuTempletProperty
            // 
            this.mnuTempletProperty.Name = "mnuTempletProperty";
            this.mnuTempletProperty.Size = new System.Drawing.Size(152, 22);
            this.mnuTempletProperty.Text = "脚本属性";
            this.mnuTempletProperty.Click += new System.EventHandler(this.mnuTempletProperty_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(136, 22);
            this.mnuDelete.Text = "删除选中项";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FolderClose.png");
            this.imageList1.Images.SetKeyName(1, "FolderOpen.png");
            this.imageList1.Images.SetKeyName(2, "Templet.png");
            // 
            // ScriptTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(281, 495);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ScriptTreeForm";
            this.Text = "脚本列表";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmenuTempletTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnOpen;
        private Heren.Common.Controls.TreeViewControl treeView1;
        private System.Windows.Forms.ContextMenuStrip cmenuTempletTree;
        private System.Windows.Forms.ToolStripMenuItem mnuNewFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuNewTemplet;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuTempletProperty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnImport;
        private System.Windows.Forms.ToolStripButton toolbtnExport;
    }
}