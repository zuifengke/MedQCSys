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

using EMRDBLib;
using EMRDBLib.DbAccess;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Systems
{
    internal partial class TempletStatForm : DockContentBase
    {
        private Hashtable m_htDocTypeList = null;
        public TempletStatForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.virtualTree1.SuspendLayout();
            this.virtualTree1.Columns.Add(new VirtualColumn("模板名称", 260, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("所属类型", 150, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("作者", 120, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("修改时间", 180, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("共享", 100, ContentAlignment.MiddleCenter));
            this.virtualTree1.Columns.Add(new VirtualColumn("审核", 100, ContentAlignment.MiddleCenter));
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
        /// 
        /// </summary>
        public override void OnRefreshView()
        {

            base.OnRefreshView();        
            this.Update();
            if (this.virtualTree1.Nodes.Count > 0)
                this.virtualTree1.Nodes.Clear();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在加载文档类型列表，请稍候...");
            this.LoadDocTypeList();
            this.ShowStatusMessage("正在加载待审核模板列表，请稍候...");
            List< TempletInfo> lstTempletInfo = null;
            short shRet =TempletAccess.Instance.GetUserTempletInfos("0", ref lstTempletInfo);
            if (shRet != SystemData.ReturnValue.OK )
            {
                MessageBoxEx.Show("获取待审核模板列表失败");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.ShowStatusMessage(null);
                return;
            }
            if (lstTempletInfo == null)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.ShowStatusMessage("未找到待审核的模板");
                return;
            }
            //查询医生已修正确认的模板列表
            List< TempletInfo> lstModifyTempletInfos = null;
            shRet =TempletAccess.Instance.GetUserTempletInfos("2", ref lstModifyTempletInfos);
            if (shRet != SystemData.ReturnValue.OK && shRet !=  SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("获取医生已确认修正待审核模板列表失败");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                this.ShowStatusMessage(null);
                return;
            }
            if (lstModifyTempletInfos != null)
                lstTempletInfo.AddRange(lstModifyTempletInfos);
            lstTempletInfo.Sort(new Comparison< TempletInfo>(this.Compare));
            //模板时间显示格式
            string szDocTimeFormat = "yyyy-MM-dd HH:mm";
            string szDeptCode = string.Empty;
            VirtualNode deptNode = null;
            for (int index = 0; index < lstTempletInfo.Count; index++)
            {
                 TempletInfo templetInfo = lstTempletInfo[index];
                if (templetInfo == null)
                    continue;
                if (templetInfo.IsFolder)
                    continue;
                //添加科室名称显示行
                if (templetInfo.DeptCode != szDeptCode)
                {
                    deptNode = new VirtualNode(templetInfo.DeptName);
                    deptNode.ForeColor = Color.Blue;
                    deptNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                    this.virtualTree1.Nodes.Add(deptNode);
                    deptNode.Expand();
                }
                szDeptCode = templetInfo.DeptCode;
                VirtualNode templetNode = new VirtualNode(templetInfo.TempletName);
                templetNode.Data = templetInfo;
                templetNode.ForeColor = Color.Black;
                templetNode.Font = new Font("宋体", 10.5f, FontStyle.Regular);

                string szDocTypeName = string.Empty;
                 DocTypeInfo docTypeInfo = this.m_htDocTypeList[templetInfo.DocTypeID] as  DocTypeInfo;
                if (docTypeInfo == null)
                    szDocTypeName = templetInfo.DocTypeID;
                else
                    szDocTypeName = docTypeInfo.DocTypeName;
                VirtualSubItem subItem = null;
                subItem = new VirtualSubItem(szDocTypeName);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                templetNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(templetInfo.CreatorName);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                templetNode.SubItems.Add(subItem);

                subItem = new VirtualSubItem(templetInfo.ModifyTime.ToString(szDocTimeFormat));
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                templetNode.SubItems.Add(subItem);

                string szShareLevel = string.Empty;
                if (templetInfo.ShareLevel ==  SystemData.ShareLevel.HOSPITAL)
                    szShareLevel = "全院";
                else if (templetInfo.ShareLevel ==  SystemData.ShareLevel.DEPART)
                    szShareLevel = "科室";
                else
                    szShareLevel = "个人";
                subItem = new VirtualSubItem(szShareLevel);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                templetNode.SubItems.Add(subItem);

                string szCheckStatus = string.Empty;
                if (templetInfo.CheckStatus ==  TempletCheckStatus.None)
                    szCheckStatus = "未审核";
                else if (templetInfo.CheckStatus ==  TempletCheckStatus.Affirm)
                    szCheckStatus = "已确认";
                subItem = new VirtualSubItem(szCheckStatus);
                subItem.Font = new Font("宋体", 10.5f, FontStyle.Regular);
                subItem.Alignment = Alignment.Middle;
                templetNode.SubItems.Add(subItem);
                deptNode.Nodes.Add(templetNode);
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 对指定的两个模板信息对象进行排序
        /// </summary>
        /// <param name="templetInfo1">模板信息对象1</param>
        /// <param name="templetInfo2">模板信息对象2</param>
        /// <returns>int</returns>
        private int Compare( TempletInfo templetInfo1,  TempletInfo templetInfo2)
        {
            if (templetInfo1 == null && templetInfo2 != null)
                return -1;
            if (templetInfo1 != null && templetInfo2 == null)
                return 1;
            if (templetInfo1 == null && templetInfo2 == null)
                return 0;
            return string.Compare(templetInfo1.DeptCode, templetInfo2.DeptCode);
        }

        /// <summary>
        /// 装载文档类型列表
        /// </summary>
        private void LoadDocTypeList()
        {
            if (this.m_htDocTypeList == null)
                this.m_htDocTypeList = new Hashtable();
            this.m_htDocTypeList.Clear();

            List< DocTypeInfo> lstDocTypeInfo = null;
            short shRet = DocTypeAccess.Instance.GetDocTypeInfos(ref lstDocTypeInfo);
            if (lstDocTypeInfo == null)
                return;

            //加载文档类型列表
            for (int index = 0; index < lstDocTypeInfo.Count; index++)
            {
                 DocTypeInfo docTypeInfo = lstDocTypeInfo[index];
                if (!docTypeInfo.CanCreate)
                    continue;

                if (!this.m_htDocTypeList.Contains(docTypeInfo.DocTypeID))
                    this.m_htDocTypeList.Add(docTypeInfo.DocTypeID, docTypeInfo);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.OnRefreshView();
        }
    }
}