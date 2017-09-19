namespace Heren.MedQC.Statistic
{
    partial class StatByCheckerForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpStatTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStatTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.cboUserList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deptStayedNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_BED_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionContentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorInchargeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deptStayedIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInpNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPARENT_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCheckedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateConfirmedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.deptStayedNameDataGridViewTextBoxColumn,
            this.col_BED_CODE,
            this.patientIDDataGridViewTextBoxColumn,
            this.patientNameDataGridViewTextBoxColumn,
            this.questionContentDataGridViewTextBoxColumn,
            this.doctorInchargeDataGridViewTextBoxColumn,
            this.deptStayedIDDataGridViewTextBoxColumn,
            this.colInpNO,
            this.colQaEventType,
            this.colPARENT_DOCTOR,
            this.checkerDataGridViewTextBoxColumn,
            this.dateCheckedDataGridViewTextBoxColumn,
            this.dateConfirmedDataGridViewTextBoxColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(977, 375);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(910, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 28);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtpStatTimeEnd
            // 
            this.dtpStatTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeEnd.Location = new System.Drawing.Point(379, 9);
            this.dtpStatTimeEnd.Name = "dtpStatTimeEnd";
            this.dtpStatTimeEnd.Size = new System.Drawing.Size(122, 23);
            this.dtpStatTimeEnd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(356, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "至";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(753, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 28);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(167, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "检查时间";
            // 
            // dtpStatTimeBegin
            // 
            this.dtpStatTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeBegin.Location = new System.Drawing.Point(232, 9);
            this.dtpStatTimeBegin.Name = "dtpStatTimeBegin";
            this.dtpStatTimeBegin.Size = new System.Drawing.Size(122, 23);
            this.dtpStatTimeBegin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(5, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "检查者";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(824, 6);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 14;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // cboUserList
            // 
            this.cboUserList.CandidateWidth = 200;
            this.cboUserList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboUserList.Location = new System.Drawing.Point(55, 10);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(105, 23);
            this.cboUserList.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboUserList);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpStatTimeBegin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpStatTimeEnd);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 42);
            this.panel1.TabIndex = 29;
            // 
            // deptStayedNameDataGridViewTextBoxColumn
            // 
            this.deptStayedNameDataGridViewTextBoxColumn.DataPropertyName = "DeptName";
            this.deptStayedNameDataGridViewTextBoxColumn.HeaderText = "科室";
            this.deptStayedNameDataGridViewTextBoxColumn.Name = "deptStayedNameDataGridViewTextBoxColumn";
            this.deptStayedNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // col_BED_CODE
            // 
            this.col_BED_CODE.HeaderText = "床号";
            this.col_BED_CODE.Name = "col_BED_CODE";
            this.col_BED_CODE.ReadOnly = true;
            this.col_BED_CODE.Width = 60;
            // 
            // patientIDDataGridViewTextBoxColumn
            // 
            this.patientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID";
            this.patientIDDataGridViewTextBoxColumn.FillWeight = 80F;
            this.patientIDDataGridViewTextBoxColumn.HeaderText = "患者ID";
            this.patientIDDataGridViewTextBoxColumn.Name = "patientIDDataGridViewTextBoxColumn";
            this.patientIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // patientNameDataGridViewTextBoxColumn
            // 
            this.patientNameDataGridViewTextBoxColumn.DataPropertyName = "PatientName";
            this.patientNameDataGridViewTextBoxColumn.FillWeight = 88F;
            this.patientNameDataGridViewTextBoxColumn.HeaderText = "患者姓名";
            this.patientNameDataGridViewTextBoxColumn.Name = "patientNameDataGridViewTextBoxColumn";
            this.patientNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientNameDataGridViewTextBoxColumn.Width = 88;
            // 
            // questionContentDataGridViewTextBoxColumn
            // 
            this.questionContentDataGridViewTextBoxColumn.DataPropertyName = "QuestionContent";
            this.questionContentDataGridViewTextBoxColumn.FillWeight = 350F;
            this.questionContentDataGridViewTextBoxColumn.HeaderText = "问题";
            this.questionContentDataGridViewTextBoxColumn.Name = "questionContentDataGridViewTextBoxColumn";
            this.questionContentDataGridViewTextBoxColumn.ReadOnly = true;
            this.questionContentDataGridViewTextBoxColumn.Width = 350;
            // 
            // doctorInchargeDataGridViewTextBoxColumn
            // 
            this.doctorInchargeDataGridViewTextBoxColumn.DataPropertyName = "DoctorInCharge";
            this.doctorInchargeDataGridViewTextBoxColumn.FillWeight = 88F;
            this.doctorInchargeDataGridViewTextBoxColumn.HeaderText = "经治医生";
            this.doctorInchargeDataGridViewTextBoxColumn.Name = "doctorInchargeDataGridViewTextBoxColumn";
            this.doctorInchargeDataGridViewTextBoxColumn.ReadOnly = true;
            this.doctorInchargeDataGridViewTextBoxColumn.Width = 88;
            // 
            // deptStayedIDDataGridViewTextBoxColumn
            // 
            this.deptStayedIDDataGridViewTextBoxColumn.DataPropertyName = "DeptCode";
            this.deptStayedIDDataGridViewTextBoxColumn.HeaderText = "所在科室ID";
            this.deptStayedIDDataGridViewTextBoxColumn.Name = "deptStayedIDDataGridViewTextBoxColumn";
            this.deptStayedIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deptStayedIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // colInpNO
            // 
            this.colInpNO.HeaderText = "病案号";
            this.colInpNO.Name = "colInpNO";
            this.colInpNO.ReadOnly = true;
            // 
            // colQaEventType
            // 
            this.colQaEventType.HeaderText = "问题类型";
            this.colQaEventType.Name = "colQaEventType";
            this.colQaEventType.ReadOnly = true;
            this.colQaEventType.Width = 200;
            // 
            // colPARENT_DOCTOR
            // 
            this.colPARENT_DOCTOR.HeaderText = "上级医生";
            this.colPARENT_DOCTOR.Name = "colPARENT_DOCTOR";
            this.colPARENT_DOCTOR.ReadOnly = true;
            // 
            // checkerDataGridViewTextBoxColumn
            // 
            this.checkerDataGridViewTextBoxColumn.DataPropertyName = "CheckerName";
            this.checkerDataGridViewTextBoxColumn.FillWeight = 80F;
            this.checkerDataGridViewTextBoxColumn.HeaderText = "检查者";
            this.checkerDataGridViewTextBoxColumn.Name = "checkerDataGridViewTextBoxColumn";
            this.checkerDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkerDataGridViewTextBoxColumn.Width = 80;
            // 
            // dateCheckedDataGridViewTextBoxColumn
            // 
            this.dateCheckedDataGridViewTextBoxColumn.DataPropertyName = "CheckTime";
            this.dateCheckedDataGridViewTextBoxColumn.FillWeight = 130F;
            this.dateCheckedDataGridViewTextBoxColumn.HeaderText = "检查日期";
            this.dateCheckedDataGridViewTextBoxColumn.Name = "dateCheckedDataGridViewTextBoxColumn";
            this.dateCheckedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCheckedDataGridViewTextBoxColumn.Width = 150;
            // 
            // dateConfirmedDataGridViewTextBoxColumn
            // 
            this.dateConfirmedDataGridViewTextBoxColumn.DataPropertyName = "ConfirmTime";
            this.dateConfirmedDataGridViewTextBoxColumn.HeaderText = "确认日期";
            this.dateConfirmedDataGridViewTextBoxColumn.Name = "dateConfirmedDataGridViewTextBoxColumn";
            this.dateConfirmedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateConfirmedDataGridViewTextBoxColumn.Width = 150;
            // 
            // StatByCheckerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(977, 417);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "StatByCheckerForm";
            this.Text = "按检查者统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpStatTimeEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStatTimeBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportExcel;
        private Heren.Common.Controls.DictInput.FindComboBox cboUserList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptStayedNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_BED_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionContentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorInchargeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptStayedIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInpNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPARENT_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheckedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateConfirmedDataGridViewTextBoxColumn;
    }
}