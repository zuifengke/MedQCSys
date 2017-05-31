namespace Heren.MedQC.Statistic
{
    partial class StatByDocScoreForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbbMrStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbScoreHigh = new System.Windows.Forms.ComboBox();
            this.cbbScoreLow = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbx = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocSetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctorInCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPARENT_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptAdmissionTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdmissionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptDischargeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDischargeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestionList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocChecker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMrStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chboxSimple = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbMrStatus
            // 
            this.cbbMrStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMrStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbMrStatus.FormattingEnabled = true;
            this.cbbMrStatus.Items.AddRange(new object[] {
            "全部",
            "已提交",
            "未提交"});
            this.cbbMrStatus.Location = new System.Drawing.Point(357, 9);
            this.cbbMrStatus.Name = "cbbMrStatus";
            this.cbbMrStatus.Size = new System.Drawing.Size(75, 22);
            this.cbbMrStatus.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(297, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "提交状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(593, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(457, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "病案得分";
            // 
            // cbbScoreHigh
            // 
            this.cbbScoreHigh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbScoreHigh.FormattingEnabled = true;
            this.cbbScoreHigh.Location = new System.Drawing.Point(621, 9);
            this.cbbScoreHigh.Name = "cbbScoreHigh";
            this.cbbScoreHigh.Size = new System.Drawing.Size(60, 22);
            this.cbbScoreHigh.TabIndex = 31;
            this.cbbScoreHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbScoreHigh_KeyPress);
            this.cbbScoreHigh.MouseLeave += new System.EventHandler(this.cbbScoreHigh_MouseLeave);
            // 
            // cbbScoreLow
            // 
            this.cbbScoreLow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbScoreLow.FormattingEnabled = true;
            this.cbbScoreLow.Location = new System.Drawing.Point(526, 9);
            this.cbbScoreLow.Name = "cbbScoreLow";
            this.cbbScoreLow.Size = new System.Drawing.Size(60, 22);
            this.cbbScoreLow.TabIndex = 30;
            this.cbbScoreLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbScoreLow_KeyPress);
            this.cbbScoreLow.MouseLeave += new System.EventHandler(this.cbbScoreLow_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(88, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "是否已评分";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(732, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbx
            // 
            this.cbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx.FormattingEnabled = true;
            this.cbx.Items.AddRange(new object[] {
            "全部",
            "已评分",
            "未评分"});
            this.cbx.Location = new System.Drawing.Point(170, 9);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(121, 22);
            this.cbx.TabIndex = 14;
            this.cbx.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnExport.Location = new System.Drawing.Point(816, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 28);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Excel导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(905, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatientID,
            this.colDocSetID,
            this.colPatName,
            this.colDoctorInCharge,
            this.colPARENT_DOCTOR,
            this.colDeptAdmissionTo,
            this.colAdmissionDate,
            this.colDeptDischargeFrom,
            this.colDischargeDate,
            this.colDocTime,
            this.colDocName,
            this.colQuestionList,
            this.colScore,
            this.colDocLevel,
            this.colDocChecker,
            this.colMrStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(988, 422);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // colPatID
            // 
            this.colPatientID.HeaderText = "患者ID";
            this.colPatientID.Name = "colPatID";
            this.colPatientID.ReadOnly = true;
            this.colPatientID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDocSetID
            // 
            this.colDocSetID.HeaderText = "colDocSetID";
            this.colDocSetID.Name = "colDocSetID";
            this.colDocSetID.ReadOnly = true;
            this.colDocSetID.Visible = false;
            // 
            // colPatName
            // 
            this.colPatName.HeaderText = "患者姓名";
            this.colPatName.Name = "colPatName";
            this.colPatName.ReadOnly = true;
            this.colPatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDoctorInCharge
            // 
            this.colDoctorInCharge.HeaderText = "经治医生";
            this.colDoctorInCharge.Name = "colDoctorInCharge";
            this.colDoctorInCharge.ReadOnly = true;
            // 
            // colPARENT_DOCTOR
            // 
            this.colPARENT_DOCTOR.HeaderText = "上级医生";
            this.colPARENT_DOCTOR.Name = "colPARENT_DOCTOR";
            this.colPARENT_DOCTOR.ReadOnly = true;
            // 
            // colDeptAdmissionTo
            // 
            this.colDeptAdmissionTo.FillWeight = 120F;
            this.colDeptAdmissionTo.HeaderText = "入院科室";
            this.colDeptAdmissionTo.Name = "colDeptAdmissionTo";
            this.colDeptAdmissionTo.ReadOnly = true;
            this.colDeptAdmissionTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeptAdmissionTo.Width = 120;
            // 
            // colAdmissionDate
            // 
            this.colAdmissionDate.FillWeight = 160F;
            this.colAdmissionDate.HeaderText = "入院时间";
            this.colAdmissionDate.Name = "colAdmissionDate";
            this.colAdmissionDate.ReadOnly = true;
            this.colAdmissionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAdmissionDate.Width = 90;
            // 
            // colDeptDischargeFrom
            // 
            this.colDeptDischargeFrom.FillWeight = 120F;
            this.colDeptDischargeFrom.HeaderText = "出院科室";
            this.colDeptDischargeFrom.Name = "colDeptDischargeFrom";
            this.colDeptDischargeFrom.ReadOnly = true;
            this.colDeptDischargeFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeptDischargeFrom.Visible = false;
            this.colDeptDischargeFrom.Width = 120;
            // 
            // colDischargeDate
            // 
            this.colDischargeDate.FillWeight = 120F;
            this.colDischargeDate.HeaderText = "出院时间";
            this.colDischargeDate.Name = "colDischargeDate";
            this.colDischargeDate.ReadOnly = true;
            this.colDischargeDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDischargeDate.Visible = false;
            this.colDischargeDate.Width = 90;
            // 
            // colDocTime
            // 
            this.colDocTime.FillWeight = 160F;
            this.colDocTime.HeaderText = "病历创建时间";
            this.colDocTime.Name = "colDocTime";
            this.colDocTime.ReadOnly = true;
            this.colDocTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDocTime.Visible = false;
            this.colDocTime.Width = 160;
            // 
            // colDocName
            // 
            this.colDocName.FillWeight = 150F;
            this.colDocName.HeaderText = "问题病历";
            this.colDocName.Name = "colDocName";
            this.colDocName.ReadOnly = true;
            this.colDocName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDocName.Width = 150;
            // 
            // colQuestionList
            // 
            this.colQuestionList.FillWeight = 180F;
            this.colQuestionList.HeaderText = "问题汇总";
            this.colQuestionList.Name = "colQuestionList";
            this.colQuestionList.ReadOnly = true;
            this.colQuestionList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuestionList.Width = 180;
            // 
            // colScore
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colScore.DefaultCellStyle = dataGridViewCellStyle2;
            this.colScore.HeaderText = "病案得分";
            this.colScore.Name = "colScore";
            this.colScore.ReadOnly = true;
            this.colScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colScore.Width = 70;
            // 
            // colDocLevel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDocLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDocLevel.HeaderText = "病历等级";
            this.colDocLevel.Name = "colDocLevel";
            this.colDocLevel.ReadOnly = true;
            this.colDocLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDocLevel.Width = 70;
            // 
            // colDocChecker
            // 
            this.colDocChecker.HeaderText = "检查者";
            this.colDocChecker.Name = "colDocChecker";
            this.colDocChecker.ReadOnly = true;
            this.colDocChecker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMrStatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMrStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.colMrStatus.HeaderText = "提交状态";
            this.colMrStatus.Name = "colMrStatus";
            this.colMrStatus.ReadOnly = true;
            this.colMrStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMrStatus.Width = 70;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.chboxSimple);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.cbbMrStatus);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.cbbScoreLow);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbx);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbScoreHigh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 36);
            this.panel1.TabIndex = 36;
            // 
            // chboxSimple
            // 
            this.chboxSimple.AutoSize = true;
            this.chboxSimple.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chboxSimple.Location = new System.Drawing.Point(3, 11);
            this.chboxSimple.Name = "chboxSimple";
            this.chboxSimple.Size = new System.Drawing.Size(82, 18);
            this.chboxSimple.TabIndex = 36;
            this.chboxSimple.Text = "扣分详情";
            this.chboxSimple.UseVisualStyleBackColor = true;
            // 
            // StatByDocScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 458);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "StatByDocScoreForm";
            this.Text = "病案评分一览表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbx;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbScoreLow;
        private System.Windows.Forms.ComboBox cbbScoreHigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbMrStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chboxSimple;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMrStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocChecker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDischargeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptDischargeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdmissionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptAdmissionTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPARENT_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctorInCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocSetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
    }
}