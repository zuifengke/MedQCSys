namespace MedQCSys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new MedQCSys.MenuBars.MqsMainMenu();
            this.dockPanel1 = new Heren.Common.DockSuite.DockPanel();
            this.toolStrip1 = new MedQCSys.ToolBars.MainToolStrip();
            
            this.statusStrip1 = new MedQCSys.StatusBars.MainStatusStrip();
            this.logoPanel1 = new MedQCSys.Controls.LogoPanel();
            this.logoPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F);
            //this.menuStrip1.Font.Size = 9.5;
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MainForm = null;
            this.menuStrip1.Name = "menuStrip1";
           // this.menuStrip1.Padding = new System.Windows.Forms.Padding(1, 2, 0, 2);
           // this.menuStrip1.Size = new System.Drawing.Size(823, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "MqsMainMenu";
            // 
            // dockPanel1
            // 
            this.dockPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel1.DocumentStyle = Heren.Common.DockSuite.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 63);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.ShowDocumentSubhead = true;
            this.dockPanel1.ShowInactiveDocumentTab = false;
            this.dockPanel1.Size = new System.Drawing.Size(823, 432);
            this.dockPanel1.TabIndex = 0;
            this.dockPanel1.ActiveDocumentChanged += new System.EventHandler(this.dockPanel1_ActiveDocumentChanged);
            this.dockPanel1.ActiveContentChanged += new System.EventHandler(this.dockPanel1_ActiveContentChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(6, 30);
            this.toolStrip1.MainForm = null;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(404, 29);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "MainToolStrip";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.MainForm = null;
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 25);
            this.statusStrip1.TabIndex = 1;
            // 
            // logoPanel1
            // 
            this.logoPanel1.Controls.Add(this.menuStrip1);
            this.logoPanel1.Controls.Add(this.toolStrip1);
            this.logoPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel1.GradientBeginColor = System.Drawing.SystemColors.ButtonFace;
            this.logoPanel1.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.logoPanel1.Location = new System.Drawing.Point(0, 0);
            this.logoPanel1.LogoImage = global::MedQCSys.Properties.Resources.CompanyLogo;
            this.logoPanel1.Name = "logoPanel1";
            this.logoPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.logoPanel1.RowMargin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.logoPanel1.Size = new System.Drawing.Size(823, 63);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 520);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.logoPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "病案质控系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.logoPanel1.ResumeLayout(false);
            this.logoPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MedQCSys.MenuBars.MqsMainMenu menuStrip1;
        private Heren.Common.DockSuite.DockPanel dockPanel1;
        private MedQCSys.ToolBars.MainToolStrip toolStrip1;
        private MedQCSys.StatusBars.MainStatusStrip statusStrip1;
        private MedQCSys.Controls.LogoPanel logoPanel1;
    }
}

