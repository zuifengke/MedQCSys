namespace Heren.MedQC.Utilities.Dialogs
{
    partial class DeptSelectDialog
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
            this.cboDeptType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDeptFind = new Heren.Common.Controls.DictInput.FindComboBox();
            this.listView1 = new Heren.Common.Controls.ListViewControl();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.btnOK = new Heren.Common.Controls.HerenButton();
            this.btnCancel = new Heren.Common.Controls.HerenButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室类型：";
            // 
            // cboDeptType
            // 
            this.cboDeptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptType.FormattingEnabled = true;
            this.cboDeptType.Items.AddRange(new object[] {
            "住院科室"});
            this.cboDeptType.Location = new System.Drawing.Point(69, 4);
            this.cboDeptType.Name = "cboDeptType";
            this.cboDeptType.Size = new System.Drawing.Size(125, 20);
            this.cboDeptType.TabIndex = 1;
            this.cboDeptType.SelectedIndexChanged += new System.EventHandler(this.cboDeptType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "简拼查找：";
            // 
            // cboDeptFind
            // 
            this.cboDeptFind.Location = new System.Drawing.Point(267, 4);
            this.cboDeptFind.Name = "cboDeptFind";
            this.cboDeptFind.Size = new System.Drawing.Size(156, 20);
            this.cboDeptFind.TabIndex = 3;
            this.cboDeptFind.SelectedIndexChanged += new System.EventHandler(this.cboDeptFind_SelectedIndexChanged);
            this.cboDeptFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDeptFind_KeyDown);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(2, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(502, 254);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(6, 294);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(126, 16);
            this.chkCheckAll.TabIndex = 5;
            this.chkCheckAll.Text = "勾选/取消勾选所有";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(332, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(419, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DeptSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(506, 318);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDeptType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboDeptFind);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.chkCheckAll);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeptSelectDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "科室选择";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDeptType;
        private System.Windows.Forms.Label label2;
        private Heren.Common.Controls.DictInput.FindComboBox cboDeptFind;
        private Heren.Common.Controls.ListViewControl listView1;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private Heren.Common.Controls.HerenButton btnOK;
        private Heren.Common.Controls.HerenButton btnCancel;
    }
}