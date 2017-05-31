namespace MedQCSys.Dialogs
{
    partial class ModifyNoticeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyNoticeForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_MODIFY_PERIOD = new System.Windows.Forms.ComboBox();
            this.herenButton2 = new Heren.Common.Controls.HerenButton();
            this.lbl_NOTICE_STATUS = new System.Windows.Forms.Label();
            this.herenButton1 = new Heren.Common.Controls.HerenButton();
            this.lbl_QC_DEPT_NAME = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_MODIFY_REMARK = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_MSG_DICT_MESSAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SCORE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ERROR_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_QA_EVENT_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_QC_LEVEL = new System.Windows.Forms.Label();
            this.lbl_RECEIVER_DEPT_NAME = new System.Windows.Forms.Label();
            this.lbl_QC_MAN = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_MODIFY_SCORE = new System.Windows.Forms.Label();
            this.lbl_RECEIVER = new System.Windows.Forms.Label();
            this.lbl_NOTICE_TIME = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_MODIFY_PERIOD);
            this.panel1.Controls.Add(this.herenButton2);
            this.panel1.Controls.Add(this.lbl_NOTICE_STATUS);
            this.panel1.Controls.Add(this.herenButton1);
            this.panel1.Controls.Add(this.lbl_QC_DEPT_NAME);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rtb_MODIFY_REMARK);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.dataTableView1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbl_QC_LEVEL);
            this.panel1.Controls.Add(this.lbl_RECEIVER_DEPT_NAME);
            this.panel1.Controls.Add(this.lbl_QC_MAN);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_MODIFY_SCORE);
            this.panel1.Controls.Add(this.lbl_RECEIVER);
            this.panel1.Controls.Add(this.lbl_NOTICE_TIME);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 461);
            this.panel1.TabIndex = 0;
            // 
            // cbo_MODIFY_PERIOD
            // 
            this.cbo_MODIFY_PERIOD.FormattingEnabled = true;
            this.cbo_MODIFY_PERIOD.Items.AddRange(new object[] {
            "1 天",
            "2 天"});
            this.cbo_MODIFY_PERIOD.Location = new System.Drawing.Point(550, 92);
            this.cbo_MODIFY_PERIOD.Name = "cbo_MODIFY_PERIOD";
            this.cbo_MODIFY_PERIOD.Size = new System.Drawing.Size(74, 20);
            this.cbo_MODIFY_PERIOD.TabIndex = 2;
            this.cbo_MODIFY_PERIOD.Text = "1 天";
            // 
            // herenButton2
            // 
            this.herenButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.herenButton2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.herenButton2.Location = new System.Drawing.Point(541, 426);
            this.herenButton2.Name = "herenButton2";
            this.herenButton2.Size = new System.Drawing.Size(87, 23);
            this.herenButton2.TabIndex = 3;
            this.herenButton2.Text = "关闭";
            this.herenButton2.UseVisualStyleBackColor = true;
            this.herenButton2.Click += new System.EventHandler(this.herenButton2_Click);
            // 
            // lbl_NOTICE_STATUS
            // 
            this.lbl_NOTICE_STATUS.AutoSize = true;
            this.lbl_NOTICE_STATUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_NOTICE_STATUS.Location = new System.Drawing.Point(547, 69);
            this.lbl_NOTICE_STATUS.Name = "lbl_NOTICE_STATUS";
            this.lbl_NOTICE_STATUS.Size = new System.Drawing.Size(35, 14);
            this.lbl_NOTICE_STATUS.TabIndex = 1;
            this.lbl_NOTICE_STATUS.Text = "草稿";
            // 
            // herenButton1
            // 
            this.herenButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.herenButton1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.herenButton1.Location = new System.Drawing.Point(422, 425);
            this.herenButton1.Name = "herenButton1";
            this.herenButton1.Size = new System.Drawing.Size(116, 23);
            this.herenButton1.TabIndex = 3;
            this.herenButton1.Text = "发送整改通知";
            this.herenButton1.UseVisualStyleBackColor = true;
            this.herenButton1.Click += new System.EventHandler(this.herenButton1_Click);
            // 
            // lbl_QC_DEPT_NAME
            // 
            this.lbl_QC_DEPT_NAME.AutoSize = true;
            this.lbl_QC_DEPT_NAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QC_DEPT_NAME.Location = new System.Drawing.Point(547, 44);
            this.lbl_QC_DEPT_NAME.Name = "lbl_QC_DEPT_NAME";
            this.lbl_QC_DEPT_NAME.Size = new System.Drawing.Size(77, 14);
            this.lbl_QC_DEPT_NAME.TabIndex = 1;
            this.lbl_QC_DEPT_NAME.Text = "消化科病房";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "整改备注：";
            // 
            // rtb_MODIFY_REMARK
            // 
            this.rtb_MODIFY_REMARK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_MODIFY_REMARK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_MODIFY_REMARK.Location = new System.Drawing.Point(2, 346);
            this.rtb_MODIFY_REMARK.Name = "rtb_MODIFY_REMARK";
            this.rtb_MODIFY_REMARK.Size = new System.Drawing.Size(628, 73);
            this.rtb_MODIFY_REMARK.TabIndex = 2;
            this.rtb_MODIFY_REMARK.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(468, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 14);
            this.label17.TabIndex = 1;
            this.label17.Text = "整改期限：";
            // 
            // dataTableView1
            // 
            this.dataTableView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MSG_DICT_MESSAGE,
            this.col_SCORE,
            this.col_ERROR_COUNT,
            this.col_QA_EVENT_TYPE});
            this.dataTableView1.Location = new System.Drawing.Point(3, 118);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTableView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataTableView1.RowHeadersVisible = false;
            this.dataTableView1.Size = new System.Drawing.Size(630, 202);
            this.dataTableView1.TabIndex = 1;
            // 
            // col_MSG_DICT_MESSAGE
            // 
            this.col_MSG_DICT_MESSAGE.HeaderText = "项目";
            this.col_MSG_DICT_MESSAGE.Name = "col_MSG_DICT_MESSAGE";
            this.col_MSG_DICT_MESSAGE.ReadOnly = true;
            this.col_MSG_DICT_MESSAGE.Width = 330;
            // 
            // col_SCORE
            // 
            this.col_SCORE.HeaderText = "扣分标准";
            this.col_SCORE.Name = "col_SCORE";
            this.col_SCORE.ReadOnly = true;
            this.col_SCORE.Width = 85;
            // 
            // col_ERROR_COUNT
            // 
            this.col_ERROR_COUNT.HeaderText = "错误次数";
            this.col_ERROR_COUNT.Name = "col_ERROR_COUNT";
            this.col_ERROR_COUNT.ReadOnly = true;
            this.col_ERROR_COUNT.Width = 85;
            // 
            // col_QA_EVENT_TYPE
            // 
            this.col_QA_EVENT_TYPE.HeaderText = "病历主题";
            this.col_QA_EVENT_TYPE.Name = "col_QA_EVENT_TYPE";
            this.col_QA_EVENT_TYPE.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(468, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "状态：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(468, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "质控科室：";
            // 
            // lbl_QC_LEVEL
            // 
            this.lbl_QC_LEVEL.AutoSize = true;
            this.lbl_QC_LEVEL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QC_LEVEL.Location = new System.Drawing.Point(299, 92);
            this.lbl_QC_LEVEL.Name = "lbl_QC_LEVEL";
            this.lbl_QC_LEVEL.Size = new System.Drawing.Size(63, 14);
            this.lbl_QC_LEVEL.TabIndex = 1;
            this.lbl_QC_LEVEL.Text = "终末质控";
            // 
            // lbl_RECEIVER_DEPT_NAME
            // 
            this.lbl_RECEIVER_DEPT_NAME.AutoSize = true;
            this.lbl_RECEIVER_DEPT_NAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_RECEIVER_DEPT_NAME.Location = new System.Drawing.Point(299, 69);
            this.lbl_RECEIVER_DEPT_NAME.Name = "lbl_RECEIVER_DEPT_NAME";
            this.lbl_RECEIVER_DEPT_NAME.Size = new System.Drawing.Size(91, 14);
            this.lbl_RECEIVER_DEPT_NAME.TabIndex = 1;
            this.lbl_RECEIVER_DEPT_NAME.Text = "内分泌科病房";
            // 
            // lbl_QC_MAN
            // 
            this.lbl_QC_MAN.AutoSize = true;
            this.lbl_QC_MAN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_QC_MAN.Location = new System.Drawing.Point(299, 44);
            this.lbl_QC_MAN.Name = "lbl_QC_MAN";
            this.lbl_QC_MAN.Size = new System.Drawing.Size(35, 14);
            this.lbl_QC_MAN.TabIndex = 1;
            this.lbl_QC_MAN.Text = "张三";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(220, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 14);
            this.label15.TabIndex = 1;
            this.label15.Text = "质控级别：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(220, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "接收科室：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(220, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "质控人：";
            // 
            // lbl_MODIFY_SCORE
            // 
            this.lbl_MODIFY_SCORE.AutoSize = true;
            this.lbl_MODIFY_SCORE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MODIFY_SCORE.ForeColor = System.Drawing.Color.Red;
            this.lbl_MODIFY_SCORE.Location = new System.Drawing.Point(83, 92);
            this.lbl_MODIFY_SCORE.Name = "lbl_MODIFY_SCORE";
            this.lbl_MODIFY_SCORE.Size = new System.Drawing.Size(35, 14);
            this.lbl_MODIFY_SCORE.TabIndex = 1;
            this.lbl_MODIFY_SCORE.Text = "2 分";
            // 
            // lbl_RECEIVER
            // 
            this.lbl_RECEIVER.AutoSize = true;
            this.lbl_RECEIVER.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_RECEIVER.Location = new System.Drawing.Point(83, 69);
            this.lbl_RECEIVER.Name = "lbl_RECEIVER";
            this.lbl_RECEIVER.Size = new System.Drawing.Size(35, 14);
            this.lbl_RECEIVER.TabIndex = 1;
            this.lbl_RECEIVER.Text = "李四";
            // 
            // lbl_NOTICE_TIME
            // 
            this.lbl_NOTICE_TIME.AutoSize = true;
            this.lbl_NOTICE_TIME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_NOTICE_TIME.Location = new System.Drawing.Point(83, 44);
            this.lbl_NOTICE_TIME.Name = "lbl_NOTICE_TIME";
            this.lbl_NOTICE_TIME.Size = new System.Drawing.Size(77, 14);
            this.lbl_NOTICE_TIME.TabIndex = 1;
            this.lbl_NOTICE_TIME.Text = "1900-01-01";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(4, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 14);
            this.label13.TabIndex = 1;
            this.label13.Text = "整改扣分：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(4, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "接收人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "通知时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(222, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "病历整改通知书";
            // 
            // ModifyNoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 461);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModifyNoticeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病历整改通知";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_NOTICE_TIME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_QC_MAN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_NOTICE_STATUS;
        private System.Windows.Forms.Label lbl_QC_DEPT_NAME;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_QC_LEVEL;
        private System.Windows.Forms.Label lbl_RECEIVER_DEPT_NAME;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_MODIFY_SCORE;
        private System.Windows.Forms.Label lbl_RECEIVER;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbo_MODIFY_PERIOD;
        private Heren.Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtb_MODIFY_REMARK;
        private Heren.Common.Controls.HerenButton herenButton1;
        private Heren.Common.Controls.HerenButton herenButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MSG_DICT_MESSAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SCORE;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ERROR_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_QA_EVENT_TYPE;
    }
}