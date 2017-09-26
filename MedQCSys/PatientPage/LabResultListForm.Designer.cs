namespace MedQCSys.DockForms
{
    partial class LabResultListForm
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
            this.dgvLabMaster = new System.Windows.Forms.DataGridView();
            this.dgvLabResult = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkPrintAll = new System.Windows.Forms.CheckBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.colNeedPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRequestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYiChang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferContext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAbnormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabResult)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabTestInfoList
            // 
            this.dgvLabMaster.AllowUserToAddRows = false;
            this.dgvLabMaster.AllowUserToDeleteRows = false;
            this.dgvLabMaster.AllowUserToOrderColumns = true;
            this.dgvLabMaster.AllowUserToResizeRows = false;
            this.dgvLabMaster.BackgroundColor = System.Drawing.Color.White;
            this.dgvLabMaster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLabMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNeedPrint,
            this.colRequestTime,
            this.colSubject,
            this.colResultStatus,
            this.colRequestDoctor,
            this.colSpecimen,
            this.colReportTime,
            this.colReportDoctor,
            this.colYiChang});
            this.dgvLabMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLabMaster.Location = new System.Drawing.Point(0, 0);
            this.dgvLabMaster.MultiSelect = false;
            this.dgvLabMaster.Name = "LabTestInfoList";
            this.dgvLabMaster.RowHeadersVisible = false;
            this.dgvLabMaster.RowTemplate.Height = 27;
            this.dgvLabMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLabMaster.Size = new System.Drawing.Size(632, 471);
            this.dgvLabMaster.TabIndex = 3;
            this.dgvLabMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LabTestInfoList_CellClick);
            this.dgvLabMaster.SelectionChanged += new System.EventHandler(this.LabTestInfoList_SelectionChanged);
            // 
            // ResultList
            // 
            this.dgvLabResult.AllowUserToAddRows = false;
            this.dgvLabResult.AllowUserToDeleteRows = false;
            this.dgvLabResult.AllowUserToOrderColumns = true;
            this.dgvLabResult.AllowUserToResizeRows = false;
            this.dgvLabResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLabResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvLabResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLabResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemName,
            this.colResult,
            this.colUnit,
            this.colReferContext,
            this.colAbnormal});
            this.dgvLabResult.Location = new System.Drawing.Point(1, 21);
            this.dgvLabResult.Name = "ResultList";
            this.dgvLabResult.ReadOnly = true;
            this.dgvLabResult.RowHeadersVisible = false;
            this.dgvLabResult.RowTemplate.Height = 27;
            this.dgvLabResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLabResult.Size = new System.Drawing.Size(449, 447);
            this.dgvLabResult.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "检验详细信息";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvLabMaster);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvLabResult);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1087, 471);
            this.splitContainer1.SplitterDistance = 632;
            this.splitContainer1.TabIndex = 9;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(1009, 474);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkPrintAll
            // 
            this.chkPrintAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPrintAll.AutoSize = true;
            this.chkPrintAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPrintAll.Location = new System.Drawing.Point(7, 481);
            this.chkPrintAll.Name = "chkPrintAll";
            this.chkPrintAll.Size = new System.Drawing.Size(138, 18);
            this.chkPrintAll.TabIndex = 12;
            this.chkPrintAll.Text = "打印所有检验记录";
            this.chkPrintAll.UseVisualStyleBackColor = true;
            this.chkPrintAll.CheckedChanged += new System.EventHandler(this.ckbPrintAll_CheckedChanged);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(917, 474);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 13;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // colNeedPrint
            // 
            this.colNeedPrint.FillWeight = 48F;
            this.colNeedPrint.HeaderText = "打印";
            this.colNeedPrint.Name = "colNeedPrint";
            this.colNeedPrint.Width = 48;
            // 
            // colRequestTime
            // 
            this.colRequestTime.HeaderText = "申请日期";
            this.colRequestTime.Name = "colRequestTime";
            this.colRequestTime.ReadOnly = true;
            // 
            // colSubject
            // 
            this.colSubject.FillWeight = 150F;
            this.colSubject.HeaderText = "内容";
            this.colSubject.Name = "colSubject";
            this.colSubject.ReadOnly = true;
            this.colSubject.Width = 150;
            // 
            // colResultStatus
            // 
            this.colResultStatus.FillWeight = 88F;
            this.colResultStatus.HeaderText = "状态";
            this.colResultStatus.Name = "colResultStatus";
            this.colResultStatus.ReadOnly = true;
            this.colResultStatus.Width = 88;
            // 
            // colRequestDoctor
            // 
            this.colRequestDoctor.FillWeight = 88F;
            this.colRequestDoctor.HeaderText = "开立医生";
            this.colRequestDoctor.Name = "colRequestDoctor";
            this.colRequestDoctor.ReadOnly = true;
            this.colRequestDoctor.Width = 88;
            // 
            // colSpecimen
            // 
            this.colSpecimen.FillWeight = 88F;
            this.colSpecimen.HeaderText = "标本";
            this.colSpecimen.Name = "colSpecimen";
            this.colSpecimen.ReadOnly = true;
            this.colSpecimen.Width = 88;
            // 
            // colReportTime
            // 
            this.colReportTime.HeaderText = "报告日期";
            this.colReportTime.Name = "colReportTime";
            this.colReportTime.ReadOnly = true;
            this.colReportTime.Visible = false;
            // 
            // colReportDoctor
            // 
            this.colReportDoctor.FillWeight = 80F;
            this.colReportDoctor.HeaderText = "报告人";
            this.colReportDoctor.Name = "colReportDoctor";
            this.colReportDoctor.ReadOnly = true;
            this.colReportDoctor.Visible = false;
            this.colReportDoctor.Width = 80;
            // 
            // colYiChang
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colYiChang.DefaultCellStyle = dataGridViewCellStyle1;
            this.colYiChang.HeaderText = "异";
            this.colYiChang.Name = "colYiChang";
            this.colYiChang.Width = 30;
            // 
            // colItemName
            // 
            this.colItemName.FillWeight = 120F;
            this.colItemName.HeaderText = "检验项目";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 120;
            // 
            // colResult
            // 
            this.colResult.FillWeight = 66F;
            this.colResult.HeaderText = "结果";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Width = 66;
            // 
            // colUnit
            // 
            this.colUnit.FillWeight = 66F;
            this.colUnit.HeaderText = "单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.Width = 66;
            // 
            // colReferContext
            // 
            this.colReferContext.FillWeight = 120F;
            this.colReferContext.HeaderText = "参考值";
            this.colReferContext.Name = "colReferContext";
            this.colReferContext.ReadOnly = true;
            this.colReferContext.Width = 120;
            // 
            // colAbnormal
            // 
            this.colAbnormal.FillWeight = 66F;
            this.colAbnormal.HeaderText = "异";
            this.colAbnormal.Name = "colAbnormal";
            this.colAbnormal.ReadOnly = true;
            this.colAbnormal.Width = 30;
            // 
            // TestResultListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1095, 503);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.chkPrintAll);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "TestResultListForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "检验记录";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabResult)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLabMaster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLabResult;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkPrintAll;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNeedPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecimen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYiChang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferContext;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAbnormal;
    }
}