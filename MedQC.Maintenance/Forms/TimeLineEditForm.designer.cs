namespace Heren.MedQC.Maintenance
{
    partial class TimeLineEditForm
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
            this.nudTimeLineValue = new System.Windows.Forms.NumericUpDown();
            this.cboTimeLineType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new Heren.Common.Controls.HerenButton();
            this.btnOK = new Heren.Common.Controls.HerenButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeLineValue)).BeginInit();
            this.SuspendLayout();
            // 
            // nudTimeLineValue
            // 
            this.nudTimeLineValue.Location = new System.Drawing.Point(74, 34);
            this.nudTimeLineValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudTimeLineValue.Name = "nudTimeLineValue";
            this.nudTimeLineValue.Size = new System.Drawing.Size(72, 21);
            this.nudTimeLineValue.TabIndex = 0;
            // 
            // cboTimeLineType
            // 
            this.cboTimeLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeLineType.FormattingEnabled = true;
            this.cboTimeLineType.Items.AddRange(new object[] {
            "月",
            "天",
            "小时"});
            this.cboTimeLineType.Location = new System.Drawing.Point(153, 35);
            this.cboTimeLineType.Name = "cboTimeLineType";
            this.cboTimeLineType.Size = new System.Drawing.Size(67, 20);
            this.cboTimeLineType.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(172, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(38, 77);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 28);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TimeLineEditForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 124);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboTimeLineType);
            this.Controls.Add(this.nudTimeLineValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeLineEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑病历书写时间限";
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeLineValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudTimeLineValue;
        private System.Windows.Forms.ComboBox cboTimeLineType;
        private Heren.Common.Controls.HerenButton btnCancel;
        private Heren.Common.Controls.HerenButton btnOK;
    }
}