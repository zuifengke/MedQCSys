namespace Heren.MedQC.Systems
{
    partial class MedCallBackForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedCallBackForm));
            this.dgvDoctors = new Heren.Common.Controls.TableView.DataTableView();
            this.colUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQueryByDept = new Heren.Common.Controls.FlatButton();
            this.cboDeptList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.colPatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChargeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdmissionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptDischargeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDischargeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUserID = new Heren.Common.Controls.TextBoxButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCallBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDoctors
            // 
            this.dgvDoctors.AllowUserToResizeColumns = false;
            this.dgvDoctors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoctors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoctors.ColumnHeadersHeight = 35;
            this.dgvDoctors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserID,
            this.colUserName});
            this.dgvDoctors.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDoctors.Location = new System.Drawing.Point(687, 74);
            this.dgvDoctors.MultiSelect = false;
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.RowHeadersVisible = false;
            this.dgvDoctors.RowHeadersWidth = 32;
            this.dgvDoctors.Size = new System.Drawing.Size(191, 337);
            this.dgvDoctors.TabIndex = 16;
            // 
            // colUserID
            // 
            this.colUserID.FillWeight = 72F;
            this.colUserID.Frozen = true;
            this.colUserID.HeaderText = "医生用户名";
            this.colUserID.Name = "colUserID";
            this.colUserID.ReadOnly = true;
            this.colUserID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colUserName
            // 
            this.colUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUserName.FillWeight = 72F;
            this.colUserName.HeaderText = "医生";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQueryByDept);
            this.groupBox1.Controls.Add(this.cboDeptList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(247, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "按出院科室";
            // 
            // btnQueryByDept
            // 
            this.btnQueryByDept.Location = new System.Drawing.Point(193, 19);
            this.btnQueryByDept.Name = "btnQueryByDept";
            this.btnQueryByDept.Size = new System.Drawing.Size(24, 24);
            this.btnQueryByDept.TabIndex = 3;
            this.btnQueryByDept.ToolTipText = null;
            // 
            // cboDeptList
            // 
            this.cboDeptList.CandidateWidth = 200;
            this.cboDeptList.DroppedDown = false;
            this.cboDeptList.Location = new System.Drawing.Point(42, 19);
            this.cboDeptList.Name = "cboDeptList";
            this.cboDeptList.SelectedItem = null;
            this.cboDeptList.Size = new System.Drawing.Size(145, 24);
            this.cboDeptList.TabIndex = 1;
            this.cboDeptList.SelectedIndexChanged += new System.EventHandler(this.cboDeptList_SelectedIndexChanged);
            this.cboDeptList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDeptList_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "科室";
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToOrderColumns = true;
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatName,
            this.colChargeType,
            this.colDeptName,
            this.colAdmissionDate,
            this.colDeptDischargeFrom,
            this.colDischargeDate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatients.Location = new System.Drawing.Point(12, 74);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowTemplate.Height = 27;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(669, 337);
            this.dgvPatients.TabIndex = 17;
            // 
            // colPatName
            // 
            this.colPatName.HeaderText = "患者姓名";
            this.colPatName.Name = "colPatName";
            this.colPatName.ReadOnly = true;
            this.colPatName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colChargeType
            // 
            this.colChargeType.HeaderText = "费别";
            this.colChargeType.Name = "colChargeType";
            this.colChargeType.ReadOnly = true;
            // 
            // colDeptName
            // 
            this.colDeptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDeptName.FillWeight = 120F;
            this.colDeptName.HeaderText = "入院科室";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            this.colDeptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAdmissionDate
            // 
            this.colAdmissionDate.FillWeight = 160F;
            this.colAdmissionDate.HeaderText = "入院时间";
            this.colAdmissionDate.Name = "colAdmissionDate";
            this.colAdmissionDate.ReadOnly = true;
            this.colAdmissionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAdmissionDate.Width = 160;
            // 
            // colDeptDischargeFrom
            // 
            this.colDeptDischargeFrom.FillWeight = 120F;
            this.colDeptDischargeFrom.HeaderText = "出院科室";
            this.colDeptDischargeFrom.Name = "colDeptDischargeFrom";
            this.colDeptDischargeFrom.ReadOnly = true;
            this.colDeptDischargeFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDeptDischargeFrom.Width = 80;
            // 
            // colDischargeDate
            // 
            this.colDischargeDate.FillWeight = 120F;
            this.colDischargeDate.HeaderText = "出院时间";
            this.colDischargeDate.Name = "colDischargeDate";
            this.colDischargeDate.ReadOnly = true;
            this.colDischargeDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDischargeDate.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUserID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "按患者ID号";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserID.ButtonImage = ((System.Drawing.Image)(resources.GetObject("txtUserID.ButtonImage")));
            this.txtUserID.ButtonToolTip = null;
            this.txtUserID.Font = new System.Drawing.Font("宋体", 9F);
            this.txtUserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserID.Location = new System.Drawing.Point(68, 20);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(148, 21);
            this.txtUserID.TabIndex = 7;
            this.txtUserID.ButtonClick += new System.EventHandler(this.txtUserID_ButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "患者ID号：";
            // 
            // btnCallBack
            // 
            this.btnCallBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCallBack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCallBack.Location = new System.Drawing.Point(257, 421);
            this.btnCallBack.Name = "btnCallBack";
            this.btnCallBack.Size = new System.Drawing.Size(95, 25);
            this.btnCallBack.TabIndex = 18;
            this.btnCallBack.Text = "召回";
            this.btnCallBack.UseVisualStyleBackColor = true;
            this.btnCallBack.Click += new System.EventHandler(this.btnCallBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(373, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 25);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MedCallBackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 466);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCallBack);
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MedCallBackForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病历召回";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Controls.TableView.DataTableView dgvDoctors;
        private System.Windows.Forms.GroupBox groupBox1;
        private Heren.Common.Controls.FlatButton btnQueryByDept;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private Heren.Common.Controls.TextBoxButton txtUserID;
        private System.Windows.Forms.Button btnCallBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChargeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdmissionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptDischargeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDischargeDate;


    }
}