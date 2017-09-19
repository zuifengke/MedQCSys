namespace Heren.MedQC.Statistic
{
    partial class StatByQuestionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cboDoctor = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEventType = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStatTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStatTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.col_BED_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctorInCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPARENT_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQaEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckDataTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMsgStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateConfirmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_BED_CODE,
            this.colPatID,
            this.colPatName,
            this.colVisitID,
            this.colPatDeptName,
            this.colDoctorInCharge,
            this.colPARENT_DOCTOR,
            this.colQaEventType,
            this.colMessage,
            this.colCheckerName,
            this.colCheckDataTime,
            this.colMsgStatus,
            this.colDateConfirmed});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 468);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.cboDoctor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboEventType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpStatTimeEnd);
            this.panel1.Controls.Add(this.dtpStatTimeBegin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 60);
            this.panel1.TabIndex = 19;
            // 
            // cboDeptName
            // 
            this.cboDeptName.CandidateWidth = 200;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.Location = new System.Drawing.Point(72, 10);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(121, 23);
            this.cboDeptName.TabIndex = 17;
            this.cboDeptName.SelectedIndexChanged += new System.EventHandler(this.cboDeptName_SelectedIndexChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(854, 29);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 16;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(4, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "科室";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(937, 29);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(771, 29);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(80, 28);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboDoctor
            // 
            this.cboDoctor.CandidateWidth = 200;
            this.cboDoctor.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDoctor.Location = new System.Drawing.Point(267, 34);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(123, 23);
            this.cboDoctor.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "问题分类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(202, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "经治医师";
            // 
            // cboEventType
            // 
            this.cboEventType.CandidateWidth = 200;
            this.cboEventType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboEventType.Location = new System.Drawing.Point(72, 34);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.Size = new System.Drawing.Size(120, 23);
            this.cboEventType.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(391, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "至";
            // 
            // dtpStatTimeEnd
            // 
            this.dtpStatTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeEnd.Location = new System.Drawing.Point(413, 10);
            this.dtpStatTimeEnd.Name = "dtpStatTimeEnd";
            this.dtpStatTimeEnd.Size = new System.Drawing.Size(123, 23);
            this.dtpStatTimeEnd.TabIndex = 3;
            // 
            // dtpStatTimeBegin
            // 
            this.dtpStatTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeBegin.Location = new System.Drawing.Point(268, 10);
            this.dtpStatTimeBegin.Name = "dtpStatTimeBegin";
            this.dtpStatTimeBegin.Size = new System.Drawing.Size(120, 23);
            this.dtpStatTimeBegin.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(199, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "检查时间";
            // 
            // col_BED_CODE
            // 
            this.col_BED_CODE.HeaderText = "床号";
            this.col_BED_CODE.Name = "col_BED_CODE";
            this.col_BED_CODE.ReadOnly = true;
            this.col_BED_CODE.Width = 60;
            // 
            // colPatID
            // 
            this.colPatID.FillWeight = 80F;
            this.colPatID.HeaderText = "患者ID";
            this.colPatID.Name = "colPatID";
            this.colPatID.ReadOnly = true;
            this.colPatID.Width = 80;
            // 
            // colPatName
            // 
            this.colPatName.FillWeight = 88F;
            this.colPatName.HeaderText = "患者姓名";
            this.colPatName.Name = "colPatName";
            this.colPatName.ReadOnly = true;
            this.colPatName.Width = 88;
            // 
            // colVisitID
            // 
            this.colVisitID.FillWeight = 60F;
            this.colVisitID.HeaderText = "入院次";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            this.colVisitID.Width = 60;
            // 
            // colPatDeptName
            // 
            this.colPatDeptName.FillWeight = 130F;
            this.colPatDeptName.HeaderText = "所在科室";
            this.colPatDeptName.Name = "colPatDeptName";
            this.colPatDeptName.ReadOnly = true;
            this.colPatDeptName.Width = 130;
            // 
            // colDoctorInCharge
            // 
            this.colDoctorInCharge.HeaderText = "经治医师";
            this.colDoctorInCharge.Name = "colDoctorInCharge";
            this.colDoctorInCharge.ReadOnly = true;
            // 
            // colPARENT_DOCTOR
            // 
            this.colPARENT_DOCTOR.HeaderText = "上级医生";
            this.colPARENT_DOCTOR.Name = "colPARENT_DOCTOR";
            this.colPARENT_DOCTOR.ReadOnly = true;
            // 
            // colQaEventType
            // 
            this.colQaEventType.HeaderText = "质量问题分类";
            this.colQaEventType.Name = "colQaEventType";
            this.colQaEventType.ReadOnly = true;
            this.colQaEventType.Width = 120;
            // 
            // colMessage
            // 
            this.colMessage.FillWeight = 350F;
            this.colMessage.HeaderText = "质检问题描述";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.Width = 350;
            // 
            // colCheckerName
            // 
            this.colCheckerName.FillWeight = 88F;
            this.colCheckerName.HeaderText = "检查者";
            this.colCheckerName.Name = "colCheckerName";
            this.colCheckerName.ReadOnly = true;
            this.colCheckerName.Width = 88;
            // 
            // colCheckDataTime
            // 
            this.colCheckDataTime.FillWeight = 130F;
            this.colCheckDataTime.HeaderText = "检查日期";
            this.colCheckDataTime.Name = "colCheckDataTime";
            this.colCheckDataTime.ReadOnly = true;
            this.colCheckDataTime.Width = 130;
            // 
            // colMsgStatus
            // 
            this.colMsgStatus.FillWeight = 88F;
            this.colMsgStatus.HeaderText = "信息状态";
            this.colMsgStatus.Name = "colMsgStatus";
            this.colMsgStatus.ReadOnly = true;
            this.colMsgStatus.Width = 88;
            // 
            // colDateConfirmed
            // 
            this.colDateConfirmed.FillWeight = 130F;
            this.colDateConfirmed.HeaderText = "信息确认时间";
            this.colDateConfirmed.Name = "colDateConfirmed";
            this.colDateConfirmed.ReadOnly = true;
            this.colDateConfirmed.Width = 150;
            // 
            // StatByQuestionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1020, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "StatByQuestionForm";
            this.Text = "按质检问题统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStatTimeEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStatTimeBegin;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnQuery;
        private Heren.Common.Controls.DictInput.FindComboBox cboEventType;
        private Heren.Common.Controls.DictInput.FindComboBox cboDoctor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExportExcel;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_BED_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctorInCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPARENT_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckDataTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsgStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateConfirmed;
    }
}