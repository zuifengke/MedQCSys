namespace Heren.MedQC.ScriptEngine.Debugger
{
    partial class ScriptEditForm
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
            this.textEditorControl1 = new Heren.Common.TextEditor.TextEditorControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmenuScript = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolmnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.toolmnuFindSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.cmenuScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.ContextMenuStrip = this.cmenuScript;
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.ShowEOLMarkers = true;
            this.textEditorControl1.ShowInvalidLines = false;
            this.textEditorControl1.ShowSpaces = true;
            this.textEditorControl1.ShowTabs = true;
            this.textEditorControl1.ShowVRuler = true;
            this.textEditorControl1.Size = new System.Drawing.Size(610, 394);
            this.textEditorControl1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textEditorControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 398);
            this.panel1.TabIndex = 3;
            // 
            // cmenuScript
            // 
            this.cmenuScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolmnuFind,
            this.toolmnuFindSelected,
            this.toolStripSeparator4,
            this.mnuUndo,
            this.mnuRedo,
            this.toolStripSeparator3,
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste});
            this.cmenuScript.Name = "contextMenuStrip1";
            this.cmenuScript.Size = new System.Drawing.Size(146, 170);
            // 
            // toolmnuFind
            // 
            this.toolmnuFind.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Find;
            this.toolmnuFind.Name = "toolmnuFind";
            this.toolmnuFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.toolmnuFind.Size = new System.Drawing.Size(145, 22);
            this.toolmnuFind.Text = "查找";
            this.toolmnuFind.Click += new System.EventHandler(this.toolmnuFind_Click);
            // 
            // toolmnuFindSelected
            // 
            this.toolmnuFindSelected.Name = "toolmnuFindSelected";
            this.toolmnuFindSelected.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.toolmnuFindSelected.Size = new System.Drawing.Size(145, 22);
            this.toolmnuFindSelected.Text = "查找引用";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(142, 6);
            // 
            // mnuUndo
            // 
            this.mnuUndo.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Undo;
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(145, 22);
            this.mnuUndo.Text = "撤销";
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Redo;
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuRedo.Size = new System.Drawing.Size(145, 22);
            this.mnuRedo.Text = "重做";
            this.mnuRedo.Click += new System.EventHandler(this.mnuRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(142, 6);
            // 
            // mnuCut
            // 
            this.mnuCut.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Cut;
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCut.Size = new System.Drawing.Size(145, 22);
            this.mnuCut.Text = "剪切";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Copy;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(145, 22);
            this.mnuCopy.Text = "复制";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = global::Heren.MedQC.ScriptEngine.Properties.Resources.Paste;
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuPaste.Size = new System.Drawing.Size(145, 22);
            this.mnuPaste.Text = "粘贴";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // ScriptEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 400);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ScriptEditForm";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "脚本编辑";
            this.panel1.ResumeLayout(false);
            this.cmenuScript.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Heren.Common.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmenuScript;
        private System.Windows.Forms.ToolStripMenuItem toolmnuFind;
        private System.Windows.Forms.ToolStripMenuItem toolmnuFindSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
    }
}