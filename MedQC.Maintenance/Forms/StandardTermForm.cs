// ***********************************************************
// 病案质控系统ICD10标准诊断库查询窗口.
// Creator:YangMingkun  Date:2009-12-4
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using MedQCSys.DockForms;
using MedQCSys;
namespace Heren.MedQC.Maintenance
{
    public partial class StandardTermForm : DockContentBase
    {
        private Hashtable m_htICDInputCode = null;
        private ListBox m_InputListBox = null;

        public StandardTermForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.OnRefreshView();
            this.btnCloseFind.Image = Heren.MedQC.Maintenance.Properties.Resources.Cancel;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //因为窗口关闭较慢，首先将其隐藏起来。
            this.Hide();
            base.OnFormClosing(e);
            //发现当TreeView中节点过多时,窗口关闭较慢,所以这里做一些处理
            this.treeView1.Nodes.Clear();
            this.treeView1.Dispose();

            if (this.m_htICDInputCode != null)
                this.m_htICDInputCode.Clear();
            if (this.m_InputListBox != null && !this.m_InputListBox.IsDisposed)
                this.m_InputListBox.Dispose();
        }

        public override void OnRefreshView()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Update();
            this.ShowStatusMessage("正在加载ICD10标准诊断库，请稍候...");
            this.LoadICD10Terms();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 从本地ICD10库文件装载ICD10标准诊断库
        /// </summary>
        private void LoadICD10Terms()
        {
            string szICD10LibFile = string.Format("{0}\\ICD10Lib.xml", Application.StartupPath);
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(szICD10LibFile);
            if (xmlDoc == null)
            {
                MessageBoxEx.Show("无法加载ICD10诊断库文件！");
                this.DockHandler.Activate();
                return;
            }

            XmlNode xmlRootNode = GlobalMethods.Xml.SelectXmlNode(xmlDoc, "/ICD10");
            if (xmlRootNode == null || xmlRootNode.ChildNodes.Count <= 0)
                return;

            if (this.m_htICDInputCode != null)
                this.m_htICDInputCode.Clear();

            this.treeView1.SuspendLayout();
            this.treeView1.Nodes.Clear();
            this.CreateICDTree(null, xmlRootNode);
            this.treeView1.ResumeLayout(true);
        }

        /// <summary>
        /// 递归从XML表示的ICD10库文件创建ICD10诊断节点树
        /// </summary>
        /// <param name="treeRootNode">TreeView节点</param>
        /// <param name="xmlRootNode">XML节点</param>
        private void CreateICDTree(TreeNode treeRootNode, XmlNode xmlRootNode)
        {
            if (xmlRootNode == null || xmlRootNode.ChildNodes.Count <= 0)
                return;
            XmlNodeList xmlNodes = xmlRootNode.ChildNodes;
            for (int index = 0; index < xmlNodes.Count; index++)
            {
                XmlNode xmlNode = xmlNodes[index];
                string szDiagCode = null;
                string szDiagName = null;
                string szInputCode = null;
                if (xmlNode.Name == "GROUP")
                {
                    if (!GlobalMethods.Xml.GetXmlNodeValue(xmlNode, "./@ICD10", ref szDiagCode))
                        continue;
                    if (!GlobalMethods.Xml.GetXmlNodeValue(xmlNode, "./@NAME", ref szDiagName))
                        continue;

                    TreeNode groupTreeNode = new TreeNode();
                    groupTreeNode.Text = szDiagName;
                    groupTreeNode.Tag = szDiagCode;
                    groupTreeNode.ImageIndex = 0;
                    groupTreeNode.SelectedImageIndex = 0;
                    if (treeRootNode != null)
                        treeRootNode.Nodes.Add(groupTreeNode);
                    else
                        this.treeView1.Nodes.Add(groupTreeNode);

                    this.CreateICDTree(groupTreeNode, xmlNode);
                }
                else if (xmlNode.Name == "ITEM")
                {
                    if (!GlobalMethods.Xml.GetXmlNodeValue(xmlNode, "./ICD10", ref szDiagCode))
                        continue;
                    if (!GlobalMethods.Xml.GetXmlNodeValue(xmlNode, "./DIAG", ref szDiagName))
                        continue;
                    if (!GlobalMethods.Xml.GetXmlNodeValue(xmlNode, "./INPUT", ref szInputCode))
                        continue;

                    TreeNode itemTreeNode = new TreeNode();
                    itemTreeNode.Text = string.Format("{0}[{1}]", szDiagName, szDiagCode);
                    itemTreeNode.Tag = szDiagCode;
                    itemTreeNode.ImageIndex = 2;
                    itemTreeNode.SelectedImageIndex = 2;
                    if (treeRootNode != null)
                        treeRootNode.Nodes.Add(itemTreeNode);
                    else
                        this.treeView1.Nodes.Add(itemTreeNode);
                    this.AddInputCodeList(szInputCode, itemTreeNode, ref this.m_htICDInputCode);
                }
            }
        }

        /// <summary>
        /// 将术语的输入码和术语对应的树节点存放到一张HashTable中,以便检索
        /// </summary>
        /// <param name="szInputCode">术语的输入码</param>
        /// <param name="treeNode">术语对应的树节点</param>
        /// <param name="htInputCode">存放的HashTable</param>
        private void AddInputCodeList(string szInputCode, TreeNode treeNode, ref  Hashtable htInputCode)
        {
            if (GlobalMethods.Misc.IsEmptyString(szInputCode))
                return;
            if (htInputCode == null)
                htInputCode = new Hashtable();
            for (int index = 0; index < szInputCode.Length; index++)
            {
                string szSubInputCode = szInputCode.Substring(0, index + 1);
                if (GlobalMethods.Misc.IsEmptyString(szSubInputCode))
                    continue;
                ArrayList list = null;
                if (htInputCode.Contains(szSubInputCode))
                {
                    list = htInputCode[szSubInputCode] as ArrayList;
                    list.Add(treeNode);
                }
                else
                {
                    list = new ArrayList();
                    list.Add(treeNode);
                    htInputCode.Add(szSubInputCode, list);
                }
            }
        }

        /// <summary>
        /// 显示查找结果列表窗口
        /// </summary>
        private void ShowFindListBox()
        {
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
            {
                this.m_InputListBox = new ListBox();
                this.m_InputListBox.IntegralHeight = false;
                this.m_InputListBox.Font = this.treeView1.Font;
                this.m_InputListBox.Anchor = this.treeView1.Anchor;
                this.m_InputListBox.Bounds = this.treeView1.Bounds;
                this.m_InputListBox.Parent = this.treeView1.Parent;
                this.m_InputListBox.Sorted = true;
                this.m_InputListBox.ImeMode = ImeMode.Off;
                this.m_InputListBox.DrawMode = DrawMode.OwnerDrawFixed;
                this.m_InputListBox.ItemHeight = this.m_InputListBox.Font.Height + 4;
                this.m_InputListBox.ContextMenuStrip = this.cmenuICD10Tree;
                this.m_InputListBox.DrawItem += new DrawItemEventHandler(this.InputListBox_DrawItem);
                this.m_InputListBox.MouseDown += new MouseEventHandler(this.InputListBox_MouseDown);
            }
            this.m_InputListBox.Items.Clear();
            this.m_InputListBox.Show();
            this.m_InputListBox.BringToFront();
            this.m_InputListBox.Update();
        }

        private void CloseFindListBox()
        {
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
                return;
            if (this.m_InputListBox.Visible)
                this.m_InputListBox.Hide();
            this.m_InputListBox.Items.Clear();
        }

        /// <summary>
        /// 模糊查找指定的诊断
        /// </summary>
        /// <param name="szDiagnoseName">诊断名称</param>
        internal void FindDiagnoseByName(string szDiagnoseName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szDiagnoseName))
            {
                this.CloseFindListBox();
                return;
            }
            szDiagnoseName = szDiagnoseName.Trim();
            this.txtFuzzyFind.Focus();
            this.txtFuzzyFind.Text = szDiagnoseName;
            this.txtFuzzyFind.SelectAll();
            this.Update();

            string szICD10LibFile = string.Format("{0}\\ICD10Lib.xml", GlobalMethods.Misc.GetWorkingPath());
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(szICD10LibFile);
            if (xmlDoc == null)
            {
                MessageBoxEx.Show("无法加载ICD10诊断库文件！");
                return;
            }

            string szXPath = string.Format("//DIAG[contains(.,'{0}')]", szDiagnoseName);
            XmlNodeList icdTermList = GlobalMethods.Xml.SelectXmlNodes(xmlDoc, szXPath);
            if (icdTermList == null || icdTermList.Count <= 0)
            {
                this.CloseFindListBox();
                return;
            }

            this.ShowFindListBox();

            for (int index = 0; icdTermList != null && index < icdTermList.Count; index++)
            {
                XmlNode xmlNode = icdTermList.Item(index);
                string szDiagName = xmlNode.InnerText.Trim();
                if (szDiagName == string.Empty)
                    continue;
                XmlNode xmlParentNode = xmlNode.ParentNode;
                string szDiagCode = string.Empty;
                if (!GlobalMethods.Xml.GetXmlNodeValue(xmlParentNode, "./ICD10", ref szDiagCode))
                    continue;
                TreeNode itemTreeNode = new TreeNode();
                itemTreeNode.Text = string.Format("{0}[{1}]", szDiagName, szDiagCode);
                itemTreeNode.Tag = szDiagCode;
                this.m_InputListBox.Items.Add(itemTreeNode);
            }
        }

        /// <summary>
        /// 模糊查找指定的诊断
        /// </summary>
        /// <param name="szPinyin">诊断名称简拼</param>
        internal void FindDiagnoseByPinyin(string szPinyin)
        {
            if (GlobalMethods.Misc.IsEmptyString(szPinyin))
            {
                this.CloseFindListBox();
                return;
            }
            ArrayList arrlstIcdTerm = null;
            if (this.m_htICDInputCode != null && this.m_htICDInputCode.Contains(szPinyin))
                arrlstIcdTerm = this.m_htICDInputCode[szPinyin] as ArrayList;

            if (arrlstIcdTerm == null || arrlstIcdTerm.Count <= 0)
            {
                this.CloseFindListBox();
                return;
            }
            this.ShowFindListBox();

            for (int index = 0; index < arrlstIcdTerm.Count; index++)
            {
                TreeNode node = arrlstIcdTerm[index] as TreeNode;
                if (node != null && !GlobalMethods.Misc.IsEmptyString(node.Text))
                    this.m_InputListBox.Items.Add(node);
            }
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = this.treeView1.GetNodeAt(e.Location);
            if (node != null)
                this.treeView1.SelectedNode = node;
        }

        private void txtFuzzyFind_ButtonClick(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDiagnoseByName(this.txtFuzzyFind.Text.Trim());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void txtPinyinFind_ButtonClick(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDiagnoseByPinyin(this.txtPinyinFind.Text.Trim());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void txtPinyinFind_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDiagnoseByPinyin(this.txtPinyinFind.Text.Trim());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnCloseFind_Click(object sender, EventArgs e)
        {
            this.CloseFindListBox();
        }

        private void InputListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
                return;
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0 || e.Index >= this.m_InputListBox.Items.Count)
                return;
            TreeNode node = this.m_InputListBox.Items[e.Index] as TreeNode;
            if (node == null)
                return;
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.FormatFlags = StringFormatFlags.NoWrap;
            SolidBrush brush = new SolidBrush(e.ForeColor);
            Rectangle bounds = e.Bounds;
            bounds.Y += (e.Bounds.Height - e.Font.Height) / 2 + 1;
            e.Graphics.DrawString(node.Text, e.Font, brush, bounds, format);
            brush.Dispose();
            format.Dispose();
        }

        private void InputListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
                return;
            if (e.Button != MouseButtons.Right)
                return;
            int index = this.m_InputListBox.IndexFromPoint(e.Location);
            if (index < 0 || index >= this.m_InputListBox.Items.Count)
                return;
            this.m_InputListBox.SelectedIndex = index;
        }

        private void cmenuICD10Tree_Opening(object sender, CancelEventArgs e)
        {
            this.mnuCopyItemName.Enabled = false;
            TreeNode selectedNode = null;
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
                selectedNode = this.treeView1.SelectedNode;
            else if (this.m_InputListBox.Visible)
                selectedNode = this.m_InputListBox.SelectedItem as TreeNode;
            else
                selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return;
            this.mnuCopyItemName.Enabled = true;
        }

        private void mnuCopyItemName_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = null;
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
                selectedNode = this.treeView1.SelectedNode;
            else if (this.m_InputListBox.Visible)
                selectedNode = this.m_InputListBox.SelectedItem as TreeNode;
            else
                selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return;
            string szItemName = selectedNode.Text;
            //if (selectedNode.Tag != null && GlobalMethods.Misc.IsEmptyString(selectedNode.Tag.ToString()))
            //    szItemName += selectedNode.Tag.ToString();
            try
            {
                Clipboard.SetText(szItemName);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("StandardTermForm.mnuCopyItemName_Click", ex);
            }
        }
    }
}