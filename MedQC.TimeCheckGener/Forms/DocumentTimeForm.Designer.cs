namespace Heren.MedQC.TimeCheckGener
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
            this.colDocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctorInCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckBasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmenuDocTime = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopyCheckBasis = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVisitID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.colDocName,
            this.colDoctorInCharge,
            this.colCreateTime,
            this.colStatus,
            this.colCreator,
            this.colEndTime,
            this.colLeave,
            this.colCheckBasis,
            this.colDocTypeID});
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(870, 406);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "病人";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            // 
            // colDocName
            // 
            this.colDocName.FillWeight = 120F;
            this.colDocName.HeaderText = "病历标题";
            this.colDocName.Name = "colDocName";
            this.colDocName.ReadOnly = true;
            this.colDocName.Width = 120;
            // 
            // colDoctorInCharge
            // 
            this.colDoctorInCharge.HeaderText = "责任医生";
            this.colDoctorInCharge.Name = "colDoctorInCharge";
            this.colDoctorInCharge.ReadOnly = true;
            // 
            // colCreateTime
            // 
            this.colCreateTime.FillWeight = 120F;
            this.colCreateTime.HeaderText = "书写时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 120;
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
            // colEndTime
            // 
            this.colEndTime.FillWeight = 124F;
            this.colEndTime.HeaderText = "截止时间";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Width = 124;
            // 
            // colLeave
            // 
            this.colLeave.HeaderText = "剩余时间(h)";
            this.colLeave.Name = "colLeave";
            this.colLeave.ReadOnly = true;
            this.colLeave.Width = 120;
            // 
            // colCheckBasis
            // 
            this.colCheckBasis.FillWeight = 400F;
            this.colCheckBasis.HeaderText = "检查依据";
            this.colCheckBasis.Name = "colCheckBasis";
            this.colCheckBasis.ReadOnly = true;
            this.colCheckBasis.Width = 400;
            // 
            // colDocTypeID
            // 
            this.colDocTypeID.HeaderText = "病历模板ID";
            this.colDocTypeID.Name = "colDocTypeID";
            this.colDocTypeID.ReadOnly = true;
            this.colDocTypeID.Width = 150;
            // 
            // cmenuDocTime
            // 
            this.cmenuDocTime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyCheckBasis});
            this.cmenuDocTime.Name = "cmenuDocTime";
            this.cmenuDocTime.Size = new System.Drawing.Size(204, 26);
            // 
            // mnuCopyCheckBasis
            // 
            this.mnuCopyCheckBasis.Name = "mnuCopyCheckBasis";
            this.mnuCopyCheckBasis.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopyCheckBasis.Size = new System.Drawing.Size(203, 22);
            this.mnuCopyCheckBasis.Text = "复制“检查依据”";
            this.mnuCopyCheckBasis.Click += new System.EventHandler(this.mnuCopyCheckBasis_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(458, 415);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 28);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "病案号：";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPatientID.Location = new System.Drawing.Point(70, 419);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(138, 23);
            this.txtPatientID.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "就诊号：";
            // 
            // txtVisitID
            // 
            this.txtVisitID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVisitID.Location = new System.Drawing.Point(291, 419);
            this.txtVisitID.Name = "txtVisitID";
            this.txtVisitID.Size = new System.Drawing.Size(138, 23);
            this.txtVisitID.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(542, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 28);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DocumentTimeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(875, 449);
            this.Controls.Add(this.txtVisitID);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "DocumentTimeForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "病历时效检查测试窗口";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmenuDocTime.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmenuDocTime;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyCheckBasis;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckBasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctorInCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.Button btnSave;
    }
}