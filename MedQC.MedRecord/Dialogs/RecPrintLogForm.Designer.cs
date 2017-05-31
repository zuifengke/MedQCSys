namespace Heren.MedQC.MedRecord.Dialogs
{
    partial class RecPrintLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecPrintLogForm));
            this.xPanel1 = new Heren.Common.Forms.XPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txt_RELATIONSHIP_PATIENT = new System.Windows.Forms.TextBox();
            this.txt_PRINT_IDENTIFICATION = new System.Windows.Forms.TextBox();
            this.txt_PRINT_NAME = new System.Windows.Forms.TextBox();
            this.txt_DISCHARGE_TIME = new MetroFramework.Controls.MetroTextBox();
            this.txt_PATIENT_NAME = new MetroFramework.Controls.MetroTextBox();
            this.txt_PATIENT_IDENTIFICATION = new MetroFramework.Controls.MetroTextBox();
            this.txt_PATIENT_ID = new MetroFramework.Controls.MetroTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p_PRINT_CONTENT = new System.Windows.Forms.FlowLayoutPanel();
            this.xPanel4 = new Heren.Common.Forms.XPanel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.xPanel5 = new Heren.Common.Forms.XPanel();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_PRINT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PRINT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_REMARKS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_MONEY = new System.Windows.Forms.TextBox();
            this.rbtn_INVOICE1 = new MetroFramework.Controls.MetroRadioButton();
            this.rbtn_INVOICE2 = new MetroFramework.Controls.MetroRadioButton();
            this.xPanel3 = new Heren.Common.Forms.XPanel();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel1.Controls.Add(this.metroButton1);
            this.xPanel1.Controls.Add(this.txt_RELATIONSHIP_PATIENT);
            this.xPanel1.Controls.Add(this.txt_PRINT_IDENTIFICATION);
            this.xPanel1.Controls.Add(this.txt_PRINT_NAME);
            this.xPanel1.Controls.Add(this.txt_DISCHARGE_TIME);
            this.xPanel1.Controls.Add(this.txt_PATIENT_NAME);
            this.xPanel1.Controls.Add(this.txt_PATIENT_IDENTIFICATION);
            this.xPanel1.Controls.Add(this.txt_PATIENT_ID);
            this.xPanel1.Controls.Add(this.label7);
            this.xPanel1.Controls.Add(this.label6);
            this.xPanel1.Controls.Add(this.label2);
            this.xPanel1.Controls.Add(this.label5);
            this.xPanel1.Controls.Add(this.label4);
            this.xPanel1.Controls.Add(this.label3);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(23, 70);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(642, 159);
            this.xPanel1.TabIndex = 5;
            // 
            // metroButton1
            // 
            this.metroButton1.Highlight = false;
            this.metroButton1.Location = new System.Drawing.Point(316, 70);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.StyleManager = null;
            this.metroButton1.TabIndex = 17;
            this.metroButton1.Text = "读卡";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txt_RELATIONSHIP_PATIENT
            // 
            this.txt_RELATIONSHIP_PATIENT.Location = new System.Drawing.Point(130, 129);
            this.txt_RELATIONSHIP_PATIENT.Name = "txt_RELATIONSHIP_PATIENT";
            this.txt_RELATIONSHIP_PATIENT.Size = new System.Drawing.Size(177, 23);
            this.txt_RELATIONSHIP_PATIENT.TabIndex = 14;
            // 
            // txt_PRINT_IDENTIFICATION
            // 
            this.txt_PRINT_IDENTIFICATION.Location = new System.Drawing.Point(130, 99);
            this.txt_PRINT_IDENTIFICATION.Name = "txt_PRINT_IDENTIFICATION";
            this.txt_PRINT_IDENTIFICATION.Size = new System.Drawing.Size(177, 23);
            this.txt_PRINT_IDENTIFICATION.TabIndex = 14;
            // 
            // txt_PRINT_NAME
            // 
            this.txt_PRINT_NAME.Location = new System.Drawing.Point(130, 70);
            this.txt_PRINT_NAME.Name = "txt_PRINT_NAME";
            this.txt_PRINT_NAME.Size = new System.Drawing.Size(177, 23);
            this.txt_PRINT_NAME.TabIndex = 15;
            // 
            // txt_DISCHARGE_TIME
            // 
            this.txt_DISCHARGE_TIME.CustomBackground = false;
            this.txt_DISCHARGE_TIME.CustomForeColor = false;
            this.txt_DISCHARGE_TIME.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_DISCHARGE_TIME.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_DISCHARGE_TIME.Location = new System.Drawing.Point(318, 9);
            this.txt_DISCHARGE_TIME.Multiline = false;
            this.txt_DISCHARGE_TIME.Name = "txt_DISCHARGE_TIME";
            this.txt_DISCHARGE_TIME.SelectedText = "";
            this.txt_DISCHARGE_TIME.Size = new System.Drawing.Size(103, 24);
            this.txt_DISCHARGE_TIME.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_DISCHARGE_TIME.StyleManager = null;
            this.txt_DISCHARGE_TIME.TabIndex = 11;
            this.txt_DISCHARGE_TIME.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_DISCHARGE_TIME.UseStyleColors = false;
            // 
            // txt_PATIENT_NAME
            // 
            this.txt_PATIENT_NAME.CustomBackground = false;
            this.txt_PATIENT_NAME.CustomForeColor = false;
            this.txt_PATIENT_NAME.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PATIENT_NAME.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PATIENT_NAME.Location = new System.Drawing.Point(525, 9);
            this.txt_PATIENT_NAME.Multiline = false;
            this.txt_PATIENT_NAME.Name = "txt_PATIENT_NAME";
            this.txt_PATIENT_NAME.SelectedText = "";
            this.txt_PATIENT_NAME.Size = new System.Drawing.Size(95, 24);
            this.txt_PATIENT_NAME.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PATIENT_NAME.StyleManager = null;
            this.txt_PATIENT_NAME.TabIndex = 12;
            this.txt_PATIENT_NAME.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PATIENT_NAME.UseStyleColors = false;
            // 
            // txt_PATIENT_IDENTIFICATION
            // 
            this.txt_PATIENT_IDENTIFICATION.CustomBackground = false;
            this.txt_PATIENT_IDENTIFICATION.CustomForeColor = false;
            this.txt_PATIENT_IDENTIFICATION.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PATIENT_IDENTIFICATION.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PATIENT_IDENTIFICATION.Location = new System.Drawing.Point(130, 40);
            this.txt_PATIENT_IDENTIFICATION.Multiline = false;
            this.txt_PATIENT_IDENTIFICATION.Name = "txt_PATIENT_IDENTIFICATION";
            this.txt_PATIENT_IDENTIFICATION.SelectedText = "";
            this.txt_PATIENT_IDENTIFICATION.Size = new System.Drawing.Size(177, 24);
            this.txt_PATIENT_IDENTIFICATION.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PATIENT_IDENTIFICATION.StyleManager = null;
            this.txt_PATIENT_IDENTIFICATION.TabIndex = 13;
            this.txt_PATIENT_IDENTIFICATION.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PATIENT_IDENTIFICATION.UseStyleColors = false;
            // 
            // txt_PATIENT_ID
            // 
            this.txt_PATIENT_ID.CustomBackground = false;
            this.txt_PATIENT_ID.CustomForeColor = false;
            this.txt_PATIENT_ID.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PATIENT_ID.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(130, 9);
            this.txt_PATIENT_ID.Multiline = false;
            this.txt_PATIENT_ID.Name = "txt_PATIENT_ID";
            this.txt_PATIENT_ID.SelectedText = "";
            this.txt_PATIENT_ID.Size = new System.Drawing.Size(88, 24);
            this.txt_PATIENT_ID.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PATIENT_ID.StyleManager = null;
            this.txt_PATIENT_ID.TabIndex = 13;
            this.txt_PATIENT_ID.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PATIENT_ID.UseStyleColors = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(33, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "与患者关系：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(7, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "复印人员身份证：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(235, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "出院时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(33, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "复印人姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(33, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "患者身份证：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(442, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "患者姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "患者ID号：";
            // 
            // p_PRINT_CONTENT
            // 
            this.p_PRINT_CONTENT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_PRINT_CONTENT.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_PRINT_CONTENT.Location = new System.Drawing.Point(23, 229);
            this.p_PRINT_CONTENT.Name = "p_PRINT_CONTENT";
            this.p_PRINT_CONTENT.Size = new System.Drawing.Size(642, 101);
            this.p_PRINT_CONTENT.TabIndex = 6;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.btnSave);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel4.Location = new System.Drawing.Point(23, 426);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(642, 30);
            this.xPanel4.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Highlight = false;
            this.btnSave.Location = new System.Drawing.Point(564, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSave.StyleManager = null;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // xPanel5
            // 
            this.xPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel5.Controls.Add(this.dataTableView1);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel5.Location = new System.Drawing.Point(23, 456);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(642, 124);
            this.xPanel5.TabIndex = 9;
            this.xPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.xPanel5_Paint);
            // 
            // dataTableView1
            // 
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_PRINT_NAME,
            this.col_PRINT_TIME,
            this.col_MONEY,
            this.colEdit,
            this.colDelete});
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 0);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(640, 122);
            this.dataTableView1.TabIndex = 0;
            this.dataTableView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseClick);
            // 
            // col_PRINT_NAME
            // 
            this.col_PRINT_NAME.HeaderText = "复印人";
            this.col_PRINT_NAME.Name = "col_PRINT_NAME";
            this.col_PRINT_NAME.ReadOnly = true;
            // 
            // col_PRINT_TIME
            // 
            this.col_PRINT_TIME.HeaderText = "复印时间";
            this.col_PRINT_TIME.Name = "col_PRINT_TIME";
            this.col_PRINT_TIME.ReadOnly = true;
            this.col_PRINT_TIME.Width = 120;
            // 
            // col_MONEY
            // 
            this.col_MONEY.HeaderText = "金额";
            this.col_MONEY.Name = "col_MONEY";
            this.col_MONEY.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "编辑";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "删除";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(13, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "备注：";
            // 
            // txt_REMARKS
            // 
            this.txt_REMARKS.Location = new System.Drawing.Point(65, 6);
            this.txt_REMARKS.Name = "txt_REMARKS";
            this.txt_REMARKS.Size = new System.Drawing.Size(177, 23);
            this.txt_REMARKS.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(13, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "金额：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(13, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "是否开发票：";
            // 
            // txt_MONEY
            // 
            this.txt_MONEY.Location = new System.Drawing.Point(65, 35);
            this.txt_MONEY.Name = "txt_MONEY";
            this.txt_MONEY.Size = new System.Drawing.Size(86, 23);
            this.txt_MONEY.TabIndex = 14;
            this.txt_MONEY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MONEY_KeyPress);
            // 
            // rbtn_INVOICE1
            // 
            this.rbtn_INVOICE1.AutoSize = true;
            this.rbtn_INVOICE1.CustomBackground = false;
            this.rbtn_INVOICE1.CustomForeColor = false;
            this.rbtn_INVOICE1.FontSize = MetroFramework.MetroLinkSize.Small;
            this.rbtn_INVOICE1.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.rbtn_INVOICE1.Location = new System.Drawing.Point(104, 68);
            this.rbtn_INVOICE1.Name = "rbtn_INVOICE1";
            this.rbtn_INVOICE1.Size = new System.Drawing.Size(36, 15);
            this.rbtn_INVOICE1.Style = MetroFramework.MetroColorStyle.Blue;
            this.rbtn_INVOICE1.StyleManager = null;
            this.rbtn_INVOICE1.TabIndex = 15;
            this.rbtn_INVOICE1.Text = "是";
            this.rbtn_INVOICE1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.rbtn_INVOICE1.UseStyleColors = false;
            this.rbtn_INVOICE1.UseVisualStyleBackColor = true;
            // 
            // rbtn_INVOICE2
            // 
            this.rbtn_INVOICE2.AutoSize = true;
            this.rbtn_INVOICE2.Checked = true;
            this.rbtn_INVOICE2.CustomBackground = false;
            this.rbtn_INVOICE2.CustomForeColor = false;
            this.rbtn_INVOICE2.FontSize = MetroFramework.MetroLinkSize.Small;
            this.rbtn_INVOICE2.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.rbtn_INVOICE2.Location = new System.Drawing.Point(147, 68);
            this.rbtn_INVOICE2.Name = "rbtn_INVOICE2";
            this.rbtn_INVOICE2.Size = new System.Drawing.Size(36, 15);
            this.rbtn_INVOICE2.Style = MetroFramework.MetroColorStyle.Blue;
            this.rbtn_INVOICE2.StyleManager = null;
            this.rbtn_INVOICE2.TabIndex = 15;
            this.rbtn_INVOICE2.TabStop = true;
            this.rbtn_INVOICE2.Text = "否";
            this.rbtn_INVOICE2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.rbtn_INVOICE2.UseStyleColors = false;
            this.rbtn_INVOICE2.UseVisualStyleBackColor = true;
            // 
            // xPanel3
            // 
            this.xPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel3.Controls.Add(this.rbtn_INVOICE2);
            this.xPanel3.Controls.Add(this.rbtn_INVOICE1);
            this.xPanel3.Controls.Add(this.txt_MONEY);
            this.xPanel3.Controls.Add(this.label10);
            this.xPanel3.Controls.Add(this.label9);
            this.xPanel3.Controls.Add(this.txt_REMARKS);
            this.xPanel3.Controls.Add(this.label8);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.Location = new System.Drawing.Point(23, 330);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(642, 96);
            this.xPanel3.TabIndex = 7;
            // 
            // RecPrintLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 603);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.p_PRINT_CONTENT);
            this.Controls.Add(this.xPanel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "RecPrintLogForm";
            this.Padding = new System.Windows.Forms.Padding(23, 70, 23, 23);
            this.Text = "复印登记";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Forms.XPanel xPanel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.TextBox txt_PRINT_IDENTIFICATION;
        private System.Windows.Forms.TextBox txt_PRINT_NAME;
        private MetroFramework.Controls.MetroTextBox txt_DISCHARGE_TIME;
        private MetroFramework.Controls.MetroTextBox txt_PATIENT_NAME;
        private MetroFramework.Controls.MetroTextBox txt_PATIENT_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_RELATIONSHIP_PATIENT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel p_PRINT_CONTENT;
        private Common.Forms.XPanel xPanel4;
        private MetroFramework.Controls.MetroButton btnSave;
        private Common.Forms.XPanel xPanel5;
        private Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PRINT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PRINT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MONEY;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private MetroFramework.Controls.MetroTextBox txt_PATIENT_IDENTIFICATION;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_REMARKS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_MONEY;
        private MetroFramework.Controls.MetroRadioButton rbtn_INVOICE1;
        private MetroFramework.Controls.MetroRadioButton rbtn_INVOICE2;
        private Common.Forms.XPanel xPanel3;
    }
}