namespace Heren.MedQC.ScriptEngine.FindReplace
{
    partial class FindReplaceForm
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
            this.btnFind = new Heren.Common.Controls.HerenButton();
            this.chkCheckAllTemple = new System.Windows.Forms.CheckBox();
            this.lblFindText = new System.Windows.Forms.Label();
            this.txtFindText = new System.Windows.Forms.TextBox();
            this.lblReplaceText = new System.Windows.Forms.Label();
            this.txtReplaceText = new System.Windows.Forms.TextBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.btnReplace = new Heren.Common.Controls.HerenButton();
            this.btnReplaceAll = new Heren.Common.Controls.HerenButton();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(381, 71);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(95, 24);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // chkCheckAllTemple
            // 
            this.chkCheckAllTemple.AutoSize = true;
            this.chkCheckAllTemple.Location = new System.Drawing.Point(272, 76);
            this.chkCheckAllTemple.Name = "chkCheckAllTemple";
            this.chkCheckAllTemple.Size = new System.Drawing.Size(96, 16);
            this.chkCheckAllTemple.TabIndex = 8;
            this.chkCheckAllTemple.Text = "查找所有模板";
            this.chkCheckAllTemple.UseVisualStyleBackColor = true;
            // 
            // lblFindText
            // 
            this.lblFindText.AutoSize = true;
            this.lblFindText.Location = new System.Drawing.Point(12, 17);
            this.lblFindText.Name = "lblFindText";
            this.lblFindText.Size = new System.Drawing.Size(65, 12);
            this.lblFindText.TabIndex = 0;
            this.lblFindText.Text = "查找内容：";
            // 
            // txtFindText
            // 
            this.txtFindText.Enabled = false;
            this.txtFindText.Location = new System.Drawing.Point(80, 12);
            this.txtFindText.Name = "txtFindText";
            this.txtFindText.Size = new System.Drawing.Size(408, 21);
            this.txtFindText.TabIndex = 1;
            this.txtFindText.TextChanged += new System.EventHandler(this.txtFindText_TextChanged);
            // 
            // lblReplaceText
            // 
            this.lblReplaceText.AutoSize = true;
            this.lblReplaceText.Location = new System.Drawing.Point(12, 46);
            this.lblReplaceText.Name = "lblReplaceText";
            this.lblReplaceText.Size = new System.Drawing.Size(53, 12);
            this.lblReplaceText.TabIndex = 2;
            this.lblReplaceText.Text = "替换为：";
            // 
            // txtReplaceText
            // 
            this.txtReplaceText.Enabled = false;
            this.txtReplaceText.Location = new System.Drawing.Point(80, 41);
            this.txtReplaceText.Name = "txtReplaceText";
            this.txtReplaceText.Size = new System.Drawing.Size(408, 21);
            this.txtReplaceText.TabIndex = 3;
            this.txtReplaceText.TextChanged += new System.EventHandler(this.txtReplaceText_TextChanged);
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(182, 76);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(84, 16);
            this.chkMatchCase.TabIndex = 4;
            this.chkMatchCase.Text = "区分大小写";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // btnReplace
            // 
            this.btnReplace.Enabled = false;
            this.btnReplace.Location = new System.Drawing.Point(381, 101);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(95, 24);
            this.btnReplace.TabIndex = 6;
            this.btnReplace.Text = "替换(&R)";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Enabled = false;
            this.btnReplaceAll.Location = new System.Drawing.Point(269, 101);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(95, 24);
            this.btnReplaceAll.TabIndex = 7;
            this.btnReplaceAll.Text = "全部替换(&A)";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // FindReplaceForm
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(514, 142);
            this.Controls.Add(this.chkCheckAllTemple);
            this.Controls.Add(this.lblFindText);
            this.Controls.Add(this.txtFindText);
            this.Controls.Add(this.lblReplaceText);
            this.Controls.Add(this.txtReplaceText);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnReplaceAll);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FindReplaceForm";
            this.Text = "查找和替换";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFindText;
        private System.Windows.Forms.TextBox txtFindText;
        private System.Windows.Forms.Label lblReplaceText;
        private System.Windows.Forms.TextBox txtReplaceText;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private Heren.Common.Controls.HerenButton btnFind;
        private Heren.Common.Controls.HerenButton btnReplace;
        private Heren.Common.Controls.HerenButton btnReplaceAll;
        private System.Windows.Forms.CheckBox chkCheckAllTemple;
    }
}