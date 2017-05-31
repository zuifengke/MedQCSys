namespace Heren.MedQC.Maintenance
{
    partial class SqlConditionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboPropertyType = new System.Windows.Forms.ComboBox();
            this.lbxPropertyList = new System.Windows.Forms.ListBox();
            this.btnLeftToRight = new Heren.Common.Controls.FlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBindProperties = new System.Windows.Forms.RichTextBox();
            this.btnOK = new Heren.Common.Controls.HerenButton();
            this.btnCancel = new Heren.Common.Controls.HerenButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "待选择的属性：";
            // 
            // cboPropertyType
            // 
            this.cboPropertyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPropertyType.FormattingEnabled = true;
            this.cboPropertyType.Location = new System.Drawing.Point(12, 30);
            this.cboPropertyType.Name = "cboPropertyType";
            this.cboPropertyType.Size = new System.Drawing.Size(189, 20);
            this.cboPropertyType.TabIndex = 17;
            this.cboPropertyType.SelectedIndexChanged += new System.EventHandler(this.cboPropertyType_SelectedIndexChanged);
            // 
            // lbxPropertyList
            // 
            this.lbxPropertyList.AllowDrop = true;
            this.lbxPropertyList.FormattingEnabled = true;
            this.lbxPropertyList.ItemHeight = 12;
            this.lbxPropertyList.Location = new System.Drawing.Point(12, 54);
            this.lbxPropertyList.Name = "lbxPropertyList";
            this.lbxPropertyList.Size = new System.Drawing.Size(189, 196);
            this.lbxPropertyList.TabIndex = 10;
            this.lbxPropertyList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxPropertyList_MouseDoubleClick);
            // 
            // btnLeftToRight
            // 
            this.btnLeftToRight.Location = new System.Drawing.Point(211, 122);
            this.btnLeftToRight.Name = "btnLeftToRight";
            this.btnLeftToRight.Size = new System.Drawing.Size(32, 32);
            this.btnLeftToRight.TabIndex = 12;
            this.btnLeftToRight.ToolTipText = null;
            this.btnLeftToRight.Click += new System.EventHandler(this.btnLeftToRight_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "已添加为条件的属性：";
            // 
            // txtBindProperties
            // 
            this.txtBindProperties.Location = new System.Drawing.Point(253, 30);
            this.txtBindProperties.MaxLength = 200;
            this.txtBindProperties.Name = "txtBindProperties";
            this.txtBindProperties.Size = new System.Drawing.Size(197, 220);
            this.txtBindProperties.TabIndex = 15;
            this.txtBindProperties.Text = "";
            this.txtBindProperties.WordWrap = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(101, 261);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 28);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(268, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SqlConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(462, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPropertyType);
            this.Controls.Add(this.lbxPropertyList);
            this.Controls.Add(this.btnLeftToRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBindProperties);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlConditionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑查询条件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPropertyType;
        private System.Windows.Forms.ListBox lbxPropertyList;
        private Heren.Common.Controls.FlatButton btnLeftToRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtBindProperties;
        private Heren.Common.Controls.HerenButton btnOK;
        private Heren.Common.Controls.HerenButton btnCancel;
    }
}