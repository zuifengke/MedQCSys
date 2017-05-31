namespace Heren.MedQC.MedRecord
{
    partial class MrArchiveTableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.cboMrStatus = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel2 = new Heren.Common.Forms.XLabel();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel1 = new Heren.Common.Forms.XLabel();
            this.col_DEPT_ADMISSION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_VISIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ADMISSION_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DISCHARGE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MR_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SUBMIT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ARCHIVE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTimeType = new System.Windows.Forms.ComboBox();
            this.dtTimeEnd = new Heren.Common.Forms.XDateTime();
            this.dtTimeBegin = new Heren.Common.Forms.XDateTime();
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTableView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataTableView1.ColumnHeadersHeight = 20;
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_DEPT_ADMISSION_NAME,
            this.col_1_PATIENT_NAME,
            this.col_PATIENT_ID,
            this.col_VISIT_ID,
            this.col_ADMISSION_DATE_TIME,
            this.col_DISCHARGE_DATE_TIME,
            this.col_MR_STATUS,
            this.col_SUBMIT_TIME,
            this.col_ARCHIVE_TIME});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 32);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(1354, 477);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboTimeType);
            this.panel1.Controls.Add(this.dtTimeEnd);
            this.panel1.Controls.Add(this.dtTimeBegin);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cboMrStatus);
            this.panel1.Controls.Add(this.xLabel2);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(735, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboMrStatus
            // 
            this.cboMrStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboMrStatus.Items.AddRange(new object[] {
            "全部",
            "未提交",
            "已提交",
            "已归档"});
            this.cboMrStatus.Location = new System.Drawing.Point(643, 6);
            this.cboMrStatus.Name = "cboMrStatus";
            this.cboMrStatus.Size = new System.Drawing.Size(81, 21);
            this.cboMrStatus.TabIndex = 3;
            this.cboMrStatus.Text = "全部";
            // 
            // xLabel2
            // 
            this.xLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel2.Location = new System.Drawing.Point(565, 9);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(77, 14);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "病案状态：";
            // 
            // cboDeptName
            // 
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDeptName.Location = new System.Drawing.Point(76, 6);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(150, 21);
            this.cboDeptName.TabIndex = 3;
            // 
            // xLabel1
            // 
            this.xLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel1.Location = new System.Drawing.Point(4, 9);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(77, 14);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "出院科室：";
            // 
            // col_DEPT_ADMISSION_NAME
            // 
            this.col_DEPT_ADMISSION_NAME.HeaderText = "出院科室";
            this.col_DEPT_ADMISSION_NAME.Name = "col_DEPT_ADMISSION_NAME";
            this.col_DEPT_ADMISSION_NAME.ReadOnly = true;
            this.col_DEPT_ADMISSION_NAME.Width = 120;
            // 
            // col_1_PATIENT_NAME
            // 
            this.col_1_PATIENT_NAME.HeaderText = "患者姓名";
            this.col_1_PATIENT_NAME.Name = "col_1_PATIENT_NAME";
            this.col_1_PATIENT_NAME.ReadOnly = true;
            // 
            // col_PATIENT_ID
            // 
            this.col_PATIENT_ID.FillWeight = 102.1956F;
            this.col_PATIENT_ID.HeaderText = "病案号";
            this.col_PATIENT_ID.Name = "col_PATIENT_ID";
            this.col_PATIENT_ID.ReadOnly = true;
            this.col_PATIENT_ID.Width = 80;
            // 
            // col_VISIT_ID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_VISIT_ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_VISIT_ID.HeaderText = "入院次";
            this.col_VISIT_ID.Name = "col_VISIT_ID";
            this.col_VISIT_ID.ReadOnly = true;
            this.col_VISIT_ID.Width = 60;
            // 
            // col_ADMISSION_DATE_TIME
            // 
            this.col_ADMISSION_DATE_TIME.FillWeight = 117.631F;
            this.col_ADMISSION_DATE_TIME.HeaderText = "入院时间";
            this.col_ADMISSION_DATE_TIME.Name = "col_ADMISSION_DATE_TIME";
            this.col_ADMISSION_DATE_TIME.ReadOnly = true;
            this.col_ADMISSION_DATE_TIME.Width = 120;
            // 
            // col_DISCHARGE_DATE_TIME
            // 
            this.col_DISCHARGE_DATE_TIME.HeaderText = "出院时间";
            this.col_DISCHARGE_DATE_TIME.Name = "col_DISCHARGE_DATE_TIME";
            this.col_DISCHARGE_DATE_TIME.ReadOnly = true;
            this.col_DISCHARGE_DATE_TIME.Width = 120;
            // 
            // col_MR_STATUS
            // 
            this.col_MR_STATUS.HeaderText = "病案状态";
            this.col_MR_STATUS.Name = "col_MR_STATUS";
            this.col_MR_STATUS.ReadOnly = true;
            this.col_MR_STATUS.Width = 80;
            // 
            // col_SUBMIT_TIME
            // 
            this.col_SUBMIT_TIME.HeaderText = "提交时间";
            this.col_SUBMIT_TIME.Name = "col_SUBMIT_TIME";
            this.col_SUBMIT_TIME.ReadOnly = true;
            this.col_SUBMIT_TIME.Width = 120;
            // 
            // col_ARCHIVE_TIME
            // 
            this.col_ARCHIVE_TIME.HeaderText = "归档时间";
            this.col_ARCHIVE_TIME.Name = "col_ARCHIVE_TIME";
            this.col_ARCHIVE_TIME.ReadOnly = true;
            this.col_ARCHIVE_TIME.Width = 120;
            // 
            // cboTimeType
            // 
            this.cboTimeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboTimeType.FormattingEnabled = true;
            this.cboTimeType.Items.AddRange(new object[] {
            "入院日期",
            "出院日期"});
            this.cboTimeType.Location = new System.Drawing.Point(232, 6);
            this.cboTimeType.Name = "cboTimeType";
            this.cboTimeType.Size = new System.Drawing.Size(87, 22);
            this.cboTimeType.TabIndex = 13;
            this.cboTimeType.Text = "出院日期";
            // 
            // dtTimeEnd
            // 
            this.dtTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTimeEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtTimeEnd.Location = new System.Drawing.Point(450, 6);
            this.dtTimeEnd.Name = "dtTimeEnd";
            this.dtTimeEnd.NullableValue = new System.DateTime(2017, 1, 18, 0, 0, 0, 0);
            this.dtTimeEnd.ShowHour = false;
            this.dtTimeEnd.ShowMinute = false;
            this.dtTimeEnd.ShowSecond = false;
            this.dtTimeEnd.Size = new System.Drawing.Size(106, 21);
            this.dtTimeEnd.TabIndex = 11;
            // 
            // dtTimeBegin
            // 
            this.dtTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTimeBegin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtTimeBegin.Location = new System.Drawing.Point(322, 6);
            this.dtTimeBegin.Name = "dtTimeBegin";
            this.dtTimeBegin.NullableValue = new System.DateTime(2017, 1, 18, 0, 0, 0, 0);
            this.dtTimeBegin.ShowHour = false;
            this.dtTimeBegin.ShowMinute = false;
            this.dtTimeBegin.ShowSecond = false;
            this.dtTimeBegin.Size = new System.Drawing.Size(106, 21);
            this.dtTimeBegin.TabIndex = 12;
            // 
            // xLabel6
            // 
            this.xLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel6.Location = new System.Drawing.Point(432, 10);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(14, 14);
            this.xLabel6.TabIndex = 10;
            this.xLabel6.Text = "-";
            // 
            // MrArchiveTableForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 509);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MrArchiveTableForm";
            this.Text = "病案归档一览表";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private Heren.Common.Forms.XLabel xLabel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboMrStatus;
        private Heren.Common.Forms.XLabel xLabel2;
        private Heren.Common.Forms.XButton btnSearch;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DEPT_ADMISSION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_VISIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ADMISSION_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DISCHARGE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MR_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SUBMIT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ARCHIVE_TIME;
        private System.Windows.Forms.ComboBox cboTimeType;
        private Common.Forms.XDateTime dtTimeEnd;
        private Common.Forms.XDateTime dtTimeBegin;
        private Common.Forms.XLabel xLabel6;
    }
}