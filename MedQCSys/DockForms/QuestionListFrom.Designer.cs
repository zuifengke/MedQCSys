namespace MedQCSys.DockForms
{
    partial class QuestionListForm
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
            this.toolbtnLock = new System.Windows.Forms.ToolStripButton();
            this.toolbtnPass = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRollback = new System.Windows.Forms.ToolStripButton();
            this.toolbtnQCPass = new System.Windows.Forms.ToolStripButton();
            this.toolbthQChat = new System.Windows.Forms.ToolStripButton();
            this.toolbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.colLockStatus = new Heren.Common.Forms.XImageColumn();
            this.colMsgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQCEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeedBackInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfirmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssusdBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDept_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPassItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.chbShowAll = new System.Windows.Forms.CheckBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.mnuNotPassItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnNew,
            this.toolbtnModify,
            this.toolbtnDelete,
            this.toolbtnLock,
            this.toolbtnPass,
            this.toolbtnRollback,
            this.toolbtnQCPass,
            this.toolbthQChat,
            this.toolbtnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(997, 32);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnNew
            // 
            this.toolbtnNew.AutoSize = false;
            this.toolbtnNew.Image = global::MedQCSys.Properties.Resources.Add;
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
            this.toolbtnModify.Image = global::MedQCSys.Properties.Resources.Update;
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
            this.toolbtnDelete.Image = global::MedQCSys.Properties.Resources.Delete;
            this.toolbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDelete.Name = "toolbtnDelete";
            this.toolbtnDelete.Size = new System.Drawing.Size(84, 26);
            this.toolbtnDelete.Text = "删除";
            this.toolbtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnDelete.ToolTipText = "删除";
            this.toolbtnDelete.Click += new System.EventHandler(this.toolbtnDelete_Click);
            // 
            // toolbtnLock
            // 
            this.toolbtnLock.Image = global::MedQCSys.Properties.Resources._lock;
            this.toolbtnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnLock.Name = "toolbtnLock";
            this.toolbtnLock.Size = new System.Drawing.Size(87, 29);
            this.toolbtnLock.Text = "强制锁定";
            this.toolbtnLock.Click += new System.EventHandler(this.toolbtnLock_Click);
            // 
            // toolbtnPass
            // 
            this.toolbtnPass.AutoSize = false;
            this.toolbtnPass.Image = global::MedQCSys.Properties.Resources.Pass;
            this.toolbtnPass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPass.Name = "toolbtnPass";
            this.toolbtnPass.Size = new System.Drawing.Size(84, 26);
            this.toolbtnPass.Text = "病案合格";
            this.toolbtnPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnPass.ToolTipText = "病案合格";
            this.toolbtnPass.Click += new System.EventHandler(this.toolbtnPass_Click);
            // 
            // toolbtnRollback
            // 
            this.toolbtnRollback.AutoSize = false;
            this.toolbtnRollback.Image = global::MedQCSys.Properties.Resources.Cancel;
            this.toolbtnRollback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRollback.Name = "toolbtnRollback";
            this.toolbtnRollback.Size = new System.Drawing.Size(84, 26);
            this.toolbtnRollback.Text = "病案退回";
            this.toolbtnRollback.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnRollback.Visible = false;
            this.toolbtnRollback.Click += new System.EventHandler(this.toolbtnRollback_Click);
            // 
            // toolbtnQCPass
            // 
            this.toolbtnQCPass.Image = global::MedQCSys.Properties.Resources.Pass;
            this.toolbtnQCPass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnQCPass.Name = "toolbtnQCPass";
            this.toolbtnQCPass.Size = new System.Drawing.Size(87, 29);
            this.toolbtnQCPass.Text = "问题合格";
            this.toolbtnQCPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnQCPass.Click += new System.EventHandler(this.toolbtnQCPass_Click);
            // 
            // toolbthQChat
            // 
            this.toolbthQChat.Image = global::MedQCSys.Properties.Resources.chat;
            this.toolbthQChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbthQChat.Name = "toolbthQChat";
            this.toolbthQChat.Size = new System.Drawing.Size(59, 29);
            this.toolbthQChat.Text = "消息";
            this.toolbthQChat.Click += new System.EventHandler(this.toolbthQChat_Click);
            // 
            // toolbtnPrint
            // 
            this.toolbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnPrint.Image = global::MedQCSys.Properties.Resources.Print;
            this.toolbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPrint.Name = "toolbtnPrint";
            this.toolbtnPrint.Size = new System.Drawing.Size(24, 29);
            this.toolbtnPrint.Text = "打印";
            this.toolbtnPrint.Click += new System.EventHandler(this.toolbtnPrint_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLockStatus,
            this.colMsgStatus,
            this.colQCEventType,
            this.colMessage,
            this.colDetailInfo,
            this.colDocTitle,
            this.colCheckTime,
            this.colFeedBackInfo,
            this.colConfirmTime,
            this.colScore,
            this.colIssusdBy,
            this.colCreator,
            this.colDept_Code});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(997, 321);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // colLockStatus
            // 
            this.colLockStatus.HeaderText = "";
            this.colLockStatus.Image = global::MedQCSys.Properties.Resources.empty;
            this.colLockStatus.Name = "colLockStatus";
            this.colLockStatus.Width = 30;
            // 
            // colQuestionStatus
            // 
            this.colMsgStatus.HeaderText = "问题状态";
            this.colMsgStatus.Name = "colQuestionStatus";
            this.colMsgStatus.ReadOnly = true;
            // 
            // colQCEventType
            // 
            this.colQCEventType.FillWeight = 120F;
            this.colQCEventType.HeaderText = "问题大类";
            this.colQCEventType.Name = "colQCEventType";
            this.colQCEventType.ReadOnly = true;
            this.colQCEventType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colQCEventType.Visible = false;
            this.colQCEventType.Width = 120;
            // 
            // colMessage
            // 
            this.colMessage.FillWeight = 260F;
            this.colMessage.HeaderText = "问题子类";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMessage.Visible = false;
            this.colMessage.Width = 260;
            // 
            // colDetailInfo
            // 
            this.colDetailInfo.FillWeight = 300F;
            this.colDetailInfo.HeaderText = "质检问题";
            this.colDetailInfo.Name = "colDetailInfo";
            this.colDetailInfo.ReadOnly = true;
            this.colDetailInfo.Width = 300;
            // 
            // colDocTitle
            // 
            this.colDocTitle.FillWeight = 120F;
            this.colDocTitle.HeaderText = "对应的病历";
            this.colDocTitle.Name = "colDocTitle";
            this.colDocTitle.ReadOnly = true;
            this.colDocTitle.Width = 120;
            // 
            // colCheckTime
            // 
            this.colCheckTime.FillWeight = 120F;
            this.colCheckTime.HeaderText = "记录时间";
            this.colCheckTime.Name = "colCheckTime";
            this.colCheckTime.ReadOnly = true;
            this.colCheckTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCheckTime.Width = 120;
            // 
            // colFeedBackInfo
            // 
            this.colFeedBackInfo.FillWeight = 120F;
            this.colFeedBackInfo.HeaderText = "医生反馈";
            this.colFeedBackInfo.Name = "colFeedBackInfo";
            this.colFeedBackInfo.ReadOnly = true;
            this.colFeedBackInfo.Width = 120;
            // 
            // colConfirmTime
            // 
            this.colConfirmTime.FillWeight = 120F;
            this.colConfirmTime.HeaderText = "反馈时间";
            this.colConfirmTime.Name = "colConfirmTime";
            this.colConfirmTime.ReadOnly = true;
            this.colConfirmTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colConfirmTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConfirmTime.Width = 120;
            // 
            // colScore
            // 
            this.colScore.FillWeight = 60F;
            this.colScore.HeaderText = "扣分";
            this.colScore.Name = "colScore";
            this.colScore.ReadOnly = true;
            this.colScore.Width = 60;
            // 
            // colIssusdBy
            // 
            this.colIssusdBy.HeaderText = "质检者";
            this.colIssusdBy.Name = "colIssusdBy";
            // 
            // colCreator
            // 
            this.colCreator.HeaderText = "病历创建者";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = false;
            // 
            // colDept_Code
            // 
            this.colDept_Code.HeaderText = "科室代码";
            this.colDept_Code.Name = "colDept_Code";
            this.colDept_Code.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddItem,
            this.mnuModifyItem,
            this.mnuDeleteItem,
            this.mnuPassItem,
            this.mnuNotPassItem,
            this.mnuOpenDoc});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 182);
            // 
            // mnuAddItem
            // 
            this.mnuAddItem.Image = global::MedQCSys.Properties.Resources.Add;
            this.mnuAddItem.Name = "mnuAddItem";
            this.mnuAddItem.Size = new System.Drawing.Size(156, 26);
            this.mnuAddItem.Text = "新增";
            this.mnuAddItem.Click += new System.EventHandler(this.mnuAddItem_Click);
            // 
            // mnuModifyItem
            // 
            this.mnuModifyItem.Image = global::MedQCSys.Properties.Resources.Update;
            this.mnuModifyItem.Name = "mnuModifyItem";
            this.mnuModifyItem.Size = new System.Drawing.Size(156, 26);
            this.mnuModifyItem.Text = "修改";
            this.mnuModifyItem.Click += new System.EventHandler(this.mnuModifyItem_Click);
            // 
            // mnuDeleteItem
            // 
            this.mnuDeleteItem.Image = global::MedQCSys.Properties.Resources.Delete;
            this.mnuDeleteItem.Name = "mnuDeleteItem";
            this.mnuDeleteItem.Size = new System.Drawing.Size(156, 26);
            this.mnuDeleteItem.Text = "删除";
            this.mnuDeleteItem.Click += new System.EventHandler(this.mnuDeleteItem_Click);
            // 
            // mnuPassItem
            // 
            this.mnuPassItem.Image = global::MedQCSys.Properties.Resources.Pass;
            this.mnuPassItem.Name = "mnuPassItem";
            this.mnuPassItem.Size = new System.Drawing.Size(156, 26);
            this.mnuPassItem.Text = "问题合格";
            this.mnuPassItem.Click += new System.EventHandler(this.mnuPassItem_Click);
            // 
            // mnuOpenDoc
            // 
            this.mnuOpenDoc.Image = global::MedQCSys.Properties.Resources.BookOpen;
            this.mnuOpenDoc.Name = "mnuOpenDoc";
            this.mnuOpenDoc.Size = new System.Drawing.Size(156, 26);
            this.mnuOpenDoc.Text = "查看历史病历";
            this.mnuOpenDoc.Click += new System.EventHandler(this.mnuOpenDoc_Click);
            // 
            // chbShowAll
            // 
            this.chbShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbShowAll.AutoSize = true;
            this.chbShowAll.Checked = true;
            this.chbShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowAll.Location = new System.Drawing.Point(843, 8);
            this.chbShowAll.Name = "chbShowAll";
            this.chbShowAll.Size = new System.Drawing.Size(138, 18);
            this.chbShowAll.TabIndex = 4;
            this.chbShowAll.Text = "显示全部质检问题";
            this.chbShowAll.UseVisualStyleBackColor = true;
            this.chbShowAll.CheckedChanged += new System.EventHandler(this.chbShowAll_CheckedChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // mnuNotPassItem
            // 
            this.mnuNotPassItem.Image = global::MedQCSys.Properties.Resources.Error;
            this.mnuNotPassItem.Name = "mnuNotPassItem";
            this.mnuNotPassItem.Size = new System.Drawing.Size(156, 26);
            this.mnuNotPassItem.Text = "问题不合格";
            this.mnuNotPassItem.Click += new System.EventHandler(this.mnuNotPassItem_Click);
            // 
            // QuestionListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(997, 355);
            this.Controls.Add(this.chbShowAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "QuestionListForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Text = "质检问题列表";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnNew;
        private System.Windows.Forms.ToolStripButton toolbtnDelete;
        private System.Windows.Forms.ToolStripButton toolbtnPass;
        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolbtnModify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenDoc;
        private System.Windows.Forms.ToolStripButton toolbtnRollback;
        private System.Windows.Forms.CheckBox chbShowAll;
        private System.Windows.Forms.ToolStripButton toolbtnQCPass;
        private System.Windows.Forms.ToolStripButton toolbthQChat;
        private System.Windows.Forms.ToolStripMenuItem mnuPassItem;
        private System.Windows.Forms.ToolStripButton toolbtnLock;
        private Heren.Common.Forms.XImageColumn colLockStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeedBackInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfirmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssusdBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDept_Code;
        private System.Windows.Forms.ToolStripButton toolbtnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem mnuNotPassItem;
    }
}