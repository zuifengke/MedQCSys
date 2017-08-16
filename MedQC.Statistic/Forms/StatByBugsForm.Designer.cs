namespace Heren.MedQC.Statistic
{
    partial class StatByBugsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestionContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctorInCharege = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPARENT_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfirmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkContentCheck = new System.Windows.Forms.CheckBox();
            this.chkTimeCheck = new System.Windows.Forms.CheckBox();
            this.dtpStatTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.cboMsgStatus = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dtpStatTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeptName,
            this.colPatientID,
            this.colVisitID,
            this.colPatientName,
            this.colQuestionType,
            this.colQuestionContent,
            this.colQuestionStatus,
            this.colQuestionCount,
            this.colCheckName,
            this.colCheckTime,
            this.colDoctorInCharege,
            this.colPARENT_DOCTOR,
            this.colConfirmDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 427);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // colDeptName
            // 
            this.colDeptName.DataPropertyName = "DeptName";
            this.colDeptName.FillWeight = 130F;
            this.colDeptName.HeaderText = "科室";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeptName.Width = 130;
            // 
            // colPatientID
            // 
            this.colPatientID.DataPropertyName = "PatientID";
            this.colPatientID.FillWeight = 80F;
            this.colPatientID.HeaderText = "患者ID号";
            this.colPatientID.Name = "colPatientID";
            this.colPatientID.ReadOnly = true;
            this.colPatientID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPatientID.Width = 80;
            // 
            // colVisitID
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colVisitID.DefaultCellStyle = dataGridViewCellStyle1;
            this.colVisitID.FillWeight = 60F;
            this.colVisitID.HeaderText = "入院次";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            this.colVisitID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVisitID.Width = 60;
            // 
            // colPatientName
            // 
            this.colPatientName.DataPropertyName = "PatientName";
            this.colPatientName.FillWeight = 88F;
            this.colPatientName.HeaderText = "患者姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            this.colPatientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPatientName.Width = 80;
            // 
            // colQuestionType
            // 
            this.colQuestionType.FillWeight = 150F;
            this.colQuestionType.HeaderText = "问题类型";
            this.colQuestionType.Name = "colQuestionType";
            this.colQuestionType.ReadOnly = true;
            this.colQuestionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuestionType.Width = 120;
            // 
            // colQuestionContent
            // 
            this.colQuestionContent.DataPropertyName = "QuestionContent";
            this.colQuestionContent.FillWeight = 300F;
            this.colQuestionContent.HeaderText = "问题";
            this.colQuestionContent.Name = "colQuestionContent";
            this.colQuestionContent.ReadOnly = true;
            this.colQuestionContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuestionContent.Width = 200;
            // 
            // colQuestionStatus
            // 
            this.colQuestionStatus.HeaderText = "问题状态";
            this.colQuestionStatus.Name = "colQuestionStatus";
            this.colQuestionStatus.ReadOnly = true;
            this.colQuestionStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuestionStatus.Width = 90;
            // 
            // colQuestionCount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQuestionCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQuestionCount.FillWeight = 88F;
            this.colQuestionCount.HeaderText = "检查例数";
            this.colQuestionCount.Name = "colQuestionCount";
            this.colQuestionCount.ReadOnly = true;
            this.colQuestionCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuestionCount.Width = 80;
            // 
            // colCheckName
            // 
            this.colCheckName.DataPropertyName = "CheckerName";
            this.colCheckName.FillWeight = 88F;
            this.colCheckName.HeaderText = "检查者";
            this.colCheckName.Name = "colCheckName";
            this.colCheckName.ReadOnly = true;
            this.colCheckName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCheckName.Width = 88;
            // 
            // colCheckTime
            // 
            this.colCheckTime.DataPropertyName = "CheckTime";
            this.colCheckTime.FillWeight = 150F;
            this.colCheckTime.HeaderText = "检查时间";
            this.colCheckTime.Name = "colCheckTime";
            this.colCheckTime.ReadOnly = true;
            this.colCheckTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCheckTime.Width = 150;
            // 
            // colDoctorInCharege
            // 
            this.colDoctorInCharege.DataPropertyName = "colDoctorInCharege";
            this.colDoctorInCharege.FillWeight = 88F;
            this.colDoctorInCharege.HeaderText = "经治医生";
            this.colDoctorInCharege.Name = "colDoctorInCharege";
            this.colDoctorInCharege.ReadOnly = true;
            this.colDoctorInCharege.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDoctorInCharege.Width = 88;
            // 
            // colPARENT_DOCTOR
            // 
            this.colPARENT_DOCTOR.HeaderText = "上级医生";
            this.colPARENT_DOCTOR.Name = "colPARENT_DOCTOR";
            this.colPARENT_DOCTOR.ReadOnly = true;
            this.colPARENT_DOCTOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colConfirmDate
            // 
            this.colConfirmDate.DataPropertyName = "ConfirmTime";
            this.colConfirmDate.FillWeight = 150F;
            this.colConfirmDate.HeaderText = "确认日期";
            this.colConfirmDate.Name = "colConfirmDate";
            this.colConfirmDate.ReadOnly = true;
            this.colConfirmDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConfirmDate.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkContentCheck);
            this.panel1.Controls.Add(this.chkTimeCheck);
            this.panel1.Controls.Add(this.dtpStatTimeBegin);
            this.panel1.Controls.Add(this.cboMsgStatus);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.dtpStatTimeEnd);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 70);
            this.panel1.TabIndex = 30;
            // 
            // chkContentCheck
            // 
            this.chkContentCheck.AutoSize = true;
            this.chkContentCheck.Location = new System.Drawing.Point(265, 46);
            this.chkContentCheck.Name = "chkContentCheck";
            this.chkContentCheck.Size = new System.Drawing.Size(82, 18);
            this.chkContentCheck.TabIndex = 29;
            this.chkContentCheck.Text = "内容检查";
            this.chkContentCheck.UseVisualStyleBackColor = true;
            // 
            // chkTimeCheck
            // 
            this.chkTimeCheck.AutoSize = true;
            this.chkTimeCheck.Location = new System.Drawing.Point(180, 46);
            this.chkTimeCheck.Name = "chkTimeCheck";
            this.chkTimeCheck.Size = new System.Drawing.Size(82, 18);
            this.chkTimeCheck.TabIndex = 29;
            this.chkTimeCheck.Text = "时效检查";
            this.chkTimeCheck.UseVisualStyleBackColor = true;
            // 
            // dtpStatTimeBegin
            // 
            this.dtpStatTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeBegin.Location = new System.Drawing.Point(244, 12);
            this.dtpStatTimeBegin.Name = "dtpStatTimeBegin";
            this.dtpStatTimeBegin.Size = new System.Drawing.Size(120, 23);
            this.dtpStatTimeBegin.TabIndex = 0;
            // 
            // cboMsgStatus
            // 
            this.cboMsgStatus.CandidateWidth = 200;
            this.cboMsgStatus.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboMsgStatus.Items.AddRange(new object[] {
            "",
            "未接收",
            "已修改",
            "合格"});
            this.cboMsgStatus.Location = new System.Drawing.Point(71, 41);
            this.cboMsgStatus.Name = "cboMsgStatus";
            this.cboMsgStatus.Size = new System.Drawing.Size(99, 23);
            this.cboMsgStatus.TabIndex = 26;
            // 
            // cboDeptName
            // 
            this.cboDeptName.CandidateWidth = 200;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.Location = new System.Drawing.Point(41, 12);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(129, 23);
            this.cboDeptName.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(2, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "问题状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(177, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "检查时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "科室";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(796, 35);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 28);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(367, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(867, 35);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dtpStatTimeEnd
            // 
            this.dtpStatTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeEnd.Location = new System.Drawing.Point(391, 12);
            this.dtpStatTimeEnd.Name = "dtpStatTimeEnd";
            this.dtpStatTimeEnd.Size = new System.Drawing.Size(120, 23);
            this.dtpStatTimeEnd.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(951, 35);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 28);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // StatByBugsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1020, 497);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "StatByBugsForm";
            this.Text = "检查问题清单";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStatTimeBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStatTimeEnd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTimeCheck;
        private System.Windows.Forms.CheckBox chkContentCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfirmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPARENT_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctorInCharege;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Heren.Common.Controls.DictInput.FindComboBox cboMsgStatus;
    }
}