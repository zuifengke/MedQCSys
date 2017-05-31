namespace Heren.MedQC.MedRecord
{
    partial class RecPrintLogSearchForm
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
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.dtTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PATIENT_NAME = new System.Windows.Forms.TextBox();
            this.col_PRINT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PRINT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PRINT_ID_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RELATIONSHIP_PATIENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DISCHARGE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_REMARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_INVOICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.col_PRINT_TIME,
            this.col_PATIENT_ID,
            this.col_PATIENT_NAME,
            this.col_PATIENT_ID_NO,
            this.col_PRINT_NAME,
            this.col_PRINT_ID_NO,
            this.col_RELATIONSHIP_PATIENT,
            this.col_DISCHARGE_TIME,
            this.col_REMARKS,
            this.col_MONEY,
            this.col_INVOICE});
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
            // xLabel6
            // 
            this.xLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel6.Location = new System.Drawing.Point(201, 10);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(14, 14);
            this.xLabel6.TabIndex = 2;
            this.xLabel6.Text = "-";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(507, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_PATIENT_NAME);
            this.panel1.Controls.Add(this.dtTimeEnd);
            this.panel1.Controls.Add(this.dtTimeBegin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 35);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "复印日期：";
            // 
            // dtTimeBegin
            // 
            this.dtTimeBegin.Location = new System.Drawing.Point(96, 7);
            this.dtTimeBegin.Name = "dtTimeBegin";
            this.dtTimeBegin.Size = new System.Drawing.Size(103, 21);
            this.dtTimeBegin.TabIndex = 10;
            // 
            // dtTimeEnd
            // 
            this.dtTimeEnd.Location = new System.Drawing.Point(218, 7);
            this.dtTimeEnd.Name = "dtTimeEnd";
            this.dtTimeEnd.Size = new System.Drawing.Size(103, 21);
            this.dtTimeEnd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(327, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "患者姓名：";
            // 
            // txt_PATIENT_NAME
            // 
            this.txt_PATIENT_NAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PATIENT_NAME.Location = new System.Drawing.Point(401, 6);
            this.txt_PATIENT_NAME.Name = "txt_PATIENT_NAME";
            this.txt_PATIENT_NAME.Size = new System.Drawing.Size(100, 23);
            this.txt_PATIENT_NAME.TabIndex = 11;
            // 
            // col_PRINT_TIME
            // 
            this.col_PRINT_TIME.HeaderText = "复印日期";
            this.col_PRINT_TIME.Name = "col_PRINT_TIME";
            this.col_PRINT_TIME.ReadOnly = true;
            this.col_PRINT_TIME.Width = 120;
            // 
            // col_PATIENT_ID
            // 
            this.col_PATIENT_ID.FillWeight = 102.1956F;
            this.col_PATIENT_ID.HeaderText = "患者ID号";
            this.col_PATIENT_ID.Name = "col_PATIENT_ID";
            this.col_PATIENT_ID.ReadOnly = true;
            this.col_PATIENT_ID.Width = 80;
            // 
            // col_PATIENT_NAME
            // 
            this.col_PATIENT_NAME.HeaderText = "患者姓名";
            this.col_PATIENT_NAME.Name = "col_PATIENT_NAME";
            this.col_PATIENT_NAME.ReadOnly = true;
            this.col_PATIENT_NAME.Width = 80;
            // 
            // col_PATIENT_ID_NO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_PATIENT_ID_NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_PATIENT_ID_NO.HeaderText = "患者身份证";
            this.col_PATIENT_ID_NO.Name = "col_PATIENT_ID_NO";
            this.col_PATIENT_ID_NO.ReadOnly = true;
            this.col_PATIENT_ID_NO.Width = 150;
            // 
            // col_PRINT_NAME
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_PRINT_NAME.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_PRINT_NAME.FillWeight = 93.80241F;
            this.col_PRINT_NAME.HeaderText = "复印人姓名";
            this.col_PRINT_NAME.Name = "col_PRINT_NAME";
            this.col_PRINT_NAME.ReadOnly = true;
            // 
            // col_PRINT_ID_NO
            // 
            this.col_PRINT_ID_NO.HeaderText = "复印人身份证";
            this.col_PRINT_ID_NO.Name = "col_PRINT_ID_NO";
            this.col_PRINT_ID_NO.ReadOnly = true;
            this.col_PRINT_ID_NO.Width = 150;
            // 
            // col_RELATIONSHIP_PATIENT
            // 
            this.col_RELATIONSHIP_PATIENT.HeaderText = "与患者关系";
            this.col_RELATIONSHIP_PATIENT.Name = "col_RELATIONSHIP_PATIENT";
            this.col_RELATIONSHIP_PATIENT.ReadOnly = true;
            // 
            // col_DISCHARGE_TIME
            // 
            this.col_DISCHARGE_TIME.HeaderText = "出院时间";
            this.col_DISCHARGE_TIME.Name = "col_DISCHARGE_TIME";
            this.col_DISCHARGE_TIME.ReadOnly = true;
            this.col_DISCHARGE_TIME.Width = 120;
            // 
            // col_REMARKS
            // 
            this.col_REMARKS.HeaderText = "备注";
            this.col_REMARKS.Name = "col_REMARKS";
            this.col_REMARKS.ReadOnly = true;
            // 
            // col_MONEY
            // 
            this.col_MONEY.HeaderText = "金额";
            this.col_MONEY.Name = "col_MONEY";
            this.col_MONEY.ReadOnly = true;
            // 
            // col_INVOICE
            // 
            this.col_INVOICE.HeaderText = "是否开具发票";
            this.col_INVOICE.Name = "col_INVOICE";
            this.col_INVOICE.ReadOnly = true;
            // 
            // RecPrintLogSearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 509);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecPrintLogSearchForm";
            this.Text = "复印查询";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private Common.Forms.XLabel xLabel6;
        private Common.Forms.XButton btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTimeBegin;
        private System.Windows.Forms.DateTimePicker dtTimeEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PRINT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PRINT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PRINT_ID_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RELATIONSHIP_PATIENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DISCHARGE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_REMARKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_INVOICE;
    }
}