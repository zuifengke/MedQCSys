namespace Heren.MedQC.Systems
{
    partial class SpecialDoctorForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnConfirm = new System.Windows.Forms.ToolStripButton();
            this.toolbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnConfirm,
            this.toolbtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 324);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(659, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnConfirm
            // 
            this.toolbtnConfirm.Image = global::Heren.MedQC.Systems.Properties.Resources.Add;
            this.toolbtnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnConfirm.Name = "toolbtnConfirm";
            this.toolbtnConfirm.Size = new System.Drawing.Size(111, 27);
            this.toolbtnConfirm.Text = "加入本次抽检";
            this.toolbtnConfirm.Click += new System.EventHandler(this.toolbtnConfirm_Click);
            // 
            // toolbtnCancel
            // 
            this.toolbtnCancel.Image = global::Heren.MedQC.Systems.Properties.Resources.Cancel;
            this.toolbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnCancel.Name = "toolbtnCancel";
            this.toolbtnCancel.Size = new System.Drawing.Size(55, 27);
            this.toolbtnCancel.Text = "取消";
            this.toolbtnCancel.Click += new System.EventHandler(this.toolbtnCancel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckBox,
            this.colUserID,
            this.colUserName,
            this.colDeptName});
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(651, 319);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(42, 10);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 6;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // colCheckBox
            // 
            this.colCheckBox.HeaderText = "选择";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.ReadOnly = true;
            this.colCheckBox.Width = 60;
            // 
            // colUserID
            // 
            this.colUserID.HeaderText = "用户账号";
            this.colUserID.MaxInputLength = 4;
            this.colUserID.Name = "colUserID";
            this.colUserID.ReadOnly = true;
            this.colUserID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colUserName
            // 
            this.colUserName.FillWeight = 250F;
            this.colUserName.HeaderText = "专家姓名";
            this.colUserName.MaxInputLength = 8;
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUserName.Width = 180;
            // 
            // colDeptName
            // 
            this.colDeptName.FillWeight = 150F;
            this.colDeptName.HeaderText = "所在科室";
            this.colDeptName.MaxInputLength = 8;
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeptName.Width = 250;
            // 
            // SpecialDoctorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(659, 354);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "SpecialDoctorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "专家资源库";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolbtnCancel;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ToolStripButton toolbtnConfirm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
    }
}