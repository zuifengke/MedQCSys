namespace Heren.MedQC.Hdp
{
    partial class CopyRoleGrantForm
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
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.colRoleName,
            this.colRoleCode});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(445, 373);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // colCheckBox
            // 
            this.colCheckBox.HeaderText = "选择";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.ReadOnly = true;
            // 
            // colRoleName
            // 
            this.colRoleName.FillWeight = 250F;
            this.colRoleName.HeaderText = "角色名称";
            this.colRoleName.MaxInputLength = 8;
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            this.colRoleName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRoleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRoleName.Width = 150;
            // 
            // colRoleCode
            // 
            this.colRoleCode.FillWeight = 250F;
            this.colRoleCode.HeaderText = "角色代码";
            this.colRoleCode.MaxInputLength = 20;
            this.colRoleCode.Name = "colRoleCode";
            this.colRoleCode.ReadOnly = true;
            this.colRoleCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRoleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRoleCode.Width = 150;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 373);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(445, 30);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolbtnSave.AutoSize = false;
            this.toolbtnSave.Image = global::Heren.MedQC.Hdp.Properties.Resources.Copy;
            this.toolbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSave.Name = "toolbtnSave";
            this.toolbtnSave.Size = new System.Drawing.Size(84, 26);
            this.toolbtnSave.Text = "复制权限";
            this.toolbtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolbtnSave.ToolTipText = "保存";
            this.toolbtnSave.Click += new System.EventHandler(this.toolbtnSave_Click);
            // 
            // CopyRoleGrantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 403);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CopyRoleGrantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "角色权限复制";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleCode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
    }
}