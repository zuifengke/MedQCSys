namespace Heren.MedQC.Statistic
{
    partial class StatByModifyTimesForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvMainList = new System.Windows.Forms.DataGridView();
            this.colModifyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifyTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenAllDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStatTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStatTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvMainList);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetailList);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Size = new System.Drawing.Size(757, 450);
            this.splitContainer1.SplitterDistance = 443;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvMainList
            // 
            this.dgvMainList.AllowUserToAddRows = false;
            this.dgvMainList.AllowUserToDeleteRows = false;
            this.dgvMainList.AllowUserToResizeRows = false;
            this.dgvMainList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMainList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMainList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModifyName,
            this.colDocTitle,
            this.colModifyTimes,
            this.colCreatorName,
            this.colPatientName});
            this.dgvMainList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMainList.Location = new System.Drawing.Point(0, 0);
            this.dgvMainList.MultiSelect = false;
            this.dgvMainList.Name = "dgvMainList";
            this.dgvMainList.ReadOnly = true;
            this.dgvMainList.RowHeadersVisible = false;
            this.dgvMainList.RowTemplate.Height = 27;
            this.dgvMainList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainList.Size = new System.Drawing.Size(443, 450);
            this.dgvMainList.TabIndex = 3;
            this.dgvMainList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMainList_CellMouseClick);
            // 
            // colModifyName
            // 
            this.colModifyName.FillWeight = 120F;
            this.colModifyName.HeaderText = "修改者";
            this.colModifyName.Name = "colModifyName";
            this.colModifyName.ReadOnly = true;
            this.colModifyName.Width = 120;
            // 
            // colDocTitle
            // 
            this.colDocTitle.FillWeight = 160F;
            this.colDocTitle.HeaderText = "病历标题";
            this.colDocTitle.Name = "colDocTitle";
            this.colDocTitle.ReadOnly = true;
            this.colDocTitle.Width = 160;
            // 
            // colModifyTimes
            // 
            this.colModifyTimes.FillWeight = 90F;
            this.colModifyTimes.HeaderText = "修改次数";
            this.colModifyTimes.Name = "colModifyTimes";
            this.colModifyTimes.ReadOnly = true;
            this.colModifyTimes.Width = 90;
            // 
            // colCreatorName
            // 
            this.colCreatorName.FillWeight = 120F;
            this.colCreatorName.HeaderText = "创建者";
            this.colCreatorName.Name = "colCreatorName";
            this.colCreatorName.ReadOnly = true;
            this.colCreatorName.Width = 120;
            // 
            // colPatientName
            // 
            this.colPatientName.FillWeight = 120F;
            this.colPatientName.HeaderText = "患者姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            this.colPatientName.Width = 120;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.AllowUserToOrderColumns = true;
            this.dgvDetailList.AllowUserToResizeRows = false;
            this.dgvDetailList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetailList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeptName,
            this.colCreateTime,
            this.colModifyDate});
            this.dgvDetailList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDetailList.Location = new System.Drawing.Point(3, 23);
            this.dgvDetailList.MultiSelect = false;
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.ReadOnly = true;
            this.dgvDetailList.RowHeadersVisible = false;
            this.dgvDetailList.RowTemplate.Height = 27;
            this.dgvDetailList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailList.Size = new System.Drawing.Size(304, 427);
            this.dgvDetailList.TabIndex = 6;
            this.dgvDetailList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocList_CellDoubleClick);
            // 
            // colDeptName
            // 
            this.colDeptName.FillWeight = 120F;
            this.colDeptName.HeaderText = "所在科室";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.Width = 120;
            // 
            // colCreateTime
            // 
            this.colCreateTime.FillWeight = 150F;
            this.colCreateTime.HeaderText = "创建时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 150;
            // 
            // colModifyDate
            // 
            this.colModifyDate.FillWeight = 150F;
            this.colModifyDate.HeaderText = "修改时间";
            this.colModifyDate.Name = "colModifyDate";
            this.colModifyDate.ReadOnly = true;
            this.colModifyDate.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenDoc,
            this.mnuOpenAllDoc});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 48);
            // 
            // mnuOpenDoc
            // 
            this.mnuOpenDoc.Name = "mnuOpenDoc";
            this.mnuOpenDoc.Size = new System.Drawing.Size(172, 22);
            this.mnuOpenDoc.Text = "打开病历";
            this.mnuOpenDoc.Click += new System.EventHandler(this.mnuOpenDoc_Click);
            // 
            // mnuOpenAllDoc
            // 
            this.mnuOpenAllDoc.Name = "mnuOpenAllDoc";
            this.mnuOpenAllDoc.Size = new System.Drawing.Size(172, 22);
            this.mnuOpenAllDoc.Text = "合并打开所有病历";
            this.mnuOpenAllDoc.Click += new System.EventHandler(this.mnuOpenAllDoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "病历修改详细信息";
            // 
            // cboDeptName
            // 
            this.cboDeptName.CandidateWidth = 200;
            this.cboDeptName.DroppedDown = false;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.Location = new System.Drawing.Point(45, 9);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.SelectedItem = null;
            this.cboDeptName.Size = new System.Drawing.Size(129, 23);
            this.cboDeptName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(5, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "科室";
            // 
            // dtpStatTimeEnd
            // 
            this.dtpStatTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeEnd.Location = new System.Drawing.Point(389, 9);
            this.dtpStatTimeEnd.Name = "dtpStatTimeEnd";
            this.dtpStatTimeEnd.Size = new System.Drawing.Size(120, 23);
            this.dtpStatTimeEnd.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(365, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "至";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(594, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 28);
            this.btnQuery.TabIndex = 11;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(176, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "修改时间";
            // 
            // dtpStatTimeBegin
            // 
            this.dtpStatTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeBegin.Location = new System.Drawing.Point(242, 9);
            this.dtpStatTimeBegin.Name = "dtpStatTimeBegin";
            this.dtpStatTimeBegin.Size = new System.Drawing.Size(121, 23);
            this.dtpStatTimeBegin.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnExport.Location = new System.Drawing.Point(665, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 28);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Excel导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.dtpStatTimeBegin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpStatTimeEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 38);
            this.panel1.TabIndex = 4;
            // 
            // StatByModifyTimesForm
            // 
            this.AcceptButton = this.btnQuery;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 488);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "StatByModifyTimesForm";
            this.Text = "病历修改次数统计";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvMainList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetailList;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStatTimeEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStatTimeBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenAllDoc;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel1;
    }
}