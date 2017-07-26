namespace Heren.MedQC.ScriptEngine.Debugger
{
    partial class DebuggerForm
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
            this.toolbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolbtnExamples = new System.Windows.Forms.ToolStripButton();
            this.toolbtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnComment = new System.Windows.Forms.ToolStripButton();
            this.toolbtnUncomment = new System.Windows.Forms.ToolStripButton();
            this.toolbtnTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnOK = new System.Windows.Forms.ToolStripButton();
            this.toolbtnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolbtnExit = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new Heren.Common.DockSuite.DockPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblSystemStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnNew,
            this.toolbtnOpen,
            this.toolbtnExamples,
            this.toolbtnSaveAs,
            this.toolStripSeparator1,
            this.toolbtnComment,
            this.toolbtnUncomment,
            this.toolbtnTest,
            this.toolStripSeparator2,
            this.toolbtnOK,
            this.toolbtnHelp,
            this.toolbtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(826, 28);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnNew
            // 
            this.toolbtnNew.AutoSize = false;
            this.toolbtnNew.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.NewDoc;
            this.toolbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNew.Name = "toolbtnNew";
            this.toolbtnNew.Size = new System.Drawing.Size(54, 24);
            this.toolbtnNew.Text = "新建";
            this.toolbtnNew.Click += new System.EventHandler(this.toolbtnNew_Click);
            // 
            // toolbtnOpen
            // 
            this.toolbtnOpen.AutoSize = false;
            this.toolbtnOpen.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.OpenDoc;
            this.toolbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnOpen.Name = "toolbtnOpen";
            this.toolbtnOpen.Size = new System.Drawing.Size(54, 24);
            this.toolbtnOpen.Text = "打开";
            this.toolbtnOpen.Click += new System.EventHandler(this.toolbtnOpen_Click);
            // 
            // toolbtnExamples
            // 
            this.toolbtnExamples.AutoSize = false;
            this.toolbtnExamples.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Example;
            this.toolbtnExamples.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExamples.Name = "toolbtnExamples";
            this.toolbtnExamples.Size = new System.Drawing.Size(54, 24);
            this.toolbtnExamples.Text = "样例";
            this.toolbtnExamples.Click += new System.EventHandler(this.toolbtnExamples_Click);
            // 
            // toolbtnSaveAs
            // 
            this.toolbtnSaveAs.AutoSize = false;
            this.toolbtnSaveAs.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.SaveDoc;
            this.toolbtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSaveAs.Name = "toolbtnSaveAs";
            this.toolbtnSaveAs.Size = new System.Drawing.Size(64, 24);
            this.toolbtnSaveAs.Text = "另存为";
            this.toolbtnSaveAs.Click += new System.EventHandler(this.toolbtnSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnComment
            // 
            this.toolbtnComment.AutoSize = false;
            this.toolbtnComment.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Comment;
            this.toolbtnComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnComment.Name = "toolbtnComment";
            this.toolbtnComment.Size = new System.Drawing.Size(54, 24);
            this.toolbtnComment.Text = "注释";
            this.toolbtnComment.Click += new System.EventHandler(this.toolbtnComment_Click);
            // 
            // toolbtnUncomment
            // 
            this.toolbtnUncomment.AutoSize = false;
            this.toolbtnUncomment.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Uncomment;
            this.toolbtnUncomment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnUncomment.Name = "toolbtnUncomment";
            this.toolbtnUncomment.Size = new System.Drawing.Size(78, 24);
            this.toolbtnUncomment.Text = "取消注释";
            this.toolbtnUncomment.Click += new System.EventHandler(this.toolbtnUncomment_Click);
            // 
            // toolbtnTest
            // 
            this.toolbtnTest.AutoSize = false;
            this.toolbtnTest.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Run;
            this.toolbtnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnTest.Name = "toolbtnTest";
            this.toolbtnTest.Size = new System.Drawing.Size(54, 24);
            this.toolbtnTest.Text = "测试";
            this.toolbtnTest.ToolTipText = "测试";
            this.toolbtnTest.Click += new System.EventHandler(this.toolbtnTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolbtnOK
            // 
            this.toolbtnOK.AutoSize = false;
            this.toolbtnOK.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.OK;
            this.toolbtnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnOK.Name = "toolbtnOK";
            this.toolbtnOK.Size = new System.Drawing.Size(54, 24);
            this.toolbtnOK.Text = "确定";
            this.toolbtnOK.Click += new System.EventHandler(this.toolbtnOK_Click);
            // 
            // toolbtnHelp
            // 
            this.toolbtnHelp.AutoSize = false;
            this.toolbtnHelp.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Help;
            this.toolbtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnHelp.Name = "toolbtnHelp";
            this.toolbtnHelp.Size = new System.Drawing.Size(54, 24);
            this.toolbtnHelp.Text = "帮助";
            this.toolbtnHelp.Click += new System.EventHandler(this.toolbtnHelp_Click);
            // 
            // toolbtnExit
            // 
            this.toolbtnExit.AutoSize = false;
            this.toolbtnExit.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Exit;
            this.toolbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExit.Name = "toolbtnExit";
            this.toolbtnExit.Size = new System.Drawing.Size(54, 24);
            this.toolbtnExit.Text = "关闭";
            this.toolbtnExit.Click += new System.EventHandler(this.toolbtnExit_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.dockPanel1.DockBackColor = System.Drawing.Color.Gray;
            this.dockPanel1.DocumentStyle = Heren.Common.DockSuite.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 28);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.ShowDocumentSubhead = true;
            this.dockPanel1.Size = new System.Drawing.Size(826, 479);
            this.dockPanel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblSystemStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(826, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblSystemStatus
            // 
            this.tsslblSystemStatus.Name = "tsslblSystemStatus";
            this.tsslblSystemStatus.Size = new System.Drawing.Size(811, 17);
            this.tsslblSystemStatus.Spring = true;
            this.tsslblSystemStatus.Text = "就绪";
            this.tsslblSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScriptDebugerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 529);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ScriptDebugerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "脚本调试器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnNew;
        private System.Windows.Forms.ToolStripButton toolbtnExamples;
        private System.Windows.Forms.ToolStripButton toolbtnOpen;
        private System.Windows.Forms.ToolStripButton toolbtnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnComment;
        private System.Windows.Forms.ToolStripButton toolbtnUncomment;
        private System.Windows.Forms.ToolStripButton toolbtnTest;
        private System.Windows.Forms.ToolStripButton toolbtnOK;
        private System.Windows.Forms.ToolStripButton toolbtnHelp;
        private System.Windows.Forms.ToolStripButton toolbtnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Heren.Common.DockSuite.DockPanel dockPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblSystemStatus;
    }
}

