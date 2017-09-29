using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.MedQC.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Utilities.Dialogs
{
    /// <summary>
    /// 采用文书编辑器实现的打印窗口，通过加载Form表单模板，数据加载通过脚本绑定到文书元素中
    /// 目的是实现检验报告等连续可动态扩展打印。
    /// </summary>
    public partial class DocumentPrintStyleForm : HerenForm
    {
        public DocumentPrintStyleForm()
        {
            InitializeComponent();
        }
        private TempletType m_TempletType = null;
        public TempletType TempletType
        {
            set
            {
                this.m_TempletType = value;
            }
        }
        public object Data { get; set; }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.m_TempletType == null)
            {
                MessageBoxEx.ShowMessage("未指定打印表单");
                return;
            }
            byte[] byteTempletData = null;
            bool result = TempletTypeCache.Instance.GetFormTemplet(this.m_TempletType.DocTypeID, ref byteTempletData);
            if (result)
                this.editor.Load(byteTempletData);
            this.editor.UpdateFormData("加载数据", this.Data);

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                if (this.m_TempletType == null)
                    return false;
                string szDocTypeID = this.m_TempletType.DocTypeID;
                if (string.IsNullOrEmpty(szDocTypeID))
                    return true;
                byte[] byteTempletData = null;
                bool result = TempletTypeCache.Instance.GetFormTemplet(this.m_TempletType.DocTypeID, ref byteTempletData);
                if (result)
                    this.editor.Load(byteTempletData);
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.editor.ExecuteQuery += Editor_ExecuteQuery;
            this.editor.QueryContext += Editor_QueryContext;
        }
        private void Editor_QueryContext(object sender, Heren.Common.Forms.Editor.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = SystemContext.Instance.GetSystemContext(e.Name, ref value);
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

        private void toolbtnPrint_Click(object sender, EventArgs e)
        {
            this.editor.UpdateFormData("打印", string.Empty);
        }
    }
}
