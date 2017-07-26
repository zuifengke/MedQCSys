using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;

namespace Heren.MedQC.ScriptEngine.Debugger
{
    internal partial class TempletListForm : DockContentBase
    {
        /// <summary>
        /// 样例树节点选中后出发事件
        /// </summary>
        public event TreeViewEventHandler AfterSelected;
        protected virtual void OnAfterSelected(TreeViewEventArgs e)
        {
            if (this.AfterSelected != null)
                this.AfterSelected(this, e);
        }

        /// <summary>
        /// 样例节点双击事件
        /// </summary>
        public event TreeNodeMouseClickEventHandler NodeDoubleClick;
        protected virtual void OnNodeDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            if (this.NodeDoubleClick != null)
                this.NodeDoubleClick(this, e);
        }

        /// <summary>
        /// 获取当前选中的节点
        /// </summary>
        internal TreeNode SelectedNode
        {
            get { return this.treeView1.SelectedNode; }
        }

        public TempletListForm(DebuggerForm mainForm)
            : base(mainForm)
        {
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.DockRight | DockAreas.DockRight;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            this.Icon = Properties.Resources.ExampleIcon;
        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            if (this.DebuggerForm == null)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.treeView1.Nodes.Clear();
            this.CreateSamplesTree(null
                , this.DebuggerForm.WorkingPath + "\\Script\\Examples");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 创建脚本样例模板目录树
        /// </summary>
        /// <param name="rootNode">目录树根节点</param>
        /// <param name="rootPath">目录树根节点目录路径</param>
        private void CreateSamplesTree(TreeNode rootNode, string rootPath)
        {
            if (GlobalMethods.Misc.IsEmptyString(rootPath))
                return;
            if (!Directory.Exists(rootPath))
                return;
            FileInfo[] files = GlobalMethods.IO.GetFiles(rootPath);
            foreach (FileInfo fileInfo in files)
            {
                string szFileExt = fileInfo.Extension;
                if (!szFileExt.EndsWith(".vbs", StringComparison.OrdinalIgnoreCase))
                    continue;
                TreeNode fileNode = new TreeNode(fileInfo.Name);
                fileNode.Tag = fileInfo.FullName;
                fileNode.ImageIndex = 0;
                fileNode.StateImageIndex = 0;
                fileNode.SelectedImageIndex = 0;
                if (rootNode != null)
                    rootNode.Nodes.Add(fileNode);
                else
                    this.treeView1.Nodes.Add(fileNode);
            }
            DirectoryInfo[] directorys = GlobalMethods.IO.GetDirectories(rootPath);
            foreach (DirectoryInfo directory in directorys)
            {
                TreeNode dirNode = new TreeNode(directory.Name);
                dirNode.Tag = directory.FullName;
                dirNode.ImageIndex = 1;
                dirNode.StateImageIndex = 1;
                dirNode.SelectedImageIndex = 1;
                if (rootNode != null)
                    rootNode.Nodes.Add(dirNode);
                else
                    this.treeView1.Nodes.Add(dirNode);
                this.CreateSamplesTree(dirNode, directory.FullName);
                if (dirNode.Parent == null && dirNode.Nodes.Count > 0) dirNode.Expand();
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            string szFullName = e.Node.Tag as string;
            if (szFullName.EndsWith(".vbs", StringComparison.OrdinalIgnoreCase))
                return;
            e.Node.ImageIndex = 2;
            e.Node.SelectedImageIndex = 2;
            e.Node.StateImageIndex = 2;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
                return;
            string szFullName = e.Node.Tag as string;
            if (szFullName.EndsWith(".vbs", StringComparison.OrdinalIgnoreCase))
                return;
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
            e.Node.StateImageIndex = 1;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.OnAfterSelected(e);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.OnNodeDoubleClick(e);
            if (e.Node.Tag == null)
                return;
            if (this.DebuggerForm == null || this.DebuggerForm.IsDisposed)
                return;
            string szFullName = e.Node.Tag as string;
            if (!GlobalMethods.Misc.IsEmptyString(szFullName))
                this.DebuggerForm.OpenScript(szFullName);
        }
    }
}