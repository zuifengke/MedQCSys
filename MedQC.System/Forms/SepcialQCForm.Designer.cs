namespace Heren.MedQC.Systems
{
    partial class SpecialQCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialQCForm));
            this.label4 = new System.Windows.Forms.Label();
            this.cobParentDoc = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cobRequestDoc = new Heren.Common.Controls.DictInput.FindComboBox();
            this.lable34 = new System.Windows.Forms.Label();
            this.cobDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInDaysEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInDaysBegin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSpecialistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDischargeMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDischargeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetailList = new System.Windows.Forms.DataGridView();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDischargeMode = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cboPatientCondition = new Heren.Common.Controls.DictInput.FindComboBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(713, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 37;
            this.label4.Text = "天 ";
            // 
            // cobParentDoc
            // 
            this.cobParentDoc.CandidateWidth = 200;
            this.cobParentDoc.DroppedDown = false;
            this.cobParentDoc.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobParentDoc.Location = new System.Drawing.Point(253, 49);
            this.cobParentDoc.Name = "cobParentDoc";
            this.cobParentDoc.SelectedItem = null;
            this.cobParentDoc.Size = new System.Drawing.Size(88, 20);
            this.cobParentDoc.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(180, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 35;
            this.label5.Text = "上级医生";
            // 
            // cobRequestDoc
            // 
            this.cobRequestDoc.CandidateWidth = 200;
            this.cobRequestDoc.DroppedDown = false;
            this.cobRequestDoc.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobRequestDoc.Location = new System.Drawing.Point(80, 49);
            this.cobRequestDoc.Name = "cobRequestDoc";
            this.cobRequestDoc.SelectedItem = null;
            this.cobRequestDoc.Size = new System.Drawing.Size(94, 20);
            this.cobRequestDoc.TabIndex = 34;
            // 
            // lable34
            // 
            this.lable34.AutoSize = true;
            this.lable34.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable34.Location = new System.Drawing.Point(7, 52);
            this.lable34.Name = "lable34";
            this.lable34.Size = new System.Drawing.Size(67, 15);
            this.lable34.TabIndex = 33;
            this.lable34.Text = "经治医生";
            // 
            // cobDeptName
            // 
            this.cobDeptName.CandidateWidth = 200;
            this.cobDeptName.DroppedDown = false;
            this.cobDeptName.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobDeptName.Location = new System.Drawing.Point(399, 17);
            this.cobDeptName.Name = "cobDeptName";
            this.cobDeptName.SelectedItem = null;
            this.cobDeptName.Size = new System.Drawing.Size(111, 21);
            this.cobDeptName.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(356, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "科室";
            // 
            // txtInDaysEnd
            // 
            this.txtInDaysEnd.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInDaysEnd.Location = new System.Drawing.Point(669, 47);
            this.txtInDaysEnd.Name = "txtInDaysEnd";
            this.txtInDaysEnd.Size = new System.Drawing.Size(38, 24);
            this.txtInDaysEnd.TabIndex = 30;
            this.txtInDaysEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInDaysEnd_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(641, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "至";
            // 
            // txtInDaysBegin
            // 
            this.txtInDaysBegin.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInDaysBegin.Location = new System.Drawing.Point(599, 47);
            this.txtInDaysBegin.Name = "txtInDaysBegin";
            this.txtInDaysBegin.Size = new System.Drawing.Size(39, 24);
            this.txtInDaysBegin.TabIndex = 28;
            this.txtInDaysBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInDaysBegin_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(525, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "住院天数";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 81);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetailList);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Size = new System.Drawing.Size(1126, 309);
            this.splitContainer1.SplitterDistance = 775;
            this.splitContainer1.TabIndex = 23;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSpecialistName,
            this.colPatientName,
            this.colPatientID,
            this.colVisitID,
            this.colDept,
            this.colPatientCondition,
            this.colDischargeMode,
            this.colDoctor,
            this.colVisitTime,
            this.colDischargeTime});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(775, 309);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // colSpecialistName
            // 
            this.colSpecialistName.HeaderText = "专家姓名";
            this.colSpecialistName.Name = "colSpecialistName";
            this.colSpecialistName.ReadOnly = true;
            // 
            // colPatientName
            // 
            this.colPatientName.FillWeight = 120F;
            this.colPatientName.HeaderText = "患者";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            this.colPatientName.Width = 80;
            // 
            // colPatientID
            // 
            this.colPatientID.FillWeight = 160F;
            this.colPatientID.HeaderText = "患者ID号";
            this.colPatientID.Name = "colPatientID";
            this.colPatientID.ReadOnly = true;
            this.colPatientID.Width = 90;
            // 
            // colVisitID
            // 
            this.colVisitID.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colVisitID.FillWeight = 90F;
            this.colVisitID.HeaderText = "入院次";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            this.colVisitID.Width = 80;
            // 
            // colDept
            // 
            this.colDept.Width = 150;
            this.colDept.HeaderText = "科室";
            this.colDept.Name = "colDept";
            this.colDept.ReadOnly = true;
            // 
            // colPatientCondition
            // 
            this.colPatientCondition.HeaderText = "病情";
            this.colPatientCondition.Name = "colPatientCondition";
            this.colPatientCondition.ReadOnly = true;
            // 
            // colDischargeMode
            // 
            this.colDischargeMode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDischargeMode.HeaderText = "出院方式";
            this.colDischargeMode.Name = "colDischargeMode";
            this.colDischargeMode.ReadOnly = true;
            // 
            // colDoctor
            // 
            this.colDoctor.HeaderText = "医师";
            this.colDoctor.Name = "colDoctor";
            this.colDoctor.ReadOnly = true;
            // 
            // colVisitTime
            // 
            this.colVisitTime.HeaderText = "入院日期";
            this.colVisitTime.Name = "colVisitTime";
            this.colVisitTime.ReadOnly = true;
            // 
            // colDischargeTime
            // 
            this.colDischargeTime.HeaderText = "出院日期";
            this.colDischargeTime.Name = "colDischargeTime";
            this.colDischargeTime.ReadOnly = true;
            // 
            // dgvDetailList
            // 
            this.dgvDetailList.AllowUserToAddRows = false;
            this.dgvDetailList.AllowUserToDeleteRows = false;
            this.dgvDetailList.AllowUserToOrderColumns = true;
            this.dgvDetailList.AllowUserToResizeRows = false;
            this.dgvDetailList.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserName,
            this.colPatientCount});
            this.dgvDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailList.Location = new System.Drawing.Point(0, 25);
            this.dgvDetailList.MultiSelect = false;
            this.dgvDetailList.Name = "dgvDetailList";
            this.dgvDetailList.ReadOnly = true;
            this.dgvDetailList.RowHeadersVisible = false;
            this.dgvDetailList.RowTemplate.Height = 27;
            this.dgvDetailList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetailList.Size = new System.Drawing.Size(347, 284);
            this.dgvDetailList.TabIndex = 6;
            this.dgvDetailList.SelectionChanged += new System.EventHandler(this.dgvDetailList_SelectionChanged);
            // 
            // colUserName
            // 
            this.colUserName.FillWeight = 120F;
            this.colUserName.HeaderText = "专家";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 120;
            // 
            // colPatientCount
            // 
            this.colPatientCount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPatientCount.FillWeight = 150F;
            this.colPatientCount.HeaderText = "分配";
            this.colPatientCount.Name = "colPatientCount";
            this.colPatientCount.ReadOnly = true;
            this.colPatientCount.Width = 150;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelect,
            this.tsbRemove});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(347, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbSelect
            // 
            this.tsbSelect.Image = global::Heren.MedQC.Systems.Properties.Resources.Add;
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(76, 22);
            this.tsbSelect.Text = "选择专家";
            this.tsbSelect.Click += new System.EventHandler(this.tsbSelect_Click);
            // 
            // tsbRemove
            // 
            this.tsbRemove.Image = global::Heren.MedQC.Systems.Properties.Resources.Delete;
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(52, 22);
            this.tsbRemove.Text = "移除";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.dtpBeginTime);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnSaveResult);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.numCount);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtInDaysBegin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cobParentDoc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtInDaysEnd);
            this.panel1.Controls.Add(this.cobRequestDoc);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lable34);
            this.panel1.Controls.Add(this.cboDischargeMode);
            this.panel1.Controls.Add(this.cboPatientCondition);
            this.panel1.Controls.Add(this.cobDeptName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 81);
            this.panel1.TabIndex = 38;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndTime.Location = new System.Drawing.Point(760, 15);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(129, 24);
            this.dtpEndTime.TabIndex = 40;
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBeginTime.Location = new System.Drawing.Point(600, 15);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(129, 24);
            this.dtpBeginTime.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(737, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = "~";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(525, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 31;
            this.label7.Text = "出院日期";
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveResult.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveResult.Image = global::Heren.MedQC.Systems.Properties.Resources.Save;
            this.btnSaveResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveResult.Location = new System.Drawing.Point(1054, 47);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(65, 23);
            this.btnSaveResult.TabIndex = 42;
            this.btnSaveResult.Text = "保存";
            this.btnSaveResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Image = global::Heren.MedQC.Systems.Properties.Resources.get_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(982, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "抽取";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numCount
            // 
            this.numCount.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numCount.Location = new System.Drawing.Point(459, 48);
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(51, 24);
            this.numCount.TabIndex = 41;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(982, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 24);
            this.txtName.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(356, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 38;
            this.label11.Text = "每科室抽取";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(437, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 15);
            this.label13.TabIndex = 38;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(961, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 15);
            this.label12.TabIndex = 38;
            this.label12.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(895, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 38;
            this.label6.Text = "抽检名称";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(180, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "出院方式";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "患者病情";
            // 
            // cboDischargeMode
            // 
            this.cboDischargeMode.CandidateWidth = 200;
            this.cboDischargeMode.DroppedDown = false;
            this.cboDischargeMode.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDischargeMode.Items.AddRange(new object[] {
            "",
            "正常",
            "转院",
            "死亡"});
            this.cboDischargeMode.Location = new System.Drawing.Point(253, 17);
            this.cboDischargeMode.Name = "cboDischargeMode";
            this.cboDischargeMode.SelectedItem = null;
            this.cboDischargeMode.Size = new System.Drawing.Size(88, 21);
            this.cboDischargeMode.TabIndex = 32;
            // 
            // cboPatientCondition
            // 
            this.cboPatientCondition.CandidateWidth = 200;
            this.cboPatientCondition.DroppedDown = false;
            this.cboPatientCondition.Font = new System.Drawing.Font("宋体", 10.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPatientCondition.Items.AddRange(new object[] {
            "",
            "一般",
            "急",
            "危"});
            this.cboPatientCondition.Location = new System.Drawing.Point(79, 17);
            this.cboPatientCondition.Name = "cboPatientCondition";
            this.cboPatientCondition.SelectedItem = null;
            this.cboPatientCondition.Size = new System.Drawing.Size(95, 21);
            this.cboPatientCondition.TabIndex = 32;
            // 
            // SpecialQCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 390);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpecialQCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病案随机抽检";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailList)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvDetailList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientCount;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbSelect;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInDaysBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInDaysEnd;
        private System.Windows.Forms.Label label3;
        private Heren.Common.Controls.DictInput.FindComboBox cobDeptName;
        private Heren.Common.Controls.DictInput.FindComboBox cobRequestDoc;
        private System.Windows.Forms.Label lable34;
        private Heren.Common.Controls.DictInput.FindComboBox cobParentDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecialistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDischargeMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDischargeTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private Heren.Common.Controls.DictInput.FindComboBox cboDischargeMode;
        private Heren.Common.Controls.DictInput.FindComboBox cboPatientCondition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}