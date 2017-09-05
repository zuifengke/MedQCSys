namespace Heren.MedQC.Statistic
{
    partial class StatByJobDetailForm
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
            this.cboUserList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpStatTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStatTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colCheckName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInpNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPARENT_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuperDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboUserList
            // 
            this.cboUserList.CandidateWidth = 200;
            this.cboUserList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboUserList.Location = new System.Drawing.Point(57, 9);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(105, 23);
            this.cboUserList.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "检查者";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(971, 7);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 15;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(1062, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtpStatTimeEnd
            // 
            this.dtpStatTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeEnd.Location = new System.Drawing.Point(377, 10);
            this.dtpStatTimeEnd.Name = "dtpStatTimeEnd";
            this.dtpStatTimeEnd.Size = new System.Drawing.Size(121, 23);
            this.dtpStatTimeEnd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(354, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(885, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(80, 28);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(165, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "检查时间";
            // 
            // dtpStatTimeBegin
            // 
            this.dtpStatTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeBegin.Location = new System.Drawing.Point(231, 10);
            this.dtpStatTimeBegin.Name = "dtpStatTimeBegin";
            this.dtpStatTimeBegin.Size = new System.Drawing.Size(121, 23);
            this.dtpStatTimeBegin.TabIndex = 0;
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
            this.colCheckName,
            this.colDeptName,
            this.colPatientID,
            this.colPatientName,
            this.colRequestDoctor,
            this.colVisitID,
            this.colInpNO,
            this.colDiagnosis,
            this.colPARENT_DOCTOR,
            this.colSuperDoctor,
            this.colTopic,
            this.colQaEventType,
            this.colContent,
            this.colLogDesc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 357);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboUserList);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dtpStatTimeEnd);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpStatTimeBegin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 39);
            this.panel1.TabIndex = 31;
            // 
            // colCheckName
            // 
            this.colCheckName.HeaderText = "检查者";
            this.colCheckName.Name = "colCheckName";
            this.colCheckName.ReadOnly = true;
            // 
            // colDeptName
            // 
            this.colDeptName.HeaderText = "科室";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.Width = 120;
            // 
            // colPatientID
            // 
            this.colPatientID.HeaderText = "患者ID";
            this.colPatientID.Name = "colPatientID";
            this.colPatientID.ReadOnly = true;
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "患者姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            // 
            // colRequestDoctor
            // 
            this.colRequestDoctor.HeaderText = "经治医生";
            this.colRequestDoctor.Name = "colRequestDoctor";
            this.colRequestDoctor.ReadOnly = true;
            // 
            // colVisitID
            // 
            this.colVisitID.HeaderText = "入院次";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            this.colVisitID.Width = 80;
            // 
            // colInpNO
            // 
            this.colInpNO.HeaderText = "病案号";
            this.colInpNO.Name = "colInpNO";
            this.colInpNO.ReadOnly = true;
            this.colInpNO.Visible = false;
            // 
            // colDiagnosis
            // 
            this.colDiagnosis.HeaderText = "诊断";
            this.colDiagnosis.Name = "colDiagnosis";
            this.colDiagnosis.ReadOnly = true;
            this.colDiagnosis.Visible = false;
            // 
            // colPARENT_DOCTOR
            // 
            this.colPARENT_DOCTOR.HeaderText = "上级医生";
            this.colPARENT_DOCTOR.Name = "colPARENT_DOCTOR";
            this.colPARENT_DOCTOR.ReadOnly = true;
            this.colPARENT_DOCTOR.Visible = false;
            // 
            // colSuperDoctor
            // 
            this.colSuperDoctor.HeaderText = "科主任";
            this.colSuperDoctor.Name = "colSuperDoctor";
            this.colSuperDoctor.ReadOnly = true;
            this.colSuperDoctor.Visible = false;
            // 
            // colTopic
            // 
            this.colTopic.HeaderText = "病历标题";
            this.colTopic.Name = "colTopic";
            this.colTopic.ReadOnly = true;
            // 
            // colQaEventType
            // 
            this.colQaEventType.HeaderText = "问题类型";
            this.colQaEventType.Name = "colQaEventType";
            this.colQaEventType.ReadOnly = true;
            // 
            // colContent
            // 
            this.colContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colContent.HeaderText = "主要问题记录";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            this.colContent.Width = 280;
            // 
            // colLogDesc
            // 
            this.colLogDesc.HeaderText = "工作记录描述";
            this.colLogDesc.Name = "colLogDesc";
            this.colLogDesc.ReadOnly = true;
            this.colLogDesc.Width = 150;
            // 
            // StatByJobDetailForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1145, 396);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "StatByJobDetailForm";
            this.Text = "工作详细内容统计";
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
        private System.Windows.Forms.Button btnExportExcel;
        private Heren.Common.Controls.DictInput.FindComboBox cboUserList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInpNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPARENT_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuperDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogDesc;
    }
}