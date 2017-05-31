namespace Heren.MedQC.CheckPoint
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button3 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.colDebug = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colHandlerCommand = new Heren.Common.Forms.XFindComboBoxColumn();
            this.colCheckPointID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckType = new Heren.Common.Forms.XComboBoxColumn();
            this.colQaEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMsgDictMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckPointContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWrittenPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsRepeat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsValid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQCScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVisitID = new System.Windows.Forms.TextBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.col_4_MsgDictMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_4_QcResult = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colQcExplain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "单患者所有规则执行检查";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(12, 55);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 0;
            this.button11.Text = "刷新";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 24;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDebug,
            this.colHandlerCommand,
            this.colCheckPointID,
            this.colCheckType,
            this.colQaEventType,
            this.colMsgDictMessage,
            this.colCheckPointContent,
            this.colEvent,
            this.colDocType,
            this.colWrittenPeriod,
            this.colIsRepeat,
            this.colIsValid,
            this.colQCScore,
            this.colExpression});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 36;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(1004, 377);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colDebug
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "调试";
            this.colDebug.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDebug.HeaderText = "";
            this.colDebug.Name = "colDebug";
            this.colDebug.Text = "调试";
            this.colDebug.Width = 50;
            // 
            // colHandlerCommand
            // 
            this.colHandlerCommand.CandidateWidth = 250;
            this.colHandlerCommand.HeaderText = "处理命令";
            this.colHandlerCommand.Name = "colHandlerCommand";
            this.colHandlerCommand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHandlerCommand.Width = 200;
            // 
            // colCheckPointID
            // 
            this.colCheckPointID.FillWeight = 130F;
            this.colCheckPointID.HeaderText = "规则编号";
            this.colCheckPointID.Name = "colCheckPointID";
            this.colCheckPointID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCheckType
            // 
            this.colCheckType.HeaderText = "检查类型";
            this.colCheckType.Items.Add("合理性");
            this.colCheckType.Items.Add("一致性");
            this.colCheckType.Items.Add("周期性");
            this.colCheckType.Items.Add("时效性");
            this.colCheckType.Items.Add("完整性");
            this.colCheckType.Name = "colCheckType";
            this.colCheckType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheckType.Width = 80;
            // 
            // colQaEventType
            // 
            this.colQaEventType.HeaderText = "内容分类";
            this.colQaEventType.Name = "colQaEventType";
            this.colQaEventType.Width = 150;
            // 
            // colMsgDictMessage
            // 
            this.colMsgDictMessage.HeaderText = "缺陷内容";
            this.colMsgDictMessage.Name = "colMsgDictMessage";
            this.colMsgDictMessage.Width = 400;
            // 
            // colCheckPointContent
            // 
            this.colCheckPointContent.FillWeight = 350F;
            this.colCheckPointContent.HeaderText = "核查方法";
            this.colCheckPointContent.Name = "colCheckPointContent";
            this.colCheckPointContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCheckPointContent.Width = 600;
            // 
            // colEvent
            // 
            this.colEvent.HeaderText = "相关事件";
            this.colEvent.Name = "colEvent";
            this.colEvent.ReadOnly = true;
            this.colEvent.Width = 80;
            // 
            // colDocType
            // 
            this.colDocType.FillWeight = 240F;
            this.colDocType.HeaderText = "相关病历";
            this.colDocType.Name = "colDocType";
            this.colDocType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colWrittenPeriod
            // 
            this.colWrittenPeriod.FillWeight = 60F;
            this.colWrittenPeriod.HeaderText = "完成时限";
            this.colWrittenPeriod.Name = "colWrittenPeriod";
            this.colWrittenPeriod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWrittenPeriod.Width = 80;
            // 
            // colIsRepeat
            // 
            this.colIsRepeat.FillWeight = 50F;
            this.colIsRepeat.HeaderText = "循环的";
            this.colIsRepeat.Name = "colIsRepeat";
            this.colIsRepeat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsRepeat.Width = 80;
            // 
            // colIsValid
            // 
            this.colIsValid.FillWeight = 50F;
            this.colIsValid.HeaderText = "有效的";
            this.colIsValid.Name = "colIsValid";
            this.colIsValid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsValid.Width = 80;
            // 
            // colQCScore
            // 
            this.colQCScore.FillWeight = 350F;
            this.colQCScore.HeaderText = "质控扣分";
            this.colQCScore.Name = "colQCScore";
            this.colQCScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQCScore.Width = 80;
            // 
            // colExpression
            // 
            this.colExpression.HeaderText = "计算表达式";
            this.colExpression.Name = "colExpression";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "PatientID:";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(84, 20);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(145, 21);
            this.txtPatientID.TabIndex = 4;
            this.txtPatientID.Text = "P099634";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "VisitID:";
            // 
            // txtVisitID
            // 
            this.txtVisitID.Location = new System.Drawing.Point(303, 20);
            this.txtVisitID.Name = "txtVisitID";
            this.txtVisitID.Size = new System.Drawing.Size(145, 21);
            this.txtVisitID.TabIndex = 4;
            this.txtVisitID.Text = "1";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_4_MsgDictMessage,
            this.col_4_QcResult,
            this.colQcExplain});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridView4.RowTemplate.Height = 23;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(1004, 25);
            this.dataGridView4.TabIndex = 32;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // col_4_MsgDictMessage
            // 
            this.col_4_MsgDictMessage.HeaderText = "缺陷名称";
            this.col_4_MsgDictMessage.Name = "col_4_MsgDictMessage";
            this.col_4_MsgDictMessage.ReadOnly = true;
            this.col_4_MsgDictMessage.Width = 400;
            // 
            // col_4_QcResult
            // 
            this.col_4_QcResult.HeaderText = "系统检测";
            this.col_4_QcResult.Name = "col_4_QcResult";
            this.col_4_QcResult.ReadOnly = true;
            this.col_4_QcResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_4_QcResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_4_QcResult.Width = 90;
            // 
            // colQcExplain
            // 
            this.colQcExplain.HeaderText = "提示语句";
            this.colQcExplain.Name = "colQcExplain";
            this.colQcExplain.ReadOnly = true;
            this.colQcExplain.Width = 500;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView4);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 406);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(12, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 406);
            this.panel1.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "耗时：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 502);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtVisitID);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button11);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button11;
        private Common.Controls.TableView.DataTableView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVisitID;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_4_MsgDictMessage;
        private System.Windows.Forms.DataGridViewLinkColumn col_4_QcResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQcExplain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn colDebug;
        private Common.Forms.XFindComboBoxColumn colHandlerCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckPointID;
        private Common.Forms.XComboBoxColumn colCheckType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQaEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsgDictMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckPointContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWrittenPeriod;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsRepeat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsValid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQCScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpression;
    }
}