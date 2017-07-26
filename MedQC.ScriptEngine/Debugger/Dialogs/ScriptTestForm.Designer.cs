namespace Heren.MedQC.ScriptEngine.Debugger
{
    partial class ScriptTestForm
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
            this.dataGridView1 = new Heren.Common.Controls.TableView.DataTableView();
            this.btnAdd = new Heren.Common.Controls.FlatButton();
            this.btnDelete = new Heren.Common.Controls.FlatButton();
            this.colElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScriptValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "小提示：本测试窗口会自动把您编写在脚本中的所有元素全部在列表中列出，您可以在元素值那一列输入元素的值，然后在您输入过程中，系统会自动执行脚本，以此来模拟您在病历中" +
                "修改元素值的过程。\r\n\r\n下面列表中自动加载的可能有多余元素，这是没有关系的，无需关心即可：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeight = 24;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colElementName,
            this.colScriptValue});
            this.dataGridView1.Location = new System.Drawing.Point(1, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 36;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(535, 318);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(541, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 22);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.ToolTipText = "添加附加条件";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(541, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 22);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.ToolTipText = "添加附加条件";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // colElementName
            // 
            this.colElementName.FillWeight = 180F;
            this.colElementName.HeaderText = "元素名称";
            this.colElementName.Name = "colElementName";
            this.colElementName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colElementName.Width = 180;
            // 
            // colScriptValue
            // 
            this.colScriptValue.FillWeight = 300F;
            this.colScriptValue.HeaderText = "请输入元素值";
            this.colScriptValue.Name = "colScriptValue";
            this.colScriptValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colScriptValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colScriptValue.Width = 300;
            // 
            // ScriptTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 379);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScriptTestForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "脚本测试";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.Controls.TableView.DataTableView dataGridView1;
        private Heren.Common.Controls.FlatButton btnAdd;
        private Heren.Common.Controls.FlatButton btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScriptValue;
    }
}