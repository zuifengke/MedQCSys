namespace Heren.MedQC.HomePage.PageCards
{
    partial class BaseCard
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
            this.fbtnRefresh = new Heren.Common.Controls.FlatButton();
            this.fbtnExport = new Heren.Common.Controls.FlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mlinkTitle = new MetroFramework.Controls.MetroLink();
            this.fbtnDelete = new Heren.Common.Controls.FlatButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fbtnRefresh
            // 
            this.fbtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnRefresh.Location = new System.Drawing.Point(536, 0);
            this.fbtnRefresh.Name = "fbtnRefresh";
            this.fbtnRefresh.Size = new System.Drawing.Size(24, 24);
            this.fbtnRefresh.TabIndex = 1;
            this.fbtnRefresh.ToolTipText = "刷新";
            this.fbtnRefresh.Click += new System.EventHandler(this.fbtnRefresh_Click);
            // 
            // fbtnExport
            // 
            this.fbtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnExport.Location = new System.Drawing.Point(561, 0);
            this.fbtnExport.Name = "fbtnExport";
            this.fbtnExport.Size = new System.Drawing.Size(24, 24);
            this.fbtnExport.TabIndex = 1;
            this.fbtnExport.ToolTipText = "导出";
            this.fbtnExport.Click += new System.EventHandler(this.fbtnExport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fbtnDelete);
            this.panel1.Controls.Add(this.fbtnRefresh);
            this.panel1.Controls.Add(this.fbtnExport);
            this.panel1.Controls.Add(this.mlinkTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 27);
            this.panel1.TabIndex = 2;
            // 
            // mlinkTitle
            // 
            this.mlinkTitle.CustomBackground = false;
            this.mlinkTitle.CustomForeColor = false;
            this.mlinkTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlinkTitle.FontSize = MetroFramework.MetroLinkSize.Small;
            this.mlinkTitle.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.mlinkTitle.Location = new System.Drawing.Point(0, 0);
            this.mlinkTitle.Name = "mlinkTitle";
            this.mlinkTitle.Size = new System.Drawing.Size(609, 27);
            this.mlinkTitle.Style = MetroFramework.MetroColorStyle.Blue;
            this.mlinkTitle.StyleManager = null;
            this.mlinkTitle.TabIndex = 2;
            this.mlinkTitle.Text = "标题";
            this.mlinkTitle.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mlinkTitle.UseStyleColors = false;
            this.mlinkTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mlinkTitle_MouseDown);
            this.mlinkTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mlinkTitle_MouseMove);
            // 
            // fbtnDelete
            // 
            this.fbtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnDelete.Location = new System.Drawing.Point(586, 0);
            this.fbtnDelete.Name = "fbtnDelete";
            this.fbtnDelete.Size = new System.Drawing.Size(24, 24);
            this.fbtnDelete.TabIndex = 3;
            this.fbtnDelete.ToolTipText = "移除";
            this.fbtnDelete.Click += new System.EventHandler(this.fbtnDelete_Click);
            // 
            // BaseCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "BaseCard";
            this.Size = new System.Drawing.Size(609, 287);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Common.Controls.FlatButton fbtnRefresh;
        private Common.Controls.FlatButton fbtnExport;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLink mlinkTitle;
        private Common.Controls.FlatButton fbtnDelete;
    }
}
