namespace Heren.MedQC.MedRecord
{
    partial class RecBrowseRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecBrowseRequestForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.XPanel1 = new Heren.Common.Forms.XPanel();
            this.cboStatus = new Heren.Common.Forms.XComboBox();
            this.btnReject = new Heren.Common.Forms.XButton();
            this.btnApproval = new Heren.Common.Forms.XButton();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.xLabel5 = new Heren.Common.Forms.XLabel();
            this.XLabel1 = new Heren.Common.Forms.XLabel();
            this.txt_PATIENT_ID = new Heren.Common.Forms.XTextBox();
            this.lbl_msg = new Heren.Common.Forms.XLabel();
            this.dtpTimeEnd = new Heren.Common.Forms.XDateTime();
            this.dtpTimeBegin = new Heren.Common.Forms.XDateTime();
            this.XLabel4 = new Heren.Common.Forms.XLabel();
            this.XLabel2 = new Heren.Common.Forms.XLabel();
            this.XDataGrid1 = new Heren.Common.Forms.XDataGrid();
            this.col_Chk = new Heren.Common.Forms.XCheckBoxColumn();
            this.col_PATIENT_NAME = new Heren.Common.Forms.XTextBoxColumn();
            this.col_PATIENT_ID = new Heren.Common.Forms.XTextBoxColumn();
            this.col_VISIT_ID = new Heren.Common.Forms.XTextBoxColumn();
            this.col_VISIT_NO = new Heren.Common.Forms.XTextBoxColumn();
            this.col_DISCHARGE_TIME = new Heren.Common.Forms.XTextBoxColumn();
            this.col_REQUEST_NAME = new Heren.Common.Forms.XTextBoxColumn();
            this.col_REQUEST_TIME = new Heren.Common.Forms.XTextBoxColumn();
            this.col_APPROVAL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_APPROVAL_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.XPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // XPanel1
            // 
            this.XPanel1.Controls.Add(this.cboStatus);
            this.XPanel1.Controls.Add(this.btnReject);
            this.XPanel1.Controls.Add(this.btnApproval);
            this.XPanel1.Controls.Add(this.btnSearch);
            this.XPanel1.Controls.Add(this.xLabel5);
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
            this.XPanel1.Size = new System.Drawing.Size(796, 51);
            this.XPanel1.TabIndex = 7;
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "",
            "已提交",
            "审批通过",
            "审批不通过"});
            this.cboStatus.Location = new System.Drawing.Point(62, 3);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(70, 22);
            this.cboStatus.TabIndex = 0;
            this.cboStatus.Text = "已提交";
            // 
            // btnReject
            // 
            this.btnReject.BindingEvents = new Heren.Common.Forms.BindingEvent[] {
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("btnReject.BindingEvents")))};
            this.btnReject.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReject.Location = new System.Drawing.Point(792, 3);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(94, 23);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "审批不通过";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApproval
            // 
            this.btnApproval.BindingEvents = new Heren.Common.Forms.BindingEvent[] {
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("btnApproval.BindingEvents")))};
            this.btnApproval.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApproval.Location = new System.Drawing.Point(713, 3);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(75, 23);
            this.btnApproval.TabIndex = 4;
            this.btnApproval.Text = "审批选中";
            this.btnApproval.UseVisualStyleBackColor = true;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BindingEvents = new Heren.Common.Forms.BindingEvent[] {
        ((Heren.Common.Forms.BindingEvent)(resources.GetObject("btnSearch.BindingEvents")))};
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(632, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // xLabel5
            // 
            this.xLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel5.Location = new System.Drawing.Point(139, 8);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(77, 14);
            this.xLabel5.TabIndex = 1;
            this.xLabel5.Text = "申请时间：";
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
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(548, 4);
            this.txt_PATIENT_ID.Name = "txt_PATIENT_ID";
            this.txt_PATIENT_ID.Size = new System.Drawing.Size(77, 23);
            this.txt_PATIENT_ID.TabIndex = 3;
            // 
            // lbl_msg
            // 
            this.lbl_msg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_msg.Location = new System.Drawing.Point(15, 31);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(105, 14);
            this.lbl_msg.TabIndex = 1;
            this.lbl_msg.Text = "共{}条申请记录";
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpTimeEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeEnd.Location = new System.Drawing.Point(354, 3);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.NullableValue = null;
            this.dtpTimeEnd.ShowHour = false;
            this.dtpTimeEnd.ShowMinute = false;
            this.dtpTimeEnd.ShowSecond = false;
            this.dtpTimeEnd.Size = new System.Drawing.Size(112, 22);
            this.dtpTimeEnd.TabIndex = 2;
            // 
            // dtpTimeBegin
            // 
            this.dtpTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpTimeBegin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpTimeBegin.Location = new System.Drawing.Point(221, 3);
            this.dtpTimeBegin.Name = "dtpTimeBegin";
            this.dtpTimeBegin.NullableValue = null;
            this.dtpTimeBegin.ShowHour = false;
            this.dtpTimeBegin.ShowMinute = false;
            this.dtpTimeBegin.ShowSecond = false;
            this.dtpTimeBegin.Size = new System.Drawing.Size(114, 23);
            this.dtpTimeBegin.TabIndex = 2;
            // 
            // XLabel4
            // 
            this.XLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XLabel4.Location = new System.Drawing.Point(478, 9);
            this.XLabel4.Name = "XLabel4";
            this.XLabel4.Size = new System.Drawing.Size(77, 14);
            this.XLabel4.TabIndex = 1;
            this.XLabel4.Text = "患者ID号：";
            // 
            // XLabel2
            // 
            this.XLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XLabel2.Location = new System.Drawing.Point(334, 7);
            this.XLabel2.Name = "XLabel2";
            this.XLabel2.Size = new System.Drawing.Size(21, 14);
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
            this.col_PATIENT_NAME,
            this.col_PATIENT_ID,
            this.col_VISIT_ID,
            this.col_VISIT_NO,
            this.col_DISCHARGE_TIME,
            this.col_REQUEST_NAME,
            this.col_REQUEST_TIME,
            this.col_APPROVAL_NAME,
            this.col_APPROVAL_TIME,
            this.col_STATUS,
            this.col_REMARK});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.XDataGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.XDataGrid1.RowHeadersVisible = false;
            this.XDataGrid1.Size = new System.Drawing.Size(796, 522);
            this.XDataGrid1.TabIndex = 8;
            this.XDataGrid1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.XDataGrid1_CellMouseClick);
            this.XDataGrid1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.XDataGrid1_CellMouseDoubleClick);
            // 
            // col_Chk
            // 
            this.col_Chk.HeaderText = "";
            this.col_Chk.Name = "col_Chk";
            this.col_Chk.ReadOnly = true;
            this.col_Chk.Width = 40;
            // 
            // col_PATIENT_NAME
            // 
            this.col_PATIENT_NAME.HeaderText = "姓名";
            this.col_PATIENT_NAME.Name = "col_PATIENT_NAME";
            this.col_PATIENT_NAME.ReadOnly = true;
            // 
            // col_PATIENT_ID
            // 
            this.col_PATIENT_ID.HeaderText = "患者ID号";
            this.col_PATIENT_ID.Name = "col_PATIENT_ID";
            this.col_PATIENT_ID.ReadOnly = true;
            // 
            // col_VISIT_ID
            // 
            this.col_VISIT_ID.HeaderText = "入院次";
            this.col_VISIT_ID.Name = "col_VISIT_ID";
            this.col_VISIT_ID.ReadOnly = true;
            // 
            // col_VISIT_NO
            // 
            this.col_VISIT_NO.HeaderText = "就诊流水号";
            this.col_VISIT_NO.Name = "col_VISIT_NO";
            this.col_VISIT_NO.ReadOnly = true;
            this.col_VISIT_NO.Visible = false;
            // 
            // col_DISCHARGE_TIME
            // 
            this.col_DISCHARGE_TIME.HeaderText = "出院时间";
            this.col_DISCHARGE_TIME.Name = "col_DISCHARGE_TIME";
            this.col_DISCHARGE_TIME.ReadOnly = true;
            this.col_DISCHARGE_TIME.Width = 140;
            // 
            // col_REQUEST_NAME
            // 
            this.col_REQUEST_NAME.HeaderText = "申请人姓名";
            this.col_REQUEST_NAME.Name = "col_REQUEST_NAME";
            this.col_REQUEST_NAME.ReadOnly = true;
            // 
            // col_REQUEST_TIME
            // 
            this.col_REQUEST_TIME.HeaderText = "申请时间";
            this.col_REQUEST_TIME.Name = "col_REQUEST_TIME";
            this.col_REQUEST_TIME.ReadOnly = true;
            this.col_REQUEST_TIME.Width = 120;
            // 
            // col_APPROVAL_NAME
            // 
            this.col_APPROVAL_NAME.HeaderText = "审批人姓名";
            this.col_APPROVAL_NAME.Name = "col_APPROVAL_NAME";
            this.col_APPROVAL_NAME.ReadOnly = true;
            // 
            // col_APPROVAL_TIME
            // 
            this.col_APPROVAL_TIME.HeaderText = "审批时间";
            this.col_APPROVAL_TIME.Name = "col_APPROVAL_TIME";
            this.col_APPROVAL_TIME.ReadOnly = true;
            this.col_APPROVAL_TIME.Width = 120;
            // 
            // col_STATUS
            // 
            this.col_STATUS.HeaderText = "申请状态";
            this.col_STATUS.Name = "col_STATUS";
            this.col_STATUS.ReadOnly = true;
            // 
            // col_REMARK
            // 
            this.col_REMARK.HeaderText = "备注";
            this.col_REMARK.Name = "col_REMARK";
            this.col_REMARK.ReadOnly = true;
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
            // RecBrowseRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(796, 573);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.XDataGrid1);
            this.Controls.Add(this.XPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecBrowseRequestForm";
            this.Text = "病历浏览审核";
            this.XPanel1.ResumeLayout(false);
            this.XPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Common.Forms.XPanel XPanel1;
        private Common.Forms.XComboBox cboStatus;
        private Common.Forms.XButton btnApproval;
        private Common.Forms.XButton btnSearch;
        private Common.Forms.XLabel XLabel1;
        private Common.Forms.XTextBox txt_PATIENT_ID;
        private Common.Forms.XLabel lbl_msg;
        private Common.Forms.XDateTime dtpTimeEnd;
        private Common.Forms.XDateTime dtpTimeBegin;
        private Common.Forms.XLabel XLabel4;
        private Common.Forms.XLabel XLabel2;
        private Common.Forms.XDataGrid XDataGrid1;
        private System.Windows.Forms.CheckBox chkAll;
        private Common.Forms.XButton btnReject;
        private Common.Forms.XLabel xLabel5;
        private Common.Forms.XCheckBoxColumn col_Chk;
        private Common.Forms.XTextBoxColumn col_PATIENT_NAME;
        private Common.Forms.XTextBoxColumn col_PATIENT_ID;
        private Common.Forms.XTextBoxColumn col_VISIT_ID;
        private Common.Forms.XTextBoxColumn col_VISIT_NO;
        private Common.Forms.XTextBoxColumn col_DISCHARGE_TIME;
        private Common.Forms.XTextBoxColumn col_REQUEST_NAME;
        private Common.Forms.XTextBoxColumn col_REQUEST_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_APPROVAL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_APPROVAL_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_REMARK;
    }
}