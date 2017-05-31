namespace MedQCSys.Dialogs
{
    partial class IcdQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IcdQueryForm));
            this.txtPinyinFind = new Heren.Common.Controls.TextBoxButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbFuzzyFind = new System.Windows.Forms.RadioButton();
            this.txtFuzzyFind = new Heren.Common.Controls.TextBoxButton();
            this.rtbPinyinFind = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmenuICD10Tree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsertSelectedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new Heren.Common.Controls.TreeViewControl();
            this.groupBox1.SuspendLayout();
            this.cmenuICD10Tree.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPinyinFind
            // 
            this.txtPinyinFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPinyinFind.BackColor = System.Drawing.Color.White;
            this.txtPinyinFind.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.txtPinyinFind.ButtonImage = ((System.Drawing.Image)(resources.GetObject("txtPinyinFind.ButtonImage")));
            this.txtPinyinFind.ButtonToolTip = null;
            this.txtPinyinFind.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPinyinFind.Location = new System.Drawing.Point(92, 49);
            this.txtPinyinFind.MaxLength = 32767;
            this.txtPinyinFind.Name = "txtPinyinFind";
            this.txtPinyinFind.ReadOnly = false;
            this.txtPinyinFind.SelectionLength = 0;
            this.txtPinyinFind.SelectionStart = 0;
            this.txtPinyinFind.Size = new System.Drawing.Size(224, 21);
            this.txtPinyinFind.TabIndex = 3;
            this.txtPinyinFind.TextChanged += new System.EventHandler(this.txtPinyinFind_TextChanged);
            this.txtPinyinFind.ButtonClick += new System.EventHandler(this.txtPinyinFind_ButtonClick);
            this.txtPinyinFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPinyinFind_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtbFuzzyFind);
            this.groupBox1.Controls.Add(this.txtFuzzyFind);
            this.groupBox1.Controls.Add(this.rtbPinyinFind);
            this.groupBox1.Controls.Add(this.txtPinyinFind);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(8, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "双击列表中的诊断可插入到病历";
            // 
            // rtbFuzzyFind
            // 
            this.rtbFuzzyFind.AutoSize = true;
            this.rtbFuzzyFind.Location = new System.Drawing.Point(15, 23);
            this.rtbFuzzyFind.Name = "rtbFuzzyFind";
            this.rtbFuzzyFind.Size = new System.Drawing.Size(71, 16);
            this.rtbFuzzyFind.TabIndex = 0;
            this.rtbFuzzyFind.TabStop = true;
            this.rtbFuzzyFind.Text = "模糊筛选";
            this.rtbFuzzyFind.UseVisualStyleBackColor = true;
            this.rtbFuzzyFind.CheckedChanged += new System.EventHandler(this.FindRadioButton_CheckedChanged);
            // 
            // txtFuzzyFind
            // 
            this.txtFuzzyFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFuzzyFind.BackColor = System.Drawing.Color.White;
            this.txtFuzzyFind.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.txtFuzzyFind.ButtonImage = ((System.Drawing.Image)(resources.GetObject("txtFuzzyFind.ButtonImage")));
            this.txtFuzzyFind.ButtonToolTip = null;
            this.txtFuzzyFind.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtFuzzyFind.Location = new System.Drawing.Point(92, 20);
            this.txtFuzzyFind.MaxLength = 20;
            this.txtFuzzyFind.Name = "txtFuzzyFind";
            this.txtFuzzyFind.ReadOnly = false;
            this.txtFuzzyFind.SelectionLength = 0;
            this.txtFuzzyFind.SelectionStart = 0;
            this.txtFuzzyFind.Size = new System.Drawing.Size(224, 21);
            this.txtFuzzyFind.TabIndex = 1;
            this.txtFuzzyFind.TextChanged += new System.EventHandler(this.txtFuzzyFind_TextChanged);
            this.txtFuzzyFind.ButtonClick += new System.EventHandler(this.txtFuzzyFind_ButtonClick);
            // 
            // rtbPinyinFind
            // 
            this.rtbPinyinFind.AutoSize = true;
            this.rtbPinyinFind.Location = new System.Drawing.Point(15, 52);
            this.rtbPinyinFind.Name = "rtbPinyinFind";
            this.rtbPinyinFind.Size = new System.Drawing.Size(71, 16);
            this.rtbPinyinFind.TabIndex = 2;
            this.rtbPinyinFind.TabStop = true;
            this.rtbPinyinFind.Text = "简拼筛选";
            this.rtbPinyinFind.UseVisualStyleBackColor = true;
            this.rtbPinyinFind.CheckedChanged += new System.EventHandler(this.FindRadioButton_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BookClose.png");
            this.imageList1.Images.SetKeyName(1, "BookOpen.png");
            this.imageList1.Images.SetKeyName(2, "ICD.png");
            // 
            // cmenuICD10Tree
            // 
            this.cmenuICD10Tree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsertSelectedItem});
            this.cmenuICD10Tree.Name = "cmenuICD10Tree";
            this.cmenuICD10Tree.Size = new System.Drawing.Size(137, 26);
            // 
            // mnuInsertSelectedItem
            // 
            this.mnuInsertSelectedItem.Name = "mnuInsertSelectedItem";
            this.mnuInsertSelectedItem.Size = new System.Drawing.Size(136, 22);
            this.mnuInsertSelectedItem.Text = "插入选中项";
            this.mnuInsertSelectedItem.Click += new System.EventHandler(this.mnuInsertSelectedItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Location = new System.Drawing.Point(0, 116);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(332, 429);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            // 
            // IcdQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 544);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "IcdQueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ICD诊断查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmenuICD10Tree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Controls.TreeViewControl treeView1;
        private Heren.Common.Controls.TextBoxButton txtPinyinFind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rtbFuzzyFind;
        private Heren.Common.Controls.TextBoxButton txtFuzzyFind;
        private System.Windows.Forms.RadioButton rtbPinyinFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmenuICD10Tree;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertSelectedItem;
    }
}