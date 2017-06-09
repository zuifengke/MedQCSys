namespace Heren.MedQC.MedRecord
{
    partial class CodeCompasionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeCompasionForm));
            this.dataTableView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.col_CODE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MC = new Heren.Common.Controls.TableView.FindComboBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxButton1 = new Heren.Common.Controls.TextBoxButton();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_PageIndex = new System.Windows.Forms.TextBox();
            this.btnNext = new Heren.Common.Controls.FlatButton();
            this.btnPre = new Heren.Common.Controls.FlatButton();
            this.btnLast = new Heren.Common.Controls.FlatButton();
            this.btnALL = new Heren.Common.Controls.FlatButton();
            this.btnFirst = new Heren.Common.Controls.FlatButton();
            this.lbl_PageCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lbl_TotalCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fbtnSettingCodeType = new Heren.Common.Controls.FlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTableView1
            // 
            this.dataTableView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataTableView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_CODE_ID,
            this.col_CODE_NAME,
            this.col_STATUS,
            this.col_DM,
            this.col_MC});
            this.dataTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView1.Location = new System.Drawing.Point(0, 34);
            this.dataTableView1.Name = "dataTableView1";
            this.dataTableView1.Size = new System.Drawing.Size(693, 468);
            this.dataTableView1.TabIndex = 0;
            this.dataTableView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataTableView1_EditingControlShowing);
            // 
            // col_CODE_ID
            // 
            this.col_CODE_ID.HeaderText = "和仁字典代码";
            this.col_CODE_ID.Name = "col_CODE_ID";
            this.col_CODE_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_CODE_NAME
            // 
            this.col_CODE_NAME.HeaderText = "和仁字典名称";
            this.col_CODE_NAME.Name = "col_CODE_NAME";
            this.col_CODE_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_CODE_NAME.Width = 200;
            // 
            // col_STATUS
            // 
            this.col_STATUS.HeaderText = ".";
            this.col_STATUS.Name = "col_STATUS";
            this.col_STATUS.Width = 30;
            // 
            // col_DM
            // 
            this.col_DM.HeaderText = "联众字典代码";
            this.col_DM.Name = "col_DM";
            // 
            // col_MC
            // 
            this.col_MC.HeaderText = "联众字典名称";
            this.col_MC.Name = "col_MC";
            this.col_MC.PinyinFuzzyMatch = true;
            this.col_MC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_MC.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(604, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 530);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "代码类别";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(3, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(149, 510);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fbtnSettingCodeType);
            this.panel1.Controls.Add(this.textBoxButton1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 34);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBoxButton1
            // 
            this.textBoxButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxButton1.ButtonImage = ((System.Drawing.Image)(resources.GetObject("textBoxButton1.ButtonImage")));
            this.textBoxButton1.ButtonToolTip = null;
            this.textBoxButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxButton1.HintText = "和仁字典名称";
            this.textBoxButton1.Location = new System.Drawing.Point(339, 5);
            this.textBoxButton1.Name = "textBoxButton1";
            this.textBoxButton1.Size = new System.Drawing.Size(174, 22);
            this.textBoxButton1.TabIndex = 3;
            this.textBoxButton1.ButtonClick += new System.EventHandler(this.textBoxButton1_ButtonClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(523, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "自动对照";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_PageIndex);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPre);
            this.panel2.Controls.Add(this.btnLast);
            this.panel2.Controls.Add(this.btnALL);
            this.panel2.Controls.Add(this.btnFirst);
            this.panel2.Controls.Add(this.lbl_PageCount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblPageSize);
            this.panel2.Controls.Add(this.lbl_TotalCount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 28);
            this.panel2.TabIndex = 5;
            // 
            // txt_PageIndex
            // 
            this.txt_PageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PageIndex.Location = new System.Drawing.Point(581, 4);
            this.txt_PageIndex.Name = "txt_PageIndex";
            this.txt_PageIndex.Size = new System.Drawing.Size(35, 21);
            this.txt_PageIndex.TabIndex = 6;
            this.txt_PageIndex.Text = "1";
            this.txt_PageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnNext.Location = new System.Drawing.Point(619, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 22);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = ">";
            this.btnNext.ToolTipText = null;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPre.Location = new System.Drawing.Point(544, 4);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(34, 22);
            this.btnPre.TabIndex = 5;
            this.btnPre.Text = "<";
            this.btnPre.ToolTipText = null;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLast.Location = new System.Drawing.Point(655, 4);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(34, 22);
            this.btnLast.TabIndex = 5;
            this.btnLast.Text = ">|";
            this.btnLast.ToolTipText = null;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnALL
            // 
            this.btnALL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnALL.Location = new System.Drawing.Point(473, 4);
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(34, 22);
            this.btnALL.TabIndex = 5;
            this.btnALL.Text = "ALL";
            this.btnALL.ToolTipText = null;
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.Location = new System.Drawing.Point(509, 4);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(34, 22);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "|<";
            this.btnFirst.ToolTipText = null;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lbl_PageCount
            // 
            this.lbl_PageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PageCount.AutoSize = true;
            this.lbl_PageCount.Location = new System.Drawing.Point(407, 7);
            this.lbl_PageCount.Name = "lbl_PageCount";
            this.lbl_PageCount.Size = new System.Drawing.Size(11, 12);
            this.lbl_PageCount.TabIndex = 4;
            this.lbl_PageCount.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "页";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "共";
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(318, 7);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(17, 12);
            this.lblPageSize.TabIndex = 1;
            this.lblPageSize.Text = "50";
            // 
            // lbl_TotalCount
            // 
            this.lbl_TotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_TotalCount.AutoSize = true;
            this.lbl_TotalCount.Location = new System.Drawing.Point(194, 7);
            this.lbl_TotalCount.Name = "lbl_TotalCount";
            this.lbl_TotalCount.Size = new System.Drawing.Size(11, 12);
            this.lbl_TotalCount.TabIndex = 1;
            this.lbl_TotalCount.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "条，";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "每页";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "条记录，";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "共";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(852, 530);
            this.panel3.TabIndex = 6;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 530);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataTableView1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(852, 530);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 4;
            // 
            // fbtnSettingCodeType
            // 
            this.fbtnSettingCodeType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fbtnSettingCodeType.Location = new System.Drawing.Point(17, 5);
            this.fbtnSettingCodeType.Name = "fbtnSettingCodeType";
            this.fbtnSettingCodeType.Size = new System.Drawing.Size(80, 22);
            this.fbtnSettingCodeType.TabIndex = 4;
            this.fbtnSettingCodeType.Text = "设置类别";
            this.fbtnSettingCodeType.ToolTipText = null;
            this.fbtnSettingCodeType.Click += new System.EventHandler(this.fbtnSettingCodeType_Click);
            // 
            // CodeCompasionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 530);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CodeCompasionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病案上传编码对照";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Controls.TableView.DataTableView dataTableView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TotalCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_PageCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private Common.Controls.FlatButton btnPre;
        private Common.Controls.FlatButton btnFirst;
        private System.Windows.Forms.TextBox txt_PageIndex;
        private Common.Controls.FlatButton btnNext;
        private Common.Controls.FlatButton btnLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox listBox1;
        private Common.Controls.TextBoxButton textBoxButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CODE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CODE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DM;
        private Common.Controls.TableView.FindComboBoxColumn col_MC;
        private Common.Controls.FlatButton btnALL;
        private Common.Controls.FlatButton fbtnSettingCodeType;
    }
}

