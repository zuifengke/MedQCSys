namespace Heren.MedQC.Statistic
{
    partial class StatByDeptForm
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
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Dept_NameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_BED_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docInChargeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQCEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInpNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentDotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Dept_NameDataGridViewTextBoxColumn,
            this.col_BED_CODE,
            this.patientIDDataGridViewTextBoxColumn,
            this.patientNameDataGridViewTextBoxColumn,
            this.msgDataGridViewTextBoxColumn,
            this.docInChargeDataGridViewTextBoxColumn,
            this.colQCEventType,
            this.colVisitID,
            this.colInpNO,
            this.colParentDotor,
            this.checkerDataGridViewTextBoxColumn,
            this.dateCheckedDataGridViewTextBoxColumn,
            this.dateConfirmedDataGridViewTextBoxColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(917, 379);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(846, 6);
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
            this.dtpStatTimeEnd.Location = new System.Drawing.Point(383, 9);
            this.dtpStatTimeEnd.Name = "dtpStatTimeEnd";
            this.dtpStatTimeEnd.Size = new System.Drawing.Size(120, 23);
            this.dtpStatTimeEnd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(359, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "至";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(688, 6);
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
            this.label1.Location = new System.Drawing.Point(170, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "检查时间";
            // 
            // dtpStatTimeBegin
            // 
            this.dtpStatTimeBegin.CustomFormat = "";
            this.dtpStatTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpStatTimeBegin.Location = new System.Drawing.Point(236, 9);
            this.dtpStatTimeBegin.Name = "dtpStatTimeBegin";
            this.dtpStatTimeBegin.Size = new System.Drawing.Size(121, 23);
            this.dtpStatTimeBegin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(1, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "科室";
            // 
            // cboDeptName
            // 
            this.cboDeptName.CandidateWidth = 200;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.Location = new System.Drawing.Point(39, 9);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(129, 23);
            this.cboDeptName.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(759, 6);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 14;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.dtpStatTimeBegin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpStatTimeEnd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 39);
            this.panel1.TabIndex = 15;
            // 
            // Dept_NameDataGridViewTextBoxColumn
            // 
            this.Dept_NameDataGridViewTextBoxColumn.HeaderText = "科室";
            this.Dept_NameDataGridViewTextBoxColumn.Name = "Dept_NameDataGridViewTextBoxColumn";
            this.Dept_NameDataGridViewTextBoxColumn.ReadOnly = true;
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
            // msgDataGridViewTextBoxColumn
            // 
            this.msgDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.msgDataGridViewTextBoxColumn.FillWeight = 350F;
            this.msgDataGridViewTextBoxColumn.HeaderText = "问题";
            this.msgDataGridViewTextBoxColumn.Name = "msgDataGridViewTextBoxColumn";
            this.msgDataGridViewTextBoxColumn.ReadOnly = true;
            this.msgDataGridViewTextBoxColumn.Width = 350;
            // 
            // docInChargeDataGridViewTextBoxColumn
            // 
            this.docInChargeDataGridViewTextBoxColumn.DataPropertyName = "DoctorInCharge";
            this.docInChargeDataGridViewTextBoxColumn.FillWeight = 88F;
            this.docInChargeDataGridViewTextBoxColumn.HeaderText = "经治医生";
            this.docInChargeDataGridViewTextBoxColumn.Name = "docInChargeDataGridViewTextBoxColumn";
            this.docInChargeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docInChargeDataGridViewTextBoxColumn.Width = 88;
            // 
            // colQCEventType
            // 
            this.colQCEventType.HeaderText = "问题类型";
            this.colQCEventType.Name = "colQCEventType";
            this.colQCEventType.ReadOnly = true;
            // 
            // colVisitID
            // 
            this.colVisitID.HeaderText = "入院次";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            // 
            // colInpNO
            // 
            this.colInpNO.HeaderText = "病案号";
            this.colInpNO.Name = "colInpNO";
            this.colInpNO.ReadOnly = true;
            // 
            // colParentDotor
            // 
            this.colParentDotor.HeaderText = "上级医生";
            this.colParentDotor.Name = "colParentDotor";
            this.colParentDotor.ReadOnly = true;
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
            this.dateConfirmedDataGridViewTextBoxColumn.FillWeight = 130F;
            this.dateConfirmedDataGridViewTextBoxColumn.HeaderText = "确认日期";
            this.dateConfirmedDataGridViewTextBoxColumn.Name = "dateConfirmedDataGridViewTextBoxColumn";
            this.dateConfirmedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateConfirmedDataGridViewTextBoxColumn.Width = 150;
            // 
            // StatByDeptForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(917, 418);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "StatByDeptForm";
            this.Text = "按科室统计";
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
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept_NameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_BED_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docInChargeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInpNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentDotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCheckedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateConfirmedDataGridViewTextBoxColumn;
    }
}