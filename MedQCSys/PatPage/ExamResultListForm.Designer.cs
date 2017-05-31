namespace MedQCSys.DockForms
{
    partial class ExamResultListForm
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
            this.ExamList = new System.Windows.Forms.DataGridView();
            this.txtReportDetial = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.colRequestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExamClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReportDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ExamList)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExamList
            // 
            this.ExamList.AllowUserToAddRows = false;
            this.ExamList.AllowUserToDeleteRows = false;
            this.ExamList.AllowUserToResizeRows = false;
            this.ExamList.BackgroundColor = System.Drawing.Color.White;
            this.ExamList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ExamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRequestTime,
            this.colExamClass,
            this.colResultStatus,
            this.colRequestDoctor,
            this.colReportTime,
            this.colReportDoctor});
            this.ExamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExamList.Location = new System.Drawing.Point(0, 0);
            this.ExamList.MultiSelect = false;
            this.ExamList.Name = "ExamList";
            this.ExamList.ReadOnly = true;
            this.ExamList.RowHeadersVisible = false;
            this.ExamList.RowTemplate.Height = 27;
            this.ExamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExamList.Size = new System.Drawing.Size(568, 447);
            this.ExamList.TabIndex = 2;
            this.ExamList.SelectionChanged += new System.EventHandler(this.ExamList_SelectionChanged);
            // 
            // txtReportDetial
            // 
            this.txtReportDetial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportDetial.BackColor = System.Drawing.Color.White;
            this.txtReportDetial.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReportDetial.Location = new System.Drawing.Point(2, 23);
            this.txtReportDetial.Name = "txtReportDetial";
            this.txtReportDetial.ReadOnly = true;
            this.txtReportDetial.Size = new System.Drawing.Size(321, 420);
            this.txtReportDetial.TabIndex = 3;
            this.txtReportDetial.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "检查详细信息";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ExamList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtReportDetial);
            this.splitContainer1.Size = new System.Drawing.Size(899, 447);
            this.splitContainer1.SplitterDistance = 568;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 8;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(823, 455);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // colRequestTime
            // 
            this.colRequestTime.HeaderText = "申请日期";
            this.colRequestTime.Name = "colRequestTime";
            this.colRequestTime.ReadOnly = true;
            // 
            // colExamClass
            // 
            this.colExamClass.FillWeight = 150F;
            this.colExamClass.HeaderText = "内容";
            this.colExamClass.Name = "colExamClass";
            this.colExamClass.ReadOnly = true;
            this.colExamClass.Width = 250;
            // 
            // colResultStatus
            // 
            this.colResultStatus.HeaderText = "状态";
            this.colResultStatus.Name = "colResultStatus";
            this.colResultStatus.ReadOnly = true;
            this.colResultStatus.Width = 80;
            // 
            // colRequestDoctor
            // 
            this.colRequestDoctor.FillWeight = 80F;
            this.colRequestDoctor.HeaderText = "开立医生";
            this.colRequestDoctor.Name = "colRequestDoctor";
            this.colRequestDoctor.ReadOnly = true;
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
            // ExamResultListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(909, 488);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "ExamResultListForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "检查记录";
            ((System.ComponentModel.ISupportInitialize)(this.ExamList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ExamList;
        private System.Windows.Forms.RichTextBox txtReportDetial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExamClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReportDoctor;
    }
}