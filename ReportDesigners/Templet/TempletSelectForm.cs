// ***********************************************************
// 护理病历配置管理系统,表单模板选择对话框.
// 主要用于导出和导入表单模板功能中,选择导出导入哪些模板
// Author : YangMingkun, Date : 2012-6-10
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace Designers.Templet
{
    internal partial class TempletSelectForm : HerenForm
    {
        private Hashtable m_htDocTypeNodes = null;
        private bool m_bMultiSelect = true;

        /// <summary>
        /// 获取或设置当前是否允许多选
        /// </summary>
        [DefaultValue(true)]
        public bool MultiSelect
        {
            get { return this.m_bMultiSelect; }
            set { this.m_bMultiSelect = value; }
        }

        private string m_szDescription = "请选择模板：";

        /// <summary>
        /// 获取或设置当前对话框描述信息
        /// </summary>
        [DefaultValue("请选择模板：")]
        public string Description
        {
            get { return this.m_szDescription; }
            set { this.m_szDescription = value; }
        }

        private string m_szApplyEnv = null;

        /// <summary>
        /// 获取或设置当前文档类型应用环境
        /// </summary>
        [Browsable(false)]
        public string ApplyEnv
        {
            get { return this.m_szApplyEnv; }
            set { this.m_szApplyEnv = value; }
        }

        private string m_szDefaultDocTypeID = null;

        /// <summary>
        /// 获取或设置当前默认选中的文档类型.
        /// 注意当有多个默认时,可以使用分号分隔
        /// </summary>
        [Browsable(false)]
        public string DefaultDocTypeID
        {
            get { return this.m_szDefaultDocTypeID; }
            set { this.m_szDefaultDocTypeID = value; }
        }

        private List<TempletType> m_lstSelectedDocTypes = null;

        /// <summary>
        /// 获取或设置已经勾选的病历类型
        /// </summary>
        [Browsable(false)]
        public List<TempletType> SelectedDocTypes
        {
            get { return this.m_lstSelectedDocTypes; }
        }

        public TempletSelectForm()
        {
            this.InitializeComponent();

            string[] applyEnvs = SystemData.TempletTypeApplyEnv.GetApplyEnvNames();
            this.cboApplyEnv.Items.AddRange(applyEnvs);
            this.cboApplyEnv.Items.Add("<所有表单类型>");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_bMultiSelect)
            {
                this.treeView1.CheckBoxes = true;
                this.treeView1.FullRowSelect = false;
                this.chkCheckAll.Visible = true;
            }
            else
            {
                this.treeView1.CheckBoxes = false;
                this.treeView1.FullRowSelect = true;
                this.chkCheckAll.Visible = false;
            }
            this.lblTipInfo.Text = this.m_szDescription;
            if (!GlobalMethods.Misc.IsEmptyString(this.m_szApplyEnv))
                this.LoadDocTypeList(this.m_szApplyEnv);
            this.SetDefaultSelectedNodes();

            this.cboApplyEnv.Text =
                SystemData.TempletTypeApplyEnv.GetApplyEnvName(this.m_szApplyEnv);
            this.cboApplyEnv.SelectedIndexChanged +=
                new EventHandler(this.cboApplyEnv_SelectedIndexChanged);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 加载病历类型信息列表树
        /// </summary>
        private void LoadDocTypeList(string szApplyEnv)
        {
            this.treeView1.Nodes.Clear();
            if (this.m_htDocTypeNodes == null)
                this.m_htDocTypeNodes = new Hashtable();
            this.m_htDocTypeNodes.Clear();
            this.Update();

            List<TempletType> lstDocTypeInfos = null;
            short shRet =TempletTypeAccess.Instance.GetTempletTypes(szApplyEnv, ref lstDocTypeInfos);
            if (shRet != SystemData.ReturnValue.OK
                &&shRet!=SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.ShowError("护理病历模板列表下载失败!");
                return;
            }
            if (lstDocTypeInfos == null)
                return;

            //先创建节点哈希列表
            Dictionary<string, TreeNode> nodeTable = new Dictionary<string, TreeNode>();
            foreach (TempletType docTypeInfo in lstDocTypeInfos)
            {
                TreeNode docTypeNode = new TreeNode();
                docTypeNode.Tag = docTypeInfo;
                docTypeNode.Text = docTypeInfo.DocTypeName;

                if (!docTypeInfo.IsValid || !docTypeInfo.IsVisible)
                    docTypeNode.ForeColor = Color.Silver;

                if (!docTypeInfo.IsFolder)
                    docTypeNode.ImageIndex = 2;
                else
                    docTypeNode.ImageIndex = 0;
                docTypeNode.SelectedImageIndex = docTypeNode.ImageIndex;

                if (!nodeTable.ContainsKey(docTypeInfo.DocTypeID))
                    nodeTable.Add(docTypeInfo.DocTypeID, docTypeNode);
                if (!this.m_htDocTypeNodes.Contains(docTypeInfo.DocTypeID))
                    this.m_htDocTypeNodes.Add(docTypeInfo.DocTypeID, docTypeNode);
            }

            //将节点连接起来,添加到树中
            foreach (KeyValuePair<string, TreeNode> pair in nodeTable)
            {
                if (string.IsNullOrEmpty(pair.Key) || pair.Value == null)
                    continue;

                TempletType docTypeInfo = pair.Value.Tag as TempletType;
                if (docTypeInfo == null)
                    continue;

                if (string.IsNullOrEmpty(docTypeInfo.ParentID))
                {
                    this.treeView1.Nodes.Add(pair.Value);
                }
                else
                {
                    TreeNodeCollection nodes = null;
                    if (!nodeTable.ContainsKey(docTypeInfo.ParentID))
                        nodes = this.treeView1.Nodes;

                    TreeNode parentNode = nodeTable[docTypeInfo.ParentID];
                    if (parentNode != null)
                        parentNode.Nodes.Add(pair.Value);
                    else
                        this.treeView1.Nodes.Add(pair.Value);
                }
            }
            this.treeView1.ExpandAll();
            if (this.treeView1.Nodes.Count > 0) this.treeView1.Nodes[0].EnsureVisible();
        }

        /// <summary>
        /// 显示默认选中的节点
        /// </summary>
        private void SetDefaultSelectedNodes()
        {
            if (this.m_htDocTypeNodes == null)
                return;
            if (GlobalMethods.Misc.IsEmptyString(this.m_szDefaultDocTypeID))
                return;
            //默认选中所有
            if (this.m_szDefaultDocTypeID.IndexOf("所有") >= 0)
            {
                foreach (DictionaryEntry dic in this.m_htDocTypeNodes)
                {
                    TreeNode defaultSelectedNode = null;
                    defaultSelectedNode = dic.Value as TreeNode;
                    if (defaultSelectedNode == null)
                        return;
                    defaultSelectedNode.Checked = true;
                }
                return;
            }
            string[] lstDocTypes = this.m_szDefaultDocTypeID.Split(';');
            if (lstDocTypes == null || lstDocTypes.Length == 0)
                return;
            if (!this.treeView1.CheckBoxes)
            {
                TreeNode defaultSelectedNode = null;
                defaultSelectedNode = this.m_htDocTypeNodes[lstDocTypes[0].Trim()] as TreeNode;
                if (defaultSelectedNode == null)
                    return;
                defaultSelectedNode.EnsureVisible();
                this.treeView1.SelectedNode = defaultSelectedNode;
            }
            for (int index = 0; index < lstDocTypes.Length; index++)
            {
                string szDocTypeID = lstDocTypes[index];
                if (!this.m_htDocTypeNodes.Contains(szDocTypeID))
                    continue;
                TreeNode defaultSelectedNode = null;
                defaultSelectedNode = this.m_htDocTypeNodes[szDocTypeID] as TreeNode;
                if (defaultSelectedNode == null)
                    return;
                defaultSelectedNode.Checked = true;
            }
            this.m_htDocTypeNodes.Clear();
        }

        /// <summary>
        /// 获取当前TreeView树中已勾选的病历类型信息列表
        /// </summary>
        /// <returns>病历类型信息列表</returns>
        private List<TempletType> GetSelectedDocTypeList()
        {
            List<TempletType> lstDocTypeInfos = new List<TempletType>();
            if (!this.treeView1.CheckBoxes)
            {
                TreeNode selectedNode = this.treeView1.SelectedNode;
                if (selectedNode == null)
                    return lstDocTypeInfos;
                TempletType docTypeInfo = selectedNode.Tag as TempletType;
                if (docTypeInfo == null)
                    return lstDocTypeInfos;
                lstDocTypeInfos.Add(docTypeInfo);
                return lstDocTypeInfos;
            }
            for (int parentIndex = 0; parentIndex < this.treeView1.Nodes.Count; parentIndex++)
            {
                TreeNode parentNode = this.treeView1.Nodes[parentIndex];
                if (parentNode.Checked)
                    lstDocTypeInfos.Add(parentNode.Tag as TempletType);
                if (parentNode.Nodes.Count > 0)
                    this.GetSelectedDocTypeList(parentNode, ref lstDocTypeInfos);
            }
            return lstDocTypeInfos;
        }

        private void GetSelectedDocTypeList(TreeNode parentNode, ref List<TempletType> lstDocTypeInfos)
        {
            if (lstDocTypeInfos == null)
            {
                lstDocTypeInfos = new List<TempletType>();
            }
            for (int nodeIndex = 0; nodeIndex < parentNode.Nodes.Count; nodeIndex++)
            {
                TreeNode tempNode = parentNode.Nodes[nodeIndex];
                if (tempNode.Checked)
                    lstDocTypeInfos.Add(tempNode.Tag as TempletType);
                if (tempNode.Nodes.Count > 0)
                {
                    this.GetSelectedDocTypeList(tempNode, ref lstDocTypeInfos);
                }
            }
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int parentIndex = 0; parentIndex < this.treeView1.Nodes.Count; parentIndex++)
            {
                TreeNode parentNode = this.treeView1.Nodes[parentIndex];
                parentNode.Checked = this.chkCheckAll.Checked;
                for (int childIndex = 0; childIndex < parentNode.Nodes.Count; childIndex++)
                {
                    parentNode.Nodes[childIndex].Checked = this.chkCheckAll.Checked;
                }
            }
        }

        private void cboApplyEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string szApplyEnv = this.cboApplyEnv.Text;
            szApplyEnv = SystemData.TempletTypeApplyEnv.GetApplyEnvCode(szApplyEnv);
            this.LoadDocTypeList(szApplyEnv);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.btnOK, Cursors.WaitCursor);
            this.m_lstSelectedDocTypes = this.GetSelectedDocTypeList();
            this.DialogResult = DialogResult.OK;
            GlobalMethods.UI.SetCursor(this.btnOK, Cursors.Default);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;
            foreach (TreeNode node in e.Node.Nodes)
                node.Checked = e.Node.Checked;
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.treeView1.CheckBoxes)
                return;
            TreeNode node = this.treeView1.GetNodeAt(e.X, e.Y);
            if (node == null || !node.Bounds.Contains(e.Location))
                this.treeView1.SelectedNode = null;
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.m_bMultiSelect)
                return;
            TreeNode node = this.treeView1.GetNodeAt(e.X, e.Y);
            if (node == null)
                return;
            GlobalMethods.UI.SetCursor(this.btnOK, Cursors.WaitCursor);
            this.m_lstSelectedDocTypes = this.GetSelectedDocTypeList();
            if (this.m_lstSelectedDocTypes != null && this.m_lstSelectedDocTypes.Count > 0)
                this.DialogResult = DialogResult.OK;
            GlobalMethods.UI.SetCursor(this.btnOK, Cursors.Default);
        }
    }
}