namespace Heren.MedQC.MedRecord
{
    partial class InPatientStatisticForm
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
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new Heren.Common.Forms.XButton();
            this.txtName = new Heren.Common.Forms.XTextBox();
            this.xLabel4 = new Heren.Common.Forms.XLabel();
            this.txtPatientID = new Heren.Common.Forms.XTextBox();
            this.xLabel3 = new Heren.Common.Forms.XLabel();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.xLabel1 = new Heren.Common.Forms.XLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTransferCount = new System.Windows.Forms.Label();
            this.lblInPatientCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.col_ORDER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_BED_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CHARGE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_VISIT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TRANSFER_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_MEDICAL_GROUP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_1_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.col_ORDER_NO,
            this.col_1_BED_NO,
            this.col_1_PATIENT_NAME,
            this.col_PATIENT_ID,
            this.col_PATIENT_SEX,
            this.col_AGE,
            this.col_CHARGE_TYPE,
            this.col_VISIT_TIME,
            this.col_TRANSFER_TIME,
            this.col_1_MEDICAL_GROUP,
            this.col_1_DEPT_NAME});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTableView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 57);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(1020, 452);
            this.dataTableView1.TabIndex = 1;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            this.dataTableView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataTableView1_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.xLabel4);
            this.panel1.Controls.Add(this.txtPatientID);
            this.panel1.Controls.Add(this.xLabel3);
            this.panel1.Controls.Add(this.cboDeptName);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(589, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 24);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(480, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(90, 23);
            this.txtName.TabIndex = 5;
            // 
            // xLabel4
            // 
            this.xLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel4.Location = new System.Drawing.Point(433, 8);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(49, 14);
            this.xLabel4.TabIndex = 4;
            this.xLabel4.Text = "姓名：";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPatientID.Location = new System.Drawing.Point(321, 3);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(94, 23);
            this.txtPatientID.TabIndex = 5;
            // 
            // xLabel3
            // 
            this.xLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel3.Location = new System.Drawing.Point(252, 9);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(77, 14);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "患者ID号：";
            // 
            // cboDeptName
            // 
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDeptName.Location = new System.Drawing.Point(86, 5);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(150, 21);
            this.cboDeptName.TabIndex = 3;
            // 
            // xLabel1
            // 
            this.xLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xLabel1.Location = new System.Drawing.Point(14, 9);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(77, 14);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "所在科室：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTransferCount);
            this.panel2.Controls.Add(this.lblInPatientCount);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 25);
            this.panel2.TabIndex = 12;
            // 
            // lblTransferCount
            // 
            this.lblTransferCount.AutoSize = true;
            this.lblTransferCount.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblTransferCount.Location = new System.Drawing.Point(231, 6);
            this.lblTransferCount.Name = "lblTransferCount";
            this.lblTransferCount.Size = new System.Drawing.Size(14, 14);
            this.lblTransferCount.TabIndex = 3;
            this.lblTransferCount.Text = "0";
            // 
            // lblInPatientCount
            // 
            this.lblInPatientCount.AutoSize = true;
            this.lblInPatientCount.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblInPatientCount.Location = new System.Drawing.Point(95, 6);
            this.lblInPatientCount.Name = "lblInPatientCount";
            this.lblInPatientCount.Size = new System.Drawing.Size(14, 14);
            this.lblInPatientCount.TabIndex = 3;
            this.lblInPatientCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(148, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "转科人次：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "留院人次：";
            // 
            // col_ORDER_NO
            // 
            this.col_ORDER_NO.HeaderText = "序";
            this.col_ORDER_NO.Name = "col_ORDER_NO";
            this.col_ORDER_NO.ReadOnly = true;
            this.col_ORDER_NO.Width = 30;
            // 
            // col_1_BED_NO
            // 
            this.col_1_BED_NO.FillWeight = 85.46564F;
            this.col_1_BED_NO.HeaderText = "床号";
            this.col_1_BED_NO.Name = "col_1_BED_NO";
            this.col_1_BED_NO.ReadOnly = true;
            this.col_1_BED_NO.Width = 40;
            // 
            // col_1_PATIENT_NAME
            // 
            this.col_1_PATIENT_NAME.HeaderText = "姓名";
            this.col_1_PATIENT_NAME.Name = "col_1_PATIENT_NAME";
            this.col_1_PATIENT_NAME.ReadOnly = true;
            // 
            // col_PATIENT_ID
            // 
            this.col_PATIENT_ID.FillWeight = 102.1956F;
            this.col_PATIENT_ID.HeaderText = "患者ID";
            this.col_PATIENT_ID.Name = "col_PATIENT_ID";
            this.col_PATIENT_ID.ReadOnly = true;
            // 
            // col_PATIENT_SEX
            // 
            this.col_PATIENT_SEX.FillWeight = 93.80241F;
            this.col_PATIENT_SEX.HeaderText = "性别";
            this.col_PATIENT_SEX.Name = "col_PATIENT_SEX";
            this.col_PATIENT_SEX.ReadOnly = true;
            this.col_PATIENT_SEX.Width = 60;
            // 
            // col_AGE
            // 
            this.col_AGE.HeaderText = "年龄";
            this.col_AGE.Name = "col_AGE";
            this.col_AGE.ReadOnly = true;
            this.col_AGE.Width = 60;
            // 
            // col_CHARGE_TYPE
            // 
            this.col_CHARGE_TYPE.HeaderText = "费用类别";
            this.col_CHARGE_TYPE.Name = "col_CHARGE_TYPE";
            this.col_CHARGE_TYPE.ReadOnly = true;
            // 
            // col_VISIT_TIME
            // 
            this.col_VISIT_TIME.FillWeight = 117.631F;
            this.col_VISIT_TIME.HeaderText = "入院时间";
            this.col_VISIT_TIME.Name = "col_VISIT_TIME";
            this.col_VISIT_TIME.ReadOnly = true;
            this.col_VISIT_TIME.Width = 120;
            // 
            // col_TRANSFER_TIME
            // 
            this.col_TRANSFER_TIME.HeaderText = "转科时间";
            this.col_TRANSFER_TIME.Name = "col_TRANSFER_TIME";
            this.col_TRANSFER_TIME.ReadOnly = true;
            this.col_TRANSFER_TIME.Width = 120;
            // 
            // col_1_MEDICAL_GROUP
            // 
            this.col_1_MEDICAL_GROUP.FillWeight = 144.596F;
            this.col_1_MEDICAL_GROUP.HeaderText = "所属医疗组";
            this.col_1_MEDICAL_GROUP.Name = "col_1_MEDICAL_GROUP";
            this.col_1_MEDICAL_GROUP.ReadOnly = true;
            // 
            // col_1_DEPT_NAME
            // 
            this.col_1_DEPT_NAME.HeaderText = "所属专科";
            this.col_1_DEPT_NAME.Name = "col_1_DEPT_NAME";
            this.col_1_DEPT_NAME.ReadOnly = true;
            this.col_1_DEPT_NAME.Width = 150;
            // 
            // InPatientStatisticForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 509);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "InPatientStatisticForm";
            this.Text = "留院人数统计";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private Heren.Common.Forms.XLabel xLabel1;
        private Heren.Common.Forms.XLabel xLabel3;
        private Heren.Common.Forms.XTextBox txtPatientID;
        private Heren.Common.Forms.XTextBox txtName;
        private Heren.Common.Forms.XLabel xLabel4;
        private Heren.Common.Forms.XButton btnSearch;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInPatientCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTransferCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ORDER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_BED_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_AGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CHARGE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_VISIT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TRANSFER_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_MEDICAL_GROUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1_DEPT_NAME;
    }
}