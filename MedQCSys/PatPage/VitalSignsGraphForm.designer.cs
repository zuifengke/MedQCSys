namespace MedQCSys.DockForms
{
    partial class VitalSignsGraphForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toollblDateFrom = new System.Windows.Forms.ToolStripLabel();
            this.tooldtpDateFrom = new Heren.Common.Controls.ToolStrip.ToolStripDateTimePicker();
            this.toollblSpace1 = new System.Windows.Forms.ToolStripLabel();
            this.toolbtnPrevWeek = new System.Windows.Forms.ToolStripButton();
            this.toollblWeek1 = new System.Windows.Forms.ToolStripLabel();
            this.tooltxtRecordWeek = new System.Windows.Forms.ToolStripTextBox();
            this.toollblWeek2 = new System.Windows.Forms.ToolStripLabel();
            this.toolbtnNextWeek = new System.Windows.Forms.ToolStripButton();
            this.toolcboZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toollblSpace2 = new System.Windows.Forms.ToolStripLabel();
            this.toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolbtnPrint = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolmnuPrintAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolmnuPrintCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolmnuPrintFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reportDesigner1 = new Heren.Common.Report.ReportDesigner();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toollblDateFrom,
            this.tooldtpDateFrom,
            this.toollblSpace1,
            this.toolbtnPrevWeek,
            this.toollblWeek1,
            this.tooltxtRecordWeek,
            this.toollblWeek2,
            this.toolbtnNextWeek,
            this.toolcboZoom,
            this.toollblSpace2,
            this.toolbtnRefresh,
            this.toolbtnPrint});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(702, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toollblDateFrom
            // 
            this.toollblDateFrom.AutoSize = false;
            this.toollblDateFrom.Name = "toollblDateFrom";
            this.toollblDateFrom.Size = new System.Drawing.Size(47, 22);
            this.toollblDateFrom.Text = "时间：";
            // 
            // tooldtpDateFrom
            // 
            this.tooldtpDateFrom.AutoSize = false;
            this.tooldtpDateFrom.BackColor = System.Drawing.Color.White;
            this.tooldtpDateFrom.Name = "tooldtpDateFrom";
            this.tooldtpDateFrom.ShowHour = false;
            this.tooldtpDateFrom.ShowMinute = false;
            this.tooldtpDateFrom.ShowSecond = false;
            this.tooldtpDateFrom.Size = new System.Drawing.Size(100, 22);
            this.tooldtpDateFrom.Text = "2012/2/20 13:32:28";
            this.tooldtpDateFrom.Value = new System.DateTime(2012, 2, 20, 13, 32, 28, 0);
            this.tooldtpDateFrom.ValueChanged += new System.EventHandler(this.tooldtpDateFrom_ValueChanged);
            // 
            // toollblSpace1
            // 
            this.toollblSpace1.AutoSize = false;
            this.toollblSpace1.Name = "toollblSpace1";
            this.toollblSpace1.Size = new System.Drawing.Size(8, 22);
            // 
            // toolbtnPrevWeek
            // 
            this.toolbtnPrevWeek.AutoSize = false;
            this.toolbtnPrevWeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPrevWeek.Name = "toolbtnPrevWeek";
            this.toolbtnPrevWeek.Size = new System.Drawing.Size(64, 22);
            this.toolbtnPrevWeek.Text = "前一周";
            this.toolbtnPrevWeek.Click += new System.EventHandler(this.toolbtnPrevWeek_Click);
            // 
            // toollblWeek1
            // 
            this.toollblWeek1.AutoSize = false;
            this.toollblWeek1.Name = "toollblWeek1";
            this.toollblWeek1.Size = new System.Drawing.Size(22, 22);
            this.toollblWeek1.Text = "第";
            // 
            // tooltxtRecordWeek
            // 
            this.tooltxtRecordWeek.AutoSize = false;
            this.tooltxtRecordWeek.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tooltxtRecordWeek.MaxLength = 4;
            this.tooltxtRecordWeek.Name = "tooltxtRecordWeek";
            this.tooltxtRecordWeek.Size = new System.Drawing.Size(48, 20);
            this.tooltxtRecordWeek.Text = "1";
            this.tooltxtRecordWeek.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltxtRecordWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tooltxtRecordWeek_KeyPress);
            // 
            // toollblWeek2
            // 
            this.toollblWeek2.AutoSize = false;
            this.toollblWeek2.Name = "toollblWeek2";
            this.toollblWeek2.Size = new System.Drawing.Size(22, 22);
            this.toollblWeek2.Text = "周";
            // 
            // toolbtnNextWeek
            // 
            this.toolbtnNextWeek.AutoSize = false;
            this.toolbtnNextWeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNextWeek.Name = "toolbtnNextWeek";
            this.toolbtnNextWeek.Size = new System.Drawing.Size(64, 22);
            this.toolbtnNextWeek.Text = "下一周";
            this.toolbtnNextWeek.Click += new System.EventHandler(this.toolbtnNextWeek_Click);
            // 
            // toolcboZoom
            // 
            this.toolcboZoom.AutoSize = false;
            this.toolcboZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolcboZoom.Items.AddRange(new object[] {
            "10%",
            "20%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "75%",
            "80%",
            "85%",
            "95%",
            "100%",
            "110%",
            "120%",
            "130%",
            "140%",
            "150%",
            "160%",
            "180%",
            "200%",
            "250%",
            "300%",
            "350%",
            "400%",
            "500%"});
            this.toolcboZoom.MaxDropDownItems = 16;
            this.toolcboZoom.Name = "toolcboZoom";
            this.toolcboZoom.Size = new System.Drawing.Size(75, 25);
            this.toolcboZoom.SelectedIndexChanged += new System.EventHandler(this.toolcboZoom_SelectedIndexChanged);
            // 
            // toollblSpace2
            // 
            this.toollblSpace2.AutoSize = false;
            this.toollblSpace2.Name = "toollblSpace2";
            this.toollblSpace2.Size = new System.Drawing.Size(8, 16);
            // 
            // toolbtnRefresh
            // 
            this.toolbtnRefresh.AutoSize = false;
            this.toolbtnRefresh.Image = global::MedQCSys.Properties.Resources.Refresh;
            this.toolbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRefresh.Name = "toolbtnRefresh";
            this.toolbtnRefresh.Size = new System.Drawing.Size(64, 22);
            this.toolbtnRefresh.Text = "刷新";
            this.toolbtnRefresh.Click += new System.EventHandler(this.toolbtnRefresh_Click);
            // 
            // toolbtnPrint
            // 
            this.toolbtnPrint.AutoSize = false;
            this.toolbtnPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolmnuPrintAll,
            this.toolmnuPrintCurrent,
            this.toolmnuPrintFrom});
            this.toolbtnPrint.Image = global::MedQCSys.Properties.Resources.Print;
            this.toolbtnPrint.Name = "toolbtnPrint";
            this.toolbtnPrint.Size = new System.Drawing.Size(64, 22);
            this.toolbtnPrint.Text = "打印";
            this.toolbtnPrint.Visible = false;
            // 
            // toolmnuPrintAll
            // 
            this.toolmnuPrintAll.Name = "toolmnuPrintAll";
            this.toolmnuPrintAll.Size = new System.Drawing.Size(172, 22);
            this.toolmnuPrintAll.Text = "打印所有页";
            this.toolmnuPrintAll.Click += new System.EventHandler(this.toolmnuPrintAll_Click);
            // 
            // toolmnuPrintCurrent
            // 
            this.toolmnuPrintCurrent.Name = "toolmnuPrintCurrent";
            this.toolmnuPrintCurrent.Size = new System.Drawing.Size(172, 22);
            this.toolmnuPrintCurrent.Text = "打印当前页";
            this.toolmnuPrintCurrent.Click += new System.EventHandler(this.toolmnuPrintCurrent_Click);
            // 
            // toolmnuPrintFrom
            // 
            this.toolmnuPrintFrom.Name = "toolmnuPrintFrom";
            this.toolmnuPrintFrom.Size = new System.Drawing.Size(172, 22);
            this.toolmnuPrintFrom.Text = "从当前页开始打印";
            this.toolmnuPrintFrom.Click += new System.EventHandler(this.toolmnuPrintFrom_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(2, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.reportDesigner1);
            this.splitContainer1.Size = new System.Drawing.Size(702, 418);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.TabIndex = 1;
            // 
            // reportDesigner1
            // 
            this.reportDesigner1.AutoScrollMinSize = new System.Drawing.Size(818, 1147);
            this.reportDesigner1.CanvasCenter = true;
            this.reportDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportDesigner1.Location = new System.Drawing.Point(0, 0);
            this.reportDesigner1.Name = "reportDesigner1";
            this.reportDesigner1.Readonly = true;
            this.reportDesigner1.Size = new System.Drawing.Size(426, 418);
            this.reportDesigner1.TabIndex = 0;
            this.reportDesigner1.Text = "reportDesigner1";
            this.reportDesigner1.ExecuteQuery += new Heren.Common.Report.ExecuteQueryEventHandler(this.reportDesigner1_ExecuteQuery);
            this.reportDesigner1.QueryContext += new Heren.Common.Report.QueryContextEventHandler(this.reportDesigner1_QueryContext);
            this.reportDesigner1.ElementDoubleClick += new Heren.Common.VectorEditor.CanvasEventHandler(this.reportDesigner1_ElementDoubleClick);
            // 
            // VitalSignsGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(706, 454);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VitalSignsGraphForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "体温单";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toollblSpace1;
        private System.Windows.Forms.ToolStripButton toolbtnPrevWeek;
        private System.Windows.Forms.ToolStripLabel toollblWeek1;
        private System.Windows.Forms.ToolStripLabel toollblWeek2;
        private System.Windows.Forms.ToolStripButton toolbtnNextWeek;
        private System.Windows.Forms.ToolStripComboBox toolcboZoom;
        private System.Windows.Forms.ToolStripLabel toollblSpace2;
        private System.Windows.Forms.ToolStripButton toolbtnRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Heren.Common.Report.ReportDesigner reportDesigner1;
        private System.Windows.Forms.ToolStripLabel toollblDateFrom;
        private Heren.Common.Controls.ToolStrip.ToolStripDateTimePicker tooldtpDateFrom;
        private System.Windows.Forms.ToolStripTextBox tooltxtRecordWeek;
        private System.Windows.Forms.ToolStripDropDownButton toolbtnPrint;
        private System.Windows.Forms.ToolStripMenuItem toolmnuPrintAll;
        private System.Windows.Forms.ToolStripMenuItem toolmnuPrintCurrent;
        private System.Windows.Forms.ToolStripMenuItem toolmnuPrintFrom;
    }
}