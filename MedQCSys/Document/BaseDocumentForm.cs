using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMRDBLib;
using MedQCSys.DockForms;

namespace MedQCSys.Document
{
    /// <summary>
    /// 病历窗口基类
    /// </summary>
    public partial class BaseDocumentForm : DockContentBase
    {
        public BaseDocumentForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 打开指定的文档
        /// </summary>
        /// <param name="document">文档信息</param>
        /// <returns>SystemConsts.ReturnValue</returns>
        public virtual short OpenDocument(MedDocInfo docInfo)
        {
            return SystemData.ReturnValue.OK;
        }
    }
}
