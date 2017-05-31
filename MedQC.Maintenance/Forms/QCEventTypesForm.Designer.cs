namespace Heren.MedQC.Maintenance
{
    partial class QCEventTypesForm
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
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.colSerialNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInputCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSecNew = new System.Windows.Forms.ToolStripButton();
            this.toolbtnModify = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddItem,
            this.mnuModifyItem,
            this.mnuDeleteItem,
            this.mnuSaveItems});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 92);
            // 
            // mnuAddItem
            // 
            this.mnuAddItem.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Add;
            this.mnuAddItem.Name = "mnuAddItem";
            this.mnuAddItem.Size = new System.Drawing.Size(100, 22);
            this.mnuAddItem.Text = "新增";
            this.mnuAddItem.Click += new System.EventHandler(this.mnuAddItem_Click);
            // 
            // mnuModifyItem
            // 
            this.mnuModifyItem.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Update;
            this.mnuModifyItem.Name = "mnuModifyItem";
            this.mnuModifyItem.Size = new System.Drawing.Size(100, 22);
            this.mnuModifyItem.Text = "修改";
            this.mnuModifyItem.Click += new System.EventHandler(this.mnuModifyItem_Click);
            // 
            // mnuDeleteItem
            // 
            this.mnuDeleteItem.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Delete;
            this.mnuDeleteItem.Name = "mnuDeleteItem";
            this.mnuDeleteItem.Size = new System.Drawing.Size(100, 22);
            this.mnuDeleteItem.Text = "删除";
            this.mnuDeleteItem.Click += new System.EventHandler(this.mnuDeleteItem_Click);
            // 
            // mnuSaveItems
            // 
            this.mnuSaveItems.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Save;
            this.mnuSaveItems.Name = "mnuSaveItems";
            this.mnuSaveItems.Size = new System.Drawing.Size(100, 22);
            this.mnuSaveItems.Text = "保存";
            this.mnuSaveItems.Click += new System.EventHandler(this.mnuSaveItems_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerialNO,
            this.colTypeDesc,
            this.colInputCode,
            this.colMaxScore});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 231);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // colSerialNO
            // 
            this.colSerialNO.HeaderText = "序号";
            this.colSerialNO.MaxInputLength = 4;
            this.colSerialNO.Name = "colSerialNO";
            this.colSerialNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSerialNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTypeDesc
            // 
            this.colTypeDesc.FillWeight = 250F;
            this.colTypeDesc.HeaderText = "问题类型";
            this.colTypeDesc.MaxInputLength = 8;
            this.colTypeDesc.Name = "colTypeDesc";
            this.colTypeDesc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTypeDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTypeDesc.Width = 250;
            // 
            // colInputCode
            // 
            this.colInputCode.FillWeight = 150F;
            this.colInputCode.HeaderText = "输入码";
            this.colInputCode.MaxInputLength = 8;
            this.colInputCode.Name = "colInputCode";
            this.colInputCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInputCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInputCode.Width = 150;
            // 
            // colMaxScore
            // 
            this.colMaxScore.HeaderText = "扣分上限";
            this.colMaxScore.Name = "colMaxScore";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnNew,
            this.toolBtnSecNew,
            this.toolbtnModify,
            this.toolbtnDelete,
            this.toolbtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 236);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(583, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnNew
            // 
            this.toolbtnNew.AutoSize = false;
            this.toolbtnNew.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Add;
            this.toolbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNew.Name = "toolbtnNew";
            this.toolbtnNew.Size = new System.Drawing.Size(84, 26);
            this.toolbtnNew.Text = "新增";
            this.toolbtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnNew.ToolTipText = "新增";
            this.toolbtnNew.Click += new System.EventHandler(this.toolbtnNew_Click);
            // 
            // toolBtnSecNew
            // 
            this.toolBtnSecNew.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Add;
            this.toolBtnSecNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSecNew.Name = "toolBtnSecNew";
            this.toolBtnSecNew.Size = new System.Drawing.Size(83, 27);
            this.toolBtnSecNew.Text = "新增子类";
            this.toolBtnSecNew.Click += new System.EventHandler(this.toolBtnSecNew_Click);
            // 
            // toolbtnModify
            // 
            this.toolbtnModify.AutoSize = false;
            this.toolbtnModify.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Update;
            this.toolbtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnModify.Name = "toolbtnModify";
            this.toolbtnModify.Size = new System.Drawing.Size(84, 26);
            this.toolbtnModify.Text = "修改";
            this.toolbtnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnModify.ToolTipText = "修改";
            this.toolbtnModify.Click += new System.EventHandler(this.toolbtnModify_Click);
            // 
            // toolbtnDelete
            // 
            this.toolbtnDelete.AutoSize = false;
            this.toolbtnDelete.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Delete;
            this.toolbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDelete.Name = "toolbtnDelete";
            this.toolbtnDelete.Size = new System.Drawing.Size(84, 26);
            this.toolbtnDelete.Text = "删除";
            this.toolbtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnDelete.ToolTipText = "删除";
            this.toolbtnDelete.Click += new System.EventHandler(this.toolbtnDelete_Click);
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.AutoSize = false;
            this.toolbtnSave.Image = global::Heren.MedQC.Maintenance.Properties.Resources.Save;
            this.toolbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSave.Name = "toolbtnSave";
            this.toolbtnSave.Size = new System.Drawing.Size(84, 26);
            this.toolbtnSave.Text = "保存";
            this.toolbtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnSave.ToolTipText = "保存";
            this.toolbtnSave.Click += new System.EventHandler(this.toolbtnSave_Click);
            // 
            // QCEventTypesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(583, 266);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "QCEventTypesForm";
            this.Text = "病案质量问题分类字典维护";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnNew;
        private System.Windows.Forms.ToolStripButton toolbtnModify;
        private System.Windows.Forms.ToolStripButton toolbtnDelete;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInputCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxScore;
        private System.Windows.Forms.ToolStripButton toolBtnSecNew;
    }
}