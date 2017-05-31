namespace MedQCSys.DockForms
{
    partial class OperationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.colOperationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperationScale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xGroupBox2 = new Heren.Common.Forms.XGroupBox();
            this.cbo_FOUR_ASSISTANT = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_THREE_ASSISTANT = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_ANAESTHESIA_METHOD = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_SECOND_ASSISTANT = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_SECOND_SUPPLY_NURSE = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_FIRST_SUPPLY_NURSE = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_SECOND_OPERATION_NURSE = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_FIRST_OPERATION_NURSE = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_FIRST_ANESTHESIA = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_ANESTHESIA_DOCTOR = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_BLOOD_DOCTOR = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cbo_FIRST_ASSISTANT = new Heren.Common.Controls.DictInput.FindComboBox();
            this.cboOPERATING_ROOM = new Heren.Common.Controls.DictInput.FindComboBox();
            this.dt_REQ_DATE_TIME = new Heren.Common.Controls.TimeControl.DateTimeControl();
            this.dtEND_DATE_TIME = new Heren.Common.Controls.TimeControl.DateTimeControl();
            this.dtSTART_DATE_TIME = new Heren.Common.Controls.TimeControl.DateTimeControl();
            this.txt_OPERATOR_DOCTOR = new System.Windows.Forms.TextBox();
            this.txt_OPERATING_DEPT = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_OPERATING_SCALE = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ISOLATION_FLAG = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOPERATION_SEQUENCE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOPERATION_ROOM_NO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_NOTES_ON_OPERATION = new System.Windows.Forms.TextBox();
            this.txtPATIENT_CONDITION = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDIAG_BEFORE_OPERATION = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.xGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTableView1
            // 
            this.dataTableView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOperationName,
            this.colOperationScale});
            this.dataTableView1.Location = new System.Drawing.Point(12, 12);
            this.dataTableView1.MultiSelect = false;
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(607, 116);
            this.dataTableView1.TabIndex = 0;
            this.dataTableView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableView1_CellClick);
            // 
            // colOperationName
            // 
            this.colOperationName.FillWeight = 159.3909F;
            this.colOperationName.HeaderText = "手术名称";
            this.colOperationName.Name = "colOperationName";
            this.colOperationName.ReadOnly = true;
            // 
            // colOperationScale
            // 
            this.colOperationScale.FillWeight = 40.60914F;
            this.colOperationScale.HeaderText = "等级";
            this.colOperationScale.MinimumWidth = 40;
            this.colOperationScale.Name = "colOperationScale";
            this.colOperationScale.ReadOnly = true;
            // 
            // xGroupBox2
            // 
            this.xGroupBox2.Controls.Add(this.cbo_FOUR_ASSISTANT);
            this.xGroupBox2.Controls.Add(this.cbo_THREE_ASSISTANT);
            this.xGroupBox2.Controls.Add(this.cbo_ANAESTHESIA_METHOD);
            this.xGroupBox2.Controls.Add(this.cbo_SECOND_ASSISTANT);
            this.xGroupBox2.Controls.Add(this.cbo_SECOND_SUPPLY_NURSE);
            this.xGroupBox2.Controls.Add(this.cbo_FIRST_SUPPLY_NURSE);
            this.xGroupBox2.Controls.Add(this.cbo_SECOND_OPERATION_NURSE);
            this.xGroupBox2.Controls.Add(this.cbo_FIRST_OPERATION_NURSE);
            this.xGroupBox2.Controls.Add(this.cbo_FIRST_ANESTHESIA);
            this.xGroupBox2.Controls.Add(this.cbo_ANESTHESIA_DOCTOR);
            this.xGroupBox2.Controls.Add(this.cbo_BLOOD_DOCTOR);
            this.xGroupBox2.Controls.Add(this.cbo_FIRST_ASSISTANT);
            this.xGroupBox2.Controls.Add(this.cboOPERATING_ROOM);
            this.xGroupBox2.Controls.Add(this.dt_REQ_DATE_TIME);
            this.xGroupBox2.Controls.Add(this.dtEND_DATE_TIME);
            this.xGroupBox2.Controls.Add(this.dtSTART_DATE_TIME);
            this.xGroupBox2.Controls.Add(this.txt_OPERATOR_DOCTOR);
            this.xGroupBox2.Controls.Add(this.txt_OPERATING_DEPT);
            this.xGroupBox2.Controls.Add(this.label13);
            this.xGroupBox2.Controls.Add(this.label16);
            this.xGroupBox2.Controls.Add(this.label10);
            this.xGroupBox2.Controls.Add(this.label15);
            this.xGroupBox2.Controls.Add(this.txt_OPERATING_SCALE);
            this.xGroupBox2.Controls.Add(this.label14);
            this.xGroupBox2.Controls.Add(this.label12);
            this.xGroupBox2.Controls.Add(this.label11);
            this.xGroupBox2.Controls.Add(this.label9);
            this.xGroupBox2.Controls.Add(this.txt_ISOLATION_FLAG);
            this.xGroupBox2.Controls.Add(this.label8);
            this.xGroupBox2.Controls.Add(this.txtOPERATION_SEQUENCE);
            this.xGroupBox2.Controls.Add(this.label7);
            this.xGroupBox2.Controls.Add(this.txtOPERATION_ROOM_NO);
            this.xGroupBox2.Controls.Add(this.label6);
            this.xGroupBox2.Controls.Add(this.txt_NOTES_ON_OPERATION);
            this.xGroupBox2.Controls.Add(this.txtPATIENT_CONDITION);
            this.xGroupBox2.Controls.Add(this.label5);
            this.xGroupBox2.Controls.Add(this.label17);
            this.xGroupBox2.Controls.Add(this.label4);
            this.xGroupBox2.Controls.Add(this.label19);
            this.xGroupBox2.Controls.Add(this.label18);
            this.xGroupBox2.Controls.Add(this.label3);
            this.xGroupBox2.Controls.Add(this.label2);
            this.xGroupBox2.Controls.Add(this.txtDIAG_BEFORE_OPERATION);
            this.xGroupBox2.Controls.Add(this.label1);
            this.xGroupBox2.Location = new System.Drawing.Point(12, 134);
            this.xGroupBox2.Name = "xGroupBox2";
            this.xGroupBox2.Size = new System.Drawing.Size(607, 369);
            this.xGroupBox2.TabIndex = 0;
            this.xGroupBox2.TabStop = false;
            this.xGroupBox2.Text = "手术信息";
            // 
            // cbo_FOUR_ASSISTANT
            // 
            this.cbo_FOUR_ASSISTANT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_FOUR_ASSISTANT.Location = new System.Drawing.Point(474, 175);
            this.cbo_FOUR_ASSISTANT.Name = "cbo_FOUR_ASSISTANT";
            this.cbo_FOUR_ASSISTANT.Size = new System.Drawing.Size(117, 22);
            this.cbo_FOUR_ASSISTANT.TabIndex = 21;
            // 
            // cbo_THREE_ASSISTANT
            // 
            this.cbo_THREE_ASSISTANT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_THREE_ASSISTANT.Location = new System.Drawing.Point(348, 175);
            this.cbo_THREE_ASSISTANT.Name = "cbo_THREE_ASSISTANT";
            this.cbo_THREE_ASSISTANT.Size = new System.Drawing.Size(120, 22);
            this.cbo_THREE_ASSISTANT.TabIndex = 21;
            // 
            // cbo_ANAESTHESIA_METHOD
            // 
            this.cbo_ANAESTHESIA_METHOD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_ANAESTHESIA_METHOD.Location = new System.Drawing.Point(290, 203);
            this.cbo_ANAESTHESIA_METHOD.Name = "cbo_ANAESTHESIA_METHOD";
            this.cbo_ANAESTHESIA_METHOD.Size = new System.Drawing.Size(301, 22);
            this.cbo_ANAESTHESIA_METHOD.TabIndex = 21;
            // 
            // cbo_SECOND_ASSISTANT
            // 
            this.cbo_SECOND_ASSISTANT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_SECOND_ASSISTANT.Location = new System.Drawing.Point(221, 175);
            this.cbo_SECOND_ASSISTANT.Name = "cbo_SECOND_ASSISTANT";
            this.cbo_SECOND_ASSISTANT.Size = new System.Drawing.Size(122, 22);
            this.cbo_SECOND_ASSISTANT.TabIndex = 21;
            // 
            // cbo_SECOND_SUPPLY_NURSE
            // 
            this.cbo_SECOND_SUPPLY_NURSE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_SECOND_SUPPLY_NURSE.Location = new System.Drawing.Point(190, 259);
            this.cbo_SECOND_SUPPLY_NURSE.Name = "cbo_SECOND_SUPPLY_NURSE";
            this.cbo_SECOND_SUPPLY_NURSE.Size = new System.Drawing.Size(98, 22);
            this.cbo_SECOND_SUPPLY_NURSE.TabIndex = 21;
            // 
            // cbo_FIRST_SUPPLY_NURSE
            // 
            this.cbo_FIRST_SUPPLY_NURSE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_FIRST_SUPPLY_NURSE.Location = new System.Drawing.Point(87, 259);
            this.cbo_FIRST_SUPPLY_NURSE.Name = "cbo_FIRST_SUPPLY_NURSE";
            this.cbo_FIRST_SUPPLY_NURSE.Size = new System.Drawing.Size(100, 22);
            this.cbo_FIRST_SUPPLY_NURSE.TabIndex = 21;
            // 
            // cbo_SECOND_OPERATION_NURSE
            // 
            this.cbo_SECOND_OPERATION_NURSE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_SECOND_OPERATION_NURSE.Location = new System.Drawing.Point(493, 231);
            this.cbo_SECOND_OPERATION_NURSE.Name = "cbo_SECOND_OPERATION_NURSE";
            this.cbo_SECOND_OPERATION_NURSE.Size = new System.Drawing.Size(98, 22);
            this.cbo_SECOND_OPERATION_NURSE.TabIndex = 21;
            // 
            // cbo_FIRST_OPERATION_NURSE
            // 
            this.cbo_FIRST_OPERATION_NURSE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_FIRST_OPERATION_NURSE.Location = new System.Drawing.Point(390, 231);
            this.cbo_FIRST_OPERATION_NURSE.Name = "cbo_FIRST_OPERATION_NURSE";
            this.cbo_FIRST_OPERATION_NURSE.Size = new System.Drawing.Size(100, 22);
            this.cbo_FIRST_OPERATION_NURSE.TabIndex = 21;
            // 
            // cbo_FIRST_ANESTHESIA
            // 
            this.cbo_FIRST_ANESTHESIA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_FIRST_ANESTHESIA.Location = new System.Drawing.Point(190, 231);
            this.cbo_FIRST_ANESTHESIA.Name = "cbo_FIRST_ANESTHESIA";
            this.cbo_FIRST_ANESTHESIA.Size = new System.Drawing.Size(98, 22);
            this.cbo_FIRST_ANESTHESIA.TabIndex = 21;
            // 
            // cbo_ANESTHESIA_DOCTOR
            // 
            this.cbo_ANESTHESIA_DOCTOR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_ANESTHESIA_DOCTOR.Location = new System.Drawing.Point(87, 231);
            this.cbo_ANESTHESIA_DOCTOR.Name = "cbo_ANESTHESIA_DOCTOR";
            this.cbo_ANESTHESIA_DOCTOR.Size = new System.Drawing.Size(100, 22);
            this.cbo_ANESTHESIA_DOCTOR.TabIndex = 21;
            // 
            // cbo_BLOOD_DOCTOR
            // 
            this.cbo_BLOOD_DOCTOR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_BLOOD_DOCTOR.Location = new System.Drawing.Point(87, 203);
            this.cbo_BLOOD_DOCTOR.Name = "cbo_BLOOD_DOCTOR";
            this.cbo_BLOOD_DOCTOR.Size = new System.Drawing.Size(128, 22);
            this.cbo_BLOOD_DOCTOR.TabIndex = 21;
            // 
            // cbo_FIRST_ASSISTANT
            // 
            this.cbo_FIRST_ASSISTANT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_FIRST_ASSISTANT.Location = new System.Drawing.Point(87, 175);
            this.cbo_FIRST_ASSISTANT.Name = "cbo_FIRST_ASSISTANT";
            this.cbo_FIRST_ASSISTANT.Size = new System.Drawing.Size(128, 22);
            this.cbo_FIRST_ASSISTANT.TabIndex = 21;
            // 
            // cboOPERATING_ROOM
            // 
            this.cboOPERATING_ROOM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboOPERATING_ROOM.Location = new System.Drawing.Point(488, 79);
            this.cboOPERATING_ROOM.Name = "cboOPERATING_ROOM";
            this.cboOPERATING_ROOM.ReadOnly = true;
            this.cboOPERATING_ROOM.Size = new System.Drawing.Size(104, 22);
            this.cboOPERATING_ROOM.TabIndex = 21;
            // 
            // dt_REQ_DATE_TIME
            // 
            this.dt_REQ_DATE_TIME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_REQ_DATE_TIME.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dt_REQ_DATE_TIME.Location = new System.Drawing.Point(390, 259);
            this.dt_REQ_DATE_TIME.Name = "dt_REQ_DATE_TIME";
            this.dt_REQ_DATE_TIME.ShowSecond = false;
            this.dt_REQ_DATE_TIME.Size = new System.Drawing.Size(146, 24);
            this.dt_REQ_DATE_TIME.TabIndex = 2;
            // 
            // dtEND_DATE_TIME
            // 
            this.dtEND_DATE_TIME.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtEND_DATE_TIME.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtEND_DATE_TIME.Location = new System.Drawing.Point(290, 79);
            this.dtEND_DATE_TIME.Name = "dtEND_DATE_TIME";
            this.dtEND_DATE_TIME.ShowSecond = false;
            this.dtEND_DATE_TIME.Size = new System.Drawing.Size(123, 24);
            this.dtEND_DATE_TIME.TabIndex = 2;
            // 
            // dtSTART_DATE_TIME
            // 
            this.dtSTART_DATE_TIME.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtSTART_DATE_TIME.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtSTART_DATE_TIME.Location = new System.Drawing.Point(87, 79);
            this.dtSTART_DATE_TIME.Name = "dtSTART_DATE_TIME";
            this.dtSTART_DATE_TIME.ShowSecond = false;
            this.dtSTART_DATE_TIME.Size = new System.Drawing.Size(128, 24);
            this.dtSTART_DATE_TIME.TabIndex = 2;
            // 
            // txt_OPERATOR_DOCTOR
            // 
            this.txt_OPERATOR_DOCTOR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OPERATOR_DOCTOR.Location = new System.Drawing.Point(488, 144);
            this.txt_OPERATOR_DOCTOR.Name = "txt_OPERATOR_DOCTOR";
            this.txt_OPERATOR_DOCTOR.Size = new System.Drawing.Size(104, 23);
            this.txt_OPERATOR_DOCTOR.TabIndex = 1;
            // 
            // txt_OPERATING_DEPT
            // 
            this.txt_OPERATING_DEPT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OPERATING_DEPT.Location = new System.Drawing.Point(291, 145);
            this.txt_OPERATING_DEPT.Name = "txt_OPERATING_DEPT";
            this.txt_OPERATING_DEPT.Size = new System.Drawing.Size(122, 23);
            this.txt_OPERATING_DEPT.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(218, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "麻醉方法：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(16, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 14);
            this.label16.TabIndex = 0;
            this.label16.Text = "供应护士：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(419, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "手术医师：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(319, 235);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 14);
            this.label15.TabIndex = 0;
            this.label15.Text = "台上护士：";
            // 
            // txt_OPERATING_SCALE
            // 
            this.txt_OPERATING_SCALE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OPERATING_SCALE.Location = new System.Drawing.Point(87, 144);
            this.txt_OPERATING_SCALE.Name = "txt_OPERATING_SCALE";
            this.txt_OPERATING_SCALE.Size = new System.Drawing.Size(128, 23);
            this.txt_OPERATING_SCALE.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(16, 235);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "麻醉医师：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(16, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "输血医师：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(16, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "助    手：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(220, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "手术科室：";
            // 
            // txt_ISOLATION_FLAG
            // 
            this.txt_ISOLATION_FLAG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ISOLATION_FLAG.Location = new System.Drawing.Point(488, 110);
            this.txt_ISOLATION_FLAG.Name = "txt_ISOLATION_FLAG";
            this.txt_ISOLATION_FLAG.Size = new System.Drawing.Size(104, 23);
            this.txt_ISOLATION_FLAG.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(15, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "手术等级：";
            // 
            // txtOPERATION_SEQUENCE
            // 
            this.txtOPERATION_SEQUENCE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOPERATION_SEQUENCE.Location = new System.Drawing.Point(291, 111);
            this.txtOPERATION_SEQUENCE.Name = "txtOPERATION_SEQUENCE";
            this.txtOPERATION_SEQUENCE.Size = new System.Drawing.Size(122, 23);
            this.txtOPERATION_SEQUENCE.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(418, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "隔离标志：";
            // 
            // txtOPERATION_ROOM_NO
            // 
            this.txtOPERATION_ROOM_NO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOPERATION_ROOM_NO.Location = new System.Drawing.Point(87, 111);
            this.txtOPERATION_ROOM_NO.Name = "txtOPERATION_ROOM_NO";
            this.txtOPERATION_ROOM_NO.Size = new System.Drawing.Size(128, 23);
            this.txtOPERATION_ROOM_NO.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(219, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "台    次：";
            // 
            // txt_NOTES_ON_OPERATION
            // 
            this.txt_NOTES_ON_OPERATION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NOTES_ON_OPERATION.Location = new System.Drawing.Point(86, 289);
            this.txt_NOTES_ON_OPERATION.Multiline = true;
            this.txt_NOTES_ON_OPERATION.Name = "txt_NOTES_ON_OPERATION";
            this.txt_NOTES_ON_OPERATION.Size = new System.Drawing.Size(505, 57);
            this.txt_NOTES_ON_OPERATION.TabIndex = 1;
            // 
            // txtPATIENT_CONDITION
            // 
            this.txtPATIENT_CONDITION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPATIENT_CONDITION.Location = new System.Drawing.Point(87, 48);
            this.txtPATIENT_CONDITION.Name = "txtPATIENT_CONDITION";
            this.txtPATIENT_CONDITION.Size = new System.Drawing.Size(505, 23);
            this.txtPATIENT_CONDITION.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(30, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "手术间：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(319, 262);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 0;
            this.label17.Text = "申请时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(432, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "手术室：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(219, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 14);
            this.label19.TabIndex = 0;
            this.label19.Text = "结束时间：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(15, 292);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 14);
            this.label18.TabIndex = 0;
            this.label18.Text = "备    注：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "手术时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "病    情：";
            // 
            // txtDIAG_BEFORE_OPERATION
            // 
            this.txtDIAG_BEFORE_OPERATION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDIAG_BEFORE_OPERATION.Location = new System.Drawing.Point(87, 17);
            this.txtDIAG_BEFORE_OPERATION.Name = "txtDIAG_BEFORE_OPERATION";
            this.txtDIAG_BEFORE_OPERATION.Size = new System.Drawing.Size(505, 23);
            this.txtDIAG_BEFORE_OPERATION.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "术前诊断：";
            // 
            // OperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 518);
            this.Controls.Add(this.dataTableView1);
            this.Controls.Add(this.xGroupBox2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "OperationForm";
            this.Text = "手术信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.xGroupBox2.ResumeLayout(false);
            this.xGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Heren.Common.Forms.XGroupBox xGroupBox2;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDIAG_BEFORE_OPERATION;
        private System.Windows.Forms.TextBox txtPATIENT_CONDITION;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Heren.Common.Controls.TimeControl.DateTimeControl dtSTART_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationScale;
        private System.Windows.Forms.Label label4;
        private Heren.Common.Controls.DictInput.FindComboBox cboOPERATING_ROOM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOPERATION_ROOM_NO;
        private System.Windows.Forms.TextBox txtOPERATION_SEQUENCE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ISOLATION_FLAG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_OPERATING_SCALE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_OPERATING_DEPT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_OPERATOR_DOCTOR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_FOUR_ASSISTANT;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_THREE_ASSISTANT;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_SECOND_ASSISTANT;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_FIRST_ASSISTANT;
        private System.Windows.Forms.Label label12;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_BLOOD_DOCTOR;
        private System.Windows.Forms.Label label13;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_ANAESTHESIA_METHOD;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_ANESTHESIA_DOCTOR;
        private System.Windows.Forms.Label label14;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_FIRST_ANESTHESIA;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_SECOND_OPERATION_NURSE;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_FIRST_OPERATION_NURSE;
        private System.Windows.Forms.Label label15;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_SECOND_SUPPLY_NURSE;
        private Heren.Common.Controls.DictInput.FindComboBox cbo_FIRST_SUPPLY_NURSE;
        private System.Windows.Forms.Label label16;
        private Heren.Common.Controls.TimeControl.DateTimeControl dt_REQ_DATE_TIME;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_NOTES_ON_OPERATION;
        private System.Windows.Forms.Label label18;
        private Heren.Common.Controls.TimeControl.DateTimeControl dtEND_DATE_TIME;
        private System.Windows.Forms.Label label19;
    }
}