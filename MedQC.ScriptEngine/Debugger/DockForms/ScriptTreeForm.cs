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
using Heren.MedQC.ScriptEngine.Debugger;

namespace Heren.MedQC.ScriptEngine.DockForms
{
    internal partial class ScriptTreeForm : DockContentBase
    {
        public ScriptTreeForm(DebuggerForm mainForm)
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
        }

        public override void OnRefreshView()
        {
            this.treeView1.Nodes.Clear();
            this.Update();
            List<ScriptConfig> lstDocTypeInfos = null;
            short shRet = ScriptConfigAccess.Instance.GetScriptConfigs(ref lstDocTypeInfos);
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
            foreach (ScriptConfig docTypeInfo in lstDocTypeInfos)
            {
                TreeNode docTypeNode = new TreeNode();
                docTypeNode.Tag = docTypeInfo;
                docTypeNode.Text = docTypeInfo.SCRIPT_NAME;

                if (docTypeInfo.IS_FOLDER == 0)
                    docTypeNode.ImageIndex = 2;
                else
                    docTypeNode.ImageIndex = 0;
                docTypeNode.SelectedImageIndex = docTypeNode.ImageIndex;

                if (!nodeTable.ContainsKey(docTypeInfo.SCRIPT_ID))
                    nodeTable.Add(docTypeInfo.SCRIPT_ID, docTypeNode);
            }

            //将节点连接起来,添加到树中
            foreach (KeyValuePair<string, TreeNode> pair in nodeTable)
            {
                if (string.IsNullOrEmpty(pair.Key) || pair.Value == null)
                    continue;

                ScriptConfig docTypeInfo = pair.Value.Tag as ScriptConfig;
                if (docTypeInfo == null)
                    continue;

                if (string.IsNullOrEmpty(docTypeInfo.PARENT_ID))
                {
                    this.treeView1.Nodes.Add(pair.Value);
                }
                else
                {
                    TreeNodeCollection nodes = null;
                    if (nodeTable.ContainsKey(docTypeInfo.PARENT_ID))
                    {
                        TreeNode parentNode = nodeTable[docTypeInfo.PARENT_ID];
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
        private ScriptConfig MakeDocTypeInfo(bool bIsDir)
        {
            ScriptConfig docTypeInfo = new ScriptConfig();
            docTypeInfo.SCRIPT_ID = docTypeInfo.MakeScriptID();
            docTypeInfo.IS_FOLDER = bIsDir ? 1 : 0;
            docTypeInfo.PARENT_ID = string.Empty;
            docTypeInfo.SCRIPT_NAME = bIsDir ? "新建目录" : "未命名模板";
            docTypeInfo.MODIFY_TIME = SysTimeHelper.Instance.Now;
            docTypeInfo.SCRIPT_NO = this.treeView1.Nodes.Count;

            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return docTypeInfo;

            ScriptConfig selectedDocType = selectedNode.Tag as ScriptConfig;
            if (selectedDocType == null)
                return docTypeInfo;

            if (selectedDocType.IS_FOLDER == 1)
            {
                docTypeInfo.PARENT_ID = selectedDocType.SCRIPT_ID;
                docTypeInfo.SCRIPT_NO = selectedNode.Nodes.Count;
            }
            else
            {
                docTypeInfo.PARENT_ID = selectedDocType.PARENT_ID;
                if (selectedNode.Parent != null)
                    docTypeInfo.SCRIPT_NO = selectedNode.Parent.Nodes.Count;
            }
            return docTypeInfo;
        }

        /// <summary>
        /// 返回当前选中的模板节点对应的文档类型信息
        /// </summary>
        /// <param name="bIsDir">是否是目录</param>
        /// <returns>DocTypeInfo</returns>
        private ScriptConfig MakeScriptConfig(bool bIsDir)
        {
            ScriptConfig scriptConfig = new ScriptConfig();
            scriptConfig.SCRIPT_ID = scriptConfig.MakeScriptID();
            scriptConfig.CREATE_TIME = SysTimeHelper.Instance.Now;
            if (SystemParam.Instance.UserInfo == null)
            {
                scriptConfig.CREATOR_ID = "administrator";
                scriptConfig.CREATOR_NAME = "管理员";
            }
            else
            {
                scriptConfig.CREATOR_ID = SystemParam.Instance.UserInfo.USER_ID;
                scriptConfig.CREATOR_NAME = SystemParam.Instance.UserInfo.USER_NAME;
            }
            scriptConfig.IS_FOLDER = bIsDir ? 1 : 0;
            scriptConfig.PARENT_ID = string.Empty;
            scriptConfig.SCRIPT_NAME = bIsDir ? "新建目录" : "未命名模板";

            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return scriptConfig;

            ScriptConfig selectedDocType = selectedNode.Tag as ScriptConfig;
            if (selectedDocType == null)
                return scriptConfig;

            if (selectedDocType.IS_FOLDER == 1)
            {
                scriptConfig.PARENT_ID = selectedDocType.SCRIPT_ID;
            }
            else
            {
                scriptConfig.PARENT_ID = selectedDocType.PARENT_ID;

            }
            return scriptConfig;
        }
        /// <summary>
        /// 创建一个新的目录或者类型节点
        /// </summary>
        /// <param name="bIsDir">是否是目录</param>
        /// <param name="docTypeInfo">病历类型信息</param>
        /// <returns>节点</returns>
        private TreeNode CreateNewNode(bool bIsDir, ScriptConfig docTypeInfo)
        {
            TreeNode node = new TreeNode();
            node.Tag = docTypeInfo;
            if (docTypeInfo == null)
                node.Text = bIsDir ? "新建目录" : "未命名模板";
            else
                node.Text = docTypeInfo.SCRIPT_NAME;
            node.ImageIndex = bIsDir ? 0 : 2;
            node.SelectedImageIndex = node.ImageIndex;

            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                this.treeView1.Nodes.Add(node);
                return node;
            }

            ScriptConfig selectedDocType = selectedNode.Tag as ScriptConfig;
            if (selectedDocType == null)
            {
                this.treeView1.Nodes.Add(node);
                return node;
            }

            TreeNode parentNode = selectedNode;
            if (selectedDocType.IS_FOLDER==0)
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
            ScriptInfoForm templetInfoForm = new ScriptInfoForm();
            templetInfoForm.IsNew = true;
            templetInfoForm.IsFolder = true;
            templetInfoForm.DocTypeInfo = this.MakeScriptConfig(true);
            if (templetInfoForm.ShowDialog() != DialogResult.OK)
                return false;

            ScriptConfig docTypeInfo = templetInfoForm.DocTypeInfo;
            if (docTypeInfo == null)
                return false;
            short shRet = ScriptConfigAccess.Instance.Insert(docTypeInfo);
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
            ScriptInfoForm templetInfoForm = new ScriptInfoForm();
            templetInfoForm.IsNew = true;
            templetInfoForm.IsFolder = false;
            templetInfoForm.DocTypeInfo = this.MakeDocTypeInfo(false);
            if (templetInfoForm.ShowDialog() != DialogResult.OK)
                return false;

            ScriptConfig docTypeInfo = templetInfoForm.DocTypeInfo;
            if (docTypeInfo == null)
                return false;
            short shRet = ScriptConfigAccess.Instance.Insert(docTypeInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("模板创建失败,无法更新到数据库!");
                return false;
            }
            this.CreateNewNode(false, docTypeInfo);
            ScriptHandler.Instance.OpenScriptConfig(docTypeInfo);
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
            ScriptConfig docTypeInfo = selectedNode.Tag as ScriptConfig;
            if (docTypeInfo == null)
                return;
            string szDocTypeID = docTypeInfo.SCRIPT_ID;

            ScriptInfoForm templetInfoForm = new ScriptInfoForm();
            templetInfoForm.IsNew = false;
            templetInfoForm.IsFolder = docTypeInfo.IS_FOLDER == 1;
            templetInfoForm.DocTypeInfo = docTypeInfo.Clone() as ScriptConfig;
            DialogResult result = templetInfoForm.ShowDialog();
            if (result != DialogResult.OK)
                return;

            docTypeInfo = templetInfoForm.DocTypeInfo;
            if (docTypeInfo == null)
                return;
            short shRet = ScriptConfigAccess.Instance.Update(docTypeInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("模板创建失败,无法更新到数据库!");
                return;
            }
            selectedNode.Tag = docTypeInfo;
            selectedNode.Text = docTypeInfo.SCRIPT_NAME;
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
            ScriptConfig docTypeInfo = node.Tag as ScriptConfig;
            if (docTypeInfo == null || docTypeInfo.SCRIPT_NAME == szNewText)
                return false;

            string szDocTypeID = docTypeInfo.SCRIPT_ID;
            string szOldDocTypeName = docTypeInfo.SCRIPT_NAME;
            docTypeInfo.SCRIPT_NAME = szNewText;

            short shRet = ScriptConfigAccess.Instance.Update(docTypeInfo);
            if (shRet == SystemData.ReturnValue.OK)
            {
                node.Text = szNewText;
                return true;
            }
            docTypeInfo.SCRIPT_NAME = szOldDocTypeName;
            MessageBoxEx.Show(string.Format("“{0}”重命名失败!", docTypeInfo.SCRIPT_NAME));
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

            ScriptConfig docTypeInfo = parentNode.Tag as ScriptConfig;
            if (docTypeInfo == null)
                return;
            lstDocTypeID.Add(docTypeInfo.SCRIPT_ID);
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

            short shRet = ScriptConfigAccess.Instance.DeleteAll(lstDocTypeID);
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

            ScriptConfig docTypeInfo = moveNode.Tag as ScriptConfig;
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
                docTypeInfo = childNode.Tag as ScriptConfig;
                if (docTypeInfo == null)
                    continue;
                int nOldValue = docTypeInfo.SCRIPT_NO;
                docTypeInfo.SCRIPT_NO = childIndex;
                short shRet = ScriptConfigAccess.Instance.Update(docTypeInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    //失败后还原被更新的对象属性
                    docTypeInfo.SCRIPT_NO = nOldValue;
                    MessageBoxEx.Show(string.Format("无法移动“{0}”!", docTypeInfo.SCRIPT_NAME));
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

            ScriptConfig moveDocTypeInfo = moveNode.Tag as ScriptConfig;
            if (moveDocTypeInfo == null)
                return;

            ScriptConfig targetDocTypeInfo = null;
            if (targetNode != null)
                targetDocTypeInfo = targetNode.Tag as ScriptConfig;

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
            string szPARENT_ID = string.Empty;
            int nTargetIndex = this.treeView1.Nodes.Count;
            if (targetDocTypeInfo != null)
            {
                nTargetIndex = targetNode.Index;
                if (targetDocTypeInfo.IS_FOLDER == 0)
                {
                    targetNode = targetNode.Parent;
                    szPARENT_ID = targetDocTypeInfo.PARENT_ID;
                }
                else
                {
                    nTargetIndex = targetNode.Nodes.Count;
                    szPARENT_ID = targetDocTypeInfo.SCRIPT_ID;
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
                ScriptConfig docTypeInfo = childNode.Tag as ScriptConfig;
                if (docTypeInfo == null)
                    continue;
                string szOldPARENT_ID = docTypeInfo.PARENT_ID;
                int nDocTypeOldNo = docTypeInfo.SCRIPT_NO;

                docTypeInfo.SCRIPT_NO = childIndex;
                docTypeInfo.PARENT_ID = szPARENT_ID;
                short shRet = ScriptConfigAccess.Instance.Update(docTypeInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    //失败后还原被更新的对象属性
                    docTypeInfo.SCRIPT_NO = nDocTypeOldNo;
                    docTypeInfo.PARENT_ID = szOldPARENT_ID;
                    MessageBoxEx.Show(string.Format("“{0}”移动失败!", docTypeInfo.SCRIPT_NAME));
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

            ScriptSelectForm frmTempletSelect = new ScriptSelectForm();
            frmTempletSelect.MultiSelect = true;
            frmTempletSelect.Description = "请选择需要导出的病历类型模板：";

            if (frmTempletSelect.ShowDialog() != DialogResult.OK)
                return;
            List<ScriptConfig> lstDocTypeInfos = frmTempletSelect.SelectedScriptConfigs;
            if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
                return;

            WorkProcess.Instance.Initialize(this.DebuggerForm, lstDocTypeInfos.Count, "正在导出系统模板...");

            StringBuilder sbExecuteResult = new StringBuilder();
            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index <= lstDocTypeInfos.Count - 1; index++)
            {
                WorkProcess.Instance.Show(null, index + 1);
                if (WorkProcess.Instance.Canceled)
                    break;

                ScriptConfig docTypeInfo = lstDocTypeInfos[index];
                if (docTypeInfo == null || docTypeInfo.IS_FOLDER == 1)
                    continue;

                //从服务器上下载模板
                string byteTempletData = null;
                shRet = ScriptConfigAccess.Instance.GetScriptSource(docTypeInfo.SCRIPT_ID, ref byteTempletData);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    sbExecuteResult.AppendLine("----导出失败! DocTypeName=" + docTypeInfo.SCRIPT_NAME);
                    continue;
                }

                //将模板写入本地文件
                string szTempletFile = string.Format("{0}\\{1}.vbs", szDirPath, docTypeInfo.SCRIPT_NAME);
                if (!GlobalMethods.IO.WriteFileText(szTempletFile, byteTempletData))
                {
                    sbExecuteResult.AppendLine("----导出失败! DocTypeName=" + docTypeInfo.SCRIPT_NAME);
                    continue;
                }
                sbExecuteResult.AppendLine("导出成功! SCRIPT_NAME=" + docTypeInfo.SCRIPT_NAME);
            }
            WorkProcess.Instance.Close();
            this.ShowTextData(sbExecuteResult.ToString());
        }

        /// <summary>
        /// 将本地目录下的模板提交到服务器
        /// </summary>
        public void ImportTemplet()
        {
            //ScriptSelectForm frmTempletSelect = new ScriptSelectForm();
            //frmTempletSelect.MultiSelect = true;
            //frmTempletSelect.Description = "请选择需要导入的病历类型模板：";


            //if (frmTempletSelect.ShowDialog() != DialogResult.OK)
            //    return;
            //List<ScriptConfig> lstDocTypeInfos = frmTempletSelect.SelectedScriptConfigs;
            //if (lstDocTypeInfos == null || lstDocTypeInfos.Count <= 0)
            //    return;

            //FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            //folderDialog.Description = "请选择模板在本地的存放目录：";
            //folderDialog.ShowNewFolderButton = false;
            //if (folderDialog.ShowDialog() != DialogResult.OK)
            //    return;
            //string szDirPath = folderDialog.SelectedPath;

            //WorkProcess.Instance.Initialize(this.DebuggerForm, lstDocTypeInfos.Count, "正在导入系统模板...");

            //StringBuilder sbExecuteResult = new StringBuilder();
            //short shRet = SystemData.ReturnValue.OK;
            //for (int index = 0; index <= lstDocTypeInfos.Count - 1; index++)
            //{
            //    WorkProcess.Instance.Show(null, index + 1);
            //    if (WorkProcess.Instance.Canceled)
            //        break;

            //    ScriptConfig scriptConfig = lstDocTypeInfos[index];
            //    if (scriptConfig == null || scriptConfig.IS_FOLDER == 1)
            //        continue;

            //    //读取本地模板文件
            //    string byteTempletData = null;
            //    string szTempletFile = string.Format("{0}\\{1}.vbs", szDirPath, scriptConfig.SCRIPT_NAME);
            //    if (!GlobalMethods.IO.GetFileText(szTempletFile, ref byteTempletData))
            //    {
            //        sbExecuteResult.AppendLine("----导入失败! SCRIPT_NAME=" + scriptConfig.SCRIPT_NAME);
            //        continue;
            //    }

            //    //保存模板到服务器
            //    shRet = ScriptConfigAccess.Instance.SaveScriptDataToDB(scriptConfig.SCRIPT_ID, byteTempletData);
            //    if (shRet != SystemData.ReturnValue.OK)
            //    {
            //        sbExecuteResult.AppendLine("----导入失败! SCRIPT_NAME=" + scriptConfig.SCRIPT_NAME);
            //        continue;
            //    }
            //    sbExecuteResult.AppendLine("导入成功! SCRIPT_NAME=" + scriptConfig.SCRIPT_NAME);
            //}
            //WorkProcess.Instance.Close();
            //this.ShowTextData(sbExecuteResult.ToString());
        }

        private void toolbtnOpen_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            ScriptHandler.Instance.OpenTemplet();
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
        }

        private void toolbtnImport_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
            //this.ImportTemplet();
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
            try
            {
                GlobalMethods.UI.SetCursor(this.treeView1, Cursors.WaitCursor);
                ScriptConfig docTypeInfo = e.Node.Tag as ScriptConfig;
                
                if (docTypeInfo != null && docTypeInfo.IS_FOLDER == 0)
                    ScriptHandler.Instance.OpenScriptConfig(e.Node.Tag as ScriptConfig);
                GlobalMethods.UI.SetCursor(this.treeView1, Cursors.Default);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
        }
    }
}
