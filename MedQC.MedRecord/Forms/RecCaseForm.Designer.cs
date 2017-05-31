namespace Heren.MedQC.MedRecord
{
    partial class RecCaseForm
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
            this.txtCaseNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPringCaseNo = new MetroFramework.Controls.MetroButton();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.txtPackCount = new MetroFramework.Controls.MetroTextBox();
            this.btnPrintNewCaseNo = new MetroFramework.Controls.MetroButton();
            this.txt_PACK_NO = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnRemovePack = new MetroFramework.Controls.MetroButton();
            this.lbl_CaseResult = new System.Windows.Forms.Label();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_CASE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PACK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PACKER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PACK_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaperCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.metroLabel1.Location = new System.Drawing.Point(12, 36);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(401, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "功能说明：病历打包的同时可记录装箱信息，打印包装条形码。";
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
            this.metroLabel2.Location = new System.Drawing.Point(12, 70);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.StyleManager = null;
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "当前箱号：";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = false;
            // 
            // txtCaseNo
            // 
            this.txtCaseNo.CustomBackground = false;
            this.txtCaseNo.CustomForeColor = false;
            this.txtCaseNo.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txtCaseNo.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txtCaseNo.Location = new System.Drawing.Point(97, 70);
            this.txtCaseNo.Multiline = false;
            this.txtCaseNo.Name = "txtCaseNo";
            this.txtCaseNo.SelectedText = "";
            this.txtCaseNo.Size = new System.Drawing.Size(110, 23);
            this.txtCaseNo.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCaseNo.StyleManager = null;
            this.txtCaseNo.TabIndex = 1;
            this.txtCaseNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCaseNo.UseStyleColors = false;
            this.txtCaseNo.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.CustomForeColor = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(229, 70);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(93, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "已装箱病历共";
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
            this.metroLabel4.Location = new System.Drawing.Point(13, 106);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(79, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.StyleManager = null;
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "包条码号：";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel4.UseStyleColors = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.col_CASE_NO,
            this.col_PACK_NO,
            this.col_PACKER,
            this.col_PACK_TIME,
            this.colPatientCount,
            this.colPaperCount});
            this.dataGridView1.Location = new System.Drawing.Point(12, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(782, 352);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // btnPringCaseNo
            // 
            this.btnPringCaseNo.Highlight = false;
            this.btnPringCaseNo.Location = new System.Drawing.Point(394, 70);
            this.btnPringCaseNo.Name = "btnPringCaseNo";
            this.btnPringCaseNo.Size = new System.Drawing.Size(96, 26);
            this.btnPringCaseNo.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnPringCaseNo.StyleManager = null;
            this.btnPringCaseNo.TabIndex = 5;
            this.btnPringCaseNo.Text = "重打标签";
            this.btnPringCaseNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPringCaseNo.Click += new System.EventHandler(this.btnPringCaseNo_Click);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.CustomBackground = false;
            this.metroLabel11.CustomForeColor = false;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel11.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel11.Location = new System.Drawing.Point(365, 72);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(23, 19);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel11.StyleManager = null;
            this.metroLabel11.TabIndex = 0;
            this.metroLabel11.Text = "包";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel11.UseStyleColors = false;
            // 
            // txtPackCount
            // 
            this.txtPackCount.CustomBackground = false;
            this.txtPackCount.CustomForeColor = false;
            this.txtPackCount.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txtPackCount.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txtPackCount.Location = new System.Drawing.Point(326, 70);
            this.txtPackCount.Multiline = false;
            this.txtPackCount.Name = "txtPackCount";
            this.txtPackCount.SelectedText = "";
            this.txtPackCount.Size = new System.Drawing.Size(37, 23);
            this.txtPackCount.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPackCount.StyleManager = null;
            this.txtPackCount.TabIndex = 1;
            this.txtPackCount.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPackCount.UseStyleColors = false;
            this.txtPackCount.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
            // 
            // btnPrintNewCaseNo
            // 
            this.btnPrintNewCaseNo.Highlight = false;
            this.btnPrintNewCaseNo.Location = new System.Drawing.Point(505, 70);
            this.btnPrintNewCaseNo.Name = "btnPrintNewCaseNo";
            this.btnPrintNewCaseNo.Size = new System.Drawing.Size(118, 26);
            this.btnPrintNewCaseNo.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnPrintNewCaseNo.StyleManager = null;
            this.btnPrintNewCaseNo.TabIndex = 5;
            this.btnPrintNewCaseNo.Text = "打印新箱号标签";
            this.btnPrintNewCaseNo.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPrintNewCaseNo.Click += new System.EventHandler(this.btnPrintNewCaseNo_Click);
            // 
            // txt_PACK_NO
            // 
            this.txt_PACK_NO.Location = new System.Drawing.Point(97, 103);
            this.txt_PACK_NO.Name = "txt_PACK_NO";
            this.txt_PACK_NO.Size = new System.Drawing.Size(186, 21);
            this.txt_PACK_NO.TabIndex = 6;
            this.txt_PACK_NO.TextChanged += new System.EventHandler(this.txt_PACK_NO_TextChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.CustomBackground = false;
            this.metroLabel5.CustomForeColor = false;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel5.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel5.Location = new System.Drawing.Point(295, 106);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(93, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.StyleManager = null;
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "（任扫一包）";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel5.UseStyleColors = false;
            // 
            // btnRemovePack
            // 
            this.btnRemovePack.Highlight = false;
            this.btnRemovePack.Location = new System.Drawing.Point(394, 100);
            this.btnRemovePack.Name = "btnRemovePack";
            this.btnRemovePack.Size = new System.Drawing.Size(96, 26);
            this.btnRemovePack.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnRemovePack.StyleManager = null;
            this.btnRemovePack.TabIndex = 5;
            this.btnRemovePack.Text = "剔除包";
            this.btnRemovePack.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnRemovePack.Click += new System.EventHandler(this.btnRemovePack_Click);
            // 
            // lbl_CaseResult
            // 
            this.lbl_CaseResult.AutoSize = true;
            this.lbl_CaseResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CaseResult.ForeColor = System.Drawing.Color.Red;
            this.lbl_CaseResult.Location = new System.Drawing.Point(506, 110);
            this.lbl_CaseResult.Name = "lbl_CaseResult";
            this.lbl_CaseResult.Size = new System.Drawing.Size(49, 14);
            this.lbl_CaseResult.TabIndex = 8;
            this.lbl_CaseResult.Text = "待扫描";
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
            // col_CASE_NO
            // 
            this.col_CASE_NO.HeaderText = "箱号";
            this.col_CASE_NO.Name = "col_CASE_NO";
            this.col_CASE_NO.ReadOnly = true;
            this.col_CASE_NO.Width = 80;
            // 
            // col_PACK_NO
            // 
            this.col_PACK_NO.HeaderText = "包号";
            this.col_PACK_NO.Name = "col_PACK_NO";
            this.col_PACK_NO.ReadOnly = true;
            // 
            // col_PACKER
            // 
            this.col_PACKER.HeaderText = "打包人";
            this.col_PACKER.Name = "col_PACKER";
            this.col_PACKER.ReadOnly = true;
            // 
            // col_PACK_TIME
            // 
            this.col_PACK_TIME.HeaderText = "打包时间";
            this.col_PACK_TIME.Name = "col_PACK_TIME";
            this.col_PACK_TIME.ReadOnly = true;
            this.col_PACK_TIME.Width = 120;
            // 
            // colPatientCount
            // 
            this.colPatientCount.HeaderText = "份数";
            this.colPatientCount.Name = "colPatientCount";
            this.colPatientCount.ReadOnly = true;
            // 
            // colPaperCount
            // 
            this.colPaperCount.HeaderText = "张数";
            this.colPaperCount.Name = "colPaperCount";
            this.colPaperCount.ReadOnly = true;
            // 
            // RecCaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(829, 513);
            this.Controls.Add(this.lbl_CaseResult);
            this.Controls.Add(this.txt_PACK_NO);
            this.Controls.Add(this.btnPrintNewCaseNo);
            this.Controls.Add(this.btnRemovePack);
            this.Controls.Add(this.btnPringCaseNo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtPackCount);
            this.Controls.Add(this.txtCaseNo);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RecCaseForm";
            this.Text = "病历装箱";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCaseNo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton btnPringCaseNo;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox txtPackCount;
        private MetroFramework.Controls.MetroButton btnPrintNewCaseNo;
        private System.Windows.Forms.TextBox txt_PACK_NO;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btnRemovePack;
        private System.Windows.Forms.Label lbl_CaseResult;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CASE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PACK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PACKER;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PACK_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaperCount;
    }
}