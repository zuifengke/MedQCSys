namespace Heren.MedQC.MedRecord
{
    partial class ReceiveInOrderForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
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
            this.btnReceive = new MetroFramework.Controls.MetroButton();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.txtDocID = new System.Windows.Forms.TextBox();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRecordTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IMAGE_FRONTAGE = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_IMAGE_OPPOSITE = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(12, 43);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(499, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "功能说明：可重复接收，扫描其中一份的病历条码，核对每一页内容是否齐全。";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.CustomBackground = false;
            this.metroLabel2.CustomForeColor = false;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel2.Location = new System.Drawing.Point(12, 77);
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
            this.metroLabel3.Location = new System.Drawing.Point(295, 77);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(107, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "（任意扫一张）";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.CustomBackground = false;
            this.metroLabel4.CustomForeColor = false;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel4.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel4.Location = new System.Drawing.Point(33, 113);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(121, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.StyleManager = null;
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "条码相关病历信息";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel4.UseStyleColors = false;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.CustomBackground = false;
            this.metroLabel5.CustomForeColor = false;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel5.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel5.Location = new System.Drawing.Point(33, 142);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(23, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.StyleManager = null;
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "应";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel5.UseStyleColors = false;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.CustomBackground = false;
            this.metroLabel6.CustomForeColor = false;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel6.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel6.Location = new System.Drawing.Point(73, 142);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(37, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel6.StyleManager = null;
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "张：";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel6.UseStyleColors = false;
            // 
            // lbl_PaperCount
            // 
            this.lbl_PaperCount.AutoSize = true;
            this.lbl_PaperCount.ForeColor = System.Drawing.Color.Red;
            this.lbl_PaperCount.Location = new System.Drawing.Point(57, 146);
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
            this.metroLabel7.Location = new System.Drawing.Point(116, 142);
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
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(182, 141);
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
            this.metroLabel8.Location = new System.Drawing.Point(447, 143);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(51, 19);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel8.StyleManager = null;
            this.metroLabel8.TabIndex = 0;
            this.metroLabel8.Text = "姓名：";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel8.UseStyleColors = false;
            // 
            // txt_PATIENT_NAME
            // 
            this.txt_PATIENT_NAME.CustomBackground = false;
            this.txt_PATIENT_NAME.CustomForeColor = false;
            this.txt_PATIENT_NAME.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txt_PATIENT_NAME.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txt_PATIENT_NAME.Location = new System.Drawing.Point(495, 142);
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
            this.metroLabel9.Location = new System.Drawing.Point(293, 142);
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
            this.txt_DEPT_NAME.Location = new System.Drawing.Point(341, 141);
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
            this.metroLabel10.Location = new System.Drawing.Point(614, 144);
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
            this.txt_DISCHARGE_TIME.Location = new System.Drawing.Point(689, 136);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(782, 205);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // btnReceive
            // 
            this.btnReceive.Highlight = false;
            this.btnReceive.Location = new System.Drawing.Point(12, 381);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(122, 26);
            this.btnReceive.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnReceive.StyleManager = null;
            this.btnReceive.TabIndex = 5;
            this.btnReceive.Text = "确认接收";
            this.btnReceive.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.CustomBackground = false;
            this.metroLabel11.CustomForeColor = false;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel11.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel11.Location = new System.Drawing.Point(339, 6);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(172, 25);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel11.StyleManager = null;
            this.metroLabel11.TabIndex = 6;
            this.metroLabel11.Text = "纸质病历逐份接收";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel11.UseStyleColors = false;
            // 
            // txtDocID
            // 
            this.txtDocID.Location = new System.Drawing.Point(105, 76);
            this.txtDocID.Name = "txtDocID";
            this.txtDocID.Size = new System.Drawing.Size(191, 21);
            this.txtDocID.TabIndex = 7;
            this.txtDocID.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
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
            this.col_IMAGE_FRONTAGE.Width = 60;
            // 
            // col_IMAGE_OPPOSITE
            // 
            this.col_IMAGE_OPPOSITE.HeaderText = "反面";
            this.col_IMAGE_OPPOSITE.Image = global::Heren.MedQC.MedRecord.Properties.Resources.transparent;
            this.col_IMAGE_OPPOSITE.Name = "col_IMAGE_OPPOSITE";
            this.col_IMAGE_OPPOSITE.ReadOnly = true;
            this.col_IMAGE_OPPOSITE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_IMAGE_OPPOSITE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_IMAGE_OPPOSITE.Width = 60;
            // 
            // ReceiveInOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(829, 513);
            this.Controls.Add(this.txtDocID);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_DEPT_NAME);
            this.Controls.Add(this.txt_DISCHARGE_TIME);
            this.Controls.Add(this.txt_PATIENT_NAME);
            this.Controls.Add(this.txt_PATIENT_ID);
            this.Controls.Add(this.lbl_PaperCount);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ReceiveInOrderForm";
            this.Text = "纸质病历逐份接收";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
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
        private MetroFramework.Controls.MetroButton btnReceive;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private System.Windows.Forms.TextBox txtDocID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecordTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocTitle;
        private System.Windows.Forms.DataGridViewImageColumn col_IMAGE_FRONTAGE;
        private System.Windows.Forms.DataGridViewImageColumn col_IMAGE_OPPOSITE;
    }
}