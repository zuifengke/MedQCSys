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
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.CustomBackground = false;
            this.metroCheckBox2.CustomForeColor = false;
            this.metroCheckBox2.FontSize = MetroFramework.MetroLinkSize.Small;
            this.metroCheckBox2.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.metroCheckBox2.Location = new System.Drawing.Point(80, 30);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(62, 15);
            this.metroCheckBox2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroCheckBox2.StyleManager = null;
            this.metroCheckBox2.TabIndex = 5;
            this.metroCheckBox2.Text = "未修改";
            this.metroCheckBox2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroCheckBox2.UseStyleColors = false;
            this.metroCheckBox2.UseVisualStyleBackColor = true;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Checked = true;
            this.metroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox1.CustomBackground = false;
            this.metroCheckBox1.CustomForeColor = false;
            this.metroCheckBox1.FontSize = MetroFramework.MetroLinkSize.Small;
            this.metroCheckBox1.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.metroCheckBox1.Location = new System.Drawing.Point(12, 30);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(62, 15);
            this.metroCheckBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroCheckBox1.StyleManager = null;
            this.metroCheckBox1.TabIndex = 6;
            this.metroCheckBox1.Text = "已修改";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroCheckBox1.UseStyleColors = false;
            this.metroCheckBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(3, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(608, 236);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "提交时间";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "质检问题";
            this.Column4.Name = "Column4";
            this.Column4.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "医生反馈";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // MedicalQcMsgCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroCheckBox2);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MedicalQcMsgCard";
            this.Size = new System.Drawing.Size(614, 290);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.metroCheckBox1, 0);
            this.Controls.SetChildIndex(this.metroCheckBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
