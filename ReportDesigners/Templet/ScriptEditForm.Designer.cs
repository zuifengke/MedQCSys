namespace Designers.Templet
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
            this.textEditor1 = new Heren.Common.TextEditor.TextEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnCut = new System.Windows.Forms.ToolStripButton();
            this.toolbtnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolbtnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnFindReplace = new System.Windows.Forms.ToolStripButton();
            this.toolbtnComment = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDebug = new System.Windows.Forms.ToolStripButton();
            this.cmenuScript = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUIDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.toolmnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.toolmnuFindSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.cmenuScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditor1
            // 
            this.textEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditor1.Location = new System.Drawing.Point(0, 25);
            this.textEditor1.Name = "textEditor1";
            this.textEditor1.ShowEOLMarkers = true;
            this.textEditor1.ShowSpaces = true;
            this.textEditor1.ShowTabs = true;
            this.textEditor1.ShowVRuler = true;
            this.textEditor1.Size = new System.Drawing.Size(843, 401);
            this.textEditor1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSave,
            this.toolStripSeparator1,
            this.toolbtnUndo,
            this.toolbtnRedo,
            this.toolStripSeparator5,
            this.toolbtnCut,
            this.toolbtnCopy,
            this.toolbtnPaste,
            this.toolStripSeparator6,
            this.toolbtnFindReplace,
            this.toolbtnComment,
            this.toolbtnDebug});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(843, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtnSave
            // 
            this.toolbtnSave.Image = global::Designers.Properties.Resources.SaveDoc;
            this.toolbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSave.Name = "toolbtnSave";
            this.toolbtnSave.Size = new System.Drawing.Size(52, 22);
            this.toolbtnSave.Text = "保存";
            this.toolbtnSave.Click += new System.EventHandler(this.toolbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnUndo
            // 
            this.toolbtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnUndo.Image = global::Designers.Properties.Resources.Undo;
            this.toolbtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnUndo.Name = "toolbtnUndo";
            this.toolbtnUndo.Size = new System.Drawing.Size(23, 22);
            this.toolbtnUndo.Text = "撤销";
            this.toolbtnUndo.Click += new System.EventHandler(this.toolbtnUndo_Click);
            // 
            // toolbtnRedo
            // 
            this.toolbtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnRedo.Image = global::Designers.Properties.Resources.Redo;
            this.toolbtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRedo.Name = "toolbtnRedo";
            this.toolbtnRedo.Size = new System.Drawing.Size(23, 22);
            this.toolbtnRedo.Text = "重做";
            this.toolbtnRedo.Click += new System.EventHandler(this.toolbtnRedo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnCut
            // 
            this.toolbtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnCut.Image = global::Designers.Properties.Resources.Cut;
            this.toolbtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnCut.Name = "toolbtnCut";
            this.toolbtnCut.Size = new System.Drawing.Size(23, 22);
            this.toolbtnCut.Text = "剪切";
            this.toolbtnCut.Click += new System.EventHandler(this.toolbtnCut_Click);
            // 
            // toolbtnCopy
            // 
            this.toolbtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnCopy.Image = global::Designers.Properties.Resources.Copy;
            this.toolbtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnCopy.Name = "toolbtnCopy";
            this.toolbtnCopy.Size = new System.Drawing.Size(23, 22);
            this.toolbtnCopy.Text = "复制";
            this.toolbtnCopy.Click += new System.EventHandler(this.toolbtnCopy_Click);
            // 
            // toolbtnPaste
            // 
            this.toolbtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnPaste.Image = global::Designers.Properties.Resources.Paste;
            this.toolbtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPaste.Name = "toolbtnPaste";
            this.toolbtnPaste.Size = new System.Drawing.Size(23, 22);
            this.toolbtnPaste.Text = "粘贴";
            this.toolbtnPaste.Click += new System.EventHandler(this.toolbtnPaste_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnFindReplace
            // 
            this.toolbtnFindReplace.Image = global::Designers.Properties.Resources.Find;
            this.toolbtnFindReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnFindReplace.Name = "toolbtnFindReplace";
            this.toolbtnFindReplace.Size = new System.Drawing.Size(52, 22);
            this.toolbtnFindReplace.Text = "查找";
            this.toolbtnFindReplace.Click += new System.EventHandler(this.toolbtnFindReplace_Click);
            // 
            // toolbtnComment
            // 
            this.toolbtnComment.Image = global::Designers.Properties.Resources.Comment;
            this.toolbtnComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnComment.Name = "toolbtnComment";
            this.toolbtnComment.Size = new System.Drawing.Size(52, 22);
            this.toolbtnComment.Text = "注释";
            this.toolbtnComment.Click += new System.EventHandler(this.toolbtnComment_Click);
            // 
            // toolbtnDebug
            // 
            this.toolbtnDebug.Image = global::Designers.Properties.Resources.Run;
            this.toolbtnDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDebug.Name = "toolbtnDebug";
            this.toolbtnDebug.Size = new System.Drawing.Size(52, 22);
            this.toolbtnDebug.Text = "调试";
            this.toolbtnDebug.Click += new System.EventHandler(this.toolbtnDebug_Click);
            // 
            // cmenuScript
            // 
            this.cmenuScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUIDesign,
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
            this.cmenuScript.Size = new System.Drawing.Size(146, 192);
            // 
            // mnuUIDesign
            // 
            this.mnuUIDesign.Image = global::Designers.Properties.Resources.UIDesign;
            this.mnuUIDesign.Name = "mnuUIDesign";
            this.mnuUIDesign.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuUIDesign.Size = new System.Drawing.Size(145, 22);
            this.mnuUIDesign.Text = "设计";
            this.mnuUIDesign.Click += new System.EventHandler(this.mnuUIDesign_Click);
            // 
            // toolmnuFind
            // 
            this.toolmnuFind.Image = global::Designers.Properties.Resources.Find;
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
            this.toolmnuFindSelected.Click += new System.EventHandler(this.toolmnuFindSelected_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(142, 6);
            // 
            // mnuUndo
            // 
            this.mnuUndo.Image = global::Designers.Properties.Resources.Undo;
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(145, 22);
            this.mnuUndo.Text = "撤销";
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Image = global::Designers.Properties.Resources.Redo;
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
            this.mnuCut.Image = global::Designers.Properties.Resources.Cut;
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCut.Size = new System.Drawing.Size(145, 22);
            this.mnuCut.Text = "剪切";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::Designers.Properties.Resources.Copy;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(145, 22);
            this.mnuCopy.Text = "复制";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = global::Designers.Properties.Resources.Paste;
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
            this.ClientSize = new System.Drawing.Size(843, 426);
            this.Controls.Add(this.textEditor1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ScriptEditForm";
            this.Text = "脚本编辑窗口";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmenuScript.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Heren.Common.TextEditor.TextEditorControl textEditor1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnUndo;
        private System.Windows.Forms.ToolStripButton toolbtnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolbtnCut;
        private System.Windows.Forms.ToolStripButton toolbtnCopy;
        private System.Windows.Forms.ToolStripButton toolbtnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolbtnDebug;
        private System.Windows.Forms.ToolStripButton toolbtnComment;
        private System.Windows.Forms.ContextMenuStrip cmenuScript;
        private System.Windows.Forms.ToolStripMenuItem mnuUIDesign;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripButton toolbtnFindReplace;
        private System.Windows.Forms.ToolStripMenuItem toolmnuFind;
        private System.Windows.Forms.ToolStripMenuItem toolmnuFindSelected;
    }
}