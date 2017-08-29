namespace Heren.MedQC.MedRecord
{
    partial class RecPackSearchForm
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.txtDocID = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txt_PATIENT_ID = new System.Windows.Forms.TextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txt_CASE_NO = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txt_PACK_NO = new System.Windows.Forms.TextBox();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CASE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PACK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DISCHARGE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PAPER_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PACK_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PACKER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HOSPITAL_DISTRICT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.CustomBackground = false;
            this.metroLabel2.CustomForeColor = false;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel2.Location = new System.Drawing.Point(289, 14);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.StyleManager = null;
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "病历条码号：";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.HighlightText;
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
            this.colOrderNo,
            this.col_CASE_NO,
            this.col_PACK_NO,
            this.col_PATIENT_ID,
            this.col_PATIENT_NAME,
            this.col_DISCHARGE_TIME,
            this.col_PAPER_NUMBER,
            this.col_PACK_TIME,
            this.col_PACKER,
            this.col_HOSPITAL_DISTRICT});
            this.dataGridView1.Location = new System.Drawing.Point(6, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(952, 426);
            this.dataGridView1.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Highlight = false;
            this.btnSearch.Location = new System.Drawing.Point(741, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 26);
            this.btnSearch.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnSearch.StyleManager = null;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDocID
            // 
            this.txtDocID.Location = new System.Drawing.Point(383, 14);
            this.txtDocID.Name = "txtDocID";
            this.txtDocID.Size = new System.Drawing.Size(129, 21);
            this.txtDocID.TabIndex = 8;
            this.txtDocID.TextChanged += new System.EventHandler(this.txtDocID_TextChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.CustomForeColor = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(524, 15);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(77, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "患者ID号：";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = false;
            // 
            // txt_PATIENT_ID
            // 
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(612, 14);
            this.txt_PATIENT_ID.Name = "txt_PATIENT_ID";
            this.txt_PATIENT_ID.Size = new System.Drawing.Size(110, 21);
            this.txt_PATIENT_ID.TabIndex = 8;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.CustomBackground = false;
            this.metroLabel4.CustomForeColor = false;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel4.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel4.Location = new System.Drawing.Point(20, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(51, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.StyleManager = null;
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "箱号：";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel4.UseStyleColors = false;
            // 
            // txt_CASE_NO
            // 
            this.txt_CASE_NO.Location = new System.Drawing.Point(77, 13);
            this.txt_CASE_NO.Name = "txt_CASE_NO";
            this.txt_CASE_NO.Size = new System.Drawing.Size(71, 21);
            this.txt_CASE_NO.TabIndex = 8;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.CustomBackground = false;
            this.metroLabel5.CustomForeColor = false;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel5.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel5.Location = new System.Drawing.Point(155, 14);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(51, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.StyleManager = null;
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "包号：";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel5.UseStyleColors = false;
            // 
            // txt_PACK_NO
            // 
            this.txt_PACK_NO.Location = new System.Drawing.Point(212, 14);
            this.txt_PACK_NO.Name = "txt_PACK_NO";
            this.txt_PACK_NO.Size = new System.Drawing.Size(71, 21);
            this.txt_PACK_NO.TabIndex = 8;
            // 
            // lbl_Result
            // 
            this.lbl_Result.AutoSize = true;
            this.lbl_Result.Location = new System.Drawing.Point(20, 50);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(0, 12);
            this.lbl_Result.TabIndex = 9;
            // 
            // colOrderNo
            // 
            this.colOrderNo.HeaderText = "序号";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            this.colOrderNo.Width = 60;
            // 
            // col_CASE_NO
            // 
            this.col_CASE_NO.HeaderText = "箱号";
            this.col_CASE_NO.Name = "col_CASE_NO";
            this.col_CASE_NO.ReadOnly = true;
            // 
            // col_PACK_NO
            // 
            this.col_PACK_NO.HeaderText = "包号";
            this.col_PACK_NO.Name = "col_PACK_NO";
            this.col_PACK_NO.ReadOnly = true;
            // 
            // col_PATIENT_ID
            // 
            this.col_PATIENT_ID.HeaderText = "患者ID号";
            this.col_PATIENT_ID.Name = "col_PATIENT_ID";
            this.col_PATIENT_ID.ReadOnly = true;
            // 
            // col_PATIENT_NAME
            // 
            this.col_PATIENT_NAME.HeaderText = "患者姓名";
            this.col_PATIENT_NAME.Name = "col_PATIENT_NAME";
            this.col_PATIENT_NAME.ReadOnly = true;
            // 
            // col_DISCHARGE_TIME
            // 
            this.col_DISCHARGE_TIME.HeaderText = "出院时间";
            this.col_DISCHARGE_TIME.Name = "col_DISCHARGE_TIME";
            this.col_DISCHARGE_TIME.ReadOnly = true;
            this.col_DISCHARGE_TIME.Width = 120;
            // 
            // col_PAPER_NUMBER
            // 
            this.col_PAPER_NUMBER.HeaderText = "张数";
            this.col_PAPER_NUMBER.Name = "col_PAPER_NUMBER";
            this.col_PAPER_NUMBER.ReadOnly = true;
            // 
            // col_PACK_TIME
            // 
            this.col_PACK_TIME.HeaderText = "打包时间";
            this.col_PACK_TIME.Name = "col_PACK_TIME";
            this.col_PACK_TIME.ReadOnly = true;
            this.col_PACK_TIME.Width = 120;
            // 
            // col_PACKER
            // 
            this.col_PACKER.HeaderText = "打包人";
            this.col_PACKER.Name = "col_PACKER";
            this.col_PACKER.ReadOnly = true;
            // 
            // col_HOSPITAL_DISTRICT
            // 
            this.col_HOSPITAL_DISTRICT.HeaderText = "院区";
            this.col_HOSPITAL_DISTRICT.Name = "col_HOSPITAL_DISTRICT";
            this.col_HOSPITAL_DISTRICT.ReadOnly = true;
            // 
            // RecPackSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(961, 513);
            this.Controls.Add(this.lbl_Result);
            this.Controls.Add(this.txt_PATIENT_ID);
            this.Controls.Add(this.txt_PACK_NO);
            this.Controls.Add(this.txt_CASE_NO);
            this.Controls.Add(this.txtDocID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecPackSearchForm";
            this.Text = "病历打包查询";
            this.Activated += new System.EventHandler(this.RecPackForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton btnSearch;
        private System.Windows.Forms.TextBox txtDocID;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox txt_PATIENT_ID;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.TextBox txt_CASE_NO;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.TextBox txt_PACK_NO;
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CASE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PACK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DISCHARGE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PAPER_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PACK_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PACKER;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HOSPITAL_DISTRICT;
    }
}