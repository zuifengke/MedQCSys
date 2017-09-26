// ***********************************************************
// 护理病历配置管理系统,表单树形列表窗口.
// Author : YangMingkun, Date : 2012-6-7
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Controls;
using Heren.Common.Controls.VirtualTreeView;
using EMRDBLib;
using EMRDBLib.DbAccess;
namespace Designers.Templet
{
    internal partial class TempletTreeForm : DockContentBase
    {
        public TempletTreeForm(DesignForm mainForm)
            : base(mainForm)
        {
            this.HideOnClose = true;
            this.ShowHint = DockState.DockRight;
            this.DockAreas = DockAreas.DockLeft | DockAreas.DockRight
                | DockAreas.DockTop | DockAreas.DockBottom;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            this.Icon = Properties.Resources.FormsIcon;

            string[] szApplyEnvs = SystemData.TempletTypeApplyEnv.GetApplyEnvNames();
            this.toolcboApplyEnv.Items.AddRange(szApplyEnvs);
            this.toolcboApplyEnv.SelectedIndex = 0;
            this.toolcboApplyEnv.SelectedIndexChanged +=
                new EventHandler(this.toolcboApplyEnv_SelectedIndexChanged);
        }

        public override void OnRefreshView()
        {
            this.treeView1.Nodes.Clear();
            this.Update();

            string szApplyEnv = this.toolcboApplyEnv.Text;
            szApplyEnv = SystemData.TempletTypeApplyEnv.GetApplyEnvCode(szApplyEnv);
            List<TempletType> lstDocTypeInfos = null;
            short shRet = TempletTypeAccess.Instance.GetTempletTypes(szApplyEnv, ref lstDocTypeInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.ShowError("模板列表下载失败!");
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
                    if (nodeTable.ContainsKey(docTypeInfo.ParentID))
                    {
                        TreeNode parentNode = nodeTable[docTypeInfo.ParentID];
                        if (parentNode != null)
                            nodes = parentNode.Nodes;
                    }
                    if (nodes == null)
                        nodes = this.treeView1.Nodes;
                    nodes.Add(pair.Value);
                }
            }
            this.treeView1.ExpandAll();
            if (this.treeView1.Nodes.Count > 0) this.treeView1.Nodes[0].EnsureVisible();
        }

        /// <summary>
        /// 返回当前选中的模板节点对应的文档类型信息
        /// </summary>
        /// <param name="bIsDir">是否是目录</param>
        /// <returns>DocTypeInfo</returns>
        private TempletType MakeDocTypeInfo(bool bIsDir)
        {
            TempletType docTypeInfo = new TempletType();
            docTypeInfo.DocTypeID = docTypeInfo.MakeDocTypeID();
            docTypeInfo.IsValid = true;
            docTypeInfo.IsFolder = bIsDir;
            docTypeInfo.ParentID = string.Empty;
            docTypeInfo.DocTypeName = bIsDir ? "新建目录" : "未命名模板";
            docTypeInfo.ModifyTime = SysTimeHelper.Instance.Now;
            docTypeInfo.DocTypeNo = this.treeView1.Nodes.Count;

            string szApplyEnv = this.toolcboApplyEnv.Text;
            szApplyEnv = SystemData.TempletTypeApplyEnv.GetApplyEnvCode(szApplyEnv);
            docTypeInfo.ApplyEnv = szApplyEnv;

            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return docTypeInfo;

            TempletType selectedDocType = selectedNode.Tag as TempletType;
            if (selectedDocType == null)
                return docTypeInfo;

            if (selectedDocType.IsFolder)
            {
                docTypeInfo.ParentID = selectedDocType.DocTypeID;
                docTypeInfo.DocTypeNo = selectedNode.Nodes.Count;
            }
            else
            {
                docTypeInfo.ParentID = selectedDocType.ParentID;
                if (selectedNode.Parent != null)
                    docTypeInfo.DocTypeNo = selectedNode.Parent.Nodes.Count;
            }
            return docTypeInfo;
        }

        /// <summary>
        /// 创建一个新的目录或者类型节点
        /// </summary>
        /// <param name="bIsDir">是否是目录</param>
        /// <param name="docTypeInfo">病历类型信息</param>
        /// <returns>节点</returns>
        private TreeNode CreateNewNode(bool bIsDir, TempletType docTypeInfo)
        {
            TreeNode node = new TreeNode();
            node.Tag = docTypeInfo;
            if (docTypeInfo == null)
                node.Text = bIsDir ? "新建目录" : "未命名模板";
            else
                node.Text = docTypeInfo.DocTypeName;
            node.ImageIndex = bIsDir ? 0 : 2;
            node.SelectedImageIndex = node.ImageIndex;

            if (!docTypeInfo.IsValid || !docTypeInfo.IsVisible)
                node.ForeColor = Color.Silver;

            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                this.treeView1.Nodes.Add(node);
                return node;
            }

            DocTypeInfo selectedDocType = selectedNode.Tag as DocTypeInfo;
            if (selectedDocType == null)
            {
                this.treeView1.Nodes.Add(node);
                return node;
            }

            TreeNode parentNode = selectedNode;
            if (!selectedDocType.IsFolder)
                parentNode = selectedNode.Parent;
            if (parentNode != null)
            {
                parentNode.Nodes.Add(node);
                parentNode.Expand();
            }
            else
            {
                this.treeView1.Nodes.Add(node);
            }

            if (node.TreeView != null)
            {
                this.treeView1.SelectedNode = node;
                node.BeginEdit();
                return node;
            }
            return null;
        }

        /// <summary>
        /// 在当前树节点位置处创建目录节点
        /// </summary>
        /// <returns>bool</returns>
        private bool CreateFolder()
        {
            TempletInfoForm templetInfoForm = new TempletInfoForm();
            templetInfoForm.IsNew = true;
            templetInfoForm.IsFolder = true;
            templetInfoForm.DocTypeInfo = this.MakeDocTypeInfo(true);
            if (templetInfoForm.ShowDialog() != DialogResult.OK)
                return false;

            TempletType docTypeInfo = templetInfoForm.DocTypeInfo;
            if (docTypeInfo == null)
                return false;
            short shRet = TempletTypeAccess.Instance.Insert(docTypeInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("目录创建失败,无法更新到数据库!");
                return false;
            }
            return this.CreateNewNode(true, docTypeInfo) != null;
        }

        /// <summary>
        /// 在当前树节点位置处创建模板节点
        /// </summary>
        /// <returns>bool</returns>
        private bool CreateDocType()
        {
            TempletInfoForm templetInfoForm = new TempletInfoForm();
            templetInfoForm.IsNew = true;
            templetInfoForm.IsFolder = false;
            templetInfoForm.DocTypeInfo = this.MakeDocTypeInfo(false);
            if (templetInfoForm.ShowDialog() != DialogResult.OK)
                return false;

            TempletType docTypeInfo = templetInfoForm.DocTypeInfo;
            if (docTypeInfo == null)
                return false;
            short shRet = TempletTypeAccess.Instance.Insert(docTypeInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("模板创建失败,无法更新到数据库!");
                return false;
            }
            this.CreateNewNode(false, docTypeInfo);
            TempletHandler.Instance.OpenTemplet(docTypeInfo);
            return true;
        }

        /// <summary>
        /// 显示选中的模板的信息,并接受修改
        /// </summary>
        private void ShowTempletInfoEditForm()
        {
            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return;
            TempletType docTypeInfo = selectedNode.Tag as TempletType;
            if (docTypeInfo == null)
                return;
            string szDocTypeID = docTypeInfo.DocTypeID;

            TempletInfoForm templetInfoForm = new TempletInfoForm();
            templetInfoForm.IsNew = false;
            templetInfoForm.IsFolder = docTypeInfo.IsFolder;
            templetInfoForm.DocTypeInfo = docTypeInfo.Clone() as TempletType;
            DialogResult result = templetInfoForm.ShowDialog();
            if (result != DialogResult.OK)
                return;

            docTypeInfo = templetInfoForm.DocTypeInfo;
            if (docTypeInfo == null)
                return;
            short shRet = TempletTypeAccess.Instance.Update(docTypeInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("模板创建失败,无法更新到数据库!");
                return;
            }
            selectedNode.Tag = docTypeInfo;
            selectedNode.Text = docTypeInfo.DocTypeName;
            if (!docTypeInfo.IsValid || !docTypeInfo.IsVisible)
                selectedNode.ForeColor = Color.Silver;
            else
                selectedNode.ForeColor = Color.Black;
        }

        /// <summary>
        /// 修改指定的节点显示文本
        /// </summary>
        /// <param name="node">节点对象</param>
        /// <param name="szNewText">修改文本</param>
        /// <returns>bool</returns>
        private bool ModifyNodeText(TreeNode node, string szNewText)
        {
            if (node == null || GlobalMethods.Misc.IsEmptyString(szNewText))
                return false;
            TempletType docTypeInfo = node.Tag as TempletType;
            if (docTypeInfo == null || docTypeInfo.DocTypeName == szNewText)
                return false;

            string szDocTypeID = docTypeInfo.DocTypeID;
            string szOldDocTypeName = docTypeInfo.DocTypeName;
            docTypeInfo.DocTypeName = szNewText;

            short shRet = TempletTypeAccess.Instance.Update(docTypeInfo);
            if (shRet == SystemData.ReturnValue.OK)
            {
                node.Text = szNewText;
                return true;
            }
            docTypeInfo.DocTypeName = szOldDocTypeName;
            MessageBoxEx.Show(string.Format("“{0}”重命名失败!", docTypeInfo.DocTypeName));
            return false;
        }

        /// <summary>
        /// 获取指定节点下所有子节点的文档类型ID列表
        /// </summary>
        /// <param name="parentNode">模板父节点</param>
        /// <param name="lstDocTypeID">文档类型ID列表</param>
        private void GetDocTypeList(TreeNode parentNode, ref List<string> lstDocTypeID)
        {
            if (lstDocTypeID == null)
                lstDocTypeID = new List<string>();
            if (parentNode == null)
                return;

            TempletType docTypeInfo = parentNode.Tag as TempletType;
            if (docTypeInfo == null)
                return;
            lstDocTypeID.Add(docTypeInfo.DocTypeID);
            for (int index = 0; index < parentNode.Nodes.Count; index++)
                this.GetDocTypeList(parentNode.Nodes[index], ref lstDocTypeID);
        }

        /// <summary>
        /// 删除指定TreeNode节点
        /// </summary>
        /// <param name="deletedNode">节点对象</param>
        private void DeleteNode(TreeNode deletedNode)
        {
            if (deletedNode == null || deletedNode.Tag == null)
                return;

            List<string> lstDocTypeID = null;
            this.GetDocTypeList(deletedNode, ref lstDocTypeID);
            if (lstDocTypeID == null || lstDocTypeID.Count <= 0)
                return;

            string szPopupInfo = "确认彻底删除“" + deletedNode.Text + "”吗？"
                        + "\r\n警告：\r\n删除病历类型将导致基于该类型书写的病历无法再编辑。"
                        + "\r\n如果系统已经上线,我们建议您不要彻底删除而将其设置为不可见。";
            DialogResult result = MessageBoxEx.ShowConfirm(szPopupInfo);
            if (result != DialogResult.OK)
                return;

            short shRet = TempletTypeAccess.Instance.DeleteAll(lstDocTypeID);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show(string.Format("删除“{0}”失败!", deletedNode.Text));
                return;
            }
            deletedNode.Remove();
        }

        /// <summary>
        /// 在同一个父节点内,向上或者向下移动指定的节点
        /// </summary>
        /// <param name="moveNode">被移动的节点</param>
        /// <param name="bIsMoveToDown">是否是向下移动</param>
        private void MoveNode(TreeNode moveNode, bool bIsMoveToDown)
        {
            if (moveNode == null || moveNode.Index < 0 || moveNode.Tag == null)
                return;

            TempletType docTypeInfo = moveNode.Tag as TempletType;
            if (docTypeInfo == null)
                return;

            TreeNodeCollection nodes = null;
            if (moveNode.Parent != null)
                nodes = moveNode.Parent.Nodes;
            else
                nodes = this.treeView1.Nodes;

            if (bIsMoveToDown && moveNode.Index >= nodes.Count - 1)
                return;
            if (!bIsMoveToDown && moveNode.Index <= 0)
                return;

            bool bIsExpanded = moveNode.IsExpanded;
            bool bIsSelected = moveNode.IsSelected;

            int index = 0;
            if (bIsMoveToDown)
                index = moveNode.Index + 2;
            else
                index = moveNode.Index - 1;
            TreeNode targetNode = moveNode.Clone() as TreeNode;
            nodes.Insert(index, targetNode);
            nodes.Remove(moveNode);

            if (bIsExpanded)
                targetNode.ExpandAll();
            if (bIsSelected)
                this.treeView1.SelectedNode = targetNode;

            //更新相关兄弟节点的顺序值
            for (int childIndex = 0; childIndex < nodes.Count; childIndex++)
            {
                TreeNode childNode = nodes[childIndex];
                if (childNode == null)
                    continue;
                docTypeInfo = childNode.Tag as TempletType;
                if (docTypeInfo == null)
                    continue;
                int nOldValue = docTypeInfo.DocTypeNo;
                docTypeInfo.DocTypeNo = childIndex;
                short shRet = TempletTypeAccess.Instance.Update(docTypeInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    //失败后还原被更新的对象属性
                    docTypeInfo.DocTypeNo = nOldValue;
                    MessageBoxEx.Show(string.Format("无法移动“{0}”!", docTypeInfo.DocTypeName));
                    return;
                }
            }
        }

        /// <summary>
        /// 在整棵TreeView树内,移动指定的节点到目标节点之前
        /// </summary>
        /// <param name="moveNode">被移动的节点</param>
        /// <param name="targetNode">目标节点</param>
        private void DragNode(TreeNode moveNode, TreeNode targetNode)
        {
            if (moveNode == null || moveNode.Index < 0 || moveNode.Tag == null)
                return;

            TempletType moveDocTypeInfo = moveNode.Tag as TempletType;
            if (moveDocTypeInfo == null)
                return;

            TempletType targetDocTypeInfo = null;
            if (targetNode != null)
                targetDocTypeInfo = targetNode.Tag as TempletType;

            //把父节点拖放到其下子节点,则取消
            TreeNode parentNode = targetNode;
            while (parentNode != null)
            {
                if (parentNode == moveNode)
                    return;
                parentNode = parentNode.Parent;
            }
            if (targetNode == moveNode.Parent)
                return;

            //寻找父目录节点以及目标位置
            string szParentID = string.Empty;
            int nTargetIndex = this.treeView1.Nodes.Count;
            if (targetDocTypeInfo != null)
            {
                nTargetIndex = targetNode.Index;
                if (!targetDocTypeInfo.IsFolder)
                {
                    targetNode = targetNode.Parent;
                    szParentID = targetDocTypeInfo.ParentID;
                }
                else
                {
                    nTargetIndex = targetNode.Nodes.Count;
                    szParentID = targetDocTypeInfo.DocTypeID;
                }
            }

            TreeNodeCollection nodes = null;
            if (targetNode != null)
                nodes = targetNode.Nodes;
            else
                nodes = this.treeView1.Nodes;

            //开始移动节点
            bool bIsExpanded = moveNode.IsExpanded;
            bool bIsSelected = moveNode.IsSelected;
            TreeNode newNode = (TreeNode)moveNode.Clone();
            nodes.Insert(nTargetIndex, newNode);
            moveNode.Remove();
            if (bIsExpanded)
                newNode.ExpandAll();
            if (bIsSelected)
                this.treeView1.SelectedNode = newNode;

            //更新相关兄弟节点的顺序值
            for (int childIndex = 0; childIndex < nodes.Count; childIndex++)
            {
                TreeNode childNode = nodes[childIndex];
                if (childNode == null)
                    continue;
                TempletType docTypeInfo = childNode.Tag as TempletType;
                if (docTypeInfo == null)
                    continue;
                string szOldParentID = docTypeInfo.ParentID;
                int nDocTypeOldNo = docTypeInfo.DocTypeNo;

                docTypeInfo.DocTypeNo = childIndex;
                docTypeInfo.ParentID = szParentID;
                short shRet = TempletTypeAccess.Instance.Update(docTypeInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    //失败后还原被更新的对象属性
                    docTypeInfo.DocTypeNo = nDocTypeOldNo;
                    docTypeInfo.ParentID = szOldParentID;
                    MessageBoxEx.Show(string.Format("“{0}”移动失败!", docTypeInfo.DocTypeName));
                    return;
                }
            }
        }

        /// <summary>
        /// 将指定的文本数据写入result.txt中,同时使用记事本打开
        /// </summary>
        /// <param name="szTextData">文本数据</param>
        private void ShowTextData(string szTextData)
        {
            string szResultFile = string.Format("{0}\\result.txt", Application.StartupPath);
            GlobalMethods.IO.WriteFileText(szResultFile, szTextData);
            try
            {
                System.Diagnostics.Process.Start(szResultFile);
            }
            catch { MessageBoxEx.Show("无法显示模板导出结果信息!"); }
        }

        /// <summary>
        /// 将服务器上的模板导出到本地目录
        /// </summary>
        public void ExportTemplet()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "请选择模板导出目录：";
            folderDialog.ShowNewFolderButton = true;
            if (folderDialog.ShowDialog() != DialogResult.OK)
                return;
            string szDirPath = folderDialog.SelectedPath;

            TempletSelectForm frmTempletSelect = new TempletSelectForm();
            frmTempletSelect.MultiSelect = true;
            frmTempletSelect.Description = "请选择需要导出的病历类型模板：";

            string szApplyEnv = this.toolcboApplyEnv.Text;
            szApplyEnv = SystemData.TempletTypeApplyEnv.GetApplyEnvCode(szApplyEnv);
            frmTempletSelect.ApplyEnv = szApplyEnv;

            if (frmTempletSelect.ShowDialog() != DialogResult.OK)
                return;
            List<TempletType> lstDocTypeInfos = frmTempletSelect.SelectedDocTypes;
            if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
                return;

            WorkProcess.Instance.Initialize(this.MainForm, lstDocTypeInfos.Count, "正在导出系统模板...");

            StringBuilder sbExecuteResult = new StringBuilder();
            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index <= lstDocTypeInfos.Count - 1; index++)
            {
                WorkProcess.Instance.Show(null, index + 1);
                if (WorkProcess.Instance.Canceled)
                    break;

                TempletType docTypeInfo = lstDocTypeInfos[index];
                if (docTypeInfo == null || docTypeInfo.IsFolder)
                    continue;

                //从服务器上下载模板
                byte[] byteTempletData = null;
                shRet =TempletTypeAccess.Instance.GetTempletData(docTypeInfo.DocTypeID, ref byteTempletData);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    sbExecuteResult.AppendLine("----导出失败! DocTypeName=" + docTypeInfo.DocTypeName);
                    continue;
                }

                //将模板写入本地文件
                string szTempletFile = string.Format("{0}\\{1}.hndt", szDirPath, docTypeInfo.DocTypeName);
                if (!GlobalMethods.IO.WriteFileBytes(szTempletFile, byteTempletData))
                {
                    sbExecuteResult.AppendLine("----导出失败! DocTypeName=" + docTypeInfo.DocTypeName);
                    continue;
                }
                sbExecuteResult.AppendLine("导出成功! DocTypeName=" + docTypeInfo.DocTypeName);
            }
            WorkProcess.Instance.Close();
            this.ShowTextData(sbExecuteResult.ToString());
        }

        /// <summary>
        /// 将本地目录下的模板提交到服务器
        /// </summary>
        public void ImportTemplet()
        {
            TempletSelectForm frmTempletSelect = new TempletSelectForm();
            frmTempletSelect.MultiSelect = true;
            frmTempletSelect.Description = "请选择需要导入的病历类型模板：";

            string szApplyEnv = this.toolcboApplyEnv.Text;
            szApplyEnv = SystemData.TempletTypeApplyEnv.GetApplyEnvCode(szApplyEnv);
            frmTempletSelect.ApplyEnv = szApplyEnv;

            if (frmTempletSelect.ShowDialog() != DialogResult.OK)
                return;
            List<TempletType> lstDocTypeInfos = frmTempletSelect.SelectedDocTypes;
            if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
                return;

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "请选择模板在本地的存放目录：";
            folderDialog.ShowNewFolderButton = false;
            if (folderDialog.ShowDialog() != DialogResult.OK)
                return;
            string szDirPath = folderDialog.SelectedPath;

            WorkProcess.Instance.Initialize(this.MainForm, lstDocTypeInfos.Count, "正在导入系统模板...");

            StringBuilder sbExecuteResult = new StringBuilder();
            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index <= lstDocTypeInfos.Count - 1; index++)
            {
                WorkProcess.Instance.Show(null, index + 1);
                if (WorkProcess.Instance.Canceled)
                    break;

                TempletType docTypeInfo = lstDocTypeInfos[index];
                if (docTypeInfo == null || docTypeInfo.IsFolder)
                    continue;

                //读取本地模板文件
                byte[] byteTempletData = null;
                string szTempletFile = string.Format("{0}\\{1}.hndt", szDirPath, docTypeInfo.DocTypeName);
                if (!GlobalMethods.IO.GetFileBytes(szTempletFile, ref byteTempletData))
                {
                    sbExecuteResult.AppendLine("----导入失败! DocTypeName=" + docTypeInfo.DocTypeName);
                    continue;
                }

                //保存模板到服务器
                shRet =TempletTypeAccess.Instance.SaveTempletDataToDB(docTypeInfo.DocTypeID, byteTempletData);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    sbExecuteResult.AppendLine("----导入失败! DocTypeName=" + docTypeInfo.DocTypeName);
                    continue;
                }
                sbExecuteResult.AppendLine("导入成功! DocTypeName=" + docTypeInfo.DocTypeName);
            }
            WorkProcess.Instance.Close();
            this.ShowTextData(sbExecuteResult.ToString());
        }

        private void toolbtnOpen_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            TempletHandler.Instance.OpenTemplet();
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void toolbtnImport_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            this.ImportTemplet();
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void toolbtnExport_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            this.ExportTemplet();
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void mnuNewFolder_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            this.CreateFolder();
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void mnuNewTemplet_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            this.CreateDocType();
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void mnuTempletProperty_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            this.ShowTempletInfoEditForm();
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            this.DeleteNode(this.treeView1.SelectedNode);
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void toolcboApplyEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnRefreshView();
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = e.Node.ImageIndex;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = e.Node.ImageIndex;
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node == null || GlobalMethods.Misc.IsEmptyString(e.Label))
            {
                e.CancelEdit = true;
                return;
            }
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            e.CancelEdit = !this.ModifyNodeText(e.Node, e.Label.Trim());
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode node = e.Item as TreeNode;
            if (node == null)
                return;
            this.treeView1.SelectedNode = node;
            if (e.Button == MouseButtons.Left)
            {
                this.treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.None;
            else
                e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point ptMousePos = new Point(e.X, e.Y);
            ptMousePos = this.treeView1.PointToClient(ptMousePos);
            TreeNode node = this.treeView1.GetNodeAt(ptMousePos);
            if (node == null)
                return;

            int nHeight = this.treeView1.Height;
            int nItemHeight = this.treeView1.ItemHeight;
            if (ptMousePos.Y < nItemHeight && node.PrevVisibleNode != null)
                node.PrevVisibleNode.EnsureVisible();
            else if (ptMousePos.Y > nHeight - nItemHeight && node.NextVisibleNode != null)
                node.NextVisibleNode.EnsureVisible();
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode moveNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (moveNode == null)
                return;

            Point ptMousePos = new Point(e.X, e.Y);
            ptMousePos = this.treeView1.PointToClient(ptMousePos);
            TreeNode targetNode = this.treeView1.GetNodeAt(ptMousePos);

            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            this.DragNode(moveNode, targetNode);
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            TempletType docTypeInfo = e.Node.Tag as TempletType;
            if (docTypeInfo != null && !docTypeInfo.IsFolder)
                TempletHandler.Instance.OpenTemplet(e.Node.Tag as TempletType);
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }
    }
}
