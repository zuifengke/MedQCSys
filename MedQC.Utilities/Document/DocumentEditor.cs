using Heren.MedQC.Model.MedDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Utilities.Document
{
    public class DocumentEditor:Control
    {

        public event EventHandler SelectionChanged;
        protected virtual void OnSelectionChanged()
        {
            if (this.SelectionChanged != null)
                this.SelectionChanged(this, EventArgs.Empty);
        }
        #region 元素操作
        public virtual StructElement GetCurrentElement()
        {
            return null;
        }

        #endregion
        #region 模板操作
        public virtual bool OpenTemplet(byte[] fileData)
        {
            return false;
        }
        #endregion

    }
}
