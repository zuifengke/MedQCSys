namespace Heren.MedQC.Hdp
{
    partial class LargeTextEditForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbxMacroList = new System.Windows.Forms.ListBox();
            this.lblMacroList = new System.Windows.Forms.Label();
            this.lblTextContent = new System.Windows.Forms.Label();
            this.txtLargeText = new System.Windows.Forms.RichTextBox();
            this.btnOK = new Heren.Common.Controls.HerenButton();
            this.btnCancel = new Heren.Common.Controls.HerenButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbxMacroList);
            this.splitContainer1.Panel1.Controls.Add(this.lblMacroList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblTextContent);
            this.splitContainer1.Panel2.Controls.Add(this.txtLargeText);
            this.splitContainer1.Size = new System.Drawing.Size(545, 299);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbxMacroList
            // 
            this.lbxMacroList.AllowDrop = true;
            this.lbxMacroList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxMacroList.FormattingEnabled = true;
            this.lbxMacroList.IntegralHeight = false;
            this.lbxMacroList.ItemHeight = 12;
            this.lbxMacroList.Location = new System.Drawing.Point(2, 20);
            this.lbxMacroList.Name = "lbxMacroList";
            this.lbxMacroList.Size = new System.Drawing.Size(167, 278);
            this.lbxMacroList.TabIndex = 1;
            this.lbxMacroList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxMacroList_MouseDoubleClick);
            // 
            // lblMacroList
            // 
            this.lblMacroList.AutoSize = true;
            this.lblMacroList.Location = new System.Drawing.Point(3, 5);
            this.lblMacroList.Name = "lblMacroList";
            this.lblMacroList.Size = new System.Drawing.Size(77, 12);
            this.lblMacroList.TabIndex = 0;
            this.lblMacroList.Text = "可用的宏列表";
            // 
            // lblTextContent
            // 
            this.lblTextContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextContent.Location = new System.Drawing.Point(3, 5);
            this.lblTextContent.Name = "lblTextContent";
            this.lblTextContent.Size = new System.Drawing.Size(365, 12);
            this.lblTextContent.TabIndex = 0;
            this.lblTextContent.Text = "编辑文本内容";
            // 
            // txtLargeText
            // 
            this.txtLargeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLargeText.DetectUrls = false;
            this.txtLargeText.HideSelection = false;
            this.txtLargeText.Location = new System.Drawing.Point(0, 19);
            this.txtLargeText.MaxLength = 4000;
            this.txtLargeText.Name = "txtLargeText";
            this.txtLargeText.Size = new System.Drawing.Size(370, 279);
            this.txtLargeText.TabIndex = 1;
            this.txtLargeText.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(146, 313);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(313, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // LargeTextEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(545, 352);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LargeTextEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑长文本";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblMacroList;
        private System.Windows.Forms.ListBox lbxMacroList;
        private System.Windows.Forms.Label lblTextContent;
        private System.Windows.Forms.RichTextBox txtLargeText;
        private Heren.Common.Controls.HerenButton btnOK;
        private Heren.Common.Controls.HerenButton btnCancel;
    }
}