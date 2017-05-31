// ***********************************************************
// 病案质控系统已有病程记录显示窗口.
// Creator:YangMingkun  Date:2009-11-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.Controls.VirtualTreeView;
using Heren.Common.DockSuite;

using EMRDBLib.DbAccess;
using EMRDBLib;
using MedQCSys.Document;
using Heren.Common.RichEditor;

namespace MedQCSys.DockForms
{
    public partial class DocumentListNewForm : DockContentBase
    {
        /// <summary>
        /// 病历阅读信息哈希表
        /// </summary>
        private Hashtable m_htQCActionLog = null;
        /// <summary>
        /// 病历质检问题
        /// </summary>
        private Hashtable m_htQCMsgInfs = null;

        /// <summary>
        /// 已有病历列表中合并文档节点标识
        /// </summary>
        private const string COMBIN_NODE_TAG = "COMBIN_NODE";
        /// <summary>
        /// 医生写的病历
        /// </summary>
        private const string DOCTOR_NODE_TAG = "DOC_NODE";
        /// <summary>
        /// 护士写的病历
        /// </summary>
        private const string NURSE_NODE_TAG = "NUR_NODE";
        /// <summary>
        /// 未知类型的病历
        /// </summary>
        private const string UNKNOWN_NODE_TAG = "UNKNOWN_NODE";

        /// <summary>
        /// 医生的病历
        /// </summary>
        private VirtualNode m_DoctorNode = null;
        /// <summary>
        /// 护士的病历
        /// </summary>
        private VirtualNode m_NurseNode = null;

        private VirtualNode m_SelectedNode;
        /// <summary>
        /// 获取当前选中的节点
        /// </summary>
        public VirtualNode SelectedNode
        {
            get { return this.m_SelectedNode; }
            set { this.m_SelectedNode = value; }
        }

        public DocumentListNewForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }

        public DocumentListNewForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent, patientPageControl)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.HideDockPanel();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.virtualTree1.SuspendLayout();
            this.virtualTree1.Columns.Add(new VirtualColumn("病历标题", 250));
            this.virtualTree1.Columns.Add(new VirtualColumn("记录时间", 150, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("创建时间", 150, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("创建人", 80, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("修改时间", 150, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("修改人", 80, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("质控读", 70, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("质检时间", 150, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("审签状态", 64, ContentAlignment.MiddleCenter));
            this.virtualTree1.ImageList.Images.Add(global::MedQCSys.Properties.Resources.Share);
            this.virtualTree1.ImageList.Images.Add(global::MedQCSys.Properties.Resources.CombinDoc);
            this.virtualTree1.PerformLayout();
        }

        /// <summary>
        /// 当切换活动文档时刷新数据
        /// </summary>
        protected override void OnActiveContentChanged()
        {
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this && this.NeedRefreshView)
                this.OnRefreshView();
        }

        /// <summary>
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            if (this.IsHidden)
                return;

            if (this.DockState == DockState.DockBottomAutoHide
                || this.DockState == DockState.DockTopAutoHide
                || this.DockState == DockState.DockLeftAutoHide
                || this.DockState == DockState.DockRightAutoHide)
            {
                if (SystemParam.Instance.PatVisitInfo != null)
                    this.DockHandler.Activate();
            }
            this.Update();

            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
                this.OnRefreshView();
        }

        /// <summary>
        /// 刷新患者当次就诊产生的病程记录
        /// </summary>
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在刷新病程记录，请稍候...");
            if (this.m_htQCActionLog == null)
                this.m_htQCActionLog = new Hashtable();
            else
                this.m_htQCActionLog.Clear();
            this.GetQCMsgInfo();
            this.GetQCActionLogInfo();
            this.virtualTree1.Nodes.Clear();
            string szDocSetID = string.Empty;
            if (this.m_SelectedNode != null)
            {
                MedDocInfo docInfo = this.m_SelectedNode.Data as MedDocInfo;
                if (docInfo != null)
                {
                    szDocSetID = docInfo.DOC_SETID;
                }
            }
            this.m_SelectedNode = null;
            //新版和仁编辑器加载方式和老版本有差别
            if (SystemParam.Instance.LocalConfigOption.DefaultEditor == "2")
                this.LoadHerenMedDocList();
            else
                this.LoadMedDocList();
            //使用新版本控件加载病历类型
            //this.LoadPastDocList();
            //添加一次质检问题后，会刷新病历节点，导致m_SelectedNode为空，此处重新选上
            SelectDocNodeByDocSetID(null, szDocSetID);
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 获取当前患者的质检问题
        /// </summary>
        private void GetQCMsgInfo()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;

            List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szPatientID, szVisitID, ref lstQCQuestionInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("质控质检问题下载失败！");
                return;
            }
            if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count <= 0)
                return;
            if (m_htQCMsgInfs == null)
                m_htQCMsgInfs = new Hashtable();
            if (m_htQCMsgInfs.Count > 0)
                m_htQCMsgInfs.Clear();
            foreach (EMRDBLib.MedicalQcMsg questionInfo in lstQCQuestionInfos)
            {
                if (!m_htQCMsgInfs.Contains(questionInfo.TOPIC_ID) && !string.IsNullOrEmpty(questionInfo.TOPIC_ID))
                    m_htQCMsgInfs.Add(questionInfo.TOPIC_ID, questionInfo);
            }
        }

        private void LoadMedDocList()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
                return;

            this.virtualTree1.SuspendLayout();
            this.virtualTree1.Tag = null;
            this.virtualTree1.Nodes.Clear();
            this.virtualTree1.PerformLayout();

            string szVisitType = MedDocSys.DataLayer.SystemData.VisitType.IP;
            MedDocList lstDocInfos = null;
            szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            short shRet = EmrDocAccess.Instance.GetDocInfos(szPatientID, szVisitID, szVisitType, DateTime.Now, string.Empty, ref lstDocInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取新格式病程记录失败！");
                return;
            }
            if (lstDocInfos == null || lstDocInfos.Count <= 0)
                return;
            lstDocInfos.Sort();

            //文档时间显示格式
            string szDocTimeFormat = "yyyy-MM-dd HH:mm";
            this.virtualTree1.SuspendLayout();
            this.virtualTree1.Tag = lstDocInfos;

            VirtualNode lastDocRootNode = new VirtualNode();
            lastDocRootNode.Text = "医生的病历";
            lastDocRootNode.ForeColor = Color.Blue;
            lastDocRootNode.ImageIndex = 0;
            lastDocRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            lastDocRootNode.Data = DOCTOR_NODE_TAG;
            lastDocRootNode.Expand();

            VirtualNode LastNurRootNode = new VirtualNode();
            LastNurRootNode.Text = "护士的病历";
            LastNurRootNode.ForeColor = Color.Blue;
            LastNurRootNode.ImageIndex = 0;
            LastNurRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            LastNurRootNode.Data = NURSE_NODE_TAG;
            LastNurRootNode.CollapseAll();

            VirtualNode otherDocRootNode = new VirtualNode("未被归类的病历");
            otherDocRootNode.ForeColor = Color.Blue;
            otherDocRootNode.ImageIndex = 1;
            otherDocRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            otherDocRootNode.Data = UNKNOWN_NODE_TAG;
            otherDocRootNode.Expand();

            Hashtable htDocType = new Hashtable();

            //加载已有文档列表到指定的容器
            for (int index = 0; index < lstDocInfos.Count; index++)
            {
                MedDocInfo docInfo = lstDocInfos[index];
                if (docInfo == null)
                    continue;

                VirtualNode docInfoNode = new VirtualNode(docInfo.DOC_TITLE);
                docInfoNode.Data = docInfo;
                docInfoNode.ForeColor = Color.Black;
                if (m_htQCMsgInfs != null && m_htQCMsgInfs.ContainsKey(docInfo.DOC_SETID))
                {
                    docInfoNode.ForeColor = Color.OrangeRed;
                }
                docInfoNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);

                VirtualSubItem subItem = null;
                DateTime dtDocTime = docInfo.DOC_TIME;


                subItem = new VirtualSubItem(dtDocTime.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(dtDocTime.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(docInfo.CREATOR_NAME);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(docInfo.MODIFY_TIME.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(docInfo.MODIFIER_NAME);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                string szReadTime = string.Empty;
                if (this.m_htQCActionLog.Contains(docInfo.DOC_SETID))
                    szReadTime = this.m_htQCActionLog[docInfo.DOC_SETID].ToString();

                subItem = new VirtualSubItem();
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                if (!string.IsNullOrEmpty(szReadTime))
                    subItem.Text = "是";
                else
                    subItem.Text = "否";
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(szReadTime);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                DocTypeInfo currDocType = null;
                DocTypeAccess.Instance.GetDocTypeInfo(docInfo.DOC_TYPE, ref currDocType);
                if (currDocType == null)
                {
                    otherDocRootNode.Nodes.Add(docInfoNode);
                    continue;
                }
                DocTypeInfo hostDocType = null;
                DocTypeAccess.Instance.GetDocTypeInfo(currDocType.HostTypeID, ref hostDocType);
                if (hostDocType == null)
                {
                    otherDocRootNode.Nodes.Add(docInfoNode);
                    continue;
                }

                VirtualNode hostDocRootNode = null;
                if (!htDocType.Contains(hostDocType.DocTypeID))
                {
                    hostDocRootNode = new VirtualNode();
                    hostDocRootNode.Text = hostDocType.DocTypeName;
                    hostDocRootNode.Tag = hostDocType.DocTypeName;
                    hostDocRootNode.Data = COMBIN_NODE_TAG;
                    hostDocRootNode.HitExpand = HitExpandMode.Click;
                    hostDocRootNode.Expand();
                    hostDocRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                    hostDocRootNode.ImageIndex = 1;
                    if (hostDocType.DocRight != MedDocSys.DataLayer.SystemData.UserType.NURSE)
                    {
                        lastDocRootNode.Nodes.Add(hostDocRootNode);
                    }
                    else if (hostDocType.DocRight == MedDocSys.DataLayer.SystemData.UserType.NURSE)
                    {
                        LastNurRootNode.Nodes.Add(hostDocRootNode);
                    }
                    else
                    {
                        this.virtualTree1.Nodes.Add(hostDocRootNode);
                    }
                    htDocType.Add(hostDocType.DocTypeID, hostDocRootNode);
                }
                else
                {
                    hostDocRootNode = htDocType[hostDocType.DocTypeID] as VirtualNode;
                }
                hostDocRootNode.Nodes.Add(docInfoNode);
            }
            htDocType.Clear();
            this.m_DoctorNode = lastDocRootNode;
            this.m_NurseNode = LastNurRootNode;
            if (otherDocRootNode.Nodes.Count > 0)
                this.virtualTree1.Nodes.Add(otherDocRootNode);
            if (lastDocRootNode.Nodes.Count > 0)
                this.virtualTree1.Nodes.Add(lastDocRootNode);
            if (LastNurRootNode.Nodes.Count > 0)
                this.virtualTree1.Nodes.Add(LastNurRootNode);
            this.virtualTree1.PerformLayout();
        }

        private void LoadHerenMedDocList()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_NO;//电子病历VISIT_NO存成了VISIT_ID
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
                return;

            this.virtualTree1.SuspendLayout();
            this.virtualTree1.Tag = null;
            this.virtualTree1.Nodes.Clear();
            this.virtualTree1.PerformLayout();

            string szVisitType = MedDocSys.DataLayer.SystemData.VisitType.IP;
            MedDocList lstDocInfos = null;
            short shRet = EmrDocAccess.Instance.GetDocInfos(szPatientID, szVisitID, szVisitType, DateTime.Now, string.Empty, ref lstDocInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取新格式病程记录失败！");
                return;
            }
            if (lstDocInfos == null || lstDocInfos.Count <= 0)
                return;
            lstDocInfos.Sort();

            //文档时间显示格式
            string szDocTimeFormat = "yyyy-MM-dd HH:mm";
            this.virtualTree1.SuspendLayout();
            this.virtualTree1.Tag = lstDocInfos;

            VirtualNode lastDocRootNode = new VirtualNode();
            lastDocRootNode.Text = "医生的病历";
            lastDocRootNode.ForeColor = Color.Blue;
            lastDocRootNode.ImageIndex = 0;
            lastDocRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            lastDocRootNode.Data = DOCTOR_NODE_TAG;
            lastDocRootNode.Expand();

            VirtualNode LastNurRootNode = new VirtualNode();
            LastNurRootNode.Text = "护士的病历";
            LastNurRootNode.ForeColor = Color.Blue;
            LastNurRootNode.ImageIndex = 0;
            LastNurRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            LastNurRootNode.Data = NURSE_NODE_TAG;
            LastNurRootNode.CollapseAll();

            VirtualNode otherDocRootNode = new VirtualNode("未被归类的病历");
            otherDocRootNode.ForeColor = Color.Blue;
            otherDocRootNode.ImageIndex = 1;
            otherDocRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            otherDocRootNode.Data = UNKNOWN_NODE_TAG;
            otherDocRootNode.Expand();

            Hashtable htDocType = new Hashtable();
            List<VirtualNode> childDocNodes = new List<VirtualNode>();
            //加载已有文档列表到指定的容器
            for (int index = 0; index < lstDocInfos.Count; index++)
            {
                MedDocInfo docInfo = lstDocInfos[index];
                if (docInfo == null)
                    continue;

                VirtualNode docInfoNode = new VirtualNode(docInfo.DOC_TITLE);
                if (!htDocType.ContainsKey(docInfo.DOC_ID))
                    htDocType.Add(docInfo.DOC_ID, docInfoNode);
                docInfoNode.HitExpand = HitExpandMode.None;
                docInfoNode.Expand();
                docInfoNode.Data = docInfo;
                docInfoNode.ForeColor = Color.Black;
                if (m_htQCMsgInfs != null && m_htQCMsgInfs.ContainsKey(docInfo.DOC_SETID))
                {
                    docInfoNode.ForeColor = Color.OrangeRed;
                }
                docInfoNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);

                VirtualSubItem subItem = null;
                DateTime dtDocTime = docInfo.DOC_TIME;
                dtDocTime = docInfo.DOC_TIME;

                subItem = new VirtualSubItem(dtDocTime.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(dtDocTime.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(docInfo.CREATOR_NAME);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(docInfo.MODIFY_TIME.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(docInfo.MODIFIER_NAME);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);


                string szReadTime = string.Empty;
                if (this.m_htQCActionLog.Contains(docInfo.DOC_SETID))
                    szReadTime = this.m_htQCActionLog[docInfo.DOC_SETID].ToString();

                subItem = new VirtualSubItem();
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                if (!string.IsNullOrEmpty(szReadTime))
                    subItem.Text = "是";
                else
                    subItem.Text = "否";

                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(szReadTime);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                subItem.ForeColor = Color.Blue;
                docInfoNode.SubItems.Add(subItem);


                subItem = new VirtualSubItem();
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                GetCnNameSignCode(docInfo, subItem);

                docInfoNode.SubItems.Add(subItem);

                DocTypeInfo currDocType = null;
                DocTypeAccess.Instance.GetDocTypeInfo(docInfo.DOC_TYPE, ref currDocType);
                if (currDocType == null)
                {
                    otherDocRootNode.Nodes.Add(docInfoNode);
                    continue;
                }
                DocTypeInfo hostDocType = null;
                DocTypeAccess.Instance.GetDocTypeInfo(currDocType.HostTypeID, ref hostDocType);
                if (hostDocType == null)
                    hostDocType = currDocType;
                //病历类型不需要审签
                if (currDocType.IsHostType
                    || ((string.IsNullOrEmpty(hostDocType.SignFlag)
                    || hostDocType.SignFlag == SystemData.SignType.NONE)
                    && (string.IsNullOrEmpty(currDocType.SignFlag)
                    || currDocType.SignFlag == SystemData.SignType.NONE)))
                {
                    subItem.Text = string.Empty;
                }

                if (currDocType.NeedCombin && !currDocType.IsHostType
                    && docInfo.DOC_ID != docInfo.DOC_SETID)
                {
                    childDocNodes.Add(docInfoNode);
                    continue;
                }


                VirtualNode hostDocRootNode = null;
                if (htDocType.ContainsKey(hostDocType.DocTypeID))
                    hostDocRootNode = htDocType[hostDocType.DocTypeID] as VirtualNode;

                if (hostDocRootNode == null)
                {
                    hostDocRootNode = new VirtualNode();
                    hostDocRootNode.Text = hostDocType.DocTypeName;
                    hostDocRootNode.Tag = hostDocType.DocTypeName;
                    hostDocRootNode.Data = COMBIN_NODE_TAG;
                    hostDocRootNode.HitExpand = HitExpandMode.Click;
                    hostDocRootNode.Expand();
                    hostDocRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                    hostDocRootNode.ImageIndex = 0;
                    if (hostDocType.DocRight != MedDocSys.DataLayer.SystemData.UserType.NURSE)
                    {
                        lastDocRootNode.Nodes.Add(hostDocRootNode);
                    }
                    else if (hostDocType.DocRight == MedDocSys.DataLayer.SystemData.UserType.NURSE)
                    {
                        LastNurRootNode.Nodes.Add(hostDocRootNode);
                    }
                    else
                    {
                        this.virtualTree1.Nodes.Add(hostDocRootNode);
                    }
                    htDocType.Add(hostDocType.DocTypeID, hostDocRootNode);
                }
                hostDocRootNode.Nodes.Add(docInfoNode);
            }

            foreach (VirtualNode node in childDocNodes)
            {
                if (node.Parent != null)
                    continue;
                MedDocInfo docInfo = node.Data as MedDocInfo;
                if (docInfo == null)
                    continue;

                if (htDocType.ContainsKey(docInfo.DOC_SETID))
                {
                    VirtualNode parent = htDocType[docInfo.DOC_SETID] as VirtualNode;
                    if (parent != null && parent != node)
                        parent.Nodes.Add(node);
                }
                if (node.Parent == null)
                    otherDocRootNode.Nodes.Add(node);
            }
            htDocType.Clear();
            this.m_DoctorNode = lastDocRootNode;
            this.m_NurseNode = LastNurRootNode;
            if (otherDocRootNode.Nodes.Count > 0)
                this.virtualTree1.Nodes.Add(otherDocRootNode);
            if (lastDocRootNode.Nodes.Count > 0)
                this.virtualTree1.Nodes.Add(lastDocRootNode);
            if (LastNurRootNode.Nodes.Count > 0)
                this.virtualTree1.Nodes.Add(LastNurRootNode);
            this.virtualTree1.PerformLayout();
        }

        private static void GetCnNameSignCode(MedDocInfo docInfo, VirtualSubItem subItem)
        {
            if (string.IsNullOrEmpty(docInfo.SIGN_CODE))
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.CREATOR_SAVE_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.CREATOR_SAVE)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.CREATOR_SAVE_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.CREATOR_COMMIT)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.CREATOR_COMMIT_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.PARENT_SAVE)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.PARENT_SAVE_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.SUPER_SAVE)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.SUPER_SAVE_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.CREATOR_COMMIT)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.CREATOR_COMMIT_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.PARENT_COMMIT)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.PARENT_COMMIT_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.SUPER_COMMIT)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.SUPER_COMMIT_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.PARENT_ROLLBACK)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.PARENT_ROLLBACK_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.SUPER_ROLLBACK)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.SUPER_ROLLBACK_CH;
            }
            else if (docInfo.SIGN_CODE == MedDocSys.DataLayer.SystemData.SignState.QC_ROLLBACK)
            {
                subItem.Text = MedDocSys.DataLayer.SystemData.SignState.QC_ROLLBACK_CH;
            }
        }
        private void LoadPastDocList()
        {
            if (this.MainForm == null || this.MainForm.IsDisposed || SystemParam.Instance.PatVisitInfo == null)
                return;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
                return;

            MedDocList lstPastDocInfos = null;
            short shRet = EMRDBAccess.Instance.GetPastDocList(szPatientID, szVisitID, ref lstPastDocInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND
                )
            {
                MessageBoxEx.Show("获取旧病程记录列表失败！");
                return;
            }
            if (lstPastDocInfos == null || lstPastDocInfos.Count <= 0)
                return;
            lstPastDocInfos.Sort();

            //文档时间显示格式
            string szDocTimeFormat = "yyyy-MM-dd HH:mm";

            VirtualNode oldDocRootNode = new VirtualNode("以往旧病历");
            oldDocRootNode.ForeColor = Color.Blue;
            oldDocRootNode.Data = lstPastDocInfos;
            oldDocRootNode.ImageIndex = 1;
            oldDocRootNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
            oldDocRootNode.Expand();

            Hashtable htDocType = new Hashtable();

            //加载已有文档列表到指定的容器
            for (int index = 0; index < lstPastDocInfos.Count; index++)
            {
                MedDocInfo pastDocInfo = lstPastDocInfos[index];
                if (pastDocInfo.DOC_ID.Contains("_"))
                {
                    pastDocInfo.DOC_SETID = pastDocInfo.DOC_ID.Substring(0, pastDocInfo.DOC_ID.LastIndexOf('_'));
                }
                if (pastDocInfo == null)
                    continue;

                string szDocTitle = "无主题";
                if (!GlobalMethods.Misc.IsEmptyString(pastDocInfo.DOC_TITLE))
                    szDocTitle = pastDocInfo.DOC_TITLE;
                VirtualNode docInfoNode = new VirtualNode(szDocTitle);
                docInfoNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                docInfoNode.Data = pastDocInfo;
                docInfoNode.ForeColor = Color.Black;

                VirtualSubItem subItem = null;
                subItem = new VirtualSubItem(pastDocInfo.DOC_TIME.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(pastDocInfo.CREATOR_NAME);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(pastDocInfo.MODIFY_TIME.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(pastDocInfo.MODIFIER_NAME);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                docInfoNode.SubItems.Add(subItem);

                string szReadTime = string.Empty;
                if (this.m_htQCActionLog.Contains(pastDocInfo.DOC_SETID))
                    szReadTime = this.m_htQCActionLog[pastDocInfo.DOC_SETID].ToString();

                subItem = new VirtualSubItem();
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                if (!string.IsNullOrEmpty(szReadTime))
                    subItem.Text = "是";
                else
                    subItem.Text = "否";
                docInfoNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(szReadTime);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                subItem.ForeColor = Color.Blue;
                docInfoNode.SubItems.Add(subItem);

                oldDocRootNode.Nodes.Add(docInfoNode);
            }
            this.virtualTree1.Nodes.Add(oldDocRootNode);
        }

        /// <summary>
        /// 获取选中节点的病历文档的标题和文档集ID
        /// </summary>
        /// <param name="selectedNode">当前节点</param>
        /// <param name="szDocSetID">文档集ID</param>
        /// <param name="szDocTitle">文档标题</param>
        /// <param name="byteDocData">文档数据</param>
        private void GetSelectedNodeInfo(VirtualNode selectedNode, ref string szDocTitle, ref string szDocSetID
            , ref string szCreatorName, ref string szDeptCode, ref byte[] byteDocData)
        {
            MedDocInfo docInfo = selectedNode.Data as MedDocInfo;
            if (docInfo != null)
            {
                szDocTitle = docInfo.DOC_TITLE;

                if (docInfo.EMR_TYPE != "BAODIAN" && docInfo.EMR_TYPE != "CHENPAD" && docInfo.EMR_TYPE != "HEREN")
                    szDocSetID = string.Empty;
                else
                    szDocSetID = docInfo.DOC_SETID;
                szCreatorName = docInfo.CREATOR_NAME;
                szDeptCode = docInfo.DEPT_CODE;
                EmrDocAccess.Instance.GetDocByID(docInfo.DOC_ID, ref byteDocData);
            }
            else if (selectedNode.Data.Equals(COMBIN_NODE_TAG))
                szDocTitle = string.Concat(SystemParam.Instance.PatVisitInfo.PATIENT_NAME, "的病历");
            else if (selectedNode.Data.Equals(DOCTOR_NODE_TAG))
                szDocTitle = "医生写的病历";
            else if (selectedNode.Data.Equals(NURSE_NODE_TAG))
                szDocTitle = "护士写的病历";
            else if (selectedNode.Data.Equals(UNKNOWN_NODE_TAG))
                szDocTitle = "未被归类的病历";
            else
                szDocTitle = string.Concat(SystemParam.Instance.PatVisitInfo.PATIENT_NAME, "的以往旧病历");
        }

        ///<summary>
        /// 记录质控者阅读病历日志信息
        /// </summary>
        /// <param name="lstDocInfo">病历文档信息列表</param>
        /// <param name="dtCheckTime">检查时间</param>
        /// <param name="node">当前节点</param>
        private void SaveReadLogInfo(MedDocInfo docInfo, DateTime dtCheckTime, VirtualNode node)
        {
            if (string.IsNullOrEmpty(docInfo.DOC_SETID))
                return;

            EMRDBLib.MedicalQcLog qcActionLog = new EMRDBLib.MedicalQcLog();
            qcActionLog.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            qcActionLog.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcActionLog.DEPT_STAYED = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            qcActionLog.DOC_SETID = docInfo.DOC_SETID;
            qcActionLog.CHECKED_BY = SystemParam.Instance.UserInfo.Name;
            qcActionLog.CHECKED_ID = SystemParam.Instance.UserInfo.ID;
            qcActionLog.DEPT_CODE = SystemParam.Instance.UserInfo.DeptCode;
            qcActionLog.DEPT_NAME = SystemParam.Instance.UserInfo.DeptName;
            qcActionLog.CHECK_TYPE = 0;
            qcActionLog.CHECK_DATE = dtCheckTime;
            qcActionLog.LOG_TYPE = 1;
            qcActionLog.LOG_DESC = "质控者阅读病历";
            qcActionLog.AddQCQuestion = false;
            short shRet = MedicalQcLogAccess.Instance.Insert(qcActionLog);
            if (shRet != SystemData.ReturnValue.OK)
                return;

            node.SubItems[5].Text = "是";
            node.SubItems[6].Text = dtCheckTime.ToString("yyyy-MM-dd HH:mm:ss");
            node.SubItems[6].ForeColor = Color.Blue;
        }

        /// <summary>
        /// 获取当前患者本次就诊最近一次的病历阅读日志信息
        /// </summary>
        private void GetQCActionLogInfo()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            int nLogType = 1;
            int nOperateType = 0;
            List<EMRDBLib.MedicalQcLog> lstQCActionLog = null;
            short shRet = MedicalQcLogAccess.Instance.GetQCLogInfo(szPatientID, szVisitID, nLogType, nOperateType, ref lstQCActionLog);
            if (shRet != SystemData.ReturnValue.OK)
                return;

            if (lstQCActionLog == null || lstQCActionLog.Count <= 0)
                return;

            for (int index = 0; index < lstQCActionLog.Count; index++)
            {
                this.m_htQCActionLog.Add(lstQCActionLog[index].DOC_SETID, lstQCActionLog[index].CHECK_DATE);
            }
        }

        private void virtualTree1_NodeMouseDoubleClick(object sender, VirtualTreeEventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (e.Node == null || e.Type == HitTestType.None)
                return;

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载并打开病历，请稍候...");

            DateTime dtCheckTime = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            MedDocInfo docInfo = e.Node.Data as MedDocInfo;

            if (docInfo == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            this.Update();
            this.OpenDocument(docInfo);
            //有审核病历权限用户查看病例后需要记录下来，表示审核人员已经查阅了该份病历
            //非审核人员查阅病历病历审核状态不改变，依然为未审阅。
            if (SystemParam.Instance.CurrentUserHasQCCheckRight)
            {
                //提示已经被质控过，确认后才更新质控阅读记录
                //提示文档被质控过的信息，如果最新质控记录为当前用户，则不提示，如果为其他用户，则提示。
                MedicalQcLog qcActionLog = null;
                short shRet = MedicalQcLogAccess.Instance.GetQCLogInfo(docInfo.DOC_SETID, 1, ref qcActionLog);
                if (shRet == SystemData.ReturnValue.OK)
                {
                    if (qcActionLog.CHECKED_ID != SystemParam.Instance.UserInfo.ID)
                    {
                        string msg = string.Format("当前病历已经被{0}于{1}质控阅读过!\t\n如需重新质控，请单击【确定】按钮"
                            , qcActionLog.CHECKED_BY
                            , qcActionLog.CHECK_DATE.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (MessageBoxEx.ShowConfirm(msg) != DialogResult.OK)
                        {
                            this.ShowStatusMessage(null);
                            GlobalMethods.UI.SetCursor(this, Cursors.Default);
                            return;
                        }
                    }
                }
                this.SaveReadLogInfo(docInfo, dtCheckTime, e.Node);
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            return;

        }
        public void OpenDocument(string szDocTile)
        {
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            string szVisitNo = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            List<MedDocInfo> lstMedDocInfo = null;
            EmrDocAccess.Instance.GetDocList(szPatientID, szVisitNo, ref lstMedDocInfo);
            if (lstMedDocInfo == null || lstMedDocInfo.Count <= 0)
                return;
            foreach (var item in lstMedDocInfo)
            {
                if (item.DOC_TITLE.Contains(szDocTile))
                {
                    this.OpenDocument(item);
                    break;
                }
            }
        }
        public void OpenDocument(MedDocInfo docInfo)
        {
            if (this.dockPanel1.Contents.Count == 0)
            {
                this.ShowDockPanel();
            }
            else
            {
                foreach (var item in this.dockPanel1.Documents)
                {
                    if (!(item is HerenDocForm))
                        continue;
                    HerenDocForm doc = item as HerenDocForm;
                    if (doc.Document.DOC_SETID == docInfo.DOC_SETID)
                    {
                        doc.Activate();
                        if (doc.Document.DOC_ID != docInfo.DOC_ID)
                        {
                            doc.GoSection(docInfo);
                        }
                        return;
                    }
                }
            }

            HerenDocForm docForm = new HerenDocForm(this.MainForm);
            docForm.OpenDocument(docInfo);
            docForm.Show(this.dockPanel1, true);
        }
        public void ShowDockPanel()
        {
            if (!this.dockPanel1.Visible)
            {
                this.dockPanel1.Visible = true;
                this.arrowSplitter1.Visible = true;
                this.virtualTree1.Dock = DockStyle.Left;
            }
        }
        public void HideDockPanel()
        {
            this.dockPanel1.Visible = false;
            this.arrowSplitter1.Visible = false;
            this.virtualTree1.Dock = DockStyle.Fill;
        }
        /// <summary>
        /// 打开医生或护士创建的所有病历
        /// <param name="parentNode">双击的节点</param>
        /// </summary>
        private void OpenAllDocList(VirtualNode parentNode)
        {
            if (parentNode == null || parentNode.Nodes.Count <= 0)
                return;

            MedDocList lstDocInfos = new MedDocList();
            DateTime dtCheckTime = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            for (int index = 0; index < parentNode.Nodes.Count; index++)
            {
                if (!parentNode.Nodes[index].Data.Equals(COMBIN_NODE_TAG))
                    continue;

                if (index > 0)
                    dtCheckTime = dtCheckTime.AddSeconds(1);
                for (int ii = 0; ii < parentNode.Nodes[index].Nodes.Count; ii++)
                {
                    VirtualNode childNode = parentNode.Nodes[index].Nodes[ii];
                    MedDocInfo docInfo = childNode.Data as MedDocInfo;
                    if (docInfo == null)
                        continue;

                    if (ii > 0)
                        dtCheckTime = dtCheckTime.AddSeconds(1);
                    this.SaveReadLogInfo(docInfo, dtCheckTime, childNode);
                    lstDocInfos.Add(docInfo);
                }
            }
            this.Update();
            this.MainForm.OpenDocument(lstDocInfos);
        }

        private void mnuAddFeedInfo_Click(object sender, EventArgs e)
        {
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;

            if (!SystemParam.Instance.CurrentUserHasQCCheckRight)
            {
                MessageBoxEx.Show("您没有权限添加质检问题！", MessageBoxIcon.Warning);
                return;
            }
            if (!SystemParam.Instance.QCUserRight.CommitQCQuestion.Value)
            {
                MessageBoxEx.Show("您没有权限添加质检问题！", MessageBoxIcon.Warning);
                return;
            }
            VirtualNode selectedNode = this.virtualTree1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBoxEx.Show("没有选中病历文书中任何一份病历，无法添加质检问题！", MessageBoxIcon.Warning);
                return;
            }

            string szDocTitle = string.Empty;
            string szDocSetID = string.Empty;
            string szDocCreator = string.Empty;
            string szDeptCode = string.Empty;
            byte[] byteDocData = null;
            MedDocInfo docInfo = selectedNode.Data as MedDocInfo;
            if (docInfo == null && !SystemParam.Instance.LocalConfigOption.AllowAddQuestionToParDocType)
            {
                MessageBoxEx.Show("没有选中病历文书中任何一份病历，无法添加质检问题！", MessageBoxIcon.Warning);
                return;
            }
            if (docInfo != null)
            {
                this.GetSelectedNodeInfo(selectedNode, ref szDocTitle, ref szDocSetID, ref szDocCreator, ref szDeptCode, ref byteDocData);
            }
            else if (SystemParam.Instance.LocalConfigOption.AllowAddQuestionToParDocType)
            {
                szDocTitle = selectedNode.ToString();
                szDocSetID = string.Empty;
                szDocCreator = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
                szDeptCode = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            }
            this.MainForm.AddFeedBackInfo(szDocTitle, szDocSetID, szDocCreator, szDeptCode, byteDocData);
        }

        private void virtualTree1_NodeMouseClick(object sender, VirtualTreeEventArgs e)
        {
            this.m_SelectedNode = e.Node;
            //显示质检问题
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (e.Node == null || e.Type == HitTestType.None)
                return;
            MedDocInfo docInfo = e.Node.Data as MedDocInfo;
            this.MainForm.ShowQuestionListByDocInfo(docInfo);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!SystemParam.Instance.QCUserRight.BrowseQCQuestion.Value)
                this.mnuAddFeedInfo.Visible = false;
        }

        public void SelectDocNodeByDocSetID(VirtualNode node, string szDocSetId)
        {
            if (string.IsNullOrEmpty(szDocSetId))
                return;
            if (node == null)
            {
                foreach (VirtualNode item in this.virtualTree1.Nodes)
                {
                    if (item == null)
                        continue;
                    SelectDocNodeByDocSetID(item, szDocSetId);
                }
            }
            else
            {
                if (node.Nodes.Count > 0)
                    foreach (VirtualNode item in node.Nodes)
                    {
                        if (item == null)
                            continue;
                        SelectDocNodeByDocSetID(item, szDocSetId);
                    }
                else
                {
                    MedDocInfo docInfo = node.Data as MedDocInfo;
                    if (docInfo == null)
                        return;
                    if (docInfo.DOC_SETID == szDocSetId)
                    {
                        this.virtualTree1.SelectedNode = node;
                        this.m_SelectedNode = node;
                        return;
                    }
                }
            }
        }

        private void dockPanel1_ContentRemoved(object sender, DockContentEventArgs e)
        {
            if (this.dockPanel1.Contents.Count == 0)
                this.HideDockPanel();
        }
    }
}