namespace MedQCSys.DockForms
{
    partial class DocScoreNewForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSystemCheck = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpHummanScore = new System.Windows.Forms.TabPage();
            this.dgvHummanScore = new MedQCSys.Controls.CollapseDataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpSystemScore = new System.Windows.Forms.TabPage();
            this.dgvSystemScore = new Heren.Common.Controls.TableView.DataTableView();
            this.col_2_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_ErrorCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2_QC_EXPLAIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpHummanScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHummanScore)).BeginInit();
            this.tpSystemScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemScore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnSave.Location = new System.Drawing.Point(129, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLevel.BackColor = System.Drawing.Color.White;
            this.txtLevel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLevel.ForeColor = System.Drawing.Color.Black;
            this.txtLevel.Location = new System.Drawing.Point(53, 393);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.ReadOnly = true;
            this.txtLevel.Size = new System.Drawing.Size(67, 23);
            this.txtLevel.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "等级";
            // 
            // btnSystemCheck
            // 
            this.btnSystemCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSystemCheck.Font = new System.Drawing.Font("宋体", 10.5F);
            this.btnSystemCheck.Location = new System.Drawing.Point(312, 390);
            this.btnSystemCheck.Name = "btnSystemCheck";
            this.btnSystemCheck.Size = new System.Drawing.Size(90, 28);
            this.btnSystemCheck.TabIndex = 16;
            this.btnSystemCheck.Text = "系统重检";
            this.btnSystemCheck.UseVisualStyleBackColor = true;
            this.btnSystemCheck.Click += new System.EventHandler(this.btnSystemCheck_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.button2.Location = new System.Drawing.Point(215, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 28);
            this.button2.TabIndex = 16;
            this.button2.Text = "整改通知书";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpHummanScore);
            this.tabControl1.Controls.Add(this.tpSystemScore);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 389);
            this.tabControl1.TabIndex = 0;
            // 
            // tpHummanScore
            // 
            this.tpHummanScore.Controls.Add(this.dgvHummanScore);
            this.tpHummanScore.Location = new System.Drawing.Point(4, 24);
            this.tpHummanScore.Name = "tpHummanScore";
            this.tpHummanScore.Padding = new System.Windows.Forms.Padding(3);
            this.tpHummanScore.Size = new System.Drawing.Size(729, 361);
            this.tpHummanScore.TabIndex = 0;
            this.tpHummanScore.Text = "人工检测（..）";
            this.tpHummanScore.UseVisualStyleBackColor = true;
            // 
            // dgvHummanScore
            // 
            this.dgvHummanScore.AllowUserToAddRows = false;
            this.dgvHummanScore.AllowUserToDeleteRows = false;
            this.dgvHummanScore.AllowUserToOrderColumns = true;
            this.dgvHummanScore.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvHummanScore.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHummanScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHummanScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHummanScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colCheckBox,
            this.colItem,
            this.colPoint,
            this.colErrorCount,
            this.colRemark});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHummanScore.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHummanScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHummanScore.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvHummanScore.GroupEvenColor = System.Drawing.Color.White;
            this.dgvHummanScore.GroupOddColor = System.Drawing.Color.White;
            this.dgvHummanScore.ImageHeight = 15;
            this.dgvHummanScore.ImageWidth = 15;
            this.dgvHummanScore.ImgCollapse = global::MedQCSys.Properties.Resources.Collapse;
            this.dgvHummanScore.ImgExpand = global::MedQCSys.Properties.Resources.Expand;
            this.dgvHummanScore.IsInitCollapsed = true;
            this.dgvHummanScore.Location = new System.Drawing.Point(3, 3);
            this.dgvHummanScore.MultiSelect = false;
            this.dgvHummanScore.Name = "dgvHummanScore";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(41);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHummanScore.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHummanScore.RowHeadersWidth = 25;
            this.dgvHummanScore.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvHummanScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHummanScore.Size = new System.Drawing.Size(723, 355);
            this.dgvHummanScore.TabIndex = 10;
            this.dgvHummanScore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHummanScore_CellClick);
            this.dgvHummanScore.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHummanScore_CellDoubleClick);
            // 
            // colNumber
            // 
            this.colNumber.HeaderText = "序号";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = false;
            // 
            // colCheckBox
            // 
            this.colCheckBox.HeaderText = "";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCheckBox.Width = 25;
            // 
            // colItem
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.colItem.FillWeight = 500F;
            this.colItem.HeaderText = "评定项目";
            this.colItem.Name = "colItem";
            this.colItem.Width = 200;
            // 
            // colPoint
            // 
            this.colPoint.HeaderText = "分值";
            this.colPoint.Name = "colPoint";
            this.colPoint.Width = 60;
            // 
            // colErrorCount
            // 
            this.colErrorCount.HeaderText = "次数";
            this.colErrorCount.Name = "colErrorCount";
            this.colErrorCount.Width = 60;
            // 
            // colRemark
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemark.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            this.colRemark.Width = 300;
            // 
            // tpSystemScore
            // 
            this.tpSystemScore.Controls.Add(this.dgvSystemScore);
            this.tpSystemScore.Location = new System.Drawing.Point(4, 24);
            this.tpSystemScore.Name = "tpSystemScore";
            this.tpSystemScore.Padding = new System.Windows.Forms.Padding(3);
            this.tpSystemScore.Size = new System.Drawing.Size(729, 361);
            this.tpSystemScore.TabIndex = 1;
            this.tpSystemScore.Text = "系统检测（..）";
            this.tpSystemScore.UseVisualStyleBackColor = true;
            // 
            // dgvSystemScore
            // 
            this.dgvSystemScore.AllowUserToOrderColumns = true;
            this.dgvSystemScore.AllowUserToResizeRows = true;
            this.dgvSystemScore.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSystemScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSystemScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSystemScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_2_Item,
            this.col_2_Score,
            this.col_2_ErrorCount,
            this.col_2_QC_EXPLAIN});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSystemScore.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSystemScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSystemScore.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSystemScore.Location = new System.Drawing.Point(3, 3);
            this.dgvSystemScore.MultiSelect = false;
            this.dgvSystemScore.Name = "dgvSystemScore";
            this.dgvSystemScore.RowHeadersVisible = false;
            this.dgvSystemScore.Size = new System.Drawing.Size(723, 355);
            this.dgvSystemScore.TabIndex = 8;
            this.dgvSystemScore.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSystemScore_ColumnHeaderMouseDoubleClick);
            // 
            // col_2_Item
            // 
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_2_Item.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_2_Item.FillWeight = 500F;
            this.col_2_Item.HeaderText = "评定项目";
            this.col_2_Item.Name = "col_2_Item";
            this.col_2_Item.Width = 330;
            // 
            // col_2_Score
            // 
            this.col_2_Score.HeaderText = "分值";
            this.col_2_Score.Name = "col_2_Score";
            this.col_2_Score.Width = 60;
            // 
            // col_2_ErrorCount
            // 
            this.col_2_ErrorCount.HeaderText = "错误次数";
            this.col_2_ErrorCount.Name = "col_2_ErrorCount";
            this.col_2_ErrorCount.Width = 90;
            // 
            // col_2_QC_EXPLAIN
            // 
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_2_QC_EXPLAIN.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_2_QC_EXPLAIN.HeaderText = "系统错误描述";
            this.col_2_QC_EXPLAIN.Name = "col_2_QC_EXPLAIN";
            this.col_2_QC_EXPLAIN.Width = 300;
            // 
            // DocScoreNewForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 429);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSystemCheck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DocScoreNewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "终末评分界面";
            this.tabControl1.ResumeLayout(false);
            this.tpHummanScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHummanScore)).EndInit();
            this.tpSystemScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSystemScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpHummanScore;
        private System.Windows.Forms.TabPage tpSystemScore;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private Heren.Common.Controls.TableView.DataTableView dgvSystemScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_ErrorCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2_QC_EXPLAIN;
        private System.Windows.Forms.Button btnSystemCheck;
        private Controls.CollapseDataGridView dgvHummanScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
    }
}