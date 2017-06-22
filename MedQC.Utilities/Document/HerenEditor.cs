using Heren.Common.RichEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Utilities.Document
{
    public class HerenEditor:DocumentEditor
    {
        private bool m_modified = false;
        private TextEditor m_textEditor = null;
        public HerenEditor()
        {
            this.m_textEditor = new TextEditor();
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

    }
}
