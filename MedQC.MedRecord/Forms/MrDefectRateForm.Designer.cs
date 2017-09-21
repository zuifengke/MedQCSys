namespace Heren.MedQC.MedRecord
{
    partial class MrDefectRateForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dtTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.xPanel1 = new Heren.Common.Forms.XPanel();
            this.dataTableView2 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_2_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_DISCHARGE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_HOS_ASSESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xSplitter1 = new Heren.Common.Forms.XSplitter();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_DEPT_ADMISSION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DefectCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DefectRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DischargeCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel6
            // 
            this.xLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel6.Location = new System.Drawing.Point(218, 10);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(14, 14);
            this.xLabel6.TabIndex = 2;
            this.xLabel6.Text = "-";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(458, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.dtTimeEnd);
            this.panel1.Controls.Add(this.dtTimeBegin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(536, 6);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 23);
            this.btnExportExcel.TabIndex = 16;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dtTimeEnd
            // 
            this.dtTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTimeEnd.Location = new System.Drawing.Point(235, 7);
            this.dtTimeEnd.Name = "dtTimeEnd";
            this.dtTimeEnd.Size = new System.Drawing.Size(121, 23);
            this.dtTimeEnd.TabIndex = 2;
            // 
            // dtTimeBegin
            // 
            this.dtTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTimeBegin.Location = new System.Drawing.Point(93, 7);
            this.dtTimeBegin.Name = "dtTimeBegin";
            this.dtTimeBegin.Size = new System.Drawing.Size(122, 23);
            this.dtTimeBegin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "出院时间：";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "按科室",
            "按医疗组",
            "按医生"});
            this.comboBox1.Location = new System.Drawing.Point(364, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(87, 22);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "按科室";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.dataTableView2);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xPanel1.Location = new System.Drawing.Point(367, 35);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(653, 474);
            this.xPanel1.TabIndex = 3;
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
            this.dataTableView2.ColumnHeadersHeight = 20;
            this.dataTableView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataTableView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_2_DEPT_NAME,
            this.col_2_PATIENT_NAME,
            this.col_2_PATIENT_ID,
            this.col_2_DISCHARGE_TIME,
            this.col_2_HOS_ASSESS});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataTableView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView2.Location = new System.Drawing.Point(0, 0);
            this.dataTableView2.Name = "dataTableView2";
            this.dataTableView2.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataTableView2.RowHeadersVisible = false;
            this.dataTableView2.Size = new System.Drawing.Size(653, 474);
            this.dataTableView2.TabIndex = 2;
            this.dataTableView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView2_CellMouseDoubleClick);
            // 
            // col_2_DEPT_NAME
            // 
            this.col_2_DEPT_NAME.HeaderText = "责任科室";
            this.col_2_DEPT_NAME.Name = "col_2_DEPT_NAME";
            this.col_2_DEPT_NAME.ReadOnly = true;
            this.col_2_DEPT_NAME.Width = 200;
            // 
            // col_2_PATIENT_NAME
            // 
            this.col_2_PATIENT_NAME.FillWeight = 102.1956F;
            this.col_2_PATIENT_NAME.HeaderText = "患者姓名";
            this.col_2_PATIENT_NAME.Name = "col_2_PATIENT_NAME";
            this.col_2_PATIENT_NAME.ReadOnly = true;
            this.col_2_PATIENT_NAME.Width = 80;
            // 
            // col_2_PATIENT_ID
            // 
            this.col_2_PATIENT_ID.HeaderText = "患者ID号";
            this.col_2_PATIENT_ID.Name = "col_2_PATIENT_ID";
            this.col_2_PATIENT_ID.ReadOnly = true;
            this.col_2_PATIENT_ID.Width = 90;
            // 
            // col_2_DISCHARGE_TIME
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_2_DISCHARGE_TIME.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_2_DISCHARGE_TIME.HeaderText = "出院时间";
            this.col_2_DISCHARGE_TIME.Name = "col_2_DISCHARGE_TIME";
            this.col_2_DISCHARGE_TIME.ReadOnly = true;
            this.col_2_DISCHARGE_TIME.Width = 150;
            // 
            // col_2_HOS_ASSESS
            // 
            this.col_2_HOS_ASSESS.HeaderText = "评分结果";
            this.col_2_HOS_ASSESS.Name = "col_2_HOS_ASSESS";
            this.col_2_HOS_ASSESS.ReadOnly = true;
            // 
            // xSplitter1
            // 
            this.xSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xSplitter1.Location = new System.Drawing.Point(355, 35);
            this.xSplitter1.Name = "xSplitter1";
            this.xSplitter1.Size = new System.Drawing.Size(12, 474);
            this.xSplitter1.TabIndex = 4;
            this.xSplitter1.TabStop = false;
            // 
            // dataTableView1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataTableView1.ColumnHeadersHeight = 20;
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_DEPT_ADMISSION_NAME,
            this.col_DefectCount,
            this.col_DefectRate,
            this.col_DischargeCount});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 35);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(355, 474);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // col_DEPT_ADMISSION_NAME
            // 
            this.col_DEPT_ADMISSION_NAME.HeaderText = "责任科室";
            this.col_DEPT_ADMISSION_NAME.Name = "col_DEPT_ADMISSION_NAME";
            this.col_DEPT_ADMISSION_NAME.ReadOnly = true;
            this.col_DEPT_ADMISSION_NAME.Width = 200;
            // 
            // col_DefectCount
            // 
            this.col_DefectCount.FillWeight = 102.1956F;
            this.col_DefectCount.HeaderText = "缺陷例数";
            this.col_DefectCount.Name = "col_DefectCount";
            this.col_DefectCount.ReadOnly = true;
            this.col_DefectCount.Width = 150;
            // 
            // col_DefectRate
            // 
            this.col_DefectRate.HeaderText = "缺陷率(%)";
            this.col_DefectRate.Name = "col_DefectRate";
            this.col_DefectRate.ReadOnly = true;
            this.col_DefectRate.Width = 150;
            // 
            // col_DischargeCount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_DischargeCount.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_DischargeCount.HeaderText = "出院人数";
            this.col_DischargeCount.Name = "col_DischargeCount";
            this.col_DischargeCount.ReadOnly = true;
            this.col_DischargeCount.Width = 150;
            // 
            // MrDefectRateForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 509);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.xSplitter1);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MrDefectRateForm";
            this.Text = "病案缺陷率统计";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private Common.Forms.XLabel xLabel6;
        private Common.Forms.XButton btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTimeBegin;
        private System.Windows.Forms.DateTimePicker dtTimeEnd;
        private Common.Forms.XPanel xPanel1;
        private Common.Controls.TableView.DataTableView dataTableView2;
        private Common.Forms.XSplitter xSplitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DEPT_ADMISSION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DefectCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DefectRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DischargeCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_DISCHARGE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_HOS_ASSESS;
        private System.Windows.Forms.Button btnExportExcel;
    }
}