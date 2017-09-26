// 病案质控系统患者信息窗口.
// Creator:LiChunYing  Date:2011-09-28
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;

using EMRDBLib.DbAccess;
using EMRDBLib.Entity;
using EMRDBLib;
using Heren.MedQC.Core;

namespace MedQCSys.DockForms
{
    public partial class PatientInfoForm : DockContentBase
    {
        public PatientInfoForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.editor.ExecuteQuery += Editor_ExecuteQuery;
            this.editor.QueryContext += Editor_QueryContext;


            string szReportName = string.Format("{0}\\Templet\\{1}.hndt", GlobalMethods.Misc.GetWorkingPath(), "患者信息");
            this.editor.Load(szReportName);
        }

        public PatientInfoForm(MainForm mainForm, PatPage.PatientPageControl patientPageControl)
            : base(mainForm, patientPageControl)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = false;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.editor.ExecuteQuery += Editor_ExecuteQuery;
            this.editor.QueryContext += Editor_QueryContext;
        }
        private TempletType m_docTypeInfo = null;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                if (this.m_docTypeInfo == null)
                    return false;
                string szDocTypeID = this.m_docTypeInfo.DocTypeID;
                if (string.IsNullOrEmpty(szDocTypeID))
                    return true;
                //重新查询获取文档类型信息
                TempletType docTypeInfo = null;
                short shRet = TempletTypeAccess.Instance.GetTempletType(szDocTypeID, ref docTypeInfo);
                // 如果本地与服务器的版本相同,则无需重新加载
                DateTime dtModifyTime = TempletTypeCache.Instance.GetFormModifyTime(docTypeInfo.DocTypeID);
                if (dtModifyTime.CompareTo(docTypeInfo.ModifyTime) == 0)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return true;
                }
                byte[] byteTempletData = null;
                bool result = TempletTypeCache.Instance.GetFormTemplet(docTypeInfo, ref byteTempletData);
                if (!result)
                {
                    MessageBoxEx.Show("刷新失败");
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return true;
                }
                byte[] byteDocData = null;
                this.editor.Save(ref byteDocData);
                result = this.editor.Load(byteDocData, byteTempletData);
                if (!result)
                {
                    MessageBoxEx.Show("刷新失败");
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return true;
                }
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        //public override void OnRefreshView()
        //{
        //    base.OnRefreshView();
        //    string szReportName = string.Format("{0}\\Templet\\{1}.hndt", GlobalMethods.Misc.GetWorkingPath(), "患者信息");
        //    this.editor.Load(szReportName);

        //}
        private void Editor_QueryContext(object sender, Heren.Common.Forms.Editor.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void Editor_ExecuteQuery(object sender, Heren.Common.Forms.Editor.ExecuteQueryEventArgs e)
        {
            DataSet result = null;
            if (CommonAccess.Instance.ExecuteQuery(e.SQL, out result) == SystemData.ReturnValue.OK)
            {
                e.Success = true;
                e.Result = result;
            }
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "患者ID号" || name == "患者ID")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            else if (name == "就诊ID号" || name == "入院次")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                return true;
            }
            return false;
        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            //if (SystemParam.Instance.PatVisitInfo == null)
            //    return;

            //this.ShowStatusMessage("正在获取患者信息，请稍候...");
            //this.Update();

            //string szReportName = string.Format("{0}\\Templet\\{1}.hndt", GlobalMethods.Misc.GetWorkingPath(), "患者信息");
            //this.editor.Load(szReportName);

            //this.ShowStatusMessage(null);
            List<TempletType> lstTempletTypes = null;
            short shRet = TempletTypeAccess.Instance.GetTempletTypes(SystemData.TempletTypeApplyEnv.PATIENT_INFO, ref lstTempletTypes);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            this.m_docTypeInfo = lstTempletTypes[0];
            byte[] byteTempletData = null;
            bool result = TempletTypeCache.Instance.GetFormTemplet(this.m_docTypeInfo.DocTypeID, ref byteTempletData);
            if (result)
                this.editor.Load(byteTempletData);
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
    }
}