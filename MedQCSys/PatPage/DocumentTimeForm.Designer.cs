namespace MedQCSys.DockForms
{
    partial class DocumentTimeForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecordTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckBasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmenuDocTime = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyCheckBasis = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDept = new Heren.Common.Controls.DictInput.FindComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmenuDocTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatientName,
            this.colDocTitle,
            this.colRecordTime,
            this.colDocTime,
            this.colStatus,
            this.colCreator,
            this.colBeginTime,
            this.colEndTime,
            this.colLeave,
            this.colTimeout,
            this.colCheckBasis});
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(959, 322);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "患者";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            // 
            // colDocTitle
            // 
            this.colDocTitle.FillWeight = 120F;
            this.colDocTitle.HeaderText = "病历标题";
            this.colDocTitle.Name = "colDocTitle";
            this.colDocTitle.ReadOnly = true;
            this.colDocTitle.Width = 120;
            // 
            // colRecordTime
            // 
            this.colRecordTime.FillWeight = 120F;
            this.colRecordTime.HeaderText = "记录时间";
            this.colRecordTime.Name = "colRecordTime";
            this.colRecordTime.ReadOnly = true;
            this.colRecordTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRecordTime.Width = 120;
            // 
            // colDocTime
            // 
            this.colDocTime.HeaderText = "创建时间";
            this.colDocTime.Name = "colDocTime";
            this.colDocTime.ReadOnly = true;
            this.colDocTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDocTime.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 70F;
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 70;
            // 
            // colCreator
            // 
            this.colCreator.FillWeight = 60F;
            this.colCreator.HeaderText = "作者";
            this.colCreator.Name = "colCreator";
            this.colCreator.ReadOnly = true;
            this.colCreator.Width = 60;
            // 
            // colBeginTime
            // 
            this.colBeginTime.HeaderText = "开始时间";
            this.colBeginTime.Name = "colBeginTime";
            this.colBeginTime.ReadOnly = true;
            this.colBeginTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBeginTime.Width = 130;
            // 
            // colEndTime
            // 
            this.colEndTime.FillWeight = 124F;
            this.colEndTime.HeaderText = "截止时间";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEndTime.Width = 124;
            // 
            // colLeave
            // 
            this.colLeave.HeaderText = "剩余时间(h)";
            this.colLeave.Name = "colLeave";
            this.colLeave.ReadOnly = true;
            this.colLeave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLeave.Width = 120;
            // 
            // colTimeout
            // 
            this.colTimeout.HeaderText = "超时时间(h)";
            this.colTimeout.Name = "colTimeout";
            this.colTimeout.ReadOnly = true;
            this.colTimeout.Width = 120;
            // 
            // colCheckBasis
            // 
            this.colCheckBasis.FillWeight = 400F;
            this.colCheckBasis.HeaderText = "检查依据";
            this.colCheckBasis.Name = "colCheckBasis";
            this.colCheckBasis.ReadOnly = true;
            this.colCheckBasis.Width = 400;
            // 
            // cmenuDocTime
            // 
            this.cmenuDocTime.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenuDocTime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyCheckBasis});
            this.cmenuDocTime.Name = "cmenuDocTime";
            this.cmenuDocTime.Size = new System.Drawing.Size(243, 30);
            // 
            // mnuCopyCheckBasis
            // 
            this.mnuCopyCheckBasis.Name = "mnuCopyCheckBasis";
            this.mnuCopyCheckBasis.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopyCheckBasis.Size = new System.Drawing.Size(242, 26);
            this.mnuCopyCheckBasis.Text = "复制“检查依据”";
            this.mnuCopyCheckBasis.Click += new System.EventHandler(this.mnuCopyCheckBasis_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(788, 332);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 14;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(884, 332);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(78, 28);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(262, 332);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 28);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "按科室：";
            this.label1.Visible = false;
            // 
            // cboDept
            // 
            this.cboDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDept.DroppedDown = false;
            this.cboDept.Location = new System.Drawing.Point(87, 335);
            this.cboDept.Name = "cboDept";
            this.cboDept.SelectedItem = null;
            this.cboDept.Size = new System.Drawing.Size(169, 20);
            this.cboDept.TabIndex = 19;
            this.cboDept.Visible = false;
            // 
            // DocumentTimeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(964, 365);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "DocumentTimeForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "病历时效";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmenuDocTime.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmenuDocTime;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyCheckBasis;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckBasis;
    }
}