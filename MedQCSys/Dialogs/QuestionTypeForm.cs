// ***********************************************************
// 病案质控系统质检问题对话框.
// Creator:yehui  Date:2017-03-22
// Copyright:heren
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Heren.Common.Libraries;
using Heren.Common.Controls;

using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
using System.Linq;
namespace MedQCSys.Dialogs
{
    public partial class QuestionTypeForm : HerenForm
    {
        private string m_szQaEventType;
        /// <summary>
        /// 获取或设置质检问题问题类型
        /// </summary>
        public string QaEventType
        {
            get { return this.m_szQaEventType; }
            set { this.m_szQaEventType = value; }
        }

        private string m_szMessage;
        /// <summary>
        /// 获取或设置质检问题模板
        /// </summary>
        public string Message
        {
            get { return this.m_szMessage; }
            set { this.m_szMessage = value; }
        }

        private string m_szMessageTitle;
        /// <summary>
        /// 获取或设置质检问题标题
        /// </summary>
        public string MessageTitle
        {
            get { return this.m_szMessageTitle; }
            set { this.m_szMessageTitle = value; }
        }


        private string m_szScore;
        /// <summary>
        /// 获取或设置扣分
        /// </summary>
        public string Score
        {
            get { return this.m_szScore; }
            set { this.m_szScore = value; }
        }

        private string m_szQcMsgCode;
        /// <summary>
        /// 获取或设置质检问题模板编码
        /// </summary>
        public string QcMsgCode
        {
            get { return this.m_szQcMsgCode; }
            set { this.m_szQcMsgCode = value; }
        }

        public QuestionTypeForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            List<EMRDBLib.QaEventTypeDict> lstQCEventTypes = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQCEventTypes);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("问题分类字典下载失败!");
                return;
            }
            if (lstQCEventTypes == null || lstQCEventTypes.Count <= 0)
                return;
            for (int index = 0; index < lstQCEventTypes.Count; index++)
            {
                if (!string.IsNullOrEmpty(lstQCEventTypes[index].PARENT_CODE))
                    continue;
                EMRDBLib.QaEventTypeDict qcEventType = lstQCEventTypes[index];
                TreeNode treeNode = new TreeNode();
                treeNode.Text = qcEventType.QA_EVENT_TYPE;
                treeNode.ImageIndex = 0;
                treeNode.SelectedImageIndex = 0;
                this.treeView1.Nodes.Add(treeNode);
                this.AppendChildNode(qcEventType.QA_EVENT_TYPE, treeNode);
            }
            InitCboQcMsgDict();
        }

        private void InitCboQcMsgDict()
        {
            List<QcMsgDict> lstQcMsgDict = null;
            short shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(ref lstQcMsgDict);
            if (lstQcMsgDict == null)
                return;
            cboQcMsgDict.Items.Clear();
            foreach (var item in lstQcMsgDict)
            {
                cboQcMsgDict.Items.Add(item);
            }

        }

        /// <summary>
        /// 根据类型查找对应的质检问题模板列表
        /// <param name="szQaEventType">问题类型</param>
        /// <param name="node">当前父节点</param>
        /// </summary>
        private void AppendChildNode(string szQaEventType, TreeNode parentNode)
        {
            List<EMRDBLib.QcMsgDict> lstMessage = null;
            short shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(szQaEventType, ref lstMessage);
            if (shRet != SystemData.ReturnValue.OK || lstMessage == null)
                return;
            var reuslt = lstMessage.Select(m => m.MESSAGE_TITLE).Distinct().ToList();
            foreach (var entry in reuslt)
            {
                var lsts = lstMessage.Where(m => m.MESSAGE_TITLE == entry).ToList();
                if (entry != string.Empty)
                {
                    TreeNode level2Node = new TreeNode();
                    level2Node.Text = entry.ToString();
                    level2Node.ImageIndex = 0;
                    level2Node.SelectedImageIndex = 0;
                    parentNode.Nodes.Add(level2Node);
                    //创建有标题的节点
                    for (int index = 0; index < lsts.Count; index++)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Tag = lsts[index];
                        childNode.Text = lsts[index].MESSAGE;
                        childNode.ImageIndex = 2;
                        childNode.SelectedImageIndex = 2;
                        level2Node.Nodes.Add(childNode);
                    }
                }
                else
                {
                    for (int index = 0; index < lsts.Count; index++)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Tag = lsts[index];
                        childNode.Text = lsts[index].MESSAGE;
                        childNode.ImageIndex = 2;
                        childNode.SelectedImageIndex = 2;
                        parentNode.Nodes.Add(childNode);
                    }
                }


            }
        }

        /// <summary>
        /// 获取相同MessageTitle的质检问题反馈模板
        /// </summary>
        /// <param name="szMessageTitle"></param>
        /// <param name="lstMessage"></param>
        /// <returns></returns>
        private List<EMRDBLib.QcMsgDict> GetSameTitleTemplet(string szMessageTitle, List<EMRDBLib.QcMsgDict> lstMessage)
        {
            if (lstMessage == null || lstMessage.Count == 0)
                return null;
            List<EMRDBLib.QcMsgDict> lstSameTitleTemplet = new List<EMRDBLib.QcMsgDict>();
            for (int index = 0; index < lstMessage.Count; index++)
            {
                if (lstMessage[index].MESSAGE_TITLE.Equals(szMessageTitle))
                    lstSameTitleTemplet.Add(lstMessage[index]);
            }
            return lstSameTitleTemplet;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EMRDBLib.QcMsgDict qcMessage = null;
            if (cboQcMsgDict.SelectedItem != null && cboQcMsgDict.Text != string.Empty)
            {
                qcMessage = cboQcMsgDict.SelectedItem as QcMsgDict;
            }
            else
            {
                TreeNode selectNode = this.treeView1.SelectedNode;
                qcMessage = selectNode.Tag as EMRDBLib.QcMsgDict;
            }
            if (qcMessage == null)
            {
                MessageBoxEx.Show("选择一个问题项目!", MessageBoxIcon.Warning);
                return;
            }
            SetQcMessage(qcMessage);
            this.selectedQCMessageTemplet = qcMessage;
            this.DialogResult = DialogResult.OK;
        }

        private QcMsgDict selectedQCMessageTemplet = null;

        public QcMsgDict SelectedQCMessageTemplet
        {
            get { return selectedQCMessageTemplet; }
            set { selectedQCMessageTemplet = value; }
        }

        private void SetQcMessage(QcMsgDict qcMessage)
        {
            this.QaEventType = qcMessage.QA_EVENT_TYPE;
            this.Message = qcMessage.MESSAGE;
            this.MessageTitle = string.IsNullOrEmpty(qcMessage.MESSAGE_TITLE) ? qcMessage.QA_EVENT_TYPE : qcMessage.MESSAGE_TITLE;
            this.QcMsgCode = qcMessage.QC_MSG_CODE;
            this.Score = qcMessage.SCORE.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
                return;
            if (selectedNode.Parent == null)
                return;

            EMRDBLib.QcMsgDict qcMessage = selectedNode.Tag as EMRDBLib.QcMsgDict;
            if (qcMessage == null)
                return;

            SetQcMessage(qcMessage);
            this.selectedQCMessageTemplet = qcMessage;
            this.DialogResult = DialogResult.OK;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void cboQcMsgDict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboQcMsgDict.SelectedItem == null)
                    return;
                QcMsgDict qcMsgDict = cboQcMsgDict.SelectedItem as QcMsgDict;
                foreach (TreeNode n in this.treeView1.Nodes)
                {
                    if (Recursion(qcMsgDict, n))
                        break;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
        }
        private void ExpendNode(TreeNode node)
        {
            if (node.Parent.Text != null)
            {
                node.Parent.Expand();
                //当为项级节点时
                if (node.Parent.Level == 0)
                {
                    node.Parent.Expand();
                }
                //不是项级节点时
                else
                {
                    ExpendNode(node.Parent);
                }

            }
        }
        private bool Recursion(QcMsgDict qcMsgDict,TreeNode node)
        {
            foreach (TreeNode item in node.Nodes)
            {
                QcMsgDict nodeQcMsgDict = item.Tag as QcMsgDict;
                if (nodeQcMsgDict != null)
                {
                    if (nodeQcMsgDict.QC_MSG_CODE == qcMsgDict.QC_MSG_CODE)
                    {
                        ExpendNode(item);
                        item.BackColor = Color.LightGray;
                        
                        return true;
                    }
                    else
                    {
                        item.Collapse();
                        item.BackColor = Color.White;
                    }
                }
                if (Recursion(qcMsgDict, item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}