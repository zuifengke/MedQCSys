namespace Heren.MedQC.Maintenance
{
    partial class StandardTermForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandardTermForm));
            this.label2 = new System.Windows.Forms.Label();
            this.txtFuzzyFind = new Heren.Common.Controls.TextBoxButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cmenuICD10Tree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyItemName = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtPinyinFind = new Heren.Common.Controls.TextBoxButton();
            this.btnCloseFind = new Heren.Common.Controls.FlatButton();
            this.cmenuICD10Tree.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "模糊筛选";
            // 
            // txtFuzzyFind
            // 
            this.txtFuzzyFind.BackColor = System.Drawing.Color.White;
            this.txtFuzzyFind.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.txtFuzzyFind.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.txtFuzzyFind.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtFuzzyFind.Location = new System.Drawing.Point(68, 7);
            this.txtFuzzyFind.MaxLength = 32767;
            this.txtFuzzyFind.Name = "txtFuzzyFind";
            this.txtFuzzyFind.SelectionLength = 0;
            this.txtFuzzyFind.SelectionStart = 0;
            this.txtFuzzyFind.Size = new System.Drawing.Size(150, 23);
            this.txtFuzzyFind.TabIndex = 0;
            this.txtFuzzyFind.ButtonClick += new System.EventHandler(this.txtFuzzyFind_ButtonClick);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.cmenuICD10Tree;
            this.treeView1.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 37);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(473, 486);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // cmenuICD10Tree
            // 
            this.cmenuICD10Tree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyItemName});
            this.cmenuICD10Tree.Name = "cmenuICD10Tree";
            this.cmenuICD10Tree.Size = new System.Drawing.Size(196, 26);
            this.cmenuICD10Tree.Opening += new System.ComponentModel.CancelEventHandler(this.cmenuICD10Tree_Opening);
            // 
            // mnuCopyItemName
            // 
            this.mnuCopyItemName.Name = "mnuCopyItemName";
            this.mnuCopyItemName.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopyItemName.Size = new System.Drawing.Size(195, 22);
            this.mnuCopyItemName.Text = "复制选中项名称";
            this.mnuCopyItemName.Click += new System.EventHandler(this.mnuCopyItemName_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BookClose.png");
            this.imageList1.Images.SetKeyName(1, "BookOpen.png");
            this.imageList1.Images.SetKeyName(2, "ICDItem.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.label1.Location = new System.Drawing.Point(230, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "简拼筛选";
            // 
            // txtPinyinFind
            // 
            this.txtPinyinFind.BackColor = System.Drawing.Color.White;
            this.txtPinyinFind.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.txtPinyinFind.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.txtPinyinFind.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtPinyinFind.Location = new System.Drawing.Point(295, 7);
            this.txtPinyinFind.MaxLength = 32767;
            this.txtPinyinFind.Name = "txtPinyinFind";
            this.txtPinyinFind.SelectionLength = 0;
            this.txtPinyinFind.SelectionStart = 0;
            this.txtPinyinFind.Size = new System.Drawing.Size(150, 23);
            this.txtPinyinFind.TabIndex = 1;
            this.txtPinyinFind.ButtonClick += new System.EventHandler(this.txtPinyinFind_ButtonClick);
            this.txtPinyinFind.TextChanged += new System.EventHandler(this.txtPinyinFind_TextChanged);
            // 
            // btnCloseFind
            // 
            this.btnCloseFind.Location = new System.Drawing.Point(453, 9);
            this.btnCloseFind.Name = "btnCloseFind";
            this.btnCloseFind.Size = new System.Drawing.Size(20, 20);
            this.btnCloseFind.TabIndex = 19;
            this.btnCloseFind.ToolTipText = "取消筛选,显示所有";
            this.btnCloseFind.Click += new System.EventHandler(this.btnCloseFind_Click);
            // 
            // StandardTermForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 526);
            this.Controls.Add(this.btnCloseFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPinyinFind);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFuzzyFind);
            this.Name = "StandardTermForm";
            this.Text = "ICD10标准诊断库";
            this.cmenuICD10Tree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Heren.Common.Controls.TextBoxButton txtFuzzyFind;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmenuICD10Tree;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyItemName;
        private System.Windows.Forms.Label label1;
        private Heren.Common.Controls.TextBoxButton txtPinyinFind;
        private Heren.Common.Controls.FlatButton btnCloseFind;
    }
}