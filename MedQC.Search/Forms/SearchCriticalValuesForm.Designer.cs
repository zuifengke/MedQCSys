namespace Heren.MedQC.Search.Forms
{
    partial class SearchCriticalValuesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CREATOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDischargeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DOC_TITLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DOC_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RECORD_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnDischargeTime = new System.Windows.Forms.RadioButton();
            this.rbtnRecordTime = new System.Windows.Forms.RadioButton();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dtpStatTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpStatTimeEnd = new System.Windows.Forms.DateTimePicker();
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeptName,
            this.col_CREATOR_NAME,
            this.colPatientName,
            this.colPatientID,
            this.colVisitTime,
            this.colDischargeTime,
            this.col_DOC_TITLE,
            this.col_DOC_TIME,
            this.col_RECORD_TIME});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 314);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // colDeptName
            // 
            this.colDeptName.HeaderText = "科室";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.Width = 140;
            // 
            // col_CREATOR_NAME
            // 
            this.col_CREATOR_NAME.HeaderText = "创建人";
            this.col_CREATOR_NAME.Name = "col_CREATOR_NAME";
            this.col_CREATOR_NAME.Width = 90;
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "患者姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.Width = 90;
            // 
            // colPatientID
            // 
            this.colPatientID.HeaderText = "患者ID号";
            this.colPatientID.Name = "colPatientID";
            // 
            // colVisitTime
            // 
            this.colVisitTime.HeaderText = "入院时间";
            this.colVisitTime.Name = "colVisitTime";
            this.colVisitTime.Width = 120;
            // 
            // colDischargeTime
            // 
            this.colDischargeTime.HeaderText = "出院时间";
            this.colDischargeTime.Name = "colDischargeTime";
            this.colDischargeTime.Width = 120;
            // 
            // col_DOC_TITLE
            // 
            this.col_DOC_TITLE.HeaderText = "病历标题";
            this.col_DOC_TITLE.Name = "col_DOC_TITLE";
            this.col_DOC_TITLE.Width = 200;
            // 
            // col_DOC_TIME
            // 
            this.col_DOC_TIME.HeaderText = "创建时间";
            this.col_DOC_TIME.Name = "col_DOC_TIME";
            this.col_DOC_TIME.Width = 120;
            // 
            // col_RECORD_TIME
            // 
            this.col_RECORD_TIME.HeaderText = "记录时间";
            this.col_RECORD_TIME.Name = "col_RECORD_TIME";
            this.col_RECORD_TIME.Width = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnDischargeTime);
            this.panel1.Controls.Add(this.rbtnRecordTime);
            this.panel1.Controls.Add(this.txtDocType);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.dtpStatTimeBegin);
            this.panel1.Controls.Add(this.dtpStatTimeEnd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 55);
            this.panel1.TabIndex = 10;
            // 
            // rbtnDischargeTime
            // 
            this.rbtnDischargeTime.AutoSize = true;
            this.rbtnDischargeTime.Checked = true;
            this.rbtnDischargeTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnDischargeTime.Location = new System.Drawing.Point(139, 33);
            this.rbtnDischargeTime.Name = "rbtnDischargeTime";
            this.rbtnDischargeTime.Size = new System.Drawing.Size(81, 18);
            this.rbtnDischargeTime.TabIndex = 11;
            this.rbtnDischargeTime.TabStop = true;
            this.rbtnDischargeTime.Text = "出院时间";
            this.rbtnDischargeTime.UseVisualStyleBackColor = true;
            // 
            // rbtnRecordTime
            // 
            this.rbtnRecordTime.AutoSize = true;
            this.rbtnRecordTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnRecordTime.Location = new System.Drawing.Point(12, 33);
            this.rbtnRecordTime.Name = "rbtnRecordTime";
            this.rbtnRecordTime.Size = new System.Drawing.Size(109, 18);
            this.rbtnRecordTime.TabIndex = 11;
            this.rbtnRecordTime.Text = "病历记录时间";
            this.rbtnRecordTime.UseVisualStyleBackColor = true;
            // 
            // txtDocType
            // 
            this.txtDocType.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDocType.Location = new System.Drawing.Point(255, 6);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.ReadOnly = true;
            this.txtDocType.Size = new System.Drawing.Size(309, 21);
            this.txtDocType.TabIndex = 10;
            // 
            // cboDeptName
            // 
            this.cboDeptName.CandidateWidth = 200;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.Location = new System.Drawing.Point(42, 6);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(129, 23);
            this.cboDeptName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(349, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "科室";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(930, 24);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 8;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(185, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "病历名称";
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(858, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 28);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtpStatTimeBegin
            // 
            this.dtpStatTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeBegin.Location = new System.Drawing.Point(227, 29);
            this.dtpStatTimeBegin.Name = "dtpStatTimeBegin";
            this.dtpStatTimeBegin.Size = new System.Drawing.Size(121, 23);
            this.dtpStatTimeBegin.TabIndex = 4;
            // 
            // dtpStatTimeEnd
            // 
            this.dtpStatTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpStatTimeEnd.Location = new System.Drawing.Point(374, 29);
            this.dtpStatTimeEnd.Name = "dtpStatTimeEnd";
            this.dtpStatTimeEnd.Size = new System.Drawing.Size(121, 23);
            this.dtpStatTimeEnd.TabIndex = 6;
            // 
            // SearchCriticalValuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 369);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SearchCriticalValuesForm";
            this.Text = "危急值患者查询";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.DateTimePicker dtpStatTimeBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStatTimeEnd;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocType;
        private System.Windows.Forms.RadioButton rbtnRecordTime;
        private System.Windows.Forms.RadioButton rbtnDischargeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CREATOR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDischargeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DOC_TITLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DOC_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RECORD_TIME;
    }
}