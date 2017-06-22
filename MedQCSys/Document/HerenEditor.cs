using Heren.Common.RichEditor;
using Heren.MedQC.Model.MedDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Frame.Document
{
    public class HerenEditor : DocumentEditor
    {
        private bool m_modified = false;
        private TextEditor m_textEditor = null;
        private float m_zoom;

        public TextEditor TextEditor
        {
            get
            {
                return this.m_textEditor;
            }
        }

        private void TextEditor_ZoomChanged(object sender, EventArgs e)
        {
            if (this.TextEditor != null && this.m_zoom != this.TextEditor.Zoom)
                this.m_zoom = this.TextEditor.Zoom;
            //this.OnZoomChanged();
        }
        
        

        private void TextEditor_SelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged();
        }
        public HerenEditor()
        {

            this.SetStyle(ControlStyles.Selectable, true);

            this.m_textEditor = new TextEditor();
            this.m_textEditor.Dock = DockStyle.Fill;
            this.m_textEditor.Parent = this;
            this.BindingTextEditorEvents();
        }

        private void BindingTextEditorEvents()
        {
            this.m_textEditor.SelectionChanged +=
               new EventHandler(this.TextEditor_SelectionChanged);
        }

        public override bool OpenTemplet(byte[] fileData)
        {
            this.m_modified = false;
            this.m_textEditor.Design = true;
            if (fileData == null || fileData.Length <= 0)
            {
                this.m_textEditor.CreateDocument();
                return true;
            }
            bool result = this.m_textEditor.LoadDocument2(fileData);
            Application.DoEvents();
            return result;
        }
        /// <summary>
        /// 获取当前选中元素
        /// </summary>
        /// <returns></returns>
        public override StructElement GetCurrentElement()
        {
            TextField field = this.m_textEditor.GetCurrentField();
            if (field != null)
            {
                StructElement element = new StructElement();
                element.ElementID = field.ID;
                element.ElementName = field.Name;
                return element;
            }
            return null;
        }

    }
}
