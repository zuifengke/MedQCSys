namespace MedQCSys.DockForms
{
    partial class DocumentBugsForm
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
            if (this.m_bugCheckEngine != null)
                this.m_bugCheckEngine.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentBugsForm));
            this.listView1 = new Heren.Common.Controls.ListViewControl();
            this.colIcon = new System.Windows.Forms.ColumnHeader();
            this.colBugNo = new System.Windows.Forms.ColumnHeader();
            this.colBugLevel = new System.Windows.Forms.ColumnHeader();
            this.colDocTitle = new System.Windows.Forms.ColumnHeader();
            this.colBugDesc = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmenuDocBugs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyBugDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuDocBugs.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIcon,
            this.colBugNo,
            this.colBugLevel,
            this.colDocTitle,
            this.colBugDesc});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(757, 259);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.SortAllColumn = true;
            this.listView1.SortColumn = 0;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // colIcon
            // 
            this.colIcon.Text = "";
            this.colIcon.Width = 28;
            // 
            // colBugNo
            // 
            this.colBugNo.Text = "序号";
            this.colBugNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colBugNo.Width = 44;
            // 
            // colBugLevel
            // 
            this.colBugLevel.Text = "缺陷级别";
            this.colBugLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colBugLevel.Width = 72;
            // 
            // colDocTitle
            // 
            this.colDocTitle.Text = "病历主题";
            this.colDocTitle.Width = 240;
            // 
            // colBugDesc
            // 
            this.colBugDesc.Text = "缺陷说明";
            this.colBugDesc.Width = 400;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Warn.png");
            this.imageList1.Images.SetKeyName(1, "Error.png");
            // 
            // cmenuDocBugs
            // 
            this.cmenuDocBugs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyBugDesc});
            this.cmenuDocBugs.Name = "cmenuDocBugs";
            this.cmenuDocBugs.Size = new System.Drawing.Size(208, 26);
            // 
            // mnuCopyBugDesc
            // 
            this.mnuCopyBugDesc.Name = "mnuCopyBugDesc";
            this.mnuCopyBugDesc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopyBugDesc.Size = new System.Drawing.Size(207, 22);
            this.mnuCopyBugDesc.Text = "复制“缺陷说明”";
            this.mnuCopyBugDesc.Click += new System.EventHandler(this.mnuCopyBugDesc_Click);
            // 
            // DocumentBugsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(757, 261);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.Name = "DocumentBugsForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Text = "病历缺陷";
            this.cmenuDocBugs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Controls.ListViewControl listView1;
        private System.Windows.Forms.ColumnHeader colIcon;
        private System.Windows.Forms.ColumnHeader colBugNo;
        private System.Windows.Forms.ColumnHeader colBugLevel;
        private System.Windows.Forms.ColumnHeader colBugDesc;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader colDocTitle;
        private System.Windows.Forms.ContextMenuStrip cmenuDocBugs;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyBugDesc;

    }
}