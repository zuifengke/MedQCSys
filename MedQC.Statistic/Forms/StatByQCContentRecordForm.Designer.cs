namespace Heren.MedQC.Statistic
{
    partial class StatByQCContentRecordForm
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
            this.txtVisitID = new System.Windows.Forms.TextBox();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colBugClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBugType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQCExpalin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaitentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocIncharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptIncharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBugCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.btnExcleOut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVisitID
            // 
            this.txtVisitID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVisitID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVisitID.Location = new System.Drawing.Point(777, 9);
            this.txtVisitID.Name = "txtVisitID";
            this.txtVisitID.Size = new System.Drawing.Size(74, 23);
            this.txtVisitID.TabIndex = 29;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatientID.Location = new System.Drawing.Point(635, 9);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(76, 23);
            this.txtPatientID.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(721, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "入院次：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(570, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 28;
            this.label1.Text = "病案号：";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(875, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 28);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBugClass,
            this.colBugType,
            this.colQCExpalin,
            this.colPatientName,
            this.colPaitentID,
            this.colVisitID,
            this.colDocTypeID,
            this.colPoint,
            this.colCheckName,
            this.colCheckDate,
            this.colDocID,
            this.colDocTitle,
            this.colModifyTime,
            this.colCreateID,
            this.colCreateName,
            this.colDocTime,
            this.colDocIncharge,
            this.colDeptIncharge,
            this.colBugCreateTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 43);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 372);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // colBugClass
            // 
            this.colBugClass.HeaderText = "错误级别";
            this.colBugClass.Name = "colBugClass";
            this.colBugClass.ReadOnly = true;
            // 
            // colBugType
            // 
            this.colBugType.HeaderText = "错误类别";
            this.colBugType.Name = "colBugType";
            this.colBugType.ReadOnly = true;
            // 
            // colQCExpalin
            // 
            this.colQCExpalin.HeaderText = "错误描述";
            this.colQCExpalin.Name = "colQCExpalin";
            this.colQCExpalin.ReadOnly = true;
            this.colQCExpalin.Width = 150;
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "患者姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            // 
            // colPaitentID
            // 
            this.colPaitentID.HeaderText = "病案号";
            this.colPaitentID.Name = "colPaitentID";
            this.colPaitentID.ReadOnly = true;
            // 
            // colVisitID
            // 
            this.colVisitID.HeaderText = "入院次";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            // 
            // colDocTypeID
            // 
            this.colDocTypeID.HeaderText = "文书类型ID";
            this.colDocTypeID.Name = "colDocTypeID";
            this.colDocTypeID.ReadOnly = true;
            // 
            // colPoint
            // 
            this.colPoint.HeaderText = "扣分值";
            this.colPoint.Name = "colPoint";
            this.colPoint.ReadOnly = true;
            this.colPoint.Visible = false;
            // 
            // colCheckName
            // 
            this.colCheckName.HeaderText = "检查者";
            this.colCheckName.Name = "colCheckName";
            this.colCheckName.ReadOnly = true;
            // 
            // colCheckDate
            // 
            this.colCheckDate.HeaderText = "检查时间";
            this.colCheckDate.Name = "colCheckDate";
            this.colCheckDate.ReadOnly = true;
            this.colCheckDate.Width = 150;
            // 
            // colDocID
            // 
            this.colDocID.HeaderText = "文档ID";
            this.colDocID.Name = "colDocID";
            this.colDocID.ReadOnly = true;
            this.colDocID.Visible = false;
            // 
            // colDocTitle
            // 
            this.colDocTitle.HeaderText = "文档标题";
            this.colDocTitle.Name = "colDocTitle";
            this.colDocTitle.ReadOnly = true;
            // 
            // colModifyTime
            // 
            this.colModifyTime.HeaderText = "修改时间";
            this.colModifyTime.Name = "colModifyTime";
            this.colModifyTime.ReadOnly = true;
            this.colModifyTime.Width = 150;
            // 
            // colCreateID
            // 
            this.colCreateID.HeaderText = "创建者ID";
            this.colCreateID.Name = "colCreateID";
            this.colCreateID.ReadOnly = true;
            this.colCreateID.Visible = false;
            // 
            // colCreateName
            // 
            this.colCreateName.HeaderText = "创建者";
            this.colCreateName.Name = "colCreateName";
            this.colCreateName.ReadOnly = true;
            // 
            // colDocTime
            // 
            this.colDocTime.HeaderText = "创建时间";
            this.colDocTime.Name = "colDocTime";
            this.colDocTime.ReadOnly = true;
            this.colDocTime.Width = 150;
            // 
            // colDocIncharge
            // 
            this.colDocIncharge.HeaderText = "责任医生";
            this.colDocIncharge.Name = "colDocIncharge";
            this.colDocIncharge.ReadOnly = true;
            // 
            // colDeptIncharge
            // 
            this.colDeptIncharge.HeaderText = "责任科室";
            this.colDeptIncharge.Name = "colDeptIncharge";
            this.colDeptIncharge.ReadOnly = true;
            // 
            // colBugCreateTime
            // 
            this.colBugCreateTime.HeaderText = "记录时间";
            this.colBugCreateTime.Name = "colBugCreateTime";
            this.colBugCreateTime.ReadOnly = true;
            this.colBugCreateTime.Width = 150;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.Location = new System.Drawing.Point(243, 8);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(122, 23);
            this.dtpEndTime.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(219, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 31;
            this.label3.Text = "至";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpBeginTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBeginTime.Location = new System.Drawing.Point(96, 8);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(122, 23);
            this.dtpBeginTime.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "文档修改时间";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(369, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 35;
            this.label5.Text = "责任科室";
            // 
            // cboDeptName
            // 
            this.cboDeptName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDeptName.CandidateWidth = 200;
            this.cboDeptName.DroppedDown = false;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.Location = new System.Drawing.Point(435, 8);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.SelectedItem = null;
            this.cboDeptName.Size = new System.Drawing.Size(129, 23);
            this.cboDeptName.TabIndex = 36;
            // 
            // btnExcleOut
            // 
            this.btnExcleOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcleOut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcleOut.Location = new System.Drawing.Point(960, 6);
            this.btnExcleOut.Name = "btnExcleOut";
            this.btnExcleOut.Size = new System.Drawing.Size(78, 28);
            this.btnExcleOut.TabIndex = 37;
            this.btnExcleOut.Text = "导出Excel";
            this.btnExcleOut.UseVisualStyleBackColor = true;
            this.btnExcleOut.Click += new System.EventHandler(this.btnExcleOut_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtVisitID);
            this.panel1.Controls.Add(this.btnExcleOut);
            this.panel1.Controls.Add(this.dtpBeginTime);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.txtPatientID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 43);
            this.panel1.TabIndex = 38;
            // 
            // StatByQCContentRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 415);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "StatByQCContentRecordForm";
            this.Text = "系统病历内容检查详情";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVisitID;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.Button btnExcleOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBugCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptIncharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocIncharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaitentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCExpalin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBugType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBugClass;
    }
}