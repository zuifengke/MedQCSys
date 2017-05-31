namespace Heren.MedQC.Hdp
{
    partial class UserManageForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManageForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuModifyUserRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancelModify = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectAll = new Heren.Common.Controls.HerenButton();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUserName = new Heren.Common.Controls.TextBoxButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUserID = new Heren.Common.Controls.TextBoxButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDeptList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.btnQueryByDept = new Heren.Common.Controls.FlatButton();
            this.cmenuSelectUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeptAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeptWard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeptOutp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeptNurse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeptOther = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAuthority = new Heren.Common.Controls.HerenButton();
            this.colUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdminDepts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmenuSelectUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuModifyUserRight,
            this.mnuCancelModify});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(185, 48);
            // 
            // mnuModifyUserRight
            // 
            this.mnuModifyUserRight.Name = "mnuModifyUserRight";
            this.mnuModifyUserRight.Size = new System.Drawing.Size(184, 22);
            this.mnuModifyUserRight.Text = "修改选中用户的权限";
            // 
            // mnuCancelModify
            // 
            this.mnuCancelModify.Name = "mnuCancelModify";
            this.mnuCancelModify.Size = new System.Drawing.Size(184, 22);
            this.mnuCancelModify.Text = "取消对选中行的修改";
            this.mnuCancelModify.Click += new System.EventHandler(this.mnuCancelModify_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnSelectAll.Location = new System.Drawing.Point(564, 22);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(88, 28);
            this.btnSelectAll.TabIndex = 12;
            this.btnSelectAll.Text = "查看所有";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 28;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserID,
            this.colUserName,
            this.colDeptName,
            this.colRoleName,
            this.colAdminDepts});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView1.Location = new System.Drawing.Point(1, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 32;
            this.dataGridView1.Size = new System.Drawing.Size(1058, 446);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "ID号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "科室";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtUserName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(396, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 56);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "按姓名(模糊匹配)";
            // 
            // txtUserName
            // 
            this.txtUserName.ButtonImage = ((System.Drawing.Image)(resources.GetObject("txtUserName.ButtonImage")));
            this.txtUserName.ButtonToolTip = null;
            this.txtUserName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserName.Location = new System.Drawing.Point(38, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(114, 21);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.ButtonClick += new System.EventHandler(this.txtUserName_ButtonClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUserID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(233, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "按ID号(区分大小写)";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserID.ButtonImage = ((System.Drawing.Image)(resources.GetObject("txtUserID.ButtonImage")));
            this.txtUserID.ButtonToolTip = null;
            this.txtUserID.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtUserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserID.Location = new System.Drawing.Point(39, 22);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(110, 21);
            this.txtUserID.TabIndex = 6;
            this.txtUserID.ButtonClick += new System.EventHandler(this.txtUserID_ButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDeptList);
            this.groupBox1.Controls.Add(this.btnQueryByDept);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按科室";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cboDeptList
            // 
            this.cboDeptList.Location = new System.Drawing.Point(42, 20);
            this.cboDeptList.Name = "cboDeptList";
            this.cboDeptList.Size = new System.Drawing.Size(145, 23);
            this.cboDeptList.TabIndex = 4;
            this.cboDeptList.SelectedIndexChanged += new System.EventHandler(this.cboDeptList_SelectedIndexChanged);
            // 
            // btnQueryByDept
            // 
            this.btnQueryByDept.Location = new System.Drawing.Point(193, 19);
            this.btnQueryByDept.Name = "btnQueryByDept";
            this.btnQueryByDept.Size = new System.Drawing.Size(24, 24);
            this.btnQueryByDept.TabIndex = 3;
            this.btnQueryByDept.ToolTipText = null;
            this.btnQueryByDept.Click += new System.EventHandler(this.btnQueryByDept_Click);
            // 
            // cmenuSelectUser
            // 
            this.cmenuSelectUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeptAll,
            this.toolStripSeparator1,
            this.mnuDeptWard,
            this.mnuDeptOutp,
            this.mnuDeptNurse,
            this.mnuDeptOther});
            this.cmenuSelectUser.Name = "cmenuSelectUser";
            this.cmenuSelectUser.Size = new System.Drawing.Size(125, 120);
            // 
            // mnuDeptAll
            // 
            this.mnuDeptAll.Name = "mnuDeptAll";
            this.mnuDeptAll.Size = new System.Drawing.Size(124, 22);
            this.mnuDeptAll.Text = "所有科室";
            this.mnuDeptAll.Click += new System.EventHandler(this.mnuDeptAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // mnuDeptWard
            // 
            this.mnuDeptWard.Name = "mnuDeptWard";
            this.mnuDeptWard.Size = new System.Drawing.Size(124, 22);
            this.mnuDeptWard.Text = "住院科室";
            this.mnuDeptWard.Click += new System.EventHandler(this.mnuDeptWard_Click);
            // 
            // mnuDeptOutp
            // 
            this.mnuDeptOutp.Name = "mnuDeptOutp";
            this.mnuDeptOutp.Size = new System.Drawing.Size(124, 22);
            this.mnuDeptOutp.Text = "门诊科室";
            this.mnuDeptOutp.Click += new System.EventHandler(this.mnuDeptOutp_Click);
            // 
            // mnuDeptNurse
            // 
            this.mnuDeptNurse.Name = "mnuDeptNurse";
            this.mnuDeptNurse.Size = new System.Drawing.Size(124, 22);
            this.mnuDeptNurse.Text = "护理单元";
            this.mnuDeptNurse.Click += new System.EventHandler(this.mnuDeptNurse_Click);
            // 
            // mnuDeptOther
            // 
            this.mnuDeptOther.Name = "mnuDeptOther";
            this.mnuDeptOther.Size = new System.Drawing.Size(124, 22);
            this.mnuDeptOther.Text = "其他所有";
            this.mnuDeptOther.Click += new System.EventHandler(this.mnuDeptOther_Click);
            // 
            // btnAuthority
            // 
            this.btnAuthority.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnAuthority.Image = global::Heren.MedQC.Hdp.Properties.Resources.Authority;
            this.btnAuthority.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthority.Location = new System.Drawing.Point(659, 22);
            this.btnAuthority.Name = "btnAuthority";
            this.btnAuthority.Size = new System.Drawing.Size(80, 28);
            this.btnAuthority.TabIndex = 13;
            this.btnAuthority.Text = "授权";
            this.btnAuthority.UseVisualStyleBackColor = true;
            this.btnAuthority.Click += new System.EventHandler(this.btnAuthority_Click);
            // 
            // colUserID
            // 
            this.colUserID.FillWeight = 72F;
            this.colUserID.Frozen = true;
            this.colUserID.HeaderText = "用户ID";
            this.colUserID.Name = "colUserID";
            this.colUserID.ReadOnly = true;
            this.colUserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colUserName
            // 
            this.colUserName.FillWeight = 72F;
            this.colUserName.Frozen = true;
            this.colUserName.HeaderText = "姓名";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colDeptName
            // 
            this.colDeptName.FillWeight = 120F;
            this.colDeptName.Frozen = true;
            this.colDeptName.HeaderText = "所属科室";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.Width = 250;
            // 
            // colRoleName
            // 
            this.colRoleName.HeaderText = "权限角色";
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            this.colRoleName.Width = 300;
            // 
            // colAdminDepts
            // 
            this.colAdminDepts.HeaderText = "质控管辖科室";
            this.colAdminDepts.Name = "colAdminDepts";
            this.colAdminDepts.ReadOnly = true;
            this.colAdminDepts.Width = 300;
            // 
            // UserManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 515);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnAuthority);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UserManageForm";
            this.Text = "用户权限管理";
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmenuSelectUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Controls.HerenButton btnAuthority;
        private Heren.Common.Controls.HerenButton btnSelectAll;
        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuCancelModify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Heren.Common.Controls.TextBoxButton txtUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private Heren.Common.Controls.TextBoxButton txtUserID;
        private System.Windows.Forms.GroupBox groupBox1;
        private Heren.Common.Controls.FlatButton btnQueryByDept;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyUserRight;
        private System.Windows.Forms.ContextMenuStrip cmenuSelectUser;
        private System.Windows.Forms.ToolStripMenuItem mnuDeptAll;
        private System.Windows.Forms.ToolStripMenuItem mnuDeptWard;
        private System.Windows.Forms.ToolStripMenuItem mnuDeptOutp;
        private System.Windows.Forms.ToolStripMenuItem mnuDeptNurse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeptOther;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdminDepts;
    }
}