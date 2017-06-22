using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMRDBLib;

namespace MedQCSys.Document
{
    public partial class HerenDocumentForm : BaseDocumentForm
    {
        public HerenDocumentForm()
        {
            InitializeComponent();
        }
        public override short OpenDocument(MedDocInfo docInfo)
        {
            return base.OpenDocument(docInfo);
        }
    }
}
