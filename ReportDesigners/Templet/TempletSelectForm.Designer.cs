namespace Designers.Templet
{
    partial class TempletSelectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempletSelectForm));
            this.lblTipInfo = new System.Windows.Forms.Label();
            this.lblApplyEnv = new System.Windows.Forms.Label();
            this.cboApplyEnv = new System.Windows.Forms.ComboBox();
            this.treeView1 = new Heren.Common.Controls.TreeViewControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.btnOK = new Heren.Common.Controls.HerenButton();
            this.btnCancel = new Heren.Common.Controls.HerenButton();
            this.SuspendLayout();
            // 
            // lblTipInfo
            // 
            this.lblTipInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipInfo.AutoEllipsis = true;
            this.lblTipInfo.Location = new System.Drawing.Point(1, 3);
            this.lblTipInfo.Name = "lblTipInfo";
            this.lblTipInfo.Size = new System.Drawing.Size(308, 18);
            this.lblTipInfo.TabIndex = 0;
            this.lblTipInfo.Text = "请选择模板";
            this.lblTipInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplyEnv
            // 
            this.lblApplyEnv.AutoEllipsis = true;
            this.lblApplyEnv.Location = new System.Drawing.Point(1, 25);
            this.lblApplyEnv.Name = "lblApplyEnv";
            this.lblApplyEnv.Size = new System.Drawing.Size(67, 18);
            this.lblApplyEnv.TabIndex = 1;
            this.lblApplyEnv.Text = "应用环境：";
            this.lblApplyEnv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboApplyEnv
            // 
            this.cboApplyEnv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboApplyEnv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApplyEnv.Location = new System.Drawing.Point(68, 24);
            this.cboApplyEnv.MaxDropDownItems = 24;
            this.cboApplyEnv.Name = "cboApplyEnv";
            this.cboApplyEnv.Size = new System.Drawing.Size(133, 20);
            this.cboApplyEnv.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 16;
            this.treeView1.Location = new System.Drawing.Point(2, 48);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(310, 397);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FolderClose.png");
            this.imageList1.Images.SetKeyName(1, "FolderOpen.png");
            this.imageList1.Images.SetKeyName(2, "Templet.png");
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(12, 462);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(72, 16);
            this.chkCheckAll.TabIndex = 4;
            this.chkCheckAll.Text = "勾选所有";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(113, 455);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 28);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(214, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TempletSelectForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(314, 491);
            this.Controls.Add(this.lblTipInfo);
            this.Controls.Add(this.lblApplyEnv);
            this.Controls.Add(this.cboApplyEnv);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.chkCheckAll);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TempletSelectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择模板";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipInfo;
        private System.Windows.Forms.Label lblApplyEnv;
        private System.Windows.Forms.ComboBox cboApplyEnv;
        private Heren.Common.Controls.TreeViewControl treeView1;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private Heren.Common.Controls.HerenButton btnOK;
        private Heren.Common.Controls.HerenButton btnCancel;
        private System.Windows.Forms.ImageList imageList1;
    }
}