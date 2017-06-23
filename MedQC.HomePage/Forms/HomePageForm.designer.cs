namespace Heren.MedQC.HomePage
{
    partial class HomePageForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.colSerialNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new Heren.Common.Forms.XComboBoxColumn();
            this.colRoleBak = new Heren.Common.Forms.XTextBoxColumn();
            this.mnuAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.demoCard1 = new Heren.MedQC.HomePage.PageCards.DemoCard();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colSerialNO
            // 
            this.colSerialNO.Name = "colSerialNO";
            // 
            // colRoleName
            // 
            this.colRoleName.Name = "colRoleName";
            // 
            // colRoleCode
            // 
            this.colRoleCode.Name = "colRoleCode";
            // 
            // colStatus
            // 
            this.colStatus.Name = "colStatus";
            // 
            // colRoleBak
            // 
            this.colRoleBak.Name = "colRoleBak";
            // 
            // mnuAddItem
            // 
            this.mnuAddItem.Name = "mnuAddItem";
            this.mnuAddItem.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuModifyItem
            // 
            this.mnuModifyItem.Name = "mnuModifyItem";
            this.mnuModifyItem.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuDeleteItem
            // 
            this.mnuDeleteItem.Name = "mnuDeleteItem";
            this.mnuDeleteItem.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuSaveItems
            // 
            this.mnuSaveItems.Name = "mnuSaveItems";
            this.mnuSaveItems.Size = new System.Drawing.Size(32, 19);
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(392, 270);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "时效监控";
            title3.Name = "Title1";
            title3.Text = "时效监控";
            this.chart1.Titles.Add(title3);
            // 
            // chart2
            // 
            chartArea5.Name = "ChartArea1";
            chartArea6.Name = "ChartArea2";
            this.chart2.ChartAreas.Add(chartArea5);
            this.chart2.ChartAreas.Add(chartArea6);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(401, 3);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(375, 270);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "内容监控";
            title4.Name = "Title1";
            title4.Text = "病历质量监控";
            this.chart2.Titles.Add(title4);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.chart1);
            this.flowLayoutPanel1.Controls.Add(this.chart2);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.demoCard1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1171, 682);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.metroCheckBox2);
            this.panel1.Controls.Add(this.metroCheckBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.metroTile1);
            this.panel1.Location = new System.Drawing.Point(3, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 286);
            this.panel1.TabIndex = 2;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.CustomBackground = false;
            this.metroCheckBox2.CustomForeColor = false;
            this.metroCheckBox2.FontSize = MetroFramework.MetroLinkSize.Small;
            this.metroCheckBox2.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.metroCheckBox2.Location = new System.Drawing.Point(209, 6);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(62, 15);
            this.metroCheckBox2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroCheckBox2.StyleManager = null;
            this.metroCheckBox2.TabIndex = 2;
            this.metroCheckBox2.Text = "未修改";
            this.metroCheckBox2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroCheckBox2.UseStyleColors = false;
            this.metroCheckBox2.UseVisualStyleBackColor = true;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Checked = true;
            this.metroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox1.CustomBackground = false;
            this.metroCheckBox1.CustomForeColor = false;
            this.metroCheckBox1.FontSize = MetroFramework.MetroLinkSize.Small;
            this.metroCheckBox1.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.metroCheckBox1.Location = new System.Drawing.Point(141, 6);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(62, 15);
            this.metroCheckBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroCheckBox1.StyleManager = null;
            this.metroCheckBox1.TabIndex = 2;
            this.metroCheckBox1.Text = "已修改";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroCheckBox1.UseStyleColors = false;
            this.metroCheckBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(3, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(455, 257);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "提交时间";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "质检问题";
            this.Column4.Name = "Column4";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "医生反馈";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.CustomBackground = false;
            this.metroTile1.CustomForeColor = false;
            this.metroTile1.Location = new System.Drawing.Point(2, 3);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.PaintTileCount = true;
            this.metroTile1.Size = new System.Drawing.Size(132, 20);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile1.StyleManager = null;
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "质检信息状态监控";
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTile1.TileCount = 0;
            // 
            // demoCard1
            // 
            this.demoCard1.Location = new System.Drawing.Point(470, 279);
            this.demoCard1.Name = "demoCard1";
            this.demoCard1.Size = new System.Drawing.Size(502, 286);
            this.demoCard1.TabIndex = 3;
            // 
            // HomePageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1171, 682);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "HomePageForm";
            this.Text = "起始页";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerialNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleCode;
        private Heren.Common.Forms.XComboBoxColumn colStatus;
        private Heren.Common.Forms.XTextBoxColumn colRoleBak;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private PageCards.DemoCard demoCard1;
    }
}