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

namespace MedQCSys.Dialogs
{
    public partial class QuestionTypeForm : HerenForm
    {
        private string m_szQuestionType;
        /// <summary>
        /// 获取或设置质检问题问题类型
        /// </summary>
        public string QuestionType
        {
            get { return this.m_szQuestionType; }
            set { this.m_szQuestionType = value; }
        }

        private string m_szMessageTemplet;
        /// <summary>
        /// 获取或设置质检问题模板
        /// </summary>
        public string MessageTemplet
        {
            get { return this.m_szMessageTemplet; }
            set { this.m_szMessageTemplet = value; }
        }

        private string m_szMessageTitle;
        /// <summary>
        /// 获取或设置质检问题标题
        /// </summary>
        public string MessageTempletTitle
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

        private string m_szMessageCode;
        /// <summary>
        /// 获取或设置质检问题模板编码
        /// </summary>
        public string MessageCode
        {
            get { return this.m_szMessageCode; }
            set { this.m_szMessageCode = value; }
        }

        public QuestionTypeForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
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
        /// <param name="szQuestionType">问题类型</param>
        /// <param name="node">当前父节点</param>
        /// </summary>
        private void AppendChildNode(string szQuestionType, TreeNode parentNode)
        {
            List<EMRDBLib.QcMsgDict> lstMessage = null;
            short shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(szQuestionType, ref lstMessage);
            if (shRet != SystemData.ReturnValue.OK || lstMessage == null)
                return;
            //根据MessageTitle再分组
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            for (int index = 0; index < lstMessage.Count; index++)
            {
                EMRDBLib.QcMsgDict qcMessageTemplet = lstMessage[index];
                if (!ht.ContainsKey(qcMessageTemplet.MESSAGE_TITLE))
                {
                    List<EMRDBLib.QcMsgDict> lstQCMessageTemplet = this.GetSameTitleTemplet(qcMessageTemplet.MESSAGE_TITLE, lstMessage);
                    if (lstQCMessageTemplet == null || lstQCMessageTemplet.Count == 0)
                        continue;
                    ht.Add(qcMessageTemplet.MESSAGE_TITLE, lstQCMessageTemplet);
                }
            }

            foreach (System.Collections.DictionaryEntry entry in ht)
            {
                List<EMRDBLib.QcMsgDict> lsts = (List<EMRDBLib.QcMsgDict>)entry.Value;
                if (entry.Key.ToString() != "")
                {
                    TreeNode level2Node = new TreeNode();
                    level2Node.Text = entry.Key.ToString();
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
            }

            //创建没有标题的节点
            List<EMRDBLib.QcMsgDict> lstEmpytTitle = (List<EMRDBLib.QcMsgDict>)ht[string.Empty];
            if (lstEmpytTitle == null || lstEmpytTitle.Count == 0)
                return;
            for (int index = 0; index < lstEmpytTitle.Count; index++)
            {
                TreeNode childNode = new TreeNode();
                childNode.Tag = lstEmpytTitle[index];
                childNode.Text = lstEmpytTitle[index].MESSAGE;
                childNode.ImageIndex = 2;
                childNode.SelectedImageIndex = 2;
                parentNode.Nodes.Add(childNode);
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

        private EMRDBLib.QcMsgDict selectedQCMessageTemplet = null;

        public EMRDBLib.QcMsgDict SelectedQCMessageTemplet
        {
            get { return selectedQCMessageTemplet; }
            set { selectedQCMessageTemplet = value; }
        }

        private void SetQcMessage(EMRDBLib.QcMsgDict qcMessage)
        {
            this.QuestionType = qcMessage.QA_EVENT_TYPE;
            this.MessageTemplet = qcMessage.MESSAGE;
            this.MessageTempletTitle = string.IsNullOrEmpty(qcMessage.MESSAGE_TITLE) ? qcMessage.QA_EVENT_TYPE : qcMessage.MESSAGE_TITLE;
            this.MessageCode = qcMessage.QC_MSG_CODE;
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
    }
}