namespace Heren.MedQC.Hdp
{
    partial class MenuConfigForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolbtnMoveUp = new System.Windows.Forms.ToolStripButton();
            this.toolbtnMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolbtnLeft = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRight = new System.Windows.Forms.ToolStripButton();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolbtnModify = new System.Windows.Forms.ToolStripButton();
            this.toolbtnNew = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolcboProduct = new System.Windows.Forms.ToolStripComboBox();
            this.toolbtnMenu = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.colShowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortCuts = new Heren.Common.Forms.XFindComboBoxColumn();
            this.colShowType = new Heren.Common.Forms.XComboBoxColumn();
            this.colRightKey = new Heren.Common.Forms.XFindComboBoxColumn();
            this.colRightDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUICommand = new Heren.Common.Forms.XFindComboBoxColumn();
            this.colUIIcon = new Heren.Common.Forms.XTextBoxColumn();
            this.colUIIconSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMicroHelp = new Heren.Common.Forms.XTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolbtnMoveUp,
            this.toolbtnMoveDown,
            this.toolbtnLeft,
            this.toolbtnRight,
            this.toolbtnSave,
            this.toolbtnDelete,
            this.toolbtnModify,
            this.toolbtnNew});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 305);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(872, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 27);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // toolbtnMoveUp
            // 
            this.toolbtnMoveUp.Image = global::Heren.MedQC.Hdp.Properties.Resources.MoveUp;
            this.toolbtnMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnMoveUp.Name = "toolbtnMoveUp";
            this.toolbtnMoveUp.Size = new System.Drawing.Size(55, 27);
            this.toolbtnMoveUp.Text = "上移";
            this.toolbtnMoveUp.Click += new System.EventHandler(this.toolbtnMoveUp_Click);
            // 
            // toolbtnMoveDown
            // 
            this.toolbtnMoveDown.Image = global::Heren.MedQC.Hdp.Properties.Resources.MoveDown;
            this.toolbtnMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnMoveDown.Name = "toolbtnMoveDown";
            this.toolbtnMoveDown.Size = new System.Drawing.Size(55, 27);
            this.toolbtnMoveDown.Text = "下移";
            this.toolbtnMoveDown.Click += new System.EventHandler(this.toolbtnMoveDown_Click);
            // 
            // toolbtnLeft
            // 
            this.toolbtnLeft.Image = global::Heren.MedQC.Hdp.Properties.Resources.Left;
            this.toolbtnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnLeft.Name = "toolbtnLeft";
            this.toolbtnLeft.Size = new System.Drawing.Size(55, 27);
            this.toolbtnLeft.Text = "升级";
            this.toolbtnLeft.Click += new System.EventHandler(this.toolbtnLeft_Click);
            // 
            // toolbtnRight
            // 
            this.toolbtnRight.Image = global::Heren.MedQC.Hdp.Properties.Resources.Right;
            this.toolbtnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRight.Name = "toolbtnRight";
            this.toolbtnRight.Size = new System.Drawing.Size(55, 27);
            this.toolbtnRight.Text = "降级";
            this.toolbtnRight.Click += new System.EventHandler(this.toolbtnRight_Click);
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolbtnSave.AutoSize = false;
            this.toolbtnSave.Image = global::Heren.MedQC.Hdp.Properties.Resources.Save;
            this.toolbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSave.Name = "toolbtnSave";
            this.toolbtnSave.Size = new System.Drawing.Size(84, 26);
            this.toolbtnSave.Text = "保存";
            this.toolbtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnSave.ToolTipText = "保存";
            this.toolbtnSave.Click += new System.EventHandler(this.toolbtnSave_Click);
            // 
            // toolbtnDelete
            // 
            this.toolbtnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolbtnDelete.AutoSize = false;
            this.toolbtnDelete.Image = global::Heren.MedQC.Hdp.Properties.Resources.Delete;
            this.toolbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDelete.Name = "toolbtnDelete";
            this.toolbtnDelete.Size = new System.Drawing.Size(84, 26);
            this.toolbtnDelete.Text = "删除";
            this.toolbtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnDelete.ToolTipText = "删除";
            this.toolbtnDelete.Click += new System.EventHandler(this.toolbtnDelete_Click);
            // 
            // toolbtnModify
            // 
            this.toolbtnModify.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolbtnModify.AutoSize = false;
            this.toolbtnModify.Image = global::Heren.MedQC.Hdp.Properties.Resources.Update;
            this.toolbtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnModify.Name = "toolbtnModify";
            this.toolbtnModify.Size = new System.Drawing.Size(84, 26);
            this.toolbtnModify.Text = "修改";
            this.toolbtnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnModify.ToolTipText = "修改";
            this.toolbtnModify.Click += new System.EventHandler(this.toolbtnModify_Click);
            // 
            // toolbtnNew
            // 
            this.toolbtnNew.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolbtnNew.AutoSize = false;
            this.toolbtnNew.Image = global::Heren.MedQC.Hdp.Properties.Resources.Add;
            this.toolbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNew.Name = "toolbtnNew";
            this.toolbtnNew.Size = new System.Drawing.Size(84, 26);
            this.toolbtnNew.Text = "新增";
            this.toolbtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnNew.ToolTipText = "新增";
            this.toolbtnNew.Click += new System.EventHandler(this.toolbtnNew_Click);
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
            this.mnuAddItem.Image = global::Heren.MedQC.Hdp.Properties.Resources.Add;
            this.mnuAddItem.Name = "mnuAddItem";
            this.mnuAddItem.Size = new System.Drawing.Size(100, 22);
            this.mnuAddItem.Text = "新增";
            this.mnuAddItem.Click += new System.EventHandler(this.mnuAddItem_Click);
            // 
            // mnuModifyItem
            // 
            this.mnuModifyItem.Image = global::Heren.MedQC.Hdp.Properties.Resources.Update;
            this.mnuModifyItem.Name = "mnuModifyItem";
            this.mnuModifyItem.Size = new System.Drawing.Size(100, 22);
            this.mnuModifyItem.Text = "修改";
            this.mnuModifyItem.Click += new System.EventHandler(this.mnuModifyItem_Click);
            // 
            // mnuDeleteItem
            // 
            this.mnuDeleteItem.Image = global::Heren.MedQC.Hdp.Properties.Resources.Delete;
            this.mnuDeleteItem.Name = "mnuDeleteItem";
            this.mnuDeleteItem.Size = new System.Drawing.Size(100, 22);
            this.mnuDeleteItem.Text = "删除";
            this.mnuDeleteItem.Click += new System.EventHandler(this.mnuDeleteItem_Click);
            // 
            // mnuSaveItems
            // 
            this.mnuSaveItems.Image = global::Heren.MedQC.Hdp.Properties.Resources.Save;
            this.mnuSaveItems.Name = "mnuSaveItems";
            this.mnuSaveItems.Size = new System.Drawing.Size(100, 22);
            this.mnuSaveItems.Text = "保存";
            this.mnuSaveItems.Click += new System.EventHandler(this.mnuSaveItems_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolcboProduct,
            this.toolbtnMenu});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(872, 30);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 27);
            this.toolStripLabel1.Text = "产品：";
            // 
            // toolcboProduct
            // 
            this.toolcboProduct.Name = "toolcboProduct";
            this.toolcboProduct.Size = new System.Drawing.Size(151, 30);
            this.toolcboProduct.SelectedIndexChanged += new System.EventHandler(this.toolcboProduct_SelectedIndexChanged);
            // 
            // toolbtnMenu
            // 
            this.toolbtnMenu.Checked = true;
            this.toolbtnMenu.CheckOnClick = true;
            this.toolbtnMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolbtnMenu.Image = global::Heren.MedQC.Hdp.Properties.Resources.Menu;
            this.toolbtnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolbtnMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnMenu.Name = "toolbtnMenu";
            this.toolbtnMenu.Size = new System.Drawing.Size(69, 27);
            this.toolbtnMenu.Text = "主菜单";
            this.toolbtnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnMenu.Click += new System.EventHandler(this.toolbtnMenu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShowName,
            this.colShortCuts,
            this.colShowType,
            this.colRightKey,
            this.colRightDesc,
            this.colUICommand,
            this.colUIIcon,
            this.colUIIconSize,
            this.colMicroHelp});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(872, 275);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // colShowName
            // 
            this.colShowName.HeaderText = "菜单显示名称";
            this.colShowName.MaxInputLength = 100;
            this.colShowName.MinimumWidth = 20;
            this.colShowName.Name = "colShowName";
            this.colShowName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colShowName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colShowName.Width = 200;
            // 
            // colShortCuts
            // 
            this.colShortCuts.FillWeight = 250F;
            this.colShortCuts.HeaderText = "快捷键";
            this.colShortCuts.MinimumWidth = 20;
            this.colShortCuts.Name = "colShortCuts";
            this.colShortCuts.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colShortCuts.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colShowType
            // 
            this.colShowType.FillWeight = 250F;
            this.colShowType.HeaderText = "显示方式";
            this.colShowType.Items.Add("文字");
            this.colShowType.Items.Add("文字+图片");
            this.colShowType.Items.Add("图片");
            this.colShowType.Name = "colShowType";
            this.colShowType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colShowType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colShowType.Visible = false;
            // 
            // colRightKey
            // 
            this.colRightKey.HeaderText = "权限点";
            this.colRightKey.Name = "colRightKey";
            this.colRightKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRightKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRightKey.Width = 250;
            // 
            // colRightDesc
            // 
            this.colRightDesc.HeaderText = "权限点说明";
            this.colRightDesc.Name = "colRightDesc";
            this.colRightDesc.Width = 250;
            // 
            // colUICommand
            // 
            this.colUICommand.HeaderText = "命令";
            this.colUICommand.Name = "colUICommand";
            this.colUICommand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUICommand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUICommand.Width = 250;
            // 
            // colUIIcon
            // 
            this.colUIIcon.HeaderText = "图标";
            this.colUIIcon.Name = "colUIIcon";
            this.colUIIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colUIIconSize
            // 
            this.colUIIconSize.HeaderText = "图标大小";
            this.colUIIconSize.Name = "colUIIconSize";
            // 
            // colMicroHelp
            // 
            this.colMicroHelp.HeaderText = "微帮助";
            this.colMicroHelp.Name = "colMicroHelp";
            this.colMicroHelp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMicroHelp.Visible = false;
            // 
            // MenuConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(872, 335);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "MenuConfigForm";
            this.Text = "菜单管理";
            this.Load += new System.EventHandler(this.MenuConfigForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnNew;
        private System.Windows.Forms.ToolStripButton toolbtnModify;
        private System.Windows.Forms.ToolStripButton toolbtnDelete;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveItems;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolcboProduct;
        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolbtnMoveUp;
        private System.Windows.Forms.ToolStripButton toolbtnMoveDown;
        private System.Windows.Forms.ToolStripButton toolbtnLeft;
        private System.Windows.Forms.ToolStripButton toolbtnRight;
        private System.Windows.Forms.ToolStripButton toolbtnMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShowName;
        private Common.Forms.XFindComboBoxColumn colShortCuts;
        private Common.Forms.XComboBoxColumn colShowType;
        private Common.Forms.XFindComboBoxColumn colRightKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRightDesc;
        private Common.Forms.XFindComboBoxColumn colUICommand;
        private Common.Forms.XTextBoxColumn colUIIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUIIconSize;
        private Common.Forms.XTextBoxColumn colMicroHelp;
    }
}