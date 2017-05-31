// ***********************************************************
// 护理病历配置管理系统,模板、报表等设计器元素属性编辑窗口.
// Author : YangMingkun, Date : 2012-3-30
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using Heren.Common.DockSuite;
using Heren.Common.Forms.Designer;
 

namespace Designers.Report
{
    public partial class PropertyEditForm : DockContentBase
    {
        internal PropertyEditForm(DesignForm mainForm)
            : base(mainForm)
        {
            this.HideOnClose = true;
            this.ShowHint = DockState.DockRight;
            this.DockAreas = DockAreas.DockLeft | DockAreas.DockRight
                | DockAreas.DockTop | DockAreas.DockBottom;
        }

        public PropertyGrid PropertyGrid
        {
            get { return this.propertyGrid1; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            this.Icon = Designers.Properties.Resources.PropertyIcon;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            if (this.MainForm.ActiveDesign != null)
                this.MainForm.ActiveDesign.PropertyGrid = this.propertyGrid1;
        }

        protected  void OnActiveDocumentChanged()
        {
            base.OnActiveDocumentChanged();
            this.propertyGrid1.SelectedObject = null;
            this.propertyGrid1.SelectedObjects = null;
            if (this.MainForm.ActiveDesign != null)
                this.MainForm.ActiveDesign.PropertyGrid = this.propertyGrid1;
        }
    }
}
