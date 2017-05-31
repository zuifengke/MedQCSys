namespace Designers.Templet
{
    partial class DesignEditForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnCut = new System.Windows.Forms.ToolStripButton();
            this.toolbtnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolbtnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnProperty = new System.Windows.Forms.ToolStripButton();
            this.toolbtnToolbox = new System.Windows.Forms.ToolStripButton();
            this.toolbtnMakeReport = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDebug = new System.Windows.Forms.ToolStripButton();
            this.formDesigner1 = new Heren.Common.Forms.Designer.FormDesigner();
            this.cmenuDesigner = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBringToFront = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendToBack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyControlName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolbox = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectObject = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuRebuild = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuReNameCb = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReNameDt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReNameCmb = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReNameRdb = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReNametxt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReNameAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.cmenuDesigner.SuspendLayout();
            this.cmenuRebuild.SuspendLayout();
            this.SuspendLayout();
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
            this.toolbtnDelete,
            this.toolStripSeparator6,
            this.toolbtnProperty,
            this.toolbtnToolbox,
            this.toolbtnMakeReport,
            this.toolbtnDebug});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(760, 25);
            this.toolStrip1.TabIndex = 0;
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
            // toolbtnDelete
            // 
            this.toolbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnDelete.Image = global::Designers.Properties.Resources.Delete;
            this.toolbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDelete.Name = "toolbtnDelete";
            this.toolbtnDelete.Size = new System.Drawing.Size(23, 22);
            this.toolbtnDelete.Text = "删除";
            this.toolbtnDelete.Click += new System.EventHandler(this.toolbtnDelete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnProperty
            // 
            this.toolbtnProperty.Image = global::Designers.Properties.Resources.Property;
            this.toolbtnProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnProperty.Name = "toolbtnProperty";
            this.toolbtnProperty.Size = new System.Drawing.Size(76, 22);
            this.toolbtnProperty.Text = "属性窗口";
            this.toolbtnProperty.Click += new System.EventHandler(this.toolbtnProperty_Click);
            // 
            // toolbtnToolbox
            // 
            this.toolbtnToolbox.Image = global::Designers.Properties.Resources.Toolbox;
            this.toolbtnToolbox.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnToolbox.Name = "toolbtnToolbox";
            this.toolbtnToolbox.Size = new System.Drawing.Size(76, 22);
            this.toolbtnToolbox.Text = "工具窗口";
            this.toolbtnToolbox.Click += new System.EventHandler(this.toolbtnToolbox_Click);
            // 
            // toolbtnMakeReport
            // 
            this.toolbtnMakeReport.Image = global::Designers.Properties.Resources.MakeReport;
            this.toolbtnMakeReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnMakeReport.Name = "toolbtnMakeReport";
            this.toolbtnMakeReport.Size = new System.Drawing.Size(76, 22);
            this.toolbtnMakeReport.Text = "生成报表";
            this.toolbtnMakeReport.Click += new System.EventHandler(this.toolbtnMakeReport_Click);
            // 
            // toolbtnDebug
            // 
            this.toolbtnDebug.Image = global::Designers.Properties.Resources.Run;
            this.toolbtnDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDebug.Name = "toolbtnDebug";
            this.toolbtnDebug.Size = new System.Drawing.Size(52, 22);
            this.toolbtnDebug.Text = "调试";
            this.toolbtnDebug.ToolTipText = "测试模板";
            this.toolbtnDebug.Click += new System.EventHandler(this.toolbtnDebug_Click);
            // 
            // formDesigner1
            // 
            this.formDesigner1.BackColor = System.Drawing.Color.White;
            this.formDesigner1.ContextMenuStrip = this.cmenuDesigner;
            this.formDesigner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formDesigner1.Location = new System.Drawing.Point(0, 25);
            this.formDesigner1.Name = "formDesigner1";
            this.formDesigner1.PropertyGrid = null;
            this.formDesigner1.Size = new System.Drawing.Size(760, 460);
            this.formDesigner1.TabIndex = 1;
            this.formDesigner1.Toolbox = null;
            this.formDesigner1.DocumentChanged += new System.EventHandler(this.formDesigner1_DocumentChanged);
            this.formDesigner1.SelectionChanged += new System.EventHandler(this.formDesigner1_SelectionChanged);
            this.formDesigner1.ComponentDbClick += new System.EventHandler(this.formDesigner1_ComponentDbClick);
            // 
            // cmenuDesigner
            // 
            this.cmenuDesigner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScript,
            this.toolStripSeparator7,
            this.mnuBringToFront,
            this.mnuSendToBack,
            this.toolStripSeparator4,
            this.mnuUndo,
            this.mnuRedo,
            this.toolStripSeparator3,
            this.mnuCut,
            this.mnuCopy,
            this.mnuCopyControlName,
            this.mnuPaste,
            this.mnuDelete,
            this.toolStripSeparator2,
            this.mnuProperty,
            this.mnuToolbox,
            this.mnuSelectObject});
            this.cmenuDesigner.Name = "contextMenuStrip1";
            this.cmenuDesigner.Size = new System.Drawing.Size(169, 314);
            this.cmenuDesigner.Opening += new System.ComponentModel.CancelEventHandler(this.cmenuDesigner_Opening);
            // 
            // mnuScript
            // 
            this.mnuScript.Image = global::Designers.Properties.Resources.Script;
            this.mnuScript.Name = "mnuScript";
            this.mnuScript.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuScript.Size = new System.Drawing.Size(168, 22);
            this.mnuScript.Text = "脚本";
            this.mnuScript.Click += new System.EventHandler(this.mnuScript_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuBringToFront
            // 
            this.mnuBringToFront.Image = global::Designers.Properties.Resources.BringToFront;
            this.mnuBringToFront.Name = "mnuBringToFront";
            this.mnuBringToFront.Size = new System.Drawing.Size(168, 22);
            this.mnuBringToFront.Text = "置顶";
            this.mnuBringToFront.Click += new System.EventHandler(this.mnuBringToFront_Click);
            // 
            // mnuSendToBack
            // 
            this.mnuSendToBack.Image = global::Designers.Properties.Resources.SendToBack;
            this.mnuSendToBack.Name = "mnuSendToBack";
            this.mnuSendToBack.Size = new System.Drawing.Size(168, 22);
            this.mnuSendToBack.Text = "置底";
            this.mnuSendToBack.Click += new System.EventHandler(this.mnuSendToBack_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuUndo
            // 
            this.mnuUndo.Image = global::Designers.Properties.Resources.Undo;
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(168, 22);
            this.mnuUndo.Text = "撤销";
            this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Image = global::Designers.Properties.Resources.Redo;
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuRedo.Size = new System.Drawing.Size(168, 22);
            this.mnuRedo.Text = "重做";
            this.mnuRedo.Click += new System.EventHandler(this.mnuRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuCut
            // 
            this.mnuCut.Image = global::Designers.Properties.Resources.Cut;
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCut.Size = new System.Drawing.Size(168, 22);
            this.mnuCut.Text = "剪切";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::Designers.Properties.Resources.Copy;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(168, 22);
            this.mnuCopy.Text = "复制";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuCopyControlName
            // 
            this.mnuCopyControlName.Name = "mnuCopyControlName";
            this.mnuCopyControlName.Size = new System.Drawing.Size(168, 22);
            this.mnuCopyControlName.Text = "复制名称";
            this.mnuCopyControlName.Click += new System.EventHandler(this.mnuCopyControlName_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = global::Designers.Properties.Resources.Paste;
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuPaste.Size = new System.Drawing.Size(168, 22);
            this.mnuPaste.Text = "粘贴";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Designers.Properties.Resources.Delete;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDelete.Size = new System.Drawing.Size(168, 22);
            this.mnuDelete.Text = "删除";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuProperty
            // 
            this.mnuProperty.Image = global::Designers.Properties.Resources.Property;
            this.mnuProperty.Name = "mnuProperty";
            this.mnuProperty.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuProperty.Size = new System.Drawing.Size(168, 22);
            this.mnuProperty.Text = "属性窗口";
            this.mnuProperty.Click += new System.EventHandler(this.mnuProperty_Click);
            // 
            // mnuToolbox
            // 
            this.mnuToolbox.Image = global::Designers.Properties.Resources.Toolbox;
            this.mnuToolbox.Name = "mnuToolbox";
            this.mnuToolbox.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuToolbox.Size = new System.Drawing.Size(168, 22);
            this.mnuToolbox.Text = "工具窗口";
            this.mnuToolbox.Click += new System.EventHandler(this.mnuToolbox_Click);
            // 
            // mnuSelectObject
            // 
            this.mnuSelectObject.Name = "mnuSelectObject";
            this.mnuSelectObject.Size = new System.Drawing.Size(168, 22);
            this.mnuSelectObject.Text = "选择父容器";
            // 
            // cmenuRebuild
            // 
            this.cmenuRebuild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReNameCb,
            this.mnuReNameDt,
            this.mnuReNameCmb,
            this.mnuReNameRdb,
            this.mnuReNametxt,
            this.toolStripSeparator8,
            this.mnuReNameAll});
            this.cmenuRebuild.Name = "cmenuRebuild";
            this.cmenuRebuild.Size = new System.Drawing.Size(157, 164);
            // 
            // mnuReNameCb
            // 
            this.mnuReNameCb.Name = "mnuReNameCb";
            this.mnuReNameCb.Size = new System.Drawing.Size(156, 22);
            this.mnuReNameCb.Text = "XCheckBox";
            this.mnuReNameCb.Click += new System.EventHandler(this.mnuReNameCb_Click);
            // 
            // mnuReNameDt
            // 
            this.mnuReNameDt.Name = "mnuReNameDt";
            this.mnuReNameDt.Size = new System.Drawing.Size(156, 22);
            this.mnuReNameDt.Text = "XDateTime";
            this.mnuReNameDt.Click += new System.EventHandler(this.mnuReNameDt_Click);
            // 
            // mnuReNameCmb
            // 
            this.mnuReNameCmb.Name = "mnuReNameCmb";
            this.mnuReNameCmb.Size = new System.Drawing.Size(156, 22);
            this.mnuReNameCmb.Text = "XComboBox";
            this.mnuReNameCmb.Click += new System.EventHandler(this.mnuReNameCmb_Click);
            // 
            // mnuReNameRdb
            // 
            this.mnuReNameRdb.Name = "mnuReNameRdb";
            this.mnuReNameRdb.Size = new System.Drawing.Size(156, 22);
            this.mnuReNameRdb.Text = "XRadioButton";
            this.mnuReNameRdb.Click += new System.EventHandler(this.mnuReNameRdb_Click);
            // 
            // mnuReNametxt
            // 
            this.mnuReNametxt.Name = "mnuReNametxt";
            this.mnuReNametxt.Size = new System.Drawing.Size(156, 22);
            this.mnuReNametxt.Text = "XTextBox";
            this.mnuReNametxt.Click += new System.EventHandler(this.mnuReNametxt_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(153, 6);
            // 
            // mnuReNameAll
            // 
            this.mnuReNameAll.Name = "mnuReNameAll";
            this.mnuReNameAll.Size = new System.Drawing.Size(156, 22);
            this.mnuReNameAll.Text = "全部";
            this.mnuReNameAll.Click += new System.EventHandler(this.mnuReNameAll_Click);
            // 
            // DesignEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 485);
            this.Controls.Add(this.formDesigner1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DesignEditForm";
            this.Text = "模板设计";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmenuDesigner.ResumeLayout(false);
            this.cmenuRebuild.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolbtnUndo;
        private System.Windows.Forms.ToolStripButton toolbtnRedo;
        private System.Windows.Forms.ToolStripButton toolbtnCopy;
        private System.Windows.Forms.ToolStripButton toolbtnCut;
        private System.Windows.Forms.ToolStripButton toolbtnPaste;
        private System.Windows.Forms.ToolStripButton toolbtnDelete;
        private System.Windows.Forms.ToolStripButton toolbtnProperty;
        private System.Windows.Forms.ToolStripButton toolbtnToolbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolbtnDebug;
        private Heren.Common.Forms.Designer.FormDesigner formDesigner1;
        private System.Windows.Forms.ContextMenuStrip cmenuDesigner;
        private System.Windows.Forms.ToolStripMenuItem mnuScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnuBringToFront;
        private System.Windows.Forms.ToolStripMenuItem mnuSendToBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyControlName;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectObject;
        private System.Windows.Forms.ToolStripMenuItem mnuProperty;
        private System.Windows.Forms.ToolStripMenuItem mnuToolbox;
        private System.Windows.Forms.ToolStripButton toolbtnMakeReport;
        private System.Windows.Forms.ContextMenuStrip cmenuRebuild;
        private System.Windows.Forms.ToolStripMenuItem mnuReNameCb;
        private System.Windows.Forms.ToolStripMenuItem mnuReNameDt;
        private System.Windows.Forms.ToolStripMenuItem mnuReNameCmb;
        private System.Windows.Forms.ToolStripMenuItem mnuReNameRdb;
        private System.Windows.Forms.ToolStripMenuItem mnuReNametxt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuReNameAll;
    }
}