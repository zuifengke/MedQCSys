namespace Heren.MedQC.DbConfig
{
    partial class MainForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tp = new System.Windows.Forms.TabControl();
            this.tpMedQC = new System.Windows.Forms.TabPage();
            this.cboQcConnString = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboQcProvider = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cboQcDbType = new System.Windows.Forms.ComboBox();
            this.tpMdsConfig = new System.Windows.Forms.TabPage();
            this.cboOcxConnString = new System.Windows.Forms.ComboBox();
            this.cboMdsConnString = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMdsDbProvider = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMdsDbType = new System.Windows.Forms.ComboBox();
            this.tpXdbConfig = new System.Windows.Forms.TabPage();
            this.cboXdbConnString = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboXdbDbProvider = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboXdbDbType = new System.Windows.Forms.ComboBox();
            this.tpNdsConfig = new System.Windows.Forms.TabPage();
            this.cboNdsConnString = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboNdsDbProvider = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboNdsDbType = new System.Windows.Forms.ComboBox();
            this.tpHisConfig = new System.Windows.Forms.TabPage();
            this.cboHisConnString = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboHisDbProvider = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboHisDbType = new System.Windows.Forms.ComboBox();
            this.tpBAJK = new System.Windows.Forms.TabPage();
            this.cboBAJKConnString = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboBAJKDbProvider = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cboBAJKDbType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tp.SuspendLayout();
            this.tpMedQC.SuspendLayout();
            this.tpMdsConfig.SuspendLayout();
            this.tpXdbConfig.SuspendLayout();
            this.tpNdsConfig.SuspendLayout();
            this.tpHisConfig.SuspendLayout();
            this.tpBAJK.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(165, 361);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(140, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtConfigFile.Location = new System.Drawing.Point(132, 12);
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.ReadOnly = true;
            this.txtConfigFile.Size = new System.Drawing.Size(501, 21);
            this.txtConfigFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "当前目标配置文件：";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Image = global::Heren.MedQC.DbConfig.Properties.Resources.Open;
            this.btnOpen.Location = new System.Drawing.Point(642, 11);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(28, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tp
            // 
            this.tp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tp.Controls.Add(this.tpMedQC);
            this.tp.Controls.Add(this.tpMdsConfig);
            this.tp.Controls.Add(this.tpXdbConfig);
            this.tp.Controls.Add(this.tpNdsConfig);
            this.tp.Controls.Add(this.tpHisConfig);
            this.tp.Controls.Add(this.tpBAJK);
            this.tp.Location = new System.Drawing.Point(15, 46);
            this.tp.Name = "tp";
            this.tp.SelectedIndex = 0;
            this.tp.Size = new System.Drawing.Size(657, 302);
            this.tp.TabIndex = 34;
            // 
            // tpMedQC
            // 
            this.tpMedQC.Controls.Add(this.cboQcConnString);
            this.tpMedQC.Controls.Add(this.label15);
            this.tpMedQC.Controls.Add(this.cboQcProvider);
            this.tpMedQC.Controls.Add(this.label16);
            this.tpMedQC.Controls.Add(this.label17);
            this.tpMedQC.Controls.Add(this.cboQcDbType);
            this.tpMedQC.Location = new System.Drawing.Point(4, 22);
            this.tpMedQC.Name = "tpMedQC";
            this.tpMedQC.Padding = new System.Windows.Forms.Padding(3);
            this.tpMedQC.Size = new System.Drawing.Size(649, 276);
            this.tpMedQC.TabIndex = 5;
            this.tpMedQC.Text = "质控数据库配置";
            this.tpMedQC.UseVisualStyleBackColor = true;
            // 
            // cboQcConnString
            // 
            this.cboQcConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboQcConnString.FormattingEnabled = true;
            this.cboQcConnString.Items.AddRange(new object[] {
            "provider=msdaora.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=oraoledb.oracle.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=sqloledb.1;server=.;database=meddoc;user id=sa;password=;",
            "data source=meddoc;user id=meddoc;password=meddoc;",
            "server=.;database=meddoc;user id=sa;password=;",
            "dsn=meddoc;uid=meddoc;pwd=meddoc;"});
            this.cboQcConnString.Location = new System.Drawing.Point(146, 148);
            this.cboQcConnString.Name = "cboQcConnString";
            this.cboQcConnString.Size = new System.Drawing.Size(486, 20);
            this.cboQcConnString.TabIndex = 44;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 12);
            this.label15.TabIndex = 49;
            this.label15.Text = "数据提供程序类型：";
            // 
            // cboQcProvider
            // 
            this.cboQcProvider.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cboQcProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboQcProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQcProvider.FormattingEnabled = true;
            this.cboQcProvider.Items.AddRange(new object[] {
            "System.Data.OracleClient",
            "System.Data.SqlClient",
            "System.Data.OleDb",
            "System.Data.Odbc",
            "Oracle.DataAccess.Client"});
            this.cboQcProvider.Location = new System.Drawing.Point(146, 107);
            this.cboQcProvider.Name = "cboQcProvider";
            this.cboQcProvider.Size = new System.Drawing.Size(486, 20);
            this.cboQcProvider.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 153);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 12);
            this.label16.TabIndex = 48;
            this.label16.Text = "数据库连接字符串：";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 46;
            this.label17.Text = "数据库类型：";
            // 
            // cboQcDbType
            // 
            this.cboQcDbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboQcDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQcDbType.FormattingEnabled = true;
            this.cboQcDbType.Items.AddRange(new object[] {
            "ORACLE",
            "SQLSERVER"});
            this.cboQcDbType.Location = new System.Drawing.Point(146, 68);
            this.cboQcDbType.Name = "cboQcDbType";
            this.cboQcDbType.Size = new System.Drawing.Size(486, 20);
            this.cboQcDbType.TabIndex = 42;
            // 
            // tpMdsConfig
            // 
            this.tpMdsConfig.Controls.Add(this.cboOcxConnString);
            this.tpMdsConfig.Controls.Add(this.cboMdsConnString);
            this.tpMdsConfig.Controls.Add(this.label3);
            this.tpMdsConfig.Controls.Add(this.cboMdsDbProvider);
            this.tpMdsConfig.Controls.Add(this.label2);
            this.tpMdsConfig.Controls.Add(this.label6);
            this.tpMdsConfig.Controls.Add(this.label5);
            this.tpMdsConfig.Controls.Add(this.cboMdsDbType);
            this.tpMdsConfig.Location = new System.Drawing.Point(4, 22);
            this.tpMdsConfig.Name = "tpMdsConfig";
            this.tpMdsConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpMdsConfig.Size = new System.Drawing.Size(649, 276);
            this.tpMdsConfig.TabIndex = 0;
            this.tpMdsConfig.Text = "病历数据库配置";
            this.tpMdsConfig.UseVisualStyleBackColor = true;
            // 
            // cboOcxConnString
            // 
            this.cboOcxConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOcxConnString.FormattingEnabled = true;
            this.cboOcxConnString.Items.AddRange(new object[] {
            "provider=msdaora.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=oraoledb.oracle.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=sqloledb.1;server=.;database=meddoc;user id=sa;password=;"});
            this.cboOcxConnString.Location = new System.Drawing.Point(146, 186);
            this.cboOcxConnString.Name = "cboOcxConnString";
            this.cboOcxConnString.Size = new System.Drawing.Size(486, 20);
            this.cboOcxConnString.TabIndex = 37;
            // 
            // cboMdsConnString
            // 
            this.cboMdsConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMdsConnString.FormattingEnabled = true;
            this.cboMdsConnString.Items.AddRange(new object[] {
            "provider=msdaora.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=oraoledb.oracle.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=sqloledb.1;server=.;database=meddoc;user id=sa;password=;",
            "data source=meddoc;user id=meddoc;password=meddoc;",
            "server=.;database=meddoc;user id=sa;password=;",
            "dsn=meddoc;uid=meddoc;pwd=meddoc;"});
            this.cboMdsConnString.Location = new System.Drawing.Point(146, 146);
            this.cboMdsConnString.Name = "cboMdsConnString";
            this.cboMdsConnString.Size = new System.Drawing.Size(486, 20);
            this.cboMdsConnString.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "数据提供程序类型：";
            // 
            // cboMdsDbProvider
            // 
            this.cboMdsDbProvider.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cboMdsDbProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMdsDbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMdsDbProvider.FormattingEnabled = true;
            this.cboMdsDbProvider.Items.AddRange(new object[] {
            "System.Data.OracleClient",
            "System.Data.SqlClient",
            "System.Data.OleDb",
            "System.Data.Odbc",
            "Oracle.DataAccess.Client"});
            this.cboMdsDbProvider.Location = new System.Drawing.Point(146, 105);
            this.cboMdsDbProvider.Name = "cboMdsDbProvider";
            this.cboMdsDbProvider.Size = new System.Drawing.Size(486, 20);
            this.cboMdsDbProvider.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "数据库连接字符串：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "数据库类型：";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "OCX数据库连接字符串：";
            // 
            // cboMdsDbType
            // 
            this.cboMdsDbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMdsDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMdsDbType.FormattingEnabled = true;
            this.cboMdsDbType.Items.AddRange(new object[] {
            "ORACLE",
            "SQLSERVER"});
            this.cboMdsDbType.Location = new System.Drawing.Point(146, 66);
            this.cboMdsDbType.Name = "cboMdsDbType";
            this.cboMdsDbType.Size = new System.Drawing.Size(486, 20);
            this.cboMdsDbType.TabIndex = 34;
            // 
            // tpXdbConfig
            // 
            this.tpXdbConfig.Controls.Add(this.cboXdbConnString);
            this.tpXdbConfig.Controls.Add(this.label9);
            this.tpXdbConfig.Controls.Add(this.cboXdbDbProvider);
            this.tpXdbConfig.Controls.Add(this.label10);
            this.tpXdbConfig.Controls.Add(this.label11);
            this.tpXdbConfig.Controls.Add(this.cboXdbDbType);
            this.tpXdbConfig.Location = new System.Drawing.Point(4, 22);
            this.tpXdbConfig.Name = "tpXdbConfig";
            this.tpXdbConfig.Size = new System.Drawing.Size(649, 276);
            this.tpXdbConfig.TabIndex = 2;
            this.tpXdbConfig.Text = "XML DB数据库配置";
            this.tpXdbConfig.UseVisualStyleBackColor = true;
            // 
            // cboXdbConnString
            // 
            this.cboXdbConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboXdbConnString.FormattingEnabled = true;
            this.cboXdbConnString.Items.AddRange(new object[] {
            "provider=msdaora.1;data source=medxdb;user id=medxdb;password=medxdb;",
            "provider=oraoledb.oracle.1;data source=medxdb;user id=medxdb;password=medxdb;",
            "data source=medxdb;user id=medxdb;password=medxdb;"});
            this.cboXdbConnString.Location = new System.Drawing.Point(146, 164);
            this.cboXdbConnString.Name = "cboXdbConnString";
            this.cboXdbConnString.Size = new System.Drawing.Size(483, 20);
            this.cboXdbConnString.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "数据提供程序类型：";
            // 
            // cboXdbDbProvider
            // 
            this.cboXdbDbProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboXdbDbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboXdbDbProvider.FormattingEnabled = true;
            this.cboXdbDbProvider.Items.AddRange(new object[] {
            "System.Data.OracleClient",
            "System.Data.SqlClient",
            "System.Data.OleDb",
            "System.Data.Odbc",
            "Oracle.DataAccess.Client"});
            this.cboXdbDbProvider.Location = new System.Drawing.Point(146, 123);
            this.cboXdbDbProvider.Name = "cboXdbDbProvider";
            this.cboXdbDbProvider.Size = new System.Drawing.Size(483, 20);
            this.cboXdbDbProvider.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 54;
            this.label10.Text = "数据库连接字符串：";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 53;
            this.label11.Text = "数据库类型：";
            // 
            // cboXdbDbType
            // 
            this.cboXdbDbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboXdbDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboXdbDbType.FormattingEnabled = true;
            this.cboXdbDbType.Items.AddRange(new object[] {
            "ORACLE",
            "SQLSERVER"});
            this.cboXdbDbType.Location = new System.Drawing.Point(146, 84);
            this.cboXdbDbType.Name = "cboXdbDbType";
            this.cboXdbDbType.Size = new System.Drawing.Size(483, 20);
            this.cboXdbDbType.TabIndex = 50;
            // 
            // tpNdsConfig
            // 
            this.tpNdsConfig.Controls.Add(this.cboNdsConnString);
            this.tpNdsConfig.Controls.Add(this.label4);
            this.tpNdsConfig.Controls.Add(this.cboNdsDbProvider);
            this.tpNdsConfig.Controls.Add(this.label7);
            this.tpNdsConfig.Controls.Add(this.label8);
            this.tpNdsConfig.Controls.Add(this.cboNdsDbType);
            this.tpNdsConfig.Location = new System.Drawing.Point(4, 22);
            this.tpNdsConfig.Name = "tpNdsConfig";
            this.tpNdsConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpNdsConfig.Size = new System.Drawing.Size(649, 276);
            this.tpNdsConfig.TabIndex = 3;
            this.tpNdsConfig.Text = "护理病历数据库配置";
            this.tpNdsConfig.UseVisualStyleBackColor = true;
            // 
            // cboNdsConnString
            // 
            this.cboNdsConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNdsConnString.FormattingEnabled = true;
            this.cboNdsConnString.Items.AddRange(new object[] {
            "provider=msdaora.1;data source=meddoc;user id=nurdoc;password=nurdoc;",
            "provider=oraoledb.oracle.1;data source=meddoc;user id=nurdoc;password=nurdoc;",
            "provider=sqloledb.1;server=.;database=meddoc;user id=sa;password=;",
            "data source=meddoc;user id=nurdoc;password=nurdoc;",
            "server=.;database=meddoc;user id=sa;password=;",
            "dsn=meddoc;uid=nurdoc;pwd=nurdoc;"});
            this.cboNdsConnString.Location = new System.Drawing.Point(146, 168);
            this.cboNdsConnString.Name = "cboNdsConnString";
            this.cboNdsConnString.Size = new System.Drawing.Size(486, 20);
            this.cboNdsConnString.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "数据提供程序类型：";
            // 
            // cboNdsDbProvider
            // 
            this.cboNdsDbProvider.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cboNdsDbProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNdsDbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNdsDbProvider.FormattingEnabled = true;
            this.cboNdsDbProvider.Items.AddRange(new object[] {
            "System.Data.OracleClient",
            "System.Data.SqlClient",
            "System.Data.OleDb",
            "System.Data.Odbc",
            "Oracle.DataAccess.Client"});
            this.cboNdsDbProvider.Location = new System.Drawing.Point(146, 127);
            this.cboNdsDbProvider.Name = "cboNdsDbProvider";
            this.cboNdsDbProvider.Size = new System.Drawing.Size(486, 20);
            this.cboNdsDbProvider.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 46;
            this.label7.Text = "数据库连接字符串：";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 45;
            this.label8.Text = "数据库类型：";
            // 
            // cboNdsDbType
            // 
            this.cboNdsDbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNdsDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNdsDbType.FormattingEnabled = true;
            this.cboNdsDbType.Items.AddRange(new object[] {
            "ORACLE",
            "SQLSERVER"});
            this.cboNdsDbType.Location = new System.Drawing.Point(146, 88);
            this.cboNdsDbType.Name = "cboNdsDbType";
            this.cboNdsDbType.Size = new System.Drawing.Size(486, 20);
            this.cboNdsDbType.TabIndex = 42;
            // 
            // tpHisConfig
            // 
            this.tpHisConfig.Controls.Add(this.cboHisConnString);
            this.tpHisConfig.Controls.Add(this.label12);
            this.tpHisConfig.Controls.Add(this.cboHisDbProvider);
            this.tpHisConfig.Controls.Add(this.label13);
            this.tpHisConfig.Controls.Add(this.label14);
            this.tpHisConfig.Controls.Add(this.cboHisDbType);
            this.tpHisConfig.Location = new System.Drawing.Point(4, 22);
            this.tpHisConfig.Name = "tpHisConfig";
            this.tpHisConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tpHisConfig.Size = new System.Drawing.Size(649, 276);
            this.tpHisConfig.TabIndex = 4;
            this.tpHisConfig.Text = "HIS数据库配置";
            this.tpHisConfig.UseVisualStyleBackColor = true;
            // 
            // cboHisConnString
            // 
            this.cboHisConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHisConnString.FormattingEnabled = true;
            this.cboHisConnString.Items.AddRange(new object[] {
            "provider=msdaora.1;data source=meddoc;user id=nurdoc;password=nurdoc;",
            "provider=oraoledb.oracle.1;data source=meddoc;user id=nurdoc;password=nurdoc;",
            "provider=sqloledb.1;server=.;database=meddoc;user id=sa;password=;",
            "data source=meddoc;user id=nurdoc;password=nurdoc;",
            "server=.;database=meddoc;user id=sa;password=;",
            "dsn=meddoc;uid=nurdoc;pwd=nurdoc;",
            "provider=msdaora.1;data source=emrdb;user id=ihd;password=ihd;"});
            this.cboHisConnString.Location = new System.Drawing.Point(146, 168);
            this.cboHisConnString.Name = "cboHisConnString";
            this.cboHisConnString.Size = new System.Drawing.Size(486, 20);
            this.cboHisConnString.TabIndex = 50;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 12);
            this.label12.TabIndex = 53;
            this.label12.Text = "数据提供程序类型：";
            // 
            // cboHisDbProvider
            // 
            this.cboHisDbProvider.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cboHisDbProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHisDbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHisDbProvider.FormattingEnabled = true;
            this.cboHisDbProvider.Items.AddRange(new object[] {
            "System.Data.OracleClient",
            "System.Data.SqlClient",
            "System.Data.OleDb",
            "System.Data.Odbc",
            "Oracle.DataAccess.Client"});
            this.cboHisDbProvider.Location = new System.Drawing.Point(146, 127);
            this.cboHisDbProvider.Name = "cboHisDbProvider";
            this.cboHisDbProvider.Size = new System.Drawing.Size(486, 20);
            this.cboHisDbProvider.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 12);
            this.label13.TabIndex = 52;
            this.label13.Text = "数据库连接字符串：";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 51;
            this.label14.Text = "数据库类型：";
            // 
            // cboHisDbType
            // 
            this.cboHisDbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHisDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHisDbType.FormattingEnabled = true;
            this.cboHisDbType.Items.AddRange(new object[] {
            "ORACLE",
            "SQLSERVER"});
            this.cboHisDbType.Location = new System.Drawing.Point(146, 88);
            this.cboHisDbType.Name = "cboHisDbType";
            this.cboHisDbType.Size = new System.Drawing.Size(486, 20);
            this.cboHisDbType.TabIndex = 48;
            // 
            // tpBAJK
            // 
            this.tpBAJK.Controls.Add(this.cboBAJKConnString);
            this.tpBAJK.Controls.Add(this.label18);
            this.tpBAJK.Controls.Add(this.cboBAJKDbProvider);
            this.tpBAJK.Controls.Add(this.label19);
            this.tpBAJK.Controls.Add(this.label20);
            this.tpBAJK.Controls.Add(this.cboBAJKDbType);
            this.tpBAJK.Location = new System.Drawing.Point(4, 22);
            this.tpBAJK.Name = "tpBAJK";
            this.tpBAJK.Padding = new System.Windows.Forms.Padding(3);
            this.tpBAJK.Size = new System.Drawing.Size(649, 276);
            this.tpBAJK.TabIndex = 6;
            this.tpBAJK.Text = "联众病案接口库";
            this.tpBAJK.UseVisualStyleBackColor = true;
            // 
            // cboBAJKConnString
            // 
            this.cboBAJKConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBAJKConnString.FormattingEnabled = true;
            this.cboBAJKConnString.Items.AddRange(new object[] {
            "provider=msdaora.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=oraoledb.oracle.1;data source=meddoc;user id=meddoc;password=meddoc;",
            "provider=sqloledb.1;server=.;database=meddoc;user id=sa;password=;",
            "data source=meddoc;user id=meddoc;password=meddoc;",
            "server=.;database=meddoc;user id=sa;password=;",
            "dsn=meddoc;uid=meddoc;pwd=meddoc;"});
            this.cboBAJKConnString.Location = new System.Drawing.Point(146, 168);
            this.cboBAJKConnString.Name = "cboBAJKConnString";
            this.cboBAJKConnString.Size = new System.Drawing.Size(486, 20);
            this.cboBAJKConnString.TabIndex = 52;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 132);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 12);
            this.label18.TabIndex = 55;
            this.label18.Text = "数据提供程序类型：";
            // 
            // cboBAJKDbProvider
            // 
            this.cboBAJKDbProvider.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cboBAJKDbProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBAJKDbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBAJKDbProvider.FormattingEnabled = true;
            this.cboBAJKDbProvider.Items.AddRange(new object[] {
            "System.Data.OracleClient",
            "System.Data.SqlClient",
            "System.Data.OleDb",
            "System.Data.Odbc",
            "Oracle.DataAccess.Client"});
            this.cboBAJKDbProvider.Location = new System.Drawing.Point(146, 127);
            this.cboBAJKDbProvider.Name = "cboBAJKDbProvider";
            this.cboBAJKDbProvider.Size = new System.Drawing.Size(486, 20);
            this.cboBAJKDbProvider.TabIndex = 51;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 173);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 12);
            this.label19.TabIndex = 54;
            this.label19.Text = "数据库连接字符串：";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 12);
            this.label20.TabIndex = 53;
            this.label20.Text = "数据库类型：";
            // 
            // cboBAJKDbType
            // 
            this.cboBAJKDbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBAJKDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBAJKDbType.FormattingEnabled = true;
            this.cboBAJKDbType.Items.AddRange(new object[] {
            "ORACLE",
            "SQLSERVER"});
            this.cboBAJKDbType.Location = new System.Drawing.Point(146, 88);
            this.cboBAJKDbType.Name = "cboBAJKDbType";
            this.cboBAJKDbType.Size = new System.Drawing.Size(486, 20);
            this.cboBAJKDbType.TabIndex = 50;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(377, 361);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 32);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 405);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tp);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfigFile);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电子病历系统数据库配置";
            this.tp.ResumeLayout(false);
            this.tpMedQC.ResumeLayout(false);
            this.tpMedQC.PerformLayout();
            this.tpMdsConfig.ResumeLayout(false);
            this.tpMdsConfig.PerformLayout();
            this.tpXdbConfig.ResumeLayout(false);
            this.tpXdbConfig.PerformLayout();
            this.tpNdsConfig.ResumeLayout(false);
            this.tpNdsConfig.PerformLayout();
            this.tpHisConfig.ResumeLayout(false);
            this.tpHisConfig.PerformLayout();
            this.tpBAJK.ResumeLayout(false);
            this.tpBAJK.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtConfigFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabControl tp;
        private System.Windows.Forms.TabPage tpMdsConfig;
        private System.Windows.Forms.ComboBox cboOcxConnString;
        private System.Windows.Forms.ComboBox cboMdsConnString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMdsDbProvider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMdsDbType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tpXdbConfig;
        private System.Windows.Forms.ComboBox cboXdbConnString;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboXdbDbProvider;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboXdbDbType;
        private System.Windows.Forms.TabPage tpNdsConfig;
        private System.Windows.Forms.ComboBox cboNdsConnString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboNdsDbProvider;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboNdsDbType;
        private System.Windows.Forms.TabPage tpHisConfig;
        private System.Windows.Forms.ComboBox cboHisConnString;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboHisDbProvider;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboHisDbType;
        private System.Windows.Forms.TabPage tpMedQC;
        private System.Windows.Forms.ComboBox cboQcConnString;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboQcProvider;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboQcDbType;
        private System.Windows.Forms.TabPage tpBAJK;
        private System.Windows.Forms.ComboBox cboBAJKConnString;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboBAJKDbProvider;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboBAJKDbType;
    }
}