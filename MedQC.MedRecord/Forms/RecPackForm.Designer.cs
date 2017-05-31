namespace Heren.MedQC.MedRecord
{
    partial class RecPackForm
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.lbl_PaperCount = new System.Windows.Forms.Label();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txt_PATIENT_ID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txt_PATIENT_NAME = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txt_DEPT_NAME = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txt_DISCHARGE_TIME = new MetroFramework.Controls.MetroTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.txt_PACK_NO = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.txt_PatientCount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.txt_PaperCount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.btnNewPackNo = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.txt_PACKER = new MetroFramework.Controls.MetroTextBox();
            this.txt_HOSPITAL_DISTRICT = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lbl_PackResult = new System.Windows.Forms.Label();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txt_ChangePackNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.btnModifyCaseNo = new MetroFramework.Controls.MetroButton();
            this.txt_ChangeCaseNo = new MetroFramework.Controls.MetroTextBox();
            this.txtDocID = new System.Windows.Forms.TextBox();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRecordTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IMAGE_FRONTAGE = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_IMAGE_OPPOSITE = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.metroLabel2.Location = new System.Drawing.Point(12, 40);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.StyleManager = null;
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "病历条码号：";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = false;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.CustomForeColor = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(342, 40);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(107, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "（任意扫一张）";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = false;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.CustomBackground = false;
            this.metroLabel6.CustomForeColor = false;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel6.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel6.Location = new System.Drawing.Point(534, 73);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(23, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel6.StyleManager = null;
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "张";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel6.UseStyleColors = false;
            // 
            // lbl_PaperCount
            // 
            this.lbl_PaperCount.AutoSize = true;
            this.lbl_PaperCount.ForeColor = System.Drawing.Color.Red;
            this.lbl_PaperCount.Location = new System.Drawing.Point(518, 77);
            this.lbl_PaperCount.Name = "lbl_PaperCount";
            this.lbl_PaperCount.Size = new System.Drawing.Size(17, 12);
            this.lbl_PaperCount.TabIndex = 2;
            this.lbl_PaperCount.Text = "几";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.CustomBackground = false;
            this.metroLabel7.CustomForeColor = false;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel7.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel7.Location = new System.Drawing.Point(16, 71);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(65, 19);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel7.StyleManager = null;
            this.metroLabel7.TabIndex = 0;
            this.metroLabel7.Text = "病案号：";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel7.UseStyleColors = false;
            // 
            // txt_PATIENT_ID
            // 
            this.txt_PATIENT_ID.CustomBackground = false;
            this.txt_PATIENT_ID.CustomForeColor = false;
            this.txt_PATIENT_ID.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PATIENT_ID.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(83, 69);
            this.txt_PATIENT_ID.Multiline = false;
            this.txt_PATIENT_ID.Name = "txt_PATIENT_ID";
            this.txt_PATIENT_ID.SelectedText = "";
            this.txt_PATIENT_ID.Size = new System.Drawing.Size(105, 23);
            this.txt_PATIENT_ID.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PATIENT_ID.StyleManager = null;
            this.txt_PATIENT_ID.TabIndex = 3;
            this.txt_PATIENT_ID.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PATIENT_ID.UseStyleColors = false;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.CustomBackground = false;
            this.metroLabel8.CustomForeColor = false;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel8.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel8.Location = new System.Drawing.Point(354, 72);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(51, 19);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel8.StyleManager = null;
            this.metroLabel8.TabIndex = 0;
            this.metroLabel8.Text = "患者：";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel8.UseStyleColors = false;
            // 
            // txt_PATIENT_NAME
            // 
            this.txt_PATIENT_NAME.CustomBackground = false;
            this.txt_PATIENT_NAME.CustomForeColor = false;
            this.txt_PATIENT_NAME.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PATIENT_NAME.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PATIENT_NAME.Location = new System.Drawing.Point(407, 71);
            this.txt_PATIENT_NAME.Multiline = false;
            this.txt_PATIENT_NAME.Name = "txt_PATIENT_NAME";
            this.txt_PATIENT_NAME.SelectedText = "";
            this.txt_PATIENT_NAME.Size = new System.Drawing.Size(105, 23);
            this.txt_PATIENT_NAME.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PATIENT_NAME.StyleManager = null;
            this.txt_PATIENT_NAME.TabIndex = 3;
            this.txt_PATIENT_NAME.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PATIENT_NAME.UseStyleColors = false;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.CustomBackground = false;
            this.metroLabel9.CustomForeColor = false;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel9.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel9.Location = new System.Drawing.Point(193, 71);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(51, 19);
            this.metroLabel9.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel9.StyleManager = null;
            this.metroLabel9.TabIndex = 0;
            this.metroLabel9.Text = "科室：";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel9.UseStyleColors = false;
            // 
            // txt_DEPT_NAME
            // 
            this.txt_DEPT_NAME.CustomBackground = false;
            this.txt_DEPT_NAME.CustomForeColor = false;
            this.txt_DEPT_NAME.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_DEPT_NAME.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_DEPT_NAME.Location = new System.Drawing.Point(244, 71);
            this.txt_DEPT_NAME.Multiline = false;
            this.txt_DEPT_NAME.Name = "txt_DEPT_NAME";
            this.txt_DEPT_NAME.SelectedText = "";
            this.txt_DEPT_NAME.Size = new System.Drawing.Size(105, 23);
            this.txt_DEPT_NAME.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_DEPT_NAME.StyleManager = null;
            this.txt_DEPT_NAME.TabIndex = 3;
            this.txt_DEPT_NAME.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_DEPT_NAME.UseStyleColors = false;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.CustomBackground = false;
            this.metroLabel10.CustomForeColor = false;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel10.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel10.Location = new System.Drawing.Point(566, 74);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(79, 19);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel10.StyleManager = null;
            this.metroLabel10.TabIndex = 0;
            this.metroLabel10.Text = "出院时间：";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel10.UseStyleColors = false;
            // 
            // txt_DISCHARGE_TIME
            // 
            this.txt_DISCHARGE_TIME.CustomBackground = false;
            this.txt_DISCHARGE_TIME.CustomForeColor = false;
            this.txt_DISCHARGE_TIME.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_DISCHARGE_TIME.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_DISCHARGE_TIME.Location = new System.Drawing.Point(650, 73);
            this.txt_DISCHARGE_TIME.Multiline = false;
            this.txt_DISCHARGE_TIME.Name = "txt_DISCHARGE_TIME";
            this.txt_DISCHARGE_TIME.SelectedText = "";
            this.txt_DISCHARGE_TIME.Size = new System.Drawing.Size(105, 23);
            this.txt_DISCHARGE_TIME.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_DISCHARGE_TIME.StyleManager = null;
            this.txt_DISCHARGE_TIME.TabIndex = 3;
            this.txt_DISCHARGE_TIME.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_DISCHARGE_TIME.UseStyleColors = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.colRecordTime,
            this.colDocTitle,
            this.col_IMAGE_FRONTAGE,
            this.col_IMAGE_OPPOSITE});
            this.dataGridView1.Location = new System.Drawing.Point(12, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(782, 239);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.CustomBackground = false;
            this.metroLabel11.CustomForeColor = false;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel11.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel11.Location = new System.Drawing.Point(13, 13);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(79, 19);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel11.StyleManager = null;
            this.metroLabel11.TabIndex = 6;
            this.metroLabel11.Text = "当前包号：";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel11.UseStyleColors = false;
            // 
            // txt_PACK_NO
            // 
            this.txt_PACK_NO.CustomBackground = false;
            this.txt_PACK_NO.CustomForeColor = false;
            this.txt_PACK_NO.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PACK_NO.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PACK_NO.Location = new System.Drawing.Point(106, 10);
            this.txt_PACK_NO.Multiline = false;
            this.txt_PACK_NO.Name = "txt_PACK_NO";
            this.txt_PACK_NO.SelectedText = "";
            this.txt_PACK_NO.Size = new System.Drawing.Size(92, 23);
            this.txt_PACK_NO.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PACK_NO.StyleManager = null;
            this.txt_PACK_NO.TabIndex = 1;
            this.txt_PACK_NO.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PACK_NO.UseStyleColors = false;
            this.txt_PACK_NO.TextChanged += new System.EventHandler(this.txt_PACK_NO_TextChanged);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.CustomBackground = false;
            this.metroLabel12.CustomForeColor = false;
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel12.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel12.Location = new System.Drawing.Point(208, 13);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(93, 19);
            this.metroLabel12.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel12.StyleManager = null;
            this.metroLabel12.TabIndex = 6;
            this.metroLabel12.Text = "已包装病历共";
            this.metroLabel12.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel12.UseStyleColors = false;
            // 
            // txt_PatientCount
            // 
            this.txt_PatientCount.CustomBackground = false;
            this.txt_PatientCount.CustomForeColor = false;
            this.txt_PatientCount.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PatientCount.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PatientCount.Location = new System.Drawing.Point(303, 10);
            this.txt_PatientCount.Multiline = false;
            this.txt_PatientCount.Name = "txt_PatientCount";
            this.txt_PatientCount.SelectedText = "";
            this.txt_PatientCount.Size = new System.Drawing.Size(37, 23);
            this.txt_PatientCount.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PatientCount.StyleManager = null;
            this.txt_PatientCount.TabIndex = 1;
            this.txt_PatientCount.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PatientCount.UseStyleColors = false;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.CustomBackground = false;
            this.metroLabel13.CustomForeColor = false;
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel13.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel13.Location = new System.Drawing.Point(342, 14);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(23, 19);
            this.metroLabel13.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel13.StyleManager = null;
            this.metroLabel13.TabIndex = 6;
            this.metroLabel13.Text = "份";
            this.metroLabel13.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel13.UseStyleColors = false;
            // 
            // txt_PaperCount
            // 
            this.txt_PaperCount.CustomBackground = false;
            this.txt_PaperCount.CustomForeColor = false;
            this.txt_PaperCount.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PaperCount.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PaperCount.Location = new System.Drawing.Point(371, 10);
            this.txt_PaperCount.Multiline = false;
            this.txt_PaperCount.Name = "txt_PaperCount";
            this.txt_PaperCount.SelectedText = "";
            this.txt_PaperCount.Size = new System.Drawing.Size(37, 23);
            this.txt_PaperCount.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PaperCount.StyleManager = null;
            this.txt_PaperCount.TabIndex = 1;
            this.txt_PaperCount.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PaperCount.UseStyleColors = false;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.CustomBackground = false;
            this.metroLabel14.CustomForeColor = false;
            this.metroLabel14.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel14.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel14.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel14.Location = new System.Drawing.Point(414, 14);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(37, 19);
            this.metroLabel14.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel14.StyleManager = null;
            this.metroLabel14.TabIndex = 6;
            this.metroLabel14.Text = "张。";
            this.metroLabel14.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel14.UseStyleColors = false;
            // 
            // btnNewPackNo
            // 
            this.btnNewPackNo.Highlight = false;
            this.btnNewPackNo.Location = new System.Drawing.Point(495, 6);
            this.btnNewPackNo.Name = "btnNewPackNo";
            this.btnNewPackNo.Size = new System.Drawing.Size(122, 26);
            this.btnNewPackNo.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnNewPackNo.StyleManager = null;
            this.btnNewPackNo.TabIndex = 5;
            this.btnNewPackNo.Text = "设置新包号";
            this.btnNewPackNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnNewPackNo.Click += new System.EventHandler(this.btnNewPackNo_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Highlight = false;
            this.metroButton2.Location = new System.Drawing.Point(495, 38);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(122, 26);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton2.StyleManager = null;
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "剔除病历";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton2.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.CustomBackground = false;
            this.metroLabel16.CustomForeColor = false;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel16.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel16.Location = new System.Drawing.Point(16, 100);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(65, 19);
            this.metroLabel16.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel16.StyleManager = null;
            this.metroLabel16.TabIndex = 0;
            this.metroLabel16.Text = "打包人：";
            this.metroLabel16.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel16.UseStyleColors = false;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.CustomBackground = false;
            this.metroLabel18.CustomForeColor = false;
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel18.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel18.Location = new System.Drawing.Point(192, 103);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(51, 19);
            this.metroLabel18.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel18.StyleManager = null;
            this.metroLabel18.TabIndex = 0;
            this.metroLabel18.Text = "院区：";
            this.metroLabel18.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel18.UseStyleColors = false;
            // 
            // txt_PACKER
            // 
            this.txt_PACKER.CustomBackground = false;
            this.txt_PACKER.CustomForeColor = false;
            this.txt_PACKER.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PACKER.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PACKER.Location = new System.Drawing.Point(83, 100);
            this.txt_PACKER.Multiline = false;
            this.txt_PACKER.Name = "txt_PACKER";
            this.txt_PACKER.SelectedText = "";
            this.txt_PACKER.Size = new System.Drawing.Size(105, 23);
            this.txt_PACKER.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_PACKER.StyleManager = null;
            this.txt_PACKER.TabIndex = 3;
            this.txt_PACKER.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_PACKER.UseStyleColors = false;
            // 
            // txt_HOSPITAL_DISTRICT
            // 
            this.txt_HOSPITAL_DISTRICT.CustomBackground = false;
            this.txt_HOSPITAL_DISTRICT.CustomForeColor = false;
            this.txt_HOSPITAL_DISTRICT.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_HOSPITAL_DISTRICT.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_HOSPITAL_DISTRICT.Location = new System.Drawing.Point(244, 100);
            this.txt_HOSPITAL_DISTRICT.Multiline = false;
            this.txt_HOSPITAL_DISTRICT.Name = "txt_HOSPITAL_DISTRICT";
            this.txt_HOSPITAL_DISTRICT.SelectedText = "";
            this.txt_HOSPITAL_DISTRICT.Size = new System.Drawing.Size(105, 23);
            this.txt_HOSPITAL_DISTRICT.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_HOSPITAL_DISTRICT.StyleManager = null;
            this.txt_HOSPITAL_DISTRICT.TabIndex = 3;
            this.txt_HOSPITAL_DISTRICT.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_HOSPITAL_DISTRICT.UseStyleColors = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(355, 101);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "结果：";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = false;
            // 
            // lbl_PackResult
            // 
            this.lbl_PackResult.AutoSize = true;
            this.lbl_PackResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PackResult.ForeColor = System.Drawing.Color.Red;
            this.lbl_PackResult.Location = new System.Drawing.Point(406, 105);
            this.lbl_PackResult.Name = "lbl_PackResult";
            this.lbl_PackResult.Size = new System.Drawing.Size(49, 14);
            this.lbl_PackResult.TabIndex = 7;
            this.lbl_PackResult.Text = "待扫描";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.CustomBackground = false;
            this.metroLabel4.CustomForeColor = false;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel4.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel4.Location = new System.Drawing.Point(12, 382);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(401, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.StyleManager = null;
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "更改箱号：将打好包的病历从旧的箱号迁移到新的箱号。包号：";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel4.UseStyleColors = false;
            // 
            // txt_ChangePackNo
            // 
            this.txt_ChangePackNo.CustomBackground = false;
            this.txt_ChangePackNo.CustomForeColor = false;
            this.txt_ChangePackNo.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_ChangePackNo.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_ChangePackNo.Location = new System.Drawing.Point(414, 381);
            this.txt_ChangePackNo.Multiline = false;
            this.txt_ChangePackNo.Name = "txt_ChangePackNo";
            this.txt_ChangePackNo.SelectedText = "";
            this.txt_ChangePackNo.Size = new System.Drawing.Size(105, 23);
            this.txt_ChangePackNo.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_ChangePackNo.StyleManager = null;
            this.txt_ChangePackNo.TabIndex = 3;
            this.txt_ChangePackNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_ChangePackNo.UseStyleColors = false;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.CustomBackground = false;
            this.metroLabel15.CustomForeColor = false;
            this.metroLabel15.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel15.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel15.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel15.Location = new System.Drawing.Point(534, 382);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(79, 19);
            this.metroLabel15.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel15.StyleManager = null;
            this.metroLabel15.TabIndex = 0;
            this.metroLabel15.Text = "新的箱号：";
            this.metroLabel15.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel15.UseStyleColors = false;
            // 
            // btnModifyCaseNo
            // 
            this.btnModifyCaseNo.Highlight = false;
            this.btnModifyCaseNo.Location = new System.Drawing.Point(700, 380);
            this.btnModifyCaseNo.Name = "btnModifyCaseNo";
            this.btnModifyCaseNo.Size = new System.Drawing.Size(103, 26);
            this.btnModifyCaseNo.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnModifyCaseNo.StyleManager = null;
            this.btnModifyCaseNo.TabIndex = 5;
            this.btnModifyCaseNo.Text = "更改";
            this.btnModifyCaseNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnModifyCaseNo.Click += new System.EventHandler(this.btnModifyCaseNo_Click);
            // 
            // txt_ChangeCaseNo
            // 
            this.txt_ChangeCaseNo.CustomBackground = false;
            this.txt_ChangeCaseNo.CustomForeColor = false;
            this.txt_ChangeCaseNo.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_ChangeCaseNo.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_ChangeCaseNo.Location = new System.Drawing.Point(613, 382);
            this.txt_ChangeCaseNo.Multiline = false;
            this.txt_ChangeCaseNo.Name = "txt_ChangeCaseNo";
            this.txt_ChangeCaseNo.SelectedText = "";
            this.txt_ChangeCaseNo.Size = new System.Drawing.Size(79, 23);
            this.txt_ChangeCaseNo.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_ChangeCaseNo.StyleManager = null;
            this.txt_ChangeCaseNo.TabIndex = 3;
            this.txt_ChangeCaseNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_ChangeCaseNo.UseStyleColors = false;
            // 
            // txtDocID
            // 
            this.txtDocID.Location = new System.Drawing.Point(106, 40);
            this.txtDocID.Name = "txtDocID";
            this.txtDocID.Size = new System.Drawing.Size(234, 21);
            this.txtDocID.TabIndex = 8;
            this.txtDocID.TextChanged += new System.EventHandler(this.txtDocID_TextChanged);
            // 
            // colCheckBox
            // 
            this.colCheckBox.HeaderText = "";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.ReadOnly = true;
            this.colCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheckBox.Width = 30;
            // 
            // colRecordTime
            // 
            this.colRecordTime.HeaderText = "记录时间";
            this.colRecordTime.Name = "colRecordTime";
            this.colRecordTime.ReadOnly = true;
            this.colRecordTime.Width = 150;
            // 
            // colDocTitle
            // 
            this.colDocTitle.HeaderText = "文档标题";
            this.colDocTitle.Name = "colDocTitle";
            this.colDocTitle.ReadOnly = true;
            this.colDocTitle.Width = 250;
            // 
            // col_IMAGE_FRONTAGE
            // 
            this.col_IMAGE_FRONTAGE.HeaderText = "正面";
            this.col_IMAGE_FRONTAGE.Image = global::Heren.MedQC.MedRecord.Properties.Resources.transparent;
            this.col_IMAGE_FRONTAGE.Name = "col_IMAGE_FRONTAGE";
            this.col_IMAGE_FRONTAGE.ReadOnly = true;
            this.col_IMAGE_FRONTAGE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_IMAGE_FRONTAGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_IMAGE_OPPOSITE
            // 
            this.col_IMAGE_OPPOSITE.HeaderText = "反面";
            this.col_IMAGE_OPPOSITE.Image = global::Heren.MedQC.MedRecord.Properties.Resources.transparent;
            this.col_IMAGE_OPPOSITE.Name = "col_IMAGE_OPPOSITE";
            this.col_IMAGE_OPPOSITE.ReadOnly = true;
            this.col_IMAGE_OPPOSITE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_IMAGE_OPPOSITE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RecPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(829, 513);
            this.Controls.Add(this.txtDocID);
            this.Controls.Add(this.lbl_PackResult);
            this.Controls.Add(this.metroLabel14);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.btnModifyCaseNo);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnNewPackNo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_DEPT_NAME);
            this.Controls.Add(this.txt_HOSPITAL_DISTRICT);
            this.Controls.Add(this.txt_DISCHARGE_TIME);
            this.Controls.Add(this.txt_ChangeCaseNo);
            this.Controls.Add(this.txt_ChangePackNo);
            this.Controls.Add(this.txt_PACKER);
            this.Controls.Add(this.txt_PATIENT_NAME);
            this.Controls.Add(this.txt_PATIENT_ID);
            this.Controls.Add(this.lbl_PaperCount);
            this.Controls.Add(this.txt_PaperCount);
            this.Controls.Add(this.txt_PatientCount);
            this.Controls.Add(this.txt_PACK_NO);
            this.Controls.Add(this.metroLabel18);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel15);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel16);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecPackForm";
            this.Text = "病历打包";
            this.Activated += new System.EventHandler(this.RecPackForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.Label lbl_PaperCount;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txt_PATIENT_ID;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txt_PATIENT_NAME;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txt_DEPT_NAME;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txt_DISCHARGE_TIME;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox txt_PACK_NO;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txt_PatientCount;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox txt_PaperCount;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroButton btnNewPackNo;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroTextBox txt_PACKER;
        private MetroFramework.Controls.MetroTextBox txt_HOSPITAL_DISTRICT;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Label lbl_PackResult;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txt_ChangePackNo;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroButton btnModifyCaseNo;
        private MetroFramework.Controls.MetroTextBox txt_ChangeCaseNo;
        private System.Windows.Forms.TextBox txtDocID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTitle;
        private System.Windows.Forms.DataGridViewImageColumn col_IMAGE_FRONTAGE;
        private System.Windows.Forms.DataGridViewImageColumn col_IMAGE_OPPOSITE;
    }
}