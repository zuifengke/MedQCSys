namespace MedQCSys.Dialogs
{
    partial class ComplexSearchForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numEndAge = new System.Windows.Forms.NumericUpDown();
            this.numBeginAge = new System.Windows.Forms.NumericUpDown();
            this.cboPatientCondition = new Heren.Common.Controls.DictInput.FindComboBox();
            this.chkPatientCondition = new System.Windows.Forms.CheckBox();
            this.cboNursingClass = new Heren.Common.Controls.DictInput.FindComboBox();
            this.chkNursingClass = new System.Windows.Forms.CheckBox();
            this.cboChargeType = new Heren.Common.Controls.DictInput.FindComboBox();
            this.chkBirthTime = new System.Windows.Forms.CheckBox();
            this.chkChargeType = new System.Windows.Forms.CheckBox();
            this.cboIdentity = new Heren.Common.Controls.DictInput.FindComboBox();
            this.chkIdentity = new System.Windows.Forms.CheckBox();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.chkDoctor = new System.Windows.Forms.CheckBox();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.chkDept = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.chkDiagnosis = new System.Windows.Forms.CheckBox();
            this.fdCBXOperation = new Heren.Common.Controls.DictInput.FindComboBox();
            this.chkOperation = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkMutilOperation = new System.Windows.Forms.CheckBox();
            this.groupNeed = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPatientStatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDischargeTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDischargeTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpVisitTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpVisitTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.chkDischargeTime = new System.Windows.Forms.CheckBox();
            this.chkVisitTime = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkLabResult = new System.Windows.Forms.CheckBox();
            this.fcbLabReprotDict = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeginAge)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupNeed.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(564, 480);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 31);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "确定";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numEndAge);
            this.groupBox1.Controls.Add(this.numBeginAge);
            this.groupBox1.Controls.Add(this.cboPatientCondition);
            this.groupBox1.Controls.Add(this.chkPatientCondition);
            this.groupBox1.Controls.Add(this.cboNursingClass);
            this.groupBox1.Controls.Add(this.chkNursingClass);
            this.groupBox1.Controls.Add(this.cboChargeType);
            this.groupBox1.Controls.Add(this.chkBirthTime);
            this.groupBox1.Controls.Add(this.chkChargeType);
            this.groupBox1.Controls.Add(this.cboIdentity);
            this.groupBox1.Controls.Add(this.chkIdentity);
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.chkDoctor);
            this.groupBox1.Controls.Add(this.cboDeptName);
            this.groupBox1.Controls.Add(this.chkDept);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可选条件";
            // 
            // numEndAge
            // 
            this.numEndAge.Location = new System.Drawing.Point(247, 123);
            this.numEndAge.Name = "numEndAge";
            this.numEndAge.ReadOnly = true;
            this.numEndAge.Size = new System.Drawing.Size(91, 23);
            this.numEndAge.TabIndex = 46;
            // 
            // numBeginAge
            // 
            this.numBeginAge.Location = new System.Drawing.Point(127, 123);
            this.numBeginAge.Name = "numBeginAge";
            this.numBeginAge.ReadOnly = true;
            this.numBeginAge.Size = new System.Drawing.Size(91, 23);
            this.numBeginAge.TabIndex = 46;
            // 
            // cboPatientCondition
            // 
            this.cboPatientCondition.DroppedDown = false;
            this.cboPatientCondition.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboPatientCondition.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cboPatientCondition.Items.AddRange(new object[] {
            "",
            "一般",
            "危",
            "急"});
            this.cboPatientCondition.Location = new System.Drawing.Point(328, 55);
            this.cboPatientCondition.Name = "cboPatientCondition";
            this.cboPatientCondition.ReadOnly = true;
            this.cboPatientCondition.SelectedItem = null;
            this.cboPatientCondition.Size = new System.Drawing.Size(120, 23);
            this.cboPatientCondition.TabIndex = 45;
            // 
            // chkPatientCondition
            // 
            this.chkPatientCondition.AutoSize = true;
            this.chkPatientCondition.Location = new System.Drawing.Point(235, 58);
            this.chkPatientCondition.Name = "chkPatientCondition";
            this.chkPatientCondition.Size = new System.Drawing.Size(54, 18);
            this.chkPatientCondition.TabIndex = 44;
            this.chkPatientCondition.Text = "病情";
            this.chkPatientCondition.UseVisualStyleBackColor = true;
            this.chkPatientCondition.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // cboNursingClass
            // 
            this.cboNursingClass.DroppedDown = false;
            this.cboNursingClass.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboNursingClass.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cboNursingClass.Items.AddRange(new object[] {
            "",
            "特级护理",
            "一级护理",
            "二级护理",
            "三级护理"});
            this.cboNursingClass.Location = new System.Drawing.Point(328, 18);
            this.cboNursingClass.Name = "cboNursingClass";
            this.cboNursingClass.ReadOnly = true;
            this.cboNursingClass.SelectedItem = null;
            this.cboNursingClass.Size = new System.Drawing.Size(119, 23);
            this.cboNursingClass.TabIndex = 43;
            // 
            // chkNursingClass
            // 
            this.chkNursingClass.AutoSize = true;
            this.chkNursingClass.Location = new System.Drawing.Point(235, 20);
            this.chkNursingClass.Name = "chkNursingClass";
            this.chkNursingClass.Size = new System.Drawing.Size(82, 18);
            this.chkNursingClass.TabIndex = 42;
            this.chkNursingClass.Text = "护理等级";
            this.chkNursingClass.UseVisualStyleBackColor = true;
            this.chkNursingClass.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // cboChargeType
            // 
            this.cboChargeType.DroppedDown = false;
            this.cboChargeType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboChargeType.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cboChargeType.Location = new System.Drawing.Point(327, 84);
            this.cboChargeType.Name = "cboChargeType";
            this.cboChargeType.ReadOnly = true;
            this.cboChargeType.SelectedItem = null;
            this.cboChargeType.Size = new System.Drawing.Size(121, 23);
            this.cboChargeType.TabIndex = 35;
            // 
            // chkBirthTime
            // 
            this.chkBirthTime.AutoSize = true;
            this.chkBirthTime.Location = new System.Drawing.Point(9, 124);
            this.chkBirthTime.Name = "chkBirthTime";
            this.chkBirthTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkBirthTime.Size = new System.Drawing.Size(54, 18);
            this.chkBirthTime.TabIndex = 34;
            this.chkBirthTime.Text = "年龄";
            this.chkBirthTime.UseVisualStyleBackColor = true;
            this.chkBirthTime.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkChargeType
            // 
            this.chkChargeType.AutoSize = true;
            this.chkChargeType.Location = new System.Drawing.Point(235, 91);
            this.chkChargeType.Name = "chkChargeType";
            this.chkChargeType.Size = new System.Drawing.Size(54, 18);
            this.chkChargeType.TabIndex = 34;
            this.chkChargeType.Text = "费别";
            this.chkChargeType.UseVisualStyleBackColor = true;
            this.chkChargeType.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // cboIdentity
            // 
            this.cboIdentity.DroppedDown = false;
            this.cboIdentity.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboIdentity.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cboIdentity.Location = new System.Drawing.Point(94, 84);
            this.cboIdentity.Name = "cboIdentity";
            this.cboIdentity.ReadOnly = true;
            this.cboIdentity.SelectedItem = null;
            this.cboIdentity.Size = new System.Drawing.Size(124, 23);
            this.cboIdentity.TabIndex = 33;
            // 
            // chkIdentity
            // 
            this.chkIdentity.AutoSize = true;
            this.chkIdentity.Location = new System.Drawing.Point(9, 91);
            this.chkIdentity.Name = "chkIdentity";
            this.chkIdentity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIdentity.Size = new System.Drawing.Size(54, 18);
            this.chkIdentity.TabIndex = 32;
            this.chkIdentity.Text = "身份";
            this.chkIdentity.UseVisualStyleBackColor = true;
            this.chkIdentity.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(94, 53);
            this.txtDoctor.MaxLength = 20;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.Size = new System.Drawing.Size(124, 23);
            this.txtDoctor.TabIndex = 29;
            // 
            // chkDoctor
            // 
            this.chkDoctor.AutoSize = true;
            this.chkDoctor.Location = new System.Drawing.Point(9, 55);
            this.chkDoctor.Name = "chkDoctor";
            this.chkDoctor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDoctor.Size = new System.Drawing.Size(82, 18);
            this.chkDoctor.TabIndex = 28;
            this.chkDoctor.Text = "经治医师";
            this.chkDoctor.UseVisualStyleBackColor = true;
            this.chkDoctor.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // cboDeptName
            // 
            this.cboDeptName.CandidateWidth = 200;
            this.cboDeptName.DroppedDown = false;
            this.cboDeptName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboDeptName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cboDeptName.Location = new System.Drawing.Point(94, 16);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.PinyinFuzzyMatch = true;
            this.cboDeptName.SelectedItem = null;
            this.cboDeptName.Size = new System.Drawing.Size(124, 23);
            this.cboDeptName.TabIndex = 27;
            // 
            // chkDept
            // 
            this.chkDept.AutoSize = true;
            this.chkDept.Checked = true;
            this.chkDept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDept.Location = new System.Drawing.Point(9, 20);
            this.chkDept.Name = "chkDept";
            this.chkDept.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDept.Size = new System.Drawing.Size(54, 18);
            this.chkDept.TabIndex = 26;
            this.chkDept.Text = "科室";
            this.chkDept.UseVisualStyleBackColor = true;
            this.chkDept.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(359, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "之间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(224, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "与";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(83, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "介于";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.BackColor = System.Drawing.Color.Lavender;
            this.txtDiagnosis.Location = new System.Drawing.Point(109, 23);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ReadOnly = true;
            this.txtDiagnosis.Size = new System.Drawing.Size(353, 23);
            this.txtDiagnosis.TabIndex = 31;
            this.txtDiagnosis.DoubleClick += new System.EventHandler(this.txtDiagnosis_DoubleClick);
            // 
            // chkDiagnosis
            // 
            this.chkDiagnosis.AutoSize = true;
            this.chkDiagnosis.Location = new System.Drawing.Point(7, 24);
            this.chkDiagnosis.Name = "chkDiagnosis";
            this.chkDiagnosis.Size = new System.Drawing.Size(96, 18);
            this.chkDiagnosis.TabIndex = 30;
            this.chkDiagnosis.Text = "入院初诊断";
            this.chkDiagnosis.UseVisualStyleBackColor = true;
            this.chkDiagnosis.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // fdCBXOperation
            // 
            this.fdCBXOperation.DroppedDown = false;
            this.fdCBXOperation.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fdCBXOperation.Location = new System.Drawing.Point(94, 28);
            this.fdCBXOperation.Margin = new System.Windows.Forms.Padding(2);
            this.fdCBXOperation.Name = "fdCBXOperation";
            this.fdCBXOperation.PinyinFuzzyMatch = true;
            this.fdCBXOperation.ReadOnly = true;
            this.fdCBXOperation.SelectedItem = null;
            this.fdCBXOperation.Size = new System.Drawing.Size(338, 20);
            this.fdCBXOperation.TabIndex = 37;
            // 
            // chkOperation
            // 
            this.chkOperation.AutoSize = true;
            this.chkOperation.Location = new System.Drawing.Point(8, 28);
            this.chkOperation.Name = "chkOperation";
            this.chkOperation.Size = new System.Drawing.Size(82, 18);
            this.chkOperation.TabIndex = 34;
            this.chkOperation.Text = "手术名称";
            this.chkOperation.UseVisualStyleBackColor = true;
            this.chkOperation.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "请先勾选复合查询条件。手术、检验、诊断只能单独查询";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkMutilOperation);
            this.groupBox2.Controls.Add(this.fdCBXOperation);
            this.groupBox2.Controls.Add(this.chkOperation);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 62);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手术相关";
            // 
            // chkMutilOperation
            // 
            this.chkMutilOperation.AutoSize = true;
            this.chkMutilOperation.Location = new System.Drawing.Point(490, 28);
            this.chkMutilOperation.Name = "chkMutilOperation";
            this.chkMutilOperation.Size = new System.Drawing.Size(82, 18);
            this.chkMutilOperation.TabIndex = 38;
            this.chkMutilOperation.Text = "多次手术";
            this.chkMutilOperation.UseVisualStyleBackColor = true;
            this.chkMutilOperation.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // groupNeed
            // 
            this.groupNeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNeed.Controls.Add(this.label3);
            this.groupNeed.Controls.Add(this.cboPatientStatus);
            this.groupNeed.Controls.Add(this.label13);
            this.groupNeed.Controls.Add(this.label12);
            this.groupNeed.Controls.Add(this.label7);
            this.groupNeed.Controls.Add(this.label11);
            this.groupNeed.Controls.Add(this.label8);
            this.groupNeed.Controls.Add(this.dtpDischargeTimeEnd);
            this.groupNeed.Controls.Add(this.label9);
            this.groupNeed.Controls.Add(this.dtpDischargeTimeBegin);
            this.groupNeed.Controls.Add(this.dtpVisitTimeEnd);
            this.groupNeed.Controls.Add(this.dtpVisitTimeBegin);
            this.groupNeed.Controls.Add(this.chkDischargeTime);
            this.groupNeed.Controls.Add(this.chkVisitTime);
            this.groupNeed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupNeed.Location = new System.Drawing.Point(3, 3);
            this.groupNeed.Name = "groupNeed";
            this.groupNeed.Size = new System.Drawing.Size(754, 109);
            this.groupNeed.TabIndex = 4;
            this.groupNeed.TabStop = false;
            this.groupNeed.Text = "时间区间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 55;
            this.label3.Text = "患者范围";
            // 
            // cboPatientStatus
            // 
            this.cboPatientStatus.FormattingEnabled = true;
            this.cboPatientStatus.Items.AddRange(new object[] {
            "所有患者",
            "在院患者",
            "出院患者"});
            this.cboPatientStatus.Location = new System.Drawing.Point(91, 84);
            this.cboPatientStatus.Name = "cboPatientStatus";
            this.cboPatientStatus.Size = new System.Drawing.Size(149, 22);
            this.cboPatientStatus.TabIndex = 54;
            this.cboPatientStatus.Text = "所有患者";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(400, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 52;
            this.label13.Text = "之间";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(251, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 50;
            this.label12.Text = "与";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(400, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 53;
            this.label7.Text = "之间";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(89, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 48;
            this.label11.Text = "介于";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(251, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 51;
            this.label8.Text = "与";
            // 
            // dtpDischargeTimeEnd
            // 
            this.dtpDischargeTimeEnd.Enabled = false;
            this.dtpDischargeTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpDischargeTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpDischargeTimeEnd.Location = new System.Drawing.Point(274, 54);
            this.dtpDischargeTimeEnd.Name = "dtpDischargeTimeEnd";
            this.dtpDischargeTimeEnd.Size = new System.Drawing.Size(120, 23);
            this.dtpDischargeTimeEnd.TabIndex = 47;
            this.dtpDischargeTimeEnd.Value = new System.DateTime(2015, 4, 20, 23, 59, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(89, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 49;
            this.label9.Text = "介于";
            // 
            // dtpDischargeTimeBegin
            // 
            this.dtpDischargeTimeBegin.Enabled = false;
            this.dtpDischargeTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpDischargeTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpDischargeTimeBegin.Location = new System.Drawing.Point(124, 54);
            this.dtpDischargeTimeBegin.Name = "dtpDischargeTimeBegin";
            this.dtpDischargeTimeBegin.Size = new System.Drawing.Size(120, 23);
            this.dtpDischargeTimeBegin.TabIndex = 44;
            this.dtpDischargeTimeBegin.Value = new System.DateTime(2015, 4, 20, 0, 0, 0, 0);
            // 
            // dtpVisitTimeEnd
            // 
            this.dtpVisitTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpVisitTimeEnd.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpVisitTimeEnd.Location = new System.Drawing.Point(274, 15);
            this.dtpVisitTimeEnd.Name = "dtpVisitTimeEnd";
            this.dtpVisitTimeEnd.Size = new System.Drawing.Size(120, 23);
            this.dtpVisitTimeEnd.TabIndex = 45;
            this.dtpVisitTimeEnd.Value = new System.DateTime(2015, 4, 20, 23, 59, 59, 0);
            // 
            // dtpVisitTimeBegin
            // 
            this.dtpVisitTimeBegin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpVisitTimeBegin.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.dtpVisitTimeBegin.Location = new System.Drawing.Point(124, 15);
            this.dtpVisitTimeBegin.Name = "dtpVisitTimeBegin";
            this.dtpVisitTimeBegin.Size = new System.Drawing.Size(120, 23);
            this.dtpVisitTimeBegin.TabIndex = 46;
            this.dtpVisitTimeBegin.Value = new System.DateTime(2015, 4, 20, 0, 0, 0, 0);
            // 
            // chkDischargeTime
            // 
            this.chkDischargeTime.AutoSize = true;
            this.chkDischargeTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDischargeTime.Location = new System.Drawing.Point(11, 56);
            this.chkDischargeTime.Name = "chkDischargeTime";
            this.chkDischargeTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDischargeTime.Size = new System.Drawing.Size(82, 18);
            this.chkDischargeTime.TabIndex = 42;
            this.chkDischargeTime.Text = "出院时间";
            this.chkDischargeTime.UseVisualStyleBackColor = true;
            this.chkDischargeTime.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkVisitTime
            // 
            this.chkVisitTime.AutoSize = true;
            this.chkVisitTime.Checked = true;
            this.chkVisitTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisitTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkVisitTime.Location = new System.Drawing.Point(12, 21);
            this.chkVisitTime.Name = "chkVisitTime";
            this.chkVisitTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkVisitTime.Size = new System.Drawing.Size(82, 18);
            this.chkVisitTime.TabIndex = 43;
            this.chkVisitTime.Text = "入院时间";
            this.chkVisitTime.UseVisualStyleBackColor = true;
            this.chkVisitTime.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkLabResult);
            this.groupBox3.Controls.Add(this.fcbLabReprotDict);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(3, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(754, 62);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检验相关";
            // 
            // chkLabResult
            // 
            this.chkLabResult.AutoSize = true;
            this.chkLabResult.Location = new System.Drawing.Point(8, 29);
            this.chkLabResult.Name = "chkLabResult";
            this.chkLabResult.Size = new System.Drawing.Size(82, 18);
            this.chkLabResult.TabIndex = 35;
            this.chkLabResult.Text = "检验异常";
            this.chkLabResult.UseVisualStyleBackColor = true;
            this.chkLabResult.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // fcbLabReprotDict
            // 
            this.fcbLabReprotDict.DroppedDown = false;
            this.fcbLabReprotDict.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fcbLabReprotDict.Location = new System.Drawing.Point(94, 27);
            this.fcbLabReprotDict.Margin = new System.Windows.Forms.Padding(2);
            this.fcbLabReprotDict.Name = "fcbLabReprotDict";
            this.fcbLabReprotDict.PinyinFuzzyMatch = true;
            this.fcbLabReprotDict.ReadOnly = true;
            this.fcbLabReprotDict.SelectedItem = null;
            this.fcbLabReprotDict.Size = new System.Drawing.Size(338, 20);
            this.fcbLabReprotDict.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "勾选此项查询可以检索出检验异常的病案";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(671, 480);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 31);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtDiagnosis);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.chkDiagnosis);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(3, 420);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(754, 56);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "诊断相关";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(468, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "双击诊断输入框，可打开诊断字典选择窗口";
            // 
            // ComplexSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 514);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupNeed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Name = "ComplexSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "复合条件查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeginAge)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupNeed.ResumeLayout(false);
            this.groupNeed.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptName;
        private System.Windows.Forms.CheckBox chkDept;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.CheckBox chkDoctor;
        private Heren.Common.Controls.DictInput.FindComboBox cboChargeType;
        private System.Windows.Forms.CheckBox chkBirthTime;
        private System.Windows.Forms.CheckBox chkChargeType;
        private Heren.Common.Controls.DictInput.FindComboBox cboIdentity;
        private System.Windows.Forms.CheckBox chkIdentity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Heren.Common.Controls.DictInput.FindComboBox fdCBXOperation;
        private System.Windows.Forms.CheckBox chkOperation;
        private Heren.Common.Controls.DictInput.FindComboBox cboNursingClass;
        private System.Windows.Forms.CheckBox chkNursingClass;
        private Heren.Common.Controls.DictInput.FindComboBox cboPatientCondition;
        private System.Windows.Forms.CheckBox chkPatientCondition;
        private System.Windows.Forms.NumericUpDown numBeginAge;
        private System.Windows.Forms.NumericUpDown numEndAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupNeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDischargeTimeEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDischargeTimeBegin;
        private System.Windows.Forms.DateTimePicker dtpVisitTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpVisitTimeBegin;
        private System.Windows.Forms.CheckBox chkDischargeTime;
        private System.Windows.Forms.CheckBox chkVisitTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkLabResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPatientStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.CheckBox chkDiagnosis;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkMutilOperation;
        private Heren.Common.Controls.DictInput.FindComboBox fcbLabReprotDict;
    }
}