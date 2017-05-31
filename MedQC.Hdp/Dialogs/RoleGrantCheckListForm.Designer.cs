namespace Heren.MedQC.Hdp
{
    partial class RoleGrantCheckListForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flpGrant = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCopyGrant = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpGrant
            // 
            this.flpGrant.AllowDrop = true;
            this.flpGrant.AutoScroll = true;
            this.flpGrant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpGrant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGrant.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGrant.Location = new System.Drawing.Point(0, 37);
            this.flpGrant.Name = "flpGrant";
            this.flpGrant.Size = new System.Drawing.Size(731, 353);
            this.flpGrant.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCopyGrant);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.cboProduct);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 37);
            this.panel1.TabIndex = 1;
            // 
            // btnCopyGrant
            // 
            this.btnCopyGrant.Image = global::Heren.MedQC.Hdp.Properties.Resources.Copy;
            this.btnCopyGrant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyGrant.Location = new System.Drawing.Point(525, 5);
            this.btnCopyGrant.Name = "btnCopyGrant";
            this.btnCopyGrant.Size = new System.Drawing.Size(169, 27);
            this.btnCopyGrant.TabIndex = 3;
            this.btnCopyGrant.Text = "从及其他角色复制";
            this.btnCopyGrant.UseVisualStyleBackColor = true;
            this.btnCopyGrant.Click += new System.EventHandler(this.btnCopyGrant_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Heren.MedQC.Hdp.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(430, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(258, 10);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(145, 18);
            this.chkAll.TabIndex = 2;
            this.chkAll.Text = "全选/取消勾选所有";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(69, 7);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(165, 22);
            this.cboProduct.TabIndex = 1;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品：";
            // 
            // RoleGrantCheckListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(731, 390);
            this.Controls.Add(this.flpGrant);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RoleGrantCheckListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "授权管理";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpGrant;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCopyGrant;
    }
}