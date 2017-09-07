namespace Heren.MedQC.Search.Forms
{
    partial class SearchCriticalValuesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbStatus = new Heren.Common.Controls.DictInput.FindComboBox();
            this.tbVisitID = new Heren.Common.Controls.HintTextBox();
            this.tbName = new Heren.Common.Controls.HintTextBox();
            this.tbParentID = new Heren.Common.Controls.HintTextBox();
            this.cboDeptName = new Heren.Common.Controls.DictInput.FindComboBox();
            this.dtcDate = new Heren.Common.Controls.TimeControl.DateTimeControl();
            this.bSearch = new Heren.Common.Controls.HerenButton();
            this.lBegin = new System.Windows.Forms.Label();
            this.pCondition = new System.Windows.Forms.Panel();
            this._CONFIRM_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._CONFIRM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ALARM_CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._REF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._INSPECTION_RESULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._VISIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ALARM_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ALARM_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NUMVAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_UNITS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_REF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ALARM_CONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CONFIRM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CONFIRM_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.HintText = "状态";
            this.cbStatus.Items.AddRange(new object[] {
            "",
            "未接收",
            "未确认",
            "已确认",
            "已处理"});
            this.cbStatus.Location = new System.Drawing.Point(19, 14);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(70, 26);
            this.cbStatus.TabIndex = 30;
            // 
            // tbVisitID
            // 
            this.tbVisitID.HintText = "住院号";
            this.tbVisitID.Location = new System.Drawing.Point(628, 16);
            this.tbVisitID.Name = "tbVisitID";
            this.tbVisitID.Size = new System.Drawing.Size(134, 21);
            this.tbVisitID.TabIndex = 29;
            // 
            // tbName
            // 
            this.tbName.HintText = "患者姓名";
            this.tbName.Location = new System.Drawing.Point(786, 16);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 21);
            this.tbName.TabIndex = 27;
            // 
            // tbParentID
            // 
            this.tbParentID.HintText = "患者ID";
            this.tbParentID.Location = new System.Drawing.Point(473, 16);
            this.tbParentID.Name = "tbParentID";
            this.tbParentID.Size = new System.Drawing.Size(131, 21);
            this.tbParentID.TabIndex = 25;
            // 
            // cboDeptName
            // 
            this.cboDeptName.HintText = "科室";
            this.cboDeptName.Location = new System.Drawing.Point(296, 14);
            this.cboDeptName.Name = "cboDeptName";
            this.cboDeptName.Size = new System.Drawing.Size(154, 26);
            this.cboDeptName.TabIndex = 24;
            // 
            // dtcDate
            // 
            this.dtcDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtcDate.Location = new System.Drawing.Point(151, 14);
            this.dtcDate.Name = "dtcDate";
            this.dtcDate.ShowHour = false;
            this.dtcDate.ShowMinute = false;
            this.dtcDate.ShowSecond = false;
            this.dtcDate.Size = new System.Drawing.Size(117, 26);
            this.dtcDate.TabIndex = 11;
            this.dtcDate.Tag = "入院开始日期";
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.Location = new System.Drawing.Point(1058, 12);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(87, 27);
            this.bSearch.TabIndex = 19;
            this.bSearch.Text = "查询";
            this.bSearch.UseVisualStyleBackColor = true;
            // 
            // lBegin
            // 
            this.lBegin.AutoSize = true;
            this.lBegin.Location = new System.Drawing.Point(115, 20);
            this.lBegin.Name = "lBegin";
            this.lBegin.Size = new System.Drawing.Size(29, 12);
            this.lBegin.TabIndex = 12;
            this.lBegin.Text = "日期";
            // 
            // pCondition
            // 
            this.pCondition.BackColor = System.Drawing.SystemColors.Window;
            this.pCondition.Controls.Add(this.cbStatus);
            this.pCondition.Controls.Add(this.tbVisitID);
            this.pCondition.Controls.Add(this.tbName);
            this.pCondition.Controls.Add(this.tbParentID);
            this.pCondition.Controls.Add(this.cboDeptName);
            this.pCondition.Controls.Add(this.dtcDate);
            this.pCondition.Controls.Add(this.bSearch);
            this.pCondition.Controls.Add(this.lBegin);
            this.pCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pCondition.Location = new System.Drawing.Point(0, 0);
            this.pCondition.Name = "pCondition";
            this.pCondition.Size = new System.Drawing.Size(1157, 50);
            this.pCondition.TabIndex = 5;
            // 
            // _CONFIRM_TIME
            // 
            this._CONFIRM_TIME.HeaderText = "确认时间";
            this._CONFIRM_TIME.Name = "_CONFIRM_TIME";
            this._CONFIRM_TIME.ReadOnly = true;
            // 
            // _CONFIRM_NAME
            // 
            this._CONFIRM_NAME.HeaderText = "确认人";
            this._CONFIRM_NAME.Name = "_CONFIRM_NAME";
            this._CONFIRM_NAME.ReadOnly = true;
            // 
            // _ALARM_CONTENT
            // 
            this._ALARM_CONTENT.HeaderText = "危急值内容";
            this._ALARM_CONTENT.Name = "_ALARM_CONTENT";
            this._ALARM_CONTENT.ReadOnly = true;
            // 
            // _REF
            // 
            this._REF.HeaderText = "参考范围";
            this._REF.Name = "_REF";
            this._REF.ReadOnly = true;
            // 
            // _INSPECTION_RESULT
            // 
            this._INSPECTION_RESULT.HeaderText = "检验结果";
            this._INSPECTION_RESULT.Name = "_INSPECTION_RESULT";
            this._INSPECTION_RESULT.ReadOnly = true;
            // 
            // _ITEM_NAME
            // 
            this._ITEM_NAME.HeaderText = "项目名称";
            this._ITEM_NAME.Name = "_ITEM_NAME";
            this._ITEM_NAME.ReadOnly = true;
            // 
            // _PATIENT_NAME
            // 
            this._PATIENT_NAME.HeaderText = "患者姓名";
            this._PATIENT_NAME.Name = "_PATIENT_NAME";
            this._PATIENT_NAME.ReadOnly = true;
            // 
            // _VISIT_ID
            // 
            this._VISIT_ID.HeaderText = "住院号";
            this._VISIT_ID.Name = "_VISIT_ID";
            this._VISIT_ID.ReadOnly = true;
            // 
            // _PATIENT_ID
            // 
            this._PATIENT_ID.HeaderText = "患者ID";
            this._PATIENT_ID.Name = "_PATIENT_ID";
            this._PATIENT_ID.ReadOnly = true;
            // 
            // _DEPT_NAME
            // 
            this._DEPT_NAME.HeaderText = "科室";
            this._DEPT_NAME.Name = "_DEPT_NAME";
            this._DEPT_NAME.ReadOnly = true;
            // 
            // _ALARM_TIME
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._ALARM_TIME.DefaultCellStyle = dataGridViewCellStyle1;
            this._ALARM_TIME.HeaderText = "报警时间";
            this._ALARM_TIME.Name = "_ALARM_TIME";
            this._ALARM_TIME.ReadOnly = true;
            this._ALARM_TIME.Width = 150;
            // 
            // _STATUS
            // 
            this._STATUS.HeaderText = "状态";
            this._STATUS.Name = "_STATUS";
            this._STATUS.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "状态";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "报警时间";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "科室";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "患者ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "住院号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "患者姓名";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "项目名称";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "检验结果";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "参考范围";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "危急值内容";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "确认人";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "确认时间";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_STATUS,
            this.col_ALARM_TIME,
            this.col_DEPT_NAME,
            this.colPatientName,
            this.colPatientID,
            this.colVisitID,
            this.col_ITEM_NAME,
            this.col_NUMVAL,
            this.col_UNITS,
            this.col_REF,
            this.col_ALARM_CONTENT,
            this.col_CONFIRM_NAME,
            this.col_CONFIRM_TIME});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1157, 437);
            this.dataGridView1.TabIndex = 6;
            // 
            // col_STATUS
            // 
            this.col_STATUS.HeaderText = "状态";
            this.col_STATUS.Name = "col_STATUS";
            this.col_STATUS.ReadOnly = true;
            this.col_STATUS.Width = 140;
            // 
            // col_ALARM_TIME
            // 
            this.col_ALARM_TIME.HeaderText = "报警时间";
            this.col_ALARM_TIME.Name = "col_ALARM_TIME";
            this.col_ALARM_TIME.ReadOnly = true;
            // 
            // col_DEPT_NAME
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_DEPT_NAME.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_DEPT_NAME.HeaderText = "科室";
            this.col_DEPT_NAME.Name = "col_DEPT_NAME";
            this.col_DEPT_NAME.ReadOnly = true;
            this.col_DEPT_NAME.Width = 60;
            // 
            // colPatientName
            // 
            this.colPatientName.HeaderText = "患者姓名";
            this.colPatientName.Name = "colPatientName";
            this.colPatientName.ReadOnly = true;
            // 
            // colPatientID
            // 
            this.colPatientID.HeaderText = "患者ID号";
            this.colPatientID.Name = "colPatientID";
            this.colPatientID.ReadOnly = true;
            // 
            // colVisitID
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colVisitID.DefaultCellStyle = dataGridViewCellStyle5;
            this.colVisitID.HeaderText = "入院次";
            this.colVisitID.Name = "colVisitID";
            this.colVisitID.ReadOnly = true;
            this.colVisitID.Width = 80;
            // 
            // col_ITEM_NAME
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_ITEM_NAME.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_ITEM_NAME.HeaderText = "项目名称";
            this.col_ITEM_NAME.Name = "col_ITEM_NAME";
            this.col_ITEM_NAME.ReadOnly = true;
            this.col_ITEM_NAME.Width = 150;
            // 
            // col_NUMVAL
            // 
            this.col_NUMVAL.HeaderText = "检验结果";
            this.col_NUMVAL.Name = "col_NUMVAL";
            this.col_NUMVAL.ReadOnly = true;
            // 
            // col_UNITS
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_UNITS.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_UNITS.HeaderText = "单位";
            this.col_UNITS.Name = "col_UNITS";
            this.col_UNITS.ReadOnly = true;
            this.col_UNITS.Width = 90;
            // 
            // col_REF
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_REF.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_REF.HeaderText = "参考范围";
            this.col_REF.Name = "col_REF";
            this.col_REF.ReadOnly = true;
            this.col_REF.Width = 90;
            // 
            // col_ALARM_CONTENT
            // 
            this.col_ALARM_CONTENT.HeaderText = "报警内容";
            this.col_ALARM_CONTENT.Name = "col_ALARM_CONTENT";
            this.col_ALARM_CONTENT.ReadOnly = true;
            this.col_ALARM_CONTENT.Width = 200;
            // 
            // col_CONFIRM_NAME
            // 
            this.col_CONFIRM_NAME.HeaderText = "确认人";
            this.col_CONFIRM_NAME.Name = "col_CONFIRM_NAME";
            this.col_CONFIRM_NAME.ReadOnly = true;
            this.col_CONFIRM_NAME.Visible = false;
            // 
            // col_CONFIRM_TIME
            // 
            this.col_CONFIRM_TIME.HeaderText = "确认时间";
            this.col_CONFIRM_TIME.Name = "col_CONFIRM_TIME";
            this.col_CONFIRM_TIME.ReadOnly = true;
            // 
            // SearchCriticalValuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 487);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pCondition);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SearchCriticalValuesForm";
            this.Text = "危急值患者查询";
            this.pCondition.ResumeLayout(false);
            this.pCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Controls.DictInput.FindComboBox cbStatus;
        private Common.Controls.HintTextBox tbVisitID;
        private Common.Controls.HintTextBox tbName;
        private Common.Controls.HintTextBox tbParentID;
        private Common.Controls.DictInput.FindComboBox cboDeptName;
        private Common.Controls.TimeControl.DateTimeControl dtcDate;
        private Common.Controls.HerenButton bSearch;
        private System.Windows.Forms.Label lBegin;
        private System.Windows.Forms.Panel pCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CONFIRM_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn _CONFIRM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ALARM_CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn _REF;
        private System.Windows.Forms.DataGridViewTextBoxColumn _INSPECTION_RESULT;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn _PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn _VISIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ALARM_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn _STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ALARM_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NUMVAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_UNITS;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_REF;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ALARM_CONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CONFIRM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CONFIRM_TIME;
    }
}