namespace MedQCSys.Controls
{
    partial class PatSearchPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPatientStatus = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.pnlSearchType = new System.Windows.Forms.Panel();
            this.pnlDeptName = new System.Windows.Forms.Panel();
            this.fdCBXDept = new Heren.Common.Controls.DictInput.FindComboBox();
            this.pnlPatientStatus = new System.Windows.Forms.Panel();
            this.pnlBeginDate = new System.Windows.Forms.Panel();
            this.pnlEndDate = new System.Windows.Forms.Panel();
            this.pnlSearchBtn = new System.Windows.Forms.Panel();
            this.chBoxShowTime = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOperationName = new System.Windows.Forms.Panel();
            this.fdCBXOperation = new Heren.Common.Controls.DictInput.FindComboBox();
            this.lblOperationName = new System.Windows.Forms.Label();
            this.pnlInHosDays = new System.Windows.Forms.Panel();
            this.lblInHosDays = new System.Windows.Forms.Label();
            this.pnlPatient = new System.Windows.Forms.Panel();
            this.lblPatient = new System.Windows.Forms.Label();
            this.pnlCheckedDoc = new System.Windows.Forms.Panel();
            this.fdbCheckName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSpecial = new System.Windows.Forms.Panel();
            this.m_cboSpecialCheckList = new Heren.Common.Controls.DictInput.FindComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDocType = new System.Windows.Forms.Panel();
            this.fdCBXDocType = new Heren.Common.Controls.DictInput.FindComboBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.panSpecialSearch = new System.Windows.Forms.Panel();
            this.rdbSpecialAll = new System.Windows.Forms.RadioButton();
            this.rdbSpecialMine = new System.Windows.Forms.RadioButton();
            this.lable10 = new System.Windows.Forms.Label();
            this.btnComplex = new System.Windows.Forms.Button();
            this.pnlSearchType.SuspendLayout();
            this.pnlDeptName.SuspendLayout();
            this.pnlPatientStatus.SuspendLayout();
            this.pnlBeginDate.SuspendLayout();
            this.pnlEndDate.SuspendLayout();
            this.pnlSearchBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlOperationName.SuspendLayout();
            this.pnlInHosDays.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            this.pnlCheckedDoc.SuspendLayout();
            this.pnlSpecial.SuspendLayout();
            this.pnlDocType.SuspendLayout();
            this.panSpecialSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBeginDate.Location = new System.Drawing.Point(2, 6);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(63, 14);
            this.lblBeginDate.TabIndex = 10;
            this.lblBeginDate.Text = "起始日期";
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSearchType.Location = new System.Drawing.Point(2, 6);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(63, 14);
            this.lblSearchType.TabIndex = 8;
            this.lblSearchType.Text = "检索方式";
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeptName.Location = new System.Drawing.Point(2, 6);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(63, 14);
            this.lblDeptName.TabIndex = 9;
            this.lblDeptName.Text = "科室名称";
            // 
            // cboSearchType
            // 
            this.cboSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "科室名称",
            "入院日期",
            "出院日期",
            "危重病历",
            "死亡病历",
            "患者ID号",
            "患者姓名",
            "病案号",
            "手术患者",
            "住院天数",
            "已质检病历",
            "病历类型",
            "重复入院",
            "转科患者",
            "待复审"});
            this.cboSearchType.Location = new System.Drawing.Point(69, 4);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(260, 22);
            this.cboSearchType.TabIndex = 7;
            this.cboSearchType.SelectedIndexChanged += new System.EventHandler(this.cboSearchType_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.AutoSize = true;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(266, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 28);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblPatientStatus
            // 
            this.lblPatientStatus.AutoSize = true;
            this.lblPatientStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientStatus.Location = new System.Drawing.Point(2, 6);
            this.lblPatientStatus.Name = "lblPatientStatus";
            this.lblPatientStatus.Size = new System.Drawing.Size(63, 14);
            this.lblPatientStatus.TabIndex = 25;
            this.lblPatientStatus.Text = "患者范围";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime.Location = new System.Drawing.Point(2, 6);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(63, 14);
            this.lblEndTime.TabIndex = 26;
            this.lblEndTime.Text = "截止日期";
            // 
            // pnlSearchType
            // 
            this.pnlSearchType.Controls.Add(this.cboSearchType);
            this.pnlSearchType.Controls.Add(this.lblSearchType);
            this.pnlSearchType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchType.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.pnlSearchType.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchType.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearchType.Name = "pnlSearchType";
            this.pnlSearchType.Size = new System.Drawing.Size(331, 27);
            this.pnlSearchType.TabIndex = 27;
            // 
            // pnlDeptName
            // 
            this.pnlDeptName.Controls.Add(this.fdCBXDept);
            this.pnlDeptName.Controls.Add(this.lblDeptName);
            this.pnlDeptName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDeptName.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.pnlDeptName.Location = new System.Drawing.Point(0, 81);
            this.pnlDeptName.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDeptName.Name = "pnlDeptName";
            this.pnlDeptName.Size = new System.Drawing.Size(331, 27);
            this.pnlDeptName.TabIndex = 28;
            // 
            // fdCBXDept
            // 
            this.fdCBXDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fdCBXDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fdCBXDept.Location = new System.Drawing.Point(69, 3);
            this.fdCBXDept.Margin = new System.Windows.Forms.Padding(2);
            this.fdCBXDept.Name = "fdCBXDept";
            this.fdCBXDept.PinyinFuzzyMatch = true;
            this.fdCBXDept.Size = new System.Drawing.Size(259, 22);
            this.fdCBXDept.TabIndex = 10;
            this.fdCBXDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fdCBXDept_KeyDown);
            // 
            // pnlPatientStatus
            // 
            this.pnlPatientStatus.Controls.Add(this.lblPatientStatus);
            this.pnlPatientStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatientStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlPatientStatus.Location = new System.Drawing.Point(0, 108);
            this.pnlPatientStatus.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPatientStatus.Name = "pnlPatientStatus";
            this.pnlPatientStatus.Size = new System.Drawing.Size(331, 27);
            this.pnlPatientStatus.TabIndex = 29;
            // 
            // pnlBeginDate
            // 
            this.pnlBeginDate.Controls.Add(this.lblBeginDate);
            this.pnlBeginDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBeginDate.Location = new System.Drawing.Point(0, 135);
            this.pnlBeginDate.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBeginDate.Name = "pnlBeginDate";
            this.pnlBeginDate.Size = new System.Drawing.Size(331, 27);
            this.pnlBeginDate.TabIndex = 30;
            // 
            // pnlEndDate
            // 
            this.pnlEndDate.Controls.Add(this.lblEndTime);
            this.pnlEndDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEndDate.Location = new System.Drawing.Point(0, 162);
            this.pnlEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEndDate.Name = "pnlEndDate";
            this.pnlEndDate.Size = new System.Drawing.Size(331, 27);
            this.pnlEndDate.TabIndex = 31;
            // 
            // pnlSearchBtn
            // 
            this.pnlSearchBtn.Controls.Add(this.btnComplex);
            this.pnlSearchBtn.Controls.Add(this.chBoxShowTime);
            this.pnlSearchBtn.Controls.Add(this.pictureBox1);
            this.pnlSearchBtn.Controls.Add(this.btnSearch);
            this.pnlSearchBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSearchBtn.Location = new System.Drawing.Point(0, 394);
            this.pnlSearchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearchBtn.Name = "pnlSearchBtn";
            this.pnlSearchBtn.Size = new System.Drawing.Size(331, 34);
            this.pnlSearchBtn.TabIndex = 32;
            // 
            // chBoxShowTime
            // 
            this.chBoxShowTime.AutoSize = true;
            this.chBoxShowTime.Location = new System.Drawing.Point(34, 12);
            this.chBoxShowTime.Name = "chBoxShowTime";
            this.chBoxShowTime.Size = new System.Drawing.Size(48, 16);
            this.chBoxShowTime.TabIndex = 26;
            this.chBoxShowTime.Text = "日期";
            this.chBoxShowTime.UseVisualStyleBackColor = true;
            this.chBoxShowTime.CheckedChanged += new System.EventHandler(this.chBoxShowTime_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedQCSys.Properties.Resources.question2;
            this.pictureBox1.Location = new System.Drawing.Point(5, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 20);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "hello");
            // 
            // pnlOperationName
            // 
            this.pnlOperationName.Controls.Add(this.fdCBXOperation);
            this.pnlOperationName.Controls.Add(this.lblOperationName);
            this.pnlOperationName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperationName.Location = new System.Drawing.Point(0, 189);
            this.pnlOperationName.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOperationName.Name = "pnlOperationName";
            this.pnlOperationName.Size = new System.Drawing.Size(331, 27);
            this.pnlOperationName.TabIndex = 33;
            // 
            // fdCBXOperation
            // 
            this.fdCBXOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fdCBXOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fdCBXOperation.Location = new System.Drawing.Point(69, 3);
            this.fdCBXOperation.Margin = new System.Windows.Forms.Padding(2);
            this.fdCBXOperation.Name = "fdCBXOperation";
            this.fdCBXOperation.Size = new System.Drawing.Size(259, 22);
            this.fdCBXOperation.TabIndex = 28;
            this.fdCBXOperation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fdCBXOperation_KeyDown);
            // 
            // lblOperationName
            // 
            this.lblOperationName.AutoSize = true;
            this.lblOperationName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationName.Location = new System.Drawing.Point(2, 6);
            this.lblOperationName.Name = "lblOperationName";
            this.lblOperationName.Size = new System.Drawing.Size(63, 14);
            this.lblOperationName.TabIndex = 27;
            this.lblOperationName.Text = "手术名称";
            // 
            // pnlInHosDays
            // 
            this.pnlInHosDays.Controls.Add(this.lblInHosDays);
            this.pnlInHosDays.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInHosDays.Location = new System.Drawing.Point(0, 216);
            this.pnlInHosDays.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInHosDays.Name = "pnlInHosDays";
            this.pnlInHosDays.Size = new System.Drawing.Size(331, 27);
            this.pnlInHosDays.TabIndex = 34;
            // 
            // lblInHosDays
            // 
            this.lblInHosDays.AutoSize = true;
            this.lblInHosDays.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHosDays.Location = new System.Drawing.Point(2, 6);
            this.lblInHosDays.Name = "lblInHosDays";
            this.lblInHosDays.Size = new System.Drawing.Size(63, 14);
            this.lblInHosDays.TabIndex = 28;
            this.lblInHosDays.Text = "住院天数";
            // 
            // pnlPatient
            // 
            this.pnlPatient.Controls.Add(this.lblPatient);
            this.pnlPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatient.Location = new System.Drawing.Point(0, 243);
            this.pnlPatient.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Size = new System.Drawing.Size(331, 27);
            this.pnlPatient.TabIndex = 35;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatient.Location = new System.Drawing.Point(2, 6);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(63, 14);
            this.lblPatient.TabIndex = 29;
            this.lblPatient.Text = "病 人 ID";
            // 
            // pnlCheckedDoc
            // 
            this.pnlCheckedDoc.Controls.Add(this.fdbCheckName);
            this.pnlCheckedDoc.Controls.Add(this.label1);
            this.pnlCheckedDoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckedDoc.Location = new System.Drawing.Point(0, 270);
            this.pnlCheckedDoc.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCheckedDoc.Name = "pnlCheckedDoc";
            this.pnlCheckedDoc.Size = new System.Drawing.Size(331, 27);
            this.pnlCheckedDoc.TabIndex = 36;
            // 
            // fdbCheckName
            // 
            this.fdbCheckName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fdbCheckName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fdbCheckName.Location = new System.Drawing.Point(70, 2);
            this.fdbCheckName.Margin = new System.Windows.Forms.Padding(2);
            this.fdbCheckName.Name = "fdbCheckName";
            this.fdbCheckName.Size = new System.Drawing.Size(259, 22);
            this.fdbCheckName.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 29;
            this.label1.Text = "质检人";
            // 
            // pnlSpecial
            // 
            this.pnlSpecial.Controls.Add(this.m_cboSpecialCheckList);
            this.pnlSpecial.Controls.Add(this.label2);
            this.pnlSpecial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpecial.Location = new System.Drawing.Point(0, 27);
            this.pnlSpecial.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSpecial.Name = "pnlSpecial";
            this.pnlSpecial.Size = new System.Drawing.Size(331, 27);
            this.pnlSpecial.TabIndex = 37;
            // 
            // m_cboSpecialCheckList
            // 
            this.m_cboSpecialCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cboSpecialCheckList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSpecialCheckList.Location = new System.Drawing.Point(70, 2);
            this.m_cboSpecialCheckList.Margin = new System.Windows.Forms.Padding(2);
            this.m_cboSpecialCheckList.Name = "m_cboSpecialCheckList";
            this.m_cboSpecialCheckList.Size = new System.Drawing.Size(259, 22);
            this.m_cboSpecialCheckList.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "分配批次";
            // 
            // pnlDocType
            // 
            this.pnlDocType.Controls.Add(this.fdCBXDocType);
            this.pnlDocType.Controls.Add(this.lblDocType);
            this.pnlDocType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDocType.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.pnlDocType.Location = new System.Drawing.Point(0, 54);
            this.pnlDocType.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDocType.Name = "pnlDocType";
            this.pnlDocType.Size = new System.Drawing.Size(331, 27);
            this.pnlDocType.TabIndex = 29;
            // 
            // fdCBXDocType
            // 
            this.fdCBXDocType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fdCBXDocType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fdCBXDocType.Location = new System.Drawing.Point(69, 3);
            this.fdCBXDocType.Margin = new System.Windows.Forms.Padding(2);
            this.fdCBXDocType.Name = "fdCBXDocType";
            this.fdCBXDocType.Size = new System.Drawing.Size(259, 22);
            this.fdCBXDocType.TabIndex = 10;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDocType.Location = new System.Drawing.Point(2, 6);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(63, 14);
            this.lblDocType.TabIndex = 9;
            this.lblDocType.Text = "文书类型";
            // 
            // panSpecialSearch
            // 
            this.panSpecialSearch.Controls.Add(this.rdbSpecialAll);
            this.panSpecialSearch.Controls.Add(this.rdbSpecialMine);
            this.panSpecialSearch.Controls.Add(this.lable10);
            this.panSpecialSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSpecialSearch.Location = new System.Drawing.Point(0, 297);
            this.panSpecialSearch.Margin = new System.Windows.Forms.Padding(2);
            this.panSpecialSearch.Name = "panSpecialSearch";
            this.panSpecialSearch.Size = new System.Drawing.Size(331, 27);
            this.panSpecialSearch.TabIndex = 39;
            // 
            // rdbSpecialAll
            // 
            this.rdbSpecialAll.AutoSize = true;
            this.rdbSpecialAll.Location = new System.Drawing.Point(122, 6);
            this.rdbSpecialAll.Name = "rdbSpecialAll";
            this.rdbSpecialAll.Size = new System.Drawing.Size(47, 16);
            this.rdbSpecialAll.TabIndex = 31;
            this.rdbSpecialAll.Text = "全部";
            this.rdbSpecialAll.UseVisualStyleBackColor = true;
            this.rdbSpecialAll.CheckedChanged += new System.EventHandler(this.rdbSpecialAll_CheckedChanged);
            // 
            // rdbSpecialMine
            // 
            this.rdbSpecialMine.AutoSize = true;
            this.rdbSpecialMine.Checked = true;
            this.rdbSpecialMine.Location = new System.Drawing.Point(69, 6);
            this.rdbSpecialMine.Name = "rdbSpecialMine";
            this.rdbSpecialMine.Size = new System.Drawing.Size(47, 16);
            this.rdbSpecialMine.TabIndex = 30;
            this.rdbSpecialMine.TabStop = true;
            this.rdbSpecialMine.Text = "本人";
            this.rdbSpecialMine.UseVisualStyleBackColor = true;
            this.rdbSpecialMine.CheckedChanged += new System.EventHandler(this.rdbSpecialMine_CheckedChanged);
            // 
            // lable10
            // 
            this.lable10.AutoSize = true;
            this.lable10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable10.Location = new System.Drawing.Point(2, 6);
            this.lable10.Name = "lable10";
            this.lable10.Size = new System.Drawing.Size(63, 14);
            this.lable10.TabIndex = 29;
            this.lable10.Text = "分配筛选";
            // 
            // btnComplex
            // 
            this.btnComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplex.AutoSize = true;
            this.btnComplex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnComplex.Location = new System.Drawing.Point(169, 4);
            this.btnComplex.Margin = new System.Windows.Forms.Padding(1);
            this.btnComplex.Name = "btnComplex";
            this.btnComplex.Size = new System.Drawing.Size(93, 28);
            this.btnComplex.TabIndex = 27;
            this.btnComplex.Text = "复合查询";
            this.btnComplex.UseVisualStyleBackColor = true;
            this.btnComplex.Visible = false;
            this.btnComplex.Click += new System.EventHandler(this.btnComplex_Click);
            // 
            // PatSearchPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panSpecialSearch);
            this.Controls.Add(this.pnlCheckedDoc);
            this.Controls.Add(this.pnlSearchBtn);
            this.Controls.Add(this.pnlPatient);
            this.Controls.Add(this.pnlInHosDays);
            this.Controls.Add(this.pnlOperationName);
            this.Controls.Add(this.pnlEndDate);
            this.Controls.Add(this.pnlBeginDate);
            this.Controls.Add(this.pnlPatientStatus);
            this.Controls.Add(this.pnlDeptName);
            this.Controls.Add(this.pnlDocType);
            this.Controls.Add(this.pnlSpecial);
            this.Controls.Add(this.pnlSearchType);
            this.Name = "PatSearchPane";
            this.Size = new System.Drawing.Size(331, 428);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PatSearchPane_KeyDown);
            this.pnlSearchType.ResumeLayout(false);
            this.pnlSearchType.PerformLayout();
            this.pnlDeptName.ResumeLayout(false);
            this.pnlDeptName.PerformLayout();
            this.pnlPatientStatus.ResumeLayout(false);
            this.pnlPatientStatus.PerformLayout();
            this.pnlBeginDate.ResumeLayout(false);
            this.pnlBeginDate.PerformLayout();
            this.pnlEndDate.ResumeLayout(false);
            this.pnlEndDate.PerformLayout();
            this.pnlSearchBtn.ResumeLayout(false);
            this.pnlSearchBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlOperationName.ResumeLayout(false);
            this.pnlOperationName.PerformLayout();
            this.pnlInHosDays.ResumeLayout(false);
            this.pnlInHosDays.PerformLayout();
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            this.pnlCheckedDoc.ResumeLayout(false);
            this.pnlCheckedDoc.PerformLayout();
            this.pnlSpecial.ResumeLayout(false);
            this.pnlSpecial.PerformLayout();
            this.pnlDocType.ResumeLayout(false);
            this.pnlDocType.PerformLayout();
            this.panSpecialSearch.ResumeLayout(false);
            this.panSpecialSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPatientStatus;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Panel pnlSearchType;
        private System.Windows.Forms.Panel pnlDeptName;
        private System.Windows.Forms.Panel pnlPatientStatus;
        private System.Windows.Forms.Panel pnlBeginDate;
        private System.Windows.Forms.Panel pnlEndDate;
        private System.Windows.Forms.Panel pnlSearchBtn;
        public System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Panel pnlOperationName;
        private System.Windows.Forms.Label lblOperationName;
        private System.Windows.Forms.Panel pnlInHosDays;
        private System.Windows.Forms.Label lblInHosDays;
        private System.Windows.Forms.Panel pnlPatient;
        private System.Windows.Forms.Label lblPatient;
        private Heren.Common.Controls.DictInput.FindComboBox fdCBXDept;
        private Heren.Common.Controls.DictInput.FindComboBox fdCBXOperation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlCheckedDoc;
        private System.Windows.Forms.Label label1;
        private Heren.Common.Controls.DictInput.FindComboBox fdbCheckName;
        private System.Windows.Forms.Panel pnlSpecial;
        private Heren.Common.Controls.DictInput.FindComboBox m_cboSpecialCheckList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chBoxShowTime;
        private System.Windows.Forms.Panel pnlDocType;
        private Heren.Common.Controls.DictInput.FindComboBox fdCBXDocType;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Panel panSpecialSearch;
        private System.Windows.Forms.RadioButton rdbSpecialAll;
        private System.Windows.Forms.RadioButton rdbSpecialMine;
        private System.Windows.Forms.Label lable10;
        private System.Windows.Forms.Button btnComplex;
    }
}
