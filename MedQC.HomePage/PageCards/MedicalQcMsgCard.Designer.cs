namespace Heren.MedQC.HomePage.PageCards
{
    partial class MedicalQcMsgCard
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chkUnModified = new MetroFramework.Controls.MetroCheckBox();
            this.chkModified = new MetroFramework.Controls.MetroCheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_ISSUED_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MESSAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DOCTOR_COMMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkUnModified
            // 
            this.chkUnModified.AutoSize = true;
            this.chkUnModified.CustomBackground = false;
            this.chkUnModified.CustomForeColor = false;
            this.chkUnModified.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkUnModified.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkUnModified.Location = new System.Drawing.Point(80, 30);
            this.chkUnModified.Name = "chkUnModified";
            this.chkUnModified.Size = new System.Drawing.Size(62, 15);
            this.chkUnModified.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkUnModified.StyleManager = null;
            this.chkUnModified.TabIndex = 5;
            this.chkUnModified.Text = "未修改";
            this.chkUnModified.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkUnModified.UseStyleColors = false;
            this.chkUnModified.UseVisualStyleBackColor = true;
            this.chkUnModified.CheckedChanged += new System.EventHandler(this.chkUnModified_CheckedChanged);
            // 
            // chkModified
            // 
            this.chkModified.AutoSize = true;
            this.chkModified.Checked = true;
            this.chkModified.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModified.CustomBackground = false;
            this.chkModified.CustomForeColor = false;
            this.chkModified.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkModified.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkModified.Location = new System.Drawing.Point(12, 30);
            this.chkModified.Name = "chkModified";
            this.chkModified.Size = new System.Drawing.Size(62, 15);
            this.chkModified.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkModified.StyleManager = null;
            this.chkModified.TabIndex = 6;
            this.chkModified.Text = "已修改";
            this.chkModified.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkModified.UseStyleColors = false;
            this.chkModified.UseVisualStyleBackColor = true;
            this.chkModified.CheckedChanged += new System.EventHandler(this.chkModified_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ISSUED_DATE_TIME,
            this.col_PATIENT_NAME,
            this.col_MESSAGE,
            this.col_DOCTOR_COMMENT});
            this.dataGridView1.Location = new System.Drawing.Point(3, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(644, 236);
            this.dataGridView1.TabIndex = 4;
            // 
            // col_ISSUED_DATE_TIME
            // 
            this.col_ISSUED_DATE_TIME.HeaderText = "提交时间";
            this.col_ISSUED_DATE_TIME.Name = "col_ISSUED_DATE_TIME";
            // 
            // col_PATIENT_NAME
            // 
            this.col_PATIENT_NAME.HeaderText = "患者";
            this.col_PATIENT_NAME.Name = "col_PATIENT_NAME";
            this.col_PATIENT_NAME.Width = 60;
            // 
            // col_MESSAGE
            // 
            this.col_MESSAGE.HeaderText = "质检问题";
            this.col_MESSAGE.Name = "col_MESSAGE";
            this.col_MESSAGE.Width = 250;
            // 
            // col_DOCTOR_COMMENT
            // 
            this.col_DOCTOR_COMMENT.HeaderText = "医生反馈";
            this.col_DOCTOR_COMMENT.Name = "col_DOCTOR_COMMENT";
            this.col_DOCTOR_COMMENT.Width = 200;
            // 
            // MedicalQcMsgCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkUnModified);
            this.Controls.Add(this.chkModified);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MedicalQcMsgCard";
            this.Size = new System.Drawing.Size(650, 290);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.chkModified, 0);
            this.Controls.SetChildIndex(this.chkUnModified, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox chkUnModified;
        private MetroFramework.Controls.MetroCheckBox chkModified;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ISSUED_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MESSAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DOCTOR_COMMENT;
    }
}
