using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using MDSDBLib;
using MedDocSys.DataLayer;

namespace MedQCSys.Dialogs
{
    internal partial class IcdQueryForm:Form
    {
        private Hashtable m_htICDInputCode = null;
        private ListBox m_InputListBox = null;

        public IcdQueryForm()
            : base()
        {
            this.InitializeComponent();
            this.Icon = Properties.Resources.ICDIcon;
            this.rtbPinyinFind.Checked = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.Update();
            //this.LoadICD10Terms();
            this.LoadICDDiagnosis();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        private void LoadICDDiagnosis()
        {
            List<ICDDiagnosisInfo> lstDiagnosis = new List<ICDDiagnosisInfo>();
            DataAccess.GetICDDiagnosisList(50, ref lstDiagnosis);
            if (lstDiagnosis == null || lstDiagnosis.Count == 0)
            {
                return;
            }
            else
            {
                foreach (ICDDiagnosisInfo diagnosis in lstDiagnosis)
                {
                    if (diagnosis.IsLeaf)
                    {
                        CreateLeafNode(null, diagnosis);
                    }
                    else
                    {
                        CreateGroupDiagnosis(null, diagnosis);
                    }
                }
            }
        }

        private void CreateGroupDiagnosis(TreeNode node, ICDDiagnosisInfo diagnosis)
        {
            TreeNode groupTreeNode = new TreeNode();
            groupTreeNode.Text = diagnosis.DiagnosisName;
            groupTreeNode.Tag = diagnosis;
            groupTreeNode.Name = diagnosis.DiagnosisCode;
            groupTreeNode.ImageIndex = 0;
            groupTreeNode.SelectedImageIndex = 0;
            //创建下一级节点
            List<ICDDiagnosisInfo> lstNextLevelNodes = new List<ICDDiagnosisInfo>();
            DataAccess.GetICDDiagnosisAndGroupList(diagnosis.DiagnosisCode, ref lstNextLevelNodes);
            if (lstNextLevelNodes != null && lstNextLevelNodes.Count > 0)
            {
                foreach (ICDDiagnosisInfo nextNode in lstNextLevelNodes)
                {
                    bool isCreated = groupTreeNode.Nodes.Find(nextNode.DiagnosisCode, false).Length > 0 ? true : false;
                    if (!isCreated && nextNode.IsLeaf)
                    {
                        CreateLeafNode(groupTreeNode, nextNode);
                    }
                    else if (!isCreated)
                    {
                        CreateGroupNode(groupTreeNode, nextNode);
                    }
                }
            }
            groupTreeNode.Collapse();
            if (node != null)
            {
                node.Nodes.Add(groupTreeNode);
            }
            else
            {
                this.treeView1.Nodes.Add(groupTreeNode);
            }
        }

        /// <summary>
        /// 从本地ICD10库文件装载ICD10标准诊断库
        /// </summary>
        private void LoadICD10Terms()
        {
            string szICD10LibFile = string.Format("{0}\\ICD10Lib.xml", GlobalMethods.Misc.GetWorkingPath());
            XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(szICD10LibFile);
            if (xmlDoc == null)
            {
                MessageBoxEx.Show("无法加载ICD10诊断库文件!");
               
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
                    //groupTreeNode.Tag = szDiagCode;
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
                this.m_InputListBox.KeyDown += new KeyEventHandler(this.InputListBox_KeyDown);
                this.m_InputListBox.DoubleClick += new EventHandler(this.InputListBox_DoubleClick);
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
            if (!this.rtbPinyinFind.Checked)
                this.rtbFuzzyFind.Checked = true;

            if (GlobalMethods.Misc.IsEmptyString(szDiagnoseName))
            {
                this.CloseFindListBox();
                return;
            }
            szDiagnoseName = szDiagnoseName.Trim();
            //this.txtFuzzyFind.Focus();
            //this.txtPinyinFind.Text = szDiagnoseName;
            this.txtPinyinFind.SelectAll();
            this.Update();

            List<ICDDiagnosisInfo> lstDiagnosis = new List<ICDDiagnosisInfo>();
            DataAccess.GetMarchDiagnosisListByName(30, szDiagnoseName, ref lstDiagnosis);
            if (lstDiagnosis != null && lstDiagnosis.Count > 0)
            {
                this.ShowFindListBox();
                foreach (ICDDiagnosisInfo diagnosis in lstDiagnosis)
                {
                    TreeNode itemTreeNode = new TreeNode();
                    itemTreeNode.Text = string.Format("{0}[{1}]", diagnosis.DiagnosisName, diagnosis.DiagnosisCode);
                    itemTreeNode.Tag = diagnosis;
                    this.m_InputListBox.Items.Add(itemTreeNode);
                }
            }
            else
            {
                this.CloseFindListBox();
                return;
            }
            //if (!this.rtbFuzzyFind.Checked)
            //    this.rtbPinyinFind.Checked = true;

            //if (GlobalMethods.Misc.IsEmptyString(szDiagnoseName))
            //{
            //    this.CloseFindListBox();
            //    return;
            //}
            //szDiagnoseName = szDiagnoseName.Trim();
            //this.txtFuzzyFind.Focus();
            //this.txtFuzzyFind.Text = szDiagnoseName;
            //this.txtFuzzyFind.SelectAll();
            //this.Update();

            //string szICD10LibFile = string.Format("{0}\\ICD10Lib.xml", GlobalMethods.Misc.GetWorkingPath());
            //XmlDocument xmlDoc = GlobalMethods.Xml.GetXmlDocument(szICD10LibFile);
            //if (xmlDoc == null)
            //{
            //    MessageBoxEx.Show("无法加载ICD10诊断库文件!");
            //    return;
            //}

            //string szXPath = string.Format("//DIAG[contains(.,'{0}')]", szDiagnoseName);
            //XmlNodeList icdTermList = GlobalMethods.Xml.SelectXmlNodes(xmlDoc, szXPath);
            //if (icdTermList == null || icdTermList.Count <= 0)
            //{
            //    this.CloseFindListBox();
            //    return;
            //}

            //this.ShowFindListBox();

            //for (int index = 0; icdTermList != null && index < icdTermList.Count; index++)
            //{
            //    XmlNode xmlNode = icdTermList.Item(index);
            //    string szDiagName = xmlNode.InnerText.Trim();
            //    if (szDiagName == string.Empty)
            //        continue;
            //    XmlNode xmlParentNode = xmlNode.ParentNode;
            //    string szDiagCode = string.Empty;
            //    if (!GlobalMethods.Xml.GetXmlNodeValue(xmlParentNode, "./ICD10", ref szDiagCode))
            //        continue;
            //    TreeNode itemTreeNode = new TreeNode();
            //    itemTreeNode.Text = string.Format("{0}[{1}]", szDiagName, szDiagCode);
            //    itemTreeNode.Tag = szDiagCode;
            //    this.m_InputListBox.Items.Add(itemTreeNode);
            //}
        }

        /// <summary>
        /// 模糊查找指定的诊断
        /// </summary>
        /// <param name="szPinyin">诊断名称简拼</param>
        internal void FindDiagnoseByPinyin(string szPinyin)
        {
            if (!this.rtbFuzzyFind.Checked)
                this.rtbPinyinFind.Checked = true;

            if (GlobalMethods.Misc.IsEmptyString(szPinyin))
            {
                this.CloseFindListBox();
                return;
            }
            szPinyin = szPinyin.Trim();
            this.txtPinyinFind.Focus();
            //this.txtFuzzyFind.Text = szPinyin;
            this.txtFuzzyFind.SelectAll();
            this.Update();

            List<ICDDiagnosisInfo> lstDiagnosis = new List<ICDDiagnosisInfo>();
            DataAccess.GetMarchDiagnosisListByPinyin(30, szPinyin, ref lstDiagnosis);
            if (lstDiagnosis != null && lstDiagnosis.Count > 0)
            {
                this.ShowFindListBox();
                foreach (ICDDiagnosisInfo diagnosis in lstDiagnosis)
                {
                    TreeNode itemTreeNode = new TreeNode();
                    itemTreeNode.Text = string.Format("{0}[{1}]", diagnosis.DiagnosisName, diagnosis.DiagnosisCode);
                    itemTreeNode.Tag = diagnosis;
                    this.m_InputListBox.Items.Add(itemTreeNode);
                }
            }
            else
            {
                this.CloseFindListBox();
                return;
            }

            //if (GlobalMethods.Misc.IsEmptyString(szPinyin))
            //{
            //    this.CloseFindListBox();
            //    return;
            //}
            //ArrayList arrlstIcdTerm = null;
            //if (this.m_htICDInputCode != null && this.m_htICDInputCode.Contains(szPinyin))
            //    arrlstIcdTerm = this.m_htICDInputCode[szPinyin] as ArrayList;

            //if (arrlstIcdTerm == null || arrlstIcdTerm.Count <= 0)
            //{
            //    this.CloseFindListBox();
            //    return;
            //}
            //this.ShowFindListBox();

            //for (int index = 0; index < arrlstIcdTerm.Count; index++)
            //{
            //    TreeNode node = arrlstIcdTerm[index] as TreeNode;
            //    if (node != null && !GlobalMethods.Misc.IsEmptyString(node.Text))
            //        this.m_InputListBox.Items.Add(node);
            //}
        }
        public string szSelectedDiagnosis = string.Empty;
        /// <summary>
        /// 插入指定节点到文档中
        /// </summary>
        /// <param name="treeNode">TreeNode节点</param>
        private void InsertTermToDoc(TreeNode treeNode)
        {
            
            if (treeNode == null || treeNode.Tag == null)
                return;
            this.Update();
            this.DialogResult = DialogResult.OK;
            ICDDiagnosisInfo diagnosisInfo = treeNode.Tag as ICDDiagnosisInfo;
            if (diagnosisInfo == null)
                return;
            this.szSelectedDiagnosis =diagnosisInfo.DiagnosisName;
          //  this.MedDocCtrl.ImportTextData(treeNode.Text);
        }

        private void txtFuzzyFind_ButtonClick(object sender, EventArgs e)
        {
            if (this.txtFuzzyFind.Text.Trim() == "")
            { return; }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDiagnoseByName(this.txtFuzzyFind.Text.Trim());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void txtFuzzyFind_TextChanged(object sender, EventArgs e)
        {
            if (this.rtbFuzzyFind.Checked == false)
                return;
            if (this.txtFuzzyFind.Text.Trim() == "")
            {
                this.CloseFindListBox();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDiagnoseByName(this.txtFuzzyFind.Text.Trim());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void txtPinyinFind_ButtonClick(object sender, EventArgs e)
        {
            if (this.txtPinyinFind.Text.Trim() == "")
            { return; }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDiagnoseByPinyin(this.txtPinyinFind.Text.Trim());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void txtPinyinFind_TextChanged(object sender, EventArgs e)
        {
            if (this.rtbPinyinFind.Checked == false)
                return;
            if (this.txtPinyinFind.Text.Trim() == "")
            {
                this.CloseFindListBox();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDiagnoseByPinyin(this.txtPinyinFind.Text.Trim());
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            this.treeView1.SelectedNode = e.Node;
            //图标更换
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
            //加载各节点的子节点
            foreach (TreeNode node in e.Node.Nodes)
            {
                List<ICDDiagnosisInfo> lstGroupDiagnosis = new List<ICDDiagnosisInfo>();
                ICDDiagnosisInfo diagnosis = node.Tag as ICDDiagnosisInfo;
                if (diagnosis == null || node.ImageIndex != 0)
                {
                    continue;
                }
                DataAccess.GetICDDiagnosisAndGroupList(diagnosis.DiagnosisCode, ref lstGroupDiagnosis);
                if (lstGroupDiagnosis != null && lstGroupDiagnosis.Count > 0)
                {
                    foreach (ICDDiagnosisInfo info in lstGroupDiagnosis)
                    {
                        if (node.Nodes.Find(info.DiagnosisCode, false).Length < 1)
                        {
                            if (info.IsLeaf)
                            {
                                //创建叶子节点
                                CreateLeafNode(node, info);
                            }
                            else
                            {
                                CreateGroupNode(node, info);
                            }
                        }
                    }
                }
            }
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
            this.treeView1.SelectedNode = e.Node;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            ICDDiagnosisInfo diagnosisInfo = node.Tag as ICDDiagnosisInfo;
            if (diagnosisInfo != null && diagnosisInfo.IsLeaf)
            {
                this.InsertTermToDoc(node);
            }
        }

        /// <summary>
        /// 在指定节点处创建叶子节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="info"></param>
        private void CreateLeafNode(TreeNode node, ICDDiagnosisInfo info)
        {
            TreeNode leafNode = new TreeNode();
            leafNode.Text = info.DiagnosisName + string.Format("[{0}]", info.DiagnosisCode);
            leafNode.Tag = info;
            leafNode.Name = info.DiagnosisCode;

            leafNode.ImageIndex = 2;
            leafNode.SelectedImageIndex = 2;
            if (node != null)
            {
                node.Nodes.Add(leafNode);
            }
            else
            {
                this.treeView1.Nodes.Add(leafNode);
            }
        }

        /// <summary>
        /// 在指定节点处创建叶子节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="info"></param>
        private void CreateGroupNode(TreeNode parentNode, ICDDiagnosisInfo info)
        {
            TreeNode leafNode = new TreeNode();
            leafNode.Text = info.DiagnosisName;
            leafNode.Tag = info;
            leafNode.Name = info.DiagnosisCode;

            leafNode.ImageIndex = 0;
            leafNode.SelectedImageIndex = 0;
            if (parentNode != null)
            {
                parentNode.Nodes.Add(leafNode);
            }
            else
            {
                this.treeView1.Nodes.Add(leafNode);
            }
        }

        private void InputListBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
                return;
            if (this.m_InputListBox.SelectedIndex < 0)
                return;
            this.InsertTermToDoc(this.m_InputListBox.SelectedItem as TreeNode);
        }

        private void InputListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (this.m_InputListBox.SelectedIndex > 0)
                    return;
                if (this.rtbPinyinFind.Checked)
                {
                    this.txtPinyinFind.Focus();
                    this.txtPinyinFind.SelectAll();
                }
                else
                {
                    this.txtFuzzyFind.Focus();
                    this.txtFuzzyFind.SelectAll();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (this.m_InputListBox.SelectedIndex < this.m_InputListBox.Items.Count - 1)
                    return;
                if (this.rtbPinyinFind.Checked)
                {
                    this.txtPinyinFind.Focus();
                    this.txtPinyinFind.SelectAll();
                }
                else
                {
                    this.txtFuzzyFind.Focus();
                    this.txtFuzzyFind.SelectAll();
                }
            }
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
            this.mnuInsertSelectedItem.Enabled = false;
            TreeNode selectedNode = null;
            if (this.m_InputListBox == null || this.m_InputListBox.IsDisposed)
                selectedNode = this.treeView1.SelectedNode;
            else if (this.m_InputListBox.Visible)
                selectedNode = this.m_InputListBox.SelectedItem as TreeNode;
            else
                selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return;
            this.mnuInsertSelectedItem.Enabled = true;
        }

        private void mnuInsertSelectedItem_Click(object sender, EventArgs e)
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
            this.InsertTermToDoc(selectedNode);
        }

        private void btnCloseFind_Click(object sender, EventArgs e)
        {
            this.CloseFindListBox();
        }

        private void FindRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.txtFuzzyFind.Enabled = this.rtbFuzzyFind.Checked;
            this.txtPinyinFind.Enabled = this.rtbPinyinFind.Checked;
            if (this.rtbFuzzyFind.Checked)
            {
                this.txtFuzzyFind.Focus();
                this.txtFuzzyFind.SelectionStart = this.txtFuzzyFind.TextLength;
                this.txtPinyinFind.Text = string.Empty;
            }
            else if (this.rtbPinyinFind.Checked)
            {
                this.txtPinyinFind.Focus();
                this.txtPinyinFind.SelectionStart = this.txtPinyinFind.TextLength; 
                this.txtFuzzyFind.Text = string.Empty;
            }
        }

        private void txtPinyinFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 'A' || e.KeyChar > 'Z' && e.KeyChar < 'a' || e.KeyChar > 'z')
            {
                e.Handled = true;
            }
            //此为退格键可以输入
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }


    }
}