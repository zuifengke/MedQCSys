namespace MedQCSys.PatPage
{
    partial class PatientPageControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dockPanel1 = new Heren.Common.DockSuite.DockPanel();
            this.patientInfoStrip1 = new MedQCSys.PatPage.PatientInfoStrip();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel1.DocumentStyle = Heren.Common.DockSuite.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 32);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.ShowDocumentBorder = false;
            this.dockPanel1.ShowInactiveDocumentTab = false;
            this.dockPanel1.Size = new System.Drawing.Size(846, 412);
            this.dockPanel1.TabIndex = 1;
            this.dockPanel1.ActiveDocumentChanged += new System.EventHandler(this.dockPanel1_ActiveDocumentChanged);
            this.dockPanel1.ActiveContentChanged += new System.EventHandler(this.dockPanel1_ActiveContentChanged);
            // 
            // patientInfoStrip1
            // 
            this.patientInfoStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.patientInfoStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientInfoStrip1.Location = new System.Drawing.Point(0, 0);
            this.patientInfoStrip1.Name = "patientInfoStrip1";
            this.patientInfoStrip1.PatientPageControl = null;
            this.patientInfoStrip1.PatVisitInfo = null;
            this.patientInfoStrip1.Size = new System.Drawing.Size(846, 32);
            this.patientInfoStrip1.TabIndex = 0;
            // 
            // PatientPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.patientInfoStrip1);
            this.Name = "PatientPageControl";
            this.Size = new System.Drawing.Size(846, 444);
            this.ResumeLayout(false);

        }

        #endregion

        private PatientInfoStrip patientInfoStrip1;
        private Heren.Common.DockSuite.DockPanel dockPanel1;
    }
}
