namespace Heren.MedQC.Maintenance
{
    partial class TimeRuleEditForm
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
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.colRuleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTypeAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWrittenPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsRepeat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsValid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQCScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuleDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnnCancelModify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancelDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveUp = new Heren.Common.Controls.FlatButton();
            this.btnMoveDown = new Heren.Common.Controls.FlatButton();
            this.btnAdd = new Heren.Common.Controls.HerenButton();
            this.btnCommit = new Heren.Common.Controls.HerenButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 24;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRuleID,
            this.colEvent,
            this.colDocType,
            this.colDocTypeAlias,
            this.colWrittenPeriod,
            this.colIsRepeat,
            this.colIsValid,
            this.colQCScore,
            this.colRuleDesc});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 36;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(685, 411);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // colRuleID
            // 
            this.colRuleID.FillWeight = 130F;
            this.colRuleID.HeaderText = "规则编号";
            this.colRuleID.Name = "colRuleID";
            this.colRuleID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRuleID.Width = 130;
            // 
            // colEvent
            // 
            this.colEvent.FillWeight = 90F;
            this.colEvent.HeaderText = "关联事件";
            this.colEvent.Name = "colEvent";
            this.colEvent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEvent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEvent.Width = 90;
            // 
            // colDocType
            // 
            this.colDocType.FillWeight = 240F;
            this.colDocType.HeaderText = "应写病历";
            this.colDocType.Name = "colDocType";
            this.colDocType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDocType.Width = 240;
            // 
            // colDocTypeAlias
            // 
            this.colDocTypeAlias.FillWeight = 120F;
            this.colDocTypeAlias.HeaderText = "应写病历别名";
            this.colDocTypeAlias.Name = "colDocTypeAlias";
            this.colDocTypeAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDocTypeAlias.Width = 120;
            // 
            // colWrittenPeriod
            // 
            this.colWrittenPeriod.FillWeight = 60F;
            this.colWrittenPeriod.HeaderText = "完成时限";
            this.colWrittenPeriod.Name = "colWrittenPeriod";
            this.colWrittenPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWrittenPeriod.Width = 60;
            // 
            // colIsRepeat
            // 
            this.colIsRepeat.FillWeight = 50F;
            this.colIsRepeat.HeaderText = "周期的";
            this.colIsRepeat.Name = "colIsRepeat";
            this.colIsRepeat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsRepeat.Width = 50;
            // 
            // colIsValid
            // 
            this.colIsValid.FillWeight = 50F;
            this.colIsValid.HeaderText = "开启";
            this.colIsValid.Name = "colIsValid";
            this.colIsValid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsValid.Width = 50;
            // 
            // colQCScore
            // 
            this.colQCScore.FillWeight = 350F;
            this.colQCScore.HeaderText = "质控扣分";
            this.colQCScore.Name = "colQCScore";
            this.colQCScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQCScore.Width = 60;
            // 
            // colRuleDesc
            // 
            this.colRuleDesc.FillWeight = 350F;
            this.colRuleDesc.HeaderText = "规则描述";
            this.colRuleDesc.Name = "colRuleDesc";
            this.colRuleDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRuleDesc.Width = 350;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMoveUp,
            this.mnuMoveDown,
            this.toolStripSeparator1,
            this.mnnCancelModify,
            this.mnuCancelDelete,
            this.mnuDeleteRecord});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(216, 120);
            // 
            // mnuMoveUp
            // 
            this.mnuMoveUp.Name = "mnuMoveUp";
            this.mnuMoveUp.Size = new System.Drawing.Size(215, 22);
            this.mnuMoveUp.Text = "上调选中行";
            this.mnuMoveUp.Click += new System.EventHandler(this.mnuMoveUp_Click);
            // 
            // mnuMoveDown
            // 
            this.mnuMoveDown.Name = "mnuMoveDown";
            this.mnuMoveDown.Size = new System.Drawing.Size(215, 22);
            this.mnuMoveDown.Text = "下调选中行";
            this.mnuMoveDown.Click += new System.EventHandler(this.mnuMoveDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // mnnCancelModify
            // 
            this.mnnCancelModify.Name = "mnnCancelModify";
            this.mnnCancelModify.Size = new System.Drawing.Size(215, 22);
            this.mnnCancelModify.Text = "取消修改";
            this.mnnCancelModify.Click += new System.EventHandler(this.mnnCancelModify_Click);
            // 
            // mnuCancelDelete
            // 
            this.mnuCancelDelete.Name = "mnuCancelDelete";
            this.mnuCancelDelete.Size = new System.Drawing.Size(215, 22);
            this.mnuCancelDelete.Text = "取消删除";
            this.mnuCancelDelete.Click += new System.EventHandler(this.mnuCancelDelete_Click);
            // 
            // mnuDeleteRecord
            // 
            this.mnuDeleteRecord.Name = "mnuDeleteRecord";
            this.mnuDeleteRecord.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.mnuDeleteRecord.Size = new System.Drawing.Size(215, 22);
            this.mnuDeleteRecord.Text = "删除选中项";
            this.mnuDeleteRecord.Click += new System.EventHandler(this.mnuDeleteRecord_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Location = new System.Drawing.Point(693, 29);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.ToolTipText = "上移";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Location = new System.Drawing.Point(693, 59);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.ToolTipText = "下移";
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 424);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 27);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Location = new System.Drawing.Point(586, 424);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(87, 27);
            this.btnCommit.TabIndex = 4;
            this.btnCommit.Text = "保存";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // TimeRuleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 461);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCommit);
            this.Name = "TimeRuleEditForm";
            this.Text = "时效规则配置";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnnCancelModify;
        private System.Windows.Forms.ToolStripMenuItem mnuCancelDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteRecord;
        private Heren.Common.Controls.FlatButton btnMoveUp;
        private Heren.Common.Controls.FlatButton btnMoveDown;
        private Heren.Common.Controls.HerenButton btnAdd;
        private Heren.Common.Controls.HerenButton btnCommit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTypeAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWrittenPeriod;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsRepeat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsValid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuleDesc;
    }
}