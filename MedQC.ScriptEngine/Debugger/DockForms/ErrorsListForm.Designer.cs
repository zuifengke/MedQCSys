namespace Heren.MedQC.ScriptEngine.Debugger
{
    partial class ErrorsListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorsListForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.colIcon = new System.Windows.Forms.ColumnHeader();
            this.colErrorText = new System.Windows.Forms.ColumnHeader();
            this.colErrorLine = new System.Windows.Forms.ColumnHeader();
            this.colErrorColumn = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIcon,
            this.colErrorText,
            this.colErrorLine,
            this.colErrorColumn});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(741, 199);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // colIcon
            // 
            this.colIcon.Text = "";
            this.colIcon.Width = 32;
            // 
            // colErrorText
            // 
            this.colErrorText.Text = "错误信息";
            this.colErrorText.Width = 600;
            // 
            // colErrorLine
            // 
            this.colErrorLine.Text = "行号";
            // 
            // colErrorColumn
            // 
            this.colErrorColumn.Text = "列号";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Warn.png");
            this.imageList1.Images.SetKeyName(1, "Error.png");
            // 
            // ErrorsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 199);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ErrorsListForm";
            this.Text = "错误列表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colErrorText;
        private System.Windows.Forms.ColumnHeader colErrorLine;
        private System.Windows.Forms.ColumnHeader colIcon;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader colErrorColumn;
    }
}