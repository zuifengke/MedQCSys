namespace Heren.MedQC.Search.Forms
{
    partial class OrdersSearchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBedNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInpNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtOrderText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeptName,
            this.colPatientName,
            this.colPatientID,
            this.colVisitID,
            this.colBedNO,
            this.colInpNO,
            this.colSex,
            this.colVisitTime});
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1191, 370);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // colDeptName
            // 
            this.colDeptName.FillWeight = 140F;
            this.colDeptName.HeaderText = "科室";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.Width = 150;
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "病人姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            this.colPatientName.Width = 120;
            // 
            // colPatientID
            // 
            this.colPatientID.HeaderText = "病人ID号";
            this.colPatientID.Name = "colPatientID";
            this.colPatientID.ReadOnly = true;
            // 
            // colVisitID
            // 
            this.colVisitID.HeaderText = "就诊ID号";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            // 
            // colBedNO
            // 
            this.colBedNO.FillWeight = 70F;
            this.colBedNO.HeaderText = "床号";
            this.colBedNO.Name = "colBedNO";
            this.colBedNO.ReadOnly = true;
            this.colBedNO.Width = 70;
            // 
            // colInpNO
            // 
            this.colInpNO.FillWeight = 88F;
            this.colInpNO.HeaderText = "住院号";
            this.colInpNO.Name = "colInpNO";
            this.colInpNO.ReadOnly = true;
            this.colInpNO.Width = 88;
            // 
            // colSex
            // 
            this.colSex.FillWeight = 70F;
            this.colSex.HeaderText = "性别";
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.Width = 70;
            // 
            // colVisitTime
            // 
            this.colVisitTime.FillWeight = 150F;
            this.colVisitTime.HeaderText = "入院时间";
            this.colVisitTime.Name = "colVisitTime";
            this.colVisitTime.ReadOnly = true;
            this.colVisitTime.Width = 150;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(1039, 384);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(78, 28);
            this.btnExportExcel.TabIndex = 36;
            this.btnExportExcel.Text = "Excel导出";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // cboDeptName
            // 
            this.cboDeptName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDeptName.DroppedDown = false;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.Location = new System.Drawing.Point(41, 387);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.SelectedItem = null;
            this.cboDeptName.Size = new System.Drawing.Size(194, 23);
            this.cboDeptName.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(3, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "科室";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(1128, 384);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 28);
            this.btnPrint.TabIndex = 34;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnQuery.Location = new System.Drawing.Point(539, 387);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 28);
            this.btnQuery.TabIndex = 32;
            this.btnQuery.Text = "查询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtOrderText
            // 
            this.txtOrderText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOrderText.Location = new System.Drawing.Point(346, 390);
            this.txtOrderText.Name = "txtOrderText";
            this.txtOrderText.Size = new System.Drawing.Size(153, 21);
            this.txtOrderText.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(258, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "医嘱内容：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(241, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 28;
            this.label2.Tag = "必须选择科室";
            this.label2.Text = "*";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(504, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 28;
            this.label4.Tag = "必须输入医嘱内容";
            this.label4.Text = "*";
            // 
            // OrdersSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderText);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.cboDeptName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnQuery);
            this.Name = "OrdersSearchForm";
            this.Text = "全院医嘱检索";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExportExcel;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtOrderText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBedNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInpNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}