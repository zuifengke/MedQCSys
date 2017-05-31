namespace Heren.MedQC.MedRecord
{
    partial class MrArchiveRateForm
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
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_DEPT_ADMISSION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_3DayArchiveCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_3DayArchiveRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_7DayArchiveCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_7DayArchiveRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            this.dtTimeBegin = new Heren.Common.Forms.XDateTime();
            this.dtTimeEnd = new Heren.Common.Forms.XDateTime();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.cboTimeType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.col_TotalCount,
            this.col_3DayArchiveCount,
            this.col_3DayArchiveRate,
            this.col_7DayArchiveCount,
            this.col_7DayArchiveRate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 35);
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
            this.dataTableView1.Size = new System.Drawing.Size(1362, 474);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // col_DEPT_ADMISSION_NAME
            // 
            this.col_DEPT_ADMISSION_NAME.HeaderText = "入院科室";
            this.col_DEPT_ADMISSION_NAME.Name = "col_DEPT_ADMISSION_NAME";
            this.col_DEPT_ADMISSION_NAME.ReadOnly = true;
            this.col_DEPT_ADMISSION_NAME.Width = 120;
            // 
            // col_TotalCount
            // 
            this.col_TotalCount.FillWeight = 102.1956F;
            this.col_TotalCount.HeaderText = "总人数";
            this.col_TotalCount.Name = "col_TotalCount";
            this.col_TotalCount.ReadOnly = true;
            // 
            // col_3DayArchiveCount
            // 
            this.col_3DayArchiveCount.HeaderText = "归档人数";
            this.col_3DayArchiveCount.Name = "col_3DayArchiveCount";
            this.col_3DayArchiveCount.ReadOnly = true;
            // 
            // col_3DayArchiveRate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_3DayArchiveRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_3DayArchiveRate.HeaderText = "归档率(%)";
            this.col_3DayArchiveRate.Name = "col_3DayArchiveRate";
            this.col_3DayArchiveRate.ReadOnly = true;
            // 
            // col_7DayArchiveCount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_7DayArchiveCount.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_7DayArchiveCount.FillWeight = 93.80241F;
            this.col_7DayArchiveCount.HeaderText = "归档人数";
            this.col_7DayArchiveCount.Name = "col_7DayArchiveCount";
            this.col_7DayArchiveCount.ReadOnly = true;
            // 
            // col_7DayArchiveRate
            // 
            this.col_7DayArchiveRate.HeaderText = "归档率(%)";
            this.col_7DayArchiveRate.Name = "col_7DayArchiveRate";
            this.col_7DayArchiveRate.ReadOnly = true;
            this.col_7DayArchiveRate.Width = 120;
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
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(348, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.cboTimeType);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtTimeEnd);
            this.panel1.Controls.Add(this.dtTimeBegin);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 35);
            this.panel1.TabIndex = 0;
            // 
            // MrArchiveRateForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 509);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MrArchiveRateForm";
            this.Text = "病案归档率统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private Common.Forms.XLabel xLabel6;
        private Common.Forms.XDateTime dtTimeBegin;
        private Common.Forms.XDateTime dtTimeEnd;
        private Common.Forms.XButton btnSearch;
        private System.Windows.Forms.ComboBox cboTimeType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DEPT_ADMISSION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_3DayArchiveCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_3DayArchiveRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_7DayArchiveCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_7DayArchiveRate;
    }
}