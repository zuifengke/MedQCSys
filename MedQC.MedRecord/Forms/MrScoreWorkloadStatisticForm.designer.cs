namespace Heren.MedQC.MedRecord
{
    partial class MrScoreWorkloadStatisticForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.cboUserList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.col_HOS_QCMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SUBMIT_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_VISIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HOS_ASSESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HOS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.col_HOS_QCMAN,
            this.colOrderNo,
            this.col_DEPT_NAME,
            this.col_SUBMIT_DOCTOR,
            this.col_PATIENT_NAME,
            this.col_PATIENT_ID,
            this.col_VISIT_ID,
            this.col_HOS_ASSESS,
            this.col_HOS_DATE});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(950, 366);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpTimeEnd.Location = new System.Drawing.Point(374, 13);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.Size = new System.Drawing.Size(121, 23);
            this.dtpTimeEnd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(351, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(779, 10);
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
            this.label1.Location = new System.Drawing.Point(162, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "检查时间";
            // 
            // dtpTimeBegin
            // 
            this.dtpTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpTimeBegin.Location = new System.Drawing.Point(228, 13);
            this.dtpTimeBegin.Name = "dtpTimeBegin";
            this.dtpTimeBegin.Size = new System.Drawing.Size(121, 23);
            this.dtpTimeBegin.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(865, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 15;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // cboUserList
            // 
            this.cboUserList.CandidateWidth = 200;
            this.cboUserList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboUserList.Location = new System.Drawing.Point(54, 13);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(105, 23);
            this.cboUserList.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(5, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "检查者";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboUserList);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.dtpTimeEnd);
            this.panel1.Controls.Add(this.dtpTimeBegin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 45);
            this.panel1.TabIndex = 31;
            // 
            // col_HOS_QCMAN
            // 
            this.col_HOS_QCMAN.DataPropertyName = "col_HOS_QCMAN";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_HOS_QCMAN.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_HOS_QCMAN.HeaderText = "检查者";
            this.col_HOS_QCMAN.Name = "col_HOS_QCMAN";
            this.col_HOS_QCMAN.ReadOnly = true;
            // 
            // colOrderNo
            // 
            this.colOrderNo.HeaderText = "序号";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            // 
            // col_DEPT_NAME
            // 
            this.col_DEPT_NAME.HeaderText = "病区";
            this.col_DEPT_NAME.Name = "col_DEPT_NAME";
            this.col_DEPT_NAME.ReadOnly = true;
            // 
            // col_SUBMIT_DOCTOR
            // 
            this.col_SUBMIT_DOCTOR.DataPropertyName = "NumOfDoc";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_SUBMIT_DOCTOR.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_SUBMIT_DOCTOR.HeaderText = "经治医生";
            this.col_SUBMIT_DOCTOR.Name = "col_SUBMIT_DOCTOR";
            this.col_SUBMIT_DOCTOR.ReadOnly = true;
            // 
            // col_PATIENT_NAME
            // 
            this.col_PATIENT_NAME.DataPropertyName = "NumOfQuestion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_PATIENT_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_PATIENT_NAME.HeaderText = "患者姓名";
            this.col_PATIENT_NAME.Name = "col_PATIENT_NAME";
            this.col_PATIENT_NAME.ReadOnly = true;
            // 
            // col_PATIENT_ID
            // 
            this.col_PATIENT_ID.DataPropertyName = "NumOfCheck";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.col_PATIENT_ID.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_PATIENT_ID.HeaderText = "患者ID号";
            this.col_PATIENT_ID.Name = "col_PATIENT_ID";
            this.col_PATIENT_ID.ReadOnly = true;
            // 
            // col_VISIT_ID
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_VISIT_ID.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_VISIT_ID.HeaderText = "入院次";
            this.col_VISIT_ID.Name = "col_VISIT_ID";
            this.col_VISIT_ID.ReadOnly = true;
            // 
            // col_HOS_ASSESS
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_HOS_ASSESS.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_HOS_ASSESS.HeaderText = "分数";
            this.col_HOS_ASSESS.Name = "col_HOS_ASSESS";
            this.col_HOS_ASSESS.ReadOnly = true;
            // 
            // col_HOS_DATE
            // 
            this.col_HOS_DATE.HeaderText = "检查时间";
            this.col_HOS_DATE.Name = "col_HOS_DATE";
            this.col_HOS_DATE.ReadOnly = true;
            this.col_HOS_DATE.Width = 120;
            // 
            // MrScoreWorkloadStatisticForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(950, 411);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "MrScoreWorkloadStatisticForm";
            this.Text = "病历评分工作量统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTimeBegin;
        private System.Windows.Forms.Button btnExportExcel;
        private Heren.Common.Controls.DictInput.FindComboBox cboUserList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HOS_QCMAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SUBMIT_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_VISIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HOS_ASSESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HOS_DATE;
    }
}