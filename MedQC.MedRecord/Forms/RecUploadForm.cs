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
using MedQCSys.DockForms;
using MedQCSys;
using System.Linq;
using Heren.Common.Forms.Editor;
using Heren.MedQC.Utilities;

namespace Heren.MedQC.MedRecord
{
    public partial class RecUploadForm : DockContentBase
    {
        public RecUploadForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.editor.ExecuteQuery += Editor_ExecuteQuery;
            this.editor.QueryContext += Editor_QueryContext;
            this.editor.CustomEvent += Editor_CustomEvent;

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
                if (docTypeInfo == null)
                    return false;
                DateTime dtModifyTime = FormCache.Instance.GetFormModifyTime(docTypeInfo.DocTypeID);
                if (dtModifyTime.CompareTo(docTypeInfo.ModifyTime) == 0)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return true;
                }
                byte[] byteTempletData = null;
                bool result = FormCache.Instance.GetFormTemplet(docTypeInfo, ref byteTempletData);
                if (!result)
                {
                    MessageBoxEx.Show("刷新失败");
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return true;
                }
                byte[] byteDocData = null;
                //this.editor.Save(ref byteDocData);
                result = this.editor.Load(null, byteTempletData);
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
       
        private void Editor_CustomEvent(object sender, CustomEventArgs e)
        {
            if (e.Name == "病区选择对话框")
            {
                bool multiSelected = false;
                if (e.Param != null)
                    multiSelected = GlobalMethods.Convert.StringToValue(e.Param.ToString(), false);
                DataTable table = e.Data as DataTable;
                if (table == null)
                    table = new DataTable();
                e.Result = UtilitiesHandler.Instance.ShowDeptSelectDialog(0, multiSelected, table);
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
            List<TempletType> lstTempletTypes = null;
            short shRet = TempletTypeAccess.Instance.GetTempletTypes(SystemData.DocTypeApplyEnv.REC_UPLOAD, ref lstTempletTypes);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            this.m_docTypeInfo = lstTempletTypes.Where(m => m.IsValid && !m.IsFolder).FirstOrDefault();
            if (this.m_docTypeInfo == null)
            {
                MessageBoxEx.ShowMessage("窗口加载失败");
                return;
            }
            byte[] byteTempletData = null;
            bool result = FormCache.Instance.GetFormTemplet(this.m_docTypeInfo.DocTypeID, ref byteTempletData);
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

        private void editor_ExecuteUpdate(object sender, ExecuteUpdateEventArgs e)
        {
            if (CommonAccess.Instance.ExecuteUpdate(e.IsProc, e.SQL) == SystemData.ReturnValue.OK)
                e.Success = true;
        }

        private void editor_ShowProgressMessage(object sender, ShowProgressMessageEventArgs e)
        {
            WorkProcess.Instance.Initialize(this,e.MaxProgressValue,e.DefaultMessage);

        }

        private void editor_UpdateProgressMessage(object sender, UpdateProgressMessageEventArgs e)
        {
            WorkProcess.Instance.Show(e.Message, e.ProgressValue, true);
            if (WorkProcess.Instance.Canceled)
                WorkProcess.Instance.Close();
        }

        private void editor_CloseProgressMessage(object sender, EventArgs e)
        {
            WorkProcess.Instance.Close();
        }
    }
}