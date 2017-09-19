namespace Heren.MedQC.MedRecord
{
    partial class RecMrBatchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_BATCH_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SEND_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SEND_DOCTOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SEND_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MR_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PAPER_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_WORKER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_WORKER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RECEIVE_DOCTOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RECEIVE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceive = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_BATCH_NO = new System.Windows.Forms.TextBox();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.dtTimeEnd = new Heren.Common.Forms.XDateTime();
            this.dtTimeBegin = new Heren.Common.Forms.XDateTime();
            this.xLabel2 = new Heren.Common.Forms.XLabel();
            this.xLabel7 = new Heren.Common.Forms.XLabel();
            this.findComboBox1 = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel5 = new Heren.Common.Forms.XLabel();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel6 = new Heren.Common.Forms.XLabel();
            this.xLabel1 = new Heren.Common.Forms.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTableView1
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataTableView1.ColumnHeadersHeight = 20;
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_BATCH_NO,
            this.col_SEND_DEPT_NAME,
            this.col_SEND_DOCTOR_NAME,
            this.col_SEND_TIME,
            this.col_MR_COUNT,
            this.col_PAPER_COUNT,
            this.col_WORKER_NAME,
            this.col_WORKER_ID,
            this.col_REMARK,
            this.col_RECEIVE_DOCTOR_NAME,
            this.col_RECEIVE_TIME,
            this.colReceive});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 55);
            this.dataTableView1.Name = "dataTableView1";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(736, 454);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // col_BATCH_NO
            // 
            this.col_BATCH_NO.HeaderText = "批号";
            this.col_BATCH_NO.Name = "col_BATCH_NO";
            this.col_BATCH_NO.Width = 120;
            // 
            // col_SEND_DEPT_NAME
            // 
            this.col_SEND_DEPT_NAME.HeaderText = "发送病区";
            this.col_SEND_DEPT_NAME.Name = "col_SEND_DEPT_NAME";
            // 
            // col_SEND_DOCTOR_NAME
            // 
            this.col_SEND_DOCTOR_NAME.FillWeight = 102.1956F;
            this.col_SEND_DOCTOR_NAME.HeaderText = "发送人";
            this.col_SEND_DOCTOR_NAME.Name = "col_SEND_DOCTOR_NAME";
            this.col_SEND_DOCTOR_NAME.Width = 80;
            // 
            // col_SEND_TIME
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_SEND_TIME.DefaultCellStyle = dataGridViewCellStyle12;
            this.col_SEND_TIME.HeaderText = "发送时间";
            this.col_SEND_TIME.Name = "col_SEND_TIME";
            this.col_SEND_TIME.Width = 120;
            // 
            // col_MR_COUNT
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_MR_COUNT.DefaultCellStyle = dataGridViewCellStyle13;
            this.col_MR_COUNT.FillWeight = 93.80241F;
            this.col_MR_COUNT.HeaderText = "病案份数";
            this.col_MR_COUNT.Name = "col_MR_COUNT";
            this.col_MR_COUNT.Width = 60;
            // 
            // col_PAPER_COUNT
            // 
            this.col_PAPER_COUNT.FillWeight = 117.631F;
            this.col_PAPER_COUNT.HeaderText = "张数";
            this.col_PAPER_COUNT.Name = "col_PAPER_COUNT";
            this.col_PAPER_COUNT.Width = 120;
            // 
            // col_WORKER_NAME
            // 
            this.col_WORKER_NAME.HeaderText = "工人姓名";
            this.col_WORKER_NAME.Name = "col_WORKER_NAME";
            this.col_WORKER_NAME.Width = 120;
            // 
            // col_WORKER_ID
            // 
            this.col_WORKER_ID.HeaderText = "工人ID";
            this.col_WORKER_ID.Name = "col_WORKER_ID";
            this.col_WORKER_ID.Width = 80;
            // 
            // col_REMARK
            // 
            this.col_REMARK.HeaderText = "备注";
            this.col_REMARK.Name = "col_REMARK";
            // 
            // col_RECEIVE_DOCTOR_NAME
            // 
            this.col_RECEIVE_DOCTOR_NAME.HeaderText = "接收人";
            this.col_RECEIVE_DOCTOR_NAME.Name = "col_RECEIVE_DOCTOR_NAME";
            this.col_RECEIVE_DOCTOR_NAME.Width = 80;
            // 
            // col_RECEIVE_TIME
            // 
            this.col_RECEIVE_TIME.HeaderText = "接收时间";
            this.col_RECEIVE_TIME.Name = "col_RECEIVE_TIME";
            this.col_RECEIVE_TIME.Width = 120;
            // 
            // colReceive
            // 
            this.colReceive.HeaderText = "接收";
            this.colReceive.Image = global::Heren.MedQC.MedRecord.Properties.Resources.receive;
            this.colReceive.Name = "colReceive";
            this.colReceive.ToolTipText = "归档";
            this.colReceive.Width = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_BATCH_NO);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtTimeEnd);
            this.panel1.Controls.Add(this.dtTimeBegin);
            this.panel1.Controls.Add(this.xLabel2);
            this.panel1.Controls.Add(this.xLabel7);
            this.panel1.Controls.Add(this.findComboBox1);
            this.panel1.Controls.Add(this.xLabel5);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.xLabel6);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 55);
            this.panel1.TabIndex = 0;
            // 
            // txt_BATCH_NO
            // 
            this.txt_BATCH_NO.Location = new System.Drawing.Point(85, 6);
            this.txt_BATCH_NO.Name = "txt_BATCH_NO";
            this.txt_BATCH_NO.Size = new System.Drawing.Size(164, 21);
            this.txt_BATCH_NO.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(519, 29);
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
            this.dtTimeEnd.Location = new System.Drawing.Point(223, 31);
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
            this.dtTimeBegin.Location = new System.Drawing.Point(95, 31);
            this.dtTimeBegin.Name = "dtTimeBegin";
            this.dtTimeBegin.NullableValue = new System.DateTime(2017, 1, 18, 0, 0, 0, 0);
            this.dtTimeBegin.ShowHour = false;
            this.dtTimeBegin.ShowMinute = false;
            this.dtTimeBegin.ShowSecond = false;
            this.dtTimeBegin.Size = new System.Drawing.Size(106, 21);
            this.dtTimeBegin.TabIndex = 6;
            // 
            // xLabel2
            // 
            this.xLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel2.Location = new System.Drawing.Point(12, 9);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(77, 14);
            this.xLabel2.TabIndex = 4;
            this.xLabel2.Text = "发送批次：";
            // 
            // xLabel7
            // 
            this.xLabel7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel7.Location = new System.Drawing.Point(12, 34);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(77, 14);
            this.xLabel7.TabIndex = 4;
            this.xLabel7.Text = "发送日期：";
            // 
            // findComboBox1
            // 
            this.findComboBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.findComboBox1.Items.AddRange(new object[] {
            "全部",
            "未发送",
            "已发送",
            "已接收"});
            this.findComboBox1.Location = new System.Drawing.Point(430, 31);
            this.findComboBox1.Name = "findComboBox1";
            this.findComboBox1.Size = new System.Drawing.Size(81, 21);
            this.findComboBox1.TabIndex = 3;
            this.findComboBox1.Text = "全部";
            // 
            // xLabel5
            // 
            this.xLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel5.Location = new System.Drawing.Point(350, 34);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(77, 14);
            this.xLabel5.TabIndex = 2;
            this.xLabel5.Text = "纸质病历：";
            // 
            // cboDeptName
            // 
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDeptName.Location = new System.Drawing.Point(317, 8);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(194, 21);
            this.cboDeptName.TabIndex = 3;
            // 
            // xLabel6
            // 
            this.xLabel6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel6.Location = new System.Drawing.Point(205, 35);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(14, 14);
            this.xLabel6.TabIndex = 2;
            this.xLabel6.Text = "-";
            // 
            // xLabel1
            // 
            this.xLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel1.Location = new System.Drawing.Point(262, 11);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(49, 14);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "病区：";
            // 
            // RecMrBatchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 509);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecMrBatchForm";
            this.Text = "纸质病历批次查询";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private Heren.Common.Forms.XLabel xLabel1;
        private Heren.Common.Forms.XDateTime dtTimeBegin;
        private Heren.Common.Forms.XLabel xLabel6;
        private Heren.Common.Forms.XDateTime dtTimeEnd;
        private Heren.Common.Forms.XButton btnSearch;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private Common.Controls.DictInput.FindComboBox findComboBox1;
        private Common.Forms.XLabel xLabel5;
        private Common.Forms.XLabel xLabel2;
        private Common.Forms.XLabel xLabel7;
        private System.Windows.Forms.TextBox txt_BATCH_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_BATCH_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SEND_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SEND_DOCTOR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SEND_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MR_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PAPER_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_WORKER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_WORKER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_REMARK;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RECEIVE_DOCTOR_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_RECEIVE_TIME;
        private System.Windows.Forms.DataGridViewImageColumn colReceive;
    }
}