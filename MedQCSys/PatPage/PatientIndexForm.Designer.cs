namespace MedQCSys.DockForms
{
    partial class PatientIndexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientIndexForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnPreview = new System.Windows.Forms.ToolStripButton();
            this.reportDesigner1 = new Heren.Common.Report.ReportDesigner();
            this.previewControl1 = new Heren.Common.PrintLib.XPreviewControl();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnPreview});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(793, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnPreview
            // 
            this.toolbtnPreview.Image = global::MedQCSys.Properties.Resources.PrintDoc;
            this.toolbtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPreview.Name = "toolbtnPreview";
            this.toolbtnPreview.Size = new System.Drawing.Size(52, 22);
            this.toolbtnPreview.Text = "打印";
            this.toolbtnPreview.Click += new System.EventHandler(this.toolbtnPreview_Click);
            // 
            // reportDesigner1
            // 
            this.reportDesigner1.AutoScrollMinSize = new System.Drawing.Size(818, 1147);
            this.reportDesigner1.CanvasCenter = true;
            this.reportDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportDesigner1.Location = new System.Drawing.Point(0, 25);
            this.reportDesigner1.Name = "reportDesigner1";
            this.reportDesigner1.Readonly = true;
            this.reportDesigner1.Size = new System.Drawing.Size(793, 450);
            this.reportDesigner1.TabIndex = 1;
            this.reportDesigner1.Text = "reportDesigner1";
            this.reportDesigner1.ExecuteQuery += new Heren.Common.Report.ExecuteQueryEventHandler(this.reportDesigner1_ExecuteQuery);
            this.reportDesigner1.QueryContext += new Heren.Common.Report.QueryContextEventHandler(this.reportDesigner1_QueryContext);
            this.reportDesigner1.NotifyPageCompleted += new System.EventHandler(this.reportDesigner1_NotifyPageCompleted);
            this.reportDesigner1.NotifyNextReport += new Heren.Common.Report.NotifyNextReportEventHandler(this.reportDesigner1_NotifyNextReport);
            // 
            // previewControl1
            // 
            this.previewControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Location = new System.Drawing.Point(0, 25);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.Size = new System.Drawing.Size(793, 450);
            this.previewControl1.TabIndex = 2;
            this.previewControl1.TabStop = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // PatientIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 475);
            this.Controls.Add(this.previewControl1);
            this.Controls.Add(this.reportDesigner1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PatientIndexForm";
            this.Text = "病案首页";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Heren.Common.Report.ReportDesigner reportDesigner1;
        private System.Windows.Forms.ToolStripButton toolbtnPreview;
        private Heren.Common.PrintLib.XPreviewControl previewControl1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}
