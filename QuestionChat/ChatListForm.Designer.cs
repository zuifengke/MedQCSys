namespace Heren.MedQC.QuestionChat
{
    partial class ChatListForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatListForm));
            this.lblTaskTip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fbtnRefresh = new Heren.Common.Controls.FlatButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colChatSendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChatContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListener = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsRead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fbtnSetting = new Heren.Common.Controls.FlatButton();
            this.chkSearch = new System.Windows.Forms.CheckBox();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.lblread = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTaskTip
            // 
            this.lblTaskTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTaskTip.Location = new System.Drawing.Point(7, 450);
            this.lblTaskTip.Name = "lblTaskTip";
            this.lblTaskTip.Size = new System.Drawing.Size(619, 15);
            this.lblTaskTip.TabIndex = 2;
            this.lblTaskTip.Text = "系统共收到0条消息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(-1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "[未读的信息列表]：是临床医生和质控质控沟通列表";
            // 
            // fbtnRefresh
            // 
            this.fbtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnRefresh.Image = global::Heren.MedQC.QuestionChat.Properties.Resources.Refresh;
            this.fbtnRefresh.Location = new System.Drawing.Point(836, 446);
            this.fbtnRefresh.Name = "fbtnRefresh";
            this.fbtnRefresh.Size = new System.Drawing.Size(80, 22);
            this.fbtnRefresh.TabIndex = 6;
            this.fbtnRefresh.Text = "刷新";
            this.fbtnRefresh.ToolTipText = null;
            this.fbtnRefresh.Click += new System.EventHandler(this.fbtnRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChatSendDate,
            this.colChatContent,
            this.colSender,
            this.colListener,
            this.colIsRead});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(1, 24);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(914, 418);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // colChatSendDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChatSendDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChatSendDate.HeaderText = "发送时间";
            this.colChatSendDate.Name = "colChatSendDate";
            this.colChatSendDate.ReadOnly = true;
            this.colChatSendDate.Width = 160;
            // 
            // colChatContent
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChatContent.DefaultCellStyle = dataGridViewCellStyle3;
            this.colChatContent.HeaderText = "消息内容";
            this.colChatContent.Name = "colChatContent";
            this.colChatContent.ReadOnly = true;
            this.colChatContent.Width = 400;
            // 
            // colSender
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSender.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSender.FillWeight = 200F;
            this.colSender.HeaderText = "发送人";
            this.colSender.Name = "colSender";
            this.colSender.ReadOnly = true;
            this.colSender.Width = 120;
            // 
            // colListener
            // 
            this.colListener.HeaderText = "接收人";
            this.colListener.Name = "colListener";
            this.colListener.ReadOnly = true;
            this.colListener.Width = 120;
            // 
            // colIsRead
            // 
            this.colIsRead.HeaderText = "是否已读";
            this.colIsRead.Name = "colIsRead";
            this.colIsRead.ReadOnly = true;
            // 
            // fbtnSetting
            // 
            this.fbtnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fbtnSetting.Image = global::Heren.MedQC.QuestionChat.Properties.Resources.System;
            this.fbtnSetting.Location = new System.Drawing.Point(750, 446);
            this.fbtnSetting.Name = "fbtnSetting";
            this.fbtnSetting.Size = new System.Drawing.Size(80, 22);
            this.fbtnSetting.TabIndex = 6;
            this.fbtnSetting.Text = "设置";
            this.fbtnSetting.ToolTipText = null;
            this.fbtnSetting.Click += new System.EventHandler(this.fbtnSetting_Click);
            // 
            // chkSearch
            // 
            this.chkSearch.AutoSize = true;
            this.chkSearch.Location = new System.Drawing.Point(326, 4);
            this.chkSearch.Name = "chkSearch";
            this.chkSearch.Size = new System.Drawing.Size(72, 16);
            this.chkSearch.TabIndex = 7;
            this.chkSearch.Text = "查找已读";
            this.chkSearch.UseVisualStyleBackColor = true;
            this.chkSearch.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(414, 2);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(103, 21);
            this.dtpBeginTime.TabIndex = 8;
            this.dtpBeginTime.Visible = false;
            // 
            // lblread
            // 
            this.lblread.AutoSize = true;
            this.lblread.Location = new System.Drawing.Point(524, 4);
            this.lblread.Name = "lblread";
            this.lblread.Size = new System.Drawing.Size(17, 12);
            this.lblread.TabIndex = 9;
            this.lblread.Text = "至";
            this.lblread.Visible = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(547, 2);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(103, 21);
            this.dtpEndTime.TabIndex = 8;
            this.dtpEndTime.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(665, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ChatListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 469);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblread);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.dtpBeginTime);
            this.Controls.Add(this.chkSearch);
            this.Controls.Add(this.fbtnSetting);
            this.Controls.Add(this.fbtnRefresh);
            this.Controls.Add(this.lblTaskTip);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控问题消息列表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTaskTip;
        private System.Windows.Forms.Label label1;
        private Heren.Common.Controls.FlatButton fbtnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChatSendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChatContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListener;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsRead;
        private Heren.Common.Controls.FlatButton fbtnSetting;
        private System.Windows.Forms.CheckBox chkSearch;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.Label lblread;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Button btnSearch;
    }
}