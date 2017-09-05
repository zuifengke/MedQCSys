namespace Heren.MedQC.MedRecord
{
    partial class RecUploadNewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecUploadNewForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.XPanel1 = new Heren.Common.Forms.XPanel();
            this.txt_DEPT_NAME = new Heren.Common.Forms.XTextBox();
            this.XLabel3 = new Heren.Common.Forms.XLabel();
            this.cboTimeType = new Heren.Common.Forms.XComboBox();
            this.cboStatus = new Heren.Common.Forms.XComboBox();
            this.btnUpload = new Heren.Common.Forms.XButton();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.XLabel1 = new Heren.Common.Forms.XLabel();
            this.txt_PATIENT_ID = new Heren.Common.Forms.XTextBox();
            this.lbl_msg = new Heren.Common.Forms.XLabel();
            this.dtpTimeEnd = new Heren.Common.Forms.XDateTime();
            this.dtpTimeBegin = new Heren.Common.Forms.XDateTime();
            this.XLabel4 = new Heren.Common.Forms.XLabel();
            this.XLabel2 = new Heren.Common.Forms.XLabel();
            this.XDataGrid1 = new Heren.Common.Forms.XDataGrid();
            this.col_Chk = new Heren.Common.Forms.XCheckBoxColumn();
            this.col_姓名 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_性别 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_患者ID号 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_入院次 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_就诊流水号 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_入院时间 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_出院时间 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_诊断 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_病区 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_主治医生 = new Heren.Common.Forms.XTextBoxColumn();
            this.col_上传 = new Heren.Common.Forms.XLinkColumn();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.XPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // XPanel1
            // 
            this.XPanel1.Controls.Add(this.txt_DEPT_NAME);
            this.XPanel1.Controls.Add(this.XLabel3);
            this.XPanel1.Controls.Add(this.cboTimeType);
            this.XPanel1.Controls.Add(this.cboStatus);
            this.XPanel1.Controls.Add(this.btnUpload);
            this.XPanel1.Controls.Add(this.btnSearch);
            this.XPanel1.Controls.Add(this.XLabel1);
            this.XPanel1.Controls.Add(this.txt_PATIENT_ID);
            this.XPanel1.Controls.Add(this.lbl_msg);
            this.XPanel1.Controls.Add(this.dtpTimeEnd);
            this.XPanel1.Controls.Add(this.dtpTimeBegin);
            this.XPanel1.Controls.Add(this.XLabel4);
            this.XPanel1.Controls.Add(this.XLabel2);
            this.XPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.XPanel1.Location = new System.Drawing.Point(0, 0);
            this.XPanel1.Name = "XPanel1";
            this.XPanel1.Size = new System.Drawing.Size(991, 51);
            this.XPanel1.TabIndex = 7;
            // 
            // txt_DEPT_NAME
            // 
            this.txt_DEPT_NAME.BindingEvents = new Heren.Common.Forms.BindingEvent[] {
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("txt_DEPT_NAME.BindingEvents")))};
            this.txt_DEPT_NAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_DEPT_NAME.Location = new System.Drawing.Point(62, 27);
            this.txt_DEPT_NAME.Name = "txt_DEPT_NAME";
            this.txt_DEPT_NAME.ReadOnly = true;
            this.txt_DEPT_NAME.Size = new System.Drawing.Size(145, 23);
            this.txt_DEPT_NAME.TabIndex = 48;
            this.txt_DEPT_NAME.Text = "全院<可双击修改>";
            this.txt_DEPT_NAME.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.XTextBox1_MouseDoubleClick);
            // 
            // XLabel3
            // 
            this.XLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XLabel3.Location = new System.Drawing.Point(12, 30);
            this.XLabel3.Name = "XLabel3";
            this.XLabel3.Size = new System.Drawing.Size(49, 14);
            this.XLabel3.TabIndex = 47;
            this.XLabel3.Text = "病区：";
            // 
            // cboTimeType
            // 
            this.cboTimeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboTimeType.FormattingEnabled = true;
            this.cboTimeType.Items.AddRange(new object[] {
            "出院日期",
            "入院日期"});
            this.cboTimeType.Location = new System.Drawing.Point(138, 3);
            this.cboTimeType.Name = "cboTimeType";
            this.cboTimeType.Size = new System.Drawing.Size(83, 22);
            this.cboTimeType.TabIndex = 0;
            this.cboTimeType.Text = "出院日期";
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "未上传",
            "已上传"});
            this.cboStatus.Location = new System.Drawing.Point(62, 3);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(70, 22);
            this.cboStatus.TabIndex = 0;
            this.cboStatus.Text = "未上传";
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BindingEvents = new Heren.Common.Forms.BindingEvent[] {
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("btnUpload.BindingEvents")))};
            this.btnUpload.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpload.Location = new System.Drawing.Point(901, 22);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "上传选中";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BindingEvents = new Heren.Common.Forms.BindingEvent[] {
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("btnSearch.BindingEvents")))};
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(820, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // XLabel1
            // 
            this.XLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XLabel1.Location = new System.Drawing.Point(12, 7);
            this.XLabel1.Name = "XLabel1";
            this.XLabel1.Size = new System.Drawing.Size(49, 14);
            this.XLabel1.TabIndex = 1;
            this.XLabel1.Text = "状态：";
            // 
            // txt_PATIENT_ID
            // 
            this.txt_PATIENT_ID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(290, 25);
            this.txt_PATIENT_ID.Name = "txt_PATIENT_ID";
            this.txt_PATIENT_ID.Size = new System.Drawing.Size(77, 23);
            this.txt_PATIENT_ID.TabIndex = 3;
            // 
            // lbl_msg
            // 
            this.lbl_msg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_msg.Location = new System.Drawing.Point(375, 30);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(105, 14);
            this.lbl_msg.TabIndex = 1;
            this.lbl_msg.Text = "共{}份患者病历";
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeEnd.Location = new System.Drawing.Point(367, 5);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.NullableValue = null;
            this.dtpTimeEnd.ShowHour = false;
            this.dtpTimeEnd.ShowMinute = false;
            this.dtpTimeEnd.ShowSecond = false;
            this.dtpTimeEnd.Size = new System.Drawing.Size(112, 20);
            this.dtpTimeEnd.TabIndex = 2;
            // 
            // dtpTimeBegin
            // 
            this.dtpTimeBegin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeBegin.Location = new System.Drawing.Point(226, 5);
            this.dtpTimeBegin.Name = "dtpTimeBegin";
            this.dtpTimeBegin.NullableValue = null;
            this.dtpTimeBegin.ShowHour = false;
            this.dtpTimeBegin.ShowMinute = false;
            this.dtpTimeBegin.ShowSecond = false;
            this.dtpTimeBegin.Size = new System.Drawing.Size(112, 20);
            this.dtpTimeBegin.TabIndex = 2;
            // 
            // XLabel4
            // 
            this.XLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XLabel4.Location = new System.Drawing.Point(212, 31);
            this.XLabel4.Name = "XLabel4";
            this.XLabel4.Size = new System.Drawing.Size(77, 14);
            this.XLabel4.TabIndex = 1;
            this.XLabel4.Text = "患者ID号：";
            // 
            // XLabel2
            // 
            this.XLabel2.Location = new System.Drawing.Point(344, 9);
            this.XLabel2.Name = "XLabel2";
            this.XLabel2.Size = new System.Drawing.Size(17, 12);
            this.XLabel2.TabIndex = 1;
            this.XLabel2.Text = "至";
            // 
            // XDataGrid1
            // 
            this.XDataGrid1.AllowUserToAddRows = false;
            this.XDataGrid1.AllowUserToResizeRows = false;
            this.XDataGrid1.BindingEvents = new Heren.Common.Forms.BindingEvent[] {
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("XDataGrid1.BindingEvents"))),
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("XDataGrid1.BindingEvents1")))};
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.XDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.XDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.XDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Chk,
            this.col_姓名,
            this.col_性别,
            this.col_患者ID号,
            this.col_入院次,
            this.col_就诊流水号,
            this.col_入院时间,
            this.col_出院时间,
            this.col_诊断,
            this.col_病区,
            this.col_主治医生,
            this.col_上传});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.XDataGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.XDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XDataGrid1.Location = new System.Drawing.Point(0, 51);
            this.XDataGrid1.Name = "XDataGrid1";
            this.XDataGrid1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.XDataGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.XDataGrid1.RowHeadersVisible = false;
            this.XDataGrid1.Size = new System.Drawing.Size(991, 644);
            this.XDataGrid1.TabIndex = 8;
            this.XDataGrid1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.XDataGrid1_CellMouseClick);
            this.XDataGrid1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.XDataGrid1_CellMouseDoubleClick);
            // 
            // col_Chk
            // 
            this.col_Chk.HeaderText = ".";
            this.col_Chk.Name = "col_Chk";
            this.col_Chk.ReadOnly = true;
            this.col_Chk.Width = 40;
            // 
            // col_姓名
            // 
            this.col_姓名.HeaderText = "姓名";
            this.col_姓名.Name = "col_姓名";
            this.col_姓名.ReadOnly = true;
            // 
            // col_性别
            // 
            this.col_性别.HeaderText = "性别";
            this.col_性别.Name = "col_性别";
            this.col_性别.ReadOnly = true;
            // 
            // col_患者ID号
            // 
            this.col_患者ID号.HeaderText = "患者ID号";
            this.col_患者ID号.Name = "col_患者ID号";
            this.col_患者ID号.ReadOnly = true;
            // 
            // col_入院次
            // 
            this.col_入院次.HeaderText = "入院次";
            this.col_入院次.Name = "col_入院次";
            this.col_入院次.ReadOnly = true;
            // 
            // col_就诊流水号
            // 
            this.col_就诊流水号.HeaderText = "就诊流水号";
            this.col_就诊流水号.Name = "col_就诊流水号";
            this.col_就诊流水号.ReadOnly = true;
            this.col_就诊流水号.Visible = false;
            // 
            // col_入院时间
            // 
            this.col_入院时间.HeaderText = "入院时间";
            this.col_入院时间.Name = "col_入院时间";
            this.col_入院时间.ReadOnly = true;
            this.col_入院时间.Width = 150;
            // 
            // col_出院时间
            // 
            this.col_出院时间.HeaderText = "出院时间";
            this.col_出院时间.Name = "col_出院时间";
            this.col_出院时间.ReadOnly = true;
            this.col_出院时间.Width = 150;
            // 
            // col_诊断
            // 
            this.col_诊断.HeaderText = "诊断";
            this.col_诊断.Name = "col_诊断";
            this.col_诊断.ReadOnly = true;
            this.col_诊断.Width = 200;
            // 
            // col_病区
            // 
            this.col_病区.HeaderText = "病区";
            this.col_病区.Name = "col_病区";
            this.col_病区.ReadOnly = true;
            // 
            // col_主治医生
            // 
            this.col_主治医生.HeaderText = "主治医生";
            this.col_主治医生.Name = "col_主治医生";
            this.col_主治医生.ReadOnly = true;
            // 
            // col_上传
            // 
            this.col_上传.HeaderText = "上传";
            this.col_上传.Name = "col_上传";
            this.col_上传.ReadOnly = true;
            this.col_上传.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(14, 55);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 9;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // RecUploadNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(991, 695);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.XDataGrid1);
            this.Controls.Add(this.XPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecUploadNewForm";
            this.Text = "病案上传";
            this.XPanel1.ResumeLayout(false);
            this.XPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Forms.XPanel XPanel1;
        private Common.Forms.XTextBox txt_DEPT_NAME;
        private Common.Forms.XLabel XLabel3;
        private Common.Forms.XComboBox cboTimeType;
        private Common.Forms.XComboBox cboStatus;
        private Common.Forms.XButton btnUpload;
        private Common.Forms.XButton btnSearch;
        private Common.Forms.XLabel XLabel1;
        private Common.Forms.XTextBox txt_PATIENT_ID;
        private Common.Forms.XLabel lbl_msg;
        private Common.Forms.XDateTime dtpTimeEnd;
        private Common.Forms.XDateTime dtpTimeBegin;
        private Common.Forms.XLabel XLabel4;
        private Common.Forms.XLabel XLabel2;
        private Common.Forms.XDataGrid XDataGrid1;
        private Common.Forms.XCheckBoxColumn col_Chk;
        private Common.Forms.XTextBoxColumn col_姓名;
        private Common.Forms.XTextBoxColumn col_性别;
        private Common.Forms.XTextBoxColumn col_患者ID号;
        private Common.Forms.XTextBoxColumn col_入院次;
        private Common.Forms.XTextBoxColumn col_就诊流水号;
        private Common.Forms.XTextBoxColumn col_入院时间;
        private Common.Forms.XTextBoxColumn col_出院时间;
        private Common.Forms.XTextBoxColumn col_诊断;
        private Common.Forms.XTextBoxColumn col_病区;
        private Common.Forms.XTextBoxColumn col_主治医生;
        private Common.Forms.XLinkColumn col_上传;
        private System.Windows.Forms.CheckBox chkAll;
    }
}