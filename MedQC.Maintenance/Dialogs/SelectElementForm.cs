using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using Heren.MedQC.Frame.Document;
using Heren.MedQC.Model.MedDoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Maintenance.Dialogs
{
    public partial class SelectElementForm : Form
    {
        public SelectElementForm()
        {
            InitializeComponent();
        }
        public DocumentEditor TempletEditor { get; set; }
        protected override void OnLoad(EventArgs e)
        {

            if (SystemParam.Instance.LocalConfigOption.DefaultEditor == SystemData.DefaultEditor.Heren)
            {
                this.TempletEditor = new Heren.MedQC.Frame.Document.HerenEditor();
                this.TempletEditor.Parent = this.panel1;
                this.TempletEditor.Dock = DockStyle.Fill;
                ((HerenEditor)this.TempletEditor).TextEditor.Zoom = 0.8f;
                ((HerenEditor)this.TempletEditor).TextEditor.Encryption = true;
            }
            else if (SystemParam.Instance.LocalConfigOption.DefaultEditor == SystemData.DefaultEditor.Chenpad)
            {
                this.TempletEditor = new Heren.MedQC.Frame.Document.ChenPadEditor();
                this.TempletEditor.Parent = this.panel1;
                this.TempletEditor.Dock = DockStyle.Fill;
                ((ChenPadEditor)this.TempletEditor).AutoZoom=true;
                ((ChenPadEditor)this.TempletEditor).OpenTemplet(new byte[0]) ;
            }
            if (this.TempletEditor == null)
            {
                MessageBoxEx.ShowMessage("当前编辑器暂不支持元素选择");
                return;
            }
            this.TempletEditor.SelectionChanged +=
                   new EventHandler(this.TempletEditor_SelectionChanged);
            this.TempletEditor.OpenTemplet(new byte[0]);

            this.lblSelectedElement.Text = "请单击需要检索的元素";

            short result = SystemData.ReturnValue.OK;
            byte[] templetData = null;
            if (this.DocTypeInfo != null)
            {
                result = DocTypeAccess.Instance.GetDocTypeData(this.DocTypeInfo.DocTypeID, ref templetData);
                if (result != SystemData.ReturnValue.OK)
                    MessageBoxEx.Show("模板文件下载失败!");
                this.TempletEditor.OpenTemplet(templetData);
            }
            base.OnLoad(e);
        }

        private void TempletEditor_SelectionChanged(object sender, EventArgs e)
        {
            this.lblSelectedElement.Text = "请单击需要检索的元素";

            StructElement selectedElement = this.TempletEditor.GetCurrentElement();
            if (selectedElement != null)
            {
                this.lblSelectedElement.Text = "当前选择的元素：" + selectedElement.ElementName;
                this.SelectedElement = selectedElement;
            }
        }

        public DocTypeInfo DocTypeInfo { get; set; }
        public StructElement SelectedElement { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SelectedElement == null)
            {
                if (MessageBoxEx.ShowConfirm("未选中元素项，确认关闭吗？") != DialogResult.OK)
                {
                    return;
                }
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            //this.Dispose();
        }
    }
}
