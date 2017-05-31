namespace Heren.MedQC.Hdp
{
    partial class RoleManageForm
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
            this.toolbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolbtnModify = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolbtnAuthority = new System.Windows.Forms.ToolStripButton();
            this.dgvRoleList = new Heren.Common.Controls.TableView.DataTableView();
            this.colSerialNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new Heren.Common.Forms.XComboBoxColumn();
            this.colRoleBak = new Heren.Common.Forms.XTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.ttHelp = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnNew,
            this.toolbtnModify,
            this.toolbtnDelete,
            this.toolbtnSave,
            this.toolbtnAuthority});
            this.toolStrip1.Location = new System.Drawing.Point(0, 305);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(772, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnNew
            // 
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
            // toolbtnModify
            // 
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
            // toolbtnDelete
            // 
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
            // toolbtnSave
            // 
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
            // toolbtnAuthority
            // 
            this.toolbtnAuthority.Image = global::Heren.MedQC.Hdp.Properties.Resources.Authority;
            this.toolbtnAuthority.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnAuthority.Name = "toolbtnAuthority";
            this.toolbtnAuthority.Size = new System.Drawing.Size(55, 27);
            this.toolbtnAuthority.Text = "授权";
            this.toolbtnAuthority.ToolTipText = "保存后才可授权";
            this.toolbtnAuthority.Click += new System.EventHandler(this.toolbtnAuthority_Click);
            // 
            // dgvRoleList
            // 
            this.dgvRoleList.AllowUserToOrderColumns = true;
            this.dgvRoleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRoleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerialNO,
            this.colRoleName,
            this.colRoleCode,
            this.colStatus,
            this.colRoleBak});
            this.dgvRoleList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvRoleList.Location = new System.Drawing.Point(4, 4);
            this.dgvRoleList.MultiSelect = false;
            this.dgvRoleList.Name = "dgvRoleList";
            this.dgvRoleList.Size = new System.Drawing.Size(764, 300);
            this.dgvRoleList.TabIndex = 5;
            this.dgvRoleList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dgvRoleList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvRoleList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dgvRoleList.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // colSerialNO
            // 
            this.colSerialNO.HeaderText = "序号";
            this.colSerialNO.MaxInputLength = 4;
            this.colSerialNO.Name = "colSerialNO";
            this.colSerialNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSerialNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRoleName
            // 
            this.colRoleName.FillWeight = 250F;
            this.colRoleName.HeaderText = "角色名称";
            this.colRoleName.MaxInputLength = 8;
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRoleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRoleName.Width = 150;
            // 
            // colRoleCode
            // 
            this.colRoleCode.FillWeight = 250F;
            this.colRoleCode.HeaderText = "角色代码";
            this.colRoleCode.MaxInputLength = 20;
            this.colRoleCode.Name = "colRoleCode";
            this.colRoleCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRoleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRoleCode.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "状态";
            this.colStatus.Items.Add("开启");
            this.colStatus.Items.Add("关闭");
            this.colStatus.Items.Add("");
            this.colStatus.Name = "colStatus";
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.Width = 150;
            // 
            // colRoleBak
            // 
            this.colRoleBak.HeaderText = "角色备注";
            this.colRoleBak.Name = "colRoleBak";
            this.colRoleBak.Width = 350;
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
            // RoleManageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(772, 335);
            this.Controls.Add(this.dgvRoleList);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "RoleManageForm";
            this.Text = "角色管理";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoleList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnNew;
        private System.Windows.Forms.ToolStripButton toolbtnModify;
        private System.Windows.Forms.ToolStripButton toolbtnDelete;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private Heren.Common.Controls.TableView.DataTableView dgvRoleList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleCode;
        private Heren.Common.Forms.XComboBoxColumn colStatus;
        private Heren.Common.Forms.XTextBoxColumn colRoleBak;
        private System.Windows.Forms.ToolStripButton toolbtnAuthority;
        private System.Windows.Forms.ToolTip ttHelp;
    }
}