namespace Heren.MedQC.Maintenance
{
    partial class QcCheckPointForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnnCancelModify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancelDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new Heren.Common.Controls.HerenButton();
            this.btnMoveDown = new Heren.Common.Controls.FlatButton();
            this.btnMoveUp = new Heren.Common.Controls.FlatButton();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.btnExport = new Heren.Common.Controls.HerenButton();
            this.btnCommit = new Heren.Common.Controls.HerenButton();
            this.colDebug = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCheckPointID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckType = new Heren.Common.Forms.XComboBoxColumn();
            this.colQaEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMsgDictMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckPointContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ELEMENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWrittenPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsRepeat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsValid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQCScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHandlerCommand = new Heren.Common.Forms.XFindComboBoxColumn();
            this.colScriptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Location = new System.Drawing.Point(883, 59);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.ToolTipText = "下移";
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Location = new System.Drawing.Point(883, 29);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.ToolTipText = "上移";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 24;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDebug,
            this.colCheckPointID,
            this.colCheckType,
            this.colQaEventType,
            this.colMsgDictMessage,
            this.colCheckPointContent,
            this.colDocType,
            this.col_ELEMENT_NAME,
            this.colEvent,
            this.colWrittenPeriod,
            this.colIsRepeat,
            this.colIsValid,
            this.colQCScore,
            this.colHandlerCommand,
            this.colScriptName});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 36;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(875, 411);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(820, 424);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 27);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Location = new System.Drawing.Point(727, 424);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(87, 27);
            this.btnCommit.TabIndex = 4;
            this.btnCommit.Text = "保存";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // colDebug
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "调试";
            this.colDebug.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDebug.Frozen = true;
            this.colDebug.HeaderText = "";
            this.colDebug.Name = "colDebug";
            this.colDebug.Text = "调试";
            this.colDebug.Width = 50;
            // 
            // colCheckPointID
            // 
            this.colCheckPointID.FillWeight = 130F;
            this.colCheckPointID.HeaderText = "规则编号";
            this.colCheckPointID.Name = "colCheckPointID";
            this.colCheckPointID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCheckPointID.Visible = false;
            // 
            // colCheckType
            // 
            this.colCheckType.HeaderText = "检查类型";
            this.colCheckType.Items.Add("合理性");
            this.colCheckType.Items.Add("一致性");
            this.colCheckType.Items.Add("周期性");
            this.colCheckType.Items.Add("时效性");
            this.colCheckType.Items.Add("完整性");
            this.colCheckType.Name = "colCheckType";
            this.colCheckType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheckType.Width = 80;
            // 
            // colQaEventType
            // 
            this.colQaEventType.HeaderText = "内容分类";
            this.colQaEventType.Name = "colQaEventType";
            this.colQaEventType.Width = 80;
            // 
            // colMsgDictMessage
            // 
            this.colMsgDictMessage.HeaderText = "缺陷内容";
            this.colMsgDictMessage.Name = "colMsgDictMessage";
            this.colMsgDictMessage.Width = 300;
            // 
            // colCheckPointContent
            // 
            this.colCheckPointContent.FillWeight = 350F;
            this.colCheckPointContent.HeaderText = "核查方法";
            this.colCheckPointContent.Name = "colCheckPointContent";
            this.colCheckPointContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCheckPointContent.Width = 600;
            // 
            // colDocType
            // 
            this.colDocType.FillWeight = 240F;
            this.colDocType.HeaderText = "相关病历";
            this.colDocType.Name = "colDocType";
            this.colDocType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_ELEMENT_NAME
            // 
            this.col_ELEMENT_NAME.HeaderText = "相关内容项";
            this.col_ELEMENT_NAME.Name = "col_ELEMENT_NAME";
            this.col_ELEMENT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colEvent
            // 
            this.colEvent.HeaderText = "相关事件";
            this.colEvent.Name = "colEvent";
            this.colEvent.ReadOnly = true;
            this.colEvent.Width = 80;
            // 
            // colWrittenPeriod
            // 
            this.colWrittenPeriod.FillWeight = 60F;
            this.colWrittenPeriod.HeaderText = "完成时限";
            this.colWrittenPeriod.Name = "colWrittenPeriod";
            this.colWrittenPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWrittenPeriod.Width = 80;
            // 
            // colIsRepeat
            // 
            this.colIsRepeat.FillWeight = 50F;
            this.colIsRepeat.HeaderText = "周期的";
            this.colIsRepeat.Name = "colIsRepeat";
            this.colIsRepeat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsRepeat.Width = 60;
            // 
            // colIsValid
            // 
            this.colIsValid.FillWeight = 50F;
            this.colIsValid.HeaderText = "开启";
            this.colIsValid.Name = "colIsValid";
            this.colIsValid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsValid.Width = 60;
            // 
            // colQCScore
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQCScore.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQCScore.FillWeight = 350F;
            this.colQCScore.HeaderText = "质控扣分";
            this.colQCScore.Name = "colQCScore";
            this.colQCScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQCScore.Width = 80;
            // 
            // colHandlerCommand
            // 
            this.colHandlerCommand.CandidateWidth = 250;
            this.colHandlerCommand.HeaderText = "处理命令";
            this.colHandlerCommand.Name = "colHandlerCommand";
            this.colHandlerCommand.PinyinFuzzyMatch = true;
            this.colHandlerCommand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHandlerCommand.Width = 200;
            // 
            // colScriptName
            // 
            this.colScriptName.HeaderText = "脚本名称";
            this.colScriptName.Name = "colScriptName";
            // 
            // QcCheckPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 461);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCommit);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "QcCheckPointForm";
            this.Text = "缺陷规则配置";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private Heren.Common.Controls.HerenButton btnExport;
        private System.Windows.Forms.DataGridViewButtonColumn colDebug;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckPointID;
        private Common.Forms.XComboBoxColumn colCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsgDictMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckPointContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ELEMENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWrittenPeriod;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsRepeat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsValid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCScore;
        private Common.Forms.XFindComboBoxColumn colHandlerCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScriptName;
    }
}