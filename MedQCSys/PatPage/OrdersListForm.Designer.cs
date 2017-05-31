namespace MedQCSys.DockForms
{
    partial class OrdersListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersListForm));
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbOrderText = new System.Windows.Forms.ToolStripTextBox();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblOrdersInfo = new System.Windows.Forms.Label();
            this.colBeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepeatIndicator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdministration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStopDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNurse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBeginTime,
            this.colRepeatIndicator,
            this.colOrderClass,
            this.colOrderContent,
            this.colDosage,
            this.colflag,
            this.colAdministration,
            this.colFrequency,
            this.colOrderDoctor,
            this.colStopDoctor,
            this.colStopTime,
            this.colOrderStatus,
            this.colNurse});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(984, 388);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbOrderText,
            this.tsbSearch});
            this.toolStrip1.Location = new System.Drawing.Point(4, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "医嘱内容：";
            // 
            // tbOrderText
            // 
            this.tbOrderText.Name = "tbOrderText";
            this.tbOrderText.Size = new System.Drawing.Size(200, 25);
            this.tbOrderText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbOrderText_KeyDown);
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(52, 22);
            this.tsbSearch.Text = "检索";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.lblOrdersInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 33);
            this.panel1.TabIndex = 19;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnExport.Location = new System.Drawing.Point(810, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 28);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Excel导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(904, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblOrdersInfo
            // 
            this.lblOrdersInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrdersInfo.AutoSize = true;
            this.lblOrdersInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblOrdersInfo.Location = new System.Drawing.Point(1, 13);
            this.lblOrdersInfo.Name = "lblOrdersInfo";
            this.lblOrdersInfo.Size = new System.Drawing.Size(175, 14);
            this.lblOrdersInfo.TabIndex = 15;
            this.lblOrdersInfo.Text = "仍在执行的医嘱数目：0 条";
            // 
            // colBeginTime
            // 
            this.colBeginTime.FillWeight = 130F;
            this.colBeginTime.HeaderText = "下达时间";
            this.colBeginTime.Name = "colBeginTime";
            this.colBeginTime.ReadOnly = true;
            this.colBeginTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBeginTime.Width = 130;
            // 
            // colRepeatIndicator
            // 
            this.colRepeatIndicator.HeaderText = "长/临";
            this.colRepeatIndicator.Name = "colRepeatIndicator";
            this.colRepeatIndicator.ReadOnly = true;
            this.colRepeatIndicator.Width = 70;
            // 
            // colOrderClass
            // 
            this.colOrderClass.HeaderText = "类型";
            this.colOrderClass.Name = "colOrderClass";
            this.colOrderClass.ReadOnly = true;
            this.colOrderClass.Width = 60;
            // 
            // colOrderContent
            // 
            this.colOrderContent.FillWeight = 200F;
            this.colOrderContent.HeaderText = "医嘱内容";
            this.colOrderContent.Name = "colOrderContent";
            this.colOrderContent.ReadOnly = true;
            this.colOrderContent.Width = 250;
            // 
            // colDosage
            // 
            this.colDosage.FillWeight = 85F;
            this.colDosage.HeaderText = "剂量";
            this.colDosage.Name = "colDosage";
            this.colDosage.ReadOnly = true;
            this.colDosage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDosage.Width = 65;
            // 
            // colflag
            // 
            this.colflag.HeaderText = "";
            this.colflag.Name = "colflag";
            this.colflag.ReadOnly = true;
            this.colflag.Width = 25;
            // 
            // colAdministration
            // 
            this.colAdministration.FillWeight = 85F;
            this.colAdministration.HeaderText = "途径";
            this.colAdministration.Name = "colAdministration";
            this.colAdministration.ReadOnly = true;
            this.colAdministration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAdministration.Width = 65;
            // 
            // colFrequency
            // 
            this.colFrequency.FillWeight = 70F;
            this.colFrequency.HeaderText = "频次";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.ReadOnly = true;
            this.colFrequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFrequency.Width = 70;
            // 
            // colOrderDoctor
            // 
            this.colOrderDoctor.HeaderText = "下达医师";
            this.colOrderDoctor.Name = "colOrderDoctor";
            this.colOrderDoctor.ReadOnly = true;
            this.colOrderDoctor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStopDoctor
            // 
            this.colStopDoctor.HeaderText = "停止医师";
            this.colStopDoctor.Name = "colStopDoctor";
            this.colStopDoctor.ReadOnly = true;
            this.colStopDoctor.Width = 90;
            // 
            // colStopTime
            // 
            this.colStopTime.FillWeight = 130F;
            this.colStopTime.HeaderText = "停止时间";
            this.colStopTime.Name = "colStopTime";
            this.colStopTime.ReadOnly = true;
            this.colStopTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStopTime.Width = 130;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.HeaderText = "状态";
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.ReadOnly = true;
            // 
            // colNurse
            // 
            this.colNurse.HeaderText = "护士";
            this.colNurse.Name = "colNurse";
            this.colNurse.ReadOnly = true;
            this.colNurse.Width = 80;
            // 
            // OrdersListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(992, 454);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "OrdersListForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "医嘱内容";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrdersListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.Label lblOrdersInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbOrderText;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepeatIndicator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colflag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdministration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStopDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNurse;
    }
}