namespace Heren.MedQC.Systems
{
    partial class QcTrackForm
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
            this.xPanel2 = new Heren.Common.Forms.XPanel();
            this.dataTableView2 = new Heren.Common.Controls.TableView.DataTableView();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_1_NOTICE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_RECEIVER_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_QC_MAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_QC_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_MODIFY_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_QC_LEVEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_DischargeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_btnDelete = new Heren.Common.Forms.XImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.dtIssuedEnd = new Heren.Common.Forms.XDateTime();
            this.dtIssuedBegin = new Heren.Common.Forms.XDateTime();
            this.txtName = new Heren.Common.Forms.XTextBox();
            this.xLabel4 = new Heren.Common.Forms.XLabel();
            this.txtPatientID = new Heren.Common.Forms.XTextBox();
            this.xLabel3 = new Heren.Common.Forms.XLabel();
            this.cboUserList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel2 = new Heren.Common.Forms.XLabel();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel5 = new Heren.Common.Forms.XLabel();
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            this.xLabel1 = new Heren.Common.Forms.XLabel();
            this.chkPass = new System.Windows.Forms.CheckBox();
            this.chkModified = new System.Windows.Forms.CheckBox();
            this.chkUnCheck = new System.Windows.Forms.CheckBox();
            this.col_2_MSG_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_QA_EVENT_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_QcMsgDict = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_Point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_ERROR_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_doctorInCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_AskDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_DoctorComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_btnPass = new Heren.Common.Forms.XImageColumn();
            this.col_2_btnReject = new Heren.Common.Forms.XImageColumn();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.dataTableView2);
            this.xPanel2.Controls.Add(this.dataTableView1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 60);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1010, 494);
            this.xPanel2.TabIndex = 1;
            // 
            // dataTableView2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataTableView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_2_MSG_STATUS,
            this.col_2_QA_EVENT_TYPE,
            this.col_2_QcMsgDict,
            this.col_2_Point,
            this.col_2_ERROR_COUNT,
            this.col_2_doctorInCharge,
            this.col_2_AskDateTime,
            this.col_2_DoctorComment,
            this.col_2_btnPass,
            this.col_2_btnReject});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataTableView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView2.Location = new System.Drawing.Point(0, 238);
            this.dataTableView2.Name = "dataTableView2";
            this.dataTableView2.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataTableView2.RowHeadersVisible = false;
            this.dataTableView2.Size = new System.Drawing.Size(1010, 256);
            this.dataTableView2.TabIndex = 1;
            this.dataTableView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView2_CellClick);
            this.dataTableView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView2_CellDoubleClick);
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
            this.col_1_NOTICE_TIME,
            this.col_1_RECEIVER_DEPT_NAME,
            this.col_1_PATIENT_ID,
            this.col_1_PATIENT_NAME,
            this.col_1_QC_MAN,
            this.col_1_QC_DEPT_NAME,
            this.col_1_MODIFY_REMARK,
            this.col_1_QC_LEVEL,
            this.col_1_DischargeTime,
            this.col_1_btnDelete});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataTableView1.Location = new System.Drawing.Point(0, 0);
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
            this.dataTableView1.Size = new System.Drawing.Size(1010, 238);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // col_1_NOTICE_TIME
            // 
            this.col_1_NOTICE_TIME.FillWeight = 85.46564F;
            this.col_1_NOTICE_TIME.HeaderText = "通知时间";
            this.col_1_NOTICE_TIME.Name = "col_1_NOTICE_TIME";
            this.col_1_NOTICE_TIME.ReadOnly = true;
            this.col_1_NOTICE_TIME.Width = 120;
            // 
            // col_1_RECEIVER_DEPT_NAME
            // 
            this.col_1_RECEIVER_DEPT_NAME.FillWeight = 93.80241F;
            this.col_1_RECEIVER_DEPT_NAME.HeaderText = "接收科室";
            this.col_1_RECEIVER_DEPT_NAME.Name = "col_1_RECEIVER_DEPT_NAME";
            this.col_1_RECEIVER_DEPT_NAME.ReadOnly = true;
            // 
            // col_1_PATIENT_ID
            // 
            this.col_1_PATIENT_ID.FillWeight = 102.1956F;
            this.col_1_PATIENT_ID.HeaderText = "患者ID";
            this.col_1_PATIENT_ID.Name = "col_1_PATIENT_ID";
            this.col_1_PATIENT_ID.ReadOnly = true;
            // 
            // col_1_PATIENT_NAME
            // 
            this.col_1_PATIENT_NAME.HeaderText = "患者姓名";
            this.col_1_PATIENT_NAME.Name = "col_1_PATIENT_NAME";
            this.col_1_PATIENT_NAME.ReadOnly = true;
            // 
            // col_1_QC_MAN
            // 
            this.col_1_QC_MAN.FillWeight = 117.631F;
            this.col_1_QC_MAN.HeaderText = "质控医生";
            this.col_1_QC_MAN.Name = "col_1_QC_MAN";
            this.col_1_QC_MAN.ReadOnly = true;
            // 
            // col_1_QC_DEPT_NAME
            // 
            this.col_1_QC_DEPT_NAME.FillWeight = 164.9927F;
            this.col_1_QC_DEPT_NAME.HeaderText = "质控科室";
            this.col_1_QC_DEPT_NAME.Name = "col_1_QC_DEPT_NAME";
            this.col_1_QC_DEPT_NAME.ReadOnly = true;
            // 
            // col_1_MODIFY_REMARK
            // 
            this.col_1_MODIFY_REMARK.FillWeight = 137.1017F;
            this.col_1_MODIFY_REMARK.HeaderText = "整改备注";
            this.col_1_MODIFY_REMARK.Name = "col_1_MODIFY_REMARK";
            this.col_1_MODIFY_REMARK.ReadOnly = true;
            this.col_1_MODIFY_REMARK.Width = 200;
            // 
            // col_1_QC_LEVEL
            // 
            this.col_1_QC_LEVEL.FillWeight = 144.596F;
            this.col_1_QC_LEVEL.HeaderText = "质控级别";
            this.col_1_QC_LEVEL.Name = "col_1_QC_LEVEL";
            this.col_1_QC_LEVEL.ReadOnly = true;
            // 
            // col_1_DischargeTime
            // 
            this.col_1_DischargeTime.HeaderText = "出院日期";
            this.col_1_DischargeTime.Name = "col_1_DischargeTime";
            this.col_1_DischargeTime.ReadOnly = true;
            // 
            // col_1_btnDelete
            // 
            this.col_1_btnDelete.FillWeight = 5.117707F;
            this.col_1_btnDelete.HeaderText = "";
            this.col_1_btnDelete.Image = global::Heren.MedQC.Systems.Properties.Resources.Delete;
            this.col_1_btnDelete.Name = "col_1_btnDelete";
            this.col_1_btnDelete.ReadOnly = true;
            this.col_1_btnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_1_btnDelete.ToolTipText = "删除";
            this.col_1_btnDelete.Width = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtIssuedEnd);
            this.panel1.Controls.Add(this.dtIssuedBegin);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.xLabel4);
            this.panel1.Controls.Add(this.txtPatientID);
            this.panel1.Controls.Add(this.xLabel3);
            this.panel1.Controls.Add(this.cboUserList);
            this.panel1.Controls.Add(this.xLabel2);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.xLabel5);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Controls.Add(this.chkPass);
            this.panel1.Controls.Add(this.chkModified);
            this.panel1.Controls.Add(this.chkUnCheck);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(845, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtIssuedEnd
            // 
            this.dtIssuedEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtIssuedEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtIssuedEnd.Location = new System.Drawing.Point(214, 33);
            this.dtIssuedEnd.Name = "dtIssuedEnd";
            this.dtIssuedEnd.NullableValue = new System.DateTime(2017, 1, 18, 0, 0, 0, 0);
            this.dtIssuedEnd.ShowHour = false;
            this.dtIssuedEnd.ShowMinute = false;
            this.dtIssuedEnd.ShowSecond = false;
            this.dtIssuedEnd.Size = new System.Drawing.Size(106, 21);
            this.dtIssuedEnd.TabIndex = 6;
            // 
            // dtIssuedBegin
            // 
            this.dtIssuedBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtIssuedBegin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtIssuedBegin.Location = new System.Drawing.Point(86, 33);
            this.dtIssuedBegin.Name = "dtIssuedBegin";
            this.dtIssuedBegin.NullableValue = new System.DateTime(2017, 1, 18, 0, 0, 0, 0);
            this.dtIssuedBegin.ShowHour = false;
            this.dtIssuedBegin.ShowMinute = false;
            this.dtIssuedBegin.ShowSecond = false;
            this.dtIssuedBegin.Size = new System.Drawing.Size(106, 21);
            this.dtIssuedBegin.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(845, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(90, 23);
            this.txtName.TabIndex = 5;
            // 
            // xLabel4
            // 
            this.xLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel4.Location = new System.Drawing.Point(798, 8);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(49, 14);
            this.xLabel4.TabIndex = 4;
            this.xLabel4.Text = "姓名：";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatientID.Location = new System.Drawing.Point(698, 3);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(94, 23);
            this.txtPatientID.TabIndex = 5;
            // 
            // xLabel3
            // 
            this.xLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel3.Location = new System.Drawing.Point(629, 9);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(77, 14);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "患者ID号：";
            // 
            // cboUserList
            // 
            this.cboUserList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboUserList.Location = new System.Drawing.Point(507, 5);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(116, 21);
            this.cboUserList.TabIndex = 3;
            // 
            // xLabel2
            // 
            this.xLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel2.Location = new System.Drawing.Point(438, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(77, 14);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "质控医生：";
            // 
            // cboDeptName
            // 
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDeptName.Location = new System.Drawing.Point(282, 5);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(150, 21);
            this.cboDeptName.TabIndex = 3;
            // 
            // xLabel5
            // 
            this.xLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel5.Location = new System.Drawing.Point(12, 37);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(77, 14);
            this.xLabel5.TabIndex = 2;
            this.xLabel5.Text = "通知日期：";
            // 
            // xLabel6
            // 
            this.xLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel6.Location = new System.Drawing.Point(196, 37);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(14, 14);
            this.xLabel6.TabIndex = 2;
            this.xLabel6.Text = "-";
            // 
            // xLabel1
            // 
            this.xLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel1.Location = new System.Drawing.Point(213, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(77, 14);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "接收科室：";
            // 
            // chkPass
            // 
            this.chkPass.AutoSize = true;
            this.chkPass.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPass.Location = new System.Drawing.Point(156, 7);
            this.chkPass.Name = "chkPass";
            this.chkPass.Size = new System.Drawing.Size(54, 18);
            this.chkPass.TabIndex = 1;
            this.chkPass.Text = "合格";
            this.chkPass.UseVisualStyleBackColor = true;
            // 
            // chkModified
            // 
            this.chkModified.AutoSize = true;
            this.chkModified.Checked = true;
            this.chkModified.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModified.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkModified.Location = new System.Drawing.Point(82, 7);
            this.chkModified.Name = "chkModified";
            this.chkModified.Size = new System.Drawing.Size(68, 18);
            this.chkModified.TabIndex = 1;
            this.chkModified.Text = "已修改";
            this.chkModified.UseVisualStyleBackColor = true;
            // 
            // chkUnCheck
            // 
            this.chkUnCheck.AutoSize = true;
            this.chkUnCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUnCheck.Location = new System.Drawing.Point(8, 7);
            this.chkUnCheck.Name = "chkUnCheck";
            this.chkUnCheck.Size = new System.Drawing.Size(68, 18);
            this.chkUnCheck.TabIndex = 1;
            this.chkUnCheck.Text = "未确认";
            this.chkUnCheck.UseVisualStyleBackColor = true;
            // 
            // col_2_MSG_STATUS
            // 
            this.col_2_MSG_STATUS.HeaderText = "状态";
            this.col_2_MSG_STATUS.Name = "col_2_MSG_STATUS";
            this.col_2_MSG_STATUS.ReadOnly = true;
            // 
            // col_2_QA_EVENT_TYPE
            // 
            this.col_2_QA_EVENT_TYPE.HeaderText = "病历主题";
            this.col_2_QA_EVENT_TYPE.Name = "col_2_QA_EVENT_TYPE";
            this.col_2_QA_EVENT_TYPE.ReadOnly = true;
            // 
            // col_2_QcMsgDict
            // 
            this.col_2_QcMsgDict.HeaderText = "缺陷名称";
            this.col_2_QcMsgDict.Name = "col_2_QcMsgDict";
            this.col_2_QcMsgDict.ReadOnly = true;
            this.col_2_QcMsgDict.Width = 200;
            // 
            // col_2_Point
            // 
            this.col_2_Point.HeaderText = "扣分值";
            this.col_2_Point.Name = "col_2_Point";
            this.col_2_Point.ReadOnly = true;
            // 
            // col_2_ERROR_COUNT
            // 
            this.col_2_ERROR_COUNT.HeaderText = "错误次数";
            this.col_2_ERROR_COUNT.Name = "col_2_ERROR_COUNT";
            this.col_2_ERROR_COUNT.ReadOnly = true;
            this.col_2_ERROR_COUNT.Width = 90;
            // 
            // col_2_doctorInCharge
            // 
            this.col_2_doctorInCharge.HeaderText = "责任医生";
            this.col_2_doctorInCharge.Name = "col_2_doctorInCharge";
            this.col_2_doctorInCharge.ReadOnly = true;
            // 
            // col_2_AskDateTime
            // 
            this.col_2_AskDateTime.HeaderText = "确认时间";
            this.col_2_AskDateTime.Name = "col_2_AskDateTime";
            this.col_2_AskDateTime.ReadOnly = true;
            this.col_2_AskDateTime.Width = 120;
            // 
            // col_2_DoctorComment
            // 
            this.col_2_DoctorComment.HeaderText = "医生反馈内容";
            this.col_2_DoctorComment.Name = "col_2_DoctorComment";
            this.col_2_DoctorComment.ReadOnly = true;
            this.col_2_DoctorComment.Width = 200;
            // 
            // col_2_btnPass
            // 
            this.col_2_btnPass.HeaderText = "确认";
            this.col_2_btnPass.Name = "col_2_btnPass";
            this.col_2_btnPass.ReadOnly = true;
            this.col_2_btnPass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_2_btnPass.Width = 60;
            // 
            // col_2_btnReject
            // 
            this.col_2_btnReject.HeaderText = "驳回";
            this.col_2_btnReject.Name = "col_2_btnReject";
            this.col_2_btnReject.ReadOnly = true;
            this.col_2_btnReject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_2_btnReject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_2_btnReject.Width = 60;
            // 
            // QcTrackForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 509);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "QcTrackForm";
            this.Text = "质控追踪";
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkUnCheck;
        private System.Windows.Forms.CheckBox chkModified;
        private System.Windows.Forms.CheckBox chkPass;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private Heren.Common.Forms.XLabel xLabel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboUserList;
        private Heren.Common.Forms.XLabel xLabel2;
        private Heren.Common.Forms.XLabel xLabel3;
        private Heren.Common.Forms.XTextBox txtPatientID;
        private Heren.Common.Forms.XTextBox txtName;
        private Heren.Common.Forms.XLabel xLabel4;
        private Heren.Common.Forms.XLabel xLabel5;
        private Heren.Common.Forms.XDateTime dtIssuedBegin;
        private Heren.Common.Forms.XLabel xLabel6;
        private Heren.Common.Forms.XDateTime dtIssuedEnd;
        private Heren.Common.Forms.XButton btnSearch;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private Heren.Common.Controls.TableView.DataTableView dataTableView2;
        private Heren.Common.Forms.XPanel xPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_NOTICE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_RECEIVER_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_QC_MAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_QC_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_MODIFY_REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_QC_LEVEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_DischargeTime;
        private Common.Forms.XImageColumn col_1_btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_MSG_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_QA_EVENT_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_QcMsgDict;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_Point;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_ERROR_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_doctorInCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_AskDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_DoctorComment;
        private Common.Forms.XImageColumn col_2_btnPass;
        private Common.Forms.XImageColumn col_2_btnReject;
    }
}