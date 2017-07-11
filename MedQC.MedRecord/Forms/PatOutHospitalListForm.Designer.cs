namespace Heren.MedQC.MedRecord
{
    partial class PatOutHospitalListForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_1_BED_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_VISIT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DISCHARGE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DISCHARGE_MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DIAGNOSIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_INCHARGE_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MR_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsBrowseRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDeath = new System.Windows.Forms.CheckBox();
            this.cboTimeType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.dtTimeEnd = new Heren.Common.Forms.XDateTime();
            this.dtTimeBegin = new Heren.Common.Forms.XDateTime();
            this.txtName = new Heren.Common.Forms.XTextBox();
            this.xLabel4 = new Heren.Common.Forms.XLabel();
            this.txtPatientID = new Heren.Common.Forms.XTextBox();
            this.xLabel3 = new Heren.Common.Forms.XLabel();
            this.cboUserList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel2 = new Heren.Common.Forms.XLabel();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            this.xLabel1 = new Heren.Common.Forms.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTableView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataTableView1.ColumnHeadersHeight = 20;
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_1_BED_NO,
            this.col_1_PATIENT_NAME,
            this.col_PATIENT_SEX,
            this.col_AGE,
            this.col_PATIENT_ID,
            this.col_VISIT_TIME,
            this.col_DISCHARGE_TIME,
            this.col_DISCHARGE_MODE,
            this.col_DIAGNOSIS,
            this.col_1_DEPT_NAME,
            this.col_INCHARGE_DOCTOR,
            this.col_MR_STATUS});
            this.dataTableView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 60);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(1185, 449);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // col_1_BED_NO
            // 
            this.col_1_BED_NO.FillWeight = 85.46564F;
            this.col_1_BED_NO.HeaderText = "床号";
            this.col_1_BED_NO.Name = "col_1_BED_NO";
            this.col_1_BED_NO.ReadOnly = true;
            this.col_1_BED_NO.Width = 40;
            // 
            // col_1_PATIENT_NAME
            // 
            this.col_1_PATIENT_NAME.HeaderText = "患者姓名";
            this.col_1_PATIENT_NAME.Name = "col_1_PATIENT_NAME";
            this.col_1_PATIENT_NAME.ReadOnly = true;
            // 
            // col_PATIENT_SEX
            // 
            this.col_PATIENT_SEX.FillWeight = 93.80241F;
            this.col_PATIENT_SEX.HeaderText = "性别";
            this.col_PATIENT_SEX.Name = "col_PATIENT_SEX";
            this.col_PATIENT_SEX.ReadOnly = true;
            this.col_PATIENT_SEX.Width = 60;
            // 
            // col_AGE
            // 
            this.col_AGE.HeaderText = "年龄";
            this.col_AGE.Name = "col_AGE";
            this.col_AGE.ReadOnly = true;
            this.col_AGE.Width = 60;
            // 
            // col_PATIENT_ID
            // 
            this.col_PATIENT_ID.FillWeight = 102.1956F;
            this.col_PATIENT_ID.HeaderText = "病案号";
            this.col_PATIENT_ID.Name = "col_PATIENT_ID";
            this.col_PATIENT_ID.ReadOnly = true;
            // 
            // col_VISIT_TIME
            // 
            this.col_VISIT_TIME.FillWeight = 117.631F;
            this.col_VISIT_TIME.HeaderText = "入院时间";
            this.col_VISIT_TIME.Name = "col_VISIT_TIME";
            this.col_VISIT_TIME.ReadOnly = true;
            this.col_VISIT_TIME.Width = 120;
            // 
            // col_DISCHARGE_TIME
            // 
            this.col_DISCHARGE_TIME.HeaderText = "出院时间";
            this.col_DISCHARGE_TIME.Name = "col_DISCHARGE_TIME";
            this.col_DISCHARGE_TIME.ReadOnly = true;
            this.col_DISCHARGE_TIME.Width = 120;
            // 
            // col_DISCHARGE_MODE
            // 
            this.col_DISCHARGE_MODE.HeaderText = "出院方式";
            this.col_DISCHARGE_MODE.Name = "col_DISCHARGE_MODE";
            this.col_DISCHARGE_MODE.ReadOnly = true;
            // 
            // col_DIAGNOSIS
            // 
            this.col_DIAGNOSIS.FillWeight = 137.1017F;
            this.col_DIAGNOSIS.HeaderText = "入院诊断";
            this.col_DIAGNOSIS.Name = "col_DIAGNOSIS";
            this.col_DIAGNOSIS.ReadOnly = true;
            this.col_DIAGNOSIS.Width = 250;
            // 
            // col_1_DEPT_NAME
            // 
            this.col_1_DEPT_NAME.FillWeight = 144.596F;
            this.col_1_DEPT_NAME.HeaderText = "入院科室";
            this.col_1_DEPT_NAME.Name = "col_1_DEPT_NAME";
            this.col_1_DEPT_NAME.ReadOnly = true;
            // 
            // col_INCHARGE_DOCTOR
            // 
            this.col_INCHARGE_DOCTOR.HeaderText = "经治医师";
            this.col_INCHARGE_DOCTOR.Name = "col_INCHARGE_DOCTOR";
            this.col_INCHARGE_DOCTOR.ReadOnly = true;
            // 
            // col_MR_STATUS
            // 
            this.col_MR_STATUS.HeaderText = "病案状态";
            this.col_MR_STATUS.Name = "col_MR_STATUS";
            this.col_MR_STATUS.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBrowseRequest});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // tsBrowseRequest
            // 
            this.tsBrowseRequest.Name = "tsBrowseRequest";
            this.tsBrowseRequest.Size = new System.Drawing.Size(148, 22);
            this.tsBrowseRequest.Text = "申请病历浏览";
            this.tsBrowseRequest.Click += new System.EventHandler(this.tsBrowseRequest_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkDeath);
            this.panel1.Controls.Add(this.cboTimeType);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtTimeEnd);
            this.panel1.Controls.Add(this.dtTimeBegin);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.xLabel4);
            this.panel1.Controls.Add(this.txtPatientID);
            this.panel1.Controls.Add(this.xLabel3);
            this.panel1.Controls.Add(this.cboUserList);
            this.panel1.Controls.Add(this.xLabel2);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 60);
            this.panel1.TabIndex = 0;
            // 
            // chkDeath
            // 
            this.chkDeath.AutoSize = true;
            this.chkDeath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDeath.Location = new System.Drawing.Point(364, 32);
            this.chkDeath.Name = "chkDeath";
            this.chkDeath.Size = new System.Drawing.Size(54, 18);
            this.chkDeath.TabIndex = 10;
            this.chkDeath.Text = "死亡";
            this.chkDeath.UseVisualStyleBackColor = true;
            // 
            // cboTimeType
            // 
            this.cboTimeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboTimeType.FormattingEnabled = true;
            this.cboTimeType.Items.AddRange(new object[] {
            "出院日期",
            "入院日期"});
            this.cboTimeType.Location = new System.Drawing.Point(6, 6);
            this.cboTimeType.Name = "cboTimeType";
            this.cboTimeType.Size = new System.Drawing.Size(87, 22);
            this.cboTimeType.TabIndex = 9;
            this.cboTimeType.Text = "出院日期";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(685, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
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
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(239, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(90, 23);
            this.txtName.TabIndex = 5;
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
            this.txtPatientID.Location = new System.Drawing.Point(95, 29);
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
            // cboUserList
            // 
            this.cboUserList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboUserList.Location = new System.Drawing.Point(660, 5);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(116, 21);
            this.cboUserList.TabIndex = 3;
            // 
            // xLabel2
            // 
            this.xLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel2.Location = new System.Drawing.Point(591, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(77, 14);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "经治医师：";
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
            // PatOutHospitalListForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 509);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PatOutHospitalListForm";
            this.Text = "出院患者列表";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private Heren.Common.Forms.XLabel xLabel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboUserList;
        private Heren.Common.Forms.XLabel xLabel2;
        private Heren.Common.Forms.XLabel xLabel3;
        private Heren.Common.Forms.XTextBox txtPatientID;
        private Heren.Common.Forms.XTextBox txtName;
        private Heren.Common.Forms.XLabel xLabel4;
        private Heren.Common.Forms.XDateTime dtTimeBegin;
        private Heren.Common.Forms.XLabel xLabel6;
        private Heren.Common.Forms.XDateTime dtTimeEnd;
        private Heren.Common.Forms.XButton btnSearch;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.ComboBox cboTimeType;
        private System.Windows.Forms.CheckBox chkDeath;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_BED_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_VISIT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DISCHARGE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DISCHARGE_MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DIAGNOSIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_INCHARGE_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MR_STATUS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsBrowseRequest;
    }
}