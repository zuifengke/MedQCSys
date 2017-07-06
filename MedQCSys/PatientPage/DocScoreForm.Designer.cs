namespace MedQCSys.DockForms
{
    partial class DocScoreForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDocConten = new System.Windows.Forms.TabPage();
            this.dgvDocContent = new Heren.Common.Controls.TableView.DataTableView();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContentIsVeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHosPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpDocTimes = new System.Windows.Forms.TabPage();
            this.dgvDocTime = new Heren.Common.Controls.TableView.DataTableView();
            this.colDocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckBasic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQcTimeIsVeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimePoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtContentPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.picVetoDesc = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tpDocConten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocContent)).BeginInit();
            this.tpDocTimes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVetoDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpDocConten);
            this.tabControl1.Controls.Add(this.tpDocTimes);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 431);
            this.tabControl1.TabIndex = 0;
            // 
            // tpDocConten
            // 
            this.tpDocConten.Controls.Add(this.dgvDocContent);
            this.tpDocConten.Location = new System.Drawing.Point(4, 24);
            this.tpDocConten.Name = "tpDocConten";
            this.tpDocConten.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocConten.Size = new System.Drawing.Size(881, 403);
            this.tpDocConten.TabIndex = 0;
            this.tpDocConten.Text = "病历内容扣分";
            this.tpDocConten.UseVisualStyleBackColor = true;
            // 
            // dgvDocContent
            // 
            this.dgvDocContent.AllowUserToOrderColumns = true;
            this.dgvDocContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItem,
            this.colContentIsVeto,
            this.colPoint,
            this.colHosPoint});
            this.dgvDocContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocContent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDocContent.Location = new System.Drawing.Point(3, 3);
            this.dgvDocContent.MultiSelect = false;
            this.dgvDocContent.Name = "dgvDocContent";
            this.dgvDocContent.RowHeadersVisible = false;
            this.dgvDocContent.Size = new System.Drawing.Size(875, 397);
            this.dgvDocContent.TabIndex = 7;
            this.dgvDocContent.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocContent_CellValueChanged);
            this.dgvDocContent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocContent_CellClick);
            this.dgvDocContent.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDocContent_EditingControlShowing);
            // 
            // colItem
            // 
            this.colItem.FillWeight = 500F;
            this.colItem.HeaderText = "评定项目";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            this.colItem.Width = 500;
            // 
            // colContentIsVeto
            // 
            this.colContentIsVeto.HeaderText = "单项否决";
            this.colContentIsVeto.Name = "colContentIsVeto";
            this.colContentIsVeto.ReadOnly = true;
            // 
            // colPoint
            // 
            this.colPoint.HeaderText = "项目分值";
            this.colPoint.Name = "colPoint";
            this.colPoint.ReadOnly = true;
            // 
            // colHosPoint
            // 
            this.colHosPoint.HeaderText = "扣分";
            this.colHosPoint.Name = "colHosPoint";
            // 
            // tpDocTimes
            // 
            this.tpDocTimes.Controls.Add(this.dgvDocTime);
            this.tpDocTimes.Location = new System.Drawing.Point(4, 24);
            this.tpDocTimes.Name = "tpDocTimes";
            this.tpDocTimes.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocTimes.Size = new System.Drawing.Size(881, 403);
            this.tpDocTimes.TabIndex = 1;
            this.tpDocTimes.Text = "病历时效扣分";
            this.tpDocTimes.UseVisualStyleBackColor = true;
            // 
            // dgvDocTime
            // 
            this.dgvDocTime.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvDocTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDocName,
            this.colStatus,
            this.colCreator,
            this.colCreateTime,
            this.colEndTime,
            this.colCheckBasic,
            this.colQcTimeIsVeto,
            this.colDocPoint});
            this.dgvDocTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocTime.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDocTime.Location = new System.Drawing.Point(3, 3);
            this.dgvDocTime.MultiSelect = false;
            this.dgvDocTime.Name = "dgvDocTime";
            this.dgvDocTime.RowHeadersVisible = false;
            this.dgvDocTime.Size = new System.Drawing.Size(875, 397);
            this.dgvDocTime.TabIndex = 5;
            this.dgvDocTime.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocTime_CellValueChanged);
            this.dgvDocTime.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocTime_CellClick);
            this.dgvDocTime.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDocTime_EditingControlShowing);
            // 
            // colDocName
            // 
            this.colDocName.FillWeight = 120F;
            this.colDocName.HeaderText = "病历标题";
            this.colDocName.Name = "colDocName";
            this.colDocName.ReadOnly = true;
            this.colDocName.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 90F;
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 90;
            // 
            // colCreator
            // 
            this.colCreator.FillWeight = 56F;
            this.colCreator.HeaderText = "作者";
            this.colCreator.Name = "colCreator";
            this.colCreator.ReadOnly = true;
            this.colCreator.Width = 56;
            // 
            // colCreateTime
            // 
            this.colCreateTime.FillWeight = 120F;
            this.colCreateTime.HeaderText = "书写时间";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 120;
            // 
            // colEndTime
            // 
            this.colEndTime.FillWeight = 128F;
            this.colEndTime.HeaderText = "截止时间";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            this.colEndTime.Width = 128;
            // 
            // colCheckBasic
            // 
            this.colCheckBasic.FillWeight = 336F;
            this.colCheckBasic.HeaderText = "检查依据";
            this.colCheckBasic.Name = "colCheckBasic";
            this.colCheckBasic.ReadOnly = true;
            this.colCheckBasic.Width = 336;
            // 
            // colQcTimeIsVeto
            // 
            this.colQcTimeIsVeto.HeaderText = "单项否决";
            this.colQcTimeIsVeto.Name = "colQcTimeIsVeto";
            // 
            // colDocPoint
            // 
            this.colDocPoint.FillWeight = 42F;
            this.colDocPoint.HeaderText = "扣分";
            this.colDocPoint.MaxInputLength = 4;
            this.colDocPoint.Name = "colDocPoint";
            this.colDocPoint.Width = 42;
            // 
            // txtLevel
            // 
            this.txtLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLevel.BackColor = System.Drawing.Color.White;
            this.txtLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLevel.ForeColor = System.Drawing.Color.Black;
            this.txtLevel.Location = new System.Drawing.Point(454, 444);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(67, 23);
            this.txtLevel.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(419, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "等级";
            // 
            // txtTimePoint
            // 
            this.txtTimePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimePoint.BackColor = System.Drawing.Color.White;
            this.txtTimePoint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTimePoint.ForeColor = System.Drawing.Color.Black;
            this.txtTimePoint.Location = new System.Drawing.Point(207, 444);
            this.txtTimePoint.Name = "txtTimePoint";
            this.txtTimePoint.ReadOnly = true;
            this.txtTimePoint.Size = new System.Drawing.Size(67, 23);
            this.txtTimePoint.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(143, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "时效扣分";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnSave.Location = new System.Drawing.Point(716, 441);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContentPoint
            // 
            this.txtContentPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtContentPoint.BackColor = System.Drawing.Color.White;
            this.txtContentPoint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContentPoint.ForeColor = System.Drawing.Color.Black;
            this.txtContentPoint.Location = new System.Drawing.Point(67, 443);
            this.txtContentPoint.Name = "txtContentPoint";
            this.txtContentPoint.ReadOnly = true;
            this.txtContentPoint.Size = new System.Drawing.Size(67, 23);
            this.txtContentPoint.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "内容扣分";
            // 
            // txtScore
            // 
            this.txtScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtScore.BackColor = System.Drawing.Color.White;
            this.txtScore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtScore.ForeColor = System.Drawing.Color.Black;
            this.txtScore.Location = new System.Drawing.Point(345, 444);
            this.txtScore.Name = "txtScore";
            this.txtScore.ReadOnly = true;
            this.txtScore.Size = new System.Drawing.Size(67, 23);
            this.txtScore.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(281, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "病历得分";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnPrint.Location = new System.Drawing.Point(808, 441);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // picVetoDesc
            // 
            this.picVetoDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picVetoDesc.Image = global::MedQCSys.Properties.Resources.question2;
            this.picVetoDesc.Location = new System.Drawing.Point(527, 446);
            this.picVetoDesc.Name = "picVetoDesc";
            this.picVetoDesc.Size = new System.Drawing.Size(23, 20);
            this.picVetoDesc.TabIndex = 37;
            this.picVetoDesc.TabStop = false;
            this.picVetoDesc.Visible = false;
            // 
            // DocScoreForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 474);
            this.Controls.Add(this.picVetoDesc);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContentPoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTimePoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "DocScoreForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病案评分";
            this.tabControl1.ResumeLayout(false);
            this.tpDocConten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocContent)).EndInit();
            this.tpDocTimes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVetoDesc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpDocConten;
        private System.Windows.Forms.TabPage tpDocTimes;
        private Heren.Common.Controls.TableView.DataTableView dgvDocTime;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimePoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private Heren.Common.Controls.TableView.DataTableView dgvDocContent;
        private System.Windows.Forms.TextBox txtContentPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContentIsVeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHosPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckBasic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQcTimeIsVeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocPoint;
        private System.Windows.Forms.PictureBox picVetoDesc;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}