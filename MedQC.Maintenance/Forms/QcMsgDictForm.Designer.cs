namespace Heren.MedQC.Maintenance
{
    partial class QcMsgDictForm
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnAutoSerialNo = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.colAuto = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSerialNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQCMsgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQCEventType = new Heren.Common.Controls.TableView.ComboBoxColumn();
            this.colMessageTitle = new Heren.Common.Controls.TableView.ComboBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsVeto = new Heren.Common.Controls.TableView.ComboBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IS_VALID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.toolStripLabel1,
            this.tsBtnAutoSerialNo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 331);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(875, 30);
            this.toolStrip1.TabIndex = 5;
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(427, 27);
            this.toolStripLabel1.Text = "                                                            ";
            // 
            // tsBtnAutoSerialNo
            // 
            this.tsBtnAutoSerialNo.Image = global::Heren.MedQC.Maintenance.Properties.Resources.order;
            this.tsBtnAutoSerialNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAutoSerialNo.Name = "tsBtnAutoSerialNo";
            this.tsBtnAutoSerialNo.Size = new System.Drawing.Size(83, 27);
            this.tsBtnAutoSerialNo.Text = "自动排序";
            this.tsBtnAutoSerialNo.Click += new System.EventHandler(this.tsBtnAutoSerialNo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAuto,
            this.colSerialNO,
            this.colQCMsgCode,
            this.colQCEventType,
            this.colMessageTitle,
            this.colMessage,
            this.colIsVeto,
            this.colScore,
            this.col_IS_VALID});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(867, 326);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // colAuto
            // 
            this.colAuto.FillWeight = 20F;
            this.colAuto.HeaderText = "";
            this.colAuto.Image = global::Heren.MedQC.Maintenance.Properties.Resources.empty;
            this.colAuto.Name = "colAuto";
            this.colAuto.Width = 20;
            // 
            // colSerialNO
            // 
            this.colSerialNO.FillWeight = 60F;
            this.colSerialNO.HeaderText = "序号";
            this.colSerialNO.MaxInputLength = 4;
            this.colSerialNO.Name = "colSerialNO";
            this.colSerialNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSerialNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSerialNO.Width = 60;
            // 
            // colQCMsgCode
            // 
            this.colQCMsgCode.FillWeight = 60F;
            this.colQCMsgCode.HeaderText = "代码";
            this.colQCMsgCode.MaxInputLength = 4;
            this.colQCMsgCode.Name = "colQCMsgCode";
            this.colQCMsgCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colQCMsgCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQCMsgCode.Width = 60;
            // 
            // colQCEventType
            // 
            this.colQCEventType.FillWeight = 200F;
            this.colQCEventType.HeaderText = "问题大类";
            this.colQCEventType.Name = "colQCEventType";
            this.colQCEventType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colQCEventType.Width = 150;
            // 
            // colMessageTitle
            // 
            this.colMessageTitle.HeaderText = "问题子类";
            this.colMessageTitle.Name = "colMessageTitle";
            this.colMessageTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colMessage
            // 
            this.colMessage.FillWeight = 400F;
            this.colMessage.HeaderText = "信息说明";
            this.colMessage.MaxInputLength = 100;
            this.colMessage.Name = "colMessage";
            this.colMessage.Width = 400;
            // 
            // colIsVeto
            // 
            this.colIsVeto.HeaderText = "单项否决";
            this.colIsVeto.Items.Add("是");
            this.colIsVeto.Items.Add("否");
            this.colIsVeto.Name = "colIsVeto";
            this.colIsVeto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsVeto.Width = 70;
            // 
            // colScore
            // 
            this.colScore.HeaderText = "扣分";
            this.colScore.MaxInputLength = 5;
            this.colScore.Name = "colScore";
            // 
            // col_IS_VALID
            // 
            this.col_IS_VALID.HeaderText = "启用";
            this.col_IS_VALID.Name = "col_IS_VALID";
            this.col_IS_VALID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_IS_VALID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_IS_VALID.Width = 50;
            // 
            // QcMsgDictForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(875, 361);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "QcMsgDictForm";
            this.Text = "质控质检问题字典维护";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsBtnAutoSerialNo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewImageColumn colAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCMsgCode;
        private Common.Controls.TableView.ComboBoxColumn colQCEventType;
        private Common.Controls.TableView.ComboBoxColumn colMessageTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private Common.Controls.TableView.ComboBoxColumn colIsVeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IS_VALID;
    }
}