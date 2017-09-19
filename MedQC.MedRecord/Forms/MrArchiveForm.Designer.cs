namespace Heren.MedQC.MedRecord
{
    partial class MrArchiveForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colArchive = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReject = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_DEPT_ADMISSION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_VISIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ADMISSION_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DISCHARGE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MR_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PAPER_RECEIVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RETURN_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SUBMIT_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SUBMIT_NURSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SUBMIT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ARCHIVE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HOS_QCMAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTimeType = new System.Windows.Forms.ComboBox();
            this.xButton2 = new Heren.Common.Forms.XButton();
            this.btnArchive = new Heren.Common.Forms.XButton();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.dtTimeEnd = new Heren.Common.Forms.XDateTime();
            this.dtTimeBegin = new Heren.Common.Forms.XDateTime();
            this.txtPatientName = new Heren.Common.Forms.XTextBox();
            this.xLabel4 = new Heren.Common.Forms.XLabel();
            this.txtPatientID = new Heren.Common.Forms.XTextBox();
            this.xLabel3 = new Heren.Common.Forms.XLabel();
            this.findComboBox1 = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel5 = new Heren.Common.Forms.XLabel();
            this.cboMrStatus = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel2 = new Heren.Common.Forms.XLabel();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            this.xLabel1 = new Heren.Common.Forms.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(4, 64);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 2;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
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
            this.col_CheckBox,
            this.colArchive,
            this.colReject,
            this.col_DEPT_ADMISSION_NAME,
            this.col_1_PATIENT_NAME,
            this.col_PATIENT_ID,
            this.col_VISIT_ID,
            this.col_PATIENT_SEX,
            this.col_ADMISSION_DATE_TIME,
            this.col_DISCHARGE_DATE_TIME,
            this.col_MR_STATUS,
            this.col_PAPER_RECEIVE,
            this.col_RETURN_COUNT,
            this.col_SUBMIT_DOCTOR,
            this.col_SUBMIT_NURSE,
            this.col_SUBMIT_TIME,
            this.col_ARCHIVE_TIME,
            this.col_HOS_QCMAN});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 60);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(852, 449);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // col_CheckBox
            // 
            this.col_CheckBox.HeaderText = "";
            this.col_CheckBox.Name = "col_CheckBox";
            this.col_CheckBox.ReadOnly = true;
            this.col_CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_CheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_CheckBox.Width = 20;
            // 
            // colArchive
            // 
            this.colArchive.HeaderText = "归档";
            this.colArchive.Image = global::Heren.MedQC.MedRecord.Properties.Resources.archive;
            this.colArchive.Name = "colArchive";
            this.colArchive.ReadOnly = true;
            this.colArchive.ToolTipText = "归档";
            this.colArchive.Width = 40;
            // 
            // colReject
            // 
            this.colReject.HeaderText = "驳回";
            this.colReject.Image = global::Heren.MedQC.MedRecord.Properties.Resources.reject;
            this.colReject.Name = "colReject";
            this.colReject.ReadOnly = true;
            this.colReject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colReject.Width = 40;
            // 
            // col_DEPT_ADMISSION_NAME
            // 
            this.col_DEPT_ADMISSION_NAME.HeaderText = "入院科室";
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
            // col_PATIENT_SEX
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_PATIENT_SEX.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_PATIENT_SEX.FillWeight = 93.80241F;
            this.col_PATIENT_SEX.HeaderText = "性别";
            this.col_PATIENT_SEX.Name = "col_PATIENT_SEX";
            this.col_PATIENT_SEX.ReadOnly = true;
            this.col_PATIENT_SEX.Width = 60;
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
            // col_PAPER_RECEIVE
            // 
            this.col_PAPER_RECEIVE.HeaderText = "纸质接收";
            this.col_PAPER_RECEIVE.Name = "col_PAPER_RECEIVE";
            this.col_PAPER_RECEIVE.ReadOnly = true;
            // 
            // col_RETURN_COUNT
            // 
            this.col_RETURN_COUNT.HeaderText = "退回次数";
            this.col_RETURN_COUNT.Name = "col_RETURN_COUNT";
            this.col_RETURN_COUNT.ReadOnly = true;
            this.col_RETURN_COUNT.Width = 80;
            // 
            // col_SUBMIT_DOCTOR
            // 
            this.col_SUBMIT_DOCTOR.HeaderText = "提交医生";
            this.col_SUBMIT_DOCTOR.Name = "col_SUBMIT_DOCTOR";
            this.col_SUBMIT_DOCTOR.ReadOnly = true;
            // 
            // col_SUBMIT_NURSE
            // 
            this.col_SUBMIT_NURSE.HeaderText = "提交护士";
            this.col_SUBMIT_NURSE.Name = "col_SUBMIT_NURSE";
            this.col_SUBMIT_NURSE.ReadOnly = true;
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
            // col_HOS_QCMAN
            // 
            this.col_HOS_QCMAN.HeaderText = "病案核对者";
            this.col_HOS_QCMAN.Name = "col_HOS_QCMAN";
            this.col_HOS_QCMAN.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboTimeType);
            this.panel1.Controls.Add(this.xButton2);
            this.panel1.Controls.Add(this.btnArchive);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtTimeEnd);
            this.panel1.Controls.Add(this.dtTimeBegin);
            this.panel1.Controls.Add(this.txtPatientName);
            this.panel1.Controls.Add(this.xLabel4);
            this.panel1.Controls.Add(this.txtPatientID);
            this.panel1.Controls.Add(this.xLabel3);
            this.panel1.Controls.Add(this.findComboBox1);
            this.panel1.Controls.Add(this.xLabel5);
            this.panel1.Controls.Add(this.cboMrStatus);
            this.panel1.Controls.Add(this.xLabel2);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 60);
            this.panel1.TabIndex = 0;
            // 
            // cboTimeType
            // 
            this.cboTimeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboTimeType.FormattingEnabled = true;
            this.cboTimeType.Items.AddRange(new object[] {
            "入院日期",
            "出院日期"});
            this.cboTimeType.Location = new System.Drawing.Point(6, 6);
            this.cboTimeType.Name = "cboTimeType";
            this.cboTimeType.Size = new System.Drawing.Size(87, 22);
            this.cboTimeType.TabIndex = 9;
            this.cboTimeType.Text = "出院日期";
            // 
            // xButton2
            // 
            this.xButton2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xButton2.Location = new System.Drawing.Point(1058, 4);
            this.xButton2.Name = "xButton2";
            this.xButton2.Size = new System.Drawing.Size(57, 24);
            this.xButton2.TabIndex = 8;
            this.xButton2.Text = "统计";
            this.xButton2.UseVisualStyleBackColor = true;
            this.xButton2.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnArchive.Location = new System.Drawing.Point(758, 32);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(72, 24);
            this.btnArchive.TabIndex = 8;
            this.btnArchive.Text = "审核归档";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(680, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtTimeEnd
            // 
            this.dtTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTimeEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtTimeEnd.Location = new System.Drawing.Point(224, 6);
            this.dtTimeEnd.Name = "dtTimeEnd";
            this.dtTimeEnd.NullableValue = new System.DateTime(2017, 1, 18, 0, 0, 0, 0);
            this.dtTimeEnd.ShowHour = false;
            this.dtTimeEnd.ShowMinute = false;
            this.dtTimeEnd.ShowSecond = false;
            this.dtTimeEnd.Size = new System.Drawing.Size(106, 21);
            this.dtTimeEnd.TabIndex = 6;
            // 
            // dtTimeBegin
            // 
            this.dtTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTimeBegin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtTimeBegin.Location = new System.Drawing.Point(96, 6);
            this.dtTimeBegin.Name = "dtTimeBegin";
            this.dtTimeBegin.NullableValue = new System.DateTime(2017, 1, 18, 0, 0, 0, 0);
            this.dtTimeBegin.ShowHour = false;
            this.dtTimeBegin.ShowMinute = false;
            this.dtTimeBegin.ShowSecond = false;
            this.dtTimeBegin.Size = new System.Drawing.Size(106, 21);
            this.dtTimeBegin.TabIndex = 6;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatientName.Location = new System.Drawing.Point(239, 29);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(90, 23);
            this.txtPatientName.TabIndex = 5;
            // 
            // xLabel4
            // 
            this.xLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel4.Location = new System.Drawing.Point(192, 34);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(49, 14);
            this.xLabel4.TabIndex = 4;
            this.xLabel4.Text = "姓名：";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatientID.Location = new System.Drawing.Point(96, 29);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(94, 23);
            this.txtPatientID.TabIndex = 5;
            // 
            // xLabel3
            // 
            this.xLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel3.Location = new System.Drawing.Point(13, 35);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(77, 14);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "患者ID号：";
            // 
            // findComboBox1
            // 
            this.findComboBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.findComboBox1.Items.AddRange(new object[] {
            "全部",
            "未发送",
            "已发送",
            "已接收"});
            this.findComboBox1.Location = new System.Drawing.Point(587, 34);
            this.findComboBox1.Name = "findComboBox1";
            this.findComboBox1.Size = new System.Drawing.Size(81, 21);
            this.findComboBox1.TabIndex = 3;
            this.findComboBox1.Text = "全部";
            // 
            // xLabel5
            // 
            this.xLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel5.Location = new System.Drawing.Point(518, 37);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(77, 14);
            this.xLabel5.TabIndex = 2;
            this.xLabel5.Text = "纸质病历：";
            // 
            // cboMrStatus
            // 
            this.cboMrStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboMrStatus.Items.AddRange(new object[] {
            "全部",
            "未提交",
            "已提交",
            "已归档"});
            this.cboMrStatus.Location = new System.Drawing.Point(433, 34);
            this.cboMrStatus.Name = "cboMrStatus";
            this.cboMrStatus.Size = new System.Drawing.Size(81, 21);
            this.cboMrStatus.TabIndex = 3;
            this.cboMrStatus.Text = "全部";
            // 
            // xLabel2
            // 
            this.xLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel2.Location = new System.Drawing.Point(364, 37);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(77, 14);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "病案状态：";
            // 
            // cboDeptName
            // 
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDeptName.Location = new System.Drawing.Point(433, 5);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(150, 21);
            this.cboDeptName.TabIndex = 3;
            // 
            // xLabel6
            // 
            this.xLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel6.Location = new System.Drawing.Point(206, 10);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(14, 14);
            this.xLabel6.TabIndex = 2;
            this.xLabel6.Text = "-";
            // 
            // xLabel1
            // 
            this.xLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel1.Location = new System.Drawing.Point(361, 9);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(77, 14);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "入院科室：";
            // 
            // MrArchiveForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 509);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MrArchiveForm";
            this.Text = "病案归档";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private Heren.Common.Forms.XLabel xLabel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboMrStatus;
        private Heren.Common.Forms.XLabel xLabel2;
        private Heren.Common.Forms.XLabel xLabel3;
        private Heren.Common.Forms.XTextBox txtPatientID;
        private Heren.Common.Forms.XTextBox txtPatientName;
        private Heren.Common.Forms.XLabel xLabel4;
        private Heren.Common.Forms.XDateTime dtTimeBegin;
        private Heren.Common.Forms.XLabel xLabel6;
        private Heren.Common.Forms.XDateTime dtTimeEnd;
        private Heren.Common.Forms.XButton btnSearch;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.ComboBox cboTimeType;
        private Common.Controls.DictInput.FindComboBox findComboBox1;
        private Common.Forms.XLabel xLabel5;
        private Common.Forms.XButton btnArchive;
        private Common.Forms.XButton xButton2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_CheckBox;
        private System.Windows.Forms.DataGridViewImageColumn colArchive;
        private System.Windows.Forms.DataGridViewImageColumn colReject;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DEPT_ADMISSION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_VISIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ADMISSION_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DISCHARGE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MR_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PAPER_RECEIVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RETURN_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SUBMIT_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SUBMIT_NURSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SUBMIT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ARCHIVE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HOS_QCMAN;
    }
}